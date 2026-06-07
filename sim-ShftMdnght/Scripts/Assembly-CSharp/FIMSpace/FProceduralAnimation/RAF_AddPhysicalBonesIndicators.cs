namespace FIMSpace.FProceduralAnimation
{
	public class RAF_AddPhysicalBonesIndicators : RagdollAnimatorFeatureBase
	{
		public override bool OnInit()
		{
			RagdollHandler parentRagdollHandler = base.ParentRagdollHandler;
			if (!base.InitializedWith.RequestVariable("Add Collision Detectors:", false).GetBool())
			{
				parentRagdollHandler.PrepareDummyBonesCollisionIndicators(collectCollisions: false);
			}
			else
			{
				parentRagdollHandler.PrepareDummyBonesCollisionIndicators(collectCollisions: true);
			}
			return true;
		}
	}
}
