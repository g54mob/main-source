using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Documenting;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using GameKit.Utilities;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Serialization;

namespace FishNet.Component.Transforming
{
	[DisallowMultipleComponent]
	[AddComponentMenu("FishNet/Component/NetworkTransform")]
	public sealed class NetworkTransform : NetworkBehaviour
	{
		[Serializable]
		public enum ComponentConfigurationType
		{
			Disabled = 0,
			CharacterController = 1,
			Rigidbody = 2,
			Rigidbody2D = 3
		}

		private struct ReceivedClientData
		{
			public List<bool> HasData;

			public PooledWriter Writer;

			public Channel Channel;

			public void Update(ArraySegment<byte> data, Channel channel, bool updateHasData)
			{
			}

			public void SetHasData(bool value)
			{
			}

			public void SetHasData(bool value, byte index)
			{
			}
		}

		[Serializable]
		public struct SnappedAxes
		{
			public bool X;

			public bool Y;

			public bool Z;
		}

		private enum ChangedDelta : uint
		{
			Unset = 0u,
			PositionX = 1u,
			PositionY = 2u,
			PositionZ = 4u,
			Rotation = 8u,
			Extended = 16u,
			ScaleX = 32u,
			ScaleY = 64u,
			ScaleZ = 128u,
			Nested = 256u,
			All = uint.MaxValue
		}

		private enum ChangedFull
		{
			Unset = 0,
			Position = 1,
			Rotation = 2,
			Scale = 4,
			Nested = 8
		}

		private enum UpdateFlagA : byte
		{
			Unset = 0,
			X2 = 1,
			X4 = 2,
			Y2 = 4,
			Y4 = 8,
			Z2 = 0x10,
			Z4 = 0x20,
			Rotation = 0x40,
			Extended = 0x80
		}

		private enum UpdateFlagB : byte
		{
			Unset = 0,
			X2 = 1,
			X4 = 2,
			Y2 = 4,
			Y4 = 8,
			Z2 = 0x10,
			Z4 = 0x20,
			Nested = 0x40
		}

		public class GoalData : IResettable
		{
			public uint ReceivedTick;

			public RateData Rates;

			public TransformData Transforms;

			public void ResetState()
			{
			}

			public void InitializeState()
			{
			}
		}

		public class RateData : IResettable
		{
			public float Position;

			public float Rotation;

			public float Scale;

			public float LastUnalteredPositionRate;

			public uint TickSpan;

			internal bool AbnormalRateDetected;

			internal float TimeRemaining;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Update(RateData rd)
			{
			}

			public void Update(float position, float rotation, float scale, float unalteredPositionRate, uint tickSpan, bool abnormalRateDetected, float timeRemaining)
			{
			}

			public void ResetState()
			{
			}

			public void InitializeState()
			{
			}
		}

		public class TransformData : IResettable
		{
			public enum ExtrapolateState : byte
			{
				Disabled = 0,
				Available = 1,
				Active = 2
			}

			public uint Tick;

			public bool SnappingChecked;

			public Vector3 Position;

			public Quaternion Rotation;

			public Vector3 Scale;

			public Vector3 ExtrapolatedPosition;

			public ExtrapolateState ExtrapolationState;

			public NetworkBehaviour ParentBehaviour;

			public bool IsDefault { get; private set; }

			[Preserve]
			public TransformData()
			{
			}

			internal void Update(TransformData copy)
			{
			}

			internal void Update(uint tick, Vector3 position, Quaternion rotation, Vector3 scale, Vector3 extrapolatedPosition, NetworkBehaviour parentBehaviour)
			{
			}

			public void ResetState()
			{
			}

			public void InitializeState()
			{
			}
		}

		[APIExclude]
		public delegate void DataReceivedChanged(TransformData prev, TransformData next);

		[Tooltip("Attached movement component to automatically configure.")]
		[SerializeField]
		private ComponentConfigurationType _componentConfiguration;

