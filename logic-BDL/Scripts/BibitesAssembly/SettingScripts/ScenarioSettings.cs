using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

namespace SettingScripts
{
	[Serializable]
	public class ScenarioSettings
	{
		public static ScenarioSettings Instance = new ScenarioSettings();

		public List<SettingsChanger> settingsChangers = new List<SettingsChanger>();

		public FloatSetting backgroundMutationChance = new FloatSetting
		{
			Name = "Background Mutation Chance",
			HelperText = "The background mutation rate (kind of like the effect of the ambient radiation). The genetic mutation rate will be added to this number to determine the real number.",
			WikiLink = "Mutation",
			DefaultValue = 1.5f,
			val = 1.5f,
			minValue = 0f,
			maxValue = 20f,
			precision = 2,
			SI = false
		};

		public FloatSetting backgroundMutationVariance = new FloatSetting
		{
			Name = "Background Mutation Variance",
			HelperText = "The background mutation variance (kind of like the effect of the ambient radiation). The genetic mutation variance will be added to this number to determine the real number.",
			WikiLink = "Mutation",
			DefaultValue = 0.05f,
			val = 0.05f,
			minValue = 0f,
			maxValue = 0.5f,
			factor = 100f,
			precision = 1,
			units = "%",
			SI = false
		};

		public FloatSetting relativeMutationShare = new FloatSetting
		{
			Name = "Mutation Value Relativity",
			HelperText = "When a mutation on a gene is triggers, how much should the variation depend on the present gene's value. A higher value here would mean that genes would be stickier around the low end of their spectrum, and harder to get out of. \nA value of 100% here would mean that if a gene would reach 0, a bibite could never evolve that gene again, so be careful.",
			WikiLink = "Mutation",
			DefaultValue = 0.75f,
			val = 0.75f,
			minValue = 0f,
			maxValue = 1f,
			factor = 100f,
			precision = 0,
			units = "%",
			SI = false
		};

		public FloatSetting synapseMutationChance = new FloatSetting
		{
			Name = "Synapse Mutation Probability",
			HelperText = "The probability that when a brain mutation occurs, it ends up being a synapse mutation (as opposed to a neuron mutation)",
			WikiLink = "Synapse_Mutation_Chance",
			DefaultValue = 0.6f,
			val = 0.6f,
			minValue = 0f,
			maxValue = 1f,
			factor = 100f,
			precision = 1,
			units = "%",
			SI = false
		};

		public FloatSetting neuronMutationChance = new FloatSetting
		{
			Name = "Neuron Mutation Probability",
			HelperText = "The probability that when a brain mutation occurs, it ends up being a neuron mutation (as opposed to a synapse mutation)",
			WikiLink = "Neuron_Mutation_Chance",
			DefaultValue = 0.4f,
			val = 0.4f,
			minValue = 0f,
			maxValue = 1f,
			factor = 100f,
			precision = 1,
			units = "%",
			SI = false
		};

		public FloatSetting synapseChangeChance = new FloatSetting
		{
			Name = "Synapse Strength Mutation Probability",
			HelperText = "The probability that when a synapse mutation occurs, it ends up being a modification of a synapse connection strength.",
			WikiLink = "Synapse_Change_Chance",
			DefaultValue = 0.75f,
			val = 0.75f,
			minValue = 0f,
			maxValue = 1f,
			factor = 100f,
			precision = 1,
			units = "%",
			SI = false
		};

		public FloatSetting synapseFlipChance = new FloatSetting
		{
			Name = "Synapse Flip Probability",
			HelperText = "The probability that when a synapse mutation occurs, it ends up being a flip of a synapse connection's polarity. (positive to negative or inversely)",
			WikiLink = "Synapse_Flip_Chance",
			DefaultValue = 0.025f,
			val = 0.025f,
			minValue = 0f,
			maxValue = 1f,
			factor = 100f,
			precision = 1,
			units = "%",
			SI = false
		};

		public FloatSetting synapseToggleChance = new FloatSetting
		{
			Name = "Synapse Toggle Probability",
			HelperText = "The probability that when a synapse mutation occurs, it ends up being the toggling of a synapse connection. (enabled connection becomes disabled or inversely)",
			WikiLink = "Synapse_Toggle_Chance",
			DefaultValue = 0.025f,
			val = 0.025f,
			minValue = 0f,
			maxValue = 1f,
			factor = 100f,
			precision = 1,
			units = "%",
			SI = false
		};

		public FloatSetting synapseAddChance = new FloatSetting
		{
			Name = "Synapse Add Probability",
			HelperText = "The probability that when a synapse mutation occurs, it ends up being the adding of a new synapse connection.",
			WikiLink = "Synapse_Add_Chance",
			DefaultValue = 0.1f,
			val = 0.1f,
			minValue = 0f,
			maxValue = 1f,
			factor = 100f,
			precision = 1,
			units = "%",
			SI = false
		};

		public FloatSetting synapseRemoveChance = new FloatSetting
		{
			Name = "Synapse Removal Probability",
			HelperText = "The probability that when a synapse mutation occurs, it ends up being the removal of an existing synapse connection.",
			WikiLink = "Synapse_Remove_Chance",
			DefaultValue = 0.1f,
			val = 0.1f,
			minValue = 0f,
			maxValue = 1f,
			factor = 100f,
			precision = 1,
			units = "%",
			SI = false
		};

