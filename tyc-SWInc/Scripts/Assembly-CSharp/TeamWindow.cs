using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Tyd;
using UnityEngine;
using UnityEngine.UI;

public class TeamWindow : MonoBehaviour
{
	[Serializable]
	public struct SpecColor
	{
		public string Specialization;

		public Color Color;
	}

	public GUIWindow Window;

	public AutomationWindow autoWindow;

	public GUIListView TeamList;

	public InputField input;

	public InputField ArrTime;

	public InputField DepTime;

	public SpecializationChart chart;

	public GUICombobox MonthCombo;

	public GUICombobox RangeCombo;

	public Toggle CrunchToggle;

	private bool _selectionChanging;

	public Text MeetingStatus;

	public Text MaxTeamLabel;

	public Slider MaxTeamSlider;

	public GameObject SingleTeamPanel;

	public Color[] SkillColor;

	public SpecColor[] ServiceColor;

	[NonSerialized]
	private bool _initialized;

	public void UpdateVacation()
	{
		if (!_selectionChanging)
		{
			Team[] selected = TeamList.GetSelected<Team>();
			foreach (Team obj in selected)
			{
				obj.VacationMonth = MonthCombo.Selected;
				obj.RescheduleVacations();
			}
		}
	}

	public void UpdateMaxTeamSliderLabel()
	{
		MaxTeamLabel.text = ((MaxTeamSlider.value == 0f) ? "∞".FontSize(20f) : MaxTeamSlider.value.ToString());
	}

	public void UpdateVacationRange()
	{
		if (!_selectionChanging)
		{
			Team[] selected = TeamList.GetSelected<Team>();
			foreach (Team obj in selected)
			{
				obj.VacationSpread = RangeCombo.Selected;
				obj.RescheduleVacations();
			}
		}
	}

	public void Disband()
	{
		Team[] sel = TeamList.GetSelected<Team>();
		if (sel.Length == 0)
		{
			return;
		}
		WindowManager.Instance.ShowMessageBox("TeamDisbandConfirmation".Loc(Newspaper.MakeList(sel.SelectInPlace((Team x) => x.Name)), "Team".LocPlural(sel.Length)), true, DialogWindow.DialogType.Warning, delegate
		{
			foreach (Team team in sel)
			{
				GameSettings.Instance.sActorManager.RemoveTeam(team.Name);
			}
			TeamList.ClearSelected();
			TeamList.Items = GameSettings.Instance.sActorManager.Teams.Values.Cast<object>().ToList();
			GameSettings.Instance.sRoomManager.TeamAssignmentDirty = true;
		}, "Disband team");
	}

	public void Rename()
	{
		Team[] selected = TeamList.GetSelected<Team>();
		if (selected.Length == 1)
		{
			Team x = selected[0];
			WindowManager.SpawnInputDialog("Rename".Loc(), "Rename".Loc(), x.Name, delegate(string y)
			{
				GameSettings.Instance.sActorManager.RenameTeam(x.Name, y);
			});
		}
	}

	public void ShowEmployees()
	{
		Team[] selected = TeamList.GetSelected<Team>();
		if (selected.Length != 0)
		{
			HUD.Instance.employeeWindow.Show(selected.ToHashSet());
		}
	}

	private void Update()
	{
		if (TeamList.Selected.Count == 1)
		{
			Team team = TeamList.GetSelectedEnum<Team>().FirstOrDefault();
			if (team != null)
			{
				MeetingStatus.text = "Meeting".Loc() + ": " + team.GetMeetingStatusLoc();
			}
			else
			{
				MeetingStatus.text = "";
			}
		}
		else
		{
			MeetingStatus.text = "";
		}
	}

	public void Init()
	{
		if (_initialized)
		{
			return;
		}
		_initialized = true;
		MonthCombo.UpdateContent(SDateTime.Months);
		RangeCombo.UpdateContent(from x in Enumerable.Range(1, 12)
			select "Month".LocPlural(x));
		UpdateMaxTeamSliderLabel();
		TeamList.Items = GameSettings.Instance.sActorManager.Teams.Values.Cast<object>().ToList();
		TeamList.OnSelectChange = delegate
		{
			Team[] selected = TeamList.GetSelected<Team>();
			chart.SetContent(TeamList.GetSelected<Team>().SelectMany((Team x) => from z in x.GetEmployees()
				select z.employee).ToArray());
			chart.MinSkillTeam = ((selected.Length == 1) ? selected[0] : null);
			_selectionChanging = true;
			UpdateArrDepTime();
			RangeCombo.interactable = selected.Length != 0;
			CrunchToggle.interactable = selected.Length != 0;
			MonthCombo.interactable = selected.Length != 0;
			if (selected.Length != 0)
			{
				MonthCombo.Selected = selected.Mode((Team x) => x.VacationMonth, 0);
				RangeCombo.Selected = selected.Mode((Team x) => x.VacationSpread, 0);
				CrunchToggle.isOn = TeamList.GetSelected<Team>().Mode((Team x) => x.CrunchMode);
			}
			MaxTeamSlider.interactable = selected.Length != 0;
			MaxTeamSlider.value = ((selected.Length != 0) ? selected.Mode((Team x) => x.MaxTasks, 0) : 0);
			_selectionChanging = false;
			SingleTeamPanel.SetActive(TeamList.Selected.Count == 1);
		};
		TeamList.OnDoubleClick = delegate
		{
			Team firstSelected = TeamList.GetFirstSelected<Team>();
			if (firstSelected != null)
			{
				HUD.Instance.employeeWindow.Show(new HashSet<Team> { firstSelected });
			}
		};
	}

