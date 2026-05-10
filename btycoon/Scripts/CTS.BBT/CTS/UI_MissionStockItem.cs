namespace CTS
{
	public class UI_MissionStockItem : UI_SellStockItem
	{
		protected override void OnEnabled()
		{
			base.OnEnabled();
			MissionBasket.MissionStarted += OnMissionStarted;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			MissionBasket.MissionStarted -= OnMissionStarted;
		}

		private void OnMissionStarted(MissionBasket basket)
		{
			if (!(basket != base.Basket))
			{
				OnBasketChanged();
			}
		}

		protected override void SetPriceText(string text)
		{
		}

		protected override void UpdatePriceText()
		{
		}
	}
}
