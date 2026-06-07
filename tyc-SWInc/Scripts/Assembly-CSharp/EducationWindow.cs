using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class EducationWindow : MonoBehaviour
{
	public GUIListView EmployeeList;

	public GUICombobox RoleCombo;

	public GUICombobox SpecCombo;

	public const int EducationMonths = 1;

	public static float[] EdCost = new float[3] { 600f, 2000f, 5000f };

	public GUIWindow Window;

	public VarValueSheet EdSheet;

	public SpecializationChart SpecChart;

	public Text StartLabel;

	private bool _disableAutoPick;

	public Employee.EmployeeRole SelectedRole
	{
		get
		{
			string selectedItemString = RoleCombo.SelectedItemString;
			if (selectedItemString != null)
			{
				return (Employee.EmployeeRole)Enum.Parse(typeof(Employee.EmployeeRole), selectedItemString);
			}
			return Employee.EmployeeRole.Lead;
		}
	}

	public static float GetEducationCost(int specLevel)
	{
		return EdCost[Mathf.Clamp(specLevel, 0, EdCost.Length - 1)];
	}

	public void UpdateCombos()
	{
		string text = ((RoleCombo.Selected > -1) ? RoleCombo.SelectedItemString : null);
		List<string> list = new List<string>();
		List<Actor> list2 = EmployeeList.Items.OfType<Actor>().ToList();
		for (int i = 0; i < 5; i++)
		{
			Employee.EmployeeRole employeeRole = (Employee.EmployeeRole)i;
			for (int j = 0; j < list2.Count; j++)
			{
				Actor actor = list2[j];
				if (actor.employee.SpecPointsLeft(employeeRole, actor) && actor.employee.GetSpecExperience(employeeRole, actor) >= 1f)
				{
					list.Add(employeeRole.ToString());
					break;
				}
			}
		}
		RoleCombo.UpdateContent(list);
		if (list.Count > 0)
		{
			if (RoleCombo.Items.Contains(text))
			{
				RoleCombo.SelectedItem = text;
			}
			else
			{
				RoleCombo.Selected = 0;
			}
		}
	}

	public void UpdateSpecCombo()
	{
		Employee.EmployeeRole selectedRole = SelectedRole;
		string[] unlockedSpecializations = GameSettings.Instance.GetUnlockedSpecializations(selectedRole);
		HashSet<string> hashSet = new HashSet<string>();
		List<Actor> list = EmployeeList.Items.OfType<Actor>().ToList();
		foreach (string text in unlockedSpecializations)
		{
			for (int j = 0; j < list.Count; j++)
			{
				Actor actor = list[j];
				if (actor.employee.GetSpecExperience(selectedRole, actor) >= 1f && actor.employee.GetSpecialization(selectedRole, text, actor) < 3)
				{
					hashSet.Add(text);
					break;
				}
			}
		}
		SpecCombo.UpdateContent(hashSet);
		if (SpecCombo.Items.Count > 0)
		{
			SpecCombo.Selected = 0;
		}
		else
		{
			UpdateDescription();
		}
	}

	public void AutoSelectSpecRole(bool fromCombo)
	{
		if (_disableAutoPick)
		{
			return;
		}
		Employee.EmployeeRole r = SelectedRole;
		if (!fromCombo)
		{
			bool flag = false;
			Actor[] selected = EmployeeList.GetSelected<Actor>();
			foreach (Actor actor in selected)
			{
				for (int j = 0; j < 5; j++)
				{
					Employee.EmployeeRole employeeRole = (Employee.EmployeeRole)j;
					if (actor.employee.SpecPointsLeft(employeeRole, actor) && actor.employee.GetSpecExperience(employeeRole, actor) >= 1f)
					{
						r = employeeRole;
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
		}
		SpecChart.RoleCombo.Selected = SpecChart.GetCombo(r);
	}

	public void UpdateDescription()
	{
		int[] array = new int[3];
		Employee.EmployeeRole selectedRole = SelectedRole;
		string selectedItemString = SpecCombo.SelectedItemString;
		if (selectedItemString != null)
		{
			foreach (Actor item in EmployeeList.Items.OfType<Actor>())
			{
				if (item.employee.GetSpecExperience(selectedRole, item) >= 1f)
				{
					int specialization = item.employee.GetSpecialization(selectedRole, selectedItemString, item);
					if (specialization >= 0 && specialization < 3)
					{
						array[specialization]++;
					}
				}
			}
		}
		float num = 0f;
		for (int i = 0; i < 3; i++)
		{
			num += (float)array[i] * GetEducationCost(i);
		}
		EdSheet.UpdateValues(new string[4]
		{
			"Employee".LocPlural(array[0]),
			"Employee".LocPlural(array[1]),
			"Employee".LocPlural(array[2]),
			num.Currency()
		});
	}

	public bool ValidForEdu(Actor ac)
	{
		Employee.EmployeeRole selectedRole = SelectedRole;
		return ac.employee.GetSpecExperience(selectedRole, ac) >= 1f;
	}

	public void SendEm()
	{
		Employee.EmployeeRole selectedRole = SelectedRole;
		string selectedItemString = SpecCombo.SelectedItemString;
		if (selectedItemString == null)
		{
			return;
		}
		bool flag = false;
		foreach (Actor item in EmployeeList.Items.OfType<Actor>().ToList())
		{
			if (item == null)
			{
				EmployeeList.Items.Remove(item);
			}
			else
			{
				if (!(item.employee.GetSpecExperience(selectedRole, item) >= 1f))
				{
					continue;
				}
				int specialization = item.employee.GetSpecialization(selectedRole, selectedItemString, item);
				if (specialization < 3)
				{
					float educationCost = GetEducationCost(specialization);
					if (!GameSettings.Instance.MyCompany.CanMakeTransaction(0f - educationCost))
					{
						WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), true, DialogWindow.DialogType.Error);
						break;
					}
					flag = true;
					GameSettings.Instance.MyCompany.MakeTransaction(0f - educationCost, Company.TransactionCategory.Education, true);
					SendEmployee(item, selectedRole, selectedItemString);
					if (!item.employee.AnySpecPoints(item))
					{
						EmployeeList.Items.Remove(item);
					}
				}
			}
		}
		if (flag)
		{
			UISoundFX.PlaySFX("Kaching");
		}
		HUD.Instance.employeeWindow.UpdateEdNumber();
		if (EmployeeList.Items.Count == 0)
		{
			Window.Close();
			return;
		}
		UpdateCombos();
		UpdateDescription();
	}

	public void SendEmployeeDirect(Actor emp, Employee.EmployeeRole r, string spec, int toLvl)
	{
		toLvl = Mathf.Min(toLvl, 3);
		if (!emp.employee.SpecPointsLeft(r, emp))
		{
			return;
		}
		bool flag = false;
		int specialization = emp.employee.GetSpecialization(r, spec, emp);
		if (specialization >= toLvl)
		{
			return;
		}
		for (int i = specialization; i < toLvl; i++)
		{
			if (!(emp.employee.GetSpecExperience(r, emp) >= 1f))
			{
				break;
			}
			float educationCost = GetEducationCost(i);
			if (GameSettings.Instance.MyCompany.CanMakeTransaction(0f - educationCost))
			{
				GameSettings.Instance.MyCompany.MakeTransaction(0f - educationCost, Company.TransactionCategory.Education, true);
				flag = true;
				SendEmployee(emp, r, spec);
				if (!emp.employee.AnySpecPoints(emp))
				{
					EmployeeList.Items.Remove(emp);
					break;
				}
				continue;
			}
			WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), true, DialogWindow.DialogType.Error);
			break;
		}
		if (flag)
		{
			UISoundFX.PlaySFX("Kaching");
		}
		HUD.Instance.employeeWindow.UpdateEdNumber();
		if (EmployeeList.Items.Count == 0)
		{
			Window.Close();
			return;
		}
		EmployeeList.Select(0);
		UpdateCombos();
		UpdateDescription();
	}

	public void SendEmployee(Actor emp, Employee.EmployeeRole role, string spec)
	{
		SDateTime? arriveTime = GameSettings.Instance.sActorManager.GetArriveTime(emp);
		SDateTime sDateTime = SDateTime.Now();
		if (arriveTime.HasValue)
		{
			sDateTime = arriveTime.Value + 1;
		}
		else
		{
			sDateTime += new SDateTime(1, 1, 0);
			sDateTime = new SDateTime(0, emp.SpawnTime, sDateTime.Day, sDateTime.Month, sDateTime.Year);
			sDateTime = AI.MakeArrivalTime(sDateTime, emp);
		}
		if (sDateTime.Month == 5 && sDateTime.Day == 0 && GameSettings.Instance.ConferenceController.IsInBooth(emp.employee))
		{
			sDateTime += new SDateTime(1, 0, 0);
		}
		emp.IgnoreOffSalary |= emp.SpecialState != Actor.HomeState.Vacation && !emp.TakingCourses;
		emp.Courses.Add(new KeyValuePair<Employee.EmployeeRole, string>(role, spec));
		emp.LastCourse = SDateTime.Now();
		GameSettings.Instance.sActorManager.ReadyForBus.Remove(emp);
		GameSettings.Instance.sActorManager.AddToAwaiting(emp, sDateTime, true);
	}

	private void Start()
	{
		EmployeeList.OnSelectChange = delegate
		{
			SpecChart.SetContent(EmployeeList.GetSelected<Actor>().SelectInPlace((Actor z) => z.employee));
			AutoSelectSpecRole(false);
		};
		EmployeeList.Initialize();
		EdSheet.SetData(new string[4]
		{
			"LevelPre".Loc(1, GetEducationCost(0).Currency()),
			"LevelPre".Loc(2, GetEducationCost(1).Currency()),
			"LevelPre".Loc(3, GetEducationCost(2).Currency()),
			"Totalcost".Loc()
		}, new string[5]);
		StartLabel.text = "Starteducation".Loc() + " (" + "Month".LocPlural(1) + ")";
	}

	public void Show(IEnumerable<Actor> affect)
	{
		int num = 0;
		List<Actor> list = new List<Actor>();
		bool max = false;
		foreach (Actor item in affect)
		{
			num++;
			if (item.employee.AnySpecPoints(ref max, item))
			{
				list.Add(item);
			}
		}
		if (list.Count == 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("EmployeeCourseBookError".Loc(num));
			stringBuilder.AppendLine(max ? "EmployeeCourseBookErrorMax".Loc() : "EmployeeCourseBookErrorXP".Loc());
			WindowManager.Instance.ShowMessageBox(stringBuilder.ToString(), false, DialogWindow.DialogType.Error);
			return;
		}
		EmployeeList.Items.Clear();
		EmployeeList.Items.AddRange(list.Cast<object>());
		if (list.Count == 1)
		{
			HintController.Show(HintController.Hints.HintEmployeeEducation);
		}
		Window.Show();
		UpdateCombos();
		TutorialSystem.Instance.StartTutorial("Education");
		EmployeeList.Select(0);
	}
}