	private void Start()
	{
		Init();
	}

	public void UpdateMaxTeam()
	{
		if (!_selectionChanging)
		{
			Team[] selected = TeamList.GetSelected<Team>();
			for (int i = 0; i < selected.Length; i++)
			{
				selected[i].MaxTasks = Mathf.RoundToInt(MaxTeamSlider.value);
				selected[i].OrderTasks();
			}
		}
	}

	public void ToggleCrunch()
	{
		if (!_selectionChanging)
		{
			Team[] selected = TeamList.GetSelected<Team>();
			for (int i = 0; i < selected.Length; i++)
			{
				selected[i].CrunchMode = CrunchToggle.isOn;
			}
		}
	}

	public void FixedUpdate()
	{
		if (TeamList.Selected.Count > 0)
		{
			_selectionChanging = true;
			CrunchToggle.isOn = TeamList.GetSelected<Team>().Mode((Team x) => x.CrunchMode);
			_selectionChanging = false;
		}
	}

	public void AddTeam()
	{
		if (CreateTeam(input.text))
		{
			input.text = "";
		}
	}

	public bool CreateTeam(string teamName)
	{
		if (!teamName.Trim().IsEmpty())
		{
			if (!GameSettings.Instance.sActorManager.Teams.Any((KeyValuePair<string, Team> x) => x.Key.Equals(teamName)))
			{
				Team team = new Team(teamName);
				GameSettings.Instance.sActorManager.Teams.Add(teamName, team);
				GameSettings.Instance.sActorManager.ApplySearchToTeam(team);
				TeamList.Items = GameSettings.Instance.sActorManager.Teams.Values.Cast<object>().ToList();
				GameSettings.Instance.sRoomManager.TeamAssignmentDirty = true;
				return true;
			}
			WindowManager.Instance.ShowMessageBox("TeamNameError".Loc(), false, DialogWindow.DialogType.Error);
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("TeamEmptyNameError".Loc(), false, DialogWindow.DialogType.Error);
		}
		return false;
	}

	private void UpdateArrDepTime()
	{
		Team[] selected = TeamList.GetSelected<Team>();
		int hour = 8;
		int hour2 = 16;
		if (selected.Length != 0)
		{
			hour = selected.Mode((Team x) => x.WorkStart, 0);
			hour2 = selected.Mode((Team x) => x.WorkEnd, 0);
		}
		ArrTime.text = Utilities.HourToTime(hour, SDateTime.AMPM);
		DepTime.text = Utilities.HourToTime(hour2, SDateTime.AMPM);
	}

	public void OpenHR()
	{
		Team[] selected = TeamList.GetSelected<Team>();
		if (selected.Length != 0)
		{
			autoWindow.Show(selected);
		}
	}

	public void ApplyTimes()
	{
		if (_selectionChanging)
		{
			return;
		}
		Team[] selected = TeamList.GetSelected<Team>();
		if (selected.Length != 0)
		{
			int num = ArrTime.text.TimeToHour(8);
			int num2 = DepTime.text.TimeToHour(16);
			if (num == num2)
			{
				num2 = (num2 + 1) % 24;
			}
			Team[] array = selected;
			foreach (Team obj in array)
			{
				obj.ChangeWorkStart(num);
				obj.ChangeWorkEnd(num2);
			}
			UpdateArrDepTime();
		}
	}

	public void ManageRoles()
	{
		Team[] selected = TeamList.GetSelected<Team>();
		if (selected.Length != 0)
		{
			HUD.Instance.roleGrid.Show(selected.SelectMany((Team x) => x.GetEmployeesDirect()));
		}
	}

	private string TaskTitle(WorkItem item)
	{
		if (item.ActiveDeal != null)
		{
			return item.GetSubjectName() + " (" + item.GetDetailedTypeName() + " " + "Deal".Loc() + ")";
		}
		if (item.contract != null)
		{
			return item.GetSubjectName() + " (" + item.GetDetailedTypeName() + " " + "Contract".Loc() + ")";
		}
		return item.GetSubjectName() + " (" + item.GetDetailedTypeName() + ")";
	}

