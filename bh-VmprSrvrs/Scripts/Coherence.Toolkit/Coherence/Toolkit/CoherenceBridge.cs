using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Cloud;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.Stats;
using Coherence.Toolkit.Relay;
using Coherence.Transport;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Coherence.Toolkit
{
	[AddComponentMenu("coherence/Coherence Bridge")]
	[DefaultExecutionOrder(-1000)]
	[NonBindable]
	[HelpURL("https://docs.coherence.io/v/1.6/manual/components/coherence-bridge")]
	public sealed class CoherenceBridge : CoherenceBehaviour, ICoherenceBridge, IDisposable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public class EventsToken
		{
			public Action<(bool liveQuerySynced, bool globalQuerySynced)> OnQuerySynced;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDisposeAsync_003Ed__179 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public CoherenceBridge _003C_003E4__this;

			public bool waitForOngoingCloudOperationsToFinish;

			private ValueTaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[SerializeField]
		private string networkPrefix;

		public bool adjustSimulationFrameByPing;

		[FormerlySerializedAs("globalQueryOn")]
		[SerializeField]
		private bool enableClientConnections;

		[SerializeField]
		[Tooltip("Creates a Global Query. Required by Client Connections")]
		private bool createGlobalQuery;

		[CoherenceSyncConfigPicker]
		public CoherenceSyncConfig ClientConnectionEntry;

		[CoherenceSyncConfigPicker]
		public CoherenceSyncConfig SimulatorConnectionEntry;

		private bool clientAsHost;

		[SerializeField]
		[Tooltip("If enabled, this CoherenceBridge instance will be saved as DontDestroyOnLoad and it will keep its connection alive between networked scene changes. When loading a different Scene with another CoherenceBridge, the secondary Bridge will pass the Scene information to the main one")]
		internal bool mainBridge;

		[SerializeField]
		[Tooltip("Uniquely identify the Scene this CoherenceBridge is attached to using the Build Index of the Scene. If this is a secondary Bridge, the identifier will be passed to the main one.")]
		internal bool useBuildIndexAsId;

		[SerializeField]
		[Tooltip("Uniquely identify the Scene this CoherenceBridge is attached to, it will be initialized with the build index of the Scene. If this is a secondary Bridge, the identifier will be passed to the main one.")]
		internal uint sceneIdentifier;

		internal uint? overrideSceneId;

		[MaybeNull]
		private CoherenceBridgePlayerAccountProvider playerAccountProvider;

		public UnityEvent<CoherenceBridge, NetworkEntityState> onNetworkEntityCreated;

		public UnityEvent<CoherenceBridge, NetworkEntityState, DestroyReason> onNetworkEntityDestroyed;

		public bool controlTimeScale;

		private CloudService cloudService;

		private Entity globalQueryEntity;

		private EventsToken events;

		private Scene? instantiationScene;

		public UnityEvent<CoherenceBridge> onConnected;

		public UnityEvent<CoherenceBridge, ConnectionCloseReason> onDisconnected;

		public UnityEvent<CoherenceBridge, ConnectionException> onConnectionError;

		public UnityEvent<CoherenceBridge> onLiveQuerySynced;

		[SerializeField]
		private string uniqueId;

		[SerializeField]
		private bool autoLoginAsGuest;

		[FormerlySerializedAs("user")]
		[SerializeField]
		private CoherenceBridgePlayerAccount playerAccount;

		private CoherenceRelayManager relayManager;

		private bool shouldDisposeCloudService;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Coherence.Log.Logger Logger { get; private set; }

		public string NetworkPrefix => null;

		public static float WorldPositionMaxRange => 0f;

		public bool EnableClientConnections
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Access to this member will be removed in a future version. Use the EnableClientConnections property instead.")]
		[Deprecated("07/2024", 1, 2, 4, Reason = "Field was renamed and made private to improve encapsulation. Use the EnableClientConnections property instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool globalQueryOn
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Access to this member will be removed in a future version. Use the EnableClientConnections property instead.")]
		[Deprecated("07/2024", 1, 2, 4, Reason = "Field was renamed and made private to improve encapsulation. Use the EnableClientConnections property instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool GlobalQueryOn
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool CreateGlobalQuery
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public long ClientFixedSimulationFrame => 0L;

		public double NetworkTimeAsDouble => 0.0;

		public bool IsConnected => false;

		public bool IsConnecting => false;

		public Coherence.Stats.Stats NetStats => null;

		public ConnectionType ConnectionType => default(ConnectionType);

		public bool IsSimulatorOrHost => false;

		public bool IsMain => false;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FixedUpdateInput FixedUpdateInput { get; }

		public ClientID ClientID => default(ClientID);

		public CoherenceClientConnectionManager ClientConnections { get; private set; }

		public CoherenceInputManager InputManager { get; private set; }

		public AuthorityManager AuthorityManager { get; private set; }

		public EntitiesManager EntitiesManager { get; private set; }

		public UniquenessManager UniquenessManager { get; private set; }

		public CoherenceSceneManager SceneManager { get; set; }

		public FloatingOriginManager FloatingOriginManager { get; private set; }

		public CloudService CloudService
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public INetworkTime NetworkTime => null;

		public IClient Client { get; private set; }

		public bool HasActiveGlobalQuery => false;

		public Scene Scene => default(Scene);

		public Scene? InstantiationScene
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int EntityCount => 0;

		public Coherence.Common.Ping Ping => default(Coherence.Common.Ping);

		public Transform Transform => null;

		public CoherenceBridgePlayerAccount PlayerAccountAutoConnect => default(CoherenceBridgePlayerAccount);

		public bool AutoLoginAsGuest
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		internal CloudUniqueId UniqueId
		{
			get
			{
				return default(CloudUniqueId);
			}
			set
			{
			}
		}

		public event Action OnFixedNetworkUpdate
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action OnLateFixedNetworkUpdate
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action OnTimeReset
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FloatingOriginShiftArgs> OnFloatingOriginShifted
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action<FloatingOriginShiftArgs> OnAfterFloatingOriginShifted
		{
			add
			{
			}
			remove
			{
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public event Action<ICoherenceBridge> OnConnectedInternal
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

		public CoherenceSyncConfig GetClientConnectionEntry()
		{
			return null;
		}

		public CoherenceSyncConfig GetSimulatorConnectionEntry()
		{
			return null;
		}

		public static void TransferCloudService(CoherenceBridge from, CoherenceBridge to)
		{
		}

		public void Connect(EndpointData endpoint, ConnectionSettings connectionSettings = null)
		{
		}

		public void Connect(EndpointData endpoint, ConnectionType connectionType, ConnectionSettings connectionSettings = null)
		{
		}

		public void ConnectAsHost(EndpointData endpoint, ConnectionSettings connectionSettings = null)
		{
		}

		public void Reconnect()
		{
		}

		public void Disconnect()
		{
		}

		public void JoinRoom(RoomData room)
		{
		}

		public void JoinWorld(WorldData world)
		{
		}

		public ICoherenceSync GetCoherenceSyncForEntity(Entity id)
		{
			return null;
		}

		public NetworkEntityState GetNetworkEntityStateForEntity(Entity id)
		{
			return null;
		}

		public Entity UnityObjectToEntityId(GameObject from)
		{
			return default(Entity);
		}

		public Entity UnityObjectToEntityId(Transform from)
		{
			return default(Entity);
		}

		public Entity UnityObjectToEntityId(ICoherenceSync from)
		{
			return default(Entity);
		}

		public GameObject EntityIdToGameObject(Entity from)
		{
			return null;
		}

		public Transform EntityIdToTransform(Entity from)
		{
			return null;
		}

		public RectTransform EntityIdToRectTransform(Entity from)
		{
			return null;
		}

		public CoherenceSync EntityIdToCoherenceSync(Entity from)
		{
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void OnNetworkEntityDestroyedInvoke(NetworkEntityState state, DestroyReason destroyReason)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void OnNetworkEntityCreatedInvoke(NetworkEntityState state)
		{
		}

		private IClient InstantiateClient()
		{
			return null;
		}

		internal void InitializeClient()
		{
		}

		public void SetInitialScene(uint initialScene)
		{
		}

		private void Connect(EndpointData endpoint, ConnectionType connectionType, bool asHost, ConnectionSettings connectionSettings)
		{
		}

		private void Awake()
		{
		}

		private CloudService CreateCloudService()
		{
			return null;
		}

		private void HandleAutoLoginAsGuest()
		{
		}

		private bool DetectMainPlayerAccountAlreadyInUse()
		{
			return false;
		}

		private void SetCloudService(CloudService cloudService, bool shouldDispose)
		{
		}

		private bool LinkToMasterBridge()
		{
			return false;
		}

		internal uint ResolveSceneId()
		{
			return 0u;
		}

		void IDisposable.Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CDisposeAsync_003Ed__179))]
		internal ValueTask DisposeAsync(bool waitForOngoingCloudOperationsToFinish)
		{
			return default(ValueTask);
		}

		private void DisposeSharedStart()
		{
		}

		private void DisposeSharedEnd()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		internal void ReceiveFromNetwork()
		{
		}

		internal void Interpolate(CoherenceSync.InterpolationLoop interpolationLoop)
		{
		}

		internal void InvokeCallbacks(CoherenceSync.InterpolationLoop interpolationLoop)
		{
		}

		internal void Sample(CoherenceSync.InterpolationLoop interpolationLoop)
		{
		}

		internal void SyncAndSend()
		{
		}

		[Conditional("ENABLE_PROFILER")]
		private void SampleNetworkMetrics()
		{
		}

		private void ReceiveFromNetworkAndUpdateTime()
		{
		}

		private void OnCommand(IEntityCommand command, MessageTarget target, Entity receiver)
		{
		}

		private void OnInput(IEntityInput input, long inputFrame, Entity receiver)
		{
		}

		private void OnApplicationQuit()
		{
		}

		private void HandleConnected(ClientID clientID)
		{
		}

		private void HandleRelayConnectionError(ConnectionException connectionException)
		{
		}

		private void HandleConnectionError(ConnectionException connectionException)
		{
		}

		private void HandleDisconnected(ConnectionCloseReason closeReason)
		{
		}

		private void OnQuerySynced((bool liveQuerySynced, bool globalQuerySynced) queryInfo)
		{
		}

		public bool TranslateFloatingOrigin(Vector3d translation)
		{
			return false;
		}

		public bool TranslateFloatingOrigin(Vector3 translation)
		{
			return false;
		}

		public bool SetFloatingOrigin(Vector3d newOrigin)
		{
			return false;
		}

		public Vector3d GetFloatingOrigin()
		{
			return default(Vector3d);
		}

		public void DontDestroyOnLoad()
		{
		}

		public void SetTransportType(TransportType transportType, TransportConfiguration transportConfiguration)
		{
		}

		public void SetTransportFactory(ITransportFactory transportFactory)
		{
		}

		public void SetRelay(IRelay newRelay)
		{
		}

		internal bool CloudServiceEquals(CloudService otherCloudService)
		{
			return false;
		}

		private void HandleException(string function, Exception exception)
		{
		}

		internal void InitializeGlobalQuery()
		{
		}

		Coroutine ICoherenceBridge.StartCoroutine(IEnumerator routine)
		{
			return null;
		}
	}
}
