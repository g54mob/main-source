using System.Text;

namespace Gh.Tk
{
	public class ShopItemTemplate : IngredientTemplate
	{
		public override (int, int) GetAllowedPriceRange()
		{
			return default((int, int));
		}

		public static int GetPurchaseChance(IPatronRatable ratable, StringBuilder details = null)
		{
			return 0;
		}
	}
}
