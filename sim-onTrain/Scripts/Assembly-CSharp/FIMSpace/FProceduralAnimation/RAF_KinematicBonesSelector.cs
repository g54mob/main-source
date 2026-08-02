namespace FIMSpace.FProceduralAnimation
{
	public class RAF_KinematicBonesSelector : RagdollAnimatorFeatureBase
	{
		public override void OnDestroyFeature()
		{
			if (base.ParentRagdollHandler == null)
			{
				return;
			}
			foreach (RagdollBonesChain chain in base.ParentRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					boneSetup.ForceKinematicOnStanding = false;
					chain.BoneSetups[chain.BoneSetups.Count - 1].RefreshDynamicPhysicalParameters(chain, base.ParentRagdollHandler.IsInFallingMode, base.ParentRagdollHandler.InstantConnectedMassChange);
				}
			}
		}
	}
}
