using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the layer of a target game object when playing the feedback")]
	[FeedbackPath("GameObject/Layer")]
	public class MMF_Layer : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Graphic", true, 54, true, false)]
		[Tooltip("the game object you want to change the layer on")]
		public GameObject TargetGameObject;

		[Tooltip("the new layer to assign to the target game object")]
		[MMLayer]
		public int NewLayer;

		protected int _initialLayer;

		public override float FeedbackDuration => 0f;

		public override bool HasChannel => false;

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			TargetGameObject = FindAutomatedTarget<GameObject>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (Active && TargetGameObject != null)
			{
				_initialLayer = TargetGameObject.layer;
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(TargetGameObject == null))
			{
				TargetGameObject.layer = NewLayer;
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				TargetGameObject.layer = _initialLayer;
			}
		}
	}
}
