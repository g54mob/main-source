using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Framework.Cheats;

public class IntroSceneCheatManager : CheatCodeManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__5_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe void _003CTflag_003Eb__5_0()
		{
			//IL_0049: Expected O, but got Ref
			GameManager.Tflag = 0u;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "TFlag: {0}", (System.ParamsArray)(&obj));
			Debug.Log(message);
		}
	}

	protected override void AddCheatCodeCombos()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_16a5: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_16cd: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_16f5: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_171d: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_1745: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_176d: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_1795: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_0401: Expected O, but got I
		//IL_045b: Expected O, but got I
		//IL_17bd: Expected O, but got I
		//IL_04c5: Expected O, but got I
		//IL_17e5: Expected O, but got I
		//IL_052f: Expected O, but got I
		//IL_180d: Expected O, but got I
		//IL_0599: Expected O, but got I
		//IL_1835: Expected O, but got I
		//IL_0603: Expected O, but got I
		//IL_185d: Expected O, but got I
		//IL_066d: Expected O, but got I
		//IL_1885: Expected O, but got I
		//IL_06d7: Expected O, but got I
		//IL_18ad: Expected O, but got I
		//IL_0741: Expected O, but got I
		//IL_07da: Expected O, but got I
		//IL_0834: Expected O, but got I
		//IL_18d5: Expected O, but got I
		//IL_089e: Expected O, but got I
		//IL_18fd: Expected O, but got I
		//IL_0908: Expected O, but got I
		//IL_1925: Expected O, but got I
		//IL_0972: Expected O, but got I
		//IL_194d: Expected O, but got I
		//IL_09dc: Expected O, but got I
		//IL_1975: Expected O, but got I
		//IL_0a46: Expected O, but got I
		//IL_199d: Expected O, but got I
		//IL_0ab1: Expected O, but got I
		//IL_133a: Expected O, but got I
		//IL_1394: Expected O, but got I
		//IL_19d8: Expected O, but got I
		//IL_13fe: Expected O, but got I
		//IL_1a00: Expected O, but got I
		//IL_1468: Expected O, but got I
		//IL_1a28: Expected O, but got I
		//IL_14d2: Expected O, but got I
		//IL_1a50: Expected O, but got I
		//IL_153c: Expected O, but got I
		//IL_1a78: Expected O, but got I
		//IL_15a6: Expected O, but got I
		//IL_1aa0: Expected O, but got I
		//IL_1610: Expected O, but got I
		CheatCodeCombo cheatCodeCombo = new CheatCodeCombo();
		List<KeyCode> list = new List<KeyCode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)120);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 120;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)45);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 45;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)120);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 120;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)49);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 49;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)118);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 118;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)105);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 105;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)105);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 105;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)113);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 113;
		}
		cheatCodeCombo.Combo = list;
		Action onComboComplete = UnlockExdash;
		cheatCodeCombo.OnComboComplete = onComboComplete;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
		CheatCodeCombo cheatCodeCombo2 = new CheatCodeCombo();
		List<KeyCode> list2 = new List<KeyCode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rdx_v25+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)120);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 120;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdx_v27+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)45);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 45;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rdx_v29+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)120);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 120;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rdx_v31+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)257);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 257;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rdx_v33+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)118);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 118;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rdx_v35+18]");
		if (num14 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)105);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 105;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdx_v37+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)105);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 105;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rdx_v39+18]");
		if (num16 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)113);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 113;
		}
		cheatCodeCombo2.Combo = list2;
		Action onComboComplete2 = UnlockExdash;
		cheatCodeCombo2.OnComboComplete = onComboComplete2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
		CheatCodeCombo cheatCodeCombo3 = new CheatCodeCombo();
		List<KeyCode> list3 = new List<KeyCode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdx_v46+18]");
		if (num17 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)120);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 120;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdx_v48+18]");
		if (num18 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)269);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 269;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rdx_v50+18]");
		if (num19 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)120);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 120;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v52+18]");
		if (num20 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)49);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 49;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdx_v54+18]");
		if (num21 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)118);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 118;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rdx_v56+18]");
		if (num22 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)105);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj44 = (nint)0 + (nint)1;
			_ = 105;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rdx_v58+18]");
		if (num23 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)105);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2307 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj46 = (nint)0 + (nint)1;
			_ = 105;
		}
		list3.Add(KeyCode.Q);
		cheatCodeCombo3.Combo = list3;
		Action onComboComplete3 = UnlockExdash;
		cheatCodeCombo3.OnComboComplete = onComboComplete3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
		CheatCodeCombo cheatCodeCombo4 = new CheatCodeCombo();
		List<KeyCode> combo = new List<KeyCode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		cheatCodeCombo4.Combo = combo;
		Action onComboComplete4 = UnlockExdash;
		cheatCodeCombo4.OnComboComplete = onComboComplete4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
		CheatCodeCombo cheatCodeCombo5 = new CheatCodeCombo();
		List<KeyCode> combo2 = new List<KeyCode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		cheatCodeCombo5.Combo = combo2;
		Action onComboComplete5 = UnlockMortaccio;
		cheatCodeCombo5.OnComboComplete = onComboComplete5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
		CheatCodeCombo cheatCodeCombo6 = new CheatCodeCombo();
		List<KeyCode> combo3 = new List<KeyCode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		cheatCodeCombo6.Combo = combo3;
		Action onComboComplete6 = UnlockMortaccio;
		cheatCodeCombo6.OnComboComplete = onComboComplete6;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
		CheatCodeCombo cheatCodeCombo7 = new CheatCodeCombo();
		List<string> list4 = new List<string>();
		list4.Add("DPadUp");
		list4.Add("DPadUp");
		list4.Add("DPadDown");
		list4.Add("DPadDown");
		list4.Add("DPadLeft");
		list4.Add("DPadRight");
		list4.Add("DPadLeft");
		list4.Add("DPadRight");
		list4.Add("ActionBottomRow2");
		list4.Add("ActionBottomRow1");
		cheatCodeCombo7.ActionCombo = list4;
		Action onComboComplete7 = UnlockMortaccio;
		cheatCodeCombo7.OnComboComplete = onComboComplete7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
		CheatCodeCombo cheatCodeCombo8 = new CheatCodeCombo();
		List<KeyCode> combo4 = new List<KeyCode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		cheatCodeCombo8.Combo = combo4;
		Action onComboComplete8 = UnlockMolise;
		cheatCodeCombo8.OnComboComplete = onComboComplete8;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
		CheatCodeCombo cheatCodeCombo9 = new CheatCodeCombo();
		List<KeyCode> combo5 = new List<KeyCode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		cheatCodeCombo9.Combo = combo5;
		Action onComboComplete9 = UnlockRandomazzo;
		cheatCodeCombo9.OnComboComplete = onComboComplete9;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
		CheatCodeCombo cheatCodeCombo10 = new CheatCodeCombo();
		List<KeyCode> combo6 = new List<KeyCode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		cheatCodeCombo10.Combo = combo6;
		Action onComboComplete10 = Tflag;
		cheatCodeCombo10.OnComboComplete = onComboComplete10;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
		CheatCodeCombo cheatCodeCombo11 = new CheatCodeCombo();
		List<KeyCode> combo7 = new List<KeyCode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		cheatCodeCombo11.Combo = combo7;
		Action onComboComplete11 = UnlockArcanas;
		cheatCodeCombo11.OnComboComplete = onComboComplete11;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
		CheatCodeCombo cheatCodeCombo12 = new CheatCodeCombo();
		List<KeyCode> list5 = new List<KeyCode>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC20");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rdx_v189+18]");
		if (num24 >= 0)
		{
			((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)115);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj48 = (nint)0 + (nint)1;
			_ = 115;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ r8_v73+18]");
		if (num25 >= 0)
		{
			((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)116);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj50 = (nint)0 + (nint)1;
			_ = 116;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ r8_v75+18]");
		if (num26 >= 0)
		{
			((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)111);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj52 = (nint)0 + (nint)1;
			_ = 111;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r8_v77+18]");
		if (num27 >= 0)
		{
			((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)109);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj54 = (nint)0 + (nint)1;
			_ = 109;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ r8_v79+18]");
		if (num28 >= 0)
		{
			((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)97);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj56 = (nint)0 + (nint)1;
			_ = 97;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ r8_v81+18]");
		if (num29 >= 0)
		{
			((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)114);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj58 = (nint)0 + (nint)1;
			_ = 114;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
		object obj59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
		nint num30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v83+18]");
		if (num30 >= 0)
		{
			((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)115);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2893 @ rax_v214 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			object obj60 = (nint)0 + (nint)1;
			_ = 115;
		}
		cheatCodeCombo12.Combo = list5;
		Action onComboComplete12 = UnlockNoseGlasses;
		cheatCodeCombo12.OnComboComplete = onComboComplete12;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AC80");
	}

	private void UnlockExdash()
	{
		PlayerOptionsData config = _playerOptions.Config;
		List<CharacterType> list = config._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				return;
			}
		}
		_playerOptions.UnlockCharacter(CharacterType.EXDASH);
		_playerOptions.BuyCharacter(CharacterType.EXDASH);
		_playerOptions.RevealCharacter(CharacterType.EXDASH);
		_playerOptions.Save();
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = -1000f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
	}

	private void UnlockMortaccio()
	{
		PlayerOptionsData config = _playerOptions.Config;
		if (!config._003CCheatCodeUsed_003Ek__BackingField)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			object obj = default(object);
			if (obj == null)
			{
				_playerOptions.UnlockCharacter(CharacterType.MORTACCIO);
				_playerOptions.RevealCharacter(CharacterType.MORTACCIO);
				_achievementManager.UnlockAchievement(AchievementType.Defeat3000Skeletons);
			}
			Debug.Log("Cheat combo complete");
			PlayerOptionsData config3 = _playerOptions.Config;
			config3._003CCheatCodeUsed_003Ek__BackingField = true;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ThingFound, null, 0f, 10, time);
			float num = _playerOptions.AddCoins(2800f);
			_playerOptions.Save();
		}
	}

	private void UnlockMolise()
	{
		//IL_00c3: Expected O, but got I
		//IL_011d: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		List<StageType> list = config._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				return;
			}
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)config2._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r9_v5+18]");
		if (num >= 0)
		{
			list2.AddWithResize((System.Int32Enum)9);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj3 = (nint)0 + (nint)1;
			_ = 9;
		}
		_playerOptions.Save();
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ThingFound, null, 0f, 10, time);
	}

	private void UnlockRandomazzo()
	{
		//IL_00e3: Expected O, but got I
		//IL_013d: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				return;
			}
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		_playerOptions.TrackItemPickup(ItemType.RELIC_RANDOMAZZO, config2);
		PlayerOptionsData config3 = _playerOptions.Config;
		List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)config3._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r9_v6+18]");
		if (num >= 0)
		{
			list2.AddWithResize((System.Int32Enum)24);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj3 = (nint)0 + (nint)1;
			_ = 24;
		}
		_playerOptions.UnlockArcana(ArcanaType.T06_SARABANDE);
		_playerOptions.Save();
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ThingFound, null, 0f, 10, time);
	}

	private unsafe void Tflag()
	{
		if (GameManager.Tflag != 0)
		{
			return;
		}
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj = default(object);
		if (obj == null)
		{
			return;
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj2 = default(object);
		if (obj2 == null)
		{
			return;
		}
		GameManager.Tflag = 1u;
		Action onComplete = _003C_003Ec._003C_003E9__5_0;
		if (_003C_003Ec._003C_003E9__5_0 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__5_0 = delegate
			{
				//IL_0049: Expected O, but got Ref
				GameManager.Tflag = 0u;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				System.ParamsArray paramsArray = new System.ParamsArray(arg);
				object obj3 = default(object);
				string message = string.FormatHelper((IFormatProvider)null, "TFlag: {0}", (System.ParamsArray)(&obj3));
				Debug.Log(message);
			});
		}
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(30.000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void UnlockArcanas()
	{
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_playerOptions.UnlockArcana(ArcanaType.T08_MAD_FOREST);
				_playerOptions.UnlockArcana(ArcanaType.T12_OUT_OF_TIME);
				_playerOptions.UnlockArcana(ArcanaType.T15_GOLD);
				_playerOptions.UnlockArcana(ArcanaType.T20_SINKING);
				_playerOptions.Save();
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ThingFound, null, 0f, 10, time);
			}
		}
	}

	private void UnlockNoseGlasses()
	{
		//IL_00e3: Expected O, but got I
		//IL_013d: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				return;
			}
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		_playerOptions.TrackItemPickup(ItemType.RELIC_NOSEGLASSES, config2, trackRunPickup: false);
		PlayerOptionsData config3 = _playerOptions.Config;
		List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)config3._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r9_v6+18]");
		if (num >= 0)
		{
			list2.AddWithResize((System.Int32Enum)35);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj3 = (nint)0 + (nint)1;
			_ = 35;
		}
		_playerOptions.Save();
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ThingFound, null, 0f, 10, time);
	}
}
