using System;
using System.Collections.Generic;
using System.Linq;
using Tyd;
using UnityEngine;

[Serializable]
public class SoftwareAddOn : IFormatColorObject, IManufacturable, IReferenceFix
{
	public struct AddonFeatureTest
	{
		public AddOnFeature Feature;

		public uint Factor;

		public double[] SubAdd;

		public double Score;

		public AddonFeatureTest(AddOnFeature f, SoftwareAddOn type, double[] targetMarket, SoftwareCategory category, Dictionary<string, TechLevel> parentTech)
		{
			Feature = f;
			SubAdd = new double[3];
			Score = 0.0;
			Factor = 1u;
			f.GetSubAdd(type, category, parentTech[f.Spec], SubAdd, 1u);
			Factor = TestCoverage(targetMarket, out Score);
		}

		private uint TestCoverage(double[] target, out double score)
		{
			double[] array = new double[3];
			uint result = 1u;
			score = 0.0;
			for (uint num = 1u; num <= Feature.MaxFactor; num++)
			{
				for (int i = 0; i < 3; i++)
				{
					array[i] = target[i] - SubAdd[i] * (double)num;
				}
				double num2 = 0.0;
				for (int j = 0; j < 3; j++)
				{
					num2 += (target[j] - array[j]) * (1.0 - Math.Abs(array[j]));
				}
				if (num2 > score)
				{
					result = num;
					score = num2;
				}
			}
			return result;
		}
	}

	public readonly string Name;

	public readonly string Description;

	public SoftwareType Parent;

	public string[] Categories;

	public Dictionary<string, AddOnFeature> Features;

	public readonly AddOnFeature BaseFeature;

	public readonly Manufacturing Manufacturing;

	private string _nameGen;

	public int? Unlock;

	public readonly float IdealPrice;

	public readonly float OptimalDevTime;

	public readonly bool Hardware;

	public readonly float? Forced;

	public readonly uint PerUser;

	public readonly float Retention;

	public uint ID = 1u;

	[NonSerialized]
	private Dictionary<uint, AddOnFeature> _featCache;

	private static List<AddonFeatureTest> _featureTestCache = new List<AddonFeatureTest>();

	public RandomNameGenerator GetNameGen(Dictionary<string, RandomNameGenerator> rng)
	{
		return rng[_nameGen];
	}

	public string GetNameGenName()
	{
		return _nameGen;
	}

	public AddOnFeature GetFeature(uint id)
	{
		if (_featCache == null)
		{
			_featCache = Features.Values.ToDictionary((AddOnFeature x) => x.ID, (AddOnFeature x) => x);
			if (BaseFeature != null)
			{
				_featCache[1u] = BaseFeature;
			}
		}
		return _featCache.GetOrNull(id);
	}

	public SoftwareAddOn()
	{
	}

	public SoftwareAddOn(SoftwareType p, SoftwareAddOn a)
	{
		try
		{
			Name = a.Name;
			Description = a.Description;
			Parent = p;
			Categories = a.Categories ?? p.Categories.Keys.ToArray();
			bool? flag = null;
			for (int i = 0; i < Categories.Length; i++)
			{
				string text = Categories[i];
				SoftwareCategory value;
				if (p.Categories.TryGetValue(text, out value))
				{
					if (!flag.HasValue)
					{
						flag = value.Hardware;
					}
					else if (flag.Value != value.Hardware)
					{
						throw new Exception("Can't use hardware and software categories for the same add-on: " + Name);
					}
					continue;
				}
				throw new Exception("Addon: " + Name + " using non-existent category " + text);
			}
			Hardware = flag.Value;
			Features = a.Features.ToDictionary((KeyValuePair<string, AddOnFeature> x) => x.Key, (KeyValuePair<string, AddOnFeature> x) => new AddOnFeature(x.Value));
			BaseFeature = a.BaseFeature;
			_nameGen = a._nameGen;
			Unlock = a.Unlock;
			OptimalDevTime = a.OptimalDevTime;
			Hardware = flag.Value;
			IdealPrice = a.IdealPrice;
			Forced = a.Forced;
			PerUser = a.PerUser;
			Retention = a.Retention;
			if (!Hardware && PerUser > 1)
			{
				throw new Exception("Only peripherals can have more than 1 sale per user");
			}
			if (!Hardware && Forced.HasValue)
			{
				throw new Exception("Only peripherals can be forced");
			}
			if (Hardware)
			{
				if (a.Manufacturing == null)
				{
					throw new Exception("Hardware add-on missing manufacturing process");
				}
				Manufacturing = new Manufacturing(a.Manufacturing, p, this);
			}
		}
		catch (Exception ex)
		{
			throw new Exception(string.Format("Error in add-on {0}: {1}", Name ?? "", ex.Message));
		}
	}

