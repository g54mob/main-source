using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Endo;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Sec
{
	public sealed class SecNamedCurves
	{
		internal class Secp112r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp112r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Secp112r2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp112r2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Secp128r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp128r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Secp128r2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp128r2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Secp160k1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp160k1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Secp160r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp160r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Secp160r2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp160r2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Secp192k1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp192k1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Secp192r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp192r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Secp224k1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp224k1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Secp224r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp224r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Secp256k1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp256k1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Secp256r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp256r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Secp384r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp384r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Secp521r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Secp521r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect113r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 113;

			private const int k = 9;

			private Sect113r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect113r2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 113;

			private const int k = 9;

			private Sect113r2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect131r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 131;

			private const int k1 = 2;

			private const int k2 = 3;

			private const int k3 = 8;

			private Sect131r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect131r2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 131;

			private const int k1 = 2;

			private const int k2 = 3;

			private const int k3 = 8;

			private Sect131r2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect163k1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 163;

			private const int k1 = 3;

			private const int k2 = 6;

			private const int k3 = 7;

			private Sect163k1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect163r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 163;

			private const int k1 = 3;

			private const int k2 = 6;

			private const int k3 = 7;

			private Sect163r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect163r2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 163;

			private const int k1 = 3;

			private const int k2 = 6;

			private const int k3 = 7;

			private Sect163r2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect193r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 193;

			private const int k = 15;

			private Sect193r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect193r2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 193;

			private const int k = 15;

			private Sect193r2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect233k1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 233;

			private const int k = 74;

			private Sect233k1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect233r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 233;

			private const int k = 74;

			private Sect233r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect239k1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 239;

			private const int k = 158;

			private Sect239k1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect283k1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 283;

			private const int k1 = 5;

			private const int k2 = 7;

			private const int k3 = 12;

			private Sect283k1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect283r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 283;

			private const int k1 = 5;

			private const int k2 = 7;

			private const int k3 = 12;

			private Sect283r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect409k1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 409;

			private const int k = 87;

			private Sect409k1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect409r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 409;

			private const int k = 87;

			private Sect409r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect571k1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 571;

			private const int k1 = 2;

			private const int k2 = 5;

			private const int k3 = 10;

			private Sect571k1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Sect571r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private const int m = 571;

			private const int k1 = 2;

			private const int k2 = 5;

			private const int k3 = 10;

			private Sect571r1Holder()
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

		private SecNamedCurves()
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

		private static ECCurve ConfigureCurveGlv(ECCurve c, GlvTypeBParameters p)
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

		static SecNamedCurves()
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
