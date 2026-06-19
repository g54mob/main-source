using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class ActivatedFirework : NetworkEntityBehaviourBase, IBoxActivated, IFlammable
{
	public enum State : byte
	{
		None = 0,
		Ignited = 1,
		Flying = 2,
		Done = 3
	}

	[Min(0f)]
	public float force = 50f;

	[Min(0f)]
	public float ignitionTime = 2f;

	[Min(0f)]
	public float explosionTime = 2f;

	[Min(0f)]
	public float rotateDownDegrees = 5f;

	[Min(0f)]
	public float noiseScale = 2f;

	[Range(0f, 360f)]
	public float noiseAngleDegrees = 5f;

	[Header("Explosion")]
	[Min(0f)]
	public float fireExplodeRadius = 4f;

	[SyncVar]
	private State _syncState;

	[SyncVar]
	private int _syncSeed;

	private Timer _timer;

	private static Collider[] _colliders;

	private const float NOISE_SAMPLE_DISTANCE = 100f;

	public MeshRenderer fireworkMeshRenderer;

	public ParticleSystem fireworkSmokeVFX;

	public ParticleSystem fireworkSparksVFX;

	public GameObject fireworkExplodeVFX;

	public StudioEventEmitter sfxFuseLoop;

	public StudioEventEmitter sfxIgnite;

	[FormerlySerializedAs("sfxTravel")]
	public StudioEventEmitter sfxTravelLoop;

	private static readonly int FLASHING_ID;

	public State state => _syncState;

	public State Network_syncState
	{
		get
		{
			return _syncState;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncState, 1uL, null);
		}
	}

	public int Network_syncSeed
	{
		get
		{
			return _syncSeed;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncSeed, 2uL, null);
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (_syncState == State.Ignited)
		{
			fireworkMeshRenderer.SetPropertyBlockFloat(FLASHING_ID, 1f);
		}
		else
		{
			fireworkMeshRenderer.SetPropertyBlockFloat(FLASHING_ID, 0f);
		}
		sfxFuseLoop.gameObject.SetActive(_syncState == State.Ignited);
		sfxTravelLoop.gameObject.SetActive(_syncState == State.Flying);
		ParticleSystem.EmissionModule emission = fireworkSmokeVFX.emission;
		ParticleSystem.EmissionModule emission2 = fireworkSparksVFX.emission;
		emission.enabled = _syncState == State.Ignited || _syncState == State.Flying;
		emission2.enabled = _syncState == State.Flying;
		if (_syncState == State.Flying && _timer.GetSecondsRemaining() < 1f)
		{
			sfxTravelLoop.Stop();
		}
	}

	[ClientRpc]
	private void RpcOnIgnite()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ActivatedFirework::RpcOnIgnite()", 1589974985, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	protected override void OnUpdateSimulation()
	{
		switch (_syncState)
		{
		case State.Flying:
		{
			Vector3 position = base.entity.rigidbody.position;
			Quaternion rotation = base.entity.rigidbody.rotation;
			Vector3 lhs = rotation * Vector3.up;
			Vector3 vector = rotation * Vector3.right;
			Vector3 axis = rotation * Vector3.forward;
			float x = Vector3.Dot(lhs, Vector3.up);
			float x2 = Vector3.Dot(vector, Vector3.up);
			if (math.abs(x) > math.abs(x2))
			{
				if (Vector3.Cross(lhs, Vector3.up).x > 0f)
				{
					rotation *= Quaternion.AngleAxis(0f - rotateDownDegrees, vector);
				}
				else
				{
					rotation *= Quaternion.AngleAxis(rotateDownDegrees, vector);
				}
			}
			else if (Vector3.Cross(vector, Vector3.up).z > 0f)
			{
				rotation *= Quaternion.AngleAxis(rotateDownDegrees, axis);
			}
			else
			{
				rotation *= Quaternion.AngleAxis(0f - rotateDownDegrees, axis);
			}
			Unity.Mathematics.Random random = MathUtil.GetRandom(_syncSeed);
			Vector3 vector2 = position + (Vector3)random.NextFloat3Direction() * random.NextFloat(0f, 100f);
			Vector3 vector3 = vector2 + Vector3.up * 100f;
			Vector3 vector4 = vector2 + Vector3.right * 100f;
			Vector3 vector5 = vector2 + Vector3.forward * 100f;
			float num = noise.cnoise(vector3 * noiseScale);
			float num2 = noise.cnoise(vector4 * noiseScale);
			Quaternion quaternion2 = Quaternion.Euler(z: noise.cnoise(vector5 * noiseScale) * noiseAngleDegrees, x: num * noiseAngleDegrees, y: num2 * noiseAngleDegrees);
			rotation *= quaternion2;
			Vector3 vector6 = rotation * Vector3.up;
			base.entity.rigidbody.rotation = rotation;
			base.entity.rigidbody.AddForce(vector6 * force, ForceMode.Acceleration);
			break;
		}
		default:
			throw new InvalidEnumException();
		case State.None:
		case State.Ignited:
		case State.Done:
			break;
		}
		if (!base.isServer)
		{
			return;
		}
		switch (_syncState)
		{
		case State.Ignited:
			_timer.DecrementTimer();
			if (_timer.IsFinished())
			{
				Network_syncState = State.Flying;
				_timer.SetTimer(explosionTime);
			}
			break;
		case State.Flying:
			_timer.DecrementTimer();
			if (_timer.IsFinished())
			{
				Network_syncState = State.Done;
				base.entity.GetObject<Grabbable>().ServerSetInteractable(interactable: true);
				ServerExplode();
			}
			break;
		default:
			throw new InvalidEnumException();
		case State.None:
		case State.Done:
			break;
		}
	}

	public void ServerBoxActivated(ActivationContext context)
	{
		Network_syncState = State.Ignited;
		Network_syncSeed = GetSeed();
		RpcOnIgnite();
		Grabbable grabbable = base.entity.GetObject<Grabbable>();
		if (base.entity.TryGetObject<BoxHealth>(out var obj))
		{
			obj.RequestTakeDamage(DamageType.Damaged);
		}
		if (grabbable.isInStack)
		{
			grabbable.ServerBreakEntireStack();
		}
		grabbable.ServerSetInteractable(interactable: false);
		_timer.SetTimer(ignitionTime);
	}

	[Server]
	private void ServerExplode()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ActivatedFirework::ServerExplode()' called when server was not active");
			return;
		}
		Vector3 position = base.entity.transform.position;
		int num = Physics.OverlapSphereNonAlloc(position, fireExplodeRadius, _colliders, 147464);
		for (int i = 0; i < num; i++)
		{
			Entity entity = _colliders[i].GetComponent<EntityCollider>().entity;
			if (!(entity == base.entity) && entity.TryGetObject<Flammable>(out var obj))
			{
				obj.RequestSetFire();
			}
		}
		num = Physics.OverlapSphereNonAlloc(position, fireExplodeRadius, _colliders, 256);
		for (int j = 0; j < num; j++)
		{
			Entity entity2 = _colliders[j].GetComponent<EntityCollider>().entity;
			if (entity2.TryGetObject<PlayerStress>(out var obj2))
			{
				if (entity2.TryGetObject<PlayerUpgrades>(out var obj3) && obj3.HasUpgrade(PlayerUpgrade.BlastProtection))
				{
					obj2.RequestAddStress(obj3.blastProtectedStressAddAmount, sendEvent: true);
				}
				else
				{
					obj2.RequestAddStress(1f, sendEvent: true);
				}
			}
		}
		NetworkAggroManagerBase<VFXManager>.instance.Play(fireworkExplodeVFX, position);
	}

	[Server]
	public bool ServerFlammableCanBePutOut()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean ActivatedFirework::ServerFlammableCanBePutOut()' called when server was not active");
			return default(bool);
		}
		if (_syncState != State.Ignited)
		{
			return _syncState == State.Flying;
		}
		return true;
	}

	[Server]
	public void ServerFlammablePutOut()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ActivatedFirework::ServerFlammablePutOut()' called when server was not active");
		}
		else if (_syncState == State.Ignited || _syncState == State.Flying)
		{
			Network_syncState = State.Done;
			base.entity.GetObject<Grabbable>().ServerSetInteractable(interactable: true);
		}
	}

	static ActivatedFirework()
	{
		_colliders = new Collider[128];
		FLASHING_ID = Shader.PropertyToID("_flashing");
		RemoteProcedureCalls.RegisterRpc(typeof(ActivatedFirework), "System.Void ActivatedFirework::RpcOnIgnite()", InvokeUserCode_RpcOnIgnite);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcOnIgnite()
	{
		sfxIgnite.Play();
	}

	protected static void InvokeUserCode_RpcOnIgnite(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnIgnite called on server.");
		}
		else
		{
			((ActivatedFirework)obj).UserCode_RpcOnIgnite();
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			GeneratedNetworkCode._Write_ActivatedFirework_002FState(writer, _syncState);
			writer.WriteVarInt(_syncSeed);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_ActivatedFirework_002FState(writer, _syncState);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarInt(_syncSeed);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_ActivatedFirework_002FState(reader));
			GeneratedSyncVarDeserialize(ref _syncSeed, null, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncState, null, GeneratedNetworkCode._Read_ActivatedFirework_002FState(reader));
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncSeed, null, reader.ReadVarInt());
		}
	}
}
