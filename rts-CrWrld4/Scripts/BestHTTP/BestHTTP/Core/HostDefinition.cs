using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace BestHTTP.Core
{
	public sealed class HostDefinition
	{
		public List<HostConnection> Alternates;

		public Dictionary<string, HostConnection> hostConnectionVariant;

		private static StringBuilder keyBuilder;

		private static ReaderWriterLockSlim keyBuilderLock;

		public string Host { get; private set; }

		public HostDefinition(string host)
		{
		}

		public HostConnection HasBetterAlternate(HTTPRequest request)
		{
			return null;
		}

		public HostConnection GetHostDefinition(HTTPRequest request)
		{
			return null;
		}

		public HostConnection GetHostDefinition(string key)
		{
			return null;
		}

		public void Send(HTTPRequest request)
		{
		}

		public void TryToSendQueuedRequests()
		{
		}

		public void HandleAltSvcHeader(HTTPResponse response)
		{
		}

		public void HandleConnectProtocol(HTTP2ConnectProtocolInfo info)
		{
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

		public static string GetKeyForRequest(HTTPRequest request)
		{
			return null;
		}

		public static string GetKeyFor(Uri uri, Proxy proxy)
		{
			return null;
		}
	}
}
