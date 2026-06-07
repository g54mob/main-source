using AppleAuth.Interfaces;

namespace AppleAuth.Native
{
	public class PayloadDeserializer : IPayloadDeserializer
	{
		public ICredentialStateResponse DeserializeCredentialStateResponse(string payload)
		{
			return null;
		}

		public ILoginWithAppleIdResponse DeserializeLoginWithAppleIdResponse(string payload)
		{
			return null;
		}
	}
}
