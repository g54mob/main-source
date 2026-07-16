using UnityEngine;

public class TireTrailController : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem ps;

	[SerializeField]
	private float trailDensity;

	[SerializeField]
	private float trailSegmentLength = 2f;

	private ParticleSystem.EmissionModule emission;

	private ParticleSystem.MinMaxCurve zeroCurve;

	private void Start()
	{
		emission = ps.emission;
		zeroCurve = new ParticleSystem.MinMaxCurve(0f);
	}

	private void FixedUpdate()
	{
		if (Time.deltaTime > 0f)
		{
			OnParticleFixedUpdateJobScheduled();
		}
	}

	private void OnParticleFixedUpdateJobScheduled()
	{
		if (!ps)
		{
			return;
		}
		bool isPlaying = ps.isPlaying;
		if (isPlaying)
		{
			ps.Pause();
		}
		emission.rateOverTime = Train.Instance.SpeedCurrent * trailDensity;
		ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = ps.velocityOverLifetime;
		velocityOverLifetime.x = zeroCurve;
		velocityOverLifetime.y = new ParticleSystem.MinMaxCurve(0f - Train.Instance.SpeedCurrent);
		velocityOverLifetime.z = zeroCurve;
		ParticleSystem.Particle[] array = new ParticleSystem.Particle[ps.particleCount];
		int particles = ps.GetParticles(array);
		for (int i = 0; i < particles; i++)
		{
			if (array[i].position.x < -5f)
			{
				array[i].remainingLifetime = 0f;
			}
		}
		ps.SetParticles(array, particles);
		if (isPlaying)
		{
			ps.Play();
		}
	}

	public void Detach()
	{
		Vector3 position = base.transform.position;
		base.transform.SetParent(EnemyManager.Instance.trailsContainer, worldPositionStays: true);
		base.transform.position = position;
		base.transform.localScale = new Vector3(trailSegmentLength, 1f, 1f);
		emission.enabled = false;
		Object.Destroy(base.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
	}
}
