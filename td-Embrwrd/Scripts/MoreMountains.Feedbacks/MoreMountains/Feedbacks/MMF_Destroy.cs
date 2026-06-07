using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback allows you to destroy a target gameobject, either via Destroy, DestroyImmediate, or SetActive:False")]
	[AddComponentMenu(null)]
	[FeedbackPath("GameObject/Destroy")]
	public class MMF_Destroy : MMF_Feedback
	{
		public enum Modes
		{
			Destroy = 0,
			DestroyImmediate = 1,
			Disable = 2
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("the game object we want to destroy")]
		[MMFInspectorGroup("Destruction", true, 18, true, false)]
		public GameObject TargetGameObject;

		[Tooltip("the optional list of extra gameobjects we want to change the active state of")]
		public List<GameObject> ExtraTargetGameObjects;

		[Tooltip("the selected destruction mode")]
		public Modes Mode;

		protected bool _initialActiveState;

		public override bool HasAutomatedTargetAcquisition => false;

		protected override void AutomateTargetAcquisition()
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void ProceedWithDestruction(GameObject go)
		{
		}

		protected override void CustomRestoreInitialValues()
		{
		}
	}
}
