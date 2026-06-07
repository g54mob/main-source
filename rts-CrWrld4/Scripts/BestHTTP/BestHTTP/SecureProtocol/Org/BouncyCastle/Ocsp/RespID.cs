using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Ocsp
{
	public class RespID
	{
		internal readonly ResponderID id;

		public RespID(ResponderID id)
		{
		}

		public RespID(X509Name name)
		{
		}

		public RespID(AsymmetricKeyParameter publicKey)
		{
		}

		public ResponderID ToAsn1Object()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
