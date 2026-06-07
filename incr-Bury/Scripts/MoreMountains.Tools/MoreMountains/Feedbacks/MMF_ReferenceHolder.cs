using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback allows you to hold a reference, that can then be used by other feedbacks to automatically set their target. It doesn't do anything when played.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Feedbacks/MMF Reference Holder")]
	public class MMF_ReferenceHolder : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("References", true, 37, true, false)]
		[Tooltip("the game object to set as the target (or on which to look for a specific component as a target) of all feedbacks that may look at this reference holder for a target")]
		public GameObject GameObjectReference;

		[Tooltip("whether or not to force this reference holder on all compatible feedbacks in the MMF Player's list")]
		public bool ForceReferenceOnAll;

		public override float FeedbackDuration => 0f;

		public override bool DisplayFullHeaderColor => true;

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (!ForceReferenceOnAll)
			{
				return;
			}
			for (int i = 0; i < Owner.FeedbacksList.Count; i++)
			{
				if (Owner.FeedbacksList[i].HasAutomatedTargetAcquisition)
				{
					Owner.FeedbacksList[i].SetIndexInFeedbacksList(i);
					Owner.FeedbacksList[i].ForcedReferenceHolder = this;
					Owner.FeedbacksList[i].ForceAutomateTargetAcquisition();
				}
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
