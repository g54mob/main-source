using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Framework.Cheats;

public class StageSelectionCheatCodeManager : CheatCodeManager
{
	protected override void AddCheatCodeCombos()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0255: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_027d: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_02a5: Expected O, but got I
		//IL_01c0: Expected O, but got I
		CheatCodeCombo cheatCodeCombo = new CheatCodeCombo();
		List<KeyCode> list = new List<KeyCode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)115);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 115;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)112);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 112;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)97);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 97;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)109);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 109;
		}
		cheatCodeCombo.Combo = list;
		Action onComboComplete = Tflag;
		cheatCodeCombo.OnComboComplete = onComboComplete;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
	}

	private void Tflag()
	{
		if (GameManager.Tflag == 3)
		{
			uint tflag = GameManager.Tflag + 4;
			GameManager.Tflag = tflag;
		}
	}
}