		public FloatSetting neuronDefaultChance = new FloatSetting
		{
			Name = "Default Activation Mutation Probability",
			HelperText = "The probability that when a neuron mutation occurs, it ends up being a modification of that neuron's default activation.",
			WikiLink = "Neuron_Change_Chance",
			DefaultValue = 0.7f,
			val = 0.7f,
			minValue = 0f,
			maxValue = 1f,
			factor = 100f,
			precision = 1,
			units = "%",
			SI = false
		};

		public FloatSetting neuronChangeChance = new FloatSetting
		{
			Name = "Neuron Function Mutation Probability",
			HelperText = "The probability that when a neuron mutation occurs, it ends up being a modification of that neuron's activation function.",
			WikiLink = "Neuron_Change_Chance",
			DefaultValue = 0.1f,
			val = 0.1f,
			minValue = 0f,
			maxValue = 1f,
			factor = 100f,
			precision = 1,
			units = "%",
			SI = false
		};

		public FloatSetting neuronAddChance = new FloatSetting
		{
			Name = "Neuron Add Probability",
			HelperText = "The probability that when a neuron mutation occurs, it ends up being the adding of a new neuron with a random function.",
			WikiLink = "Neuron_Add_Chance",
			DefaultValue = 0.1f,
			val = 0.1f,
			minValue = 0f,
			maxValue = 1f,
			factor = 100f,
			precision = 1,
			units = "%",
			SI = false
		};

		public FloatSetting neuronRemoveChance = new FloatSetting
		{
			Name = "Neuron Removal Probability",
			HelperText = "The probability that when a neuron mutation occurs, it ends up being the removal of an existing neuron.",
			WikiLink = "Neuron_Removal_Chance",
			DefaultValue = 0.1f,
			val = 0.1f,
			minValue = 0f,
			maxValue = 1f,
			factor = 100f,
			precision = 1,
			units = "%",
			SI = false
		};

		public BoolSetting pelletCollision = new BoolSetting
		{
			Name = "Pellet Collision",
			HelperText = "If enabled, pellets will collide with bibites and acts as obstacles. This makes for a much more interesting simulation, but packs a pretty heavy load in term of performances.",
			WikiLink = "Pellet_Collision",
			DefaultValue = true,
			val = true
		};

		public BoolSetting pelletMerge = new BoolSetting
		{
			Name = "Pellet Merge",
			HelperText = "If enabled, pellets of the same type will merge when they collide. This can help with performances, but prevent pellets from interacting physically.",
			WikiLink = "Pellet_Merge",
			DefaultValue = false,
			val = false
		};

		public BoolSetting pelletRotation = new BoolSetting
		{
			Name = "Pellet Rotation",
			HelperText = "If enabled, pellets will be able to rotate and roll. Disabling this helps performances, but prevent pellets to roll against each others realistically.",
			WikiLink = "Pellet_Rotation",
			DefaultValue = true,
			val = true
		};

		public BoolSetting eggCollision = new BoolSetting
		{
			Name = "Egg Collision",
			HelperText = "If enabled, eggs will collide with bibites and acts as obstacles.",
			WikiLink = "Egg_Collision",
			DefaultValue = true,
			val = true
		};

		public BoolSetting disableHerding = new BoolSetting
		{
			Name = "Disable Herding",
			HelperText = "If enabled, activating its herding output neuron won't change the behavior of a bibite. Some people didn't like that system, citing that it's either too powerful or not fun, so here you can disable it.",
			DefaultValue = false,
			val = false
		};

		public FloatSetting minPelletSize = new FloatSetting
		{
			Name = "Minimum Pellet Size",
			HelperText = "The smallest possible pellet size that can exist in simulation. Good to stop the creation of tiny pellets from hindering preformance.",
			DefaultValue = 0.1f,
			minValue = 0.001f,
			maxValue = 10f,
			precision = 2,
			units = " u²",
			canGoOutOfBounds = false
		};

		public BoolSetting preventMutations = new BoolSetting
		{
			Name = "Prevent Mutations",
			HelperText = "If enabled, Bibites will not mutate or evolve.",
			DefaultValue = false,
			val = false
		};

		public BoolSetting voidAvoidance = new BoolSetting
		{
			Name = "Void-No-Mo'",
			HelperText = "This will enable Bibites to automatically turn back when they get out off the simulation area. It's cheating, but it's legal cheating.",
			WikiLink = "Automatic_Void_Avoidance",
			DefaultValue = false,
			val = false
		};

		public FloatSetting voidAvoidanceDistance = new FloatSetting
		{
			Name = "Void Avoidance Distance",
			HelperText = "The distance at which the void avoidance system will be in full effect after getting out of the simulation area. The effect will scale linearly between the boundary and that additional distance.",
			WikiLink = "Void_Avoidance_Distance",
			DefaultValue = 100f,
			val = 100f,
			minValue = 0.0001f,
			maxValue = 1000f,
			precision = 0,
			units = " u",
			SI = false
		};

