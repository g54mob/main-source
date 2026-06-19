using System.Collections.Generic;
using UnityEngine;

public class ParticlesSoundOnSpawn : MonoBehaviour
{
	public string soundOnSpawn;

	private List<ParticleSystem.Particle> triggerParticles = new List<ParticleSystem.Particle>();

	private ParticleSystem particleSystemRef;

	private void Awake()
	{
		particleSystemRef = GetComponent<ParticleSystem>();
	}

	private void OnParticleTrigger()
	{
		if (soundOnSpawn.Length != 0)
		{
			int num = particleSystemRef.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, triggerParticles);
			for (int i = 0; i < num; i++)
			{
				AudioController.Play(soundOnSpawn, particleSystemRef.transform.position);
			}
		}
	}
}
