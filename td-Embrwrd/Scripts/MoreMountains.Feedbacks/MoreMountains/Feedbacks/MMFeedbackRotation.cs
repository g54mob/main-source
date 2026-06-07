using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("Transform/Rotation")]
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback will animate the target's rotation on the 3 specified animation curves (one per axis), for the specified duration (in seconds).")]
	public class MMFeedbackRotation : MMFeedback
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
		private sealed class _003CAnimateRotation_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform targetTransform;

			public AnimationCurve curveX;

			public AnimationCurve curveY;

			public AnimationCurve curveZ;

			public float duration;

			public MMFeedbackRotation _003C_003E4__this;

			public float remapZero;

			public float remapOne;

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
			public _003CAnimateRotation_003Ed__32(int _003C_003E1__state)
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
		private sealed class _003CRotateToDestination_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMFeedbackRotation _003C_003E4__this;

			private Vector3 _003CdestinationAngles_003E5__2;

			private float _003Cjourney_003E5__3;

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
			public _003CRotateToDestination_003Ed__31(int _003C_003E1__state)
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

		[Tooltip("the object whose rotation you want to animate")]
		[Header("Rotation Target")]
		public Transform AnimateRotationTarget;

		[Header("Animation")]
		[Tooltip("whether this feedback should animate in absolute values or additive")]
		public Modes Mode;

		[Tooltip("whether this feedback should play in scaled or unscaled time")]
		public TimeScales TimeScale;

		[Tooltip("whether this feedback should play on local or world rotation")]
		public Space RotationSpace;

		[Tooltip("the duration of the transition")]
		public float AnimateRotationDuration;

		[Tooltip("the value to remap the curve's 0 value to")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public float RemapCurveZero;

		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		[Tooltip("the value to remap the curve's 1 value to")]
		public float RemapCurveOne;

		[Tooltip("if this is true, should animate the X rotation")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public bool AnimateX;

		[Tooltip("how the x part of the rotation should animate over time, in degrees")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public AnimationCurve AnimateRotationX;

		[Tooltip("if this is true, should animate the X rotation")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public bool AnimateY;

		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		[Tooltip("how the y part of the rotation should animate over time, in degrees")]
		public AnimationCurve AnimateRotationY;

		[Tooltip("if this is true, should animate the X rotation")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public bool AnimateZ;

		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		[Tooltip("how the z part of the rotation should animate over time, in degrees")]
		public AnimationCurve AnimateRotationZ;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("if this is true, initial and destination rotations will be recomputed on every play")]
		public bool DetermineRotationOnPlay;

		[MMFEnumCondition("Mode", new int[] { 2 })]
		[Tooltip("the space in which the ToDestination mode should operate")]
		[Header("To Destination")]
		public Space ToDestinationSpace;

		[Tooltip("the angles to match when in ToDestination mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public Vector3 DestinationAngles;

		[Tooltip("the animation curve to use when animating to destination (individual x,y,z curves above won't be used)")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public AnimationCurve ToDestinationCurve;

		protected Quaternion _initialRotation;

		protected Vector3 _initialToDestinationAngles;

		protected Quaternion _destinationRotation;

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

		protected virtual void GetInitialRotation()
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		[IteratorStateMachine(typeof(_003CRotateToDestination_003Ed__31))]
		protected virtual IEnumerator RotateToDestination()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateRotation_003Ed__32))]
		protected virtual IEnumerator AnimateRotation(Transform targetTransform, Vector3 vector, float duration, AnimationCurve curveX, AnimationCurve curveY, AnimationCurve curveZ, float remapZero, float remapOne)
		{
			return null;
		}

		protected virtual void ApplyRotation(Transform targetTransform, float remapZero, float remapOne, AnimationCurve curveX, AnimationCurve curveY, AnimationCurve curveZ, float percent)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void OnDisable()
		{
		}
	}
}
