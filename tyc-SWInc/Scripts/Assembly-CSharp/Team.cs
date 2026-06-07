using System;
using System.Collections.Generic;
using System.Linq;
using Tyd;
using UnityEngine;

public class Team : IFormatColorObject, IBenefitReceiver
{
	public enum MeetingStatus
	{
		OK = 0,
		NoLeader = 1,
		LowSpec = 2,
		NoPlace = 3,
		Blocked = 4,
		Waiting = 5
	}

	public string Name;

	public Color TeamColor = Color.white;

	public int VacationMonth = 6;

	public int VacationSpread = 1;

	public int MaxTasks;

	private List<Actor> Employees = new List<Actor>();

	public HashSet<string> SecondaryTasks = new HashSet<string>();

	private Actor _leader;

	public int WorkStart = 8;

	public int WorkEnd = 16;

	public TableScript MeetingTable;

	public List<Actor> Meeting = new List<Actor>();

	public Actor Talking;

	public List<WorkItem> WorkItems = new List<WorkItem>();

	public Dictionary<string, float> Benefits = new Dictionary<string, float>();

	private float compatibility = -1f;

	private float _minCompatibility = 1f;

	private float _cohesion;

	private bool _cohesionDirty = true;

	public HRManagement HR = new HRManagement
	{
		AfterRoleSplit = true,
		InitRoleSystem = false
	};

	public bool CrunchMode;

	public Dictionary<string, SDateTime> LastAssigned = new Dictionary<string, SDateTime>();

	private MeetingStatus _status;

	private static List<WorkItem> _taskCompTemp = new List<WorkItem>();

	[NonSerialized]
	private bool _disableTaskCompRefresh;

	[NonSerialized]
	public bool DisableCompatibilityUpdate;

	private static Dictionary<uint, WorkItem> _serializationCache = new Dictionary<uint, WorkItem>();

	public Actor Leader
	{
		get
		{
			return _leader;
		}
		set
		{
			if (_leader != value && MeetingTable != null)
			{
				MeetingTable.ReserveTables(false);
				MeetingTable = null;
				Meeting.Clear();
			}
			_leader = value;
		}
	}

	public int WorkHours
	{
		get
		{
			if (WorkStart <= WorkEnd)
			{
				return WorkEnd - WorkStart;
			}
			return 24 - WorkStart + WorkEnd;
		}
	}

	public float Cohesion
	{
		get
		{
			if (_cohesionDirty)
			{
				_cohesionDirty = false;
				_cohesion = 0f;
				if (Employees.Count > 0)
				{
					int num = 0;
					for (int i = 0; i < Employees.Count; i++)
					{
						for (int j = i + 1; j < Employees.Count; j++)
						{
							_cohesion += Mathf.Min(1f, Employee.GetFriendship(Employees[i].employee, Employees[j].employee));
							num++;
						}
					}
					if (num > 0)
					{
						_cohesion /= num;
					}
				}
			}
			return _cohesion;
		}
	}

	public float Compatibility
	{
		get
		{
			if (Employees.Count == 0 || GameSettings.Instance.IsReferenceNull())
			{
				return -1f;
			}
			if (compatibility == -1f)
			{
				CalculateCompatibility();
			}
			float num = compatibility;
			if (Leader != null && Employees.Count > 1)
			{
				num *= Leader.employee.ModTrait(Employee.Trait.BornLeader, 1.5f);
				if (Leader.employee.GetSpecialization(Employee.EmployeeRole.Lead, "Socialization") > 0 && num < 1f)
				{
					num = Mathf.Lerp(num, 1f, Leader.employee.GetSkill(Employee.EmployeeRole.Lead));
				}
			}
			return num;
		}
	}

	public float MinCompatibility
	{
		get
		{
			if (Employees.Count == 0 || GameSettings.Instance.IsReferenceNull())
			{
				return 1f;
			}
			if (compatibility == -1f)
			{
				CalculateCompatibility();
			}
			return _minCompatibility;
		}
	}

	public int Count
	{
		get
		{
			return Employees.Count;
		}
	}

	public void SetCohesionDirty()
	{
		_cohesionDirty = true;
		compatibility = -1f;
	}

	public bool IsTaskCompatible(Team other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		ValueTuple<Team, Team> item = ((other.Name.CompareTo(Name) < 0) ? new ValueTuple<Team, Team>(other, this) : new ValueTuple<Team, Team>(this, other));
		return GameSettings.Instance.TeamTaskComp.Contains(item);
	}