		[SerializeField]
		[Tooltip("True to synchronize when this transform changes parent.")]
		private bool _synchronizeParent;

		[Tooltip("How much to compress each transform property.")]
		[SerializeField]
		private TransformPackingData _packing;

		[Range(1f, 250f)]
		[SerializeField]
		[Tooltip("How many ticks to interpolate.")]
		private ushort _interpolation;

		[SerializeField]
		[Range(0f, 1024f)]
		[Tooltip("How many ticks to extrapolate.")]
		private ushort _extrapolation;

		[SerializeField]
		[Tooltip("True to enable teleport threshhold.")]
		private bool _enableTeleport;

		[Range(0f, float.MaxValue)]
		[Tooltip("How far the transform must travel in a single update to cause a teleport rather than smoothing. Using 0f will teleport every update.")]
		[SerializeField]
		private float _teleportThreshold;

		[SerializeField]
		[Tooltip("True to increase the teleport threshhold based on LOD of the object.")]
		private bool _scaleThreshold;

		[Tooltip("True if owner controls how the object is synchronized.")]
		[SerializeField]
		private bool _clientAuthoritative;

		[Tooltip("True to synchronize movements on server to owner when not using client authoritative movement.")]
		[SerializeField]
		private bool _sendToOwner;

		[SerializeField]
		[FormerlySerializedAs("_useNetworkLod")]
		[Tooltip("True to use Network Level of Detail when the feature is enabled.")]
		private bool _enableNetworkLod;

		[SerializeField]
		[Range(1f, 255f)]
		[Tooltip("How often in ticks to synchronize. This is default to 1 but can be set longer to send less often. This value may also be changed at runtime. Enabling Network level of detail for this NetworkTransform disables manual control of this feature as it will be handled internally.")]
		private byte _interval;

		[Tooltip("True to synchronize position. Even while checked only changed values are sent.")]
		[SerializeField]
		private bool _synchronizePosition;

		[SerializeField]
		[Tooltip("Axes to snap on position.")]
		private SnappedAxes _positionSnapping;

		[Tooltip("True to synchronize rotation. Even while checked only changed values are sent.")]
		[SerializeField]
		private bool _synchronizeRotation;

		[Tooltip("Axes to snap on rotation.")]
		[SerializeField]
		private SnappedAxes _rotationSnapping;

		[Tooltip("True to synchronize scale. Even while checked only changed values are sent.")]
		[SerializeField]
		private bool _synchronizeScale;

		[SerializeField]
		[Tooltip("Axes to snap on scale.")]
		private SnappedAxes _scaleSnapping;

		private TransformPackingData _unpacked;

		private bool _lastReceiveReliable;

		private NetworkBehaviour _parentBehaviour;

		private Transform _parentTransform;

		private List<ChangedDelta> _serverChangedSinceReliable;

		private ChangedDelta _clientChangedSinceReliable;

		private uint _lastObserversRpcTick;

		private uint _lastServerRpcTick;

		private ReceivedClientData _authoritativeClientData;

		private bool _subscribedToTicks;

		private TransformData _lastReceivedServerTransformData;

		private TransformData _lastReceivedClientTransformData;

		private RateData _lastCalculatedRateData;

		private Queue<GoalData> _goalDataQueue;

		private GoalData _currentGoalData;

		private bool _changedSinceStart;

		private short _intervalsRemaining;

		private List<TransformData> _lastSentTransformDatas;

		private List<PooledWriter> _toClientChangedWriters;

		private uint _forceSendTick;

		public const ushort MAX_INTERPOLATION = 250;

		private bool NetworkInitialize___EarlyFishNet_002EComponent_002ETransforming_002ENetworkTransformFishNet_002ERuntime_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EComponent_002ETransforming_002ENetworkTransformFishNet_002ERuntime_002Edll_Excuted;

		public bool TakenOwnership { get; private set; }

		private ChangedDelta _fullChanged => default(ChangedDelta);

		public event DataReceivedChanged OnDataReceived
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