		public BoolSetting preventRedPheroProduction = new BoolSetting
		{
			Name = "Prevent Red Pheromones Production",
			HelperText = "If enabled, Bibites will not be able to produce red pheromones.",
			DefaultValue = false,
			val = false
		};

		public BoolSetting preventGreenPheroProduction = new BoolSetting
		{
			Name = "Prevent Green Pheromones Production",
			HelperText = "If enabled, Bibites will not be able to produce green pheromones.",
			DefaultValue = false,
			val = false
		};

		public BoolSetting preventBluePheroProduction = new BoolSetting
		{
			Name = "Prevent Blue Pheromones Production",
			HelperText = "If enabled, Bibites will not be able to produce blue pheromones.",
			DefaultValue = false,
			val = false
		};

		public BoolSetting enableRedDeath = new BoolSetting
		{
			Name = "The Red Death Bloom",
			HelperText = "Allows the event The Red Death bloom, that will creep in from outside the shades and slowly choke the world to death, devouring pellets and gradually hurting bibites.",
			DefaultValue = false,
			val = false
		};

		public FloatSetting redDeathFill = new FloatSetting
		{
			Name = "Red Death Fill",
			HelperText = "How much of the map has the Red Death Bloom has claimed.\nNormalized for area.",
			DefaultValue = 0f,
			val = 0f,
			factor = 100f,
			precision = 1,
			minValue = 0f,
			maxValue = 1f,
			units = "%",
			SI = false,
			canGoOutOfBounds = false
		};

		public FloatSetting redDeathBaseDamages = new FloatSetting
		{
			Name = "Red Death Base Damage",
			HelperText = "The base number of health point of damages (and of u² for pellets)",
			DefaultValue = 0.5f,
			val = 0.5f,
			precision = 2,
			minValue = 0f,
			maxValue = 100f,
			units = " HP/s",
			SI = false
		};

		public FloatSetting redDeathDamageVelocity = new FloatSetting
		{
			Name = "Red Death Damages Velocity",
			HelperText = "The rate at which damages increase for each seconds passed in the red death.",
			DefaultValue = 0.15f,
			val = 0.15f,
			precision = 2,
			minValue = 0f,
			maxValue = 10f,
			units = " HP/s²",
			SI = false
		};

		public BoolSetting shadeOutsideOfBounds = new BoolSetting
		{
			Name = "Add Shaded Bounds",
			DefaultValue = true,
			HelperText = "If enabled, only the simulation area is lit up and the remaining space is dark. Bibites will try to avoid the shade at all costs, and pellets that stay in the shade for too long (checked every autosave) will be destroyed."
		};

		public BoolSetting shadeAvoidance = new BoolSetting
		{
			Name = "Bibites Fear Shade",
			HelperText = "If this is enabled, bibites will have an instinctive fear of the shade and will turn away when so.\nRequires Shade to be enabled.",
			WikiLink = "Shade",
			DefaultValue = false,
			val = false
		};

		public BoolSetting worldWrapping = new BoolSetting
		{
			Name = "World Wraps Behind Shade",
			HelperText = "If this is enabled, the world will wrap behind the shade. Any Bibite entering the shade will come out the other side of the world (180° away).\nRequires Shade to be enabled.",
			WikiLink = "Shade",
			DefaultValue = true,
			val = true
		};

		public FloatSetting initialSeeding = new FloatSetting
		{
			Name = "Initial Seeding",
			HelperText = "The percentage of initial biomass that is initially spawned as plant pellets before the simulation is started.",
			WikiLink = "Plant_Growth#Initial_Seeding",
			minValue = 0f,
			maxValue = 1f,
			DefaultValue = 0.75f,
			val = 0.75f,
			factor = 100f,
			precision = 1,
			units = "%",
			SI = false
		};

		public FloatSetting pelletEnergy = new FloatSetting
		{
			Name = "Default pellet Size",
			HelperText = "Approximate amount of energy per plant pellet. In practice, there is a ~25% variation in their spawned value.",
			WikiLink = "Pellet_Size",
			DefaultValue = 200f,
			val = 200f,
			minValue = 10f,
			maxValue = 5000f,
			precision = 2,
			units = " E"
		};

		public FloatSetting fatSustain = new FloatSetting
		{
			Name = "Fat Storage Cost",
			HelperText = "What percentage of the stored Fat energy does the bibite need to expand to sustain it.",
			WikiLink = "Fat",
			DefaultValue = 0f,
			val = 0f,
			minValue = 0f,
			factor = 100f,
			maxValue = 0.05f,
			precision = 1,
			units = " %/s",
			SI = false
		};

		public FloatSetting dragCoefficient = new FloatSetting
		{
			Name = "Drag Coefficient",
			HelperText = "Physical Constant representing the drag coefficient that affect the bibites. A higher value means that the 'environment' is thicker and it's harder to move through it. 0 means no friction.",
			WikiLink = "Drag_Coefficient",
			DefaultValue = 5f,
			val = 5f,
			minValue = 0f,
			maxValue = 25f,
			precision = 2,
			units = " Nu/s"
		};

