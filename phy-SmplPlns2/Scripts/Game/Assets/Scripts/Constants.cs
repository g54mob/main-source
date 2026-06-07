using System;
using UnityEngine;

namespace Assets.Scripts
{
	public static class Constants
	{
		public static class Airfoils
		{
			public const string FlatBottom = "Flat Bottom";

			public const string SemiSymmetric = "Semi-Symmetric";

			public const string Symmetric = "Symmetric";
		}

		public static class Colors
		{
			public static Color AxisForward => new Color32(0, 101, 254, byte.MaxValue);

			public static Color AxisRight => new Color32(219, 62, 29, byte.MaxValue);

			public static Color AxisUp => new Color32(0, 254, 0, byte.MaxValue);

			public static Color DangerColor => new Color32(220, 53, 69, byte.MaxValue);

			public static Color HighlightColor => new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);

			public static Color Primary => new Color32(40, 89, 158, byte.MaxValue);

			public static Color PrimaryLight => new Color32(48, 107, 190, byte.MaxValue);

			public static Color Symmetric => new Color32(66, 189, 166, byte.MaxValue);

			public static Color WarningColor => new Color32(byte.MaxValue, 174, 0, byte.MaxValue);
		}

		public static class ControlAxisNames
		{
			public const string Brake = "Brake";

			public const string CycleTargetingMode = "CycleTargetingMode";

			public const string Disabled = "Disabled";

			public const string FireGuns = "FireGuns";

			public const string FireWeapons = "FireWeapons";

			public const string Flaps = "Flaps";

			public const string LandingGear = "LandingGear";

			public const string NextTarget = "NextTarget";

			public const string NextWeapon = "NextWeapon";

			public const string Pitch = "Pitch";

			public const string PreviousTarget = "PreviousTarget";

			public const string PreviousWeapon = "PreviousWeapon";

			public const string Roll = "Roll";

			public const string Throttle = "Throttle";

			public const string ToggleActivationPanel = "ToggleActivationPanel";

			public const string Trim = "Trim";

			public const string Vtol = "VTOL";

			public const string Yaw = "Yaw";
		}

		public static class EngineTypes
		{
			public const string AfterburningTurbojet = "AfterburningTurbojet";

			public const string PropEngine = "Prop";

			public const string Turbofan = "Turbofan";

			public const string Turbojet = "Turbojet";
		}

		public static class FuselageCornerTypes
		{
			public const int Circular = 3;

			public const int Curved = 2;

			public const int Hard = 0;

			public const int Smooth = 1;
		}

		public static class Gui
		{
			public class Names
			{
				public const string ControlSurfaceEditShapeButtonName = "ControlSurfaceEditShapeButton";

				public const string ControlSurfaceInvertButtonName = "ControlSurfaceInvertButton";

				public const string ControlSurfaceTrimButtonName = "ControlSurfaceTrimButton";

				public const string ControlSurfaceTypeButtonName = "ControlSurfaceTypeButton";

				public const string DeleteControlSurfaceButtonName = "DeleteControlSurfaceButton";
			}
		}

		public static class Levels
		{
			public const string LevelBombTraining = "LevelBombTraining";

			public const string LevelDogfight = "LevelDogfight";

			public const string LevelGoingTheDistance = "LevelGoingTheDistance";

			public const string LevelGunTraining = "LevelGunTraining";

			public const string LevelMaxGroundSpeed = "LevelMaxGroundSpeed";

			public const string LevelMissileTraining = "LevelMissileTraining";

			public const string LevelOceanview = "RaceOceanview";

			public const string LevelParadise = "LevelParadise";

			public const string LevelRaceAdrenaline = "RaceAdrenaline";

			public const string LevelRaceAi = "LevelRaceAi";

			public const string LevelRaceArctic = "RaceArctic";

			public const string LevelRaceBridge = "RaceBridge";

			public const string LevelRaceCarPark = "RaceCarPark";

			public const string LevelRaceCarWright = "RaceCarWright";

			public const string LevelRaceCorkscrew = "RaceCorkscrew";

			public const string LevelRaceDaredevil = "RaceDaredevil";

			public const string LevelRaceDesert = "RaceDesert";

			public const string LevelRaceGlider = "RaceGlider";

			public const string LevelRaceLoop = "RaceLoop";

			public const string LevelRaceLunarArc = "RaceLunarArc";

			public const string LevelRaceMirage = "RaceMirage";

			public const string LevelRacePylon = "RacePylon";

			public const string LevelRaceSkyParkPylons = "RaceSkyParkPylons";

			public const string LevelRaceTrenchCircuit = "RaceTrenchCircuit";

			public const string LevelRaceTrenchPylon = "RaceRaceTrenchPylon";

			public const string LevelRaceTundra = "RaceTundra";

			public const string LevelRaceVortex = "RaceVortex";

			public const string LevelRocketTraining = "LevelRocketTraining";

			public const string LevelSamEvasion = "SamEvasion";

