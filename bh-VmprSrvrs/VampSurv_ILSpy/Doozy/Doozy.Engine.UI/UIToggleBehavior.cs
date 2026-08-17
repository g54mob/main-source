using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Events;
using Doozy.Engine.Soundy;
using Doozy.Engine.UI.Animation;
using Doozy.Engine.UI.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Doozy.Engine.UI;

[Serializable]
public class UIToggleBehavior
{
	private sealed class _003C_003Ec__DisplayClass56_0
	{
		public UIToggle toggle;

		public bool sendGameEvents;

		public UIAction uiAction;

		public bool executeUnityEvent;

		internal void _003CInvoke_003Eb__0()
		{
			UIToggle uIToggle = toggle;
			if ((object)toggle == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1 (Doozy.Engine.UI.UIToggle)+10]");
			if ((nint)0 == 0)
			{
				return;
			}
			if (sendGameEvents)
			{
				UIAction uIAction = uiAction;
				GameObject gameObject = toggle.gameObject;
				if (uIAction.GameEvents != null)
				{
					List<string> gameEvents = uIAction.GameEvents;
					if (gameEvents._size > 0)
					{
						GameEventMessage.SendEvents(gameEvents, gameObject);
					}
				}
			}
			if (executeUnityEvent)
			{
				UIAction uIAction2 = uiAction;
				GameObject gameObject2 = toggle.gameObject;
				if (uIAction2.Action != null)
				{
					Action<GameObject> action = uIAction2.Action;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v402 @ r9_v6 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
				UIAction uIAction3 = uiAction;
				if (uIAction3.Event != null)
				{
					uIAction3.Event.Invoke();
				}
			}
		}
	}

	private sealed class _003CInvokeCallbackAfterDelay_003Ed__62(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UnityAction callback;

		public float delay;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0025: Expected I4, but got I8
			//IL_00c8: Expected I4, but got I8
			//IL_003e: Invalid comparison between I4 and F4
			//IL_00ea: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				bool flag = callback == null;
				_003C_003E1__state = -1;
				if (flag)
				{
					goto IL_010c;
				}
				if (0f < delay)
				{
					WaitForSecondsRealtime waitForSecondsRealtime = null;
					waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = delay;
					waitForSecondsRealtime.m_WaitUntilTime = -1f;
					_003C_003E2__current = waitForSecondsRealtime;
					_003C_003E1__state = 1;
					return true;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_010c;
				}
				_003C_003E1__state = -1;
			}
			UnityAction unityAction = callback;
			if (callback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v122.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				goto IL_010c;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_010c:
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

	private sealed class _003CInvokeCallbacks_003Ed__61(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIAnimation animation;

		public UnityAction onStartCallback;

		public UnityAction onCompleteCallback;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0182: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_00aa: Expected I4, but got I8
			//IL_0234: Expected I4, but got O
			//IL_0063: Expected I4, but got I8
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag)
				{
					bool flag2 = onStartCallback == null;
					_003C_003E1__state = -1;
					if (!flag2)
					{
						UnityAction unityAction = onStartCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v121.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
					if (animation != null)
					{
						float totalDuration = animation.TotalDuration;
						if (animation != null)
						{
							float startDelay = animation.StartDelay;
							WaitForSecondsRealtime waitForSecondsRealtime = null;
							float num = totalDuration - startDelay;
							waitForSecondsRealtime.m_WaitUntilTime = -1f;
							waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = num;
							_003C_003E2__current = waitForSecondsRealtime;
							_003C_003E1__state = 2;
							return true;
						}
					}
					goto IL_0226;
				}
				if ((nint)obj == 1)
				{
					bool flag3 = onCompleteCallback == null;
					_003C_003E1__state = -1;
					if (!flag3)
					{
						UnityAction unityAction2 = onCompleteCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v211.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				}
			}
			else
			{
				bool flag4 = animation == null;
				_003C_003E1__state = -1;
				if (!flag4 && animation.Enabled)
				{
					if (animation != null)
					{
						float startDelay2 = animation.StartDelay;
						WaitForSecondsRealtime waitForSecondsRealtime2 = null;
						waitForSecondsRealtime2._003CwaitTime_003Ek__BackingField = startDelay2;
						waitForSecondsRealtime2.m_WaitUntilTime = -1f;
						_003C_003E2__current = waitForSecondsRealtime2;
						_003C_003E1__state = 1;
						return true;
					}
					goto IL_0226;
				}
			}
			return false;
			IL_0226:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
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

	public const ButtonAnimationType DEFAULT_BUTTON_ANIMATION_TYPE = ButtonAnimationType.Punch;

	public const bool DEFAULT_DESELECT_BUTTON = false;

	public const bool DEFAULT_ENABLED = false;

	public const bool DEFAULT_LOAD_SELECTED_PRESET_AT_RUNTIME = false;

	public const bool DEFAULT_READY = true;

	public const bool DEFAULT_SELECT_BUTTON = false;

	public const bool DEFAULT_TRIGGER_EVENTS_AFTER_ANIMATION = false;

	public const float ON_BUTTON_DESELECTED_DISABLE_INTERVAL = 0f;

	public const float ON_BUTTON_SELECTED_DISABLE_INTERVAL = 0f;

	public const float ON_CLICK_DISABLE_INTERVAL = 0.4f;

	public const float ON_POINTER_ENTER_DISABLE_INTERVAL = 0.4f;

	public const float ON_POINTER_EXIT_DISABLE_INTERVAL = 0.4f;

	public List<AnimatorEvent> Animators;

	public ButtonAnimationType ButtonAnimationType;

	public bool DeselectButton;

	public float DisableInterval;

	public bool Enabled;

	public bool LoadSelectedPresetAtRuntime;

	public UIAction OnToggleOff;

	public UIAction OnToggleOn;

	public string PresetCategory;

	public string PresetName;

	public UIAnimation PunchAnimation;

	public bool Ready;

	public bool SelectButton;

	public UIAnimation StateAnimation;

	public bool TriggerEventsAfterAnimation;

	private UIToggleBehaviorType m_behaviorType;

	public static string DefaultPresetCategory
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998076A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "Uncategorized";
		}
	}

