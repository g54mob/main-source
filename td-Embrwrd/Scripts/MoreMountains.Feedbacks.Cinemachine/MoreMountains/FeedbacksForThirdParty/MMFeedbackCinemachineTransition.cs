using Cinemachine;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback will let you change the priorities of your cameras. It requires a bit of setup : adding a MMCinemachinePriorityListener to your different cameras, with unique Channel values on them. Optionally, you can add a MMCinemachinePriorityBrainListener on your Cinemachine Brain to handle different transition types and durations. Then all you have to do is pick a channel and a new priority on your feedback, and play it. Magic transition!")]
	[FeedbackPath("Camera/Cinemachine Transition")]
	public class MMFeedbackCinemachineTransition : MMFeedback
	{
		public enum Modes
		{
			Event = 0,
			Binding = 1
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("the selected mode (either via event, or via direct binding of a specific camera)")]
		[Header("Cinemachine Transition")]
		public Modes Mode;

		[Tooltip("the channel to emit on")]
		public int Channel;

		[Tooltip("the virtual camera to target")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public CinemachineVirtualCamera TargetVirtualCamera;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetValuesAfterTransition;

		[Tooltip("the new priority to apply to all virtual cameras on the specified channel")]
		[Header("Priority")]
		public int NewPriority;

		[Tooltip("whether or not to force all virtual cameras on other channels to reset their priority to zero")]
		public bool ForceMaxPriority;

		[Tooltip("whether or not to apply a new blend")]
		public bool ForceTransition;

		[Tooltip("the new blend definition to apply")]
		[MMFCondition("ForceTransition", true)]
		public CinemachineBlendDefinition BlendDefintion;

		protected CinemachineBlendDefinition _tempBlend;

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
	}
}
