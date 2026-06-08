using System;

namespace Amazon.Runtime
{
	public class SsoVerificationArguments
	{
		public string UserCode { get; set; }

		public string VerificationUri { get; set; }

		public string VerificationUriComplete { get; set; }

		public string GetSsoSigninMessage()
		{
			return string.Format($"Using a browser, visit: {VerificationUri}{0}" + $"And enter the code: {UserCode}{0}", Environment.NewLine);
		}
	}
}
