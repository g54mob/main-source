using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreAvailability
	{
		public string AvailabilityId { get; }

		public XStorePrice Price { get; }

		public DateTime EndDate { get; }

		internal XStoreAvailability(XGamingRuntime.Interop.XStoreAvailability rawAvailability)
		{
			AvailabilityId = rawAvailability.availabilityId.GetString();
			Price = new XStorePrice(rawAvailability.price);
			EndDate = rawAvailability.endDate.DateTime;
		}
	}
}
