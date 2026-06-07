namespace FIMSpace.FProceduralAnimation
{
	public abstract class RagdollAnimatorFeatureUpdate : RagdollAnimatorFeatureBase
	{
		public virtual bool UseUpdate => false;

		public virtual bool UseLateUpdate => false;

		public virtual bool UseFixedUpdate => false;

		public override bool OnInit()
		{
			if (UseUpdate)
			{
				base.ParentRagdollHandler.AddToUpdateLoop(Update);
			}
			if (UseLateUpdate)
			{
				base.ParentRagdollHandler.AddToLateUpdateLoop(LateUpdate);
			}
			if (UseFixedUpdate)
			{
				base.ParentRagdollHandler.AddToFixedUpdateLoop(FixedUpdate);
			}
			return true;
		}

		public virtual void Update()
		{
		}

		public virtual void LateUpdate()
		{
		}

		public virtual void FixedUpdate()
		{
		}

		public override void OnDestroyFeature()
		{
			if (UseUpdate)
			{
				base.ParentRagdollHandler.RemoveFromUpdateLoop(Update);
			}
			if (UseLateUpdate)
			{
				base.ParentRagdollHandler.RemoveFromLateUpdateLoop(LateUpdate);
			}
			if (UseFixedUpdate)
			{
				base.ParentRagdollHandler.RemoveFromFixedUpdateLoop(FixedUpdate);
			}
		}
	}
}
