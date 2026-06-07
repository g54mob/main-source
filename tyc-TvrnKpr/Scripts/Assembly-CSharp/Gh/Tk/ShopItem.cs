namespace Gh.Tk
{
	public class ShopItem : Ingredient
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new ShopItemTemplate Template
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		public ShopItem()
		{
		}

		public ShopItem(ShopItemTemplate template, bool representsTemplate = false)
		{
		}

		public override (int, string) GetOkPrice(string race, int tier, bool generateReason)
		{
			return default((int, string));
		}
	}
}
