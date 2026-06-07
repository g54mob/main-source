using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;

namespace Coherence.Transport
{
	internal class CompoundTransport<TPrimary, TFallback> : ITransport where TPrimary : ITransport where TFallback : ITransport
	{
		private static bool useFallBack;

		private ITransport currentTransport;

		private readonly ITransport primaryTransport;

		private readonly ITransport fallbackTransport;

		private readonly Logger logger;

		private bool anyPacketReceived;

		private EndpointData endpoint;

		private ConnectionSettings settings;

		private DateTime? openTime;

		public TransportState State => default(TransportState);

		public bool IsReliable => false;

		public bool CanSend => false;

		public int HeaderSize => 0;

		public string Description => null;

		public event Action OnOpen
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

		public event Action<ConnectionException> OnError
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

		public CompoundTransport(TPrimary primaryTransport, TFallback fallbackTransport, Logger logger)
		{
		}

		public void Open(EndpointData endpoint, ConnectionSettings settings)
		{
		}

		public void Close()
		{
		}

		public void Send(IOutOctetStream data)
		{
		}

		public void Receive(List<(IInOctetStream, IPEndPoint)> buffer)
		{
		}

		public void PrepareDisconnect()
		{
		}

		private void HandleOpened()
		{
		}

		private void HandleError(ConnectionException exception)
		{
		}

		private bool ShouldFallBack(Exception exception)
		{
			return false;
		}

		private void ConfigureTransportWithFallback()
		{
		}
	}
}
