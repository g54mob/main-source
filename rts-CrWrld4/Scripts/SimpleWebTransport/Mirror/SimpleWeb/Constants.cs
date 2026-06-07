namespace Mirror.SimpleWeb
{
	internal static class Constants
	{
		public const int HeaderSize = 4;

		public const int HeaderMinSize = 2;

		public const int ShortLength = 2;

		public const int MaskSize = 4;

		public const int BytePayloadLength = 125;

		public const int UshortPayloadLength = 126;

		public const int UlongPayloadLength = 127;

		public const string HandshakeGUID = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";

		public static readonly int HandshakeGUIDLength;

		public static readonly byte[] HandshakeGUIDBytes;

		public static readonly byte[] endOfHandshake;
	}
}
