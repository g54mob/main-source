using System;
using System.Linq;
using Assets.Scripts.Character.State;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Events;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Lightbug.CharacterControllerPro.Core;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class NetworkCharacterScript : NetworkBehaviour
	{
		private static class Profile
		{
			public static readonly ProfilerMarker OnPostTickOwner = new ProfilerMarker("NetworkCharacterScript.OnPostTickOwner");
		}

		private const float ExplosiveBlastMaxForce = 100f;

		private float _animationHorizontalAxis;

		private float _animationPlanarSpeed;

		private float _animationSwimLayerWeight;

		private float _animationTimeToGround;

		private Vector3 _animationVelocity;

		private float _animationVerticalAxis;

		private Rigidbody _body;

		private CharacterActor _characterActor;

		private float _currentExtrapolationBlend;

		[SerializeField]
		private float _extrapolationSpeedThreshold = 25f;

		private FlightSceneNetworkScript _fsn;

		private Collider _groundedCollider;

		private float _horizontalAxis;

		[SerializeField]
		private float _interpolationTime = 0.1f;

		private int _lastAnimationMessageId;

		private float _lastPacketTime;

		private float _lastPhysicsTime;

		private Vector3 _localVelocity;

		private NormalMovement _normalMovementState;

		private Vector3? _pendingExplosiveBlastForce;

		private float _planarSpeed;

		private FlightScenePlayer _player;

		private Vector3 _previousLocalPosition;

		private Vector3 _previousPosition;

		private Quaternion _previousRotation;

		[SerializeField]
		private RelativeVelocityZoneScript _relativeVelocityZone;

		[SerializeField]
		private float _smoothingFactor = 1f;

		private int _swimLayer;

		private float _swimLayerWeight;

		private Vector3 _targetLocalPosition;

		private Vector3 _targetPosition;

		private Quaternion _targetRotation;

		private float _timeToGround;

		private Vector3 _velocity;

		private float _verticalAxis;

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkCharacterScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkCharacterScriptGame_002Edll_Excuted;

		public CharacterActor CharacterActor => _characterActor;

		public bool IsRemote => !base.IsOwner;

		public void HandleExplosiveBlast(float blastForce, float blastRadius, float criticalBlastRadius, Vector3 blastOrigin, AircraftScript owner)
		{
			if (!IsRemote)
			{
				Vector3 vector = base.transform.position + (GetComponent<CapsuleCollider>()?.center ?? Vector3.zero) - blastOrigin;
				float magnitude = vector.magnitude;
				float num = blastForce;
				if (magnitude > criticalBlastRadius)
				{
					num *= 1f - (magnitude - criticalBlastRadius) / (blastRadius - criticalBlastRadius);
				}
				num = Mathf.Clamp(num, 0f, 100f);
				Vector3 vector2 = vector.normalized * num;
				Vector3 valueOrDefault = _pendingExplosiveBlastForce.GetValueOrDefault();
				if (!_pendingExplosiveBlastForce.HasValue)
				{
					valueOrDefault = Vector3.zero;
					_pendingExplosiveBlastForce = valueOrDefault;
				}
				_pendingExplosiveBlastForce = _pendingExplosiveBlastForce.Value + vector2;
			}
		}

		public void OnRepositionedRemotely(Vector3 globalPosition, Vector3 rotation, float physicsTime)
		{
			if (IsRemote)
			{
				Vector3 position = (_targetPosition = (_previousPosition = Utility.ConvertAbsoluteToFloatingOriginPosition(globalPosition)));
				_previousRotation = Quaternion.Euler(rotation);
				_targetRotation = _previousRotation;
				_lastPhysicsTime = physicsTime;
				if (_relativeVelocityZone != null)
				{
					Transform transform = _relativeVelocityZone.Rigidbody.transform;
					_previousLocalPosition = transform.InverseTransformPoint(position);
					_targetLocalPosition = _previousLocalPosition;
				}
			}
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
			_fsn = FlightSceneScript.Instance.FlightSceneNetwork;
			_body = GetComponent<Rigidbody>();
			_characterActor = GetComponent<CharacterActor>();
			_normalMovementState = GetComponentInChildren<NormalMovement>();
			if (base.IsOwner)
			{
				base.TimeManager.OnPostTick += OnPostTickOwner;
				_normalMovementState.OnDanceStateChanged += OnDanceStateChanged;
			}
			else
			{
				_characterActor.enabled = false;
				_normalMovementState.IsRemote = true;
			}
			FlightScenePlayer flightScenePlayer = FlightSceneScript.Instance.AllPlayers.Where((FlightScenePlayer x) => x.NetworkPlayer.PlayerId == base.OwnerId).FirstOrDefault();
			if (flightScenePlayer != null)
			{
				AttachedToPlayer(flightScenePlayer);
				return;
			}
			Debug.Log($"Could not find player for network character with owner {base.OwnerId}");
			FlightSceneScript.Instance.PlayerLoaded += OnPlayerLoaded;
		}

		public override void OnStopClient()
		{
			base.OnStopClient();
			if (base.IsOwner)
			{
				base.TimeManager.OnPostTick -= OnPostTickOwner;
				_normalMovementState.OnDanceStateChanged -= OnDanceStateChanged;
			}
		}

		[ServerRpc]
		public void SetAnimationStateServer(int messageId, int state)
		{
			RpcWriter___Server_SetAnimationStateServer___1692629761(messageId, state);
		}

		public virtual void Awake()
		{
			NetworkInitialize___Early();
			Awake_UserLogic_Assets_002EScripts_002EMultiplayer_002ENetworkCharacterScript_Game_002Edll();
			NetworkInitialize___Late();
		}

		protected virtual void FixedUpdate()
		{
			if (!IsRemote)
			{
				if (_groundedCollider != _characterActor.CharacterCollisionInfo.groundCollider3D)
				{
					_groundedCollider = _characterActor.CharacterCollisionInfo.groundCollider3D;
					if (_groundedCollider != null)
					{
						_relativeVelocityZone = _groundedCollider.GetComponentInParent<RelativeVelocityZoneScript>();
					}
				}
				else if (_relativeVelocityZone != null && !_relativeVelocityZone.IsWithinBounds(base.transform.position))
				{
					_relativeVelocityZone = null;
				}
				if (_pendingExplosiveBlastForce.HasValue)
				{
					if (_pendingExplosiveBlastForce.Value.magnitude > 100f)
					{
						_pendingExplosiveBlastForce = _pendingExplosiveBlastForce.Value.normalized * 100f;
					}
					_body.AddForce(_pendingExplosiveBlastForce.Value, ForceMode.Impulse);
					_pendingExplosiveBlastForce = null;
				}
			}
			if (!IsRemote || !(_characterActor != null))
			{
				return;
			}
			float deltaTime = Time.deltaTime;
			float num = _fsn.PhysicsTime - _lastPacketTime;
			RelativeVelocityZoneScript relativeVelocityZone = _relativeVelocityZone;
			if (relativeVelocityZone != null)
			{
				Transform obj = relativeVelocityZone.Rigidbody.transform;
				_velocity = relativeVelocityZone.Rigidbody.linearVelocity + _localVelocity;
				Mathf.Clamp01((_localVelocity.magnitude - _extrapolationSpeedThreshold) / _extrapolationSpeedThreshold);
				_currentExtrapolationBlend = 0f;
				float t = Mathf.Clamp01(num / _interpolationTime);
				Vector3 b = Vector3.Lerp(_previousLocalPosition, _targetLocalPosition, t);
				Vector3 b2 = _targetLocalPosition + _localVelocity * num;
				b = Vector3.Lerp(obj.InverseTransformPoint(base.transform.position), b, _smoothingFactor * deltaTime * 10f);
				Vector3 position = Vector3.Lerp(b, b2, _currentExtrapolationBlend);
				Vector3 position2 = obj.TransformPoint(position);
				Quaternion quaternion = Quaternion.Lerp(_previousRotation, _targetRotation, t);
				if (Vector3.Distance(base.transform.position, _targetPosition) > 5f)
				{
					base.transform.SetPositionAndRotation(_targetPosition, quaternion);
				}
				else
				{
					base.transform.SetPositionAndRotation(position2, Quaternion.Slerp(base.transform.rotation, quaternion, _smoothingFactor * deltaTime * 10f));
				}
			}
			else
			{
				Mathf.Clamp01((_velocity.magnitude - _extrapolationSpeedThreshold) / _extrapolationSpeedThreshold);
				_currentExtrapolationBlend = 0f;
				float t2 = Mathf.Clamp01(num / _interpolationTime);
				Vector3 b3 = Vector3.Lerp(_previousPosition, _targetPosition, t2);
				Vector3 b4 = _targetPosition + _velocity * num;
				b3 = Vector3.Lerp(base.transform.position, b3, _smoothingFactor * deltaTime * 10f);
				Vector3 position3 = Vector3.Lerp(b3, b4, _currentExtrapolationBlend);
				Quaternion quaternion2 = Quaternion.Slerp(_previousRotation, _targetRotation, t2);
				if (Vector3.Distance(base.transform.position, _targetPosition) > 5f)
				{
					position3 = (_previousPosition = _targetPosition);
					base.transform.SetPositionAndRotation(position3, quaternion2);
				}
				else
				{
					base.transform.SetPositionAndRotation(position3, Quaternion.Slerp(base.transform.rotation, quaternion2, _smoothingFactor * deltaTime * 10f));
				}
			}
			_animationVelocity = Vector3.Lerp(_animationVelocity, _velocity, _smoothingFactor * deltaTime * 10f);
			_animationPlanarSpeed = Mathf.Lerp(_animationPlanarSpeed, _planarSpeed, _smoothingFactor * deltaTime * 10f);
			_animationTimeToGround = Mathf.Lerp(_animationTimeToGround, _timeToGround, _smoothingFactor * deltaTime * 20f);
			_animationHorizontalAxis = Mathf.Lerp(_animationHorizontalAxis, _horizontalAxis, _smoothingFactor * deltaTime * 10f);
			_animationVerticalAxis = Mathf.Lerp(_animationVerticalAxis, _verticalAxis, _smoothingFactor * deltaTime * 10f);
			_animationSwimLayerWeight = Mathf.Lerp(_animationSwimLayerWeight, _swimLayerWeight, _smoothingFactor * deltaTime / _normalMovementState.WaterParameters.SwimTransitionTime);
			if (_normalMovementState.RuntimeAnimatorController == _player.CharacterAnimator.runtimeAnimatorController)
			{
				_normalMovementState.SetRemoteSpeedProperties(_animationVelocity.y, _animationPlanarSpeed, _animationHorizontalAxis, _animationVerticalAxis, _animationTimeToGround);
				_normalMovementState.SetRemoteLayerWeight(_swimLayer, _animationSwimLayerWeight);
			}
			_body.linearVelocity = _velocity;
		}

		protected virtual void OnDestroy()
		{
			if ((object)FloatingOriginScript.Instance != null)
			{
				FloatingOriginScript.Instance.Repositioned -= FloatingOriginChanged;
			}
			FlightSceneScript instance = FlightSceneScript.Instance;
			if ((object)instance != null)
			{
				instance.PlayerLoaded -= OnPlayerLoaded;
			}
		}

		private void AttachedToPlayer(FlightScenePlayer player)
		{
			_player = player;
			player.OnCharacterLoaded(this);
			if (base.IsOwner)
			{
				_characterActor.Velocity = Vector3.zero;
			}
		}

		private void FloatingOriginChanged(object sender, FloatingOriginUpdatedEventArgs e)
		{
			base.transform.position -= e.Delta;
			if (_relativeVelocityZone == null)
			{
				_targetPosition -= e.Delta;
				_previousPosition -= e.Delta;
			}
		}

		private void OnDanceStateChanged(int state)
		{
			SetAnimationStateServer(++_lastAnimationMessageId, state);
		}

		private void OnPlayerLoaded(object sender, FlightScenePlayerEventArgs e)
		{
			if (e.Player.NetworkPlayer.PlayerId == base.OwnerId)
			{
				Debug.Log($"Found player for network character with owner {base.OwnerId}");
				FlightSceneScript.Instance.PlayerLoaded -= OnPlayerLoaded;
				AttachedToPlayer(e.Player);
			}
		}

		private void OnPostTickOwner()
		{
			using (Profile.OnPostTickOwner.Auto())
			{
				if (base.gameObject.activeInHierarchy)
				{
					PooledWriter pooledWriter = WriterPool.Retrieve();
					SerializeWrite(pooledWriter);
					RpcNetworkCharacterDataReceived(pooledWriter.GetArraySegment());
					pooledWriter.Store();
				}
			}
		}

		[ObserversRpc(ExcludeOwner = true)]
		private void RpcDataReceivedClient(ArraySegment<byte> data, Channel channel = Channel.Unreliable)
		{
			RpcWriter___Observers_RpcDataReceivedClient___2713644489(data, channel);
		}

		[ServerRpc]
		private void RpcNetworkCharacterDataReceived(ArraySegment<byte> data, Channel channel = Channel.Unreliable)
		{
			RpcWriter___Server_RpcNetworkCharacterDataReceived___2713644489(data, channel);
		}

		private void SerializeRead(Reader reader)
		{
			bool flag = true;
			float num = reader.ReadSingle();
			Vector3 vector = reader.ReadVector3() - GameWorld.Instance.FloatingOriginOffset;
			int objectOrPrefabId;
			NetworkObject networkObject = reader.ReadNetworkObject(out objectOrPrefabId, null, logException: false);
			if (objectOrPrefabId != 65535)
			{
				_relativeVelocityZone = networkObject?.GetComponentInChildren<RelativeVelocityZoneScript>();
				if (_relativeVelocityZone?.Rigidbody == null)
				{
					flag = false;
					_relativeVelocityZone = null;
					if (_player.AvatarActive)
					{
						Debug.LogWarning("Character is on a relative velocity zone that is not spawned/initialized");
					}
				}
			}
			else
			{
				_relativeVelocityZone = null;
			}
			_player.AvatarActive = flag;
			if (!flag)
			{
				return;
			}
			_ = _fsn.PhysicsTime;
			if (!(_lastPhysicsTime <= num))
			{
				return;
			}
			_lastPhysicsTime = num;
			Vector3 vector2 = reader.ReadVector3();
			Vector3 vector3 = reader.ReadVector3();
			Quaternion targetRotation = reader.ReadQuaternion32();
			float planarSpeed = reader.ReadSingle();
			float timeToGround = reader.ReadSingle();
			float horizontalAxis = reader.ReadSingle();
			float verticalAxis = reader.ReadSingle();
			int swimLayer = reader.ReadInt32();
			float swimLayerWeight = reader.ReadSingle();
			bool remoteCrouched = reader.ReadBoolean();
			bool grounded = reader.ReadBoolean();
			bool stable = reader.ReadBoolean();
			if (_body != null && _characterActor != null)
			{
				if (_relativeVelocityZone != null)
				{
					_previousLocalPosition = _targetLocalPosition;
					_targetLocalPosition = vector2;
					_localVelocity = vector3;
					Transform transform = _relativeVelocityZone.Rigidbody.transform;
					_previousPosition = transform.TransformPoint(_previousLocalPosition);
					_targetPosition = transform.TransformPoint(_targetLocalPosition);
					_velocity = _relativeVelocityZone.Rigidbody.linearVelocity + _localVelocity;
				}
				else
				{
					_previousPosition = _targetPosition;
					_targetPosition = vector2 + vector;
					_velocity = vector3;
				}
				_previousRotation = _targetRotation;
				_targetRotation = targetRotation;
				_planarSpeed = planarSpeed;
				_timeToGround = timeToGround;
				_horizontalAxis = horizontalAxis;
				_verticalAxis = verticalAxis;
				_swimLayer = swimLayer;
				_swimLayerWeight = swimLayerWeight;
				_lastPacketTime = num;
				if (_normalMovementState.RuntimeAnimatorController == _player.CharacterAnimator.runtimeAnimatorController)
				{
					_normalMovementState.SetRemoteGroundedProperties(grounded, stable);
					_normalMovementState.SetRemoteCrouched(remoteCrouched);
				}
			}
			else
			{
				Debug.LogWarning("Character body or actor is null");
			}
		}

		private void SerializeWrite(Writer writer)
		{
			writer.WriteSingle(_fsn.PhysicsTime);
			writer.WriteVector3(GameWorld.Instance.FloatingOriginOffset);
			bool num = _relativeVelocityZone != null && _relativeVelocityZone.Rigidbody != null;
			Vector3 vector = (_characterActor?.Velocity + _characterActor?.GroundVelocity) ?? Vector3.zero;
			if (num)
			{
				writer.WriteNetworkObject(_relativeVelocityZone.NetworkObject);
				Rigidbody rigidbody = _relativeVelocityZone.Rigidbody;
				Transform transform = rigidbody.transform;
				writer.WriteVector3(transform.InverseTransformPoint(base.transform.position));
				writer.WriteVector3(transform.InverseTransformDirection(vector - rigidbody.linearVelocity));
			}
			else
			{
				writer.WriteNetworkObject(null);
				writer.WriteVector3(base.transform.position);
				writer.WriteVector3(vector);
			}
			writer.WriteQuaternion32(base.transform.rotation);
			writer.WriteSingle(_characterActor?.PlanarVelocity.magnitude ?? 0f);
			writer.WriteSingle(_normalMovementState?.TimeToGround ?? 0f);
			writer.WriteSingle(_normalMovementState?.HorizontalAxis ?? 0f);
			writer.WriteSingle(_normalMovementState?.VerticalAxis ?? 0f);
			writer.WriteInt32(_normalMovementState?.SwimLayer ?? 1);
			writer.WriteSingle(_normalMovementState?.SwimLayerWeight ?? 0f);
			writer.WriteBoolean(_normalMovementState.IsCrouched);
			writer.WriteBoolean(_characterActor.IsGrounded);
			writer.WriteBoolean(_characterActor.IsStable);
		}

		[ObserversRpc(ExcludeOwner = true)]
		private void SetAnimationStateClient(int messageId, int state)
		{
			RpcWriter___Observers_SetAnimationStateClient___1692629761(messageId, state);
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkCharacterScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkCharacterScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				RegisterServerRpc(0u, RpcReader___Server_SetAnimationStateServer___1692629761);
				RegisterObserversRpc(1u, RpcReader___Observers_RpcDataReceivedClient___2713644489);
				RegisterServerRpc(2u, RpcReader___Server_RpcNetworkCharacterDataReceived___2713644489);
				RegisterObserversRpc(3u, RpcReader___Observers_SetAnimationStateClient___1692629761);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkCharacterScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkCharacterScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Server_SetAnimationStateServer___1692629761(int messageId, int state)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			if (!base.IsOwner)
			{
				NetworkManager networkManager2 = base.NetworkManager;
				networkManager2.LogWarning("Cannot complete action because you are not the owner of this object. .");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(messageId);
			pooledWriter.WriteInt32(state);
			SendServerRpc(0u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		public void RpcLogic___SetAnimationStateServer___1692629761(int P_0, int P_1)
		{
			SetAnimationStateClient(P_0, P_1);
		}

		private void RpcReader___Server_SetAnimationStateServer___1692629761(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			int num2 = PooledReader0.ReadInt32();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___SetAnimationStateServer___1692629761(num, num2);
			}
		}

		private void RpcWriter___Observers_RpcDataReceivedClient___2713644489(ArraySegment<byte> data, Channel channel = Channel.Unreliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			SendObserversRpc(1u, pooledWriter, channel2, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcDataReceivedClient___2713644489(ArraySegment<byte> P_0, Channel P_1)
		{
			if (!base.IsOwner)
			{
				PooledReader pooledReader = ReaderPool.Retrieve(P_0, base.NetworkManager);
				SerializeRead(pooledReader);
				pooledReader.Store();
			}
		}

		private void RpcReader___Observers_RpcDataReceivedClient___2713644489(PooledReader PooledReader0, Channel channel)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcDataReceivedClient___2713644489(arraySegment, channel);
			}
		}

		private void RpcWriter___Server_RpcNetworkCharacterDataReceived___2713644489(ArraySegment<byte> data, Channel channel = Channel.Unreliable)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			if (!base.IsOwner)
			{
				NetworkManager networkManager2 = base.NetworkManager;
				networkManager2.LogWarning("Cannot complete action because you are not the owner of this object. .");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			SendServerRpc(2u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcNetworkCharacterDataReceived___2713644489(ArraySegment<byte> P_0, Channel P_1)
		{
			RpcDataReceivedClient(P_0, P_1);
		}

		private void RpcReader___Server_RpcNetworkCharacterDataReceived___2713644489(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___RpcNetworkCharacterDataReceived___2713644489(arraySegment, channel);
			}
		}

		private void RpcWriter___Observers_SetAnimationStateClient___1692629761(int messageId, int state)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(messageId);
			pooledWriter.WriteInt32(state);
			SendObserversRpc(3u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___SetAnimationStateClient___1692629761(int P_0, int P_1)
		{
			if (_lastAnimationMessageId <= P_0)
			{
				_normalMovementState.ForceNetworkDanceState = P_1;
			}
		}

		private void RpcReader___Observers_SetAnimationStateClient___1692629761(PooledReader PooledReader0, Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			int num2 = PooledReader0.ReadInt32();
			if (base.IsClientInitialized)
			{
				RpcLogic___SetAnimationStateClient___1692629761(num, num2);
			}
		}

		protected virtual void Awake_UserLogic_Assets_002EScripts_002EMultiplayer_002ENetworkCharacterScript_Game_002Edll()
		{
			FloatingOriginScript.Instance.Repositioned += FloatingOriginChanged;
		}
	}
}
