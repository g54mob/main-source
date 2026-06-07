using System;
using System.Globalization;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class BalancingParameter : Attribute
{
	public enum EType
	{
		Default = 0,
		PercentageModifyer = 1,
		Percentage = 2
	}

	public string key;

	public EType type;

	public BalancingParameter(EType _type = EType.Default)
	{
		type = _type;
	}

	public string ValueToString(string input)
	{
		return input;
	}

	public string ValueToString(float input)
	{
		switch (type)
		{
		case EType.PercentageModifyer:
			input -= 1f;
			if (input >= 0f)
			{
				return "+" + RoundToQuarterString(input * 100f) + "%";
			}
			return RoundToQuarterString(input * 100f) + "%";
		case EType.Percentage:
			_ = 0f;
			return RoundToQuarterString(input * 100f) + "%";
		default:
			return RoundToQuarterString(input);
		}
	}

	public static string RoundToQuarterString(float input)
	{
		float num = Mathf.Round(input * 4f) / 4f;
		if (Mathf.Approximately(num, Mathf.Round(num)))
		{
			return Mathf.RoundToInt(num).ToString(CultureInfo.InvariantCulture);
		}
		return num.ToString("F2", CultureInfo.InvariantCulture);
	}
}
