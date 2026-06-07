using System.Collections.Generic;
using System.Linq;
using SimulationScripts.BibiteScripts;

namespace SettingScripts
{
	public class BibiteEditorSettings
	{
		public static BibiteEditorSettings instance = new BibiteEditorSettings();

		public static GeneSetting colorR = new GeneSetting
		{
			Name = "Red Color",
			HelperText = "The amount of red pigments in the bibite's skin.",
			WikiLink = "Color",
			DefaultValue = 0.1f,
			val = 0.1f,
			minValue = 0f,
			maxValue = 1f,
			precision = 3,
			units = "",
			gene = BibiteGenes.Genes.ColorR,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting colorG = new GeneSetting
		{
			Name = "Green Color",
			HelperText = "The amount of green pigments in the bibite's skin.",
			WikiLink = "Color",
			DefaultValue = 0.1f,
			val = 0.1f,
			minValue = 0f,
			maxValue = 1f,
			precision = 3,
			units = "",
			gene = BibiteGenes.Genes.ColorG,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting colorB = new GeneSetting
		{
			Name = "Blue Color",
			HelperText = "The amount of blue pigments in the bibite's skin.",
			WikiLink = "Color",
			DefaultValue = 0.1f,
			val = 0.1f,
			minValue = 0f,
			maxValue = 1f,
			precision = 3,
			units = "",
			gene = BibiteGenes.Genes.ColorB,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting eyeOffset = new GeneSetting
		{
			Name = "Eye Hue Offset",
			HelperText = "The hue shift of the bibite's eyes compared to it's body color",
			WikiLink = "Color",
			DefaultValue = 0.5f,
			val = 0.5f,
			minValue = 0f,
			maxValue = 1f,
			precision = 2,
			units = "",
			gene = BibiteGenes.Genes.EyeOffset,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting diet = new GeneSetting
		{
			Name = "Diet",
			HelperText = "Decides what kind of food is best suited to the Bibite. 0 means completely herbivorous, 1 means completely carnivorous, omnivory will depend on the parameters of the respective food source.",
			WikiLink = "Bibite_Diet",
			DefaultValue = 0.2f,
			val = 0.2f,
			minValue = 0f,
			maxValue = 1f,
			precision = 2,
			units = "",
			gene = BibiteGenes.Genes.Diet,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting sizeRatio = new GeneSetting
		{
			Name = "Size Ratio",
			HelperText = "The relative size of the bibite (1D, length). This increases the metabolism (energy cost each second) of the bibite, as well as many other dynamics.",
			WikiLink = "Size_Ratio",
			DefaultValue = 1f,
			val = 1f,
			minValue = 0.05f,
			maxValue = 2.55f,
			precision = 2,
			units = "",
			gene = BibiteGenes.Genes.SizeRatio,
			SI = false,
			isPurelyRelative = true,
			canGoOutOfBounds = false
		};

		public static GeneSetting speedRatio = new GeneSetting
		{
			Name = "Metabolism Speed",
			HelperText = "The relative metabolic activity of the bibite. This increases digestive activities, movement, etc., but also increases the default sustenance cost (energy/s) and energy expanses of the bibite.",
			WikiLink = "Metabolism_Speed",
			DefaultValue = 0.75f,
			val = 0.75f,
			minValue = 1E-06f,
			maxValue = 2.5f,
			precision = 2,
			units = " SPD",
			gene = BibiteGenes.Genes.SpeedRatio,
			SI = false,
			isPurelyRelative = true,
			canGoOutOfBounds = false
		};

		public static GeneSetting mutationChance = new GeneSetting
		{
			Name = "Average Gene Mutations",
			HelperText = "The average number of mutations that occurs in every generations.",
			WikiLink = "Mutation_Chance",
			DefaultValue = 2f,
			val = 2f,
			minValue = 0f,
			maxValue = 30f,
			precision = 1,
			units = "",
			gene = BibiteGenes.Genes.AverageMutationNumber,
			SI = false
		};

		public static GeneSetting mutationVariance = new GeneSetting
		{
			Name = "Gene Mutation Variance",
			HelperText = "The standard deviation of the amount of change on mutations in genes.\nExpressed in fraction of the total gene span, but a portion (based on the 'Mutation Value Relativity' parameter) will be scaled to the present value of the gene.",
			WikiLink = "Mutation_Variance",
			DefaultValue = 0.05f,
			val = 0.05f,
			minValue = 0f,
			maxValue = 0.25f,
			factor = 100f,
			precision = 2,
			units = "%",
			gene = BibiteGenes.Genes.MutationAmountSigma,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting brainMutationChance = new GeneSetting
		{
			Name = "Average Brain Mutations",
			HelperText = "The average number of brain mutations that occurs in every generations.",
			WikiLink = "Brain_Mutation_Chance",
			DefaultValue = 1f,
			val = 1f,
			minValue = 0f,
			maxValue = 10f,
			precision = 1,
			units = "",
			gene = BibiteGenes.Genes.BrainAverageMutation,
			SI = false
		};

		public static GeneSetting brainMutationVariance = new GeneSetting
		{
			Name = "Brain Mutation Variance",
			HelperText = "The standard deviation of the amount of change on mutations in the brain.\nExpressed in fraction of the total gene span, but a portion (based on the 'Mutation Value Relativity' parameter) will be scaled to the present value of the gene.",
			WikiLink = "Brain_Mutation_Variance",
			DefaultValue = 0.1f,
			val = 0.1f,
			minValue = 0f,
			maxValue = 0.25f,
			factor = 100f,
			precision = 2,
			units = "%",
			gene = BibiteGenes.Genes.BrainMutationSigma,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting layTime = new GeneSetting
		{
			Name = "Lay Time",
			HelperText = "Default time it takes a bibites to produce an egg if its egg production node is fully activated.\nThis also scales with the bibite's metabolic speed, so a bibite with a metabolism speed gene of 0.5 would take twice as long to produce the egg.",
			WikiLink = "Lay_Time",
			DefaultValue = 15f,
			val = 15f,
			minValue = 1f,
			maxValue = 51f,
			precision = 1,
			units = " s",
			gene = BibiteGenes.Genes.LayTime,
			canGoOutOfBounds = false
		};

		public static GeneSetting broodTime = new GeneSetting
		{
			Name = "Brood Time",
			HelperText = "Used in a formula to determine the bibite's maturity at birth (hatchTime/broodTime)². A higher brood time will cause bibites to be born smaller.\n\nThis gene used to be more consequential but is now only used in the maturity at birth formula.",
			WikiLink = "Brood_Time",
			DefaultValue = 20f,
			val = 20f,
			minValue = 1f,
			maxValue = 101f,
			precision = 1,
			units = " s",
			gene = BibiteGenes.Genes.BroodTime,
			canGoOutOfBounds = false
		};

		public static GeneSetting hatchTime = new GeneSetting
		{
			Name = "Hatch Time",
			HelperText = "Time it takes for the egg to hatch. It's also used to calculate how developed the newborn will be when hatching. A longer hatch times usually cost more energy but makes the newborn's survival more likely.",
			WikiLink = "Hatch_Time",
			DefaultValue = 10f,
			val = 10f,
			minValue = 1f,
			maxValue = 101f,
			precision = 1,
			units = " s",
			gene = BibiteGenes.Genes.HatchTime,
			canGoOutOfBounds = false
		};

		public static GeneSetting viewRadius = new GeneSetting
		{
			Name = "View Radius",
			HelperText = "The distance up to which bibites can see",
			WikiLink = "View_Radius",
			DefaultValue = 180f,
			val = 180f,
			minValue = 0f,
			maxValue = 200f,
			precision = 1,
			units = " u",
			gene = BibiteGenes.Genes.ViewRadius,
			canGoOutOfBounds = false
		};

		public static GeneSetting viewAngle = new GeneSetting
		{
			Name = "View Angle",
			HelperText = "The bibite's field of view.",
			WikiLink = "View_Radius",
			DefaultValue = 75f,
			val = 75f,
			minValue = 0f,
			maxValue = 360f,
			precision = 0,
			units = "°",
			gene = BibiteGenes.Genes.ViewAngle,
			canGoOutOfBounds = false
		};

		public static GeneSetting clkSpeed = new GeneSetting
		{
			Name = "Clock Period",
			HelperText = "The period of the internal clock in the bibite's brain. Influences a few senses related to time.",
			WikiLink = "Internal_Clock_Period",
			DefaultValue = 1f,
			val = 1f,
			minValue = 0.1f,
			maxValue = 10.1f,
			precision = 2,
			units = " s",
			gene = BibiteGenes.Genes.ClockSpeed,
			canGoOutOfBounds = false
		};

		public static GeneSetting pherosense = new GeneSetting
		{
			Name = "Pheromones Sensing Radius",
			HelperText = "Influences the distance at which the bibite can sense pheromone, as well as how much they will respond to it.",
			WikiLink = "Pheromone_Sensibility",
			DefaultValue = 150f,
			val = 150f,
			minValue = 0f,
			maxValue = 500f,
			precision = 0,
			units = "u",
			gene = BibiteGenes.Genes.PheroSense,
			canGoOutOfBounds = false
		};

		public static GeneSetting herdSeparationWeight = new GeneSetting
		{
			Name = "Herd Separation Weight",
			HelperText = "The weight controlling how much the separation rule is applied for the herd. This rule tries to prevent the bibites from bumping into one another.",
			WikiLink = "Herd_Separation_Weight",
			DefaultValue = 1f,
			val = 1f,
			minValue = 0f,
			maxValue = 4f,
			precision = 2,
			units = "",
			gene = BibiteGenes.Genes.HerdSeparationWeight,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting herdAlignmentWeight = new GeneSetting
		{
			Name = "Herd Alignment Weight",
			HelperText = "The weight controlling how much the alignment rule is applied for the herd. This rule tries to align the herd so all bibites head in the same direction.",
			WikiLink = "Herd_Alignment_Weight",
			DefaultValue = 1.5f,
			val = 1.5f,
			minValue = 0f,
			maxValue = 4f,
			precision = 2,
			units = "",
			gene = BibiteGenes.Genes.HerdAlignmentWeight,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting herdCohesionWeight = new GeneSetting
		{
			Name = "Herd Cohesion Weight",
			HelperText = "The weight controlling how much the cohesion rule is applied for the herd. This rule tries to keep the herd together.",
			WikiLink = "Herd_Cohesion_Weight",
			DefaultValue = 0.75f,
			val = 0.75f,
			minValue = 0f,
			maxValue = 4f,
			precision = 2,
			units = "",
			gene = BibiteGenes.Genes.HerdCohesionWeight,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting herdVelocityWeight = new GeneSetting
		{
			Name = "Herd Velocity Weight",
			HelperText = "The weight controlling how much the velocity rule is applied for the herd. This rule tries to match a bibite's speed to its herd.",
			WikiLink = "Herd_Velocity_Weight",
			DefaultValue = 0.25f,
			val = 0.25f,
			minValue = 0f,
			maxValue = 1f,
			precision = 2,
			units = "",
			gene = BibiteGenes.Genes.HerdVelocityWeight,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting herdSeparationDistance = new GeneSetting
		{
			Name = "Herd Separation Distance",
			HelperText = "The distance bibites will try to keep between them in a herd. A regular bibite usually measures 10u.",
			WikiLink = "Herd_Separation_Distance",
			DefaultValue = 35f,
			val = 35f,
			minValue = 0f,
			maxValue = 100f,
			precision = 1,
			units = "u",
			gene = BibiteGenes.Genes.HerdSeparationDistance,
			canGoOutOfBounds = false
		};

		public static GeneSetting growthFactor = new GeneSetting
		{
			Name = "Growth Scale Factor",
			HelperText = "The genetic value influencing the scale of the growth function.",
			WikiLink = "BibiteGrowth#Growth_Formula",
			DefaultValue = 0.15f,
			val = 0.15f,
			minValue = 0f,
			maxValue = 2f,
			precision = 3,
			units = "",
			gene = BibiteGenes.Genes.GrowthScale,
			SI = false,
			isPurelyRelative = true,
			canGoOutOfBounds = false
		};

		public static GeneSetting growthMaturityFactor = new GeneSetting
		{
			Name = "Growth Maturity Factor",
			HelperText = "The genetic value influencing the impact of maturity on growth.",
			WikiLink = "BibiteGrowth#Growth_Formula",
			DefaultValue = 2f,
			val = 2f,
			minValue = 0f,
			maxValue = 10f,
			precision = 2,
			units = "",
			gene = BibiteGenes.Genes.GrowthMaturityFactor,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting growthMaturityExponent = new GeneSetting
		{
			Name = "Growth Maturity Exponent",
			HelperText = "The genetic value determining the exponent of maturity's influence on growth.",
			WikiLink = "BibiteGrowth#Growth_Formula",
			DefaultValue = 1f,
			val = 1f,
			minValue = 0f,
			maxValue = 10f,
			precision = 2,
			units = "",
			gene = BibiteGenes.Genes.GrowthMaturityExponent,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting stomachWAG = new GeneSetting
		{
			Name = "Stomach WAG",
			HelperText = "Stomach WAG (Weighted Apportionment Gene) determines the share of the bibite's internal area that's dedicated to the stomach.",
			WikiLink = "Organs",
			DefaultValue = 2f,
			val = 2f,
			minValue = -1f,
			maxValue = 9f,
			precision = 3,
			units = "",
			gene = BibiteGenes.Genes.StomachWAG,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting wombWAG = new GeneSetting
		{
			Name = "Egg Organ WAG",
			HelperText = "Egg Organ WAG (Weighted Apportionment Gene) determines the share of the bibite's internal area that's dedicated to the egg organ.",
			WikiLink = "Organs",
			DefaultValue = 1f,
			val = 1f,
			minValue = -1f,
			maxValue = 9f,
			precision = 3,
			units = "",
			gene = BibiteGenes.Genes.WombWAG,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting fatWAG = new GeneSetting
		{
			Name = "Fat Organ WAG",
			HelperText = "Fat Organ WAG (Weighted Apportionment Gene) determines the share of the bibite's internal area that's dedicated to fat storage.",
			WikiLink = "Organs",
			DefaultValue = 1f,
			val = 1f,
			minValue = -1f,
			maxValue = 9f,
			precision = 3,
			units = "",
			gene = BibiteGenes.Genes.FatWAG,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting armorWAG = new GeneSetting
		{
			Name = "Armor WAG",
			HelperText = "Armor WAG (Weighted Apportionment Gene) determines the share of the bibite's internal area that's dedicated to armor. Armor protects the bibite from attacks by creating a harder layer that is harder to break the thicker it is.",
			WikiLink = "Organs",
			DefaultValue = 0.15f,
			val = 0.15f,
			minValue = -1f,
			maxValue = 9f,
			precision = 3,
			units = "",
			gene = BibiteGenes.Genes.ArmorWAG,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting throatWAG = new GeneSetting
		{
			Name = "Throat WAG",
			HelperText = "Throat WAG (Weighted Apportionment Gene) determines the share of the bibite's internal area that's dedicated to their throat. A Larger throat makes it possible to take bigger bites and swallow larger chunks of matters. Larger throat/mouths also means a longer bite period, meaning bibites will have to wait longer before after taking a bite.",
			WikiLink = "Organs",
			DefaultValue = 1f,
			val = 1f,
			minValue = -1f,
			maxValue = 9f,
			precision = 3,
			units = "",
			gene = BibiteGenes.Genes.ThroatWAG,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting jawWAG = new GeneSetting
		{
			Name = "Jaw Muscles WAG",
			HelperText = "Jaw Muscles WAG (Weighted Apportionment Gene) determines the share of the bibite's internal area that's dedicated to their jaw muscles. Bigger jaw muscles allows them to apply larger forces when biting, and taking bigger bites proportionally, or dealing more damages.",
			WikiLink = "Organs",
			DefaultValue = 1f,
			val = 1f,
			minValue = -1f,
			maxValue = 9f,
			precision = 3,
			units = "",
			gene = BibiteGenes.Genes.MouthMusclesWAG,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting moveWAG = new GeneSetting
		{
			Name = "Arm Muscles WAG",
			HelperText = "Arm Muscles WAG (Weighted Apportionment Gene) determines the share of the bibite's internal area that's dedicated to their arm muscles. Larger arm muscles makes them more powerful and allows them to move faster.",
			WikiLink = "Organs",
			DefaultValue = 1f,
			val = 1f,
			minValue = -1f,
			maxValue = 9f,
			precision = 3,
			units = "",
			gene = BibiteGenes.Genes.MoveMusclesWAG,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting fatThreshold = new GeneSetting
		{
			Name = "Fat Storage Threshold",
			HelperText = "The energy ratio that will be considered a neutral point for fat storage/retrieval.",
			WikiLink = "Fat",
			DefaultValue = 0.5f,
			val = 0.5f,
			minValue = 0f,
			maxValue = 1f,
			precision = 3,
			units = "",
			gene = BibiteGenes.Genes.FatStorageThreshold,
			SI = false,
			canGoOutOfBounds = false
		};

		public static GeneSetting fatDeadband = new GeneSetting
		{
			Name = "Fat Storage Deadband",
			HelperText = "The delta energy ratio around the neutral point (threshold) where fat storage/retrieval will not be activated.",
			WikiLink = "Fat",
			DefaultValue = 0.25f,
			val = 0.25f,
			minValue = 0f,
			maxValue = 0.5f,
			precision = 3,
			units = "",
			gene = BibiteGenes.Genes.FatStorageDeadband,
			SI = false,
			canGoOutOfBounds = false
		};

		public static List<GeneSetting> geneSettings = new List<GeneSetting>
		{
			colorR, colorG, colorB, eyeOffset, diet, sizeRatio, speedRatio, mutationChance, mutationVariance, brainMutationChance,
			brainMutationVariance, layTime, broodTime, hatchTime, viewRadius, viewAngle, clkSpeed, pherosense, herdSeparationWeight, herdAlignmentWeight,
			herdCohesionWeight, herdVelocityWeight, herdSeparationDistance, growthFactor, growthMaturityFactor, growthMaturityExponent, moveWAG, stomachWAG, wombWAG, fatWAG,
			armorWAG, throatWAG, jawWAG, fatThreshold, fatDeadband
		};

		public static List<GeneSetting> geneSettingsOrdered = geneSettings.OrderBy((GeneSetting s) => (int)s.gene).ToList();

		public static List<GeneSetting> WAGGSettings = new List<GeneSetting> { moveWAG, stomachWAG, wombWAG, fatWAG, armorWAG, throatWAG, jawWAG };

		public static float[] geneArray => (from g in geneSettings
			orderby (int)g.gene
			select g.val).ToArray();

		public static GeneSetting SettingOfGene(BibiteGenes.Genes gene)
		{
			return geneSettings.FirstOrDefault((GeneSetting s) => s.gene == gene);
		}

		public static GeneSetting SettingOfGene(int i)
		{
			return geneSettings.FirstOrDefault((GeneSetting s) => s.gene == (BibiteGenes.Genes)i);
		}
	}
}
