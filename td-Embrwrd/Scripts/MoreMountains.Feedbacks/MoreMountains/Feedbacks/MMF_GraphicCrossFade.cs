using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("UI/Graphic CrossFade")]
	[FeedbackHelp("This feedback will let you trigger cross fades on a target Graphic.")]
	[AddComponentMenu(null)]
	public class MMF_GraphicCrossFade : MMF_Feedback
	{
		public enum Modes
		{
			Alpha = 0,
			Color = 1
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("the Graphic to affect when playing the feedback")]
		[MMFInspectorGroup("Graphic Cross Fade", true, 54, true, false)]
		public Graphic TargetGraphic;

		[Tooltip("whether the feedback should affect the Image instantly or over a period of time")]
		public Modes Mode;

		[Tooltip("how long the Graphic should change over time")]
		public float Duration;

		[Tooltip("the target alpha")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float TargetAlpha;

		[Tooltip("the target color")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public Color TargetColor;

		[Tooltip("whether or not the crossfade should also tween the alpha channel")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public bool UseAlpha;

		[Tooltip("if this is true, the target will be disabled when this feedbacks is stopped")]
		public bool DisableOnStop;

		protected Coroutine _coroutine;

		protected Color _initialColor;

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

		public override bool HasChannel => false;

		public override bool HasAutomatedTargetAcquisition => false;

		protected override void AutomateTargetAcquisition()
		{
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void Turn(bool status)
		{
		}

		protected override void CustomRestoreInitialValues()
		{
		}
	}
}
