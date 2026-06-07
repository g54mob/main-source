using System;
using System.Collections.Generic;
using Coherence.Brisk;
using Coherence.Brisk.Models;
using Coherence.Brook;
using Coherence.Common;

namespace Coherence.Connection
{
	internal interface IConnection : IOutConnection
	{
		ClientID ClientID { get; }

		ConnectionState State { get; }

		Ping Ping { get; }

		byte SendFrequency { get; }

		uint InitialScene { get; set; }

		string TransportDescription { get; }

		event Action<ConnectResponse> OnConnect;

		event Action<ConnectionCloseReason> OnDisconnect;

		event Action<ConnectionException> OnError;

		event Action<DeliveryInfo> OnDeliveryInfo;

		void Update();

		void Connect(EndpointData data, ConnectionType connectionType, bool clientAsSimulator, ConnectionSettings settings);

		void Disconnect(ConnectionCloseReason connectionCloseReason, bool serverInitiated);

		void Receive(List<InPacket> buffer);
	}
}
