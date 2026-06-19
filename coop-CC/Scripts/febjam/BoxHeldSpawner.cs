using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class BoxHeldSpawner : NetworkEntityBehaviourBase
{
	[Min(0f)]
	public float spawnEveryInSeconds = 1f;

	public bool checkPlayerSpeed;

	public Vector2 spawnMinMaxSpeed = new Vector2(10f, 15f);

	public Vector2 spawnMinMaxAngularSpeed = new Vector2(20f, 90f);

	public float spawnDistanceUpOffset = 0.5f;

	[Min(0f)]
	public float spawnDistanceOutOffset = 1f;

	public Vector2 upwardsModifierMinMaxDegrees = new Vector2(20f, 40f);

	public bool inheritFire = true;

	[Space]
	public GameObject prefab;

	[Header("Visual")]
	public Animator animator;

	public string animatorTriggerOnSpawn = "";

	public StudioEventEmitter sfxEmitter;

	[SyncVar]
	private bool _syncCanThrow;

	private Timer _spawnTimer;

	public bool canThrow => _syncCanThrow;

	public bool Network_syncCanThrow
	{
		get
		{
			return _syncCanThrow;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncCanThrow, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		_spawnTimer.SetTimer(spawnEveryInSeconds);
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer || !base.entity.TryGetObject<Grabbable>(out var obj) || !obj.ServerIsBeingHeldByPlayer())
		{
			return;
		}
		if (checkPlayerSpeed && obj.serverPlayerEntity.TryGetObject<VehicleController>(out var obj2) && obj.serverPlayerEntity.TryGetObject<NitroController>(out var obj3) && (MathUtil.Approximate(obj2.velocitySync, Vector3.zero) || obj3.nitroActiveSync || obj2.trailsEnabled))
		{
			Network_syncCanThrow = false;
			return;
		}
		Network_syncCanThrow = true;
		_spawnTimer.DecrementTimer();
		if (_spawnTimer.IsFinished())
		{
			_spawnTimer.SetTimer(spawnEveryInSeconds);
			RpcOnSpawned();
			Unity.Mathematics.Random random = GetRandom();
			Vector3 normalized = ((obj.stackLevel != 1) ? new Vector3(random.NextFloat(-1f, 1f), 0f, random.NextFloat(-1f, 1f)) : new Vector3(random.NextFloat(-1f, 1f), 0f, random.NextFloat(0f, 1f))).normalized;
			Vector3 vector = obj.ServerGetHoldingPlayer().transform.TransformDirection(normalized);
			Vector3 position = base.entity.transform.position + Vector3.up * spawnDistanceUpOffset + vector * spawnDistanceOutOffset;
			Entity entity = EntityUtil.Instantiate(prefab, position);
			Vector3 vector2 = vector;
			float angle = random.NextFloat(upwardsModifierMinMaxDegrees.x, upwardsModifierMinMaxDegrees.y);
			float num = random.NextFloat(spawnMinMaxSpeed.x, spawnMinMaxSpeed.y);
			float num2 = random.NextFloat(spawnMinMaxAngularSpeed.x, spawnMinMaxAngularSpeed.y);
			if (random.NextBool())
			{
				num2 *= -1f;
			}
			vector2 = Quaternion.AngleAxis(angle, MathUtil.GetOrtho(vector2, Vector3.up)) * vector2;
			vector2 *= num;
			entity.rigidbody.velocity = vector2;
			entity.rigidbody.angularVelocity = new Vector3(0f, num2, 0f);
			if (inheritFire && base.entity.TryGetObject<Flammable>(out var obj4) && obj4.isOnFire && entity.TryGetObject<Flammable>(out var obj5))
			{
				obj5.RequestSetFire();
			}
		}
	}

	[ClientRpc]
	public void RpcOnSpawned()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void BoxHeldSpawner::RpcOnSpawned()", 1710971345, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcOnSpawned()
	{
		sfxEmitter.Play();
		if (animator != null && !string.IsNullOrEmpty(animatorTriggerOnSpawn))
		{
			animator.SetTrigger(animatorTriggerOnSpawn);
		}
	}

	protected static void InvokeUserCode_RpcOnSpawned(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnSpawned called on server.");
		}
		else
		{
			((BoxHeldSpawner)obj).UserCode_RpcOnSpawned();
		}
	}

	static BoxHeldSpawner()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(BoxHeldSpawner), "System.Void BoxHeldSpawner::RpcOnSpawned()", InvokeUserCode_RpcOnSpawned);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(_syncCanThrow);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(_syncCanThrow);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncCanThrow, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncCanThrow, null, reader.ReadBool());
		}
	}
}
