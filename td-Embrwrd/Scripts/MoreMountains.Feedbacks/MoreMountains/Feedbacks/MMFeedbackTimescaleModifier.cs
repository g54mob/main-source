using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackPath("Time/Timescale Modifier")]
	[FeedbackHelp("This feedback triggers a MMTimeScaleEvent, which, if you have a MMTimeManager object in your scene, will be caught and used to modify the timescale according to the specified settings. These settings are the new timescale (0.5 will be twice slower than normal, 2 twice faster, etc), the duration of the timescale modification, and the optional speed at which to transition between normal and altered time scale.")]
	public class MMFeedbackTimescaleModifier : MMFeedback
	{
		public enum Modes
		{
			Shake = 0,
			Change = 1,
			Reset = 2
		}

		public static bool FeedbackTypeAuthorized;

		[Header("Mode")]
		[Tooltip("the selected mode : shake : changes the timescale for a certain duration- change : sets the timescale to a new value, forever (until you change it again)- reset : resets the timescale to its previous value")]
		public Modes Mode;

		[Header("Timescale Modifier")]
		[Tooltip("the new timescale to apply")]
		public float TimeScale;

		[Tooltip("the duration of the timescale modification")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float TimeScaleDuration;

		[Tooltip("whether or not we should lerp the timescale")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public bool TimeScaleLerp;

		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		[Tooltip("the speed at which to lerp the timescale")]
		public float TimeScaleLerpSpeed;

		[Tooltip("whether to reset the timescale on Stop or not")]
		public bool ResetTimescaleOnStop;

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

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
