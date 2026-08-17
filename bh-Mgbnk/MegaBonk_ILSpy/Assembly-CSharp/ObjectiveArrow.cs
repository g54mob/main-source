using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class ObjectiveArrow : MonoBehaviour
{
	private Vector3 offset;

	public Transform tutorialArrow;

	public RectTransform canvasRect;

	private Transform _003Ctarget_003Ek__BackingField;

	private float hideAtDistance;

	private float timeout;

	private float targetAtTime;

	private float minTime;

	private float scaleMultiplier;

	private Vector3 targetSize;

	private Vector3 fromScale;

	private float timer;

	private float scaleTime;

	public Transform target
	{
		get
		{
			return _003Ctarget_003Ek__BackingField;
		}
		set
		{
			_003Ctarget_003Ek__BackingField = value;
		}
	}

	private unsafe void Awake()
	{
		//IL_0021: Expected O, but got Ref
		//IL_0057: Expected I, but got O
		Transform transform = tutorialArrow.transform;
		object obj = default(object);
		transform.localScale = (Vector3)(&obj);
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v9 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		targetSize = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		GameObject gameObject = tutorialArrow.gameObject;
		gameObject.SetActive(value: false);
	}

	public void SetTarget(Transform t, Vector3 offset, float hideAtDistance, float timeout, float scaleMultiplier = 1f)
	{
		//IL_008b: Expected O, but got F4
		//IL_00d6: Expected I, but got O
		//IL_005c: Expected O, but got F4
		_003Ctarget_003Ek__BackingField = t;
		this.offset = (Vector3)offset.x;
		float num = default(float);
		this.timeout = num;
		this.hideAtDistance = hideAtDistance;
		float num2 = default(float);
		this.scaleMultiplier = num2;
		_ = offset.z;
		targetAtTime = MyTime.time;
		GameObject gameObject = tutorialArrow.gameObject;
		gameObject.SetActive(value: true);
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		targetSize = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rcx_v9 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		_ = 0;
		Transform transform = tutorialArrow.transform;
		Vector3 localScale = transform.localScale;
		fromScale = (Vector3)localScale.x;
		_ = localScale.z;
		timer = 0f;
	}

	public void ClearTarget()
	{
		_003Ctarget_003Ek__BackingField = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 13 Invalid \"Jump target not found in method: 0x18053E3D0\"");
	}

	private void Show()
	{
		//IL_007b: Expected I, but got O
		//IL_0057: Expected O, but got F4
		GameObject gameObject = tutorialArrow.gameObject;
		gameObject.SetActive(value: true);
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		targetSize = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		_ = 0;
		Transform transform = tutorialArrow.transform;
		Vector3 localScale = transform.localScale;
		fromScale = (Vector3)localScale.x;
		_ = localScale.z;
		timer = 0f;
	}

	private void Hide()
	{
		//IL_0059: Expected I, but got O
		//IL_0035: Expected O, but got F4
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		targetSize = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		Transform transform = tutorialArrow.transform;
		Vector3 localScale = transform.localScale;
		fromScale = (Vector3)localScale.x;
		_ = localScale.z;
		timer = 0f;
	}

	private bool IsHidden()
	{
		//IL_014c: Expected I4, but got O
		//IL_015a: Expected I, but got O
		//IL_0100: Invalid comparison between F4 and I4
		//IL_0110: Invalid comparison between F4 and I4
		if ((object)tutorialArrow != null)
		{
			Vector3 localScale = tutorialArrow.localScale;
			nint num = (nint)typeof(Math);
			float num2 = localScale.y * localScale.y;
			float num3 = localScale.x * localScale.x;
			float num4 = localScale.z * localScale.z;
			float num5 = num2 + num3;
			float num6 = num5 + num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v3 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			}
			else
			{
				double num7 = Math.Sqrt(num6);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
			bool flag = 0.001f < 0f;
			bool flag2 = 0.001f == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void UpdateSize()
	{
		//IL_0080: Invalid comparison between I4 and F4
		//IL_00cb: Expected F4, but got I4
		//IL_00dd: Expected O, but got Ref
		if (!(timer < 1f))
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		float num = deltaTime / scaleTime;
		float num2 = num + timer;
		timer = num2;
		Transform transform = tutorialArrow.transform;
		float num3 = timer;
		if (!(0f > timer))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = 0f;
		}
		float num4 = default(float);
		transform.localScale = (Vector3)(&num4);
	}

	private unsafe void Update()
	{
		//IL_0063: Invalid comparison between I4 and F4
		//IL_00ae: Expected F4, but got I4
		//IL_0482: Expected I, but got O
		//IL_00c0: Expected O, but got Ref
		//IL_030f: Invalid comparison between F4 and I4
		//IL_03f1: Expected I, but got O
		//IL_0207: Invalid comparison between F4 and I4
		if (timer < 1f)
		{
			float deltaTime = Time.deltaTime;
			float num = deltaTime / scaleTime;
			float num2 = num + timer;
			timer = num2;
			Transform transform = tutorialArrow.transform;
			float num3 = timer;
			if (!(0f > timer))
			{
				if (num3 > 1f)
				{
					num3 = 1f;
				}
			}
			else
			{
				num3 = 0f;
			}
			float num4 = default(float);
			transform.localScale = (Vector3)(&num4);
		}
		bool flag = _003Ctarget_003Ek__BackingField != null;
		if (_003Ctarget_003Ek__BackingField != null)
		{
			TargetFollowItem();
			float num5 = targetAtTime + timeout;
			if (!(MyTime.time < num5))
			{
				Hide();
			}
			Vector3 position = _003Ctarget_003Ek__BackingField.position;
			Transform transform2 = MyPlayer.Instance.transform;
			Vector3 position2 = transform2.position;
			nint num6 = (nint)typeof(Math);
			float num7 = position.x - position2.x;
			float num8 = position.y - position2.y;
			float num9 = position.z - position2.z;
			float num10 = num8 * num8;
			float num11 = num7 * num7;
			float num12 = num9 * num9;
			float num13 = num10 + num11;
			float num14 = num13 + num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ rcx_v25 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			}
			else
			{
				double num15 = Math.Sqrt(num14);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
			if (hideAtDistance > 0f)
			{
				float num16 = minTime + targetAtTime;
				if (MyTime.time > num16)
				{
					Hide();
				}
			}
		}
		Vector3 localScale = tutorialArrow.localScale;
		nint num17 = (nint)typeof(Math);
		float num18 = localScale.y * localScale.y;
		float num19 = localScale.x * localScale.x;
		float num20 = localScale.z * localScale.z;
		float num21 = num18 + num19;
		float num22 = num21 + num20;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v10 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
		}
		else
		{
			double num23 = Math.Sqrt(num22);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
		if (0.001f > 0f)
		{
			GameObject gameObject = tutorialArrow.gameObject;
			if (gameObject.activeSelf)
			{
				GameObject gameObject2 = tutorialArrow.gameObject;
				gameObject2.SetActive(value: false);
			}
		}
	}

	private unsafe void TargetFollowItem()
	{
		//IL_0057: Expected O, but got Ref
		//IL_0077: Expected O, but got Ref
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_015e: Invalid comparison between O and F4
		//IL_016f: Expected F4, but got O
		//IL_01a6: Expected O, but got Ref
		GameObject gameObject = tutorialArrow.gameObject;
		gameObject.SetActive(value: true);
		Vector3 position = _003Ctarget_003Ek__BackingField.position;
		Camera main = Camera.main;
		float num = default(float);
		Vector3 vector = calculateWorldPosition((Vector3)(&num), main);
		Camera main2 = Camera.main;
		Vector3 vector2 = main2.WorldToScreenPoint((Vector3)(&num));
		Vector2 screenPoint = default(Vector2);
		bool flag = RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, null, out var localPoint);
		Vector2 sizeDelta = canvasRect.sizeDelta;
		float num2 = (float)sizeDelta * 0.5f;
		object obj = default(object);
		float num3 = (float)obj * 0.5f;
		float num4 = num2 * 0.85f;
		float num5 = num3 * 0.85f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
		object obj2 = sizeDelta ^ 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
		object obj3 = obj ^ 0;
		float num6 = (float)obj2 * 0.5f;
		float num7 = (float)obj3 * 0.5f;
		float num8 = num6 * 0.85f;
		float num9 = num7 * 0.85f;
		bool flag2 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref localPoint) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4);
		float num10 = (float)localPoint;
		if (!flag2)
		{
			num10 = num4;
		}
		if (num8 > num10)
		{
			goto IL_01c1;
		}
		goto IL_01db;
		IL_01db:
		float num11 = default(float);
		bool flag3 = !(num11 > num5);
		float num12 = num11;
		if (!flag3)
		{
			num12 = num5;
		}
		goto IL_01c1;
		IL_01c1:
		if (!(num9 > num12))
		{
			tutorialArrow.localPosition = (Vector3)(&num);
			return;
		}
		goto IL_01db;
	}

	private unsafe Vector3 calculateWorldPosition(Vector3 position, Camera camera)
	{
		//IL_018a: Invalid comparison between I4 and F4
		//IL_034b: Expected native int or pointer, but got O
		//IL_035d: Expected native int or pointer, but got O
		//IL_030c: Expected native int or pointer, but got O
		//IL_0319: Expected native int or pointer, but got O
		//IL_0326: Expected native int or pointer, but got O
		if ((object)camera != null)
		{
			Transform transform = camera.transform;
			if ((object)transform != null)
			{
				Vector3 forward = transform.forward;
				Transform transform2 = camera.transform;
				if ((object)transform2 != null)
				{
					Vector3 position2 = transform2.position;
					float num = position.x - position2.x;
					float num2 = position.y - position2.y;
					float num3 = position.z - position2.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					float num4 = forward.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rax_v8+4]");
					float num5 = num4 * 0f;
					object obj = default(object);
					float num6 = forward.x * (float)obj;
					float num7 = forward.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rax_v8+8]");
					float num8 = num7 * 0f;
					float num9 = num5 + num6;
					float num10 = num9 + num8;
					if (!(0f < num10))
					{
						float num11 = num2 * forward.y;
						float num12 = num * forward.x;
						float num13 = num3 * forward.z;
						float num14 = num11 + num12;
						float num15 = num14 + num13;
						float num16 = num15 * forward.x;
						float num17 = num15 * forward.y;
						float num18 = num15 * forward.z;
						float num19 = num17 * 1.01f;
						float num20 = num16 * 1.01f;
						float num21 = num18 * 1.01f;
						Transform transform3 = camera.transform;
						if ((object)transform3 == null)
						{
							goto IL_0330;
						}
						Vector3 position3 = transform3.position;
						float num22 = num - num20;
						float num23 = num2 - num19;
						float num24 = num3 - num21;
						float x = num22 + position3.x;
						float y = num23 + position3.y;
						float z = num24 + position3.z;
						((Vector3*)(nint)position)->x = x;
						((Vector3*)(nint)position)->y = y;
						((Vector3*)(nint)position)->z = z;
					}
					Vector3 vector = default(Vector3);
					((Vector3*)(nint)vector)->x = position.x;
					((Vector3*)(nint)vector)->z = position.z;
					return vector;
				}
			}
		}
		goto IL_0330;
		IL_0330:
		return (Vector3)new NullReferenceException();
	}

	public ObjectiveArrow()
	{
		//IL_001e: Expected I, but got O
		//IL_0059: Expected I, but got O
		minTime = 2f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		targetSize = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		_ = 0;
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		fromScale = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		scaleTime = 0.5f;
		base._002Ector();
	}
}
