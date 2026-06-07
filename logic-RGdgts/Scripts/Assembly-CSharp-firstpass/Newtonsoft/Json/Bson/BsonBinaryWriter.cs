using System;
using System.IO;
using System.Text;

namespace Newtonsoft.Json.Bson
{
	internal class BsonBinaryWriter
	{
		private static readonly Encoding Encoding;

		private readonly BinaryWriter _writer;

		private byte[] _largeByteBuffer;

		public DateTimeKind DateTimeKindHandling { get; set; }

		public BsonBinaryWriter(BinaryWriter writer)
		{
		}

		public void Flush()
		{
		}

		public void Close()
		{
		}

		public void WriteToken(Newtonsoft.Json.Bson.BsonToken t)
		{
		}

		private void WriteTokenInternal(Newtonsoft.Json.Bson.BsonToken t)
		{
		}

		private long TicksFromDateObject(object value)
		{
			return 0L;
		}

		private void WriteString(string s, int byteCount, int? calculatedlengthPrefix)
		{
		}

		public void WriteUtf8Bytes(string s, int byteCount)
		{
		}

		private int CalculateSize(int stringByteCount)
		{
			return 0;
		}

		private int CalculateSizeWithLength(int stringByteCount, bool includeSize)
		{
			return 0;
		}

		private int CalculateSize(Newtonsoft.Json.Bson.BsonToken t)
		{
			return 0;
		}
	}
}
