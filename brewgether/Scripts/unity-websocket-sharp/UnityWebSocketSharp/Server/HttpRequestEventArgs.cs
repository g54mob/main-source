using System;
using System.Security.Principal;
using UnityWebSocketSharp.Net;

namespace UnityWebSocketSharp.Server
{
	internal class HttpRequestEventArgs : EventArgs
	{
		private HttpListenerContext _context;

		private string _docRootPath;

		public HttpListenerRequest Request => null;

		public HttpListenerResponse Response => null;

		public IPrincipal User => null;

		internal HttpRequestEventArgs(HttpListenerContext context, string documentRootPath)
		{
		}

		private string createFilePath(string childPath)
		{
			return null;
		}

		private static bool tryReadFile(string path, out byte[] contents)
		{
			contents = null;
			return false;
		}

		public byte[] ReadFile(string path)
		{
			return null;
		}

		public bool TryReadFile(string path, out byte[] contents)
		{
			contents = null;
			return false;
		}
	}
}
