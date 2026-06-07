using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.CryptoPro
{
	public sealed class Gost3410NamedParameters
	{
		private static readonly IDictionary objIds;

		private static readonly IDictionary parameters;

		private static readonly Gost3410ParamSetParameters cryptoProA;

		private static readonly Gost3410ParamSetParameters cryptoProB;

		private static readonly Gost3410ParamSetParameters cryptoProXchA;

		public static IEnumerable Names => null;

		private Gost3410NamedParameters()
		{
		}

		static Gost3410NamedParameters()
		{
		}

		public static Gost3410ParamSetParameters GetByOid(DerObjectIdentifier oid)
		{
			return null;
		}

		public static Gost3410ParamSetParameters GetByName(string name)
		{
			return null;
		}

		public static DerObjectIdentifier GetOid(string name)
		{
			return null;
		}
	}
}
