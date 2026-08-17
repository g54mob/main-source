using System;
using Assets.Scripts.Objects;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

namespace Assets.Scripts.UI.HUD;

public class ColorFilterUI : MonoBehaviour
{
	public CanvasGroup group;

	public RawImage i_color;

	private bool usingFilter;

	private float fadeSeconds = 0.1f;

	private float interpValue;

	public void ResetFilter()
	{
		usingFilter = false;
	}

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
		Action<ColorFilter> b = OnFilterEnter;
		Delegate obj = Delegate.Combine(ColorFilter.A_FilterEnter, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			ColorFilter.A_FilterEnter = (Action<ColorFilter>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<ColorFilter> action = default(Action<ColorFilter>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<ColorFilter>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			ColorFilter.A_FilterEnter = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<ColorFilter>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0215;
			}
		}
		Action<ColorFilter> b2 = OnFilterExit;
		Delegate obj6 = Delegate.Combine(ColorFilter.A_FilterExit, b2);
		if ((object)obj6 == null)
		{
			ColorFilter.A_FilterExit = (Action<ColorFilter>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<ColorFilter> action2 = default(Action<ColorFilter>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<ColorFilter>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		ColorFilter.A_FilterExit = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<ColorFilter>);
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
		Action<ColorFilter> value = OnFilterEnter;
		Delegate obj = Delegate.Remove(ColorFilter.A_FilterEnter, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			ColorFilter.A_FilterEnter = (Action<ColorFilter>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<ColorFilter> action = default(Action<ColorFilter>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<ColorFilter>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			ColorFilter.A_FilterEnter = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<ColorFilter>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0215;
			}
		}
		Action<ColorFilter> value2 = OnFilterExit;
		Delegate obj6 = Delegate.Remove(ColorFilter.A_FilterExit, value2);
		if ((object)obj6 == null)
		{
			ColorFilter.A_FilterExit = (Action<ColorFilter>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<ColorFilter> action2 = default(Action<ColorFilter>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<ColorFilter>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		ColorFilter.A_FilterExit = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<ColorFilter>);
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

	private unsafe void OnFilterEnter(ColorFilter filter)
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		i_color.color = (Color)(&obj);
		usingFilter = true;
	}

	private void OnFilterExit(ColorFilter filter)
	{
		usingFilter = false;
	}

	private void Update()
	{
		//IL_0102: Invalid comparison between F4 and I4
		//IL_0157: Invalid comparison between I4 and F4
		if (usingFilter)
		{
			float alpha = group.alpha;
			if (1f > alpha)
			{
				float deltaTime = Time.deltaTime;
				float num = deltaTime / fadeSeconds;
				if ((interpValue = num + interpValue) > 1f)
				{
					interpValue = 1f;
				}
				goto IL_017e;
			}
		}
		if (usingFilter)
		{
			return;
		}
		float alpha2 = group.alpha;
		if (!(alpha2 > 0f))
		{
			return;
		}
		float deltaTime2 = Time.deltaTime;
		float num2 = deltaTime2 / fadeSeconds;
		if (0f > (interpValue -= num2))
		{
			interpValue = 0f;
		}
		goto IL_017e;
		IL_017e:
		float alpha3 = Easing.InOutQuad(interpValue);
		group.alpha = alpha3;
	}
}
