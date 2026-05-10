using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Component.Transforming;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using FishNet.Utility;
using UnityEngine;

namespace FishNet.Component.Prediction
{
	[AddComponentMenu("FishNet/Component/PredictedObject")]
	public class PredictedObject : NetworkBehaviour
	{
		public enum SpectatorSmoothingType
		{
			Accuracy = 0,
			Mixed = 1,
			Gradual = 2,
			Custom = 3
		}

		private enum CollectionState : byte
		{
			Unset = 0,
			Added = 1,
			Removed = 2
		}

		internal enum PredictionType : byte
		{
			Other = 0,
			Rigidbody = 1,
			Rigidbody2D = 2
		}

		internal enum ResendType : byte
		{
			Disabled = 0,
			Interval = 1
		}

		[Serializable]
		public struct SmoothingData
		{
			[Range(0.01f, 5f)]
			[Tooltip("Percentage of ping to use as interpolation. Higher values will result in more interpolation.")]
			public float InterpolationPercent;

			[Range(0.01f, 5f)]
			[Tooltip("Percentage of ping to use as interpolation when colliding with an object local client owns.This is used to speed up local interpolation when predicted objects collide with a player as well keep graphics closer to the objects root while colliding.")]
			public float CollisionInterpolationPercent;

			[Range(1f, 255f)]
			[Tooltip("How much per tick to decrease to collision interpolation when colliding with a local player object. Higher values will set interpolation to collision settings faster.")]
			public byte InterpolationDecreaseStep;

			[Range(1f, 255f)]
			[Tooltip("How much per tick to increase to normal interpolation when not colliding with a local player object. Higher values will set interpolation to normal settings faster.")]
			public byte InterpolationIncreaseStep;
		}

		[Tooltip("True if this object implements replicate and reconcile methods.")]
		[SerializeField]
		private bool _implementsPredictionMethods;

		[Tooltip("Transform which holds the graphical features of this object. This transform will be smoothed when desynchronizations occur.")]
		[SerializeField]
		private Transform _graphicalObject;

		[SerializeField]
		[Tooltip("True to enable teleport threshhold.")]
		private bool _enableTeleport;

		[Range(0f, 200f)]
		[SerializeField]
		[Tooltip("How far the transform must travel in a single update to cause a teleport rather than smoothing. Using 0f will teleport every update.")]
		private float _teleportThreshold;

		[Tooltip("True to smooth position on owner objects.")]
		[SerializeField]
		private bool _ownerSmoothPosition;

		[SerializeField]
		[Tooltip("True to smooth rotation on owner objects.")]
		private bool _ownerSmoothRotation;

		[Tooltip("How far in the past to keep the graphical object when owner. Using a value of 0 will disable interpolation.")]
		[Range(0f, 255f)]
		[SerializeField]
		private byte _ownerInterpolation;

		[Tooltip("Type of prediction movement which is being used.")]
		[SerializeField]
		private PredictionType _predictionType;

		[Tooltip("Rigidbody to predict.")]
		[SerializeField]
		private Rigidbody _rigidbody;

		[Tooltip("Rigidbody2D to predict.")]
		[SerializeField]
		private Rigidbody2D _rigidbody2d;

		[Tooltip("True to smooth position on spectated objects.")]
		[SerializeField]
		private bool _spectatorSmoothPosition;

		[Tooltip("True to smooth rotation on spectated objects.")]
		[SerializeField]
		private bool _spectatorSmoothRotation;

		[SerializeField]
		[Tooltip("How to favor smoothing for predicted objects.")]
		private SpectatorSmoothingType _spectatorSmoothingType;

		[Tooltip("Custom settings for smoothing data.")]
		[SerializeField]
		private SmoothingData _customSmoothingData;

		[SerializeField]
		private SmoothingData _preconfiguredSmoothingDataPreview;

		[Tooltip("Multiplier applied to difference in velocity between ticks. Positive values will result in more velocity while lowers will result in less. A value of 1f will prevent any velocity from being lost between ticks, unless indicated by the server.")]
		[SerializeField]
		[Range(-10f, 10f)]
		private float _maintainedVelocity;

		[SerializeField]
		[Tooltip("How often to resend current values regardless if the state has changed. Using this value will consume more bandwidth but may be preferred if you want to force synchronization the object move on the client but not on the server.")]
		private ResendType _resendType;

		[Tooltip("How often in ticks to resend values.")]
		[SerializeField]
		private ushort _resendInterval;

		[Tooltip("NetworkTransform to configure.")]
		[SerializeField]
		private NetworkTransform _networkTransform;

		private bool _clientSubscribed;

		private bool _registered;