	public bool CompareTasks(Team other)
	{
		if (WorkItems.Count == 0 || other.WorkItems.Count == 0)
		{
			return WorkItems.Count == other.WorkItems.Count;
		}
		_taskCompTemp.Clear();
		_taskCompTemp.AddRange(WorkItems);
		RemoveCompatible(_taskCompTemp, other.WorkItems);
		int count = _taskCompTemp.Count;
		_taskCompTemp.Clear();
		_taskCompTemp.AddRange(other.WorkItems);
		RemoveCompatible(_taskCompTemp, WorkItems);
		int num = count + _taskCompTemp.Count;
		_taskCompTemp.Clear();
		return num <= (WorkItems.Count + other.WorkItems.Count) / 2;
	}

	private void RemoveCompatible(List<WorkItem> target, List<WorkItem> compare)
	{
		for (int i = 0; i < target.Count; i++)
		{
			for (int j = 0; j < compare.Count; j++)
			{
				if (CompatibleProject(target[i], compare[j]))
				{
					target.RemoveAt(i);
					i--;
					break;
				}
			}
		}
	}

	private bool CompatibleProject(WorkItem a, WorkItem b)
	{
		if (a == b)
		{
			return true;
		}
		if ((a is SoftwareWorkItem || a is MarketingPlan || a is SupportWork || a is ReviewWork || a is SoftwarePort) && (b is SoftwareWorkItem || b is MarketingPlan || b is SupportWork || b is ReviewWork || b is SoftwarePort))
		{
			string groupProject = a.GetGroupProject();
			if (groupProject != null)
			{
				return groupProject.Equals(b.GetGroupProject());
			}
			return false;
		}
		return false;
	}

	public void AddWork(WorkItem item)
	{
		if (!WorkItems.Contains(item))
		{
			WorkItems.Add(item);
			HR.TasksChanged = true;
			OrderTasks();
			RefreshTaskCompatibility(false);
		}
	}

	public void RemoveWork(WorkItem item)
	{
		if (WorkItems.RemoveAll((WorkItem x) => x == item) > 0)
		{
			HR.TasksChanged = true;
			RefreshTaskCompatibility(false);
		}
	}

	public void ClearTaskCompatibilities()
	{
		GameSettings.Instance.TeamTaskComp.RemoveAll((ValueTuple<Team, Team> x) => x.Item1 == this || x.Item2 == this);
	}

	public void PauseTaskCompRefresh(bool pause = true)
	{
		_disableTaskCompRefresh = pause;
	}

	public void RefreshTaskCompatibility(bool force = true)
	{
		if (!force && _disableTaskCompRefresh)
		{
			return;
		}
		_disableTaskCompRefresh = false;
		ClearTaskCompatibilities();
		foreach (Team value in GameSettings.Instance.sActorManager.Teams.Values)
		{
			if (value != this && CompareTasks(value))
			{
				GameSettings.Instance.TeamTaskComp.Add((value.Name.CompareTo(Name) < 0) ? new ValueTuple<Team, Team>(value, this) : new ValueTuple<Team, Team>(this, value));
			}
		}
	}

	public void OrderTasks()
	{
		if (MaxTasks > 0)
		{
			WorkItems.Sort((WorkItem x, WorkItem y) => x.SiblingIndex.CompareTo(y.SiblingIndex));
			Employees.ForEach(delegate(Actor x)
			{
				x.CurrentWorkItem = 0;
			});
		}
	}

	public void SetMeetingStatus(MeetingStatus status)
	{
		_status = status;
	}

	public MeetingStatus GetMeetingStatus()
	{
		if (Leader == null)
		{
			_status = MeetingStatus.NoLeader;
		}
		else if (Leader.employee.GetSpecialization(Employee.EmployeeRole.Lead, "Socialization") < 3)
		{
			_status = MeetingStatus.LowSpec;
		}
		else if (_status == MeetingStatus.LowSpec || _status == MeetingStatus.NoLeader)
		{
			_status = MeetingStatus.OK;
		}
		if (_status == MeetingStatus.OK && MeetingTable == null)
		{
			return MeetingStatus.Waiting;
		}
		return _status;
	}

	public string GetMeetingStatusLoc()
	{
		return ("MeetingStatus" + GetMeetingStatus()).Loc();
	}

	public int GetHRLevel()
	{
		if (!(Leader != null))
		{
			return 0;
		}
		return Leader.employee.GetSpecialization(Employee.EmployeeRole.Lead, "HR");
	}

