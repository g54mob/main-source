using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[AltDeprecate("DevActions", typeof(float))]
[AltDeprecate("DesignActions", typeof(float))]
[AltDeprecate("MarketingActions", typeof(float))]
public class AutoDevWorkItem : WorkItem
{
	[Serializable]
	public class AutoDevItem
	{
		public SoftwareAlpha Alpha;

		public DesignDocument Document;

		public MarketingPlan Hype;

		public List<SoftwareWorkItem> Addons = new List<SoftwareWorkItem>();

		public bool PressRelease;

		public bool PressBuild;

		public bool Queued = true;

		public bool Secondary;

		public bool hasPrinted;

		public SDateTime ActualStartDate;

		public float AlreadyDev;

		public float MonthsToSpend;

		public SoftwareWorkItem SWWorkItem
		{
			get
			{
				return (SoftwareWorkItem)(((object)Document) ?? ((object)Alpha));
			}
		}

		public SDateTime? ReleaseDate
		{
			get
			{
				if (Alpha != null)
				{
					return Alpha.ReleaseDate;
				}
				return Document.ReleaseDate;
			}
		}

		public string ReleaseDateText
		{
			get
			{
				SDateTime? releaseDate = ReleaseDate;
				if (releaseDate.HasValue)
				{
					return releaseDate.Value.ToCompactString();
				}
				if (Queued)
				{
					return "None".Loc();
				}
				return (ActualStartDate + (MonthsToSpend - AlreadyDev)).ToCompactString();
			}
		}

		public int ReleaseDateInt
		{
			get
			{
				SDateTime? releaseDate = ReleaseDate;
				if (releaseDate.HasValue)
				{
					return releaseDate.Value.ToInt();
				}
				if (Queued)
				{
					return -1;
				}
				return (ActualStartDate + (MonthsToSpend - AlreadyDev)).ToInt();
			}
		}

		public bool InHouse
		{
			get
			{
				if (Alpha != null)
				{
					return Alpha.InHouse;
				}
				return Document.InHouse;
			}
		}

		public SDateTime StartDate
		{
			get
			{
				if (Alpha != null)
				{
					return Alpha.DevStart;
				}
				return Document.DevStart;
			}
		}

		public string Name
		{
			get
			{
				if (Alpha != null)
				{
					return Alpha.SoftwareName;
				}
				return Document.SoftwareName;
			}
		}

		public bool Design
		{
			get
			{
				if (Alpha != null)
				{
					return false;
				}
				return true;
			}
		}

		public SDateTime GetCutDate(float progress)
		{
			return ActualStartDate + (MonthsToSpend * progress - AlreadyDev);
		}

		public SDateTime GetNextCut()
		{
			if (!Queued && (Alpha == null || !Alpha.InBeta))
			{
				if (Document == null)
				{
					return GetCutDate(SoftwareType.DesignRatio + 0.75f * (1f - SoftwareType.DesignRatio));
				}
				return GetCutDate(SoftwareType.DesignRatio);
			}
			return default(SDateTime);
		}

		public string GetNextCutDesc()
		{
			if (!Queued && (Alpha == null || !Alpha.InBeta))
			{
				return ((Document != null) ? GetCutDate(SoftwareType.DesignRatio) : GetCutDate(SoftwareType.DesignRatio + 0.75f * (1f - SoftwareType.DesignRatio))).ToCompactString();
			}
			return "NotApplicableAbbr".Loc();
		}

		public AutoDevItem()
		{
		}

		public string Phase()
		{
			if (Alpha != null)
			{
				if (!Alpha.InBeta)
				{
					return "Alpha";
				}
				return "Beta";
			}
			return "Design";
		}

		public int PhaseOrder()
		{
			if (Alpha != null)
			{
				if (!Alpha.InBeta)
				{
					return 1;
				}
				return 2;
			}
			return 0;
		}

		public AutoDevItem(SoftwareWorkItem work, List<SoftwareWorkItem> addons, AutoDevWorkItem self)
		{
			if (work is SoftwareAlpha)
			{
				Alpha = (SoftwareAlpha)work;
			}
			else
			{
				Document = (DesignDocument)work;
			}
			Addons = addons ?? Addons;
			int[] optimalEmployeeCount = SoftwareType.GetOptimalEmployeeCount(SWWorkItem.DevTime);
			MonthsToSpend = GameData.ProjectDevTime(optimalEmployeeCount[0], optimalEmployeeCount[1], SWWorkItem.DevTime, SWWorkItem.CodeArtRatio) * self.DevTimeMultiplier;
		}

		public SDateTime ReleaseBy()
		{
			SoftwareWorkItem softwareWorkItem = (SoftwareWorkItem)(((object)Alpha) ?? ((object)Document));
			if (softwareWorkItem.ReleaseDate.HasValue)
			{
				return softwareWorkItem.ReleaseDate.Value;
			}
			return softwareWorkItem.DevStart + softwareWorkItem.DevTime;
		}

		public void Release()
		{
			SoftwareWorkItem sWWorkItem = SWWorkItem;
			AutoDevWorkItem autoDevWorkItem = GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>().FirstOrDefault((AutoDevWorkItem x) => x.Items.Contains(this));
			if (autoDevWorkItem != null)
			{
				autoDevWorkItem.Items.Remove(this);
				autoDevWorkItem.NextReleaseDate = autoDevWorkItem.GetNextReleaseDate(this);
				if (sWWorkItem.SoftwareName.Equals(autoDevWorkItem.LastDesign))
				{
					autoDevWorkItem.LastDesign = null;
				}
				if (sWWorkItem.SoftwareName.Equals(autoDevWorkItem.LastAlpha))
				{
					autoDevWorkItem.LastAlpha = null;
				}
				if (sWWorkItem.SoftwareName.Equals(autoDevWorkItem.LastAlpha2))
				{
					autoDevWorkItem.LastAlpha2 = null;
				}
			}
			sWWorkItem.AutoDev = false;
			sWWorkItem.Hidden = false;
			RevealMarketing(sWWorkItem);
			foreach (SoftwareWorkItem addonWorkChild in sWWorkItem.AddonWorkChildren)
			{
				addonWorkChild.Hidden = false;
				addonWorkChild.AutoDev = false;
				RevealMarketing(addonWorkChild);
			}
		}

		private void RevealMarketing(SoftwareWorkItem item)
		{
			foreach (MarketingPlan item2 in GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>())
			{
				if (item2.TargetItem == item)
				{
					item2.Hidden = false;
					item2.AutoDev = false;
				}
			}
		}

		public void Cancel()
		{
			SWWorkItem.Kill(true);
		}

		public void ChangeLead()
		{
			if (Design && !Queued)
			{
				Document.SelectLeadDesigner();
			}
		}
	}

	public float LastLicensePaid;

	public string LastDesign;

	public string LastAlpha;

	public string LastAlpha2;

	public const float MaxEffectiveness = 3f;

	public float LastEffectiveness = 3f;

	public float LastEffLoss;

	public float LastEffGain;

	public SDateTime LastEffGainTime;

	private SDateTime? NextReleaseDate;

	public List<SupportWork> SupportItems = new List<SupportWork>();

	public List<MarketingPlan> MarketingItems = new List<MarketingPlan>();

	public List<SoftwarePort> PortingItems = new List<SoftwarePort>();

	public List<SoftwareProduct> PastReleases = new List<SoftwareProduct>();

	public List<SoftwareProduct> PreviousSoftware = new List<SoftwareProduct>();

	public Dictionary<SoftwareUpdate, SDateTime> UpdateTasks = new Dictionary<SoftwareUpdate, SDateTime>();

	public string MainServer;

	public string SCMServer;

	public SHashSet<string> DesignTeams = new SHashSet<string>();

	public SHashSet<string> SDevTeams = new SHashSet<string>();

	public SHashSet<string> SecondaryDevTeams = new SHashSet<string>();

	public SHashSet<string> MarketingTeams = new SHashSet<string>();

	public SHashSet<string> PostMarketingTeams = new SHashSet<string>();

	public SHashSet<string> SupportTeams = new SHashSet<string>();

	public SHashSet<string> UpdateTeams = new SHashSet<string>();

	public SHashSet<string> PortingTeams = new SHashSet<string>();

	public bool Hype = true;

	public bool AutoProject;

	public bool OnlySequels;

	public bool PostMarketing;

	public bool HandleMarketing;

	public bool SingleIP;

	public bool UseOwnLicenses;

	public bool AutoSupport = true;

	public bool PhysicalCopyRel;

	public bool PrintingCopyRel;

	public bool UseFrameworks;

	public bool Updates;

	public bool TechUpdates;

	public bool AutoDistribution;

	public bool Porting;

	public float DevTimeMultiplier = 1f;

	public uint PhysicalCopies;

	public uint PrintingCopies;

	public int IterationCoolDown;

	public int UpdateCooldown = 3;

	public int UpdateMonths = 12;

	public int ReleaseCooldown;

	[NonSerialized]
	public Employee LastDesignError;

	private uint _lastLeader;

	public EventList<AutoDevItem> Items = new EventList<AutoDevItem>();

	public List<string> Mistakes = new List<string>();

	[NonSerialized]
	private Actor _leader;

	[NonSerialized]
	public bool IsViewed;

	public uint LeaderID;

	public static int[] MaxActionCounts = new int[4] { 0, 3, 6, 10 };

	private static HashSet<string> _pCache = new HashSet<string>();

