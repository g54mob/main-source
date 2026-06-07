using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMGlobalPostProcessingVolumeAutoBlend")]
	public class MMGlobalPostProcessingVolumeAutoBlend : MonoBehaviour
	{
		public enum TimeScales
		{
			Scaled = 0,
			Unscaled = 1
		}

		public enum BlendTriggerModes
		{
			OnEnable = 0,
			Script = 1
		}

		[Header("Blend")]
		[Tooltip("the trigger mode for this MMGlobalPostProcessingVolumeAutoBlend")]
		public BlendTriggerModes BlendTriggerMode;

		[Tooltip("the duration of the blend (in seconds)")]
		public float BlendDuration;

		[Tooltip("the curve to use to blend")]
		public AnimationCurve Curve;

		[Header("Weight")]
		[Range(0f, 1f)]
		[Tooltip("the weight at the start of the blend")]
		public float InitialWeight;

		[Range(0f, 1f)]
		[Tooltip("the desired weight at the end of the blend")]
		public float FinalWeight;

		[Tooltip("the timescale to operate on")]
		[Header("Behaviour")]
		public TimeScales TimeScale;

		[Tooltip("whether or not the associated volume should be disabled at 0")]
		public bool DisableVolumeOnZeroWeight;

		[Tooltip("whether or not this blender should disable itself at 0")]
		public bool DisableSelfAfterEnd;

		[Tooltip("whether or not this blender can be interrupted")]
		public bool Interruptable;

		[Tooltip("whether or not this blender should pick the current value as its starting point")]
		public bool StartFromCurrentValue;

		[Tooltip("reset to initial value on end ")]
		public bool ResetToInitialValueOnEnd;

		[Tooltip("test blend button")]
		[Header("Tests")]
		[MMFInspectorButton("Blend")]
		public bool TestBlend;

		[MMFInspectorButton("BlendBack")]
		[Tooltip("test blend back button")]
		public bool TestBlendBackwards;

		protected float _initial;

		protected float _destination;

		protected float _startTime;

		protected bool _blending;

		protected float GetTime()
		{
			return 0f;
		}
	}
}