	public bool CheckHRLevel(int minLvl)
	{
		return GetHRLevel() >= minLvl;
	}

	public TydTable SerializeTyd()
	{
		TydTable tydTable = new TydTable(null);
		tydTable["Name"] = Name;
		tydTable["Color"] = "#" + ColorUtility.ToHtmlStringRGB(TeamColor);
		tydTable["VacationMonth"] = VacationMonth.ToString();
		tydTable["VacationSpread"] = VacationSpread.ToString();
		tydTable["WorkStart"] = WorkStart.ToString();
		tydTable["WorkEnd"] = WorkEnd.ToString();
		tydTable["MaxTasks"] = MaxTasks.ToString();
		tydTable.AddChild(new TydList("SecondaryTasks", SecondaryTasks.ToArray()));
		tydTable.AddChild(HR.Serialize());
		if (Benefits.Count > 0)
		{
			TydList node = new TydList("Benefits", Benefits.Select((KeyValuePair<string, float> x) => x.Key + " = " + x.Value).ToArray());
			tydTable.AddChild(node);
		}
		return tydTable;
	}

	public static Team DeserializeTyd(string name, TydTable t)
	{
		Team team = new Team(name);
		ColorUtility.TryParseHtmlString(t["Color"], out team.TeamColor);
		team.VacationMonth = t.GetChildValue("VacationMonth", true, 0);
		team.VacationSpread = t.GetChildValue("VacationSpread", true, 0);
		team.WorkStart = t.GetChildValue("WorkStart", true, 0);
		team.WorkEnd = t.GetChildValue("WorkEnd", true, 0);
		team.MaxTasks = t.GetChildValue("MaxTasks", true, 0);
		team.SecondaryTasks = t.GetChild<TydList>("SecondaryTasks").GetChildValues().ToHashSet();
		team.HR = HRManagement.Deserialize(t.GetChild<TydTable>("HR"));
		TydList child = t.GetChild<TydList>("Benefits");
		if (child != null)
		{
			team.Benefits = (from x in child.GetChildValues()
				select x.Split(new string[1] { " = " }, StringSplitOptions.RemoveEmptyEntries)).ToDictionary((string[] x) => x[0], (string[] x) => x[1].ConvertToFloatDef(0f));
		}
		return team;
	}

	public Team(string name, bool first = false)
	{
		Name = name;
		Color teamColor;
		if (!first)
		{
			ActorManager sActorManager = GameSettings.Instance.sActorManager;
			teamColor = ServerGroup.CreateColor((sActorManager != null) ? sActorManager.Teams.Values.Select((Team x) => x.TeamColor) : null, 0.2f);
		}
		else
		{
			teamColor = Utilities.HSVToRGBA(0.6f, 0.2f, 1f);
		}
		TeamColor = teamColor;
		CalendarWindow.ScheduleRefresh = true;
	}

	public Team(Team old, string name, bool rename)
	{
		Name = name;
		TeamColor = old.TeamColor;
		HR = (rename ? old.HR : new HRManagement(old.HR));
		WorkEnd = old.WorkEnd;
		WorkStart = old.WorkStart;
		if (rename)
		{
			Talking = old.Talking;
			Meeting = old.Meeting;
			CrunchMode = old.CrunchMode;
			MeetingTable = old.MeetingTable;
			SecondaryTasks = old.SecondaryTasks;
		}
		else
		{
			SecondaryTasks = old.SecondaryTasks.ToHashSet();
		}
		VacationMonth = old.VacationMonth;
		VacationSpread = old.VacationSpread;
		MaxTasks = old.MaxTasks;
		Benefits = old.Benefits.ToDictionary();
		CalendarWindow.ScheduleRefresh = true;
	}

	public override string ToString()
	{
		return Name;
	}

	public string GetActualString()
	{
		return Name;
	}

	public int GetNextVacation(Actor emp)
	{
		if (VacationSpread == 0)
		{
			return VacationMonth;
		}
		int num = Employees.IndexOf(emp);
		return (VacationMonth + num % (VacationSpread + 1)) % 12;
	}

