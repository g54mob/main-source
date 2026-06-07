using Spine.Unity;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class ResumeAnimation : NimbatusAction
	{
		public SkeletonAnimation Anim;

		public override void Execute()
		{
			if (Anim != null)
			{
				Anim.timeScale = 1f;
			}
		}
	}
}
