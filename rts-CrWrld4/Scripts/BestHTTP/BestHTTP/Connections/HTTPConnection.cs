using System;
using BestHTTP.Core;

namespace BestHTTP.Connections
{
	public sealed class HTTPConnection : ConnectionBase
	{
		public TCPConnector connector;

		public IHTTPRequestHandler requestHandler;

		public override TimeSpan KeepAliveTime
		{
			get
			{
				return default(TimeSpan);
			}
			protected set
			{
			}
		}

		public override bool CanProcessMultiple => false;

		internal HTTPConnection(string serverAddress)
			: base(null)
		{
		}

		internal override void Process(HTTPRequest request)
		{
		}

		protected override void ThreadFunc()
		{
		}

		public override void Shutdown(ShutdownTypes type)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