	public Actor Leader
	{
		get
		{
			return _leader;
		}
		set
		{
			if (value == null && _leader == null)
			{
				return;
			}
			if (value != null && value.DID == LeaderID)
			{
				_leader = value;
				if (!_leader.AutoDevs.Contains(this))
				{
					_leader.AutoDevs.Add(this);
				}
				return;
			}
			if (_leader != null)
			{
				_leader.AutoDevs.Remove(this);
				_lastLeader = _leader.DID;
			}
			LeaderID = ((!(value == null)) ? value.DID : 0u);
			_leader = value;
			UpdateSpecLevels();
			if (_leader != null && !_leader.AutoDevs.Contains(this))
			{
				_leader.AutoDevs.Add(this);
			}
		}
	}

	public override Color BackColor
	{
		get
		{
			return new Color(0f, 0.75f, 0.75f);
		}
	}

	public override IReferenceFix FixReferences()
	{
		PastReleases.FixMyReferences(true);
		PreviousSoftware.FixMyReferences(true);
		return base.FixReferences();
	}

	public void RefreshNextReleaseDate()
	{
		NextReleaseDate = GetNextReleaseDate(null);
	}

	public T GetSpecValue<T>(T value, int minSpec, T def = default(T))
	{
		if (Leader != null)
		{
			if (Leader.employee.GetSpecialization(Employee.EmployeeRole.Lead, "Automation") < minSpec)
			{
				return def;
			}
			return value;
		}
		return def;
	}

	public void UpdatePostItems()
	{
		bool flag = false;
		for (int i = 0; i < MarketingItems.Count; i++)
		{
			if (MarketingItems[i].Done)
			{
				MarketingItems.RemoveAt(i);
				flag = true;
				i--;
			}
		}
		for (int j = 0; j < SupportItems.Count; j++)
		{
			if (SupportItems[j].Done)
			{
				SupportItems.RemoveAt(j);
				flag = true;
				j--;
			}
		}
		for (int k = 0; k < PortingItems.Count; k++)
		{
			if (PortingItems[k].Done)
			{
				PortingItems.RemoveAt(k);
				flag = true;
				k--;
			}
		}
		if (UpdateTasks.Count > 0)
		{
			foreach (SoftwareUpdate item in UpdateTasks.Keys.ToList())
			{
				if (item.Done)
				{
					UpdateTasks.Remove(item);
					flag = true;
				}
			}
		}
		if (flag)
		{
			UpdateLists();
		}
	}

	public void LogMistake(string loc, string projectName, string amountLabel)
	{
		string input = ((Leader != null) ? Leader.employee.FullName : "NotApplicableAbbr".Loc());
		Mistakes.Add(SDateTime.Now().ToVeryCompactString().FontBold() + ": " + ("PM" + loc + "Mistake").Loc(input.FontColor(new Color(0f, 0.5f, 0f)), projectName.FontColor(new Color(0f, 0f, 0.5f)), amountLabel.FontColor(new Color(0.5f, 0f, 0f))));
		if (Mistakes.Count > 5)
		{
			Mistakes.RemoveAt(0);
		}
	}

	public void AddPreviousSoftware(SoftwareProduct p)
	{
		if (PreviousSoftware.Contains(p))
		{
			return;
		}
		PreviousSoftware.Add(p);
		if (GetSpecValue(PostMarketing, 3, false) && HandleMarketing)
		{
			MarketingPlan marketingPlan = GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>().FirstOrDefault((MarketingPlan x) => x.TargetProduct == p);
			if (marketingPlan != null)
			{
				marketingPlan.AutoDev = true;
				marketingPlan.Hidden = true;
				AssignTeams(marketingPlan, MarketingTeams);
				if (!MarketingItems.Contains(marketingPlan))
				{
					MarketingItems.Add(marketingPlan);
				}
			}
		}
		if (GetSpecValue(AutoSupport, 3, false))
		{
			SupportWork supportWork = GameSettings.Instance.MyCompany.WorkItems.OfType<SupportWork>().FirstOrDefault((SupportWork x) => x.TargetProduct == p);
			if (supportWork != null)
			{
				supportWork.AutoDev = true;
				supportWork.Hidden = true;
				AssignTeams(supportWork, SupportTeams);
				if (!SupportItems.Contains(supportWork))
				{
					SupportItems.Add(supportWork);
				}
			}
		}
		if (GetSpecValue(Updates, 3, false))
		{
			SoftwareUpdate softwareUpdate = GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareUpdate>().FirstOrDefault((SoftwareUpdate x) => x.Target == p);
			if (softwareUpdate != null)
			{
				softwareUpdate.AutoDev = true;
				softwareUpdate.Hidden = true;
				AssignTeams(softwareUpdate, UpdateTeams);
				UpdateTasks[softwareUpdate] = SDateTime.Now();
			}
		}
		if (GetSpecValue(Porting, 3, false))
		{
			SoftwarePort softwarePort = GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwarePort>().FirstOrDefault((SoftwarePort x) => x.Product == p);
			if (softwarePort != null)
			{
				softwarePort.AutoDev = true;
				softwarePort.Hidden = true;
				AssignTeams(softwarePort, PortingTeams);
				PortingItems.Add(softwarePort);
			}
		}
		UpdateLists();
	}

	public void CleanupWork()
	{
		MarketingItems.RemoveAll((MarketingPlan x) => x.Done);
		SupportItems.RemoveAll((SupportWork x) => x.Done);
		PortingItems.RemoveAll((SoftwarePort x) => x.Done);
	}

	public void RemovePreviousSoftware(SoftwareProduct p)
	{
		if (!PreviousSoftware.Remove(p))
		{
			return;
		}
		foreach (MarketingPlan item in MarketingItems.Where((MarketingPlan x) => x.TargetProduct == p))
		{
			TakeOverTask(item);
		}
		foreach (SupportWork item2 in SupportItems.Where((SupportWork x) => x.TargetProduct == p))
		{
			TakeOverTask(item2);
		}
		foreach (SoftwareUpdate item3 in UpdateTasks.Keys.Where((SoftwareUpdate x) => x.Target == p).ToList())
		{
			TakeOverTask(item3);
		}
		foreach (SoftwarePort item4 in PortingItems.Where((SoftwarePort x) => x.Product == p).ToList())
		{
			TakeOverTask(item4);
		}
		UpdateLists();
	}

	public void UpdateLists()
	{
		if (!IsViewed)
		{
			return;
		}
		HUD.Instance.AutoDevWindow.WorkList.Items.Clear();
		HUD.Instance.AutoDevWindow.WorkList.Items.AddRange(SupportItems);
		HUD.Instance.AutoDevWindow.WorkList.Items.AddRange(MarketingItems);
		HUD.Instance.AutoDevWindow.WorkList.Items.AddRange(UpdateTasks.Keys);
		HUD.Instance.AutoDevWindow.WorkList.Items.AddRange(PortingItems);
		HUD.Instance.AutoDevWindow.WorkList.Items.AddRange(from x in GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>()
			where x.TargetItem != null && Items.Any((AutoDevItem z) => z.SWWorkItem == x.TargetItem)
			select x);
	}

	private void UpdateSpecLevels()
	{
	}

	public void AddPastRelease(SoftwareProduct p)
	{
		for (int i = 0; i < PastReleases.Count; i++)
		{
			if (PastReleases[i].GetLatestSuccessor() == p)
			{
				PastReleases.RemoveAt(i);
				i--;
			}
		}
		PastReleases.Add(p);
		UpdateLists();
	}

	public SoftwareProduct GetValidSequel(out Employee leaderError)
	{
		leaderError = null;
		if (PastReleases.Count == 0)
		{
			return null;
		}
		for (int num = PastReleases.Count - 1; num > -1; num--)
		{
			SoftwareProduct latestSuccessor = PastReleases[num].GetLatestSuccessor();
			if (SDateTime.GetMonthsFlat(latestSuccessor.Release, SDateTime.Now()) >= GetSpecValue(ReleaseCooldown, 2, 0) && GameSettings.Instance.MyCompany.CanMakeSequel(latestSuccessor))
			{
				if (CheckLead(latestSuccessor))
				{
					return latestSuccessor;
				}
				leaderError = latestSuccessor.LeadDesigner;
			}
			if (SingleIP)
			{
				return null;
			}
		}
		return null;
	}

	public SoftwareProduct GetLatestRelease()
	{
		return PastReleases.LastOrDefault((SoftwareProduct x) => SDateTime.GetMonthsFlat(x.Release, SDateTime.Now()) >= GetSpecValue(ReleaseCooldown, 2, 0));
	}

	public AutoDevWorkItem()
	{
	}

	public AutoDevWorkItem(string name)
		: base(name, null, 0u, null)
	{
	}

	public float MaxActions()
	{
		return (!(Leader == null)) ? MaxActionCounts[Leader.employee.GetSpecialization(Employee.EmployeeRole.Lead, "Automation")] : 0;
	}

	public void RefreshTeams()
	{
		foreach (AutoDevItem item in Items)
		{
			if (item.Queued)
			{
				continue;
			}
			if (item.Alpha == null)
			{
				AssignTeams(item.Document, DesignTeams);
				foreach (SoftwareWorkItem addon in item.Addons)
				{
					AssignTeams(addon, DesignTeams);
				}
			}
			else
			{
				AssignTeams(item.Alpha, item.Secondary ? SecondaryDevTeams : SDevTeams);
				foreach (SoftwareWorkItem addon2 in item.Addons)
				{
					AssignTeams(addon2, item.Secondary ? SecondaryDevTeams : SDevTeams);
				}
			}
			if (item.Hype != null)
			{
				AssignTeams(item.Hype, MarketingTeams);
			}
			MarketingPlan marketingPlan = GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>().FirstOrDefault((MarketingPlan x) => x.Type == MarketingPlan.TaskType.PressRelease && x.TargetItem == item.SWWorkItem);
			if (marketingPlan != null)
			{
				AssignTeams(marketingPlan, MarketingTeams);
			}
		}
		for (int num = 0; num < MarketingItems.Count; num++)
		{
			AssignTeams(MarketingItems[num], PostMarketingTeams);
		}
		for (int num2 = 0; num2 < SupportItems.Count; num2++)
		{
			AssignTeams(SupportItems[num2], SupportTeams);
		}
		foreach (SoftwareUpdate key in UpdateTasks.Keys)
		{
			AssignTeams(key, UpdateTeams);
		}
		foreach (SoftwarePort portingItem in PortingItems)
		{
			AssignTeams(portingItem, PortingTeams);
		}
	}

