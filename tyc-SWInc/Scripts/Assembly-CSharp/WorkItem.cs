using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[AllowScopeList]
public abstract class WorkItem : IFormatColorObject, ILossable, IReferenceFix, IByteData
{
	public enum NetworkDealState
	{
		None = 0,
		Sender = 1,
		Receiver = 2
	}

	public enum HasWorkReturn
	{
		True = 0,
		Ignore = 1,
		Finished = 2,
		NotApplicable = 3,
		Waiting = 4,
		Secondary = 5,
		Pretend = 6
	}

	private static Dictionary<Type, string> _workNames = new Dictionary<Type, string>();

	public string _name;

	public readonly uint ID;

	public int Priority = 5;

	private float[] WorkerSkill = new float[5];

	[AltWasFloat(0)]
	public double Loss;

	[AltWasFloat(0)]
	public double[] LossBreakdown = new double[15];

	protected uint deal;

	public float TotalNetworkUnits;

	public float LastNetworkUnits;

	public string NetworkStage;

	public string NetworkCategory;

	public string NetworkProgressLabel;

	public float NetworkProgress;

	public int SiblingIndex = -1;

	public SHashSet<string> DevTeams = new SHashSet<string>();

	private SimulatedCompany _companyWorker;

	public bool Done;

	public bool AutoDev;

	public ContractWork contract;

	public bool Collapsed;

	public bool Enabled = true;

	private bool _hidden;

	private bool _wasCancelled;

	public bool _paused;

	[NonSerialized]
	public Vector2 MouseRel;

	[NonSerialized]
	public GUIWorkItem guiItem;

	public int MiniGameLives = 3;

	public NetworkDeal NetworkDeal;

