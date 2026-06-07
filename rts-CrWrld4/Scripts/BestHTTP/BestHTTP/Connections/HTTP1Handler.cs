using System;
using BestHTTP.Core;
using BestHTTP.Logger;

namespace BestHTTP.Connections
{
	public sealed class HTTP1Handler : IHTTPRequestHandler, IDisposable
	{
		private KeepAliveHeader _keepAlive;

		private readonly HTTPConnection conn;

		public bool HasCustomRequestProcessor => false;

		public KeepAliveHeader KeepAlive => null;

		public bool CanProcessMultiple => false;

		public LoggingContext Context { get; private set; }

		public ShutdownTypes ShutdownType { get; private set; }

		public HTTP1Handler(HTTPConnection conn)
		{
		}

		public void Process(HTTPRequest request)
		{
		}

		public void RunHandler()
		{
		}

		private void OnCancellationRequested(HTTPRequest obj)
		{
		}

		private bool Receive(HTTPRequest request)
		{
			return false;
		}

		public void Shutdown(ShutdownTypes type)
		{
		}

		public void Dispose()
		{
		}

		private void Dispose(bool disposing)
		{
		}

		~HTTP1Handler()
		{
		}
	}
}
