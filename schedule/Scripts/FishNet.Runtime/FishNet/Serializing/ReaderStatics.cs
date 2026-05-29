using System;
using System.Text;
using FishNet.Documenting;

namespace FishNet.Serializing
{
	[APIExclude]
	internal class ReaderStatics
	{
		private static byte[] _guidBuffer;

		private static readonly UTF8Encoding _encoding;

		public static byte[] GetGuidBuffer()
		{
			return null;
		}

		public static string GetString(ArraySegment<byte> data)
		{
			return null;
		}
	}
}
