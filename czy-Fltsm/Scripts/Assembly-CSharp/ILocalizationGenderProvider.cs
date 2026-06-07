using System;
using I2.Loc;
using UnityEngine;

public interface ILocalizationGenderProvider : ILocalizationParamsManager
{
	private const string GENDER_KEY = "GENDER:";

	protected Agent.EGender LocalizationGender { get; }

	string ILocalizationParamsManager.GetParameterValue(string param)
	{
		if (!param.StartsWith("GENDER:"))
		{
			return null;
		}
		int length = "GENDER:".Length;
		return SelectGenderedText(param.Substring(length, param.Length - length), LocalizationGender);
	}

	private static string SelectGenderedText(string values, Agent.EGender gender)
	{
		int num = values.IndexOf('/');
		if (num == -1)
		{
			Debug.LogException(new IndexOutOfRangeException("Could not find '/' separator in values of gender localization key! Values are " + values));
			return values;
		}
		switch (gender)
		{
		case Agent.EGender.Male:
			return values.Substring(0, num);
		case Agent.EGender.Female:
		{
			int num2 = num + 1;
			return values.Substring(num2, values.Length - num2);
		}
		default:
			return values;
		}
	}
}
