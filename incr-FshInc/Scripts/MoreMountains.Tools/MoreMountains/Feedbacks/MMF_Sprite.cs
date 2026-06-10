using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the sprite of a target SpriteRenderer.")]
	[FeedbackPath("Renderer/Sprite")]
	public class MMF_Sprite : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Sprite", true, 54, true, false)]
		[Tooltip("the SpriteRenderer to affect when playing the feedback")]
		public SpriteRenderer BoundSpriteRenderer;

		[Tooltip("the Sprite to apply to the BoundSpriteRenderer when this feedback plays")]
		public Sprite NewSprite;

		protected Sprite _initialSprite;

		public override float FeedbackDuration => 0f;

		public override bool HasChannel => true;

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			BoundSpriteRenderer = FindAutomatedTarget<SpriteRenderer>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (Active)
			{
				if (BoundSpriteRenderer == null)
				{
					Debug.LogWarning("[Sprite Feedback] The Sprite feedback on " + Owner.name + " doesn't have a BoundSpriteRenderer, it won't work. You need to specify a Sprite Renderer in its inspector.");
				}
				else
				{
					_initialSprite = BoundSpriteRenderer.sprite;
				}
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(BoundSpriteRenderer == null))
			{
				SetSprite(NormalPlayDirection ? NewSprite : _initialSprite);
			}
		}

		protected virtual void SetSprite(Sprite newSprite)
		{
			BoundSpriteRenderer.sprite = newSprite;
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
