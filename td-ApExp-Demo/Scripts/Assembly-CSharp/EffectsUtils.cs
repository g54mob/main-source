using System.Collections.Generic;
using UnityEngine;

public static class EffectsUtils
{
	public static void PlayMultipleParticles(List<ParticleSystem> particles, bool play, bool clearOnStop = false)
	{
		if (particles == null || particles.Count == 0)
		{
			return;
		}
		if (play)
		{
			foreach (ParticleSystem particle in particles)
			{
				particle.Play();
			}
			return;
		}
		foreach (ParticleSystem particle2 in particles)
		{
			particle2.Stop();
			if (clearOnStop)
			{
				particle2.Clear();
			}
		}
	}
}
