using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("GameObject/Set Active")]
	[FeedbackHelp("This feedback allows you to change the state of the target gameobject from active to inactive (or the opposite), on init, play, stop or reset. For each of these you can specify if you want to force a state (active or inactive), or toggle it (active becomes inactive, inactive becomes active).")]
	[AddComponentMenu(null)]
	public class MMFeedbackSetActive : MMFeedback
	{
		public enum PossibleStates
		{
			Active = 0,
			Inactive = 1,
			Toggle = 2
		}

		public static bool FeedbackTypeAuthorized;

		[Header("Set Active")]
		[Tooltip("the gameobject we want to change the active state of")]
		public GameObject TargetGameObject;

		[Tooltip("whether or not we should alter the state of the target object on init")]
		[Header("States")]
		public bool SetStateOnInit;

		[Tooltip("how to change the state on init")]
		[MMFCondition("SetStateOnInit", true)]
		public PossibleStates StateOnInit;

		[Tooltip("whether or not we should alter the state of the target object on play")]
		public bool SetStateOnPlay;

		[Tooltip("how to change the state on play")]
		[MMFCondition("SetStateOnPlay", true)]
		public PossibleStates StateOnPlay;

		[Tooltip("whether or not we should alter the state of the target object on stop")]
		public bool SetStateOnStop;

		[MMFCondition("SetStateOnStop", true)]
		[Tooltip("how to change the state on stop")]
		public PossibleStates StateOnStop;

		[Tooltip("whether or not we should alter the state of the target object on reset")]
		public bool SetStateOnReset;

		[Tooltip("how to change the state on reset")]
		[MMFCondition("SetStateOnReset", true)]
		public PossibleStates StateOnReset;

		protected override void CustomInitialization(GameObject owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomReset()
		{
		}

		protected virtual void SetStatus(PossibleStates state)
		{
		}
	}
}
