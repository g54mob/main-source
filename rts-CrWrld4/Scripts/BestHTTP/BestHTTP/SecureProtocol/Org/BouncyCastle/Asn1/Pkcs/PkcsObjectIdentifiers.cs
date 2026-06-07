namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public abstract class PkcsObjectIdentifiers
	{
		public const string Pkcs1 = "1.2.840.113549.1.1";

		internal static readonly DerObjectIdentifier Pkcs1Oid;

		public static readonly DerObjectIdentifier RsaEncryption;

		public static readonly DerObjectIdentifier MD2WithRsaEncryption;

		public static readonly DerObjectIdentifier MD4WithRsaEncryption;

		public static readonly DerObjectIdentifier MD5WithRsaEncryption;

		public static readonly DerObjectIdentifier Sha1WithRsaEncryption;

		public static readonly DerObjectIdentifier SrsaOaepEncryptionSet;

		public static readonly DerObjectIdentifier IdRsaesOaep;

		public static readonly DerObjectIdentifier IdMgf1;

		public static readonly DerObjectIdentifier IdPSpecified;

		public static readonly DerObjectIdentifier IdRsassaPss;

		public static readonly DerObjectIdentifier Sha256WithRsaEncryption;

		public static readonly DerObjectIdentifier Sha384WithRsaEncryption;

		public static readonly DerObjectIdentifier Sha512WithRsaEncryption;

		public static readonly DerObjectIdentifier Sha224WithRsaEncryption;

		public static readonly DerObjectIdentifier Sha512_224WithRSAEncryption;

		public static readonly DerObjectIdentifier Sha512_256WithRSAEncryption;

		public const string Pkcs3 = "1.2.840.113549.1.3";

		public static readonly DerObjectIdentifier DhKeyAgreement;

		public const string Pkcs5 = "1.2.840.113549.1.5";

		public static readonly DerObjectIdentifier PbeWithMD2AndDesCbc;

		public static readonly DerObjectIdentifier PbeWithMD2AndRC2Cbc;

		public static readonly DerObjectIdentifier PbeWithMD5AndDesCbc;

		public static readonly DerObjectIdentifier PbeWithMD5AndRC2Cbc;

		public static readonly DerObjectIdentifier PbeWithSha1AndDesCbc;

		public static readonly DerObjectIdentifier PbeWithSha1AndRC2Cbc;

		public static readonly DerObjectIdentifier IdPbeS2;

		public static readonly DerObjectIdentifier IdPbkdf2;

		public const string EncryptionAlgorithm = "1.2.840.113549.3";

		public static readonly DerObjectIdentifier DesEde3Cbc;

		public static readonly DerObjectIdentifier RC2Cbc;

		public static readonly DerObjectIdentifier rc4;

		public const string DigestAlgorithm = "1.2.840.113549.2";

		public static readonly DerObjectIdentifier MD2;

		public static readonly DerObjectIdentifier MD4;

		public static readonly DerObjectIdentifier MD5;

		public static readonly DerObjectIdentifier IdHmacWithSha1;

		public static readonly DerObjectIdentifier IdHmacWithSha224;

		public static readonly DerObjectIdentifier IdHmacWithSha256;

		public static readonly DerObjectIdentifier IdHmacWithSha384;

		public static readonly DerObjectIdentifier IdHmacWithSha512;

		public const string Pkcs7 = "1.2.840.113549.1.7";

		public static readonly DerObjectIdentifier Data;

		public static readonly DerObjectIdentifier SignedData;

		public static readonly DerObjectIdentifier EnvelopedData;

		public static readonly DerObjectIdentifier SignedAndEnvelopedData;

		public static readonly DerObjectIdentifier DigestedData;

		public static readonly DerObjectIdentifier EncryptedData;

		public const string Pkcs9 = "1.2.840.113549.1.9";

		public static readonly DerObjectIdentifier Pkcs9AtEmailAddress;

		public static readonly DerObjectIdentifier Pkcs9AtUnstructuredName;

		public static readonly DerObjectIdentifier Pkcs9AtContentType;

		public static readonly DerObjectIdentifier Pkcs9AtMessageDigest;

		public static readonly DerObjectIdentifier Pkcs9AtSigningTime;

		public static readonly DerObjectIdentifier Pkcs9AtCounterSignature;

		public static readonly DerObjectIdentifier Pkcs9AtChallengePassword;

		public static readonly DerObjectIdentifier Pkcs9AtUnstructuredAddress;

		public static readonly DerObjectIdentifier Pkcs9AtExtendedCertificateAttributes;

		public static readonly DerObjectIdentifier Pkcs9AtSigningDescription;

		public static readonly DerObjectIdentifier Pkcs9AtExtensionRequest;

		public static readonly DerObjectIdentifier Pkcs9AtSmimeCapabilities;

		public static readonly DerObjectIdentifier IdSmime;

		public static readonly DerObjectIdentifier Pkcs9AtFriendlyName;

		public static readonly DerObjectIdentifier Pkcs9AtLocalKeyID;

		public static readonly DerObjectIdentifier X509CertType;

		public const string CertTypes = "1.2.840.113549.1.9.22";

		public static readonly DerObjectIdentifier X509Certificate;

		public static readonly DerObjectIdentifier SdsiCertificate;

		public const string CrlTypes = "1.2.840.113549.1.9.23";

		public static readonly DerObjectIdentifier X509Crl;

		public static readonly DerObjectIdentifier IdAlg;

		public static readonly DerObjectIdentifier IdAlgEsdh;

		public static readonly DerObjectIdentifier IdAlgCms3DesWrap;

		public static readonly DerObjectIdentifier IdAlgCmsRC2Wrap;

		public static readonly DerObjectIdentifier IdAlgPwriKek;

		public static readonly DerObjectIdentifier IdAlgSsdh;

		public static readonly DerObjectIdentifier IdRsaKem;

		public static readonly DerObjectIdentifier IdAlgAeadChaCha20Poly1305;

		public static readonly DerObjectIdentifier PreferSignedData;

		public static readonly DerObjectIdentifier CannotDecryptAny;

		public static readonly DerObjectIdentifier SmimeCapabilitiesVersions;

		public static readonly DerObjectIdentifier IdAAReceiptRequest;

		public const string IdCT = "1.2.840.113549.1.9.16.1";

		public static readonly DerObjectIdentifier IdCTAuthData;

		public static readonly DerObjectIdentifier IdCTTstInfo;

		public static readonly DerObjectIdentifier IdCTCompressedData;

		public static readonly DerObjectIdentifier IdCTAuthEnvelopedData;

		public static readonly DerObjectIdentifier IdCTTimestampedData;

		public const string IdCti = "1.2.840.113549.1.9.16.6";

		public static readonly DerObjectIdentifier IdCtiEtsProofOfOrigin;

		public static readonly DerObjectIdentifier IdCtiEtsProofOfReceipt;

		public static readonly DerObjectIdentifier IdCtiEtsProofOfDelivery;

		public static readonly DerObjectIdentifier IdCtiEtsProofOfSender;

		public static readonly DerObjectIdentifier IdCtiEtsProofOfApproval;

		public static readonly DerObjectIdentifier IdCtiEtsProofOfCreation;

		public const string IdAA = "1.2.840.113549.1.9.16.2";

		public static readonly DerObjectIdentifier IdAAOid;

		public static readonly DerObjectIdentifier IdAAContentHint;

		public static readonly DerObjectIdentifier IdAAMsgSigDigest;

		public static readonly DerObjectIdentifier IdAAContentReference;

		public static readonly DerObjectIdentifier IdAAEncrypKeyPref;

		public static readonly DerObjectIdentifier IdAASigningCertificate;

		public static readonly DerObjectIdentifier IdAASigningCertificateV2;

		public static readonly DerObjectIdentifier IdAAContentIdentifier;

		public static readonly DerObjectIdentifier IdAASignatureTimeStampToken;

		public static readonly DerObjectIdentifier IdAAEtsSigPolicyID;

		public static readonly DerObjectIdentifier IdAAEtsCommitmentType;

		public static readonly DerObjectIdentifier IdAAEtsSignerLocation;

		public static readonly DerObjectIdentifier IdAAEtsSignerAttr;

		public static readonly DerObjectIdentifier IdAAEtsOtherSigCert;

		public static readonly DerObjectIdentifier IdAAEtsContentTimestamp;

		public static readonly DerObjectIdentifier IdAAEtsCertificateRefs;

		public static readonly DerObjectIdentifier IdAAEtsRevocationRefs;

		public static readonly DerObjectIdentifier IdAAEtsCertValues;

		public static readonly DerObjectIdentifier IdAAEtsRevocationValues;

		public static readonly DerObjectIdentifier IdAAEtsEscTimeStamp;

		public static readonly DerObjectIdentifier IdAAEtsCertCrlTimestamp;

		public static readonly DerObjectIdentifier IdAAEtsArchiveTimestamp;

		public static readonly DerObjectIdentifier IdAADecryptKeyID;

		public static readonly DerObjectIdentifier IdAAImplCryptoAlgs;

		public static readonly DerObjectIdentifier IdAAAsymmDecryptKeyID;

		public static readonly DerObjectIdentifier IdAAImplCompressAlgs;

		public static readonly DerObjectIdentifier IdAACommunityIdentifiers;

		public static readonly DerObjectIdentifier IdAASigPolicyID;

		public static readonly DerObjectIdentifier IdAACommitmentType;

		public static readonly DerObjectIdentifier IdAASignerLocation;

		public static readonly DerObjectIdentifier IdAAOtherSigCert;

		public const string IdSpq = "1.2.840.113549.1.9.16.5";

		public static readonly DerObjectIdentifier IdSpqEtsUri;

		public static readonly DerObjectIdentifier IdSpqEtsUNotice;

		public const string Pkcs12 = "1.2.840.113549.1.12";

		public const string BagTypes = "1.2.840.113549.1.12.10.1";

		public static readonly DerObjectIdentifier KeyBag;

		public static readonly DerObjectIdentifier Pkcs8ShroudedKeyBag;

		public static readonly DerObjectIdentifier CertBag;

		public static readonly DerObjectIdentifier CrlBag;

		public static readonly DerObjectIdentifier SecretBag;

		public static readonly DerObjectIdentifier SafeContentsBag;

		public const string Pkcs12PbeIds = "1.2.840.113549.1.12.1";

		public static readonly DerObjectIdentifier PbeWithShaAnd128BitRC4;

		public static readonly DerObjectIdentifier PbeWithShaAnd40BitRC4;

		public static readonly DerObjectIdentifier PbeWithShaAnd3KeyTripleDesCbc;

		public static readonly DerObjectIdentifier PbeWithShaAnd2KeyTripleDesCbc;

		public static readonly DerObjectIdentifier PbeWithShaAnd128BitRC2Cbc;

		public static readonly DerObjectIdentifier PbewithShaAnd40BitRC2Cbc;
	}
}
