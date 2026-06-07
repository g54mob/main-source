using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AutomationWindow : MonoBehaviour
{
	public float RoleTick = 0.05f;

	public GUIWindow Window;

	[NonSerialized]
	public Team[] Teams;

	public bool Initializing;

	public GUICombobox WageBracket;

	public GameObject[] RoleControls;

	public Toggle HandleWage;

	public Toggle HandleComplaint;

	public Toggle AutoSpec;

	public Toggle AutoHireSpec;

	public Toggle ControlRole;

	public Toggle HiredFor;

	public Toggle HireHiredFor;

	public InputField HREducationAmount;

	public InputField Budget;

	public Slider HREducation;

	public Slider PrimaryRole;

	public Slider SecondaryRole;

	public Text HRAgeText;

	public Text HRDurationText;

	public Text HRSalariesText;

	public Text TeamName;

	public Text Spent;

	public Text Complaints;

	public Text Resignations;

	public Text Status;

	public Text PrimaryRoleLabel;

	public Text SecondaryRoleLabel;

	public Text ExpectedAge;

	public Text ExpectedSkill;

	public InputField[] HREmployeeCount;

	public Text[] HREmployeeText;

	public Text SpecLabel;

	public Text HireSpecLabel;

	public Text[] Levels;

	public Image[] LevelChecks;

	public Sprite LevelOK;

	public Sprite LevelBad;

	public Color ActiveLevel;

	public Color InactiveLevel;

	private int _lastLevel = -1;

	public static string[] RoleCategory = new string[5] { "Leader", "Development", "Development", "Development", "Service" };

	private void Awake()
	{
		WageBracket.UpdateContent(Enum.GetNames(typeof(Employee.WageBracket)));
	}

	public void UpdateRoleSlider(int type)
	{
		Slider slider = ((type == 0) ? PrimaryRole : SecondaryRole);
		((type == 0) ? PrimaryRoleLabel : SecondaryRoleLabel).text = ((slider.value < 0f) ? "Disabled".Loc() : (slider.value * RoleTick).ToPercent());
		if (Initializing || Teams == null)
		{
			return;
		}
		Team[] teams = Teams;
		foreach (Team team in teams)
		{
			if (type == 0)
			{
				team.HR.PrimaryRole = slider.value * RoleTick;
			}
			else
			{
				team.HR.SecondaryRole = slider.value * RoleTick;
			}
			team.HR.UpdateActiveLevel();
		}
	}

	public void Show(params Team[] ts)
	{
		_lastLevel = -1;
		TutorialSystem.Instance.StartTutorial("HR");
		Window.Show();
		Teams = ts;
		Initialize();
	}

	public void Initialize()
	{
		Initializing = true;
		TeamName.text = Teams.GetListAbbrev("Team", (Team x) => x.Name);
		HandleWage.isOn = Teams.Mode((Team x) => x.HR.HandleWages);
		HandleComplaint.isOn = Teams.Mode((Team x) => x.HR.HandleComplaints);
		AutoSpec.isOn = Teams.Mode((Team x) => x.HR.AutoSpec);
		AutoHireSpec.isOn = Teams.Mode((Team x) => x.HR.AutoSpecHire);
		HREducationAmount.text = Teams.Mode((Team x) => x.HR.EducationAmount, 0).ToString();
		Budget.text = Teams.Average((Team x) => x.HR.Budget).CurrencyMul().ToString("N0");
		HREducation.value = Teams.Mode((Team x) => x.HR.EducationLevel, 0);
		for (int num = 0; num < 4; num++)
		{
			int i1 = num;
			HREmployeeCount[num].text = Teams.Mode((Team x) => x.HR.MaxEmployees[i1], 0).ToString();
		}
		WageBracket.Selected = (int)Teams.Mode((Team x) => x.HR.HireBracket, Employee.WageBracket.Low);
		ControlRole.isOn = Teams.Mode((Team x) => x.HR.ControlRole);
		HiredFor.isOn = Teams.Mode((Team x) => x.HR.HiredFor);
		HireHiredFor.isOn = Teams.Mode((Team x) => x.HR.HireHiredFor);
		PrimaryRole.value = Teams.Max((Team x) => x.HR.PrimaryRole) / RoleTick;
		SecondaryRole.value = Teams.Max((Team x) => x.HR.SecondaryRole) / RoleTick;
		Initializing = false;
		UpdateSpecLabel(true);
		UpdateSpecLabel(false);
		UpdateExpectedRanges();
	}

	private void UpdateExpectedRanges()
	{
		int selected = WageBracket.Selected;
		ExpectedAge.text = Employee.AgeBrackets[selected][0] + "\t\t-\t" + Employee.AgeBrackets[selected][1];
		float num = (float)selected / 4f;
		float value = ((selected < 2) ? (num + 0.25f) : 1f);
		ExpectedSkill.text = num.ToPercent(false) + "\t-\t" + value.ToPercent(false);
	}

	public void UpdateWageBracket()
	{
		if (!Initializing && Teams != null)
		{
			Team[] teams = Teams;
			for (int i = 0; i < teams.Length; i++)
			{
				teams[i].HR.HireBracket = (Employee.WageBracket)WageBracket.Selected;
			}
			UpdateExpectedRanges();
		}
	}

	public void UpdateHRCount(int i)
	{
		if (Initializing)
		{
			return;
		}
		try
		{
			int num = Convert.ToInt32(HREmployeeCount[i].text);
			Team[] teams = Teams;
			foreach (Team obj in teams)
			{
				obj.HR.MaxEmployees[i] = num;
				obj.HR.UpdateActiveLevel();
			}
		}
		catch (Exception)
		{
		}
	}

	public void UpdateHREducation()
	{
		if (!Initializing)
		{
			try
			{
				Team[] teams = Teams;
				foreach (Team obj in teams)
				{
					obj.HR.EducationLevel = Mathf.RoundToInt(HREducation.value);
					obj.HR.UpdateActiveLevel();
				}
			}
			catch (Exception)
			{
			}
		}
		HRDurationText.text = HREducation.value.ToString("N0");
	}

	public void UpdateHREducationAmount()
	{
		if (Initializing)
		{
			return;
		}
		try
		{
			int educationAmount = Convert.ToInt32(HREducationAmount.text);
			Team[] teams = Teams;
			foreach (Team obj in teams)
			{
				obj.HR.EducationAmount = educationAmount;
				obj.HR.UpdateActiveLevel();
			}
		}
		catch (Exception)
		{
		}
	}

	public void UpdateBudget()
	{
		if (Initializing)
		{
			return;
		}
		try
		{
			float budget = ((float)Convert.ToDouble(Budget.text)).FromCurrency();
			Team[] teams = Teams;
			for (int i = 0; i < teams.Length; i++)
			{
				teams[i].HR.Budget = budget;
			}
		}
		catch (Exception)
		{
		}
	}

	public void ToggleComplaint()
	{
		if (!Initializing)
		{
			Team[] teams = Teams;
			foreach (Team obj in teams)
			{
				obj.HR.HandleComplaints = HandleComplaint.isOn;
				obj.HR.UpdateActiveLevel();
			}
		}
	}

	public void ToggleControlRole()
	{
		RoleControls.ForEachEnum(delegate(GameObject x)
		{
			x.SetActive(ControlRole.isOn);
		});
		if (!Initializing)
		{
			Team[] teams = Teams;
			foreach (Team obj in teams)
			{
				obj.HR.ControlRole = ControlRole.isOn;
				obj.HR.UpdateActiveLevel();
			}
		}
	}

	public void ToggleHiredFor()
	{
		if (!Initializing)
		{
			Team[] teams = Teams;
			foreach (Team obj in teams)
			{
				obj.HR.HiredFor = HiredFor.isOn;
				obj.HR.UpdateActiveLevel();
			}
		}
	}

	public void ToggleHireHiredFor()
	{
		if (!Initializing)
		{
			Team[] teams = Teams;
			for (int i = 0; i < teams.Length; i++)
			{
				teams[i].HR.HireHiredFor = HireHiredFor.isOn;
			}
		}
	}

	public void ToggleAutoSpec(bool forHiring)
	{
		if (Initializing)
		{
			return;
		}
		Team[] teams = Teams;
		foreach (Team team in teams)
		{
			if (forHiring)
			{
				team.HR.AutoSpecHire = AutoHireSpec.isOn;
			}
			else
			{
				team.HR.AutoSpec = AutoSpec.isOn;
			}
		}
	}

	public void ToggleWage()
	{
		if (!Initializing)
		{
			Team[] teams = Teams;
			foreach (Team obj in teams)
			{
				obj.HR.HandleWages = HandleWage.isOn;
				obj.HR.UpdateActiveLevel();
			}
		}
	}

	public void ChangeBenefits()
	{
	}

	public void ChangeTraits()
	{
		HUD.Instance.traitFilterWindow.Show(Teams[0].HR.Require, Teams[0].HR.Filter, 1, 4, delegate(Employee.Trait req, Employee.Trait filt)
		{
			int num = 0;
			for (int i = 0; i < 64; i++)
			{
				if (((ulong)filt & (ulong)(1L << i)) != 0L)
				{
					num++;
				}
			}
			for (int j = 0; j < Teams.Length; j++)
			{
				Team obj = Teams[j];
				obj.HR.Require = req;
				obj.HR.Filter = filt;
				obj.HR.FilterCount = num;
			}
		});
	}

	private void Update()
	{
		int[] array = new int[5];
		Team[] teams = Teams;
		foreach (Team team in teams)
		{
			team.CountRoles(array, team.HR.HireHiredFor);
		}
		HREmployeeText[0].text = "Programmers".Loc() + "(" + array[1] + "):";
		HREmployeeText[1].text = "Designers".Loc() + "(" + array[2] + "):";
		HREmployeeText[2].text = "Artists".Loc() + "(" + array[3] + "):";
		HREmployeeText[3].text = "Service".Loc() + "(" + array[4] + "):";
		HRSalariesText.text = Teams.Sum((Team y) => y.GetEmployeesDirect().SumSafe((Actor x) => x.GetMonthlySalary())).Currency();
		Spent.text = Teams.Sum((Team y) => y.HR.SpentLast).Currency();
		Complaints.text = Teams.Sum((Team x) => x.HR.Complaints).ToString("N0");
		Resignations.text = Teams.Sum((Team x) => x.HR.Resignations).ToString("N0");
		Status.text = Teams.Mode((Team x) => x.HR.EducationStatus).Loc();
		int num = Teams.MaxSafeInt((Team y) => y.GetHRLevel());
		if (num != _lastLevel)
		{
			for (int num2 = 0; num2 < 3; num2++)
			{
				Levels[num2].text = "SpecSkillRole".Loc(num2 + 1, "HR".Loc(), "Leader".Loc()).Capitalize();
				Image obj = LevelChecks[num2];
				Color color = (Levels[num2].color = ((num2 < num) ? ActiveLevel : InactiveLevel));
				obj.color = color;
				LevelChecks[num2].sprite = ((num2 < num) ? LevelOK : LevelBad);
			}
			_lastLevel = num;
		}
	}

	public void PickSpecs(bool forHiring)
	{
		Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
		for (int i = 0; i < 5; i++)
		{
			string[] allSpecializations = GameSettings.Instance.GetAllSpecializations((Employee.EmployeeRole)i);
			foreach (string element in allSpecializations)
			{
				dictionary.Append(RoleCategory[i], element);
			}
		}
		string[] specs = new string[dictionary.Count + dictionary.SumSafe((KeyValuePair<string, HashSet<string>> x) => x.Value.Count)];
		bool[] array = new bool[dictionary.Count + dictionary.SumSafe((KeyValuePair<string, HashSet<string>> x) => x.Value.Count)];
		int num = 0;
		foreach (KeyValuePair<string, HashSet<string>> item in dictionary)
		{
			specs[num] = "*" + item.Key;
			array[num] = false;
			num++;
			foreach (string item2 in item.Value)
			{
				specs[num] = item2;
				string s1 = item2;
				array[num] = Teams.Any((Team y) => !y.HR.GetSpecs(forHiring).Contains(s1));
				num++;
			}
		}
		WindowManager.Instance.MultiWindow.ShowMulti("Specializations".Loc(), specs, array, delegate(int[] sel)
		{
			HashSet<string> hashSet = sel.Select((int x) => specs[x]).ToHashSet();
			if (hashSet.Count == specs.Length)
			{
				hashSet.Clear();
			}
			for (int num2 = 0; num2 < Teams.Length; num2++)
			{
				SHashSet<string> specs2 = Teams[num2].HR.GetSpecs(forHiring);
				specs2.Clear();
				specs2.AddRange(hashSet);
			}
			UpdateSpecLabel(forHiring);
		}, true, true, true, true);
	}

	public void UpdateSpecLabel(bool forHiring)
	{
		SHashSet<string> sHashSet = new SHashSet<string>();
		for (int i = 0; i < 5; i++)
		{
			sHashSet.AddRange(GameSettings.Instance.GetAllSpecializations((Employee.EmployeeRole)i));
		}
		string[] array = sHashSet.ToArray();
		string[] array2 = array.Where((string x) => Teams.Any((Team y) => !y.HR.GetSpecs(forHiring).Contains(x))).ToArray();
		Text text = (forHiring ? HireSpecLabel : SpecLabel);
		if (array2.Length == 0 || array2.Length == array.Length)
		{
			text.text = "Any".Loc();
		}
		else if (array2.Length == 1)
		{
			text.text = array2[0].Loc();
		}
		else
		{
			text.text = "Specialization".LocPlural(array2.Length);
		}
	}
}