	public void CalculateCompatibility()
	{
		if (DisableCompatibilityUpdate)
		{
			return;
		}
		Employees.RemoveAll((Actor x) => x == null);
		if (Employees.Count == 0)
		{
			compatibility = -1f;
			_minCompatibility = 1f;
			return;
		}
		if (Employees.Count == 1)
		{
			Employees[0].TeamCompatibility = 1f;
			compatibility = 1f;
			_minCompatibility = 1f;
			return;
		}
		float[] array = new float[Employees.Count];
		_minCompatibility = float.MaxValue;
		for (int num = 0; num < Employees.Count; num++)
		{
			for (int num2 = num + 1; num2 < Employees.Count; num2++)
			{
				float a = Employees[num].employee.Compatibility(Employees[num2].employee, false);
				_minCompatibility = Mathf.Min(a, _minCompatibility);
				a = Employees[num].employee.ModifyCompatibilityWithFriendship(Employees[num2].employee, a);
				array[num] += a;
				array[num2] += a;
			}
		}
		float num3 = 0f;
		for (int num4 = 0; num4 < Employees.Count; num4++)
		{
			Employees[num4].TeamCompatibility = array[num4] / (float)(Employees.Count - 1);
			num3 += Employees[num4].TeamCompatibility;
		}
		compatibility = num3 / (float)Employees.Count;
		if (Compatibility < 0.25f && !NotificationManager.CheckAggregate<LowCompatNotification>(this))
		{
			NotificationManager.AddNotification(new LowCompatNotification(this));
		}
	}

	public void AddEmployee(Actor actor, bool isRename)
	{
		if (Employees.Contains(actor))
		{
			return;
		}
		if (isRename)
		{
			Employees.Add(actor);
			return;
		}
		if (actor.employee.IsRole(Employee.RoleBit.Lead))
		{
			if (Leader == null)
			{
				Leader = actor;
			}
			else
			{
				actor.employee.ChangeToNaturalRole(false);
			}
		}
		Employees.Add(actor);
		CalculateCompatibility();
		for (int i = 0; i < WorkItems.Count; i++)
		{
			SoftwareWorkItem softwareWorkItem;
			if ((softwareWorkItem = WorkItems[i] as SoftwareWorkItem) != null)
			{
				softwareWorkItem.UpdateWorking();
			}
		}
		GameSettings.Instance.CheckOSLicenses = true;
		_cohesionDirty = true;
	}

	public void RemoveEmployee(Actor actor, bool isRename)
	{
		if (isRename)
		{
			Employees.Remove(actor);
			return;
		}
		if (actor == Leader)
		{
			Leader = null;
		}
		actor.TeamCompatibility = -1f;
		Employees.Remove(actor);
		CalculateCompatibility();
		for (int i = 0; i < WorkItems.Count; i++)
		{
			SoftwareWorkItem softwareWorkItem;
			if ((softwareWorkItem = WorkItems[i] as SoftwareWorkItem) != null)
			{
				softwareWorkItem.UpdateWorking();
				DesignDocument designDocument;
				if ((designDocument = softwareWorkItem as DesignDocument) != null && designDocument.LeadDesigner == actor.employee)
				{
					designDocument.ResetLeadDesigner();
				}
			}
		}
		if (HUD.Instance != null && HUD.Instance.docWindow.Window.Shown && HUD.Instance.docWindow.LeadDesigner.CurrentEmployee == actor.employee)
		{
			HUD.Instance.docWindow.PickBestLead(true);
		}
		GameSettings.Instance.CheckOSLicenses = true;
		_cohesionDirty = true;
	}

	public bool HasEmployee(Actor actor)
	{
		return Employees.Contains(actor);
	}

	public Actor[] GetEmployees()
	{
		return Employees.ToArray();
	}

	public List<Actor> GetEmployeesDirect()
	{
		return Employees;
	}

	private static void InitCache(IEnumerable<WorkItem> ws)
	{
		foreach (WorkItem w in ws)
		{
			_serializationCache[w.ID] = w;
		}
	}

