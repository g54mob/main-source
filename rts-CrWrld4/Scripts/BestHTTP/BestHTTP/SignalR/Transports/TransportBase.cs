using System.Runtime.CompilerServices;
using BestHTTP.SignalR.JsonEncoders;
using BestHTTP.SignalR.Messages;

namespace BestHTTP.SignalR.Transports
{
	public abstract class TransportBase
	{
		private const int MaxRetryCount = 5;

		public TransportStates _state;

		public string Name { get; protected set; }

		public abstract bool SupportsKeepAlive { get; }

		public abstract TransportTypes Type { get; }

		public IConnection Connection { get; protected set; }

		public TransportStates State
		{
			get
			{
				return default(TransportStates);
			}
			protected set
			{
			}
		}

		public event OnTransportStateChangedDelegate OnStateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public TransportBase(string name, Connection connection)
		{
		}

		public abstract void Connect();

		public abstract void Stop();

		protected abstract void SendImpl(string json);

		protected abstract void Started();

		protected abstract void Aborted();

		protected void OnConnected()
		{
		}

		protected void Start()
		{
		}

		private void OnStartRequestFinished(HTTPRequest req, HTTPResponse resp)
		{
		}

		public virtual void Abort()
		{
		}

		protected void AbortFinished()
		{
		}

		private void OnAbortRequestFinished(HTTPRequest req, HTTPResponse resp)
		{
		}

		public void Send(string jsonStr)
		{
		}

		public void Reconnect()
		{
		}

		public static IServerMessage Parse(IJsonEncoder encoder, string json)
		{
			return null;
		}
	}
}
