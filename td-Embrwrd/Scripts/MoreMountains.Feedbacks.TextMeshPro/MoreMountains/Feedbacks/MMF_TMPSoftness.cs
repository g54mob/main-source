using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MoreMountains.Tools;
using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("TextMesh Pro/TMP Softness")]
	[FeedbackHelp("This feedback lets you tweak the softness of a TMP text over time.")]
	[AddComponentMenu(null)]
	public class MMF_TMPSoftness : MMF_Feedback
	{
		[CompilerGenerated]
		private sealed class _003CApplyValueOverTime_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMF_TMPSoftness _003C_003E4__this;

			private float _003Cjourney_003E5__2;

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
			public _003CApplyValueOverTime_003Ed__22(int _003C_003E1__state)
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

		[MMFInspectorGroup("Target", true, 12, true, false)]
		[Tooltip("the TMP_Text component to control")]
		public TMP_Text TargetTMPText;

		[MMFInspectorGroup("Softness", true, 13, false, false)]
		[Tooltip("whether or not values should be relative")]
		public bool RelativeValues;

		[Tooltip("the selected mode")]
		public MMFeedbackBase.Modes Mode;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the duration of the feedback, in seconds")]
		public float Duration;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the curve to tween on")]
		public MMTweenType SoftnessCurve;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapOne;

		[Tooltip("the value to move to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantSoftness;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		protected float _initialSoftness;

		protected Coroutine _coroutine;

		public override bool HasCustomInspectors => false;

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

		public override bool HasAutomatedTargetAcquisition => false;

		protected override void AutomateTargetAcquisition()
		{
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		[IteratorStateMachine(typeof(_003CApplyValueOverTime_003Ed__22))]
		protected virtual IEnumerator ApplyValueOverTime()
		{
			return null;
		}

		protected virtual void SetValue(float time)
		{
		}

		protected override void CustomRestoreInitialValues()
		{
		}
	}
}
