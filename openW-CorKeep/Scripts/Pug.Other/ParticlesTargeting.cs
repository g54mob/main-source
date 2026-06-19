using UnityEngine;

public class ParticlesTargeting : MonoBehaviour
{
	public ParticleSystem p;

	public Transform Target;

	public float speedMultiplier = 1f;

	private ParticleSystem.Particle[] _particles;

	private void Start()
	{
		p = GetComponent<ParticleSystem>();
	}

	private void LateUpdate()
	{
		if (_particles == null || _particles.Length < p.particleCount)
		{
			_particles = new ParticleSystem.Particle[p.particleCount];
		}
		p.GetParticles(_particles);
		Vector3 vector = base.transform.InverseTransformPoint(Target.position);
		for (int i = 0; i < p.particleCount; i++)
		{
			float num = (_particles[i].startLifetime - _particles[i].remainingLifetime) * (10f * Vector3.Distance(vector, _particles[i].position) * speedMultiplier);
			_particles[i].velocity = (vector - _particles[i].position).normalized * num;
		}
		p.SetParticles(_particles, p.particleCount);
	}
}
