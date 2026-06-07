using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("GameObject/Enable Behaviour")]
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback allows you to change the state of a behaviour on a target gameobject from active to inactive (or the opposite), on init, play, stop or reset. For each of these you can specify if you want to force a state (enabled or disabled), or toggle it (enabled becomes disabled, disabled becomes enabled).")]
	public class MMFeedbackEnable : MMFeedback
	{
		public enum PossibleStates
		{
			Enabled = 0,
			Disabled = 1,
			Toggle = 2
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("the gameobject we want to change the active state of")]
		[Header("Set Active")]
		public Behaviour TargetBehaviour;

		[Tooltip("whether or not we should alter the state of the target object on init")]
		public bool SetStateOnInit;

		[MMFCondition("SetStateOnInit", true)]
		[Tooltip("how to change the state on init")]
		public PossibleStates StateOnInit;

		[Tooltip("whether or not we should alter the state of the target object on play")]
		public bool SetStateOnPlay;

		[MMFCondition("SetStateOnPlay", true)]
		[Tooltip("how to change the state on play")]
		public PossibleStates StateOnPlay;

		[Tooltip("whether or not we should alter the state of the target object on stop")]
		public bool SetStateOnStop;

		[Tooltip("how to change the state on stop")]
		[MMFCondition("SetStateOnStop", true)]
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