	public void Deserialize(WriteDictionary dictionary)
	{
		Name = (string)dictionary["Name"];
		uint[] source = (uint[])dictionary["Employees"];
		VacationMonth = dictionary.Get("VacationMonth", 6);
		VacationSpread = dictionary.Get("VacationSpread", 1);
		Employees = (from x in source.Distinct()
			select Writeable.STGetDeserializedObject(x) as Actor into x
			where x != null && x.gameObject != null
			select x).ToList();
		Employees.ForEach(delegate(Actor x)
		{
			x.SetTeamDeserialize(this);
		});
		Leader = Writeable.STGetDeserializedObject(dictionary.Get("Leader", 0u)) as Actor;
		Talking = Writeable.STGetDeserializedObject(dictionary.Get("Talking", 0u)) as Actor;
		WorkStart = (int)dictionary["WorkStart"];
		WorkEnd = (int)dictionary["WorkEnd"];
		CrunchMode = dictionary.Get("CrunchMode", false);
		SecondaryTasks = dictionary.Get("SecondaryTasks", Array.Empty<string>()).ToHashSet();
		LastAssigned = dictionary.Get("LastAssigned", Array.Empty<KeyValuePair<string, SDateTime>>()).ToDictionary();
		Benefits = dictionary.Get("Benefits", Benefits);
		Color color;
		ColorUtility.TryParseHtmlString("#" + dictionary.Get("TeamColor", "FFFFFF"), out color);
		TeamColor = color;
		object obj = Writeable.STGetDeserializedObject(dictionary.Get("MeetingTable", 0u));
		if (obj != null)
		{
			MeetingTable = ((Furniture)obj).GetComponent<TableScript>();
		}
		source = (uint[])dictionary["Meeting"];
		Meeting = source.Select((uint x) => (Actor)Writeable.STGetDeserializedObject(x)).ToList();
		uint[] array = dictionary.Get("workItems", Array.Empty<uint>());
		_serializationCache.Clear();
		InitCache(GameSettings.Instance.MyCompany.WorkItems);
		for (int num = 0; num < array.Length; num++)
		{
			WorkItem value;
			if (_serializationCache.TryGetValue(array[num], out value))
			{
				WorkItems.Add(value);
				_serializationCache.Remove(array[num]);
			}
		}
		_serializationCache.Clear();
		GameSettings.Instance.sRoomManager.Rooms.ForEach(delegate(Room x)
		{
			if (x.TempTeam != null && x.TempTeam.Contains(Name))
			{
				x.AddTeam(this);
			}
		});
		HR = dictionary.Get("HR", new HRManagement
		{
			AfterRoleSplit = true
		});
		HR.InitRoleSetup(HR.ForceRole, false);
		CalculateCompatibility();
		_status = dictionary.Get("MeetingStatus", GetMeetingStatus());
		MaxTasks = dictionary.Get("MaxTasks", 0);
	}

	public float GetCompatibility(Employee employee)
	{
		float num = 0f;
		bool flag = false;
		for (int i = 0; i < Employees.Count; i++)
		{
			if (Employees[i].employee != employee)
			{
				flag = true;
				num += Employees[i].employee.Compatibility(employee);
			}
		}
		if (!flag)
		{
			return 1f;
		}
		return num / (float)Employees.Count;
	}

	public float GetMinCompatibility(Employee employee)
	{
		float num = 2f;
		bool flag = false;
		for (int i = 0; i < Employees.Count; i++)
		{
			if (Employees[i].employee != employee)
			{
				flag = true;
				num = Mathf.Min(num, Employees[i].employee.Compatibility(employee));
			}
		}
		if (!flag)
		{
			return 1f;
		}
		return num;
	}

	public WriteDictionary Serialize()
	{
		WriteDictionary writeDictionary = new WriteDictionary("Team");
		writeDictionary["Name"] = Name;
		writeDictionary["Employees"] = Employees.WhereSelect((Actor x) => x != null && x.gameObject != null, (Actor x) => x.DID).ToArray();
		writeDictionary["Leader"] = ((Leader != null) ? Leader.DID : 0u);
		writeDictionary["WorkStart"] = WorkStart;
		writeDictionary["WorkEnd"] = WorkEnd;
		writeDictionary["MeetingTable"] = ((MeetingTable != null) ? MeetingTable.FurnComp.DID : 0u);
		writeDictionary["Meeting"] = Meeting.WhereSelect((Actor x) => x != null && x.gameObject != null, (Actor x) => x.DID).ToArray();
		writeDictionary["Talking"] = ((Talking != null) ? Talking.DID : 0u);
		writeDictionary["workItems"] = ((WorkItems != null) ? WorkItems.Select((WorkItem x) => x.ID).ToArray() : null);
		writeDictionary["HR"] = HR;
		writeDictionary["VacationMonth"] = VacationMonth;
		writeDictionary["VacationSpread"] = VacationSpread;
		writeDictionary["CrunchMode"] = CrunchMode;
		writeDictionary["SecondaryTasks"] = SecondaryTasks.ToArray();
		writeDictionary["LastAssigned"] = LastAssigned.ToArray();
		writeDictionary["TeamColor"] = ColorUtility.ToHtmlStringRGB(TeamColor);
		writeDictionary["MeetingStatus"] = _status;
		writeDictionary["MaxTasks"] = MaxTasks;
		writeDictionary["Benefits"] = Benefits;
		return writeDictionary;
	}

