using System;
using System.Collections.Generic;
using System.Linq;
using Achievements;
using Tyd;
using UnityEngine;

[Serializable]
public class HRManagement
{
	[Serializable]
	public struct EdNeed
	{
		public string Spec;

		public int Level;

		public EdNeed(string spec, int level)
		{
			Spec = spec;
			Level = level;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is EdNeed))
			{
				return false;
			}
			EdNeed edNeed = (EdNeed)obj;
			if (Spec == edNeed.Spec)
			{
				return Level == edNeed.Level;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (1137285643 * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Spec)) * -1521134295 + Level.GetHashCode();
		}

		public override string ToString()
		{
			return "Level " + Level + " " + Spec;
		}
	}

	public enum RoleMode
	{
		Custom = 0,
		HiredFor = 1,
		Best = 2,
		BestThenSecondary = 3
	}

	public float SpentLast;

	public float Spent;

	public float Budget = 1000000f;

	public int[] MaxEmployees = new int[4];

	public SDateTime[] EmptyPool = new SDateTime[4]
	{
		new SDateTime(0),
		new SDateTime(0),
		new SDateTime(0),
		new SDateTime(0)
	};

	public Employee.WageBracket HireBracket;

	public int EducationLevel;

	public float EducationBudget = 4000f;

	public int EducationAmount;

	public int PreferredAge = 35;

	public RoleMode ForceRole;

	public bool HandleWages;

	public bool HandleComplaints;

	public bool AnyActiveFunctions;

	public bool AutoSpec = true;

	public bool AutoSpecHire = true;

	public bool AfterRoleSplit;

	public SHashSet<string> Specs = new SHashSet<string>();

	public SHashSet<string> HireSpecs = new SHashSet<string>();

	public int Complaints;

	public int Resignations;

	public string EducationStatus = "Disabled";

	public Dictionary<EdNeed, int>[] Needs = new Dictionary<EdNeed, int>[4]
	{
		new Dictionary<EdNeed, int>(),
		new Dictionary<EdNeed, int>(),
		new Dictionary<EdNeed, int>(),
		new Dictionary<EdNeed, int>()
	};

	public bool TasksChanged = true;

	public Employee.Trait Require;

	public Employee.Trait Filter;

	public int FilterCount;

	public bool InitRoleSystem = true;

	public bool ControlRole;

	public bool HiredFor = true;

	public bool HireHiredFor = true;

	public float PrimaryRole = 0.8f;

	public float SecondaryRole = -1f;

	private static List<Employee> _lookCache = new List<Employee>();

	private static Dictionary<string, float> _specPriCache = new Dictionary<string, float>();

	private static Dictionary<EdNeed, int> _subCache = new Dictionary<EdNeed, int>();

	public void InitRoleSetup(RoleMode mode, bool force)
	{
		if (InitRoleSystem || force)
		{
			switch (mode)
			{
			case RoleMode.Custom:
				ControlRole = false;
				HiredFor = true;
				PrimaryRole = 0.8f;
				SecondaryRole = -1f;
				break;
			case RoleMode.HiredFor:
				ControlRole = true;
				HiredFor = true;
				PrimaryRole = -1f;
				SecondaryRole = -1f;
				break;
			case RoleMode.Best:
				ControlRole = true;
				HiredFor = false;
				PrimaryRole = 0.8f;
				SecondaryRole = -1f;
				break;
			case RoleMode.BestThenSecondary:
				ControlRole = true;
				HiredFor = false;
				PrimaryRole = 1f;
				SecondaryRole = 0.25f;
				break;
			}
			InitRoleSystem = false;
			UpdateActiveLevel();
		}
	}

	public bool GetAutoSpec(bool forHiring)
	{
		if (forHiring && !AfterRoleSplit)
		{
			AutoSpecHire = AutoSpec;
			HireSpecs = Specs.ToSHashSet();
			AfterRoleSplit = true;
		}
		if (!forHiring)
		{
			return AutoSpec;
		}
		return AutoSpecHire;
	}

	public SHashSet<string> GetSpecs(bool forHiring)
	{
		if (forHiring && !AfterRoleSplit)
		{
			AutoSpecHire = AutoSpec;
			HireSpecs = Specs.ToSHashSet();
			AfterRoleSplit = true;
		}
		if (!forHiring)
		{
			return Specs;
		}
		return HireSpecs;
	}

	public TydTable Serialize()
	{
		TydTable tydTable = new TydTable("HR");
		tydTable["Budget"] = Budget.ToString();
		tydTable.AddChild(new TydList("MaxEmployees", MaxEmployees.SelectInPlace((int x) => x.ToString())));
		tydTable["HireBracket"] = HireBracket.ToString();
		tydTable["EducationLevel"] = EducationLevel.ToString();
		tydTable["EducationAmount"] = EducationAmount.ToString();
		tydTable["HandleWages"] = HandleWages.ToString();
		tydTable["HandleComplaints"] = HandleComplaints.ToString();
		tydTable["AutoSpec"] = AutoSpec.ToString();
		tydTable["AutoSpecHire"] = AutoSpec.ToString();
		tydTable["HireHiredFor"] = HireHiredFor.ToString();
		if (Specs.Count > 0)
		{
			tydTable.AddChild(new TydList("Specs", InvertSpecs(Specs).ToArray()));
		}
		if (HireSpecs.Count > 0)
		{
			tydTable.AddChild(new TydList("HireSpecs", InvertSpecs(HireSpecs).ToArray()));
		}
		tydTable.AddChild(new TydList("RequireTrait", (from x in Employee.EnumTraits(Require)
			select x.ToString()).ToArray()));
		tydTable.AddChild(new TydList("FilterTrait", (from x in Employee.EnumTraits(Filter)
			select x.ToString()).ToArray()));
		tydTable["ControlRole"] = ControlRole.ToString();
		tydTable["HiredFor"] = HiredFor.ToString();
		tydTable["PrimaryRole"] = PrimaryRole.ToString();
		tydTable["SecondaryRole"] = SecondaryRole.ToString();
		return tydTable;
	}

	public static HRManagement Deserialize(TydTable table)
	{
		HRManagement hRManagement = new HRManagement
		{
			AfterRoleSplit = true,
			InitRoleSystem = false
		};
		hRManagement.Budget = table.GetChildValue("Budget", true, 0f);
		hRManagement.MaxEmployees = table.GetChild<TydList>("MaxEmployees").GetChildValues<int>().ToArray();
		Enum.TryParse<Employee.WageBracket>(table["HireBracket"], false, out hRManagement.HireBracket);
		hRManagement.EducationLevel = table.GetChildValue("EducationLevel", true, 0);
		hRManagement.EducationAmount = table.GetChildValue("EducationAmount", true, 0);
		if (table.GetChild<TydString>("ForceRole") != null)
		{
			RoleMode result;
			if (Enum.TryParse<RoleMode>(table["ForceRole"], false, out result))
			{
				hRManagement.InitRoleSetup(result, true);
			}
		}
		else
		{
			hRManagement.ControlRole = table.GetChildValue("ControlRole", false, false);
			hRManagement.HiredFor = table.GetChildValue("HiredFor", false, true);
			hRManagement.PrimaryRole = table.GetChildValue("PrimaryRole", false, 0.8f);
			hRManagement.SecondaryRole = table.GetChildValue("SecondaryRole", false, -1f);
		}
		hRManagement.HireHiredFor = table.GetChildValue("HireHiredFor", false, true);
		hRManagement.HandleWages = table.GetChildValue("HandleWages", true, false);
		hRManagement.HandleComplaints = table.GetChildValue("HandleComplaints", true, false);
		hRManagement.AutoSpec = table.GetChildValue("AutoSpec", true, false);
		TydList child = table.GetChild<TydList>("Specs");
		if (child != null)
		{
			hRManagement.Specs = InvertSpecs(child.GetChildValues().ToHashSet()).ToSHashSet();
		}
		if (table.GetChild("AutoSpecHire") != null)
		{
			hRManagement.AutoSpecHire = table.GetChildValue("AutoSpecHire", true, false);
			child = table.GetChild<TydList>("HireSpecs");
			if (child != null)
			{
				hRManagement.HireSpecs = InvertSpecs(child.GetChildValues().ToHashSet()).ToSHashSet();
			}
		}
		else
		{
			hRManagement.AutoSpecHire = hRManagement.AutoSpec;
			hRManagement.HireSpecs = hRManagement.Specs.ToSHashSet();
		}
		LoadTrait(table.GetChild<TydList>("RequireTrait"), out hRManagement.Require);
		hRManagement.FilterCount = LoadTrait(table.GetChild<TydList>("FilterTrait"), out hRManagement.Filter);
		hRManagement.UpdateActiveLevel();
		return hRManagement;
	}

	private static IEnumerable<string> InvertSpecs(HashSet<string> specs)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (Employee.EmployeeRole item2 in Enum.GetValues(typeof(Employee.EmployeeRole)).OfType<Employee.EmployeeRole>())
		{
			string[] allSpecializations = GameSettings.Instance.GetAllSpecializations(item2);
			foreach (string item in allSpecializations)
			{
				hashSet.Add(item);
			}
		}
		foreach (string item3 in hashSet)
		{
			if (!specs.Contains(item3))
			{
				yield return item3;
			}
		}
	}

	private static int LoadTrait(TydList l, out Employee.Trait t)
	{
		Employee.Trait[] array = l.GetChildValues<Employee.Trait>().ToArray();
		t = array.Aggregate(Employee.Trait.None, (Employee.Trait x, Employee.Trait y) => x | y);
		return array.Length;
	}

	public HRManagement()
	{
	}

	public HRManagement(HRManagement copy)
	{
		Budget = copy.Budget;
		MaxEmployees = copy.MaxEmployees.ToArray();
		HireBracket = copy.HireBracket;
		EducationLevel = copy.EducationLevel;
		EducationBudget = copy.EducationBudget;
		EducationAmount = copy.EducationAmount;
		PreferredAge = copy.PreferredAge;
		HandleWages = copy.HandleWages;
		HandleComplaints = copy.HandleComplaints;
		Specs = copy.Specs.ToSHashSet();
		HireSpecs = copy.HireSpecs.ToSHashSet();
		AutoSpec = copy.AutoSpec;
		AutoSpecHire = copy.AutoSpecHire;
		Require = copy.Require;
		Filter = copy.Filter;
		FilterCount = copy.FilterCount;
		AfterRoleSplit = copy.AfterRoleSplit;
		InitRoleSystem = false;
		HireHiredFor = copy.HireHiredFor;
		if (copy.InitRoleSystem)
		{
			InitRoleSetup(copy.ForceRole, true);
		}
		else
		{
			ControlRole = copy.ControlRole;
			HiredFor = copy.HiredFor;
			PrimaryRole = copy.PrimaryRole;
			SecondaryRole = copy.SecondaryRole;
		}
		UpdateActiveLevel();
	}

	public void UpdateActiveLevel()
	{
		AnyActiveFunctions = false;
		if (HandleWages || HandleComplaints)
		{
			AchievementController.SetInteraction(AchievementController.Mechanics.HR);
			AnyActiveFunctions = true;
			return;
		}
		for (int i = 0; i < MaxEmployees.Length; i++)
		{
			if (MaxEmployees[i] > 0)
			{
				AchievementController.SetInteraction(AchievementController.Mechanics.HR);
				AnyActiveFunctions = true;
				return;
			}
		}
		if (EducationLevel > 0 && EducationAmount != 0)
		{
			AchievementController.SetInteraction(AchievementController.Mechanics.HR);
			AnyActiveFunctions = true;
		}
		else if (ControlRole)
		{
			AchievementController.SetInteraction(AchievementController.Mechanics.HR);
			AnyActiveFunctions = true;
		}
	}

	public bool HandleComplaint(float demand, float actualWorth, Team parent, Actor ac)
	{
		parent.Leader.employee.ChangeSkill(Employee.EmployeeRole.Lead, 0.001f, false);
		Complaints++;
		bool flag = demand / actualWorth < 1.5f;
		if (flag)
		{
			HUD.Instance.LogAuto("AutoLogHRRaise", parent.Name, ((demand - ac.GetRealSalary()) * (float)ac.GetWorkHours(true)).Currency(), ac.employee.FullName);
		}
		return flag;
	}

	public void HandleWage(Actor employee, Team parent)
	{
		employee.NegotiateSalary = false;
		employee.employee.ChangeSalary(employee.employee.Worth(), employee.employee.Worth(), employee, true);
	}

	private void CheckEducation(Team parent)
	{
		if (EducationAmount != 0 && EducationLevel > 0)
		{
			int num = ((EducationAmount >= 0) ? parent.GetEmployeesDirect().Count((Actor x) => x.TakingCourses) : 0);
			if (EducationAmount < 0 || EducationAmount > num)
			{
				if (Budget - Spent < EducationWindow.GetEducationCost(0))
				{
					EducationStatus = "EducationNoBudget";
					return;
				}
				int num2 = EducationAmount - num;
				int num3 = 0;
				float num4 = 0f;
				foreach (Actor item in from x in parent.GetEmployeesDirect()
					where x.employee.GetAgeFlat() < Employee.RetirementAge - 1 && !x.employee.Dismissed && !x.TakingCourses
					orderby x.LastCourse
					select x)
				{
					if (num2 == 0)
					{
						EducationStatus = "EducationEmployeesSent";
						break;
					}
					float num5 = Budget - Spent;
					int num6 = EducationLevel;
					int num7 = EducationLevel - 1;
					while (num7 >= 0 && !(num5 >= EducationWindow.GetEducationCost(num7)))
					{
						num6--;
						num7--;
					}
					if (num6 == 0)
					{
						EducationStatus = "EducationNoBudget";
						break;
					}
					Employee.EmployeeRole role = Employee.EmployeeRole.Lead;
					string text = null;
					for (int num8 = 0; num8 < 5; num8++)
					{
						Employee.EmployeeRole r = (Employee.EmployeeRole)num8;
						if (item.employee.IsRole(r, true) && item.employee.GetSpecExperience(r) - (float)item.Courses.Count((KeyValuePair<Employee.EmployeeRole, string> x) => x.Key == r) >= 1f && item.employee.SpecPointsLeft(r, item, true))
						{
							text = GetAutoPreferredSpec(parent, r, item, num6, false);
							if (text != null)
							{
								role = r;
								break;
							}
						}
					}
					if (text != null)
					{
						int specialization = item.employee.GetSpecialization(role, text);
						if (specialization < 3)
						{
							float educationCost = EducationWindow.GetEducationCost(specialization);
							Spent += educationCost;
							num4 += educationCost;
							GameSettings.Instance.MyCompany.MakeTransaction(0f - educationCost, Company.TransactionCategory.Education, true);
							HUD.Instance.educationWindow.SendEmployee(item, role, text);
							parent.Leader.employee.ChangeSkill(Employee.EmployeeRole.Lead, 0.001f, false);
							num2--;
							num3++;
						}
					}
				}
				if (num3 == 0)
				{
					EducationStatus = ((num > 0) ? "EducationEmployeesSent" : "EducationNoElligable");
					return;
				}
				HUD.Instance.employeeWindow.UpdateEdNumber();
				HUD.Instance.LogAuto("AutoLogHREducate", parent.Name, num3, num4.Currency());
			}
			else
			{
				EducationStatus = "EducationEmployeesSent";
			}
		}
		else
		{
			EducationStatus = "Disabled";
		}
	}

	public void CheckRoles(Team parent)
	{
		if (InitRoleSystem)
		{
			InitRoleSetup(ForceRole, false);
			InitRoleSystem = false;
		}
		if (!ControlRole)
		{
			return;
		}
		List<Actor> employeesDirect = parent.GetEmployeesDirect();
		for (int i = 0; i < employeesDirect.Count; i++)
		{
			Actor actor = employeesDirect[i];
			if (!actor.employee.IsRole(Employee.RoleBit.Lead))
			{
				Employee.RoleBit roleBit = ((HiredFor && actor.employee.HiredFor != Employee.EmployeeRole.Lead) ? Employee.RoleToMask[(int)actor.employee.HiredFor] : Employee.RoleBit.None);
				if (PrimaryRole >= 0f)
				{
					roleBit |= actor.employee.GetBestRoles(false, PrimaryRole);
				}
				Employee.RoleBit roleBit2 = ((SecondaryRole >= 0f) ? actor.employee.GetBestRoles(false, SecondaryRole) : Employee.RoleBit.None);
				roleBit2 &= ~roleBit;
				if (roleBit != Employee.RoleBit.None && (roleBit != actor.employee.CurrentRoleBit || roleBit2 != actor.employee.SecondaryRole))
				{
					actor.ChangeRole(roleBit, roleBit2);
				}
			}
		}
	}

	private Employee.Trait[] ConvertFilter()
	{
		if (FilterCount == 0)
		{
			return Array.Empty<Employee.Trait>();
		}
		Employee.Trait[] array = new Employee.Trait[FilterCount];
		int num = 0;
		for (int i = 0; i < 64; i++)
		{
			Employee.Trait trait = (Employee.Trait)(1L << i);
			if (Filter.HasBits(trait))
			{
				array[num] = trait;
				num++;
			}
		}
		return array;
	}

	private void LookForEmployees(Team parent)
	{
		int[] array = parent.CountRoles(null, HireHiredFor);
		int num = 0;
		float num2 = 0f;
		for (int i = 0; i < MaxEmployees.Length; i++)
		{
			if (SDateTime.GetMonthsFlat(EmptyPool[i], SDateTime.Now()) <= 0)
			{
				continue;
			}
			Employee.EmployeeRole employeeRole = (Employee.EmployeeRole)(i + 1);
			int num3 = Mathf.Min(MaxEmployees[i] - array[i + 1], 30);
			if (num3 <= 0)
			{
				continue;
			}
			LookHireWindow.HireFilter filter = new LookHireWindow.HireFilter(employeeRole, null, HireBracket, null, parent.Name, Require, ConvertFilter(), null);
			_lookCache.Clear();
			int employeesLeft = HUD.Instance.hireWindow.HireWin.GetEmployeesLeft(_lookCache, parent, filter);
			parent.DisableCompatibilityUpdate = true;
			bool flag = false;
			bool flag2 = false;
			float skill = parent.Leader.employee.GetSkill(Employee.EmployeeRole.Lead);
			float num4 = Mathf.Min(parent.MinCompatibility, 1f + skill * 0.5f);
			float num5 = LookHireWindow.GetFinalCost((int)HireBracket, 3, false, true, Require != Employee.Trait.None, FilterCount) * skill.MapRange(0f, 1f, 1f, 0.5f) / (float)num3;
			num5 /= GameSettings.Instance.Environment.EmployeePool;
			if (_lookCache.Count > 0)
			{
				string[] prioritizedSpec = GetPrioritizedSpec(parent, employeeRole, true);
				for (int j = 0; j < _lookCache.Count; j++)
				{
					Employee employee = _lookCache[j];
					bool flag3 = employee.DemandsMet == 0;
					if (flag3 && prioritizedSpec != null)
					{
						for (int k = 0; k < Mathf.Min(2, prioritizedSpec.Length); k++)
						{
							if (employee.GetSpecialization(employeeRole, prioritizedSpec[k]) < (int)(HireBracket + 1 - k))
							{
								flag3 = false;
								break;
							}
						}
					}
					if (flag3 && !(parent.GetMinCompatibility(employee) < num4))
					{
						employee.Filter = true;
						GameSettings.Instance.RegisterStat("Hired", 1f);
						num++;
						flag = true;
						GameSettings.Instance.SpawnActor(employee).Team = parent.Name;
						employee.SetRoles(Employee.RoleBit.AnyRole, Employee.RoleBit.None);
						parent.Leader.employee.ChangeSkill(Employee.EmployeeRole.Lead, 0.001f, false);
						num3--;
						if (num3 == 0)
						{
							break;
						}
						prioritizedSpec = GetPrioritizedSpec(parent, employeeRole, true);
					}
				}
			}
			if (num3 > 0 && employeesLeft > 0)
			{
				string[] prioritizedSpec2 = GetPrioritizedSpec(parent, employeeRole, true);
				int num6 = Mathf.Min(num3, employeesLeft);
				for (int l = 0; l < num6; l++)
				{
					if (Spent + num5 >= Budget || !GameSettings.Instance.MyCompany.CanMakeTransaction(0f - num5))
					{
						flag2 = true;
						break;
					}
					Employee employee2 = new Employee(SDateTime.Now(), employeeRole, UnityEngine.Random.value > 0.5f, HireBracket, GameSettings.Instance.Personalities, "Default", false, prioritizedSpec2, parent, skill, skill.MapRange(0f, 1f, 0.01f, 0.1f), Require, Filter, true);
					Spent += num5;
					num2 += num5;
					GameSettings.Instance.MyCompany.MakeTransaction(0f - num5, Company.TransactionCategory.Hire, true);
					HUD.Instance.hireWindow.HireWin.HirePool[new KeyValuePair<Employee.EmployeeRole, Employee.WageBracket>(employeeRole, HireBracket)].Add(employee2);
					if (!(parent.GetMinCompatibility(employee2) < num4))
					{
						employee2.Employ(GameSettings.Instance.MyCompany, SDateTime.Now(), false);
						employee2.Filter = true;
						GameSettings.Instance.RegisterStat("Hired", 1f);
						num++;
						flag = true;
						GameSettings.Instance.SpawnActor(employee2).Team = parent.Name;
						employee2.SetRoles(Employee.RoleBit.AnyRole, Employee.RoleBit.None);
						parent.Leader.employee.ChangeSkill(Employee.EmployeeRole.Lead, 0.001f, false);
						prioritizedSpec2 = GetPrioritizedSpec(parent, employeeRole, true);
					}
				}
				if (flag2)
				{
					break;
				}
			}
			parent.DisableCompatibilityUpdate = false;
			if (flag)
			{
				parent.CalculateCompatibility();
			}
			else if (num3 > 0)
			{
				EmptyPool[i] = SDateTime.Now();
			}
		}
		if (num2 > 0f)
		{
			HUD.Instance.LogAuto("AutoLogHRHire", parent.Name, num2.Currency(), num);
		}
	}

	public string GetPreferredSpec(Employee.EmployeeRole role, Team parent, Actor ac, bool forHiring)
	{
		RefreshNeeds(parent);
		List<Actor> employeesDirect = parent.GetEmployeesDirect();
		_specPriCache.Clear();
		bool flag = false;
		string[] array;
		if (!GetAutoSpec(forHiring) || role == Employee.EmployeeRole.Lead || Needs.GetNeed(role).Count == 0)
		{
			array = GameSettings.Instance.GetUnlockedSpecializations(role);
		}
		else
		{
			array = Needs.GetNeed(role).Keys.Select((EdNeed x) => x.Spec).Distinct().ToArray();
			flag = true;
		}
		SHashSet<string> specs = GetSpecs(forHiring);
		if (specs.Count > 0)
		{
			bool flag2 = false;
			for (int num = 0; num < array.Length; num++)
			{
				if (!specs.Contains(array[num]))
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				if (!flag)
				{
					return null;
				}
				int num2 = array.Length;
				array = GameSettings.Instance.GetUnlockedSpecializations(role);
				if (num2 == array.Length)
				{
					return null;
				}
			}
		}
		bool flag3 = false;
		for (int num3 = 0; num3 < employeesDirect.Count; num3++)
		{
			Actor actor = employeesDirect[num3];
			foreach (string text in array)
			{
				if (!specs.Contains(text) && actor.employee.IsRole(role, true) && (ac == null || ac.employee.GetSpecialization(role, text) < 3))
				{
					_specPriCache.AddUp(text, actor.employee.GetSpecialization(role, text));
					flag3 = true;
				}
			}
		}
		if (!flag3)
		{
			if (flag)
			{
				foreach (KeyValuePair<EdNeed, int> item in from x in Needs.GetNeed(role)
					orderby x.Value descending
					select x)
				{
					if (!specs.Contains(item.Key.Spec))
					{
						return item.Key.Spec;
					}
				}
			}
			foreach (string text2 in array)
			{
				if (!specs.Contains(text2))
				{
					return text2;
				}
			}
		}
		if (_specPriCache.Count != 0)
		{
			return _specPriCache.MinInstance((KeyValuePair<string, float> x) => x.Value).Key;
		}
		return null;
	}

	public bool HandlesEducation(Team parent)
	{
		if (EducationLevel > 0 && EducationAmount != 0)
		{
			return parent.GetHRLevel() >= 2;
		}
		return false;
	}

	public void Update(Team parent)
	{
		int hRLevel = parent.GetHRLevel();
		if (hRLevel >= 1)
		{
			if (hRLevel >= 3)
			{
				LookForEmployees(parent);
			}
			if (EducationLevel > 0 && EducationAmount != 0 && hRLevel >= 2)
			{
				CheckEducation(parent);
			}
			else
			{
				EducationStatus = "Disabled";
			}
			CheckRoles(parent);
		}
		else
		{
			EducationStatus = "Disabled";
		}
	}

	private void RefreshNeeds(Team parent)
	{
		if (TasksChanged)
		{
			for (int i = 0; i < 4; i++)
			{
				Needs[i].Clear();
			}
			for (int j = 0; j < parent.WorkItems.Count; j++)
			{
				parent.WorkItems[j].GetNeeds(Needs);
			}
			TasksChanged = false;
		}
	}

	public static Dictionary<EdNeed, int> SubtractNeeds(Dictionary<EdNeed, int> needs, List<Actor> employees, Employee.EmployeeRole role, bool keepAll, HashSet<string> specFilter)
	{
		_subCache.Clear();
		foreach (KeyValuePair<EdNeed, int> need in needs)
		{
			if (specFilter.Contains(need.Key.Spec))
			{
				continue;
			}
			int num = need.Value;
			bool flag = false;
			for (int i = 0; i < employees.Count; i++)
			{
				Actor actor = employees[i];
				if (actor.employee.IsRole(role, true))
				{
					int specialization = actor.employee.GetSpecialization(role, need.Key.Spec, actor);
					if (need.Key.Level <= specialization)
					{
						num--;
						flag = true;
					}
				}
			}
			if (!flag)
			{
				num = int.MaxValue;
			}
			if (keepAll || num > 0)
			{
				_subCache[need.Key] = num;
			}
		}
		return _subCache;
	}

	public string GetAutoPreferredSpec(Team parent, Employee.EmployeeRole r, Actor emp, int maxLevel, bool forHiring)
	{
		if (!GetAutoSpec(forHiring) || r == Employee.EmployeeRole.Lead)
		{
			return GetPreferredSpec(r, parent, emp, forHiring);
		}
		RefreshNeeds(parent);
		Dictionary<EdNeed, int> dictionary = SubtractNeeds(Needs.GetNeed(r), parent.GetEmployeesDirect(), r, false, GetSpecs(forHiring));
		if (dictionary.Count > 0)
		{
			string text = null;
			int num = -1;
			int num2 = 4;
			foreach (KeyValuePair<EdNeed, int> item in dictionary.OrderByDescending((KeyValuePair<EdNeed, int> x) => x.Value))
			{
				int specialization = emp.employee.GetSpecialization(r, item.Key.Spec, emp);
				if (specialization < maxLevel && (item.Key.Level < 0 || item.Key.Level > specialization))
				{
					int num3 = ((item.Key.Level < 0) ? 1 : (item.Key.Level - specialization));
					if (specialization == 2 && num3 == 1)
					{
						return item.Key.Spec;
					}
					if (item.Key.Level > 0 && num3 == 1 && item.Value == int.MaxValue)
					{
						return item.Key.Spec;
					}
					if (specialization > num || (specialization >= num && num3 < num2))
					{
						text = item.Key.Spec;
						num = specialization;
						num2 = num3;
					}
				}
			}
			if (text != null)
			{
				return text;
			}
		}
		return GetPreferredSpec(r, parent, emp, forHiring);
	}

	public string[] GetPrioritizedSpec(Team parent, Employee.EmployeeRole r, bool forHiring)
	{
		if (!GetAutoSpec(forHiring) || r == Employee.EmployeeRole.Lead)
		{
			string preferredSpec = GetPreferredSpec(r, parent, null, forHiring);
			if (preferredSpec != null)
			{
				return new string[1] { preferredSpec };
			}
			return null;
		}
		RefreshNeeds(parent);
		Dictionary<EdNeed, int> dictionary = SubtractNeeds(Needs.GetNeed(r), parent.GetEmployeesDirect(), r, true, GetSpecs(forHiring));
		if (dictionary.Count > 0)
		{
			return (from x in dictionary
				orderby x.Value descending
				select x.Key.Spec).Distinct().ToArray();
		}
		string preferredSpec2 = GetPreferredSpec(r, parent, null, forHiring);
		if (preferredSpec2 != null)
		{
			return new string[1] { preferredSpec2 };
		}
		return null;
	}
}
