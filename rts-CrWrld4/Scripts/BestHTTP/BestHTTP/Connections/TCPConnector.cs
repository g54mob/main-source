using System;
using System.IO;
using BestHTTP.PlatformSupport.TcpClient.General;

namespace BestHTTP.Connections
{
	public sealed class TCPConnector : IDisposable
	{
		public bool IsConnected => false;

		public string NegotiatedProtocol { get; private set; }

		public TcpClient Client { get; private set; }

		public Stream TopmostStream { get; private set; }

		public Stream Stream { get; private set; }

		public bool LeaveOpen { get; set; }

		public void Connect(HTTPRequest request)
		{
		}

		public void Close()
		{
		}

		public void Dispose()
		{
		}

		private void Dispose(bool disposing)
		{
		}

		~TCPConnector()
		{
		}
	}
}
