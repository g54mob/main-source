using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	[Serializable]
	public class Asn1ParsingException : InvalidOperationException
	{
		public Asn1ParsingException()
		{
		}

		public Asn1ParsingException(string message)
		{
		}

		public Asn1ParsingException(string message, Exception exception)
		{
		}
	}
}
