using Spine;
using Spine.Unity;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnAnimationStateEvent : NimbatusEvent
	{
		public SkeletonAnimation Animation;

		public string Eventname;

		protected override void Subscribe()
		{
			if (Animation.AnimationState != null)
			{
				Animation.AnimationState.Event += AnimationState_Event;
			}
		}

		private void AnimationState_Event(TrackEntry trackEntry, Event e)
		{
			if (e.Data.Name == Eventname)
			{
				RaiseEvent();
			}
		}

		protected override void Unsubscribe()
		{
			if (Animation.AnimationState != null)
			{
				Animation.AnimationState.Event -= AnimationState_Event;
			}
		}
	}
}
