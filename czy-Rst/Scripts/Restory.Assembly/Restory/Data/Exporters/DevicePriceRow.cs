using System;
using System.Collections.Generic;

namespace Restory.Data.Exporters
{
	[Serializable]
	public class DevicePriceRow
	{
		public string DeviceId;

		public int DefaultPrice;

		public int LicensePrice;

		public int CompetitionPrice;

		public int CompetitionReward;

		public List<ElementPriceRow> Elements;
	}
}
