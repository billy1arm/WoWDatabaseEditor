using System.Threading.Tasks;
using Avalonia;
using AvaloniaStyles.Controls.FastTableView;
using Prism.Ioc;
using WDE.Common.Avalonia.Utils;
using WDE.Common.Parameters;
using WDE.Common.Utils;
using WDE.DatabaseEditors.Avalonia.Views.Common;
using WDE.DatabaseEditors.Models;
using WDE.DatabaseEditors.ViewModels;
using WDE.DatabaseEditors.ViewModels.MultiRow;

namespace WDE.DatabaseEditors.Avalonia.Views.MultiRow;

public class CustomCellInteractor : SingleRow.CustomCellDrawerInteractorBase, ICustomCellInteractor
{
    private IParameterPickerService ParameterPickerService => ViewBind.ContainerProvider.Resolve<IParameterPickerService>();
    private PhantomFlagsComboBox flagPicker = new();
    private PhantomCompletionComboBox comboBox = new();
    private PhantomTextBox textBox = new();

    public bool SpawnEditorFor(string? initialText, Visual parent, Rect rect, ITableCell c)
    {
        if (c is not DatabaseCellViewModel cell)
            return false;

        if (cell.ActionCommand != null)
        {
            if (cell.ActionCommand.CanExecute(cell))
                cell.ActionCommand.Execute(cell);
            return true;
        }

        var context = (parent.DataContext as ITableContext)!;
        
        if (initialText != null)
            return false; // then use builtin-text editor

        var longValue = cell.ParameterValue as IParameterValue<long>;
        if (cell.UseFlagsPicker && longValue != null)
        {
            flagPicker.Spawn(parent, rect, longValue, context, cell.DbColumnName!);
            return true;
        }
        if (cell.UseItemPicker)
        {
            comboBox.Spawn(parent, rect, cell, context, cell.DbColumnName!);
            return true;
        }
        // if (cell.HasItems && longValue != null)
        // {
        //     Pick(longValue).ListenErrors();
        //     return true;
        // }

        return false;
    }

    public bool PointerDown(ITableCell c, Rect cellRect, Point mouse, bool leftButton, bool rightButton, int clickCount)
    {
        if (c is not DatabaseCellViewModel cell)
            return false;
        
        return false;
    }
    
    public bool PointerUp(ITableCell c, Rect cellRect, Point mouse, bool leftButton, bool rightButton)
    {
        if (c is not DatabaseCellViewModel cell)
            return false;

        var threeDots = GetThreeDotRectForCell(cellRect);
        if (leftButton && threeDots.Deflate(3).Contains(mouse) && cell.HasItems && !cell.UseItemPicker && !cell.UseFlagsPicker)
        {
            switch (cell.ParameterValue)
            {
                case IParameterValue<long> longValue:
                    Pick(longValue).ListenErrors();
                    break;
                case IParameterValue<string> stringValue:
                    Pick(stringValue).ListenErrors();
                    break;
            }
        }
        
        if (leftButton && cell.ActionCommand != null && cell.ActionCommand.CanExecute(cell))
        {
            cell.ActionCommand.Execute(cell);
            return true;
        }
        
        return false;
    }

    private async Task Pick<T>(IParameterValue<T> parameter) where T : notnull
    {
        var (value, ok) = await ParameterPickerService.PickParameter<T>(parameter.Parameter, parameter.Value!, parameter.Context);
        if (ok)
            parameter.Value = value;
    }
}