	public void ChangeTasks()
	{
		Team[] sel = TeamList.GetSelected<Team>();
		if (sel.Length == 0)
		{
			return;
		}
		List<WorkItem> tasks = (from x in GameSettings.Instance.MyCompany.WorkItems
			where !x.Done && x.Enabled && !x.AutoDev && !(x is AutoDevWorkItem)
			orderby x.GetWorkTypeName(), x.GetSubjectName()
			select x).ToList();
		bool[] en = tasks.SelectInPlace((WorkItem x) => sel.Any((Team y) => x.DevTeams.Contains(y.Name)));
		WindowManager.Instance.MultiWindow.ShowMulti("Tasks", tasks.Select(TaskTitle), en, delegate(int[] ts)
		{
			for (int i = 0; i < en.Length; i++)
			{
				en[i] = false;
			}
			for (int j = 0; j < ts.Length; j++)
			{
				en[ts[j]] = true;
			}
			foreach (Team team in sel)
			{
				for (int l = 0; l < en.Length; l++)
				{
					WorkItem workItem = tasks[l];
					bool flag = workItem.DevTeams.Contains(team.Name);
					if (en[l] != flag)
					{
						if (en[l])
						{
							workItem.AddDevTeam(team);
						}
						else
						{
							workItem.RemoveDevTeam(team);
						}
						SoftwareWorkItem softwareWorkItem;
						if ((softwareWorkItem = workItem as SoftwareWorkItem) != null)
						{
							softwareWorkItem.CheckCompetency();
						}
					}
				}
			}
		});
	}

