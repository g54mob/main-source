using UnityEngine;

namespace Gh.Tk.UI
{
	public class StockPrognosisBlock3DUIView : BaseBlock3DUIView
	{
		[SerializeField]
		private TextBlock3DUIView _stockAmountText;

		[SerializeField]
		private TextBlock3DUIView _demandText;

		[SerializeField]
		private TextBlock3DUIView _intransitText;

		[SerializeField]
		private GameObject _inventoryForecast;

		[SerializeField]
		private GameObject _inventoryForecastParent;

		[SerializeField]
		private TextBlock3DUIView _spoilRateText;

		[SerializeField]
		private Container3DUIView _spoilageAlertParent;

		[SerializeField]
		private GameObject _spoilageAlertPrefab;

		public override void SetBlockData(string data)
		{
		}

		private void UpdateLayout()
		{
		}

		private void UpdateDemandText(int demand)
		{
		}

		private void UpdateStockAmount(int amount)
		{
		}

		private void UpdateIntransit(GameItemTemplate template)
		{
		}

		private string GetIntransitText(GameItemTemplate template)
		{
			return null;
		}

		private void UpdateSpoilage(float spoilRate, StockInfo stockInfo)
		{
		}

		private void AddSpoilageAlert(string spoilsIn, string amountRemaining)
		{
		}
	}
}
