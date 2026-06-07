using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Security
{
	public sealed class AgreementUtilities
	{
		private static readonly IDictionary algorithms;

		private AgreementUtilities()
		{
		}

		static AgreementUtilities()
		{
		}

		public static IBasicAgreement GetBasicAgreement(DerObjectIdentifier oid)
		{
			return null;
		}

		public static IBasicAgreement GetBasicAgreement(string algorithm)
		{
			return null;
		}

		public static IBasicAgreement GetBasicAgreementWithKdf(DerObjectIdentifier oid, string wrapAlgorithm)
		{
			return null;
		}

		public static IBasicAgreement GetBasicAgreementWithKdf(string agreeAlgorithm, string wrapAlgorithm)
		{
			return null;
		}

		public static IRawAgreement GetRawAgreement(DerObjectIdentifier oid)
		{
			return null;
		}

		public static IRawAgreement GetRawAgreement(string algorithm)
		{
			return null;
		}

		public static string GetAlgorithmName(DerObjectIdentifier oid)
		{
			return null;
		}

		private static string GetMechanism(string algorithm)
		{
			return null;
		}
	}
}