	public AutoDevWorkItem(string name, Actor leader)
		: base(name, null, 0u, null)
	{
		Leader = leader;
	}

	public override string GetIcon()
	{
		return "Automation";
	}

	public void AssignTeams(WorkItem item, HashSet<string> teams)
	{
		item.SetDevTeams(teams.ToList());
	}

	public override HasWorkReturn HasWork(Actor actor, bool secondary, bool actualCheck)
	{
		if ((actor == Leader && (SupportItems.Count > 0 || MarketingItems.Count > 0 || UpdateTasks.Count > 0 || Items.Any((AutoDevItem x) => !x.Queued))) || PortingItems.Count > 0)
		{
			return HasWorkReturn.True;
		}
		return HasWorkReturn.Ignore;
	}

	public override void DoWork(Actor actor, float effectiveness, float delta, bool secondary)
	{
		float skill = actor.employee.GetSkill(Employee.EmployeeRole.Lead);
		float perDay = (LastEffGain = effectiveness * actor.GetPCAddonBonus(Employee.EmployeeRole.Lead) * skill * skill) * 3f;
		LastEffectiveness = Mathf.Min(3f, LastEffectiveness + Utilities.PerDay(perDay, delta));
		LastEffGainTime = SDateTime.Now();
	}

	public float GetLastEffGain()
	{
		if (LastEffGain > 0f && SDateTime.GetHours(LastEffGainTime, SDateTime.Now()) > 0.1f)
		{
			LastEffGain = 0f;
		}
		return LastEffGain;
	}

	public override float GetWorkBoost(Employee.EmployeeRole role, float currentSkil)
	{
		return 1f;
	}

	public override Employee.EmployeeRole? GetBoostRole(Actor act, bool secondary)
	{
		return Employee.EmployeeRole.Lead;
	}

	public override Actor.WorkParticle EmitType(Actor actor, bool secondary)
	{
		return Actor.WorkParticle.Letters;
	}

	public override IEnumerable<KeyValuePair<string, Action>> GetButtons()
	{
		yield return new KeyValuePair<string, Action>("Assign", delegate
		{
			List<Actor> leaders = GameSettings.Instance.sActorManager.Actors.Where((Actor x) => x.employee.IsRole(Employee.RoleBit.Lead) && x.employee.GetSpecialization(Employee.EmployeeRole.Lead, "Automation") > 0).ToList();
			if (leaders.Count > 0)
			{
				WindowManager.Instance.MultiWindow.Show("Pick a leader", leaders.Select((Actor x) => x.employee.FullName), delegate(int x)
				{
					Leader = ((x == -1) ? null : leaders[x]);
				}, false);
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("AutoDevNoLeaders".Loc(), false, DialogWindow.DialogType.Error);
			}
		});
		yield return new KeyValuePair<string, Action>("Options", OpenOptions);
		yield return new KeyValuePair<string, Action>("Cancel", delegate
		{
			WindowManager.Instance.ShowMessageBox("WorkItemCancelConf".LocColor(this), true, DialogWindow.DialogType.Warning, delegate
			{
				Kill();
			}, "Cancel work");
		});
	}

	public override void GetNeeds(Dictionary<HRManagement.EdNeed, int>[] needs)
	{
	}

	public override string GetTypeName()
	{
		return "AutoDevWorkItem";
	}

	public override string GetGroupType()
	{
		return "Projectmanagement";
	}

	public override string GetGroupProject()
	{
		return "Projectmanagement".Loc();
	}

	public override string GetGroupProjectLabel()
	{
		return base.Name;
	}

	public override string GetGroupTypeLabel()
	{
		return base.Name;
	}

	public override bool HasProjectGrouping()
	{
		return false;
	}

	private void RefreshHype(AutoDevItem item)
	{
		if (item.InHouse)
		{
			return;
		}
		if (Hype)
		{
			if (item.Hype == null || (item.Hype != null && item.Hype.Done))
			{
				MarketingPlan marketingPlan = GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>().FirstOrDefault((MarketingPlan x) => x.Type == MarketingPlan.TaskType.Hype && x.TargetItem == item.SWWorkItem);
				if (marketingPlan != null)
				{
					item.Hype = marketingPlan;
					return;
				}
				SoftwareWorkItem softwareWorkItem = (SoftwareWorkItem)(((object)item.Alpha) ?? ((object)item.Document));
				item.Hype = new MarketingPlan(softwareWorkItem, MarketingPlan.TaskType.Hype, MarketingPlan.PressOption.None, (softwareWorkItem.guiItem == null) ? (-1) : (softwareWorkItem.guiItem.transform.GetSiblingIndex() + 1));
				item.Hype.AutoDev = true;
				item.Hype.Hidden = true;
				AssignTeams(item.Hype, MarketingTeams);
				GameSettings.Instance.MyCompany.AddWorkItem(item.Hype);
				UpdateLists();
			}
		}
		else if (item.Hype != null)
		{
			item.Hype.Kill();
			item.Hype = null;
		}
	}

	public void AssignProject(SoftwareWorkItem doc, List<SoftwareWorkItem> addons)
	{
		doc.AutoDev = true;
		doc.Hidden = true;
		if (addons != null)
		{
			foreach (SoftwareWorkItem addon in addons)
			{
				addon.AutoDev = true;
				addon.Hidden = true;
			}
		}
		GameSettings.Instance.MyCompany.AddWorkItem(doc);
		AutoDevItem item = new AutoDevItem(doc, addons, this);
		Items.Add(item);
		NotificationManager.RemoveAggregate<AutoDevAssignNotification>(this);
	}

	public override void PauseChange()
	{
		for (int i = 0; i < Items.Count; i++)
		{
			AutoDevItem autoDevItem = Items[i];
			if (!autoDevItem.Queued)
			{
				if (Paused)
				{
					autoDevItem.AlreadyDev += SDateTime.GetMonths(autoDevItem.ActualStartDate, SDateTime.Now());
				}
				else
				{
					autoDevItem.ActualStartDate = SDateTime.Now();
				}
				autoDevItem.SWWorkItem.Paused = Paused;
				if (autoDevItem.Hype != null)
				{
					autoDevItem.Hype.Paused = Paused;
				}
			}
		}
		for (int j = 0; j < MarketingItems.Count; j++)
		{
			MarketingItems[j].Paused = Paused;
		}
		for (int k = 0; k < SupportItems.Count; k++)
		{
			SupportItems[k].Paused = Paused;
		}
		foreach (KeyValuePair<SoftwareUpdate, SDateTime> updateTask in UpdateTasks)
		{
			updateTask.Key.Paused = Paused;
		}
		foreach (SoftwarePort portingItem in PortingItems)
		{
			portingItem.Paused = Paused;
		}
	}

	private void SetDev(AutoDevItem item, bool value, ref bool primary, ref bool secondary)
	{
		if (item.Secondary)
		{
			secondary |= value;
		}
		else
		{
			primary |= value;
		}
	}

	private SDateTime? GetNextReleaseDate(AutoDevItem exclude)
	{
		SDateTime? result = null;
		for (int i = 0; i < Items.Count; i++)
		{
			AutoDevItem autoDevItem = Items[i];
			if (autoDevItem != exclude && !autoDevItem.Queued)
			{
				SDateTime? releaseDate = autoDevItem.ReleaseDate;
				if (releaseDate.HasValue && (!result.HasValue || result.Value > releaseDate.Value))
				{
					result = releaseDate;
				}
			}
		}
		return result;
	}

	private void StartPrintJob(SoftwareAlpha item, bool hasPrinted)
	{
		if (GetSpecValue(PrintingCopies, 3, 0u) != 0 && !hasPrinted)
		{
			uint num = PrintingCopies;
			if (PrintingCopyRel)
			{
				num = (uint)(item.Followers * ((float)PrintingCopies / 100f));
			}
			PrintJob printJob = new PrintJob(item, 1f);
			if (GetSpecValue(AutoDistribution, 3, false))
			{
				printJob.Maximum = num;
			}
			else
			{
				printJob.Limit = num;
			}
			GameSettings.Instance.AddPrintOrder(printJob, true);
			HUD.Instance.distributionWindow.RefreshOrders();
			HUD.Instance.LogAuto("AutoLogPMPrintCopy", _name, num, item.Name);
		}
	}

