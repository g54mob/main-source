using UnityEngine;

namespace ModApi
{
	public class Constants
	{
		public static class Colors
		{
			public class CommonColor
			{
				public Color Gamma { get; private set; }

				public Color32 Gamma32 { get; private set; }

				public Color Linear { get; private set; }

				public Color32 Linear32 { get; private set; }

				public CommonColor(Color color)
				{
					SetWithGamma(color);
				}

				public void SetWithGamma(Color color)
				{
					Gamma = color;
					Gamma32 = Gamma;
					Linear = color.linear;
					Linear32 = Linear;
				}

				public void SetWithLinear(Color color)
				{
					Linear = color;
					Linear32 = Linear;
					Gamma = color.gamma;
					Gamma32 = Gamma;
				}
			}

			public static readonly CommonColor Complementary = new CommonColor(new Color32(byte.MaxValue, 174, 0, byte.MaxValue));

			public static readonly CommonColor Primary = new CommonColor(new Color32(0, 218, 232, byte.MaxValue));

			public static readonly CommonColor Selected = new CommonColor(new Color32(0, 218, 232, byte.MaxValue));
		}

		public static class ControlAxisNames
		{
			public const string Brake = "Brake";

			public const string CycleTargetingMode = "CycleTargetingMode";

			public const string FireGuns = "FireGuns";

			public const string FireWeapons = "FireWeapons";

			public const string LandingGear = "LandingGear";

			public const string NextTarget = "NextTarget";

			public const string NextWeapon = "NextWeapon";

			public const string Pitch = "Pitch";

			public const string PreviousTarget = "PreviousTarget";

			public const string PreviousWeapon = "PreviousWeapon";

			public const string Roll = "Roll";

			public const string Slider1 = "Slider1";

			public const string Slider2 = "Slider2";

			public const string Slider3 = "Slider3";

			public const string Slider4 = "Slider4";

			public const string Throttle = "Throttle";

			public const string ToggleActivationPanel = "ToggleActivationPanel";

			public const string Yaw = "Yaw";
		}

		public static class PartStyles
		{
			public const int MaxSubmeshCount = 5;

			public const int MaxSubpartCount = 3;
		}

		public static class Paths
		{
			public static class Resources
			{
				public const string CareerFolder = "Career/";

				public const string ContractsFolder = "Contracts/";

				public const string ContractsAddedFolder = "ExtraContracts/";

				public const string CareerImagesFolder = "Images/";

				public const string CareerCraftsFolder = "Crafts/";

				public const string CareerPayloadsFolder = "Payloads/";

				public const string CareerFile = "Career.xml";

				public const string CustomersFile = "Customers.xml";

				public const string ContractLocations = "ContractLocations.xml";

				public const string CraftFolder = "Craft/";

				public const string CraftThemesFile = "Craft/CraftThemes";

				public const string ExplorationFile = "Exploration.xml";

				public const string LaunchLocations = "LaunchLocations.xml";

				public const string LevelsFolder = "Levels/";

				public const string Mfd = "Craft/Parts/Mfd/";

				public const string MilestonesFile = "Milestones.xml";

				public const string PartsFolder = "Craft/Parts/";

				public const string PropulsionDataFile = "Craft/Parts/Propulsion";

				public const string SoundsFolder = "Audio/Sounds/";

				public const string StarterPlanetsFolder = "PlanetStudio/StarterPlanets/";

				public const string TechTreeFile = "TechTree.xml";

				public const string VizzyToolboxFile = "Ui/Xml/Vizzy/VizzyToolbox";
			}

			public const string FlightStatesFolder = "GameData/FlightStates/";

			public const string GameDataFolder = "GameData/";

			public const string GameStatesFolder = "UserData/GameStates/";

			public const string LegacySolarSystemsGameDataFolder = "GameData/SolarSystems/";

			public const string LegacySolarSystemsUserDataFolder = "UserData/SolarSystems/";

			public const string LevelFolder = "UserData/Levels/";

			public const string LevelScoresFolder = "UserData/Levels/Scores/";

			public const string PartIconFolder = "GameData/Parts/Icons/";

			public const string PhotoLibraryFolder = "UserData/PhotoLibrary/";

			public const string UserCraftDesignsFolder = "UserData/CraftDesigns/";

			public const string UserDataFolder = "UserData/";

			public const string UserFlightProgramsFolder = "UserData/FlightPrograms/";

			public const string UserSubassembliesFolder = "UserData/Subassemblies/";
		}

		public static class PlanetCubemapSize
		{
			public const int VeryLow = 64;

			public const int Low = 128;

			public const int Medium = 256;

			public const int High = 512;

			public const int VeryHigh = 1024;

			public const int Ultra = 2048;

			public const int UltraPro = 4096;

			public const int MegaUltraPro = 8192;
		}

		public static class Rendering
		{
			public const int TransparentRenderQueue = 3000;

			public static readonly Color AmbientLightInSpace = new Color32(60, 60, 60, byte.MaxValue);
		}

		public static class UI
		{
			public static Vector2 ReferenceResolution { get; } = new Vector2(1920f, 1080f);
		}

		public const float AttachPointOverlapSphereRadius = 1f / 32f;

		public const float AttachPointRadius = 0.25f;

		public const int CameraFieldOfViewMax = 120;

		public const int CameraFieldOfViewMin = 20;

		public const string CustomThemeName = "Custom";

		public const float DefaultAtmosphereRenderingScale = 1.025f;

		public const string DefaultCompanyName = "Simple Aerospace, Inc";

		public const float DefaultDopplarLevel = 0.1f;

		public const string DefaultLegacySolarSystemId = "__default__";

		public const double DefaultStructureLoadDistance = 100000.0;

		public const double DefaultSurfaceLockAltitude = 20000.0;

		public const string DegreeSymbol = "°";

		public const float DoubleClickTime = 0.5f;

		public const float DragForceScale = 0.875f;

		public const float EarthGravity = 9.80665f;

		public const float FuelEpsilon = 0.0001f;

		public const double GravitationConstant = 6.67384E-11;

		public const float GridUnit = 0.25f;

		public const string HomePlanetName = "Droo";

		public const float InitialRigidBodyAngularDrag = 0.05f;

		public const string JunoSystemAliasId = "__StockJuno__";

		public const float MassScale = 0.01f;

		public const float MassScaleInv = 100f;

		public const int MaxActivationGroups = 20;

		public const float MaxRaycastDistance = 10000f;

		public const int MaxStages = 100;

		public const int MaxUndoSteps = 100;

		public const float MinBodyMass = 0.005f;

		public const int NumActivationGroups = 10;

		public const float PartTemperature = 288.706f;

		public const int RenderQueueBeforeDepthMask = 1990;

		public const int RenderQueueMfdUI = 2999;

		public const double ScaledSpaceScale = 0.0001;

		public const double SpaceTemperature = 2.0;

		public const double StefanBoltzmann = 5.670374392252597E-08;

		public const float UiSoundVolume = 1f;

		public const double UnifiedAtomicMassToKg = 1.66E-27;

		public const float WaterDensity = 1000f;

		public const float WingThickness = 0.1f;
	}
}
