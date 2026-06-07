using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using BestHTTP.Caching;
using BestHTTP.Cookies;
using BestHTTP.Extensions;
using BestHTTP.Logger;
using UnityEngine;

namespace BestHTTP
{
	public class HTTPResponse : IDisposable
	{
		internal const byte CR = 13;

		internal const byte LF = 10;

		public static int MinReadBufferSize;

		protected string dataAsText;

		protected Texture2D texture;

		internal long UnprocessedFragments;

		internal HTTPRequest baseRequest;

		protected Stream Stream;

		protected byte[] fragmentBuffer;

		protected int fragmentBufferDataLength;

		protected Stream cacheStream;

		protected int allFragmentSize;

		public int VersionMajor { get; protected set; }

		public int VersionMinor { get; protected set; }

		public int StatusCode { get; protected set; }

		public bool IsSuccess => false;

		public string Message { get; protected set; }

		public bool IsStreamed { get; protected set; }

		public bool IsFromCache { get; internal set; }

		public HTTPCacheFileInfo CacheFileInfo { get; internal set; }

		public bool IsCacheOnly { get; private set; }

		public bool IsProxyResponse { get; private set; }

		public Dictionary<string, List<string>> Headers { get; protected set; }

		public byte[] Data { get; internal set; }

		public bool IsUpgraded { get; protected set; }

		public List<Cookie> Cookies { get; internal set; }

		public string DataAsText => null;

		public Texture2D DataAsTexture2D => null;

		public bool IsClosedManually { get; protected set; }

		public LoggingContext Context { get; private set; }

		protected HTTPResponse(HTTPRequest request, bool isFromCache)
		{
		}

		public HTTPResponse(HTTPRequest request, Stream stream, bool isStreamed, bool isFromCache, bool isProxyResponse = false)
		{
		}

		public virtual bool Receive(int forceReadRawContentLength = -1, bool readPayloadData = true, bool sendUpgradedEvent = true)
		{
			return false;
		}

		protected bool ReadPayload(int forceReadRawContentLength)
		{
			return false;
		}

		protected void ReadHeaders(Stream stream)
		{
		}

		public void AddHeader(string name, string value)
		{
		}

		public List<string> GetHeaderValues(string name)
		{
			return null;
		}

		public string GetFirstHeaderValue(string name)
		{
			return null;
		}

		public bool HasHeaderWithValue(string headerName, string value)
		{
			return false;
		}

		public bool HasHeader(string headerName)
		{
			return false;
		}

		public HTTPRange GetRange()
		{
			return null;
		}

		internal static string ReadTo(Stream stream, byte blocker)
		{
			return null;
		}

		internal static string ReadTo(Stream stream, byte blocker1, byte blocker2)
		{
			return null;
		}

		internal static string NoTrimReadTo(Stream stream, byte blocker1, byte blocker2)
		{
			return null;
		}

		protected int ReadChunkLength(Stream stream)
		{
			return 0;
		}

		protected void ReadChunked(Stream stream)
		{
		}

		internal void ReadRaw(Stream stream, long contentLength)
		{
		}

		protected void ReadUnknownSize(Stream stream)
		{
		}

		protected byte[] DecodeStream(BufferPoolMemoryStream streamToDecode)
		{
			return null;
		}

		protected void BeginReceiveStreamFragments()
		{
		}

		protected void FeedStreamFragment(byte[] buffer, int pos, int length)
		{
		}

		protected void FlushRemainingFragmentBuffer()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void AddStreamedFragment(byte[] buffer, int bufferLength)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool FragmentQueueIsFull()
		{
			return false;
		}

		private void VerboseLogging(string str)
		{
		}

		public void Dispose()
		{
		}

		~HTTPResponse()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