	private void PromoteAddon(AddOnProduct product)
	{
		bool flag = false;
		if (GetSpecValue(PostMarketing, 3, false))
		{
			MarketingPlan marketingPlan = new MarketingPlan(0f, product);
			AssignTeams(marketingPlan, PostMarketingTeams);
			GameSettings.Instance.MyCompany.AddWorkItem(marketingPlan);
			if (HandleMarketing)
			{
				marketingPlan.AutoDev = true;
				marketingPlan.Hidden = true;
				MarketingItems.Add(marketingPlan);
				HUD.Instance.LogAuto("AutoLogPMStartMarketing", _name, product.Name);
				flag = true;
			}
		}
		if (flag)
		{
			UpdateLists();
		}
		if (GetSpecValue(PhysicalCopies, 3, 0u) == 0)
		{
			return;
		}
		uint num = PhysicalCopies;
		if (PhysicalCopyRel)
		{
			num = (uint)((float)product.Followers * ((float)PhysicalCopies / 100f));
		}
		float num2 = (float)num * product.GetPrintPrice();
		GameSettings.Instance.MyCompany.MakeTransaction(0f - num2, Company.TransactionCategory.Distribution, true, "Copy order");
		product.AddLoss(num2, SoftwareProduct.LossType.Copies, true);
		if (num != 0 && GetMistakeChance(false) > Utilities.RandomValue)
		{
			uint num3 = num.Min((uint)Mathf.RoundToInt(GetMistakeAmount(Utilities.RandomRange(900, 1100))));
			if (num3 > 1)
			{
				num -= num3;
				LogMistake("Distribution", product.Name, num3.ToString());
			}
		}
		product.PhysicalCopies += num;
		HUD.Instance.LogAuto("AutoLogPMOrderCopy", _name, num, product.Name);
	}

	private float RawMistakeChance()
	{
		return 1f - Mathf.Clamp01(LastEffectiveness);
	}

	public float GetMistakeChance(bool ongoing)
	{
		float num = RawMistakeChance();
		if (!ongoing)
		{
			return num;
		}
		return num.MapRange(0f, 1f, 0f, 0.25f.SpreadChance(GameSettings.DaysPerMonth));
	}

	public float GetMistakeAmount(float max)
	{
		return RawMistakeChance() * max;
	}

