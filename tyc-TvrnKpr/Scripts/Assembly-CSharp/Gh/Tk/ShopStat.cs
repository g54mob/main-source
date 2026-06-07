namespace Gh.Tk
{
	public class ShopStat : PatronStat
	{
		protected ShopStat()
		{
		}

		public ShopStat(Patron owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
