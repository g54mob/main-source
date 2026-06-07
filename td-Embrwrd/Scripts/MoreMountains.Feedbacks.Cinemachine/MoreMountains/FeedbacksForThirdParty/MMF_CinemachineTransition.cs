using Cinemachine;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[FeedbackHelp("This feedback will let you change the priorities of your cameras. It requires a bit of setup : adding a MMCinemachinePriorityListener to your different cameras, with unique Channel values on them. Optionally, you can add a MMCinemachinePriorityBrainListener on your Cinemachine Brain to handle different transition types and durations. Then all you have to do is pick a channel and a new priority on your feedback, and play it. Magic transition!")]
	[FeedbackPath("Camera/Cinemachine Transition")]
	[AddComponentMenu(null)]
	public class MMF_CinemachineTransition : MMF_Feedback
	{
		public enum Modes
		{
			Event = 0,
			Binding = 1
		}

		public static bool FeedbackTypeAuthorized;

		[MMFInspectorGroup("Cinemachine Transition", true, 52, false, false)]
		[Tooltip("the selected mode (either via event, or via direct binding of a specific camera)")]
		public Modes Mode;

		[Tooltip("the virtual camera to target")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public CinemachineVirtualCamera TargetVirtualCamera;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetValuesAfterTransition;

		[Header("Priority")]
		[Tooltip("the new priority to apply to all virtual cameras on the specified channel")]
		public int NewPriority;

		[Tooltip("whether or not to force all virtual cameras on other channels to reset their priority to zero")]
		public bool ForceMaxPriority;

		[Tooltip("whether or not to apply a new blend")]
		public bool ForceTransition;

		[MMFCondition("ForceTransition", true)]
		[Tooltip("the new blend definition to apply")]
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

		public override bool HasAutomatedTargetAcquisition => false;

		public override bool HasChannel => false;

		protected override void AutomateTargetAcquisition()
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomRestoreInitialValues()
		{
		}
	}
}
