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
	[FeedbackHelp("This feedback will animate the target object's position over time, for the specified duration, from the chosen initial position to the chosen destination. These can either be relative Vector3 offsets from the Feedback's position, or Transforms. If you specify transforms, the Vector3 values will be ignored.")]
	[FeedbackPath("Transform/Position")]
	public class MMFeedbackPosition : MMFeedback
	{
		public enum Spaces
		{
			World = 0,
			Local = 1,
			RectTransform = 2
		}

		public enum Modes
		{
			AtoB = 0,
			AlongCurve = 1,
			ToDestination = 2
		}

		public enum TimeScales
		{
			Scaled = 0,
			Unscaled = 1
		}

		[CompilerGenerated]
		private sealed class _003CMoveAlongCurve_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMFeedbackPosition _003C_003E4__this;

			public float duration;

			public GameObject movingObject;

			public Vector3 initialPosition;

			public float intensityMultiplier;

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
			public _003CMoveAlongCurve_003Ed__36(int _003C_003E1__state)
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
		private sealed class _003CMoveFromTo_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMFeedbackPosition _003C_003E4__this;

			public float duration;

			public Vector3 pointA;

			public Vector3 pointB;

			public AnimationCurve curve;

			public GameObject movingObject;

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
			public _003CMoveFromTo_003Ed__38(int _003C_003E1__state)
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

		[Header("Position Target")]
		[Tooltip("the object this feedback will animate the position for")]
		public GameObject AnimatePositionTarget;

		[Header("Animation")]
		[Tooltip("the mode this animation should follow (either going from A to B, or moving along a curve)")]
		public Modes Mode;

		[Tooltip("whether this feedback should play in scaled or unscaled time")]
		public TimeScales TimeScale;

		[Tooltip("the space in which to move the position in")]
		public Spaces Space;

		[Tooltip("the duration of the animation on play")]
		public float AnimatePositionDuration;

		[Tooltip("the acceleration of the movement")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public AnimationCurve AnimatePositionCurve;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("the value to remap the curve's 0 value to")]
		public float RemapCurveZero;

		[Tooltip("the value to remap the curve's 1 value to")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		[FormerlySerializedAs("CurveMultiplier")]
		public float RemapCurveOne;

		[Tooltip("if this is true, the x position will be animated")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public bool AnimateX;

		[MMFCondition("AnimateX", true)]
		[Tooltip("the acceleration of the movement")]
		public AnimationCurve AnimatePositionCurveX;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("if this is true, the y position will be animated")]
		public bool AnimateY;

		[MMFCondition("AnimateY", true)]
		[Tooltip("the acceleration of the movement")]
		public AnimationCurve AnimatePositionCurveY;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("if this is true, the z position will be animated")]
		public bool AnimateZ;

		[MMFCondition("AnimateZ", true)]
		[Tooltip("the acceleration of the movement")]
		public AnimationCurve AnimatePositionCurveZ;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("if this is true, the initial position won't be added to init and destination")]
		[Header("Positions")]
		public bool RelativePosition;

		[Tooltip("if this is true, initial and destination positions will be recomputed on every play")]
		public bool DeterminePositionsOnPlay;

		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		[Tooltip("the initial position")]
		public Vector3 InitialPosition;

		[Tooltip("the destination position")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public Vector3 DestinationPosition;

		[Tooltip("the initial transform - if set, takes precedence over the Vector3 above")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Transform InitialPositionTransform;

		[Tooltip("the destination transform - if set, takes precedence over the Vector3 above")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public Transform DestinationPositionTransform;

		protected Vector3 _newPosition;

		protected RectTransform _rectTransform;

		protected Vector3 _initialPosition;

		protected Vector3 _destinationPosition;

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

		protected virtual void DeterminePositions()
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		[IteratorStateMachine(typeof(_003CMoveAlongCurve_003Ed__36))]
		protected virtual IEnumerator MoveAlongCurve(GameObject movingObject, Vector3 initialPosition, float duration, float intensityMultiplier)
		{
			return null;
		}

		protected virtual void ComputeNewCurvePosition(GameObject movingObject, Vector3 initialPosition, float percent, float intensityMultiplier)
		{
		}

		[IteratorStateMachine(typeof(_003CMoveFromTo_003Ed__38))]
		protected virtual IEnumerator MoveFromTo(GameObject movingObject, Vector3 pointA, Vector3 pointB, float duration, AnimationCurve curve = null)
		{
			return null;
		}

		protected virtual Vector3 GetPosition(Transform target)
		{
			return default(Vector3);
		}

		protected virtual void SetPosition(Transform target, Vector3 newPosition)
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