	public NetworkDeal.NetworkWorkItemID WorkItemID;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
			if (guiItem != null)
			{
				guiItem.Title.text = Name;
			}
		}
	}

	public WorkDeal ActiveDeal
	{
		get
		{
			if (deal != 0)
			{
				return HUD.Instance.dealWindow.AllDeals.GetOrNull(deal) as WorkDeal;
			}
			return null;
		}
		set
		{
			deal = ((value != null) ? value.ID : 0u);
		}
	}

	public SimulatedCompany CompanyWorker
	{
		get
		{
			return _companyWorker;
		}
		set
		{
			if (CanUseCompany())
			{
				if (value != null)
				{
					ClearTeams();
				}
				_companyWorker = value;
			}
		}
	}

	public bool Hidden
	{
		get
		{
			return _hidden;
		}
		set
		{
			_hidden = value;
			if (guiItem != null)
			{
				guiItem.UpdateActivation();
			}
		}
	}

	public virtual bool Paused
	{
		get
		{
			return _paused;
		}
		set
		{
			_paused = value;
			PauseChange();
		}
	}

	public string QueryString
	{
		get
		{
			return GetSubjectName() + " " + GetWorkTypeName().Loc();
		}
	}

	public virtual bool CanOutsourceNetwork
	{
		get
		{
			return false;
		}
	}

	public virtual string UnitName
	{
		get
		{
			return null;
		}
	}

	public virtual uint MaxUnits
	{
		get
		{
			return 0u;
		}
	}

	public virtual Color BackColor
	{
		get
		{
			return Color.white;
		}
	}

	public virtual bool AlwaysUseLocalProgressLabel
	{
		get
		{
			return false;
		}
	}

	public virtual bool AlwaysUseLocalCategory
	{
		get
		{
			return false;
		}
	}

	public virtual bool AlwaysUseLocalStageLabel
	{
		get
		{
			return false;
		}
	}

	public virtual byte ByteTypeID
	{
		get
		{
			return 0;
		}
	}

	public virtual bool HasNaturalNetworkEnd
	{
		get
		{
			return false;
		}
	}

	public static string GetWorkTypeName(WorkItem item)
	{
		return GetWorkTypeName(item.GetType());
	}

	public static string GetWorkTypeName(Type type)
	{
		string value;
		if (_workNames.TryGetValue(type, out value))
		{
			return value;
		}
		string name = type.Name;
		_workNames[type] = name;
		return name;
	}

	public bool GetCanOutsourceNetwork()
	{
		if (CanOutsourceNetwork && NetworkDeal == null && deal == 0)
		{
			return contract == null;
		}
		return false;
	}

	public NetworkDealState GetNetworkDealState()
	{
		if (NetworkDeal != null)
		{
			if (!NetworkDeal.IsSender)
			{
				return NetworkDealState.Receiver;
			}
			return NetworkDealState.Sender;
		}
		return NetworkDealState.None;
	}

	public bool IsWorkOwner()
	{
		if (NetworkDeal != null)
		{
			return NetworkDeal.IsSender;
		}
		if (deal == 0)
		{
			return contract == null;
		}
		return false;
	}

	public Company GetWorkOwner()
	{
		if (NetworkDeal == null)
		{
			return GetLocalCompanyOwner();
		}
		return NetworkDeal.SenderCompany;
	}

	public virtual Company GetLocalCompanyOwner()
	{
		return GameSettings.Instance.MyCompany;
	}

	public virtual IRoyaltyItem GetRoyaltyItem()
	{
		return null;
	}

	public virtual void OnNetworkComplete(Stream st)
	{
	}

	public virtual void InitNetworkDealAccepted()
	{
	}

	public virtual byte[] GetNetworkCompletionData(bool success)
	{
		return null;
	}

	public void SendDeal(NetworkPlayer player)
	{
		if (WorkItemID == null)
		{
			NetworkMessaging.GetGlobalNetworkID(delegate(uint x)
			{
				WorkItemID = new NetworkDeal.NetworkWorkItemID(x);
				SubSendDeal(player);
			}, NetworkManager.NetworkIDType.WorkItem);
		}
		else
		{
			SubSendDeal(player);
		}
	}

	public virtual List<KeyValuePair<string, string>> GetInfo()
	{
		return new List<KeyValuePair<string, string>>();
	}

	private void SubSendDeal(NetworkPlayer player)
	{
		NetworkManager.Instance.TradeController.CreateOffer(player, 0f, (uint id, float amount) => new NetworkDeal(id, NetworkManager.Self, player, WorkItemID.ID, 10f, 10f, 10f, 0.1f, 100u, SDateTime.Now() + 6, Name, UnitName, GetInfo()), WorkItemID);
	}

	public abstract string GetSubjectName();

	protected void RecordSkill(Employee.EmployeeRole role, float value, float delta)
	{
		WorkerSkill[(int)role] = Mathf.Lerp(WorkerSkill[(int)role], value, Utilities.PerDay(1f + value * 8f, delta));
	}

	protected void RecordSkill(Employee.EmployeeRole role, Actor act, float delta)
	{
		RecordSkill(role, act.employee.GetSkill(role), delta);
	}

	public virtual void DevTeamChange()
	{
	}

	public virtual void PauseChange()
	{
	}

	public void HandleUnitPayout()
	{
		if (GetNetworkDealState() == NetworkDealState.Receiver && NetworkDeal.PerUnit > 0f)
		{
			float num = TotalNetworkUnits - LastNetworkUnits;
			LastNetworkUnits = TotalNetworkUnits;
			if (num > 0f)
			{
				Company receiverCompany = NetworkDeal.ReceiverCompany;
				double amount = num * NetworkDeal.PerUnit;
				NetworkPlayer sender = NetworkDeal.Sender;
				receiverCompany.MakeTransaction(amount, Company.TransactionCategory.Deals, (sender != null) ? sender.Name : null);
				Company senderCompany = NetworkDeal.SenderCompany;
				double amount2 = (0f - num) * NetworkDeal.PerUnit;
				NetworkPlayer receiver = NetworkDeal.Receiver;
				senderCompany.MakeTransaction(amount2, Company.TransactionCategory.Deals, (receiver != null) ? receiver.Name : null);
			}
		}
	}

	public bool HandleNetworkEnding(bool endOfDay)
	{
		NetworkDealState networkDealState = GetNetworkDealState();
		if (networkDealState == NetworkDealState.Receiver && ((NetworkDeal.EndDate.HasValue && SDateTime.Now() >= NetworkDeal.EndDate.Value) || (NetworkDeal.Limit != 0 && TotalNetworkUnits >= (float)NetworkDeal.Limit) || IsDoneForNetworkDeal()))
		{
			SendNetworkDealSync();
			HandleUnitPayout();
			bool flag = NetworkDeal.Limit == 0 || TotalNetworkUnits >= (float)NetworkDeal.Limit;
			if (NetworkDeal.Limit == 0)
			{
				flag &= !HasNaturalNetworkEnd || IsDoneForNetworkDeal();
			}
			NetworkMessaging.SendNetworkDealComplete(NetworkDeal.ID, GetNetworkCompletionData(true), flag, NetworkMessaging.MessageTarget.Specifically, NetworkDeal.SenderID);
			object[] array = new object[2];
			NetworkPlayer sender = NetworkDeal.Sender;
			array[0] = ((sender != null) ? sender.Name : null) ?? "Client".Loc();
			array[1] = Name;
			NotificationManager.AddNotification("NetworkDealComplete".Loc(array), "Server", NotificationManager.NotificationType.Good);
			Kill();
			return true;
		}
		if (endOfDay && networkDealState != NetworkDealState.None)
		{
			NetworkPlayer networkPlayer = ((networkDealState == NetworkDealState.Receiver) ? NetworkDeal.Sender : NetworkDeal.Receiver);
			if (networkPlayer == null || !networkPlayer.Connected)
			{
				if (networkDealState == NetworkDealState.Receiver)
				{
					NotificationManager.AddNotification("NetworkDealCancel".Loc(((networkPlayer != null) ? networkPlayer.Name : null) ?? "Client".Loc(), Name), "Server", NotificationManager.NotificationType.Neutral);
					Kill();
				}
				else
				{
					NotificationManager.AddNotification(new WorkItemNotification(this, "NetworkDealCancel".Loc(((networkPlayer != null) ? networkPlayer.Name : null) ?? "Client".Loc(), Name), "Server", NotificationManager.NotificationType.Neutral));
					NetworkCancel(false);
				}
			}
		}
		return false;
	}

	public void InitNetwork()
	{
		if (NetworkDeal == null)
		{
			return;
		}
		NetworkManager.Instance.TradeController.Trades[NetworkDeal.ID] = NetworkDeal;
		if (NetworkDeal.IsReceiver)
		{
			if (NetworkDeal.Sender == null || !NetworkDeal.Sender.Connected)
			{
				Kill();
			}
			else
			{
				NetworkMessaging.SendVerifyDeal(NetworkDeal.ID, true, NetworkMessaging.MessageTarget.Specifically, NetworkDeal.SenderID);
			}
		}
		else if (NetworkDeal.IsSender)
		{
			NetworkMessaging.SendVerifyDeal(NetworkDeal.ID, true, NetworkMessaging.MessageTarget.Specifically, NetworkDeal.ReceiverID);
		}
	}

	public void NetworkCancel(bool accept)
	{
		if (NetworkDeal == null || !NetworkDeal.IsSender)
		{
			return;
		}
		if (NetworkDeal.Receiver != null && NetworkDeal.Receiver.Connected)
		{
			WindowManager.Instance.ShowMessageBox("NetworkDealEndPrompt".Loc(NetworkDeal.Receiver.Name), true, DialogWindow.DialogType.Question, delegate
			{
				if (NetworkDeal != null)
				{
					NetworkMessaging.SendNetworkDealCancel(NetworkDeal.ID, accept, NetworkMessaging.MessageTarget.Specifically, NetworkDeal.ReceiverID);
				}
			}, "NetworkDealEndPrompt");
		}
		else
		{
			NetworkManager.Instance.TradeController.CancelTrade(NetworkDeal, false);
		}
	}

	public void UpdateDealSender()
	{
		if (GetNetworkDealState() == NetworkDealState.Receiver)
		{
			SendNetworkDealSync();
			NetworkMessaging.SendUpdateWorkItem(WorkItemID.ID, SerializeProgressData(), GetProgress(), NetworkMessaging.MessageTarget.Specifically, NetworkDeal.SenderID);
		}
	}

	public virtual byte[] SerializeProgressData()
	{
		return null;
	}

	public virtual void DeserializeProgressData(byte[] data)
	{
	}

	public void SendNetworkDealSync()
	{
		if (NetworkDeal != null)
		{
			byte[] array = SubSendNetworkDealSync();
			if (array != null)
			{
				NetworkMessaging.SendNetworkDealSync(NetworkDeal.ID, array, NetworkMessaging.MessageTarget.Specifically, NetworkDeal.SenderID);
			}
		}
	}

	public virtual byte[] SubSendNetworkDealSync()
	{
		return null;
	}

	public virtual void ReceiveNetworkDealSync(Stream st)
	{
	}

	public void AddDevTeam(Team team)
	{
		if (!Done && !(this is AutoDevWorkItem))
		{
			CompanyWorker = null;
			if (DevTeams.Add(team.Name))
			{
				team.AddWork(this);
				DevTeamChange();
			}
		}
	}

	public void AddDevTeams(IEnumerable<string> teams)
	{
		if (Done || this is AutoDevWorkItem)
		{
			return;
		}
		bool flag = false;
		foreach (string team2 in teams)
		{
			Team team = GameSettings.GetTeam(team2);
			if (team != null && DevTeams.Add(team2))
			{
				team.AddWork(this);
				flag = true;
			}
		}
		if (flag)
		{
			DevTeamChange();
			CompanyWorker = null;
		}
	}

	public void AddDevTeams(IList<string> teams)
	{
		if (Done || this is AutoDevWorkItem)
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < teams.Count; i++)
		{
			Team team = GameSettings.GetTeam(teams[i]);
			if (team != null && DevTeams.Add(team.Name))
			{
				team.AddWork(this);
				flag = true;
			}
		}
		if (flag)
		{
			DevTeamChange();
			CompanyWorker = null;
		}
	}

	public void SetDevTeams(IList<string> teams)
	{
		if (Done)
		{
			return;
		}
		bool flag = false;
		List<string> list = DevTeams.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			string text = list[i];
			if (!teams.Contains(text))
			{
				Team team = GameSettings.GetTeam(text);
				if (team != null)
				{
					team.RemoveWork(this);
				}
				DevTeams.Remove(text);
				flag = true;
			}
		}
		for (int j = 0; j < teams.Count; j++)
		{
			Team team2 = GameSettings.GetTeam(teams[j]);
			if (team2 != null && DevTeams.Add(team2.Name))
			{
				team2.AddWork(this);
				flag = true;
			}
		}
		if (flag)
		{
			DevTeamChange();
			if (DevTeams.Count > 0)
			{
				CompanyWorker = null;
			}
		}
	}

	public void RemoveDevTeam(Team team)
	{
		if (!(this is AutoDevWorkItem) && DevTeams.Remove(team.Name))
		{
			team.RemoveWork(this);
			DevTeamChange();
		}
	}

	public void SwitchDevTeam(Team team, Team newteam)
	{
		if (DevTeams.Contains(team.Name))
		{
			DevTeams.Remove(team.Name);
			team.RemoveWork(this);
			DevTeams.Add(newteam.Name);
			newteam.AddWork(this);
			DevTeamChange();
		}
	}

	public List<Team> GetDevTeams()
	{
		return DevTeams.SelectNotNull(GameSettings.GetTeam).ToList();
	}

	public void ClearTeams()
	{
		if (DevTeams.Count > 0)
		{
			List<Team> devTeams = GetDevTeams();
			for (int i = 0; i < devTeams.Count; i++)
			{
				devTeams[i].RemoveWork(this);
			}
			DevTeams.Clear();
			DevTeamChange();
		}
	}

	public virtual void Kill(bool wasCancelled = false)
	{
		if (wasCancelled && !_wasCancelled)
		{
			_wasCancelled = true;
			Cancelled();
		}
		if (Done)
		{
			return;
		}
		if (AutoDev)
		{
			foreach (AutoDevWorkItem item in GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>())
			{
				item.CleanupWork();
			}
		}
		if (WorkItemID != null)
		{
			NetworkManager.Instance.TradeController.CancelAllTradesFor(WorkItemID, NetworkDeal);
			if (NetworkDeal != null && NetworkManager.Instance.TradeController.Trades.ContainsKey(NetworkDeal.ID))
			{
				if (NetworkDeal.IsSender)
				{
					NetworkManager.Instance.TradeController.CancelTrade(NetworkDeal, false);
				}
				else
				{
					NetworkManager.Instance.TradeController.Trades.Remove(NetworkDeal.ID);
				}
			}
		}
		if (deal != 0)
		{
			HUD.Instance.dealWindow.CancelDeal(ActiveDeal);
		}
		lock (GameSettings.Instance.MyCompany.WorkItems)
		{
			GameSettings.Instance.MyCompany.WorkItems.Remove(this);
		}
		if (guiItem != null)
		{
			guiItem.Remove();
		}
		Done = true;
		ClearTeams();
	}

	public virtual float GetMax()
	{
		return 0f;
	}

	public virtual float GetWorkScore()
	{
		return 0f;
	}

	public void MakeWorkItem()
	{
		if (HUD.Instance != null)
		{
			if (guiItem == null)
			{
				guiItem = HUD.Instance.SpawnWorkItem(this, GUIWorkItemType());
			}
			guiItem.UpdateActivation();
		}
	}

	public virtual int GUIWorkItemType()
	{
		return 0;
	}

	protected virtual void Cancelled()
	{
	}

	public virtual HasWorkReturn HasWork(Actor actor, bool secondary, bool actualCheck)
	{
		return HasWorkReturn.True;
	}

	public static HasWorkReturn CombineWorkResult(HasWorkReturn a, HasWorkReturn b)
	{
		if (a == HasWorkReturn.True || b == HasWorkReturn.True)
		{
			return HasWorkReturn.True;
		}
		if (a == HasWorkReturn.Secondary || b == HasWorkReturn.Secondary)
		{
			return HasWorkReturn.Secondary;
		}
		if (a == HasWorkReturn.NotApplicable)
		{
			if (b != HasWorkReturn.NotApplicable)
			{
				return b;
			}
			return HasWorkReturn.NotApplicable;
		}
		return a;
	}

	public virtual string GetIcon()
	{
		return "Cogs";
	}

	public abstract string GetWorkTypeName();

	public virtual string GetIdentifyingTypeName()
	{
		return GetWorkTypeName();
	}

	public virtual string GetDetailedTypeName()
	{
		return GetWorkTypeName().Loc();
	}

	public virtual string GetWorkTypeFilter()
	{
		return GetWorkTypeName();
	}

	public WorkItem(string name, ContractWork Contract, uint networkID, NetworkDeal networkDeal, int siblingIndex = -1)
	{
		_name = name;
		if (!GameSettings.Instance.IsReferenceNull())
		{
			ID = GameSettings.Instance.GetWorkItemID();
		}
		WorkItemID = ((networkID != 0) ? new NetworkDeal.NetworkWorkItemID(networkID) : null);
		Priority = GameSettings.DefaultPriority;
		contract = Contract;
		SiblingIndex = siblingIndex;
		NetworkDeal = networkDeal;
		MakeWorkItem();
	}

	public WorkItem()
	{
	}

	public float GetActualProgress()
	{
		if (GetNetworkDealState() != NetworkDealState.Sender)
		{
			return GetProgress();
		}
		return NetworkProgress;
	}

	public virtual float GetProgress()
	{
		return 0f;
	}

	public string GetActualProgressLabel()
	{
		if (AlwaysUseLocalProgressLabel || GetNetworkDealState() != NetworkDealState.Sender)
		{
			return GetProgressLabel();
		}
		return NetworkProgressLabel;
	}

	public virtual string GetProgressLabel()
	{
		return "";
	}

	public string GetCategory()
	{
		if (AlwaysUseLocalCategory || GetNetworkDealState() != NetworkDealState.Sender)
		{
			return Category();
		}
		return NetworkCategory;
	}

	public virtual string Category()
	{
		return "N/A";
	}

	public string GetCurrentStage()
	{
		if (AlwaysUseLocalStageLabel || GetNetworkDealState() != NetworkDealState.Sender)
		{
			return CurrentStage();
		}
		return NetworkStage;
	}

	public virtual string CurrentStage()
	{
		return "N/A";
	}

	public virtual string GetTeam(Text label = null)
	{
		if (GetNetworkDealState() == NetworkDealState.Sender)
		{
			NetworkPlayer receiver = NetworkDeal.Receiver;
			return ((receiver != null) ? receiver.Name : null) ?? "";
		}
		if (CompanyWorker != null)
		{
			return CompanyWorker.Name;
		}
		if (deal != 0 && !ActiveDeal.Incoming)
		{
			return ActiveDeal.Company.Name;
		}
		if (label != null && DevTeams.Count > 1)
		{
			float width = label.rectTransform.rect.width;
			int num = 0;
			int lineWidth = label.GetLineWidth(", ");
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			int num2 = 1;
			foreach (string devTeam in DevTeams)
			{
				if (flag)
				{
					num += label.GetLineWidth(devTeam);
					stringBuilder.Append(devTeam);
					flag = false;
					continue;
				}
				num += lineWidth + label.GetLineWidth(devTeam);
				if ((float)num <= width)
				{
					stringBuilder.Append(", ");
					stringBuilder.Append(devTeam);
					num2++;
				}
			}
			if (num2 < DevTeams.Count)
			{
				stringBuilder.Append("+");
				stringBuilder.Append(DevTeams.Count - num2);
			}
			return stringBuilder.ToString();
		}
		if (DevTeams.Count > 1)
		{
			return DevTeams.First() + "+" + (DevTeams.Count - 1);
		}
		if (DevTeams.Count > 0)
		{
			return DevTeams.First();
		}
		return null;
	}

	public static Color GetDefaultProgressColor()
	{
		if (Options.ColorBlindness == -1)
		{
			return Options.GetCustomColor(21);
		}
		switch (Options.ColorBlindness)
		{
		case 1:
			return new Color32(171, 160, 55, byte.MaxValue);
		case 2:
			return new Color32(185, 170, 53, byte.MaxValue);
		case 3:
			return new Color32(97, 210, 250, byte.MaxValue);
		default:
			return new Color32(157, 214, 133, 173);
		}
	}

	public virtual Color GetProgressColor()
	{
		return GetDefaultProgressColor();
	}

	public override string ToString()
	{
		return Name;
	}

	public void WriteData(Stream st)
	{
		st.WriteByte(ByteTypeID);
		NetworkDeal.NetworkWorkItemID workItemID = WorkItemID;
		st.WriteUInt((workItemID != null) ? workItemID.ID : 0u);
		NetworkDeal networkDeal = NetworkDeal;
		st.WriteUInt((networkDeal != null) ? networkDeal.ID : 0u);
		WriteSubData(st);
	}

	public virtual void WriteSubData(Stream st)
	{
	}

	public static WorkItem ReadData(Stream st)
	{
		int num = st.ReadByte();
		uint num2 = st.ReadUInt();
		NetworkDeal deal = NetworkManager.Instance.TradeController.Trades.GetOrNull(st.ReadUInt()) as NetworkDeal;
		WorkItem workItem = null;
		switch (num)
		{
		case 1:
		{
			SupportWork obj2 = new SupportWork(MarketSimulation.Active.GetProduct(st.ReadUInt(), false, false, true), -1, num2, deal)
			{
				TargetProduct = 
				{
					VerifiedBugs = st.ReadInt()
				}
			};
			workItem = obj2;
			obj2.Tickets.AddRange(st.ReadArray(SDateTime.ReadData));
			break;
		}
		case 2:
		{
			if (st.ReadBool())
			{
				SoftwareFramework framework2 = MarketSimulation.Active.GetFramework(st.ReadUInt());
				TechLevel[] array = st.ReadArray((Stream ss) => MarketSimulation.Active.GetTechLevel(ss.ReadStringUTF8(), ss.ReadInt()));
				SoftwareUpdate softwareUpdate = new SoftwareUpdate(framework2, (array != null) ? array.ToDictionary((TechLevel x) => x.Spec, (TechLevel x) => x) : null, null, -1, num2, deal);
				softwareUpdate.LoadProgressData(st);
				workItem = softwareUpdate;
				break;
			}
			SoftwareProduct target = MarketSimulation.Active.GetProduct(st.ReadUInt(), false, false, true);
			int verifiedBugs = st.ReadInt();
			if (GameSettings.Instance.MyCompany.WorkItems.OfType<SupportWork>().None((SupportWork x) => x.TargetProduct == target))
			{
				target.VerifiedBugs = verifiedBugs;
			}
			bool fixBugs = st.ReadBool();
			float addedBugs = st.ReadFloat();
			float fixedBugs = st.ReadFloat();
			TechLevel[] array2 = st.ReadArray((Stream ss) => MarketSimulation.Active.GetTechLevel(ss.ReadStringUTF8(), ss.ReadInt()));
			Dictionary<string, SoftwareProduct> needs2 = st.ReadDictionary((Stream ss) => ss.ReadStringUTF8(), (Stream ss) => MarketSimulation.Active.GetProduct(ss.ReadUInt(), false));
			SoftwareUpdate softwareUpdate2 = new SoftwareUpdate(target, fixBugs, (array2 != null) ? array2.ToDictionary((TechLevel x) => x.Spec, (TechLevel x) => x) : null, needs2, null, -1, num2, deal);
			softwareUpdate2.FixedBugs = fixedBugs;
			softwareUpdate2.AddedBugs = addedBugs;
			softwareUpdate2.LoadProgressData(st);
			workItem = softwareUpdate2;
			break;
		}
		case 3:
		{
			SoftwareProduct product2 = MarketSimulation.Active.GetProduct(st.ReadUInt(), false);
			SoftwareProduct[] os = st.ReadArray((Stream ss) => MarketSimulation.Active.GetProduct(ss.ReadUInt(), false));
			SoftwarePort softwarePort = new SoftwarePort(product2, os, num2, deal);
			softwarePort.LoadCompletionData(st, false);
			workItem = softwarePort;
			break;
		}
		case 4:
			switch ((MarketingPlan.TaskType)st.ReadByte())
			{
			case MarketingPlan.TaskType.PostMarket:
			{
				IMarketable targetProduct;
				switch (st.ReadByte())
				{
				case 0:
					targetProduct = MarketSimulation.Active.GetProduct(st.ReadUInt(), false);
					break;
				case 1:
					targetProduct = MarketSimulation.Active.GetProduct(st.ReadUInt(), false).GetAddon(st.ReadUInt());
					break;
				default:
					throw new ArgumentOutOfRangeException("Marketing target type");
				}
				float num3 = st.ReadFloat();
				float lastProgress = st.ReadFloat();
				float budget = st.ReadFloat();
				float spent = st.ReadFloat();
				float lastSpent = st.ReadFloat();
				MarketingPlan marketingPlan = new MarketingPlan(budget, targetProduct, num2, deal);
				marketingPlan.Progress[0] = num3;
				marketingPlan.LastProgress = lastProgress;
				marketingPlan.Spent = spent;
				marketingPlan.LastSpent = lastSpent;
				workItem = marketingPlan;
				break;
			}
			case MarketingPlan.TaskType.PressRelease:
			{
				string fakeTarget = st.ReadStringUTF8();
				MarketingPlan.PressOption options = (MarketingPlan.PressOption)st.ReadByte();
				workItem = new MarketingPlan(fakeTarget, options, num2, deal)
				{
					Progress = st.ReadArray((Stream s) => s.ReadFloat())
				};
				break;
			}
			default:
				throw new ArgumentOutOfRangeException("Marketing type");
			}
			break;
		case 5:
			workItem = new LegalWork((LegalWork.WorkType)st.ReadByte(), MarketSimulation.Active.GetCompany(st.ReadUInt()), MarketSimulation.Active.GetTechLevel(st.ReadStringUTF8(), st.ReadInt()), st.ReadStringUTF8(), st.ReadDouble(), st.ReadFloat(), st.ReadInt(), st.ReadInt(), SDateTime.ReadData(st), SDateTime.ReadData(st), st.ReadFloat(), st.ReadBool(), num2, deal);
			break;
		case 6:
		{
			string name2 = st.ReadStringUTF8();
			SoftwareType sw2 = MarketSimulation.Active.GetSoftwareType(st.ReadUInt());
			SoftwareCategory category = sw2.GetCategory(st.ReadUInt());
			SoftwareAddOn addon2 = sw2.GetAddon(st.ReadUInt());
			SoftwareProduct product3 = MarketSimulation.Active.GetProduct(st.ReadUInt(), false);
			Dictionary<string, SoftwareProduct> needs3 = st.ReadDictionary((Stream s) => s.ReadStringUTF8(), (Stream s) => MarketSimulation.Active.GetProduct(s.ReadUInt(), false));
			SoftwareProduct[] os2 = st.ReadArray((Stream s) => MarketSimulation.Active.GetProduct(s.ReadUInt(), false));
			float price2 = st.ReadFloat();
			bool subscription2 = st.ReadBool();
			double[] submarkets2 = st.ReadArray((Stream s) => s.ReadDouble());
			SDateTime start2 = SDateTime.ReadData(st);
			SoftwareProduct product4 = MarketSimulation.Active.GetProduct(st.ReadUInt(), false, false, true);
			bool inHouse2 = st.ReadBool();
			double loss2 = st.ReadDouble();
			ValueTuple<FeatureBase, uint>[] arr = st.ReadArray((Stream s) => new ValueTuple<FeatureBase, uint>((addon2 != null) ? addon2.GetFeature(s.ReadUInt()) : sw2.GetFeature(s.ReadUInt()), s.ReadUInt()));
			TechLevel[] source = st.ReadArray((Stream s) => MarketSimulation.Active.GetTechLevel(st.ReadStringUTF8(), st.ReadInt()));
			SoftwareFramework framework3 = MarketSimulation.Active.GetFramework(st.ReadUInt());
			string createFramework = st.ReadStringUTF8();
			List<SoftwareProduct> tools2 = st.ReadList((Stream s) => MarketSimulation.Active.GetProduct(s.ReadUInt(), false));
			workItem = ((addon2 == null) ? new DesignDocument(name2, sw2, category, needs3, os2, price2, subscription2, submarkets2, start2, deal.SenderCompany, product4, inHouse2, loss2, arr.SelectInPlaceList((ValueTuple<FeatureBase, uint> x) => x.Item1), source.ToDictionary((TechLevel x) => x.Spec, (TechLevel x) => x), null, null, null, framework3, createFramework, tools2, true, num2, deal) : new DesignDocument(name2, addon2, category, needs3, price2, start2, deal.SenderCompany, product3, null, loss2, arr.SelectInPlaceList((ValueTuple<FeatureBase, uint> x) => x.Item1), arr.SelectInPlace((ValueTuple<FeatureBase, uint> x) => x.Item2), null, tools2, true, num2, deal));
			((DesignDocument)workItem).ReadProgress(st);
			break;
		}
		case 7:
		{
			string name = st.ReadStringUTF8();
			bool inBeta = st.ReadBool();
			SoftwareType sw = MarketSimulation.Active.GetSoftwareType(st.ReadUInt());
			SoftwareCategory cat = sw.GetCategory(st.ReadUInt());
			SoftwareAddOn addon = sw.GetAddon(st.ReadUInt());
			SoftwareProduct product = MarketSimulation.Active.GetProduct(st.ReadUInt(), false);
			Dictionary<string, SoftwareProduct> needs = st.ReadDictionary((Stream s) => s.ReadStringUTF8(), (Stream s) => MarketSimulation.Active.GetProduct(s.ReadUInt(), false));
			SoftwareProduct[] oss = st.ReadArray((Stream s) => MarketSimulation.Active.GetProduct(s.ReadUInt(), false));
			float price = st.ReadFloat();
			bool subscription = st.ReadBool();
			double[] submarkets = st.ReadArray((Stream s) => s.ReadDouble());
			SDateTime start = SDateTime.ReadData(st);
			SoftwareProduct sequelTo = MarketSimulation.Active.GetProduct(st.ReadUInt(), false, false, true);
			bool inHouse = st.ReadBool();
			double loss = st.ReadDouble();
			Dictionary<string, TechLevel> techs = st.ReadArray((Stream s) => MarketSimulation.Active.GetTechLevel(st.ReadStringUTF8(), st.ReadInt())).ToDictionary((TechLevel x) => x.Spec, (TechLevel x) => x);
			SoftwareFramework framework = MarketSimulation.Active.GetFramework(st.ReadUInt());
			string newFrame = st.ReadStringUTF8();
			SoftwareWorkItem.FeatureProgress[] feat = st.ReadArray(delegate(Stream s)
			{
				SoftwareType type = sw;
				SoftwareCategory cat2 = cat;
				SoftwareAddOn add = addon;
				Company senderCompany = deal.SenderCompany;
				Dictionary<string, TechLevel> techs2 = techs;
				SoftwareProduct sequelTo2 = sequelTo;
				bool newFramework = newFrame != null;
				SoftwareFramework framework4 = framework;
				uint id = s.ReadUInt();
				uint factor = s.ReadUInt();
				SoftwareProduct[] array3 = oss;
				return GetFeatFromData(type, cat2, add, senderCompany, techs2, sequelTo2, newFramework, framework4, id, factor, (array3 != null) ? array3.Length : 0, s.ReadDouble(), s.ReadDouble());
			});
			List<SoftwareProduct> tools = st.ReadList((Stream s) => MarketSimulation.Active.GetProduct(s.ReadUInt(), false));
			double creativityScore = st.ReadDouble();
			int maxBugs = st.ReadInt();
			float bugRate = st.ReadFloat();
			float bugs = st.ReadFloat();
			workItem = ((addon == null) ? new SoftwareAlpha(name, null, sw, cat, needs, feat, techs, oss, price, subscription, submarkets, start, bugs, deal.SenderCompany, sequelTo, inHouse, loss, null, null, null, -1, new SHashSet<uint>(), 0f, 0u, 0f, null, maxBugs, bugRate, framework, 0f, newFrame, new List<string>(), tools, creativityScore, false, null, num2, deal) : new SoftwareAlpha(name, null, addon, cat, needs, feat, price, start, bugs, deal.SenderCompany, product, null, loss, null, -1, new SHashSet<uint>(), 0f, 0u, 0f, null, maxBugs, bugRate, new List<string>(), tools, creativityScore, false, null, num2, deal));
			SoftwareAlpha obj = (SoftwareAlpha)workItem;
			obj.InBeta = inBeta;
			obj.ReadProgress(st, true);
			break;
		}
		}
		return workItem;
	}

	public static SoftwareWorkItem.FeatureProgress GetFeatFromData(SoftwareType type, SoftwareCategory cat, SoftwareAddOn add, Company c, Dictionary<string, TechLevel> techs, SoftwareProduct sequelTo, bool newFramework, SoftwareFramework framework, uint id, uint factor, int OSs, double artTarget, double codeTarget)
	{
		SoftwareWorkItem.FeatureProgress featureProgress = ((id != 0) ? new SoftwareWorkItem.FeatureProgress((add != null) ? add.GetFeature(id) : type.GetFeature(id), cat, c, techs, sequelTo, newFramework, framework, factor) : new SoftwareWorkItem.FeatureProgress(type, OSs));
		featureProgress.ArtTargetQual = artTarget;
		featureProgress.CodeTargetQual = codeTarget;
		return featureProgress;
	}

	public virtual bool IsDoneForNetworkDeal()
	{
		return false;
	}

	public void NetworkComplete()
	{
		SendNetworkDealSync();
		NetworkMessaging.SendNetworkDealComplete(NetworkDeal.ID, GetNetworkCompletionData(true), false, NetworkMessaging.MessageTarget.Specifically, NetworkDeal.SenderID);
		Kill();
	}

	public virtual IReferenceFix FixReferences()
	{
		NetworkDeal networkDeal = NetworkDeal;
		NetworkDeal = ((networkDeal != null) ? networkDeal.FixReferences() : null) as NetworkDeal;
		if (_companyWorker != null)
		{
			_companyWorker = MarketSimulation.Active.GetCompany(_companyWorker.ID) as SimulatedCompany;
		}
		ContractWork contractWork = contract;
		if (contractWork != null)
		{
			contractWork.FixReferences();
		}
		return this;
	}

	public virtual void AddLoss(float cost, SoftwareProduct.LossType type, bool immediate, bool fromNetwork = false)
	{
		lock (this)
		{
			if (LossBreakdown == null || LossBreakdown.Length != 15)
			{
				LossBreakdown = LossBreakdown.Resize(15);
			}
			LossBreakdown[(int)type] += cost;
		}
	}

	public virtual void AddLoss(float cost, bool fromNetwork = false)
	{
		AddLoss(cost, SoftwareProduct.LossType.Development, false, fromNetwork);
	}

	public virtual void AddLicenseCost(SoftwareProduct tool, float cost, bool fromNetwork = false)
	{
	}

	public virtual float GetLicenseAmount()
	{
		return 0f;
	}

	public virtual string GetActualString()
	{
		return Name;
	}

	public int GetEmployeeCount()
	{
		int num = 0;
		foreach (string devTeam in DevTeams)
		{
			int count = GameSettings.Instance.sActorManager.Teams[devTeam].Count;
			num += count;
		}
		return num;
	}

	public abstract float StressMultiplier();

	public virtual void InitWorkItem(GUIWorkItem gWork)
	{
	}

	public virtual string CollapseLabel()
	{
		return Category();
	}

	public abstract void DoWork(Actor actor, float effectiveness, float delta, bool secondary);

	public virtual float GetWorkBoost(Employee.EmployeeRole role, float currentSkill)
	{
		return 1f + Mathf.Max(0f, WorkerSkill[(int)role] - currentSkill);
	}

	public abstract Employee.EmployeeRole? GetBoostRole(Actor act, bool secondary);

	public virtual string HightlightButton()
	{
		return null;
	}

	public abstract Actor.WorkParticle EmitType(Actor actor, bool secondary);

	public virtual bool CanUseCompany()
	{
		return false;
	}

	public virtual bool HasCompanyWork()
	{
		return false;
	}

	public virtual float CompanyWork(float delta)
	{
		return 0f;
	}

	public virtual Color? GetLastPhaseProgress()
	{
		return null;
	}

	public void Assign(string saveCat = null, Action a = null)
	{
		if (CanUseCompany())
		{
			HUD.Instance.TeamSelectWindow.Show(DevTeams, CompanyWorker, delegate(string[] t, SimulatedCompany c)
			{
				if (c != null)
				{
					CompanyWorker = c;
				}
				else
				{
					SetDevTeams(t);
				}
				Action action = a;
				if (action != null)
				{
					action();
				}
			}, GetWorkTypeName(), saveCat, GetTypeName(), GetCanOutsourceNetwork() ? this : null);
			return;
		}
		HUD.Instance.TeamSelectWindow.Show(false, DevTeams, delegate(string[] t)
		{
			SetDevTeams(t);
			Action action = a;
			if (action != null)
			{
				action();
			}
		}, GetWorkTypeName(), saveCat, GetTypeName(), GetCanOutsourceNetwork() ? this : null);
	}

	public virtual string ProgressTip()
	{
		return "";
	}

	public virtual string GetTutorial()
	{
		return null;
	}

	public virtual bool IsLeaderTask()
	{
		return false;
	}

	protected void RunScripts<T>(IList<T> features, bool ended, bool cancelled, Func<T, FeatureBase> getFeature = null)
	{
		if (GetNetworkDealState() == NetworkDealState.Receiver || (ended && Done))
		{
			return;
		}
		ScriptSystem.DevScope tempScope = ScriptSystem.DevScope.GetTempScope(this, ended, cancelled);
		for (int i = 0; i < features.Count; i++)
		{
			SubFeature subFeature = ((getFeature == null) ? (features[i] as SubFeature) : (getFeature(features[i]) as SubFeature));
			if (subFeature != null && subFeature.Level == 3)
			{
				subFeature.RunScript(ScriptSystem.EntryPoint.WorkItemChange, tempScope, null);
			}
		}
	}

	public abstract IEnumerable<KeyValuePair<string, Action>> GetButtons();

	public abstract void GetNeeds(Dictionary<HRManagement.EdNeed, int>[] needs);

	public abstract string GetTypeName();

	public abstract string GetGroupType();

	public abstract string GetGroupProject();

	public virtual string GetGroupTypeLabel()
	{
		return GetGroupProject();
	}

	public virtual string GetGroupProjectLabel()
	{
		return GetGroupType().Loc();
	}

	public virtual bool HasProjectGrouping()
	{
		return true;
	}
}