	public void Update(float delta)
	{
		if (Leader == null || Paused)
		{
			return;
		}
		bool flag = false;
		bool primary = false;
		bool secondary = false;
		for (int i = 0; i < Items.Count; i++)
		{
			AutoDevItem autoDevItem = Items[i];
			if (autoDevItem.Queued)
			{
				continue;
			}
			if (autoDevItem.Alpha != null)
			{
				bool flag2 = false;
				SetDev(autoDevItem, true, ref primary, ref secondary);
				if (autoDevItem.Alpha.InBeta)
				{
					for (int j = 0; j < autoDevItem.Addons.Count; j++)
					{
						if (!((SoftwareAlpha)autoDevItem.Addons[j]).InBeta)
						{
							autoDevItem.Addons[j].PromoteAction();
						}
					}
					if (SDateTime.Now() > autoDevItem.GetCutDate(1f) - new SDateTime(0, 3, 0, 0, 0))
					{
						bool flag3 = true;
						for (int k = 0; k < autoDevItem.Addons.Count; k++)
						{
							if (!((SoftwareAlpha)autoDevItem.Addons[k]).InBeta)
							{
								flag3 = false;
							}
						}
						if (flag3)
						{
							EndMarketingFor(autoDevItem.Alpha);
							object[] array = (object[])autoDevItem.Alpha.PromoteAction();
							if (array != null)
							{
								HUD.Instance.LogAuto("AutoLogPMRelease", _name, autoDevItem.Name);
								NextReleaseDate = GetNextReleaseDate(autoDevItem);
								if (autoDevItem.Secondary)
								{
									LastAlpha2 = null;
								}
								else
								{
									LastAlpha = null;
								}
								SupportWork supportWork = (SupportWork)array[0];
								SoftwareProduct softwareProduct = (SoftwareProduct)array[1];
								if (GetMistakeChance(false) > Utilities.RandomValue)
								{
									int num = Mathf.RoundToInt(GetMistakeAmount(Utilities.RandomRange(190, 210)));
									if (num > 1)
									{
										softwareProduct.AddBugs(num);
										LogMistake("Beta", autoDevItem.Alpha.SoftwareName, num.ToString());
									}
								}
								bool flag4 = false;
								if (GetSpecValue(AutoSupport, 3, false))
								{
									supportWork.AutoDev = true;
									supportWork.Hidden = true;
									SupportItems.Add(supportWork);
									HUD.Instance.LogAuto("AutoLogPMStartSupport", _name, softwareProduct.Name);
									flag4 = true;
								}
								AssignTeams(supportWork, SupportTeams);
								AddPastRelease(softwareProduct);
								if (GetSpecValue(PostMarketing, 3, false) && !autoDevItem.InHouse)
								{
									MarketingPlan marketingPlan = new MarketingPlan(0f, softwareProduct);
									AssignTeams(marketingPlan, PostMarketingTeams);
									GameSettings.Instance.MyCompany.AddWorkItem(marketingPlan);
									if (HandleMarketing)
									{
										marketingPlan.AutoDev = true;
										marketingPlan.Hidden = true;
										MarketingItems.Add(marketingPlan);
										HUD.Instance.LogAuto("AutoLogPMStartMarketing", _name, softwareProduct.Name);
										flag4 = true;
									}
								}
								if (flag4)
								{
									UpdateLists();
								}
								Items.Remove(autoDevItem);
								i--;
								SetDev(autoDevItem, false, ref primary, ref secondary);
								if (GetSpecValue(PhysicalCopies, 3, 0u) != 0)
								{
									uint num2 = PhysicalCopies;
									if (PhysicalCopyRel)
									{
										num2 = (uint)((float)softwareProduct.Followers * ((float)PhysicalCopies / 100f));
									}
									float num3 = (float)num2 * softwareProduct.GetPrintPrice();
									GameSettings.Instance.MyCompany.MakeTransaction(0f - num3, Company.TransactionCategory.Distribution, true, "Copy order");
									softwareProduct.AddLoss(num3, SoftwareProduct.LossType.Copies, true);
									softwareProduct.PhysicalCopies += num2;
									HUD.Instance.LogAuto("AutoLogPMOrderCopy", _name, num2, autoDevItem.Name);
								}
								if (softwareProduct.ForcedAddons != null)
								{
									for (int l = 0; l < softwareProduct.ForcedAddons.Length; l++)
									{
										PromoteAddon(softwareProduct.ForcedAddons[l]);
									}
								}
								NotificationManager.AddNotification(new ProductDetailNotification(softwareProduct, "ProjectManagementRelease".Loc(base.Name, "", softwareProduct.Type.Name.LocSWFull(softwareProduct.Category.Name), softwareProduct), "Software", SDateTime.Now(), NotificationManager.NotificationType.Good));
								flag2 = true;
							}
						}
					}
				}
				else
				{
					if (autoDevItem.Alpha.HasFinished || SDateTime.Now() > autoDevItem.GetCutDate(SoftwareType.DesignRatio + 0.75f * (1f - SoftwareType.DesignRatio)))
					{
						if (autoDevItem.Alpha.HasFinished)
						{
							SDateTime cutDate = autoDevItem.GetCutDate(SoftwareType.DesignRatio + 0.75f * (1f - SoftwareType.DesignRatio));
							SDateTime sDateTime = SDateTime.Now();
							if (sDateTime < cutDate)
							{
								float months = SDateTime.GetMonths(sDateTime, cutDate);
								if (months > 1f)
								{
									autoDevItem.MonthsToSpend -= months;
									autoDevItem.Alpha.ReleaseDate = SDateTime.Max(SDateTime.Now() + 1, autoDevItem.GetCutDate(1f));
									autoDevItem.Alpha.NetworkSchedule(false);
									NextReleaseDate = GetNextReleaseDate(null);
								}
							}
						}
						autoDevItem.Alpha.PromoteAction();
						if (autoDevItem.Alpha.InBeta)
						{
							if (GetMistakeChance(false) > Utilities.RandomValue)
							{
								float mistakeAmount = GetMistakeAmount(0.25f);
								if (mistakeAmount >= 0.01f)
								{
									SoftwareWorkItem.FeatureProgress[] features = autoDevItem.Alpha.Features;
									foreach (SoftwareWorkItem.FeatureProgress obj in features)
									{
										obj.Progress *= 1f - mistakeAmount;
										obj.ArtProgress *= 1f - mistakeAmount;
									}
									LogMistake("Alpha", autoDevItem.Alpha.SoftwareName, mistakeAmount.ToPercent());
								}
							}
							for (int n = 0; n < autoDevItem.Addons.Count; n++)
							{
								SoftwareAlpha softwareAlpha = (SoftwareAlpha)autoDevItem.Addons[n];
								if (!softwareAlpha.InBeta)
								{
									softwareAlpha.PromoteAction();
									if (softwareAlpha.InBeta)
									{
										StartPrintJob(softwareAlpha, autoDevItem.hasPrinted);
									}
								}
							}
							HUD.Instance.LogAuto("AutoLogPMBeta", _name, autoDevItem.Name);
							StartPrintJob(autoDevItem.Alpha, autoDevItem.hasPrinted);
							autoDevItem.hasPrinted = true;
						}
					}
					int specValue = GetSpecValue(IterationCoolDown, 2, 0);
					if (!autoDevItem.Alpha.InBeta && specValue > 0 && SDateTime.GetMonths(autoDevItem.Alpha.LastIteration, SDateTime.Now()) >= (float)specValue)
					{
						autoDevItem.Alpha.ReviewAndIterate();
					}
				}
				if (!flag2 && !autoDevItem.InHouse && !autoDevItem.PressRelease && MarketingTeams.Count > 0 && SDateTime.Now() > autoDevItem.GetCutDate(SoftwareType.DesignRatio + (1f - SoftwareType.DesignRatio) * 0.5f))
				{
					autoDevItem.PressRelease = true;
					MarketingPlan marketingPlan2 = new MarketingPlan(autoDevItem.Alpha, MarketingPlan.TaskType.PressRelease, MarketingPlan.PressOption.All, (autoDevItem.Alpha.guiItem == null) ? (-1) : (autoDevItem.Alpha.guiItem.transform.GetSiblingIndex() + 1));
					marketingPlan2.AutoDev = true;
					marketingPlan2.Hidden = true;
					AssignTeams(marketingPlan2, MarketingTeams);
					GameSettings.Instance.MyCompany.AddWorkItem(marketingPlan2);
					UpdateLists();
				}
				if (!flag2 && !autoDevItem.InHouse && !autoDevItem.PressBuild && MarketingTeams.Count > 0 && SDateTime.Now() > autoDevItem.GetCutDate(SoftwareType.DesignRatio + (1f - SoftwareType.DesignRatio) * 0.75f))
				{
					GameSettings.Instance.PressBuildQueue.Add(autoDevItem.Alpha);
					autoDevItem.PressBuild = true;
				}
				if (!flag2)
				{
					RefreshHype(autoDevItem);
				}
				continue;
			}
			flag = true;
			if (autoDevItem.Document.LeadDesigner == null && !WorkIssueNotification.CheckAggregate(autoDevItem.Document, WorkIssueNotification.Issue.LeadDesignerAutoError))
			{
				NotificationManager.AddNotification(new WorkIssueNotification(WorkIssueNotification.Issue.LeadDesignerAutoError, autoDevItem.Document));
			}
			if (autoDevItem.Document.HasFinished || SDateTime.Now() > autoDevItem.GetCutDate(SoftwareType.DesignRatio))
			{
				if (autoDevItem.Document.HasFinished)
				{
					SDateTime cutDate2 = autoDevItem.GetCutDate(SoftwareType.DesignRatio);
					SDateTime sDateTime2 = SDateTime.Now();
					if (sDateTime2 < cutDate2)
					{
						float months2 = SDateTime.GetMonths(sDateTime2, cutDate2);
						if (months2 > 1f)
						{
							autoDevItem.MonthsToSpend -= months2;
						}
					}
				}
				EndMarketingFor(autoDevItem.Document);
				object obj2 = autoDevItem.Document.PromoteAction();
				if (obj2 != null)
				{
					for (int num4 = 0; num4 < autoDevItem.Addons.Count; num4++)
					{
						SoftwareWorkItem softwareWorkItem = autoDevItem.Addons[num4];
						autoDevItem.Addons[num4] = (SoftwareAlpha)softwareWorkItem.PromoteAction();
						softwareWorkItem = autoDevItem.Addons[num4];
						softwareWorkItem.Hidden = true;
						softwareWorkItem.AutoDev = true;
					}
					LastDesign = null;
					SoftwareAlpha softwareAlpha2 = (SoftwareAlpha)obj2;
					if (GetMistakeChance(false) > Utilities.RandomValue)
					{
						float mistakeAmount2 = GetMistakeAmount(0.25f);
						if (mistakeAmount2 >= 0.01f)
						{
							SoftwareWorkItem.FeatureProgress[] features = softwareAlpha2.Features;
							foreach (SoftwareWorkItem.FeatureProgress obj3 in features)
							{
								obj3.ArtTargetQual *= 1f - mistakeAmount2;
								obj3.CodeTargetQual *= 1f - mistakeAmount2;
							}
							LogMistake("Design", softwareAlpha2.SoftwareName, mistakeAmount2.ToPercent());
						}
					}
					softwareAlpha2.AutoDev = true;
					softwareAlpha2.Hidden = true;
					AutoDevItem autoDevItem2 = new AutoDevItem(softwareAlpha2, autoDevItem.Addons, this);
					autoDevItem2.MonthsToSpend = autoDevItem.MonthsToSpend;
					autoDevItem2.AlreadyDev = SDateTime.GetMonths(autoDevItem.ActualStartDate, SDateTime.Now());
					autoDevItem2.Hype = autoDevItem.Hype;
					Items.Add(autoDevItem2);
					Items.Remove(autoDevItem);
					i--;
					flag = false;
				}
			}
			if (flag && !autoDevItem.InHouse && !autoDevItem.PressRelease && MarketingTeams.Count > 0 && SDateTime.Now() > autoDevItem.GetCutDate(SoftwareType.DesignRatio * 0.5f))
			{
				autoDevItem.PressRelease = true;
				MarketingPlan marketingPlan3 = new MarketingPlan(autoDevItem.Document, MarketingPlan.TaskType.PressRelease, MarketingPlan.PressOption.All, (autoDevItem.Document.guiItem == null) ? (-1) : (autoDevItem.Document.guiItem.transform.GetSiblingIndex() + 1));
				marketingPlan3.AutoDev = true;
				marketingPlan3.Hidden = true;
				AssignTeams(marketingPlan3, MarketingTeams);
				GameSettings.Instance.MyCompany.AddWorkItem(marketingPlan3);
				UpdateLists();
			}
			if (flag)
			{
				RefreshHype(autoDevItem);
			}
		}
		if ((!primary && SDevTeams.Count > 0) || (!secondary && SecondaryDevTeams.Count > 0))
		{
			AutoDevItem autoDevItem3 = Items.FirstOrDefault((AutoDevItem x) => x.Queued && x.Alpha != null);
			if (autoDevItem3 != null)
			{
				HUD.Instance.LogAuto("AutoLogPMAlpha", _name, autoDevItem3.Name);
				autoDevItem3.ActualStartDate = SDateTime.Now();
				autoDevItem3.SWWorkItem.ReleaseDate = SDateTime.Max(SDateTime.Now() + 1, autoDevItem3.GetCutDate(1f));
				autoDevItem3.SWWorkItem.NetworkSchedule(false);
				autoDevItem3.Queued = false;
				NextReleaseDate = GetNextReleaseDate(null);
				if (!primary && SDevTeams.Count > 0)
				{
					AssignTeams(autoDevItem3.Alpha, SDevTeams);
					foreach (SoftwareWorkItem addon in autoDevItem3.Addons)
					{
						AssignTeams(addon, SDevTeams);
					}
					LastAlpha = autoDevItem3.Name;
				}
				else
				{
					AssignTeams(autoDevItem3.Alpha, SecondaryDevTeams);
					foreach (SoftwareWorkItem addon2 in autoDevItem3.Addons)
					{
						AssignTeams(addon2, SecondaryDevTeams);
					}
					autoDevItem3.Secondary = true;
					LastAlpha2 = autoDevItem3.Name;
				}
			}
		}
		if (!flag && DesignTeams.Count > 0)
		{
			AutoDevItem autoDevItem4 = Items.FirstOrDefault((AutoDevItem x) => x.Queued && x.Document != null);
			if (autoDevItem4 != null)
			{
				HUD.Instance.LogAuto("AutoLogPMDesign", _name, autoDevItem4.Name);
				autoDevItem4.ActualStartDate = SDateTime.Now();
				autoDevItem4.Queued = false;
				LastDesign = autoDevItem4.Name;
				AssignTeams(autoDevItem4.Document, DesignTeams);
				foreach (SoftwareWorkItem addon3 in autoDevItem4.Addons)
				{
					AssignTeams(addon3, DesignTeams);
				}
			}
			else if (AutoProject)
			{
				List<SoftwareWorkItem> addons;
				SoftwareWorkItem softwareWorkItem2 = GenerateProduct(out addons);
				if (softwareWorkItem2 != null)
				{
					HUD.Instance.LogAuto("AutoLogPMNewProj", _name, softwareWorkItem2.SoftwareName);
					softwareWorkItem2.AutoDev = true;
					softwareWorkItem2.Hidden = true;
					GameSettings.Instance.MyCompany.AddWorkItem(softwareWorkItem2);
					Items.Add(new AutoDevItem(softwareWorkItem2, addons, this));
				}
			}
			else if (PreviousSoftware.Count > 0)
			{
				NotificationManager.RemoveAggregate<AutoDevAssignNotification>(this);
			}
		}
		if (flag || primary || secondary || MarketingItems.Count > 0 || SupportItems.Count > 0 || UpdateTasks.Count > 0 || PortingItems.Count > 0)
		{
			float num5 = (float)Items.Count((AutoDevItem x) => !x.Queued) + (float)MarketingItems.Count * 0.25f + (float)SupportItems.Count * 0.1f + (float)UpdateTasks.Count * 0.1f + (float)PortingItems.Count * 0.25f;
			num5 = (LastEffLoss = num5 / 4f);
			LastEffectiveness = Mathf.Max(0f, LastEffectiveness - Utilities.PerDay(num5, delta, false));
		}
	}

	private void EndMarketingFor(WorkItem i)
	{
		foreach (MarketingPlan item in (from x in GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>()
			where x.TargetItem == i
			select x).ToList())
		{
			item.StopMarketing();
		}
		UpdateLists();
	}

	public bool TakeOverTask(WorkItem work)
	{
		SoftwareUpdate key;
		if (SupportItems.Remove(work) || MarketingItems.Remove(work) || PortingItems.Remove(work) || ((key = work as SoftwareUpdate) != null && UpdateTasks.Remove(key)))
		{
			work.AutoDev = false;
			work.Hidden = false;
			UpdateLists();
			return true;
		}
		return false;
	}

