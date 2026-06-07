using System;
using System.Collections.Generic;
using System.Linq;
using Tyd;
using UnityEngine;

[AltDeprecate("Category", typeof(string))]
public class SoftwareType : IFormatColorObject
{
	public static float SequelBoost = 0.9f;

	public static float RoyaltySum = 0.2f;

	private static int AwarenessLabelCount = 5;

	private static int PerceptionLabelCount = 5;

	public readonly string Name;

	public readonly string Description;

	public readonly float RandomFactor;

	public readonly float OptimalDevTime;

	public readonly string[] SubMarkets;

	private readonly string[] _OSLimits;

	public readonly bool OneClient;

	public readonly bool InHouse;

	public readonly Dictionary<string, FeatureBase> Features;

	public readonly Dictionary<string, SoftwareCategory> Categories;

	public readonly Dictionary<string, SoftwareAddOn> AddOns = new Dictionary<string, SoftwareAddOn>();

	public readonly int? Unlock;

	public readonly bool Modded;

	public string ModName;

	public bool CanOverride = true;

	public uint ID = 1u;

	[NonSerialized]
	private Dictionary<uint, FeatureBase> _featCache;

	[NonSerialized]
	private Dictionary<uint, SoftwareAddOn> _addonCache;

	[NonSerialized]
	private Dictionary<uint, SoftwareCategory> _catCache;

	private List<string> _specCache = new List<string>();

	public static float DesignRatio = 1f / 3f;

	public static FloatInterpolator QualityLevel = new FloatInterpolator(1f, 1f, 2f, 2f, 2f, 3f, 3f, 3f, 3f, 4f, 4f, 4f, 4f, 4f, 4f, 5f, 5f, 5f, 5f, 6f, 6f);

	public static FloatInterpolator CreativityLevel = new FloatInterpolator(1f, 1f, 1f, 1f, 2f, 2f, 2f, 2f, 3f, 3f, 3f, 3f, 3f, 3f, 3f, 4f, 4f, 4f, 4f, 5f, 5f);

	private static Dictionary<string, int> _osSpecCounter = new Dictionary<string, int>();

	private static Dictionary<string, HashSet<string>> _toolRatioCache = new Dictionary<string, HashSet<string>>();

	public bool OSSpecific
	{
		get
		{
			return _OSLimits != null;
		}
	}

	public bool HasOSLimits()
	{
		if (OSSpecific)
		{
			return _OSLimits.Length != 0;
		}
		return false;
	}

	public IEnumerable<string> GetOSLimits()
	{
		if (OSSpecific)
		{
			for (int i = 0; i < _OSLimits.Length; i++)
			{
				yield return _OSLimits[i];
			}
		}
	}

	public FeatureBase GetFeature(uint id)
	{
		if (_featCache == null)
		{
			_featCache = Features.Values.ToDictionary((FeatureBase x) => x.ID, (FeatureBase x) => x);
		}
		return _featCache.GetOrNull(id);
	}

	public SoftwareAddOn GetAddon(uint id)
	{
		if (_addonCache == null)
		{
			_addonCache = AddOns.Values.ToDictionary((SoftwareAddOn x) => x.ID, (SoftwareAddOn x) => x);
		}
		return _addonCache.GetOrNull(id);
	}

	public SoftwareCategory GetCategory(uint id)
	{
		if (_catCache == null)
		{
			_catCache = Categories.Values.ToDictionary((SoftwareCategory x) => x.ID, (SoftwareCategory x) => x);
		}
		return _catCache.GetOrNull(id);
	}

	public void UpdateID(uint id)
	{
		ID = id;
		uint num = 1u;
		foreach (KeyValuePair<string, FeatureBase> feature in Features)
		{
			feature.Value.ID = num;
			num++;
		}
		num = 1u;
		foreach (KeyValuePair<string, SoftwareCategory> category in Categories)
		{
			category.Value.ID = num;
			num++;
		}
		num = 1u;
		foreach (KeyValuePair<string, SoftwareAddOn> addOn in AddOns)
		{
			addOn.Value.ID = num;
			num++;
			uint num2 = 2u;
			foreach (KeyValuePair<string, AddOnFeature> feature2 in addOn.Value.Features)
			{
				feature2.Value.ID = num2;
				num2++;
			}
		}
	}

	public bool SupportsOS(string cat)
	{
		if (OSSpecific)
		{
			if (_OSLimits.Length != 0)
			{
				return _OSLimits.Contains(cat);
			}
			return true;
		}
		return false;
	}

	public bool HasSpec(string spec)
	{
		foreach (FeatureBase value in Features.Values)
		{
			SpecFeature specFeature = value as SpecFeature;
			if (specFeature != null && specFeature.Spec.Equals(spec))
			{
				return true;
			}
		}
		return false;
	}

