using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class CompressedDataParser
	{
		private DerInteger _version;

		private AlgorithmIdentifier _compressionAlgorithm;

		private ContentInfoParser _encapContentInfo;

		public DerInteger Version => null;

		public AlgorithmIdentifier CompressionAlgorithmIdentifier => null;

		public CompressedDataParser(Asn1SequenceParser seq)
		{
		}

		public ContentInfoParser GetEncapContentInfo()
		{
			return null;
		}
	}
}
