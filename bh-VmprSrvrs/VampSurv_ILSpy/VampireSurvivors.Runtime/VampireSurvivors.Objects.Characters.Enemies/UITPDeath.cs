using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class UITPDeath : MonoBehaviour
{
	public Image deathMask;

	public List<Image> deathCape;

	public List<Image> glitch;

	public Image leftHand;

	public Image rightHand;

	public Image leftCracks;

	public Image rightCracks;

	public Image leftEye;

	public Image rightEye;

	public List<Image> leftJoints;

	public List<Image> rightJoints;

	private MultiTargetTween _armTween;

	[NonSerialized]
	public int glitchIndex;

	[NonSerialized]
	public float glitchYOffset;

	[NonSerialized]
	public float leftHandOffset;

	[NonSerialized]
	public float rightHandOffset;

	[NonSerialized]
	public bool leftHandScale;

	[NonSerialized]
	public bool rightHandScale;

	private float _crawlTimer;

	private void Awake()
	{
		//IL_001a: Expected O, but got I4
		bool flag = SpriteLoader.LoadTexture("TP_Death", "Gameplay", (DlcType?)(object)1);
	}

	private unsafe void Start()
	{
		//IL_07f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fa: Expected O, but got Unknown
		//IL_0698: Expected O, but got I
		//IL_06ec: Expected O, but got I
		//IL_083a: Unknown result type (might be due to invalid IL or missing references)
		//IL_083f: Expected O, but got Unknown
		//IL_071a: Expected I, but got O
		//IL_0723: Unknown result type (might be due to invalid IL or missing references)
		//IL_0728: Expected O, but got Unknown
		//IL_0741: Unknown result type (might be due to invalid IL or missing references)
		//IL_0746: Expected O, but got Unknown
		//IL_074e: Expected I, but got O
		//IL_0889: Unknown result type (might be due to invalid IL or missing references)
		//IL_088e: Expected O, but got Unknown
		//IL_0902: Unknown result type (might be due to invalid IL or missing references)
		//IL_0907: Expected O, but got Unknown
		//IL_094a: Expected O, but got I4
		//IL_0967: Expected I, but got O
		//IL_09b9: Expected O, but got F4
		//IL_0304: Expected O, but got I4
		//IL_01d4: Expected O, but got I
		//IL_0228: Expected O, but got I
		//IL_0365: Expected O, but got I
		//IL_0256: Expected I, but got O
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_028a: Expected I, but got O
		//IL_029a: Expected O, but got I
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_03b9: Expected O, but got I
		//IL_03e7: Expected I, but got O
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Expected O, but got Unknown
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Expected O, but got Unknown
		//IL_041b: Expected I, but got O
		//IL_042b: Expected O, but got I
		//IL_09cc: Expected I, but got O
		//IL_09f8: Expected O, but got I4
		//IL_0502: Expected O, but got I
		//IL_0a0f: Expected O, but got F4
		//IL_0556: Expected O, but got I
		//IL_0584: Expected I, but got O
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Expected O, but got Unknown
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Expected O, but got Unknown
		//IL_05b8: Expected I, but got O
		//IL_05c8: Expected O, but got I
		//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Expected O, but got Unknown
		//IL_0b01->IL0b01: Incompatible stack heights: 14 vs 5
		//IL_02f6->IL0158: Incompatible stack heights: 16 vs 10
		//IL_0a01->IL0b0b: Incompatible stack heights: 16 vs 5
		//IL_0a1c->IL0b0b: Incompatible stack heights: 16 vs 5
		//IL_0631->IL0486: Incompatible stack heights: 21 vs 16
		//IL_0637->IL0637: Incompatible stack heights: 21 vs 16
		bool flag = (object)leftCracks == null;
		leftCracks.enabled = false;
		bool flag2 = (object)rightCracks == null;
		rightCracks.enabled = false;
		if (_armTween != null)
		{
			_armTween.Kill();
		}
		leftHandOffset = -1f;
		rightHandOffset = 1f;
		bool flag3 = (object)leftHand == null;
		Transform transform = leftHand.transform;
		bool flag4 = (object)leftHand == null;
		Transform transform2 = leftHand.transform;
		bool flag5 = (object)transform2 == null;
		_ = 0;
		_ = 0;
		bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform obj = transform2;
		if (flag6)
		{
			goto IL_0b01;
		}
		object obj3 = default(object);
		object obj2 = obj3 - 96;
		Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj2);
		_ = 0;
		bool flag7 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		object obj4 = obj3 - 80;
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj4);
		Transform transform3 = rightHand.transform;
		Transform transform4 = rightHand.transform;
		_ = 0;
		_ = 0;
		bool flag8 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
		object obj5 = obj3 - 96;
		Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj5);
		float num = rightHandOffset * 0.75f;
		float num2 = num + 0.75f;
		bool flag9 = (object)transform3 == null;
		_ = 0;
		bool flag10 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		object obj6 = obj3 - 64;
		Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj6);
		List<Image> list = deathCape;
		bool flag11 = deathCape == null;
		object obj8 = default(object);
		object obj7 = obj8;
		Transform transform5 = null;
		object obj9 = 0;
		Transform transform6 = null;
		while (true)
		{
			object obj10 = deathCape;
			if ((nint)transform6 < list._size)
			{
				bool flag12 = deathCape == null;
				Transform obj11 = transform5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdi_v25 (System.Object)+18]");
				bool flag13 = (nint)obj11 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdi_v25 (System.Object)+10]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdi_v25 (System.Object)+10]");
				bool flag14 = (nint)0 == 0;
				Transform obj13 = transform5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rcx_v109+18]");
				bool flag15 = (nint)obj13 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rcx_v109+20+v173 @ rsi_v23 (UnityEngine.Transform)*8]");
				Transform transform7 = (Transform)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rcx_v109+20+v173 @ rsi_v23 (UnityEngine.Transform)*8]");
				bool flag16 = (nint)0 == 0;
				nint num3 = (nint)transform7;
				object obj14 = obj3 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1767 @ r8_v34 (Il2CppClass<UnityEngine.Transform>)+298] (should have been resolved before IL gen)");
				_ = 0;
				obj6 = obj3 - 96;
				nint num4 = (nint)transform7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1775 @ rax_v139 (Il2CppClass<UnityEngine.Transform>)+2B0]");
				obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1775 @ rax_v139 (Il2CppClass<UnityEngine.Transform>)+2A8] (should have been resolved before IL gen)");
				list = deathCape;
				transform5 = (Transform)(transform5 + 1);
				bool flag17 = deathCape == null;
				obj7 = obj8;
				transform6 = transform5;
				continue;
			}
			break;
		}
		nint num5 = (nint)typeof(PauseSystem);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1708 @ rax_v76 (Il2CppClass<PauseSystem>)+B8]");
		nint num6 = 0;
		if (PauseSystem._paused)
		{
			obj7 = 0;
		}
		else
		{
			object obj15 = Time.time;
		}
		bool flag18 = deathCape == null;
		float num7 = (float)obj7 * 4f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdi_v25 (System.Object)+18]");
		object obj16 = default(object);
		bool flag19 = (nint)obj16 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdi_v25 (System.Object)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdi_v25 (System.Object)+10]");
		bool flag20 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v68+18]");
		bool flag21 = (nint)obj16 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v68+20+v215 @ rax_v78*8]");
		Transform transform8 = (Transform)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v68+20+v215 @ rax_v78*8]");
		bool flag22 = (nint)0 == 0;
		nint num8 = (nint)transform8;
		object obj18 = obj3 - 48;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1817 @ r8_v23 (Il2CppClass<UnityEngine.Transform>)+298] (should have been resolved before IL gen)");
		_ = 1065353216;
		object obj19 = obj3 - 64;
		nint num9 = (nint)transform8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1825 @ rax_v83 (Il2CppClass<UnityEngine.Transform>)+2B0]");
		object obj20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1825 @ rax_v83 (Il2CppClass<UnityEngine.Transform>)+2A8] (should have been resolved before IL gen)");
		List<Image> list2 = glitch;
		bool flag23 = glitch == null;
		Transform transform9 = null;
		object obj21 = obj8;
		object obj22 = obj8;
		object obj23 = obj8;
		Transform transform10 = null;
		bool flag29;
		do
		{
			object obj24 = glitch;
			if ((nint)transform10 < list2._size)
			{
				bool flag24 = glitch == null;
				Transform obj25 = transform9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdi_v28 (System.Object)+18]");
				bool flag25 = (nint)obj25 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdi_v28 (System.Object)+10]");
				object obj26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdi_v28 (System.Object)+10]");
				bool flag26 = (nint)0 == 0;
				Transform obj27 = transform9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rcx_v101+18]");
				bool flag27 = (nint)obj27 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rcx_v101+20+v76 @ r14_v23 (UnityEngine.Transform)*8]");
				Transform transform11 = (Transform)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rcx_v101+20+v76 @ r14_v23 (UnityEngine.Transform)*8]");
				bool flag28 = (nint)0 == 0;
				nint num10 = (nint)transform11;
				object obj28 = obj3 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1948 @ r8_v31 (Il2CppClass<UnityEngine.Transform>)+298] (should have been resolved before IL gen)");
				_ = 0;
				obj19 = obj3 - 80;
				nint num11 = (nint)transform11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1956 @ rax_v125 (Il2CppClass<UnityEngine.Transform>)+2B0]");
				obj20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1956 @ rax_v125 (Il2CppClass<UnityEngine.Transform>)+2A8] (should have been resolved before IL gen)");
				list2 = glitch;
				transform9 = (Transform)(transform9 + 1);
				flag29 = glitch != null;
				obj21 = obj8;
				obj22 = obj8;
				obj23 = obj8;
				transform10 = transform9;
				continue;
			}
			break;
		}
		while (flag29);
		nint num12 = (nint)typeof(PauseSystem);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1888 @ rax_v88 (Il2CppClass<PauseSystem>)+B8]");
		nint num13 = 0;
		bool flag30 = PauseSystem._paused;
		object obj29 = 0;
		if (!flag30)
		{
			object obj30 = Time.time;
			obj29 = obj23;
		}
		goto IL_0b0b;
		IL_0b01:
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(obj);
		goto IL_0b0b;
		IL_0b0b:
		bool flag31 = glitch == null;
		float num14 = (float)obj29 * 29f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdi_v28 (System.Object)+18]");
		object obj31 = default(object);
		bool flag32 = (nint)obj31 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdi_v28 (System.Object)+10]");
		object obj32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdi_v28 (System.Object)+10]");
		bool flag33 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v77+18]");
		bool flag34 = (nint)obj31 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v77+20+v221 @ rax_v90*8]");
		Transform transform12 = (Transform)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v77+20+v221 @ rax_v90*8]");
		bool flag35 = (nint)0 == 0;
		nint num15 = (nint)transform12;
		object obj33 = obj3 - 48;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1993 @ r8_v27 (Il2CppClass<UnityEngine.Transform>)+298] (should have been resolved before IL gen)");
		_ = 1065353216;
		object obj34 = obj3 - 64;
		nint num16 = (nint)transform12;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2000 @ rax_v95 (Il2CppClass<UnityEngine.Transform>)+2A8] (should have been resolved before IL gen)");
		object obj35 = leftHand;
		bool flag36 = (object)leftHand == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdi_v30 (System.Object)+10]");
		bool flag37 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdi_v30 (System.Object)+10]");
		IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
		Transform component = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
		Transform transform13 = RenderingExtensions.SetScale(component, 0.5f);
		Transform transform14 = (Transform)(object)rightHand;
		bool flag38 = (object)rightHand == null;
		bool flag39 = ((UnityEngine.Object)transform14).m_CachedPtr == (IntPtr)0;
		IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)transform14).m_CachedPtr);
		Transform component2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
		Transform transform15 = RenderingExtensions.SetScale(component2, -0.5f, 0.5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1314 Invalid \"Jump target not found in method: 0x18778C160\"");
		Transform transform16 = default(Transform);
		obj = transform16;
		goto IL_0b01;
	}

	private void StartMovingArms()
	{
		//IL_0216: Invalid comparison between I4 and F4
		//IL_027a: Invalid comparison between I4 and F4
		//IL_0029: Expected O, but got I4
		//IL_005f: Expected I, but got O
		//IL_0052: Expected O, but got I4
		leftHandScale = false;
		if (0f > leftHandOffset)
		{
			leftCracks.enabled = true;
			rightHandScale = true;
			object obj = 0;
		}
		if (0f > rightHandOffset)
		{
			rightCracks.enabled = true;
			leftHandScale = true;
			object obj = 0;
		}
		glitchIndex = 0;
		glitchYOffset = -0.7f;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"leftHandOffset", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"rightHandOffset", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value3 = default(object);
			bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"glitchIndex", value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value4 = default(object);
			bool flag4 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"glitchYOffset", value4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 2000f;
			tweenConfig.delay = 500f;
			TweenCallback onStart = delegate
			{
				leftCracks.enabled = false;
				rightCracks.enabled = false;
			};
			tweenConfig.onStart = onStart;
			TweenCallback onComplete = StartMovingArms;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween armTween = Tweens.Add(tweenConfig);
			_armTween = armTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	protected unsafe void Update()
	{
		//IL_0008: Expected O, but got Ref
		//IL_093f: Expected O, but got Ref
		//IL_0998: Expected O, but got Ref
		//IL_09fd: Expected O, but got Ref
		//IL_0a76: Expected O, but got Ref
		//IL_0ae4: Expected I, but got O
		//IL_0b10: Expected O, but got I4
		//IL_0b27: Expected O, but got F4
		//IL_0315: Expected O, but got I
		//IL_01d9: Expected I, but got O
		//IL_01e7: Expected O, but got Ref
		//IL_0205: Expected O, but got Ref
		//IL_020d: Expected I, but got O
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		//IL_0347: Expected I, but got O
		//IL_0355: Expected O, but got Ref
		//IL_0373: Expected O, but got Ref
		//IL_037c: Expected I, but got O
		//IL_05e8: Expected O, but got I
		//IL_04a5: Expected I, but got O
		//IL_04b3: Expected O, but got Ref
		//IL_04d1: Expected O, but got Ref
		//IL_04da: Expected I, but got O
		//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Expected O, but got Unknown
		//IL_0649: Expected O, but got I
		//IL_06a0: Expected O, but got I
		//IL_0c5f: Expected O, but got Ref
		//IL_070b: Expected O, but got I
		//IL_0762: Expected O, but got I
		//IL_0d36: Expected O, but got Ref
		//IL_0d8d: Expected O, but got Ref
		//IL_0863: Expected I, but got O
		//IL_0871: Expected O, but got Ref
		//IL_088f: Expected O, but got Ref
		//IL_0897: Expected I, but got O
		//IL_0ad1->IL08e1: Incompatible stack heights: 10 vs 0
		//IL_0de8->IL08e1: Incompatible stack heights: 10 vs 0
		//IL_0173->IL08e1: Incompatible stack heights: 11 vs 0
		//IL_02dd->IL08e1: Incompatible stack heights: 11 vs 0
		//IL_01cc->IL08e1: Incompatible stack heights: 12 vs 0
		//IL_033a->IL08e1: Incompatible stack heights: 12 vs 0
		//IL_0253->IL0aad: Incompatible stack heights: 12 vs 10
		//IL_03b5->IL08e1: Incompatible stack heights: 12 vs 0
		//IL_0258->IL0258: Incompatible stack heights: 12 vs 10
		//IL_055d->IL08e1: Incompatible stack heights: 12 vs 0
		//IL_0b58->IL08e1: Incompatible stack heights: 12 vs 0
		//IL_05ae->IL08e1: Incompatible stack heights: 13 vs 0
		//IL_043f->IL08e1: Incompatible stack heights: 13 vs 0
		//IL_0608->IL08e1: Incompatible stack heights: 14 vs 0
		//IL_0498->IL08e1: Incompatible stack heights: 14 vs 0
		//IL_052a->IL0b34: Incompatible stack heights: 14 vs 12
		//IL_0bc8->IL08e1: Incompatible stack heights: 15 vs 0
		//IL_052f->IL052f: Incompatible stack heights: 14 vs 12
		//IL_0666->IL08e1: Incompatible stack heights: 16 vs 0
		//IL_06c0->IL08e1: Incompatible stack heights: 17 vs 0
		//IL_0c22->IL08e1: Incompatible stack heights: 18 vs 0
		//IL_0c9f->IL08e1: Incompatible stack heights: 19 vs 0
		//IL_0728->IL08e1: Incompatible stack heights: 20 vs 0
		//IL_0782->IL08e1: Incompatible stack heights: 21 vs 0
		//IL_0cf9->IL08e1: Incompatible stack heights: 22 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		object obj7;
		object obj8 = default(object);
		if ((object)leftHand != null)
		{
			Transform transform = leftHand.transform;
			if ((object)leftHand != null)
			{
				Transform transform2 = leftHand.transform;
				if ((object)transform2 != null)
				{
					_ = 0;
					_ = 0;
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj3);
					bool flag2 = (object)transform == null;
					_ = 0;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj4);
					bool flag4 = (object)rightHand == null;
					Transform transform3 = rightHand.transform;
					bool flag5 = (object)rightHand == null;
					Transform transform4 = rightHand.transform;
					bool flag6 = (object)transform4 == null;
					_ = 0;
					_ = 0;
					bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
					object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj5);
					float num = rightHandOffset * 0.75f;
					float num2 = num + 0.75f;
					bool flag8 = (object)transform3 == null;
					_ = 0;
					bool flag9 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
					Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj6);
					List<Image> list = deathCape;
					bool flag10 = deathCape == null;
					bool flag11 = list._size <= 0;
					obj7 = obj8;
					Transform transform5 = null;
					if (flag11)
					{
						goto IL_0258;
					}
					while (true)
					{
						List<Image> list2 = deathCape;
						if (deathCape == null)
						{
							break;
						}
						bool flag12 = (nint)transform5 >= list2._size;
						Image[] items = list2._items;
						if (list2._items == null)
						{
							break;
						}
						bool flag13 = (nint)transform5 >= items.Length;
						Transform transform6 = (Transform)(object)items[(object)transform5];
						if ((object)items[(object)transform5] == null)
						{
							break;
						}
						nint num3 = (nint)transform6;
						object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1860 @ r8_v31 (Il2CppClass<UnityEngine.Transform>)+298] (should have been resolved before IL gen)");
						_ = 0;
						obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
						nint num4 = (nint)transform6;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1867 @ rax_v100 (Il2CppClass<UnityEngine.Transform>)+2A8] (should have been resolved before IL gen)");
						transform5 = (Transform)(transform5 + 1);
						bool flag14 = (nint)transform5 < list._size;
						obj7 = obj8;
						if (flag14)
						{
							continue;
						}
						goto IL_0258;
					}
				}
			}
		}
		goto IL_08e1;
		IL_0258:
		Transform transform7 = (Transform)(object)deathCape;
		nint num5 = (nint)typeof(PauseSystem);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1521 @ rax_v105 (Il2CppClass<PauseSystem>)+B8]");
		nint num6 = 0;
		bool flag15 = PauseSystem._paused;
		object obj10 = 0;
		if (!flag15)
		{
			object obj11 = Time.time;
			obj10 = obj7;
		}
		if (deathCape != null)
		{
			float num7 = (float)obj10 * 4f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdi_v38 (UnityEngine.Transform)+18]");
			object obj12 = default(object);
			bool flag16 = (nint)obj12 >= 0;
			IntPtr cachedPtr = ((UnityEngine.Object)transform7).m_CachedPtr;
			if (((UnityEngine.Object)transform7).m_CachedPtr != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rcx_v90 (System.IntPtr)+18]");
				bool flag17 = (nint)obj12 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rcx_v90 (System.IntPtr)+20+v185 @ rax_v107*8]");
				Transform transform8 = (Transform)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rcx_v90 (System.IntPtr)+20+v185 @ rax_v107*8]");
				if ((nint)0 != 0)
				{
					nint num8 = (nint)transform8;
					object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1964 @ r8_v35 (Il2CppClass<UnityEngine.Transform>)+298] (should have been resolved before IL gen)");
					_ = 1065353216;
					object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
					nint num9 = (nint)transform8;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1971 @ rax_v112 (Il2CppClass<UnityEngine.Transform>)+2A8] (should have been resolved before IL gen)");
					List<Image> list3 = glitch;
					if (glitch != null)
					{
						bool flag18 = list3._size <= 0;
						object obj15 = obj8;
						object obj16 = obj8;
						Transform transform9 = null;
						if (flag18)
						{
							goto IL_052f;
						}
						while (true)
						{
							List<Image> list4 = glitch;
							if (glitch == null)
							{
								break;
							}
							bool flag19 = (nint)transform9 >= list4._size;
							Image[] items2 = list4._items;
							if (list4._items == null)
							{
								break;
							}
							bool flag20 = (nint)transform9 >= items2.Length;
							Transform transform10 = (Transform)(object)items2[(object)transform9];
							if ((object)items2[(object)transform9] == null)
							{
								break;
							}
							nint num10 = (nint)transform10;
							object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2293 @ r8_v39 (Il2CppClass<UnityEngine.Transform>)+298] (should have been resolved before IL gen)");
							_ = 0;
							obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
							nint num11 = (nint)transform10;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2300 @ rax_v121 (Il2CppClass<UnityEngine.Transform>)+2A8] (should have been resolved before IL gen)");
							transform9 = (Transform)(transform9 + 1);
							bool flag21 = (nint)transform9 < list3._size;
							obj15 = obj8;
							obj16 = obj8;
							if (flag21)
							{
								continue;
							}
							goto IL_052f;
						}
					}
				}
			}
		}
		goto IL_08e1;
		IL_052f:
		List<Image> list5 = glitch;
		int num12 = glitchIndex;
		if (glitch != null)
		{
			bool flag22 = glitchIndex >= list5._size;
			Transform items3 = (Transform)(object)list5._items;
			if (list5._items != null)
			{
				int num13 = glitchIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdi_v44 (UnityEngine.Transform)+18]");
				bool flag23 = (nint)num13 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdi_v44 (UnityEngine.Transform)+20+v207 @ rcx_v100 (System.Int32)*8]");
				Transform transform11 = (Transform)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdi_v44 (UnityEngine.Transform)+20+v207 @ rcx_v100 (System.Int32)*8]");
				if ((nint)0 != 0)
				{
					bool flag24 = ((UnityEngine.Object)transform11).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)transform11).m_CachedPtr);
					Transform transform12 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					Transform transform13 = (Transform)(object)glitch;
					int num14 = glitchIndex;
					if (glitch != null)
					{
						int num15 = glitchIndex;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdi_v46 (UnityEngine.Transform)+18]");
						bool flag25 = (nint)num15 >= (nint)0;
						Transform transform14 = (Transform)(nint)((UnityEngine.Object)transform13).m_CachedPtr;
						if (((UnityEngine.Object)transform13).m_CachedPtr != (IntPtr)0)
						{
							int num16 = glitchIndex;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdi_v47 (UnityEngine.Transform)+18]");
							bool flag26 = (nint)num16 >= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdi_v47 (UnityEngine.Transform)+20+v208 @ rcx_v105 (System.Int32)*8]");
							Transform transform15 = (Transform)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdi_v47 (UnityEngine.Transform)+20+v208 @ rcx_v105 (System.Int32)*8]");
							if ((nint)0 != 0)
							{
								bool flag27 = ((UnityEngine.Object)transform15).m_CachedPtr == (IntPtr)0;
								IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)transform15).m_CachedPtr);
								Transform transform16 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
								if ((object)transform16 != null)
								{
									_ = 0;
									_ = 0;
									bool flag28 = ((UnityEngine.Object)transform16).m_CachedPtr == (IntPtr)0;
									object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
									Transform.get_position_Injected(((UnityEngine.Object)transform16).m_CachedPtr, out *(Vector3*)obj18);
									Transform transform17 = (Transform)(object)glitch;
									int num17 = glitchIndex;
									if (glitch != null)
									{
										int num18 = glitchIndex;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdi_v50 (UnityEngine.Transform)+18]");
										bool flag29 = (nint)num18 >= (nint)0;
										Transform transform18 = (Transform)(nint)((UnityEngine.Object)transform17).m_CachedPtr;
										if (((UnityEngine.Object)transform17).m_CachedPtr != (IntPtr)0)
										{
											int num19 = glitchIndex;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdi_v51 (UnityEngine.Transform)+18]");
											bool flag30 = (nint)num19 >= (nint)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdi_v51 (UnityEngine.Transform)+20+v193 @ rax_v141 (System.Int32)*8]");
											Transform transform19 = (Transform)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdi_v51 (UnityEngine.Transform)+20+v193 @ rax_v141 (System.Int32)*8]");
											if ((nint)0 != 0)
											{
												bool flag31 = ((UnityEngine.Object)transform19).m_CachedPtr == (IntPtr)0;
												IntPtr gcHandlePtr3 = Component.get_transform_Injected(((UnityEngine.Object)transform19).m_CachedPtr);
												Transform transform20 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
												if ((object)transform20 != null)
												{
													_ = 0;
													_ = 0;
													bool flag32 = ((UnityEngine.Object)transform20).m_CachedPtr == (IntPtr)0;
													object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
													Transform.get_position_Injected(((UnityEngine.Object)transform20).m_CachedPtr, out *(Vector3*)obj19);
													bool flag33 = (object)transform12 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-1]");
													_ = 0;
													bool flag34 = ((UnityEngine.Object)transform12).m_CachedPtr == (IntPtr)0;
													object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
													Transform.set_position_Injected(((UnityEngine.Object)transform12).m_CachedPtr, ref *(Vector3*)obj20);
													List<Image> list6 = glitch;
													int num20 = glitchIndex;
													bool flag35 = glitch == null;
													bool flag36 = glitchIndex >= list6._size;
													Image[] items4 = list6._items;
													bool flag37 = list6._items == null;
													bool flag38 = glitchIndex >= items4.Length;
													Transform transform21 = (Transform)(object)items4[num20];
													bool flag39 = (object)items4[num20] == null;
													nint num21 = (nint)transform21;
													object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2744 @ r8_v43 (Il2CppClass<UnityEngine.Transform>)+298] (should have been resolved before IL gen)");
													_ = 1065353216;
													object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
													nint num22 = (nint)transform21;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2753 @ rax_v160 (Il2CppClass<UnityEngine.Transform>)+2A8] (should have been resolved before IL gen)");
													UpdateJoints(leftHand, leftJoints, leftHandScale);
													UpdateJoints(rightHand, rightJoints, rightHandScale);
													return;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_08e1;
		IL_08e1:
		throw new NullReferenceException();
	}

	private unsafe void UpdateJoints(Image arm, List<Image> armSprites, bool shouldScale)
	{
		//IL_0008: Expected O, but got Ref
		//IL_008a: Expected O, but got I4
		//IL_0564: Expected F4, but got I4
		//IL_03a3: Expected O, but got F4
		//IL_03a3: Expected O, but got F4
		//IL_0101: Expected O, but got F4
		//IL_0101: Expected O, but got F4
		//IL_011f: Expected F4, but got I
		//IL_011f: Expected O, but got F4
		//IL_011f: Expected O, but got F4
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00e1: Expected F4, but got O
		//IL_04f5: Expected O, but got Ref
		//IL_0503: Expected O, but got Ref
		//IL_054e: Expected I, but got O
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_026b: Expected F4, but got O
		//IL_0300->IL0282: Incompatible stack heights: 1 vs 0
		//IL_0068->IL0282: Incompatible stack heights: 1 vs 0
		//IL_037c->IL0282: Incompatible stack heights: 2 vs 0
		//IL_0177->IL0282: Incompatible stack heights: 3 vs 0
		//IL_01cb->IL0282: Incompatible stack heights: 4 vs 0
		//IL_027c->IL0553: Incompatible stack heights: 8 vs 2
		//IL_0281->IL0281: Incompatible stack heights: 8 vs 2
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)deathMask != null)
		{
			Transform transform = deathMask.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				float num = (float)ret - 0.049999997f;
				if ((object)arm != null)
				{
					Transform transform2 = arm.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret2);
						float num2 = (float)ret2 - 0.049999997f;
						object obj3 = default(object);
						float num3 = (float)obj3 + 0.39999998f;
						bool flag3 = (nint)armSprites < 0;
						if (armSprites != null)
						{
							object obj4 = armSprites._size - 1;
							_ = 1f;
							if (flag3)
							{
								return;
							}
							float num4 = num2;
							float num5 = 1f;
							float num10 = default(float);
							Vector3 euler = default(Vector3);
							while (true)
							{
								float num6 = num5;
								float num7 = 0f;
								Transform transform3 = null;
								bool flag4;
								do
								{
									num6 += -0.001f;
									float2 float5 = ArmSample((float2)num, (float2)num2, num6);
									float num8 = (float)float5 - num4;
									float num9 = num10 - num3;
									float num11 = num8 * num8;
									float num12 = num9 * num9;
									float num13 = num11 + num12;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
									num7 += num13;
									if (num7 > 0.2f)
									{
										break;
									}
									transform3 = (Transform)(transform3 + 1);
									flag4 = (nint)transform3 < 100;
									num3 = num10;
									num4 = (float)float5;
								}
								while (flag4);
								float2 float6 = ArmSample((float2)num, (float2)num2, num6);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
								float2 float7 = ArmSample((float2)num, (float2)num2, 0f);
								bool flag5 = (nint)obj4 >= armSprites._size;
								Image[] items = armSprites._items;
								if (armSprites._items == null)
								{
									break;
								}
								bool flag6 = (nint)obj4 >= items.Length;
								object obj5 = items[obj4];
								if ((object)items[obj4] == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v21 (System.Object)+10]");
								bool flag7 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v21 (System.Object)+10]");
								IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
								Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
								float num14 = 0f - (float)float6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+74]");
								float num15 = 0f - num10;
								double num16 = Math.Atan2(num15, num14);
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
								Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
								bool flag8 = (object)transform4 == null;
								_ = 0;
								bool flag9 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
								object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
								object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
								Transform.SetPositionAndRotation_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)obj7, ref *(Quaternion*)obj6);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v21 (System.Object)+10]");
								bool flag10 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v21 (System.Object)+10]");
								IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
								Transform component = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
								nint num17 = (nint)typeof(RenderingExtensions);
								Transform transform5 = RenderingExtensions.SetScale(component, 0.5f);
								obj4--;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1814 @ rcx_v65 (Il2CppClass<VampireSurvivors.App.Tools.RenderingExtensions>)+E4]");
								bool flag11 = (nint)0 >= (nint)0;
								num3 = num10;
								num4 = (float)float6;
								num5 = num6;
								if (!flag11)
								{
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private float FindNextJointT(float2 start, float2 end, float2 lastJointPos, float lastJointT, float desiredDistance, float iterationStep = -0.01f)
	{
		//IL_0046: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		float2 float5 = lastJointPos;
		object obj2 = default(object);
		object obj = obj2;
		object obj3 = 0;
		object obj4 = 0;
		float num2 = default(float);
		float num = num2;
		object obj5 = default(object);
		object obj11 = default(object);
		bool flag;
		do
		{
			num += (float)obj5;
			float2 float6 = ArmSample(start, end, num);
			object obj6 = float6 - float5;
			object obj7 = obj2 - obj;
			object obj8 = obj6 * obj6;
			object obj9 = obj7 * obj7;
			object obj10 = obj8 + obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
			obj3 += obj10;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11))
			{
				break;
			}
			obj4++;
			flag = (nint)obj4 < 100;
			float5 = float6;
			obj = obj2;
		}
		while (flag);
		return num;
	}

	private float2 ArmSample(float2 start, float2 end, float t)
	{
		float2 result = default(float2);
		return result;
	}

	private void OnDestroy()
	{
		if (_armTween != null)
		{
			_armTween.Kill();
		}
	}

	public UITPDeath()
	{
		List<Image> list = new List<Image>();
		leftJoints = list;
		List<Image> list2 = new List<Image>();
		rightJoints = list2;
	}

	private void _003CStartMovingArms_003Eb__21_0()
	{
		leftCracks.enabled = false;
		rightCracks.enabled = false;
	}
}
