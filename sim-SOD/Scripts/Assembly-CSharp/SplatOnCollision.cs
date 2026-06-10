using System.Collections.Generic;
using UnityEngine;

public class SplatOnCollision : MonoBehaviour
{
	public ParticleSystem particleLauncher;

	public Gradient particleColorGradient;

	public ParticleDecalPool dropletDecalPool;

	private List<ParticleCollisionEvent> collisionEvents;

	private void Start()
	{
	}

	private void OnParticleCollision(GameObject other)
	{
	}
}
