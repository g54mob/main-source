using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Coherence.Brisk;
using Coherence.Brisk.Models;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.SimulationFrame;
using Coherence.Stats;
using Coherence.Transport;

namespace Coherence.Core
{
	internal class ClientCore : IClient, IDisposable
	{
		private const int ServerParticipantID = 0;

		private NetworkTime networkTime;

		private readonly HashSet<Entity> knownEntities;

		private readonly HashSet<Entity> ackedEntities;

		private readonly Dictionary<Entity, AuthorityType> authorityByEntity;

		private readonly IConnection connection;

		private readonly InConnection inConnection;

		private readonly OutConnection outConnection;

		private readonly IDefinition protocolDefinition;

		private readonly EntityIDGenerator entityIdGenerator;

		private string hostname;

		private readonly Logger logger;

		private readonly List<InPacket> receiveBuffer;

		private ITransportFactory transportFactory;

		private TransportConditioner networkConditioner;

		private readonly TransportConditioner.Configuration networkConditionerConfig;

		private IDomainNameResolver domainNameResolver;

		private CancellationTokenSource dnsResolveCancellationSource;

		private EndpointData lastConnectData;

		private ConnectionType lastConnectionType;

		private bool clientAsSimulator;

		private ConnectionSettings lastConnectionSettings;

		private Vector3d floatingOrigin;

		public INetworkTime NetworkTime => null;

		public ConnectionType ConnectionType { get; private set; }

		public ClientID ClientID => default(ClientID);

		public string Hostname => null;

		public Coherence.Stats.Stats Stats { get; private set; }

		public ConnectionState ConnectionState => default(ConnectionState);

		public Ping Ping => default(Ping);

		public EndpointData LastEndpointData => default(EndpointData);

		public ConnectionSettings ConnectionSettings => null;

		public uint InitialScene
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public byte SendFrequency => 0;

		public event Action<ClientID> OnConnected
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

		public event Action<ConnectionCloseReason> OnDisconnected
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

		public event Action<ConnectionException> OnConnectionError
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

		public event Action<EndpointData> OnConnectedEndpoint
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

		public event Action<Entity, IncomingEntityUpdate> OnEntityCreated
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

		public event Action<Entity, IncomingEntityUpdate> OnEntityUpdated
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

		public event Action<Entity, DestroyReason> OnEntityDestroyed
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

		public event Action<IEntityCommand, MessageTarget, Entity> OnCommand
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

		public event Action<IEntityInput, long, Entity> OnInput
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

		public event Action<PacketSentDebugInfo> DebugOnPacketSent
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

		public event Action<int> DebugOnPacketReceived
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

		public event Action<Entity> DebugOnEntityAcked
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

		public event Action<AuthorityRequest> OnAuthorityRequested
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

		public event Action<AuthorityRequestRejection> OnAuthorityRequestRejected
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

		public event Action<AuthorityChange> OnAuthorityChange
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

		public event Action<Entity> OnAuthorityTransferred
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

		public event Action<SceneIndexChanged> OnSceneIndexChanged
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

		public ClientCore(IDefinition protocolDefinition, Logger logger, HashSet<Entity> activeEntities = null, BriskServices briskServices = null, ITransportFactory transportFactory = null, IDomainNameResolver domainNameResolver = null)
		{
		}

		private ITransport SetUpTransport(Logger transportLogger)
		{
			return null;
		}

		public void Connect(EndpointData data, ConnectionSettings connectionSettings, ConnectionType connectionType = ConnectionType.Client, bool clientAsSimulator = false)
		{
		}

		private void DnsResolveHostAndStartConnection(EndpointData data, ConnectionSettings connectionSettings, ConnectionType connectionType, bool clientAsSimulator)
		{
		}

		private void StartConnection(EndpointData data, ConnectionSettings connectionSettings, ConnectionType connectionType, bool clientAsSimulator)
		{
		}

		public void Reconnect()
		{
		}

		private void Reset()
		{
		}

		private void OnConnect(ConnectResponse connectResponse)
		{
		}

		private void OnDisconnect(ConnectionCloseReason reason)
		{
		}

		private void HandleError(ConnectionException exception)
		{
		}