		public BoolSetting disableDragOnHeldPellet = new BoolSetting
		{
			Name = "Disable Drag On Held Pellet",
			HelperText = "If enabled, pellets will stop experiencing drag when they are being held. This isn't very realistic in itself, but it helps bibite better navigate when they are holding pellets in their mouth.",
			DefaultValue = false,
			val = false
		};

		public FloatSetting armMusclePressure = new FloatSetting
		{
			Name = "Arm Muscles Force",
			HelperText = "Force exerted by a bibite's movement muscles. By default scales linearly with size, but can be changed. Will also scale with a bibite's SpeedRatio gene.\nIt's recommended to adjust this setting when changing the muscles' sizing power for moving or turning.",
			WikiLink = "Bibites_Movement_System",
			DefaultValue = 50f,
			val = 50f,
			minValue = 1f,
			maxValue = 1000f,
			precision = 1,
			units = " N/u"
		};

		public FloatSetting forwardForceSizePower = new FloatSetting
		{
			Name = "Muscles Sizing Propel Power",
			HelperText = "The Power Factor by which the movement muscles will scales when propelling the bibite. 1.0 Signifies a linear scaling with size (1D), so muscles strength scales proportionally with the muscle's cross-section. While a value of 2.0 would mean that muscle strength scales proportionally to the muscle's area.\nIf you change this, you'll also need to update the related constants appropriately.",
			WikiLink = "Movement",
			DefaultValue = 1.5f,
			val = 1.5f,
			minValue = 0f,
			maxValue = 2.5f,
			precision = 1,
			SI = false
		};

		public FloatSetting turnForceSizePower = new FloatSetting
		{
			Name = "Muscles Sizing Turning Power",
			HelperText = "The Power Factor by which the movement muscles will scales when turning. 1.0 Signifies a linear scaling with size (1D), so muscles effectiveness at turning scales proportionally with the muscle's cross-section. While a value of 2.0 would mean that muscles effectiveness at turning scales proportionally to the muscle's area.\nIf you change this, you'll also need to update the related constants appropriately.",
			WikiLink = "Movement",
			DefaultValue = 3f,
			val = 3f,
			minValue = 0f,
			maxValue = 4f,
			precision = 1,
			SI = false
		};

		public FloatSetting backwardFraction = new FloatSetting
		{
			Name = "Backward Force Efficiency",
			HelperText = "Fraction of the Forward Force that is applied when going backward. 0 means that bibites can't go backward, 100% means there's no difference.",
			WikiLink = "Backward_Force_Fraction",
			DefaultValue = 0.5f,
			val = 0.5f,
			minValue = 0f,
			maxValue = 1f,
			precision = 0,
			factor = 100f,
			units = "%",
			SI = false
		};

		public FloatSetting bibiteMassDensity = new FloatSetting
		{
			Name = "Base Bibite Mass Density",
			HelperText = "Base mass density of bibites. Basically, how much does a bibite weight (grams) per u² of space occupied. \n(A bibite with a size gene and growth of 1.0 will occupy ~80u²). The actual mass of the bibites also includes the possible added weight of the other internal organs.",
			WikiLink = "Bibite#Mass",
			DefaultValue = 0.025f,
			val = 0.025f,
			minValue = 0.001f,
			maxValue = 0.25f,
			factor = 1000f,
			precision = 2,
			units = " g/u²"
		};

		public FloatSetting stomachContentContribution = new FloatSetting
		{
			Name = "Stomach Content Weight Contribution",
			HelperText = "What percentage of the weight of the bibite's stomach's content is added to the bibite's weight. The only value that makes sense is 100%, but oh well. Feel free to try things that don't make physical sense.",
			WikiLink = "Bibite_Mass",
			DefaultValue = 1f,
			val = 1f,
			minValue = 0f,
			maxValue = 2f,
			factor = 100f,
			precision = 0,
			units = "%",
			SI = false
		};

		public FloatSetting bitingPressure = new FloatSetting
		{
			Name = "Jaw Muscles Strength",
			HelperText = "The amount of force applied by the jaw of the bibites. By default it will scale with the square root of the area of a bibite's jaw muscles.",
			WikiLink = "Biting_Pressure_Constant",
			DefaultValue = 80f,
			val = 80f,
			minValue = 1f,
			maxValue = 500f,
			precision = 0,
			units = " N/u"
		};

		public FloatSetting throwingForceFactor = new FloatSetting
		{
			Name = "Throwing Force Factor",
			HelperText = "The Factor of the jaw's power that can be used to throw objects.",
			WikiLink = "Throwing_Force_Constant",
			DefaultValue = 0.25f,
			val = 0.25f,
			minValue = 0f,
			maxValue = 1f,
			precision = 0,
			factor = 100f,
			units = "%",
			SI = false
		};

		public FloatSetting bitingThrowForceFactor = new FloatSetting
		{
			Name = "Biting Repulsion Force Factor",
			HelperText = "This defines how strongly a bibite will be thrown away when bitten compared to if it was thrown.\nThis reduction is applied on top of the previous setting.",
			DefaultValue = 0.25f,
			val = 0.25f,
			minValue = 0f,
			maxValue = 1f,
			precision = 0,
			factor = 100f,
			units = "%",
			SI = false
		};

