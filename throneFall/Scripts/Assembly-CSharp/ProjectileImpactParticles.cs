using UnityEngine;

public class ProjectileImpactParticles : MonoBehaviour
{
	public AimbotProjectile target;

	public ParticleSystem particles;

	private void Start()
	{
		if (target != null)
		{
			target.onHit.AddListener(Play);
		}
	}

	private void Play()
	{
		particles.gameObject.transform.parent = null;
		particles.Play();
	}
}
