using System;
using BestHTTP.Connections;
using BestHTTP.Logger;

namespace BestHTTP.Core
{
	public interface IHTTPRequestHandler : IDisposable
	{
		bool HasCustomRequestProcessor { get; }

		KeepAliveHeader KeepAlive { get; }

		bool CanProcessMultiple { get; }

		ShutdownTypes ShutdownType { get; }

		LoggingContext Context { get; }

		void Process(HTTPRequest request);

		void RunHandler();

		void Shutdown(ShutdownTypes type);
	}
}