	public void UpdateSupportMarket(bool daily)
	{
		if (daily && (Leader == null || Paused))
		{
			return;
		}
		bool flag = false;
		SDateTime now = SDateTime.Now();
		for (int i = 0; i < SupportItems.Count; i++)
		{
			SupportWork supportWork = SupportItems[i];
			SoftwareProduct targetProduct = supportWork.TargetProduct;
			if (SDateTime.GetMonths(targetProduct.Release, now) >= 3f && (targetProduct.Bugss == 0 || targetProduct.Userbase < 100))
			{
				HUD.Instance.LogAuto("AutoLogPMEndSupport", _name, targetProduct.Name);
				SupportItems.RemoveAt(i);
				supportWork.CancelSupport();
				flag = true;
				i--;
			}
			else if (daily && GetMistakeChance(true) > Utilities.RandomValue)
			{
				int num = Mathf.RoundToInt(GetMistakeAmount((float)targetProduct.FixableBugs * 0.5f));
				if (num > 1)
				{
					targetProduct.VerifiedBugs -= num;
					LogMistake("Support", targetProduct.Name, num.ToString());
				}
			}
		}
		for (int j = 0; j < MarketingItems.Count; j++)
		{
			MarketingPlan marketingPlan = MarketingItems[j];
			IMarketable targetProduct2 = marketingPlan.TargetProduct;
			float maxBudget = 0f;
			int salesMonths = targetProduct2.GetSalesMonths();
			if (salesMonths > 0)
			{
				float b = 5000f;
				SoftwareProduct softwareProduct;
				AddOnProduct addOnProduct;
				if ((softwareProduct = targetProduct2 as SoftwareProduct) != null)
				{
					b = (MarketSimulation.Active.GetMaxAwareness(softwareProduct) - softwareProduct.GetRealAwareness()) * MarketingPlan.PostMarketingPrice / (float)GameSettings.DaysPerMonth;
				}
				else if ((addOnProduct = targetProduct2 as AddOnProduct) != null)
				{
					b = (addOnProduct.Parent.GetMaxAwareness(addOnProduct) - addOnProduct.GetRealAwareness()) * MarketingPlan.PostMarketingPrice / (float)GameSettings.DaysPerMonth;
				}
				b = Mathf.Max(0f, b);
				float lastDayIncome = targetProduct2.GetLastDayIncome(true);
				if (salesMonths >= 3 && lastDayIncome < 1000f / (float)GameSettings.DaysPerMonth)
				{
					HUD.Instance.LogAuto("AutoLogPMEndMarketing", _name, targetProduct2.GetName());
					MarketingItems.RemoveAt(j);
					marketingPlan.StopMarketing();
					flag = true;
					j--;
					continue;
				}
				maxBudget = ((salesMonths > 3) ? Mathf.Min(b, Mathf.Max(5000f, lastDayIncome / 4f)) : b);
			}
			marketingPlan.MaxBudget = maxBudget;
			SoftwareProduct softwareProduct2;
			if (daily && (softwareProduct2 = targetProduct2 as SoftwareProduct) != null && GetMistakeChance(true) > Utilities.RandomValue)
			{
				float mistakeAmount = GetMistakeAmount(0.25f);
				if (mistakeAmount >= 0.01f)
				{
					softwareProduct2.SetAwareness(softwareProduct2.GetRealAwareness() * (1f - mistakeAmount), false);
					LogMistake("Marketing", softwareProduct2.Name, mistakeAmount.ToPercent());
				}
			}
		}
		if (UpdateTasks.Count > 0)
		{
			foreach (KeyValuePair<SoftwareUpdate, SDateTime> item in UpdateTasks.ToList())
			{
				SoftwareUpdate key = item.Key;
				if (!key.HasFinished || !(SDateTime.GetMonths(item.Value, now) >= (float)UpdateCooldown))
				{
					continue;
				}
				if (GetMistakeChance(false) > Utilities.RandomValue)
				{
					int num2 = Mathf.RoundToInt(GetMistakeAmount(key.FixedBugs * 0.5f));
					if (num2 > 1)
					{
						key.FixedBugs -= num2;
						LogMistake("Update", key.Target.Name, num2.ToString());
					}
				}
				key.Finish();
				UpdateTasks.Remove(key);
				flag = true;
			}
		}
		if (GetSpecValue(Updates, 3, false))
		{
			for (int k = 0; k < PastReleases.Count; k++)
			{
				flag |= UpdateCheck(PastReleases[k], now);
			}
			for (int l = 0; l < PreviousSoftware.Count; l++)
			{
				flag |= UpdateCheck(PreviousSoftware[l], now);
			}
		}
		if (GetSpecValue(AutoDistribution, 3, false))
		{
			for (int m = 0; m < PastReleases.Count; m++)
			{
				DistributionCheck(PastReleases[m], now);
			}
			for (int n = 0; n < PreviousSoftware.Count; n++)
			{
				DistributionCheck(PreviousSoftware[n], now);
			}
		}
		if (GetSpecValue(Porting, 3, false))
		{
			List<SoftwareProduct> oSs = (from x in MarketSimulation.Active.GetAllProducts(false)
				where x.Type.Name.Equals("Operating System") && x.Userbase > 500000
				select x).ToList();
			for (int num3 = 0; num3 < PastReleases.Count; num3++)
			{
				PortCheck(PastReleases[num3], oSs);
			}
			for (int num4 = 0; num4 < PreviousSoftware.Count; num4++)
			{
				PortCheck(PreviousSoftware[num4], oSs);
			}
		}
		if (flag)
		{
			UpdateLists();
		}
	}

	private void PortCheck(SoftwareProduct p, List<SoftwareProduct> OSs)
	{
		if (!p.Type.OSSpecific || p.Archived || SDateTime.GetYears(p.LastSale, SDateTime.Now()) > 5f)
		{
			return;
		}
		SoftwarePort softwarePort = null;
		int num = 0;
		string text = null;
		for (int i = 0; i < OSs.Count; i++)
		{
			SoftwareProduct os = OSs[i];
			if (!p.Type.SupportsOS(os.Category.Name) || p.HasOS(os))
			{
				continue;
			}
			if (softwarePort == null)
			{
				softwarePort = GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwarePort>().FirstOrDefault((SoftwarePort x) => x.Product == p);
				if (softwarePort != null)
				{
					if (softwarePort.OSs.None((SoftwarePort.PortProgress x) => x.Product == os))
					{
						softwarePort.OSs.Add(new SoftwarePort.PortProgress(os));
						num++;
						text = os.Name;
					}
				}
				else
				{
					softwarePort = new SoftwarePort(p, new SoftwareProduct[1] { os });
					softwarePort.AutoDev = true;
					softwarePort.Hidden = true;
					softwarePort.AddDevTeams(PortingTeams);
					GameSettings.Instance.MyCompany.WorkItems.Add(softwarePort);
					PortingItems.Add(softwarePort);
					num++;
					text = os.Name;
				}
			}
			else if (softwarePort.OSs.None((SoftwarePort.PortProgress x) => x.Product == os))
			{
				softwarePort.OSs.Add(new SoftwarePort.PortProgress(os));
				num++;
				text = os.Name;
			}
		}
		if (num > 0)
		{
			HUD.Instance.LogAuto("AutoLogPMPort", _name, p.Name, (num == 1) ? text : (num + " " + "Operatingsystems".Loc()));
		}
	}

	private void DistributionCheck(SoftwareProduct p, SDateTime now)
	{
		if (p.Archived)
		{
			return;
		}
		double budget = Math.Max(p.GetLastDayIncome(true) * (float)GameSettings.DaysPerMonth, GameSettings.Instance.MyCompany.Money * 0.25);
		int num = SimulatedCompany.SimulateProductDistribution(p, budget, false);
		if (num > 0)
		{
			BuyCopies(p, num);
			if (p.ForcedAddons != null)
			{
				for (int i = 0; i < p.ForcedAddons.Length; i++)
				{
					BuyCopies(p.ForcedAddons[i], num + CheckAddon(p.ForcedAddons[i], budget));
				}
			}
			return;
		}
		bool canCancel = p.GetLastMissedPhysicalSales() == 0 && p.GetLastPhysicalSales() == 0 && SDateTime.GetMonths(p.Release, now) > 6f;
		UpdateZeroPrintJob(p, canCancel);
		if (p.ForcedAddons != null)
		{
			for (int j = 0; j < p.ForcedAddons.Length; j++)
			{
				UpdateZeroPrintJob(p.ForcedAddons[j], canCancel);
			}
		}
	}

	private int CheckAddon(AddOnProduct a, double budget)
	{
		int num = SimulatedCompany.SimulateProductDistribution(a, budget, true);
		if (a.Forced && num + a.PhysicalCopies < a.Parent.PhysicalCopies)
		{
			num = Mathf.RoundToInt((float)(a.Parent.PhysicalCopies - a.PhysicalCopies) * (1f + ((float)a.Type.PerUser - 1f) * 0.25f));
			float printPrice = a.GetPrintPrice(true);
			num = Utilities.FloorToInt(Math.Min(budget, (float)num * printPrice) / (double)printPrice);
		}
		return num;
	}

	private void UpdateZeroPrintJob(IStockable p, bool canCancel)
	{
		PrintJob printJob = GameSettings.Instance.GetPrintJob(p);
		if (printJob != null)
		{
			if (canCancel)
			{
				GameSettings.Instance.CancelPrintOrder(printJob, false);
			}
			else
			{
				printJob.Maximum = 0u;
			}
		}
	}

	private void BuyCopies(IStockable p, int copies)
	{
		if (copies > 0)
		{
			PrintJob printJob = GameSettings.Instance.GetPrintJob(p);
			if (printJob != null)
			{
				printJob.Maximum = (uint)copies + p.PhysicalCopies;
				return;
			}
			float num = (float)copies * p.GetPrintPrice();
			GameSettings.Instance.MyCompany.MakeTransaction(0f - num, Company.TransactionCategory.Distribution, true, "Copy order");
			p.AddLoss(num, SoftwareProduct.LossType.Copies, true);
			p.PhysicalCopies += (uint)copies;
			HUD.Instance.LogAuto("AutoLogPMOrderCopy", _name, copies, p.GetName());
		}
	}

