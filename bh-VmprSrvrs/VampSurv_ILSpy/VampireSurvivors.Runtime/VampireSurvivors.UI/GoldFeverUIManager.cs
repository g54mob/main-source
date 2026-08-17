using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI;

public class GoldFeverUIManager : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__34_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CExitTween_003Eb__34_1()
		{
		}
	}

	private Image _FillBackground;

	private Image _Panel;

	private Image _ProgressFill;

	private Text _RewardText;

	private Text _TimeLeft;

	private ParticleEmitterManager _Emitter;

	private RectTransform _Title;

	private GoldFeverFlashingLights _Lights;

	private Vector3 _TitleStartPos;

	private Vector3 _TitleEndPos;

	private Sequence _exitSequence1;

	private Sequence _exitSequence2;

	private Vector3 _RewardOriginPos;

	private Vector3 _RewardScale;

	private bool _isActive;

	private SignalBus _signalBus;

	private GoldFeverController _goldFever;

	private ParticleSystem _particles;

	private bool _emitterBuilt;

	private bool _003CIsGoldFeverShowing_003Ek__BackingField;

	public bool IsGoldFeverShowing
	{
		get
		{
			return _003CIsGoldFeverShowing_003Ek__BackingField;
		}
		private set
		{
			_003CIsGoldFeverShowing_003Ek__BackingField = value;
		}
	}

	private void Construct(SignalBus signalBus, GoldFeverController fever)
	{
		_signalBus = signalBus;
		_goldFever = fever;
	}

	private void Start()
	{
		Transform transform = _RewardText.transform;
		Transform parent = transform.parent;
		RectTransform component = parent.GetComponent<RectTransform>();
		Vector2 anchoredPosition = component.anchoredPosition;
		Vector3 rewardOriginPos = default(Vector3);
		_RewardOriginPos = rewardOriginPos;
		_ = 0;
	}

	private void OnEnable()
	{
		//IL_0085: Expected O, but got I4
		//IL_0085: Expected O, but got I
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0196: Expected O, but got I
		//IL_0131: Expected O, but got I4
		//IL_0131: Expected O, but got I
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_01cf: Expected O, but got I
		Action<UISignals.GoldFeverCoinCollectedSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9EAD0");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.GoldFeverCoinCollectedSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.GoldFeverCoinCollectedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v12 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action<UISignals.EmitGoldFeverParticleSignal> action3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9EBB0");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.EmitGoldFeverParticleSignal>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.EmitGoldFeverParticleSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v27 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
	}

	private void OnDisable()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		Action<UISignals.GoldFeverCoinCollectedSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9EAD0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action<UISignals.EmitGoldFeverParticleSignal> token2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9EBB0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
	}

	private unsafe void Update()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0134: Expected O, but got I4
		//IL_0654: Expected O, but got Ref
		//IL_0671: Expected O, but got Ref
		//IL_0685: Expected native int or pointer, but got O
		//IL_0698: Expected O, but got Ref
		//IL_0126: Expected O, but got I8
		//IL_01bf: Expected O, but got Ref
		//IL_01e5: Expected O, but got Ref
		//IL_01f9: Expected native int or pointer, but got O
		//IL_020c: Expected O, but got Ref
		//IL_070a: Expected O, but got Ref
		//IL_076b: Invalid comparison between F4 and I
		//IL_03ac: Expected O, but got F4
		//IL_03ba: Expected O, but got F4
		//IL_03df: Invalid comparison between F4 and I4
		//IL_03ee: Invalid comparison between F4 and I4
		//IL_0798: Expected O, but got I4
		//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a5: Expected O, but got Unknown
		//IL_0326: Expected O, but got F4
		//IL_0333: Expected O, but got F4
		//IL_0358: Invalid comparison between F4 and I4
		//IL_0367: Invalid comparison between F4 and I4
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Expected O, but got Unknown
		//IL_07d8: Expected O, but got Ref
		//IL_0843: Expected O, but got Ref
		//IL_0882: Expected O, but got I
		//IL_08de: Expected O, but got Ref
		//IL_0953: Expected O, but got Ref
		//IL_099c: Expected O, but got I
		//IL_0a23: Expected O, but got Ref
		//IL_056f: Expected O, but got Ref
		//IL_0594: Expected O, but got Ref
		//IL_05a8: Expected native int or pointer, but got O
		//IL_05bb: Expected O, but got Ref
		//IL_0423->IL0423: Incompatible stack heights: 1 vs 2
		//IL_09b6->IL0620: Incompatible stack heights: 10 vs 0
		//IL_0528->IL0a5d: Incompatible stack heights: 13 vs 0
		//IL_0607->IL0620: Incompatible stack heights: 13 vs 0
		//IL_0620->IL0a5d: Incompatible stack heights: 13 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!_isActive)
		{
			return;
		}
		GoldFeverController goldFever = _goldFever;
		if (_goldFever != null && (object)_ProgressFill != null)
		{
			float num = goldFever._totalTime / goldFever._durationInMS;
			float fillAmount = 1f - num;
			_ProgressFill.fillAmount = fillAmount;
			GoldFeverController goldFever2 = _goldFever;
			if (_goldFever != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003E40");
				if (goldFever2._total < 2.1474836E+09f)
				{
					if (-2.1474836E+09f < goldFever2._total)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
					}
					else
					{
						object obj3 = 2147483648L;
					}
				}
				else
				{
					object obj3 = 2147483647;
				}
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				_ = 0;
				_ = 0;
				object arg = default(object);
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
				System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
				_ = 0;
				string text = string.FormatHelper((IFormatProvider)null, "${0}", args);
				if ((object)_RewardText != null)
				{
					_RewardText.text = text;
					GoldFeverController goldFever3 = _goldFever;
					if (_goldFever != null)
					{
						TimeSpan timeSpan = TimeSpan.Interval((double)goldFever3._totalDuration, 1000);
						object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
						object arg2 = (TimeSpan)obj5;
						System.ParamsArray paramsArray2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray2, new System.ParamsArray(arg2));
						System.ParamsArray args2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
						_ = 0;
						string text2 = string.FormatHelper((IFormatProvider)null, "{0:mm\\:ss\\:ff}", args2);
						if ((object)_TimeLeft != null)
						{
							_TimeLeft.text = text2;
							if ((object)_RewardText != null)
							{
								Transform transform = _RewardText.transform;
								if ((object)transform != null)
								{
									Transform parent = transform.parent;
									if ((object)parent != null)
									{
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v60 (UnityEngine.Transform)+10]");
										bool flag = (nint)0 == 0;
										object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v60 (UnityEngine.Transform)+10]");
										Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj6);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
										_ = 0;
										float deltaTime = PauseSystem.DeltaTime;
										float num2 = deltaTime * 1000f;
										float num3 = num2 * 0.001f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
										float num4;
										bool flag2;
										bool flag3;
										bool flag4;
										if (!(1f > 0f))
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
											num4 = 0f - num3;
											float num5 = num4 - 1f;
											object obj7 = num4 ^ 1f;
											object obj8 = num4 ^ num5;
											object obj9 = obj7 & obj8;
											flag2 = (nint)obj9 < 0;
											flag3 = num5 < 0f;
											flag4 = num5 == 0f;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
											num4 = 0f + num3;
											float num6 = 1f - num4;
											object obj10 = 1f ^ num4;
											object obj11 = 1f ^ num6;
											object obj12 = obj10 & obj11;
											flag2 = (nint)obj12 < 0;
											flag3 = num6 < 0f;
											flag4 = num6 == 0f;
										}
										bool flag5 = flag3 == flag2;
										object obj13 = !flag4;
										object obj14 = flag5 & obj13;
										if (obj14 == null)
										{
											object obj15 = num4 & -2147483649L;
											if ((nint)obj15 <= 2139095040)
											{
												goto IL_07ca;
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-41]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v60 (UnityEngine.Transform)+10]");
										bool flag6 = (nint)0 == 0;
										goto IL_07ca;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0620;
		IL_0620:
		throw new NullReferenceException();
		IL_07ca:
		object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v60 (UnityEngine.Transform)+10]");
		Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj16);
		bool flag7 = (object)_RewardText == null;
		Transform transform2 = _RewardText.transform;
		bool flag8 = (object)transform2 == null;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1316 @ rax_v73 (UnityEngine.Transform)+10]");
		bool flag9 = (nint)0 == 0;
		object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1316 @ rax_v73 (UnityEngine.Transform)+10]");
		Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj17);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj18 = num7 & 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-41]");
		_ = 0;
		bool flag10 = (object)_RewardText == null;
		Transform transform3 = _RewardText.transform;
		bool flag11 = (object)transform3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
		_ = 0;
		_ = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1120 @ rax_v80 (UnityEngine.Transform)+10]");
		bool flag12 = (nint)0 == 0;
		object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1120 @ rax_v80 (UnityEngine.Transform)+10]");
		Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj19);
		object title = _Title;
		bool flag13 = (object)_Title == null;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rbx_v23 (System.Object)+10]");
		bool flag14 = (nint)0 == 0;
		object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rbx_v23 (System.Object)+10]");
		Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj20);
		GoldFeverController goldFever4 = _goldFever;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj21 = num8 & 0;
		if (_goldFever != null)
		{
			float num9 = ((!goldFever4._isFake) ? 1f : (-1f));
			object title2 = _Title;
			float num10 = (float)obj21 * num9;
			bool flag15 = (object)_Title == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-41]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rbx_v24 (System.Object)+10]");
			bool flag16 = (nint)0 == 0;
			object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rbx_v24 (System.Object)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj22);
			GoldFeverController goldFever5 = _goldFever;
			bool flag17 = _goldFever == null;
			if (!goldFever5._isFake)
			{
				return;
			}
			float num11 = UnityEngine.Random.Range(-1f, 1f);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
			TimeSpan timeSpan2 = TimeSpan.FromSeconds(0.0);
			object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
			object arg3 = (TimeSpan)obj23;
			System.ParamsArray paramsArray3 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray3, new System.ParamsArray(arg3));
			System.ParamsArray args3 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
			_ = 0;
			string text3 = string.FormatHelper((IFormatProvider)null, "{0:mm\\:ss\\:ff}", args3);
			if ((object)_TimeLeft != null)
			{
				_TimeLeft.text = text3;
				return;
			}
		}
		goto IL_0620;
	}

	public void Hide()
	{
		Debug.Log("HIDING GOLD FEVER");
		if (_isActive)
		{
			ExitTween();
			_isActive = false;
		}
	}

	public void Show()
	{
		IntroTween();
		_isActive = true;
		_003CIsGoldFeverShowing_003Ek__BackingField = true;
	}

	private void FormatTitle(UISignals.GoldFeverCoinCollectedSignal sig)
	{
		//IL_02c9: Expected O, but got I4
		//IL_0467: Expected I, but got O
		//IL_049e: Expected I, but got O
		//IL_02bb: Expected O, but got I8
		//IL_03e1: Expected I, but got O
		//IL_039a: Expected I, but got O
		//IL_0353: Expected I, but got O
		//IL_030c: Expected I, but got O
		GoldFeverController goldFever = _goldFever;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003E40");
		if (!(goldFever._total < 2.1474836E+09f))
		{
			goto IL_023c;
		}
		if (-2.1474836E+09f < goldFever._total)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			object obj = default(object);
			if ((nint)obj > 20000)
			{
				goto IL_023c;
			}
		}
		GoldFeverController goldFever2 = _goldFever;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003E40");
		Vector3 rewardScale = default(Vector3);
		float num3;
		if (goldFever2._total < 2.1474836E+09f)
		{
			if (-2.1474836E+09f < goldFever2._total)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				object obj2 = default(object);
				if ((nint)obj2 > 10000)
				{
					goto IL_03d3;
				}
			}
			GoldFeverController goldFever3 = _goldFever;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003E40");
			if (goldFever3._total < 2.1474836E+09f)
			{
				if (-2.1474836E+09f < goldFever3._total)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
					object obj3 = default(object);
					if ((nint)obj3 > 1000)
					{
						goto IL_038c;
					}
				}
				GoldFeverController goldFever4 = _goldFever;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003E40");
				if (goldFever4._total < 2.1474836E+09f)
				{
					if (-2.1474836E+09f < goldFever4._total)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
						object obj4 = default(object);
						if ((nint)obj4 > 100)
						{
							goto IL_0345;
						}
					}
					nint num = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rax_v49 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ rcx_v32 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
					num3 = 0f * 1.25f;
					_RewardScale = rewardScale;
					goto IL_02ce;
				}
				goto IL_0345;
			}
			goto IL_038c;
		}
		goto IL_03d3;
		IL_02ce:
		Transform transform = _RewardText.transform;
		Transform parent = transform.parent;
		bool flag = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)parent).m_CachedPtr, ref value);
		return;
		IL_03d3:
		nint num4 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rax_v36 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rcx_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		num3 = 0f * 2f;
		_RewardScale = rewardScale;
		goto IL_02ce;
		IL_023c:
		GoldFeverController goldFever5 = _goldFever;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003E40");
		object obj5 = default(object);
		if (goldFever5._total < 2.1474836E+09f)
		{
			if (-2.1474836E+09f < goldFever5._total)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			}
			else
			{
				obj5 = 2147483648L;
			}
		}
		else
		{
			obj5 = 2147483647;
		}
		float num6 = (float)obj5 / 10000f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		float num7 = num6 * 0.15f;
		float num8 = num7 + 1f;
		nint num9 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ rdx_v10 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rax_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num11 = 0f * 1.15f;
		nint num12 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ rdx_v11 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rax_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num14 = 0f * num8;
		num3 = num14 + num11;
		_RewardScale = rewardScale;
		goto IL_02ce;
		IL_0345:
		nint num15 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ rax_v46 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rcx_v29 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		num3 = 0f * 1.35f;
		_RewardScale = rewardScale;
		goto IL_02ce;
		IL_038c:
		nint num17 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v41 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rcx_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		num3 = 0f * 1.5f;
		_RewardScale = rewardScale;
		goto IL_02ce;
	}

	private void DoParticles(UISignals.EmitGoldFeverParticleSignal sig)
	{
		if (!_emitterBuilt)
		{
			BuildEmitter();
		}
		object particles = _particles;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdi_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdi_v2 (System.Object)+10]");
		ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
		ParticleSystem.Emit_Injected((IntPtr)0, ref emitParams, 10);
	}

	private unsafe void BuildEmitter()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0047: Expected O, but got I
		//IL_0063: Expected O, but got I4
		//IL_0134: Expected O, but got Ref
		//IL_0143: Expected O, but got I4
		//IL_0151: Expected native int or pointer, but got O
		//IL_0363: Expected O, but got I4
		//IL_0169: Expected O, but got Ref
		//IL_0183: Expected native int or pointer, but got O
		//IL_019d: Expected O, but got I
		//IL_01bd: Expected O, but got Ref
		//IL_01d7: Expected native int or pointer, but got O
		//IL_0380: Expected O, but got I4
		//IL_0209: Expected O, but got Ref
		//IL_0223: Expected native int or pointer, but got O
		//IL_03ba: Expected O, but got I
		//IL_0269: Expected O, but got I4
		//IL_03f4: Expected O, but got I
		//IL_02c2: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!_emitterBuilt)
		{
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("items");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
			particleSystemConfig._quantity = (int?)(object)0;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(2000f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"CoinGold.png");
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
			_ = 0;
			obj = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(225f, 315f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+20]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(225f, 275f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+60]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(800f);
			particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0.2f);
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
			particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
			_ = 0;
			particleSystemConfig._on = true;
			_ = 257;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
			particleSystemConfig._collideBottom = (bool?)(object)0;
			Transform parent = base.transform;
			ParticleSystem particles = _Emitter.CreateEmitter(particleSystemConfig, parent);
			_particles = particles;
			Transform transform = _particles.transform;
			Transform parent2 = base.transform;
			transform.parent = parent2;
			_emitterBuilt = true;
		}
	}

	private unsafe void IntroTween()
	{
		if ((object)_Lights != null)
		{
			_Lights.Show();
			if (_exitSequence1 != null)
			{
				TweenExtensions.Kill(_exitSequence1);
			}
			if (_exitSequence2 != null)
			{
				TweenExtensions.Kill(_exitSequence2);
			}
			if ((object)_RewardText != null)
			{
				Transform transform = _RewardText.transform;
				if ((object)transform != null)
				{
					Transform parent = transform.parent;
					if ((object)parent != null)
					{
						RectTransform component = parent.GetComponent<RectTransform>();
						if ((object)component != null)
						{
							Vector2 vector = default(Vector2);
							component.anchoredPosition = vector;
							TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_RewardText, 1f, 0.01f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore != null)
							{
								TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_TimeLeft, 1f, 0.01f);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if (tweenerCore2 != null)
								{
									GameObject gameObject = base.gameObject;
									if ((object)gameObject != null)
									{
										gameObject.SetActive(value: true);
										if ((object)_Title != null)
										{
											_Title.anchoredPosition = vector;
											TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore3 = DOTweenModuleUI.DOAnchorPos(_Title, vector, 0.4f);
											if (tweenerCore3 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1111 @ rax_v34 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
												if ((nint)0 != 0)
												{
													_ = 4;
													_ = 0;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											Transform transform2 = _Title.transform;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rax_v39 (UnityEngine.Transform)+10]");
											bool flag = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rax_v39 (UnityEngine.Transform)+10]");
											Vector2 value = default(Vector2);
											Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value));
											Transform target = _Title.transform;
											TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScale(target, 1f, 0.4f);
											if (tweenerCore4 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1309 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
												if ((nint)0 != 0)
												{
													_ = 4;
													_ = 0;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											Text component2 = _Title.GetComponent<Text>();
											TweenerCore<Color, Color, ColorOptions> tweenerCore5 = DOTweenModuleUI.DOFade(component2, 1f, 0.2f);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											Transform transform3 = _RewardText.transform;
											Transform parent2 = transform3.parent;
											bool flag2 = ((UnityEngine.Object)parent2).m_CachedPtr == (IntPtr)0;
											Vector2 value2 = default(Vector2);
											Transform.set_localScale_Injected(((UnityEngine.Object)parent2).m_CachedPtr, ref *(Vector3*)(&value2));
											Transform transform4 = _RewardText.transform;
											Transform parent3 = transform4.parent;
											TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore6 = ShortcutExtensions.DOScaleY(parent3, 1f, 0.4f);
											if (tweenerCore6 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1587 @ rax_v62 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
												if ((nint)0 != 0)
												{
													_ = 4;
													_ = 0;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											TweenerCore<Color, Color, ColorOptions> tweenerCore7 = DOTweenModuleUI.DOFade(_RewardText, 1f, 0.4f);
											if (tweenerCore7 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1728 @ rax_v67 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
												if ((nint)0 != 0)
												{
													_ = 4;
													_ = 0;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											TweenerCore<Color, Color, ColorOptions> tweenerCore8 = DOTweenModuleUI.DOFade(_ProgressFill, 1f, 0.4f);
											if (tweenerCore8 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1890 @ rax_v72 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
												if ((nint)0 != 0)
												{
													_ = 4;
													_ = 0;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											TweenerCore<Color, Color, ColorOptions> tweenerCore9 = DOTweenModuleUI.DOFade(_FillBackground, 1f, 0.4f);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											TweenerCore<Color, Color, ColorOptions> tweenerCore10 = DOTweenModuleUI.DOFade(_Panel, 1f, 0.4f);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
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
		throw new NullReferenceException();
	}

	private unsafe void ExitTween()
	{
		//IL_0ac5: Expected O, but got Ref
		//IL_0719->IL0966: Incompatible stack heights: 2 vs 0
		//IL_07d1->IL0966: Incompatible stack heights: 2 vs 0
		if ((object)_Lights != null)
		{
			_Lights.Exit();
			Sequence sequence = DOTween.Sequence();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (sequence != null)
			{
				sequence.stringId = "DefaultGameTweenId";
				_exitSequence1 = sequence;
				Sequence sequence2 = DOTween.Sequence();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (sequence2 != null)
				{
					sequence2.stringId = "DefaultGameTweenId";
					_exitSequence2 = sequence2;
					Sequence exitSequence = _exitSequence2;
					if ((object)_Title != null)
					{
						Text component = _Title.GetComponent<Text>();
						TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(component, 0f, 0.5f);
						if (TweenSettingsExtensions.ValidateAddToSequence(_exitSequence2, (Tween)t, false))
						{
							if (_exitSequence2 == null)
							{
								goto IL_0966;
							}
							Sequence sequence3 = Sequence.DoInsert(_exitSequence2, (Tween)t, exitSequence.lastTweenInsertTime);
						}
						Sequence exitSequence2 = _exitSequence2;
						TweenerCore<Color, Color, ColorOptions> t2 = DOTweenModuleUI.DOFade(_RewardText, 0f, 0.5f);
						if (TweenSettingsExtensions.ValidateAddToSequence(_exitSequence2, (Tween)t2, false))
						{
							if (_exitSequence2 == null)
							{
								goto IL_0966;
							}
							Sequence sequence4 = Sequence.DoInsert(_exitSequence2, (Tween)t2, exitSequence2.lastTweenInsertTime);
						}
						Sequence exitSequence3 = _exitSequence2;
						TweenerCore<Color, Color, ColorOptions> t3 = DOTweenModuleUI.DOFade(_TimeLeft, 0f, 0.5f);
						if (TweenSettingsExtensions.ValidateAddToSequence(_exitSequence2, (Tween)t3, false))
						{
							if (_exitSequence2 == null)
							{
								goto IL_0966;
							}
							Sequence sequence5 = Sequence.DoInsert(_exitSequence2, (Tween)t3, exitSequence3.lastTweenInsertTime);
						}
						Sequence sequence6 = TweenSettingsExtensions.AppendInterval(_exitSequence2, 0.5f);
						Sequence exitSequence4 = _exitSequence2;
						TweenCallback tweenCallback = delegate
						{
							GameObject gameObject = base.gameObject;
							gameObject.SetActive(value: false);
							_003CIsGoldFeverShowing_003Ek__BackingField = false;
						};
						object message;
						if (_exitSequence2 != null)
						{
							if (((Tween)exitSequence4)._003Cactive_003Ek__BackingField)
							{
								if (!((Tween)exitSequence4).creationLocked)
								{
									if (tweenCallback != null)
									{
										Sequence sequence7 = Sequence.DoInsertCallback(_exitSequence2, tweenCallback, ((Tween)exitSequence4).duration);
									}
									goto IL_0418;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								message = "You can't add elements to an inactive/killed Sequence";
							}
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							message = "You can't add elements to a NULL Sequence";
						}
						Debugger.LogWarning(message);
						goto IL_0418;
					}
				}
			}
		}
		goto IL_0966;
		IL_0418:
		Sequence sequence8 = TweenExtensions.Pause(_exitSequence2);
		if ((object)_RewardText != null)
		{
			Transform transform = _RewardText.transform;
			if ((object)transform != null)
			{
				Transform parent = transform.parent;
				if ((object)parent != null)
				{
					RectTransform component2 = parent.GetComponent<RectTransform>();
					Sequence exitSequence5 = _exitSequence1;
					TweenerCore<Color, Color, ColorOptions> t4 = DOTweenModuleUI.DOFade(_Panel, 0f, 0.2f);
					if (TweenSettingsExtensions.ValidateAddToSequence(_exitSequence1, (Tween)t4, false))
					{
						if (_exitSequence1 == null)
						{
							goto IL_0966;
						}
						Sequence sequence9 = Sequence.DoInsert(_exitSequence1, (Tween)t4, exitSequence5.lastTweenInsertTime);
					}
					Sequence exitSequence6 = _exitSequence1;
					TweenerCore<Color, Color, ColorOptions> t5 = DOTweenModuleUI.DOFade(_FillBackground, 0f, 0.2f);
					if (TweenSettingsExtensions.ValidateAddToSequence(_exitSequence1, (Tween)t5, false))
					{
						if (_exitSequence1 == null)
						{
							goto IL_0966;
						}
						Sequence sequence10 = Sequence.DoInsert(_exitSequence1, (Tween)t5, exitSequence6.lastTweenInsertTime);
					}
					Sequence exitSequence7 = _exitSequence1;
					TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_ProgressFill, 0f, 0.2f);
					TweenCallback tweenCallback2 = _003C_003Ec._003C_003E9__34_1;
					if (_003C_003Ec._003C_003E9__34_1 == null)
					{
						tweenCallback2 = (_003C_003Ec._003C_003E9__34_1 = delegate
						{
						});
					}
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1316 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
						if ((nint)0 == 0)
						{
						}
					}
					if (TweenSettingsExtensions.ValidateAddToSequence(_exitSequence1, (Tween)tweenerCore, false))
					{
						if (_exitSequence1 == null)
						{
							goto IL_0966;
						}
						Sequence sequence11 = Sequence.DoInsert(_exitSequence1, (Tween)tweenerCore, exitSequence7.lastTweenInsertTime);
					}
					Sequence exitSequence8 = _exitSequence1;
					if ((object)component2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1247 @ rax_v45 (UnityEngine.RectTransform)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1247 @ rax_v45 (UnityEngine.RectTransform)+10]");
						Transform.get_localScale_Injected((IntPtr)0, out Vector3 _);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1247 @ rax_v45 (UnityEngine.RectTransform)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1247 @ rax_v45 (UnityEngine.RectTransform)+10]");
						Transform.get_localScale_Injected((IntPtr)0, out Vector3 ret2);
						TweenerCore<Vector3, Vector3, VectorOptions> t6 = ShortcutExtensions.DOScale(component2, (Vector3)(&ret2), 0.5f);
						if (TweenSettingsExtensions.ValidateAddToSequence(_exitSequence1, (Tween)t6, false))
						{
							if (_exitSequence1 == null)
							{
								goto IL_0966;
							}
							Sequence sequence12 = Sequence.DoInsert(_exitSequence1, (Tween)t6, exitSequence8.lastTweenInsertTime);
						}
						Sequence exitSequence9 = _exitSequence1;
						Vector2 anchoredPosition = component2.anchoredPosition;
						object obj = default(object);
						float endValue = (float)obj + 96f;
						TweenerCore<Vector2, Vector2, VectorOptions> t7 = DOTweenModuleUI.DOAnchorPosY(component2, endValue, 0.5f);
						if (TweenSettingsExtensions.ValidateAddToSequence(_exitSequence1, (Tween)t7, false))
						{
							if (_exitSequence1 == null)
							{
								goto IL_0966;
							}
							Sequence sequence13 = Sequence.DoInsert(_exitSequence1, (Tween)t7, exitSequence9.lastTweenInsertTime);
						}
						Sequence sequence14 = TweenSettingsExtensions.AppendInterval(_exitSequence1, 1.5f);
						Sequence exitSequence10 = _exitSequence1;
						TweenCallback tweenCallback3 = delegate
						{
							Sequence sequence16 = TweenExtensions.Play(_exitSequence2);
						};
						Tween t8;
						object message2;
						if (_exitSequence1 != null)
						{
							if (((Tween)exitSequence10)._003Cactive_003Ek__BackingField)
							{
								if (!((Tween)exitSequence10).creationLocked)
								{
									if (tweenCallback3 != null)
									{
										Sequence sequence15 = Sequence.DoInsertCallback(_exitSequence1, tweenCallback3, ((Tween)exitSequence10).duration);
									}
									return;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								t8 = null;
								message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								t8 = null;
								message2 = "You can't add elements to an inactive/killed Sequence";
							}
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							t8 = null;
							message2 = "You can't add elements to a NULL Sequence";
						}
						Debugger.LogWarning(message2, t8);
						return;
					}
				}
			}
		}
		goto IL_0966;
		IL_0966:
		throw new NullReferenceException();
	}

	private float Approach(float start, float end, float shift)
	{
		//IL_00b1: Expected O, but got F4
		//IL_00be: Expected O, but got F4
		//IL_00e3: Invalid comparison between F4 and I4
		//IL_00f2: Invalid comparison between F4 and I4
		//IL_0179: Expected O, but got I4
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0035: Expected O, but got F4
		//IL_0042: Expected O, but got F4
		//IL_0067: Invalid comparison between F4 and I4
		//IL_0076: Invalid comparison between F4 and I4
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		float num;
		bool flag;
		bool flag2;
		bool flag3;
		if (!(end > start))
		{
			num = start - shift;
			float num2 = num - end;
			object obj = num ^ end;
			object obj2 = num ^ num2;
			object obj3 = obj & obj2;
			flag = (nint)obj3 < 0;
			flag2 = num2 < 0f;
			flag3 = num2 == 0f;
		}
		else
		{
			num = start + shift;
			float num3 = end - num;
			object obj4 = end ^ num;
			object obj5 = end ^ num3;
			object obj6 = obj4 & obj5;
			flag = (nint)obj6 < 0;
			flag2 = num3 < 0f;
			flag3 = num3 == 0f;
		}
		bool flag4 = flag2 == flag;
		object obj7 = !flag3;
		object obj8 = flag4 & obj7;
		float result;
		if (obj8 == null)
		{
			object obj9 = num & -2147483649L;
			bool flag5 = (nint)obj9 <= 2139095040;
			result = end;
			if (flag5)
			{
				goto IL_0194;
			}
		}
		result = num;
		goto IL_0194;
		IL_0194:
		return result;
	}

	public GoldFeverUIManager()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CExitTween_003Eb__34_0()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
		_003CIsGoldFeverShowing_003Ek__BackingField = false;
	}

	private void _003CExitTween_003Eb__34_2()
	{
		Sequence sequence = TweenExtensions.Play(_exitSequence2);
	}
}
