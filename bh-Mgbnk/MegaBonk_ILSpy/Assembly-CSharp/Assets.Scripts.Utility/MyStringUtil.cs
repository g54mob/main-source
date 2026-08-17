using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Utility;

public class MyStringUtil
{
	public static string ShowOnlyDecimals(float number)
	{
		//IL_012c: Expected I, but got O
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		//IL_018c: Invalid comparison between F4 and O
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_0200: Invalid comparison between F4 and O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831724F0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float num = number * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C50");
		float num2 = num / 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
		nint num3 = (nint)typeof(Mathf);
		float num4 = num2 - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num2 & 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj2 = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			obj = obj2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v5 (Il2CppClass<UnityEngine.Mathf>)+B8]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj3 = num4 & 0;
		float num6 = (float)obj * 1E-06f;
		float num7 = Mathf.Epsilon * 8f;
		if (num6 < num7)
		{
			num6 = num7;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			float num8 = num2 * 10f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C50");
			float num9 = num8 / 10f;
			float num10 = num9 - num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj4 = num9 & 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj5 = num2 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				obj5 = obj4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj6 = num10 & 0;
			float num11 = Mathf.Epsilon * 8f;
			float num12 = (float)obj5 * 1E-06f;
			if (num12 < num11)
			{
				num12 = num11;
			}
			float num13 = default(float);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num12) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
			{
				return num13.ToString("0.00");
			}
			float num14 = default(float);
			return num14.ToString("0.0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
		float num15 = default(float);
		return num15.ToString();
	}

	public static void ApplyEllipsisIfTruncated(TextMeshProUGUI tmp)
	{
		//IL_00a4: Expected O, but got I4
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected O, but got Unknown
		//IL_01c3: Expected I4, but got O
		//IL_017f: Expected O, but got I4
		if (!(tmp != null))
		{
			return;
		}
		string text = tmp.text;
		tmp.ForceMeshUpdate();
		if (!((TMP_Text)tmp).m_isTextTruncated)
		{
			return;
		}
		int num = text._stringLength;
		bool flag = text._stringLength < 0;
		int length = 0;
		if (!flag)
		{
			object obj = 0;
			int num2 = 0;
			int num4;
			bool flag3;
			do
			{
				object obj2 = num + obj;
				object obj3 = obj2 >> 31;
				object obj4 = obj2 - obj3;
				int num3 = obj4 >> 1;
				string text2 = text.Substring(0, num3);
				string text3 = text2 + "...";
				tmp.text = text3;
				tmp.ForceMeshUpdate();
				bool flag2 = (byte)(~(((TMP_Text)tmp).m_isTextTruncated ? 1u : 0u)) != 0;
				num4 = num3;
				if (!flag2)
				{
					num4 = num2;
				}
				int num5 = num3 - 1;
				if (!flag2)
				{
					num = num5;
				}
				object obj5 = num3 + 1;
				if (!flag2)
				{
					obj5 = obj;
				}
				flag3 = (nint)obj5 <= num;
				obj = obj5;
				num2 = num4;
			}
			while (flag3);
			length = num4;
		}
		string text4 = text.Substring(0, length);
		string text5 = text4 + "...";
		tmp.text = text5;
	}
}