		public FloatSetting jawMusclesSizingPower = new FloatSetting
		{
			Name = "Jaw Sizing Power",
			HelperText = "The Power Factor by which the jaw muscles will scales. 1.0 Signifies a linear scaling with size (1D), so muscles strength scales proportionally with the muscle's cross-section. While a value of 2.0 would mean that muscle strength scales proportionally to the muscle's area.\nIf you change this, you'll also need to update the related constants appropriately.",
			WikiLink = "Biting",
			DefaultValue = 2f,
			val = 2f,
			minValue = 0f,
			maxValue = 3f,
			precision = 1
		};

		public FloatSetting bitePeriodFactor = new FloatSetting
		{
			Name = "Bite Period Factor",
			HelperText = "This will determine how fast bibite will be able to bite by applying a factor to bite period calculation.",
			WikiLink = "Biting",
			DefaultValue = 1f,
			val = 1f,
			minValue = 0f,
			maxValue = 10f,
			precision = 1,
			units = "X",
			SI = false
		};

		public FloatSetting bitingDamageFactor = new FloatSetting
		{
			Name = "Biting Damage Factor",
			HelperText = "The factor by which damages will be applied. By default (500%), a bitten bibite will receive damages proportional to the bite they've received as a portion of their full area. This damage will be applied once at bite, but also every 5 bite period for which the bite continues.\nAs an example, a 100u² bibite with 150 max HP, receiving a bite covering 3u², will receive 22.5 dmg (500% * 150HP * 3u²/100u²).",
			WikiLink = "Biting_Damage_Constant",
			DefaultValue = 5f,
			val = 5f,
			minValue = 0f,
			maxValue = 20f,
			precision = 0,
			factor = 100f,
			units = "%",
			SI = false
		};

		public FloatSetting collisionDamageConstant = new FloatSetting
		{
			Name = "Collision Damage Constant",
			HelperText = "The amount of damage dealt by a collision. Damages scale with mass of the colliding objects and their relative speeds.",
			WikiLink = "Collision_Damage_Constant",
			DefaultValue = 0.1f,
			val = 0.1f,
			minValue = 0f,
			maxValue = 2f,
			precision = 2,
			units = " Dmg/(u/s)",
			SI = false
		};

		public FloatSetting collisionDamageThreshold = new FloatSetting
		{
			Name = "Collision Damage Threshold",
			HelperText = "The minimum relative speed required so a collision is considered hurtful.",
			WikiLink = "Collision_Damage_Threshold",
			DefaultValue = 50f,
			val = 50f,
			minValue = 0f,
			maxValue = 200f,
			precision = 0,
			units = " u/s",
			SI = false
		};

		public FloatSetting baseMetabolismCost = new FloatSetting
		{
			Name = "Default Metabolism Cost",
			HelperText = "The basic energy cost that a bibite have to burn for each units of area (u²) to stay alive. It then also scales with bibite's speed ratio genes proportionally.",
			WikiLink = "Default_Metabolism_Cost",
			DefaultValue = 0.001f,
			val = 0.001f,
			minValue = 0f,
			maxValue = 0.1f,
			factor = 1000f,
			precision = 1,
			units = " E/u²s"
		};

		public FloatSetting energyUsageEfficiency = new FloatSetting
		{
			Name = "Energy Usage Efficiency",
			HelperText = "A factor in determining the efficiency of energy use to the power of the speed ratio gene.",
			DefaultValue = 0.8f,
			val = 0.8f,
			minValue = 0.1f,
			maxValue = 1f,
			factor = 100f,
			precision = 1,
			units = "%",
			canGoOutOfBounds = false,
			SI = false
		};

		public FloatSetting moveMusclesCost = new FloatSetting
		{
			Name = "Move Muscles Activation Cost",
			HelperText = "The energy rate that a bibite's muscles consumes when activated to propel the bibite. The expended energy scales with activation (when moving or turning) and then with the speed ratio gene proportionally.",
			WikiLink = "Movement#Cost",
			DefaultValue = 0.02f,
			val = 0.02f,
			minValue = 0f,
			maxValue = 1f,
			factor = 1000f,
			precision = 1,
			units = " E/u²s"
		};

		public FloatSetting neuronBirthCost = new FloatSetting
		{
			Name = "Neuron Birth Cost",
			HelperText = "The energy cost at birth of a brain neuron (only count neurons in the hidden layer).",
			WikiLink = "Neuron_Birth_Cost",
			DefaultValue = 0.1f,
			val = 0.1f,
			minValue = 0f,
			maxValue = 1f,
			precision = 0,
			factor = 1000f,
			units = " E"
		};

		public FloatSetting synapseBirthCost = new FloatSetting
		{
			Name = "Synapse Birth Cost",
			HelperText = "The energy cost at birth of a brain synapse.",
			WikiLink = "Synapse_Birth_Cost",
			DefaultValue = 0.025f,
			val = 0.025f,
			minValue = 0f,
			maxValue = 0.5f,
			precision = 0,
			factor = 1000f,
			units = " E"
		};

