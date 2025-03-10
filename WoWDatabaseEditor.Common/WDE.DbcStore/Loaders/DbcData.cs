using System.Collections.Generic;
using WDE.Common.DBC.Structs;
using WDE.Common.Parameters;
using WDE.DbcStore.Structs;

namespace WDE.DbcStore.Loaders;

public class DbcData
{
    public Dictionary<long, string> AreaTriggerStore { get; } = new();
    public Dictionary<long, long> FactionTemplateStore { get; } = new();
    public Dictionary<long, string> FactionStore { get; } = new();
    public Dictionary<long, string> SpellStore { get; } = new();
    public Dictionary<long, string> SkillStore { get; } = new();
    public Dictionary<long, string> LanguageStore { get; } = new();
    public Dictionary<long, string> PhaseStore { get; } = new();
    public Dictionary<long, string> AreaStore { get; } = new();
    public Dictionary<long, string> MapStore { get; } = new();
    public Dictionary<long, string> SoundStore { get; } = new();
    public Dictionary<long, string> MovieStore { get; } = new();
    public Dictionary<long, string> ClassStore { get; } = new();
    public Dictionary<long, string> RaceStore { get; } = new();
    public Dictionary<long, string> EmoteStore { get; } = new();
    public Dictionary<long, string> EmoteOneShotStore { get; } = new();
    public Dictionary<long, string> EmoteStateStore { get; } = new();
    public Dictionary<long, string> TextEmoteStore { get; } = new();
    public Dictionary<long, string> AchievementStore { get; } = new();
    public Dictionary<long, string> ItemStore { get; } = new();
    public Dictionary<long, string> SpellFocusObjectStore { get; } = new();
    public Dictionary<long, string> QuestInfoStore { get; } = new();
    public Dictionary<long, string> CharTitleStore { get; } = new();
    public Dictionary<long, long> CreatureDisplayInfoStore { get; } = new();
    public Dictionary<long, string> CreatureModelDataStore { get; } = new();
    public Dictionary<long, string> GameObjectDisplayInfoStore { get; } = new();
    public Dictionary<long, string> MapDirectoryStore { get; internal set;} = new();
    public Dictionary<long, string> QuestSortStore { get; internal set;} = new();
    public Dictionary<long, string> CurrencyTypeStore { get; internal set;} = new();
    public Dictionary<long, string> ExtendedCostStore { get; internal set;} = new();
    public Dictionary<long, string> TaxiNodeStore { get; internal set;} = new();
    public Dictionary<long, (int, int)> TaxiPathsStore { get; internal set;} = new();
    public Dictionary<long, string> SpellItemEnchantmentStore { get; internal set;} = new();
    public Dictionary<long, string> AreaGroupStore { get; internal set;} = new();
    public Dictionary<long, string> ItemDisplayInfoStore { get; internal set;} = new();
    public Dictionary<long, string> MailTemplateStore { get; internal set;} = new();
    public Dictionary<long, string> LFGDungeonStore { get; internal set;} = new();
    public Dictionary<long, string> ItemSetStore { get; internal set;} = new();
    public Dictionary<long, string> DungeonEncounterStore { get; internal set;} = new();
    public Dictionary<long, string> HolidayNamesStore { get; internal set;} = new();
    public Dictionary<long, string> HolidaysStore { get; internal set;} = new();
    public Dictionary<long, string> WorldSafeLocsStore { get; internal set;} = new();
    public Dictionary<long, string> BattlegroundStore { get; internal set;} = new();
    public Dictionary<long, string> AchievementCriteriaStore { get; internal set;} = new();
    public Dictionary<long, string> ItemDbcStore { get; internal set;} = new(); // item.dbc, not item-sparse.dbc
    public Dictionary<long, string> SceneStore { get; internal set;} = new();
    public Dictionary<long, string> ScenarioStore { get; internal set;} = new();
    public Dictionary<long, string> ScenarioStepStore { get; internal set;} = new();
    public Dictionary<long, string> BattlePetAbilityStore { get; internal set;} = new();
    public Dictionary<long, Dictionary<long, long>> ScenarioToStepStore { get; internal set; } = new();
    public Dictionary<long, long> BattlePetSpeciesIdStore { get; internal set; } = new();
    public Dictionary<long, string> CharSpecializationStore { get; internal set;} = new();
    public Dictionary<long, string> GarrisonClassSpecStore { get; internal set; } = new();
    public Dictionary<long, string> GarrisonBuildingStore { get; internal set; } = new();
    public Dictionary<long, string> GarrisonTalentStore { get; internal set; } = new();
    public Dictionary<long, string> DifficultyStore { get; internal set; } = new();
    public Dictionary<long, string> LockTypeStore { get; internal set; } = new();
    public Dictionary<long, string> VignetteStore { get; internal set; } = new();
    public Dictionary<long, string> AdventureJournalStore { get; internal set; } = new();
    public Dictionary<long, string> WorldMapAreaStore { get; internal set; } = new();

    public List<(string parameter, Dictionary<long, SelectOption> options)> parametersToRegister = new();
    public List<AreaEntry> Areas { get; } = new();
    public List<MapEntry> Maps { get; } = new();
    public List<FactionTemplate> FactionTemplates { get; } = new();
    public List<Faction> Factions { get; } = new();
}