	public static string DefaultPresetName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998076B]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "Default";
		}
	}

	public int AnimatorsCount
	{
		get
		{
			if (Animators == null)
			{
				return 0;
			}
			List<AnimatorEvent> animators = Animators;
			return animators._size;
		}
	}

	public UIToggleBehaviorType BehaviorType => m_behaviorType;

	public bool HasAnimation
	{
		get
		{
			//IL_002f: Expected O, but got I4
			bool flag = ButtonAnimationType == ButtonAnimationType.Punch;
			UIAnimation uIAnimation;
			if (!flag)
			{
				object obj = ButtonAnimationType - 1;
				if (!flag)
				{
					if ((nint)obj == 1)
					{
						if (Animators == null)
						{
							bool flag2 = 0 < 0;
							bool flag3 = 0 < 0;
							bool flag4 = flag3 == flag2;
							return (byte)(0xFFFFFFFEu & (flag4 ? 1u : 0u)) != 0;
						}
						List<AnimatorEvent> animators = Animators;
						int num = animators._size ^ animators._size;
						int num2 = animators._size & num;
						bool flag5 = num2 < 0;
						bool flag6 = animators._size < 0;
						bool flag7 = animators._size == 0;
						bool flag8 = flag6 == flag5;
						bool flag9 = !flag7;
						return flag9 & flag8;
					}
				}
				else if (ButtonAnimationType == ButtonAnimationType.State && StateAnimation != null)
				{
					uIAnimation = StateAnimation;
					goto IL_020d;
				}
			}
			else if (ButtonAnimationType == ButtonAnimationType.Punch && PunchAnimation != null)
			{
				uIAnimation = PunchAnimation;
				goto IL_020d;
			}
			return false;
			IL_020d:
			if (uIAnimation.Enabled)
			{
				return true;
			}
			return LoadSelectedPresetAtRuntime;
		}
	}

	public bool HasAnimators
	{
		get
		{
			if (ButtonAnimationType != ButtonAnimationType.Animator)
			{
				return false;
			}
			if (Animators == null)
			{
				bool flag = 0 < 0;
				bool flag2 = 0 < 0;
				bool flag3 = flag2 == flag;
				return (byte)(0xFFFFFFFEu & (flag3 ? 1u : 0u)) != 0;
			}
			List<AnimatorEvent> animators = Animators;
			int num = animators._size ^ animators._size;
			int num2 = animators._size & num;
			bool flag4 = num2 < 0;
			bool flag5 = animators._size < 0;
			bool flag6 = animators._size == 0;
			bool flag7 = flag5 == flag4;
			bool flag8 = !flag6;
			return flag8 & flag7;
		}
	}

	public bool HasAnimatorEvents
	{
		get
		{
			//IL_016d: Expected I4, but got O
			UIAction onToggleOn = OnToggleOn;
			if (OnToggleOn != null)
			{
				if (onToggleOn.AnimatorEvents != null)
				{
					List<AnimatorEvent> animatorEvents = onToggleOn.AnimatorEvents;
					if (onToggleOn.AnimatorEvents == null)
					{
						goto IL_015f;
					}
					if (animatorEvents._size > 0)
					{
						return true;
					}
				}
				UIAction onToggleOff = OnToggleOff;
				if (OnToggleOff != null)
				{
					if (onToggleOff.AnimatorEvents == null)
					{
						return false;
					}
					List<AnimatorEvent> animatorEvents2 = onToggleOff.AnimatorEvents;
					if (onToggleOff.AnimatorEvents != null)
					{
						int num = animatorEvents2._size ^ animatorEvents2._size;
						int num2 = animatorEvents2._size & num;
						bool flag = num2 < 0;
						bool flag2 = animatorEvents2._size < 0;
						bool flag3 = animatorEvents2._size == 0;
						bool flag4 = flag2 == flag;
						bool flag5 = !flag3;
						return flag5 & flag4;
					}
				}
			}
			goto IL_015f;
			IL_015f:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasEffect
	{
		get
		{
			//IL_008e: Expected I4, but got O
			if (OnToggleOn != null)
			{
				if (OnToggleOn.HasEffect)
				{
					return true;
				}
				if (OnToggleOff != null)
				{
					return OnToggleOff.HasEffect;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasGameEvents
	{
		get
		{
			//IL_016d: Expected I4, but got O
			UIAction onToggleOn = OnToggleOn;
			if (OnToggleOn != null)
			{
				if (onToggleOn.GameEvents != null)
				{
					List<string> gameEvents = onToggleOn.GameEvents;
					if (onToggleOn.GameEvents == null)
					{
						goto IL_015f;
					}
					if (gameEvents._size > 0)
					{
						return true;
					}
				}
				UIAction onToggleOff = OnToggleOff;
				if (OnToggleOff != null)
				{
					if (onToggleOff.GameEvents == null)
					{
						return false;
					}
					List<string> gameEvents2 = onToggleOff.GameEvents;
					if (onToggleOff.GameEvents != null)
					{
						int num = gameEvents2._size ^ gameEvents2._size;
						int num2 = gameEvents2._size & num;
						bool flag = num2 < 0;
						bool flag2 = gameEvents2._size < 0;
						bool flag3 = gameEvents2._size == 0;
						bool flag4 = flag2 == flag;
						bool flag5 = !flag3;
						return flag5 & flag4;
					}
				}
			}
			goto IL_015f;
			IL_015f:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasPunchAnimation
	{
		get
		{
			if (ButtonAnimationType == ButtonAnimationType.Punch && PunchAnimation != null)
			{
				if (PunchAnimation.Enabled)
				{
					return true;
				}
				return LoadSelectedPresetAtRuntime;
			}
			return false;
		}
	}

	public bool HasSound
	{
		get
		{
			//IL_008e: Expected I4, but got O
			if (OnToggleOn != null)
			{
				if (OnToggleOn.HasSound)
				{
					return true;
				}
				if (OnToggleOff != null)
				{
					return OnToggleOff.HasSound;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasStateAnimation
	{
		get
		{
			if (ButtonAnimationType == ButtonAnimationType.State && StateAnimation != null)
			{
				if (StateAnimation.Enabled)
				{
					return true;
				}
				return LoadSelectedPresetAtRuntime;
			}
			return false;
		}
	}

	public bool HasUnityEvents
	{
		get
		{
			//IL_00f8: Expected I4, but got O
			UIAction onToggleOn = OnToggleOn;
			if (OnToggleOn != null)
			{
				if (onToggleOn.Event == null)
				{
					goto IL_00b7;
				}
				UnityEvent unityEvent = onToggleOn.Event;
				UnityEngine.Events.PersistentCallGroup persistentCalls = ((UnityEventBase)unityEvent).m_PersistentCalls;
				if (((UnityEventBase)unityEvent).m_PersistentCalls != null)
				{
					List<UnityEngine.Events.PersistentCall> calls = persistentCalls.m_Calls;
					if (persistentCalls.m_Calls != null)
					{
						if (calls._size > 0)
						{
							return true;
						}
						goto IL_00b7;
					}
				}
			}
			goto IL_00ea;
			IL_00b7:
			if (OnToggleOff != null)
			{
				return OnToggleOff.HasUnityEvent;
			}
			goto IL_00ea;
			IL_00ea:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public UIToggleBehavior(UIToggleBehaviorType behaviorType, bool enabled = false)
	{
		Reset(behaviorType);
		Enabled = enabled;
	}

	public float GetAnimationTotalDuration()
	{
		//IL_007a: Expected F4, but got I4
		UIAnimation uIAnimation;
		if (ButtonAnimationType == ButtonAnimationType.Punch)
		{
			uIAnimation = PunchAnimation;
		}
		else
		{
			if (ButtonAnimationType != ButtonAnimationType.State)
			{
				return 0f;
			}
			uIAnimation = StateAnimation;
		}
		return uIAnimation.TotalDuration;
	}

	public void Invoke(UIToggle toggle, bool playAnimation = true, bool playSound = true, bool executeEffect = true, bool executeAnimatorEvents = true, bool sendGameEvents = true, bool executeUnityEvent = true)
	{
		//IL_030c: Expected F4, but got I4
		_003C_003Ec__DisplayClass56_0 CS_0024_003C_003E8__locals32 = new _003C_003Ec__DisplayClass56_0();
		CS_0024_003C_003E8__locals32.toggle = toggle;
		UIToggle toggle2 = CS_0024_003C_003E8__locals32.toggle;
		bool sendGameEvents2 = default(bool);
		CS_0024_003C_003E8__locals32.sendGameEvents = sendGameEvents2;
		bool executeUnityEvent2 = default(bool);
		CS_0024_003C_003E8__locals32.executeUnityEvent = executeUnityEvent2;
		if ((object)CS_0024_003C_003E8__locals32.toggle == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdi_v3 (Doozy.Engine.UI.UIToggle)+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		Toggle toggle3 = CS_0024_003C_003E8__locals32.toggle.Toggle;
		UIAction uiAction = ((!toggle3.m_IsOn) ? OnToggleOff : OnToggleOn);
		CS_0024_003C_003E8__locals32.uiAction = uiAction;
		if (playAnimation)
		{
			UnityAction onCompleteCallback = default(UnityAction);
			PlayAnimation(CS_0024_003C_003E8__locals32.toggle, withSound: false, null, onCompleteCallback);
		}
		if (playSound)
		{
			UIAction uiAction2 = CS_0024_003C_003E8__locals32.uiAction;
			if (CS_0024_003C_003E8__locals32.uiAction.HasSound)
			{
				SoundyController soundyController = SoundyManager.Play(uiAction2.SoundData);
			}
		}
		object obj = default(object);
		if (obj != null)
		{
			GameObject gameObject = CS_0024_003C_003E8__locals32.toggle.gameObject;
			Canvas canvas = CS_0024_003C_003E8__locals32.uiAction.GetCanvas(gameObject);
			CS_0024_003C_003E8__locals32.uiAction.ExecuteEffect(canvas);
		}
		object obj2 = default(object);
		if (obj2 != null)
		{
			CS_0024_003C_003E8__locals32.uiAction.InvokeAnimatorEvents();
		}
		if (!CS_0024_003C_003E8__locals32.sendGameEvents && !CS_0024_003C_003E8__locals32.executeUnityEvent)
		{
			return;
		}
		if (TriggerEventsAfterAnimation)
		{
			UnityAction callback = delegate
			{
				UIToggle toggle4 = CS_0024_003C_003E8__locals32.toggle;
				if ((object)CS_0024_003C_003E8__locals32.toggle != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1 (Doozy.Engine.UI.UIToggle)+10]");
					if ((nint)0 != 0)
					{
						if (CS_0024_003C_003E8__locals32.sendGameEvents)
						{
							UIAction uiAction5 = CS_0024_003C_003E8__locals32.uiAction;
							GameObject gameObject4 = CS_0024_003C_003E8__locals32.toggle.gameObject;
							if (uiAction5.GameEvents != null)
							{
								List<string> gameEvents = uiAction5.GameEvents;
								if (gameEvents._size > 0)
								{
									GameEventMessage.SendEvents(gameEvents, gameObject4);
								}
							}
						}
						if (CS_0024_003C_003E8__locals32.executeUnityEvent)
						{
							UIAction uiAction6 = CS_0024_003C_003E8__locals32.uiAction;
							GameObject gameObject5 = CS_0024_003C_003E8__locals32.toggle.gameObject;
							if (uiAction6.Action != null)
							{
								Action<GameObject> action2 = uiAction6.Action;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v402 @ r9_v6 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
							}
							UIAction uiAction7 = CS_0024_003C_003E8__locals32.uiAction;
							if (uiAction7.Event != null)
							{
								uiAction7.Event.Invoke();
							}
						}
					}
				}
			};
			float delay;
			if (ButtonAnimationType == ButtonAnimationType.Punch)
			{
				float totalDuration = PunchAnimation.TotalDuration;
				delay = totalDuration;
			}
			else if (ButtonAnimationType == ButtonAnimationType.State)
			{
				float totalDuration2 = StateAnimation.TotalDuration;
				delay = totalDuration2;
			}
			else
			{
				delay = 0f;
			}
			_003CInvokeCallbackAfterDelay_003Ed__62 obj3 = null;
			obj3._003C_003E1__state = 0;
			obj3.callback = callback;
			obj3.delay = delay;
			Coroutine coroutine = Coroutiner.Start(obj3);
			return;
		}
		if (CS_0024_003C_003E8__locals32.sendGameEvents)
		{
			GameObject gameObject2 = CS_0024_003C_003E8__locals32.toggle.gameObject;
			CS_0024_003C_003E8__locals32.uiAction.SendGameEvents(gameObject2);
		}
		if (CS_0024_003C_003E8__locals32.executeUnityEvent)
		{
			UIAction uiAction3 = CS_0024_003C_003E8__locals32.uiAction;
			GameObject gameObject3 = CS_0024_003C_003E8__locals32.toggle.gameObject;
			if (uiAction3.Action != null)
			{
				Action<GameObject> action = uiAction3.Action;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v864 @ r9_v6 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
			}
			UIAction uiAction4 = CS_0024_003C_003E8__locals32.uiAction;
			if (uiAction4.Event != null)
			{
				uiAction4.Event.Invoke();
			}
		}
	}

	public void LoadPreset()
	{
		if (ButtonAnimationType == ButtonAnimationType.Animator)
		{
			return;
		}
		UIAnimations instance = UIAnimations.Instance;
		AnimationType databaseType;
		if (ButtonAnimationType == ButtonAnimationType.Punch)
		{
			databaseType = AnimationType.Punch;
		}
		else
		{
			bool flag = ButtonAnimationType != ButtonAnimationType.State;
			databaseType = AnimationType.Undefined;
			if (!flag)
			{
				databaseType = AnimationType.State;
			}
		}
		UIAnimationData uIAnimationData = instance.Get(databaseType, PresetCategory, PresetName);
		if ((object)uIAnimationData != null && ((UnityEngine.Object)uIAnimationData).m_CachedPtr != (IntPtr)0)
		{
			if (ButtonAnimationType == ButtonAnimationType.Punch)
			{
				UIAnimation punchAnimation = uIAnimationData.Animation.Copy();
				PunchAnimation = punchAnimation;
			}
			else if (ButtonAnimationType == ButtonAnimationType.State)
			{
				UIAnimation stateAnimation = uIAnimationData.Animation.Copy();
				StateAnimation = stateAnimation;
			}
		}
	}

	public void LoadPreset(string presetCategory, string presetName)
	{
		if (ButtonAnimationType == ButtonAnimationType.Animator)
		{
			return;
		}
		UIAnimations instance = UIAnimations.Instance;
		AnimationType databaseType;
		if (ButtonAnimationType == ButtonAnimationType.Punch)
		{
			databaseType = AnimationType.Punch;
		}
		else
		{
			bool flag = ButtonAnimationType != ButtonAnimationType.State;
			databaseType = AnimationType.Undefined;
			if (!flag)
			{
				databaseType = AnimationType.State;
			}
		}
		UIAnimationData uIAnimationData = instance.Get(databaseType, presetCategory, presetName);
		if ((object)uIAnimationData != null && ((UnityEngine.Object)uIAnimationData).m_CachedPtr != (IntPtr)0)
		{
			if (ButtonAnimationType == ButtonAnimationType.Punch)
			{
				UIAnimation punchAnimation = uIAnimationData.Animation.Copy();
				PunchAnimation = punchAnimation;
			}
			else if (ButtonAnimationType == ButtonAnimationType.State)
			{
				UIAnimation stateAnimation = uIAnimationData.Animation.Copy();
				StateAnimation = stateAnimation;
			}
		}
	}

	public unsafe void PlayAnimation(UIToggle toggle, bool withSound = true, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_0531: Expected O, but got I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0151: Expected O, but got Ref
		//IL_017c: Expected O, but got Ref
		//IL_01a7: Expected O, but got Ref
		//IL_01d9: Expected F4, but got I
		//IL_00c0: Expected O, but got Ref
		//IL_03d5: Expected O, but got Ref
		//IL_0400: Expected O, but got Ref
		//IL_042b: Expected O, but got Ref
		IEnumerator enumerator = (IEnumerator)ButtonAnimationType;
		bool flag = ButtonAnimationType == ButtonAnimationType.Punch;
		object obj = default(object);
		UnityAction onCompleteCallback2 = default(UnityAction);
		UIAnimation animation;
		if (!flag)
		{
			enumerator = (IEnumerator)(enumerator - 1);
			if (!flag)
			{
				if ((nint)enumerator == 1)
				{
					if (Animators == null)
					{
						return;
					}
					List<AnimatorEvent> animators = Animators;
					if (animators._size == 0)
					{
						return;
					}
					List<AnimatorEvent>.Enumerator enumerator2 = default(List<AnimatorEvent>.Enumerator);
					if (enumerator2.MoveNext())
					{
						AnimatorEvent animatorEvent = null;
						throw new NullReferenceException();
					}
					enumerator = (IEnumerator)(&enumerator2);
				}
				goto IL_043a;
			}
			if (StateAnimation == null)
			{
				return;
			}
			if ((object)toggle != null)
			{
				RectTransform rectTransform = toggle.RectTransform;
				UIAnimator.StopAnimations(rectTransform, AnimationType.State);
				RectTransform rectTransform2 = toggle.RectTransform;
				UIAnimator.MoveState(rectTransform2, StateAnimation, (Vector3)(&obj), null, onCompleteCallback2);
				RectTransform rectTransform3 = toggle.RectTransform;
				UIAnimator.RotateState(rectTransform3, StateAnimation, (Vector3)(&obj), null, onCompleteCallback2);
				RectTransform rectTransform4 = toggle.RectTransform;
				UIAnimator.ScaleState(rectTransform4, StateAnimation, (Vector3)(&obj), null, onCompleteCallback2);
				RectTransform rectTransform5 = toggle.RectTransform;
				UIAnimation stateAnimation = StateAnimation;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [toggle @ rdx (Doozy.Engine.UI.UIToggle)+48]");
				UIAnimator.FadeState(rectTransform5, stateAnimation, 0f, null, onCompleteCallback2);
				animation = StateAnimation;
				goto IL_0586;
			}
		}
		else
		{
			if (PunchAnimation == null)
			{
				return;
			}
			if ((object)toggle != null)
			{
				RectTransform rectTransform6 = toggle.RectTransform;
				UIAnimator.StopAnimations(rectTransform6, AnimationType.Punch);
				UIAnimation punchAnimation = PunchAnimation;
				bool flag2 = PunchAnimation == null;
				enumerator = (IEnumerator)(object)rectTransform6;
				if (!flag2)
				{
					Move move = punchAnimation.Move;
					bool flag3 = punchAnimation.Move == null;
					enumerator = (IEnumerator)(object)rectTransform6;
					if (!flag3)
					{
						bool flag4 = !move.Enabled;
						enumerator = (IEnumerator)(object)rectTransform6;
						if (!flag4)
						{
							toggle.ResetPosition();
							enumerator = (IEnumerator)toggle;
						}
						UIAnimation punchAnimation2 = PunchAnimation;
						if (PunchAnimation != null)
						{
							enumerator = (IEnumerator)punchAnimation2.Rotate;
							if (punchAnimation2.Rotate != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rcx_v17 (System.Collections.IEnumerator)+14]");
								if ((nint)0 != 0)
								{
									toggle.ResetRotation();
									enumerator = (IEnumerator)toggle;
								}
								UIAnimation punchAnimation3 = PunchAnimation;
								if (PunchAnimation != null)
								{
									enumerator = (IEnumerator)punchAnimation3.Scale;
									if (punchAnimation3.Scale != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rcx_v17 (System.Collections.IEnumerator)+14]");
										if ((nint)0 != 0)
										{
											toggle.ResetScale();
										}
										RectTransform rectTransform7 = toggle.RectTransform;
										UIAnimator.MovePunch(rectTransform7, PunchAnimation, (Vector3)(&obj), null, onCompleteCallback2);
										RectTransform rectTransform8 = toggle.RectTransform;
										UIAnimator.RotatePunch(rectTransform8, PunchAnimation, (Vector3)(&obj), null, onCompleteCallback2);
										RectTransform rectTransform9 = toggle.RectTransform;
										UIAnimator.ScalePunch(rectTransform9, PunchAnimation, (Vector3)(&obj), null, onCompleteCallback2);
										animation = PunchAnimation;
										goto IL_0586;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_051b;
		IL_043a:
		if (!withSound)
		{
			return;
		}
		if ((object)toggle != null)
		{
			Toggle toggle2 = toggle.Toggle;
			if ((object)toggle2 != null)
			{
				UIAction uIAction = (toggle2.m_IsOn ? OnToggleOn : OnToggleOff);
				if (uIAction != null)
				{
					if (uIAction.HasSound)
					{
						SoundyController soundyController = SoundyManager.Play(uIAction.SoundData);
					}
					return;
				}
			}
		}
		goto IL_051b;
		IL_051b:
		throw new NullReferenceException();
		IL_0586:
		UnityAction onCompleteCallback3 = default(UnityAction);
		IEnumerator enumerator3 = InvokeCallbacks(animation, onStartCallback, onCompleteCallback3);
		Coroutine coroutine = Coroutiner.Start(enumerator3);
		goto IL_043a;
	}

	public void Reset(UIToggleBehaviorType behaviorType)
	{
		//IL_002a: Expected F4, but got I4
		m_behaviorType = behaviorType;
		Enabled = false;
		Ready = true;
		bool flag = behaviorType == UIToggleBehaviorType.OnClick;
		float disableInterval = ((flag || flag || flag) ? 0.4f : 0f);
		DisableInterval = disableInterval;
		SelectButton = false;
		DeselectButton = false;
		ButtonAnimationType = ButtonAnimationType.Punch;
		LoadSelectedPresetAtRuntime = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998076A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PresetCategory = "Uncategorized";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998076B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PresetName = "Default";
		UIAnimation uIAnimation = null;
		uIAnimation.Reset(AnimationType.Punch);
		PunchAnimation = uIAnimation;
		UIAnimation uIAnimation2 = null;
		uIAnimation2.Reset(AnimationType.State);
		StateAnimation = uIAnimation2;
		List<AnimatorEvent> animators = new List<AnimatorEvent>();
		Animators = animators;
		TriggerEventsAfterAnimation = false;
		UIAction onToggleOn = new UIAction();
		OnToggleOn = onToggleOn;
		UIAction onToggleOff = new UIAction();
		OnToggleOff = onToggleOff;
	}

	private static IEnumerator InvokeCallbacks(UIAnimation animation, UnityAction onStartCallback, UnityAction onCompleteCallback)
	{
		_003CInvokeCallbacks_003Ed__61 obj = null;
		obj._003C_003E1__state = 0;
		obj.animation = animation;
		obj.onStartCallback = onStartCallback;
		obj.onCompleteCallback = onCompleteCallback;
		return obj;
	}

	private static IEnumerator InvokeCallbackAfterDelay(UnityAction callback, float delay)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002e: Expected O, but got I8
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_010d: Expected O, but got I4
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		_003CInvokeCallbackAfterDelay_003Ed__62 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj.callback = callback;
		if (!flag)
		{
			object obj2 = obj + 32;
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
			obj.delay = delay;
			return obj;
		}
		obj.delay = delay;
		return obj;
	}

	public static AnimationType GetAnimationType(ButtonAnimationType type)
	{
		if (type == ButtonAnimationType.Punch)
		{
			return AnimationType.Punch;
		}
		bool flag = type != ButtonAnimationType.State;
		AnimationType result = AnimationType.Undefined;
		if (!flag)
		{
			result = AnimationType.State;
		}
		return result;
	}

	public static float GetDefaultDisableInterval(UIToggleBehaviorType type)
	{
		//IL_003f: Expected F4, but got I4
		bool flag = type == UIToggleBehaviorType.OnClick;
		if (!flag && !flag && !flag)
		{
			return 0f;
		}
		return 0.4f;
	}
}
