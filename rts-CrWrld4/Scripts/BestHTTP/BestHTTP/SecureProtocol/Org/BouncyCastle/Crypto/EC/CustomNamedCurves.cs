using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Endo;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.EC
{
	public sealed class CustomNamedCurves
	{
		internal class Curve25519Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Curve25519Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecP128R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecP128R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecP160K1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecP160K1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecP160R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecP160R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecP160R2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecP160R2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecP192K1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecP192K1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecP192R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecP192R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecP224K1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecP224K1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecP224R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecP224R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecP256K1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecP256K1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecP256R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecP256R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecP384R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecP384R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecP521R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecP521R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT113R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT113R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT113R2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT113R2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT131R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT131R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT131R2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT131R2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT163K1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT163K1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT163R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT163R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT163R2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT163R2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT193R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT193R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT193R2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT193R2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT233K1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT233K1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT233R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT233R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT239K1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT239K1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT283K1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT283K1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT283R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT283R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT409K1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT409K1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT409R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT409R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT571K1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT571K1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class SecT571R1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private SecT571R1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

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

		private static readonly IDictionary nameToCurve;

		private static readonly IDictionary nameToOid;

		private static readonly IDictionary oidToCurve;

		private static readonly IDictionary oidToName;

		private static readonly IList names;

		public static IEnumerable Names => null;

		private CustomNamedCurves()
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

		private static void DefineCurve(string name, X9ECParametersHolder holder)
		{
		}

		private static void DefineCurveWithOid(string name, DerObjectIdentifier oid, X9ECParametersHolder holder)
		{
		}

		private static void DefineCurveAlias(string name, DerObjectIdentifier oid)
		{
		}

		static CustomNamedCurves()
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
