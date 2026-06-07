using System;
using TMPro;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "InputValidator - Digits.asset", menuName = "TextMeshPro/Input Validators/Digits", order = 100)]
public class CustomTMProInputValidator : TMP_InputValidator
{
	public override char Validate(ref string text, ref int pos, char ch)
	{
		return '\0';
	}
}
