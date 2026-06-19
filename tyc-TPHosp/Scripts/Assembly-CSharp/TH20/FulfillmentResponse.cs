using System.Collections.Generic;

namespace TH20
{
	[DontSave]
	public class FulfillmentResponse
	{
		public readonly string EntitlementId;

		public readonly string Result;

		public const string Success = "SUCCESS";

		public const string Error = "ERROR";

		public FulfillmentResponse(Dictionary<string, object> responseData)
		{
			EntitlementId = (string)responseData["EntitlementId"];
			Result = (string)responseData["Result"];
		}
	}
}
