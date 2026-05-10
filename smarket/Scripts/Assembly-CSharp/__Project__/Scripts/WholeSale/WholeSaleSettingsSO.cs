using UnityEngine;

namespace __Project__.Scripts.WholeSale
{
	[CreateAssetMenu(fileName = "WholeSaleSettings", menuName = "Wholesale/WholeSaleSetting")]
	public class WholeSaleSettingsSO : ScriptableObject
	{
		public Vector2Int PlayerLevelRange;

		public Vector2 PopupTimeRange;

		public Vector2Int PopupAmountRange;

		public Vector2Int BuyOfferDiscountPercentage;

		public Vector2Int SellOfferDiscountPercentage;
	}
}
