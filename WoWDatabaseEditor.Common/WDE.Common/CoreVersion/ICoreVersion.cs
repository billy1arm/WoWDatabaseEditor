﻿using System;
using System.Collections.Generic;
using WDE.Common.Database;
using WDE.Common.Types;
using WDE.Module.Attributes;

namespace WDE.Common.CoreVersion
{
    [NonUniqueProvider]
    public interface ICoreVersion
    {
        string Tag { get; }
        string FriendlyName { get; }
        ImageUri Icon { get; }
        IDatabaseFeatures DatabaseFeatures { get; }
        ISmartScriptFeatures SmartScriptFeatures { get; }
        IConditionFeatures ConditionFeatures { get; }
        IGameVersionFeatures GameVersionFeatures { get; }
        IEventAiFeatures EventAiFeatures { get; }
        bool SupportsRbac => true;
        bool SupportsSpecialCommands => false;
        bool SupportsReverseCommands => false;
        bool SupportsEventScripts => false;
        PhasingType PhasingType { get; }
        GameVersion Version { get; }
        // todo: this can be moved to settings as a configurable option
        IEnumerable<(string id, bool enabled)> TopBarQuickTableEditors => Array.Empty<(string, bool)>();
    }

    public struct GameVersion
    {
        public GameVersion(int major, int minor, int patch, int build)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
            Build = build;
        }

        public int Major { get; }
        public int Minor { get; }
        public int Patch { get; }
        public int Build { get; }
    }

    public enum PhasingType
    {
        NoPhasing,
        PhaseMasks,
        PhaseIds
    }
    
    public interface IGameVersionFeatures
    {
        CharacterRaces AllRaces { get; }
        CharacterClasses AllClasses { get; }
    }

    public interface IConditionFeatures
    {
        string ConditionsFile { get; }
        string ConditionGroupsFile { get; }
        string ConditionSourcesFile { get; }
    }

    [Flags]
    public enum WaypointTables
    {
        WaypointData = 0x1,  // waypoint_data
        SmartScriptWaypoint = 0x2, // waypoints
        ScriptWaypoint = 0x4, // script_waypoint
        MangosWaypointPath = 0x8, // waypoint_path
        MangosCreatureMovement = 0x16 // creature_movement(_template)
    }
    
    public interface IDatabaseFeatures
    {
        ISet<Type> UnsupportedTables { get; }
        bool AlternativeTrinityDatabase { get; }
        bool HasAiEntry => false;
        WaypointTables SupportedWaypoints { get; }
        bool SpawnGroupTemplateHasType { get; }
    }

    public interface IEventAiFeatures
    {
        string? ActionsPath => null;
        string? EventsPath => null;
        string? EventGroupPath => null;
        string? ActionGroupPath => null;
        bool IsSupported => false;
    }

    public interface ISmartScriptFeatures
    {
        ISet<SmartScriptType> SupportedTypes { get; }
        bool SupportsCreatingTimedEventsInsideTimedEvents => false;
        bool ProposeSmartScriptOnMainPage => true;
        bool SupportsConditionTargetVictim => false;
        string CreatureSmartAiName => "SmartAI";
        string GameObjectSmartAiName => "SmartGameObjectAI";

        string? ForceLoadTag => null;
        string TableName { get; }

        string? ActionsPath => null;
        string? EventsPath => null;
        string? TargetsPath => null;
        string? ActionGroupPath => null;
        string? EventGroupPath => null;
        string? TargetGroupPath => null;
    }
}