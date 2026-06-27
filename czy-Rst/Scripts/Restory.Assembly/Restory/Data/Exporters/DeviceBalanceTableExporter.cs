using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.Exporters
{
	[CreateAssetMenu(menuName = "Restory/Exporters/DeviceBalanceTableExporter", fileName = "DeviceBalanceTableExporter")]
	public class DeviceBalanceTableExporter : ScriptableObject
	{
		[SerializeField]
		private int headerRow = 4;

		[SerializeField]
		private string deviceIdColumnName = "DeviceID";

		[SerializeField]
		private string devicePriceColumnName = "Price";

		[SerializeField]
		private string licensePriceColumnName = "LicensePrice";

		[SerializeField]
		private string competitionPriceColumnName = "CompCost";

		[SerializeField]
		private string competitionRewardColumnName = "CompReward";

		[SerializeField]
		private string elementIdColumnName = "ElementID";

		[SerializeField]
		private string elementPriceColumnName = "ElementPrice";

		[Space]
		private List<DevicePriceRow> deviceRows = new List<DevicePriceRow>();

		public int HeaderRow => headerRow;

		public string DeviceIdColumnName => deviceIdColumnName;

		public string DevicePriceColumnName => devicePriceColumnName;

		public string LicensePriceColumnName => licensePriceColumnName;

		public string CompetitionPriceColumnName => competitionPriceColumnName;

		public string CompetitionRewardColumnName => competitionRewardColumnName;

		public string ElementIdColumnName => elementIdColumnName;

		public string ElementPriceColumnName => elementPriceColumnName;
	}
}
