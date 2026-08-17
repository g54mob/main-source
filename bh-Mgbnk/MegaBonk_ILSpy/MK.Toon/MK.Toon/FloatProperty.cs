using Cpp2ILInjected;
using UnityEngine;

namespace MK.Toon;

public class FloatProperty : Property<float>
{
	private float _keywordDisabled;

	public FloatProperty(Uniform uniform, string keyword, float keywordDisabled = 0f)
		: base(uniform, new string[1] { keyword })
	{
		_keywordDisabled = keywordDisabled;
	}

	public FloatProperty(Uniform uniform)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18002A400");
		string[] keywords = default(string[]);
		base._002Ector(uniform, keywords);
	}

	public override float GetValue(Material material)
	{
		//IL_0010: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.FloatProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1+18]");
		return material.GetFloatImpl(0);
	}

	public override void SetValue(Material material, float value)
	{
		//IL_0075: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MK.Toon.FloatProperty)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdx_v1+18]");
		material.SetFloat(0, value);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001812D39D7h\"");
		bool b = ((value != _keywordDisabled) ? true : false);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r9d,xmm6\"");
		SetKeyword(material, b, 0);
	}
}