		private void HandleDeliveryInfo(DeliveryInfo deliveryInfo)
		{
		}

		public void Disconnect()
		{
		}

		internal void Disconnect(ConnectionCloseReason reason, bool serverInitiated)
		{
		}

		public bool IsConnected()
		{
			return false;
		}

		public bool IsConnecting()
		{
			return false;
		}

		public bool IsDisconnected()
		{
			return false;
		}

		public void UpdateReceiving()
		{
		}

		private void ReceiveAndProcessPackets()
		{
		}

		public void UpdateSending()
		{
		}

		public Entity CreateEntity(ICoherenceComponentData[] data, bool orphan)
		{
			return default(Entity);
		}

		public bool IsEntityInAuthTransfer(Entity id)
		{
			return false;
		}

		public bool CanSendUpdates(Entity id)
		{
			return false;
		}

		public void UpdateComponents(Entity id, ICoherenceComponentData[] data)
		{
		}

		public void RemoveComponents(Entity id, uint[] components)
		{
		}

		public void DestroyEntity(Entity id)
		{
		}

		public bool EntityExists(Entity entity)
		{
			return false;
		}

		public bool HasAuthorityOverEntity(Entity entity, AuthorityType authorityType)
		{
			return false;
		}

		public void SendCommand(IEntityCommand message, MessageTarget target, Entity id, ChannelID channelID)
		{
		}

		public void SendInput(IEntityInput message, long frame, Entity id)
		{
		}

		public void SendAuthorityRequest(Entity id, AuthorityType authorityType = AuthorityType.Full)
		{
		}

		public void SendAdoptOrphanRequest(Entity id)
		{
		}

		public bool SendAuthorityTransfer(Entity id, ClientID newAuthority, bool authorized, AuthorityType transferredAuthorityType = AuthorityType.Full)
		{
			return false;
		}

		public void SetFloatingOrigin(Vector3d newFloatingOrigin)
		{
		}

		public Vector3d GetFloatingOrigin()
		{
			return default(Vector3d);
		}

		public void SetTransportType(TransportType transportType, TransportConfiguration transportConfiguration)
		{
		}

		public void SetTransportFactory(ITransportFactory transportFactory)
		{
		}

		private void RaiseOnAuthorityTransferred(Entity id)
		{
		}

		private void OnEntityUpdates(List<IncomingEntityUpdate> updates)
		{
		}

		private void HandleReceivedCreate(in IncomingEntityUpdate update)
		{
		}

		private void HandleReceivedUpdate(in IncomingEntityUpdate update)
		{
		}

		private void HandleReceivedDestroy(in EntityWithMeta meta, bool known)
		{
		}

		private bool ProcessAuthorityChange(EntityWithMeta meta, out AuthorityType newAuthorityType)
		{
			newAuthorityType = default(AuthorityType);
			return false;
		}

		private void HandleCommand(IEntityCommand entityCommand, MessageTarget target, Entity id)
		{
		}

		private void HandleInput(IEntityInput input, long frame, Entity entityId)
		{
		}

		public void Dispose()
		{
		}

		private bool UseDnsResolution()
		{
			return false;
		}

		private void RaiseOnAuthorityRequested(Entity id, ClientID requester, AuthorityType authType)
		{
		}

		private void RaiseOnAuthorityRequestRejected(Entity id, AuthorityType authType)
		{
		}

		private void RaiseOnAuthorityChange(Entity id, AuthorityType authorityType)
		{
		}

		private void RaiseOnConnectedEndpoint()
		{
		}

		private void RaiseOnSceneIndexChanged(Entity id, int sceneIndex)
		{
		}

		public string DebugGetTransportDescription()
		{
			return null;
		}

		public void DebugHoldAllPackets(bool drop)
		{
		}

		public void DebugReleaseAllHeldPackets()
		{
		}

		public void DebugSetNetworkCondition(Condition condition)
		{
		}

		public void DebugStopSerializingUpdates(bool stop)
		{
		}

		public void DebugDropNextOutPacket(Action callback)
		{
		}

		public void DebugOnNextPacketSentOneShot(Action callback)
		{
		}

		private void OnServerSimulationFrameReceived(AbsoluteSimulationFrame serverFrame)
		{
		}
	}
}
