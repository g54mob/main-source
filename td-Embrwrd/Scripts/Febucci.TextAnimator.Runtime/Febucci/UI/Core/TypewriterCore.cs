using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Febucci.UI.Core.Parsing;
using UnityEngine;
using UnityEngine.Events;

namespace Febucci.UI.Core
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(TAnimCore))]
	public abstract class TypewriterCore : MonoBehaviour
	{
		[Flags]
		public enum StartTypewriterMode
		{
			FromScriptOnly = 0,
			OnEnable = 1,
			OnShowText = 2,
			AutomaticallyFromAllEvents = 3
		}

		public enum DisappearanceOrientation
		{
			SameAsTypewriter = 0,
			Inverted = 1
		}

		[CompilerGenerated]
		private sealed class _003CHideTextRoutine_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TypewriterCore _003C_003E4__this;

			private TypingInfo _003CtypingInfo_003E5__2;

			private int _003Ci_003E5__3;

			private float _003CtimeToWait_003E5__4;

			private float _003CdeltaTime_003E5__5;

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
			public _003CHideTextRoutine_003Ed__38(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CShowTextRoutine_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TypewriterCore _003C_003E4__this;

			private TypingInfo _003CtypingInfo_003E5__2;

			private bool _003CactionsEnabled_003E5__3;

			private int _003Ci_003E5__4;

			private float _003CtimeToWait_003E5__5;

			private float _003CdeltaTime_003E5__6;

			private int _003CmaxIndex_003E5__7;

			private int _003Ca_003E5__8;

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
			public _003CShowTextRoutine_003Ed__27(int _003C_003E1__state)
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

		private TAnimCore _textAnimator;

		[Tooltip("True if you want to shows the text dynamically")]
		[SerializeField]
		public bool useTypeWriter;

		[SerializeField]
		[Tooltip("Controls from which method(s) the typewriter will automatically start/resume. Default is 'Automatic'")]
		public StartTypewriterMode startTypewriterMode;

		[SerializeField]
		private bool hideAppearancesOnSkip;

		[Tooltip("True = plays all remaining events once the typewriter has been skipped")]
		[SerializeField]
		private bool triggerEventsOnSkip;

		[Tooltip("True = resets the typewriter speed every time a new text is set/shown")]
		[SerializeField]
		public bool resetTypingSpeedAtStartup;

		[SerializeField]
		public DisappearanceOrientation disappearanceOrientation;

		public UnityEvent onTextShowed;

		public UnityEvent onTypewriterStart;

		public UnityEvent onTextDisappeared;

		public CharacterEvent onCharacterVisible;

		public MessageEvent onMessage;

		private Coroutine showRoutine;

		private Coroutine nestedActionRoutine;

		private Coroutine hideRoutine;

		private Coroutine nestedHideRoutine;

		private float internalSpeed;

		private int latestActionTriggered;

		private int latestEventTriggered;

		public TAnimCore TextAnimator => null;

		public bool isShowingText { get; private set; }

		public bool isHidingText { get; private set; }

		[Obsolete("Please set the speed through 'SetTypewriterSpeed' method instead")]
		protected float typewriterPlayerSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Obsolete("Please skip the typewriter via the 'SkipTypewriter' method instead")]
		protected bool wantsToSkip
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Please use 'isShowingText' instead")]
		protected bool isBaseInsideRoutine => false;

		[Obsolete("Please use 'TextAnimator' instead")]
		public TAnimCore textAnimator => null;

		public void ShowText(string text)
		{
		}

		public void SkipTypewriter()
		{
		}

		public void StartShowingText(bool restart = false)
		{
		}

		protected abstract float GetWaitAppearanceTimeOf(int charIndex);

		private float GetDeltaTime(TypingInfo typingInfo)
		{
			return 0f;
		}

		[IteratorStateMachine(typeof(_003CShowTextRoutine_003Ed__27))]
		private IEnumerator ShowTextRoutine()
		{
			return null;
		}

		public void StopShowingText()
		{
		}

		[ContextMenu("Start Disappearing Text")]
		public void StartDisappearingText()
		{
		}

		[ContextMenu("Stop Disappearing Text")]
		public void StopDisappearingText()
		{
		}

		protected virtual float GetWaitDisappearanceTimeOf(int charIndex)
		{
			return 0f;
		}

		[IteratorStateMachine(typeof(_003CHideTextRoutine_003Ed__38))]
		private IEnumerator HideTextRoutine()
		{
			return null;
		}

		public void SetTypewriterSpeed(float value)
		{
		}

		private void TriggerEventsBeforeAction(int maxIndex, ActionMarker action)
		{
		}

		private void TriggerEventsUntil(int maxIndex)
		{
		}

		public void TriggerRemainingEvents()
		{
		}

		public void TriggerVisibleEvents()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}
	}
}
