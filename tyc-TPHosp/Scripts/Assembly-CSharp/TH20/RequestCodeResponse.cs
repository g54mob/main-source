using System;
using System.Collections.Generic;

namespace TH20
{
	[DontSave]
	public class RequestCodeResponse
	{
		public readonly string UserCode;

		public readonly string DeviceCode;

		public readonly string VerificationURL;

		public readonly int ExpiryTime;

		public readonly int Interval;

		public RequestCodeResponse(Dictionary<string, object> responseData)
		{
			UserCode = (string)responseData["user_code"];
			DeviceCode = (string)responseData["device_code"];
			VerificationURL = (string)responseData["verification_uri"];
			ExpiryTime = Convert.ToInt32(responseData["expires_in"]);
			Interval = Convert.ToInt32(responseData["interval"]);
		}
	}
}