	public static AddOnFeature LoadBaseFeature(TydCollection node, string software)
	{
		if (node != null)
		{
			node.AddChild(new TydString("Name", "Base"));
			return new AddOnFeature(node, node.GetChildValue("Spec"), software, true);
		}
		return null;
	}

	public SoftwareAddOn(SoftwareType p, TydCollection node, string modPath, string softwareName)
	{
		try
		{
			Name = node.GetChildValue("Name");
			Description = node.GetChildValue("Description", false);
			OptimalDevTime = node.GetChildValue("OptimalDevTime", true, 0f);
			Retention = Mathf.Abs(node.GetChildValue("Retention", true, 0f));
			Parent = p;
			Forced = node.GetChildValue<float?>("Forced", false);
			if (Forced.HasValue && (Forced.Value < 0f || Forced.Value > 1f))
			{
				throw new Exception("Peripheral Forced value has to be between 0 and 1");
			}
			PerUser = node.GetChildValue("PerUser", false, 1u);
			BaseFeature = LoadBaseFeature(node.GetChild<TydCollection>("BaseFeature"), softwareName);
			if (PerUser < 1)
			{
				PerUser = 1u;
			}
			if (p != null)
			{
				TydNode child = node.GetChild("Categories");
				if (child != null)
				{
					Categories = child.GetNodeValues().ToArray();
				}
				else
				{
					Categories = p.Categories.Keys.ToArray();
				}
				bool? flag = null;
				for (int i = 0; i < Categories.Length; i++)
				{
					string text = Categories[i];
					SoftwareCategory value;
					if (p.Categories.TryGetValue(text, out value))
					{
						if (!flag.HasValue)
						{
							flag = value.Hardware;
						}
						else if (flag.Value != value.Hardware)
						{
							throw new Exception("Can't use hardware and software categories for the same add-on");
						}
						continue;
					}
					throw new Exception("Addon: " + Name + " using non-existent category " + text);
				}
				Hardware = flag.Value;
				if (!Hardware && PerUser > 1)
				{
					throw new Exception("Only peripherals can have more than 1 sale per user");
				}
				if (!Hardware && Forced.HasValue)
				{
					throw new Exception("Only peripherals can be forced");
				}
			}
			else
			{
				TydNode child2 = node.GetChild("Categories");
				if (child2 != null)
				{
					Categories = child2.GetNodeValues().ToArray();
				}
				else
				{
					Categories = null;
				}
				Hardware = false;
			}
			Features = new Dictionary<string, AddOnFeature>();
			foreach (TydCollection item in node.GetChild<TydCollection>("Features", true).Nodes.OfType<TydCollection>())
			{
				AddOnFeature addOnFeature = new AddOnFeature(item, item.GetChildValue("Spec"), softwareName, false);
				if (addOnFeature.Level == 3)
				{
					throw new Exception("Add-ons can't have level 3 features");
				}
				if (Features.ContainsKey(addOnFeature.Name))
				{
					throw new Exception("Can't re-use feature name: " + addOnFeature.Name);
				}
				Features[addOnFeature.Name] = addOnFeature;
			}
			Unlock = node.GetChildValue<int?>("Unlock", false);
			IdealPrice = node.GetChildValue("IdealPrice", true, 0f);
			_nameGen = node.GetChildValue("NameGenerator");
			if (Hardware || p == null)
			{
				TydTable child3 = node.GetChild<TydTable>("Manufacturing");
				if (child3 != null)
				{
					Manufacturing = new Manufacturing(child3, p, this, modPath);
				}
				else if (p != null)
				{
					throw new Exception("Hardware add-on missing manufacturing process");
				}
			}
		}
		catch (Exception ex)
		{
			throw new Exception(string.Format("Error in add-on {0}: {1}", Name ?? "", ex.Message));
		}
	}

