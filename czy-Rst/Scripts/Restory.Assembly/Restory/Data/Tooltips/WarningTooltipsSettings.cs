using UnityEngine;

namespace Restory.Data.Tooltips
{
	[CreateAssetMenu(fileName = "WarningTooltipsSettings", menuName = "Restory/TooltipsSettings/WarningTooltipsSettings")]
	public class WarningTooltipsSettings : ScriptableObject
	{
		[SerializeField]
		private string uniqueDeviceTooltipKey = "UI_TOOLTIP_NOT_FOR_SALE";

		[SerializeField]
		private string notIdealDeviceWarningTooltipKey = "UI_TOOLTIP_NOT_IDEAL_DEVICE_WARNING";

		[SerializeField]
		private string notIdealDeviceOfWorkOrderWarningTooltipKey = "UI_TOOLTIP_NOT_IDEAL_DEVICE_OF_WORK_ORDER_WARNING";

		[SerializeField]
		private string notIdealDeviceInBoxWarningTooltipKey = "UI_TOOLTIP_NOT_IDEAL_DEVICE_IN_BOX_ORDER";

		[SerializeField]
		private string notIdealDeviceInBoxFleamarketWarningTooltipKey = "UI_TOOLTIP_NOT_IDEAL_DEVICE_IN_BOX_FLEAMARKET";

		[SerializeField]
		private string unfinishedCompetitionBoxWarningTooltipKey = "UI_TOOLTIP_UNFINISHED_COMPETITION_IN_BOX_WARNING";

		[SerializeField]
		private string licenseRequiredWarningTooltipKey = "UI_BROWSER_LICENSE_REQUIRED";

		[SerializeField]
		private string notAllDeviceWorkTypesCompletedWarningTooltipKey = "UI_TOOLTIP_NOT_ALL_DEVICE_WORK_TYPES_COMPLETED_WARNING";

		public string UniqueDeviceTooltipKey => uniqueDeviceTooltipKey;

		public string NotIdealDeviceWarningTooltipKey => notIdealDeviceWarningTooltipKey;

		public string NotIdealDeviceOfWorkOrderWarningTooltipKey => notIdealDeviceOfWorkOrderWarningTooltipKey;

		public string NotIdealDeviceInBoxWarningTooltipKey => notIdealDeviceInBoxWarningTooltipKey;

		public string NotIdealDeviceInBoxFleamarketWarningTooltipKey => notIdealDeviceInBoxFleamarketWarningTooltipKey;

		public string UnfinishedCompetitionBoxWarningTooltipKey => unfinishedCompetitionBoxWarningTooltipKey;

		public string LicenseRequiredWarningTooltipKey => licenseRequiredWarningTooltipKey;

		public string NotAllDeviceWorkTypesCompletedWarningTooltipKey => notAllDeviceWorkTypesCompletedWarningTooltipKey;
	}
}
