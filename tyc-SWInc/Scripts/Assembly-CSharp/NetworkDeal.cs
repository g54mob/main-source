using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SINetworking;

[Serializable]
public class NetworkDeal : NetworkTrade<NetworkDeal.NetworkWorkItemID>, IReferenceFix
{
	[Serializable]
	public class NetworkWorkItemID
	{
		public readonly uint ID;

		public NetworkWorkItemID()
		{
		}

		public NetworkWorkItemID(uint id)
		{
			ID = id;
		}

		protected bool Equals(NetworkWorkItemID other)
		{
			return ID == other.ID;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((NetworkWorkItemID)obj);
		}

		public override int GetHashCode()
		{
			return (int)ID;
		}

		public override string ToString()
		{
			return ID.ToString();
		}
	}

	public float OnComplete;

	public float PerUnit;

	public float Royalty;

	public uint Limit;

	public SDateTime? EndDate;

	public string WorkName;

	public string UnitName;

	public List<KeyValuePair<string, string>> Info;

	public override bool CancelForSender
	{
		get
		{
			return true;
		}
	}

	public override bool KeepOnAccept
	{
		get
		{
			return true;
		}
	}

	public override bool CancelOnDisconnect
	{
		get
		{
			return false;
		}
	}

	public NetworkDeal()
	{
	}

	public NetworkDeal(uint id, NetworkPlayer sender, NetworkPlayer receiver, uint workItemID, float onAccept, float onComplete, float perUnit, float royalty, uint limit, SDateTime? endDate, string workName, string unitName, List<KeyValuePair<string, string>> info)
		: base(id, sender, receiver, new NetworkWorkItemID(workItemID), onAccept)
	{
		OnComplete = onComplete;
		PerUnit = perUnit;
		Royalty = royalty;
		Limit = limit;
		EndDate = endDate;
		WorkName = workName;
		UnitName = unitName;
		Info = info;
	}

	public override string GetReceiveMessage()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("NetworkDealInto".Loc(base.Sender.Name) + " ");
		List<string> list = new List<string>();
		if (Offer > 0f)
		{
			list.Add("NetworkDealAccept".Loc(Offer.Currency()));
		}
		if (OnComplete > 0f)
		{
			list.Add("NetworkDealCompletion".Loc(OnComplete.Currency()));
		}
		if (Royalty > 0f)
		{
			list.Add("NetworkDealRoyalties".Loc(Royalty.ToPercent()));
		}
		if (PerUnit > 0f)
		{
			list.Add("NetworkDealUnit".Loc(PerUnit.Currency(), Utilities.RobustStringFormat(UnitName.Loc(), false, false)));
		}
		stringBuilder.Append(Newspaper.MakeList(list, true, true) + " ");
		if (Limit != 0)
		{
			stringBuilder.Append("NetworkDealLimit".Loc(UnitName.LocPlural(Limit)) + " ");
		}
		stringBuilder.Append("NetworkDealWork".Loc(WorkName) + " ");
		if (EndDate.HasValue)
		{
			stringBuilder.Append("NetworkDealDeadline".Loc(EndDate.Value.ToCompactString2()));
		}
		return stringBuilder.ToString().TrimEnd();
	}

	public override string GetSendMessage()
	{
		return GetReceiveMessage();
	}

	public override float GetBaseWorth()
	{
		return 0f;
	}

	public WorkItem GetWorkItem()
	{
		return GameSettings.Instance.MyCompany.WorkItems.FirstOrDefault((WorkItem x) => Resource.Equals(x.WorkItemID));
	}

	public override void AcceptTrade()
	{
		if (Offer > 0f)
		{
			ReceiverCompany.MakeTransaction(Offer, Company.TransactionCategory.Deals, base.Sender.Name);
			SenderCompany.MakeTransaction(0f - Offer, Company.TransactionCategory.Deals, base.Receiver.Name);
		}
	}

	public override void OnCancelled()
	{
		WorkItem workItem = GetWorkItem();
		if (workItem != null && workItem.NetworkDeal == this)
		{
			if (base.Sender.Self)
			{
				workItem.NetworkDeal = null;
				workItem.guiItem.InitButtons();
			}
			else
			{
				workItem.Kill();
			}
		}
	}

	public override void AcceptTradeSender()
	{
		WorkItem workItem = GetWorkItem();
		if (workItem != null)
		{
			workItem.NetworkDeal = this;
			workItem.guiItem.InitButtons();
			NetworkMessaging.SendNewNetworkDeal(workItem, NetworkMessaging.MessageTarget.Specifically, base.Receiver.ID);
			workItem.guiItem.UpdatePauseButton();
			workItem.InitNetworkDealAccepted();
		}
	}

	public override byte TypeID()
	{
		return 5;
	}

	public override void Focus()
	{
		GUIWindow tableInfoWindow = WindowManager.GetTableInfoWindow("DealInfo" + Resource.ID);
		if (tableInfoWindow != null)
		{
			tableInfoWindow.Show();
			return;
		}
		WindowManager.SpawnTableInfoWindow("Deal".Loc(), WorkName, Info.SelectInPlace((KeyValuePair<string, string> x) => x.Key), Info.SelectInPlace((KeyValuePair<string, string> x) => x.Value), "DealInfo" + Resource.ID);
	}

	public override string Description()
	{
		return WorkName;
	}

	public override void WriteSubData(Stream st)
	{
		st.WriteUInt(Resource.ID);
		st.WriteStringUTF8(WorkName);
		st.WriteStringUTF8(UnitName);
		st.WriteFloat(OnComplete);
		st.WriteFloat(PerUnit);
		st.WriteFloat(Royalty);
		st.WriteUInt(Limit);
		st.WriteBool(EndDate.HasValue);
		if (EndDate.HasValue)
		{
			EndDate.Value.WriteData(st);
		}
		st.WriteArray(Info, delegate(Stream s, KeyValuePair<string, string> x)
		{
			s.WriteStringUTF8(x.Key);
			s.WriteStringUTF8(x.Value);
		});
	}

	public IReferenceFix FixReferences()
	{
		SenderCompany = MarketSimulation.Active.GetCompany(SenderCompany.ID);
		ReceiverCompany = MarketSimulation.Active.GetCompany(ReceiverCompany.ID);
		return this;
	}
}
