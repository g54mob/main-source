using System;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;
using UnityEngine;
using Utility;

namespace SimulationScripts.BibiteScripts
{
	public class BibiteGenes : MonoBehaviour, ISaveable
	{
		public enum Genes
		{
			LayTime = 0,
			BroodTime = 1,
			HatchTime = 2,
			SizeRatio = 3,
			SpeedRatio = 4,
			ColorR = 5,
			ColorG = 6,
			ColorB = 7,
			MutationAmountSigma = 8,
			AverageMutationNumber = 9,
			BrainMutationSigma = 10,
			BrainAverageMutation = 11,
			ViewAngle = 12,
			ViewRadius = 13,
			ClockSpeed = 14,
			PheroSense = 15,
			Diet = 16,
			HerdSeparationWeight = 17,
			HerdAlignmentWeight = 18,
			HerdCohesionWeight = 19,
			HerdVelocityWeight = 20,
			HerdSeparationDistance = 21,
			GrowthScale = 22,
			GrowthMaturityFactor = 23,
			GrowthMaturityExponent = 24,
			EyeOffset = 25,
			StomachWAG = 26,
			WombWAG = 27,
			FatWAG = 28,
			ArmorWAG = 29,
			ThroatWAG = 30,
			MouthMusclesWAG = 31,
			MoveMusclesWAG = 32,
			FatStorageThreshold = 33,
			FatStorageDeadband = 34
		}

		public string speciesTag;

		public Species species;

		public bool isMutant;

		public GameObject parent1;

		[NonSerialized]
		public int parent1ID;

		public GameObject parent2;

		[NonSerialized]
		public int parent2ID;

		public float[] genes;

		public float roleValue;

		private static readonly FloatSetting BackgroundMutationChance = ScenarioSettings.Instance.backgroundMutationChance;

		private static readonly FloatSetting BackgroundMutationVariance = ScenarioSettings.Instance.backgroundMutationVariance;

		private static readonly BoolSetting PreventMutations = ScenarioSettings.Instance.preventMutations;

		private static float backgroundMutationChance = BackgroundMutationChance.SubscribeTo<FloatSetting, float>(UpdateBackgroundMutationChance);

		private static float backgroundMutationVariance = BackgroundMutationVariance.SubscribeTo<FloatSetting, float>(UpdateBackgroundMutationVariance);

		private static bool preventMutations = PreventMutations.SubscribeTo<BoolSetting, bool>(UpdatePreventMutations);

		public const float BodyDefaultArea = 80f;

		public const float BodyDefaultLength = 12.5f;

		private static readonly System.Random SystemRandom = new System.Random();

		public Dictionary<string, MutationIncreases> mutationFactors = new Dictionary<string, MutationIncreases>();

		public MutationIncreases mutationIncreases;

		private float willMute;

		private int muteChoice;

		public int generation;

		internal bool IsReady;

		public bool isRad;

		public bool isRain;

		public bool isKiller;

		public bool isSource;

		internal bool geneTransfered;

		public bool deuxParent;

		public static int NGene = Enum.GetValues(typeof(Genes)).Length;

		public float SumBodyAndHealthEnergyRatio => BodyEnergyDensity * (1f + ScenarioSettings.Instance.healthEnergyFactor.val);

		public float BodyEnergyDensity => ScenarioSettings.Instance.baseBodyGrowthCost.val + genes[12] * ScenarioSettings.Instance.viewAngleAddedCost.val + genes[13] * ScenarioSettings.Instance.viewRadiusAddedCost.val + armorAreaPortion * MatterMaterialManager.Armor.EnergyDensity;

		public float HealthEnergyRatio => BodyEnergyDensity * ScenarioSettings.Instance.healthEnergyFactor.val;

		public float LayBodyEnergy => 100f * D2SizeAtBirth * (ScenarioSettings.Instance.storableEnergyPerArea.val + SumBodyAndHealthEnergyRatio);

		public float BodyEnergyAtBirth => 100f * D2SizeAtBirth * SumBodyAndHealthEnergyRatio;

		public float D1SizeAtBirth => genes[3] * RootOfMaturityAtBirth;

		public float D2SizeAtBirth => genes[3] * genes[3] * BibiteGrowthAtBirth;

		public float areaAtBirth => 80f * D2SizeAtBirth;

		public float metabolicRate => genes[4];

		public float MetabolicEfficiency => Mathf.Pow(ScenarioSettings.Instance.energyUsageEfficiency.val, Gene(Genes.SpeedRatio));

		public float BibiteGrowthAtBirth => GrowthAtBirth(genes);

		public float GrowthAtBigEnoughEggOrgan => GrowthAtMature(genes);

		public float RootOfMaturityAtBirth => genes[2] / genes[1];

		public float totalWAG => TotalOrganWAG(genes);

