using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;

[Serializable]
public class TechLevel : IFormatColorObject, IReferenceFix
{
	public const float ResearchBoost = 0.9f;

	public static float PatentPrice = 50000f;

	public static int PatentExpiration = 10;

	public static int TechMaxRelevancy = 6;

	public static int TechMaxDevtimeCooldown = 20;

	public static int TechRelevancyGrace = 2;

	public string Spec;

	public int Year;

	public bool CanPatent = true;

	public float Income;

	public readonly float Royalty;

	public int Outdates;

	public Dictionary<SoftwareCategory, int> MarketOutdates = new Dictionary<SoftwareCategory, int>();

	private Dictionary<SoftwareCategory, float> _cachedRelevancy = new Dictionary<SoftwareCategory, float>();

	private uint _patentOwner;

	public int ActualYear
	{
		get
		{
			return 1900 + Year;
		}
	}

	public uint PatentOwner
	{
		get
		{
			if (_patentOwner != 0)
			{
				CheckPatentValid();
			}
			return _patentOwner;
		}
	}

	private static float ClampedRel(int outdates, int cooldown)
	{
		return (1f - Mathf.Min(1f, (float)outdates / (float)cooldown)).InOutCurve().WeightOne(0.9f);
	}

	public float GetRelevancy(SoftwareCategory cat)
	{
		return _cachedRelevancy.GetOrDefault(cat, 1f);
	}

	public float GetDevTime()
	{
		return ClampedRel(Outdates, TechMaxDevtimeCooldown).MapRange(0.1f, 1f, 0.5f, 1.2f);
	}

	public void RefreshRelevancy(SoftwareCategory cat)
	{
		int num = Mathf.Max(0, MarketOutdates.GetOrDefault(cat, 0) - TechRelevancyGrace);
		if (num < TechMaxRelevancy)
		{
			_cachedRelevancy[cat] = ClampedRel(num, TechMaxRelevancy);
		}
		else
		{
			_cachedRelevancy[cat] = 0.1f / ((float)(num - TechMaxRelevancy) + 1f);
		}
	}

	public TechLevel()
	{
	}

	public TechLevel(string spec, int year, float royalty)
	{
		Spec = spec;
		Year = year;
		Royalty = royalty;
	}

	public bool CheckPatentValid()
	{
		if (_patentOwner != 0 && GameSettings.Instance.simulation.GetCompany(_patentOwner) == null)
		{
			_patentOwner = 0u;
		}
		if (TimeOfDay.Instance.Year - Year > PatentExpiration)
		{
			if (_patentOwner != 0)
			{
				Company company = GameSettings.Instance.simulation.GetCompany(_patentOwner);
				if (company != null)
				{
					if (company.IsLocalPlayer)
					{
						NotificationManager.AddNotification("PatentExpiration".Loc(Spec.LocTry(), ActualYear), "Law", NotificationManager.NotificationType.Neutral);
					}
					company.Patents.Remove(this);
				}
				_patentOwner = 0u;
			}
			return false;
		}
		return true;
	}

	public bool HasToPay(Company c)
	{
		if (_patentOwner == 0)
		{
			return false;
		}
		if (_patentOwner == c.ID)
		{
			return false;
		}
		Company ownerCompany = c.OwnerCompany;
		if (ownerCompany != null && ownerCompany.ID == _patentOwner)
		{
			return false;
		}
		if (c.Subsidiaries.Contains(_patentOwner))
		{
			return false;
		}
		for (int i = 0; i < c.NewOwnedStock.Count; i++)
		{
			if (c.NewOwnedStock[i].Seller.ID == _patentOwner && c.NewOwnedStock[i].Percentage >= 0.25)
			{
				return false;
			}
		}
		return true;
	}

	public float GetActualRoyalty()
	{
		if (_patentOwner == 0)
		{
			return 0f;
		}
		return Royalty;
	}

	public bool TransferPatent(Company newOwner, SDateTime time)
	{
		if (!CheckPatentValid())
		{
			return false;
		}
		NetworkMessaging.SendTransferPatent(Spec, Year, (newOwner != null) ? newOwner.ID : 0u, time, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		return ActuallyTransferPatent(newOwner, time);
	}

	public bool ActuallyTransferPatent(Company newOwner, SDateTime time)
	{
		if (PatentOwner != 0)
		{
			Company company = GameSettings.Instance.simulation.GetCompany(PatentOwner);
			if (company != null)
			{
				company.Patents.Remove(this);
			}
		}
		if (newOwner == null)
		{
			_patentOwner = 0u;
		}
		else
		{
			if (_patentOwner == 0)
			{
				newOwner.AddMarketEvent(new MarketEvent(MarketEvent.EventType.Patent, time, Spec, (uint)ActualYear), false);
			}
			_patentOwner = newOwner.ID;
			newOwner.Patents.Add(this);
		}
		NetworkMeta.CheckDirty();
		return true;
	}

	public override string ToString()
	{
		return Spec;
	}

	public IReferenceFix FixReferences()
	{
		return MarketSimulation.Active.GetTechLevel(Spec, Year);
	}

	public string GetActualString()
	{
		return Spec.LocTry();
	}

	public static void CleanTechLevels(Dictionary<string, TechLevel> techs, IList<FeatureBase> features)
	{
		HashSet<string> hashSet = new HashSet<string>();
		for (int i = 0; i < features.Count; i++)
		{
			FeatureBase featureBase = features[i];
			hashSet.Add(featureBase.Spec);
		}
		foreach (string item in techs.Keys.ToList())
		{
			if (!hashSet.Contains(item))
			{
				techs.Remove(item);
			}
		}
	}
}
