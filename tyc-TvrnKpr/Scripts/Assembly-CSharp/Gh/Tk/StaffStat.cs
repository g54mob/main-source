namespace Gh.Tk
{
	public abstract class StaffStat : ActorStat
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new Staff Owner
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		protected StaffStat()
		{
		}

		public StaffStat(Staff owner, string name, string displayNameKey, float startingValue, string meterColor)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
