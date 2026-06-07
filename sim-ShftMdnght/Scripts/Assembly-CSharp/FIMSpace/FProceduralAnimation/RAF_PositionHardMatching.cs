namespace FIMSpace.FProceduralAnimation
{
	public class RAF_PositionHardMatching : RagdollAnimatorFeatureBase
	{
		public override bool OnInit()
		{
			RefreshHardMatchingProperty(base.ParentRagdollHandler, base.Helper);
			return base.OnInit();
		}

		public void RefreshHardMatchingProperty(RagdollHandler ragdollHandler, RagdollAnimatorFeatureHelper helper)
		{
			ragdollHandler.HardMatchPositions = helper.Enabled;
		}

		public override void OnEnabledSwitch()
		{
			base.OnEnabledSwitch();
			RefreshHardMatchingProperty(base.ParentRagdollHandler, base.Helper);
		}

		public override void OnDestroyFeature()
		{
			base.ParentRagdollHandler.HardMatchPositions = false;
			base.ParentRagdollHandler.HardMatchPositionsOnFall = false;
		}
	}
}
