using Spine.Unity;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class PauseAnimation : NimbatusAction
	{
		public SkeletonAnimation Anim;

		public override void Execute()
		{
			if (Anim != null)
			{
				Anim.timeScale = 0f;
			}
		}
	}
}
