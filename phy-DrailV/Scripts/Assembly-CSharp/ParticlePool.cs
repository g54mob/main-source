using System;
using System.Collections;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

public class ParticlePool : SingletonBehaviour<ParticlePool>
{
	[Serializable]
	public class PooledParticle
	{
		public string name;

		public GameObject prefab;

		public float lifetime;

		public int expectedCapacity;
	}

	[SerializeField]
	private List<PooledParticle> particles;

	private Dictionary<string, Queue<GameObject>> pools;

	private Dictionary<string, PooledParticle> particleDictionary;

	public new static string AllowAutoCreate()
	{
		return null;
	}

	protected override void Awake()
	{
		base.Awake();
		pools = new Dictionary<string, Queue<GameObject>>();
		particleDictionary = new Dictionary<string, PooledParticle>();
		foreach (PooledParticle particle in particles)
		{
			Queue<GameObject> queue = new Queue<GameObject>(particle.expectedCapacity);
			for (int i = 0; i < particle.expectedCapacity; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(particle.prefab, base.transform, worldPositionStays: true);
				gameObject.SetActive(value: false);
				queue.Enqueue(gameObject);
			}
			pools.Add(particle.name, queue);
			particleDictionary.Add(particle.name, particle);
		}
	}

	private IEnumerator PutParticleBack(GameObject particle, string name)
	{
		yield return WaitFor.Seconds(particleDictionary[name].lifetime);
		particle.SetActive(value: false);
		pools[name].Enqueue(particle);
	}

	public GameObject GetParticle(string name)
	{
		Queue<GameObject> queue = pools[name];
		GameObject gameObject = ((queue.Count == 0) ? UnityEngine.Object.Instantiate(particleDictionary[name].prefab, base.transform, worldPositionStays: true) : queue.Dequeue());
		StartCoroutine(PutParticleBack(gameObject, name));
		gameObject.SetActive(value: true);
		return gameObject;
	}

	public GameObject SpawnParticleOnWater(string name, Vector3 position)
	{
		GameObject particle = GetParticle(name);
		position.y = ((SingletonBehaviour<LevelInfo>.Instance != null) ? SingletonBehaviour<LevelInfo>.Instance.waterLevel : position.y);
		particle.transform.position = position;
		return particle;
	}

	public GameObject SpawnParticleAt(string name, Vector3 position)
	{
		GameObject particle = GetParticle(name);
		particle.transform.position = position;
		return particle;
	}
}
