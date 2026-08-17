using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class WeaponRecapUI : MonoBehaviour
{
	private TextMeshProUGUI _Name;

	private TextMeshProUGUI _Level;

	private TextMeshProUGUI _Damage;

	private TextMeshProUGUI _Time;

	private TextMeshProUGUI _Dps;

	private Image _Icon;

	public unsafe void SetData(RecapPage.StatsDisplay statsDisplay)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0038: Expected O, but got Ref
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected I4, but got Unknown
		//IL_0128: Invalid comparison between F4 and I4
		//IL_0149: Expected I, but got O
		//IL_0156: Expected O, but got Ref
		//IL_02e9: Expected O, but got Ref
		//IL_01d8: Expected O, but got Ref
		//IL_026f: Invalid comparison between F4 and I4
		//IL_0290: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [statsDisplay @ rdx (VampireSurvivors.UI.RecapPage+StatsDisplay)+40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [statsDisplay @ rdx (VampireSurvivors.UI.RecapPage+StatsDisplay)+40]");
		_ = 0;
		System.ParamsArray paramsArray = default(System.ParamsArray);
		_Name.color = (Color)(&paramsArray);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [statsDisplay @ rdx (VampireSurvivors.UI.RecapPage+StatsDisplay)+40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [statsDisplay @ rdx (VampireSurvivors.UI.RecapPage+StatsDisplay)+40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
		Sprite sprite = SpriteManager.GetSprite(statsDisplay.WeaponFrameName, statsDisplay.WeaponFrameName);
		_Icon.sprite = sprite;
		int num = statsDisplay + 8;
		string text = ((int*)num)->ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		float number = statsDisplay.InflictedDamage * 10f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [statsDisplay @ rdx (VampireSurvivors.UI.RecapPage+StatsDisplay)+40]");
		_ = 0;
		string text2 = FormatNumberValue(number, 1);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,0Dh\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [statsDisplay @ rdx (VampireSurvivors.UI.RecapPage+StatsDisplay)+40]");
		_ = 0;
		if (statsDisplay.InflictedDamage != 0f)
		{
		}
		TextMeshProUGUI damage = _Damage;
		nint num2 = (nint)damage;
		damage.color = (Color)(&paramsArray);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [statsDisplay @ rdx (VampireSurvivors.UI.RecapPage+StatsDisplay)+40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		float num3 = statsDisplay.Lifetime / 60f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		NumberFormatInfo instance = NumberFormatInfo.GetInstance(CultureInfo.invariant_culture_info);
		string text3 = System.Number.FormatSingle(statsDisplay.Lifetime, null, instance);
		string arg = text3.PadLeft(2, '0');
		object arg2 = default(object);
		paramsArray = new System.ParamsArray(arg2, arg);
		System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
		_ = 0;
		_ = 0;
		string text4 = string.FormatHelper((IFormatProvider)null, "{0}:{1}", args);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		float number2 = statsDisplay.Dps * 10f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [statsDisplay @ rdx (VampireSurvivors.UI.RecapPage+StatsDisplay)+40]");
		_ = 0;
		string text5 = FormatNumberValue(number2, 1);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,0Ch\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [statsDisplay @ rdx (VampireSurvivors.UI.RecapPage+StatsDisplay)+40]");
		_ = 0;
		if (statsDisplay.InflictedDamage == 0f)
		{
		}
		_Dps.color = (Color)(&paramsArray);
	}

	private unsafe string FormatNumberValue(float number, int digits)
	{
		//IL_0153: Expected O, but got I4
		//IL_020e: Expected O, but got Ref
		//IL_01a1: Expected O, but got I4
		//IL_0345: Invalid comparison between F4 and I4
		//IL_02f2: Expected I8, but got I4
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected Ref, but got Unknown
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected Ref, but got Unknown
		Dictionary<double, string> dictionary = null;
		EqualityComparer<double> equalityComparer = EqualityComparer<double>.Default;
		bool flag = equalityComparer == null;
		nint num = 0;
		if (!flag)
		{
			_ = 0;
			num = 0;
		}
		string text2;
		if (dictionary != null)
		{
			bool flag2 = ((Dictionary<double, object>)(object)dictionary).TryInsert(1.0, (object)"", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			bool flag3 = ((Dictionary<double, object>)(object)dictionary).TryInsert(1000.0, (object)"k", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			bool flag4 = ((Dictionary<double, object>)(object)dictionary).TryInsert(1000000.0, (object)"M", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			bool flag5 = ((Dictionary<double, object>)(object)dictionary).TryInsert(1000000000.0, (object)"G", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			bool flag6 = ((Dictionary<double, object>)(object)dictionary).TryInsert(1000000000000.0, (object)"T", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			bool flag7 = ((Dictionary<double, object>)(object)dictionary).TryInsert(1000000000000000.0, (object)"P", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			bool flag8 = ((Dictionary<double, object>)(object)dictionary).TryInsert(1E+18, (object)"E", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			object obj = 0;
			string text = null;
			Dictionary<double, object>.Enumerator enumerator = default(Dictionary<double, object>.Enumerator);
			while (true)
			{
				bool flag9 = enumerator.MoveNext();
				if (flag9)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm7\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,qword ptr [rsp+0B8h]\"");
					if ((flag9 ? 1 : 0) >= (false ? 1 : 0))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
						obj = 1;
						text = null;
					}
					continue;
				}
				break;
			}
			string text3;
			if (obj == null)
			{
				text2 = "0";
				text3 = "0";
				num = (nint)(&enumerator);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm8,xmm7\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm8,xmm6\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				System.ParamsArray paramsArray = new System.ParamsArray(arg);
				System.ParamsArray paramsArray2 = default(System.ParamsArray);
				string format = string.FormatHelper((IFormatProvider)null, "F{0}", (System.ParamsArray)(&paramsArray2));
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				string input = System.Number.FormatDouble(0.0, format, currentInfo);
				string text4 = Regex.Replace(input, "/\\.0+$|(\\.[0-9]*[1-9])0+$/", "$1");
				string text5 = text4 + text;
				text2 = text5;
				text3 = "0";
			}
			if (text2 != null)
			{
				if ((object)text2 == text3)
				{
					goto IL_033c;
				}
				if (text3 != null && text2._stringLength == text3._stringLength)
				{
					ulong length = (ulong)(text2._stringLength + text2._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref *(byte*)(text2 + 20), ref *(byte*)(text3 + 20), length))
					{
						goto IL_033c;
					}
				}
				goto IL_044d;
			}
		}
		throw new NullReferenceException();
		IL_033c:
		bool flag10 = number == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E00D50h\"");
		if (!flag10)
		{
			NumberFormatInfo instance = NumberFormatInfo.GetInstance(CultureInfo.invariant_culture_info);
			string text6 = System.Number.FormatSingle(number, "F2", instance);
			text2 = text6;
		}
		goto IL_044d;
		IL_044d:
		return text2;
	}

	public WeaponRecapUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
