using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace BestHTTP
{
	public static class HTTPRequestAsyncExtensions
	{
		public static Task<HTTPResponse> GetHTTPResponseAsync(this HTTPRequest request, CancellationToken token = default(CancellationToken))
		{
			return null;
		}

		public static Task<string> GetAsStringAsync(this HTTPRequest request, CancellationToken token = default(CancellationToken))
		{
			return null;
		}

		public static Task<Texture2D> GetAsTexture2DAsync(this HTTPRequest request, CancellationToken token = default(CancellationToken))
		{
			return null;
		}

		public static Task<byte[]> GetRawDataAsync(this HTTPRequest request, CancellationToken token = default(CancellationToken))
		{
			return null;
		}

		[EditorBrowsable]
		public static Task<T> CreateTask<T>(HTTPRequest request, CancellationToken token, Action<HTTPRequest, HTTPResponse, TaskCompletionSource<T>> callback)
		{
			return null;
		}

		[EditorBrowsable]
		public static void VerboseLogging(HTTPRequest request, string str)
		{
		}

		[EditorBrowsable]
		public static Exception CreateException(string errorMessage, HTTPResponse resp = null, Exception ex = null)
		{
			return null;
		}
	}
}
