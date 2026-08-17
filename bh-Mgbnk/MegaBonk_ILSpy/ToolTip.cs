using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ToolTip : MonoBehaviour
{
	public TextMeshProUGUI t_tip;

	public CanvasGroup group;

	public Canvas parentCanvas;

	public RectTransform backDrop;

	public static ToolTip Instance;

	private bool visible;

	private bool useMouse;

	private float x;

	private float speed = 6f;

	private float offset = 4f;

	private void Awake()
	{
		//IL_0221: Expected O, but got I4
		//IL_0237: Expected I, but got O
		//IL_025d: Expected O, but got I4
		//IL_0273: Expected I, but got O
		//IL_029e: Expected I, but got O
		//IL_02f8: Expected O, but got I4
		if (Instance == null)
		{
			Instance = this;
			Action b = HideTip;
			Delegate obj = Delegate.Combine(TransitionUI.A_transitionStart, b);
			object obj3;
			Delegate obj4;
			if ((object)obj == null)
			{
				TransitionUI.A_transitionStart = null;
			}
			else
			{
				bool flag = (object)obj.GetType() != typeof(Action);
				Delegate obj2 = null;
				if (!flag)
				{
					obj2 = obj;
				}
				bool flag2 = (object)obj2 == null;
				obj3 = 0;
				obj4 = obj;
				nint num = (nint)typeof(Action);
				if (flag2)
				{
					goto IL_02c9;
				}
				TransitionUI.A_transitionStart = (Action)obj2;
				bool flag3 = (object)obj.GetType() != typeof(Action);
				Delegate obj5 = null;
				if (!flag3)
				{
					obj5 = obj;
				}
				bool flag4 = (object)obj5 == null;
				obj3 = 0;
				obj4 = obj;
				nint num2 = (nint)typeof(Action);
				if (flag4)
				{
					goto IL_02d4;
				}
			}
			Action b2 = HideTip;
			Delegate obj6 = Delegate.Combine(TransitionUI.A_transitionEnd, b2);
			if ((object)obj6 == null)
			{
				TransitionUI.A_transitionEnd = null;
				return;
			}
			bool flag5 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag5)
			{
				obj7 = obj6;
			}
			bool flag6 = (object)obj7 == null;
			nint num3 = (nint)typeof(Action);
			if (!flag6)
			{
				TransitionUI.A_transitionEnd = (Action)obj7;
				bool flag7 = (object)obj6.GetType() != typeof(Action);
				Delegate obj8 = null;
				if (!flag7)
				{
					obj8 = obj6;
				}
				if ((object)obj8 != null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			obj3 = 0;
			obj4 = obj6;
			goto IL_02d4;
		}
		GameObject obj9 = base.gameObject;
		UnityEngine.Object.Destroy(obj9);
		return;
		IL_02c9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02d4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02c9;
	}

	private void OnDestroy()
	{
		//IL_01a4: Expected I, but got O
		//IL_01ad: Expected O, but got I4
		//IL_0217: Expected O, but got I4
		//IL_022d: Expected I, but got O
		//IL_0253: Expected O, but got I4
		//IL_0269: Expected I, but got O
		//IL_0294: Expected I, but got O
		//IL_029d: Expected O, but got I4
		Action value = HideTip;
		Delegate obj = Delegate.Remove(TransitionUI.A_transitionStart, value);
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			TransitionUI.A_transitionStart = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_02ce;
			}
			TransitionUI.A_transitionStart = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_02b3;
			}
		}
		Action value2 = HideTip;
		Delegate obj6 = Delegate.Remove(TransitionUI.A_transitionEnd, value2);
		if ((object)obj6 == null)
		{
			TransitionUI.A_transitionEnd = null;
			return;
		}
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag4)
		{
			obj7 = obj6;
		}
		bool flag5 = (object)obj7 == null;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_02be;
		}
		TransitionUI.A_transitionEnd = (Action)obj7;
		bool flag6 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag6)
		{
			obj8 = obj6;
		}
		bool flag7 = (object)obj8 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj6;
		if (!flag7)
		{
			return;
		}
		goto IL_02ce;
		IL_02b3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02be:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b3;
		IL_02ce:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02be;
	}

	public void SetTip(string text)
	{
		t_tip.text = text;
		visible = true;
	}

	public unsafe void SetTip(string text, RectTransform uiElement)
	{
		//IL_0061: Expected O, but got Ref
		TextMeshProUGUI textMeshProUGUI = t_tip;
		textMeshProUGUI.text = text;
		visible = true;
		Vector3[] fourCornersArray = new Vector3[4];
		uiElement.GetWorldCorners(fourCornersArray);
		Transform transform = base.transform;
		float num = default(float);
		transform.position = (Vector3)(&num);
	}

	public void HideTip()
	{
		visible = false;
	}

	private unsafe void Update()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_048f: Invalid comparison between I4 and F4
		//IL_00c6: Expected F4, but got I4
		//IL_04cd: Expected I, but got O
		//IL_04f1: Expected I, but got O
		//IL_06fe: Invalid comparison between I4 and F4
		//IL_0134: Expected F4, but got I4
		//IL_0513: Expected O, but got I
		//IL_053f: Expected O, but got I
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_0672: Expected I, but got O
		//IL_069b: Expected O, but got I
		//IL_0377: Expected O, but got I
		//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Expected Ref, but got Unknown
		//IL_03ce: Expected O, but got I
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_035d: Expected O, but got I
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Expected O, but got Unknown
		//IL_05e9: Expected I, but got O
		//IL_03b4: Expected O, but got I
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		_ = 0;
		float num2;
		if (!visible)
		{
			float deltaTime = Time.deltaTime;
			float num = deltaTime * speed;
			num2 = x - num;
		}
		else
		{
			float deltaTime2 = Time.deltaTime;
			float num3 = deltaTime2 * speed;
			float num4 = num3 + x;
			num2 = num4;
		}
		x = num2;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		x = num2;
		float num5 = Easing.InOutQuad(num2);
		group.alpha = x;
		Transform transform = group.transform;
		nint num6 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rax_v11 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num7 = 0;
		_ = Vector3.zeroVector;
		nint num8 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rax_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num9 = 0;
		float num10;
		if (!(0f > num5))
		{
			bool flag = !(num5 > 1f);
			num10 = num5;
			if (!flag)
			{
				num10 = 1f;
			}
		}
		else
		{
			num10 = 0f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rax_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj3 = num11 - 0;
		object obj4 = Vector3.oneVector - Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rax_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-25]");
		object obj5 = num12 - 0;
		float num13 = (float)obj3 * num10;
		float num14 = (float)obj4 * num10;
		float num15 = (float)obj5 * num10;
		float num16 = num13;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		float num17 = num16 + 0f;
		float num18 = num14 + (float)Vector3.zeroVector;
		float num19 = num15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-25]");
		float num20 = num19 + 0f;
		Vector3 localScale = (Vector3)(obj - 41);
		transform.localScale = localScale;
		if (useMouse)
		{
			Transform transform2 = parentCanvas.transform;
			Vector3 mousePosition = Input.mousePosition;
			Camera worldCamera = parentCanvas.worldCamera;
			bool flag2 = (object)transform2 == null;
			RectTransform rect = null;
			if (!flag2)
			{
				bool flag3 = (object)transform2.GetType() != typeof(RectTransform);
				rect = null;
				if (!flag3)
				{
					rect = (RectTransform)transform2;
				}
			}
			Vector2 screenPoint = default(Vector2);
			bool flag4 = RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPoint, worldCamera, out *(Vector2*)(obj + 103));
			Transform transform3 = parentCanvas.transform;
			Vector3 position = (Vector3)(obj - 41);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1+67]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1+6B]");
			_ = 0;
			_ = 0;
			Vector3 vector = transform3.TransformPoint(position);
			num20 = vector.y;
			_ = vector.x;
			_ = vector.y;
			Transform transform4 = base.transform;
			float scaleFactor = parentCanvas.scaleFactor;
			nint num21 = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rax_v36 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num22 = 0;
			float num23 = offset * scaleFactor;
			float num24 = num23;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rcx_v33 (Il2CppStaticFields<UnityEngine.Vector2>)+C]");
			float num25 = num24 * 0f;
			float num26 = num23 * (float)Vector2.oneVector;
			float num27 = num25;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1+6B]");
			float num28 = num27 + 0f;
			float num29 = num26;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1+67]");
			num18 = num29 + 0f;
			Vector3 position2 = (Vector3)(obj - 41);
			_ = 0;
			transform4.position = position2;
		}
		Vector3[] fourCornersArray = new Vector3[4];
		backDrop.GetWorldCorners(fourCornersArray);
		nint num30 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rax_v19 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num31 = 0;
		Vector3 vector2 = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ rcx_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
		Vector3 vector3 = (Vector3)0;
		int width = Screen.width;
		int height = Screen.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v16 (UnityEngine.Vector3[])+38]");
		if ((nint)0 <= (nint)width)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v16 (UnityEngine.Vector3[])+20]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v16 (UnityEngine.Vector3[])+20]");
				vector2 = (Vector3)0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v16 (UnityEngine.Vector3[])+38]");
			vector2 = (Vector3)(-width);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v16 (UnityEngine.Vector3[])+3C]");
		if ((nint)0 <= (nint)height)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v16 (UnityEngine.Vector3[])+24]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v16 (UnityEngine.Vector3[])+24]");
				vector3 = (Vector3)0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v16 (UnityEngine.Vector3[])+3C]");
			vector3 = (Vector3)(-height);
		}
		Transform transform5 = base.transform;
		Vector3 position3 = transform5.position;
		Vector3 position4 = (Vector3)(obj - 41);
		float num32 = position3.x - (float)vector2;
		float num33 = position3.y - (float)vector3;
		float num34 = position3.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ rcx_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		float num35 = num34 - 0f;
		transform5.position = position4;
	}
}
