using System;
using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class RangeProperty : Property<float>
{
	private float _keywordDisabled;

	private float _minValue;

	private float _maxValue;

	public RangeProperty(Uniform uniform, string keyword, float minValue, float maxValue, float keywordDisabled = 0f)
		: base(uniform, new string[1] { keyword })
	{
		_minValue = minValue;
		float keywordDisabled2 = default(float);
		_keywordDisabled = keywordDisabled2;
		float maxValue2 = default(float);
		_maxValue = maxValue2;
	}

	public RangeProperty(Uniform uniform, string keyword, float minValue, float keywordDisabled = 0f)
		: base(uniform, new string[1] { keyword })
	{
		_minValue = minValue;
		float keywordDisabled2 = default(float);
		_keywordDisabled = keywordDisabled2;
		_maxValue = 1f / 0f;
	}

	public RangeProperty(Uniform uniform, float minValue, float maxValue)
		: base(uniform, Array.Empty<string>())
	{
		_minValue = minValue;
		_maxValue = maxValue;
	}

	public RangeProperty(Uniform uniform, float minValue)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18002A400");
		string[] keywords = default(string[]);
		base._002Ector(uniform, keywords);
		_minValue = minValue;
		_maxValue = 1f / 0f;
	}

	public override float GetValue(Material material)
	{
		//IL_0010: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.RangeProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1+18]");
		return material.GetFloatImpl(0);
	}

	public override void SetValue(Material material, float value)
	{
		//IL_00d2: Expected O, but got I
		float num = _minValue;
		if (!(_minValue > value))
		{
			num = _maxValue;
			if (!(value > _maxValue))
			{
				num = value;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.RangeProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v1+18]");
		material.SetFloat(0, num);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001812DA9B3h\"");
		bool b = ((num != _keywordDisabled) ? true : false);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r9d,xmm6\"");
		SetKeyword(material, b, 0);
	}
}
