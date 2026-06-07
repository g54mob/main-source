using System;
using Coherence.Brisk;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Entities;
using Coherence.ProtocolDef;
using Coherence.Stats;
using Coherence.Transport;

namespace Coherence
{
	public interface IClient : IDisposable
	{
		ClientID ClientID { get; }

		INetworkTime NetworkTime { get; }

		ConnectionType ConnectionType { get; }

		string Hostname { get; }

		Coherence.Stats.Stats Stats { get; }

		ConnectionState ConnectionState { get; }

		Ping Ping { get; }

		EndpointData LastEndpointData { get; }

		ConnectionSettings ConnectionSettings { get; }

		uint InitialScene { get; set; }

		byte SendFrequency { get; }

		event Action<ClientID> OnConnected;

		event Action<ConnectionCloseReason> OnDisconnected;

		event Action<ConnectionException> OnConnectionError;

		event Action<EndpointData> OnConnectedEndpoint;

		event Action<Entity, IncomingEntityUpdate> OnEntityCreated;

		event Action<Entity, IncomingEntityUpdate> OnEntityUpdated;

		event Action<Entity, DestroyReason> OnEntityDestroyed;

		event Action<IEntityCommand, MessageTarget, Entity> OnCommand;

		event Action<IEntityInput, long, Entity> OnInput;

		event Action<AuthorityRequest> OnAuthorityRequested;

		event Action<AuthorityRequestRejection> OnAuthorityRequestRejected;

		event Action<AuthorityChange> OnAuthorityChange;

		event Action<Entity> OnAuthorityTransferred;

		event Action<SceneIndexChanged> OnSceneIndexChanged;

		event Action<Entity> DebugOnEntityAcked;

		event Action<PacketSentDebugInfo> DebugOnPacketSent;

		event Action<int> DebugOnPacketReceived;

		void Connect(EndpointData data, ConnectionSettings connectionSettings, ConnectionType connectionType = ConnectionType.Client, bool clientAsSimulator = false);

		bool IsConnected();

		bool IsDisconnected();

		bool IsConnecting();

		void UpdateReceiving();

		void UpdateSending();

		void Disconnect();

		void Reconnect();

		Entity CreateEntity(ICoherenceComponentData[] data, bool orphan);

		bool CanSendUpdates(Entity id);

		void UpdateComponents(Entity id, ICoherenceComponentData[] data);

		void RemoveComponents(Entity id, uint[] data);

		void DestroyEntity(Entity id);

		bool EntityExists(Entity id);

		bool HasAuthorityOverEntity(Entity entity, AuthorityType authorityType);

		bool IsEntityInAuthTransfer(Entity id);

		void SendCommand(IEntityCommand message, MessageTarget target, Entity id, ChannelID channelID);

		void SendInput(IEntityInput message, long frame, Entity id);

		void SendAuthorityRequest(Entity id, AuthorityType authorityMode = AuthorityType.Full);

		void SendAdoptOrphanRequest(Entity id);

		bool SendAuthorityTransfer(Entity id, ClientID newAuthority, bool authorized, AuthorityType authorityType = AuthorityType.Full);

		void SetFloatingOrigin(Vector3d newFloatingOrigin);

		Vector3d GetFloatingOrigin();

		void SetTransportType(TransportType transportType, TransportConfiguration transportConfiguration);

		void SetTransportFactory(ITransportFactory transportFactory);

		string DebugGetTransportDescription();

		void DebugHoldAllPackets(bool hold);

		void DebugReleaseAllHeldPackets();

		void DebugSetNetworkCondition(Condition condition);

		void DebugStopSerializingUpdates(bool stop);

		void DebugDropNextOutPacket(Action callback);

		void DebugOnNextPacketSentOneShot(Action callback);
	}
}
