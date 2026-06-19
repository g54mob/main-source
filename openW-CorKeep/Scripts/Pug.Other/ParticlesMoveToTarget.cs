using Unity.Collections;
using UnityEngine;

public class ParticlesMoveToTarget : MonoBehaviour
{
	public Vector3 targetWorldPosition;

	public float startDespawnDistance;

	public float despawnLifetimeToSet;

	public float speed;

	public float speedScaledByLifetime;

	private ParticleSystem _particleSystem;

	private NativeArray<ParticleSystem.Particle> _particleCache;

	private int _cachedParticles;

	private void Awake()
	{
		_particleSystem = GetComponent<ParticleSystem>();
		_particleCache = new NativeArray<ParticleSystem.Particle>(_particleSystem.maxParticles, Allocator.Persistent);
	}

	private void OnDestroy()
	{
		_particleCache.Dispose();
	}

	private void LateUpdate()
	{
		if (targetWorldPosition == Vector3.zero)
		{
			return;
		}
		Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(targetWorldPosition);
		if (_particleSystem.main.simulationSpace == ParticleSystemSimulationSpace.Custom)
		{
			vector = _particleSystem.main.customSimulationSpace.InverseTransformPoint(vector);
		}
		int particleCount = _particleSystem.particleCount;
		particleCount = _particleSystem.GetParticles(_particleCache);
		for (int i = 0; i < particleCount; i++)
		{
			Vector3 vector2 = vector - _particleCache[i].position;
			float magnitude = vector2.magnitude;
			ParticleSystem.Particle value = _particleCache[i];
			if (magnitude < startDespawnDistance && value.remainingLifetime > despawnLifetimeToSet)
			{
				value.remainingLifetime = despawnLifetimeToSet;
			}
			vector2.Normalize();
			float num = speedScaledByLifetime * (1f - value.remainingLifetime / value.startLifetime);
			value.velocity = vector2 * (speed + num);
			_particleCache[i] = value;
		}
		_particleSystem.SetParticles(_particleCache, particleCount);
	}
}
