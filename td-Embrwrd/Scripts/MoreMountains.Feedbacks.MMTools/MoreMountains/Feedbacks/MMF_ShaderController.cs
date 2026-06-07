using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you trigger a one time play on a target ShaderController.")]
	[FeedbackPath("Renderer/ShaderController")]
	public class MMF_ShaderController : MMF_Feedback
	{
		public enum Modes
		{
			OneTime = 0,
			ToDestination = 1
		}

		public static bool FeedbackTypeAuthorized;

		[MMFInspectorGroup("Shader Controller", true, 37, true, false)]
		[Tooltip("the mode this controller is in")]
		public Modes Mode;

		[Tooltip("the float controller to trigger a one time play on")]
		public ShaderController TargetShaderController;

		[Tooltip("an optional list of float controllers to trigger a one time play on")]
		public List<ShaderController> TargetShaderControllerList;

		[Tooltip("whether this should revert to original at the end")]
		public bool RevertToInitialValueAfterEnd;

		[Tooltip("the duration of the One Time shake")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float OneTimeDuration;

		[Tooltip("the amplitude of the One Time shake (this will be multiplied by the curve's height)")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float OneTimeAmplitude;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the low value to remap the normalized curve value to")]
		public float OneTimeRemapMin;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the high value to remap the normalized curve value to")]
		public float OneTimeRemapMax;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the curve to apply to the one time shake")]
		public AnimationCurve OneTimeCurve;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("the new value towards which to move the current value")]
		public float ToDestinationValue;

		[Tooltip("the duration over which to interpolate the target value")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float ToDestinationDuration;

		[Tooltip("the color to aim for (when targetting a Color property")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public Color ToDestinationColor;

		[Tooltip("the curve over which to interpolate the value")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public AnimationCurve ToDestinationCurve;

		protected float _oneTimeDurationStorage;

		protected float _oneTimeAmplitudeStorage;

		protected float _oneTimeRemapMinStorage;

		protected float _oneTimeRemapMaxStorage;

		protected AnimationCurve _oneTimeCurveStorage;

		protected float _toDestinationValueStorage;

		protected float _toDestinationDurationStorage;

		protected AnimationCurve _toDestinationCurveStorage;

		protected bool _revertToInitialValueAfterEndStorage;

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

		protected virtual void PerformPlay(ShaderController shaderController, float intensityMultiplier)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomReset()
		{
		}

		protected virtual void PerformReset(ShaderController shaderController)
		{
		}

		protected override void CustomRestoreInitialValues()
		{
		}
	}
}
