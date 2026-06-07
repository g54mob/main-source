using System.Collections.Generic;
using System.IO;
using BestHTTP.Decompression;

namespace BestHTTP.Connections.HTTP2
{
	public sealed class HTTP2Response : HTTPResponse
	{
		private bool isPrepared;

		private GZipDecompressor decompressor;

		public int ExpectedContentLength { get; private set; }

		public bool IsCompressed { get; private set; }

		public HTTP2Response(HTTPRequest request, bool isFromCache)
			: base(null, isFromCache: false)
		{
		}

		internal void AddHeaders(List<KeyValuePair<string, string>> headers)
		{
		}

		internal void AddData(Stream stream)
		{
		}

		internal void ProcessData(byte[] payload, int payloadLength)
		{
		}

		internal void FinishProcessData()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
