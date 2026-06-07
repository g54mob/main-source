using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("GameObject/Destroy")]
	[FeedbackHelp("This feedback allows you to destroy a target gameobject, either via Destroy, DestroyImmediate, or SetActive:False")]
	[AddComponentMenu(null)]
	public class MMFeedbackDestroy : MMFeedback
	{
		public enum Modes
		{
			Destroy = 0,
			DestroyImmediate = 1,
			Disable = 2
		}

		public static bool FeedbackTypeAuthorized;

		[Header("Destroy")]
		[Tooltip("the gameobject we want to change the active state of")]
		public GameObject TargetGameObject;

		[Tooltip("the selected destruction mode")]
		public Modes Mode;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void ProceedWithDestruction(GameObject go)
		{
		}
	}
}
