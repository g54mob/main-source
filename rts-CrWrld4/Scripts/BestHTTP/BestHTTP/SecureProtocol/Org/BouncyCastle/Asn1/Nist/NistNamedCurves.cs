using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Nist
{
	public sealed class NistNamedCurves
	{
		private static readonly IDictionary objIds;

		private static readonly IDictionary names;

		public static IEnumerable Names => null;

		private NistNamedCurves()
		{
		}

		private static void DefineCurveAlias(string name, DerObjectIdentifier oid)
		{
		}

		static NistNamedCurves()
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
