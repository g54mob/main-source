using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
	public int particles;

	public ParticleSystem particleLauncher;

	public ParticleSystem splatterParticles;

	public Gradient particleColorGradient;

	public ParticleDecalPool splatDecalPool;

	private List<ParticleCollisionEvent> collisionEvents;

	private void Awake()
	{
	}

	private void OnParticleCollision(GameObject other)
	{
	}

	private void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
	{
	}

	private void Update()
	{
	}
}
