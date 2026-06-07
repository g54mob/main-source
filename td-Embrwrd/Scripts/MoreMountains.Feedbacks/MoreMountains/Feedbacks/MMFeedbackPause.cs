using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback will cause a pause when met, preventing any other feedback lower in the sequence to run until it's complete.")]
	[AddComponentMenu(null)]
	[FeedbackPath("Pause/Pause")]
	public class MMFeedbackPause : MMFeedback
	{
		[CompilerGenerated]
		private sealed class _003CPlayPause_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMFeedbackPause _003C_003E4__this;

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
			public _003CPlayPause_003Ed__17(int _003C_003E1__state)
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

		[Tooltip("the duration of the pause, in seconds")]
		[Header("Pause")]
		public float PauseDuration;

		public bool RandomizePauseDuration;

		[MMFCondition("RandomizePauseDuration", true)]
		public float MinPauseDuration;

		[MMFCondition("RandomizePauseDuration", true)]
		public float MaxPauseDuration;

		[MMFCondition("RandomizePauseDuration", true)]
		public bool RandomizeOnEachPlay;

		[Tooltip("if this is true, you'll need to call the Resume() method on the host MMFeedbacks for this pause to stop, and the rest of the sequence to play")]
		public bool ScriptDriven;

		[Tooltip("if this is true, a script driven pause will resume after its AutoResumeAfter delay, whether it has been manually resumed or not")]
		[MMFCondition("ScriptDriven", true)]
		public bool AutoResume;

		[MMFCondition("AutoResume", true)]
		[Tooltip("the duration after which to auto resume, regardless of manual resume calls beforehand")]
		public float AutoResumeAfter;

		public override IEnumerator Pause => null;

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

		protected virtual IEnumerator PauseWait()
		{
			return null;
		}

		protected override void CustomInitialization(GameObject owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		[IteratorStateMachine(typeof(_003CPlayPause_003Ed__17))]
		protected virtual IEnumerator PlayPause()
		{
			return null;
		}
	}
}
