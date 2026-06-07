using UnityEngine;

public class SplashParticleTrigger : MonoBehaviour
{
	public ParticleSystem splashParticle;

	public void TriggerSplash()
	{
		splashParticle.Play();
	}
}
