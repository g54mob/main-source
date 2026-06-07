namespace Gh.Tk
{
	public abstract class PatronStat : ActorStat
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new Patron Owner
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		protected PatronStat()
		{
		}

		public PatronStat(Patron owner, string name, string displayNameKey, float startingValue, string meterColor)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
