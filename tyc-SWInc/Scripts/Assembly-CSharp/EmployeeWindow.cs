using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeWindow : MonoBehaviour
{
	public GUIListView EmployeeList;

	public GUIWindow Window;

	[NonSerialized]
	private HashSet<Team> teams;

	public Toggle Information;

	public Toggle State;

	public Toggle Skill;

	public SpecializationChart chart;

	public ButtonCounter EdCounter;

	public RectTransform SpecTrans;

	public LeadDesignControl LeadControl;

	public RawImage Portrait;

	public GameObject TaskPanel;

	public Text TaskText;

	public RectTransform ListPanel;

	public RectTransform ButtonPanel;

	public RectTransform BottomPanel;

	public float NormalLayoutSize;

	public float FullLayoutSize;

	[NonSerialized]
	private List<Actor> _customEmps;

	private void Update()
	{
		if (!GameSettings.Instance.IsReferenceNull() && TaskPanel.activeSelf)
		{
			UpdateTaskPanel();
		}
	}

	private void UpdateTaskPanel()
	{
		Actor firstSelected = EmployeeList.GetFirstSelected<Actor>();
		if (firstSelected != null)
		{
			TaskText.text = string.Join("\n", firstSelected.GetCurrentTasks());
			if (string.IsNullOrWhiteSpace(TaskText.text))
			{
				TaskText.text = "None".Loc();
			}
		}
		else
		{
			TaskText.text = "";
		}
	}

	public void UpdateLayout()
	{
		bool flag = chart.RoleCombo.Selected == 3;
		BottomPanel.sizeDelta = new Vector2(BottomPanel.sizeDelta.x, flag ? FullLayoutSize : NormalLayoutSize);
		ButtonPanel.anchoredPosition = new Vector2(ButtonPanel.anchoredPosition.x, 154f + (flag ? (FullLayoutSize - NormalLayoutSize) : 0f));
		ListPanel.offsetMin = new Vector2(ListPanel.offsetMin.x, 181f + (flag ? (FullLayoutSize - NormalLayoutSize) : 0f));
	}

	private void Start()
	{
		ChangeType();
		EmployeeList.OnSelectChange = delegate(bool direct)
		{
			Actor[] selected = EmployeeList.GetSelected<Actor>();
			chart.SetContent(selected.SelectInPlace((Actor x) => x.employee));
			chart.MinSkillTeam = selected.GetIfDistinct((Actor x) => x.GetTeam());
			if (direct)
			{
				SelectorController instance = SelectorController.Instance;
				instance.Highligt(false);
				instance.Selected.Clear();
				foreach (Actor item in selected)
				{
					if (!instance.Selected.Contains(item))
					{
						UISoundFX.PlaySFX("ObjectHighlight");
						instance.Selected.Add(item);
					}
				}
				instance.DoPostSelectChecks();
			}
			UpdatePortrait(selected);
			if (selected.Length == 1)
			{
				TaskPanel.SetActive(true);
				UpdateTaskPanel();
			}
			else
			{
				TaskPanel.SetActive(false);
			}
		};
		EmployeeList.OnDoubleClick = delegate
		{
			Actor firstSelected = EmployeeList.GetFirstSelected<Actor>();
			if (firstSelected != null && firstSelected.isActiveAndEnabled)
			{
				CameraScript.Instance.MoveTo(firstSelected.GetFlatPos(), firstSelected.GetFloor());
			}
		};
	}

	public void ToggleOnlyED(bool value)
	{
		GUIColumn gUIColumn = EmployeeList["EmployeeXP"];
		if (value)
		{
			gUIColumn.FilterNumber[0] = 100.0;
			gUIColumn.FilterNumber[1] = 100.0;
			gUIColumn.ForceFilter = true;
			gUIColumn.ActivateFilter();
		}
		else
		{
			gUIColumn.ForceFilter = false;
			gUIColumn.DeactivateFilter();
		}
	}

	public void UpdatePortrait(Actor[] selected)
	{
		if (selected.Length == 1)
		{
			if (selected[0].employee.IsRole(Employee.RoleBit.Designer, true))
			{
				LeadControl.gameObject.SetActive(true);
				Portrait.gameObject.SetActive(false);
				LeadControl.Init(selected[0].employee);
				return;
			}
			LeadControl.gameObject.SetActive(false);
			Portrait.gameObject.SetActive(true);
			KeyValuePair<Texture2D, Rect> keyValuePair = selected[0].Snapshot();
			Portrait.texture = keyValuePair.Key;
			Portrait.uvRect = keyValuePair.Value;
			Portrait.gameObject.SetActive(true);
		}
		else
		{
			LeadControl.gameObject.SetActive(false);
			Portrait.gameObject.SetActive(false);
		}
	}

	public void Show(HashSet<Team> t = null)
	{
		_customEmps = null;
		if (Window.Shown && t == null)
		{
			Window.Toggle();
			return;
		}
		TutorialSystem.Instance.StartTutorial("Employees");
		teams = t;
		Window.Show();
		EmployeeList.ClearSelected();
		UpdateEmployeeList();
	}

	public void Show(IEnumerable<Actor> employees)
	{
		TutorialSystem.Instance.StartTutorial("Employees");
		Window.Show();
		EmployeeList.ClearSelected();
		_customEmps = employees.ToList();
		UpdateEmployeeList();
	}

	public void UpdateEmployeeList()
	{
		if (!Window.Shown)
		{
			return;
		}
		if (_customEmps != null)
		{
			EmployeeList.Items = _customEmps.Where((Actor x) => !x.OnDestroyWasCalled && x != null && x.gameObject != null).Cast<object>().ToList();
		}
		else if (teams != null)
		{
			EmployeeList.Items = GameSettings.Instance.sActorManager.Actors.Where((Actor x) => teams.Contains(x.GetTeam())).Cast<object>().ToList();
		}
		else
		{
			EmployeeList.Items = GameSettings.Instance.sActorManager.Actors.Cast<object>().ToList();
		}
	}

	public void UpdateEdNumber()
	{
		int num = 0;
		for (int i = 0; i < GameSettings.Instance.sActorManager.Actors.Count; i++)
		{
			Actor actor = GameSettings.Instance.sActorManager.Actors[i];
			if (!actor.TakingCourses)
			{
				Team team = actor.GetTeam();
				if (team != null && !team.HR.HandlesEducation(team) && actor.employee.AnySpecPoints(actor, true))
				{
					num++;
				}
			}
		}
		EdCounter.SetNumber(num);
		if (num > 0)
		{
			TutorialSystem.Instance.StartTutorial("Education");
		}
	}

	public void ChangeType()
	{
		EmployeeList["EmployeeName"].ToggleActive(false, true);
		EmployeeList["EmployeeRole"].ToggleActive(false, Information.isOn);
		EmployeeList["EmployeeTeam"].ToggleActive(false, Information.isOn);
		EmployeeList["EmployeeSalary"].ToggleActive(false, Information.isOn);
		EmployeeList["EmployeeVacation"].ToggleActive(false, Information.isOn);
		EmployeeList["EmployeeAge"].ToggleActive(false, Information.isOn);
		EmployeeList["EmployeeYears"].ToggleActive(false, Information.isOn);
		EmployeeList["EmployeeSickDays"].ToggleActive(false, Information.isOn);
		EmployeeList["EmployeeTraits"].ToggleActive(false, Information.isOn);
		EmployeeList["EmployeeState"].ToggleActive(false, State.isOn);
		EmployeeList["EmployeeArrival"].ToggleActive(false, State.isOn);
		EmployeeList["EmployeeEffectiveness"].ToggleActive(false, State.isOn);
		EmployeeList["EmployeeCompatibility"].ToggleActive(false, State.isOn);
		EmployeeList["EmployeeCohesion"].ToggleActive(false, State.isOn);
		EmployeeList["EmployeeSatisfaction"].ToggleActive(false, State.isOn);
		EmployeeList["EmployeeSkillLead"].ToggleActive(false, Skill.isOn);
		EmployeeList["EmployeeSkillCode"].ToggleActive(false, Skill.isOn);
		EmployeeList["EmployeeSkillDesign"].ToggleActive(false, Skill.isOn);
		EmployeeList["EmployeeSkillArt"].ToggleActive(false, Skill.isOn);
		EmployeeList["EmployeeSkillMarketing"].ToggleActive(false, Skill.isOn);
		EmployeeList["EmployeeXP"].ToggleActive(false, Skill.isOn);
		EmployeeList["EmployeeCreativity"].ToggleActive(false, Skill.isOn);
		EmployeeList["EmployeeInspiration"].ToggleActive(false, Skill.isOn);
	}

	public void FireSelected()
	{
		Actor[] selected = (from x in EmployeeList.GetSelected<Actor>()
			where !x.employee.Founder
			select x).ToArray();
		if (selected.Length == 0)
		{
			return;
		}
		WindowManager.Instance.ShowMessageBox("DismissMsg".Loc(selected.Length), true, "Trash", DialogWindow.DialogType.Error, DialogWindow.DialogType.Warning, delegate
		{
			Actor[] array = selected;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Fire(false);
			}
			GameSettings.Instance.RegisterStat("Fired", selected.Length);
			EmployeeList.ClearSelected();
			EmployeeList.UpdateElements();
		});
	}

	public void SelectAll()
	{
		EmployeeList.ClearSelected();
		int[] array = new int[EmployeeList.Items.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = i;
		}
		EmployeeList.LastSelectDirect = true;
		EmployeeList.Selected.AddRange(array);
		EmployeeList.UpdateSelected();
	}

	public void Educate()
	{
		if (EmployeeList.Selected.Count > 0)
		{
			HUD.Instance.educationWindow.Show(EmployeeList.GetSelected<Actor>());
		}
	}

	public void ShowDetails()
	{
		Actor firstSelected = EmployeeList.GetFirstSelected<Actor>();
		if (firstSelected != null)
		{
			HUD.Instance.DetailWindow.Show(firstSelected);
		}
	}

	public void ChangeBenefits()
	{
		if (EmployeeList.Selected.Count > 0)
		{
			HUD.Instance.benefitWindow.Show(EmployeeList.GetSelected<IBenefitReceiver>());
		}
	}

	public static void ChangeRolesNow(IList<Actor> acts)
	{
		if (acts.Count > 0)
		{
			HUD.Instance.roleSelect.Show(acts);
		}
	}

	public void ChangeRoles()
	{
		ChangeRolesNow(EmployeeList.GetSelected<Actor>());
	}

	public void ChangeTeams()
	{
		Actor[] selected = EmployeeList.GetSelected<Actor>().ToArray();
		Actor actor = selected.FirstOrDefault((Actor x) => x.GetTeam() != null);
		string selected2 = ((actor != null) ? actor.Team : null);
		HUD.Instance.TeamSelectWindow.Show(true, selected2, delegate(string[] x)
		{
			foreach (Actor item in selected.Where((Actor y) => y != null))
			{
				item.Team = ((x.Length == 0) ? null : x[0]);
			}
			EmployeeList.UpdateElements();
		}, null, null, (selected.Length == 1) ? selected[0].employee : null);
	}
}
