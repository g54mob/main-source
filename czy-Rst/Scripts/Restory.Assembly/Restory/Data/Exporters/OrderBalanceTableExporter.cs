using Helpers.Ranges;
using Restory.Data.Devices;
using Restory.Data.Email;
using UnityEngine;

namespace Restory.Data.Exporters
{
	[CreateAssetMenu(menuName = "Restory/Exporters/OrderBalanceTableExporter", fileName = "OrderBalanceTableExporter")]
	public class OrderBalanceTableExporter : ScriptableObject
	{
		private const string EMAIL_ORDERS_SETTINGS_GROUP = "Email Orders Settings";

		private const string EMAIL_RANDOM_DEVICES_GENERATION_SETTINGS_GROUP = "Email Random Devices Generation Settings";

		private const string DEVICE_PRICE_ESTIMATION_SETTINGS_GROUP = "Device Price Estimation Settings";

		[SerializeField]
		private EmailSettings emailSettings;

		[SerializeField]
		private string dailyOrdersRangeRowName = "DailyOrdersRange";

		[SerializeField]
		private EmailRandomDevicesGenerationSettings randomDevicesGenerationSettings;

		[SerializeField]
		private string maxRestorationTypesAtOnceRowName = "MaxRestorationTypesAtOnce";

		[SerializeField]
		private string dirtyElementAmountRowName = "DirtyElementAmount";

		[SerializeField]
		private string damagedElementAmountRowName = "DamagedElementAmount";

		[SerializeField]
		private string deviceHasDamagedElementsChanceRowName = "DeviceHasDamagedElementsChance";

		[SerializeField]
		private string deviceHasPaintTaskChanceRowName = "PaintTaskChance";

		[SerializeField]
		private string deviceHasHackTaskChanceRowName = "HackTaskChance";

		[SerializeField]
		private DevicePriceEstimationSettings devicePriceEstimationSettings;

		[SerializeField]
		private string paymentModifierPerDirtyPartRowName = "PaymentModifierPerDirtyPart";

		[SerializeField]
		private string fixedPaymentPerDirtyPartRowName = "FixedPaymentPerDirtyPart";

		[SerializeField]
		private string fixedHackPaymentRowName = "HackPayment";

		[SerializeField]
		private string fixedPaintPaymentRowName = "PaintPayment";

		[SerializeField]
		private string fixedPalettePaymentRowName = "PalettePayment";

		[Space]
		[SerializeField]
		private IntRange importedDailyOrdersRange;

		[SerializeField]
		private int importedMaxRestorationTypesAtOnce;

		[SerializeField]
		private IntRange importedDirtyElementsAmount;

		[SerializeField]
		private IntRange importedDamagedElementsAmount;

		[SerializeField]
		private float importedDeviceHasDamagedElementsChance;

		[SerializeField]
		private float importedDeviceHasPaintTaskChance;

		[SerializeField]
		private float importedDeviceHasHackTaskChance;

		[SerializeField]
		private float importedPaymentModifierPerDirtyPart;

		[SerializeField]
		private int importedFixedPaymentPerDirtyPart;

		[SerializeField]
		private int importedHackPayment;

		[SerializeField]
		private int importedPaintPayment;

		[SerializeField]
		private int importedPalettePayment;

		public EmailSettings EmailSettings => emailSettings;

		public string DailyOrdersRangeRowName => dailyOrdersRangeRowName;

		public EmailRandomDevicesGenerationSettings RandomDevicesGenerationSettings => randomDevicesGenerationSettings;

		public string MaxRestorationTypesAtOnceRowName => maxRestorationTypesAtOnceRowName;

		public string DirtyElementAmountRowName => dirtyElementAmountRowName;

		public string DamagedElementAmountRowName => damagedElementAmountRowName;

		public string DeviceHasDamagedElementsChanceRowName => deviceHasDamagedElementsChanceRowName;

		public string DeviceHasPaintTaskChanceRowName => deviceHasPaintTaskChanceRowName;

		public string DeviceHasHackTaskChanceRowName => deviceHasHackTaskChanceRowName;

		public DevicePriceEstimationSettings DevicePriceEstimationSettings => devicePriceEstimationSettings;

		public string PaymentModifierPerDirtyPartRowName => paymentModifierPerDirtyPartRowName;

		public string FixedPaymentPerDirtyPartRowName => fixedPaymentPerDirtyPartRowName;

		public string FixedPaintPaymentRowName => fixedPaintPaymentRowName;

		public string FixedPalettePaymentRowName => fixedPalettePaymentRowName;

		public string FixedHackPaymentRowName => fixedHackPaymentRowName;
	}
}
