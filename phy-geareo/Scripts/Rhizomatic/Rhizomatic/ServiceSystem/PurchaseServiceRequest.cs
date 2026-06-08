using System;

namespace Rhizomatic.ServiceSystem
{
	public class PurchaseServiceRequest
	{
		public PurchaseServiceRequestType type;

		public Action<object[]> onSucceed;

		public Action<object[]> onFailed;

		public float time;
	}
}
