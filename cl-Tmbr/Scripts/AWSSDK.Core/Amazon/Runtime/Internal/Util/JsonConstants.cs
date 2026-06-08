using System;

namespace Amazon.Runtime.Internal.Util
{
	public static class JsonConstants
	{
		private static byte[] _utf8BomBytes = new byte[3] { 239, 187, 191 };

		public static ReadOnlySpan<byte> Utf8Bom => _utf8BomBytes;
	}
}
