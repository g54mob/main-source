using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EmployeeBenefit
{
	public const int LateNightStart = 18;

	public const int LateNightEnd = 5;

	public string Name;

	public string Units;

	public string Tip;

	public float Min;

	public float Max;

	public float Increment;

	public float Default;

	public float Weight;

	public float Baseline;

	public float MaxWeight = 1f;

	private Func<Employee, Team, float> _weighting;

	public Func<float, string> ValueToText;

	public Action<Actor, float, float> OnChange;

	public static float[] CompanyCarPrice = new float[3] { 0f, 4000f, 25000f };

	public static float MaxBenefits = 78f;

	public static Dictionary<string, EmployeeBenefit> Benefits = new Dictionary<string, EmployeeBenefit>
	{
		{
			"Pension",
			new EmployeeBenefit("Pension", "PensionTip", 0f, 200f, 10f, 0f, (float x) => x.Currency(), "Month", (Employee x, Team y) => AgeWeight(x, 20f, 55f, 0.9f) * 5f, 5f)
		},
		{
			"Life insurance",
			new EmployeeBenefit("Life insurance", "LifeInsTip", 0f, 200000f, 1000f, 0f, (float x) => x.Currency(), "Death", (Employee x, Team y) => AgeWeight(x, 65f, 25f, 0.6f) * 2f, 2f)
		},
		{
			"Health insurance",
			new EmployeeBenefit("Health insurance", "HealthInsTip", 0f, 100000f, 1000f, 0f, (float x) => x.Currency(), "Hospitalization", (Employee x, Team y) => AgeWeight(x, 42f, 25f), 1f)
		},
		{
			"Minimum raise",
			new EmployeeBenefit("Minimum raise", "MinRaiseTip", 0f, 60f, 6f, 0f, (float x) => (x * 8f).Currency(), "Year", (Employee x, Team y) => (!(x.Salary > 0f)) ? 0f : (Employee.AverageWage / x.Salary * 8f), 8f)
		},
		{
			"Severance pay",
			new EmployeeBenefit("Severance pay", "SeveranceTip", 0f, 2f, 0.25f, 0f, (float x) => x.ToPercent(), "Termination", 3f)
		},
		{
			"Vacation months",
			new EmployeeBenefit("Vacation months", null, 0f, 3f, 1f, 1f, (float x) => x.ToString("N0"), null, 16f, 1f)
		},
		{
			"Paid vacation",
			new EmployeeBenefit("Paid vacation", null, 0f, 1f, 0.25f, 1f, (float x) => x.ToPercent(), null, (Employee x, Team y) => x.GetBenefitValue("Vacation months", y) * 4f, 12f, 0.5f)
		},
		{
			"Free food",
			new EmployeeBenefit("Free food", null, 0f, 1f, 1f, 1f, (float x) => (!(x > 0.5f)) ? "No".Loc() : "Yes".Loc(), null, 4f)
		},
		{
			"Christmas bonus",
			new EmployeeBenefit("Christmas bonus", null, 0f, 1f, 0.25f, 0f, (float x) => x.ToPercent(), "Employee", 8f, 0f, ChristmasBonusChange)
		},
		{
			"Company car",
			new EmployeeBenefit("Company car", null, 0f, 2f, 1f, 0f, (float x) => CompanyCarPrice[(int)x].Currency(), "Employee", 16f, 0f, CompanyCarChange)
		},
		{
			"NightShiftCompensation",
			new EmployeeBenefit("NightShiftCompensation", "NightShiftBenefitTip", 0f, 0.5f, 0.1f, 0f, (float x) => x.ToPercent(), "Hour", GetNightShiftValue, 3f)
		}
	};

	public EmployeeBenefit(string name, string tip, float min, float max, float increment, float defaultVal, Func<float, string> valToText, string units, float weight, float baseLine = -100f, Action<Actor, float, float> onChange = null)
	{
		Name = name;
		Tip = tip;
		Min = min;
		Max = max;
		Increment = increment;
		Default = defaultVal;
		Weight = weight;
		ValueToText = valToText;
		OnChange = onChange;
		Units = units;
		Baseline = Mathf.Max(Min, baseLine);
	}

	public EmployeeBenefit(string name, string tip, float min, float max, float increment, float defaultVal, Func<float, string> valToText, string units, Func<Employee, Team, float> weighting, float maxWeight, float baseLine = -100f, Action<Actor, float, float> onChange = null)
	{
		Name = name;
		Tip = tip;
		Min = min;
		Max = max;
		Increment = increment;
		Default = defaultVal;
		_weighting = weighting;
		ValueToText = valToText;
		OnChange = onChange;
		Units = units;
		Baseline = Mathf.Max(Min, baseLine);
		MaxWeight = maxWeight;
	}

	public float GetScore(float value)
	{
		if (value < Baseline)
		{
			return (0f - (Baseline - value)) / (Baseline - Min);
		}
		return (value - Min) / (Max - Min);
	}

	public float GetMaxWeight()
	{
		if (_weighting == null)
		{
			return Weight;
		}
		return MaxWeight;
	}

	public float GetWeight(Employee emp, Team team)
	{
		if (_weighting == null)
		{
			return Weight;
		}
		return _weighting(emp, team);
	}

	public string AddPost(string input)
	{
		if (Units == null)
		{
			return input;
		}
		return input + "/" + Units.Loc().ToLower();
	}

	private static float GetNightShiftValue(Employee emp, Team t)
	{
		if (t == null)
		{
			return 0f;
		}
		return Utilities.GetPercentLateNight(t.WorkStart, t.WorkEnd) * 3f;
	}

	private static void CompanyCarChange(Actor emp, float before, float after)
	{
		GameSettings.Instance.MyCompany.MakeTransaction(CompanyCarPrice[(int)before] * 0.5f, Company.TransactionCategory.Benefits, true, "Company car");
		GameSettings.Instance.MyCompany.MakeTransaction(0f - CompanyCarPrice[(int)after], Company.TransactionCategory.Benefits, false, "Company car");
		GameSettings.Instance.MyCompany.AddTax(TaxReport.TaxType.Depreciation, (0f - CompanyCarPrice[(int)after]) * 0.5f);
	}

	private static void ChristmasBonusChange(Actor emp, float before, float after)
	{
		emp.ChristmasBonus = Mathf.Max(emp.ChristmasBonus, after);
	}

	public static float GetBenefitScore(IBenefitReceiver receiver)
	{
		float num = 0f;
		foreach (KeyValuePair<string, EmployeeBenefit> benefit in Benefits)
		{
			float benefitValue = receiver.GetBenefitValue(benefit.Key);
			num += benefit.Value.GetScore(benefitValue) * benefit.Value.GetMaxWeight();
		}
		return num / (MaxBenefits / 2f);
	}

	public static float GetBenefitScore(Employee employee, Team team)
	{
		float num = 0f;
		foreach (KeyValuePair<string, EmployeeBenefit> benefit in Benefits)
		{
			float benefitValue = employee.GetBenefitValue(benefit.Key, team);
			num += benefit.Value.GetScore(benefitValue) * benefit.Value.GetWeight(employee, team);
		}
		return num / (MaxBenefits / 2f);
	}

	public static float GetBenefitValue(Employee emp, Team team, string benefit)
	{
		float value;
		if (emp != null && emp.CustomBenefits.TryGetValue(benefit, out value))
		{
			return value;
		}
		if (team != null && team.Benefits.TryGetValue(benefit, out value))
		{
			return value;
		}
		if (!GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.CompanyBenefits.TryGetValue(benefit, out value))
		{
			return value;
		}
		return Benefits[benefit].Default;
	}

	public static Dictionary<string, float> GetDefaultBenefits()
	{
		return Benefits.ToDictionary((KeyValuePair<string, EmployeeBenefit> x) => x.Key, (KeyValuePair<string, EmployeeBenefit> x) => x.Value.Default);
	}

	private static float AgeWeight(Employee emp, float bestAge, float ageRange = 45f, float weightOne = 0.75f)
	{
		float age = emp.GetAge();
		return Mathf.Sqrt(Mathf.Max(0f, 1f - Mathf.Abs(bestAge - age) / ageRange)).WeightOne(weightOne);
	}
}
