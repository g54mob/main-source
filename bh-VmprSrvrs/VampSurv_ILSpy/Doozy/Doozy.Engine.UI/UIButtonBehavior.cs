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

namespace Doozy.Engine.UI;

[Serializable]
public class UIButtonBehavior
{
	private sealed class _003CInvokeCallbacks_003Ed__63(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
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

	public const float ON_DOUBLE_CLICK_DISABLE_INTERVAL = 0.2f;

	public const float ON_LONG_CLICK_DISABLE_INTERVAL = 0.2f;

	public const float ON_POINTER_DOWN_DISABLE_INTERVAL = 0f;

	public const float ON_POINTER_ENTER_DISABLE_INTERVAL = 0.4f;

	public const float ON_POINTER_EXIT_DISABLE_INTERVAL = 0.4f;

	public const float ON_POINTER_UP_DISABLE_INTERVAL = 0f;

	public List<AnimatorEvent> Animators;

	public ButtonAnimationType ButtonAnimationType;

	public bool DeselectButton;

	public float DisableInterval;

	public bool Enabled;

	public bool LoadSelectedPresetAtRuntime;

	public UIAction OnTrigger;

	public string PresetCategory;

	public string PresetName;

	public UIAnimation PunchAnimation;

	public bool Ready;

	public bool SelectButton;

	public UIAnimation StateAnimation;

	public bool TriggerEventsAfterAnimation;

	private UIButtonBehaviorType m_behaviorType;

	public static string DefaultPresetCategory
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980672]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980673]");
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

	public UIButtonBehaviorType BehaviorType => m_behaviorType;

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
			//IL_00f2: Expected I4, but got O
			UIAction onTrigger = OnTrigger;
			if (OnTrigger != null)
			{
				if (onTrigger.AnimatorEvents == null)
				{
					return false;
				}
				List<AnimatorEvent> animatorEvents = onTrigger.AnimatorEvents;
				if (onTrigger.AnimatorEvents != null)
				{
					int num = animatorEvents._size ^ animatorEvents._size;
					int num2 = animatorEvents._size & num;
					bool flag = num2 < 0;
					bool flag2 = animatorEvents._size < 0;
					bool flag3 = animatorEvents._size == 0;
					bool flag4 = flag2 == flag;
					bool flag5 = !flag3;
					return flag5 & flag4;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasEffect
	{
		get
		{
			//IL_0041: Expected I4, but got O
			if (OnTrigger != null)
			{
				return OnTrigger.HasEffect;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool HasGameEvents
	{
		get
		{
			//IL_00f2: Expected I4, but got O
			UIAction onTrigger = OnTrigger;
			if (OnTrigger != null)
			{
				if (onTrigger.GameEvents == null)
				{
					return false;
				}
				List<string> gameEvents = onTrigger.GameEvents;
				if (onTrigger.GameEvents != null)
				{
					int num = gameEvents._size ^ gameEvents._size;
					int num2 = gameEvents._size & num;
					bool flag = num2 < 0;
					bool flag2 = gameEvents._size < 0;
					bool flag3 = gameEvents._size == 0;
					bool flag4 = flag2 == flag;
					bool flag5 = !flag3;
					return flag5 & flag4;
				}
			}
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
			//IL_0041: Expected I4, but got O
			if (OnTrigger != null)
			{
				return OnTrigger.HasSound;
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
			//IL_012e: Expected I4, but got O
			UIAction onTrigger = OnTrigger;
			if (OnTrigger != null)
			{
				if (onTrigger.Event == null)
				{
					return false;
				}
				UnityEvent unityEvent = onTrigger.Event;
				UnityEngine.Events.PersistentCallGroup persistentCalls = ((UnityEventBase)unityEvent).m_PersistentCalls;
				if (((UnityEventBase)unityEvent).m_PersistentCalls != null)
				{
					List<UnityEngine.Events.PersistentCall> calls = persistentCalls.m_Calls;
					if (persistentCalls.m_Calls != null)
					{
						int num = calls._size ^ calls._size;
						int num2 = calls._size & num;
						bool flag = num2 < 0;
						bool flag2 = calls._size < 0;
						bool flag3 = calls._size == 0;
						bool flag4 = flag2 == flag;
						bool flag5 = !flag3;
						return flag5 & flag4;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public UIButtonBehavior(UIButtonBehaviorType behaviorType, bool enabled = false)
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

	public unsafe void PlayAnimation(UIButton button, bool withSound = true, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
	{
		//IL_04d7: Expected O, but got I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0156: Expected O, but got Ref
		//IL_0181: Expected O, but got Ref
		//IL_01ac: Expected O, but got Ref
		//IL_01de: Expected F4, but got I
		//IL_00c5: Expected O, but got Ref
		//IL_03da: Expected O, but got Ref
		//IL_0405: Expected O, but got Ref
		//IL_0430: Expected O, but got Ref
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
				goto IL_043f;
			}
			if (StateAnimation == null)
			{
				return;
			}
			if ((object)button != null)
			{
				RectTransform rectTransform = button.RectTransform;
				UIAnimator.StopAnimations(rectTransform, AnimationType.State);
				RectTransform rectTransform2 = button.RectTransform;
				UIAnimator.MoveState(rectTransform2, StateAnimation, (Vector3)(&obj), null, onCompleteCallback2);
				RectTransform rectTransform3 = button.RectTransform;
				UIAnimator.RotateState(rectTransform3, StateAnimation, (Vector3)(&obj), null, onCompleteCallback2);
				RectTransform rectTransform4 = button.RectTransform;
				UIAnimator.ScaleState(rectTransform4, StateAnimation, (Vector3)(&obj), null, onCompleteCallback2);
				RectTransform rectTransform5 = button.RectTransform;
				UIAnimation stateAnimation = StateAnimation;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [button @ rdx (Doozy.Engine.UI.UIButton)+48]");
				UIAnimator.FadeState(rectTransform5, stateAnimation, 0f, null, onCompleteCallback2);
				animation = StateAnimation;
				goto IL_052c;
			}
		}
		else
		{
			if (PunchAnimation == null)
			{
				return;
			}
			if ((object)button != null)
			{
				RectTransform rectTransform6 = button.RectTransform;
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
							button.ResetPosition();
							enumerator = (IEnumerator)button;
						}
						UIAnimation punchAnimation2 = PunchAnimation;
						if (PunchAnimation != null)
						{
							enumerator = (IEnumerator)punchAnimation2.Rotate;
							if (punchAnimation2.Rotate != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rcx_v16 (System.Collections.IEnumerator)+14]");
								if ((nint)0 != 0)
								{
									button.ResetRotation();
									enumerator = (IEnumerator)button;
								}
								UIAnimation punchAnimation3 = PunchAnimation;
								if (PunchAnimation != null)
								{
									enumerator = (IEnumerator)punchAnimation3.Scale;
									if (punchAnimation3.Scale != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rcx_v16 (System.Collections.IEnumerator)+14]");
										if ((nint)0 != 0)
										{
											button.ResetScale();
										}
										RectTransform rectTransform7 = button.RectTransform;
										UIAnimator.MovePunch(rectTransform7, PunchAnimation, (Vector3)(&obj), null, onCompleteCallback2);
										RectTransform rectTransform8 = button.RectTransform;
										UIAnimator.RotatePunch(rectTransform8, PunchAnimation, (Vector3)(&obj), null, onCompleteCallback2);
										RectTransform rectTransform9 = button.RectTransform;
										UIAnimator.ScalePunch(rectTransform9, PunchAnimation, (Vector3)(&obj), null, onCompleteCallback2);
										animation = PunchAnimation;
										goto IL_052c;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_04c1;
		IL_043f:
		if (!withSound)
		{
			return;
		}
		UIAction onTrigger = OnTrigger;
		if (OnTrigger != null)
		{
			if (OnTrigger.HasSound)
			{
				SoundyController soundyController = SoundyManager.Play(onTrigger.SoundData);
			}
			return;
		}
		goto IL_04c1;
		IL_052c:
		UnityAction onCompleteCallback3 = default(UnityAction);
		IEnumerator enumerator3 = InvokeCallbacks(animation, onStartCallback, onCompleteCallback3);
		Coroutine coroutine = Coroutiner.Start(enumerator3);
		goto IL_043f;
		IL_04c1:
		throw new NullReferenceException();
	}

	public void Reset(UIButtonBehaviorType behaviorType)
	{
		//IL_0114: Expected O, but got I8
		//IL_001f: Expected O, but got I8
		m_behaviorType = behaviorType;
		object obj = 6442450944L;
		Enabled = false;
		Ready = true;
		if (behaviorType <= UIButtonBehaviorType.OnDeselected)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rsi_v1+2B9E49C+behaviorType @ rdx (Doozy.Engine.UI.UIButtonBehaviorType)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ rcx_v39 (should have been resolved before IL gen)");
		}
		else
		{
			DisableInterval = 0f;
			SelectButton = false;
			DeselectButton = false;
			ButtonAnimationType = ButtonAnimationType.Punch;
			LoadSelectedPresetAtRuntime = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980672]");
			if ((nint)0 != 0)
			{
				goto IL_01b6;
			}
		}
		_ = 1;
		goto IL_01b6;
		IL_01b6:
		PresetCategory = "Uncategorized";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980673]");
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
		UIAction onTrigger = new UIAction();
		OnTrigger = onTrigger;
	}

	private static IEnumerator InvokeCallbacks(UIAnimation animation, UnityAction onStartCallback, UnityAction onCompleteCallback)
	{
		_003CInvokeCallbacks_003Ed__63 obj = null;
		obj._003C_003E1__state = 0;
		obj.animation = animation;
		obj.onStartCallback = onStartCallback;
		obj.onCompleteCallback = onCompleteCallback;
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

	public static float GetDefaultDisableInterval(UIButtonBehaviorType type)
	{
		//IL_0054: Expected F4, but got I4
		//IL_002a: Expected O, but got I8
		//IL_0044: Expected O, but got I8
		if (type <= UIButtonBehaviorType.OnDeselected)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rdx_v1+2B9E674+type @ rcx (Doozy.Engine.UI.UIButtonBehaviorType)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ rcx_v2 (should have been resolved before IL gen)");
		}
		return 0f;
	}
}
