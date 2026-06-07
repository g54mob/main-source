using System;
using System.Collections.Generic;
using System.Linq;
using DevConsole;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class HireWindow : MonoBehaviour
{
	public GUIWindow Window;

	public LookHireWindow LookHire;

	public GameObject PersonInterviewPanel;

	public GameObject SpecInterviewPanel;

	public GameObject SpecLabel;

	public GameObject DemandTitle;

	public Transform DemandPanel;

	public LeadDesignControl LeadControl;

	public GUIListView EmployeeList;

	public Text Personlity;

	public Text CompatText;

	public Text TeamLabel;

	public Button SkillInterviewButton;

	public Button PersonInterviewButton;

	public Color[] CompatColors;

	public Toggle CompareTeam;

	public RawImage EmpThumb;

	[NonSerialized]
	public Dictionary<Employee, float> Compatibility = new Dictionary<Employee, float>();

	public SpecializationChart chart;

	[NonSerialized]
	public string SelectedTeam;

	[NonSerialized]
	private LookHireWindow.HireFilter _hireFilter;

	[NonSerialized]
	public Dictionary<KeyValuePair<Employee.EmployeeRole, Employee.WageBracket>, List<Employee>> HirePool = new Dictionary<KeyValuePair<Employee.EmployeeRole, Employee.WageBracket>, List<Employee>>();

	public UITrait[] TraitIcons;

	private static float[] _bracketRatios = new float[3] { 0.5f, 0.35f, 0.15f };

	public int BonusPool;

	private bool AboutToHire;

	private bool _foundNew = true;

	[NonSerialized]
	private bool lookingAgain;

	private bool _disableInput;

	public Team GetCompareTeam()
	{
		if (SelectedTeam != null && CompareTeam.isOn)
		{
			return GameSettings.Instance.sActorManager.Teams.GetOrNull(SelectedTeam);
		}
		return null;
	}

	public Team GetSelectedTeam()
	{
		if (SelectedTeam == null)
		{
			return null;
		}
		return GameSettings.Instance.sActorManager.Teams.GetOrNull(SelectedTeam);
	}

	public int GetEmployeePoolCount(LookHireWindow.HireFilter filter)
	{
		return GetEmployeePoolCount(filter.Wage, filter.TeamCompatibility != null, filter.SecondaryRole.HasValue, (filter.Role != Employee.EmployeeRole.Service && filter.SpecFilter != null) ? filter.SpecFilter.Length : 0, filter.RequireTrait != Employee.Trait.None, filter.FilterTrait.Length);
	}

	public int GetEmployeePoolCount(Employee.WageBracket b, bool compatibility, bool secondary, int specs, bool requireTrait, int filterTraits)
	{
		return Mathf.FloorToInt(GameSettings.Instance.Environment.EmployeePool * _bracketRatios[(int)b] * (float)(100 + BonusPool + MarketSimulation.Active.Layoffs) * GameSettings.Instance.ApplicantScore.GetAppeal() * (1f / (1f + (float)specs * 0.25f) * (compatibility ? 0.5f : 1f) * (secondary ? 0.75f : 1f) * (requireTrait ? 0.75f : 1f) * (1f / (1f + (float)filterTraits * 0.1f))));
	}

	public static bool EmployeeMatch(Employee emp, LookHireWindow.HireFilter filter)
	{
		if (filter.SecondaryRole.HasValue)
		{
			int num = -1;
			float num2 = 0f;
			for (int i = 0; i < 5; i++)
			{
				if (i != (int)emp.HiredFor)
				{
					float skill = emp.GetSkill((Employee.EmployeeRole)i);
					if (skill > num2)
					{
						num2 = skill;
						num = i;
					}
				}
			}
			if (num != (int)filter.SecondaryRole.Value)
			{
				return false;
			}
		}
		if (filter.SpecFilter != null)
		{
			for (int j = 0; j < Mathf.Min(2, filter.SpecFilter.Length); j++)
			{
				if (emp.GetSpecialization(emp.HiredFor, filter.SpecFilter[j]) == 0)
				{
					return false;
				}
			}
		}
		if (filter.TeamCompatibility != null)
		{
			Team team = GameSettings.GetTeam(filter.TeamCompatibility);
			if (team != null && team.GetMinCompatibility(emp) < 1f)
			{
				return false;
			}
		}
		if (filter.RequireTrait != Employee.Trait.None && !emp.Traits.HasBits(filter.RequireTrait))
		{
			return false;
		}
		for (int k = 0; k < filter.FilterTrait.Length; k++)
		{
			if (emp.Traits.HasBits(filter.FilterTrait[k]))
			{
				return false;
			}
		}
		return true;
	}

	private void Awake()
	{
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				HirePool[new KeyValuePair<Employee.EmployeeRole, Employee.WageBracket>((Employee.EmployeeRole)i, (Employee.WageBracket)j)] = new List<Employee>();
			}
		}
		EmployeeList.OnSelectChange = delegate
		{
			Employee firstSelected = EmployeeList.GetFirstSelected<Employee>();
			if (firstSelected != null)
			{
				PersonInterviewPanel.SetActive(true);
				SpecInterviewPanel.SetActive(true);
				UpdateInterviewPanel(firstSelected);
				chart.SetContent(new Employee[1] { firstSelected });
				Team team = ((SelectedTeam == null) ? null : GameSettings.Instance.sActorManager.Teams.GetOrNull(SelectedTeam));
				if (firstSelected.StyleGen == null)
				{
					firstSelected.StyleGen = ActorGenerator.Instance.GenerateStyle(firstSelected.Female, "Default", firstSelected.GetAge());
				}
				else
				{
					ActorGenerator.SetStyleAge(firstSelected.StyleGen, firstSelected.GetAge());
				}
				KeyValuePair<PortraitMaker.PortraitAtlas, Vector2Int> actorTex = HUD.Instance.Portraits.GetActorTex(firstSelected);
				float num = 1f / (float)PortraitMaker.PortraitPerAtlas;
				Rect uvRect = new Rect((float)actorTex.Value.x * num, (float)actorTex.Value.y * num, num, num);
				EmpThumb.texture = actorTex.Key.Tex;
				EmpThumb.uvRect = uvRect;
				if (team != null)
				{
					CompatText.text = "Compatibility".Loc() + ": " + GetCompatibility(team);
					CompatText.color = GetCompatColor(team);
					chart.CompareTeam = GetCompareTeam();
					chart.MinSkillTeam = team;
				}
				else
				{
					CompatText.text = "Compatibility".Loc() + ": " + "TeamCompat0".Loc();
					CompatText.color = GetCompatColor(null);
					chart.CompareTeam = null;
					chart.MinSkillTeam = null;
				}
				if (firstSelected.CreativityKnown > 0f)
				{
					LeadControl.gameObject.SetActive(true);
					LeadControl.Init(firstSelected);
				}
				else
				{
					LeadControl.Init(null);
					LeadControl.gameObject.SetActive(false);
				}
				if (firstSelected.DemandsMet != 0)
				{
					DemandTitle.SetActive(true);
					DemandPanel.gameObject.SetActive(true);
					Utilities.InitializeDemands(firstSelected, DemandPanel);
				}
				else
				{
					DemandTitle.SetActive(false);
					DemandPanel.gameObject.SetActive(false);
				}
			}
			else
			{
				LeadControl.Init(null);
				PersonInterviewPanel.SetActive(false);
				SpecInterviewPanel.SetActive(false);
				LeadControl.gameObject.SetActive(false);
				DemandTitle.SetActive(false);
				DemandPanel.gameObject.SetActive(false);
			}
		};
		Window.OnClose = delegate
		{
			GameSettings.ForcePause = false;
		};
	}

	public void UpdateCompatibilities(IEnumerable<Employee> employees)
	{
		Compatibility.Clear();
		if (SelectedTeam != null)
		{
			Team orNull = GameSettings.Instance.sActorManager.Teams.GetOrNull(SelectedTeam);
			if (orNull != null && orNull.Count > 0)
			{
				foreach (Employee employee in employees)
				{
					Compatibility[employee] = orNull.GetMinCompatibility(employee);
				}
			}
		}
		EmployeeList.UpdateActiveList();
	}

	public static Color GetCompatibilityColor(float compat, Color[] colors)
	{
		if (compat < 0.5f)
		{
			return colors[0];
		}
		if (compat < 0.9f)
		{
			return Color.Lerp(colors[0], colors[1], (compat - 0.5f) / 0.4f);
		}
		if (compat < 1f)
		{
			return Color.Lerp(colors[1], colors[2], (compat - 0.9f) / 0.1f);
		}
		return colors[2];
	}

	private Color GetCompatColor(Team team)
	{
		if (team != null && team.GetEmployees().Length != 0)
		{
			Employee firstSelected = EmployeeList.GetFirstSelected<Employee>();
			if (firstSelected != null)
			{
				return GetCompatibilityColor(team.GetMinCompatibility(firstSelected), CompatColors);
			}
		}
		return new Color32(50, 50, 50, byte.MaxValue);
	}

	private string GetCompatibility(Team team)
	{
		if (team.GetEmployees().Length != 0)
		{
			Employee firstSelected = EmployeeList.GetFirstSelected<Employee>();
			if (firstSelected != null)
			{
				return Team.GetCompatDesc(team.GetMinCompatibility(firstSelected));
			}
			return "TeamCompat0".Loc();
		}
		return "TeamCompat0".Loc();
	}

	public void ShowSpecific(List<Employee> emps)
	{
		_hireFilter = null;
		EmployeeList.Items.Clear();
		EmployeeList.Selected.Clear();
		if (SelectedTeam != null && GameSettings.Instance.sActorManager.Teams.ContainsKey(SelectedTeam))
		{
			ChangeTeam(SelectedTeam);
		}
		else
		{
			ChangeTeam(GameSettings.Instance.sActorManager.Teams.Keys.FirstOrDefault());
		}
		Compatibility.Clear();
		UpdateCompatibilities(emps);
		EmployeeList.Items = ((IEnumerable<object>)emps).ToList();
		EmployeeList.scrollbar.value = 0f;
		Window.Show();
		GameSettings.ForcePause = true;
		GameSettings.FreezeGame = true;
		if (EmployeeList.Items.Count > 0)
		{
			EmployeeList.Select(0);
			EmployeeList.OnSelectChange(true);
		}
		ListViewFocus.ActiveListView = EmployeeList;
	}

	public bool Show(float cost, LookHireWindow.HireFilter filter, bool withWindow = true)
	{
		EmployeeList.Items.Clear();
		EmployeeList.Selected.Clear();
		_hireFilter = filter;
		if (_hireFilter.TeamCompatibility != null && GameSettings.Instance.sActorManager.Teams.ContainsKey(_hireFilter.TeamCompatibility))
		{
			ChangeTeam(_hireFilter.TeamCompatibility);
		}
		if (SelectedTeam != null && GameSettings.Instance.sActorManager.Teams.ContainsKey(SelectedTeam))
		{
			ChangeTeam(SelectedTeam);
		}
		else
		{
			ChangeTeam(GameSettings.Instance.sActorManager.Teams.Keys.FirstOrDefault());
		}
		Compatibility.Clear();
		Employee[] array = GenerateEmployees(_hireFilter);
		if (array.Length == 0)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(cost, Company.TransactionCategory.Hire, true);
			WindowManager.Instance.ShowMessageBox("EmployeeSearchFail".Loc(), true, DialogWindow.DialogType.Warning);
			return false;
		}
		if (!_foundNew)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(cost, Company.TransactionCategory.Hire, true);
			WindowManager.Instance.ShowMessageBox("NoNewApplicants".Loc(cost.Currency()), true, DialogWindow.DialogType.Information, Window);
		}
		UpdateCompatibilities(array);
		EmployeeList.Items = ((IEnumerable<object>)array).ToList();
		EmployeeList.scrollbar.value = 0f;
		ReevaluateSalaries();
		if (withWindow)
		{
			Window.Show();
			GameSettings.ForcePause = true;
			GameSettings.FreezeGame = true;
		}
		if (EmployeeList.Items.Count > 0)
		{
			EmployeeList.Select(0);
			EmployeeList.OnSelectChange(true);
		}
		ListViewFocus.ActiveListView = EmployeeList;
		return true;
	}

	public void RemoveEmployee(Employee emp)
	{
		emp.Filter = true;
		EmployeeList.Items.Remove(emp);
	}

	public void HireEmployee(Employee emp, bool clearSelected = true)
	{
		if (AboutToHire)
		{
			return;
		}
		if ((emp.MyEmployer == null || !emp.MyEmployer.IsPlayerOwned()) && !GameSettings.IgnoreBusinessRep && emp.LastDemandScore > GameSettings.Instance.MyCompany.BusinessReputation)
		{
			int num = Mathf.CeilToInt(emp.LastDemandScore * 6f);
			WindowManager.Instance.ShowMessageBox("LeadBusinessRep".Loc(num), true, DialogWindow.DialogType.Warning);
			return;
		}
		float upfrontCost = emp.GetUpfrontCost(emp.MyEmployer != null && emp.MyEmployer.IsPlayerOwned());
		if (upfrontCost > 0f)
		{
			bool flag = GameSettings.Instance.MyCompany.CanMakeTransaction(0f - upfrontCost);
			bool flag2 = GameSettings.Instance.MyCompany.CanMakeTransaction(0f - (upfrontCost - emp.UpfrontDemand)) && GameSettings.Instance.OffshoreAccount >= (double)emp.UpfrontDemand && GameSettings.Instance.HeatPercent < 0.9f;
			if (!flag && !flag2)
			{
				WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), true, DialogWindow.DialogType.Error);
				return;
			}
			AboutToHire = true;
			List<KeyValuePair<string, Action>> list = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("No", delegate
				{
					AboutToHire = false;
				})
			};
			if (flag2)
			{
				list.Insert(0, new KeyValuePair<string, Action>("UseOffshoreAccount", delegate
				{
					HireSustainableCheck(emp, clearSelected, true);
				}));
			}
			if (flag)
			{
				list.Insert(0, new KeyValuePair<string, Action>("Yes", delegate
				{
					HireSustainableCheck(emp, clearSelected, false);
				}));
			}
			WindowManager.Instance.ShowMessageBox("HireDemandPrice".LocColor(upfrontCost.Currency()), false, DialogWindow.DialogType.Warning, list.ToArray()).Window.SetParentWindow(Window);
		}
		else
		{
			AboutToHire = true;
			HireSustainableCheck(emp, clearSelected, false);
		}
	}

	private void HireRetirementCheck(Employee emp, bool clearSelected, bool useOffshore)
	{
		if (SDateTime.GetYears(emp.BirthDate, SDateTime.Now()) >= (float)(Employee.RetirementAge - 3))
		{
			DialogWindow dialogWindow = WindowManager.Instance.ShowMessageBox("RetireWarning".LocColor(SDateTime.DateDiff(SDateTime.Now(), emp.BirthDate + Employee.RetirementAge * 12)), false, DialogWindow.DialogType.Warning, delegate
			{
				HireSub(emp, clearSelected, useOffshore);
			}, "HireRetirementWarning", delegate
			{
				AboutToHire = false;
			});
			if (dialogWindow != null)
			{
				dialogWindow.Window.SetParentWindow(Window);
			}
		}
		else
		{
			HireSub(emp, clearSelected, useOffshore);
		}
	}

	private void HireSustainableCheck(Employee emp, bool clearSelected, bool useOffshore)
	{
		if ((double)emp.GetMonthlySalary(GetSelectedTeam()) > GameSettings.Instance.MyCompany.Money / 24.0)
		{
			DialogWindow dialogWindow = WindowManager.Instance.ShowMessageBox("LowMoneyHireWarning".LocColor(emp), false, DialogWindow.DialogType.Warning, delegate
			{
				HireRetirementCheck(emp, clearSelected, useOffshore);
			}, "HireMoneyWarning", delegate
			{
				AboutToHire = false;
			});
			if (dialogWindow != null)
			{
				dialogWindow.Window.SetParentWindow(Window);
			}
		}
		else
		{
			HireRetirementCheck(emp, clearSelected, useOffshore);
		}
	}

	private void DoActualHiring(Employee emp, bool clearSelected, bool useOffshore)
	{
		emp.Filter = true;
		SimulatedCompany simulatedCompany = emp.MyEmployer as SimulatedCompany;
		if (simulatedCompany != null)
		{
			emp.Dismiss(false);
			simulatedCompany.LeadDesigner = null;
			if (!simulatedCompany.IsPlayerOwned())
			{
				simulatedCompany.FindNewLead(SDateTime.Now(), false);
			}
			else
			{
				simulatedCompany.LeadDesigner = null;
			}
		}
		emp.Employ(GameSettings.Instance.MyCompany, SDateTime.Now(), emp.MyEmployer != null && emp.MyEmployer.IsPlayerOwned(), useOffshore);
		GameSettings.Instance.RegisterStat("Hired", 1f);
		GameSettings.Instance.SpawnActor(emp).Team = SelectedTeam;
		if (EmployeeList.GetFirstSelected<Employee>() == emp)
		{
			int b = EmployeeList.Selected[0];
			EmployeeList.ClearSelected();
			EmployeeList.Items.Remove(emp);
			UpdateCompatibilities(EmployeeList.Items.OfType<Employee>());
			if (!clearSelected && EmployeeList.Items.Count > 0)
			{
				EmployeeList.UpdateElements();
				EmployeeList.Select(Mathf.Min(EmployeeList.Items.Count - 1, b));
			}
		}
		else
		{
			EmployeeList.Items.Remove(emp);
			UpdateCompatibilities(EmployeeList.Items.OfType<Employee>());
		}
	}

	private void HireSub(Employee emp, bool clearSelected, bool useOffshore)
	{
		if (emp.NetworkID != 0)
		{
			NetworkMessaging.VerifiedNetworkMessage(NetworkMessaging.SyncType.Employee, emp.NetworkID, emp.EmployerID, GameSettings.Instance.MyCompany.ID, delegate(bool x)
			{
				if (x)
				{
					DoActualHiring(emp, clearSelected, useOffshore);
					NetworkMessaging.MoveLeadDesigner(emp, GameSettings.Instance.MyCompany, false, false);
				}
				AboutToHire = false;
			}, null, delegate
			{
				AboutToHire = true;
			});
		}
		else
		{
			DoActualHiring(emp, clearSelected, useOffshore);
			AboutToHire = false;
		}
	}

	public int GetEmployeesLeft(List<Employee> employees, Team team, LookHireWindow.HireFilter filter, int num = -1)
	{
		if (num < 0)
		{
			num = GetEmployeePoolCount(filter);
		}
		List<Employee> list = HirePool[new KeyValuePair<Employee.EmployeeRole, Employee.WageBracket>(filter.Role, filter.Wage)];
		Employee.EmployeeRole[] roles = ((!filter.SecondaryRole.HasValue) ? new Employee.EmployeeRole[1] { filter.Role } : new Employee.EmployeeRole[2]
		{
			filter.Role,
			filter.SecondaryRole.Value
		});
		for (int i = 0; i < list.Count; i++)
		{
			if (EmployeeMatch(list[i], filter))
			{
				if (!list[i].Filter)
				{
					list[i].CustomBenefits = ((filter.Benefits != null) ? filter.Benefits.ToDictionary() : new Dictionary<string, float>());
					list[i].ReevaluateSalary(roles, filter.SpecFilter, team);
					employees.Add(list[i]);
				}
				else
				{
					num--;
				}
				if (employees.Count >= num)
				{
					break;
				}
			}
		}
		num -= employees.Count;
		return Mathf.Min(num, Mathf.Max(0, GetEmployeePoolCount(filter.Wage, false, false, 0, false, 0) - list.Count));
	}

	public Employee[] GenerateEmployees(int num, Employee.WageBracket bracket, Employee.EmployeeRole role, bool fromPool, Employee.EmployeeRole? secondaryRole = null, string[] spec = null, Team compatTeam = null, Employee.Trait require = Employee.Trait.None, Employee.Trait filter = Employee.Trait.None, LookHireWindow.HireFilter hFilter = null, Team team = null)
	{
		_foundNew = true;
		List<Employee> list = new List<Employee>();
		if (fromPool)
		{
			if (hFilter == null)
			{
				Debug.Log("Tried generating employees from pool with no hire filter");
				return new Employee[0];
			}
			num = GetEmployeesLeft(list, team, hFilter, num);
		}
		List<Employee> list2 = HirePool[new KeyValuePair<Employee.EmployeeRole, Employee.WageBracket>(role, bracket)];
		if (num <= 0)
		{
			if (list.Count > 0)
			{
				_foundNew = false;
			}
		}
		else
		{
			Employee.EmployeeRole[] roles = ((!secondaryRole.HasValue) ? new Employee.EmployeeRole[1] { role } : new Employee.EmployeeRole[2] { role, secondaryRole.Value });
			for (int i = 0; i < num; i++)
			{
				SDateTime currentTime = SDateTime.Now();
				bool female = UnityEngine.Random.value > 0.5f;
				PersonalityGraph personalities = GameSettings.Instance.Personalities;
				LookHireWindow.HireFilter hireFilter = _hireFilter;
				Employee item = new Employee(currentTime, roles, female, bracket, personalities, "Default", false, spec, compatTeam, 1f, 0.1f, require, filter, false, (hireFilter != null) ? hireFilter.Benefits : null);
				list.Add(item);
				if (fromPool)
				{
					list2.Add(item);
				}
			}
		}
		return list.ToArray();
	}

	public Employee[] GenerateEmployees(LookHireWindow.HireFilter filter)
	{
		Team team = ((filter.TeamCompatibility != null) ? GameSettings.GetTeam(filter.TeamCompatibility) : null);
		if (team != null && (team.MinCompatibility < 1f || team.Count == 0))
		{
			team = null;
		}
		Employee.Trait trait = Employee.Trait.None;
		for (int i = 0; i < filter.FilterTrait.Length; i++)
		{
			trait |= filter.FilterTrait[i];
		}
		return GenerateEmployees(GetEmployeePoolCount(filter), filter.Wage, filter.Role, true, filter.SecondaryRole, filter.SpecFilter, team, filter.RequireTrait, trait, filter, GetSelectedTeam());
	}

	public void ReevaluateSalaries()
	{
		if (_hireFilter != null)
		{
			Employee.EmployeeRole[] roles = ((!_hireFilter.SecondaryRole.HasValue) ? new Employee.EmployeeRole[1] { _hireFilter.Role } : new Employee.EmployeeRole[2]
			{
				_hireFilter.Role,
				_hireFilter.SecondaryRole.Value
			});
			EmployeeList.Items.OfType<Employee>().ForEachEnum(delegate(Employee x)
			{
				x.ReevaluateSalary(roles, _hireFilter.SpecFilter, GetSelectedTeam());
			});
		}
	}

	public void LookAgain()
	{
	}

	private void UpdateInterviewPanel(Employee emp)
	{
		Team compareTeam = GetCompareTeam();
		chart.CompareTeam = compareTeam;
		chart.MinSkillTeam = ((SelectedTeam == null) ? null : GameSettings.Instance.sActorManager.Teams.GetOrNull(SelectedTeam));
		Personlity.text = emp.PersonalityTraits[0].LocTry() + "\n" + emp.PersonalityTraits[1].LocTry();
		Utilities.InitTraitUI(emp.Traits, TraitIcons);
	}

	private void Update()
	{
		if (!(WindowManager.Instance.GetFrontMostWindow() == Window) || EmployeeList.ActualItems.Count <= 0 || DevConsole.Console.isOpen || (!Input.GetKeyUp(KeyCode.Return) && !Input.GetKeyUp(KeyCode.KeypadEnter)))
		{
			return;
		}
		if (_disableInput)
		{
			_disableInput = false;
			return;
		}
		Employee firstSelected = EmployeeList.GetFirstSelected<Employee>();
		if (firstSelected != null)
		{
			HireEmployee(firstSelected, false);
		}
	}

	private void UpdateTeamLabel()
	{
		TeamLabel.text = SelectedTeam ?? "None".Loc();
	}

	public void ChangeTeam(string nTeam)
	{
		SelectedTeam = nTeam;
		UpdateTeamLabel();
		UpdateCompatibilities(EmployeeList.Items.OfType<Employee>());
		if (SelectedTeam != null && EmployeeList.Selected.Count > 0)
		{
			Team team = GameSettings.Instance.sActorManager.Teams[SelectedTeam];
			CompatText.text = "Compatibility".Loc() + ": " + GetCompatibility(team);
			CompatText.color = GetCompatColor(team);
		}
		else
		{
			CompatText.text = "Compatibility".Loc() + ": " + "TeamCompat0".Loc();
			CompatText.color = GetCompatColor(null);
		}
		UpdateInterviewPanel();
		ReevaluateSalaries();
		if (Input.GetKey(KeyCode.Return))
		{
			_disableInput = true;
		}
	}

	public void UpdateInterviewPanel()
	{
		Employee firstSelected = EmployeeList.GetFirstSelected<Employee>();
		if (firstSelected != null)
		{
			UpdateInterviewPanel(firstSelected);
		}
	}

	public void PickTeam()
	{
		HUD.Instance.TeamSelectWindow.Show(true, SelectedTeam, delegate(string[] ts)
		{
			ChangeTeam((ts.Length != 0) ? ts[0] : null);
		}, null);
		HUD.Instance.TeamSelectWindow.Window.SetParentWindow(Window);
	}
}
