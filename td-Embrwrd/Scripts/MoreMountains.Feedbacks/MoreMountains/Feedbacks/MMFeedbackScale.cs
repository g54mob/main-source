using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackPath("Transform/Scale")]
	[FeedbackHelp("This feedback will animate the target's scale on the 3 specified animation curves, for the specified duration (in seconds). You can apply a multiplier, that will multiply each animation curve value.")]
	public class MMFeedbackScale : MMFeedback
	{
		public enum Modes
		{
			Absolute = 0,
			Additive = 1,
			ToDestination = 2
		}

		public enum TimeScales
		{
			Scaled = 0,
			Unscaled = 1
		}

		[CompilerGenerated]
		private sealed class _003CAnimateScale_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform targetTransform;

			public AnimationCurve curveX;

			public AnimationCurve curveY;

			public AnimationCurve curveZ;

			public float duration;

			public MMFeedbackScale _003C_003E4__this;

			public Vector3 vector;

			public float remapCurveZero;

			public float remapCurveOne;

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
			public _003CAnimateScale_003Ed__29(int _003C_003E1__state)
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
		private sealed class _003CScaleToDestination_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMFeedbackScale _003C_003E4__this;

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
			public _003CScaleToDestination_003Ed__28(int _003C_003E1__state)
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

		[Tooltip("the mode this feedback should operate onAbsolute : follows the curveAdditive : adds to the current scale of the targetToDestination : sets the scale to the destination target, whatever the current scale is")]
		[Header("Scale")]
		public Modes Mode;

		[Tooltip("whether this feedback should play in scaled or unscaled time")]
		public TimeScales TimeScale;

		[Tooltip("the object to animate")]
		public Transform AnimateScaleTarget;

		[Tooltip("the duration of the animation")]
		public float AnimateScaleDuration;

		[Tooltip("the value to remap the curve's 0 value to")]
		public float RemapCurveZero;

		[FormerlySerializedAs("Multiplier")]
		[Tooltip("the value to remap the curve's 1 value to")]
		public float RemapCurveOne;

		[Tooltip("how much should be added to the curve")]
		public float Offset;

		[Tooltip("if this is true, should animate the X scale value")]
		public bool AnimateX;

		[MMFCondition("AnimateX", true)]
		[Tooltip("the x scale animation definition")]
		public AnimationCurve AnimateScaleX;

		[Tooltip("if this is true, should animate the Y scale value")]
		public bool AnimateY;

		[Tooltip("the y scale animation definition")]
		[MMFCondition("AnimateY", true)]
		public AnimationCurve AnimateScaleY;

		[Tooltip("if this is true, should animate the z scale value")]
		public bool AnimateZ;

		[Tooltip("the z scale animation definition")]
		[MMFCondition("AnimateZ", true)]
		public AnimationCurve AnimateScaleZ;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("if this is true, initial and destination scales will be recomputed on every play")]
		public bool DetermineScaleOnPlay;

		[MMFEnumCondition("Mode", new int[] { 2 })]
		[Tooltip("the scale to reach when in ToDestination mode")]
		[Header("To Destination")]
		public Vector3 DestinationScale;

		protected Vector3 _initialScale;

		protected Vector3 _newScale;

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

		protected virtual void GetInitialScale()
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		[IteratorStateMachine(typeof(_003CScaleToDestination_003Ed__28))]
		protected virtual IEnumerator ScaleToDestination()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateScale_003Ed__29))]
		protected virtual IEnumerator AnimateScale(Transform targetTransform, Vector3 vector, float duration, AnimationCurve curveX, AnimationCurve curveY, AnimationCurve curveZ, float remapCurveZero = 0f, float remapCurveOne = 1f)
		{
			return null;
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void OnDisable()
		{
		}
	}
}
