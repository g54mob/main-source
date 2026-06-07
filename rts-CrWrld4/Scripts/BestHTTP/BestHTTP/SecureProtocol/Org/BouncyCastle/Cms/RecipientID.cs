using BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class RecipientID : X509CertStoreSelector
	{
		private byte[] keyIdentifier;

		public byte[] KeyIdentifier
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}
	}
}
