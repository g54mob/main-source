using System;
using System.Linq;
using SINetworking;
using UnityEngine;

[Serializable]
[AltDeprecate("ActualBandwidthSales", typeof(uint))]
public class DistributionPlatform : IServerItem, IReferenceFix, IFormatColorObject
{
	public const float BandwidthPerSale = 0.05f;

	public Company Owner;

	public SoftwareProduct Software;

	public SDateTime Founded;

	public bool Open = true;

	public float ItemSales;

	public float ActualItemSales;

	[IgnoreNetwork]
	public string ServerName;

	public float LastLoad = 1f;

	[NameRedirection(new string[] { "Cut" })]
	private float _cut = 0.05f;

	public float MarketShare;

	private float _extraBandwidth;

	private uint _targetUsers;

	public uint ActualUsers;

	public uint UserPenalty;

	public uint BitID;

	private bool _autoAcceptClients = true;

	public float AvailableBandwidth;

	public bool AutoAcceptClients
	{
		get
		{
			return _autoAcceptClients;
		}
	}

	public bool UsesISP
	{
		get
		{
			return true;
		}
	}

	public float GetCut()
	{
		return _cut;
	}

	public void UpdateBandwidth(SDateTime time)
	{
		if (ServerName != null)
		{
			ServerGroup serverGroup = GameSettings.Instance.GetServerGroup(ServerName);
			if (serverGroup != null)
			{
				AvailableBandwidth = serverGroup.PowerSum - serverGroup.Items.Where((IServerItem x) => x != this).SumSafe((IServerItem x) => x.GetLoadRequirement().BandwidthFactor(time));
			}
			else
			{
				AvailableBandwidth = 0f;
			}
		}
		else
		{
			AvailableBandwidth = 0f;
		}
	}

	public void SetCut(float cut, bool fromNetwork = false)
	{
		if (!fromNetwork)
		{
			NetworkMessaging.SendDistributionCut(Software.ID, cut, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		float val;
		if (!GameSettings.Instance.PreSimActive && GameSettings.Instance.MyCompany.IsSigned(this) && HasToPay(GameSettings.Instance.MyCompany) && GameSettings.Instance.MyCompany.DistributionAcceptedAt(this, out val) && val + 0.01f <= cut)
		{
			if (GameSettings.HasCompletedOrInMission("Marketing"))
			{
				NotificationManager.AddNotification(new DigitalDistributionCutChange(this, val, cut));
			}
			GameSettings.Instance.MyCompany.ChangeDistributionAccept(Owner, cut);
		}
		_cut = cut;
	}

	public void SetAutoAcceptClients(bool autoAcceptClients, bool fromNetwork = false)
	{
		if (!fromNetwork && autoAcceptClients != _autoAcceptClients)
		{
			NetworkMessaging.SendChangePlatformAccept(Owner.ID, true, autoAcceptClients, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		_autoAcceptClients = autoAcceptClients;
	}

	public static float AcceptableCut(float share)
	{
		return share.MapRange(0f, 0.4f, 0.05f, 0.3f, true);
	}

	public float CutScore()
	{
		float num = AcceptableCut(MarketShare);
		float num2 = 1f;
		if (Owner.Player)
		{
			float discreteRep = Owner.DiscreteRep;
			if (discreteRep < 1f)
			{
				num2 = Mathf.Lerp(discreteRep, Mathf.Min(discreteRep * 2f, 1f), MarketShare / MarketSimulation.Active.DistributionPlatforms.MaxSafe((DistributionPlatform x) => x.MarketShare));
			}
		}
		return Mathf.Min(num / GetCut(), 2f) * ((float)ActualUsers / (float)MarketSimulation.Population) * num2;
	}

	public void RecalculateTargetUsers(uint maxPopulation, double pvsd)
	{
		_targetUsers = (uint)((float)maxPopulation * GetFeatScore() * GetTechScore() * GetQualityScore());
		if (UserPenalty > _targetUsers)
		{
			_targetUsers = 0u;
		}
		else
		{
			_targetUsers -= UserPenalty;
		}
		UserPenalty = (uint)(0.9f.SpreadPercentage(GameSettings.DaysPerMonth) * (float)UserPenalty);
		ActualUsers = (uint)Mathf.Lerp(ActualUsers, _targetUsers, 0.25f.SpreadPercentage(GameSettings.DaysPerMonth));
		Software.Userbase = (int)((double)ActualUsers * (1.0 - pvsd));
		NetworkMessaging.SendDistributionStats(Software.ID, _targetUsers, UserPenalty, ActualUsers, Software.Userbase, false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
	}

	public void SyncTargetUsers(uint target, uint penalty, uint actualUsers, int userBase)
	{
		_targetUsers = target;
		UserPenalty = penalty;
		ActualUsers = actualUsers;
		Software.Userbase = userBase;
	}

	public DistributionPlatform()
	{
	}

	public DistributionPlatform(uint bitID, Company owner, SoftwareProduct software, float cut)
	{
		BitID = bitID;
		Owner = owner;
		Software = software;
		Founded = software.Release;
		_cut = cut;
		UpdateExtraBandwidth();
	}

	public void UpdateExtraBandwidth()
	{
		_extraBandwidth = Software.ServerReq;
	}

	public bool HasToPay(Company c)
	{
		if (Owner == c)
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

	public bool CancelOnUnload()
	{
		return false;
	}

	public float GetLoadRequirement()
	{
		return ActualItemSales * (0.05f + _extraBandwidth);
	}

	public void AddPenalty(uint add, bool fromNetwork = false)
	{
		if (add != 0)
		{
			UserPenalty += add;
			if (!fromNetwork)
			{
				NetworkMessaging.SendDistributionStats(Software.ID, 0u, UserPenalty, 0u, 0, true, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
		}
	}

	public void HandleLoad(float load)
	{
		if (Owner.IsLocalPlayer && load < 1f)
		{
			AddPenalty((uint)((1f - load) * 0.05f * (float)_targetUsers));
			if (!NotificationManager.CheckAggregate<ServerIssueNotification>(ServerName))
			{
				NotificationManager.AddNotification(new ServerIssueNotification(ServerName));
			}
		}
		LastLoad = load;
	}

	public float GetQualityScore()
	{
		return (float)(Software.RealQuality * Software.CreativityScore.WeightOne(0.25));
	}

	public float GetFeatScore()
	{
		return Software.Features.SumSafe((FeatureBase x) => x.DevTime) / MarketSimulation.Active.GetDistributionMaxDevTime();
	}

	public float GetTechScore()
	{
		return (float)Software.CalculateRelevancy(false);
	}

	public float GetStabilityScore()
	{
		float num = _targetUsers + UserPenalty;
		if (num > 0f)
		{
			return 1f - (float)UserPenalty / num;
		}
		return 1f;
	}

	public string GetDescription()
	{
		return Software.Name;
	}

	public void SerializeServer(string name)
	{
		ServerName = name;
	}

	public string GetActualString()
	{
		return Software.Name;
	}

	public override string ToString()
	{
		return Software.Name;
	}

	public IReferenceFix FixReferences()
	{
		return MarketSimulation.Active.DistributionPlatforms.FirstOrDefault((DistributionPlatform x) => x.Software.ID == Software.ID);
	}
}