		public FloatSetting neuronUpkeepCost = new FloatSetting
		{
			Name = "Neuron Upkeep Cost",
			HelperText = "The energy rate that a bibite must spend to sustain a brain neuron.",
			WikiLink = "Neuron_Upkeep_Cost",
			DefaultValue = 0.001f,
			val = 0.001f,
			minValue = 0f,
			maxValue = 0.05f,
			precision = 2,
			factor = 1000f,
			units = " E/s"
		};

		public FloatSetting synapseUpkeepCost = new FloatSetting
		{
			Name = "Synapse Upkeep Cost",
			HelperText = "The energy rate that a bibite must spend to sustain a brain synapse.",
			WikiLink = "Synapse_Upkeep_Cost",
			DefaultValue = 0.00025f,
			val = 0.00025f,
			minValue = 0f,
			maxValue = 0.015f,
			precision = 2,
			factor = 1000f,
			units = " E/s"
		};

		public FloatSetting pheromoneProductionCost = new FloatSetting
		{
			Name = "Pheromone Production Cost",
			HelperText = "The per second energy cost a bibite has to spend to produce pheromones at a neuron activation of 1.0",
			WikiLink = "Pheromones",
			DefaultValue = 0.01f,
			val = 0.01f,
			minValue = 0f,
			maxValue = 0.1f,
			precision = 1,
			factor = 1000f,
			units = " E/s"
		};

		public FloatSetting pheromoneProductionStrength = new FloatSetting
		{
			Name = "Pheromone Production rate",
			HelperText = "The amount of pheromones produced by default for a neuron activation of 1.0 (dissipate at 1u²/s). Production scales linearly with the neuron activation.",
			WikiLink = "Pheromones",
			DefaultValue = 10f,
			val = 10f,
			minValue = 0f,
			maxValue = 100f,
			precision = 1,
			units = " u²"
		};

		public FloatSetting ageingThreshold = new FloatSetting
		{
			Name = "Ageing Threshold",
			HelperText = "Age at which penalties starts accumulating.",
			WikiLink = "Ageing",
			DefaultValue = 1f,
			val = 1f,
			minValue = 0f,
			maxValue = 24f,
			precision = 2,
			units = " h",
			SI = false
		};

		public FloatSetting ageStrengthPenalties = new FloatSetting
		{
			Name = "Age Strength Penalty",
			HelperText = "Percentage of reduction in strength (movement and mouth strength) per hour of life above the ageing threshold.",
			WikiLink = "Ageing",
			DefaultValue = 0.25f,
			val = 0.25f,
			minValue = 0f,
			maxValue = 1f,
			precision = 2,
			factor = 100f,
			prefix = "-",
			units = " %/h",
			SI = false
		};

		public FloatSetting ageMetabolismPenalties = new FloatSetting
		{
			Name = "Age Metabolism Penalty",
			HelperText = "Percentage of increase in the metabolism cost of the Bibite per hour of life above the ageing threshold.",
			WikiLink = "Ageing",
			DefaultValue = 0.5f,
			val = 0.5f,
			minValue = 0f,
			maxValue = 1f,
			precision = 2,
			factor = 100f,
			prefix = "+",
			units = " %/h",
			SI = false
		};

		public FloatSetting healthPerArea = new FloatSetting
		{
			Name = "Health to Area Factor",
			HelperText = "The Ratio between max health and a bibite's size. A value of 1.2 means that bibites will have 1.2HP for each units of area (u²).\nMax Health is sometimes also called a 'Body Point'.",
			WikiLink = "Bibite#Health",
			DefaultValue = 1.25f,
			val = 1.25f,
			minValue = 0.05f,
			maxValue = 5f,
			precision = 2,
			SI = false,
			units = "HP/u²"
		};

		public FloatSetting storableEnergyPerArea = new FloatSetting
		{
			Name = "Storable Energy by Area",
			HelperText = "The amount of 'active energy' (energy bar) a bibite can store per square units of body. A value of 1.5 means that bibites can store 1.5 unit of energy for each units of area (u²).",
			WikiLink = "Bibite#Energy",
			DefaultValue = 1.5f,
			val = 1.5f,
			minValue = 0.05f,
			maxValue = 5f,
			precision = 2,
			SI = false,
			units = "E/u²"
		};

		public FloatSetting baseBodyGrowthCost = new FloatSetting
		{
			Name = "Base Body Growth Cost",
			HelperText = "The base Energy cost for growing 1 unit of area (u²). Some Internal organs also cost energy to grow, so this is the minimum for a empty 1u².\nIncreasing this helps increasing the energy density of meat, but makes it costlier to grow.",
			WikiLink = "Bibite#Growth",
			DefaultValue = 2f,
			val = 2f,
			minValue = 0.05f,
			maxValue = 10f,
			precision = 2,
			units = " E/u²"
		};

		public FloatSetting viewAngleAddedCost = new FloatSetting
		{
			Name = "View Angle Added Cost",
			HelperText = "The added energy cost of the view angle. The Base Body Growth Cost each unit of body (u²) is increased by an amount proportional to the view angle multiplied by this setting. A low value helps increasing the energy density of meat, but makes it costlier to grow.",
			WikiLink = "View_Angle_Body_Cost",
			DefaultValue = 0.003f,
			val = 0.003f,
			minValue = 0f,
			maxValue = 0.05f,
			precision = 1,
			factor = 1000f,
			units = " E/°u²"
		};