	public string[] GetNeeds(string category)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (SpecFeature item in from x in Features.Values.OfType<SpecFeature>()
			where x.IsCompatible(category)
			select x)
		{
			hashSet.AddRange(item.Dependencies);
		}
		return hashSet.ToArray();
	}

	public Dictionary<string, List<string>> GetNeedsWithSpecs(string category)
	{
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		foreach (SpecFeature item in from x in Features.Values.OfType<SpecFeature>()
			where x.IsCompatible(category)
			select x)
		{
			for (int num = 0; num < item.Dependencies.Length; num++)
			{
				dictionary.Append(item.Dependencies[num], item.Spec);
			}
		}
		return dictionary;
	}

	public IEnumerable<FeatureBase> GetAllFeatures()
	{
		foreach (KeyValuePair<string, FeatureBase> feature in Features)
		{
			yield return feature.Value;
		}
		foreach (KeyValuePair<string, SoftwareAddOn> addon in AddOns)
		{
			if (addon.Value.BaseFeature != null)
			{
				yield return addon.Value.BaseFeature;
			}
			foreach (KeyValuePair<string, AddOnFeature> feature2 in addon.Value.Features)
			{
				yield return feature2.Value;
			}
		}
	}

	public string[] GetSpecsFromNeed(string need, IList<FeatureBase> features = null)
	{
		_specCache.Clear();
		if (features != null)
		{
			for (int i = 0; i < features.Count; i++)
			{
				SpecFeature specFeature = features[i] as SpecFeature;
				if (specFeature != null && specFeature.Dependencies.Contains(need))
				{
					_specCache.Add(specFeature.Spec);
				}
			}
		}
		else
		{
			foreach (SpecFeature item in Features.Values.OfType<SpecFeature>())
			{
				if (item.Dependencies.Contains(need))
				{
					_specCache.Add(item.Spec);
				}
			}
		}
		if (_specCache.Count <= 0)
		{
			return null;
		}
		return _specCache.ToArray();
	}

	public string[] GetNeedsFromSpec(string spec, IList<FeatureBase> features = null)
	{
		_specCache.Clear();
		if (features != null)
		{
			for (int i = 0; i < features.Count; i++)
			{
				SpecFeature specFeature = features[i] as SpecFeature;
				if (specFeature != null && specFeature.Spec.Equals(spec))
				{
					return specFeature.Dependencies;
				}
			}
		}
		else
		{
			foreach (SpecFeature item in Features.Values.OfType<SpecFeature>())
			{
				if (item.Spec.Equals(spec))
				{
					return item.Dependencies;
				}
			}
		}
		return null;
	}

	public string[] GetNeeds(IList<FeatureBase> features, string category)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (SpecFeature item in from x in features.OfType<SpecFeature>()
			where x.IsCompatible(category)
			select x)
		{
			hashSet.AddRange(item.Dependencies);
		}
		return hashSet.ToArray();
	}

	public SoftwareType(string name, string description, string[] osLimit, float random, float optimalDevtime, bool oneClient, bool inHouse, string[] submarkets, Dictionary<string, FeatureBase> feat, int? unlock, Dictionary<string, SoftwareCategory> categories, Dictionary<string, SoftwareAddOn> addOns, string mod)
	{
		Name = name;
		Description = description;
		_OSLimits = osLimit;
		RandomFactor = random;
		OptimalDevTime = optimalDevtime;
		SubMarkets = submarkets;
		OneClient = oneClient;
		InHouse = inHouse;
		Features = feat;
		Unlock = unlock;
		Categories = categories;
		AddOns = addOns;
		if (mod != null)
		{
			Modded = true;
			ModName = mod;
		}
	}

	public SoftwareType()
	{
	}

	public static double[] GetSoftwareEq(TydNode node, bool canBeZero)
	{
		string[] array = node.GetNodeValues().ToArray();
		if (array.Length == 1 && (string.IsNullOrEmpty(array[0]) || array[0].Equals("0")))
		{
			if (canBeZero)
			{
				return new double[3];
			}
			throw new Exception("Submarket equilibrium must be higher than 0");
		}
		if (array.Length != 3)
		{
			throw new Exception("Wrong number of sub market values supplied, only 3 are supported");
		}
		double[] array2 = new double[3];
		double num = 0.0;
		for (int i = 0; i < 3; i++)
		{
			array2[i] = Mathf.Max(0f, array[i].ConvertToFloat("Submarkets"));
			num += array2[i];
		}
		if (num > 0.0)
		{
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] /= num;
			}
		}
		else if (!canBeZero || num < 0.0)
		{
			throw new Exception("Submarket equilibrium must be higher than 0");
		}
		return array2;
	}

	public SoftwareType(TydCollection node, string mod, string pathRoot)
	{
		SoftwareType softwareType = this;
		Name = node.GetChildValue("Name");
		Description = node.GetChildValue("Description", false);
		RandomFactor = node.GetChildValue("Random", true, 0f);
		OptimalDevTime = node.GetChildValue("OptimalDevTime", true, 0f);
		SubMarkets = node.GetChild<TydCollection>("SubmarketNames", true).GetChildValues().ToArray();
		if (SubMarkets.Length != 3)
		{
			throw new Exception("Incorrect number of submarket names supplied. Needs 3");
		}
		string defaultGen = node.GetChildValue("NameGenerator", false);
		TydCollection child = node.GetChild<TydCollection>("Categories");
		Manufacturing man = null;
		TydTable child2 = node.GetChild<TydTable>("Manufacturing");
		if (child2 != null)
		{
			man = new Manufacturing(child2, pathRoot);
		}
		if (child == null)
		{
			float childValue = node.GetChildValue("Popularity", true, 0f);
			bool childValue2 = node.GetChildValue("ForcePopularity", false, false);
			float childValue3 = node.GetChildValue("Retention", true, 0f);
			float childValue4 = node.GetChildValue("Iterative", true, 0f);
			TydNode child3 = node.GetChild("Submarkets");
			double[] submarketeq = ((child3 != null) ? GetSoftwareEq(child3, false) : new double[3]
			{
				1.0 / 3.0,
				1.0 / 3.0,
				1.0 / 3.0
			});
			float childValue5 = node.GetChildValue("IdealPrice", true, 0f);
			bool childValue6 = node.GetChildValue("Hardware", false, false);
			Categories = new Dictionary<string, SoftwareCategory> { 
			{
				"Default",
				SoftwareCategory.GetDefault(this, childValue, childValue2, childValue3, childValue4, childValue5, submarketeq, defaultGen, childValue6, man)
			} };
		}
		else
		{
			float? idealPrice = node.GetChildValue<float?>("IdealPrice", false);
			bool? hardware = node.GetChildValue<bool?>("Hardware", false);
			Categories = (from x in child.Nodes.OfType<TydCollection>()
				select new SoftwareCategory(softwareType, x, defaultGen, idealPrice, hardware, man, pathRoot)).ToDictionary((SoftwareCategory x) => x.Name, (SoftwareCategory x) => x);
		}
		TydNode child4 = node.GetChild("OSSupport");
		if (child4 != null)
		{
			_OSLimits = child4.GetNodeValues().ToArray();
			if (_OSLimits.Length == 1 && _OSLimits[0] == null)
			{
				_OSLimits = null;
			}
			else if (_OSLimits.Length == 1 && _OSLimits[0].ConvertToBoolDef(false))
			{
				_OSLimits = new string[0];
			}
		}
		else
		{
			_OSLimits = null;
		}
		OneClient = node.GetChildValue("OneClient", false, false);
		InHouse = node.GetChildValue("InHouse", false, false);
		Features = new Dictionary<string, FeatureBase>();
		foreach (TydCollection item in node.GetChild<TydCollection>("Features", true).Nodes.OfType<TydCollection>())
		{
			SpecFeature specFeature = new SpecFeature(item, Name);
			if (Features.ContainsKey(specFeature.Name))
			{
				throw new Exception("Can't re-use feature name: " + specFeature.Name);
			}
			Features[specFeature.Name] = specFeature;
			TydCollection child5 = item.GetChild<TydCollection>("Features");
			if (child5 == null)
			{
				continue;
			}
			foreach (TydCollection item2 in child5.Nodes.OfType<TydCollection>())
			{
				SubFeature subFeature = new SubFeature(item2, specFeature, Name, pathRoot);
				if (Features.ContainsKey(subFeature.Name))
				{
					throw new Exception("Can't re-use feature name: " + subFeature.Name);
				}
				Features[subFeature.Name] = subFeature;
			}
		}
		Unlock = node.GetChildValue<int?>("Unlock", false);
		if (Categories.Values.All((SoftwareCategory x) => x.Unlock.HasValue))
		{
			int num = Categories.Values.Where((SoftwareCategory x) => x.Unlock.HasValue).Min((SoftwareCategory x) => x.Unlock.Value);
			if (Unlock.HasValue)
			{
				num = Mathf.Min(Unlock.Value, num);
			}
			Unlock = num;
		}
		TydCollection child6 = node.GetChild<TydCollection>("AddOns");
		AddOns = ((child6 != null) ? (from x in child6.Nodes.OfType<TydCollection>()
			select new SoftwareAddOn(softwareType, x, pathRoot, softwareType.Name)).ToDictionary((SoftwareAddOn x) => x.Name, (SoftwareAddOn x) => x) : new Dictionary<string, SoftwareAddOn>());
		if (mod != null)
		{
			Modded = true;
			ModName = mod;
		}
	}

	public SoftwareType Clone(params SoftwareTypeOverride[] Overrides)
	{
		if (!CanOverride)
		{
			Dictionary<string, SoftwareCategory> dictionary = new Dictionary<string, SoftwareCategory>();
			Dictionary<string, SoftwareAddOn> dictionary2 = new Dictionary<string, SoftwareAddOn>();
			SoftwareType softwareType = new SoftwareType(Name, Description, _OSLimits, RandomFactor, OptimalDevTime, OneClient, InHouse, SubMarkets, Features.ToDictionary((KeyValuePair<string, FeatureBase> x) => x.Key, (KeyValuePair<string, FeatureBase> x) => FeatureBase.Clone(x.Value)), Unlock, dictionary, dictionary2, null);
			foreach (KeyValuePair<string, SoftwareCategory> category in Categories)
			{
				dictionary[category.Key] = new SoftwareCategory(softwareType, category.Value, null, null, null, null);
			}
			{
				foreach (KeyValuePair<string, SoftwareAddOn> addOn in AddOns)
				{
					dictionary2[addOn.Key] = new SoftwareAddOn(softwareType, addOn.Value);
				}
				return softwareType;
			}
		}
		try
		{
			Dictionary<string, FeatureBase> dictionary3 = new Dictionary<string, FeatureBase>();
			bool oneClient = Overrides.LastNotNull((SoftwareTypeOverride x) => x.OneClient, OneClient);
			float? idealPrice = Overrides.LastNotNull((SoftwareTypeOverride x) => x.IdealPrice);
			bool? hardware = Overrides.LastNotNull((SoftwareTypeOverride x) => x.Hardware);
			if (Overrides.Any((SoftwareTypeOverride x) => x.Features != null))
			{
				foreach (SoftwareTypeOverride item in Overrides.Where((SoftwareTypeOverride x) => x.Features != null))
				{
					FeatureBase[] features = item.Features;
					foreach (FeatureBase featureBase in features)
					{
						dictionary3[featureBase.Name] = FeatureBase.Clone(featureBase);
					}
				}
			}
			else
			{
				foreach (KeyValuePair<string, FeatureBase> feature in Features)
				{
					dictionary3[feature.Key] = FeatureBase.Clone(feature.Value);
				}
			}
			string description = Overrides.LastNotNull((SoftwareTypeOverride x) => x.Description, Description);
			float random = Overrides.LastNotNull((SoftwareTypeOverride x) => x.RandomFactor, RandomFactor);
			string[] osLimit = (OSSpecific ? Overrides.LastNotNull((SoftwareTypeOverride x) => x.OSLimit, _OSLimits) : null);
			bool inHouse = Overrides.LastNotNull((SoftwareTypeOverride x) => x.InHouse, InHouse);
			int? unlock = Overrides.LastNotNull((SoftwareTypeOverride x) => x.Unlock, Unlock);
			Manufacturing manufacturing = Overrides.LastNotNull((SoftwareTypeOverride x) => x.Manufacturing);
			Dictionary<string, SoftwareCategory> dictionary4 = new Dictionary<string, SoftwareCategory>();
			Dictionary<string, SoftwareAddOn> dictionary5 = new Dictionary<string, SoftwareAddOn>();
			string[] submarkets = Overrides.LastNotNull((SoftwareTypeOverride x) => x.Submarkets, SubMarkets);
			string text = ((Overrides.Length != 0) ? string.Join(", ", Overrides.Select((SoftwareTypeOverride x) => x.ModName)) : null);
			if (ModName != null)
			{
				text = ((text == null) ? ModName : (ModName + ", " + text));
			}
			SoftwareType softwareType2 = new SoftwareType(Name, description, osLimit, random, OptimalDevTime, oneClient, inHouse, submarkets, dictionary3, unlock, dictionary4, dictionary5, text);
			string text2 = Overrides.LastNotNull((SoftwareTypeOverride x) => x.NameGenerator);
			foreach (KeyValuePair<string, SoftwareCategory> category2 in Categories)
			{
				dictionary4[category2.Key] = new SoftwareCategory(softwareType2, category2.Value, text2, idealPrice, hardware, manufacturing);
			}
			foreach (KeyValuePair<string, SoftwareAddOn> addOn2 in AddOns)
			{
				dictionary5[addOn2.Key] = new SoftwareAddOn(softwareType2, addOn2.Value);
			}
			text2 = text2 ?? dictionary4.Select((KeyValuePair<string, SoftwareCategory> x) => x.Value.GetNameGenName()).First();
			if (Overrides.Any((SoftwareTypeOverride x) => x.Categories != null))
			{
				dictionary4.Clear();
				SoftwareTypeOverride[] array = Overrides;
				foreach (SoftwareTypeOverride softwareTypeOverride in array)
				{
					if (softwareTypeOverride.Categories != null)
					{
						SoftwareCategory[] categories = softwareTypeOverride.Categories;
						foreach (SoftwareCategory softwareCategory in categories)
						{
							string text3 = softwareTypeOverride.CategoryRngs[softwareCategory.Name];
							dictionary4[softwareCategory.Name] = new SoftwareCategory(softwareType2, softwareCategory, text3 ?? text2, idealPrice, hardware, manufacturing);
						}
					}
				}
			}
			if (Overrides.Any((SoftwareTypeOverride x) => x.AddOns != null))
			{
				dictionary5.Clear();
				SoftwareTypeOverride[] array = Overrides;
				foreach (SoftwareTypeOverride softwareTypeOverride2 in array)
				{
					if (softwareTypeOverride2.AddOns != null)
					{
						SoftwareAddOn[] addOns = softwareTypeOverride2.AddOns;
						foreach (SoftwareAddOn softwareAddOn in addOns)
						{
							dictionary5[softwareAddOn.Name] = new SoftwareAddOn(softwareType2, softwareAddOn);
						}
					}
				}
			}
			return softwareType2;
		}
		catch (Exception ex)
		{
			throw new Exception(string.Format("Error in applying overrides to {0}: {1}", Name ?? "", ex.Message));
		}
	}

	public bool IsUnlocked(int year)
	{
		if (Unlock.HasValue)
		{
			return year >= Unlock.Value - 1900;
		}
		return true;
	}

	public override string ToString()
	{
		return Name;
	}

	public string GetActualString()
	{
		return Name.LocSW();
	}

	public static int[] GetOptimalEmployeeCount(float devTime)
	{
		return new int[2]
		{
			GameData.GetOptimalEmployees(Mathf.Max(1, Mathf.RoundToInt(devTime * DesignRatio))),
			GameData.GetOptimalEmployees(Mathf.Max(1, Mathf.RoundToInt(devTime * (1f - DesignRatio))))
		};
	}

	public static float GetMaxDevTime(int design, int dev)
	{
		return Mathf.Min(GameData.GetMaxDevTime(Mathf.RoundToInt((float)design / DesignRatio)), GameData.GetMaxDevTime(Mathf.RoundToInt((float)dev / (1f - DesignRatio))));
	}

	public static float GetEmployeeCountEffect(int employees, float devTime, bool design)
	{
		float num = (design ? DesignRatio : (1f - DesignRatio));
		return GameData.GetProjectEffectiveness(employees, Mathf.Max(1, Mathf.RoundToInt(devTime * num)));
	}

	public double MaxQuality(Dictionary<string, SoftwareProduct> needs, IList<FeatureBase> features)
	{
		Dictionary<string, double> dictionary = new Dictionary<string, double>();
		float num = features.Sum((FeatureBase x) => x.DevTime);
		for (int num2 = 0; num2 < features.Count; num2++)
		{
			SpecFeature specFeature;
			if ((specFeature = features[num2] as SpecFeature) != null)
			{
				for (int num3 = 0; num3 < specFeature.Dependencies.Length; num3++)
				{
					dictionary.AddUp(specFeature.Dependencies[num3], specFeature.DevTime / num);
				}
			}
		}
		double num4 = 1.0;
		double num5 = 1.0;
		foreach (KeyValuePair<string, SoftwareProduct> need in needs)
		{
			double value;
			if (need.Value != null && dictionary.TryGetValue(need.Key, out value))
			{
				num4 += need.Value.RealQuality * value;
				num5 += value;
			}
		}
		num4 /= num5;
		return num4 * 1.05;
	}

	public float DevTime(IList<FeatureBase> features, SoftwareCategory category, Company c, Dictionary<string, TechLevel> techs, int OSs, SoftwareFramework framework, bool newFramework, SoftwareProduct sequelTo)
	{
		float num = 0f;
		for (int i = 0; i < features.Count; i++)
		{
			num += features[i].GetDevTime(category, c, techs, sequelTo, framework, newFramework);
		}
		return num + (float)OSs;
	}

	public float DevTime(IList<FeatureBase> features, SoftwareCategory category, Company c, Dictionary<string, TechLevel> techs, IList<SoftwareProduct> OSs, SoftwareFramework framework, bool newFramework, SoftwareProduct sequelTo)
	{
		return DevTime(features, category, c, techs, (OSs != null) ? OSs.Count : 0, framework, newFramework, sequelTo);
	}

	public float SimpleDevTime(IList<FeatureBase> features, SoftwareCategory category, Dictionary<string, TechLevel> techs)
	{
		float num = 0f;
		for (int i = 0; i < features.Count; i++)
		{
			num += features[i].GetDevTime(category, null, techs, null, null, false, false);
		}
		return num;
	}

	public float GetOptimalDevTime(SoftwareCategory cat)
	{
		return OptimalDevTime * cat.TimeScale;
	}

	public float MaxDevTime(SoftwareCategory cat, int year)
	{
		return GetOptimalDevTime(cat);
	}

	public static float CodeArtRatio(IList<FeatureBase> features)
	{
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < features.Count; i++)
		{
			FeatureBase featureBase = features[i];
			num += featureBase.CodeArtRatio * featureBase.DevTime;
			num2 += featureBase.DevTime;
		}
		if (num2 != 0f)
		{
			return num / num2;
		}
		return 1f;
	}

	public static float CodeArtRatio(IList<FeatureBase> features, uint[] factors)
	{
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < features.Count; i++)
		{
			FeatureBase featureBase = features[i];
			num += featureBase.CodeArtRatio * featureBase.DevTime * (float)factors[i];
			num2 += featureBase.DevTime * (float)factors[i];
		}
		if (num2 != 0f)
		{
			return num / num2;
		}
		return 1f;
	}

	public float CodeArtRatio(IList<string> features)
	{
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < features.Count; i++)
		{
			FeatureBase featureBase = Features[features[i]];
			num += featureBase.CodeArtRatio * featureBase.DevTime;
			num2 += featureBase.DevTime;
		}
		if (num2 != 0f)
		{
			return num / num2;
		}
		return 1f;
	}

	private FeatureBase[] FeatureByDependency(Dictionary<string, TechLevel> techs, SDateTime date, SoftwareCategory swCategory, System.Random rnd)
	{
		return (from x in Features.Values
			where x.IsCompatible(swCategory.Name) && ((techs == null) ? x.IsUnlocked(date.Year) : x.IsUnlocked(techs, swCategory))
			orderby (!(x is SpecFeature)) ? 2f : rnd.NextFloat()
			select x).ToArray();
	}

	public FeatureBase[] GenerateFeatures(float scoreTolerance, SoftwareCategory swCategory, Dictionary<string, SoftwareProduct> needs, Dictionary<string, TechLevel> techs, HashSet<string> validSpecs, SDateTime date, double[] marketTarget, System.Random rnd, bool online = true)
	{
		List<FeatureBase> list = new List<FeatureBase>();
		double[] array = new double[3];
		double[] array2 = new double[3];
		double num = 0.0;
		HashSet<string> hashSet = new HashSet<string>();
		float num2 = 0f;
		foreach (FeatureBase item in from x in Features.Values
			orderby (!(x is SpecFeature)) ? 1 : 0, (!swCategory.Hardware || !swCategory.Manufacturing.IsDependency(x.Name, 0u)) ? (rnd.NextFloat() + 0.1f) : 0f
			select x)
		{
			if (item.Level == 3 || !item.IsCompatible(swCategory.Name) || !item.IsUnlocked(techs, swCategory) || (!online && item.ServerRequirement > 0f))
			{
				continue;
			}
			SpecFeature specFeature = item as SpecFeature;
			if (specFeature != null)
			{
				bool flag = validSpecs == null || validSpecs.Contains(specFeature.Spec);
				if (flag)
				{
					for (int num3 = 0; num3 < specFeature.Dependencies.Length; num3++)
					{
						string key = specFeature.Dependencies[num3];
						SoftwareProduct value;
						if (!needs.TryGetValue(key, out value))
						{
							flag = false;
							break;
						}
						if (!value.TechLevels.ContainsKey(specFeature.Spec))
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					list.Add(specFeature);
					num2 += specFeature.DevTime;
					hashSet.Add(specFeature.Spec);
				}
				else if (item.IsForced(swCategory.Name))
				{
					return null;
				}
			}
			else
			{
				if (!hashSet.Contains(item.Spec))
				{
					continue;
				}
				item.GetSubAdd(swCategory, (techs == null) ? null : techs.GetOrDefault(item.Spec), array2);
				array2.AddArray(array);
				double num4 = marketTarget.SubmarketScore(array2);
				if (num4 > num)
				{
					list.Add(item);
					num2 += item.DevTime;
					num = num4;
					array.ReplaceContent(array2);
					if (num >= (double)scoreTolerance || num2 > GetOptimalDevTime(swCategory))
					{
						break;
					}
				}
			}
		}
		return list.ToArray();
	}

	public List<FeatureBase> GenerateFeatures(IList<Actor> design, IList<Actor> dev, SoftwareCategory swCategory, Company c, Dictionary<string, SoftwareProduct> needs, Dictionary<string, TechLevel> techs, double[] marketTarget, SoftwareProduct sequel, bool online = true)
	{
		float maxDevtime = Mathf.Min(GetOptimalDevTime(swCategory), GetMaxDevTime(design.Count, dev.Count));
		double[] array = new double[3];
		HashSet<string> hashSet = new HashSet<string>();
		List<string> list = new List<string>();
		Dictionary<FeatureBase, double> dictionary = new Dictionary<FeatureBase, double>();
		foreach (FeatureBase item in Features.Values.OrderBy((FeatureBase x) => x.Level))
		{
			if (item.Level == 3 || !item.IsCompatible(swCategory.Name) || !item.IsUnlocked(techs, swCategory) || (!online && item.ServerRequirement > 0f))
			{
				continue;
			}
			SpecFeature specFeature = item as SpecFeature;
			if (specFeature != null)
			{
				bool flag = true;
				for (int num = 0; num < specFeature.Dependencies.Length; num++)
				{
					string key = specFeature.Dependencies[num];
					if (!needs.ContainsKey(key))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					item.GetSubAdd(swCategory, (techs == null) ? null : techs.GetOrDefault(item.Spec), array);
					dictionary[item] = marketTarget.SubmarketScore(array);
					hashSet.Add(specFeature.Spec);
					if (!specFeature.Forced)
					{
						list.Add(specFeature.Spec);
					}
				}
			}
			else if (hashSet.Contains(item.Spec))
			{
				FeatureBase f1 = item;
				if (design.Any((Actor x) => x.employee.GetSpecialization(Employee.EmployeeRole.Designer, f1.Spec) >= f1.Level) && (!(item.CodeArtRatio > 0f) || dev.Any((Actor x) => x.employee.GetSpecialization(Employee.EmployeeRole.Programmer, f1.Spec) >= f1.Level)) && (!(item.CodeArtRatio < 1f) || dev.Any((Actor x) => x.employee.GetSpecialization(Employee.EmployeeRole.Artist, f1.Spec) >= f1.Level)))
				{
					item.GetSubAdd(swCategory, (techs == null) ? null : techs.GetOrDefault(item.Spec), array);
					dictionary[item] = marketTarget.SubmarketScore(array);
				}
			}
		}
		List<FeatureBase> list2 = new List<FeatureBase>();
		if (list.Count == 0)
		{
			MaxScore(dictionary, techs, swCategory, c, sequel, hashSet, maxDevtime, list2, marketTarget, new double[3]);
			return list2;
		}
		HashSet<string> hashSet2 = hashSet.ToHashSet();
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			hashSet2.Remove(list[num2]);
		}
		double num3 = -1.0;
		List<FeatureBase> list3 = new List<FeatureBase>();
		int num4 = 2;
		for (int num5 = 0; num5 < list.Count - 1; num5++)
		{
			num4 *= 2;
		}
		double[] cache = new double[3];
		for (int num6 = 0; num6 < num4; num6++)
		{
			hashSet.Clear();
			hashSet.AddRange(hashSet2);
			list3.Clear();
			for (int num7 = 0; num7 < list.Count; num7++)
			{
				if (((1 << num7) & num6) != 0)
				{
					hashSet.Add(list[num7]);
				}
			}
			double num8 = MaxScore(dictionary, techs, swCategory, c, sequel, hashSet, maxDevtime, list3, marketTarget, cache);
			if (num8 > num3)
			{
				num3 = num8;
				List<FeatureBase> list4 = list3;
				list3 = list2;
				list2 = list4;
				if (num3 >= 1.0)
				{
					break;
				}
			}
		}
		return list2;
	}

	private static double MaxScore(Dictionary<FeatureBase, double> scores, Dictionary<string, TechLevel> techs, SoftwareCategory cat, Company c, SoftwareProduct sequel, HashSet<string> specs, float maxDevtime, List<FeatureBase> result, double[] targetMarket, double[] cache)
	{
		double num = 0.0;
		for (int i = 0; i < 3; i++)
		{
			cache[i] = 0.0;
		}
		float num2 = 0f;
		foreach (KeyValuePair<FeatureBase, double> item in from x in scores
			orderby (!(x.Key is SpecFeature)) ? 1 : 0, x.Value descending
			select x)
		{
			if (specs.Contains(item.Key.Spec))
			{
				float devTime = item.Key.GetDevTime(cat, c, techs, sequel, null, false);
				if (item.Key is SpecFeature || (item.Value > 0.0 && num2 + devTime <= maxDevtime))
				{
					result.Add(item.Key);
					item.Key.GetSubAdd(cat, (techs == null) ? null : techs.GetOrDefault(item.Key.Spec), cache, true);
					num = targetMarket.SubmarketScore(cache);
					num2 += devTime;
				}
			}
			if (!(item.Key is SpecFeature) && (num >= 1.0 || num2 >= maxDevtime))
			{
				break;
			}
		}
		if (!(num2 > maxDevtime))
		{
			return num;
		}
		return 0.0;
	}

	public static bool DependencyMet(string feature, SoftwareProduct sw)
	{
		return true;
	}

	public static bool OSDependenciesMet(SoftwareProduct target, IList<FeatureBase> features)
	{
		for (int i = 0; i < features.Count; i++)
		{
			SpecFeature specFeature;
			if ((specFeature = features[i] as SpecFeature) != null && MarketSimulation.Active.IsOSBacked(specFeature.Spec) && !target.TechLevels.ContainsKey(specFeature.Spec))
			{
				return false;
			}
		}
		return true;
	}

	public bool DependenciesMet(SoftwareProduct target, IList<FeatureBase> features, Dictionary<string, TechLevel> techs)
	{
		if (!target.Type.Name.Equals("Operating System"))
		{
			foreach (SpecFeature item in features.OfType<SpecFeature>())
			{
				if (item.Dependencies.Contains(target.Type.Name))
				{
					TechLevel orDefault = target.TechLevels.GetOrDefault(item.Spec);
					if (orDefault != null && orDefault.Year < techs[item.Spec].Year)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	public FeatureBase[] FixUp(IEnumerable<FeatureBase> features, SoftwareCategory swCategory, Dictionary<string, SoftwareProduct> needs, Dictionary<string, TechLevel> techs)
	{
		List<FeatureBase> list = features.Where((FeatureBase x) => x.IsCompatible(swCategory.Name)).ToList();
		foreach (FeatureBase item in Features.Values.Where((FeatureBase x) => x.IsForced(swCategory.Name) && x.IsCompatible(swCategory.Name) && x.IsUnlocked(techs, swCategory)))
		{
			if (!list.Contains(item))
			{
				list.Add(item);
			}
		}
		for (int num = 0; num < list.Count; num++)
		{
			SpecFeature specFeature = list[num] as SpecFeature;
			if (specFeature == null)
			{
				continue;
			}
			string[] dependencies = specFeature.Dependencies;
			bool flag = true;
			for (int num2 = 0; num2 < dependencies.Length; num2++)
			{
				if (!needs.ContainsKey(dependencies[num2]))
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				list.Remove(specFeature);
				num--;
			}
		}
		return list.ToArray();
	}

	public FeatureBase[] FixUp(IEnumerable<FeatureBase> features, SoftwareCategory swCategory, Dictionary<string, TechLevel> techs)
	{
		HashSet<FeatureBase> hashSet = features.Where((FeatureBase x) => x.IsCompatible(swCategory.Name)).ToHashSet();
		foreach (FeatureBase item in Features.Values.Where((FeatureBase x) => x.IsForced(swCategory.Name) && x.IsCompatible(swCategory.Name) && x.IsUnlocked(techs, swCategory)))
		{
			hashSet.Add(item);
		}
		return hashSet.ToArray();
	}

	public static string GetQualityLabel(double quality)
	{
		return ("QualityAmount" + Mathf.FloorToInt(QualityLevel.Evaluate((float)quality))).Loc();
	}

	public static string GetCreativityLabel(double creativity, bool details = true)
	{
		return ("CreativityAmount" + Mathf.FloorToInt(CreativityLevel.Evaluate((float)creativity))).Loc();
	}

	public static string GetAwarenessLabel(float popularity)
	{
		if (!(popularity < 0.0001f))
		{
			return ("MarketingAmount" + (Mathf.Clamp(Mathf.FloorToInt(Mathf.Sqrt(popularity) * (float)(AwarenessLabelCount - 1)), 0, AwarenessLabelCount - 2) + 2)).Loc();
		}
		return "MarketingAmount1".Loc();
	}

	public FeatureBase[] FeaturesFromSpecialization(string spec, bool code)
	{
		return Features.Values.Where((FeatureBase x) => spec.Equals(x.Spec)).ToArray();
	}

	public static Dictionary<Employee.EmployeeRole, Dictionary<string, int>> GetSpecs(IList<FeatureBase> features, bool design = false)
	{
		Dictionary<Employee.EmployeeRole, Dictionary<string, int>> dictionary = new Dictionary<Employee.EmployeeRole, Dictionary<string, int>>();
		for (int i = 0; i < features.Count; i++)
		{
			FeatureBase featureBase = features[i];
			if (design)
			{
				dictionary.GetOrAdd(Employee.EmployeeRole.Designer, (Employee.EmployeeRole x) => new Dictionary<string, int>()).AddTo(featureBase.Spec, featureBase.Level, Mathf.Max);
				continue;
			}
			if (featureBase.CodeArtRatio > 0f)
			{
				dictionary.GetOrAdd(Employee.EmployeeRole.Programmer, (Employee.EmployeeRole x) => new Dictionary<string, int>()).AddTo(featureBase.Spec, featureBase.Level, Mathf.Max);
			}
			if (featureBase.CodeArtRatio < 1f)
			{
				dictionary.GetOrAdd(Employee.EmployeeRole.Artist, (Employee.EmployeeRole x) => new Dictionary<string, int>()).AddTo(featureBase.Spec, featureBase.Level, Mathf.Max);
			}
		}
		return dictionary;
	}

	public static Dictionary<string, float> GetSpecializationMonths(IList<FeatureBase> features, SoftwareCategory category, SoftwareProduct[] OSs, SoftwareProduct sequelTo, uint[] featureFactors)
	{
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		float num = ((category != null) ? category.TimeScale : 1f);
		for (int i = 0; i < features.Count; i++)
		{
			FeatureBase featureBase = features[i];
			float num2 = ((sequelTo != null && sequelTo.Features.Contains(featureBase)) ? SequelBoost : 1f);
			if (featureFactors != null)
			{
				num2 *= (float)featureFactors[i];
			}
			dictionary.AddUp(featureBase.Spec, featureBase.DevTime * num * num2);
		}
		if (OSs != null && OSs.Length != 0)
		{
			dictionary.AddUp("System", OSs.Length);
		}
		return dictionary;
	}

	public Dictionary<string, float[]> GetSpecializationMonthsCodeArt(IEnumerable<FeatureBase> features, SoftwareCategory category, Company c, Dictionary<string, TechLevel> techs, SoftwareProduct[] OSs, SoftwareFramework framework, bool newFramework, SoftwareProduct sequelTo, bool includeStars = false)
	{
		Dictionary<string, float[]> dictionary = new Dictionary<string, float[]>();
		foreach (FeatureBase feature in features)
		{
			float devTime = feature.GetDevTime(category, c, techs, sequelTo, framework, newFramework);
			float[] value;
			if (dictionary.TryGetValue(feature.Spec, out value))
			{
				value[0] += devTime * feature.CodeArtRatio;
				value[1] += devTime * (1f - feature.CodeArtRatio);
				if (includeStars)
				{
					if (feature.CodeArtRatio > 0f)
					{
						value[2] = Mathf.Max(value[2], feature.Level);
					}
					if (feature.CodeArtRatio < 1f)
					{
						value[3] = Mathf.Max(value[3], feature.Level);
					}
				}
			}
			else
			{
				dictionary[feature.Spec] = ((!includeStars) ? new float[2]
				{
					devTime * feature.CodeArtRatio,
					devTime * (1f - feature.CodeArtRatio)
				} : new float[4]
				{
					devTime * feature.CodeArtRatio,
					devTime * (1f - feature.CodeArtRatio),
					(feature.CodeArtRatio > 0f) ? feature.Level : 0,
					(feature.CodeArtRatio < 1f) ? feature.Level : 0
				});
			}
		}
		if (OSs != null && OSs.Length != 0)
		{
			dictionary.GetOrAdd("System", (string x) => (!includeStars) ? new float[2] : new float[4])[0] += OSs.Length;
		}
		return dictionary;
	}

	public bool ForceIssueBool(string cat, Dictionary<string, SoftwareProduct> needs, IList<SoftwareProduct> OSs)
	{
		foreach (SpecFeature item in from x in Features.Values.OfType<SpecFeature>()
			where x.Forced && x.IsCompatible(cat)
			select x)
		{
			for (int num = 0; num < item.Dependencies.Length; num++)
			{
				string key = item.Dependencies[num];
				if (!needs.ContainsKey(key))
				{
					return true;
				}
			}
		}
		return false;
	}

	public string ForceIssue(string cat, Dictionary<string, SoftwareProduct> needs, SoftwareProduct[] OSs)
	{
		foreach (SpecFeature item in from x in Features.Values.OfType<SpecFeature>()
			where x.Forced && x.IsCompatible(cat)
			select x)
		{
			for (int num = 0; num < item.Dependencies.Length; num++)
			{
				string text = item.Dependencies[num];
				if (!needs.ContainsKey(text))
				{
					return text;
				}
			}
		}
		return null;
	}

	public uint GetReach(string category, IEnumerable<SoftwareProduct> OSs)
	{
		return GetReach(Categories[category], OSs);
	}

	public uint GetReach(SoftwareCategory catt, IEnumerable<SoftwareProduct> OSs)
	{
		if (OSSpecific)
		{
			return Math.Min((uint)Math.Round(catt.Popularity * (float)MarketSimulation.Population), GameSettings.Instance.simulation.GetOSCoverage(OSs));
		}
		return (uint)Math.Round(catt.Popularity * (float)MarketSimulation.Population);
	}

	public double FinalQualityCalc(double codeProgress, double artProgress, double codeQuality, double artQuality, IList<FeatureBase> features)
	{
		return SoftwareAlpha.FinalQualityCalc(codeProgress, artProgress, codeQuality, artQuality, CodeArtRatio(features));
	}

	public HashSet<string> GetValidSpecs(IList<SoftwareProduct> OSs)
	{
		if (!OSSpecific || OSs == null)
		{
			return null;
		}
		_osSpecCounter.Clear();
		for (int i = 0; i < OSs.Count; i++)
		{
			SoftwareProduct softwareProduct = OSs[i];
			for (int j = 0; j < softwareProduct.Features.Length; j++)
			{
				SpecFeature specFeature = softwareProduct.Features[j] as SpecFeature;
				if (specFeature != null)
				{
					_osSpecCounter.AddUp(specFeature.Spec);
				}
			}
		}
		foreach (KeyValuePair<string, FeatureBase> feature in Features)
		{
			SpecFeature specFeature2 = feature.Value as SpecFeature;
			if (specFeature2 != null && !MarketSimulation.Active.IsOSBacked(specFeature2.Spec))
			{
				_osSpecCounter[specFeature2.Spec] = OSs.Count;
			}
		}
		return (from x in _osSpecCounter
			where x.Value == OSs.Count
			select x.Key).ToHashSet();
	}

	public bool Licensable()
	{
		return MarketSimulation.Active.SoftwareTypes.Values.Any((SoftwareType x) => x.Features.Values.OfType<SpecFeature>().Any((SpecFeature z) => z.Dependencies.Contains(Name)));
	}

	public static Dictionary<string, float> GetToolRatio(IList<FeatureBase> features)
	{
		_toolRatioCache.Clear();
		for (int i = 0; i < features.Count; i++)
		{
			SpecFeature specFeature = features[i] as SpecFeature;
			if (specFeature != null)
			{
				for (int j = 0; j < specFeature.Dependencies.Length; j++)
				{
					string key = specFeature.Dependencies[j];
					_toolRatioCache.Append(key, specFeature.Spec);
				}
			}
		}
		float sum = features.SumSafe((FeatureBase x) => x.DevTime);
		return _toolRatioCache.ToDictionary((KeyValuePair<string, HashSet<string>> x) => x.Key, (KeyValuePair<string, HashSet<string>> x) => features.Where((FeatureBase z) => x.Value.Contains(z.Spec)).SumSafe((FeatureBase z) => z.DevTime) / sum);
	}

	public IEnumerable<SoftwareAddOn> GetValidAddons(SoftwareCategory cat, Dictionary<string, TechLevel> tech, IList<FeatureBase> features, SDateTime time)
	{
		foreach (SoftwareAddOn value in AddOns.Values)
		{
			if (value.Valid(cat) && value.IsUnlocked(time.Year) && ((value.BaseFeature != null && tech.ContainsKey(value.BaseFeature.Spec)) || (value.BaseFeature == null && value.Features.Values.Any((AddOnFeature x) => x.IsUnlocked(tech, cat) && (x.FeatureDependency == null || features.Any((FeatureBase z) => z.Name.Equals(x.FeatureDependency)))))))
			{
				yield return value;
			}
		}
	}

	public static float GetServerRequirement(IList<FeatureBase> features, float added = 0f)
	{
		float num = added;
		float num2 = 1f;
		for (int i = 0; i < features.Count; i++)
		{
			FeatureBase featureBase = features[i];
			if (featureBase.RelativeServer >= 0f)
			{
				num2 *= featureBase.RelativeServer;
			}
			num += featureBase.ServerRequirement;
		}
		return num * num2;
	}

	public static double CalculateRelevancy(IList<FeatureBase> features, Dictionary<string, TechLevel> tech, SoftwareCategory cat, double[] submarkets)
	{
		Dictionary<string, double> dictionary = tech.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => 0.0);
		for (int num = 0; num < features.Count; num++)
		{
			FeatureBase featureBase = features[num];
			if (featureBase is SpecFeature)
			{
				dictionary[featureBase.Spec] += featureBase.DevTime;
			}
			else if (featureBase.Level < 3)
			{
				dictionary[featureBase.Spec] += (double)(featureBase.DevTime * (float)featureBase.Level) * ((submarkets != null) ? featureBase.Submarkets.SubmarketDistance(submarkets) : 1.0);
			}
		}
		double num2 = 0.0;
		double num3 = dictionary.Sum((KeyValuePair<string, double> x) => x.Value);
		foreach (KeyValuePair<string, double> item in dictionary)
		{
			num2 += (double)tech[item.Key].GetRelevancy(cat) * (item.Value / num3);
		}
		return num2;
	}

	public static double BigProjectEffect(float devtime, double quality, double creativity, float actualDevtime)
	{
		if (devtime <= 40f)
		{
			return 1.0;
		}
		float num = devtime.MapRange(40f, 60f, 0f, 1f, true);
		num *= num;
		float num2 = Mathf.Clamp01(actualDevtime / devtime);
		double num3 = Utilities.Clamp01(quality * creativity * (double)num2 * 1.2000000476837158);
		return Utilities.Lerp(1.0, num3 * num3, num, true);
	}
}
