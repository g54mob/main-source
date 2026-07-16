using UnityEngine;

public class DeadSmokeController : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem ps;

	[SerializeField]
	private float speedMultiplier = 2f;

	[SerializeField]
	private float sizeMax = 1f;

	[SerializeField]
	private float smokeSpread = 0.5f;

	[SerializeField]
	[Range(0f, 1f)]
	private float baseOpacity = 1f;

	[SerializeField]
	private AnimationCurve opacityCurve;

	private ParticleSystem.MainModule mainModule;

	private ParticleSystem.EmissionModule emission;

	private void Start()
	{
		mainModule = ps.main;
		emission = ps.emission;
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
		emission.rateOverTime = Train.Instance.SpeedCurrent * 30f;
		ParticleSystem.SizeOverLifetimeModule sizeOverLifetime = ps.sizeOverLifetime;
		sizeOverLifetime.size = new ParticleSystem.MinMaxCurve(0f, sizeMax * Train.Instance.TrainSpeedNormalized);
		float time = Mathf.Clamp01(Train.Instance.SpeedCurrent / Train.Instance.SpeedMax);
		float num = opacityCurve.Evaluate(time);
		float a = baseOpacity * num;
		Color color = mainModule.startColor.color;
		ParticleSystem.Particle[] array = new ParticleSystem.Particle[ps.particleCount];
		int particles = ps.GetParticles(array);
		for (int i = 0; i < particles; i++)
		{
			if (array[i].remainingLifetime > array[i].startLifetime - 0.1f)
			{
				array[i].velocity = new Vector3((0f - Train.Instance.TrainSpeedNormalized) * speedMultiplier, Train.Instance.TrainSpeedNormalized * Random.Range(0f - smokeSpread, smokeSpread), 0f);
			}
			array[i].startColor = new Color(color.r, color.g, color.b, a);
		}
		ps.SetParticles(array, particles);
		if (isPlaying)
		{
			ps.Play();
		}
	}

	private void UpdateParticleSystem(ParticleSystem s)
	{
	}

	public void Detach()
	{
		base.transform.SetParent(EnemyManager.Instance.trailsContainer, worldPositionStays: true);
		base.transform.localScale = Vector3.one;
		emission.enabled = false;
		Object.Destroy(base.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
	}
}
