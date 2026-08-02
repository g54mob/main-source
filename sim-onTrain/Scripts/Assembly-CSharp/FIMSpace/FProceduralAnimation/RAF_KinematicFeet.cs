namespace FIMSpace.FProceduralAnimation
{
	public class RAF_KinematicFeet : RagdollAnimatorFeatureBase
	{
		public override bool OnInit()
		{
			foreach (RagdollBonesChain chain in base.ParentRagdollHandler.Chains)
			{
				if (chain.BoneSetups.Count != 0 && chain.ChainType.IsLeg() && chain.ChainType.IsLeg())
				{
					RagdollChainBone ragdollChainBone = chain.BoneSetups[chain.BoneSetups.Count - 1];
					ragdollChainBone.ForceKinematicOnStanding = true;
					ragdollChainBone.RefreshDynamicPhysicalParameters(chain, chain.ParentHandler.IsFallingOrSleep, base.ParentRagdollHandler.InstantConnectedMassChange);
				}
			}
			return base.OnInit();
		}

		public override void OnDestroyFeature()
		{
			foreach (RagdollBonesChain chain in base.ParentRagdollHandler.Chains)
			{
				if (chain.BoneSetups.Count != 0 && chain.ChainType.IsLeg())
				{
					chain.BoneSetups[chain.BoneSetups.Count - 1].ForceKinematicOnStanding = false;
					chain.BoneSetups[chain.BoneSetups.Count - 1].RefreshDynamicPhysicalParameters(chain, base.ParentRagdollHandler.IsInFallingMode, base.ParentRagdollHandler.InstantConnectedMassChange);
				}
			}
		}
	}
}
