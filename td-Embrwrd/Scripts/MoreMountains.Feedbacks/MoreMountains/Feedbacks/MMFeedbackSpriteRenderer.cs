using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("Renderer/SpriteRenderer")]
	[FeedbackHelp("This feedback will let you change the color of a target sprite renderer over time, and flip it on X or Y. You can also use it to command one or many MMSpriteRendererShakers.")]
	[AddComponentMenu(null)]
	public class MMFeedbackSpriteRenderer : MMFeedback
	{
		public enum Modes
		{
			OverTime = 0,
			Instant = 1,
			ShakerEvent = 2,
			ToDestinationColor = 3,
			ToDestinationColorAndBack = 4
		}

		public enum InitialColorModes
		{
			InitialColorOnInit = 0,
			InitialColorOnPlay = 1
		}

		[CompilerGenerated]
		private sealed class _003CSpriteRendererSequence_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMFeedbackSpriteRenderer _003C_003E4__this;

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
			public _003CSpriteRendererSequence_003Ed__29(int _003C_003E1__state)
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
		private sealed class _003CSpriteRendererToDestinationSequence_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMFeedbackSpriteRenderer _003C_003E4__this;

			public bool andBack;

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
			public _003CSpriteRendererToDestinationSequence_003Ed__30(int _003C_003E1__state)
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
		[Tooltip("the SpriteRenderer to affect when playing the feedback")]
		public SpriteRenderer BoundSpriteRenderer;

		[Tooltip("whether the feedback should affect the sprite renderer instantly or over a period of time")]
		public Modes Mode;

		[Tooltip("how long the sprite renderer should change over time")]
		[MMFEnumCondition("Mode", new int[] { 0, 2, 3, 4 })]
		public float Duration;

		[Tooltip("whether or not that sprite renderer should be turned off on start")]
		public bool StartsOff;

		[MMFEnumCondition("Mode", new int[] { 2 })]
		[Tooltip("the channel to broadcast on")]
		public int Channel;

		[MMFEnumCondition("Mode", new int[] { 2 })]
		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public bool ResetTargetValuesAfterShake;

		[Tooltip("whether or not to broadcast a range to only affect certain shakers")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public bool UseRange;

		[MMFEnumCondition("Mode", new int[] { 2 })]
		[Tooltip("the range of the event, in units")]
		public float EventRange;

		[Tooltip("the transform to use to broadcast the event as origin point")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public Transform EventOriginTransform;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("whether to grab the initial color to (potentially) go back to at init or when the feedback plays")]
		public InitialColorModes InitialColorMode;

		[Header("Color")]
		[Tooltip("whether or not to modify the color of the sprite renderer")]
		public bool ModifyColor;

		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		[Tooltip("the colors to apply to the sprite renderer over time")]
		public Gradient ColorOverTime;

		[MMFEnumCondition("Mode", new int[] { 1, 2 })]
		[Tooltip("the color to move to in instant mode")]
		public Color InstantColor;

		[Tooltip("the color to move to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1, 3, 4 })]
		public Color ToDestinationColor;

		[Tooltip("the color to move to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1, 3, 4 })]
		public AnimationCurve ToDestinationColorCurve;

		[Header("Flip")]
		[Tooltip("whether or not to flip the sprite on X")]
		public bool FlipX;

		[Tooltip("whether or not to flip the sprite on Y")]
		public bool FlipY;

		protected Coroutine _coroutine;

		protected Color _initialColor;

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

		[IteratorStateMachine(typeof(_003CSpriteRendererSequence_003Ed__29))]
		protected virtual IEnumerator SpriteRendererSequence()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSpriteRendererToDestinationSequence_003Ed__30))]
		protected virtual IEnumerator SpriteRendererToDestinationSequence(bool andBack)
		{
			return null;
		}

		protected virtual void Flip()
		{
		}

		protected virtual void SetSpriteRendererValues(float time)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void Turn(bool status)
		{
		}

		protected virtual void OnDisable()
		{
		}
	}
}
