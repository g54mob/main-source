using Spine.Unity;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class SetAnimation : NimbatusAction
	{
		public SkeletonAnimation Anim;

		public string AnimationName;

		public bool Loop = true;

		public override void Execute()
		{
			if (Anim.AnimationState != null)
			{
				Anim.AnimationState.SetAnimation(0, AnimationName, Loop);
			}
		}
	}
}
