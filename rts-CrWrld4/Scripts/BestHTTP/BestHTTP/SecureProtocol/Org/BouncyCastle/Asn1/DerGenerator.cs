using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public abstract class DerGenerator : Asn1Generator
	{
		private bool _tagged;

		private bool _isExplicit;

		private int _tagNo;

		protected DerGenerator(Stream outStream)
			: base(null)
		{
		}

		protected DerGenerator(Stream outStream, int tagNo, bool isExplicit)
			: base(null)
		{
		}

		private static void WriteLength(Stream outStr, int length)
		{
		}

		internal static void WriteDerEncoded(Stream outStream, int tag, byte[] bytes)
		{
		}

		internal void WriteDerEncoded(int tag, byte[] bytes)
		{
		}

		internal static void WriteDerEncoded(Stream outStr, int tag, Stream inStr)
		{
		}
	}
}
