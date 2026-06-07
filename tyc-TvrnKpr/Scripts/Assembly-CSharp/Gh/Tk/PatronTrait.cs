namespace Gh.Tk
{
	public abstract class PatronTrait : ActorTrait
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

		protected PatronTrait()
		{
		}

		public PatronTrait(Patron owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
