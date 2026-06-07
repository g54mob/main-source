using System.Collections.Generic;
using System.IO;

namespace BestHTTP.Connections.HTTP2
{
	public sealed class HPACKEncoder
	{
		private HTTP2SettingsManager settingsRegistry;

		private HeaderTable requestTable;

		private HeaderTable responseTable;

		private HTTP2Handler parent;

		public HPACKEncoder(HTTP2Handler parentHandler, HTTP2SettingsManager registry)
		{
		}

		public void Encode(HTTP2Stream context, HTTPRequest request, Queue<HTTP2FrameHeaderAndPayload> to, uint streamId)
		{
		}

		public void Decode(HTTP2Stream context, Stream stream, List<KeyValuePair<string, string>> to)
		{
		}

		private KeyValuePair<string, string> ReadIndexedHeader(byte firstByte, Stream stream)
		{
			return default(KeyValuePair<string, string>);
		}

		private KeyValuePair<string, string> ReadLiteralHeaderFieldWithIncrementalIndexing_IndexedName(byte firstByte, Stream stream)
		{
			return default(KeyValuePair<string, string>);
		}

		private KeyValuePair<string, string> ReadLiteralHeaderFieldWithIncrementalIndexing_NewName(byte firstByte, Stream stream)
		{
			return default(KeyValuePair<string, string>);
		}

		private KeyValuePair<string, string> ReadLiteralHeaderFieldwithoutIndexing_IndexedName(byte firstByte, Stream stream)
		{
			return default(KeyValuePair<string, string>);
		}

		private KeyValuePair<string, string> ReadLiteralHeaderFieldwithoutIndexing_NewName(byte firstByte, Stream stream)
		{
			return default(KeyValuePair<string, string>);
		}

		private KeyValuePair<string, string> ReadLiteralHeaderFieldNeverIndexed_IndexedName(byte firstByte, Stream stream)
		{
			return default(KeyValuePair<string, string>);
		}

		private KeyValuePair<string, string> ReadLiteralHeaderFieldNeverIndexed_NewName(byte firstByte, Stream stream)
		{
			return default(KeyValuePair<string, string>);
		}

		private string DecodeString(Stream stream)
		{
			return null;
		}

		private void CreateHeaderFrames(Queue<HTTP2FrameHeaderAndPayload> to, uint streamId, byte[] dataToSend, uint payloadLength, bool hasBody)
		{
		}

		private void WriteHeader(Stream stream, string header, string value)
		{
		}

		private static void WriteIndexedHeaderField(Stream stream, uint index)
		{
		}

		private static void WriteLiteralHeaderFieldWithIncrementalIndexing_IndexedName(Stream stream, uint index, string value)
		{
		}

		private static void WriteLiteralHeaderFieldWithIncrementalIndexing_NewName(Stream stream, string header, string value)
		{
		}

		private static void WriteLiteralHeaderFieldWithoutIndexing_IndexedName(Stream stream, uint index, string value)
		{
		}

		private static void WriteLiteralHeaderFieldWithoutIndexing_NewName(Stream stream, string header, string value)
		{
		}

		private static void WriteLiteralHeaderFieldNeverIndexed_IndexedName(Stream stream, uint index, string value)
		{
		}

		private static void WriteLiteralHeaderFieldNeverIndexed_NewName(Stream stream, string header, string value)
		{
		}

		private static void WriteDynamicTableSizeUpdate(Stream stream, ushort maxSize)
		{
		}

		private static uint RequiredBytesToEncodeString(string str)
		{
			return 0u;
		}

		private static void EncodeString(string str, byte[] buffer, ref uint offset)
		{
		}

		private static uint RequiredBytesToEncodeStringWithHuffman(string str)
		{
			return 0u;
		}

		private static void EncodeStringWithHuffman(string str, uint encodedLength, byte[] buffer, ref uint offset)
		{
		}

		private static void AddCodePointToBuffer(HuffmanEncoder.TableEntry code, byte[] buffer, ref uint offset, ref byte bufferBitIdx, bool finishOnBoundary = false)
		{
		}

		private static uint RequiredBytesToEncodeRawString(string str)
		{
			return 0u;
		}

		private static void EncodeRawStringTo(string str, byte[] buffer, ref uint offset)
		{
		}

		private static byte RequiredBytesToEncodeInteger(uint value, byte N)
		{
			return 0;
		}

		private static void EncodeInteger(uint value, byte N, byte[] buffer, ref uint offset)
		{
		}

		private static uint DecodeInteger(byte N, byte[] buffer, ref uint offset)
		{
			return 0u;
		}

		private static uint DecodeInteger(byte N, byte data, Stream stream)
		{
			return 0u;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
