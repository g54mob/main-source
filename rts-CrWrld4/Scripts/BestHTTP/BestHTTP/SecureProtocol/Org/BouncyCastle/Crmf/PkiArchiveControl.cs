using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Cms;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crmf
{
	public class PkiArchiveControl : IControl
	{
		public static readonly int encryptedPrivKey;

		public static readonly int keyGenParameters;

		public static readonly int archiveRemGenPrivKey;

		private static readonly DerObjectIdentifier type;

		private readonly PkiArchiveOptions pkiArchiveOptions;

		public DerObjectIdentifier Type => null;

		public Asn1Encodable Value => null;

		public int ArchiveType => 0;

		public bool EnvelopedData => false;

		public PkiArchiveControl(PkiArchiveOptions pkiArchiveOptions)
		{
		}

		public CmsEnvelopedData GetEnvelopedData()
		{
			return null;
		}
	}
}