			public const string LevelShortLanding = "LevelShortLanding";

			public const string LevelShortTakeOff = "LevelShortTakeOff";

			public const string LevelTrenchRun = "RaceTrenchRun";

			public const string Sandbox = "LevelSandbox";

			public const string TutorialFirstSolo = "TutFirstSolo";

			public const string TutorialLanding = "TutLanding";

			public const string TutorialTakeOff = "TutTakeOff";
		}

		public static class ModifierNames
		{
			public const string ControlSurface = "ControlSurface";

			public const string Engine = "Engine";

			public const string Rotor = "RotorBase";

			public const string RotorMainShaft = "RotorMainShaft";

			public const string Wheel = "Wheel";

			public const string Wing = "Wing";
		}

		public static class Multiplayer
		{
			public const float LoadCraftCooldown = 5f;
		}

		public static class PartNames
		{
			public const string Engine = "Engine";

			public const string FuelTank = "FuelTank";

			public const string Inlet = "Inlet";

			public const string Pylon = "Pylon";

			public const string RotorMainShaft = "RotorMainShaft";

			public const string ThrustPort = "ThrustPort";

			public const string Wing = "Wing";
		}

		public static class ResourcePaths
		{
			public const string DiscoverableImages = "Flight/Discoverable/Pictures/";

			public const string Sound = "Sound/";
		}

		public static class Scenes
		{
			public const string Designer = "Designer";

			public const string LevelMenu = "MainMenu";

			public const string LevelMenuVR = "LevelMenuVR";

			public const string SelectOpponentDogfightMenu = "SelectOpponentDogfightMenu";

			public const string SelectOpponentRacingMenu = "SelectOpponentRacingMenu";

			public const string Startup = "Startup";

			public const string Terrain = "Terrain";

			public const string Training = "Training";

			public const string Transition = "Transition";

			public static bool SupportsNonVR(string sceneName)
			{
				switch (sceneName)
				{
				default:
					return sceneName == "Training";
				case "Designer":
				case "MainMenu":
				case "SelectOpponentDogfightMenu":
				case "SelectOpponentRacingMenu":
				case "Startup":
				case "Transition":
				case "Terrain":
					return true;
				}
			}

			public static bool SupportsVR(string sceneName)
			{
				switch (sceneName)
				{
				default:
					return sceneName == "Terrain";
				case "Startup":
				case "Transition":
				case "LevelMenuVR":
					return true;
				}
			}
		}

		public static class Tags
		{
			public const string MainLights = "MainLights";

			public const string OrthoLights = "OrthoLights";
		}

		public const string AircraftIdOverridePlayerPrefsKey = "AircraftLoadOverride";

		public const string AircraftThemesFileName = "AircraftThemes.xml";

		public const bool AllowBreakOnRigidBodyBoundary = true;

		public const string BlueprintsFolderName = "Blueprints";

		public const string BlueprintsSettingsFileName = "Blueprints/config.xml";

		public const string CloudSettingsFileName = "CloudSettings.xml";

		public const string CraftInstructionsVisibleKey = "CraftInstructionsVisible";

		public const string CustomThemeName = "Custom";

		public const float DefaultDopplarLevel = 0.25f;

		public const float DefaultMaxAngularVelocity = 10f;

		public const string DefaultThemeName = "Default";

		public const string DesignerPartsFileName = "DesignerParts.xml";

		public const float DragForceScale = 0.875f;

		public const float DragScale = 1.25f;

		public const float EarthGravity = 9.81f;

		public const string EditorAircraftId = "__editor__.xml";

		public const float FeetToMeters = 0.3048f;

		public const float GridUnit = 0.25f;

		public const float HoverSoundDelay = 0.05f;

		public const float InitialRigidBodyAngularDrag = 0.05f;

		public const float IRSignatureScaleAfterburner = 10f;

		public const float IRSignatureScaleJet = 1f;

		public const float IRSignatureScaleProp = 0.1f;

		public const string LevelsFileName = "Levels.xml";

		public const float MassScale = 0.01f;

		public const float MetersToFeet = 3.28084f;

		public const float MilesPerHourToMetersPerSecond = 0.44704f;

		public const string NewAircraftId = "__new__";

		public const int NumActivationGroups = 8;

		public const string PlayerVRCraftID = "__vrPlayer__.xml";

		public const int RenderQueueBeforeDepthMask = 1990;

		public const float RPMToRadSec = MathF.PI / 30f;

		public const float SpeedOfSoundAtSeaLevel = 340.29f;

		public const string SubassembliesFileName = "SubAssemblies.xml";

		public const string SubassembliesFolderName = "SubAssemblies";

		public const string SubassembliesUpgradedFileName = "SubAssemblies.xml.bak";

		public const string TrainierAircraftId = "__trainer__";

		public const float WingThickness = 0.1f;

		public static Color FocusButtonColor => new Color32(128, 128, 160, byte.MaxValue);

		public static Color ResetButtonColor => new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
	}
}
