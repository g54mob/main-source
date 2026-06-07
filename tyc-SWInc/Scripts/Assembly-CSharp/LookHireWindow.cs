using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LookHireWindow : MonoBehaviour
{
	[Serializable]
	public class HireFilter
	{
		public Employee.EmployeeRole Role;

		public Employee.EmployeeRole? SecondaryRole;

		public Employee.WageBracket Wage;

		public string[] SpecFilter;

		public string TeamCompatibility;

		public Employee.Trait RequireTrait;

		public Employee.Trait[] FilterTrait;

		public Dictionary<string, float> Benefits;

		public HireFilter()
		{
		}

		public HireFilter(Employee.EmployeeRole role, Employee.EmployeeRole? secondaryRole, Employee.WageBracket wage, string[] specFilter, string teamCompatibility, Employee.Trait requireTrait, Employee.Trait[] filterTrait, Dictionary<string, float> benefits)
		{
			Role = role;
			SecondaryRole = secondaryRole;
			Wage = wage;
			SpecFilter = specFilter;
			TeamCompatibility = teamCompatibility;
			RequireTrait = requireTrait;
			FilterTrait = filterTrait;
			Benefits = benefits;
		}
	}

	public GUIWindow Window;

	public HireWindow HireWin;

	public GameObject SpecPrefab;

	public GameObject ServiceCombo;

	public UITrait TraitTogglePrefab;

	public RectTransform PriorityPanel;

	public RectTransform IgnorePanel;

	public RectTransform PriorityViewport;

	public RectTransform IgnoreViewport;

	public RectTransform MainPanel;

	public RectTransform TraitPanel;

	public GUICombobox RoleCombo;

	public GUICombobox SpecCombo;

	public GUICombobox WageBracket;

	public GUICombobox SecondRoleCombo;

	public Transform DragObject;

	public GameObject SpecPriorityPanel;

	public GameObject CompatButton;

	public Toggle SpecPriority;

	public Toggle CompatFilter;

	public Toggle TraitFilter;

	public Text WageLabel;

	public Text CostText;

	public Text PoolText;

	public Text CompatLabel;

	public Text AppealLabel;

	public Text BenefitLabel;

	public GUIToolTipper AppealTip;

	private List<RectTransform> _specPool = new List<RectTransform>();

	private RectTransform _activeDrag;

	private Transform _lastPanel;

	private string _compatTeam;

	private Employee.EmployeeRole[] _secondRoles = new Employee.EmployeeRole[4];

	[NonSerialized]
	private Dictionary<Employee.Trait, UITrait> _traitToggles = new Dictionary<Employee.Trait, UITrait>();

	[NonSerialized]
	private List<Employee.Trait> _traitFilter = new List<Employee.Trait>();

	[NonSerialized]
	private Employee.Trait _traitRequire;

	[NonSerialized]
	public HireFilter LastFilter;

	[NonSerialized]
	public Dictionary<string, HireFilter> HireFilters = new Dictionary<string, HireFilter>();

	[NonSerialized]
	public Dictionary<string, float> Benefits = new Dictionary<string, float>();

	private bool _first = true;

	public HireFilter GetFilter()
	{
		Team team = ((_compatTeam != null) ? GameSettings.GetTeam(_compatTeam) : null);
		string teamCompatibility = null;
		if (team != null && team.Count > 0 && team.MinCompatibility >= 1f)
		{
			teamCompatibility = team.Name;
		}
		return new HireFilter((Employee.EmployeeRole)RoleCombo.Selected, (SecondRoleCombo.Selected > 0) ? new Employee.EmployeeRole?(_secondRoles[SecondRoleCombo.Selected - 1]) : ((Employee.EmployeeRole?)null), (Employee.WageBracket)WageBracket.Selected, GetSpecPriority(), teamCompatibility, _traitRequire, _traitFilter.ToArray(), Benefits.ToDictionary());
	}

	public void PickBenefits()
	{
		Team team = ((_compatTeam != null) ? GameSettings.GetTeam(_compatTeam) : null);
		string teamBacking = null;
		if (team != null && team.Count > 0 && team.MinCompatibility >= 1f)
		{
			teamBacking = team.Name;
		}
		BenefitWindow benefitWindow = HUD.Instance.benefitWindow;
		IBenefitReceiver[] targets = new TempBenefits[1]
		{
			new TempBenefits(Benefits, teamBacking, delegate
			{
				UpdateBenefitLabel();
				UpdateWageBracket();
			})
		};
		benefitWindow.Show(targets, true);
	}

	private void UpdateWindowHeight()
	{
		StartCoroutine(UpdateWindowHeightCo());
	}

	private IEnumerator UpdateWindowHeightCo()
	{
		LayoutRebuilder.ForceRebuildLayoutImmediate(MainPanel);
		yield return new WaitForEndOfFrame();
		Window.rectTransform.sizeDelta = new Vector2(Window.rectTransform.sizeDelta.x, MainPanel.rect.height + 74f);
	}

	public void ApplyFilter(HireFilter filter)
	{
		RoleCombo.Selected = (int)filter.Role;
		WageBracket.Selected = (int)filter.Wage;
		if (filter.SecondaryRole.HasValue)
		{
			SecondRoleCombo.SelectedItem = filter.SecondaryRole.Value.ToString();
		}
		else
		{
			SecondRoleCombo.Selected = 0;
		}
		if (filter.Role == Employee.EmployeeRole.Service)
		{
			SpecCombo.SelectedItem = filter.SpecFilter[0];
		}
		else if (filter.SpecFilter != null && filter.SpecFilter.Length != 0)
		{
			SpecPriority.isOn = true;
			Dictionary<string, int> dictionary = filter.SpecFilter.Select([return: TupleElementNames(new string[] { "x", "i" })] (string x, int i) => new ValueTuple<string, int>(x, i)).ToDictionary(([TupleElementNames(new string[] { "x", "i" })] ValueTuple<string, int> x) => x.Item1, ([TupleElementNames(new string[] { "x", "i" })] ValueTuple<string, int> x) => x.Item2);
			for (int num = 0; num < PriorityPanel.childCount; num++)
			{
				Transform child = PriorityPanel.GetChild(num);
				if (child.gameObject.activeSelf && child != DragObject && !dictionary.ContainsKey(child.name))
				{
					child.SetParent(IgnorePanel, false);
					num--;
				}
			}
			for (int num2 = 0; num2 < IgnorePanel.childCount; num2++)
			{
				Transform child2 = IgnorePanel.GetChild(num2);
				if (child2.gameObject.activeSelf && child2 != DragObject && dictionary.ContainsKey(child2.name))
				{
					child2.SetParent(PriorityPanel, false);
					num2--;
				}
			}
			List<Transform> list = PriorityPanel.GetChildren().ToList();
			for (int num3 = 0; num3 < list.Count; num3++)
			{
				Transform transform = list[num3];
				int value;
				if (transform.gameObject.activeSelf && transform != DragObject && dictionary.TryGetValue(transform.name, out value))
				{
					transform.SetSiblingIndex(value);
				}
			}
		}
		else
		{
			SpecPriority.isOn = false;
		}
		if (filter.RequireTrait != Employee.Trait.None || filter.FilterTrait.Length != 0)
		{
			TraitFilter.isOn = true;
			Employee.Trait trait = Employee.Trait.None;
			for (int num4 = 0; num4 < filter.FilterTrait.Length; num4++)
			{
				trait |= filter.FilterTrait[num4];
			}
			_traitRequire = filter.RequireTrait;
			_traitFilter.Clear();
			_traitFilter.AddRange(filter.FilterTrait);
			foreach (KeyValuePair<Employee.Trait, UITrait> traitToggle in _traitToggles)
			{
				if (filter.RequireTrait.HasBits(traitToggle.Key))
				{
					traitToggle.Value.SetToggle(UITrait.ToggleState.On);
				}
				else if (trait.HasBits(traitToggle.Key))
				{
					traitToggle.Value.SetToggle(UITrait.ToggleState.Off);
				}
				else
				{
					traitToggle.Value.SetToggle(UITrait.ToggleState.None);
				}
			}
		}
		else
		{
			TraitFilter.isOn = false;
		}
		if (filter.TeamCompatibility != null)
		{
			CompatFilter.isOn = true;
			Team team = GameSettings.GetTeam(filter.TeamCompatibility);
			if (team != null && team.MinCompatibility >= 1f && team.Count > 0)
			{
				CompatLabel.text = team.Name;
				_compatTeam = team.Name;
			}
			else
			{
				CompatLabel.text = "SelectATeam".Loc();
				_compatTeam = null;
			}
		}
		else
		{
			CompatFilter.isOn = false;
		}
		Benefits = ((filter.Benefits != null) ? filter.Benefits.ToDictionary() : new Dictionary<string, float>());
		UpdateBenefitLabel();
		UpdateWageBracket();
		UpdateCost();
	}

	public void UpdateBenefitLabel()
	{
		BenefitLabel.text = "Changebenefits".Loc() + " (" + Benefits.Count + ")";
	}

	public void LoadFilter()
	{
		KeyValuePair<string, HireFilter>[] vals = HireFilters.ToArray();
		WindowManager.Instance.MultiWindow.Show("Filter", HireFilters.Keys, delegate(int x)
		{
			ApplyFilter(vals[x].Value);
		}, false, true, true, false, delegate(int x)
		{
			HireFilters.Remove(vals[x].Key);
		});
	}

	public void SaveFilter()
	{
		WindowManager.SpawnInputDialog("SaveHireFilterPrompt".Loc(), "Filter", "Filter".Loc(), delegate(string x)
		{
			if (!HireFilters.ContainsKey(x))
			{
				HireFilters[x] = GetFilter();
			}
		});
	}

	public void UpdateSecondaryCombo()
	{
		Employee.EmployeeRole selected = (Employee.EmployeeRole)RoleCombo.Selected;
		string[] array = new string[5] { null, null, null, null, null };
		int num = 1;
		for (int i = 0; i < 5; i++)
		{
			Employee.EmployeeRole employeeRole = (Employee.EmployeeRole)i;
			if (employeeRole != selected)
			{
				array[num] = employeeRole.ToString();
				_secondRoles[num - 1] = employeeRole;
				num++;
			}
		}
		SecondRoleCombo.UpdateContent(array);
	}

	public void UpdateSpecCombo()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			Employee.EmployeeRole selected = (Employee.EmployeeRole)RoleCombo.Selected;
			if (selected == Employee.EmployeeRole.Service)
			{
				ServiceCombo.SetActive(true);
				SpecPriority.isOn = false;
				SpecPriority.gameObject.SetActive(false);
				SpecCombo.UpdateContent(GameSettings.Instance.GetUnlockedSpecializations(selected));
			}
			else
			{
				ServiceCombo.SetActive(false);
				SpecPriority.gameObject.SetActive(true);
			}
			UpdateWindowHeight();
		}
	}

	public void UpdateWageBracket()
	{
		float num = 0.25f;
		int num2 = 8;
		if (_compatTeam != null)
		{
			Team team = GameSettings.GetTeam(_compatTeam);
			if (team != null)
			{
				num2 = team.WorkHours;
			}
		}
		float benefitScore = EmployeeBenefit.GetBenefitScore(new TempBenefits(Benefits, _compatTeam, null));
		string text = (Employee.GetEmployeeWorth(RoleCombo.Selected, SpecCombo.SelectedItemString, (float)WageBracket.Selected * num, Employee.AgeBrackets[WageBracket.Selected][0], 0f, benefitScore) * (float)num2).Currency();
		if (WageBracket.Selected < 2)
		{
			float x = Employee.GetEmployeeWorth(RoleCombo.Selected, SpecCombo.SelectedItemString, (float)WageBracket.Selected * num + num, Employee.AgeBrackets[WageBracket.Selected][1], 0f, benefitScore) * (float)num2;
			text = text + " - " + x.Currency();
		}
		else
		{
			text += "+";
		}
		WageLabel.text = text + " (" + "Hour".LocPlural(num2) + ")";
	}

	private void Start()
	{
		Window.OnClose = delegate
		{
			if (_activeDrag != null)
			{
				_activeDrag.SetParent(_lastPanel, false);
				_activeDrag = null;
				DragObject.gameObject.SetActive(false);
			}
		};
		UpdateBenefitLabel();
	}

	public void Show()
	{
		if (!Window.ToggleReturn())
		{
			return;
		}
		if (_compatTeam != null)
		{
			Team team = GameSettings.GetTeam(_compatTeam);
			if (team == null || team.MinCompatibility < 1f || team.Count == 0)
			{
				CompatLabel.text = "SelectATeam".Loc();
				_compatTeam = null;
			}
		}
		UpdateCost();
		if (_first)
		{
			RoleCombo.UpdateSelection(0);
			_first = false;
			TraitPanel.gameObject.SetActive(true);
			LayoutRebuilder.ForceRebuildLayoutImmediate(TraitPanel);
			TraitPanel.gameObject.SetActive(false);
		}
		if (LastFilter != null)
		{
			ApplyFilter(LastFilter);
		}
	}

	public void StartLooking()
	{
		float finalCost = GetFinalCost();
		if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - finalCost))
		{
			UISoundFX.PlaySFX("Kaching");
			GameSettings.Instance.MyCompany.MakeTransaction(0f - finalCost, Company.TransactionCategory.Hire, true);
			HireFilter filter = (LastFilter = GetFilter());
			if (HireWin.Show(finalCost, filter))
			{
				Window.Close();
			}
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), true, DialogWindow.DialogType.Error);
		}
	}

	public void UpdateCost()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			CostText.text = GetFinalCost().Currency();
			PoolText.text = GetPoolLabel(HireWin.GetEmployeePoolCount((Employee.WageBracket)WageBracket.Selected, _compatTeam != null, SecondRoleCombo.Selected > 0, GetSpecPriorityCount(), _traitRequire != Employee.Trait.None, _traitFilter.Count));
			float appeal = GameSettings.Instance.ApplicantScore.GetAppeal();
			AppealLabel.text = "ApplicantAppeal".Loc().FontBold() + ": " + appeal.ToPercent().FontColor(Color.Lerp(new Color32(200, 0, 0, byte.MaxValue), new Color32(50, 50, 50, byte.MaxValue), appeal));
			ValueTuple<float, float, float, float> appealData = GameSettings.Instance.ApplicantScore.GetAppealData();
			float item = appealData.Item1;
			float item2 = appealData.Item2;
			float item3 = appealData.Item3;
			float item4 = appealData.Item4;
			AppealTip.TooltipDescription = string.Format("{0}: {1}\n{2}: {3}\n{4}: {5}", "TurnoverRate".Loc(), GetAppealScore(item), "MassLayoffs".Loc(), GetAppealScore(item2), "JobSatisfaction".Loc(), GetAppealScore(item3));
			if (item4 < 1f)
			{
				GUIToolTipper appealTip = AppealTip;
				appealTip.TooltipDescription = appealTip.TooltipDescription + "\n" + "TaxFraud".Loc() + ": " + GetAppealScore(item4);
			}
		}
	}

	private string GetAppealScore(float score)
	{
		if (score >= 1f)
		{
			return "+".FontColor(new Color(0f, 1f, 0f));
		}
		switch (Mathf.CeilToInt((1f - score) * 3f))
		{
		case 2:
			return "- -".FontColor(new Color(1f, 0f, 0f));
		case 3:
			return "- - -".FontColor(new Color(1f, 0f, 0f));
		case 4:
			return "- - - -".FontColor(new Color(1f, 0f, 0f));
		default:
			return "-".FontColor(new Color(1f, 0f, 0f));
		}
	}

	private string GetPoolLabel(int count)
	{
		if (count < 5)
		{
			return "< 5";
		}
		if (count < 10)
		{
			return "< 10";
		}
		if (count < 25)
		{
			return "< 25";
		}
		if (count < 50)
		{
			return "< 50";
		}
		if (count < 100)
		{
			return "< 100";
		}
		return "100+";
	}

	private float GetFinalCost()
	{
		return GetFinalCost(WageBracket.Selected, GetSpecPriorityCount(), SecondRoleCombo.Selected > 0, _compatTeam != null, _traitRequire != Employee.Trait.None, _traitFilter.Count);
	}

	public static float GetFinalCost(int wageBracket, int specs, bool secondary, bool compat, bool requireTrait, int filterTraits)
	{
		return 500f * (1f + (float)specs * 0.5f) * (secondary ? 1.5f : 1f) * (compat ? 2f : 1f) * (requireTrait ? 2f : 1f) * (1f + (float)filterTraits * 0.25f) * Mathf.Pow(1.3f, wageBracket);
	}

	private void Awake()
	{
		RoleCombo.UpdateContent(Enum.GetNames(typeof(Employee.EmployeeRole)));
		WageBracket.UpdateContent(Enum.GetNames(typeof(Employee.WageBracket)));
		foreach (Employee.Trait t in Enum.GetValues(typeof(Employee.Trait)).OfType<Employee.Trait>().OrderBy(Employee.TraitOrder))
		{
			if (t != Employee.Trait.None && !Employee.Trait.OldSole.HasFlag(t))
			{
				UITrait uITrait = UnityEngine.Object.Instantiate(TraitTogglePrefab);
				uITrait.SetTrait(t);
				uITrait.OnToggle.AddListener(delegate(UITrait.ToggleState x)
				{
					OnTraitToggle(t, x);
				});
				uITrait.transform.SetParent(TraitPanel, false);
				_traitToggles[t] = uITrait;
			}
		}
		SpecPriority.isOn = false;
		CompatFilter.isOn = false;
		TraitFilter.isOn = false;
	}

	private void OnTraitToggle(Employee.Trait t, UITrait.ToggleState s)
	{
		switch (s)
		{
		case UITrait.ToggleState.On:
			if (_traitRequire != Employee.Trait.None)
			{
				_traitToggles[_traitRequire].SetToggle(UITrait.ToggleState.None);
			}
			_traitRequire = t;
			_traitFilter.Remove(t);
			break;
		case UITrait.ToggleState.Off:
			if (_traitFilter.Count == 4)
			{
				_traitToggles[_traitFilter[0]].SetToggle(UITrait.ToggleState.None);
				_traitFilter.RemoveAt(0);
			}
			if (_traitRequire == t)
			{
				_traitRequire = Employee.Trait.None;
			}
			_traitFilter.Add(t);
			break;
		case UITrait.ToggleState.None:
			if (_traitRequire == t)
			{
				_traitRequire = Employee.Trait.None;
			}
			_traitFilter.Remove(t);
			break;
		}
		UpdateCost();
	}

	public void SelectTeam()
	{
		HUD.Instance.TeamSelectWindow.Show(true, _compatTeam, delegate(string[] xs)
		{
			Team team = ((xs.Length != 0) ? GameSettings.GetTeam(xs[0]) : null);
			if (team != null)
			{
				if (team.Count == 0 || team.MinCompatibility < 1f)
				{
					CompatLabel.text = "SelectATeam".Loc();
					_compatTeam = null;
					UpdateCost();
					UpdateWageBracket();
					WindowManager.Instance.ShowMessageBox(((team.Count == 0) ? "TeamCompatFail" : "EmployeeCompatFail").Loc(), true, DialogWindow.DialogType.Error);
				}
				else
				{
					CompatLabel.text = team.Name;
					_compatTeam = team.Name;
					UpdateCost();
					UpdateWageBracket();
				}
			}
			else
			{
				CompatLabel.text = "SelectATeam".Loc();
				_compatTeam = null;
				UpdateCost();
				UpdateWageBracket();
			}
		}, null);
	}

	public void UpdateSpecToggle(bool on)
	{
		SpecPriorityPanel.SetActive(on);
		for (int i = 0; i < PriorityPanel.childCount; i++)
		{
			Transform child = PriorityPanel.GetChild(i);
			if (child.gameObject.activeSelf && child != DragObject)
			{
				child.SetParent(IgnorePanel, false);
				i--;
			}
		}
		UpdateCost();
		UpdateWindowHeight();
	}

	public void UpdateTraitToggle(bool on)
	{
		TraitPanel.gameObject.SetActive(on);
		_traitToggles.Values.ForEachEnum(delegate(UITrait x)
		{
			x.SetToggle(UITrait.ToggleState.None);
		});
		_traitFilter.Clear();
		_traitRequire = Employee.Trait.None;
		UpdateCost();
		UpdateWindowHeight();
	}

	public void UpdateCompatToggle(bool on)
	{
		CompatButton.SetActive(on);
		if (on && GameSettings.Instance.sActorManager.Teams.Count == 1)
		{
			Team team = GameSettings.Instance.sActorManager.Teams.Values.First();
			if (team.MinCompatibility >= 1f && team.Count > 0)
			{
				_compatTeam = team.Name;
				CompatLabel.text = team.Name;
			}
			else
			{
				_compatTeam = null;
				CompatLabel.text = "SelectATeam".Loc();
			}
		}
		else
		{
			_compatTeam = null;
			CompatLabel.text = "SelectATeam".Loc();
		}
		UpdateCost();
		UpdateWageBracket();
		UpdateWindowHeight();
	}

	public void RefreshSpecs()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		Employee.EmployeeRole selected = (Employee.EmployeeRole)RoleCombo.Selected;
		for (int i = 0; i < PriorityPanel.childCount; i++)
		{
			Transform child = PriorityPanel.GetChild(i);
			if (child != DragObject && child.gameObject.activeSelf)
			{
				_specPool.Add(child.GetComponent<RectTransform>());
			}
			child.gameObject.SetActive(false);
		}
		for (int j = 0; j < IgnorePanel.childCount; j++)
		{
			Transform child2 = IgnorePanel.GetChild(j);
			if (child2 != DragObject && child2.gameObject.activeSelf)
			{
				_specPool.Add(child2.GetComponent<RectTransform>());
			}
			child2.gameObject.SetActive(false);
		}
		if (selected != Employee.EmployeeRole.Service)
		{
			string[] unlockedSpecializations = GameSettings.Instance.GetUnlockedSpecializations(selected);
			for (int k = 0; k < unlockedSpecializations.Length; k++)
			{
				RectTransform spec = GetSpec();
				spec.name = unlockedSpecializations[k];
				spec.GetComponentInChildren<Text>().text = unlockedSpecializations[k].Loc();
				spec.transform.SetParent(IgnorePanel.transform, false);
				spec.transform.SetSiblingIndex(k);
			}
		}
	}

	public RectTransform GetSpec()
	{
		if (_specPool.Count > 0)
		{
			RectTransform rectTransform = _specPool[0];
			_specPool.RemoveAt(0);
			rectTransform.gameObject.SetActive(true);
			return rectTransform;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(SpecPrefab);
		EventTrigger component = gameObject.GetComponent<EventTrigger>();
		RectTransform rt = gameObject.GetComponent<RectTransform>();
		component.AddTrigger(EventTriggerType.PointerDown, delegate(BaseEventData x)
		{
			PointerEventData pointerEventData;
			if ((pointerEventData = x as PointerEventData) != null && pointerEventData.button == PointerEventData.InputButton.Left && _activeDrag != rt)
			{
				_activeDrag = rt;
				_lastPanel = rt.parent;
				rt.SetParent(WindowManager.Instance.Canvas.transform, false);
			}
		});
		return rt;
	}

	private bool Contains(RectTransform t, Vector2 p)
	{
		if (p.x >= 0f && p.y <= 0f && p.x <= t.rect.width)
		{
			return 0f - p.y <= t.rect.height;
		}
		return false;
	}

	private void Update()
	{
		if (!(_activeDrag != null))
		{
			return;
		}
		_activeDrag.anchoredPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y - (float)Screen.height) * (1f / Options.UISize);
		RectTransform rectTransform = null;
		int siblingIndex = 0;
		Vector2 localPoint;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(PriorityPanel, Input.mousePosition, UICamSize.GetUICam(), out localPoint) && Contains(PriorityViewport, localPoint))
		{
			rectTransform = PriorityPanel;
		}
		if (rectTransform == null && RectTransformUtility.ScreenPointToLocalPointInRectangle(IgnorePanel, Input.mousePosition, UICamSize.GetUICam(), out localPoint) && Contains(IgnoreViewport, localPoint))
		{
			rectTransform = IgnorePanel;
		}
		if (rectTransform != null)
		{
			siblingIndex = Mathf.Min(Mathf.FloorToInt((0f - localPoint.y) / 24f), rectTransform.GetActiveChildCount(DragObject));
			DragObject.gameObject.SetActive(true);
			DragObject.transform.SetParent(rectTransform, false);
			DragObject.transform.SetSiblingIndex(siblingIndex);
		}
		else
		{
			DragObject.gameObject.SetActive(false);
		}
		if (Input.GetMouseButtonUp(0))
		{
			if (rectTransform != null)
			{
				_activeDrag.SetParent(rectTransform, false);
				_activeDrag.SetSiblingIndex(siblingIndex);
				_activeDrag = null;
			}
			else
			{
				_activeDrag.SetParent(_lastPanel, false);
				_activeDrag = null;
			}
			DragObject.gameObject.SetActive(false);
			UpdateCost();
		}
	}

	public int GetSpecPriorityCount()
	{
		if (RoleCombo.Selected == 4)
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < PriorityPanel.childCount; i++)
		{
			Transform child = PriorityPanel.GetChild(i);
			if (child != DragObject && child.gameObject.activeSelf)
			{
				num++;
			}
		}
		return num;
	}

	public string[] GetSpecPriority()
	{
		if (RoleCombo.Selected == 4)
		{
			return new string[1] { SpecCombo.SelectedItemString };
		}
		if (!SpecPriority.isOn)
		{
			return new string[0];
		}
		List<string> list = new List<string>();
		for (int i = 0; i < PriorityPanel.childCount; i++)
		{
			Transform child = PriorityPanel.GetChild(i);
			if (child != DragObject && child.gameObject.activeSelf)
			{
				list.Add(child.name);
			}
		}
		return list.ToArray();
	}

	public void ShowLeads()
	{
		TutorialSystem.Instance.StartTutorial("Lead Designers");
		List<Employee> list = MarketSimulation.Active.FreeLeads.Where((Employee x) => !x.PlayerQuarantine.HasValue || SDateTime.Now() > x.PlayerQuarantine.Value).ToList();
		if (list.Count > 0)
		{
			RoleCombo.Selected = 2;
			list.ForEachEnum(delegate(Employee x)
			{
				x.RefreshSalary();
			});
			HireWin.ShowSpecific(list);
			Window.Close();
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("NoFreeLeads".Loc(), true, DialogWindow.DialogType.Information);
		}
	}
}