	public static string GetCompatDesc(float compat)
	{
		int num = Mathf.FloorToInt(Mathf.Clamp(compat, 0f, 2f) / 2f * 6f) + 1;
		return ("TeamCompat" + num).Loc();
	}

	public int[] CountRoles(int[] r = null, bool hiredFor = true)
	{
		r = r ?? new int[5];
		for (int i = 0; i < Employees.Count; i++)
		{
			Actor actor = Employees[i];
			if (hiredFor)
			{
				if (actor.employee.IsRole(Employee.RoleBit.Lead))
				{
					r[0]++;
				}
				else
				{
					r[(int)actor.employee.HiredFor]++;
				}
				continue;
			}
			for (int j = 0; j < 5; j++)
			{
				if (actor.employee.IsRoleIndex(j))
				{
					r[j]++;
				}
			}
		}
		return r;
	}

	public int[] CountDesignDev()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < Employees.Count; i++)
		{
			Actor actor = Employees[i];
			if (actor.employee.IsRole(Employee.RoleBit.Designer))
			{
				num++;
			}
			if (actor.employee.IsRole(Employee.RoleBit.Programmer | Employee.RoleBit.Artist))
			{
				num2++;
			}
		}
		return new int[2] { num, num2 };
	}

	public void RescheduleVacations()
	{
		foreach (Actor employee in Employees)
		{
			employee.ScheduleVacation(false);
		}
		CalendarWindow.ScheduleRefresh = true;
	}

	public void ChangeWorkStart(int value)
	{
		if (value == WorkStart)
		{
			return;
		}
		SDateTime sDateTime = SDateTime.Now();
		for (int i = 0; i < Employees.Count; i++)
		{
			Actor actor = Employees[i];
			if (actor.isActiveAndEnabled)
			{
				continue;
			}
			SDateTime? arriveTime = GameSettings.Instance.sActorManager.GetArriveTime(actor);
			if (arriveTime.HasValue)
			{
				SDateTime value2 = arriveTime.Value;
				int num = value2.Hour - WorkStart;
				SDateTime sDateTime2 = value2.ChangeHour(value + num);
				if (sDateTime2 < sDateTime)
				{
					sDateTime2 += ((GameSettings.DaysPerMonth > 1) ? SDateTime.GetDay(1) : SDateTime.GetMonth(1));
				}
				GameSettings.Instance.sActorManager.AddToAwaiting(actor, sDateTime2, true);
			}
		}
		WorkStart = value;
		CalendarWindow.ScheduleRefresh = true;
	}

	public void ChangeWorkEnd(int value)
	{
		if (value == WorkEnd)
		{
			return;
		}
		int num = ((WorkStart > value) ? (24 - WorkStart + value) : (value - WorkStart));
		for (int i = 0; i < Employees.Count; i++)
		{
			Actor actor = Employees[i];
			if (actor.isActiveAndEnabled && !actor.GoHomeNow)
			{
				int num2 = Mathf.RoundToInt(SDateTime.GetHours(actor.MeetingTime, actor.LeaveTime));
				if (num <= 8 || num < num2)
				{
					actor.LeaveTime += SDateTime.GetHour(num - num2);
				}
			}
		}
		WorkEnd = value;
		CalendarWindow.ScheduleRefresh = true;
	}

	public Actor GetBestLeadDesigner(out float score, SoftwareType type, DesignDocument target, DesignDocument ignore = null)
	{
		Actor result = null;
		score = -100f;
		foreach (Actor employee in Employees)
		{
			if (employee.employee.IsRole(Employee.RoleBit.Designer) && (target == null || target.CompatibleLead(employee.employee)))
			{
				float leadDesignPriority = employee.employee.GetLeadDesignPriority(type, ignore);
				if (leadDesignPriority > score)
				{
					result = employee;
					score = leadDesignPriority;
				}
			}
		}
		return result;
	}

	public Dictionary<string, float> GetBenefits()
	{
		return Benefits;
	}

	public float GetBenefitValue(string benefit, bool ignoreSelf = false)
	{
		return EmployeeBenefit.GetBenefitValue(null, ignoreSelf ? null : this, benefit);
	}

	public void CacheBenefits()
	{
		Employees.ForEach(delegate(Actor x)
		{
			x.CacheBenefits();
		});
	}

	public void ApplyNewBenefits()
	{
		Employees.ForEach(delegate(Actor x)
		{
			x.ApplyNewBenefits();
		});
	}
}
