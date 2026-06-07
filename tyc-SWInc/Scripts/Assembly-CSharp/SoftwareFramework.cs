using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;

[Serializable]
public class SoftwareFramework : IFormatColorObject, IReferenceFix
{
	public const float NewFactor = 1.25f;

	public const float UseFactor = 0.75f;

	public const float MaxRoyalty = 0.15f;

	public string Name;

	public Company Owner;

	public SoftwareType Type;

	public SoftwareCategory Category;

	public SDateTime Release;

	public SDateTime? LastUpdate;

	public int Updated;

	[AltWasFloat(0)]
	public Dictionary<FeatureBase, double> Features;

	public Dictionary<string, TechLevel> TechLevels;

	public float Income;

	public uint ID = 1u;

	public static float GetUpdateSpeed(int updates)
	{
		return Mathf.Lerp(0.25f, 1f, (float)updates / 3f);
	}

	public static float SpeedBoost(TechLevel framework, TechLevel software)
	{
		if (framework.Year >= software.Year)
		{
			return 1f;
		}
		float num = Mathf.Max(0f, 1f - (float)(framework.Outdates - software.Outdates) / 5f);
		return num * num;
	}

	public SoftwareFramework()
	{
	}

	public SoftwareFramework(string name, uint id, SoftwareType type, SoftwareCategory cat, IEnumerable<SoftwareWorkItem.FeatureProgress> features, Dictionary<string, TechLevel> techs, SDateTime releaseDate)
	{
		Name = name;
		ID = id;
		Type = type;
		Category = cat;
		Release = releaseDate;
		Features = features.Where((SoftwareWorkItem.FeatureProgress x) => !x.OS && x.GetOverallProgress() > 0.009999999776482582).ToDictionary((SoftwareWorkItem.FeatureProgress x) => x.Feature, (SoftwareWorkItem.FeatureProgress x) => x.GetOverallProgress());
		TechLevels = techs;
	}

	public SoftwareFramework(string name, uint id, uint type, uint cat, Dictionary<uint, double> features, Dictionary<string, int> techs, SDateTime releaseDate)
	{
		Name = name;
		ID = id;
		SoftwareType t = MarketSimulation.Active.GetSoftwareType(type);
		Type = t;
		Category = t.GetCategory(cat);
		Release = releaseDate;
		Features = features.ToDictionary((KeyValuePair<uint, double> x) => t.GetFeature(x.Key), (KeyValuePair<uint, double> x) => x.Value);
		TechLevels = techs.ToDictionary((KeyValuePair<string, int> x) => x.Key, (KeyValuePair<string, int> x) => MarketSimulation.Active.TechLevels[x.Key].First((TechLevel z) => z.Year == x.Value));
	}

	public void Transfer(Company c)
	{
		NetworkMessaging.SendTransferFramework((c != null) ? c.ID : 0u, ID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		ActuallyTransfer(c);
	}

	public void ActuallyTransfer(Company c)
	{
		if (Owner != null)
		{
			Owner.Frameworks.Remove(this);
		}
		Owner = c;
		if (c != null)
		{
			c.Frameworks.Add(this);
		}
		NetworkMeta.CheckDirty();
	}

	public float GetActualRoyalty(Company c)
	{
		if (!HasToPay(c))
		{
			return 0f;
		}
		return GetRoyalty();
	}

	public float GetRoyalty()
	{
		float num = 0f;
		double num2 = 0.0;
		int year = SDateTime.Now().Year;
		Dictionary<string, float> dict = TechLevels.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => x.Value.GetRelevancy(Category));
		foreach (FeatureBase value in Type.Features.Values)
		{
			if (value.Level < 3 && value.IsCompatible(Category.Name) && value.IsUnlocked(year))
			{
				num += value.DevTime;
				num2 += (double)value.DevTime * Features.GetOrDefault(value, 0.0) * (double)dict.GetOrDefault(value.Spec, 0f);
			}
		}
		return (float)(num2 / (double)num * 0.15000000596046448);
	}

	public float Quality()
	{
		float num = 0f;
		double num2 = 0.0;
		int year = SDateTime.Now().Year;
		Dictionary<string, float> dict = TechLevels.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => x.Value.GetRelevancy(Category));
		foreach (FeatureBase value in Type.Features.Values)
		{
			if (value.Level < 3 && value.IsCompatible(Category.Name) && value.IsUnlocked(year))
			{
				num += value.DevTime;
				num2 += (double)value.DevTime * Features.GetOrDefault(value, 0.0) * (double)dict.GetOrDefault(value.Spec, 0f);
			}
		}
		return (float)(num2 / (double)num);
	}

	public bool HasToPay(Company c)
	{
		if (Owner == null || Owner.Bankrupt || Owner == MarketSimulation.Active.PublicDomain)
		{
			return false;
		}
		if (c == Owner)
		{
			return false;
		}
		Company ownerCompany = c.OwnerCompany;
		if (ownerCompany != null && ownerCompany == Owner)
		{
			return false;
		}
		if (c.Subsidiaries.Contains(Owner.ID))
		{
			return false;
		}
		for (int i = 0; i < c.NewOwnedStock.Count; i++)
		{
			if (c.NewOwnedStock[i].Seller == Owner && c.NewOwnedStock[i].Percentage >= 0.25)
			{
				return false;
			}
		}
		return true;
	}

	public override string ToString()
	{
		return Name;
	}

	public IReferenceFix FixReferences()
	{
		return MarketSimulation.Active.GetFramework(ID);
	}

	public string GetActualString()
	{
		return Name;
	}

	public void Update(Dictionary<string, TechLevel> techs, SDateTime time)
	{
		if (techs == null || techs.Count == 0)
		{
			return;
		}
		if (NetworkManager.IsConnected)
		{
			NetworkMessaging.SendUpdateFramework(ID, techs.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => x.Value.Year), time, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		ActuallyUpdate(techs, time);
	}

	public void ActuallyUpdate(Dictionary<string, TechLevel> techs, SDateTime time)
	{
		if (techs == null || techs.Count <= 0)
		{
			return;
		}
		LastUpdate = time;
		Updated++;
		foreach (KeyValuePair<string, TechLevel> tech in techs)
		{
			TechLevels[tech.Key] = tech.Value;
		}
		NetworkMeta.CheckDirty();
	}
}
