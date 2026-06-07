using System.Collections.Generic;
using System.IO;

namespace NAudio.Wave
{
	public class Id3v2Tag
	{
		private long tagStartPosition;

		private long tagEndPosition;

		private byte[] rawData;

		public byte[] RawData => null;

		public static Id3v2Tag ReadTag(Stream input)
		{
			return null;
		}

		public static Id3v2Tag Create(IEnumerable<KeyValuePair<string, string>> tags)
		{
			return null;
		}

		private static byte[] FrameSizeToBytes(int n)
		{
			return null;
		}

		private static byte[] CreateId3v2Frame(string key, string value)
		{
			return null;
		}

		private static byte[] GetId3TagHeaderSize(int size)
		{
			return null;
		}

		private static byte[] CreateId3v2TagHeader(IEnumerable<byte[]> frames)
		{
			return null;
		}

		private static Stream CreateId3v2TagStream(IEnumerable<KeyValuePair<string, string>> tags)
		{
			return null;
		}

		private Id3v2Tag(Stream input)
		{
		}
	}
}
