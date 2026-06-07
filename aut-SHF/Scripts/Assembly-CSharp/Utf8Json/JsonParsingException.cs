using System;

namespace Utf8Json
{
	public class JsonParsingException : Exception
	{
		private WeakReference underyingBytes;

		private int limit;

		public int Offset { get; private set; }

		public string ActualChar { get; set; }

		public JsonParsingException(string message)
		{
		}

		public JsonParsingException(string message, byte[] underlyingBytes, int offset, int limit, string actualChar)
		{
		}

		public byte[] GetUnderlyingByteArrayUnsafe()
		{
			return null;
		}

		public string GetUnderlyingStringUnsafe()
		{
			return null;
		}
	}
}
