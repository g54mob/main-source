using System.Collections;
using System.IO;
using BestHTTP.PlatformSupport.IL2CPP;
using BestHTTP.PlatformSupport.Memory;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	[Il2CppEagerStaticClassConstruction]
	public abstract class TlsUtilities
	{
		public static readonly byte[] EmptyBytes;

		public static readonly short[] EmptyShorts;

		public static readonly int[] EmptyInts;

		public static readonly long[] EmptyLongs;

		internal static readonly byte[] SSL_CLIENT;

		internal static readonly byte[] SSL_SERVER;

		internal static readonly byte[][] SSL3_CONST;

		public static void CheckUint8(int i)
		{
		}

		public static void CheckUint8(long i)
		{
		}

		public static void CheckUint16(int i)
		{
		}

		public static void CheckUint16(long i)
		{
		}

		public static void CheckUint24(int i)
		{
		}

		public static void CheckUint24(long i)
		{
		}

		public static void CheckUint32(long i)
		{
		}

		public static void CheckUint48(long i)
		{
		}

		public static void CheckUint64(long i)
		{
		}

		public static bool IsValidUint8(int i)
		{
			return false;
		}

		public static bool IsValidUint8(long i)
		{
			return false;
		}

		public static bool IsValidUint16(int i)
		{
			return false;
		}

		public static bool IsValidUint16(long i)
		{
			return false;
		}

		public static bool IsValidUint24(int i)
		{
			return false;
		}

		public static bool IsValidUint24(long i)
		{
			return false;
		}

		public static bool IsValidUint32(long i)
		{
			return false;
		}

		public static bool IsValidUint48(long i)
		{
			return false;
		}

		public static bool IsValidUint64(long i)
		{
			return false;
		}

		public static bool IsSsl(TlsContext context)
		{
			return false;
		}

		public static bool IsTlsV11(ProtocolVersion version)
		{
			return false;
		}

		public static bool IsTlsV11(TlsContext context)
		{
			return false;
		}

		public static bool IsTlsV12(ProtocolVersion version)
		{
			return false;
		}

		public static bool IsTlsV12(TlsContext context)
		{
			return false;
		}

		public static void WriteUint8(byte i, Stream output)
		{
		}

		public static void WriteUint8(byte i, byte[] buf, int offset)
		{
		}

		public static void WriteUint16(int i, Stream output)
		{
		}

		public static void WriteUint16(int i, byte[] buf, int offset)
		{
		}

		public static void WriteUint24(int i, Stream output)
		{
		}

		public static void WriteUint24(int i, byte[] buf, int offset)
		{
		}

		public static void WriteUint32(long i, Stream output)
		{
		}

		public static void WriteUint32(long i, byte[] buf, int offset)
		{
		}

		public static void WriteUint48(long i, Stream output)
		{
		}

		public static void WriteUint48(long i, byte[] buf, int offset)
		{
		}

		public static void WriteUint64(long i, Stream output)
		{
		}

		public static void WriteUint64(long i, byte[] buf, int offset)
		{
		}

		public static void WriteOpaque8(byte[] buf, Stream output)
		{
		}

		public static void WriteOpaque16(byte[] buf, Stream output)
		{
		}

		public static void WriteOpaque24(byte[] buf, Stream output)
		{
		}

		public static void WriteUint8Array(byte[] uints, Stream output)
		{
		}

		public static void WriteUint8Array(byte[] uints, byte[] buf, int offset)
		{
		}

		public static void WriteUint8ArrayWithUint8Length(byte[] uints, Stream output)
		{
		}

		public static void WriteUint8ArrayWithUint8Length(byte[] uints, byte[] buf, int offset)
		{
		}

		public static void WriteUint16Array(int[] uints, Stream output)
		{
		}

		public static void WriteUint16Array(int[] uints, byte[] buf, int offset)
		{
		}

		public static void WriteUint16ArrayWithUint16Length(int[] uints, Stream output)
		{
		}

		public static void WriteUint16ArrayWithUint16Length(int[] uints, byte[] buf, int offset)
		{
		}

		public static byte DecodeUint8(byte[] buf)
		{
			return 0;
		}

		public static byte[] DecodeUint8ArrayWithUint8Length(byte[] buf)
		{
			return null;
		}

		public static byte[] EncodeOpaque8(byte[] buf)
		{
			return null;
		}

		public static byte[] EncodeUint8(byte val)
		{
			return null;
		}

		public static byte[] EncodeUint8ArrayWithUint8Length(byte[] uints)
		{
			return null;
		}

		public static byte[] EncodeUint16ArrayWithUint16Length(int[] uints)
		{
			return null;
		}

		public static byte ReadUint8(Stream input)
		{
			return 0;
		}

		public static byte ReadUint8(byte[] buf, int offset)
		{
			return 0;
		}

		public static int ReadUint16(Stream input)
		{
			return 0;
		}

		public static int ReadUint16(byte[] buf, int offset)
		{
			return 0;
		}

		public static int ReadUint24(Stream input)
		{
			return 0;
		}

		public static int ReadUint24(byte[] buf, int offset)
		{
			return 0;
		}

		public static long ReadUint32(Stream input)
		{
			return 0L;
		}

		public static long ReadUint32(byte[] buf, int offset)
		{
			return 0L;
		}

		public static long ReadUint48(Stream input)
		{
			return 0L;
		}

		public static long ReadUint48(byte[] buf, int offset)
		{
			return 0L;
		}

		public static BufferSegment ReadAllOrNothing(int length, Stream input)
		{
			return default(BufferSegment);
		}

		public static byte[] ReadFully(int length, Stream input)
		{
			return null;
		}

		public static BufferSegment ReadFullyOptimized(int length, Stream input)
		{
			return default(BufferSegment);
		}

		public static void ReadFully(byte[] buf, Stream input)
		{
		}

		public static byte[] ReadOpaque8(Stream input)
		{
			return null;
		}

		public static byte[] ReadOpaque16(Stream input)
		{
			return null;
		}

		public static byte[] ReadOpaque24(Stream input)
		{
			return null;
		}

		public static byte[] ReadUint8Array(int count, Stream input)
		{
			return null;
		}

		public static int[] ReadUint16Array(int count, Stream input)
		{
			return null;
		}

		public static ProtocolVersion ReadVersion(byte[] buf, int offset)
		{
			return null;
		}

		public static ProtocolVersion ReadVersion(Stream input)
		{
			return null;
		}

		public static int ReadVersionRaw(byte[] buf, int offset)
		{
			return 0;
		}

		public static int ReadVersionRaw(Stream input)
		{
			return 0;
		}

		public static Asn1Object ReadAsn1Object(byte[] encoding)
		{
			return null;
		}

		public static Asn1Object ReadDerObject(byte[] encoding)
		{
			return null;
		}

		public static void WriteGmtUnixTime(byte[] buf, int offset)
		{
		}

		public static void WriteVersion(ProtocolVersion version, Stream output)
		{
		}

		public static void WriteVersion(ProtocolVersion version, byte[] buf, int offset)
		{
		}

		public static IList GetAllSignatureAlgorithms()
		{
			return null;
		}

		public static IList GetDefaultDssSignatureAlgorithms()
		{
			return null;
		}

		public static IList GetDefaultECDsaSignatureAlgorithms()
		{
			return null;
		}

		public static IList GetDefaultRsaSignatureAlgorithms()
		{
			return null;
		}

		public static byte[] GetExtensionData(IDictionary extensions, int extensionType)
		{
			return null;
		}

		public static IList GetDefaultSupportedSignatureAlgorithms()
		{
			return null;
		}

		public static SignatureAndHashAlgorithm GetSignatureAndHashAlgorithm(TlsContext context, TlsSignerCredentials signerCredentials)
		{
			return null;
		}

		public static bool HasExpectedEmptyExtensionData(IDictionary extensions, int extensionType, byte alertDescription)
		{
			return false;
		}

		public static TlsSession ImportSession(byte[] sessionID, SessionParameters sessionParameters)
		{
			return null;
		}

		public static bool IsSignatureAlgorithmsExtensionAllowed(ProtocolVersion clientVersion)
		{
			return false;
		}

		public static void AddSignatureAlgorithmsExtension(IDictionary extensions, IList supportedSignatureAlgorithms)
		{
		}

		public static IList GetSignatureAlgorithmsExtension(IDictionary extensions)
		{
			return null;
		}

		public static byte[] CreateSignatureAlgorithmsExtension(IList supportedSignatureAlgorithms)
		{
			return null;
		}

		public static IList ReadSignatureAlgorithmsExtension(byte[] extensionData)
		{
			return null;
		}

		public static void EncodeSupportedSignatureAlgorithms(IList supportedSignatureAlgorithms, bool allowAnonymous, Stream output)
		{
		}

		public static IList ParseSupportedSignatureAlgorithms(bool allowAnonymous, Stream input)
		{
			return null;
		}

		public static void VerifySupportedSignatureAlgorithm(IList supportedSignatureAlgorithms, SignatureAndHashAlgorithm signatureAlgorithm)
		{
		}

		public static byte[] PRF(TlsContext context, byte[] secret, string asciiLabel, byte[] seed, int size)
		{
			return null;
		}

		public static byte[] PRF_legacy(byte[] secret, string asciiLabel, byte[] seed, int size)
		{
			return null;
		}

		internal static byte[] PRF_legacy(byte[] secret, byte[] label, byte[] labelSeed, int size)
		{
			return null;
		}

		internal static byte[] Concat(byte[] a, byte[] b)
		{
			return null;
		}

		internal static void HMacHash(IDigest digest, byte[] secret, byte[] seed, byte[] output)
		{
		}

		internal static void ValidateKeyUsage(X509CertificateStructure c, int keyUsageBits)
		{
		}

		internal static byte[] CalculateKeyBlock(TlsContext context, int size)
		{
			return null;
		}

		internal static byte[] CalculateKeyBlock_Ssl(byte[] master_secret, byte[] random, int size)
		{
			return null;
		}

		internal static byte[] CalculateMasterSecret(TlsContext context, byte[] pre_master_secret)
		{
			return null;
		}

		internal static byte[] CalculateMasterSecret_Ssl(byte[] pre_master_secret, byte[] random)
		{
			return null;
		}

		internal static byte[] CalculateVerifyData(TlsContext context, string asciiLabel, byte[] handshakeHash)
		{
			return null;
		}

		public static IDigest CreateHash(byte hashAlgorithm)
		{
			return null;
		}

		public static IDigest CreateHash(SignatureAndHashAlgorithm signatureAndHashAlgorithm)
		{
			return null;
		}

		public static IDigest CloneHash(byte hashAlgorithm, IDigest hash)
		{
			return null;
		}

		public static IDigest CreatePrfHash(int prfAlgorithm)
		{
			return null;
		}

		public static IDigest ClonePrfHash(int prfAlgorithm, IDigest hash)
		{
			return null;
		}

		public static byte GetHashAlgorithmForPrfAlgorithm(int prfAlgorithm)
		{
			return 0;
		}

		public static DerObjectIdentifier GetOidForHashAlgorithm(byte hashAlgorithm)
		{
			return null;
		}

		internal static short GetClientCertificateType(Certificate clientCertificate, Certificate serverCertificate)
		{
			return 0;
		}

		internal static void TrackHashAlgorithms(TlsHandshakeHash handshakeHash, IList supportedSignatureAlgorithms)
		{
		}

		public static bool HasSigningCapability(byte clientCertificateType)
		{
			return false;
		}

		public static TlsSigner CreateTlsSigner(byte clientCertificateType)
		{
			return null;
		}

		private static byte[][] GenSsl3Const()
		{
			return null;
		}

		private static IList VectorOfOne(object obj)
		{
			return null;
		}

		public static int GetCipherType(int ciphersuite)
		{
			return 0;
		}

		public static int GetEncryptionAlgorithm(int ciphersuite)
		{
			return 0;
		}

		public static int GetKeyExchangeAlgorithm(int ciphersuite)
		{
			return 0;
		}

		public static int GetMacAlgorithm(int ciphersuite)
		{
			return 0;
		}

		public static ProtocolVersion GetMinimumVersion(int ciphersuite)
		{
			return null;
		}

		public static bool IsAeadCipherSuite(int ciphersuite)
		{
			return false;
		}

		public static bool IsBlockCipherSuite(int ciphersuite)
		{
			return false;
		}

		public static bool HasBlockCipherSuite(int[] ciphersuites)
		{
			return false;
		}

		public static bool IsStreamCipherSuite(int ciphersuite)
		{
			return false;
		}

		public static bool IsValidCipherSuiteForSignatureAlgorithms(int cipherSuite, IList sigAlgs)
		{
			return false;
		}

		public static bool IsValidCipherSuiteForVersion(int cipherSuite, ProtocolVersion serverVersion)
		{
			return false;
		}

		public static IList GetUsableSignatureAlgorithms(IList sigHashAlgs)
		{
			return null;
		}
	}
}
