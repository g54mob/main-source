using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Signals;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class PianoPage : BaseUIPage
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Equipment, bool> _003C_003E9__31_0;

		public static Func<Equipment, bool> _003C_003E9__31_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003COnShowStart_003Eb__31_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 27;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003COnShowStart_003Eb__31_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 28;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003CWaitForNextHint_003Ed__35(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float wait;

		public PianoPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0079: Expected I4, but got I8
			//IL_00bc: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = null;
				waitForSeconds.m_Seconds = wait;
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.FlyInNext();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private bool _DEBUG;

	private Image _Fader;

	private Image _Piano;

	private Image _PianoOverlay;

	private RectTransform _PeachoneHelper;

	private RectTransform _EbonyHelper;

	private RectTransform _BirdBox;

	private GameObject _BackButton;

	private List<RectTransform> _CorrectKeys;

	private PlayerOptions _playerOptions;

	private SignalBus _signalBus;

	private bool _hasPeachone;

	private bool _hasEbony;

	private int[] _keysToPush;

	private List<int> _keysPushed;

	private int _hintCounter;

	private float _birdSpeed;

	private Tween _peachoneXTween;

	private Tween _peachoneYTween;

	private Tween _peachoneAlphaTween;

	private Tween _ebonyXTween;

	private Tween _ebonyYTween;

	private Tween _ebonyAlphaTween;

	private void Construct(SignalBus signal, PlayerOptions player)
	{
		//IL_009b: Expected O, but got I4
		//IL_009b: Expected O, but got I
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_02f5: Expected O, but got I
		//IL_0147: Expected O, but got I4
		//IL_0147: Expected O, but got I
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0330: Expected O, but got I
		//IL_018e: Expected O, but got I
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_0203: Expected O, but got I
		//IL_035b: Expected O, but got I4
		//IL_01ee: Expected O, but got I8
		//IL_0295: Expected O, but got I4
		//IL_0295: Expected O, but got I
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_0394: Expected O, but got I
		_signalBus = signal;
		_playerOptions = player;
		Action action = OnSuccessfulPianoRemotely;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.SuccessfulPianoSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.SuccessfulPianoSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v15 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action action3 = OnExitPianoRemotely;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.ExitPianoSignal>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.ExitPianoSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v30 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		Action<OnlineSignals.TouchedPianoKeySignal> action5 = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r9_v8 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r9_v8 (Il2CppMethodInfo)+4C]");
		object obj7 = (nint)0 >> 4;
		object obj8 = obj7 & 1;
		object obj9;
		if (obj8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r9_v8 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 1)
			{
				obj9 = 6442485696L;
				goto IL_0352;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v37 (System.Action`1<VampireSurvivors.Signals.OnlineSignals+TouchedPianoKeySignal>)+10]");
		obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v37 (System.Action`1<VampireSurvivors.Signals.OnlineSignals+TouchedPianoKeySignal>)+20]");
		_ = 0;
		goto IL_0352;
		IL_0352:
		object obj10 = 24;
		_ = 6447743808L;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdi_v6 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj11 = null;
		Action<object> action6 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.TouchedPianoKeySignal>)obj11)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.TouchedPianoKeySignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj13 = default(object);
		object obj12 = obj13 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v50 (System.Object)+10]");
		Type signalType3 = default(Type);
		signalBus3.SubscribeInternal(signalType3, (object)null, (object)0, callback);
	}

	private void OnTouchedKeyRemotely(OnlineSignals.TouchedPianoKeySignal signal)
	{
		//IL_0009: Expected I4, but got O
		PlaySoundForKey((int)signal);
	}

	private void OnExitPianoRemotely()
	{
		Exit();
	}

	private void OnSuccessfulPianoRemotely()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AADA40");
		DoTheBigSpoop();
	}

	public void PlayKey(int i)
	{
		//IL_00a6: Expected O, but got I
		//IL_017f: Expected I4, but got O
		//IL_0197: Expected I4, but got O
		//IL_006f: Expected O, but got I
		if (IsLocalPlayerControllingUi())
		{
			PlaySoundForKey(i);
			GameManager core = GM.Core;
			if (core._multiplayer.IsOnlineMultiplayer)
			{
				int num = (int)OnlineStageManager._instance;
				Action<int> action = null;
				((OnlineStageManager)(object)action).TouchedPianoKey((int)OnlineStageManager._instance);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rsi_v6 (System.Int32)+78]");
				bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.Other, i);
			}
			List<int> keysPushed = _keysPushed;
			int[] keysToPush = _keysToPush;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v12 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj = 0;
			if (keysToPush[obj] != i)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v12 (System.Collections.Generic.List`1<System.Int32>)+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
			}
			else
			{
				keysPushed.Add(i);
			}
			List<int> keysPushed2 = _keysPushed;
			int[] keysToPush2 = _keysToPush;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)0 == keysToPush2.Length)
			{
				ExitSuccessfully();
			}
		}
	}

	private static void PlaySoundForKey(int i)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 39 Invalid \"Jump target not found in method: 0x18735542C\"");
	}

	public void Back()
	{
		//IL_0098: Expected I8, but got O
		//IL_00b0: Expected I8, but got O
		//IL_0066: Expected O, but got I
		if (IsLocalPlayerControllingUi())
		{
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				Exit();
				return;
			}
			long num = (long)OnlineStageManager._instance;
			Action<long> action = null;
			((OnlineStageManager)(object)action).ExitPiano((long)OnlineStageManager._instance);
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rbx_v4 (System.Int64)+78]");
			bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
		}
	}

	protected void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		Action token = OnSuccessfulPianoRemotely;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action token2 = OnExitPianoRemotely;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
	}

	protected override void OnShowStart(GameObject g)
	{
		//IL_0345->IL0206: Incompatible stack heights: 6 vs 0
		//IL_0143->IL0206: Incompatible stack heights: 6 vs 0
		//IL_0172->IL0206: Incompatible stack heights: 6 vs 0
		//IL_03c3->IL0206: Incompatible stack heights: 6 vs 0
		//IL_01de->IL0206: Incompatible stack heights: 6 vs 0
		base.OnShowStart(g);
		if ((object)GM.Core != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController interactingPlayer = GM.Core.InteractingPlayer;
			EnterMultiplayerControl(interactingPlayer);
			if ((object)_PianoOverlay != null)
			{
				Transform transform = _PianoOverlay.transform;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Transform transform2 = _Piano.transform;
				bool flag2 = (object)transform2 == null;
				bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Vector3 value2 = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
				TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_Fader, 0.65f, 0.5f);
				TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_PianoOverlay, 1f, 0.5f);
				bool flag4 = (object)GM.Core == null;
				VampireSurvivors.Objects.Characters.CharacterController interactingPlayer2 = GM.Core.InteractingPlayer;
				bool flag5 = (object)interactingPlayer2 == null;
				CharacterWeaponsManager weaponsManager = interactingPlayer2._weaponsManager;
				bool flag6 = (object)interactingPlayer2._weaponsManager == null;
				Func<Equipment, bool> predicate = _003C_003Ec._003C_003E9__31_0;
				if (_003C_003Ec._003C_003E9__31_0 == null)
				{
					predicate = (_003C_003Ec._003C_003E9__31_0 = delegate(Equipment x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj = x._equipmentType - 27;
						return obj == null;
					});
				}
				if (Enumerable.Any(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, predicate))
				{
					_hasPeachone = true;
				}
				if ((object)GM.Core != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController interactingPlayer3 = GM.Core.InteractingPlayer;
					if ((object)interactingPlayer3 != null)
					{
						CharacterWeaponsManager weaponsManager2 = interactingPlayer3._weaponsManager;
						if ((object)interactingPlayer3._weaponsManager != null)
						{
							Func<Equipment, bool> predicate2 = _003C_003Ec._003C_003E9__31_1;
							if (_003C_003Ec._003C_003E9__31_1 == null)
							{
								predicate2 = (_003C_003Ec._003C_003E9__31_1 = delegate(Equipment x)
								{
									//IL_0052: Expected I4, but got O
									//IL_0030: Expected O, but got I4
									if ((object)x == null)
									{
										NullReferenceException ex = new NullReferenceException();
										return (byte)(int)ex != 0;
									}
									object obj = x._equipmentType - 28;
									return obj == null;
								});
							}
							if (Enumerable.Any(((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField, predicate2))
							{
								_hasEbony = true;
							}
							bool active = IsLocalPlayerControllingUi();
							if ((object)_BackButton != null)
							{
								_BackButton.SetActive(active);
								Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 632 Invalid \"Jump target not found in method: 0x187355E50\"");
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnHideFinish(GameObject g)
	{
		base.OnHideFinish(g);
		ExitMultiplayerControl();
	}

	protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
	{
		if ((object)GM.Core != null)
		{
			return GM.Core.InteractingPlayer;
		}
		return (VampireSurvivors.Objects.Characters.CharacterController)(object)new NullReferenceException();
	}

	private void FlyInNext()
	{
		//IL_00d7: Expected O, but got I4
		//IL_00b6: Expected O, but got I4
		//IL_019e: Expected O, but got I
		//IL_016c: Expected O, but got I8
		int[] keysToPush = _keysToPush;
		int hintCounter = _hintCounter;
		if (keysToPush[hintCounter] <= 10)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt eax,edx\"");
			if (keysToPush[hintCounter] < 10)
			{
				goto IL_00bb;
			}
		}
		if (keysToPush[hintCounter] == 8)
		{
			goto IL_00bb;
		}
		FlyInPeachone(keysToPush[hintCounter]);
		object obj = 0;
		goto IL_00dc;
		IL_00dc:
		int[] keysToPush2 = _keysToPush;
		if (++_hintCounter >= keysToPush2.Length)
		{
			_hintCounter = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			keysToPush2 = (int[])6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v245 @ rax_v13 (should have been resolved before IL gen)");
		_003CWaitForNextHint_003Ed__35 obj3 = null;
		obj3._003C_003E1__state = 0;
		obj3._003C_003E4__this = this;
		obj3.wait = 4f;
		Coroutine coroutine = StartCoroutine(obj3);
		return;
		IL_00bb:
		FlyInEbony(keysToPush[hintCounter]);
		obj = 0;
		goto IL_00dc;
	}

	private IEnumerator WaitForNextHint(float wait)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002e: Expected O, but got I8
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_010a: Expected O, but got I4
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		_003CWaitForNextHint_003Ed__35 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 40;
			object obj3 = obj2 >> 12;
			object obj4 = 6603864928L;
			object obj5 = obj3 & 0x1FFFFF;
			object obj6 = obj5 >> 6;
			object obj7 = obj5 & 0x3F;
			nint num2;
			do
			{
				object obj8 = 1 << (int)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				object obj9 = 0 | obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				if (num == 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
			}
			while (num2 != 0);
			obj.wait = wait;
			return obj;
		}
		obj.wait = wait;
		return obj;
	}

	private unsafe void FlyInEbony(int nextKey)
	{
		//IL_001a: Expected I, but got O
		//IL_0053: Expected I, but got O
		//IL_008c: Expected I, but got O
		//IL_00eb: Expected O, but got I
		//IL_067d: Invalid comparison between I4 and F4
		//IL_0744: Expected O, but got I4
		//IL_0754: Expected O, but got I
		//IL_06a9: Expected O, but got I4
		//IL_06b9: Expected O, but got I
		//IL_0154: Expected O, but got I8
		//IL_0255: Expected O, but got I8
		//IL_0193: Expected O, but got I8
		//IL_078c: Expected O, but got I
		//IL_028d: Expected O, but got I
		//IL_02be: Expected O, but got I4
		//IL_06f1: Expected O, but got I
		//IL_01f5: Expected O, but got I
		//IL_0216: Expected O, but got I4
		//IL_07d0: Expected O, but got I8
		//IL_0321: Expected F4, but got I4
		//IL_03df: Expected O, but got I
		//IL_04c7: Expected O, but got I
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Expected O, but got Unknown
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_0576: Expected O, but got Unknown
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Expected O, but got Unknown
		//IL_0934: Expected O, but got I4
		//IL_0944: Unknown result type (might be due to invalid IL or missing references)
		//IL_0949: Expected O, but got Unknown
		//IL_025a->IL0917: Incompatible stack heights: 1 vs 0
		//IL_0198->IL08f2: Incompatible stack heights: 1 vs 0
		//IL_0736->IL063e: Incompatible stack heights: 1 vs 0
		//IL_021b->IL0712: Incompatible stack heights: 4 vs 1
		//IL_02de->IL02de: Incompatible stack heights: 2 vs 1
		//IL_0354->IL063e: Incompatible stack heights: 1 vs 0
		//IL_03a5->IL063e: Incompatible stack heights: 2 vs 0
		//IL_03ff->IL063e: Incompatible stack heights: 3 vs 0
		//IL_043c->IL063e: Incompatible stack heights: 4 vs 0
		//IL_048d->IL063e: Incompatible stack heights: 5 vs 0
		//IL_04e7->IL063e: Incompatible stack heights: 6 vs 0
		if (_ebonyXTween != null)
		{
			TweenExtensions.Kill(_ebonyXTween);
			nint num = unchecked((nint)null);
		}
		if (_ebonyYTween != null)
		{
			TweenExtensions.Kill(_ebonyYTween);
			nint num = unchecked((nint)null);
		}
		if (_ebonyAlphaTween != null)
		{
			TweenExtensions.Kill(_ebonyAlphaTween);
			nint num = unchecked((nint)null);
		}
		Vector2 ret;
		if ((object)_EbonyHelper != null)
		{
			Image component = _EbonyHelper.GetComponent<Image>();
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(component, 0f, 1E-05f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag = (nint)0 != 0;
			Image image = component;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				image = (Image)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v355 @ rax_v53 (should have been resolved before IL gen)");
			Vector2 vector = default(Vector2);
			if (0f > 0.5f)
			{
				object obj2 = Screen.width;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					bool flag2 = obj3 == null;
					image = (Image)6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v568 @ rax_v111 (should have been resolved before IL gen)");
				_EbonyHelper.anchoredPosition = vector;
				Transform transform = _EbonyHelper.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rax_v114 (UnityEngine.Transform)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rax_v114 (UnityEngine.Transform)+10]");
				bool flag3 = (nint)0 == 0;
				object obj5 = 0;
				bool flag4 = (nint)0 != 0;
				ret = vector;
				Vector2 vector2 = vector;
				Vector2 vector3 = vector;
				object obj6 = 0;
				if (!flag4)
				{
					bool flag5 = (nint)0 == 0;
					goto IL_02de;
				}
			}
			else
			{
				object obj7 = Screen.width;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					bool flag6 = obj8 == null;
					image = (Image)6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v528 @ rax_v124 (should have been resolved before IL gen)");
				bool flag7 = (object)_EbonyHelper == null;
				_EbonyHelper.anchoredPosition = vector;
				bool flag8 = (object)_EbonyHelper == null;
				Transform transform2 = _EbonyHelper.transform;
				bool flag9 = (object)transform2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ rax_v127 (UnityEngine.Transform)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ rax_v127 (UnityEngine.Transform)+10]");
				bool flag10 = (nint)0 == 0;
				object obj5 = 0;
				ret = vector;
				Vector2 vector2 = vector;
				Vector2 vector3 = vector;
				object obj6 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1255 @ rax_v56 (should have been resolved before IL gen)");
			if ((object)_EbonyHelper != null)
			{
				goto IL_02de;
			}
		}
		goto IL_063e;
		IL_05ff:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1788 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_062e;
		IL_063e:
		throw new NullReferenceException();
		IL_062e:
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2;
		_ebonyYTween = tweenerCore2;
		return;
		IL_02de:
		Image component2 = _EbonyHelper.GetComponent<Image>();
		bool flag11 = _hasEbony;
		float endValue = 1f;
		if (!flag11)
		{
			endValue = 0f;
		}
		TweenerCore<Color, Color, ColorOptions> ebonyAlphaTween = DOTweenModuleUI.DOFade(component2, endValue, 0.5f);
		object obj9 = 6603577472L;
		_ebonyAlphaTween = ebonyAlphaTween;
		List<RectTransform> correctKeys = _CorrectKeys;
		int hintCounter = _hintCounter;
		if (_CorrectKeys != null)
		{
			bool flag12 = _hintCounter >= correctKeys._size;
			object items = correctKeys._items;
			if (correctKeys._items != null)
			{
				int hintCounter2 = _hintCounter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdi_v20 (System.Object)+18]");
				bool flag13 = (nint)hintCounter2 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdi_v20 (System.Object)+20+v199 @ rcx_v54 (System.Int32)*8]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdi_v20 (System.Object)+20+v199 @ rcx_v54 (System.Int32)*8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdi_v21 (System.Object)+10]");
					bool flag14 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdi_v21 (System.Object)+10]");
					float ret2;
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret2));
					TweenerCore<Vector3, Vector3, VectorOptions> ebonyXTween = ShortcutExtensions.DOMoveX(_EbonyHelper, ret2, _birdSpeed);
					_ebonyXTween = ebonyXTween;
					List<RectTransform> correctKeys2 = _CorrectKeys;
					int hintCounter3 = _hintCounter;
					if (_CorrectKeys != null)
					{
						bool flag15 = _hintCounter >= correctKeys2._size;
						object items2 = correctKeys2._items;
						if (correctKeys2._items != null)
						{
							int hintCounter4 = _hintCounter;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdi_v22 (System.Object)+18]");
							bool flag16 = (nint)hintCounter4 >= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdi_v22 (System.Object)+20+v185 @ rdx_v42 (System.Int32)*8]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdi_v22 (System.Object)+20+v185 @ rdx_v42 (System.Int32)*8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdi_v23 (System.Object)+10]");
								bool flag17 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdi_v23 (System.Object)+10]");
								Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
								object obj12 = default(object);
								float endValue2 = (float)obj12 - 0.1f;
								tweenerCore2 = ShortcutExtensions.DOMoveY(_EbonyHelper, endValue2, _birdSpeed);
								TweenCallback tweenCallback2;
								if (tweenerCore2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1788 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
									if ((nint)0 != 0)
									{
										_ = 3;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
										bool flag18 = (nint)0 == 0;
										_ = 0;
										if (!flag18)
										{
											object obj13 = tweenerCore2 + 184;
											object obj14 = obj13 >> 12;
											object obj15 = obj14 & 0x1FFFFF;
											object obj16 = obj15 >> 6;
											object obj17 = obj15 & 0x3F;
											nint num3;
											do
											{
												object obj18 = 1 << (int)obj17;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r14_v19+462E0+v1841 @ rdx_v53*8]");
												object obj19 = 0 | obj18;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r14_v19+462E0+v1841 @ rdx_v53*8]");
												nint num2 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r14_v19+462E0+v1841 @ rdx_v53*8]");
												if (num2 == 0)
												{
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r14_v19+462E0+v1841 @ rdx_v53*8]");
												num3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r14_v19+462E0+v1841 @ rdx_v53*8]");
											}
											while (num3 != 0);
											TweenCallback tweenCallback = delegate
											{
												Image component3 = _EbonyHelper.GetComponent<Image>();
												TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(component3, 0f, 0.5f);
												TweenerCore<Color, Color, ColorOptions> ebonyAlphaTween2 = TweenSettingsExtensions.SetDelay(t, 0.5f);
												_ebonyAlphaTween = ebonyAlphaTween2;
											};
											tweenCallback2 = tweenCallback;
											goto IL_05ff;
										}
									}
								}
								TweenCallback tweenCallback3 = delegate
								{
									Image component3 = _EbonyHelper.GetComponent<Image>();
									TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(component3, 0f, 0.5f);
									TweenerCore<Color, Color, ColorOptions> ebonyAlphaTween2 = TweenSettingsExtensions.SetDelay(t, 0.5f);
									_ebonyAlphaTween = ebonyAlphaTween2;
								};
								bool flag19 = tweenerCore2 == null;
								tweenCallback2 = tweenCallback3;
								if (!flag19)
								{
									goto IL_05ff;
								}
								goto IL_062e;
							}
						}
					}
				}
			}
		}
		goto IL_063e;
	}

	private void FlyOutEbony()
	{
		Image component = _EbonyHelper.GetComponent<Image>();
		TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(component, 0f, 0.5f);
		TweenerCore<Color, Color, ColorOptions> ebonyAlphaTween = TweenSettingsExtensions.SetDelay(t, 0.5f);
		_ebonyAlphaTween = ebonyAlphaTween;
	}

	private unsafe void FlyInPeachone(int nextKey)
	{
		//IL_001a: Expected I, but got O
		//IL_0053: Expected I, but got O
		//IL_008c: Expected I, but got O
		//IL_00eb: Expected O, but got I
		//IL_067d: Invalid comparison between I4 and F4
		//IL_0744: Expected O, but got I4
		//IL_0754: Expected O, but got I
		//IL_06a9: Expected O, but got I4
		//IL_06b9: Expected O, but got I
		//IL_0154: Expected O, but got I8
		//IL_0255: Expected O, but got I8
		//IL_0193: Expected O, but got I8
		//IL_078c: Expected O, but got I
		//IL_028d: Expected O, but got I
		//IL_02be: Expected O, but got I4
		//IL_06f1: Expected O, but got I
		//IL_01f5: Expected O, but got I
		//IL_0216: Expected O, but got I4
		//IL_07d0: Expected O, but got I8
		//IL_0321: Expected F4, but got I4
		//IL_03df: Expected O, but got I
		//IL_04c7: Expected O, but got I
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Expected O, but got Unknown
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_0576: Expected O, but got Unknown
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Expected O, but got Unknown
		//IL_0934: Expected O, but got I4
		//IL_0944: Unknown result type (might be due to invalid IL or missing references)
		//IL_0949: Expected O, but got Unknown
		//IL_025a->IL0917: Incompatible stack heights: 1 vs 0
		//IL_0198->IL08f2: Incompatible stack heights: 1 vs 0
		//IL_0736->IL063e: Incompatible stack heights: 1 vs 0
		//IL_021b->IL0712: Incompatible stack heights: 4 vs 1
		//IL_02de->IL02de: Incompatible stack heights: 2 vs 1
		//IL_0354->IL063e: Incompatible stack heights: 1 vs 0
		//IL_03a5->IL063e: Incompatible stack heights: 2 vs 0
		//IL_03ff->IL063e: Incompatible stack heights: 3 vs 0
		//IL_043c->IL063e: Incompatible stack heights: 4 vs 0
		//IL_048d->IL063e: Incompatible stack heights: 5 vs 0
		//IL_04e7->IL063e: Incompatible stack heights: 6 vs 0
		if (_peachoneXTween != null)
		{
			TweenExtensions.Kill(_peachoneXTween);
			nint num = unchecked((nint)null);
		}
		if (_peachoneYTween != null)
		{
			TweenExtensions.Kill(_peachoneYTween);
			nint num = unchecked((nint)null);
		}
		if (_peachoneAlphaTween != null)
		{
			TweenExtensions.Kill(_peachoneAlphaTween);
			nint num = unchecked((nint)null);
		}
		Vector2 ret;
		if ((object)_PeachoneHelper != null)
		{
			Image component = _PeachoneHelper.GetComponent<Image>();
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(component, 0f, 1E-05f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag = (nint)0 != 0;
			Image image = component;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				image = (Image)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v355 @ rax_v53 (should have been resolved before IL gen)");
			Vector2 vector = default(Vector2);
			if (0f > 0.5f)
			{
				object obj2 = Screen.width;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					bool flag2 = obj3 == null;
					image = (Image)6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v568 @ rax_v111 (should have been resolved before IL gen)");
				_PeachoneHelper.anchoredPosition = vector;
				Transform transform = _PeachoneHelper.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rax_v114 (UnityEngine.Transform)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rax_v114 (UnityEngine.Transform)+10]");
				bool flag3 = (nint)0 == 0;
				object obj5 = 0;
				bool flag4 = (nint)0 != 0;
				ret = vector;
				Vector2 vector2 = vector;
				Vector2 vector3 = vector;
				object obj6 = 0;
				if (!flag4)
				{
					bool flag5 = (nint)0 == 0;
					goto IL_02de;
				}
			}
			else
			{
				object obj7 = Screen.width;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					bool flag6 = obj8 == null;
					image = (Image)6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v528 @ rax_v124 (should have been resolved before IL gen)");
				bool flag7 = (object)_PeachoneHelper == null;
				_PeachoneHelper.anchoredPosition = vector;
				bool flag8 = (object)_PeachoneHelper == null;
				Transform transform2 = _PeachoneHelper.transform;
				bool flag9 = (object)transform2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ rax_v127 (UnityEngine.Transform)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ rax_v127 (UnityEngine.Transform)+10]");
				bool flag10 = (nint)0 == 0;
				object obj5 = 0;
				ret = vector;
				Vector2 vector2 = vector;
				Vector2 vector3 = vector;
				object obj6 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1255 @ rax_v56 (should have been resolved before IL gen)");
			if ((object)_PeachoneHelper != null)
			{
				goto IL_02de;
			}
		}
		goto IL_063e;
		IL_05ff:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1788 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_062e;
		IL_063e:
		throw new NullReferenceException();
		IL_062e:
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2;
		_peachoneYTween = tweenerCore2;
		return;
		IL_02de:
		Image component2 = _PeachoneHelper.GetComponent<Image>();
		bool flag11 = _hasPeachone;
		float endValue = 1f;
		if (!flag11)
		{
			endValue = 0f;
		}
		TweenerCore<Color, Color, ColorOptions> peachoneAlphaTween = DOTweenModuleUI.DOFade(component2, endValue, 0.5f);
		object obj9 = 6603577472L;
		_peachoneAlphaTween = peachoneAlphaTween;
		List<RectTransform> correctKeys = _CorrectKeys;
		int hintCounter = _hintCounter;
		if (_CorrectKeys != null)
		{
			bool flag12 = _hintCounter >= correctKeys._size;
			object items = correctKeys._items;
			if (correctKeys._items != null)
			{
				int hintCounter2 = _hintCounter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdi_v20 (System.Object)+18]");
				bool flag13 = (nint)hintCounter2 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdi_v20 (System.Object)+20+v199 @ rcx_v54 (System.Int32)*8]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdi_v20 (System.Object)+20+v199 @ rcx_v54 (System.Int32)*8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdi_v21 (System.Object)+10]");
					bool flag14 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdi_v21 (System.Object)+10]");
					float ret2;
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret2));
					TweenerCore<Vector3, Vector3, VectorOptions> peachoneXTween = ShortcutExtensions.DOMoveX(_PeachoneHelper, ret2, _birdSpeed);
					_peachoneXTween = peachoneXTween;
					List<RectTransform> correctKeys2 = _CorrectKeys;
					int hintCounter3 = _hintCounter;
					if (_CorrectKeys != null)
					{
						bool flag15 = _hintCounter >= correctKeys2._size;
						object items2 = correctKeys2._items;
						if (correctKeys2._items != null)
						{
							int hintCounter4 = _hintCounter;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdi_v22 (System.Object)+18]");
							bool flag16 = (nint)hintCounter4 >= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdi_v22 (System.Object)+20+v185 @ rdx_v42 (System.Int32)*8]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdi_v22 (System.Object)+20+v185 @ rdx_v42 (System.Int32)*8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdi_v23 (System.Object)+10]");
								bool flag17 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdi_v23 (System.Object)+10]");
								Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
								object obj12 = default(object);
								float endValue2 = (float)obj12 - 0.1f;
								tweenerCore2 = ShortcutExtensions.DOMoveY(_PeachoneHelper, endValue2, _birdSpeed);
								TweenCallback tweenCallback2;
								if (tweenerCore2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1788 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
									if ((nint)0 != 0)
									{
										_ = 3;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
										bool flag18 = (nint)0 == 0;
										_ = 0;
										if (!flag18)
										{
											object obj13 = tweenerCore2 + 184;
											object obj14 = obj13 >> 12;
											object obj15 = obj14 & 0x1FFFFF;
											object obj16 = obj15 >> 6;
											object obj17 = obj15 & 0x3F;
											nint num3;
											do
											{
												object obj18 = 1 << (int)obj17;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r14_v19+462E0+v1841 @ rdx_v53*8]");
												object obj19 = 0 | obj18;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r14_v19+462E0+v1841 @ rdx_v53*8]");
												nint num2 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r14_v19+462E0+v1841 @ rdx_v53*8]");
												if (num2 == 0)
												{
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r14_v19+462E0+v1841 @ rdx_v53*8]");
												num3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r14_v19+462E0+v1841 @ rdx_v53*8]");
											}
											while (num3 != 0);
											TweenCallback tweenCallback = delegate
											{
												Image component3 = _PeachoneHelper.GetComponent<Image>();
												TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(component3, 0f, 0.5f);
												TweenerCore<Color, Color, ColorOptions> peachoneAlphaTween2 = TweenSettingsExtensions.SetDelay(t, 0.5f);
												_peachoneAlphaTween = peachoneAlphaTween2;
											};
											tweenCallback2 = tweenCallback;
											goto IL_05ff;
										}
									}
								}
								TweenCallback tweenCallback3 = delegate
								{
									Image component3 = _PeachoneHelper.GetComponent<Image>();
									TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(component3, 0f, 0.5f);
									TweenerCore<Color, Color, ColorOptions> peachoneAlphaTween2 = TweenSettingsExtensions.SetDelay(t, 0.5f);
									_peachoneAlphaTween = peachoneAlphaTween2;
								};
								bool flag19 = tweenerCore2 == null;
								tweenCallback2 = tweenCallback3;
								if (!flag19)
								{
									goto IL_05ff;
								}
								goto IL_062e;
							}
						}
					}
				}
			}
		}
		goto IL_063e;
	}

	private void FlyOutPeachone()
	{
		Image component = _PeachoneHelper.GetComponent<Image>();
		TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(component, 0f, 0.5f);
		TweenerCore<Color, Color, ColorOptions> peachoneAlphaTween = TweenSettingsExtensions.SetDelay(t, 0.5f);
		_peachoneAlphaTween = peachoneAlphaTween;
	}

	private void Exit()
	{
		if (_ebonyAlphaTween != null)
		{
			TweenExtensions.Kill(_ebonyAlphaTween);
		}
		if (_ebonyXTween != null)
		{
			TweenExtensions.Kill(_ebonyXTween);
		}
		if (_ebonyYTween != null)
		{
			TweenExtensions.Kill(_ebonyYTween);
		}
		if (_peachoneAlphaTween != null)
		{
			TweenExtensions.Kill(_peachoneAlphaTween);
		}
		if (_peachoneXTween != null)
		{
			TweenExtensions.Kill(_peachoneXTween);
		}
		if (_peachoneYTween != null)
		{
			TweenExtensions.Kill(_peachoneYTween);
		}
		Image component = _PeachoneHelper.GetComponent<Image>();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(component, 0f, 0.5f);
		Image component2 = _EbonyHelper.GetComponent<Image>();
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(component2, 0f, 0.5f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(_Fader, 0f, 0.5f);
		Transform target = _Piano.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScale(target, 0f, 0.5f);
		Transform target2 = _PianoOverlay.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOScale(target2, 0f, 0.5f);
		TweenCallback tweenCallback = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AADA40");
		};
		if (tweenerCore5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
	}

	private void ExitSuccessfully()
	{
		if (_ebonyAlphaTween != null)
		{
			TweenExtensions.Kill(_ebonyAlphaTween);
		}
		if (_ebonyXTween != null)
		{
			TweenExtensions.Kill(_ebonyXTween);
		}
		if (_ebonyYTween != null)
		{
			TweenExtensions.Kill(_ebonyYTween);
		}
		if (_peachoneAlphaTween != null)
		{
			TweenExtensions.Kill(_peachoneAlphaTween);
		}
		if (_peachoneXTween != null)
		{
			TweenExtensions.Kill(_peachoneXTween);
		}
		if (_peachoneYTween != null)
		{
			TweenExtensions.Kill(_peachoneYTween);
		}
		Image component = _PeachoneHelper.GetComponent<Image>();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(component, 0f, 0.5f);
		Image component2 = _EbonyHelper.GetComponent<Image>();
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(component2, 0f, 0.5f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(_Fader, 0f, 0.5f);
		Transform target = _Piano.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScale(target, 0f, 0.5f);
		Transform target2 = _PianoOverlay.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOScale(target2, 0f, 0.5f);
		TweenCallback tweenCallback = delegate
		{
			//IL_0084: Expected I8, but got O
			//IL_009c: Expected I8, but got O
			//IL_0068: Expected O, but got I
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AADA40");
				DoTheBigSpoop();
			}
			else
			{
				long num = (long)OnlineStageManager._instance;
				Action<long> action = null;
				((OnlineStageManager)(object)action).SuccessfulPiano((long)OnlineStageManager._instance);
				long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v3 (System.Int64)+78]");
				bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
			}
		};
		if (tweenerCore5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
		Debug.Log("Eixit successfully");
	}

	private void ProcessPianoSuccess()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AADA40");
		DoTheBigSpoop();
	}

	private void DoTheBigSpoop()
	{
		//IL_011f: Expected I, but got O
		//IL_012c: Expected I, but got O
		//IL_013c: Expected O, but got I
		//IL_0178: Expected O, but got I
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if ((object)core._stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		BackgroundManager fancyBg = stage2._fancyBg;
		if ((object)stage2._fancyBg == null || ((UnityEngine.Object)fancyBg).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSelectedStage_003Ek__BackingField != StageType.LIBRARY)
		{
			return;
		}
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		Background2 fancyBg2 = (Background2)stage3._fancyBg;
		nint num = (nint)typeof(Background2);
		nint num2 = (nint)fancyBg2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.Background2>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.Background2>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.Background2>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.Background2>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v25+FFFFFFF8+v209 @ rax_v24*8]");
			if (0 == (nint)typeof(Background2))
			{
				fancyBg2.BigSpoop();
				return;
			}
		}
		throw new InvalidCastException();
	}

	public PianoPage()
	{
		List<RectTransform> correctKeys = new List<RectTransform>();
		_CorrectKeys = correctKeys;
		_keysToPush = new int[5] { 2, 9, 10, 7, 1 };
		_keysPushed = new List<int>();
		_birdSpeed = 3f;
		base._002Ector();
	}

	private void _003CFlyInEbony_003Eb__36_0()
	{
		Image component = _EbonyHelper.GetComponent<Image>();
		TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(component, 0f, 0.5f);
		TweenerCore<Color, Color, ColorOptions> ebonyAlphaTween = TweenSettingsExtensions.SetDelay(t, 0.5f);
		_ebonyAlphaTween = ebonyAlphaTween;
	}

	private void _003CFlyInPeachone_003Eb__38_0()
	{
		Image component = _PeachoneHelper.GetComponent<Image>();
		TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(component, 0f, 0.5f);
		TweenerCore<Color, Color, ColorOptions> peachoneAlphaTween = TweenSettingsExtensions.SetDelay(t, 0.5f);
		_peachoneAlphaTween = peachoneAlphaTween;
	}

	private void _003CExit_003Eb__40_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AADA40");
	}

	private void _003CExitSuccessfully_003Eb__41_0()
	{
		//IL_0084: Expected I8, but got O
		//IL_009c: Expected I8, but got O
		//IL_0068: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AADA40");
			DoTheBigSpoop();
			return;
		}
		long num = (long)OnlineStageManager._instance;
		Action<long> action = null;
		((OnlineStageManager)(object)action).SuccessfulPiano((long)OnlineStageManager._instance);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v3 (System.Int64)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}
}
