using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class ParticleCollisionSpawner : NetworkBehaviour
{
	public GameObject objectToSpawn;

	private ParticleSystem particleSystem;

	public int spawnEveryXCollisions = 1;

	private int curSpawnEveryXCollisions;

	private void Start()
	{
		particleSystem = GetComponent<ParticleSystem>();
		if (spawnEveryXCollisions == 0)
		{
			spawnEveryXCollisions = 1;
		}
	}

	private void OnParticleCollision(GameObject other)
	{
		curSpawnEveryXCollisions++;
		if (curSpawnEveryXCollisions != spawnEveryXCollisions)
		{
			List<ParticleCollisionEvent> list = new List<ParticleCollisionEvent>();
			int collisionEvents = particleSystem.GetCollisionEvents(other, list);
			ParticleSystem.Particle[] array = new ParticleSystem.Particle[particleSystem.main.maxParticles];
			int particles = particleSystem.GetParticles(array);
			for (int i = 0; i < collisionEvents; i++)
			{
				Vector3 intersection = list[i].intersection;
				for (int j = 0; j < particles; j++)
				{
					if (Vector3.Distance(array[j].position, intersection) < 0.1f)
					{
						array[j].remainingLifetime = 0f;
						break;
					}
				}
			}
			particleSystem.SetParticles(array, particles);
			return;
		}
		curSpawnEveryXCollisions = 0;
		List<ParticleCollisionEvent> list2 = new List<ParticleCollisionEvent>();
		int collisionEvents2 = particleSystem.GetCollisionEvents(other, list2);
		ParticleSystem.Particle[] array2 = new ParticleSystem.Particle[particleSystem.main.maxParticles];
		int particles2 = particleSystem.GetParticles(array2);
		for (int k = 0; k < collisionEvents2; k++)
		{
			Vector3 intersection2 = list2[k].intersection;
			Quaternion rotation = Quaternion.LookRotation(list2[k].normal);
			if (ClientPlayer.Instance.playerMan.isServer)
			{
				NetworkServer.Spawn(Object.Instantiate(objectToSpawn, intersection2, rotation));
			}
			for (int l = 0; l < particles2; l++)
			{
				if (Vector3.Distance(array2[l].position, intersection2) < 0.1f)
				{
					array2[l].remainingLifetime = 0f;
					break;
				}
			}
		}
		particleSystem.SetParticles(array2, particles2);
	}

	public override bool Weaved()
	{
		return true;
	}
}
