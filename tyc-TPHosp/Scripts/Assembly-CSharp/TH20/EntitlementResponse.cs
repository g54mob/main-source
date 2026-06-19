using System.Collections.Generic;

namespace TH20
{
	[DontSave]
	public class EntitlementResponse
	{
		public readonly string EntitlementId;

		public readonly string VendorProductId;

		public readonly string NextInstruction;

		public const string NoActionNeeded = "NOOP";

		public const string Fulfill = "FULFILL";

		public EntitlementResponse(Dictionary<string, object> responseData)
		{
			EntitlementId = (string)responseData["EntitlementId"];
			VendorProductId = (string)responseData["VendorProductId"];
			NextInstruction = (string)responseData["NextInstruction"];
		}
	}
}
