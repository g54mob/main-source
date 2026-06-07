using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Security
{
	public sealed class SignerUtilities
	{
		internal static readonly IDictionary algorithms;

		internal static readonly IDictionary oids;

		public static ICollection Algorithms => null;

		private SignerUtilities()
		{
		}

		static SignerUtilities()
		{
		}

		public static DerObjectIdentifier GetObjectIdentifier(string mechanism)
		{
			return null;
		}

		public static Asn1Encodable GetDefaultX509Parameters(DerObjectIdentifier id)
		{
			return null;
		}

		public static Asn1Encodable GetDefaultX509Parameters(string algorithm)
		{
			return null;
		}

		private static Asn1Encodable GetPssX509Parameters(string digestName)
		{
			return null;
		}

		public static ISigner GetSigner(DerObjectIdentifier id)
		{
			return null;
		}

		public static ISigner GetSigner(string algorithm)
		{
			return null;
		}

		public static string GetEncodingName(DerObjectIdentifier oid)
		{
			return null;
		}

		public static ISigner InitSigner(DerObjectIdentifier algorithmOid, bool forSigning, AsymmetricKeyParameter privateKey, SecureRandom random)
		{
			return null;
		}

		public static ISigner InitSigner(string algorithm, bool forSigning, AsymmetricKeyParameter privateKey, SecureRandom random)
		{
			return null;
		}
	}
}
