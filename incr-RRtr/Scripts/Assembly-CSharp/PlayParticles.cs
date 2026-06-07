using UnityEngine;

public class PlayParticles : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem particles;

	public void PlayParticleSystem()
	{
		if ((bool)particles)
		{
			particles.Play();
		}
	}
}
