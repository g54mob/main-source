using System;
using UnityEngine;

[Serializable]
public class TaxReport
{
	public enum TaxType
	{
		None = 0,
		Income = 1,
		Operation = 2,
		Depreciation = 3,
		Investments = 4,
		Interest = 5
	}

	public const float MaxReduction = 0.05f;

	[AltWasFloat(0)]
	public double[] Values = new double[5];

	public float ReportProgress;

	public float Optimization;

	private float _complexity = -1f;

	[AltWasFloat(0)]
	private double _cost = -1.0;

	public bool IllegalActions;

	public void MakeIllegal()
	{
		IllegalActions = true;
		_complexity = -1f;
	}

	public double GetOptimization()
	{
		double num = 0.0;
		for (int i = 0; i < Values.Length; i++)
		{
			num += Values[i];
		}
		if (num <= 0.0)
		{
			return 0.0;
		}
		return Math.Min(num * 0.05000000074505806, Optimization);
	}

	public double FinalValue(out float optimization)
	{
		optimization = 0f;
		double num = 0.0;
		for (int i = 0; i < Values.Length; i++)
		{
			num += Values[i];
		}
		if (num <= 0.0)
		{
			return 0.0;
		}
		optimization = (float)Math.Min(num * 0.05000000074505806, Optimization);
		num *= (double)GameSettings.Instance.GetTaxeRate();
		return num - (double)optimization;
	}

	public double FinalValue(bool withOptimization)
	{
		double num = 0.0;
		for (int i = 0; i < Values.Length; i++)
		{
			num += Values[i];
		}
		if (num <= 0.0)
		{
			return 0.0;
		}
		double num2 = 0.0;
		if (withOptimization)
		{
			num2 = Math.Min(num * 0.05000000074505806, Optimization);
		}
		num *= (double)GameSettings.Instance.GetTaxeRate();
		return num - num2;
	}

	public static bool NeedsAccounting(TaxReport r)
	{
		if (r != null && r.IllegalActions)
		{
			return true;
		}
		if (GameSettings.Instance.IsReferenceNull())
		{
			return false;
		}
		return GameSettings.Instance.GetTaxeRate() > 0f;
	}

	public float GetComplexity()
	{
		if (_complexity < 0f)
		{
			if (!NeedsAccounting(this))
			{
				_complexity = 0f;
				return _complexity;
			}
			double num = 0.0;
			for (int i = 0; i < Values.Length; i++)
			{
				num += Math.Abs(Values[i]);
			}
			_complexity = (float)(Math.Pow(num / 250000.0, 0.35) * 0.5);
			if (_complexity < 1f)
			{
				_complexity = _complexity * _complexity * _complexity;
			}
		}
		return _complexity;
	}

	public double GetCost()
	{
		if (_cost < 0.0)
		{
			if (GameSettings.Instance.GetTaxeRate() == 0f)
			{
				_cost = 0.0;
				return _cost;
			}
			float num = GetComplexity();
			if (num < 1f)
			{
				num *= num;
			}
			double num2 = (double)num / 1.25;
			float maxEmployeeWorth = Employee.GetMaxEmployeeWorth(4, "Accounting");
			_cost = Math.Max(100.0, num2 * (double)maxEmployeeWorth * 8.0 * 3.0);
		}
		return _cost;
	}

	public void AddTax(TaxType type, double amount)
	{
		if (type != TaxType.None && !double.IsInfinity(amount) && !double.IsNaN(amount))
		{
			_complexity = -1f;
			Values[(int)(type - 1)] += amount;
		}
	}

	public void GetWorkersNeeded(out int workers, out float salary)
	{
		if (!NeedsAccounting(this))
		{
			workers = 0;
			salary = 0f;
		}
		else
		{
			float num = Mathf.Max(0.01f, GetComplexity());
			workers = Mathf.CeilToInt(num / 0.5f / 3f / 1.5f);
			salary = (float)workers * Employee.GetEmployeeWorth(4, "Accounting", 1f, 41f, 0f, 0f) * 8f * 3f;
		}
	}
}
