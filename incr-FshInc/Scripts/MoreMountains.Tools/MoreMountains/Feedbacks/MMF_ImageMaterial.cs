using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the material on a target UI Image")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("UI/Image Material")]
	public class MMF_ImageMaterial : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Image", true, 12, true, false)]
		[Tooltip("the target Image we want to change the material on")]
		public Image TargetImage;

		[Tooltip("the new material to apply to the target image")]
		public Material NewMaterial;

		protected Material _initialMaterial;

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			TargetImage = FindAutomatedTarget<Image>();
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(TargetImage == null))
			{
				_initialMaterial = TargetImage.material;
				TargetImage.material = NewMaterial;
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				TargetImage.material = _initialMaterial;
			}
		}
	}
}