		public float wombAreaPortion => WombAreaPortion(genes);

		public float armorAreaPortion => ArmorOrganAreaPortion(genes);

		public float stomachAreaPortion => StomachAreaPortion(genes);

		public float throatAreaPortion => ThroatAreaPortion(genes);

		public float jawAreaPortion => JawAreaPortion(genes);

		public float fatAreaPortion => FatAreaPortion(genes);

		public float moveMusclesAreaPortion => MoveMusclesAreaPortion(genes);

		public float totalOrganWAG => TotalOrganWAG(genes);

		public static float GrowthAtBirth(float[] genetics)
		{
			return Mathf.Pow(genetics[2] / genetics[1], 2f);
		}

		public static float GrowthAtMature(float[] genetics)
		{
			return Mathf.Max(1f, GrowthAtBirth(genetics) / Mathf.Max(WombAreaPortion(genetics), 0.001f));
		}

		public static float AreaAtMature(float[] genetics)
		{
			return 80f * GrowthAtMature(genetics) * genetics[3] * genetics[3];
		}

		public static float LengthAtMature(float[] genetics)
		{
			return 12.5f * Mathf.Sqrt(GrowthAtMature(genetics)) * genetics[3];
		}

		public static float WombAreaPortion(float[] g)
		{
			return OrganAreaPortion(g, Genes.WombWAG);
		}

		public static float ArmorOrganAreaPortion(float[] g)
		{
			return OrganAreaPortion(g, Genes.ArmorWAG);
		}

		public static float StomachAreaPortion(float[] g)
		{
			return OrganAreaPortion(g, Genes.StomachWAG);
		}

		public static float ThroatAreaPortion(float[] g)
		{
			return OrganAreaPortion(g, Genes.ThroatWAG);
		}

		public static float JawAreaPortion(float[] g)
		{
			return OrganAreaPortion(g, Genes.MouthMusclesWAG);
		}

		public static float FatAreaPortion(float[] g)
		{
			return OrganAreaPortion(g, Genes.FatWAG);
		}

		public static float MoveMusclesAreaPortion(float[] g)
		{
			return OrganAreaPortion(g, Genes.MoveMusclesWAG);
		}

		public static float OrganAreaPortion(float[] g, Genes organWAG)
		{
			return Mathf.Max(0f, g[(int)organWAG]) / Mathf.Max(TotalOrganWAG(g), 0.0001f);
		}

		public static float TotalOrganWAG(float[] g)
		{
			return Mathf.Max(0f, g[26]) + Mathf.Max(0f, g[27]) + Mathf.Max(0f, g[28]) + Mathf.Max(0f, g[29]) + Mathf.Max(0f, g[30]) + Mathf.Max(0f, g[31]) + Mathf.Max(0f, g[32]);
		}

		private static void UpdateBackgroundMutationChance(float val)
		{
			backgroundMutationChance = val;
		}

		private static void UpdateBackgroundMutationVariance(float val)
		{
			backgroundMutationVariance = val;
		}

		private static void UpdatePreventMutations(bool val)
		{
			preventMutations = val;
		}

		public float Gene(Genes gene)
		{
			return genes[(int)gene];
		}

		public void UpdateMutationIncreases()
		{
			mutationIncreases.probabilityIncrease = mutationFactors.Sum((KeyValuePair<string, MutationIncreases> p) => p.Value.probabilityIncrease);
			mutationIncreases.intensityIncrease = mutationFactors.Sum((KeyValuePair<string, MutationIncreases> p) => p.Value.intensityIncrease);
		}

		public void StartGenes()
		{
			genes = new float[NGene];
		}

		public void StartGenesFromTemplate(BibiteTemplate template, Tagging tagStyle, string customTag = "")
		{
			float[] array = template.genes;
			StartGenes();
			for (int i = 0; i < NGene; i++)
			{
				genes[i] = array[i];
			}
			CapGenes();
			generation = template.generation;
			geneTransfered = true;
			IsReady = true;
			species = GlobalLineageManager.Instance.FindSpeciesFromTemplate(template);
			speciesTag = tagStyle switch
			{
				Tagging.SpeciesTagging => species.name, 
				Tagging.RandomTagging => $"Bibite{UnityEngine.Random.Range(0, int.MaxValue)}", 
				Tagging.CustomTagging => customTag, 
				_ => speciesTag, 
			};
		}

		public void SetParents(GameObject firstParent, GameObject secondParent = null)
		{
			parent1 = firstParent;
			parent2 = secondParent;
		}

