using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Doozy.Engine.Events;
using Doozy.Engine.UI.Animation;
using Doozy.Engine.UI.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.UI
{
	[Serializable]
	public class UIButtonBehavior
	{
		[CompilerGenerated]
		private sealed class _003CInvokeCallbacks_003Ed__63 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIAnimation animation;

			public UnityAction onStartCallback;

			public UnityAction onCompleteCallback;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CInvokeCallbacks_003Ed__63(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
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

		[SerializeField]
		private UIButtonBehaviorType m_behaviorType;

		public static string DefaultPresetCategory => null;

		public static string DefaultPresetName => null;

		public int AnimatorsCount => 0;

		public UIButtonBehaviorType BehaviorType => default(UIButtonBehaviorType);

		public bool HasAnimation => false;

		public bool HasAnimators => false;

		public bool HasAnimatorEvents => false;

		public bool HasEffect => false;

		public bool HasGameEvents => false;

		public bool HasPunchAnimation => false;

		public bool HasSound => false;

		public bool HasStateAnimation => false;

		public bool HasUnityEvents => false;

		public UIButtonBehavior(UIButtonBehaviorType behaviorType, bool enabled = false)
		{
		}

		public float GetAnimationTotalDuration()
		{
			return 0f;
		}

		public void LoadPreset()
		{
		}

		public void LoadPreset(string presetCategory, string presetName)
		{
		}

		public void PlayAnimation(UIButton button, bool withSound = true, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
		{
		}

		public void Reset(UIButtonBehaviorType behaviorType)
		{
		}

		[IteratorStateMachine(typeof(_003CInvokeCallbacks_003Ed__63))]
		private static IEnumerator InvokeCallbacks(UIAnimation animation, UnityAction onStartCallback, UnityAction onCompleteCallback)
		{
			return null;
		}

		public static AnimationType GetAnimationType(ButtonAnimationType type)
		{
			return default(AnimationType);
		}

		public static float GetDefaultDisableInterval(UIButtonBehaviorType type)
		{
			return 0f;
		}
	}
}
