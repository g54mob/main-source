using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MM Global Post Processing Volume Auto Blend")]
	public class MMGlobalPostProcessingVolumeAutoBlend : MonoBehaviour, MMEventListener<MMPostProcessingVolumeAutoBlendShakeEvent>, MMEventListenerBase
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

		[Header("Channel")]
		[Tooltip("whether to listen on a channel defined by an int or by a MMChannel scriptable object. Ints are simple to setup but can get messy and make it harder to remember what int corresponds to what. MMChannel scriptable objects require you to create them in advance, but come with a readable name and are more scalable")]
		public MMChannelModes ChannelMode;

		[Tooltip("the channel to listen to - has to match the one on the feedback")]
		[MMEnumCondition("ChannelMode", new int[] { 0 })]
		public int Channel;

		[Tooltip("the MMChannel definition asset to use to listen for events. The feedbacks targeting this shaker will have to reference that same MMChannel definition to receive events - to create a MMChannel, right click anywhere in your project (usually in a Data folder) and go MoreMountains > MMChannel, then name it with some unique name")]
		[MMEnumCondition("ChannelMode", new int[] { 1 })]
		public MMChannel MMChannelDefinition;

		[Header("Blend")]
		[Tooltip("the trigger mode for this MMGlobalPostProcessingVolumeAutoBlend")]
		public BlendTriggerModes BlendTriggerMode = BlendTriggerModes.Script;

		[Tooltip("the duration of the blend (in seconds)")]
		public float BlendDuration = 1f;

		[Tooltip("the curve to use to blend")]
		public AnimationCurve Curve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[Header("Weight")]
		[Tooltip("the weight at the start of the blend")]
		[Range(0f, 1f)]
		public float InitialWeight;

		[Tooltip("the desired weight at the end of the blend")]
		[Range(0f, 1f)]
		public float FinalWeight = 1f;

		[Header("Behaviour")]
		[Tooltip("the timescale to operate on")]
		public TimeScales TimeScale = TimeScales.Unscaled;

		[Tooltip("whether or not the associated volume should be disabled at 0")]
		public bool DisableVolumeOnZeroWeight = true;

		[Tooltip("whether or not this blender should disable itself at 0")]
		public bool DisableSelfAfterEnd = true;

		[Tooltip("whether or not this blender can be interrupted")]
		public bool Interruptable = true;

		[Tooltip("whether or not this blender should pick the current value as its starting point")]
		public bool StartFromCurrentValue = true;

		[Tooltip("reset to initial value on end ")]
		public bool ResetToInitialValueOnEnd;

		[Header("Tests")]
		[Tooltip("test blend button")]
		[MMFInspectorButton("Blend")]
		public bool TestBlend;

		[Tooltip("test blend back button")]
		[MMFInspectorButton("BlendBack")]
		public bool TestBlendBackwards;

		protected float _initial;

		protected float _destination;

		protected float _startTime;

		protected bool _blending;

		protected float GetTime()
		{
			if (TimeScale != TimeScales.Unscaled)
			{
				return Time.time;
			}
			return Time.unscaledTime;
		}

		public void OnMMEvent(MMPostProcessingVolumeAutoBlendShakeEvent shakeEvent)
		{
		}

		protected void OnDestroy()
		{
			this.MMEventStopListening();
		}
	}
}
