using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.Geom;

namespace VampireSurvivors.Framework.Actions;

public static class Actions
{
	public unsafe static void PlaceOnCircle(List<Transform> items, Circle circle, float? startAngle = null, float? endAngle = null)
	{
		//IL_000e: Expected F4, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		//IL_00aa: Expected O, but got I4
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01fc: Expected O, but got Ref
		//IL_0201->IL0201: Incompatible stack heights: 4 vs 2
		float num;
		float? num2;
		if ((object)startAngle == null)
		{
			num = 0f;
			num2 = (float?)(object)1;
		}
		else
		{
			float num3 = default(float);
			num = num3;
			num2 = startAngle;
		}
		float num4;
		float? num5;
		if ((object)endAngle == null)
		{
			num4 = 6.28f;
			num5 = (float?)(object)1;
		}
		else
		{
			float num6 = default(float);
			num4 = num6;
			num5 = endAngle;
		}
		bool flag = (object)num2 == null;
		bool flag2 = (object)num5 == null;
		float num7 = num4 - num;
		float num8 = num7 / (float)items._size;
		Circle circle2 = circle;
		object obj = 0;
		Vector3 value = default(Vector3);
		while ((nint)obj < items._size)
		{
			bool flag3 = (nint)obj >= items._size;
			Transform[] items2 = items._items;
			object obj2 = items2[obj];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float num9 = num * circle._radius;
			float num10 = circle._y - num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbp_v7 (System.Object)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbp_v7 (System.Object)+10]");
			Transform.set_position_Injected((IntPtr)0, ref value);
			obj++;
			num += num8;
			circle2 = (Circle)(&value);
		}
	}

	public static void RotateAroundDistance(List<Transform> items, Vector2 point, float angle, float distance)
	{
		//IL_00f7: Invalid comparison between F4 and I4
		//IL_001d: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		//IL_01e2->IL01e3: Incompatible stack heights: 5 vs 0
		bool flag = distance == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186BB9B1Ch\"");
		if (!flag)
		{
			object obj = 0;
			object obj2 = 0;
			object obj4 = default(object);
			object obj5 = default(object);
			Vector3 value = default(Vector3);
			while ((nint)obj2 < items._size)
			{
				bool flag2 = (nint)obj >= items._size;
				Transform[] items2 = items._items;
				Transform transform = items2[obj];
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				object obj3 = obj4 - obj5;
				object obj6 = (object)ret - (object)point;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				float num = (float)obj3 + angle;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				bool flag4 = (nint)obj >= items._size;
				Transform[] items3 = items._items;
				object obj7 = items3[obj];
				bool flag5 = (object)items3[obj] == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rsi_v12 (System.Object)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rsi_v12 (System.Object)+10]");
				Transform.set_position_Injected((IntPtr)0, ref value);
				obj++;
				obj2 = obj;
			}
		}
	}

	private static Vector2 MathRotateAroundDistance(Vector2 point, float x, float y, float angle, float distance)
	{
		float num = (float)point - x;
		object obj = default(object);
		float num2 = (float)obj - y;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float num3 = num2 + angle;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Vector2 result = default(Vector2);
		return result;
	}
}
