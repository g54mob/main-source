using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.GM
{
	public sealed class GMNamedCurves
	{
		internal class SM2P256V1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SM2P256V1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class WapiP192V1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private WapiP192V1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		private static readonly IDictionary objIds;

		private static readonly IDictionary curves;

		private static readonly IDictionary names;

		public static IEnumerable Names => null;

		private GMNamedCurves()
		{
		}

		private static X9ECPoint ConfigureBasepoint(ECCurve curve, string encoding)
		{
			return null;
		}

		private static ECCurve ConfigureCurve(ECCurve curve)
		{
			return null;
		}

		private static BigInteger FromHex(string hex)
		{
			return null;
		}

		private static void DefineCurve(string name, DerObjectIdentifier oid, X9ECParametersHolder holder)
		{
		}

		static GMNamedCurves()
		{
		}

		public static X9ECParameters GetByName(string name)
		{
			return null;
		}

		public static X9ECParameters GetByOid(DerObjectIdentifier oid)
		{
			return null;
		}

		public static DerObjectIdentifier GetOid(string name)
		{
			return null;
		}

		public static string GetName(DerObjectIdentifier oid)
		{
			return null;
		}
	}
}
