using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you control the color of a target Text over time.")]
	[FeedbackPath("UI/Text Color")]
	[AddComponentMenu(null)]
	public class MMFeedbackTextColor : MMFeedback
	{
		public enum ColorModes
		{
			Instant = 0,
			Gradient = 1,
			Interpolate = 2
		}

		[CompilerGenerated]
		private sealed class _003CChangeColor_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMFeedbackTextColor _003C_003E4__this;

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
			public _003CChangeColor_003Ed__17(int _003C_003E1__state)
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

		[Header("Target")]
		[Tooltip(" Text component to control")]
		public Text TargetText;

		[Header("Color")]
		[Tooltip("the selected color mode :None : nothing will happen,gradient : evaluates the color over time on that gradient, from left to right,interpolate : lerps from the current color to the destination one ")]
		public ColorModes ColorMode;

		[Tooltip("how long the color of the text should change over time")]
		[MMFEnumCondition("ColorMode", new int[] { 2, 1 })]
		public float Duration;

		[Tooltip("the color to apply")]
		[MMFEnumCondition("ColorMode", new int[] { 0 })]
		public Color InstantColor;

		[Tooltip("the gradient to use to animate the color over time")]
		[GradientUsage(true)]
		[MMFEnumCondition("ColorMode", new int[] { 1 })]
		public Gradient ColorGradient;

		[MMFEnumCondition("ColorMode", new int[] { 2 })]
		[Tooltip("the destination color when in interpolate mode")]
		public Color DestinationColor;

		[Tooltip("the curve to use when interpolating towards the destination color")]
		[MMFEnumCondition("ColorMode", new int[] { 2 })]
		public AnimationCurve ColorCurve;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		protected Color _initialColor;

		protected Coroutine _coroutine;

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

		[IteratorStateMachine(typeof(_003CChangeColor_003Ed__17))]
		protected virtual IEnumerator ChangeColor()
		{
			return null;
		}

		protected virtual void SetColor(float time)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
