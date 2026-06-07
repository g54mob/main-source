using UnityEngine;

namespace Gh.Tk.UI.Dialogs.TavernMenu
{
	public class TavernMenuShopItem3DUIView : IngredientTavernMenuItem3DUIView
	{
		[SerializeField]
		private TextBlock3DUIView _purchaseChanceText;

		[SerializeField]
		private TextBlock3DUIView _priceRatingText;

		private TooltipData _priceRatingDetail;

		public override void SetData(Ingredient ingredient)
		{
		}

		protected override void OnPriceChanged()
		{
		}

		private void InvalidatePriceRatingLabel()
		{
		}

		private void InvalidatePurchaseChanceLabel()
		{
		}
	}
}
