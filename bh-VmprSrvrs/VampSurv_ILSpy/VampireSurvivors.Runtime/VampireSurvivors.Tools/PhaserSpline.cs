using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Tools;

public class PhaserSpline
{
	private List<Vector2> _points;

	public PhaserSpline(List<Vector2> points)
	{
		_points = points;
	}

	public PhaserSpline(List<float> points)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		List<Vector2> points2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		_points = points2;
		object obj = 0;
		object obj2 = 0;
		Vector2 item = default(Vector2);
		while (true)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rdx (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)obj3 < 0)
			{
				object obj4 = obj + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [points @ rdx (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)obj4 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049FD20");
					object obj5 = obj + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049FD20");
					_points.Add(item);
				}
				obj += 2;
				obj2 = obj;
				continue;
			}
			break;
		}
	}

	public Vector2 GetPoint(float t)
	{
		//IL_001b: Expected O, but got I
		//IL_00d9: Expected O, but got I
		//IL_00ef: Expected O, but got I
		//IL_00fd: Expected O, but got I
		//IL_013c: Expected O, but got I
		//IL_0152: Expected O, but got I
		//IL_0160: Expected O, but got I
		List<Vector2> points = _points;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdi_v1 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		object obj = -1;
		float num = (float)obj * t;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
		List<Vector2> points2 = _points;
		nint num3 = default(nint);
		nint num2 = num3 - 1;
		bool flag = num3 == 0;
		IntPtr intPtr = num3;
		if (!flag)
		{
			intPtr = num2;
		}
		IntPtr intPtr2 = intPtr;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r10_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)intPtr2 < 0)
		{
			List<Vector2> points3 = _points;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rdx_v3 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if (num3 < 0)
			{
				List<Vector2> points4 = _points;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdi_v1 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj2 = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdi_v1 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj3 = -2;
				object obj4 = num3 + 1;
				if (num3 <= (nint)obj3)
				{
					obj2 = obj4;
				}
				object obj5 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r11_v3 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)obj5 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdi_v1 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					object obj6 = -3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdi_v1 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					object obj7 = -1;
					object obj8 = num3 + 2;
					if (num3 <= (nint)obj6)
					{
						obj7 = obj8;
					}
					object obj9 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r11_v3 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					Vector2 result = default(Vector2);
					if ((nint)obj9 < 0)
					{
						return result;
					}
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Vector2 result2 = default(Vector2);
		return result2;
	}

	public void Dispose()
	{
		List<Vector2> points = _points;
		if (_points != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
		}
		_points = null;
	}

	private float CatmullRom(float t, float p0, float p1, float p2, float p3)
	{
		object obj = default(object);
		float num = (float)obj * 3f;
		float num2 = (float)obj - p0;
		object obj2 = obj + obj;
		float num3 = p1 * -3f;
		object obj3 = default(object);
		float num4 = (float)obj3 - p1;
		float num5 = num2 * 0.5f;
		float num6 = num3 + num;
		float num7 = t * t;
		float num8 = num4 * 0.5f;
		float num9 = p1 + p1;
		float num10 = num5 + num5;
		float num11 = num9 - (float)obj2;
		float num12 = num6 - num10;
		float num13 = num11 + num5;
		float num14 = num5 * t;
		float num15 = num12 - num8;
		float num16 = num13 + num8;
		float num17 = num15 * num7;
		float num18 = num7 * t;
		float num19 = num16 * num18;
		float num20 = num17 + num19;
		float num21 = num20 + num14;
		return num21 + p1;
	}
}
