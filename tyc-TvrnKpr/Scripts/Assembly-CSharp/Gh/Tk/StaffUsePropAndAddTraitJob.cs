namespace Gh.Tk
{
	public class StaffUsePropAndAddTraitJob : UseProp_Job
	{
		[PersistenceOptIn]
		private string _traitName;

		protected StaffUsePropAndAddTraitJob()
		{
		}

		public StaffUsePropAndAddTraitJob(GameObjectX source, Prop target, string traitType, ActorBehaviour behaviour, string usageKeyOverride = null, GameItem item = null, float duration = -1f)
		{
		}

		protected override void OnFinishInternal()
		{
		}
	}
}
