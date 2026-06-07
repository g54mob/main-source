namespace Gh.Tk
{
	public class PatronSkill : ActorSkill
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

		protected PatronSkill()
		{
		}

		public PatronSkill(Patron owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