	private bool UpdateCheck(SoftwareProduct p, SDateTime now)
	{
		if (p.Archived)
		{
			return false;
		}
		if ((p.FixableBugs > 0 || TechUpdates) && SDateTime.GetMonths(p.Release, now) <= (float)UpdateMonths && GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareUpdate>().None((SoftwareUpdate x) => x.Target == p))
		{
			Dictionary<string, TechLevel> dictionary = null;
			Dictionary<string, SoftwareProduct> dictionary2 = new Dictionary<string, SoftwareProduct>();
			if (TechUpdates && !p.HasSequel)
			{
				dictionary = new Dictionary<string, TechLevel>();
				foreach (KeyValuePair<string, TechLevel> techLevel in p.TechLevels)
				{
					string spec = techLevel.Key;
					TechLevel latestTech = GameSettings.Instance.simulation.GetLatestTech(spec, SDateTime.Now(), p.SWCat, GameSettings.Instance.MyCompany);
					if (latestTech.Year <= techLevel.Value.Year)
					{
						continue;
					}
					SpecFeature specFeature = p.Features.OfType<SpecFeature>().FirstOrDefault((SpecFeature x) => x.Spec.Equals(spec));
					if (specFeature == null)
					{
						continue;
					}
					bool flag = true;
					string[] dependencies = specFeature.Dependencies;
					foreach (string text in dependencies)
					{
						SoftwareProduct value;
						if (dictionary2.TryGetValue(text, out value))
						{
							TechLevel value2;
							if (!value.TechLevels.TryGetValue(spec, out value2) || value2.Year <= latestTech.Year)
							{
								flag = false;
								break;
							}
							continue;
						}
						SoftwareProduct need = GetNeed(spec, text, latestTech, UseOwnLicenses);
						if (need == null)
						{
							flag = false;
							break;
						}
						dictionary2[text] = need;
					}
					if (flag)
					{
						dictionary[spec] = latestTech;
					}
				}
				if (dictionary.Count == 0)
				{
					dictionary = null;
					dictionary2.Clear();
				}
			}
			if (p.FixableBugs > 0 || dictionary != null)
			{
				SoftwareUpdate softwareUpdate = new SoftwareUpdate(p, true, dictionary, dictionary2, SCMServer, -1);
				softwareUpdate.AutoDev = true;
				softwareUpdate.Hidden = true;
				softwareUpdate.AddDevTeams(UpdateTeams);
				GameSettings.Instance.MyCompany.WorkItems.Add(softwareUpdate);
				softwareUpdate.CheckCompetency();
				UpdateTasks.Add(softwareUpdate, now);
				return true;
			}
		}
		return false;
	}

	private bool CheckLead(SoftwareProduct p)
	{
		if (p.DesignerOwned)
		{
			if (p.LeadDesigner.MyActor != null)
			{
				return DesignTeams.Contains(p.LeadDesigner.MyActor.Team);
			}
			return false;
		}
		return true;
	}

	public bool Owns(WorkItem item)
	{
		if (item != null)
		{
			DesignDocument designDocument;
			if ((designDocument = item as DesignDocument) != null)
			{
				DesignDocument designDocument2 = designDocument;
				return Items.Any((AutoDevItem x) => x.Document == designDocument2);
			}
			MarketingPlan marketingPlan;
			if ((marketingPlan = item as MarketingPlan) != null)
			{
				MarketingPlan item2 = marketingPlan;
				return MarketingItems.Contains(item2);
			}
			SoftwareAlpha softwareAlpha;
			if ((softwareAlpha = item as SoftwareAlpha) != null)
			{
				SoftwareAlpha softwareAlpha2 = softwareAlpha;
				return Items.Any((AutoDevItem x) => x.Alpha == softwareAlpha2);
			}
			SoftwareUpdate softwareUpdate;
			if ((softwareUpdate = item as SoftwareUpdate) != null)
			{
				SoftwareUpdate key = softwareUpdate;
				return UpdateTasks.ContainsKey(key);
			}
			SupportWork supportWork;
			if ((supportWork = item as SupportWork) != null)
			{
				SupportWork item3 = supportWork;
				return SupportItems.Contains(item3);
			}
			SoftwarePort softwarePort;
			if ((softwarePort = item as SoftwarePort) != null)
			{
				SoftwarePort item4 = softwarePort;
				return PortingItems.Contains(item4);
			}
		}
		return false;
	}

	public bool IsFunctionallySingleIP()
	{
		if (OnlySequels)
		{
			SoftwareProduct first = null;
			for (int i = 0; i < PastReleases.Count; i++)
			{
				if (first == null)
				{
					first = PastReleases[i].GetLatestSuccessor();
				}
				else if (PastReleases[i].GetLatestSuccessor() != first)
				{
					return false;
				}
			}
			if (first != null)
			{
				return !Items.Any((AutoDevItem x) => x.SWWorkItem.SequelTo != first);
			}
			return true;
		}
		return false;
	}

	public SoftwareWorkItem GenerateProduct(out List<SoftwareWorkItem> addons)
	{
		addons = null;
		Employee leaderError = null;
		SoftwareProduct softwareProduct = (GetSpecValue(OnlySequels, 2, false) ? GetValidSequel(out leaderError) : GetLatestRelease());
		if (softwareProduct == null)
		{
			LastDesignError = null;
			if (leaderError != null && Items.Count == 0)
			{
				LastDesignError = leaderError;
				if (!WorkIssueNotification.CheckAggregate(this, WorkIssueNotification.Issue.LeadDesignerAutoError))
				{
					NotificationManager.AddNotification(new WorkIssueNotification(WorkIssueNotification.Issue.LeadDesignerAutoError, this));
				}
			}
			if (PastReleases.Count == 0 && Items.Count == 0)
			{
				if (!NotificationManager.CheckAggregate<AutoDevAssignNotification>(this))
				{
					NotificationManager.AddNotification(new AutoDevAssignNotification(this));
				}
			}
			else
			{
				NotificationManager.RemoveAggregate<AutoDevAssignNotification>(this);
			}
			return null;
		}
		LastDesignError = null;
		NotificationManager.RemoveAggregate<AutoDevAssignNotification>(this);
		SoftwareType type = softwareProduct.Type;
		SoftwareCategory category = softwareProduct.Category;
		SoftwareProduct softwareProduct2 = (GetSpecValue(OnlySequels, 2, false) ? softwareProduct : null);
		double budget = GameSettings.Instance.MyCompany.Money * 0.25;
		Dictionary<string, SoftwareProduct> needs = GetNeeds(ref budget, softwareProduct);
		SoftwareFramework framework = (GetSpecValue(UseFrameworks, 2, false) ? SimulatedCompany.FindFramework(GameSettings.Instance.MyCompany, category, SDateTime.Now()) : null);
		bool subscriptionBased = softwareProduct.SubscriptionBased;
		if (needs != null)
		{
			bool oSSpecific = type.OSSpecific;
			List<SoftwareProduct> oSs = GetOSs(needs, softwareProduct.SWType, UseOwnLicenses);
			if ((oSs != null || !oSSpecific) && !type.ForceIssueBool(category.Name, needs, oSs))
			{
				SoftwareProduct[] os = (oSSpecific ? oSs.ToArray() : null);
				Dictionary<string, TechLevel> dictionary = SimulatedCompany.PickTechs(category, SDateTime.Now(), needs, framework, GameSettings.Instance.MyCompany);
				if (dictionary == null)
				{
					return null;
				}
				double[] array = ((softwareProduct2 != null) ? softwareProduct2.Submarkets.ToArray() : SimulatedCompany.PickMarketFocus(category, 0.95f, SDateTime.Now()));
				FeatureBase[] array2 = type.GenerateFeatures(1f, category, needs, dictionary, type.GetValidSpecs(oSs), SDateTime.Now(), array, Utilities.RNG, MainServer != null);
				if (array2 == null)
				{
					return null;
				}
				string[] needs2 = type.GetNeeds(array2, category.Name);
				needs = needs2.ToDictionary((string x) => x, (string x) => needs[x]);
				TechLevel.CleanTechLevels(dictionary, array2);
				DesignDocument designDocument = DesignDocument.CreateWork((softwareProduct2 != null) ? GameSettings.Instance.simulation.GenerateProductSequalName(softwareProduct.Name) : GameSettings.Instance.simulation.GenerateProductName(category, Utilities.RNG), type, category, needs, os, SimulatedCompany.PickPrice(type, category, subscriptionBased, array2, dictionary, 1f), subscriptionBased, array, SDateTime.Now(), GameSettings.Instance.MyCompany, softwareProduct2, softwareProduct.InHouse, 0.0, array2, dictionary, null, MainServer, SCMServer, framework, null, needs.Values.ToList(), false);
				LastLicensePaid = 0f;
				designDocument.Hidden = true;
				List<AddOnProduct> list = null;
				{
					foreach (SoftwareAddOn item in from x in type.GetValidAddons(category, dictionary, array2, SDateTime.Now())
						where x.Forced.HasValue
						select x)
					{
						if (addons == null)
						{
							addons = new List<SoftwareWorkItem>();
						}
						List<AddOnFeature> list2 = new List<AddOnFeature>();
						List<uint> list3 = new List<uint>();
						item.GenerateFeatures(array2, dictionary, array, category, Utilities.RNG, list2, list3);
						HashSet<string> specs = list2.Select((AddOnFeature x) => x.Spec).Distinct().ToHashSet();
						Dictionary<string, SoftwareProduct> dictionary2 = (from x in array2.OfType<SpecFeature>()
							where specs.Contains(x.Spec)
							select x).SelectMany((SpecFeature x) => x.Dependencies).Distinct().ToDictionary((string x) => x, (string x) => needs[x]);
						DesignDocument designDocument2 = new DesignDocument(MarketSimulation.Active.GenerateAddonName(null, softwareProduct2, item, true, Utilities.RNG), item, category, dictionary2, (float)((double)GameSettings.Instance.simulation.GetIdealMarketPrice(item) * item.PerceivedValue(list2, list3, category, dictionary)), SDateTime.Now(), GameSettings.Instance.MyCompany, null, designDocument, 0.0, list2.ToArray(), list3.ToArray(), SCMServer, dictionary2.Select((KeyValuePair<string, SoftwareProduct> x) => x.Value).ToList(), false);
						designDocument2.Hidden = true;
						designDocument2.AutoDev = true;
						GameSettings.Instance.MyCompany.AddWorkItem(designDocument2);
						if (list == null)
						{
							list = new List<AddOnProduct>();
						}
						addons.Add(designDocument2);
					}
					return designDocument;
				}
			}
		}
		return null;
	}

