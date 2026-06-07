using System;
using System.Collections.Generic;
using System.IO;
using BestHTTP.Connections;
using BestHTTP.Logger;

namespace BestHTTP.Core
{
	public sealed class HostConnection
	{
		private List<ConnectionBase> Connections;

		private List<HTTPRequest> Queue;

		public HostDefinition Host { get; private set; }

		public string VariantId { get; private set; }

		public HostProtocolSupport ProtocolSupport { get; private set; }

		public DateTime LastProtocolSupportUpdate { get; private set; }

		public int QueuedRequests => 0;

		public LoggingContext Context { get; private set; }

		public HostConnection(HostDefinition host, string variantId)
		{
		}

		internal void AddProtocol(HostProtocolSupport protocolSupport)
		{
		}

		internal HostConnection Send(HTTPRequest request)
		{
			return null;
		}

		internal ConnectionBase GetNextAvailable(HTTPRequest request)
		{
			return null;
		}

		internal HostConnection RecycleConnection(ConnectionBase conn)
		{
			return null;
		}

		internal HostConnection RemoveConnection(ConnectionBase conn, HTTPConnectionStates setState)
		{
			return null;
		}

		internal HostConnection TryToSendQueuedRequests()
		{
			return null;
		}

		public ConnectionBase Find(Predicate<ConnectionBase> match)
		{
			return null;
		}

		private bool CloseConnectionAfterInactivity(DateTime now, object context)
		{
			return false;
		}

		internal void Shutdown()
		{
		}

		internal void SaveTo(BinaryWriter bw)
		{
		}

		internal void LoadFrom(int version, BinaryReader br)
		{
		}
	}
}
