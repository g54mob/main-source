using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.Toolkit.Archetypes;
using Coherence.Toolkit.Bindings;
using Coherence.Toolkit.Bindings.TransformBindings;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Coherence.Toolkit
{
	[AddComponentMenu("coherence/Coherence Sync")]
	[DefaultExecutionOrder(-900)]
	[DisallowMultipleComponent]
	[NonBindable]
	[HelpURL("https://docs.coherence.io/v/1.6/manual/components/coherence-sync")]
	public sealed class CoherenceSync : CoherenceBehaviour, ICoherenceSync, IConnectedEntityDriver
	{
		public enum AuthorityTransferType
		{
			[InspectorName("Not transferable")]
			NotTransferable = 0,
			Request = 1,
			[InspectorName("Steal")]
			Stealing = 2
		}

		public enum LifetimeType
		{
			SessionBased = 0,
			Persistent = 1
		}

		public enum OrphanedBehavior
		{
			DoNothing = 0,
			AutoAdopt = 1
		}

		public enum UniquenessType
		{
			AllowDuplicates = 0,
			NoDuplicates = 1
		}

		public enum UniqueObjectReplacementStrategy
		{
			[Tooltip("Should be used for objects that remain in the scene, will preserve local customizations.")]
			Replace = 0,
			[Tooltip("Should be used for objects that move to other scenes, will not preserve local customizations.")]
			Destroy = 1
		}

		public enum UnsyncedNetworkEntityPriority
		{
			[Tooltip("This is the default option and coherence will use the Asset Id from the CoherenceSyncConfig to relate Remote Network Entities to instantiated objects of this Prefab.")]
			AssetId = 0,
			[Tooltip("With this option coherence will force instantiated objects of this Prefab to match the Unique Id of a Remote Network Entity that is not synchronized yet with a Unity Object.")]
			UniqueId = 1
		}

		public enum SimulationType
		{
			ClientSide = 0,
			ServerSide = 2,
			ServerSideWithClientInput = 3
		}

		[Flags]
		public enum InterpolationLoop
		{
			[InspectorName("Update")]
			Update = 1,
			[InspectorName("LateUpdate")]
			LateUpdate = 2,
			[InspectorName("FixedUpdate")]
			FixedUpdate = 4,
			[InspectorName("Update and FixedUpdate")]
			UpdateAndFixedUpdate = 5,
			[InspectorName("LateUpdate and FixedUpdate")]
			LateUpdateAndFixedUpdate = 6
		}

		public enum RigidbodyMode
		{
			Direct = 0,
			Interpolated = 1,
			Manual = 2
		}

		public delegate bool OnAuthorityRequestedHandler(ClientID requesterID, AuthorityType authorityType, CoherenceSync sync);

		public delegate void ConnectedEntityChangeHandler(CoherenceSync newConnectedEntity);

		public delegate void ConnectedEntitySentHandler(CoherenceSync newConnectedEntity);

		internal delegate void NetworkCommandHandler(object sender, byte[] data);

		public enum FloatingOriginMode
		{
			DontMoveWithFloatingOrigin = 0,
			MoveWithFloatingOrigin = 1
		}

		[CompilerGenerated]
		private sealed class _003CDestroyThroughInstantiatorDelayed_003Ed__222 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CoherenceSync _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDestroyThroughInstantiatorDelayed_003Ed__222(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[FormerlySerializedAs("OnStateAuthorityLost")]
		public UnityEvent OnStateRemote;

		[FormerlySerializedAs("OnInputAuthorityLost")]
		public UnityEvent OnInputRemote;

		[FormerlySerializedAs("OnStateAuthorityGained")]
		public UnityEvent OnStateAuthority;

		[FormerlySerializedAs("OnInputAuthorityGained")]
		public UnityEvent OnInputAuthority;

		public UnityEvent<AuthorityType> OnAuthorityRequestRejected;

		public UnityEvent OnAuthTransferComplete;

		public UnityEvent<CoherenceSync> OnConnectedEntityChanged;

		public UnityEvent OnInputSimulatorConnected;

		private Coherence.Log.Logger loggerBacking;

		internal NetworkCommandHandler NetworkCommandReceived;

		[SerializeField]
		private CoherenceSyncConfig coherenceSyncConfig;

		[SerializeField]
		private ToolkitArchetype archetype;

		private CoherenceInput input;

		[FormerlySerializedAs("InterpolationLocation")]
		[SerializeField]
		private InterpolationLoop interpolationLocation;

		public RigidbodyMode RigidbodyUpdateMode;

		public UnityEvent<Vector2> OnRigidbody2DPositionUpdate;

		public UnityEvent<Vector3> OnRigidbody3DPositionUpdate;

		public UnityEvent<float> OnRigidbody2DRotationUpdate;

		public UnityEvent<Quaternion> OnRigidbody3DRotationUpdate;

		private ICoherenceSyncUpdater updater;

		private Rigidbody syncRigidbody;

		private Rigidbody2D syncRigidbody2D;

		private bool resettingInterpolation;

		private ICoherenceBridge bridge;

		private UniquenessManager uniquenessManager;

		[SerializeField]
		private string bakedScriptType;

		private CoherenceSyncBaked bakedScript;

		private Transform lastSentParent;

		private Vector3 lastSentRelativePosition;

		private Quaternion lastSentRelativeRotation;

		private Vector3 lastSentRelativeScale;

		private Transform lastReceivedParent;

		private Transform lastValidatedParent;

		private bool lastValidatedParentSet;

		private Transform tform;

		[SerializeField]
		private bool isGlobal;

		public bool approveAuthorityTransferRequests;

		[Tooltip("Define how and where this entity is simulated.\n\nClient Side: State and input authority are kept by the client that instantiates this GameObject, until authority is transferred to a different client.\n\nServer Side: State and input authority are transferred to a Simulator. If a client instantiates this GameObject, a transfer request to the Simulator is performed. If a Simulator instantiates this GameObject, nothing happens.\n\nServer Side With Client Input: State authority is transferred to a Simulator, but input authority is kept by the client that instantiates this GameObject")]
		public SimulationType simulationType;

		[Tooltip("Define how this Entity should respond to requests for authority by other clients.\n\nNot Transferable: All transfer requests are rejected automatically.\n\nRequest: Authority transfer may be requested by any client. The current owner decides if the transfer is accepted or not.\n\nSteal: Authority will always be given to the requesting client on a FCFS (\"First Come First Serve\") basis.")]
		public AuthorityTransferType authorityTransferType;

		public OrphanedBehavior orphanedBehavior;

		[Tooltip("Define what should happen to this Entity after the client with authority over it disconnects or abandons it.\n\nSession Based: The Entity will be destroyed when the Client or Simulator that has authority over it disconnects.\n\nPersistent: The Entity will remain on the Replication Server until a simulating Client or Simulator destroys it explicitly.")]
		public LifetimeType lifetimeType;

		[Tooltip("Define if this Entity enforces that only a single instance with the same UUID can exist at the same time.\n\nAllow Duplicates: Every instance of this prefab will create a new Network Entity.\n\nNo Duplicates: Instances of this prefab that share the same UUID cannot be duplicated. Duplicated instances will be destroyed upon creation.")]
		public UniquenessType uniquenessType;

		[SerializeField]
		private UniqueObjectReplacementStrategy replacementStrategy;

		[SerializeField]
		private UnsyncedNetworkEntityPriority unsyncedNetworkEntityPriority;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool preserveChildren;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use Bindings instead.")]
		[Deprecated("17/9/2024", 1, 3, 0)]
		[SerializeReference]
		public List<Binding> bindings;

		[SerializeField]
		private UnityEvent<CoherenceSync> onNetworkedInstantiation;

		[SerializeField]
		private UnityEvent<CoherenceSync> onBeforeNetworkedInstantiation;

		[SerializeField]
		private UnityEvent<CoherenceSync> onNetworkedDestruction;

		[SerializeField]
		[HideInInspector]
		private string scenePrefabInstanceUUID;

		[SerializeField]
		private string coherenceUUID;

		private string uuidToBeDeRegistered;

		[SerializeField]
		private string assetVersion;

		[SerializeField]
		[CoherenceTag]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use CoherenceTag instead.")]
		[Deprecated("17/9/2024", 1, 3, 0)]
		public string coherenceTag;

		private CommandsHandler commandsHandler;

		[SerializeReference]
		internal ComponentAction[] componentActions;

		private bool destroyAsDuplicate;

		public FloatingOriginMode floatingOriginMode;

		public FloatingOriginMode floatingOriginParentedMode;

		[NonSerialized]
		private PositionBinding positionBinding;

		[NonSerialized]
		private RotationBinding rotationBinding;

		[NonSerialized]
		private ScaleBinding scaleBinding;

		private bool bakedBindings;

		private CoherenceNode coherenceNode;

		private bool networkInstantiated;

		internal bool loadedViaCoherenceSyncConfig;

		private Coroutine destroyRoutine;

		private readonly Dictionary<(Type, string), Binding> bakedBindingsTypeAndNameCache;

		private Dictionary<(Descriptor, UnityEngine.Component), Binding> bindingCache;

		UnityEvent ICoherenceSync.OnInputSimulatorConnected => null;

		internal Coherence.Log.Logger logger
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CoherenceSyncConfig CoherenceSyncConfig
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		internal ToolkitArchetype Archetype => null;

		public CoherenceInput Input => null;

		public bool HasInput => false;

		public InterpolationLoop InterpolationLocationConfig
		{
			get
			{
				return default(InterpolationLoop);
			}
			set
			{
			}
		}

		ICoherenceSyncUpdater ICoherenceSync.Updater => null;

		private bool hasPhysics => false;

		CoherenceSyncBaked ICoherenceSync.BakedScript => null;

		public CoherenceSync ConnectedEntity { get; private set; }

		public NetworkEntityState EntityState { get; internal set; }

		public bool IsUnique => false;

		public bool IsGlobal => false;

		public UniqueObjectReplacementStrategy ReplacementStrategy => default(UniqueObjectReplacementStrategy);

		public UnsyncedNetworkEntityPriority UnsyncedEntityPriority
		{
			get
			{
				return default(UnsyncedNetworkEntityPriority);
			}
			set
			{
			}
		}

		SimulationType ICoherenceSync.SimulationTypeConfig => default(SimulationType);

		LifetimeType ICoherenceSync.LifetimeTypeConfig => default(LifetimeType);

		AuthorityTransferType ICoherenceSync.AuthorityTransferTypeConfig => default(AuthorityTransferType);

		bool ICoherenceSync.PreserveChildren => false;

		string ICoherenceSync.ArchetypeName => null;

		OrphanedBehavior ICoherenceSync.OrphanedBehaviorConfig => default(OrphanedBehavior);

		public List<Binding> Bindings => null;

		public string ManualUniqueId
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public bool IsPersistent => false;

		public bool HasStateAuthority => false;

		public bool HasInputAuthority => false;

		public bool IsSynchronizedWithNetwork => false;

		public bool IsOrphaned => false;

		public string CoherenceTag
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal IClient ClientInternal { get; set; }

		public CoherenceBridge CoherenceBridge => null;

		ICoherenceBridge ICoherenceSync.CoherenceBridge => null;

		public Action<Vector3, Vector3> OnFloatingOriginShifted { get; set; }

		internal PositionBinding PositionBinding => null;

		internal RotationBinding RotationBinding => null;

		internal ScaleBinding ScaleBinding => null;

		private bool GeneratesArchetypeDefinition => false;

		public bool UsesLODsAtRuntime => false;

		public bool HasParentWithCoherenceSync => false;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3 coherencePosition
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Quaternion coherenceRotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3 coherenceLocalScale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		string ICoherenceSync.name => null;

		Transform ICoherenceSync.transform => null;

		GameObject ICoherenceSync.gameObject => null;

		public event OnAuthorityRequestedHandler OnAuthorityRequested
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

		event UnityAction ICoherenceSync.OnStateRemote
		{
			add
			{
			}
			remove
			{
			}
		}

		event UnityAction ICoherenceSync.OnStateAuthority
		{
			add
			{
			}
			remove
			{
			}
		}

		event UnityAction ICoherenceSync.OnInputAuthority
		{
			add
			{
			}
			remove
			{
			}
		}

		public event ConnectedEntityChangeHandler ConnectedEntityChangeOverride
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

		public event ConnectedEntitySentHandler DidSendConnectedEntity
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

		public static event CoherenceBridgeResolver<CoherenceSync> BridgeResolve
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

		private CoherenceSync()
		{
		}

		public void RegisterUniqueId(string uniqueIdentifier)
		{
		}

		void ICoherenceSync.OnNetworkCommandReceived(object sender, byte[] data)
		{
		}

		private bool UpdateBakedScriptReference()
		{
			return false;
		}

		private void BakeBindings()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void Reset()
		{
		}

		private void Awake()
		{
		}

		private bool IsIncludedInSchema()
		{
			return false;
		}

		private void ResolveUniqueId()
		{
		}

		private void ResolveUniqueIdFromUniquenessManager()
		{
		}

		private void OnEnable()
		{
		}

		private bool IsClientConnectionInstance()
		{
			return false;
		}

		private void ValidateSyncProperties()
		{
		}

		private bool ConnectToBridge()
		{
			return false;
		}

		private void ResetBridge()
		{
		}

		private void HandleConnected(ICoherenceBridge coherenceBridge)
		{
		}

		private void ConstructGameObjectName()
		{
		}

		void ICoherenceSync.HandleDisconnected()
		{
		}

		void ICoherenceSync.InitializeReplacedUniqueObject(SpawnInfo info)
		{
		}

		bool ICoherenceSync.IsChildFromSyncGroup()
		{
			return false;
		}

		private void UpdateChildrenOfReplacedUniqueObject()
		{
		}

		void ICoherenceSync.SetObservedLodLevel(int lod)
		{
		}

		void ICoherenceSync.DestroyAsDuplicate()
		{
		}

		internal void OnDestroy()
		{
		}

		private void OnDisable()
		{
		}

		private void DestroyNetworkEntity()
		{
		}

		private void HandleChildrenOnNetworkDestruction()
		{
		}

		void ICoherenceSync.HandleNetworkedDestruction(bool destroyedByParent)
		{
		}

		[IteratorStateMachine(typeof(_003CDestroyThroughInstantiatorDelayed_003Ed__222))]
		private IEnumerator DestroyThroughInstantiatorDelayed()
		{
			return null;
		}

		internal void DestroyThroughInstantiator()
		{
		}

		public bool RequestAuthority(AuthorityType authorityType)
		{
			return false;
		}

		public bool TransferAuthority(ClientID clientID, AuthorityType authorityTransferred = AuthorityType.Full)
		{
			return false;
		}

		public bool AbandonAuthority()
		{
			return false;
		}

		public bool Adopt()
		{
			return false;
		}

		public void ResetInterpolation(bool setToLastSamples = false)
		{
		}

		private void OnAuthorityChanged(AuthorityType oldAuthorityType, AuthorityType newAuthorityType)
		{
		}

		private void ResetLastSentData()
		{
		}

		private void ResetBindings()
		{
		}

		private void OnBecomesAuthority(bool gainedStateAuthority, bool gainedInputAuthority)
		{
		}

		private void OnBecomesRemote(bool lostStateAuthority, bool lostInputAuthority)
		{
		}

		private void TriggerComponentActionsForAuthority()
		{
		}

		private void TriggerComponentActionsForRemote()
		{
		}

		void ICoherenceSync.ReceiveCommand(IEntityCommand command, MessageTarget target)
		{
		}

		private void ActivateBindings()
		{
		}

		void ICoherenceSync.ValidateConnectedEntity()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		void ICoherenceSync.RaiseOnConnectedEntityChanged()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		void ICoherenceSync.ApplyNodeBindings()
		{
		}

		private void UpdateConnectedEntityParent()
		{
		}

		void ICoherenceSync.SendConnectedEntity()
		{
		}

		private void ResetConnectedEntity()
		{
		}

		private void ResetLastSentParent()
		{
		}

		private ICoherenceComponentData[] CreateConnectedEntityComponentUpdate(CoherenceSync coherenceSyncParent, Vector3 pos, Quaternion rot, Vector3 scale, uint mask)
		{
			return null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetParent(Transform parent)
		{
		}

		private void TransformSamplesCoordinateSystem(Transform oldParent, Transform newParent, bool transformLastSampleToo)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		bool ICoherenceSync.ConnectedEntityChanged(Entity newConnectedEntityID, out bool didChangeParent)
		{
			didChangeParent = default(bool);
			return false;
		}

		public bool TryGetBinding(Type componentType, string bindingName, out Binding returnBinding)
		{
			returnBinding = null;
			return false;
		}

		bool ICoherenceSync.TryGetBindingByGuid(string bindingGuid, out Binding outBinding)
		{
			outBinding = null;
			return false;
		}

		public T GetBakedValueBinding<T>(string bindingName = null) where T : Binding
		{
			return null;
		}

		private T BakeBinding<T>(T binding) where T : Binding
		{
			return null;
		}

		internal (int, Binding) IndexOfBindingForDescriptor(Descriptor descriptor, UnityEngine.Component component)
		{
			return default((int, Binding));
		}

		internal bool HasBindingForDescriptor(Descriptor descriptor, UnityEngine.Component component)
		{
			return false;
		}

		internal Binding ShouldUpdateBindingDescriptor(Descriptor descriptor, UnityEngine.Component component)
		{
			return null;
		}

		internal Binding GetBindingForDescriptor(Descriptor descriptor, UnityEngine.Component component)
		{
			return null;
		}

		private void ClearEntityState()
		{
		}

		internal bool ValidateArchetype()
		{
			return false;
		}

		bool ICoherenceSync.RaiseOnAuthorityRequested(ClientID requesterID, AuthorityType authorityType)
		{
			return false;
		}

		internal void RaiseOnAuthorityRequestRejected(AuthorityType authorityType)
		{
		}

		internal void RaiseOnAuthorityTranferred()
		{
		}

		private void RaiseOnStateAuthorityGained()
		{
		}

		private void RaiseOnStateAuthorityLost()
		{
		}

		private void RaiseOnInputAuthorityGained()
		{
		}

		private void RaiseOnInputAuthorityLost()
		{
		}

		bool ICoherenceSync.ShiftOrigin(Vector3d delta)
		{
			return false;
		}

		bool ICoherenceSync.ShouldShift()
		{
			return false;
		}

		private bool IsPositionNetworkedControlled()
		{
			return false;
		}

		private void HandleException(string function, Exception exception)
		{
		}

		public bool SendCommand<TTarget>(string methodName, MessageTarget target) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendCommand(Type targetType, string methodName, MessageTarget target)
		{
			return false;
		}

		public bool SendCommand<TTarget>(string methodName, MessageTarget target, params object[] args) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendCommand(Type targetType, string methodName, MessageTarget target, params object[] args)
		{
			return false;
		}

		public bool SendCommand<TTarget>(string methodName, MessageTarget target, params (Type, object)[] args) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendCommand(Type targetType, string methodName, MessageTarget target, params (Type, object)[] args)
		{
			return false;
		}

		public bool SendCommandToChildren<TTarget>(string methodName, MessageTarget target) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendCommandToChildren(Type targetType, string methodName, MessageTarget target)
		{
			return false;
		}

		public bool SendCommandToChildren<TTarget>(string methodName, MessageTarget target, params object[] args) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendCommandToChildren(Type targetType, string methodName, MessageTarget target, params object[] args)
		{
			return false;
		}

		public bool SendCommandToChildren<TTarget>(string methodName, MessageTarget target, params (Type, object)[] args) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendCommandToChildren(Type targetType, string methodName, MessageTarget target, params (Type, object)[] args)
		{
			return false;
		}

		public bool SendCommand(Action action, MessageTarget target)
		{
			return false;
		}

		public bool SendCommand<T1>(Action<T1> action, MessageTarget target, T1 param1)
		{
			return false;
		}

		public bool SendCommand<T1, T2>(Action<T1, T2> action, MessageTarget target, T1 param1, T2 param2)
		{
			return false;
		}

		public bool SendCommand<T1, T2, T3>(Action<T1, T2, T3> action, MessageTarget target, T1 param1, T2 param2, T3 param3)
		{
			return false;
		}

		public bool SendCommand<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, MessageTarget target, T1 param1, T2 param2, T3 param3, T4 param4)
		{
			return false;
		}

		public bool SendCommand<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action, MessageTarget target, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
		{
			return false;
		}

		public bool SendCommand<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action, MessageTarget target, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6)
		{
			return false;
		}

		public bool SendCommand<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action, MessageTarget target, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7)
		{
			return false;
		}

		public bool SendCommand<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action, MessageTarget target, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8)
		{
			return false;
		}

		public bool SendOrderedCommand<TTarget>(string methodName, MessageTarget target) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendOrderedCommand(Type targetType, string methodName, MessageTarget target)
		{
			return false;
		}

		public bool SendOrderedCommand<TTarget>(string methodName, MessageTarget target, params object[] args) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendOrderedCommand(Type targetType, string methodName, MessageTarget target, params object[] args)
		{
			return false;
		}

		public bool SendOrderedCommand<TTarget>(string methodName, MessageTarget target, params (Type, object)[] args) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendOrderedCommand(Type targetType, string methodName, MessageTarget target, params (Type, object)[] args)
		{
			return false;
		}

		public bool SendOrderedCommandToChildren<TTarget>(string methodName, MessageTarget target) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendOrderedCommandToChildren(Type targetType, string methodName, MessageTarget target)
		{
			return false;
		}

		public bool SendOrderedCommandToChildren<TTarget>(string methodName, MessageTarget target, params object[] args) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendOrderedCommandToChildren(Type targetType, string methodName, MessageTarget target, params object[] args)
		{
			return false;
		}

		public bool SendOrderedCommandToChildren<TTarget>(string methodName, MessageTarget target, params (Type, object)[] args) where TTarget : UnityEngine.Component
		{
			return false;
		}

		public bool SendOrderedCommandToChildren(Type targetType, string methodName, MessageTarget target, params (Type, object)[] args)
		{
			return false;
		}

		public bool SendOrderedCommand(Action action, MessageTarget target)
		{
			return false;
		}

		public bool SendOrderedCommand<T1>(Action<T1> action, MessageTarget target, T1 param1)
		{
			return false;
		}

		public bool SendOrderedCommand<T1, T2>(Action<T1, T2> action, MessageTarget target, T1 param1, T2 param2)
		{
			return false;
		}

		public bool SendOrderedCommand<T1, T2, T3>(Action<T1, T2, T3> action, MessageTarget target, T1 param1, T2 param2, T3 param3)
		{
			return false;
		}

		public bool SendOrderedCommand<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, MessageTarget target, T1 param1, T2 param2, T3 param3, T4 param4)
		{
			return false;
		}

		public bool SendOrderedCommand<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action, MessageTarget target, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
		{
			return false;
		}

		public bool SendOrderedCommand<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action, MessageTarget target, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6)
		{
			return false;
		}

		public bool SendOrderedCommand<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action, MessageTarget target, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7)
		{
			return false;
		}

		public bool SendOrderedCommand<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action, MessageTarget target, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8)
		{
			return false;
		}
	}
}
