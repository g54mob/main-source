namespace Gh.Tk
{
	public class PatronSecondaryWantsSpecificItemTypeNeed : PatronSecondaryNeed
	{
		public string ItemType { get; private set; }

		public override string DisplayTitleKey => null;

		protected PatronSecondaryWantsSpecificItemTypeNeed()
		{
		}

		public PatronSecondaryWantsSpecificItemTypeNeed(string itemType)
		{
		}

		public override bool CanTavernFulfillNeed(out string reasonKey)
		{
			reasonKey = null;
			return false;
		}

		public override void OnPatronSpawned(Patron patron)
		{
		}
	}
}
