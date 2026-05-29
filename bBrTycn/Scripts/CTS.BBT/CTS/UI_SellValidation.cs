namespace CTS
{
	public class UI_SellValidation : UI_StoreValidation<SellBasket>
	{
		protected override void OnEnabled()
		{
			base.OnEnabled();
			base.Basket.ValidationPriceChanged += OnSellPriceChanged;
			OnSellPriceChanged(base.Basket.CurrentTotalPrice);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			SellBasket basket = base.Basket;
			if (!(basket == null))
			{
				basket.ValidationPriceChanged -= OnSellPriceChanged;
			}
		}

		private void OnSellPriceChanged(int price)
		{
			EnableInfoText(price > 0);
			if (price > 0)
			{
				SetInfoText("+ $" + price);
			}
		}
	}
}