		public event Action<GoalData> OnNextGoal
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

		public event Action OnInterpolationComplete
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

		public bool GetSendToOwner()
		{
			return false;
		}

		public void SetSendToOwner(bool value)
		{
		}

		public void SetSynchronizePosition(bool value)
		{
		}

		public void SetPositionSnapping(SnappedAxes axes)
		{
		}

		public void SetSynchronizeRotation(bool value)
		{
		}

		public void SetRotationSnapping(SnappedAxes axes)
		{
		}

		public void SetSynchronizeScale(bool value)
		{
		}

		public void SetScaleSnapping(SnappedAxes axes)
		{
		}

		public void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public override void OnStartNetwork()
		{
		}

		public override void OnStartServer()
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnOwnershipServer(NetworkConnection prevOwner)
		{
		}

		public override void OnOwnershipClient(NetworkConnection prevOwner)
		{
		}

		public override void OnStopNetwork()
		{
		}

		private void ResetState(bool destroyed)
		{
		}

		private void Update()
		{
		}

		private void AddCollections(bool asServer)
		{
		}

		private void ConfigureComponents()
		{
		}

		private void TimeManager_OnPostTick()
		{
		}

		private void ChangeTickSubscription(bool subscribe)
		{
		}

		private bool CanControl()
		{
			return false;
		}

		[ObserversRpc(BufferLast = true, ExcludeServer = true)]
		private void ObserversSetSendToOwner(bool value)
		{
		}

		public void ForceSend(uint ticks)
		{
		}

		public void ForceSend()
		{
		}

		public void SetInterval(byte value)
		{
		}

		private void SetIntervalInternal(byte value)
		{
		}

		[ServerRpc(RunLocally = true)]
		private void ServerSetInterval(byte value)
		{
		}

		[ObserversRpc(BufferLast = true, RunLocally = true)]
		private void ObserversSetInterval(byte value)
		{
		}

		private void SetDefaultGoalData()
		{
		}

		private void LogInvalidParent()
		{
		}

