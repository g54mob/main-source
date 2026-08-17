using System;
using Assets.Scripts.UI.Mouse;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class ToolTipMouse : MonoBehaviour
{
	public GameObject parent;

	public TextMeshProUGUI t_tooltip;

	private bool opening;

	private float lerpValue;

	private float scaleTime = 0.1f;

	private unsafe void Awake()
	{
		//IL_0247: Expected I, but got O
		//IL_0258: Expected O, but got I4
		//IL_0261: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_013d: Expected I, but got O
		//IL_014e: Expected O, but got I4
		//IL_0157: Expected O, but got I4
		//IL_0111: Expected I, but got O
		//IL_0195: Expected I, but got O
		//IL_01a3: Expected I, but got O
		//IL_01b4: Expected O, but got I4
		//IL_01bd: Expected O, but got I4
		//IL_01f5: Expected O, but got I4
		//IL_01fe: Expected O, but got I4
		//IL_02f5: Expected O, but got I4
		//IL_02fe: Expected O, but got I4
		//IL_022d: Expected O, but got Ref
		Action<string, Vector2> b = OpenTooltip;
		Delegate obj = Delegate.Combine(ToolTipsText.A_OpenTooltip, b);
		nint num2;
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		if ((object)obj == null)
		{
			ToolTipsText.A_OpenTooltip = (Action<string, Vector2>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, Vector2> action = default(Action<string, Vector2>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<string, Vector2>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_02c1;
			}
			ToolTipsText.A_OpenTooltip = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<string, Vector2>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_028e;
			}
		}
		Action<string> b2 = CloseTooltip;
		Delegate obj6 = Delegate.Combine(ToolTipsText.A_CloseTooltip, b2);
		nint num3;
		if ((object)obj6 == null)
		{
			ToolTipsText.A_CloseTooltip = (Action<string>)obj6;
			num3 = (nint)ToolTipsText.A_CloseTooltip;
			goto IL_01cb;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string> action2 = default(Action<string>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<string>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag2)
		{
			ToolTipsText.A_CloseTooltip = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num3 = (nint)typeof(Action<string>);
			num = (nint)typeof(Action<string>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (!flag3)
			{
				goto IL_01cb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			num2 = num;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_028e;
		IL_028e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02c1:
		throw new NullReferenceException();
		IL_01cb:
		bool flag4 = (object)parent == null;
		num = num3;
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag4)
		{
			Transform transform = parent.transform;
			bool flag5 = (object)transform == null;
			num = num3;
			obj2 = (Delegate)(object)transform;
			obj3 = 0;
			obj4 = 0;
			if (!flag5)
			{
				object obj8 = default(object);
				transform.localScale = (Vector3)(&obj8);
				return;
			}
		}
		goto IL_02c1;
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
		Action<string, Vector2> value = OpenTooltip;
		Delegate obj = Delegate.Remove(ToolTipsText.A_OpenTooltip, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			ToolTipsText.A_OpenTooltip = (Action<string, Vector2>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, Vector2> action = default(Action<string, Vector2>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<string, Vector2>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			ToolTipsText.A_OpenTooltip = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<string, Vector2>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0215;
			}
		}
		Action<string> value2 = CloseTooltip;
		Delegate obj6 = Delegate.Remove(ToolTipsText.A_CloseTooltip, value2);
		if ((object)obj6 == null)
		{
			ToolTipsText.A_CloseTooltip = (Action<string>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string> action2 = default(Action<string>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<string>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		ToolTipsText.A_CloseTooltip = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<string>);
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

	private unsafe void OpenTooltip(string linkID, Vector2 position)
	{
		//IL_0043: Expected O, but got Ref
		//IL_00bd: Expected O, but got Ref
		//IL_00e3: Expected O, but got Ref
		float num = -1f / scaleTime;
		lerpValue = num;
		Transform transform = parent.transform;
		Vector3 vector = default(Vector3);
		transform.localScale = (Vector3)(&vector);
		string idInfo = Tooltip.GetIdInfo(linkID);
		t_tooltip.text = idInfo;
		GameObject gameObject = parent.gameObject;
		gameObject.SetActive(value: true);
		opening = true;
		Transform transform2 = parent.transform;
		transform2.localScale = (Vector3)(&vector);
		Transform transform3 = parent.transform;
		transform3.position = (Vector3)(&vector);
	}

	private void CloseTooltip(string linkID)
	{
		opening = false;
	}

	private unsafe void Update()
	{
		//IL_01c5: Invalid comparison between I4 and F4
		//IL_0111: Expected F4, but got I4
		//IL_0123: Expected O, but got Ref
		//IL_0150: Invalid comparison between I4 and F4
		float num2;
		if (!opening)
		{
			float deltaTime = Time.deltaTime;
			float num = deltaTime / scaleTime;
			num2 = lerpValue - num;
		}
		else
		{
			float deltaTime2 = Time.deltaTime;
			float num3 = deltaTime2 / scaleTime;
			float num4 = num3 + lerpValue;
			num2 = num4;
		}
		lerpValue = num2;
		if (!(-1f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = -1f;
		}
		lerpValue = num2;
		Transform transform = parent.transform;
		float num5 = lerpValue;
		if (!(0f > lerpValue))
		{
			if (num5 > 1f)
			{
				num5 = 1f;
			}
		}
		else
		{
			num5 = 0f;
		}
		float num6 = default(float);
		transform.localScale = (Vector3)(&num6);
		if (!opening && !(0f < lerpValue))
		{
			parent.SetActive(value: false);
		}
	}
}