	public bool Valid(SoftwareCategory cat)
	{
		return Categories.Contains(cat.Name);
	}

	public bool IsUnlocked(int year)
	{
		if (Unlock.HasValue)
		{
			return year >= Unlock.Value - 1900;
		}
		return true;
	}

	public string GetActualString()
	{
		return Name.LocSWC(Parent.Name);
	}

	public override string ToString()
	{
		return Name;
	}

	public IReferenceFix FixReferences()
	{
		return MarketSimulation.Active.GetSoftwareType(Parent.ID).GetAddon(ID);
	}

	public string ManufactureType()
	{
		return "AddOn";
	}

	public string GetPrettyName()
	{
		return Name.LocSWC(Parent.Name);
	}

	public string GetActualName()
	{
		return Name;
	}

	public Manufacturing GetManufacturing()
	{
		return Manufacturing;
	}

	public bool IsHardware()
	{
		return Hardware;
	}

	public bool MatchPath(string sw, string cat)
	{
		if (Parent.Name.Equals(sw))
		{
			return Name.Equals(cat);
		}
		return false;
	}

	public uint GetID()
	{
		return ID;
	}

	public float DevTime(IList<AddOnFeature> features, IList<uint> factors, SoftwareCategory category, Company c, Dictionary<string, TechLevel> techs)
	{
		float num = 0f;
		for (int i = 0; i < features.Count; i++)
		{
			num += features[i].GetDevTime(category, c, techs, factors[i]);
		}
		return num;
	}

	public double PerceivedValue(IList<AddOnFeature> features, IList<uint> factors, SoftwareCategory category, Dictionary<string, TechLevel> techs)
	{
		double num = 0.0;
		for (int i = 0; i < features.Count; i++)
		{
			AddOnFeature addOnFeature = features[i];
			num += addOnFeature.GetSubAdd(this, category, (techs == null) ? null : techs.GetOrDefault(addOnFeature.Spec), factors[i]);
			if (num > 1.0)
			{
				break;
			}
		}
		return Math.Min(1.0, num);
	}

	public double PerceivedMarketValue(IList<AddOnFeature> features, IList<uint> factors, SoftwareCategory category, Dictionary<string, TechLevel> techs, double[] subMarket, bool wasted = false)
	{
		double[] array = new double[3];
		for (int i = 0; i < features.Count; i++)
		{
			AddOnFeature addOnFeature = features[i];
			addOnFeature.GetSubAdd(this, category, techs.GetOrDefault(addOnFeature.Spec), array, factors[i], true);
		}
		if (!wasted)
		{
			return subMarket.SubmarketScore(array);
		}
		return subMarket.SubmarketScoreWasted(array);
	}

	public Dictionary<string, double[]> GetSummarizedMarketScore(SoftwareCategory cat, IList<AddOnFeature> features, IList<uint> featureFactors)
	{
		Dictionary<string, double[]> dictionary = new Dictionary<string, double[]>();
		for (int i = 0; i < features.Count; i++)
		{
			AddOnFeature addOnFeature = features[i];
			double[] orAdd = dictionary.GetOrAdd(addOnFeature.Spec, (string x) => new double[3]);
			addOnFeature.GetSubAdd(this, cat, null, orAdd, featureFactors[i], true);
		}
		return dictionary;
	}

	private void SubtractSubmarket(double[] a, double[] b, uint factor)
	{
		for (int i = 0; i < 3; i++)
		{
			a[i] = Math.Max(0.0, a[i] - b[i] * (double)factor);
		}
	}

	private bool SubmarketLeft(double[] a)
	{
		for (int i = 0; i < 3; i++)
		{
			if (a[i] > 0.0)
			{
				return true;
			}
		}
		return false;
	}

