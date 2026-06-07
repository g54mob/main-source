using System;
using System.Collections.Generic;
using Tyd;
using UnityEngine;

[Serializable]
public class SoftwareCategory : IFormatColorObject, IManufacturable, IReferenceFix
{
	public readonly string Name;

	public readonly string Description;

	public readonly SoftwareType Parent;

	public readonly float Retention;

	public readonly float TimeScale;

	public readonly float Iterative;

	public float Popularity;

	[AltWasFloat(0)]
	public double[] SubmarketEq;

	public float[][] SubmarketHistory = new float[12][];

	public int SubmarketHistoryIndex;

	private string _nameGen;

	public int? Unlock;

	public int? LagBehind;

	public readonly float IdealPrice;

	public readonly bool IsDefault;

	public readonly bool Hardware;

	public readonly bool ForcePopularity;

	public readonly Manufacturing Manufacturing;

	public bool Hidden;

	public uint ID = 1u;

	public float GetPopularityFactor(float factor = 0.1f)
	{
		if (!ForcePopularity)
		{
			return Popularity.WeightOne(factor);
		}
		return Popularity;
	}

	public void StoreHistory(SDateTime time)
	{
		float[] array = SubmarketHistory[SubmarketHistoryIndex];
		if (array == null)
		{
			array = (SubmarketHistory[SubmarketHistoryIndex] = new float[3]);
		}
		double[] quality = MarketSimulation.Active.GetQuality(this, time);
		double num = 0.0;
		for (int i = 0; i < 3; i++)
		{
			num += quality[i];
		}
		double[] subMarket = MarketSimulation.Active.GetSubMarket(this);
		for (int j = 0; j < 3; j++)
		{
			array[j] = (float)(((num > 0.0) ? (quality[j] / num) : 0.0) / subMarket[j]);
		}
		SubmarketHistoryIndex = (SubmarketHistoryIndex + 1) % SubmarketHistory.GetLength(0);
	}

	public SoftwareCategory(SoftwareType p, SoftwareCategory c, string defaultGen, float? idealPrice, bool? hardware, Manufacturing manufacturing)
	{
		try
		{
			Name = c.Name;
			Description = c.Description;
			Parent = p;
			Retention = c.Retention;
			TimeScale = c.TimeScale;
			Popularity = c.Popularity;
			Iterative = c.Iterative;
			_nameGen = defaultGen ?? c._nameGen;
			Unlock = c.Unlock;
			SubmarketEq = c.SubmarketEq;
			IsDefault = c.IsDefault;
			LagBehind = c.LagBehind;
			Hardware = c.Hardware;
			IdealPrice = (idealPrice.HasValue ? idealPrice.Value : c.IdealPrice);
			Hardware = (hardware.HasValue ? hardware.Value : c.Hardware);
			Hidden = c.Hidden;
			ForcePopularity = c.ForcePopularity;
			if (!Hardware)
			{
				return;
			}
			if (manufacturing != null)
			{
				Manufacturing = new Manufacturing(manufacturing, p, this);
				return;
			}
			if (c.Manufacturing != null)
			{
				Manufacturing = new Manufacturing(c.Manufacturing, p, this);
				return;
			}
			throw new Exception("Hardware category missing manufacturing process");
		}
		catch (Exception ex)
		{
			throw new Exception(string.Format("Error in category {0}: {1}", Name ?? "", ex.Message));
		}
	}

	public RandomNameGenerator GetNameGen(Dictionary<string, RandomNameGenerator> rng)
	{
		return rng[_nameGen];
	}

	public string GetNameGenName()
	{
		return _nameGen;
	}

