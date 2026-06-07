using System.Text;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Utilities
{
	public sealed class Asn1Dump
	{
		private static readonly string NewLine;

		private const string Tab = "    ";

		private const int SampleSize = 32;

		private Asn1Dump()
		{
		}

		private static void AsString(string indent, bool verbose, Asn1Object obj, StringBuilder buf)
		{
		}

		private static string outputApplicationSpecific(string type, string indent, bool verbose, DerApplicationSpecific app)
		{
			return null;
		}

		public static string DumpAsString(object obj)
		{
			return null;
		}

		public static string DumpAsString(Asn1Encodable obj)
		{
			return null;
		}

		public static string DumpAsString(Asn1Encodable obj, bool verbose)
		{
			return null;
		}

		private static string dumpBinaryDataAsString(string indent, byte[] bytes)
		{
			return null;
		}

		private static string calculateAscString(byte[] bytes, int off, int len)
		{
			return null;
		}
	}
}
