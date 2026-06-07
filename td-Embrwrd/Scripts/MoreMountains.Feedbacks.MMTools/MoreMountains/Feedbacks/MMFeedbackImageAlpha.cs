using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback will let you change the alpha of a target Image over time.")]
	[FeedbackPath("UI/Image Alpha")]
	[AddComponentMenu(null)]
	public class MMFeedbackImageAlpha : MMFeedback
	{
		public enum Modes
		{
			OverTime = 0,
			Instant = 1,
			ToDestination = 2
		}

		[CompilerGenerated]
		private sealed class _003CImageSequence_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMFeedbackImageAlpha _003C_003E4__this;

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
			public _003CImageSequence_003Ed__19(int _003C_003E1__state)
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

		[Header("Sprite Renderer")]
		[Tooltip("the Image to affect when playing the feedback")]
		public Image BoundImage;

		[Tooltip("whether the feedback should affect the Image instantly or over a period of time")]
		public Modes Mode;

		[Tooltip("how long the Image should change over time")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public float Duration;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Header("Alpha")]
		[Tooltip("the alpha to move to in instant mode")]
		public float InstantAlpha;

		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		[Tooltip("the curve to use when interpolating towards the destination alpha")]
		public MMTweenType Curve;

		[Tooltip("the value to which the curve's 0 should be remapped")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float CurveRemapZero;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to which the curve's 1 should be remapped")]
		public float CurveRemapOne;

		[Tooltip("the alpha to aim towards when in ToDestination mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public float DestinationAlpha;

		protected Coroutine _coroutine;

		protected Color _imageColor;

		protected float _initialAlpha;

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

		protected override void CustomInitialization(GameObject owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		[IteratorStateMachine(typeof(_003CImageSequence_003Ed__19))]
		protected virtual IEnumerator ImageSequence()
		{
			return null;
		}

		protected virtual void SetAlpha(float time)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void Turn(bool status)
		{
		}
	}
}
