using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("GameObject/Property")]
	[FeedbackHelp("This feedback will let you target (almost) any property, on any object in your scene. It also works on scriptable objects. Drag an object, select a property, and setup your feedback to update that property over time.")]
	[AddComponentMenu(null)]
	public class MMFeedbackProperty : MMFeedback
	{
		public enum Modes
		{
			OverTime = 0,
			Instant = 1
		}

		[CompilerGenerated]
		private sealed class _003CUpdateValueSequence_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMFeedbackProperty _003C_003E4__this;

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
			public _003CUpdateValueSequence_003Ed__18(int _003C_003E1__state)
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

		[Header("Target Property")]
		[Tooltip("the receiver to write the level to")]
		public MMPropertyReceiver Target;

		[Tooltip("whether the feedback should affect the target property instantly or over a period of time")]
		[Header("Mode")]
		public Modes Mode;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("how long the target property should change over time")]
		public float Duration;

		[Tooltip("whether or not that target property should be turned off on start")]
		public bool StartsOff;

		[Tooltip("whether or not the values should be relative or not")]
		public bool RelativeValues;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("the curve to tween the intensity on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Header("Level")]
		public MMTweenType LevelCurve;

		[Tooltip("the value to remap the intensity curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapLevelZero;

		[Tooltip("the value to remap the intensity curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapLevelOne;

		[Tooltip("the value to move the intensity to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantLevel;

		protected float _initialIntensity;

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

		[IteratorStateMachine(typeof(_003CUpdateValueSequence_003Ed__18))]
		protected virtual IEnumerator UpdateValueSequence(float intensityMultiplier)
		{
			return null;
		}

		protected virtual void SetValues(float time, float intensityMultiplier)
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
