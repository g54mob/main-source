namespace XGamingRuntime
{
	public class XUserGetTokenAndSignatureUtf16Data
	{
		public string Token { get; }

		public string Signature { get; }

		internal XUserGetTokenAndSignatureUtf16Data(string token, string signature)
		{
			Token = token;
			Signature = signature;
		}
	}
}
