using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("On play, this feedback will broadcast a MMFlashEvent. If you create a UI image with a MMFlash component on it (see example in the Demo scene), it will intercept that event, and flash (usually you'll want it to take the full size of your screen, but that's not mandatory). In the feedback's inspector, you can define the color of the flash, its duration, alpha, and a FlashID. That FlashID needs to be the same on your feedback and MMFlash for them to work together. This allows you to have multiple MMFlashs in your scene, and flash them separately.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Camera/Flash")]
	public class MMF_Flash : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Flash", true, 37, false, false)]
		[Tooltip("the color of the flash")]
		public Color FlashColor = Color.white;

		[Tooltip("the flash duration (in seconds)")]
		public float FlashDuration = 0.2f;

		[Tooltip("the alpha of the flash")]
		public float FlashAlpha = 1f;

		[Tooltip("the ID of the flash (usually 0). You can specify on each MMFlash object an ID, allowing you to have different flash images in one scene and call them separately (one for damage, one for health pickups, etc)")]
		public int FlashID;

		[Header("Optional Target")]
		[Tooltip("this field lets you bind a specific MMFlash to this feedback. If left empty, the feedback will trigger a MMFlashEvent instead, targeting all matching flashes. If you fill it, only that specific MMFlash will be targeted.")]
		public MMFlash TargetFlash;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(FlashDuration);
			}
			set
			{
				FlashDuration = value;
			}
		}

		public override bool HasChannel => true;

		public override bool HasRandomness => true;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				float num = ComputeIntensity(feedbacksIntensity, position);
				if (TargetFlash != null)
				{
					TargetFlash.Flash(FlashColor, FlashDuration * num, FlashAlpha, ComputedTimescaleMode);
				}
				else
				{
					MMFlashEvent.Trigger(FlashColor, FeedbackDuration * num, FlashAlpha, FlashID, ChannelData, ComputedTimescaleMode);
				}
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				MMFlashEvent.Trigger(FlashColor, FeedbackDuration, FlashAlpha, FlashID, ChannelData, ComputedTimescaleMode, stop: true);
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				MMFlashEvent.Trigger(FlashColor, FeedbackDuration, FlashAlpha, FlashID, ChannelData, ComputedTimescaleMode, stop: true);
			}
		}

		public override void AutomaticShakerSetup()
		{
			if (!(Object.FindFirstObjectByType<MMFlash>() != null))
			{
				Canvas item = Owner.gameObject.MMFindOrCreateObjectOfType<Canvas>("FlashCanvas", null).newComponent;
				item.renderMode = RenderMode.ScreenSpaceOverlay;
				Image item2 = item.gameObject.MMFindOrCreateObjectOfType<Image>("FlashImage", item.transform, forceNewCreation: true).newComponent;
				item2.raycastTarget = false;
				item2.color = Color.white;
				RectTransform component = item2.GetComponent<RectTransform>();
				component.anchorMin = new Vector2(0f, 0f);
				component.anchorMax = new Vector2(1f, 1f);
				component.offsetMin = Vector2.zero;
				component.offsetMax = Vector2.zero;
				item2.gameObject.AddComponent<MMFlash>();
				item2.gameObject.GetComponent<CanvasGroup>().alpha = 0f;
				item2.gameObject.GetComponent<CanvasGroup>().interactable = false;
				MMDebug.DebugLogInfo("Added a MMFlash to the scene. You're all set.");
			}
		}
	}
}
