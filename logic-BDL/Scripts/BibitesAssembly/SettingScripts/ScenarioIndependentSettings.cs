using System.Collections.Generic;

namespace SettingScripts
{
	public class ScenarioIndependentSettings
	{
		public enum VirginBibiteTagType
		{
			Untagged = 0,
			UniformTag = 1,
			UniqueTag = 2
		}

		public static ScenarioIndependentSettings Instance = new ScenarioIndependentSettings();

		public FloatSetting SimulationSize = new FloatSetting
		{
			Name = "Size of the Simulation Area",
			HelperText = "Defines the size of the simulation. From the center, the simulation expends in every cardinal direction by this length. A bibite is usually approximately 10u long.",
			WikiLink = "Simulation_Size",
			DefaultValue = 2000f,
			val = 2000f,
			minValue = 100f,
			maxValue = 20000f,
			precision = 2,
			units = " u",
			canGoOutOfBounds = true,
			landmarks = new List<SettingLandmarkValues<float>>
			{
				new SettingLandmarkValues<float>("Smallest", 1000f),
				new SettingLandmarkValues<float>("Small", 1500f),
				new SettingLandmarkValues<float>("Normal", 2000f),
				new SettingLandmarkValues<float>("Bigger", 3500f),
				new SettingLandmarkValues<float>("Large", 5000f),
				new SettingLandmarkValues<float>("Larger", 7500f),
				new SettingLandmarkValues<float>("Enormous", 10000f),
				new SettingLandmarkValues<float>("Gigantic", 15000f)
			}
		};

		public FloatSetting biomassDensity = new FloatSetting
		{
			Name = "Global Biomass Density",
			HelperText = "Defines the default amount of biomass per unit of fertile area. Biomass is used to spawn pellets and a high biomass density usually means a high number of max plant pellets.",
			WikiLink = "Biomass_Density",
			DefaultValue = 0.0075f,
			val = 0.0075f,
			minValue = 0f,
			maxValue = 1f,
			precision = 1,
			factor = 1000f,
			units = " E/u²",
			landmarks = new List<SettingLandmarkValues<float>>
			{
				new SettingLandmarkValues<float>("Barren", 0.00075f),
				new SettingLandmarkValues<float>("Sparser", 0.001f),
				new SettingLandmarkValues<float>("Sparse", 0.0025f),
				new SettingLandmarkValues<float>("Low", 0.005f),
				new SettingLandmarkValues<float>("Normal", 0.0075f),
				new SettingLandmarkValues<float>("High", 0.0125f),
				new SettingLandmarkValues<float>("Dense", 0.025f),
				new SettingLandmarkValues<float>("Denser", 0.05f),
				new SettingLandmarkValues<float>("Packed", 0.1f)
			}
		};

		public FloatSetting pelletGrowth = new FloatSetting
		{
			Name = "Global Fertility",
			HelperText = "Defines the amount of energy that gets spawned each seconds per unit of fertile area. Correlated with how many bibites the simulation can sustain simultaneously.",
			WikiLink = "Fertility",
			DefaultValue = 1E-05f,
			val = 1E-05f,
			minValue = 0f,
			maxValue = 0.0005f,
			factor = 1000000f,
			precision = 1,
			units = " E/u²s",
			landmarks = new List<SettingLandmarkValues<float>>
			{
				new SettingLandmarkValues<float>("Sterile", 0f, "No Growth at all (or very close to none)"),
				new SettingLandmarkValues<float>("Arid", 1E-06f),
				new SettingLandmarkValues<float>("Low", 3.5E-06f),
				new SettingLandmarkValues<float>("Normal", 1E-05f),
				new SettingLandmarkValues<float>("High", 2E-05f),
				new SettingLandmarkValues<float>("Lush", 5E-05f),
				new SettingLandmarkValues<float>("Overgrown", 0.0001f)
			}
		};

		public BoolSetting limitBibiteBirth = new BoolSetting
		{
			Name = "Limit Bibite Birth",
			HelperText = "This is similar to the virgin cap, as it will prevent virgin bibites being spawned (the smallest of the two will be respected), but this also prevents new eggs from being laid when a certain number of bibite is reached.\nIn general try keeping this value lower than the virgin spawn cap.\n\nThe Minimum settings on virgin bibites templates will ignore this and takes precedence.",
			WikiLink = "Virgin_Bibites_Spawn",
			DefaultValue = false,
			val = false
		};

		public IntSetting bibiteLimit = new IntSetting
		{
			Name = "Bibite Limit",
			HelperText = "Number of bibites where birth stops.",
			WikiLink = "Virgin_Bibites_Spawn",
			DefaultValue = 100,
			val = 100,
			minValue = 0,
			maxValue = 500,
			units = ""
		};

