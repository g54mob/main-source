using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	internal class ConstructedOctetStream : BaseInputStream
	{
		private readonly Asn1StreamParser _parser;

		private bool _first;

		private Stream _currentStream;

		internal ConstructedOctetStream(Asn1StreamParser parser)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override int ReadByte()
		{
			return 0;
		}

		private Asn1OctetStringParser GetNextParser()
		{
			return null;
		}
	}
}
