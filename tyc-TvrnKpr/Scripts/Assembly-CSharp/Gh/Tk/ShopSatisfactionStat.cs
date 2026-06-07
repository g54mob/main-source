namespace Gh.Tk
{
	public class ShopSatisfactionStat : SatisfactionStatBase
	{
		protected ShopSatisfactionStat()
		{
		}

		public ShopSatisfactionStat(Patron owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
