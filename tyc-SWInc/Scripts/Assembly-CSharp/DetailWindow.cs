using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DetailWindow : MonoBehaviour
{
	public GUIWindow Window;

	public Text Personality;

	public Toggle[] Roles;

	public Toggle[] SecondaryRoles;

	public GUIProgressBar[] Skill;

	public SpecializationChart SpecChart;

	public GameObject AffectBarPrefab;

	[NonSerialized]
	public GUIProgressBar[] Affectors;

	public List<GUIProgressBar> Thoughts = new List<GUIProgressBar>();

	public GUIProgressBar Satisfaction;

	public GUIProgressBar Effectiveness;

	public GameObject AffectPanel;

	public GameObject ThoughtPanel;

	public PosNegBar SatisfactionBar;

	public PosNegBar EffectBar;

	public ScrollRect ThoughtScroll;

	public Button FireButton;

	public RawImage Portrait;

	public CompatibilityPanel[] Comps;

	public Scrollbar CompScroll;

	public UITrait[] TraitIcons;

	public LeadDesignControl LeadControl;

	public Transform DemandPanel;

	public GameObject DemandTitle;

	public GameObject ButtonPanel;

	public Toggle CompatOrder;

	public Toggle RelationOrder;

	public Toggle MentorToggle;

	public GameObject CEOButton;

	public GameObject ComplaintWarning;

	[NonSerialized]
	public Actor CurrentEmployee;

	[NonSerialized]
	private LeadDesignDemands.Demand _lastDemands;

	[NonSerialized]
	private bool _initializing;

	private bool _settingRoles;

	public void SetMentor()
	{
		if (!_initializing)
		{
			CurrentEmployee.IsMentor = MentorToggle.isOn;
		}
	}

	public void MakeCEO()
	{
		GameSettings.Instance.HasFounder = true;
		CurrentEmployee.employee.MadeCEO = (CurrentEmployee.employee.Founder = true);
		CurrentEmployee.employee.Thoughts.Clear();
		CurrentEmployee.employee.Social = (CurrentEmployee.employee.Stress = (CurrentEmployee.employee.Posture = (CurrentEmployee.employee.Hunger = (CurrentEmployee.employee.Bladder = 1f))));
		CurrentEmployee.employee.Salary = (CurrentEmployee.employee.Demanded = 0f);
		CurrentEmployee.employee.Traits &= Employee.Trait.FastLearner | Employee.Trait.BigBrain | Employee.Trait.Capacitor | Employee.Trait.ThisIsFine | Employee.Trait.BornLeader | Employee.Trait.FirmwareInc | Employee.Trait.SuperFocus | Employee.Trait.Detached | Employee.Trait.Stressed | Employee.Trait.BumLeg | Employee.Trait.Forgetful | Employee.Trait.Cupholder | Employee.Trait.NeatFreak | Employee.Trait.SilentButDeadly | Employee.Trait.Watch | Employee.Trait.WalkInstead | Employee.Trait.UnderTheWeather | Employee.Trait.Sunshine | Employee.Trait.Skyscraper | Employee.Trait.RGBThumb | Employee.Trait.FriendMaker | Employee.Trait.Clean | Employee.Trait.Claustrophobic;
		CEOButton.SetActive(false);
		Utilities.InitTraitUI(CurrentEmployee.employee.Traits, TraitIcons);
	}

	public void Show(Actor emp, bool modal = false, bool interactable = true)
	{
		if (Window.Shown && CurrentEmployee == emp)
		{
			if (!WindowManager.HasModal)
			{
				Window.Focus();
			}
			return;
		}
		_initializing = true;
		for (int i = 0; i < Roles.Length; i++)
		{
			Roles[i].isOn = emp.employee.IsRoleIndex(i, true);
			Roles[i].interactable = interactable;
		}
		MentorToggle.isOn = emp.IsMentor;
		MentorToggle.interactable = interactable;
		for (int j = 0; j < SecondaryRoles.Length; j++)
		{
			SecondaryRoles[j].isOn = emp.employee.IsSecondaryRoleIndex(j + 1);
			SecondaryRoles[j].interactable = interactable;
		}
		if (emp.employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead))
		{
			Roles[0].interactable = false;
		}
		ButtonPanel.SetActive(interactable);
		CEOButton.SetActive(!GameSettings.Instance.HasFounder && interactable && !emp.employee.Founder && !emp.employee.Dismissed);
		Window.Modal = modal;
		KeyValuePair<Texture2D, Rect> keyValuePair = emp.Snapshot();
		Portrait.texture = keyValuePair.Key;
		Portrait.uvRect = keyValuePair.Value;
		for (int k = 0; k < Actor.AffectorCount; k++)
		{
			Affectors[k].gameObject.SetActive(false);
		}
		if (emp.employee.IsRole(Employee.RoleBit.Designer, true))
		{
			LeadControl.gameObject.SetActive(true);
			LeadControl.Init(emp.employee);
		}
		else
		{
			LeadControl.Init(null);
			LeadControl.gameObject.SetActive(false);
		}
		if (emp.employee.DemandsMet != 0)
		{
			DemandTitle.SetActive(true);
			DemandPanel.gameObject.SetActive(true);
			Utilities.InitializeDemands(emp.employee, DemandPanel);
		}
		else
		{
			DemandTitle.SetActive(false);
			DemandPanel.gameObject.SetActive(false);
		}
		_lastDemands = emp.employee.DemandResults;
		CurrentEmployee = emp;
		string text = ((CurrentEmployee.employee.NickName != null) ? (CurrentEmployee.employee.NickName + "(" + CurrentEmployee.employee.Name + ")") : CurrentEmployee.employee.Name);
		Window.NonLocTitle = text + " - " + "Age".Loc() + ": " + CurrentEmployee.employee.GetAgeFlat() + " - " + "Team".Loc() + ": " + CurrentEmployee.Team;
		Window.Show();
		Personality.text = ((CurrentEmployee.AItype == AI.AIType.Robot) ? "Misanthropist".Loc() : (CurrentEmployee.employee.PersonalityTraits[0].LocTry() + "\n" + CurrentEmployee.employee.PersonalityTraits[1].LocTry()));
		SpecChart.SetContent(new Employee[1] { emp.employee });
		SpecChart.MinSkillTeam = emp.GetTeam();
		_initializing = false;
		CompScroll.value = 0f;
		RefreshComps();
		UpdateFireButton();
		Utilities.InitTraitUI(emp.employee.Traits, TraitIcons);
	}

	public void Goto()
	{
		if (CurrentEmployee != null)
		{
			SelectorController.Instance.SetSelection(CurrentEmployee);
			if (CurrentEmployee.isActiveAndEnabled && SelectorController.Instance.Selected.Count > 0)
			{
				Selectable selectable = SelectorController.Instance.Selected.First();
				CameraScript.Instance.MoveTo(selectable.GetFlatPos(), selectable.GetFloor());
			}
		}
	}

	public void ToggleCompOrder(bool v)
	{
		if (v)
		{
			RefreshComps();
		}
	}

	public void ScrollComps(BaseEventData ev)
	{
		if (CompScroll.numberOfSteps > 0)
		{
			PointerEventData pointerEventData = (PointerEventData)ev;
			CompScroll.value = Mathf.Clamp01(CompScroll.value - pointerEventData.scrollDelta.y / (float)CompScroll.numberOfSteps);
		}
	}

	public void RefreshComps()
	{
		int num = 0;
		Team team = CurrentEmployee.GetTeam();
		if (team != null)
		{
			List<Actor> employeesDirect = team.GetEmployeesDirect();
			for (int i = 0; i < employeesDirect.Count; i++)
			{
				if (employeesDirect[i] != CurrentEmployee)
				{
					num++;
				}
			}
		}
		int numberOfSteps = Mathf.Max(0, num - Comps.Length + 1);
		CompScroll.numberOfSteps = numberOfSteps;
		CompScroll.size = ((num == 0) ? 1f : (1f / (float)num));
		for (int j = 0; j < Comps.Length; j++)
		{
			Comps[j].gameObject.SetActive(j < num);
		}
		if (team == null || num <= 0)
		{
			return;
		}
		int num2 = Mathf.FloorToInt(CompScroll.value * (float)Mathf.Max(0, num - Comps.Length));
		List<Actor> employeesDirect2 = team.GetEmployeesDirect();
		int num3 = 0;
		foreach (Actor item in employeesDirect2.OrderBy((Actor x) => (!CompatOrder.isOn) ? Employee.GetFriendship(CurrentEmployee.employee, x.employee) : CurrentEmployee.employee.Compatibility(x.employee)))
		{
			if (!(item != CurrentEmployee))
			{
				continue;
			}
			if (num2 == 0)
			{
				Comps[num3].SetValues(item, CurrentEmployee);
				num3++;
				if (num3 >= Comps.Length)
				{
					break;
				}
			}
			else
			{
				num2--;
			}
		}
		for (int num4 = 0; num4 < Comps.Length; num4++)
		{
			Comps[num4].gameObject.SetActive(num4 < num3);
		}
	}

	public void SetRoles(bool secondary)
	{
		if (_initializing || _settingRoles)
		{
			return;
		}
		_settingRoles = true;
		if (secondary)
		{
			for (int i = 1; i < Roles.Length; i++)
			{
				Roles[i].isOn |= SecondaryRoles[i - 1].isOn;
			}
		}
		else
		{
			for (int j = 0; j < SecondaryRoles.Length; j++)
			{
				SecondaryRoles[j].isOn &= Roles[j + 1].isOn;
			}
		}
		int num = 0;
		for (int num2 = Roles.Length - 1; num2 >= 0; num2--)
		{
			num <<= 1;
			if (Roles[num2].isOn && (num2 == 0 || !SecondaryRoles[num2 - 1].isOn))
			{
				num |= 1;
			}
		}
		int num3 = 0;
		for (int num4 = SecondaryRoles.Length - 1; num4 >= 0; num4--)
		{
			num3 <<= 1;
			if (SecondaryRoles[num4].isOn)
			{
				num3 |= 1;
			}
		}
		num3 <<= 1;
		CurrentEmployee.ChangeRole((Employee.RoleBit)num, (Employee.RoleBit)num3);
		_settingRoles = false;
		if (CurrentEmployee.employee.IsRole(Employee.RoleBit.Designer, true))
		{
			LeadControl.gameObject.SetActive(true);
			LeadControl.Init(CurrentEmployee.employee);
		}
		else
		{
			LeadControl.Init(null);
			LeadControl.gameObject.SetActive(false);
		}
	}

	private void Awake()
	{
		Affectors = new GUIProgressBar[Actor.AffectorCount];
		for (int i = 0; i < Actor.AffectorCount; i++)
		{
			Actor.Affector affector = (Actor.Affector)i;
			GUIProgressBar gUIProgressBar = CreateAffectBar(AffectPanel.transform);
			gUIProgressBar.GetComponentInChildren<Text>().text = affector.ToString().Loc();
			gUIProgressBar.gameObject.SetActive(false);
			Affectors[i] = gUIProgressBar;
		}
	}

	private GUIProgressBar CreateAffectBar(Transform parent)
	{
		GameObject obj = UnityEngine.Object.Instantiate(AffectBarPrefab);
		GUIProgressBar component = obj.GetComponent<GUIProgressBar>();
		obj.transform.SetParent(parent, false);
		return component;
	}

	public void ChangeName()
	{
		WindowManager.SpawnInputDialog("NameChangePrompt".Loc(), "NameChangeTitle".Loc(), CurrentEmployee.employee.NickName ?? "", delegate(string x)
		{
			if (string.IsNullOrEmpty(x))
			{
				CurrentEmployee.employee.NickName = null;
			}
			else
			{
				CurrentEmployee.employee.NickName = (GameSettings.Instance.IsNetworkMode ? x.StripRichTags() : x);
			}
			GlobalSearchPanel.Instance.RefreshQuery(CurrentEmployee, CurrentEmployee.employee.ExtraName);
		}, null, 64);
	}

	private void UpdateAffect()
	{
		int num = 1;
		float num2 = 0f;
		float num3 = 0f;
		foreach (KeyValuePair<int, float> item in from x in CurrentEmployee.Affactors.Select((float x, int i) => new KeyValuePair<int, float>(i, x))
			orderby Mathf.Abs(x.Value) descending
			select x)
		{
			if (item.Value > -2f)
			{
				Affectors[item.Key].gameObject.SetActive(true);
				Affectors[item.Key].Value = item.Value;
				Affectors[item.Key].transform.SetSiblingIndex(num);
				if (item.Value < 0f)
				{
					num2 += 0f - item.Value;
				}
				else
				{
					num3 += item.Value;
				}
				num++;
			}
			else
			{
				Affectors[item.Key].gameObject.SetActive(false);
			}
		}
		Effectiveness.Value = CurrentEmployee.Effectiveness - 1f;
		EffectBar.SetValues(Mathf.Clamp(num3 * 6f, 0f, 6f), Mathf.Clamp(num2 * 6f, 0f, 6f));
	}

	private void UpdateThoughts()
	{
		int num = 0;
		float num2 = 0f;
		float num3 = 0f;
		bool flag = false;
		foreach (Employee.ThoughtEffect item in CurrentEmployee.employee.Thoughts.List.OrderByDescending((Employee.ThoughtEffect x) => x.Effect))
		{
			if (Thoughts.Count <= num)
			{
				GUIProgressBar gUIProgressBar = CreateAffectBar(ThoughtPanel.transform);
				gUIProgressBar.FromCenter = false;
				gUIProgressBar.OnlyUseStart = true;
				Thoughts.Add(gUIProgressBar);
				flag = true;
			}
			GUIProgressBar gUIProgressBar2 = Thoughts[num];
			gUIProgressBar2.StartColor = (item.Mood.Negative ? HUD.GetThemeColor(2) : HUD.GetThemeColor(0));
			gUIProgressBar2.gameObject.SetActive(true);
			gUIProgressBar2.GetComponentInChildren<Text>().text = item.Thought.Loc();
			gUIProgressBar2.GetComponent<GUIToolTipper>().TooltipDescription = (item.Thought + "Hint").LocDef(null);
			gUIProgressBar2.Value = item.Effect;
			gUIProgressBar2.SetDirty();
			if (item.Mood.Negative)
			{
				num2 += item.Effect;
			}
			else
			{
				num3 += item.Effect;
			}
			num++;
		}
		for (int num4 = num; num4 < Thoughts.Count; num4++)
		{
			Thoughts[num4].gameObject.SetActive(false);
			flag = true;
		}
		Satisfaction.Value = CurrentEmployee.employee.JobSatisfaction - 1f;
		SatisfactionBar.SetValues(Mathf.Clamp(num3 * 6f, 0f, 4f), Mathf.Clamp(num2 * 6f, 0f, 4f));
		if (flag)
		{
			ThoughtScroll.verticalNormalizedPosition = Mathf.Clamp01(ThoughtScroll.verticalNormalizedPosition);
		}
	}

	private void Update()
	{
		if (!CurrentEmployee.IsAliveNotNull())
		{
			Window.Close();
			return;
		}
		if (ComplaintWarning.activeSelf != CurrentEmployee.employee.ActiveComplaint)
		{
			ComplaintWarning.SetActive(CurrentEmployee.employee.ActiveComplaint);
		}
		for (int i = 0; i < 5; i++)
		{
			Skill[i].Value = Mathf.Min(1f, CurrentEmployee.employee.GetSpecExperience((Employee.EmployeeRole)i));
		}
		UpdateThoughts();
		UpdateAffect();
		if (_lastDemands != CurrentEmployee.employee.DemandResults)
		{
			if (CurrentEmployee.employee.DemandsMet != 0)
			{
				DemandTitle.SetActive(true);
				DemandPanel.gameObject.SetActive(true);
				Utilities.InitializeDemands(CurrentEmployee.employee, DemandPanel);
			}
			else
			{
				DemandTitle.SetActive(false);
				DemandPanel.gameObject.SetActive(false);
			}
			_lastDemands = CurrentEmployee.employee.DemandResults;
		}
	}

	private void UpdateFireButton()
	{
		FireButton.interactable = !CurrentEmployee.employee.Founder && !CurrentEmployee.employee.Dismissed;
	}

	public void Fire()
	{
		if (!CurrentEmployee.employee.Dismissed)
		{
			WindowManager.Instance.ShowMessageBox("DismissMsg".Loc(1), true, "Trash", DialogWindow.DialogType.Error, DialogWindow.DialogType.Warning, delegate
			{
				CurrentEmployee.Fire(false);
				GameSettings.Instance.RegisterStat("Fired", 1f);
			}, "Fire employees");
		}
		UpdateFireButton();
	}
}
