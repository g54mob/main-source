using FIMSpace.FProceduralAnimation;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_SwitchBOC : FimpossibleComponent
	{
		public RagdollAnimator2 Ragdoll;

		public void SwitchBlendOnCollision(bool enabled)
		{
			RagdollAnimatorFeatureHelper extraFeatureHelper = Ragdoll.Handler.GetExtraFeatureHelper<RAF_BlendOnCollisions>();
			if (extraFeatureHelper != null)
			{
				extraFeatureHelper.Enabled = enabled;
			}
		}
	}
}
