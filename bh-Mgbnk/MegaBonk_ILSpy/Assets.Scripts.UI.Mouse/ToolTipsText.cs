using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Mouse;

public class ToolTipsText : MonoBehaviour
{
	public delegate void HoverOnLinkEvent(string keyword, Vector3 mousePos);

	public delegate void CloseTooltipEvent();

	private TMP_Text tmpTextBox;

	private Canvas canvas;

	private UnityEngine.Camera camera;

	private RectTransform textBoxRectTransform;

	private int currentlyActiveLinkedElement;

	private static HoverOnLinkEvent m_OnHoverOnLinkEvent;

	private static CloseTooltipEvent m_OnCloseTooltipEvent;

	public static Action<string, Vector2> A_OpenTooltip;

	public static Action<string> A_CloseTooltip;

	private float readyTime;

	private Vector3 lastPos;

	private bool hasVisibleMouse;

	public static event HoverOnLinkEvent OnHoverOnLinkEvent
	{
		add
		{
			//IL_004f: Expected I, but got O
			Delegate obj = ToolTipsText.m_OnHoverOnLinkEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(HoverOnLinkEvent);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(ToolTipsText);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802652A0");
				bool flag3 = (object)obj4 != obj;
				obj = obj4;
				if (!flag3)
				{
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		remove
		{
			//IL_004f: Expected I, but got O
			Delegate obj = ToolTipsText.m_OnHoverOnLinkEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(HoverOnLinkEvent);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(ToolTipsText);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802652A0");
				bool flag3 = (object)obj4 != obj;
				obj = obj4;
				if (!flag3)
				{
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
	}

	public static event CloseTooltipEvent OnCloseTooltipEvent
	{
		add
		{
			//IL_004f: Expected I, but got O
			//IL_0065: Expected O, but got I
			Delegate obj = ToolTipsText.m_OnCloseTooltipEvent;
			Delegate obj5 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(CloseTooltipEvent);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(ToolTipsText);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v5 (Il2CppClass<Assets.Scripts.UI.Mouse.ToolTipsText>)+B8]");
				object obj4 = (nint)0 + (nint)8;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802652A0");
				bool flag3 = (object)obj5 != obj;
				obj = obj5;
				if (!flag3)
				{
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		remove
		{
			//IL_004f: Expected I, but got O
			//IL_0065: Expected O, but got I
			Delegate obj = ToolTipsText.m_OnCloseTooltipEvent;
			Delegate obj5 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(CloseTooltipEvent);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(ToolTipsText);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v5 (Il2CppClass<Assets.Scripts.UI.Mouse.ToolTipsText>)+B8]");
				object obj4 = (nint)0 + (nint)8;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802652A0");
				bool flag3 = (object)obj5 != obj;
				obj = obj5;
				if (!flag3)
				{
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
	}

	private void Awake()
	{
		TMP_Text component = GetComponent<TMP_Text>();
		tmpTextBox = component;
		Canvas componentInParent = GetComponentInParent<Canvas>();
		canvas = componentInParent;
		RectTransform component2 = GetComponent<RectTransform>();
		textBoxRectTransform = component2;
		if (canvas.renderMode != RenderMode.ScreenSpaceOverlay)
		{
			UnityEngine.Camera worldCamera = canvas.worldCamera;
			camera = worldCamera;
		}
		else
		{
			camera = null;
		}
	}

	private void OnEnable()
	{
		float time = Time.time;
		float num = time + 1f;
		readyTime = num;
	}

	private void Update()
	{
		//IL_0054: Expected O, but got F4
		float time = Time.time;
		if (!(readyTime > time))
		{
			CheckForLinkAtMousePosition();
			return;
		}
		Vector3 mousePosition = Input.mousePosition;
		Vector3 mousePosition2 = Input.mousePosition;
		lastPos = (Vector3)mousePosition.x;
		_ = mousePosition2.y;
		_ = 0;
	}

	private unsafe void CheckForLinkAtMousePosition()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_042b: Expected O, but got I
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_04a7: Expected I4, but got I8
		//IL_0341: Expected O, but got I4
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Expected O, but got Unknown
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		//IL_0493: Expected I4, but got I8
		//IL_01dc: Expected O, but got I4
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_0212: Expected O, but got F4
		//IL_014f: Expected O, but got I4
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		_ = 0;
		_ = 0;
		_ = 0;
		Vector3 mousePosition = Input.mousePosition;
		Vector3 mousePosition2 = Input.mousePosition;
		float num = (float)lastPos - mousePosition.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.UI.Mouse.ToolTipsText)+4C]");
		float num2 = 0f - mousePosition2.y;
		float num3 = num2 * num2;
		float num4 = num * num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.UI.Mouse.ToolTipsText)+50]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.UI.Mouse.ToolTipsText)+50]");
		object obj3 = num5 * 0;
		float num6 = num3 + num4;
		float num7 = num6 + (float)obj3;
		if (0.1f > num7)
		{
			return;
		}
		_ = mousePosition.x;
		_ = mousePosition2.y;
		Vector3 position = (Vector3)(obj - 57);
		_ = 0;
		if (TMP_TextUtilities.IsIntersectingRectTransform(textBoxRectTransform, position, camera))
		{
			_ = mousePosition.x;
			_ = mousePosition2.y;
			Vector3 position2 = (Vector3)(obj - 57);
			_ = 0;
			int num8 = TMP_TextUtilities.FindIntersectingLink(tmpTextBox, position2, camera);
			if (currentlyActiveLinkedElement == num8)
			{
				return;
			}
			if (currentlyActiveLinkedElement != -1)
			{
				Action<string> a_CloseTooltip = A_CloseTooltip;
				if (A_CloseTooltip != null)
				{
					TMP_TextInfo textInfo = tmpTextBox.textInfo;
					object obj4 = currentlyActiveLinkedElement + 1;
					object obj5 = obj4 * 4;
					object obj6 = currentlyActiveLinkedElement + obj5;
					object obj7 = obj6 * 8;
					TMP_LinkInfo tMP_LinkInfo = (TMP_LinkInfo)((object)textInfo.linkInfo + obj7);
					string linkID = ((TMP_LinkInfo*)tMP_LinkInfo)->GetLinkID();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v390 @ rsi_v10 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
				}
				currentlyActiveLinkedElement = -1;
			}
			if (num8 != -1)
			{
				TMP_TextInfo textInfo2 = tmpTextBox.textInfo;
				TMP_LinkInfo[] linkInfo = textInfo2.linkInfo;
				object obj8 = num8 * 4;
				object obj9 = num8 + obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rdx_v16 (TMPro.TMP_LinkInfo[])+20+v575 @ rcx_v21*8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rdx_v16 (TMPro.TMP_LinkInfo[])+30+v575 @ rcx_v21*8]");
				_ = 0;
				lastPos = (Vector3)mousePosition.x;
				_ = mousePosition2.y;
				currentlyActiveLinkedElement = num8;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rdx_v16 (TMPro.TMP_LinkInfo[])+40+v575 @ rcx_v21*8]");
				_ = 0;
				Action<string, Vector2> a_OpenTooltip = A_OpenTooltip;
				if (A_OpenTooltip != null)
				{
					TMP_LinkInfo tMP_LinkInfo2 = (TMP_LinkInfo)(obj - 41);
					string linkID2 = ((TMP_LinkInfo*)tMP_LinkInfo2)->GetLinkID();
					TMP_LinkInfo linkInfo2 = (TMP_LinkInfo)(obj + 7);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-29]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-19]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-9]");
					_ = 0;
					Vector3 linkPosition = GetLinkPosition(linkInfo2);
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v283 @ rsi_v9 (System.Action`2<System.String, UnityEngine.Vector2>)+18] (should have been resolved before IL gen)");
				}
			}
		}
		else if (currentlyActiveLinkedElement != -1)
		{
			Action<string> a_CloseTooltip2 = A_CloseTooltip;
			if (A_CloseTooltip != null)
			{
				TMP_TextInfo textInfo3 = tmpTextBox.textInfo;
				object obj10 = currentlyActiveLinkedElement + 1;
				object obj11 = obj10 * 4;
				object obj12 = currentlyActiveLinkedElement + obj11;
				object obj13 = obj12 * 8;
				TMP_LinkInfo tMP_LinkInfo3 = (TMP_LinkInfo)((object)textInfo3.linkInfo + obj13);
				string linkID3 = ((TMP_LinkInfo*)tMP_LinkInfo3)->GetLinkID();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v262 @ rbx_v7 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
			currentlyActiveLinkedElement = -1;
		}
	}

	private unsafe Vector3 GetLinkPosition(TMP_LinkInfo linkInfo, float verticalOffset = 10f)
	{
		//IL_004f: Expected O, but got I4
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_009c: Expected O, but got Ref
		//IL_00a4: Expected O, but got Ref
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Expected O, but got Unknown
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected O, but got Unknown
		//IL_03f4: Expected O, but got I4
		//IL_00d4: Expected F4, but got O
		//IL_00cf: Expected native int or pointer, but got O
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_018d: Expected O, but got I
		//IL_01b9: Expected O, but got Ref
		//IL_01c1: Expected O, but got Ref
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Expected O, but got Unknown
		//IL_0427: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Expected O, but got Unknown
		//IL_0498: Expected O, but got I4
		//IL_01f1: Expected F4, but got O
		//IL_01ec: Expected native int or pointer, but got O
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_02dc: Expected O, but got I
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected O, but got Unknown
		//IL_0322: Expected O, but got Ref
		//IL_033b: Expected O, but got Ref
		//IL_034c: Expected F4, but got O
		//IL_0347: Expected native int or pointer, but got O
		//IL_0354: Expected native int or pointer, but got O
		//IL_0362: Expected native int or pointer, but got O
		TMP_TextInfo textInfo = tmpTextBox.textInfo;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004750");
		TMP_TextInfo textInfo2 = tmpTextBox.textInfo;
		object obj = linkInfo.linkTextLength - 1;
		object obj2 = obj + linkInfo.linkTextfirstCharacterIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004750");
		TMP_TextInfo textInfo3 = tmpTextBox.textInfo;
		bool flag = textInfo3 == null;
		object obj4 = default(object);
		object obj3 = (object)(&obj4);
		object obj5 = default(object);
		Vector3 vector = (Vector3)(&obj5);
		object obj6 = default(object);
		obj3 = obj6;
		Vector3 vector2 = default(Vector3);
		vector = vector2;
		object obj7;
		do
		{
			vector += 128;
			obj3 += 128;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12-60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12-30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12-20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12-10]");
			_ = 0;
			obj7 = !flag;
		}
		while (obj7 != null);
		TMP_MeshInfo[] meshInfo = textInfo3.meshInfo;
		((Vector3*)(nint)vector)->x = (float)obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12+40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v12+70]");
		_ = 0;
		object obj8 = default(object);
		if ((nint)obj8 < meshInfo.Length)
		{
			object obj9 = obj8 * 4;
			object obj10 = obj8 + obj9;
			object obj11 = obj10 + obj10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v14 (TMPro.TMP_MeshInfo[])+30+v434 @ rax_v17*8]");
			TMP_MeshInfo tMP_MeshInfo = (TMP_MeshInfo)0;
			TMP_TextInfo textInfo4 = tmpTextBox.textInfo;
			bool flag2 = textInfo4 == null;
			object obj13 = default(object);
			object obj12 = (object)(&obj13);
			Vector3 vector3 = (Vector3)(&obj5);
			obj12 = obj6;
			vector3 = vector2;
			object obj14;
			do
			{
				vector3 += 128;
				obj12 += 128;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v20+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v20-60]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v20-50]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v20-40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v20-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v20-20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v20-10]");
				_ = 0;
				obj14 = !flag2;
			}
			while (obj14 != null);
			TMP_MeshInfo[] meshInfo2 = textInfo4.meshInfo;
			((Vector3*)(nint)vector3)->x = (float)obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v20+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v20+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v20+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v20+40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v20+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v20+60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v20+70]");
			_ = 0;
			if ((nint)obj8 < meshInfo2.Length)
			{
				object obj16 = default(object);
				object obj15 = obj16 + 1;
				Vector3[] normals = tMP_MeshInfo.normals;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15) < System.Runtime.CompilerServices.Unsafe.As<Vector3[], UIntPtr>(ref normals))
				{
					object obj17 = obj8 * 4;
					object obj18 = obj8 + obj17;
					object obj19 = obj18 + obj18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r8_v7 (TMPro.TMP_MeshInfo[])+30+v96 @ rax_v24*8]");
					TMP_MeshInfo tMP_MeshInfo2 = (TMP_MeshInfo)0;
					object obj21 = default(object);
					object obj20 = obj21 + 2;
					Vector3[] normals2 = tMP_MeshInfo2.normals;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj20) < System.Runtime.CompilerServices.Unsafe.As<Vector3[], UIntPtr>(ref normals2))
					{
						float num = default(float);
						Vector3 vector4 = textBoxRectTransform.TransformPoint((Vector3)(&num));
						Vector2 vector5 = RectTransformUtility.WorldToScreenPoint(camera, (Vector3)(&num));
						((Vector3*)(nint)vector2)->x = (float)vector5;
						float y = default(float);
						((Vector3*)(nint)vector2)->y = y;
						((Vector3*)(nint)vector2)->z = 0f;
						return vector2;
					}
				}
			}
		}
		return (Vector3)new IndexOutOfRangeException();
	}

	private unsafe void OnDisable()
	{
		//IL_00d7: Expected I4, but got I8
		//IL_0050: Expected O, but got I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		if (currentlyActiveLinkedElement != -1)
		{
			Action<string> a_CloseTooltip = A_CloseTooltip;
			if (A_CloseTooltip != null)
			{
				TMP_TextInfo textInfo = tmpTextBox.textInfo;
				object obj = currentlyActiveLinkedElement + 1;
				object obj2 = obj * 4;
				object obj3 = currentlyActiveLinkedElement + obj2;
				object obj4 = obj3 * 8;
				TMP_LinkInfo tMP_LinkInfo = (TMP_LinkInfo)((object)textInfo.linkInfo + obj4);
				string linkID = ((TMP_LinkInfo*)tMP_LinkInfo)->GetLinkID();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v41 @ rdi_v2 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
			currentlyActiveLinkedElement = -1;
		}
	}

	public ToolTipsText()
	{
		//IL_000f: Expected I4, but got I8
		currentlyActiveLinkedElement = -1;
		base._002Ector();
	}
}
