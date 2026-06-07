namespace FIMSpace.FProceduralAnimation
{
	public class RAF_IgnoreSelfDummyColliders : RagdollAnimatorFeatureBase
	{
		public override bool OnInit()
		{
			if (base.InitializedWith.customObjectList == null)
			{
				return false;
			}
			if (base.InitializedWith.customStringList == null)
			{
				return false;
			}
			if (base.InitializedWith.customStringList.Count != base.ParentRagdollHandler.GetAllBonesCount())
			{
				return false;
			}
			int num = 0;
			foreach (RagdollBonesChain chain in base.ParentRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					if (base.InitializedWith.customStringList[num] == "1")
					{
						foreach (RagdollBonesChain chain2 in base.ParentRagdollHandler.Chains)
						{
							foreach (RagdollChainBone boneSetup2 in chain2.BoneSetups)
							{
								boneSetup.IgnoreCollisionsWith(boneSetup2);
							}
						}
					}
					num++;
				}
			}
			return true;
		}
	}
}
