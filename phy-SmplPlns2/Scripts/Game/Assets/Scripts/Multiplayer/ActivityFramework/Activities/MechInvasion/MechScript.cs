using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.WorldObjects.Combat;
using Assets.Scripts.Input;
using Assets.Scripts.Multiplayer.FlightObjects.Damage;
using Assets.Scripts.Multiplayer.FlightObjects.Damage.Events;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Jundroo.Common.Extensions;
using Jundroo.Common.Pool;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.MechInvasion
{
	public class MechScript : NetworkBehaviour
	{
		private Animation _animation;

		private Rigidbody _body;

		[SerializeField]
		private GameObject[] _breakawayParts;

		private float _closestDistanceToTarget = float.MaxValue;

		private int _currentWaypointTargetIndex;

		[SerializeField]
		private ParticleSystem _destroyedSmoke;

		[SerializeField]
		private RotatingGunScript _guns;

		[SerializeField]
		private Transform[] _raycastPoints;

		[SerializeField]
		private MechShieldScript _shields;

		[SerializeField]
		private AnimationClip _shutdownClip;

		[SerializeField]
		private float _speed = 5f;

		[SerializeField]
		private Transform _targetPosition;

		private float _timeAtObjective;

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EMechInvasion_002EMechScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EMechInvasion_002EMechScriptGame_002Edll_Excuted;

		public MechInvasionScript Activity { get; private set; }

		public NetworkFlightObjectDamageReceiverScript DamageReceiver { get; private set; }

		public bool HasReachedObjective { get; private set; }

		public bool HasStopped { get; private set; }

		public bool IsDestroyed { get; private set; }

		public string MechName { get; private set; }

		public MechPathScript Path { get; private set; }

		public ushort RandomSeed { get; private set; }

		public GroundTarget Target { get; private set; }

		public NpcTargetingSystem TargetingSystem { get; private set; }

		[field: SerializeField]
		public ushort TeamId { get; private set; }

		public float TimeAtObjective => _timeAtObjective;

		public List<INpcWeaponSystem> WeaponSystems { get; private set; }

		public override void OnStartClient()
		{
			base.OnStartClient();
			base.transform.SetParent(Activity.transform, worldPositionStays: true);
			Activity.RegisterMech(this);
		}

		public void OnUpdateServer()
		{
			if (HasReachedObjective && !IsDestroyed)
			{
				_timeAtObjective += Time.deltaTime;
			}
			IReadOnlyList<MechPathWaypointScript> readOnlyList = Path?.Waypoints ?? Array.Empty<MechPathWaypointScript>();
			if (IsDestroyed || HasReachedObjective || _currentWaypointTargetIndex >= readOnlyList.Count)
			{
				return;
			}
			float num = (Path.Waypoints[_currentWaypointTargetIndex].Position - base.transform.position).MagnitudeXZ();
			if (num > _closestDistanceToTarget + 100f)
			{
				DestroyMechServerRpc();
				return;
			}
			_closestDistanceToTarget = Mathf.Min(_closestDistanceToTarget, num);
			if (num < 20f)
			{
				_closestDistanceToTarget = float.MaxValue;
				int num2 = _currentWaypointTargetIndex + 1;
				if (num2 >= Path.Waypoints.Count)
				{
					MechReachedObjectiveServerRpc();
				}
				else
				{
					SetWaypointTargetServerRpc((byte)num2);
				}
			}
		}

		public override void ReadPayload(NetworkConnection connection, Reader reader)
		{
			base.ReadPayload(connection, reader);
			NetworkObject networkObject = reader.ReadNetworkObject();
			Activity = networkObject.GetComponent<MechInvasionScript>();
			RandomSeed = reader.ReadUInt16();
			MechName = reader.ReadStringAllocated();
			string pathName = reader.ReadStringAllocated();
			List<MechPathScript> value;
			using (CollectionPool<List<MechPathScript>, MechPathScript>.Get(out value))
			{
				Activity.GetComponentsInChildren(includeInactive: false, value);
				Path = value.FirstOrDefault((MechPathScript p) => p.name == pathName);
				if (Path == null)
				{
					Debug.LogError("Could not find the mech path named '" + pathName + "' for mech '" + MechName + "'");
				}
				_currentWaypointTargetIndex = reader.ReadUInt8Unpacked();
				IsDestroyed = reader.ReadBoolean();
				TeamId = Activity.Team2.PlayerTeamId;
			}
		}

		public void ServerInitialize(MechInvasionScript activity, MechPathScript path, int waypointIndexTarget, ushort randomSeed, string mechName, ushort teamId)
		{
			Activity = activity;
			Path = path;
			RandomSeed = randomSeed;
			MechName = mechName;
			TeamId = teamId;
			_currentWaypointTargetIndex = waypointIndexTarget;
		}

		public override void WritePayload(NetworkConnection connection, Writer writer)
		{
			base.WritePayload(connection, writer);
			writer.WriteNetworkObject(Activity.NetworkObject);
			writer.WriteUInt16(RandomSeed);
			writer.WriteString(MechName);
			writer.WriteString(Path.name);
			writer.WriteUInt8Unpacked((byte)_currentWaypointTargetIndex);
			writer.WriteBoolean(IsDestroyed);
		}

		protected virtual void InitializeDamageReceiver()
		{
			DamageReceiver = GetComponent<NetworkFlightObjectDamageReceiverScript>();
			DamageReceiver.DamageLevelChanged += OnDamageLevelChanged;
			DamageReceiver.LocalDamageReceived += OnLocalDamageReceived;
			DamageReceiver.DamageReceptionEnabled = false;
		}

		protected void OnDestroy()
		{
			TargetingSystem?.OnDestroy();
			if (Target != null)
			{
				FlightSceneScript.Instance.TargetRegistry.UnregisterTarget(Target);
			}
		}

		protected virtual void Start()
		{
			InitializeDamageReceiver();
			Unity.Mathematics.Random random = new Unity.Mathematics.Random(RandomSeed);
			float num = Mathf.Lerp(0.95f, 1.05f, random.NextFloat());
			_speed *= num;
			_animation = GetComponent<Animation>();
			if (!HasReachedObjective)
			{
				AnimationState animationState = _animation["Forward"];
				animationState.speed = 0.25f * num;
				animationState.time = random.NextFloat();
			}
			_body = GetComponent<Rigidbody>();
			Target = new GroundTarget(MechName, _targetPosition ?? base.transform, 10000f, TeamId);
			FlightSceneScript.Instance.TargetRegistry.RegisterTarget(Target);
			TargetingSystem = new NpcTargetingSystem(TeamId);
			WeaponSystems = GetComponentsInChildren<INpcWeaponSystem>(includeInactive: true).ToList();
			foreach (INpcWeaponSystem weaponSystem in WeaponSystems)
			{
				weaponSystem.InitializeTargetingSystem(TargetingSystem);
				weaponSystem.Arm();
			}
			if (IsDestroyed)
			{
				OnMechDestroyed();
			}
		}

		protected virtual void Update()
		{
			if (HasReachedObjective && !IsDestroyed)
			{
				if (!base.IsServerStarted)
				{
					_timeAtObjective += Time.deltaTime;
				}
				if (_timeAtObjective > 10f && !HasStopped)
				{
					HasStopped = true;
					_animation.Stop();
				}
			}
			bool flag = !IsDestroyed && !HasStopped;
			if (flag)
			{
				Vector3 vector = base.transform.forward * _speed;
				vector.y = 0f;
				base.transform.position += vector * Time.deltaTime;
			}
			Vector3? vector2 = null;
			Transform[] raycastPoints = _raycastPoints;
			foreach (Transform transform in raycastPoints)
			{
				Ray ray = new Ray(transform.position + Vector3.up * 1000f, Vector3.down);
				int layerMask = 9441280;
				Vector3? terrainIntersection = Utility.GetTerrainIntersection(ray, 20000f, layerMask);
				if (terrainIntersection.HasValue && (!vector2.HasValue || terrainIntersection.Value.y < vector2.Value.y))
				{
					vector2 = terrainIntersection.Value;
				}
			}
			if (vector2.HasValue)
			{
				Vector3 position = base.transform.position;
				position.y = vector2.Value.y;
				base.transform.position = position;
			}
			if (flag)
			{
				Transform transform2 = Path.Objective;
				if (_currentWaypointTargetIndex < Path.Waypoints.Count)
				{
					transform2 = Path.Waypoints[_currentWaypointTargetIndex]?.transform;
				}
				Vector3 eulerAngles = Quaternion.LookRotation((transform2.position - base.transform.position).normalized, Vector3.up).eulerAngles;
				Vector3 eulerAngles2 = base.transform.rotation.eulerAngles;
				float y = Mathf.MoveTowardsAngle(eulerAngles2.y, eulerAngles.y, 15f * Time.deltaTime);
				base.transform.rotation = Quaternion.Euler(eulerAngles2.x, y, eulerAngles2.z);
			}
			TargetingSystem.Update(base.transform.position);
			if (DebugInput.GetKeyDown(KeyCode.X) && DebugInput.GetKey(KeyCode.LeftControl) && base.IsServerStarted)
			{
				DestroyMechServerRpc();
			}
		}

		[ContextMenu("Destroy Mech")]
		private void DestroyMech()
		{
			DestroyMechServerRpc();
		}

		[ObserversRpc(RunLocally = true)]
		private void DestroyMechClientRpc()
		{
			RpcWriter___Observers_DestroyMechClientRpc___2166136261();
			RpcLogic___DestroyMechClientRpc___2166136261();
		}

		[ServerRpc(RunLocally = true)]
		private void DestroyMechServerRpc()
		{
			RpcWriter___Server_DestroyMechServerRpc___2166136261();
			RpcLogic___DestroyMechServerRpc___2166136261();
		}

		[ObserversRpc(RunLocally = true)]
		private void MechReachedObjectiveClientRpc()
		{
			RpcWriter___Observers_MechReachedObjectiveClientRpc___2166136261();
			RpcLogic___MechReachedObjectiveClientRpc___2166136261();
		}

		[ServerRpc(RunLocally = true)]
		private void MechReachedObjectiveServerRpc()
		{
			RpcWriter___Server_MechReachedObjectiveServerRpc___2166136261();
			RpcLogic___MechReachedObjectiveServerRpc___2166136261();
		}

		private void OnDamageLevelChanged(object sender, DamageLevelEventArgs e)
		{
			if (e.NewLevel.Level >= 4 && base.IsServerStarted && !IsDestroyed)
			{
				DestroyMechServerRpc();
			}
		}

		private void OnLocalDamageReceived(object sender, LocalDamageReceivedEventArgs e)
		{
			if (e.PlayerId.HasValue && Activity.LocalPlayer != null && e.PlayerId == Activity.LocalPlayer.PlayerId)
			{
				Activity.RegisterDamageFromLocalPlayer(e.DamageReceived);
			}
		}

		private void OnMechDestroyed()
		{
			if (IsDestroyed)
			{
				return;
			}
			foreach (INpcWeaponSystem weaponSystem in WeaponSystems)
			{
				weaponSystem.Disable();
			}
			Target.MarkAsDead();
			_destroyedSmoke.gameObject.SetActive(value: true);
			_animation["Forward"].speed = 0f;
			_animation.clip = _shutdownClip;
			_animation.Play();
			IsDestroyed = true;
			GameObject[] breakawayParts = _breakawayParts;
			for (int i = 0; i < breakawayParts.Length; i++)
			{
				Rigidbody rigidbody = breakawayParts[i].AddComponent<Rigidbody>();
				rigidbody.mass = 100f;
				rigidbody.linearDamping = 0.2f;
				rigidbody.linearVelocity = UnityEngine.Random.insideUnitSphere * 15f;
				rigidbody.angularVelocity = UnityEngine.Random.insideUnitSphere * 3f;
			}
		}

		[ObserversRpc(RunLocally = true)]
		private void SetWaypointTargetClientRpc(byte waypointIndex)
		{
			RpcWriter___Observers_SetWaypointTargetClientRpc___1246646286(waypointIndex);
			RpcLogic___SetWaypointTargetClientRpc___1246646286(waypointIndex);
		}

		[ServerRpc(RunLocally = true)]
		private void SetWaypointTargetServerRpc(byte waypointIndex)
		{
			RpcWriter___Server_SetWaypointTargetServerRpc___1246646286(waypointIndex);
			RpcLogic___SetWaypointTargetServerRpc___1246646286(waypointIndex);
		}

		private IEnumerator StopWalkingAnimationAfterCurrentLoop()
		{
			AnimationState state = _animation["Forward"];
			int currentLoop = Mathf.FloorToInt(state.normalizedTime + 0.5f);
			while (Mathf.FloorToInt(state.normalizedTime + 0.5f) == currentLoop)
			{
				yield return null;
			}
			HasStopped = true;
			_animation.Stop();
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EMechInvasion_002EMechScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EMechInvasion_002EMechScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				RegisterObserversRpc(0u, RpcReader___Observers_DestroyMechClientRpc___2166136261);
				RegisterServerRpc(1u, RpcReader___Server_DestroyMechServerRpc___2166136261);
				RegisterObserversRpc(2u, RpcReader___Observers_MechReachedObjectiveClientRpc___2166136261);
				RegisterServerRpc(3u, RpcReader___Server_MechReachedObjectiveServerRpc___2166136261);
				RegisterObserversRpc(4u, RpcReader___Observers_SetWaypointTargetClientRpc___1246646286);
				RegisterServerRpc(5u, RpcReader___Server_SetWaypointTargetServerRpc___1246646286);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EMechInvasion_002EMechScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EActivityFramework_002EActivities_002EMechInvasion_002EMechScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Observers_DestroyMechClientRpc___2166136261()
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			SendObserversRpc(0u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___DestroyMechClientRpc___2166136261()
		{
			OnMechDestroyed();
		}

		private void RpcReader___Observers_DestroyMechClientRpc___2166136261(PooledReader PooledReader0, Channel channel)
		{
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___DestroyMechClientRpc___2166136261();
			}
		}

		private void RpcWriter___Server_DestroyMechServerRpc___2166136261()
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
			SendServerRpc(1u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___DestroyMechServerRpc___2166136261()
		{
			Activity.ShowMessageToAllPlayers(MechName + " has been destroyed!", logMessage: true, highlighted: true);
			DestroyMechClientRpc();
		}

		private void RpcReader___Server_DestroyMechServerRpc___2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			if (base.IsServerInitialized && OwnerMatches(conn) && !conn.IsLocalClient)
			{
				RpcLogic___DestroyMechServerRpc___2166136261();
			}
		}

		private void RpcWriter___Observers_MechReachedObjectiveClientRpc___2166136261()
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			SendObserversRpc(2u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___MechReachedObjectiveClientRpc___2166136261()
		{
			HasReachedObjective = true;
			_currentWaypointTargetIndex = Path.Waypoints.Count;
			_guns.OverrideTarget = Path.Objective;
			Activity.OnMechReachedObjective(this);
			StartCoroutine(StopWalkingAnimationAfterCurrentLoop());
		}

		private void RpcReader___Observers_MechReachedObjectiveClientRpc___2166136261(PooledReader PooledReader0, Channel channel)
		{
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___MechReachedObjectiveClientRpc___2166136261();
			}
		}

		private void RpcWriter___Server_MechReachedObjectiveServerRpc___2166136261()
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
			SendServerRpc(3u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___MechReachedObjectiveServerRpc___2166136261()
		{
			MechReachedObjectiveClientRpc();
		}

		private void RpcReader___Server_MechReachedObjectiveServerRpc___2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			if (base.IsServerInitialized && OwnerMatches(conn) && !conn.IsLocalClient)
			{
				RpcLogic___MechReachedObjectiveServerRpc___2166136261();
			}
		}

		private void RpcWriter___Observers_SetWaypointTargetClientRpc___1246646286(byte waypointIndex)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteUInt8Unpacked(waypointIndex);
			SendObserversRpc(4u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: true);
			pooledWriter.Store();
		}

		private void RpcLogic___SetWaypointTargetClientRpc___1246646286(byte P_0)
		{
			_currentWaypointTargetIndex = P_0;
		}

		private void RpcReader___Observers_SetWaypointTargetClientRpc___1246646286(PooledReader PooledReader0, Channel channel)
		{
			byte b = PooledReader0.ReadUInt8Unpacked();
			if (base.IsClientInitialized && !base.IsHostStarted)
			{
				RpcLogic___SetWaypointTargetClientRpc___1246646286(b);
			}
		}

		private void RpcWriter___Server_SetWaypointTargetServerRpc___1246646286(byte waypointIndex)
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
			pooledWriter.WriteUInt8Unpacked(waypointIndex);
			SendServerRpc(5u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___SetWaypointTargetServerRpc___1246646286(byte P_0)
		{
			SetWaypointTargetClientRpc(P_0);
		}

		private void RpcReader___Server_SetWaypointTargetServerRpc___1246646286(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			byte b = PooledReader0.ReadUInt8Unpacked();
			if (base.IsServerInitialized && OwnerMatches(conn) && !conn.IsLocalClient)
			{
				RpcLogic___SetWaypointTargetServerRpc___1246646286(b);
			}
		}

		public virtual void Awake()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}
	}
}
