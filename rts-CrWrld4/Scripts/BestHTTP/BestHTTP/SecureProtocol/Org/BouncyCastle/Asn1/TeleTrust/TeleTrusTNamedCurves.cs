using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.TeleTrust
{
	public class TeleTrusTNamedCurves
	{
		internal class BrainpoolP160r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private BrainpoolP160r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class BrainpoolP160t1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private BrainpoolP160t1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class BrainpoolP192r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private BrainpoolP192r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class BrainpoolP192t1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private BrainpoolP192t1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class BrainpoolP224r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private BrainpoolP224r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class BrainpoolP224t1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private BrainpoolP224t1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class BrainpoolP256r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private BrainpoolP256r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class BrainpoolP256t1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private BrainpoolP256t1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class BrainpoolP320r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private BrainpoolP320r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class BrainpoolP320t1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private BrainpoolP320t1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class BrainpoolP384r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private BrainpoolP384r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class BrainpoolP384t1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private BrainpoolP384t1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class BrainpoolP512r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private BrainpoolP512r1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class BrainpoolP512t1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private BrainpoolP512t1Holder()
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

		static TeleTrusTNamedCurves()
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

		public static DerObjectIdentifier GetOid(short curvesize, bool twisted)
		{
			return null;
		}
	}
}
