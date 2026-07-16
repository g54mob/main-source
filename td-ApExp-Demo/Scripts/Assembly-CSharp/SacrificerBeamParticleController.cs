using System.Collections;
using UnityEngine;

public class SacrificerBeamParticleController : MonoBehaviour
{
	private Transform targetTf;

	private ParticleSystem system;

	private ParticleSystem.Particle[] particles;

	private float noiseSeed;

	[SerializeField]
	private float speed = 1f;

	[SerializeField]
	private float noiseFactor;

	private void Start()
	{
		if (system == null)
		{
			system = GetComponent<ParticleSystem>();
			particles = new ParticleSystem.Particle[system.main.maxParticles];
		}
		noiseSeed = Random.Range(0, 100000);
	}

	private void FixedUpdate()
	{
		if (!(targetTf == null) && Time.deltaTime > 0f)
		{
			bool isPlaying = system.isPlaying;
			if (isPlaying)
			{
				system.Pause();
			}
			int num = system.GetParticles(particles);
			for (int i = 0; i < num; i++)
			{
				float x = Mathf.PerlinNoise(Time.time, noiseSeed) * noiseFactor;
				float y = Mathf.PerlinNoise(Time.time, noiseSeed) * noiseFactor;
				float z = Mathf.PerlinNoise(Time.time, noiseSeed) * noiseFactor;
				particles[i].velocity = (targetTf.position - particles[i].position).normalized * speed + new Vector3(x, y, z);
			}
			system.SetParticles(particles, num);
			if (isPlaying)
			{
				system.Play();
			}
		}
	}

	public void Play()
	{
		system.Play();
	}

	public void DestroyAfterDelay(float delay)
	{
		StartCoroutine(DADC(delay));
	}

	private IEnumerator DADC(float delay)
	{
		Stop();
		yield return new WaitForSeconds(delay);
		Object.Destroy(base.gameObject);
	}

	public void Stop()
	{
		system.Stop();
	}

	public void SetTarget(Transform transform)
	{
		targetTf = transform;
	}

	public void OnSourceDied()
	{
		int num = system.GetParticles(particles);
		for (int i = 0; i < num; i++)
		{
			particles[i].remainingLifetime = 0f;
		}
		system.SetParticles(particles, num);
		Object.Destroy(base.gameObject);
	}

	private IEnumerator DelayedDestroy()
	{
		yield return new WaitForSeconds(2f);
		Object.Destroy(base.gameObject);
	}
}
