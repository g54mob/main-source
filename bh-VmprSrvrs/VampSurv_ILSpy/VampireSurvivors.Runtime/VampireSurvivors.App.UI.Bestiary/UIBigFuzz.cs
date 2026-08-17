using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.App.UI.Bestiary;

public class UIBigFuzz : MonoBehaviour
{
	private Image body;

	private Image head;

	private Image leftHand;

	private Image rightHand;

	private Image leftDoor;

	private Image rightDoor;

	private MultiTargetTween doorOpenTween;

	private Timer rightHandTimer;

	private Timer leftHandTimer;

	private Timer doorTimer;

	public float doorOffset;

	public float handOffset;

	private unsafe void Start()
	{
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Expected O, but got Unknown
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Expected O, but got Unknown
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Expected O, but got Unknown
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Expected O, but got Unknown
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Expected O, but got Unknown
		if (rightHandTimer != null)
		{
			rightHandTimer.Cancel();
		}
		if (leftHandTimer != null)
		{
			leftHandTimer.Cancel();
		}
		if (doorTimer != null)
		{
			doorTimer.Cancel();
		}
		if (doorOpenTween != null)
		{
			doorOpenTween.Kill();
		}
		doorOffset = 0f;
		if ((object)leftDoor != null)
		{
			Transform transform = leftDoor.transform;
			if ((object)leftDoor != null)
			{
				Transform transform2 = leftDoor.transform;
				if ((object)transform2 != null)
				{
					_ = 0;
					_ = 0;
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					object obj2 = default(object);
					object obj = obj2 - 96;
					Transform.get_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj);
					bool flag2 = (object)transform == null;
					_ = 0;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					object obj3 = obj2 - 80;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj3);
					bool flag4 = (object)rightDoor == null;
					Transform transform3 = rightDoor.transform;
					bool flag5 = (object)rightDoor == null;
					Transform transform4 = rightDoor.transform;
					bool flag6 = (object)transform4 == null;
					_ = 0;
					_ = 0;
					bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
					object obj4 = obj2 - 96;
					Transform.get_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj4);
					bool flag8 = (object)transform3 == null;
					_ = 0;
					bool flag9 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					object obj5 = obj2 - 64;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj5);
					bool flag10 = (object)leftHand == null;
					Transform transform5 = leftHand.transform;
					bool flag11 = (object)leftHand == null;
					Transform transform6 = leftHand.transform;
					bool flag12 = (object)transform6 == null;
					_ = 0;
					_ = 0;
					bool flag13 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
					object obj6 = obj2 - 96;
					Transform.get_localPosition_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out *(Vector3*)obj6);
					bool flag14 = (object)transform5 == null;
					_ = 0;
					bool flag15 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
					object obj7 = obj2 - 80;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)obj7);
					bool flag16 = (object)rightHand == null;
					Transform transform7 = rightHand.transform;
					bool flag17 = (object)rightHand == null;
					Transform transform8 = rightHand.transform;
					bool flag18 = (object)transform8 == null;
					_ = 0;
					_ = 0;
					bool flag19 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
					object obj8 = obj2 - 96;
					Transform.get_localPosition_Injected(((UnityEngine.Object)transform8).m_CachedPtr, out *(Vector3*)obj8);
					bool flag20 = (object)transform7 == null;
					_ = 0;
					bool flag21 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
					object obj9 = obj2 - 64;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref *(Vector3*)obj9);
					OpenDoors();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OpenDoors()
	{
		//IL_0027: Expected I, but got O
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)this != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"doorOffset", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value2 = default(object);
		bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"handOffset", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		tweenConfig.duration = 1000f;
		tweenConfig.delay = 500f;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		doorOpenTween = multiTargetTween;
	}

	protected unsafe void Update()
	{
		//IL_06fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0701: Expected O, but got Unknown
		//IL_073f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Expected O, but got Unknown
		//IL_07a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a9: Expected O, but got Unknown
		//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0800: Expected O, but got Unknown
		//IL_0860: Unknown result type (might be due to invalid IL or missing references)
		//IL_0865: Expected O, but got Unknown
		//IL_08b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bc: Expected O, but got Unknown
		//IL_091c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0921: Expected O, but got Unknown
		//IL_0973: Unknown result type (might be due to invalid IL or missing references)
		//IL_0978: Expected O, but got Unknown
		//IL_09d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dd: Expected O, but got Unknown
		//IL_0a2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a34: Expected O, but got Unknown
		//IL_0b24: Expected O, but got I
		//IL_0650: Expected O, but got I
		//IL_0669: Expected O, but got I4
		//IL_0672: Expected O, but got I4
		//IL_0aad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab2: Expected O, but got Unknown
		//IL_06a3->IL06a3: Incompatible stack heights: 32 vs 0
		object obj = default(object);
		object obj3 = default(object);
		object obj17 = default(object);
		while (true)
		{
			float time = PauseSystem.Time;
			float num = time * 8f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r14d,xmm0\"");
			Transform transform = body.transform;
			float num2 = (float)obj * (float)Math.PI;
			float num3 = num2 * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float num4 = num3 * 0.0625f;
			float num5 = num4 - 50f;
			_ = 0;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj2 = obj3 - 96;
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj2);
			Transform transform2 = head.transform;
			float num6 = (float)obj * (float)Math.PI;
			float num7 = num6 * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			bool flag2 = (object)transform2 == null;
			_ = 0;
			bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			object obj4 = obj3 - 80;
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj4);
			bool flag4 = (object)leftDoor == null;
			Transform transform3 = leftDoor.transform;
			bool flag5 = (object)leftDoor == null;
			Transform transform4 = leftDoor.transform;
			bool flag6 = (object)transform4 == null;
			_ = 0;
			_ = 0;
			bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
			object obj5 = obj3 - 96;
			Transform.get_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj5);
			bool flag8 = (object)transform3 == null;
			_ = 0;
			bool flag9 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			object obj6 = obj3 - 64;
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj6);
			bool flag10 = (object)rightDoor == null;
			Transform transform5 = rightDoor.transform;
			bool flag11 = (object)rightDoor == null;
			Transform transform6 = rightDoor.transform;
			bool flag12 = (object)transform6 == null;
			_ = 0;
			_ = 0;
			bool flag13 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
			object obj7 = obj3 - 96;
			Transform.get_localPosition_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out *(Vector3*)obj7);
			bool flag14 = (object)transform5 == null;
			_ = 0;
			bool flag15 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
			object obj8 = obj3 - 80;
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)obj8);
			bool flag16 = (object)leftHand == null;
			Transform transform7 = leftHand.transform;
			bool flag17 = (object)leftHand == null;
			Transform transform8 = leftHand.transform;
			bool flag18 = (object)transform8 == null;
			_ = 0;
			_ = 0;
			bool flag19 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
			object obj9 = obj3 - 96;
			Transform.get_localPosition_Injected(((UnityEngine.Object)transform8).m_CachedPtr, out *(Vector3*)obj9);
			bool flag20 = (object)transform7 == null;
			_ = 0;
			bool flag21 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
			object obj10 = obj3 - 64;
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref *(Vector3*)obj10);
			bool flag22 = (object)rightHand == null;
			Transform transform9 = rightHand.transform;
			bool flag23 = (object)rightHand == null;
			Transform transform10 = rightHand.transform;
			bool flag24 = (object)transform10 == null;
			_ = 0;
			_ = 0;
			bool flag25 = ((UnityEngine.Object)transform10).m_CachedPtr == (IntPtr)0;
			object obj11 = obj3 - 96;
			Transform.get_localPosition_Injected(((UnityEngine.Object)transform10).m_CachedPtr, out *(Vector3*)obj11);
			bool flag26 = (object)transform9 == null;
			_ = 0;
			bool flag27 = ((UnityEngine.Object)transform9).m_CachedPtr == (IntPtr)0;
			object obj12 = obj3 - 80;
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform9).m_CachedPtr, ref *(Vector3*)obj12);
			float time2 = PauseSystem.Time;
			float num8 = time2 * 8f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
			Sprite sprite = SpriteManager.GetSprite("BigFuzzHeadOpen", "firstBloodEnemies");
			bool flag28 = (object)head == null;
			head.sprite = sprite;
			bool flag29 = (object)head == null;
			Transform transform11 = head.transform;
			bool flag30 = (object)transform11 == null;
			_ = 1f;
			Transform transform12 = (Transform)(nint)((UnityEngine.Object)transform11).m_CachedPtr;
			bool flag31 = ((UnityEngine.Object)transform11).m_CachedPtr == (IntPtr)0;
			object obj13 = 0;
			bool flag32 = (nint)0 != 0;
			object obj14 = 0;
			object obj15 = 0;
			float num9 = 1f;
			object obj16 = obj17;
			if (flag32)
			{
				break;
			}
			bool flag33 = (nint)0 == 0;
		}
		object obj18 = obj3 - 64;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3058 @ rax_v151 (should have been resolved before IL gen)");
	}

	public UIBigFuzz()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
