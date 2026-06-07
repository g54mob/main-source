using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class GasCollisionSpawner : NetworkBehaviour
{
	public GameObject objectToSpawn;

	private ParticleSystem ps;

	public int spawnEveryXCollisions = 1;

	private int curSpawnEveryXCollisions;

	private void Start()
	{
		ps = GetComponent<ParticleSystem>();
	}

	private void OnParticleCollision(GameObject other)
	{
		int num = LayerMask.NameToLayer("Water");
		if (other.layer == num)
		{
			PetrolTank componentInParent = other.GetComponentInParent<PetrolTank>();
			if (componentInParent != null)
			{
				componentInParent.PetrolPumped();
				KillCollidedParticles(other);
				return;
			}
		}
		curSpawnEveryXCollisions++;
		if (curSpawnEveryXCollisions != spawnEveryXCollisions)
		{
			KillCollidedParticles(other);
			return;
		}
		curSpawnEveryXCollisions = 0;
		List<ParticleCollisionEvent> list = new List<ParticleCollisionEvent>();
		int collisionEvents = ps.GetCollisionEvents(other, list);
		ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.main.maxParticles];
		int particles2 = ps.GetParticles(particles);
		for (int i = 0; i < collisionEvents; i++)
		{
			Vector3 intersection = list[i].intersection;
			Quaternion rot = Quaternion.LookRotation(list[i].normal);
			SpawnParticle(intersection, rot);
			KillClosestParticleAt(intersection, particles, particles2);
		}
		ps.SetParticles(particles, particles2);
	}

	private void KillCollidedParticles(GameObject other)
	{
		List<ParticleCollisionEvent> list = new List<ParticleCollisionEvent>();
		int collisionEvents = ps.GetCollisionEvents(other, list);
		ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.main.maxParticles];
		int particles2 = ps.GetParticles(particles);
		for (int i = 0; i < collisionEvents; i++)
		{
			KillClosestParticleAt(list[i].intersection, particles, particles2);
		}
		ps.SetParticles(particles, particles2);
	}

	private static void KillClosestParticleAt(Vector3 hitPos, ParticleSystem.Particle[] particles, int alive, float threshold = 0.1f)
	{
		for (int i = 0; i < alive; i++)
		{
			if (Vector3.Distance(particles[i].position, hitPos) < threshold)
			{
				particles[i].remainingLifetime = 0f;
				break;
			}
		}
	}

	private void SpawnParticle(Vector3 pos, Quaternion rot)
	{
		if (base.isServer)
		{
			SpawnParticleRpc(pos, rot);
		}
		else
		{
			SpawnParticleCmd(pos, rot);
		}
	}

	[Command(requiresAuthority = false)]
	private void SpawnParticleCmd(Vector3 pos, Quaternion rot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rot);
		SendCommandInternal("System.Void GasCollisionSpawner::SpawnParticleCmd(UnityEngine.Vector3,UnityEngine.Quaternion)", 1624812709, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void SpawnParticleRpc(Vector3 pos, Quaternion rot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rot);
		SendRPCInternal("System.Void GasCollisionSpawner::SpawnParticleRpc(UnityEngine.Vector3,UnityEngine.Quaternion)", 1890314558, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_SpawnParticleCmd__Vector3__Quaternion(Vector3 pos, Quaternion rot)
	{
		SpawnParticleRpc(pos, rot);
	}

	protected static void InvokeUserCode_SpawnParticleCmd__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SpawnParticleCmd called on client.");
		}
		else
		{
			((GasCollisionSpawner)obj).UserCode_SpawnParticleCmd__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_SpawnParticleRpc__Vector3__Quaternion(Vector3 pos, Quaternion rot)
	{
		if (base.isServer)
		{
			NetworkServer.Spawn(Object.Instantiate(objectToSpawn, pos, rot));
		}
	}

	protected static void InvokeUserCode_SpawnParticleRpc__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpawnParticleRpc called on server.");
		}
		else
		{
			((GasCollisionSpawner)obj).UserCode_SpawnParticleRpc__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	static GasCollisionSpawner()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(GasCollisionSpawner), "System.Void GasCollisionSpawner::SpawnParticleCmd(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_SpawnParticleCmd__Vector3__Quaternion, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(GasCollisionSpawner), "System.Void GasCollisionSpawner::SpawnParticleRpc(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_SpawnParticleRpc__Vector3__Quaternion);
	}
}
