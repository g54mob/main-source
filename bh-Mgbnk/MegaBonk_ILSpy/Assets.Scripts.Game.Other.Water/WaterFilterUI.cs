using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game.Other.Water;

public class WaterFilterUI : MonoBehaviour
{
	public CanvasGroup group;

	public RawImage i_color;

	private bool usingFilter;

	private float fadeSeconds = 0.06f;

	private void Awake()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<global::Water> b = OnFilterEnter;
		Delegate obj = Delegate.Combine(global::Water.A_CameraEnterWater, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			global::Water.A_CameraEnterWater = (Action<global::Water>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<global::Water> action = default(Action<global::Water>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<global::Water>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			global::Water.A_CameraEnterWater = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<global::Water>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0215;
			}
		}
		Action<global::Water> b2 = OnFilterExit;
		Delegate obj6 = Delegate.Combine(global::Water.A_CameraExitWater, b2);
		if ((object)obj6 == null)
		{
			global::Water.A_CameraExitWater = (Action<global::Water>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<global::Water> action2 = default(Action<global::Water>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<global::Water>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		global::Water.A_CameraExitWater = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<global::Water>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0230;
		IL_0215:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0220;
		IL_0220:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0215;
	}

	private void OnDestroy()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<global::Water> value = OnFilterEnter;
		Delegate obj = Delegate.Remove(global::Water.A_CameraEnterWater, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			global::Water.A_CameraEnterWater = (Action<global::Water>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<global::Water> action = default(Action<global::Water>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<global::Water>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			global::Water.A_CameraEnterWater = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<global::Water>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0215;
			}
		}
		Action<global::Water> value2 = OnFilterExit;
		Delegate obj6 = Delegate.Remove(global::Water.A_CameraExitWater, value2);
		if ((object)obj6 == null)
		{
			global::Water.A_CameraExitWater = (Action<global::Water>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<global::Water> action2 = default(Action<global::Water>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<global::Water>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		global::Water.A_CameraExitWater = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<global::Water>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0230;
		IL_0215:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0220;
		IL_0220:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0215;
	}

	private unsafe void OnFilterEnter(global::Water filter)
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		i_color.color = (Color)(&obj);
		usingFilter = true;
	}

	private void OnFilterExit(global::Water filter)
	{
		usingFilter = false;
	}

	private void Update()
	{
		//IL_00e3: Invalid comparison between F4 and I4
		CanvasGroup canvasGroup;
		float alpha3;
		if (usingFilter)
		{
			float alpha = group.alpha;
			if (1f > alpha)
			{
				canvasGroup = group;
				float alpha2 = group.alpha;
				float deltaTime = Time.deltaTime;
				float num = deltaTime / fadeSeconds;
				float num2 = num + alpha2;
				alpha3 = num2;
				goto IL_0154;
			}
		}
		if (usingFilter)
		{
			return;
		}
		float alpha4 = group.alpha;
		if (!(alpha4 > 0f))
		{
			return;
		}
		canvasGroup = group;
		float alpha5 = group.alpha;
		float deltaTime2 = Time.deltaTime;
		float num3 = deltaTime2 / fadeSeconds;
		float num4 = alpha5 - num3;
		alpha3 = num4;
		goto IL_0154;
		IL_0154:
		canvasGroup.alpha = alpha3;
	}
}
