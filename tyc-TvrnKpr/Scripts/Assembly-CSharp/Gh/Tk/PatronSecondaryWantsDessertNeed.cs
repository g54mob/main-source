namespace Gh.Tk
{
	public class PatronSecondaryWantsDessertNeed : PatronSecondaryNeed
	{
		public string ItemType { get; private set; }

		public override string DisplayTitleKey => null;

		protected PatronSecondaryWantsDessertNeed()
		{
		}

		public PatronSecondaryWantsDessertNeed(string itemType)
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
