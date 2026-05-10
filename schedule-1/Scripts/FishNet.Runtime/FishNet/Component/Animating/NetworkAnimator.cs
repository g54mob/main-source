using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Documenting;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace FishNet.Component.Animating
{
	[AddComponentMenu("FishNet/Component/NetworkAnimator")]
	public sealed class NetworkAnimator : NetworkBehaviour
	{
		private struct ReceivedServerData
		{
			private int _length;

			private byte[] _data;

			public ArraySegment<byte> GetArraySegment()
			{
				return default(ArraySegment<byte>);
			}

			public ReceivedServerData(ArraySegment<byte> segment)
			{
				_length = 0;
				_data = null;
			}

			public void Dispose()
			{
			}
		}

		private struct StateChange
		{
			public int FrameCount;

			public bool IsCrossfade;

			public int Hash;

			public bool FixedTime;

			public float DurationTime;

			public float OffsetTime;

			public float NormalizedTransitionTime;

			public StateChange(int frame)
			{
				FrameCount = 0;
				IsCrossfade = false;
				Hash = 0;
				FixedTime = false;
				DurationTime = 0f;
				OffsetTime = 0f;
				NormalizedTransitionTime = 0f;
			}

			public StateChange(int frame, int hash, bool fixedTime, float duration, float offset, float normalizedTransition)
			{
				FrameCount = 0;
				IsCrossfade = false;
				Hash = 0;
				FixedTime = false;
				DurationTime = 0f;
				OffsetTime = 0f;
				NormalizedTransitionTime = 0f;
			}
		}

		private class ClientAuthoritativeUpdate
		{
			public int BufferCount;

			private int[] _bufferLengths;

			private List<byte[]> _buffers;

			private const int MAXIMUM_DATA_SIZE = 1000;

			public const int MAXIMUM_BUFFER_COUNT = 2;

			public bool ForceAll { get; private set; }

			public void AddToBuffer(ref ArraySegment<byte> data)
			{
			}

			public void GetBuffer(int index, ref byte[] buffer, ref int length)
			{
			}

			public void Reset()
			{
			}
		}

		private struct SmoothedFloat
		{
			public readonly float Rate;

			public readonly float Target;

			public SmoothedFloat(float rate, float target)
			{
				Rate = 0f;
				Target = 0f;
			}
		}

		private struct TriggerUpdate
		{
			public byte ParameterIndex;

			public bool Setting;

			public TriggerUpdate(byte parameterIndex, bool setting)
			{
				ParameterIndex = 0;
				Setting = false;
			}
		}

		private class ParameterDetail
		{
			public readonly AnimatorControllerParameter ControllerParameter;

			public readonly byte TypeIndex;

			public readonly int Hash;

			public ParameterDetail(AnimatorControllerParameter controllerParameter, byte typeIndex)
			{
			}
		}

		[SerializeField]
		[HideInInspector]
		internal List<string> IgnoredParameters;

		[Tooltip("The animator component to synchronize.")]
		[SerializeField]
		private Animator _animator;

		[Tooltip("True to smooth float value changes for spectators.")]
		[SerializeField]
		private bool _smoothFloats;

		[Tooltip("How many ticks to interpolate.")]
		[Range(1f, 250f)]
		[SerializeField]
		private ushort _interpolation;

		[Tooltip("True if using client authoritative animations.")]
		[SerializeField]
		private bool _clientAuthoritative;

		[Tooltip("True to synchronize server results back to owner. Typically used when you are changing animations on the server and are relying on the server response to update the clients animations.")]
		[SerializeField]
		private bool _sendToOwner;

		private List<ParameterDetail> _parameterDetails;

		private List<int> _ints;

		private List<float> _floats;

		private List<bool> _bools;

		private float[] _layerWeights;

		private float _speed;

		private List<TriggerUpdate> _triggerUpdates;

		private List<byte[]> _toClientsBuffer;

		private Dictionary<int, SmoothedFloat> _smoothedFloats;

		private Dictionary<int, StateChange> _unsynchronizedLayerStates;

		private Animator _lastAnimator;

		private RuntimeAnimatorController _lastController;

		private PooledWriter _writer;

		private ClientAuthoritativeUpdate _clientAuthoritativeUpdates;

		private bool _forceAllOnTimed;

		private Queue<ReceivedServerData> _fromServerBuffer;

		private uint _startTick;

		private bool _subscribedToTicks;

		private const byte LAYER_WEIGHT = 240;

		private const byte SPEED = 241;

		private const byte STATE = 242;

		private const byte CROSSFADE = 243;

		private bool NetworkInitialize___EarlyFishNet_002EComponent_002EAnimating_002ENetworkAnimatorFishNet_002ERuntime_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EComponent_002EAnimating_002ENetworkAnimatorFishNet_002ERuntime_002Edll_Excuted;

		public Animator Animator => null;

		public bool ClientAuthoritative => false;

		private bool _isAnimatorEnabled => false;

		private bool _canSmoothFloats => false;

		public void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		[APIExclude]
		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		public override void OnStartNetwork()
		{
		}

		[APIExclude]
		public override void OnStartServer()
		{
		}

		public override void OnStopNetwork()
		{
		}

		private void TimeManager_OnPreTick()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void TimeManager_OnPostTick()
		{
		}

		private void Update()
		{
		}

		private void InitializeOnce()
		{
		}

		private void ChangeTickSubscription(bool subscribe)
		{
		}

		public void SetAnimator(Animator animator)
		{
		}

		public void SetController(RuntimeAnimatorController controller)
		{
		}

		private void CheckSendToServer()
		{
		}

		private void CheckSendToClients()
		{
		}

		private void SmoothFloats()
		{
		}

		private bool AnimatorUpdated(out ArraySegment<byte> updatedBytes, bool forceAll = false)
		{
			updatedBytes = default(ArraySegment<byte>);
			return false;
		}

		private void ApplyParametersUpdated(ref ArraySegment<byte> updatedParameters)
		{
		}

		private bool ReturnCurrentLayerState(out int stateHash, out float normalizedTime, int layerIndex)
		{
			stateHash = default(int);
			normalizedTime = default(float);
			return false;
		}

		[Obsolete("This does not function anymore. Data is always sent on tick now.")]
		public void ForceSend()
		{
		}

		public void SendAll()
		{
		}

		public void Play(string name)
		{
		}

		public void Play(int hash)
		{
		}

		public void Play(string name, int layer)
		{
		}

		public void Play(int hash, int layer)
		{
		}

		public void Play(string name, int layer, float normalizedTime)
		{
		}

		public void Play(int hash, int layer, float normalizedTime)
		{
		}

		public void PlayInFixedTime(string name, float fixedTime)
		{
		}

		public void PlayInFixedTime(int hash, float fixedTime)
		{
		}

		public void PlayInFixedTime(string name, int layer, float fixedTime)
		{
		}

		public void PlayInFixedTime(int hash, int layer, float fixedTime)
		{
		}

		public void CrossFade(string stateName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset = float.NegativeInfinity, float normalizedTransitionTime = 0f)
		{
		}

		public void CrossFade(int hash, float normalizedTransitionDuration, int layer, float normalizedTimeOffset = 0f, float normalizedTransitionTime = 0f)
		{
		}

		public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer, float fixedTimeOffset = 0f, float normalizedTransitionTime = 0f)
		{
		}

		public void CrossFadeInFixedTime(int hash, float fixedTransitionDuration, int layer, float fixedTimeOffset = 0f, float normalizedTransitionTime = 0f)
		{
		}

		public void SetTrigger(int hash)
		{
		}

		public void SetTrigger(string name)
		{
		}

		public void ResetTrigger(int hash)
		{
		}

		public void ResetTrigger(string name)
		{
		}

		private void UpdateTrigger(int hash, bool set)
		{
		}

		[TargetRpc(ValidateTarget = false)]
		private void TargetAnimatorUpdated(NetworkConnection connection, ArraySegment<byte> data)
		{
		}

		[ServerRpc]
		private void ServerAnimatorUpdated(ArraySegment<byte> data)
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

		private void RpcWriter___Target_TargetAnimatorUpdated_2304494427(NetworkConnection connection, ArraySegment<byte> data)
		{
		}

		private void RpcLogic___TargetAnimatorUpdated_2304494427(NetworkConnection connection, ArraySegment<byte> data)
		{
		}

		private void RpcReader___Target_TargetAnimatorUpdated_2304494427(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Server_ServerAnimatorUpdated_415360332(ArraySegment<byte> data)
		{
		}

		private void RpcLogic___ServerAnimatorUpdated_415360332(ArraySegment<byte> data)
		{
		}

		private void RpcReader___Server_ServerAnimatorUpdated_415360332(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		private void Awake_UserLogic_FishNet_002EComponent_002EAnimating_002ENetworkAnimator_FishNet_002ERuntime_002Edll()
		{
		}
	}
}
