using System.Text;

namespace Mono.Security.X509
{
	public sealed class X501
	{
		private static byte[] countryName;

		private static byte[] organizationName;

		private static byte[] organizationalUnitName;

		private static byte[] commonName;

		private static byte[] localityName;

		private static byte[] stateOrProvinceName;

		private static byte[] streetAddress;

		private static byte[] serialNumber;

		private static byte[] domainComponent;

		private static byte[] userid;

		private static byte[] email;

		private static byte[] dnQualifier;

		private static byte[] title;

		private static byte[] surname;

		private static byte[] givenName;

		private static byte[] initial;

		public static string ToString(ASN1 seq)
		{
			return null;
		}

		public static string ToString(ASN1 seq, bool reversed, string separator, bool quotes)
		{
			return null;
		}

		private static void AppendEntry(StringBuilder sb, ASN1 entry, bool quotes)
		{
		}

		private static X520.AttributeTypeAndValue GetAttributeFromOid(string attributeType)
		{
			return null;
		}

		private static bool IsOid(string oid)
		{
			return false;
		}

		private static X520.AttributeTypeAndValue ReadAttribute(string value, ref int pos)
		{
			return null;
		}

		private static bool IsHex(char c)
		{
			return false;
		}

		private static string ReadHex(string value, ref int pos)
		{
			return null;
		}

		private static int ReadEscaped(StringBuilder sb, string value, int pos)
		{
			return 0;
		}

		private static int ReadQuoted(StringBuilder sb, string value, int pos)
		{
			return 0;
		}

		private static string ReadValue(string value, ref int pos)
		{
			return null;
		}

		public static ASN1 FromString(string rdn)
		{
			return null;
		}
	}
}
