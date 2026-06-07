using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.CryptoPro
{
	public sealed class ECGost3410NamedCurves
	{
		internal static readonly IDictionary objIds;

		internal static readonly IDictionary parameters;

		internal static readonly IDictionary names;

		public static IEnumerable Names => null;

		private static ECPoint ConfigureBasepoint(ECCurve curve, BigInteger x, BigInteger y)
		{
			return null;
		}

		private static ECCurve ConfigureCurve(ECCurve curve)
		{
			return null;
		}

		private ECGost3410NamedCurves()
		{
		}

		static ECGost3410NamedCurves()
		{
		}

		public static ECDomainParameters GetByOid(DerObjectIdentifier oid)
		{
			return null;
		}

		public static ECDomainParameters GetByName(string name)
		{
			return null;
		}

		public static string GetName(DerObjectIdentifier oid)
		{
			return null;
		}

		public static DerObjectIdentifier GetOid(string name)
		{
			return null;
		}
	}
}
