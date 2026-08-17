using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.App.Scripts.Framework.Curves;

public class QuadraticBezierCurve(Vector2 p0, Vector2 p1, Vector2 p2)
{
	private Vector2 _p0 = p0;

	private Vector2 _p1 = p1;

	private Vector2 _p2 = p2;

	public Vector2 GetPoint(float t)
	{
		Vector2 result = default(Vector2);
		return result;
	}

	public unsafe Vector3[] GetPoints(int points)
	{
		//IL_000e: Expected F4, but got I4
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected I4, but got Unknown
		//IL_0281: Expected O, but got I4
		//IL_028e: Expected O, but got I4
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_00ae: Expected O, but got I
		//IL_0074: Expected O, but got Ref
		//IL_00f8: Expected O, but got I
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_018e: Invalid comparison between I4 and F4
		List<Vector3> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		if (points >= 0)
		{
			float num = 0f;
			object obj5 = default(object);
			object obj6 = default(object);
			do
			{
				int num2 = (int)(num / points);
				float num3 = 1f - (float)num2;
				float num4 = 1f - (float)num2;
				float num5 = 1f - (float)num2;
				float num6 = num3 + num3;
				float num7 = num4 * num4;
				float num8 = num5 * num5;
				float num9 = num7 * (float)_p0;
				float num10 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Curves.QuadraticBezierCurve)+14]");
				float num11 = num10 * 0f;
				float num12 = num6 * (float)num2;
				float num13 = num12 * (float)_p1;
				float num14 = num13 + num9;
				object obj = num2 * num2;
				object obj2 = num2 * num2;
				object obj3 = obj * (object)_p2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Curves.QuadraticBezierCurve)+24]");
				object obj4 = obj2 * 0;
				float num15 = num14 + (float)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
				nint num16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				nint num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdx_v4 (Il2CppMethodInfo)+18]");
				if (num17 >= 0)
				{
					list.AddWithResize((Vector3)(&obj5));
					obj5 = obj6;
					object obj7 = obj6;
					nint num18 = 0;
					num16 = (nint)(&obj5);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					object obj8 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					nint num19 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdx_v4 (Il2CppMethodInfo)+18]");
					if (num19 >= 0)
					{
						return (Vector3[])(object)new IndexOutOfRangeException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					object obj9 = (nint)0 * (nint)2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					object obj10 = 0 + obj9;
					_ = 0;
					object obj7 = obj6;
					nint num18 = 0;
				}
				num++;
			}
			while (!((float)points < num));
		}
		else
		{
			nint num16 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049EA70");
		Vector3[] result = default(Vector3[]);
		return result;
	}

	private float P0(float t, float p)
	{
		float num = 1f - t;
		float num2 = num * num;
		return num2 * p;
	}

	private float P1(float t, float p)
	{
		float num = 1f - t;
		float num2 = num + num;
		float num3 = num2 * t;
		return num3 * p;
	}

	private float P2(float t, float p)
	{
		float num = t * t;
		return num * p;
	}

	private float QuadraticBezierInterpolation(float t, float p0, float p1, float p2)
	{
		float num = 1f - t;
		float num2 = 1f - t;
		float num3 = num + num;
		float num4 = num2 * num2;
		float num5 = num3 * t;
		float num6 = num4 * p0;
		float num7 = num5 * p1;
		float num8 = t * t;
		float num9 = num7 + num6;
		object obj = default(object);
		float num10 = num8 * (float)obj;
		return num9 + num10;
	}
}
