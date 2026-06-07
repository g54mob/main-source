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
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback will let you control the texture scale of a target UI Image over time.")]
	[FeedbackPath("UI/Image Texture Scale")]
	public class MMF_ImageTextureScale : MMF_Feedback
	{
		public enum Modes
		{
			OverTime = 0,
			Instant = 1
		}

		public enum MaterialPropertyTypes
		{
			Main = 0,
			TextureID = 1
		}

		[CompilerGenerated]
		private sealed class _003CTransitionCo_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MMF_ImageTextureScale _003C_003E4__this;

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
			public _003CTransitionCo_003Ed__28(int _003C_003E1__state)
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

		[Tooltip("the UI Image on which to change texture scale on")]
		[MMFInspectorGroup("Texture Scale", true, 63, true, false)]
		public Image TargetImage;

		[Tooltip("whether to target the main texture property, or one specified in MaterialPropertyName")]
		public MaterialPropertyTypes MaterialPropertyType;

		[MMEnumCondition("MaterialPropertyType", new int[] { 1 })]
		[Tooltip("the property name, for example _MainTex_ST, or _MainTex if you don't have UseMaterialPropertyBlocks set to true")]
		public string MaterialPropertyName;

		[Tooltip("whether the feedback should affect the material instantly or over a period of time")]
		public Modes Mode;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("how long the material should change over time")]
		public float Duration;

		[Tooltip("whether or not the values should be relative")]
		public bool RelativeValues;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[MMFInspectorGroup("Intensity", true, 65, false, false)]
		[Tooltip("the curve to tween the scale on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public AnimationCurve ScaleCurve;

		[Tooltip("the value to remap the scale curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Vector2 RemapZero;

		[Tooltip("the value to remap the scale curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Vector2 RemapOne;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("the value to move the intensity to in instant mode")]
		public Vector2 InstantScale;

		protected Vector2 _initialValue;

		protected Coroutine _coroutine;

		protected Vector2 _newValue;

		protected Material _material;

		public override bool HasRandomness => false;

		public override bool HasAutomatedTargetAcquisition => false;

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

		protected override void AutomateTargetAcquisition()
		{
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		[IteratorStateMachine(typeof(_003CTransitionCo_003Ed__28))]
		protected virtual IEnumerator TransitionCo(float intensityMultiplier)
		{
			return null;
		}

		protected virtual void SetMaterialValues(float time, float intensityMultiplier)
		{
		}

		protected virtual void ApplyValue(Vector2 newValue)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
