using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class StepProperty : Property<int>
{
	private int _keywordDisabled;

	private int _minValue;

	private int _maxValue;

	public StepProperty(Uniform uniform, int minValue, int maxValue, string keyword, int keywordDisabled = 0)
	{
		object obj = default(object);
		base._002Ector(uniform, new string[1] { (string)obj });
		int keywordDisabled2 = default(int);
		_keywordDisabled = keywordDisabled2;
		_minValue = minValue;
		_maxValue = maxValue;
	}

	public StepProperty(Uniform uniform, int minValue, int maxValue)
		: base(uniform, Array.Empty<string>())
	{
		_minValue = minValue;
		_maxValue = maxValue;
	}

	public override int GetValue(Material material)
	{
		//IL_0010: Expected O, but got I
		//IL_007e: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.StepProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.StepProperty)+18]");
		if ((nint)0 != 0 && (object)material != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1+18]");
			return material.GetInt(0);
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public override void SetValue(Material material, int value)
	{
		//IL_00cc: Expected O, but got I
		//IL_0062: Expected O, but got I4
		int num = _minValue;
		if (value >= _minValue)
		{
			num = _maxValue;
			if (value <= _maxValue)
			{
				num = value;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.StepProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v1+18]");
		material.SetInt(0, num);
		object obj2 = num - _keywordDisabled;
		bool flag = obj2 == null;
		bool b = !flag;
		SetKeyword(material, b, num);
	}
}