		private Vector3 _graphicalInstantiatedOffsetPosition;

		private Quaternion _graphicalInstantiatedOffsetRotation;

		private uint _localTick;

		private PredictedObjectSpectatorSmoother _spectatorSmoother;

		private PredictedObjectOwnerSmoother _ownerSmoother;

		private RigidbodyPauser _rigidbodyPauser;

		private uint _nextIntervalResend;

		private ushort _resendsRemaining;

		private bool _previouslyChanged;

		private Animator[] _graphicalAnimators;

		private bool _animatorsInitialized;

		private uint _lastStateLocalTick;

		private long _currentSpectatorInterpolation;

		private uint _targetSpectatorInterpolation;

		private uint _targetCollisionSpectatorInterpolation;

		private byte _interpolationDecreaseStep;

		private byte _interpolationIncreaseStep;

		private uint _collisionStayedTick;

		private HashSet<GameObject> _localClientCollidedObjects;

		private bool _spectatorPaused;

		private static SmoothingData _accurateSmoothingData;

		private static SmoothingData _mixedSmoothingData;

		private static SmoothingData _gradualSmoothingData;

		private uint _igtt;

		private RingBuffer<RigidbodyState> _rigidbodyStates;

		private Vector3 _lastVelocity;

		private Vector3 _lastAngularVelocity;

		private float? _velocityBaseline;

		private float? _angularVelocityBaseline;

		private PhysicsScene _physicsScene;

		private RingBuffer<Rigidbody2DState> _rigidbody2dStates;

		private Vector3 _lastVelocity2D;

		private float _lastAngularVelocity2D;

		private float? _velocityBaseline2D;

		private float? _angularVelocityBaseline2D;

		private PhysicsScene2D _physicsScene2D;

		private int _preReplicateReplayCacheIndex;

		private uint _lastPingUpdateTick;

		private long _lastPing;

		private bool NetworkInitialize___EarlyFishNet_002EComponent_002EPrediction_002EPredictedObjectFishNet_002ERuntime_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EComponent_002EPrediction_002EPredictedObjectFishNet_002ERuntime_002Edll_Excuted;

		public bool IsRigidbodyPrediction => false;

		public Transform GetGraphicalObject()
		{
			return null;
		}

		public void SetGraphicalObject(Transform value)
		{
		}

		[Obsolete("No longer used. This setting has been replaced by Smoothing Type.")]
		public bool GetSmoothTicks()
		{
			return false;
		}

		[Obsolete("No longer used. This setting has been replaced by Smoothing Type.")]
		public void SetSmoothTicks(bool value)
		{
		}

		[Obsolete("No longer used. This setting has been replaced by Smoothing Type.")]
		public byte GetInterpolation(bool asOwner)
		{
			return 0;
		}

		[Obsolete("No longer used. This setting has been replaced by Smoothing Type.")]
		public void SetInterpolation(byte value, bool asOwner)
		{
		}

		public void SetSpectatorSmoothingType(SpectatorSmoothingType value)
		{
		}

		public virtual void Awake()
		{
		}

		public override void OnStartNetwork()
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnOwnershipClient(NetworkConnection prevOwner)
		{
		}

		public override void OnStopNetwork()
		{
		}

		private void UpdateRigidbodiesCount(bool add)
		{
		}

		private void SetInstantiatedOffsetValues()
		{
		}

		private void TimeManager_OnUpdate()
		{
		}

		private void TimeManager_OnPreTick()
		{
		}

		protected void TimeManager_OnPostTick()
		{
		}

		private void ChangeSubscriptions(bool subscribe)
		{
		}

		private void TimeManager_OnRoundTripTimeUpdated(long obj)
		{
		}

		private void PredictionManager_OnPreServerReconcile(NetworkBehaviour obj)
		{
		}

		protected virtual void PredictionManager_OnPreReplicateReplay(uint tick, PhysicsScene ps, PhysicsScene2D ps2d)
		{
		}

		private void PredictionManager_OnPostReplicateReplay(uint tick, PhysicsScene ps, PhysicsScene2D ps2d)
		{
		}

		private void PredictionManager_OnPreReconcile(NetworkBehaviour nb)
		{
		}

		private void PredictionManager_OnPostReconcile(NetworkBehaviour nb)
		{
		}

		private void InitializeSmoother(bool ownerSmoother)
		{
		}

		private void ConfigureRigidbodies()
		{
		}

		private void ConfigureNetworkTransform()
		{
		}

		internal bool IsPredictingOwner()
		{
			return false;
		}

		private bool _isPredictingOwner(NetworkConnection c)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Rigidbodies_OnSpawnServer(NetworkConnection c)
		{
		}

