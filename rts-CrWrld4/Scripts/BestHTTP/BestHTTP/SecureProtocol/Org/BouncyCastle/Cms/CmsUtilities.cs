using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	internal class CmsUtilities
	{
		internal static int MaximumMemory => 0;

		internal static ContentInfo ReadContentInfo(byte[] input)
		{
			return null;
		}

		internal static ContentInfo ReadContentInfo(Stream input)
		{
			return null;
		}

		private static ContentInfo ReadContentInfo(Asn1InputStream aIn)
		{
			return null;
		}

		public static byte[] StreamToByteArray(Stream inStream)
		{
			return null;
		}

		public static byte[] StreamToByteArray(Stream inStream, int limit)
		{
			return null;
		}

		public static IList GetCertificatesFromStore(IX509Store certStore)
		{
			return null;
		}

		public static IList GetCrlsFromStore(IX509Store crlStore)
		{
			return null;
		}

		public static Asn1Set CreateBerSetFromList(IList berObjects)
		{
			return null;
		}

		public static Asn1Set CreateDerSetFromList(IList derObjects)
		{
			return null;
		}

		internal static Stream CreateBerOctetOutputStream(Stream s, int tagNo, bool isExplicit, int bufferSize)
		{
			return null;
		}

		internal static TbsCertificateStructure GetTbsCertificateStructure(X509Certificate cert)
		{
			return null;
		}

		internal static IssuerAndSerialNumber GetIssuerAndSerialNumber(X509Certificate cert)
		{
			return null;
		}
	}
}
