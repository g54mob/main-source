using System;
using System.IO;

namespace BestHTTP.Caching
{
	public class HTTPCacheFileInfo : IComparable<HTTPCacheFileInfo>
	{
		public Uri Uri { get; private set; }

		public DateTime LastAccess { get; private set; }

		public int BodyLength { get; internal set; }

		public string ETag { get; private set; }

		public string LastModified { get; private set; }

		public DateTime Expires { get; private set; }

		public long Age { get; private set; }

		public long MaxAge { get; private set; }

		public DateTime Date { get; private set; }

		public bool MustRevalidate { get; private set; }

		public bool NoCache { get; private set; }

		public long StaleWhileRevalidate { get; private set; }

		public long StaleIfError { get; private set; }

		public DateTime Received { get; private set; }

		public string ConstructedPath { get; private set; }

		internal ulong MappedNameIDX { get; private set; }

		internal HTTPCacheFileInfo(Uri uri)
		{
		}

		internal HTTPCacheFileInfo(Uri uri, DateTime lastAcces, int bodyLength)
		{
		}

		internal HTTPCacheFileInfo(Uri uri, BinaryReader reader, int version)
		{
		}

		internal void SaveTo(BinaryWriter writer)
		{
		}

		public string GetPath()
		{
			return null;
		}

		public bool IsExists()
		{
			return false;
		}

		internal void Delete()
		{
		}

		private void Reset()
		{
		}

		internal void SetUpCachingValues(HTTPResponse response)
		{
		}

		public bool WillExpireInTheFuture(bool isInError)
		{
			return false;
		}

		internal void SetUpRevalidationHeaders(HTTPRequest request)
		{
		}

		public Stream GetBodyStream(out int length)
		{
			length = default(int);
			return null;
		}

		internal HTTPResponse ReadResponseTo(HTTPRequest request)
		{
			return null;
		}

		internal void Store(HTTPResponse response)
		{
		}

		internal Stream GetSaveStream(HTTPResponse response)
		{
			return null;
		}

		public int CompareTo(HTTPCacheFileInfo other)
		{
			return 0;
		}
	}
}
