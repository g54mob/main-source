using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
	public ParticleSystem Particle;

	public void PlayParticleEffect()
	{
		if (Particle != null)
		{
			Particle.Play();
		}
	}
}