	public Dictionary<string, SoftwareProduct> GetNeeds(ref double budget, SoftwareProduct proto)
	{
		SDateTime time = SDateTime.Now();
		Dictionary<string, List<string>> needsWithSpecs = proto.Type.GetNeedsWithSpecs(proto.Category.Name);
		double num = budget;
		Dictionary<string, SoftwareProduct> dictionary = new Dictionary<string, SoftwareProduct>();
		int num2 = needsWithSpecs.Count + (proto.Type.OSSpecific ? 2 : 0);
		List<SoftwareProduct> list = new List<SoftwareProduct>();
		foreach (KeyValuePair<string, List<string>> item in needsWithSpecs)
		{
			double localBudget = budget;
			string localNeed = item.Key;
			int i1 = num2;
			GameSettings.Instance.simulation.GetAllProducts(false).GetSecondaryWhere((SoftwareProduct x) => x.Type.Name.Equals(localNeed) && (double)x.GetLicenseCost(true) <= localBudget / (double)i1, (SoftwareProduct x) => SDateTime.GetMonths(x.Release, SDateTime.Now()) < 60f, list);
			List<string> spec = item.Value;
			if (list.Count <= 0)
			{
				continue;
			}
			SoftwareProduct softwareProduct = list.MaxInstance((SoftwareProduct x) => (double)((!UseOwnLicenses) ? 1f : (x.DevCompany.IsLocalPlayer ? 1f : 0.001f)) * ((double)spec.SumSafe((string s) => x.TechLevels.GetOrDefault(s, (TechLevel z) => z.ActualYear, 0)) + x.RelativeFeatureScore(MarketSimulation.Active, time) + (double)(Utilities.RandomValue * 0.05f)));
			num -= (double)softwareProduct.GetLicenseCost(true);
			dictionary.Add(item.Key, softwareProduct);
			num2--;
		}
		budget = num;
		return dictionary;
	}

	public static SoftwareProduct GetNeed(string spec, string swType, TechLevel tech, bool ownLicenses)
	{
		SDateTime time = SDateTime.Now();
		List<SoftwareProduct> list = GameSettings.Instance.simulation.GetAllProducts(false).Where(delegate(SoftwareProduct x)
		{
			if (x.Type.Name.Equals(swType))
			{
				TechLevel orDefault = x.TechLevels.GetOrDefault(spec);
				return ((orDefault != null) ? new int?(orDefault.Year) : ((int?)null)) >= tech.Year;
			}
			return false;
		}).ToList();
		if (list.Count > 0)
		{
			return list.MaxInstance((SoftwareProduct x) => (double)((!ownLicenses) ? 1f : (x.DevCompany.IsLocalPlayer ? 1f : 0.001f)) * (x.RelativeFeatureScore(MarketSimulation.Active, time) + (double)(Utilities.RandomValue * 0.05f)));
		}
		return null;
	}

	public static List<SoftwareProduct> GetOSs(Dictionary<string, SoftwareProduct> needs, SoftwareType type, bool useOwnLicenses)
	{
		if (!type.OSSpecific)
		{
			return null;
		}
		SDateTime time = SDateTime.Now();
		List<SoftwareProduct> secondaryWhere = GameSettings.Instance.simulation.GetAllProducts(false).GetSecondaryWhere((SoftwareProduct x) => "Operating System".Equals(x.Type.Name) && type.SupportsOS(x.Category.Name), (SoftwareProduct x) => (time - x.Release).Year < 5);
		List<SoftwareProduct> list = new List<SoftwareProduct>();
		int num = 0;
		double maxFeat = 0.0;
		foreach (KeyValuePair<string, SoftwareCategory> category in MarketSimulation.Active.SoftwareTypes["Operating System"].Categories)
		{
			maxFeat = Math.Max(maxFeat, GameSettings.Instance.simulation.GetFeatureScore(category.Value, time));
		}
		foreach (SoftwareProduct item in secondaryWhere.OrderBy(delegate(SoftwareProduct x)
		{
			if (!useOwnLicenses)
			{
				return 0;
			}
			return (!x.DevCompany.IsLocalPlayer) ? 1 : 0;
		}).ThenByDescending((SoftwareProduct x) => (double)x.Userbase * (x.PerceivedValue(time) / maxFeat)))
		{
			list.Add(item);
			num++;
			if (num == 3)
			{
				break;
			}
		}
		if (list.Count != 0)
		{
			return list;
		}
		return null;
	}

	public override void Kill(bool wasCancelled = false)
	{
		NotificationManager.RemoveAggregate<AutoDevAssignNotification>(this);
		Leader = null;
		Items.OnChange = null;
		for (int num = Items.Count - 1; num > -1; num--)
		{
			((WorkItem)(((object)Items[num].Alpha) ?? ((object)Items[num].Document))).Kill(false);
		}
		foreach (MarketingPlan marketingItem in MarketingItems)
		{
			marketingItem.AutoDev = false;
			marketingItem.Hidden = false;
		}
		foreach (SupportWork supportItem in SupportItems)
		{
			supportItem.AutoDev = false;
			supportItem.Hidden = false;
		}
		foreach (KeyValuePair<SoftwareUpdate, SDateTime> updateTask in UpdateTasks)
		{
			updateTask.Key.AutoDev = false;
			updateTask.Key.Hidden = false;
		}
		foreach (SoftwarePort portingItem in PortingItems)
		{
			portingItem.AutoDev = false;
			portingItem.Hidden = false;
		}
		if (HUD.Instance.AutoDevWindow.Window.Shown && HUD.Instance.AutoDevWindow.Work == this)
		{
			HUD.Instance.AutoDevWindow.Window.Close();
		}
		base.Kill(wasCancelled);
	}

	public override string CurrentStage()
	{
		return "Designing".Loc() + ": " + (LastDesign ?? "None".Loc()) + "\n" + "Developing".Loc() + ": " + GetAlphaWork();
	}

	private string GetAlphaWork()
	{
		if (LastAlpha != null && LastAlpha2 != null)
		{
			return "Product".LocPlural(2);
		}
		if (LastAlpha != null)
		{
			return LastAlpha;
		}
		if (LastAlpha2 != null)
		{
			return LastAlpha2;
		}
		return "None".Loc();
	}

	public override int GUIWorkItemType()
	{
		return 1;
	}

	public override string Category()
	{
		return "Nextrelease".Loc() + ": " + (NextReleaseDate.HasValue ? NextReleaseDate.Value.ToCompactString() : "None".Loc());
	}

	public void OpenOptions()
	{
		HUD.Instance.AutoDevWindow.Show(this);
	}

	public int GetActiveProjectCount()
	{
		_pCache.Clear();
		for (int i = 0; i < Items.Count; i++)
		{
			if (!Items[i].Queued)
			{
				_pCache.Add(Items[i].SWWorkItem.GetSubjectName());
			}
		}
		for (int j = 0; j < MarketingItems.Count; j++)
		{
			_pCache.Add(MarketingItems[j].GetSubjectName());
		}
		for (int k = 0; k < SupportItems.Count; k++)
		{
			_pCache.Add(SupportItems[k].GetSubjectName());
		}
		foreach (SoftwareUpdate key in UpdateTasks.Keys)
		{
			_pCache.Add(key.GetSubjectName());
		}
		for (int l = 0; l < PortingItems.Count; l++)
		{
			_pCache.Add(PortingItems[l].GetSubjectName());
		}
		int count = _pCache.Count;
		_pCache.Clear();
		return count;
	}

	public override float StressMultiplier()
	{
		return (float)GetActiveProjectCount() * 0.5f;
	}

	public override string GetWorkTypeName()
	{
		return "Project management";
	}

	public override string GetTeam(Text Label = null)
	{
		if (!(Leader == null))
		{
			return Leader.employee.FullName;
		}
		return null;
	}

	public override string GetSubjectName()
	{
		return base.Name;
	}

	public override bool IsLeaderTask()
	{
		return true;
	}

	public override float GetProgress()
	{
		return Mathf.Clamp01(LastEffectiveness);
	}

	public override Color GetProgressColor()
	{
		return Color.Lerp(HUD.GetThemeColor(2), base.GetProgressColor(), Mathf.Clamp01(LastEffectiveness));
	}
}
