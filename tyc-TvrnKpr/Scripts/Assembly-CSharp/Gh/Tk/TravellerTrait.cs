namespace Gh.Tk
{
	public class TravellerTrait : PatronTrait
	{
		protected TravellerTrait()
		{
		}

		public TravellerTrait(Patron owner)
		{
		}

		public override void Init()
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
