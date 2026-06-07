using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9
{
	public sealed class X962NamedCurves
	{
		internal class Prime192v1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Prime192v1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Prime192v2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Prime192v2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Prime192v3Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Prime192v3Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Prime239v1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Prime239v1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Prime239v2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Prime239v2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Prime239v3Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Prime239v3Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class Prime256v1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private Prime256v1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2pnb163v1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2pnb163v1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2pnb163v2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2pnb163v2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2pnb163v3Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2pnb163v3Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2pnb176w1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2pnb176w1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2tnb191v1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2tnb191v1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2tnb191v2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2tnb191v2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2tnb191v3Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2tnb191v3Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2pnb208w1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2pnb208w1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2tnb239v1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2tnb239v1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2tnb239v2Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2tnb239v2Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2tnb239v3Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2tnb239v3Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2pnb272w1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2pnb272w1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2pnb304w1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2pnb304w1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2tnb359v1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2tnb359v1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2pnb368w1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2pnb368w1Holder()
			{
			}

			protected override X9ECParameters CreateParameters()
			{
				return null;
			}
		}

		internal class C2tnb431r1Holder : X9ECParametersHolder
		{
			internal static readonly X9ECParametersHolder Instance;

			private C2tnb431r1Holder()
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

		private X962NamedCurves()
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

		static X962NamedCurves()
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