		public void CopyGene(BibiteGenes genetoCopy, bool increaseGeneration = false, bool mutate = false)
		{
			StartGenes();
			for (int i = 0; i < NGene; i++)
			{
				genes[i] = genetoCopy.genes[i];
			}
			CapGenes();
			if (increaseGeneration)
			{
				generation = genetoCopy.generation + 1;
				mutationIncreases = genetoCopy.mutationIncreases;
				if (genetoCopy.isRad && UnityEngine.Random.value < 0.1f)
				{
					isRad = true;
				}
				if (genetoCopy.isRain && UnityEngine.Random.value < 0.1f)
				{
					isRain = true;
				}
				if (genetoCopy.isKiller && UnityEngine.Random.value < 0.1f)
				{
					isKiller = true;
				}
				if (genetoCopy.isSource && UnityEngine.Random.value < 0.1f)
				{
					isSource = true;
				}
			}
			else
			{
				generation = genetoCopy.generation;
				isRad = genetoCopy.isRad;
				isRain = genetoCopy.isRain;
				isSource = genetoCopy.isSource;
				isKiller = genetoCopy.isKiller;
			}
			speciesTag = genetoCopy.speciesTag;
			species = genetoCopy.species;
			deuxParent = genetoCopy.deuxParent;
			isMutant = genetoCopy.isMutant;
			geneTransfered = true;
			if (mutate)
			{
				Mutate();
			}
			IsReady = true;
		}

		public void CopyGene2(BibiteGenes gene, BibiteGenes gene2)
		{
			bool flag = true;
			int num = 0;
			int num2 = RandChi(NGene);
			for (int i = 0; i < NGene; i++)
			{
				if (flag)
				{
					genes[i] = gene.genes[i];
				}
				else
				{
					genes[i] = gene2.genes[i];
				}
				num++;
				if (num >= num2)
				{
					flag = !flag;
					num2 = RandChi(NGene - num);
					num = 0;
				}
			}
			geneTransfered = true;
			deuxParent = true;
			IsReady = true;
		}

		public void Mutate(int? numberOfMutation = null)
		{
			if (preventMutations)
			{
				return;
			}
			if (UserSettings.AllowEasterEggs.val && UnityEngine.Random.value < 1f / (float)UserSettings.EasterEggsProbability.val)
			{
				switch (UnityEngine.Random.Range(0, 4))
				{
				case 0:
					isRad = true;
					break;
				case 1:
					isRain = true;
					break;
				case 2:
					isSource = true;
					break;
				case 3:
					isKiller = true;
					break;
				}
			}
			int num = numberOfMutation ?? SystemRandom.NextPoisson(genes[9] + backgroundMutationChance + mutationIncreases.probabilityIncrease);
			for (int i = 0; i < num; i++)
			{
				OneMutation();
			}
		}

		private void OneMutation()
		{
			int gene = UnityEngine.Random.Range(0, NGene);
			OneMutation(gene);
		}

		private void OneMutation(int gene)
		{
			GeneSetting geneSetting = BibiteEditorSettings.SettingOfGene(gene);
			float mutationSigma = genes[8] + backgroundMutationVariance + mutationIncreases.intensityIncrease;
			float num = SystemRandom.NextMutationValue(genes[gene], mutationSigma, geneSetting.span, geneSetting.isPurelyRelative);
			genes[gene] = Mathf.Clamp(genes[gene] + num, geneSetting.minValue, geneSetting.maxValue);
		}

		public void CapGenes()
		{
			for (int num = genes.Length - 1; num >= 0; num--)
			{
				GeneSetting geneSetting = BibiteEditorSettings.SettingOfGene(num);
				genes[num] = Mathf.Clamp(genes[num], geneSetting.minValue, geneSetting.maxValue);
			}
		}

		public void InitGenesFromGameSettings()
		{
			StartGenes();
			for (int num = genes.Length - 1; num >= 0; num--)
			{
				genes[num] = BibiteEditorSettings.SettingOfGene(num).DefaultValue;
			}
		}

		public void RandomColor()
		{
			genes[5] = UnityEngine.Random.Range(BibiteEditorSettings.colorR.minValue, BibiteEditorSettings.colorR.maxValue);
			genes[6] = UnityEngine.Random.Range(BibiteEditorSettings.colorG.minValue, BibiteEditorSettings.colorG.maxValue);
			genes[7] = UnityEngine.Random.Range(BibiteEditorSettings.colorB.minValue, BibiteEditorSettings.colorB.maxValue);
		}

		public void RandomGenes()
		{
			StartGenes();
			for (int num = genes.Length - 1; num >= 0; num--)
			{
				GeneSetting geneSetting = BibiteEditorSettings.SettingOfGene(num);
				genes[num] = UnityEngine.Random.Range(geneSetting.minValue, geneSetting.maxValue);
			}
			genes[1] = Mathf.Max(genes[1], genes[2] / 0.75f);
			genes[3] = Mathf.Pow(1.5f, SystemRandom.NextGaussian(0f, 1f));
		}

		public int RandChi(int nMax)
		{
			return (int)((4f * Mathf.Pow(UnityEngine.Random.Range(0f, 1f) - 0.5f, 3f) + 0.5f) * (float)nMax);
		}

