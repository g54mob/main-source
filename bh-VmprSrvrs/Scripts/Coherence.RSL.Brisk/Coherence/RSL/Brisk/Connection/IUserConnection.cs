using Coherence.Brisk.Models;
using Coherence.Brook;
using Coherence.Connection;
using Coherence.RSL.Transport;
using Coherence.SimulationFrame;

namespace Coherence.RSL.Brisk.Connection
{
	public interface IUserConnection : IConnectionAckHandler, IConnectionReceiver
	{
		uint Participant { get; }

		ConnectionID ID { get; }

		ClientID ClientID { get; }

		ConnectInfo? ConnectionInfo { get; }

		bool IsReliable { get; }

		bool UseDebugStream { get; }

		ConnectionType Type();

		bool CanSend();

		OutPacket CreatePacket(bool isReliable);

		void Send(OutPacket packet);

		void UpgradeInfo(ConnectInfo newInfo);

		void UpgradeType(ConnectionType newType);

		void Accept(ClientID clientID, AbsoluteSimulationFrame simFrame);

		bool IsConnected();

		bool IsDisconnected();
	}
}
