using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the sprite of a target Image.")]
	[FeedbackPath("UI/Image Sprite")]
	public class MMF_ImageSprite : MMF_Feedback
	{
		public enum Modes
		{
			Sprite = 0,
			OverrideSprite = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Image", true, 54, true, false)]
		[Tooltip("the Image to affect when playing the feedback")]
		public Image BoundImage;

		[Tooltip("whether to target the Image's Sprite or OverrideSprite to replace it")]
		public Modes Mode;

		[Tooltip("the Sprite to apply to the BoundImage when this feedback plays")]
		public Sprite NewSprite;

		protected Sprite _initialSprite;

		public override float FeedbackDuration => 0f;

		public override bool HasChannel => true;

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			BoundImage = FindAutomatedTarget<Image>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (Active)
			{
				if (BoundImage == null)
				{
					Debug.LogWarning("[Image Sprite Feedback] The Image Sprite feedback on " + Owner.name + " doesn't have a BoundImage, it won't work. You need to specify an Image in its inspector.");
				}
				else
				{
					_initialSprite = BoundImage.sprite;
				}
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(BoundImage == null))
			{
				SetSprite(NormalPlayDirection ? NewSprite : _initialSprite);
			}
		}

		protected virtual void SetSprite(Sprite newSprite)
		{
			switch (Mode)
			{
			case Modes.Sprite:
				BoundImage.sprite = newSprite;
				break;
			case Modes.OverrideSprite:
				BoundImage.overrideSprite = newSprite;
				break;
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				IsPlaying = false;
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				SetSprite(_initialSprite);
			}
		}
	}
}