		public Color GetBodyColor(bool objective = false)
		{
			if (isRain && !objective)
			{
				return Color.clear;
			}
			float r = genes[5];
			float g = genes[6];
			float b = genes[7];
			return GenesToColor(r, g, b);
		}

		public Color GetEyeColor()
		{
			Color.RGBToHSV(GetBodyColor(), out var H, out var _, out var _);
			H -= genes[25];
			return Color.HSVToRGB(H, 1f, 1f);
		}

		public static Color GenesToEyeColor(Color bodyColor, float offset)
		{
			Color.RGBToHSV(bodyColor, out var H, out var _, out var _);
			return Color.HSVToRGB(H - offset, 1f, 1f);
		}

		public static Color GenesToColor(float r, float g, float b)
		{
			float num = Mathf.Min(r, g, b);
			float num2 = 1f + r - ((g > b) ? g : b);
			num2 = ((num2 > 1f) ? 1f : ((num2 < 0f) ? 0f : num2));
			float num3 = 1f + g - ((r > b) ? r : b);
			num3 = ((num3 > 1f) ? 1f : ((num3 < 0f) ? 0f : num3));
			float num4 = 1f + b - ((r > g) ? r : g);
			num4 = ((num4 > 1f) ? 1f : ((num4 < 0f) ? 0f : num4));
			return new Color(num2 - num, num3 - num, num4 - num, 1f);
		}

		public void AddMutationFactor(MutationIncreases factors, string source)
		{
			mutationFactors[source] = factors;
			UpdateMutationIncreases();
		}

		public void RemoveMutationFactor(string source)
		{
			mutationFactors.Remove(source);
			UpdateMutationIncreases();
		}

		public JObject SaveState()
		{
			JObject jObject = new JObject();
			if (!string.IsNullOrEmpty(speciesTag))
			{
				jObject["tag"] = speciesTag;
			}
			if (species != null)
			{
				jObject["speciesID"] = species.speciesID;
			}
			jObject["isReady"] = IsReady;
			jObject["gen"] = generation;
			if (isMutant)
			{
				jObject["isMutant"] = true;
			}
			if (isRad)
			{
				jObject["isRad"] = true;
			}
			if (isRain)
			{
				jObject["isRain"] = true;
			}
			if (isKiller)
			{
				jObject["isKiller"] = true;
			}
			if (isSource)
			{
				jObject["isSource"] = true;
			}
			if (parent1 != null)
			{
				jObject["parent1"] = parent1.GetComponent<BibiteBody>().id.id;
			}
			if (parent2 != null)
			{
				jObject["parent2"] = parent2.GetComponent<BibiteBody>().id.id;
			}
			JToken jToken = (jObject["genes"] = new JObject());
			JToken jToken3 = jToken;
			string[] names = Enum.GetNames(typeof(Genes));
			foreach (string text in names)
			{
				jToken3[text] = JToken.FromObject(genes[(int)Enum.Parse(typeof(Genes), text)]);
			}
			return jObject;
		}

		public void LoadState(JObject state)
		{
			StartGenes();
			if (state["genes"] == null)
			{
				throw new InvalidOperationException("Json object doesn't have genes data");
			}
			if (state["tag"] != null)
			{
				speciesTag = state["tag"].ToString();
			}
			if (state["speciesID"] != null)
			{
				species = GlobalLineageManager.Instance.recordedSpecies.FirstOrDefault((Species s) => s.speciesID == state["speciesID"].ToObject<long>());
			}
			string[] names = Enum.GetNames(typeof(Genes));
			foreach (string text in names)
			{
				int num2 = (int)Enum.Parse(typeof(Genes), text);
				if (state["genes"][text] != null)
				{
					genes[num2] = state["genes"][text].ToObject<float>();
				}
				else
				{
					genes[num2] = BibiteEditorSettings.SettingOfGene(num2).DefaultValue;
				}
			}
			if (state["parent1"] != null)
			{
				parent1ID = (int)state["parent1"];
			}
			if (state["parent2"] != null)
			{
				parent2ID = (int)state["parent2"];
			}
			if (state["isMutant"] != null)
			{
				isMutant = state["isMutant"].ToObject<bool>();
			}
			if (state["isRad"] != null)
			{
				isRad = state["isRad"].ToObject<bool>();
			}
			if (state["isRain"] != null)
			{
				isRain = state["isRain"].ToObject<bool>();
			}
			if (state["isKiller"] != null)
			{
				isKiller = state["isKiller"].ToObject<bool>();
			}
			if (state["isSource"] != null)
			{
				isSource = state["isSource"].ToObject<bool>();
			}
			generation = (int)state["gen"];
			IsReady = (bool)state["isReady"];
			CapGenes();
		}
	}
}