		public FloatSetting viewRadiusAddedCost = new FloatSetting
		{
			Name = "View Radius Added Cost",
			HelperText = "The added energy cost of the view radius. The Base Body Growth Cost each unit of body (u²) is increased by an amount proportional to the view radius multiplied by this setting. A low value helps increasing the energy density of meat, but makes it costlier to grow.",
			WikiLink = "View_Radius_Body_Cost",
			DefaultValue = 0.002f,
			val = 0.002f,
			minValue = 0f,
			maxValue = 0.05f,
			precision = 1,
			factor = 1000f,
			units = " E/u²"
		};

		public FloatSetting healthEnergyFactor = new FloatSetting
		{
			Name = "Blood Energy Density Factor",
			HelperText = "The factor between the base energy density of health and max health.\nBasically 'How energy dense is blood compared to meat'.\nUsed when healing, drinking blood of other bibites, when energy is depleted, and so on.",
			WikiLink = "Bibite#Blood",
			DefaultValue = 0.5f,
			val = 0.5f,
			minValue = 0.01f,
			maxValue = 1f,
			precision = 0,
			factor = 100f,
			units = "%",
			SI = false
		};

		public FloatSetting globalZoneSpeed = new FloatSetting
		{
			Name = "Global Zone Speed",
			HelperText = "The speed factor at which all zones will move. By default (at a value of 1.0), the global speed will be 1% of the sim size per hour.",
			WikiLink = "Zones",
			minValue = 0f,
			maxValue = 100f,
			DefaultValue = 1f,
			val = 1f,
			precision = 3,
			units = "x",
			SI = false
		};

		public FloatSetting healRate = new FloatSetting
		{
			Name = "Heal Rate",
			HelperText = "The base percent of health a bibite can heal in a second.\nThis value will scale with the inverse of a bibite's size factor (2D), based on the Heal Power Factor, meaning bigger bibites will heal at a lower %/s proportionally .",
			DefaultValue = 0.001f,
			val = 0.001f,
			minValue = 0.0001f,
			maxValue = 0.02f,
			precision = 1,
			units = "% HP/s",
			factor = 100f,
			SI = false
		};

		public FloatSetting healPowerFactor = new FloatSetting
		{
			Name = "Heal Power Factor ",
			HelperText = "The rate at which heal rate in % health/second scales with the inverse (1/x) of a bibite's size factor (2D). This means that bigger bibites will heal slower (as a %/s of their max Health) by default. For example, a value of 0 means no difference (in %/s) based on size and all bibites will heal at the heal rate set by the previous setting.\n0.5 indicates a square root scaling, where a bibite 4x the size (in area) would heal at half the rate (in %HP/s), and 1 indicates a linear scaling.",
			val = 1f,
			DefaultValue = 1f,
			minValue = 0f,
			maxValue = 2f,
			precision = 1,
			SI = false
		};

		public FloatSetting healEfficiency = new FloatSetting
		{
			Name = "Heal Efficiency",
			HelperText = "The multipler of energy used to health gained. For example, a setting of 25% means the cost to heal one hitpoint is 4x the base, and a setting of 100% means the cost to heal 1 hit point is the base amount. A setting of 200% means the cost to heal 1 hit point is half the amount.\n This efficiency (or inefficiency) is added to the bibite's metabolic inefficiency.",
			DefaultValue = 1f,
			val = 1f,
			minValue = 0.01f,
			maxValue = 2f,
			factor = 100f,
			precision = 1,
			units = "%",
			SI = false
		};

		public FloatSetting plantAffinityPowerFactor = new FloatSetting
		{
			Name = "Plant Affinity Power Factor",
			HelperText = "The factor at which affinity for plants scale.\n For example, a value of 1 would mean diet affinity is linear, while a power of .5 means it scales by the square root.\n This setting can drastically change dynamics, so be careful.",
			DefaultValue = 1f,
			val = 1f,
			minValue = 0.1f,
			maxValue = 3f,
			precision = 1
		};

		public FloatSetting meatAffinityPowerFactor = new FloatSetting
		{
			Name = "Meat Affinity Power Factor",
			HelperText = "The factor at which affinity for meats scale.\n For example, a value of 1 would mean diet affinity is linear, while a power of .5 means it scales by the square root.\n This setting can drastically change dynamics, so be careful.",
			DefaultValue = 1f,
			val = 1f,
			minValue = 0.1f,
			maxValue = 3f,
			precision = 1
		};

		public List<ZoneSettings> zones = new List<ZoneSettings>();

		public List<ZoneGroupSettings> zoneGroups = new List<ZoneGroupSettings>();

		[NonSerialized]
		public static UnityEvent<ZoneSettings> onZoneAdded = new UnityEvent<ZoneSettings>();

		[NonSerialized]
		public static UnityEvent<ZoneSettings> onZoneRemoved = new UnityEvent<ZoneSettings>();

		[NonSerialized]
		public static UnityEvent<ZoneSettings> onZoneFromGroupAdded = new UnityEvent<ZoneSettings>();

