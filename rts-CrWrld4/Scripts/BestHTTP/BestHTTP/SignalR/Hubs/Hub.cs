using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using BestHTTP.SignalR.Messages;

namespace BestHTTP.SignalR.Hubs
{
	public class Hub : IHub
	{
		private Dictionary<string, object> state;

		private Dictionary<ulong, ClientMessage> SentMessages;

		private Dictionary<string, OnMethodCallCallbackDelegate> MethodTable;

		private StringBuilder builder;

		public string Name { get; private set; }

		public Dictionary<string, object> State => null;

		Connection IHub.Connection
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public event OnMethodCallDelegate OnMethodCall
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

		public Hub(string name)
		{
		}

		public Hub(string name, Connection manager)
		{
		}

		public void On(string method, OnMethodCallCallbackDelegate callback)
		{
		}

		public void Off(string method)
		{
		}

		public bool Call(string method, params object[] args)
		{
			return false;
		}

		public bool Call(string method, OnMethodResultDelegate onResult, params object[] args)
		{
			return false;
		}

		public bool Call(string method, OnMethodResultDelegate onResult, OnMethodFailedDelegate onResultError, params object[] args)
		{
			return false;
		}

		public bool Call(string method, OnMethodResultDelegate onResult, OnMethodProgressDelegate onProgress, params object[] args)
		{
			return false;
		}

		public bool Call(string method, OnMethodResultDelegate onResult, OnMethodFailedDelegate onResultError, OnMethodProgressDelegate onProgress, params object[] args)
		{
			return false;
		}

		bool IHub.Call(ClientMessage msg)
		{
			return false;
		}

		bool IHub.HasSentMessageId(ulong id)
		{
			return false;
		}

		void IHub.Close()
		{
		}

		void IHub.OnMethod(MethodCallMessage msg)
		{
		}

		void IHub.OnMessage(IServerMessage msg)
		{
		}

		private void MergeState(IDictionary<string, object> state)
		{
		}

		private string BuildMessage(ClientMessage msg)
		{
			return null;
		}
	}
}
