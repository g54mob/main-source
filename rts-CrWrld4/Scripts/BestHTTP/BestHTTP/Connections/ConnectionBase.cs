using System;
using BestHTTP.Logger;

namespace BestHTTP.Connections
{
	public abstract class ConnectionBase : IDisposable
	{
		internal LoggingContext Context;

		private bool IsThreaded;

		public string ServerAddress { get; protected set; }

		public HTTPConnectionStates State { get; internal set; }

		public HTTPRequest CurrentRequest { get; internal set; }

		public virtual TimeSpan KeepAliveTime { get; protected set; }

		public virtual bool CanProcessMultiple => false;

		public DateTime StartTime { get; protected set; }

		public Uri LastProcessedUri { get; protected set; }

		public DateTime LastProcessTime { get; protected set; }

		public ShutdownTypes ShutdownType { get; protected set; }

		public ConnectionBase(string serverAddress)
		{
		}

		public ConnectionBase(string serverAddress, bool threaded)
		{
		}

		internal virtual void Process(HTTPRequest request)
		{
		}

		protected virtual void ThreadFunc()
		{
		}

		public virtual void Shutdown(ShutdownTypes type)
		{
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		~ConnectionBase()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
