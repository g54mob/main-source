using Spine.Unity;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class AddAnimation : NimbatusAction
	{
		public SkeletonAnimation Anim;

		public string AnimationName;

		public bool Loop = true;

		public float Delay;

		public override void Execute()
		{
			if (Anim.AnimationState != null)
			{
				Anim.AnimationState.AddAnimation(0, AnimationName, Loop, Delay);
			}
		}
	}
}