		private void SerializeChanged(ChangedDelta changed, PooledWriter writer, byte lodIndex)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DeserializePacket(ArraySegment<byte> data, TransformData prevTransformData, TransformData nextTransformData, ref ChangedFull changedFull, out byte lodIndex)
		{
			lodIndex = default(byte);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateParentBehaviour()
		{
		}

		private void SetParent(NetworkBehaviour parent, RateData rd)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void MoveToTarget(float deltaOverride = -1f)
		{
		}

		private void SendToClients(byte lodIndex)
		{
		}

		private void SendToServer(TransformData lastSentTransformData)
		{
		}

		private bool HasChanged(TransformData td)
		{
			return false;
		}

		private bool HasChanged(TransformData a, TransformData b)
		{
			return false;
		}

		private bool HasChanged(TransformData a, TransformData b, ref ChangedFull changedFull)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private ChangedDelta GetChanged(TransformData transformData)
		{
			return default(ChangedDelta);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private ChangedDelta GetChanged(ref Vector3 lastPosition, ref Quaternion lastRotation, ref Vector3 lastScale, NetworkBehaviour lastParentBehaviour)
		{
			return default(ChangedDelta);
		}

		private void SnapProperties(TransformData transformData, bool force = false)
		{
		}

		private void SetInstantRates(RateData rd, uint tickDifference, float timeRemaining)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetCalculatedRates(byte lodIndex, TransformData prevTd, RateData prevRd, GoalData nextGd, ChangedFull changedFull, bool hasChanged, Channel channel, bool asServer)
		{
		}

		private uint GetTickDifference(TransformData prevTd, GoalData nextGd, uint minimum, bool asServer, out float timePassed)
		{
			timePassed = default(float);
			return 0u;
		}

		private void SetExtrapolation(TransformData prev, TransformData next, Channel channel)
		{
		}

		[TargetRpc(ValidateTarget = false)]
		private void TargetUpdateTransform(NetworkConnection conn, ArraySegment<byte> data, Channel channel)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[ObserversRpc]
		private void ObserversUpdateClientAuthoritativeTransform(ArraySegment<byte> data, Channel channel)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[ServerRpc]
		private void ServerUpdateTransform(ArraySegment<byte> data, Channel channel)
		{
		}

		private void DataReceived(ArraySegment<byte> data, Channel channel, bool asServer)
		{
		}

		private void SetCurrentGoalData(GoalData data)
		{
		}

		public void ClearGoalData()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateTransformData(ArraySegment<byte> packetData, TransformData prevTransformData, TransformData nextTransformData, ref ChangedFull changedFull, out byte lodIndex)
		{
			lodIndex = default(byte);
		}

		internal void ConfigureForCSP()
		{
		}

		public void SetSynchronizedProperties(SynchronizedProperty value)
		{
		}

		[ServerRpc]
		private void ServerSetSynchronizedProperties(SynchronizedProperty value)
		{
		}

		[ObserversRpc(BufferLast = true)]
		private void ObserversSetSynchronizedProperties(SynchronizedProperty value)
		{
		}

		private void SetSynchronizedPropertiesInternal(SynchronizedProperty value)
		{
		}

		public void NetworkInitialize___Early()
		{
		}

		public void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void RpcWriter___Observers_ObserversSetSendToOwner_1140765316(bool value)
		{
		}

		private void RpcLogic___ObserversSetSendToOwner_1140765316(bool value)
		{
		}

		private void RpcReader___Observers_ObserversSetSendToOwner_1140765316(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Server_ServerSetInterval_1246646286(byte value)
		{
		}

		private void RpcLogic___ServerSetInterval_1246646286(byte value)
		{
		}

		private void RpcReader___Server_ServerSetInterval_1246646286(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		private void RpcWriter___Observers_ObserversSetInterval_1246646286(byte value)
		{
		}

		private void RpcLogic___ObserversSetInterval_1246646286(byte value)
		{
		}

		private void RpcReader___Observers_ObserversSetInterval_1246646286(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Target_TargetUpdateTransform_748863190(NetworkConnection conn, ArraySegment<byte> data, Channel channel)
		{
		}

		private void RpcLogic___TargetUpdateTransform_748863190(NetworkConnection conn, ArraySegment<byte> data, Channel channel)
		{
		}

		private void RpcReader___Target_TargetUpdateTransform_748863190(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Observers_ObserversUpdateClientAuthoritativeTransform_2713644489(ArraySegment<byte> data, Channel channel)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RpcLogic___ObserversUpdateClientAuthoritativeTransform_2713644489(ArraySegment<byte> data, Channel channel)
		{
		}

		private void RpcReader___Observers_ObserversUpdateClientAuthoritativeTransform_2713644489(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Server_ServerUpdateTransform_2713644489(ArraySegment<byte> data, Channel channel)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void RpcLogic___ServerUpdateTransform_2713644489(ArraySegment<byte> data, Channel channel)
		{
		}

		private void RpcReader___Server_ServerUpdateTransform_2713644489(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		private void RpcWriter___Server_ServerSetSynchronizedProperties_535967898(SynchronizedProperty value)
		{
		}

		private void RpcLogic___ServerSetSynchronizedProperties_535967898(SynchronizedProperty value)
		{
		}

		private void RpcReader___Server_ServerSetSynchronizedProperties_535967898(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		private void RpcWriter___Observers_ObserversSetSynchronizedProperties_535967898(SynchronizedProperty value)
		{
		}

		private void RpcLogic___ObserversSetSynchronizedProperties_535967898(SynchronizedProperty value)
		{
		}

		private void RpcReader___Observers_ObserversSetSynchronizedProperties_535967898(PooledReader PooledReader0, Channel channel)
		{
		}

		private void Awake_UserLogic_FishNet_002EComponent_002ETransforming_002ENetworkTransform_FishNet_002ERuntime_002Edll()
		{
		}
	}
}