	public void SetTaskPriority()
	{
		Team[] sel = TeamList.GetSelected<Team>();
		if (sel.Length == 0)
		{
			return;
		}
		Type typeFromHandle = typeof(WorkItem);
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		List<string> list = new List<string>();
		foreach (Assembly assembly in assemblies)
		{
			try
			{
				Type[] types = assembly.GetTypes();
				foreach (Type type in types)
				{
					if (!type.IsAbstract && type.IsSubclassOf(typeFromHandle) && type != typeof(ReviewWork))
					{
						list.Add(WorkItem.GetWorkTypeName(type));
					}
				}
			}
			catch (Exception)
			{
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		List<KeyValuePair<string, string>> final = (from x in list
			select new KeyValuePair<string, string>(x, (x + "Class").Loc()) into x
			orderby x.Value
			select x).ToList();
		bool[] selected = final.Select((KeyValuePair<string, string> x) => sel.All((Team z) => z.SecondaryTasks.Contains(x.Key))).ToArray();
		WindowManager.Instance.MultiWindow.ShowMulti("Secondary tasks", final.Select((KeyValuePair<string, string> x) => x.Value), selected, delegate(int[] z)
		{
			string[] range = z.SelectInPlace((int x) => final[x].Key);
			foreach (Team obj in sel)
			{
				obj.SecondaryTasks.Clear();
				obj.SecondaryTasks.AddRange(range);
			}
		});
	}

	public void SetColor()
	{
		Team[] sel = TeamList.GetSelected<Team>();
		if (sel.Length == 0)
		{
			return;
		}
		WindowManager.SpawnColorDialog(delegate(Color x)
		{
			sel.ForEachEnum(delegate(Team z)
			{
				z.TeamColor = x;
			});
		}, sel.Mode((Team x) => x.TeamColor), GameSettings.Instance.sActorManager.Teams.Select((KeyValuePair<string, Team> x) => x.Value.TeamColor).ToHashSet());
	}

	public void DuplicateTeam()
	{
		Team t = TeamList.GetFirstSelected<Team>();
		if (t == null)
		{
			return;
		}
		WindowManager.SpawnInputDialog("Teamname".Loc(), "NameChangeTitle".Loc(), "Teamname".Loc(), delegate(string teamName)
		{
			if (!teamName.Trim().IsEmpty())
			{
				if (!GameSettings.Instance.sActorManager.Teams.Any((KeyValuePair<string, Team> x) => x.Key.Equals(teamName)))
				{
					Team team = new Team(t, teamName, false);
					GameSettings.Instance.sActorManager.Teams.Add(teamName, team);
					GameSettings.Instance.sActorManager.ApplySearchToTeam(team);
					HUD.Instance.TeamWindow.TeamList.Items = GameSettings.Instance.sActorManager.Teams.Values.Cast<object>().ToList();
					GameSettings.Instance.sRoomManager.TeamAssignmentDirty = true;
				}
				else
				{
					WindowManager.Instance.ShowMessageBox("TeamNameError".Loc(), false, DialogWindow.DialogType.Error);
				}
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("TeamEmptyNameError".Loc(), false, DialogWindow.DialogType.Error);
			}
		});
	}

	public void AutoColor()
	{
		Team[] selected = TeamList.GetSelected<Team>();
		foreach (Team team in selected)
		{
			Employee.EmployeeRole employeeRole = team.GetEmployeesDirect().Mode((Actor x) => x.employee.GetRoleOrNatural(false), Employee.EmployeeRole.Lead);
			Color c;
			if (employeeRole == Employee.EmployeeRole.Service)
			{
				string[] list = ServiceColor.SelectInPlace((SpecColor x) => x.Specialization);
				List<Actor> emps = (from x in team.GetEmployeesDirect()
					where x.employee.GetRoleOrNatural(false) == Employee.EmployeeRole.Service
					select x).ToList();
				string spec = list.MaxInstance((string x) => emps.SumSafe((Actor z) => z.employee.GetSpecialization(Employee.EmployeeRole.Service, x)));
				c = ServiceColor.First((SpecColor x) => x.Specialization.Equals(spec)).Color;
			}
			else
			{
				c = SkillColor[(int)employeeRole];
			}
			Vector3 vector = Utilities.RGBToHSV(c);
			int num = (team.WorkStart + team.WorkEnd) / 2;
			if (team.WorkStart > team.WorkEnd)
			{
				num += 12;
				if (num > 23)
				{
					num -= 24;
				}
			}
			num = Mathf.Abs(num - 12);
			team.TeamColor = Utilities.HSVToRGBA(vector.x, 0.2f, num.MapRange(0f, 12f, 1f, 0.75f, true));
		}
	}

	public void LoadTeamSetup()
	{
		if (GameData.TeamSetups == null || GameData.TeamSetups.Nodes.Count <= 0)
		{
			return;
		}
		List<TydList> setups = GameData.TeamSetups.Nodes.OfType<TydList>().ToList();
		WindowManager.Instance.MultiWindow.Show("Teams".Loc(), setups.Select((TydList x) => x.Name), delegate(int x)
		{
			foreach (TydTable item in setups[x].Nodes.OfType<TydTable>())
			{
				string text = item["Name"];
				string key = text;
				int num = 2;
				while (GameSettings.Instance.sActorManager.Teams.ContainsKey(key))
				{
					key = text + " " + num;
					num++;
				}
				Team team = Team.DeserializeTyd(key, item);
				GameSettings.Instance.sActorManager.Teams.Add(key, team);
				GameSettings.Instance.sActorManager.ApplySearchToTeam(team);
				TeamList.Items = GameSettings.Instance.sActorManager.Teams.Values.Cast<object>().ToList();
				GameSettings.Instance.sRoomManager.TeamAssignmentDirty = true;
			}
		}, false, true, true, false, delegate(int del)
		{
			GameData.TeamSetups.Nodes.Remove(setups[del]);
			if (GameData.TeamSetups.Nodes.Count == 0)
			{
				File.Delete("Teams.tyd");
			}
			else
			{
				File.WriteAllText("Teams.tyd", TydToText.Write(GameData.TeamSetups, true));
			}
		});
	}

	public void SaveTeamSetup()
	{
		Team[] sel = TeamList.GetSelected<Team>();
		if (sel.Length == 0)
		{
			return;
		}
		WindowManager.SpawnInputDialog("SaveTeamSetup".Loc(), "Teams".Loc(), "Teams".Loc(), delegate(string x)
		{
			string value = TydToText.CleanNodeName(x);
			if (!string.IsNullOrWhiteSpace(value))
			{
				TydNode[] children = sel.SelectInPlace((Team z) => z.SerializeTyd());
				TydList node = new TydList(value, children);
				if (GameData.TeamSetups == null)
				{
					GameData.TeamSetups = new TydDocument();
				}
				GameData.TeamSetups.AddChild(node);
				File.WriteAllText("Teams.tyd", TydToText.Write(GameData.TeamSetups, true));
			}
		});
	}

	public void SendHome()
	{
		Team[] selected = TeamList.GetSelected<Team>();
		if (selected.Length == 0)
		{
			return;
		}
		for (int i = 0; i < selected.Length; i++)
		{
			List<Actor> employeesDirect = selected[i].GetEmployeesDirect();
			for (int j = 0; j < employeesDirect.Count; j++)
			{
				Actor actor = employeesDirect[j];
				if (actor.isActiveAndEnabled)
				{
					actor.GoHomeNow = true;
				}
			}
		}
	}

	public void ChangeBenefits()
	{
		if (TeamList.Selected.Count > 0)
		{
			HUD.Instance.benefitWindow.Show(TeamList.GetSelected<IBenefitReceiver>());
		}
	}
}