		public FloatSetting virginSpawnRate = new FloatSetting
		{
			Name = "Bibite Spawning Rate",
			HelperText = "Number of 'virgin' bibites that are spawned each seconds.",
			WikiLink = "Bibite_Spawn_Rate",
			DefaultValue = 1f,
			val = 1f,
			minValue = 0f,
			maxValue = 5f,
			precision = 2,
			units = "Hz"
		};

		public FloatSetting speciesGeneticSpan = new FloatSetting
		{
			Name = "Species Genetic Span",
			HelperText = "DO NOT CHANGE LIGHTLY, THIS WILL ONLY IMPACT FUTURE SPECIATION!\nCounted in total relative genetic difference, determines the maximum genetic distance from a species definition to be included in the species. If individuals from a species get further than this value, a new species will be created",
			WikiLink = "Species#Pruning",
			DefaultValue = 1.5f,
			val = 1.5f,
			minValue = 0.25f,
			maxValue = 5f,
			precision = 2,
			SI = false
		};

		public FloatSetting speciesSpanScalingFactor = new FloatSetting
		{
			Name = "Species Span Scaling Factor",
			HelperText = "The Factor by which it will increase the Species Genetic Span based on the number of active species over 20. (the first 20 active species have no impact, then each additional active species increase the span for next species to be created.",
			WikiLink = "Species#Pruning",
			DefaultValue = 0.05f,
			val = 0.05f,
			minValue = 0f,
			maxValue = 0.5f,
			precision = 0,
			factor = 100f,
			units = "%/species",
			SI = false
		};

		public IntSetting speciesPrunePointLimit = new IntSetting
		{
			Name = "Species Pruning Point Limit",
			HelperText = "The minimum number of datapoint a species can have before being pruned. Template Species or Favorited Species will never be pruned, but can still disappear if they go bellow 1 datapoint.\nPruning occurs every 30 minutes, so changing this is NON-reversible",
			WikiLink = "Species#Pruning",
			DefaultValue = 2,
			val = 2,
			minValue = 1,
			maxValue = 20,
			SI = false,
			canGoOutOfBounds = true
		};

		public IntSetting simTPS = new IntSetting
		{
			Name = "Ticks Per Second",
			HelperText = "The number of simulation ticks (updates) per second. This encompasses everything aside from rendering and UI interactions, be it physics or bibite systems. Increasing this means the simulation goes slower but is more stable and precise.\nIt's not recommended to change these after starting the simulation, aside from testing purposes.\nIt's not recommended to go bellow 20, as physics start behaving too badly after that.",
			DefaultValue = 30,
			val = 30,
			minValue = 5,
			maxValue = 100,
			units = "tps"
		};

		public IntSetting brainTPS = new IntSetting
		{
			Name = "Brain Update Factor",
			HelperText = "The number of simulation ticks between each bibites brain update. Changing this might impact some systems, as it's also the update factor for all senses. \nIt's not recommended to change these after starting the simulation, aside from testing purposes.",
			DefaultValue = 2,
			val = 2,
			minValue = 1,
			maxValue = 100,
			units = "X"
		};

		public IntSetting decayTPS = new IntSetting
		{
			Name = "Decay Update Factor",
			HelperText = "The number of simulation ticks between each material decay updates.\nIn general, this will only be impactful in very big simulations where decay is enabled to many materials (like plants).\nIt's not recommended to change these after starting the simulation, aside from testing purposes.",
			DefaultValue = 2,
			val = 2,
			minValue = 1,
			maxValue = 100,
			units = "X"
		};

		public IntSetting visionLookupUpdateFactor = new IntSetting
		{
			Name = "Vision Lookup Factor",
			HelperText = "The number of brain updates between each bibite Field of View entity Check. This decides how often bibites will update their list of seen entities (the heaviest operation of bibite vision). A value of 10 means that every 10 brain updates, bibites will update what entities they see.\nThis can be interpreted analogously as their reaction time, or how long it takes them to realise a new object has entered their field of view.\nIt's not recommended to change these after starting the simulation, aside from testing purposes.",
			DefaultValue = 10,
			val = 10,
			minValue = 1,
			maxValue = 100,
			units = "X"
		};

		public IntSetting visionSenseUpdateFactor = new IntSetting
		{
			Name = "Vision Sensing Factor",
			HelperText = "The number of brain updates between each bibite Field of View senses updates. This decides how often bibites will update their vision neurons. A value of 10 means that every 10 brain updates, bibites will update their plant angles, distance, etc.\nIt's not recommended to change these after starting the simulation, aside from testing purposes.",
			DefaultValue = 5,
			val = 5,
			minValue = 1,
			maxValue = 50,
			units = "X"
		};

		public static float simArea => 4f * Instance.SimulationSize.val * Instance.SimulationSize.val;
	}
}
