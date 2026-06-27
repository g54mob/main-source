using UnityEngine;

namespace Restory.Data.Tooltips
{
	[CreateAssetMenu(fileName = "DeliveryPackTooltipsSettings", menuName = "Restory/TooltipsSettings/DeliveryPackTooltipsSettings")]
	public class DeliveryPackTooltipsSettings : ScriptableObject
	{
		[SerializeField]
		private GameObject deliveryBoxInitialTooltipPrefab;

		[SerializeField]
		private GameObject deliveryBoxMainTooltipPrefab;

		[SerializeField]
		private string sellForLocalizationKey;

		[SerializeField]
		private string giveToLocalizationKey;

		[SerializeField]
		private string canBeSoldLocalizationKey;

		[SerializeField]
		private string lastDayLocalizationKey;

		[SerializeField]
		private string overdueOrderLocalizationKey;

		public GameObject DeliveryBoxInitialTooltipPrefab => deliveryBoxInitialTooltipPrefab;

		public GameObject DeliveryBoxMainTooltipPrefab => deliveryBoxMainTooltipPrefab;

		public string SellForLocalizationKey => sellForLocalizationKey;

		public string GiveToLocalizationKey => giveToLocalizationKey;

		public string CanBeSoldLocalizationKey => canBeSoldLocalizationKey;

		public string LastDayTooltipLocalizationKey => lastDayLocalizationKey;

		public string OverdueOrderTooltipLocalizationKey => overdueOrderLocalizationKey;
	}
}