		private void Rigidbodies_OnStartClient()
		{
		}

		private void Rigidbodies_OnOwnershipClient(NetworkConnection prevOwner)
		{
		}

		private void Rigidbodies_TimeManager_OnPostTick()
		{
		}

		private void TrySetCollisionExited(bool is2d)
		{
		}

		private void Rigidbodies_TimeManager_OnPreReconcile(NetworkBehaviour nb)
		{
		}

		private void Rigidbodies_TimeManager_OnPostReconcile(NetworkBehaviour nb)
		{
		}

		private void Rigidbodies_PredictionManager_OnPreReplicateReplay(uint tick, PhysicsScene ps, PhysicsScene2D ps2d)
		{
		}

		private void Rigidbodies_PredictionManager_OnPostReplicateReplay(uint tick, PhysicsScene ps, PhysicsScene2D ps2d)
		{
		}

		public void SetPauseSpectatorCorrections_Experimental(bool pause)
		{
		}

		private void Rigidbodies_OnRoundTripTimeUpdated(long ping)
		{
		}

		private void SetTargetSmoothing(long ping, bool setImmediately)
		{
		}

		private bool CollidingWithLocalClient()
		{
			return false;
		}

		private void UpdateSpectatorSmoothing()
		{
		}

		private bool CollisionEnteredLocalClientObject(GameObject go)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SendRigidbodyState(NetworkBehaviour nb)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void TrySendRigidbodyState(NetworkBehaviour nb, uint tick)
		{
		}

		private int GetCachedStateIndex(uint tick, bool is2d)
		{
			return 0;
		}

		protected bool PredictVector3Velocity(ref float? velocityBaseline, ref Vector3 lastVelocity, Vector3 velocity, out Vector3 result)
		{
			result = default(Vector3);
			return false;
		}

		private bool PredictFloatVelocity(ref float? velocityBaseline, ref float lastVelocity, float velocity, out float result)
		{
			result = default(float);
			return false;
		}

		private bool CanPredict()
		{
			return false;
		}

		private void OnCollisionEnter(Collision collision)
		{
		}

		private void OnCollisionStay(Collision collision)
		{
		}

		private void ResetRigidbodyToData(RigidbodyState state)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictVelocity(PhysicsScene ps)
		{
		}

		private void SendRigidbodyState(uint reconcileTick, NetworkConnection conn, bool applyImmediately)
		{
		}

		[TargetRpc(ValidateTarget = false)]
		private void TargetSendRigidbodyState(NetworkConnection c, RigidbodyState state, bool applyImmediately, Channel channel = Channel.Unreliable)
		{
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
		}

		private void OnCollisionStay2D(Collision2D collision)
		{
		}

		private void CollisionEntered(GameObject go)
		{
		}

		private void CollisionExited()
		{
		}

		private void ResetRigidbody2DToData(Rigidbody2DState state)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PredictVelocity(PhysicsScene2D ps)
		{
		}

		private void SendRigidbody2DState(uint reconcileTick, NetworkConnection conn, bool applyImmediately)
		{
		}

		[TargetRpc(ValidateTarget = false)]
		private void TargetSendRigidbody2DState(NetworkConnection c, Rigidbody2DState state, bool applyImmediately, Channel channel = Channel.Unreliable)
		{
		}

		private bool CanProcessReceivedState(uint stateTick)
		{
			return false;
		}

		public virtual void NetworkInitialize___Early()
		{
		}

		public virtual void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void RpcWriter___Target_TargetSendRigidbodyState_1016043495(NetworkConnection c, RigidbodyState state, bool applyImmediately, Channel channel = Channel.Unreliable)
		{
		}

		private void RpcLogic___TargetSendRigidbodyState_1016043495(NetworkConnection c, RigidbodyState state, bool applyImmediately, Channel channel = Channel.Unreliable)
		{
		}

		private void RpcReader___Target_TargetSendRigidbodyState_1016043495(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Target_TargetSendRigidbody2DState_700510009(NetworkConnection c, Rigidbody2DState state, bool applyImmediately, Channel channel = Channel.Unreliable)
		{
		}

		private void RpcLogic___TargetSendRigidbody2DState_700510009(NetworkConnection c, Rigidbody2DState state, bool applyImmediately, Channel channel = Channel.Unreliable)
		{
		}

		private void RpcReader___Target_TargetSendRigidbody2DState_700510009(PooledReader PooledReader0, Channel channel)
		{
		}

		private void Awake_UserLogic_FishNet_002EComponent_002EPrediction_002EPredictedObject_FishNet_002ERuntime_002Edll()
		{
		}
	}
}
