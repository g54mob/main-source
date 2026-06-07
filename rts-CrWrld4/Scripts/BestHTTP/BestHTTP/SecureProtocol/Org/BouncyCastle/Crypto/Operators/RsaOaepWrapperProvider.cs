using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Operators
{
	internal class RsaOaepWrapperProvider : WrapperProvider
	{
		private readonly DerObjectIdentifier digestOid;

		internal RsaOaepWrapperProvider(DerObjectIdentifier digestOid)
		{
		}

		object WrapperProvider.CreateWrapper(bool forWrapping, ICipherParameters parameters)
		{
			return null;
		}
	}
}
