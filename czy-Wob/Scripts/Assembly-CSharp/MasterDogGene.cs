using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MasterDogGene : MonoBehaviour
{
	public static GeneticVersion currentGeneticVersion = GeneticVersion.THREE;

	public List<Gene> dogGenes = new List<Gene>();

	public List<DominantRecessiveGene> domRecGenes = new List<DominantRecessiveGene>();

	public string debugGene = "";

	public string debugDomRecGene = "";

	private static char seperatorSymbol = '|';

	private string dogGene = "";

	private string domRecGene = "";

	private static float mutationRate = 0.0075f;

	private static float baseDomRecMutationRate = 0f;

	private static float maxDomRecMutationRate = 0.0075f;

	private static int gutFloraMutationMax = 15;

	private static float mutationRateMin = 0.15f;

	private static float mutationRateMax = 1f;

	private static float crossoverRate = 0.7f;

	[HideInInspector]
	public static float superMutationRate = 0.05f;

	private string plusString = "Plus";

	private string minusString = "Minus";

	private static int randomSeedSize = 10;

	private string randomSeed = "0100100010";

	private string geneticRandomSeed;

	private Dictionary<GeneticProperty, int> activeLoopedGeneSet = new Dictionary<GeneticProperty, int>();

	private Dictionary<GeneticProperty, int> loopedGenesPropertyCount = new Dictionary<GeneticProperty, int>();

	private Dictionary<GeneticProperty, GeneValue> geneValueDict = new Dictionary<GeneticProperty, GeneValue>();

	private Dictionary<GeneticProperty, StandardGeneHolder> geneticMapStandard = new Dictionary<GeneticProperty, StandardGeneHolder>();

	private Dictionary<GeneticProperty, SuperGeneHolder> geneticMapSuper = new Dictionary<GeneticProperty, SuperGeneHolder>();

	private Dictionary<GeneticProperty, LoopedGeneHolder> geneticMapLooped = new Dictionary<GeneticProperty, LoopedGeneHolder>();

	private Dictionary<GeneticDomRecProperty, bool> domRecPropertyMap = new Dictionary<GeneticDomRecProperty, bool>();

	private bool runUnitTests;

	private DogLooks looksRef;

	private DogRegistration dogRegRef;

	private void Awake()
	{
		looksRef = GetComponent<DogLooks>();
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		if (runUnitTests)
		{
			UnitTest();
		}
	}

	public float GetRandomSeedFloat()
	{
		return MathUtil.GetFloatFromBinaryString(GetRandomSeedString());
	}

	public string GetRandomSeedString()
	{
		return geneticRandomSeed;
	}

	public string GetPlusStringForGene(string gene)
	{
		return gene + plusString;
	}

	public string GetMinusStringForGene(string gene)
	{
		return gene + minusString;
	}

	public bool ShouldDogUseOldHead()
	{
		if (domRecGene.Length < 40)
		{
			return false;
		}
		if (domRecGene.Substring(0, 5) == "Aaaaa" && domRecGene.Substring(20, 5) == "aaAAa" && domRecGene.Substring(30, 5) == "aaAaa")
		{
			return true;
		}
		return false;
	}

	public GeneticProperty GetGeneticPropertyFromKeyString(string key)
	{
		return (GeneticProperty)Enum.Parse(typeof(GeneticProperty), key);
	}

	public GeneticProperty GetGeneticPropertyPlusFromKeyString(string key)
	{
		return GetGeneticPropertyFromKeyString(key + plusString);
	}

	public GeneticProperty GetGeneticPropertyMinusFromKeyString(string key)
	{
		return GetGeneticPropertyFromKeyString(key + minusString);
	}

	public int GetExpectedGeneSize(GeneticProperty key)
	{
		if (!geneticMapSuper.ContainsKey(key))
		{
			Debug.LogError(string.Concat("GetExpectedGeneSize() is ONLY meant to be called with Super genes, and: ", key, " is not a super gene."));
			return 0;
		}
		return geneticMapSuper[key].GetOriginalLength();
	}

	public float GetMaxValIncrease(GeneticProperty key)
	{
		if (!geneticMapSuper.ContainsKey(key))
		{
			Debug.LogError(string.Concat("GetMaxValIncrease() is ONLY meant to be called with Super genes, and: ", key, " is not a super gene."));
			return 0f;
		}
		return geneticMapSuper[key].GetMaxValIncrease();
	}

	public void SetPropertyCountForLoopedGene(GeneticProperty p, int count)
	{
		loopedGenesPropertyCount[p] = count;
	}

	public int GetPropertyCountForLoopedGene(GeneticProperty p)
	{
		return loopedGenesPropertyCount[p];
	}

	public void SetActiveLoopedGeneSet(GeneticProperty p, int set)
	{
		activeLoopedGeneSet[p] = set;
	}

	public int GetActiveLoopedGeneSet(GeneticProperty p)
	{
		return activeLoopedGeneSet[p];
	}

	public bool IsGeneticPropertyLooped(GeneticProperty key)
	{
		if (geneticMapLooped.ContainsKey(key))
		{
			return true;
		}
		return false;
	}

	public GeneValue GetGeneValues(GeneticProperty key)
	{
		return geneValueDict[key];
	}

	public LoopedGeneHolder GetLoopedGeneHolder(GeneticProperty key)
	{
		return geneticMapLooped[key];
	}

	public void SetGeneValues(GeneticProperty key, float val, float minVal, float maxVal, float defaultMaxVal, float? trueMax = null, float? trueVal = null)
	{
		if (!geneticMapLooped.ContainsKey(key))
		{
			if (!geneValueDict.ContainsKey(key))
			{
				geneValueDict[key] = new GeneValue();
			}
			geneValueDict[key].SetValues(val, minVal, maxVal, defaultMaxVal, trueMax, trueVal);
		}
	}

	public void UpdateGeneString(GeneticProperty key, string newGene, bool updateActualGene = true)
	{
		if (geneticMapStandard.ContainsKey(key))
		{
			if (newGene.Length != geneticMapStandard[key].GetGeneString().Length)
			{
				Debug.LogError("Invalid gene string for " + key);
			}
			geneticMapStandard[key].UpdateGene(newGene);
		}
		if (geneticMapSuper.ContainsKey(key))
		{
			SuperGeneHolder superGeneHolder = geneticMapSuper[key];
			SuperGeneHolder value = new SuperGeneHolder(newGene, newGene.Length, superGeneHolder.GetMaxValIncrease());
			geneticMapSuper[key] = value;
		}
		if (geneticMapLooped.ContainsKey(key))
		{
			LoopedGeneHolder loopedGeneHolder = geneticMapLooped[key];
			LoopedGeneHolder value2 = new LoopedGeneHolder(newGene, loopedGeneHolder.GetLoopLength(), loopedGeneHolder.IsDiscrete());
			if (newGene.Length != loopedGeneHolder.GetTotalLength())
			{
				Debug.LogError("Invalid gene string for " + key);
			}
			geneticMapLooped[key] = value2;
		}
		if (updateActualGene)
		{
			UpdateActualGene();
		}
	}

	public void UpdateActualGene()
	{
		UpdateGeneInternal();
	}

	public string GetFullGene()
	{
		return dogGene;
	}

	public string GetDomRecGene()
	{
		return domRecGene;
	}

	public SaveableDogGene GetSaveableDogGene(SaveableDogGene referenceSD)
	{
		SaveableDogGene saveableDogGene = new SaveableDogGene();
		saveableDogGene.dogGene = dogGene;
		saveableDogGene.domRecGene = domRecGene;
		saveableDogGene.geneVersion = currentGeneticVersion;
		if (referenceSD != null)
		{
			saveableDogGene.puppyCode = referenceSD.puppyCode;
			saveableDogGene.childCode = referenceSD.childCode;
			saveableDogGene.teenCode = referenceSD.teenCode;
			saveableDogGene.youngAdultCode = referenceSD.youngAdultCode;
		}
		dogRegRef.PopulateLoopedGeneticsMap(saveableDogGene);
		return saveableDogGene;
	}

	private void UpdateGeneInternal()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(dogGene.Substring(0, randomSeedSize));
		for (int i = 0; i < dogGenes.Count; i++)
		{
			if (dogGenes[i].geneType != GeneType.SUPER)
			{
				string key = dogGenes[i].key;
				if (dogGenes[i].plusMinus)
				{
					string key2 = key + plusString;
					string key3 = key + minusString;
					stringBuilder.Append(GetStoredGeneStringForKey(key2));
					stringBuilder.Append(GetStoredGeneStringForKey(key3));
				}
				else
				{
					stringBuilder.Append(GetStoredGeneStringForKey(key));
				}
			}
		}
		for (int j = 0; j < dogGenes.Count; j++)
		{
			if (dogGenes[j].geneType == GeneType.SUPER)
			{
				stringBuilder.Append(seperatorSymbol);
				string key4 = dogGenes[j].key;
				if (dogGenes[j].plusMinus)
				{
					string key5 = key4 + plusString;
					string key6 = key4 + minusString;
					stringBuilder.Append(GetStoredGeneStringForKey(key5));
					stringBuilder.Append(seperatorSymbol);
					stringBuilder.Append(GetStoredGeneStringForKey(key6));
				}
				else
				{
					stringBuilder.Append(GetStoredGeneStringForKey(key4));
				}
			}
		}
		dogGene = stringBuilder.ToString();
	}

	public string GetStoredGeneStringForKey(string key)
	{
		GeneticProperty geneticPropertyFromKeyString = GetGeneticPropertyFromKeyString(key);
		if (geneticMapStandard.ContainsKey(geneticPropertyFromKeyString))
		{
			return geneticMapStandard[geneticPropertyFromKeyString].GetGeneString();
		}
		if (geneticMapSuper.ContainsKey(geneticPropertyFromKeyString))
		{
			return geneticMapSuper[geneticPropertyFromKeyString].GetGene();
		}
		if (geneticMapLooped.ContainsKey(geneticPropertyFromKeyString))
		{
			return geneticMapLooped[geneticPropertyFromKeyString].GetRawGene();
		}
		Debug.LogError("Gene not found");
		return "";
	}

	public string GetGeneString(GeneticProperty key, bool raw = false)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if (geneticMapStandard.ContainsKey(key))
		{
			flag = true;
		}
		if (geneticMapSuper.ContainsKey(key))
		{
			flag2 = true;
		}
		if (geneticMapLooped.ContainsKey(key))
		{
			flag3 = true;
		}
		if (!flag && !flag2 && !flag3)
		{
			Debug.LogError("No valid gene found for key: " + key);
			return "";
		}
		if ((flag && flag2) || (flag && flag3) || (flag2 && flag3))
		{
			Debug.LogError(string.Concat("Key ", key, " found in multiple gene dictionaries!"));
			return "";
		}
		if (flag)
		{
			return geneticMapStandard[key].GetGeneString();
		}
		if (flag2)
		{
			return geneticMapSuper[key].GetGene();
		}
		if (flag3)
		{
			if (raw)
			{
				return geneticMapLooped[key].GetRawGene();
			}
			return geneticMapLooped[key].GetGene();
		}
		Debug.LogError("Something went wrong here in GetGene()... ominous...");
		return "";
	}

	public void MapDogGene(SaveableDogGene newGene = null, bool mutateGene = false, bool randomizeGene = false)
	{
		if (newGene != null && newGene.dogGene != null && newGene.dogGene.Length > 1)
		{
			dogGene = newGene.dogGene;
		}
		else if (debugGene.Length > 2)
		{
			dogGene = debugGene;
		}
		else
		{
			dogGene = GenerateNewGene(randomizeGene);
		}
		if (newGene != null && newGene.domRecGene != null && newGene.domRecGene.Length > 1)
		{
			domRecGene = newGene.domRecGene;
		}
		else if (debugDomRecGene.Length > 2)
		{
			domRecGene = debugDomRecGene;
		}
		else
		{
			domRecGene = GenerateNewDomRecGene(randomizeGene);
		}
		if (mutateGene)
		{
			dogGene = MutateGenome(dogGene);
		}
		MapGeneInternal();
		MapDomRecGeneInternal();
	}

	public static void MigrateSaveableDogGene(SaveableDogGene oldSaveableGene)
	{
		if (oldSaveableGene == null)
		{
			return;
		}
		DogRegistration globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		DogLooks component = globalComponent.globalDogprefab.GetComponent<DogLooks>();
		bool flag = false;
		if (oldSaveableGene.geneVersion != currentGeneticVersion)
		{
			flag = true;
		}
		else if (oldSaveableGene.dynamicLoopPropertiesCounter != null)
		{
			for (int i = 0; i < oldSaveableGene.dynamicLoopPropertiesCounter.keys.Count; i++)
			{
				if (component.GetLoopCountForGene(oldSaveableGene.dynamicLoopPropertiesCounter.keys[i]) != oldSaveableGene.dynamicLoopPropertiesCounter.values[i])
				{
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			return;
		}
		if (oldSaveableGene.dogGene.Length == 0 && oldSaveableGene.dogGeneEncoded.Length == 0 && oldSaveableGene.domRecGene.Length == 0 && oldSaveableGene.domRecGeneEncoded.Length == 0)
		{
			oldSaveableGene.geneVersion = currentGeneticVersion;
			return;
		}
		string text = oldSaveableGene.dogGene;
		StringBuilder stringBuilder = new StringBuilder();
		MasterDogGene component2 = globalComponent.globalDogprefab.GetComponent<MasterDogGene>();
		int num = 0;
		stringBuilder.Append(text.Substring(num, randomSeedSize));
		num += randomSeedSize;
		for (int j = 0; j < component2.dogGenes.Count; j++)
		{
			if (component2.dogGenes[j].geneType == GeneType.SUPER)
			{
				continue;
			}
			int num2 = 0;
			int num3 = 0;
			if (component2.dogGenes[j].geneType == GeneType.LOOPED)
			{
				int num4 = component2.dogGenes[j].loopCount;
				if (component2.dogGenes[j].dynamicLoopCount)
				{
					num4 = component.GetLoopCountForGene(component2.dogGenes[j].key);
					if (oldSaveableGene.dynamicLoopPropertiesCounter != null)
					{
						int num5 = oldSaveableGene.dynamicLoopPropertiesCounter.keys.IndexOf(component2.dogGenes[j].key);
						if (num5 >= 0)
						{
							int num6 = oldSaveableGene.dynamicLoopPropertiesCounter.values[num5];
							if (num6 > num4)
							{
								Debug.LogError("Something went massively wrong. The saved loop count should never be less than the updated loop count.");
							}
							else if (num6 < num4)
							{
								num3 = num4 - num6;
								num4 = num6;
							}
						}
					}
				}
				num2 += component2.dogGenes[j].length * num4;
				if (component2.dogGenes[j].plusMinus)
				{
					num2 += component2.dogGenes[j].length * num4;
				}
			}
			else
			{
				num2 += component2.dogGenes[j].length;
				if (component2.dogGenes[j].plusMinus)
				{
					num2 += component2.dogGenes[j].length;
				}
			}
			if (component2.dogGenes[j].version <= oldSaveableGene.geneVersion)
			{
				string value;
				try
				{
					value = text.Substring(num, num2);
				}
				catch
				{
					value = GenerateBaseGeneOfSize(num2, addSeperator: false);
				}
				stringBuilder.Append(value);
				num += num2;
				num2 = 0;
				if (num3 > 0)
				{
					num2 += component2.dogGenes[j].length * num3;
					if (component2.dogGenes[j].plusMinus)
					{
						num2 += component2.dogGenes[j].length * num3;
					}
					stringBuilder.Append(GenerateBaseGeneOfSize(num2, addSeperator: false));
				}
			}
			else
			{
				stringBuilder.Append(GenerateBaseGeneOfSize(num2, addSeperator: false));
			}
		}
		for (int k = 0; k < component2.dogGenes.Count; k++)
		{
			if (component2.dogGenes[k].geneType != GeneType.SUPER)
			{
				continue;
			}
			bool flag2 = false;
			bool flag3 = false;
			int length = component2.dogGenes[k].length;
			if (component2.dogGenes[k].version <= oldSaveableGene.geneVersion)
			{
				int num2;
				if (num + 1 < text.Length)
				{
					num2 = text.IndexOf(seperatorSymbol, num + 1) - num;
					if (num2 < 0)
					{
						num2 = length;
					}
				}
				else
				{
					num2 = length;
					flag2 = true;
				}
				if (component2.dogGenes[k].plusMinus)
				{
					if (num + 1 + num2 < text.Length)
					{
						num2 = text.IndexOf(seperatorSymbol, num + 1 + num2) - num;
						if (num2 < 0)
						{
							num2 = length;
						}
					}
					else
					{
						num2++;
						num2 += length;
						flag3 = true;
					}
				}
				if (text.Length <= num + num2 || flag2 || flag3)
				{
					stringBuilder.Append(GenerateBaseGeneOfSize(length));
					if (component2.dogGenes[k].plusMinus)
					{
						stringBuilder.Append(GenerateBaseGeneOfSize(length));
					}
				}
				else
				{
					stringBuilder.Append(text.Substring(num, num2));
				}
				num += num2;
			}
			else
			{
				stringBuilder.Append(GenerateBaseGeneOfSize(length));
				if (component2.dogGenes[k].plusMinus)
				{
					stringBuilder.Append(GenerateBaseGeneOfSize(length));
				}
			}
		}
		num = 0;
		string text2 = oldSaveableGene.domRecGene;
		StringBuilder stringBuilder2 = new StringBuilder();
		for (int l = 0; l < component2.domRecGenes.Count; l++)
		{
			if (component2.domRecGenes[l].version <= oldSaveableGene.geneVersion && text2.Length >= num + 1)
			{
				stringBuilder2.Append(text2.Substring(num, 2));
				num += 2;
			}
			else
			{
				stringBuilder2.Append(component2.GetDomRecStringForTraitType(component2.domRecGenes[l].defaultValue));
			}
		}
		oldSaveableGene.dogGene = stringBuilder.ToString();
		oldSaveableGene.domRecGene = stringBuilder2.ToString();
		globalComponent.PopulateLoopedGeneticsMap(oldSaveableGene);
		oldSaveableGene.geneVersion = currentGeneticVersion;
	}

	public static string BreedDomRecGenes(string a, string b, float stability)
	{
		if (a.Length != b.Length)
		{
			Debug.LogError("Mismatched genetics!");
			return a;
		}
		int length = a.Length;
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < length; i += 2)
		{
			stringBuilder.Append((UnityEngine.Random.value >= 0.5f) ? a.Substring(i, 1) : a.Substring(i + 1, 1));
			stringBuilder.Append((UnityEngine.Random.value >= 0.5f) ? b.Substring(i, 1) : b.Substring(i + 1, 1));
		}
		float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(1f - stability, baseDomRecMutationRate, maxDomRecMutationRate);
		for (int j = 0; j < length; j++)
		{
			if (UnityEngine.Random.value <= valueOfRangePercentage)
			{
				stringBuilder[j] = ((stringBuilder[j] == 'a') ? 'A' : 'a');
			}
		}
		return stringBuilder.ToString();
	}

	public static string Breed(string a, string b, int debugCrossoverIndex = -1)
	{
		if (UnityEngine.Random.value <= crossoverRate || debugCrossoverIndex != -1)
		{
			return CrossoverGenes(a, b, debugCrossoverIndex);
		}
		if (UnityEngine.Random.value > 0.5f)
		{
			return a;
		}
		return b;
	}

	public static string CrossoverGenes(string a, string b, int debugCrossoverIndex = -1)
	{
		string combinedGene = "";
		float num = 1f;
		while (a.Length > 0 && b.Length > 0)
		{
			int num2 = Mathf.Max(a.Length, b.Length);
			int crossoverIndex = ((!(UnityEngine.Random.value < num)) ? num2 : UnityEngine.Random.Range(1, num2));
			if (debugCrossoverIndex != -1)
			{
				crossoverIndex = debugCrossoverIndex;
			}
			if (UnityEngine.Random.value > 0.5f)
			{
				CrossoverGenesInternal(crossoverIndex, ref a, ref b, ref combinedGene);
			}
			else
			{
				CrossoverGenesInternal(crossoverIndex, ref b, ref a, ref combinedGene);
			}
			num /= 2f;
		}
		return combinedGene;
	}

	private static void CrossoverGenesInternal(int crossoverIndex, ref string a, ref string b, ref string combinedGene)
	{
		if (crossoverIndex == 0)
		{
			crossoverIndex = 1;
		}
		if (crossoverIndex > a.Length)
		{
			crossoverIndex = a.Length;
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < crossoverIndex; i++)
		{
			if (a[i] == seperatorSymbol)
			{
				num++;
				num2 = 0;
			}
			else
			{
				num2++;
			}
		}
		combinedGene += a.Substring(0, crossoverIndex);
		a = a.Substring(crossoverIndex, a.Length - crossoverIndex);
		int num3 = -1;
		if (num == 0)
		{
			if (b[0] == seperatorSymbol)
			{
				return;
			}
			num3 = 0;
		}
		else
		{
			for (int j = 0; j < b.Length; j++)
			{
				if (b[j] == seperatorSymbol)
				{
					num--;
					if (num == 0)
					{
						num3 = j + 1;
						break;
					}
				}
			}
			if (num3 == -1)
			{
				Debug.LogError("Something went wrong! Unable to find the appropriate amount of seperator symbols in gene B. This implies genes A and B have a different number of properites but this should not be possible.");
				return;
			}
		}
		for (int k = 1; k < num2; k++)
		{
			if (num3 + k >= b.Length)
			{
				b = "";
				return;
			}
			if (b[num3 + k] == seperatorSymbol)
			{
				num2 = k - 1;
				break;
			}
		}
		crossoverIndex = num3 + num2;
		b = b.Substring(crossoverIndex, b.Length - crossoverIndex);
	}

	public string GenerateNewDomRecGene(bool randomizeGene = false)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < domRecGenes.Count; i++)
		{
			if (randomizeGene)
			{
				stringBuilder.Append((UnityEngine.Random.value > 0.5f) ? "A" : "a");
				stringBuilder.Append((UnityEngine.Random.value > 0.5f) ? "A" : "a");
			}
			else
			{
				stringBuilder.Append(GetDomRecStringForTraitType(domRecGenes[i].defaultValue));
			}
		}
		return stringBuilder.ToString();
	}

	private string GetDomRecStringForTraitType(TraitType t)
	{
		switch (t)
		{
		case TraitType.HET_Aa:
			return "Aa";
		case TraitType.HOMO_DOM_AA:
			return "AA";
		case TraitType.HOMO_SUB_aa:
			return "aa";
		default:
			Debug.LogError("No handling found for TraitType: " + t);
			return "AA";
		}
	}

	public string GenerateNewGene(bool randomizeGene = false)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (randomizeGene)
		{
			stringBuilder.Append(GenerateRandomGeneOfSize(randomSeedSize, addSeperator: false));
		}
		else
		{
			stringBuilder.Append(randomSeed);
		}
		int num = 0;
		for (int i = 0; i < dogGenes.Count; i++)
		{
			if (dogGenes[i].geneType == GeneType.SUPER)
			{
				continue;
			}
			num = dogGenes[i].length;
			if (dogGenes[i].geneType == GeneType.LOOPED)
			{
				int num2 = dogGenes[i].loopCount;
				if (dogGenes[i].dynamicLoopCount)
				{
					num2 = looksRef.GetLoopCountForGene(dogGenes[i].key);
				}
				num *= num2;
			}
			if (dogGenes[i].plusMinus)
			{
				num *= 2;
			}
			if (randomizeGene)
			{
				stringBuilder.Append(GenerateRandomGeneOfSize(num, addSeperator: false));
			}
			else
			{
				stringBuilder.Append(GenerateBaseGeneOfSize(num, addSeperator: false));
			}
		}
		for (int j = 0; j < dogGenes.Count; j++)
		{
			if (dogGenes[j].geneType != GeneType.SUPER)
			{
				continue;
			}
			num = dogGenes[j].length;
			if (randomizeGene)
			{
				stringBuilder.Append(GenerateRandomGeneOfSize(num));
				if (dogGenes[j].plusMinus)
				{
					stringBuilder.Append(GenerateRandomGeneOfSize(num));
				}
			}
			else
			{
				stringBuilder.Append(GenerateBaseGeneOfSize(num));
				if (dogGenes[j].plusMinus)
				{
					stringBuilder.Append(GenerateBaseGeneOfSize(num));
				}
			}
		}
		return stringBuilder.ToString();
	}

	private string GenerateRandomGeneOfSize(int size, bool addSeperator = true)
	{
		string text = "";
		if (addSeperator)
		{
			text += seperatorSymbol;
		}
		for (int i = 0; i < size; i++)
		{
			text = ((!(UnityEngine.Random.value >= 0.5f)) ? (text + "1") : (text + "0"));
		}
		return text;
	}

	private static string GenerateBaseGeneOfSize(int size, bool addSeperator = true)
	{
		string text = "";
		if (addSeperator)
		{
			text += seperatorSymbol;
		}
		for (int i = 0; i < size; i++)
		{
			text += "0";
		}
		return text;
	}

	public Dictionary<GutFloraMutationEffect, FloraMutationInfo> AdvanceDogGenes(SaveableDog sd, GameSettings.PassiveMutationRate floraMutationEffects, GameSettings.PassiveMutationRate pupationMutationRate)
	{
		Dictionary<GutFloraMutationEffect, FloraMutationInfo> dictionary = new Dictionary<GutFloraMutationEffect, FloraMutationInfo>();
		if (sd == null || sd.gut == null)
		{
			Debug.LogError("Attempting to advance dog genes but no saveableDog or gut were found.");
			return dictionary;
		}
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		FloraManager globalComponent = registrationScript.GetGlobalComponent<FloraManager>(GlobalObject.FLORA_MANAGER);
		DogGutsManager globalComponent2 = registrationScript.GetGlobalComponent<DogGutsManager>(GlobalObject.DOG_GUT_MANAGER);
		List<bool> list = new List<bool>();
		List<GutFloraMutationEffect> list2 = new List<GutFloraMutationEffect>();
		List<List<string>> list3 = new List<List<string>>();
		for (int i = 0; i < sd.gut.gutFlora.Count; i++)
		{
			if (floraMutationEffects == GameSettings.PassiveMutationRate.NONE)
			{
				continue;
			}
			GutFloraBase component = globalComponent2.GetFloraForPath(sd.gut.gutFlora[i].path).gutFloraPrefab.GetComponent<GutFloraBase>();
			for (int j = 0; j < component.mutationEffects.Count; j++)
			{
				if (!list2.Contains(component.mutationEffects[j].effect))
				{
					list.Add(item: false);
					dictionary[component.mutationEffects[j].effect] = new FloraMutationInfo();
					list2.Add(component.mutationEffects[j].effect);
				}
				string path = sd.gut.gutFlora[i].path;
				if (!dictionary[component.mutationEffects[j].effect].uniqueFlora.Contains(path))
				{
					dictionary[component.mutationEffects[j].effect].uniqueFlora.Add(path);
				}
				dictionary[component.mutationEffects[j].effect].totalFloraCount++;
				if (sd.gut.gutFlora[i].boosted)
				{
					dictionary[component.mutationEffects[j].effect].totalFloraCount++;
				}
				switch (floraMutationEffects)
				{
				case GameSettings.PassiveMutationRate.HIGH:
					dictionary[component.mutationEffects[j].effect].totalFloraCount++;
					break;
				case GameSettings.PassiveMutationRate.VERY_HIGH:
					dictionary[component.mutationEffects[j].effect].totalFloraCount += 2;
					break;
				}
				int num = list2.IndexOf(component.mutationEffects[j].effect);
				if (num >= list3.Count)
				{
					list3.Add(new List<string>());
				}
				if (GutFloraMutationEffectInfo.RarityCheck(component.mutationEffects[j].rarity))
				{
					list[num] = true;
				}
				list3[num].Add(sd.gut.gutFlora[i].path);
			}
		}
		for (int k = 0; k < list2.Count; k++)
		{
			if (list[k])
			{
				for (int l = 0; l < list3[k].Count; l++)
				{
					globalComponent.ReportEffectUnlock(list3[k][l], list2[k], unlockStatus: true);
				}
				float valueOfRangePercentage = MathUtil.GetValueOfRangePercentage(Mathf.Min((float)dictionary[list2[k]].totalFloraCount, (float)gutFloraMutationMax) / (float)gutFloraMutationMax, mutationRateMin, mutationRateMax);
				GutFloraMutations.MutateGeneFromEffect(this, list2[k], sd.brain.dogAge, valueOfRangePercentage, dictionary[list2[k]]);
			}
		}
		UpdateActualGene();
		switch (pupationMutationRate)
		{
		case GameSettings.PassiveMutationRate.DEFAULT:
			dogGene = MutateGenome(dogGene);
			break;
		case GameSettings.PassiveMutationRate.HIGH:
			dogGene = MutateGenome(dogGene, allowSuperMutations: true, forceMutation: true, 2f);
			break;
		case GameSettings.PassiveMutationRate.VERY_HIGH:
			dogGene = MutateGenome(dogGene, allowSuperMutations: true, forceMutation: true, 10f);
			break;
		}
		MapGeneInternal();
		DogRegistration globalComponent3 = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		sd.dogGene = GetSaveableDogGene(sd.dogGene);
		globalComponent3.UpdateSaveableDog(sd);
		return dictionary;
	}

	public static string MutateGenome(string genome, bool allowSuperMutations = true, bool forceMutation = true, float mutationRateMultiplier = 1f)
	{
		float num = mutationRate * mutationRateMultiplier;
		StringBuilder stringBuilder = new StringBuilder();
		int length = genome.Length;
		for (int i = 0; i < length; i++)
		{
			if (genome[i] != seperatorSymbol && UnityEngine.Random.value <= num)
			{
				int num2 = int.Parse(new string(genome[i], 1));
				int num3 = (num2 ^= 1);
				stringBuilder.Append(num3.ToString());
			}
			else
			{
				stringBuilder.Append(genome[i]);
			}
		}
		string text = stringBuilder.ToString();
		if (allowSuperMutations)
		{
			text = SuperMutation(text);
		}
		if (text == genome && forceMutation)
		{
			return MutateGenome(genome, allowSuperMutations);
		}
		return text;
	}

	private static string SuperMutation(string gene)
	{
		if (UnityEngine.Random.value <= superMutationRate)
		{
			int num = gene.IndexOf(seperatorSymbol);
			int num2 = UnityEngine.Random.Range(num + 1, gene.Length - 1);
			int num3;
			for (num3 = num2; num3 > num; num3--)
			{
				if (num3 < 0 || num3 >= gene.Length)
				{
					Debug.LogError("Invalid startIndex: " + num3);
					return gene;
				}
				if (gene[num3] == seperatorSymbol)
				{
					num3++;
					break;
				}
			}
			int i;
			for (i = num3; i < gene.Length - 1; i++)
			{
				if (i < 0 || i >= gene.Length)
				{
					Debug.LogError("Invalid endIndex: " + i);
					return gene;
				}
				if (gene[i] == seperatorSymbol)
				{
					i--;
					break;
				}
			}
			int num4 = i - num3 + 1;
			Gene specificSuperGeneForIndex = GetSpecificSuperGeneForIndex(num2, gene);
			if (specificSuperGeneForIndex == null)
			{
				Debug.LogError("No super gene found for index: " + num2);
				return gene;
			}
			if ((num4 <= specificSuperGeneForIndex.length || UnityEngine.Random.value >= 0.5f) && num4 < MathUtil.maxGeneLen)
			{
				gene = ((!(UnityEngine.Random.value >= 0.5f)) ? gene.Insert(num2, "1") : gene.Insert(num2, "0"));
			}
			else if (num4 > specificSuperGeneForIndex.length)
			{
				if (gene[num2] == seperatorSymbol)
				{
					return gene;
				}
				gene = gene.Remove(num2, 1);
			}
		}
		return gene;
	}

	public static Gene GetSpecificSuperGeneForIndex(int index, string fullGene)
	{
		MasterDogGene component = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).globalDogprefab.GetComponent<MasterDogGene>();
		int num = fullGene.IndexOf(seperatorSymbol) + 1;
		for (int i = 0; i < component.dogGenes.Count; i++)
		{
			if (component.dogGenes[i].geneType != GeneType.SUPER)
			{
				continue;
			}
			int num2 = 1;
			if (component.dogGenes[i].plusMinus)
			{
				num2 = 2;
			}
			while (num2 > 0)
			{
				int num3 = fullGene.IndexOf(seperatorSymbol, num);
				if (num3 == -1)
				{
					num3 = fullGene.Length;
				}
				if (index >= num && index <= num3)
				{
					return component.dogGenes[i];
				}
				num = num3 + 1;
				num2--;
			}
		}
		return null;
	}

	public bool GetDomRecPropertyStatus(GeneticDomRecProperty property, bool log = true)
	{
		try
		{
			return domRecPropertyMap[property];
		}
		catch
		{
			if (log)
			{
				Debug.LogError(string.Concat("Missing DomRec property: ", property, " This dog was likely manually edited."));
			}
		}
		return false;
	}

	public void CheckGeneticGoals()
	{
		float num = 0.85f;
		if (GoalsController.GetCounterForCondition(GoalCondition.MORE_THAN_4_LEGS) == 0 && GetComponent<LegController>().GetLegCount() > 4)
		{
			GoalsController.SetGoalEvent(GoalCondition.MORE_THAN_4_LEGS, 1);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.LARGE_DOG) == 0 && looksRef.GetGlobalScaleMod() >= looksRef.GetMaxGlobalScaleMod() * num)
		{
			GoalsController.SetGoalEvent(GoalCondition.LARGE_DOG, 1);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.SMALL_DOG) == 0 && looksRef.GetGlobalScaleMod() <= (0f - looksRef.GetMinGlobalScaleMod()) * num)
		{
			GoalsController.SetGoalEvent(GoalCondition.SMALL_DOG, 1);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.FLAT_DOG) == 0 && looksRef.GetBodyHeightMod() <= (0f - looksRef.GetMinBodyHeightMod()) * num)
		{
			GoalsController.SetGoalEvent(GoalCondition.FLAT_DOG, 1);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.TALL_DOG) == 0 && looksRef.GetBodyHeightMod() >= looksRef.GetMaxBodyHeightMod() * num)
		{
			GoalsController.SetGoalEvent(GoalCondition.TALL_DOG, 1);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.LONG_BODY) == 0 && looksRef.GetBodyLengthMod() >= looksRef.GetMaxBodyLengthMod() * num)
		{
			GoalsController.SetGoalEvent(GoalCondition.LONG_BODY, 1);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.SHORT_BODY) == 0 && looksRef.GetBodyLengthMod() <= (0f - looksRef.GetMinBodyLengthMod()) * num)
		{
			GoalsController.SetGoalEvent(GoalCondition.SHORT_BODY, 1);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.HORNS) == 0 && looksRef.GetHornType() != HornType.NO_HORNS)
		{
			GoalsController.SetGoalEvent(GoalCondition.HORNS, 1);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.TAIL) == 0 && looksRef.GetTailNumber() > 0 && looksRef.GetTailType() != TailType.NO_TAIL)
		{
			GoalsController.SetGoalEvent(GoalCondition.TAIL, 1);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.MULTIPLE_TAILS) == 0 && looksRef.GetTailNumber() > 1 && looksRef.GetTailType() != TailType.NO_TAIL)
		{
			GoalsController.SetGoalEvent(GoalCondition.MULTIPLE_TAILS, 1);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.MULTIPLE_HEADS) == 0 && looksRef.GetHeadCount() > 1 && !looksRef.useOldHead)
		{
			GoalsController.SetGoalEvent(GoalCondition.MULTIPLE_HEADS, 1);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.LONG_LEGS) == 0 && looksRef.GetCombinedLegLength() >= looksRef.GetMaxCombinedLegLength() * num)
		{
			GoalsController.SetGoalEvent(GoalCondition.LONG_LEGS, 1);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.SMALL_HEAD) == 0 && looksRef.HasTinyHead() && !looksRef.useOldHead)
		{
			GoalsController.SetGoalEvent(GoalCondition.SMALL_HEAD, 1);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.BIG_HEAD) == 0 && (looksRef.HasBigHead() || looksRef.GetHeadSize() >= looksRef.GetMaxHeadSize() * num) && !looksRef.useOldHead)
		{
			GoalsController.SetGoalEvent(GoalCondition.BIG_HEAD, 1);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.WIDE_DOG) == 0 && looksRef.GetBodyWidthMod() >= looksRef.GetMaxBodyWidthMod() * num)
		{
			GoalsController.SetGoalEvent(GoalCondition.WIDE_DOG, 1);
		}
	}

	private void MapDomRecGeneInternal()
	{
		domRecPropertyMap.Clear();
		foreach (GeneticDomRecProperty value in EnumUtils.GetValues<GeneticDomRecProperty>())
		{
			if (value != GeneticDomRecProperty.NONE)
			{
				domRecPropertyMap[value] = false;
			}
		}
		for (int i = 0; i < domRecGenes.Count; i++)
		{
			string text = domRecGene.Substring(i * 2, 2);
			TraitType currentValue = TraitType.HOMO_DOM_AA;
			switch (text)
			{
			case "Aa":
			case "aA":
				currentValue = TraitType.HET_Aa;
				break;
			case "aa":
				currentValue = TraitType.HOMO_SUB_aa;
				break;
			}
			domRecGenes[i].SetCurrentValue(currentValue);
			GeneticDomRecProperty currentProperty = domRecGenes[i].GetCurrentProperty();
			if (currentProperty != GeneticDomRecProperty.NONE)
			{
				domRecPropertyMap[currentProperty] = true;
			}
		}
	}

	private void MapGeneInternal()
	{
		geneticRandomSeed = "";
		geneticMapSuper.Clear();
		geneticMapLooped.Clear();
		geneticMapStandard.Clear();
		geneticRandomSeed = dogGene.Substring(0, randomSeedSize);
		int currentSuperIndex = 0;
		int currentStandardIndex = randomSeedSize;
		for (int i = 0; i < dogGenes.Count; i++)
		{
			if (dogGenes[i].geneType == GeneType.SUPER)
			{
				if (dogGenes[i].plusMinus)
				{
					MapSuperGeneInternal(ref currentSuperIndex, i, plusString);
					MapSuperGeneInternal(ref currentSuperIndex, i, minusString);
				}
				else
				{
					MapSuperGeneInternal(ref currentSuperIndex, i);
				}
			}
			else if (dogGenes[i].geneType == GeneType.LOOPED)
			{
				if (dogGenes[i].plusMinus)
				{
					MapLoopedGeneInternal(ref currentStandardIndex, i, plusString);
					MapLoopedGeneInternal(ref currentStandardIndex, i, minusString);
				}
				else
				{
					MapLoopedGeneInternal(ref currentStandardIndex, i);
				}
			}
			else if (dogGenes[i].plusMinus)
			{
				MapStandardGeneInternal(ref currentStandardIndex, i, plusString);
				MapStandardGeneInternal(ref currentStandardIndex, i, minusString);
			}
			else
			{
				MapStandardGeneInternal(ref currentStandardIndex, i);
			}
		}
	}

	private void MapSuperGeneInternal(ref int currentSuperIndex, int index, string optionalKeyAddition = "", bool minus = false)
	{
		int num = dogGene.IndexOf(seperatorSymbol, currentSuperIndex) + 1;
		if (num == 0)
		{
			Debug.LogError("Missing valid separator symbol. Something went wrong. Fixing up manually.");
			dogGene += GenerateBaseGeneOfSize(dogGenes[index].length);
			num = dogGene.IndexOf(seperatorSymbol, currentSuperIndex) + 1;
		}
		int num2 = dogGene.IndexOf(seperatorSymbol, num);
		if (num2 == -1)
		{
			num2 = dogGene.Length;
		}
		GeneticProperty geneticPropertyFromKeyString = GetGeneticPropertyFromKeyString(dogGenes[index].key + optionalKeyAddition);
		float newMaxValIncrease = dogGenes[index].superMutationValueAddition;
		if (minus)
		{
			newMaxValIncrease = 0f;
		}
		geneticMapSuper[geneticPropertyFromKeyString] = new SuperGeneHolder(dogGene.Substring(num, num2 - num), dogGenes[index].length, newMaxValIncrease);
		currentSuperIndex = num;
	}

	private void MapLoopedGeneInternal(ref int currentStandardIndex, int index, string optionalKeyAddition = "")
	{
		int num = dogGenes[index].loopCount;
		if (dogGenes[index].dynamicLoopCount)
		{
			num = looksRef.GetLoopCountForGene(dogGenes[index].key);
		}
		LoopedGeneHolder value;
		try
		{
			value = new LoopedGeneHolder(dogGene.Substring(currentStandardIndex, dogGenes[index].length * num), dogGenes[index].length, dogGenes[index].discrete);
		}
		catch
		{
			Debug.LogError("Dog gene is too short. Generating new empty gene.");
			value = new LoopedGeneHolder(GenerateBaseGeneOfSize(dogGenes[index].length * num, addSeperator: false), dogGenes[index].length, dogGenes[index].discrete);
		}
		GeneticProperty geneticPropertyFromKeyString = GetGeneticPropertyFromKeyString(dogGenes[index].key + optionalKeyAddition);
		geneticMapLooped[geneticPropertyFromKeyString] = value;
		currentStandardIndex += dogGenes[index].length * num;
	}

	private void MapStandardGeneInternal(ref int currentStandardIndex, int index, string optionalKeyAddition = "")
	{
		GeneticProperty geneticPropertyFromKeyString = GetGeneticPropertyFromKeyString(dogGenes[index].key + optionalKeyAddition);
		geneticMapStandard[geneticPropertyFromKeyString] = new StandardGeneHolder(dogGene.Substring(currentStandardIndex, dogGenes[index].length));
		currentStandardIndex += dogGenes[index].length;
	}

	private void UnitTest()
	{
		int size = 100;
		GenerateRandomGeneOfSize(size, addSeperator: false);
		GenerateRandomGeneOfSize(size);
		GenerateBaseGeneOfSize(size, addSeperator: false);
		GenerateBaseGeneOfSize(size);
		List<GeneticProperty> list = new List<GeneticProperty>();
		MapDogGene();
		for (int i = 0; i < dogGenes.Count; i++)
		{
			list.Clear();
			if (dogGenes[i].plusMinus)
			{
				list.Add(GetGeneticPropertyFromKeyString(dogGenes[i].key + plusString));
				list.Add(GetGeneticPropertyFromKeyString(dogGenes[i].key + minusString));
			}
			else
			{
				list.Add(GetGeneticPropertyFromKeyString(dogGenes[i].key));
			}
			for (int j = 0; j < list.Count; j++)
			{
				_ = list[j];
				if (dogGenes[i].geneType != GeneType.SUPER && dogGenes[i].geneType == GeneType.LOOPED)
				{
					_ = dogGenes[i].loopCount;
					if (dogGenes[i].dynamicLoopCount)
					{
						looksRef.GetLoopCountForGene(dogGenes[i].key);
					}
				}
			}
		}
		string text = "0000";
		string text2 = "1111";
		for (int k = 0; k < 100; k++)
		{
		}
		text = "0000|00|00";
		text2 = "1111|11|11";
		for (int l = 0; l < 100; l++)
		{
		}
		text = "00|000|0000|00000000000";
		text2 = "11|11|11|11";
		int expectedCount = 3;
		for (int m = 0; m < 100; m++)
		{
			AssertSeperatorCount(Breed(text, text2), expectedCount);
		}
		text = "|00";
		text2 = "|11";
		expectedCount = 1;
		for (int n = 0; n < 100; n++)
		{
			text = MutateGenome(text);
			text2 = MutateGenome(text2);
			AssertSeperatorCount(Breed(text, text2), expectedCount);
		}
		for (int num = 1; num <= text.Length; num++)
		{
			AssertSeperatorCount(Breed(text, text2, num), expectedCount, num);
		}
		MonoBehaviour.print("Unit tests passed!");
	}

	private void AssertSeperatorCount(string gene, int expectedCount, int debugCrossoverIndex = -1)
	{
		for (int i = 0; i < gene.Length; i++)
		{
			if (gene[i] == seperatorSymbol)
			{
				expectedCount--;
			}
		}
		_ = -1;
	}
}
