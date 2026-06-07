using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("UI/Image RaycastTarget")]
	[FeedbackHelp("This feedback will let you control the RaycastTarget parameter of a target image, turning it on or off on play")]
	[AddComponentMenu(null)]
	public class MMF_ImageRaycastTarget : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the target Image we want to control the RaycastTarget parameter on")]
		[MMFInspectorGroup("Image", true, 12, true, false)]
		public Image TargetImage;

		[Tooltip("if this is true, when played, the target image will become a raycast target")]
		public bool ShouldBeRaycastTarget;

		protected bool _initialState;

		public override bool HasAutomatedTargetAcquisition => false;

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
