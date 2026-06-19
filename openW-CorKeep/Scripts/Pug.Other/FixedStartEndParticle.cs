using Unity.Collections;
using UnityEngine;

public class FixedStartEndParticle : MonoBehaviour
{
	public Vector3 startLocalPos = Vector3.forward;

	public Vector3 endLocalPos = Vector3.zero;

	private ParticleSystem _particleSystem;

	private NativeArray<ParticleSystem.Particle> _particleCache;

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
		int particleCount = _particleSystem.particleCount;
		if (particleCount != 0)
		{
			_particleSystem.GetParticles(_particleCache);
			Vector3 lossyScale = base.transform.lossyScale;
			ParticleSystem.Particle value = _particleCache[0];
			value.velocity = Vector2.zero;
			value.position = new Vector3(startLocalPos.x * lossyScale.x, startLocalPos.y * lossyScale.y, startLocalPos.z * lossyScale.z);
			_particleCache[0] = value;
			ParticleSystem.Particle value2 = _particleCache[particleCount - 1];
			value2.velocity = Vector2.zero;
			value2.position = new Vector3(endLocalPos.x * lossyScale.x, endLocalPos.y * lossyScale.y, endLocalPos.z * lossyScale.z);
			_particleCache[particleCount - 1] = value2;
			_particleSystem.SetParticles(_particleCache, particleCount);
		}
	}
}
