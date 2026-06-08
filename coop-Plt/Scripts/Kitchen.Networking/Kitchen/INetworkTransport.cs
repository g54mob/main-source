using System;
using System.Collections.Generic;
using Kitchen.NetworkSupport;
using Platforms;

namespace Kitchen
{
	public interface INetworkTransport : ILiveness
	{
		ConnectionType ConnectionType { get; }

		bool IsHosting { get; }

		bool ShouldBeActive { get; }

		TransportConnectionStatus ConnectionStatus { get; }

		TransportSendStatus SendStatus { get; }

		event Action<INetworkTarget, byte[]> OnReceive;

		TransportSendResult Send(byte[] data);

		void Update();

		void Dispose();

		void Initialise();

		void RequestKickUser(INetworkTarget target);

		void RequestBanUser(INetworkTarget target);

		bool RequestJoinServer(INetworkTarget target);

		void RequestStartServer();

		string GetTargetName(INetworkTarget target);

		void RequestDisconnect();

		void RequestSuspend();

		void RequestUnsuspend();

		void SupplyInviteData(ref NetworkInviteData invite_data);

		bool IsTargetConnected(INetworkTarget target);

		string GetDebugInfo();

		void GetConnectedPlayers(ref List<NetworkTargetDescription> users);
	}
}