	private uint SubmarketOverlap(double[] a, double[] b)
	{
		uint num = 0u;
		for (int i = 0; i < 3; i++)
		{
			if (a[i] > 0.0 && b[i] > 0.0)
			{
				uint num2 = (uint)Utilities.CeilToInt(a[i] / b[i]);
				if (num2 > num)
				{
					num = num2;
				}
			}
		}
		return num;
	}

	public void GenerateFeatures(IList<FeatureBase> parentFeatures, Dictionary<string, TechLevel> parentTech, double[] subMarket, SoftwareCategory category, System.Random rnd, List<AddOnFeature> resultFeatures, List<uint> resultFactors)
	{
		double[] array = new double[3];
		double[] a = subMarket.ToArray();
		if (BaseFeature != null)
		{
			resultFeatures.Add(BaseFeature);
			resultFactors.Add(1u);
			BaseFeature.GetSubAdd(this, category, parentTech[BaseFeature.Spec], array, 1u);
			SubtractSubmarket(a, array, 1u);
		}
		foreach (AddOnFeature f in Features.Values)
		{
			if (f.IsForced && f.IsUnlocked(parentTech, category) && (f.FeatureDependency == null || parentFeatures.Any((FeatureBase x) => x.Name.Equals(f.FeatureDependency))))
			{
				f.GetSubAdd(this, category, parentTech[f.Spec], array, 1u);
				uint num = SubmarketOverlap(a, array);
				if (num == 0)
				{
					num = 1u;
				}
				else if (num > f.MaxFactor)
				{
					num = f.MaxFactor;
				}
				resultFeatures.Add(f);
				resultFactors.Add(num);
			}
		}
		if (!SubmarketLeft(a))
		{
			return;
		}
		_featureTestCache.Clear();
		_featureTestCache.AddRange(from x in Features.Values
			where !x.IsForced && parentTech.ContainsKey(x.Spec)
			select new AddonFeatureTest(x, this, subMarket, category, parentTech));
		foreach (AddonFeatureTest f2 in _featureTestCache.OrderByDescending((AddonFeatureTest x) => x.Score))
		{
			if (f2.Score < 0.0)
			{
				break;
			}
			if (!f2.Feature.IsUnlocked(parentTech, category) || (f2.Feature.FeatureDependency != null && !parentFeatures.Any((FeatureBase x) => x.Name.Equals(f2.Feature.FeatureDependency))))
			{
				continue;
			}
			uint num2 = SubmarketOverlap(a, f2.SubAdd);
			if (num2 != 0)
			{
				if (num2 > f2.Factor)
				{
					num2 = f2.Factor;
				}
				resultFeatures.Add(f2.Feature);
				resultFactors.Add(num2);
				SubtractSubmarket(a, f2.SubAdd, num2);
				if (!SubmarketLeft(a))
				{
					break;
				}
			}
		}
	}

	public HashSet<string> GetTools(IList<AddOnFeature> feats)
	{
		HashSet<string> hashSet = new HashSet<string>();
		HashSet<string> hashSet2 = feats.Select((AddOnFeature x) => x.Spec).ToHashSet();
		foreach (SpecFeature item in Parent.Features.Values.OfType<SpecFeature>())
		{
			if (hashSet2.Contains(item.Spec))
			{
				hashSet.AddRange(item.Dependencies);
			}
		}
		return hashSet;
	}

	public double GetTargeting(SoftwareCategory cat, IList<FeatureBase> features, double[] submarket, Dictionary<string, TechLevel> techs)
	{
		List<AddOnFeature> list = new List<AddOnFeature>();
		List<uint> list2 = new List<uint>();
		if (BaseFeature != null)
		{
			list.Add(BaseFeature);
			list2.Add(1u);
		}
		foreach (AddOnFeature f in Features.Values)
		{
			if (f.IsUnlocked(techs, cat) && (f.FeatureDependency == null || features.Any((FeatureBase x) => x.Name.Equals(f.FeatureDependency))))
			{
				list.Add(f);
				list2.Add(f.MaxFactor);
			}
		}
		return PerceivedMarketValue(list, list2, cat, techs, submarket);
	}
}
