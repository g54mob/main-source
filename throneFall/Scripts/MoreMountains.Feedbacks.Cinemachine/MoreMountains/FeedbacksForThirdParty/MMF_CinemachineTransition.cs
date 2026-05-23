using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the priorities of your cameras. It requires a bit of setup : adding a MMCinemachinePriorityListener to your different cameras, with unique Channel values on them. Optionally, you can add a MMCinemachinePriorityBrainListener on your Cinemachine Brain to handle different transition types and durations. Then all you have to do is pick a channel and a new priority on your feedback, and play it. Magic transition!")]
	public class MMF_CinemachineTransition : MMF_Feedback
	{
		public enum Modes
		{
			Event = 0,
			Binding = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Cinemachine Transition", true, 52, false, false)]
		[Tooltip("the selected mode (either via event, or via direct binding of a specific camera)")]
		public Modes Mode;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetValuesAfterTransition = true;

		[Header("Priority")]
		[Tooltip("the new priority to apply to all virtual cameras on the specified channel")]
		public int NewPriority = 10;

		[Tooltip("whether or not to force all virtual cameras on other channels to reset their priority to zero")]
		public bool ForceMaxPriority = true;

		[Tooltip("whether or not to apply a new blend")]
		public bool ForceTransition;

		public override bool HasChannel => true;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active)
			{
				_ = FeedbackTypeAuthorized;
			}
		}
	}
}
