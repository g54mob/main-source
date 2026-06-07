using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("Loop/Looper")]
	[FeedbackHelp("This feedback will move the current 'head' of an MMFeedbacks sequence back to another feedback above in the list. What feedback the head lands on depends on your settings : you can decide to have it loop at last pause, or at the last LoopStart feedback in the list (or both). Furthermore, you can decide to have it loop multiple times and cause a pause when met.")]
	[AddComponentMenu(null)]
	public class MMFeedbackLooper : MMFeedbackPause
	{
		[Tooltip("if this is true, this feedback, when met, will cause the MMFeedbacks to reposition its 'head' to the first pause found above it (going from this feedback to the top), or to the start if none is found")]
		[Header("Loop conditions")]
		public bool LoopAtLastPause;

		[Tooltip("if this is true, this feedback, when met, will cause the MMFeedbacks to reposition its 'head' to the first LoopStart feedback found above it (going from this feedback to the top), or to the start if none is found")]
		public bool LoopAtLastLoopStart;

		[Header("Loop")]
		[Tooltip("if this is true, the looper will loop forever")]
		public bool InfiniteLoop;

		[Tooltip("how many times this loop should run")]
		public int NumberOfLoops;

		[MMFReadOnly]
		[Tooltip("the amount of loops left (updated at runtime)")]
		public int NumberOfLoopsLeft;

		[MMFReadOnly]
		[Tooltip("whether we are in an infinite loop at this time or not")]
		public bool InInfiniteLoop;

		public override bool LooperPause => false;

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

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomReset()
		{
		}
	}
}
