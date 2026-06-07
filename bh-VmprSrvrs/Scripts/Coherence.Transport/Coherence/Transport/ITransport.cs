using System;
using System.Collections.Generic;
using System.Net;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Connection;

namespace Coherence.Transport
{
	public interface ITransport
	{
		TransportState State { get; }

		bool IsReliable { get; }

		bool CanSend { get; }

		int HeaderSize { get; }

		string Description { get; }

		event Action OnOpen;

		event Action<ConnectionException> OnError;

		void Open(EndpointData endpoint, ConnectionSettings settings);

		void Close();

		void Send(IOutOctetStream data);

		void Receive(List<(IInOctetStream, IPEndPoint)> buffer);

		void PrepareDisconnect();
	}
}
