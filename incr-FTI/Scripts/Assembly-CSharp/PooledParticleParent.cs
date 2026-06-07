using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PooledParticleParent : MonoBehaviour
{
	private List<ParticleSystem> particles = new List<ParticleSystem>();

	private IObjectPool<PooledParticleParent> pool;

	private float start;

	public void Awake()
	{
		ParticleSystem[] componentsInChildren = GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem item in componentsInChildren)
		{
			particles.Add(item);
		}
	}

	public void InitFromPool(IObjectPool<PooledParticleParent> parentPool)
	{
		pool = parentPool;
		foreach (ParticleSystem particle in particles)
		{
			PooledParticle pooledParticle = particle.gameObject.AddComponent<PooledParticle>();
			pooledParticle.particles = particle;
			pooledParticle.InitFromParent(this);
		}
	}

	public void Play(Vector3 position)
	{
		base.transform.position = position;
		base.gameObject.SetActive(value: true);
		start = Time.realtimeSinceStartup;
		foreach (ParticleSystem particle in particles)
		{
			particle.Play();
		}
	}

	public void OnChildStopped(PooledParticle child)
	{
		pool.Release(this);
	}
}
