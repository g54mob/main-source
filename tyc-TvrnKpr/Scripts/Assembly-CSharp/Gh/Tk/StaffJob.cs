namespace Gh.Tk
{
	public abstract class StaffJob : ActorJob
	{
		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public int MinStaffLevel;

		public new Staff Owner
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public StaffJob()
		{
		}

		protected StaffJob(GameObjectX source, GameObjectX target = null, ActorBehaviour behaviour = null, string usageKeyOverride = null, int priority = 0)
		{
		}
	}
}