	public SoftwareCategory(SoftwareType p, TydCollection node, string defaultGen, float? idealPrice, bool? hardware, Manufacturing manufacturing, string modPath)
	{
		try
		{
			Name = node.GetChildValue("Name");
			Description = node.GetChildValue("Description", false);
			Parent = p;
			Retention = Mathf.Abs(node.GetChildValue("Retention", true, 0f));
			TimeScale = Mathf.Abs(node.GetChildValue("TimeScale", true, 0f));
			Popularity = Mathf.Abs(node.GetChildValue("Popularity", true, 0f));
			Iterative = Mathf.Abs(node.GetChildValue("Iterative", true, 0f));
			Unlock = node.GetChildValue<int?>("Unlock", false);
			LagBehind = node.GetChildValue<int?>("LagBehind", false);
			ForcePopularity = node.GetChildValue("ForcePopularity", false, false);
			float? childValue = node.GetChildValue("IdealPrice", false, idealPrice);
			if (!childValue.HasValue)
			{
				throw new Exception("Ideal price not defined");
			}
			IdealPrice = childValue.Value;
			_nameGen = node.GetChildValue("NameGenerator", false, defaultGen);
			IsDefault = false;
			Hardware = node.GetChildValue("Hardware", false, hardware ?? false);
			SubmarketEq = SoftwareType.GetSoftwareEq(node.GetChild("Submarkets", true), false);
			if (!Hardware)
			{
				return;
			}
			TydTable child = node.GetChild<TydTable>("Manufacturing");
			if (child != null)
			{
				Manufacturing = new Manufacturing(child, p, this, modPath);
				return;
			}
			if (manufacturing != null)
			{
				Manufacturing = new Manufacturing(manufacturing, p, this);
				return;
			}
			throw new Exception("Hardware category missing manufacturing process");
		}
		catch (Exception ex)
		{
			throw new Exception(string.Format("Error in category {0}: {1}", Name ?? "", ex.Message));
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

	public SoftwareCategory(SoftwareType p, string name, string description, float retention, float timescale, float popularity, bool forcePopularity, float iterative, double[] submarketeq, float idealPrice, string nameGen, bool isDefault, bool hardware, Manufacturing manufacturing)
	{
		Name = name;
		Parent = p;
		Description = description;
		Retention = retention;
		TimeScale = timescale;
		Popularity = popularity;
		Iterative = iterative;
		IdealPrice = idealPrice;
		_nameGen = nameGen;
		SubmarketEq = submarketeq;
		ForcePopularity = forcePopularity;
		IsDefault = isDefault;
		Hardware = hardware;
		if (Hardware)
		{
			if (manufacturing == null)
			{
				throw new Exception("Hardware category missing manufacturing process");
			}
			Manufacturing = new Manufacturing(manufacturing, p, this);
		}
	}

	public SoftwareCategory()
	{
	}

	public static SoftwareCategory GetDefault(SoftwareType p, float popularity, bool forcePopularity, float retention, float iterative, float idealPrice, double[] submarketeq, string nameGen, bool hardware, Manufacturing manufacturing)
	{
		return new SoftwareCategory(p, "Default", "", retention, 1f, popularity, forcePopularity, iterative, submarketeq, idealPrice, nameGen, true, hardware, manufacturing);
	}

	public TechLevel GetTechLimit(SpecFeature feat, Dictionary<string, SoftwareProduct> needs, SoftwareFramework framework, Company c, SDateTime time)
	{
		string lim = null;
		return GetTechLimit(feat, needs, framework, ref lim, GameSettings.Instance.simulation.GetLatestTech(feat.Spec, time, this, c));
	}

	public TechLevel GetTechLimit(SpecFeature feat, Dictionary<string, SoftwareProduct> needs, SoftwareFramework framework, ref string lim, TechLevel max)
	{
		if (max == null)
		{
			return null;
		}
		TechLevel value;
		if (framework != null && framework.TechLevels.TryGetValue(feat.Spec, out value) && value.Year < max.Year)
		{
			lim = framework.Name;
			max = value;
		}
		for (int i = 0; i < feat.Dependencies.Length; i++)
		{
			SoftwareProduct value2;
			if (needs.TryGetValue(feat.Dependencies[i], out value2) && value2 != null)
			{
				TechLevel orDefault = value2.TechLevels.GetOrDefault(feat.Spec);
				if (orDefault != null && orDefault.Year < max.Year)
				{
					max = orDefault;
					lim = value2.Name;
				}
				continue;
			}
			return null;
		}
		return max;
	}

	public double GetRetentionFact()
	{
		if (Retention != 0f)
		{
			return Math.Pow(0.009999999776482582, 1f / Retention);
		}
		return 0.0;
	}

	public override string ToString()
	{
		return Parent.Name + ": " + Name;
	}

	public IReferenceFix FixReferences()
	{
		return MarketSimulation.Active.GetSoftwareType(Parent.ID).GetCategory(ID);
	}

	public string ManufactureType()
	{
		return "Category";
	}

	public string GetPrettyName()
	{
		return Parent.Name.LocSWFull(Name);
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

	public string GetActualString()
	{
		return Parent.Name.LocSWFull(Name);
	}

	public double PerceivedValue(IList<FeatureBase> features, Dictionary<string, TechLevel> techs)
	{
		double num = 0.0;
		for (int i = 0; i < features.Count; i++)
		{
			FeatureBase featureBase = features[i];
			num += featureBase.GetSubAdd(this, (techs == null) ? null : techs.GetOrDefault(featureBase.Spec));
			if (num > 1.0)
			{
				break;
			}
		}
		return Math.Min(1.0, num);
	}

	public double PerceivedMarketValue(IList<FeatureBase> features, Dictionary<string, TechLevel> techs, double[] subMarket, double bigProjectFactor, bool wasted = false)
	{
		double[] array = new double[3];
		for (int i = 0; i < features.Count; i++)
		{
			FeatureBase featureBase = features[i];
			featureBase.GetSubAdd(this, (techs != null) ? techs.GetOrDefault(featureBase.Spec) : null, array, true);
		}
		for (int j = 0; j < 3; j++)
		{
			array[j] *= bigProjectFactor;
		}
		if (!wasted)
		{
			return subMarket.SubmarketScore(array);
		}
		return subMarket.SubmarketScoreWasted(array);
	}

	public Dictionary<string, double[]> GetSummarizedMarketScore(IList<FeatureBase> features)
	{
		Dictionary<string, double[]> dictionary = new Dictionary<string, double[]>();
		for (int i = 0; i < features.Count; i++)
		{
			FeatureBase featureBase = features[i];
			double[] orAdd = dictionary.GetOrAdd(featureBase.Spec, (string x) => new double[3]);
			featureBase.GetSubAdd(this, null, orAdd, true);
		}
		return dictionary;
	}

	public void GetFinalScoreFromSummary(Dictionary<string, double[]> summation, Dictionary<string, TechLevel> techs, double[] quality, double[] submarketTarget, double[] output)
	{
		for (int i = 0; i < 3; i++)
		{
			output[i] = 0.0;
		}
		foreach (KeyValuePair<string, double[]> item in summation)
		{
			for (int j = 0; j < 3; j++)
			{
				if (submarketTarget[j] > 0.0)
				{
					output[j] += Math.Min(1.0, item.Value[j] * FeatureBase.GetSubScale(techs[item.Key], this, quality[j]) / submarketTarget[j]) * submarketTarget[j];
				}
			}
		}
	}

	public float RepCut(Company main, Company publisher)
	{
		return Mathf.Max(main.GetReputation(this), publisher.GetReputation(this) * 0.5f);
	}
}
