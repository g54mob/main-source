namespace Gh.Tk
{
	public class AccommodationStat : PatronStat
	{
		protected AccommodationStat()
		{
		}

		public AccommodationStat(Patron owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