		[NonSerialized]
		public static UnityEvent<ZoneSettings> onZoneFromGroupRemoved = new UnityEvent<ZoneSettings>();

		[NonSerialized]
		public static UnityEvent allZonesChanged = new UnityEvent();

		[NonSerialized]
		public static UnityEvent onZoneBiomassChange = new UnityEvent();

		public List<ZoneSettings> allZones = new List<ZoneSettings>();

		public static UnityEvent<int, string> zoneNameChanged = new UnityEvent<int, string>();

		public List<BibiteSettings> bibites = new List<BibiteSettings>();

		[NonSerialized]
		public static UnityEvent<BibiteSettings> onBibiteAdded = new UnityEvent<BibiteSettings>();

		[NonSerialized]
		public static UnityEvent<BibiteSettings> onBibiteRemoved = new UnityEvent<BibiteSettings>();

		[NonSerialized]
		public static UnityEvent<BibiteSettings> onBibiteSpawningChanged = new UnityEvent<BibiteSettings>();

		[NonSerialized]
		public static UnityEvent bibiteSpawnPriorityChanged = new UnityEvent();

		[NonSerialized]
		public static UnityEvent bibiteHasMinimumChanged = new UnityEvent();

		[NonSerialized]
		public static UnityEvent<ChallengeParameters> challengeParametersChanged = new UnityEvent<ChallengeParameters>();

		[NonSerialized]
		public ChallengeParameters challengeParameters;

		public bool isChallenge => challengeParameters != null;

		public void UpdateAllZonesList()
		{
			allZones.Clear();
			IEnumerable<ZoneSettings> enumerable = allZones.Concat(zones);
			foreach (ZoneGroupSettings zoneGroup in zoneGroups)
			{
				enumerable = enumerable.Concat(zoneGroup.zones);
			}
			allZones = enumerable.ToList();
			int num = 0;
			foreach (ZoneSettings allZone in allZones)
			{
				allZone.zoneID = num++;
			}
			allZonesChanged.Invoke();
		}

		public int PelletNumberEstimation()
		{
			return allZones.Sum((ZoneSettings z) => z.estimatedPellets);
		}

		public float TotalBiomass()
		{
			return allZones.Sum((ZoneSettings z) => z.maxBiomass);
		}

		public float TotalGrowth()
		{
			return allZones.Sum((ZoneSettings z) => z.totalGrowth);
		}

		public void RebindListeners()
		{
			zones.ForEach(delegate(ZoneSettings z)
			{
				z.target.RebindToTarget();
			});
			zones.ForEach(delegate(ZoneSettings z)
			{
				z.onBiomassChange.AddListener(onZoneBiomassChange.Invoke);
			});
			zoneGroups.ForEach(delegate(ZoneGroupSettings z)
			{
				z.onTotalBiomassChange.AddListener(onZoneBiomassChange.Invoke);
			});
			bibites.ForEach(delegate(BibiteSettings b)
			{
				b.RebindToTarget();
			});
			bibites.ForEach(delegate(BibiteSettings b)
			{
				b.spawnPriority.OnChange.AddListener(bibiteSpawnPriorityChanged.Invoke);
			});
			bibites.ForEach(delegate(BibiteSettings b)
			{
				b.minimumNumber.OnChange.AddListener(bibiteHasMinimumChanged.Invoke);
			});
			bibites.ForEach(delegate(BibiteSettings b)
			{
				b.onSpawnSettingsChanged.AddListener(onBibiteSpawningChanged.Invoke);
			});
		}

		public void AddNewZone(ZoneSettings newZone)
		{
			zones.Add(newZone);
			newZone.onBiomassChange.AddListener(onZoneBiomassChange.Invoke);
			UpdateAllZonesList();
			onZoneAdded.Invoke(newZone);
		}

		public void RemoveZone(ZoneSettings zoneToRemove)
		{
			zones.Remove(zoneToRemove);
			zoneToRemove.onBiomassChange.RemoveListener(onZoneBiomassChange.Invoke);
			UpdateAllZonesList();
			onZoneRemoved.Invoke(zoneToRemove);
		}

		public void RemoveAllZones()
		{
			zones.Clear();
			UpdateAllZonesList();
			onZoneRemoved.Invoke(null);
		}

		public void RegenerateZoneGroups()
		{
			zoneGroups.ForEach(delegate(ZoneGroupSettings g)
			{
				g.GenerateZones();
			});
		}

		public void AddNewBibite(BibiteSettings newBibite)
		{
			bibites.Add(newBibite);
			newBibite.spawnPriority.OnChange.AddListener(bibiteSpawnPriorityChanged.Invoke);
			newBibite.minimumNumber.OnChange.AddListener(bibiteHasMinimumChanged.Invoke);
			newBibite.onSpawnSettingsChanged.AddListener(onBibiteSpawningChanged.Invoke);
			onBibiteAdded.Invoke(newBibite);
		}

		public void RemoveBibite(BibiteSettings bibiteToRemove)
		{
			bibites.Remove(bibiteToRemove);
			onBibiteRemoved.Invoke(bibiteToRemove);
		}

		public void RemoveAllBibites()
		{
			bibites.Clear();
			onBibiteRemoved.Invoke(null);
		}
	}
}
