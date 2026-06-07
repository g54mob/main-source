using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("TextMesh Pro/TMP Text Reveal")]
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback will let you reveal words, lines, or characters in a target TMP, one at a time")]
	public class MMFeedbackTMPTextReveal : MMFeedback
	{
		public enum RevealModes
		{
			Character = 0,
			Lines = 1,
			Words = 2
		}

		public enum DurationModes
		{
			Interval = 0,
			TotalDuration = 1
		}

		[CompilerGenerated]
		private sealed class _003CRevealCharacters_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMFeedbackTMPTextReveal _003C_003E4__this;

			private float _003CstartTime_003E5__2;

			private int _003CtotalCharacters_003E5__3;

			private int _003CvisibleCharacters_003E5__4;

			private float _003ClastCharAt_003E5__5;

			private float _003CdeltaTime_003E5__6;

			private float _003Ctime_003E5__7;

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
			public _003CRevealCharacters_003Ed__17(int _003C_003E1__state)
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
		private sealed class _003CRevealLines_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMFeedbackTMPTextReveal _003C_003E4__this;

			private int _003CtotalLines_003E5__2;

			private int _003CvisibleLines_003E5__3;

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
			public _003CRevealLines_003Ed__18(int _003C_003E1__state)
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
		private sealed class _003CRevealWords_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMFeedbackTMPTextReveal _003C_003E4__this;

			private int _003CtotalWords_003E5__2;

			private int _003CvisibleWords_003E5__3;

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
			public _003CRevealWords_003Ed__19(int _003C_003E1__state)
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

		public static bool FeedbackTypeAuthorized;

		[Tooltip("the target TMP_Text component we want to change the text on")]
		[Header("TextMesh Pro")]
		public TMP_Text TargetTMPText;

		[Header("Change Text")]
		[Tooltip("whether or not to replace the current TMP target's text on play")]
		public bool ReplaceText;

		[Tooltip("the new text to replace the old one with")]
		[TextArea]
		public string NewText;

		[Tooltip("the selected way to reveal the text (character by character, word by word, or line by line)")]
		[Header("Reveal")]
		public RevealModes RevealMode;

		[Tooltip("whether to define duration by the time interval between two unit reveals, or by the total duration the reveal should take")]
		public DurationModes DurationMode;

		[Tooltip("the interval (in seconds) between two reveals")]
		[MMFEnumCondition("DurationMode", new int[] { 0 })]
		public float IntervalBetweenReveals;

		[Tooltip("the total duration of the text reveal, in seconds")]
		[MMFEnumCondition("DurationMode", new int[] { 1 })]
		public float RevealDuration;

		protected float _delay;

		protected Coroutine _coroutine;

		protected int _richTextLength;

		public override float FeedbackDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		[IteratorStateMachine(typeof(_003CRevealCharacters_003Ed__17))]
		protected virtual IEnumerator RevealCharacters()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRevealLines_003Ed__18))]
		protected virtual IEnumerator RevealLines()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRevealWords_003Ed__19))]
		protected virtual IEnumerator RevealWords()
		{
			return null;
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected int RichTextLength(string richText)
		{
			return 0;
		}
	}
}
