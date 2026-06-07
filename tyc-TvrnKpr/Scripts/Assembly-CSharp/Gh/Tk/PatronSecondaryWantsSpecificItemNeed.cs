namespace Gh.Tk
{
	public class PatronSecondaryWantsSpecificItemNeed : PatronSecondaryNeed
	{
		[PersistenceObjectReference]
		public GameItemTemplate Template { get; set; }

		public override string DisplayTitleKey => null;

		protected PatronSecondaryWantsSpecificItemNeed()
		{
		}

		public PatronSecondaryWantsSpecificItemNeed(GameItemTemplate template)
		{
		}

		public override bool CanTavernFulfillNeed(out string reasonKey)
		{
			reasonKey = null;
			return false;
		}
	}
}
