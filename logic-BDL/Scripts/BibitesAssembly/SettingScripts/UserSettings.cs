using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace SettingScripts
{
	public static class UserSettings
	{
		public enum AutoSavePeriods
		{
			OneMinute = 1,
			FiveMinutes = 5,
			TenMinutes = 10,
			ThirtyMinutes = 30,
			OneHour = 60,
			FiveHours = 300,
			TenHours = 600
		}

		public enum ProceduralSizeChoice
		{
			Genetic = 0,
			Maturity = 1,
			Both = 2
		}

		public static BoolUserSetting AutoSave = new BoolUserSetting
		{
			Name = "Autosave",
			key = "AutoSave",
			DefaultValue = true,
			HelperText = "This enables autosaves at regular intervals. It's cumbersome, but it allows you to restore the simulation in the event of a crash."
		};

		public static ChoiceUserSetting<AutoSavePeriods> AutoSavePeriod = new ChoiceUserSetting<AutoSavePeriods>
		{
			Name = "Autosave Period",
			DefaultValue = AutoSavePeriods.TenMinutes,
			HelperText = "The number of minutes between each autosaves."
		};

		public static BoolUserSetting AutoSaveRealTime = new BoolUserSetting
		{
			Name = "Real-time autosave period",
			key = "AutoSaveRealTime",
			DefaultValue = true,
			HelperText = "If enabled, the saves will be taken at each interval period regardless of the in-game time acceleration."
		};

		public static IntUserSetting AutoSaveMaxFiles = new IntUserSetting
		{
			Name = "AutoSave Max Files",
			key = "AutoSaveFiles",
			DefaultValue = 25,
			minValue = 1,
			maxValue = 100,
			canGoOutOfBounds = true,
			HelperText = "The maximum number of individual autosave files. When a new save is created, if the max is reached, the oldest will be deleted."
		};

		public static BoolUserSetting PauseAfterLoad = new BoolUserSetting
		{
			Name = "Pause After Load",
			key = "PauseAfterLoad",
			DefaultValue = false,
			HelperText = "If enabled, the simulation will be paused after loading a save."
		};

		public static BoolUserSetting ReloadAfterAutosaves = new BoolUserSetting
		{
			Name = "Reload After AutoSaves",
			key = "ReloadAfterAutoSaves",
			DefaultValue = false,
			HelperText = "If enabled, the simulation will be reloaded after each autosaves.\nI would like to avoid this, but there are currently some memory leaks I'm trying to fix and this is the best way to prevent them having an impact."
		};

		public static StringUserSetting SavePath = new StringUserSetting
		{
			Name = "Save path",
			key = "SavePath",
			DefaultValue = ""
		};

		public static StringUserSetting SpriteGeneratorSavePath = new StringUserSetting
		{
			Name = "Sprite Generator Save Path",
			key = "SpriteGeneratorSavePath",
			DefaultValue = ""
		};

		public static BoolUserSetting FormatBibiteJSON = new BoolUserSetting
		{
			Name = "Format JSON",
			key = "FormatBibiteJSON",
			DefaultValue = false,
			HelperText = "Should the JSON be formatted so that it's more readable? Doing so will increase it's size."
		};

		public static BoolUserSetting SaveBibiteAsTemplate = new BoolUserSetting
		{
			Name = "Save as template",
			key = "SaveBibiteAsTemplate",
			DefaultValue = false,
			HelperText = "Bibite will be saved as a template, a more optimized file format."
		};

		public static BoolUserSetting ShowPheromones = new BoolUserSetting
		{
			Name = "Show Pheromones",
			key = "ShowPheromones",
			DefaultValue = true,
			HelperText = "This enables whether you see pheromones or not. It's far more visually pleasing when turned on, but you can turn it off if you don't like it or to improve rendering performances."
		};

		public static FloatUserSetting pheromonesStrength = new FloatUserSetting
		{
			Name = "Pheromones Strength",
			key = "PheromonesStrength",
			DefaultValue = 0.1f,
			maxValue = 1f,
			minValue = 0f,
			factor = 100f,
			precision = 0,
			units = "%",
			HelperText = "This determines the amount of pheromones visible. Lowering this will make pheromones less numerous and will thus be less computationally expansive.",
			SI = false
		};

		public static BoolUserSetting AutomaticallyDetectScreenResolution = new BoolUserSetting
		{
			Name = "Automatically Detect Screen Resolution",
			key = "AutomaticallyDetectScreenResolution",
			DefaultValue = true,
			HelperText = "If enabled, the UI Scale will automatically be updated when the screen window changes."
		};

		public static FloatUserSetting ScreenResolutionFactor = new FloatUserSetting
		{
			Name = "Screen Resolution",
			key = "ScreenResolutionFactor",
			DefaultValue = 1f,
			HelperText = "The resolution of your screen.",
			SI = false,
			precision = 2,
			units = "X",
			landmarks = new List<SettingLandmarkValues<float>>
			{
				new SettingLandmarkValues<float>("720p", 0.667f),
				new SettingLandmarkValues<float>("768p", 0.711f),
				new SettingLandmarkValues<float>("900p", 0.833f),
				new SettingLandmarkValues<float>("1080p", 1f),
				new SettingLandmarkValues<float>("1440p", 1.333f),
				new SettingLandmarkValues<float>("4K", 2f)
			}
		};

		public static FloatUserSetting UIScale = new FloatUserSetting
		{
			Name = "UI Scale",
			key = "UIScale",
			DefaultValue = 1f,
			HelperText = "The scale of the UI. This is an experimental feature, might not work properly",
			landmarks = new List<SettingLandmarkValues<float>>
			{
				new SettingLandmarkValues<float>("Smaller (0.5)", 0.5f),
				new SettingLandmarkValues<float>("Small (0.75)", 0.75f),
				new SettingLandmarkValues<float>("Normal (1.0)", 1f),
				new SettingLandmarkValues<float>("Large (1.15)", 1.15f),
				new SettingLandmarkValues<float>("Larger (1.25)", 1.25f)
			}
		};

		public static ColorUserSetting FertilityColor = new ColorUserSetting
		{
			Name = "Fertility Color",
			key = "FertilityColor",
			DefaultValue = new Color(0.04313726f, 0.5019608f, 0f),
			HelperText = "Base color of fertility zones",
			allowAlphaChange = true
		};

		public static ColorUserSetting BackgroundColor = new ColorUserSetting
		{
			Name = "Background Color",
			key = "Background",
			DefaultValue = new Color(0f, 0f, 0.19f, 1f),
			HelperText = "Background color during play",
			allowAlphaChange = false
		};

		public static ColorUserSetting TextureColor = new ColorUserSetting
		{
			Name = "Texture Color",
			key = "TextureColor",
			DefaultValue = new Color(0.1988905f, 0.1988905f, 0.262f, 1f),
			HelperText = "Texture color",
			allowAlphaChange = false
		};

		public static BoolUserSetting ShowTexture = new BoolUserSetting
		{
			Name = "Show Experimental Background",
			key = "ShowTexture",
			DefaultValue = false,
			HelperText = "Experimental background using parallax effect."
		};

		public static BoolUserSetting ShowGrid = new BoolUserSetting
		{
			Name = "Show Grid",
			key = "ShowGrid",
			DefaultValue = false,
			HelperText = "If enabled, a grid will be displayed at regular intervals"
		};

		public static IntUserSetting GridStep1 = new IntUserSetting
		{
			Name = "Fine Grid Step",
			key = "GridStep1",
			DefaultValue = 100,
			maxValue = 1000,
			minValue = 10,
			units = "u",
			HelperText = "Determines the distance between each line of the fine grid."
		};

		public static FloatUserSetting GridLineWidth1 = new FloatUserSetting
		{
			Name = "Fine Grid Line Width",
			key = "GridLineWidth1",
			DefaultValue = 1f,
			maxValue = 10f,
			minValue = 1f,
			units = "u",
			HelperText = "Determines the thickness of line for the fine grid."
		};

		public static ColorUserSetting GridColor1 = new ColorUserSetting
		{
			Name = "Fine Grid Color",
			key = "GridColor1",
			DefaultValue = new Color(1f, 1f, 1f, 0.25f),
			HelperText = "Color of the fine grid lines.",
			allowAlphaChange = true
		};

		public static IntUserSetting GridStep2 = new IntUserSetting
		{
			Name = "Coarse Grid Step Factor",
			key = "GridStep2",
			DefaultValue = 10,
			maxValue = 100,
			minValue = 10,
			HelperText = "Determines the number of fine steps before a coarse step is made"
		};

		public static IntUserSetting GridLineWidth2 = new IntUserSetting
		{
			Name = "Coarse Line Width Factor",
			key = "GridLineWidth2",
			DefaultValue = 5,
			maxValue = 25,
			minValue = 1,
			HelperText = "Determines the thickness of line for the coarse grid. (as a multiple of the fine width)"
		};

		public static ColorUserSetting GridColor2 = new ColorUserSetting
		{
			Name = "Coarse Grid Color",
			key = "GridColor2",
			DefaultValue = new Color(1f, 1f, 1f, 0.4f),
			HelperText = "Color of the coarse grid lines.",
			allowAlphaChange = true
		};

		public static BoolUserSetting Fullscreen = new BoolUserSetting
		{
			Name = "Fullscreen",
			key = "Fullscreen",
			DefaultValue = true,
			HelperText = "Should the game be displayed in fullscreen. Setting this to false sets the game in windowed mode."
		};

		public static ChoiceUserSetting<ProceduralSizeChoice> ProceduralSize = new ChoiceUserSetting<ProceduralSizeChoice>
		{
			Name = "Procedural Size",
			key = "ProceduralSize",
			DefaultValue = ProceduralSizeChoice.Both,
			HelperText = "This changes how the different procedural sprites sizes are switched between. Genetic Size is the best for performances, but is less realistic. Select both for the ideal experience."
		};

		public static BoolUserSetting SortBiologyPanelEnergyDetails = new BoolUserSetting
		{
			key = "SortBiologyPanelEnergyDetails",
			DefaultValue = false
		};

		public static BoolUserSetting ShowFertility = new BoolUserSetting
		{
			Name = "Show Fertility",
			key = "ShowFertility",
			DefaultValue = true,
			HelperText = "This enables whether you see the map's fertility or not."
		};

		public static BoolUserSetting ShowRuler = new BoolUserSetting
		{
			Name = "Show Ruler",
			key = "ShowRuler",
			DefaultValue = true,
			HelperText = "This enables whether you see the ruler."
		};

		public static BoolUserSetting ShowStatusBars = new BoolUserSetting
		{
			Name = "Show Status Bars",
			key = "ShowStatusBars",
			DefaultValue = false,
			HelperText = "This enables whether you see the status bars over a selected bibite or not."
		};

		public static BoolUserSetting ShowNodeNames = new BoolUserSetting
		{
			Name = "Show Node Names",
			key = "ShowNodeName",
			DefaultValue = false,
			HelperText = "If enabled, names of each nodes will be displayed over it. Can get messy, so disabled by default"
		};

		public static BoolUserSetting ShowNodeValues = new BoolUserSetting
		{
			Name = "Show Node Values",
			key = "ShowNodeValues",
			DefaultValue = false,
			HelperText = "If enabled, the output value of each nodes will be displayed over it."
		};

		public static BoolUserSetting ShowBibiteFOW = new BoolUserSetting
		{
			Name = "Show Selected Bibite Field Of View",
			key = "ShowBibiteFOW",
			DefaultValue = true,
			HelperText = "If enabled, you will see the field of view of the bibite you will have selected"
		};

		public static BoolUserSetting ShowBibiteTargets = new BoolUserSetting
		{
			Name = "Show Targets Priority of Selected Bibite",
			key = "ShowBibiteTargets",
			DefaultValue = false,
			HelperText = "If enabled, you will see the weights of the different target a bibite is seeing, and how much it influence the vision inputs of the bibite."
		};

		public static BoolUserSetting showBrainDifferences = new BoolUserSetting
		{
			Name = "Show Difference",
			key = "showBrainDifferences",
			DefaultValue = false,
			HelperText = "If enabled, you will see the weights of the different target a bibite is seeing, and how much it influence the vision inputs of the bibite."
		};

		public static BoolUserSetting AllowEasterEggs = new BoolUserSetting
		{
			Name = "Allow Easter Eggs",
			key = "AllowEasterEggs",
			HelperText = "Easter eggs are rare special bibites that can sometime spawn and have a significant impact in your sim. Turn this off if you don't want that to happen.",
			DefaultValue = false
		};

		public static IntUserSetting EasterEggsProbability = new IntUserSetting
		{
			Name = "Easter Eggs Probability Period",
			HelperText = "How many eggs, on average, will have to be laid between each easter egg. The frequency is 1/x, where x is this number.",
			key = "EasterEggsProbability",
			DefaultValue = 500000,
			minValue = 1,
			maxValue = 100000000,
			precision = 0,
			SI = true
		};

		public static FloatUserSetting SpeciesSpanPreference = new FloatUserSetting
		{
			Name = "Genetic Distance Preference",
			key = "GeneticDistancePreference",
			DefaultValue = 3f
		};

		public static FloatUserSetting SpeciesSpanScalingFactorPreference = new FloatUserSetting
		{
			Name = "Species Span Scaling Factor Preference",
			key = "SpeciesSpanScalingFactorPreference",
			DefaultValue = 0.05f
		};

		public static BoolUserSetting PreventSleep = new BoolUserSetting
		{
			Name = "Prevent OS Sleep",
			key = "PreventSleep",
			HelperText = "When enabled, this prevents your computer from falling in sleep mode, or automatically shutting down (although the OS still get the last call)",
			DefaultValue = true
		};

		public static IntUserSetting simTPSDefault = new IntUserSetting
		{
			key = "simTPSDefault",
			DefaultValue = 40
		};

		public static IntUserSetting brainTPSDefault = new IntUserSetting
		{
			key = "brainTPSDefault",
			DefaultValue = 2
		};

		public static IntUserSetting decayTPSDefault = new IntUserSetting
		{
			key = "decayTPSDefault",
			DefaultValue = 2
		};

		public static IntUserSetting visionLookupTPSDefault = new IntUserSetting
		{
			key = "visionLookupTPSDefault",
			DefaultValue = 10
		};

		public static IntUserSetting visionSensesTPSDefault = new IntUserSetting
		{
			key = "visionSensesTPSDefault",
			DefaultValue = 5
		};

		public static BoolUserSetting allowArrowKeyCameraControl = new BoolUserSetting
		{
			Name = "Allow Arrow Key",
			key = "AllowArrowKeyCameraControl",
			HelperText = "Allows the arrow key to move the camera.\r\nDisabled by default because it caused some users' camera to drift away.",
			DefaultValue = true
		};

		public static BoolUserSetting OpenZoneEditorOnSelect = new BoolUserSetting
		{
			Name = "Open Zone Editor On Select",
			key = "OpenZoneEditorOnSelect",
			HelperText = "If enabled, this will open the zone editor when a zone is selected (when pressing Z)",
			DefaultValue = true
		};

		public static IntUserSetting minimumFPS = new IntUserSetting
		{
			Name = "Minimum FPS",
			key = "MinimumFPS",
			HelperText = "The minimum FPS target the game will try to maintain. A value of 0 means no minimum.",
			DefaultValue = 15,
			maxValue = 120,
			minValue = 0
		};

		public static BoolUserSetting ignoreMinOnUnfocus = new BoolUserSetting
		{
			Name = "Ignore FPS minimum When Unfocused",
			key = "ignoreMinOnUnfocus",
			HelperText = "If enabled, the FPS minimum will only be applied when the application is focused.",
			DefaultValue = false
		};

		public static BoolUserSetting FirstTimeBeingOpened = new BoolUserSetting
		{
			key = "FirstTimeBeingOpened",
			DefaultValue = true
		};

		private static StringUserSetting SavedVersionOnLastOpen = new StringUserSetting
		{
			key = "VersionOnLastOpen",
			DefaultValue = "0.0"
		};

		public static BoolUserSetting AskedForAnalyticsConsent = new BoolUserSetting
		{
			key = "AskedForAnalyticsConsent",
			DefaultValue = false
		};

		public static BoolUserSetting AnalyticsConsent = new BoolUserSetting
		{
			Name = "Analytics Consent",
			key = "AnalyticsConsent",
			DefaultValue = false,
			HelperText = "When this is enabled, some hand-picked data and interactions will automatically be sent to Unity's servers. Only The Bibites Devs have to capacity to review this information and this would not allow anyone to spy on you.\n The aim of this is to eventually be able to use The Bibites project as a research platform, agglomerating everyone's simulations to have a better picture of the large-scale dynamics at play."
		};

		public static BoolUserSetting AskedForCloudDiagnosticConsent = new BoolUserSetting
		{
			key = "AskedForCloudDiagnosticConsent",
			DefaultValue = false
		};

		public static BoolUserSetting CloudDiagnosticConsent = new BoolUserSetting
		{
			Name = "Cloud Diagnostic Consent",
			key = "CloudDiagnosticConsent",
			DefaultValue = false,
			HelperText = "When this is enabled, the errors and crashes you experience will automatically be sent to Unity's servers as well as some minor contextual data. Only The Bibites Devs have to capacity to review this information and this would not allow anyone to spy on you."
		};

		public static BoolUserSetting IncludeAutoSavesInLoadPanel = new BoolUserSetting
		{
			Name = "Include autosaves",
			key = "IncludeAutoSavesInLoadPanel",
			DefaultValue = false
		};

		public static BoolUserSetting WarnBeforeDeletingSaves = new BoolUserSetting
		{
			Name = "Warn Before SaveFile Deletion",
			key = "WarnBeforeDeletingSaves",
			DefaultValue = false
		};

		public static float totalUIScale => ScreenResolutionFactor.val * UIScale.val;

		public static Version versionOnLastOpen
		{
			get
			{
				return Version.Parse(SavedVersionOnLastOpen.val);
			}
			set
			{
				SavedVersionOnLastOpen.SetValue(value.ToString());
			}
		}
	}
}
