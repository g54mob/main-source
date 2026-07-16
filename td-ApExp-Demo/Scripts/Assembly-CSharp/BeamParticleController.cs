using System.Collections;
using UnityEngine;

public class BeamParticleController : MonoBehaviour
{
	protected Transform targetTf;

	protected ParticleSystem system;

	protected ParticleSystem.Particle[] particles;

	protected float noiseSeed;

	[SerializeField]
	protected float speed = 1f;

	[SerializeField]
	protected float noiseFactor;

	[SerializeField]
	protected bool destroyOnProximity = true;

	[SerializeField]
	protected float proximityCutoff = 0.1f;

	protected bool playing;

	protected int particleCount;

	protected void Start()
	{
		playing = false;
		if (system == null)
		{
			system = GetComponent<ParticleSystem>();
			particles = new ParticleSystem.Particle[system.main.maxParticles];
		}
		noiseSeed = Random.Range(0, 100000);
	}

	protected void FixedUpdate()
	{
		if (!(system == null) && Time.deltaTime > 0f)
		{
			bool isPlaying = system.isPlaying;
			if (isPlaying)
			{
				system.Pause();
			}
			UpdateParticles();
			if (isPlaying)
			{
				system.Play();
			}
		}
	}

	public virtual void UpdateParticles()
	{
		particleCount = system.GetParticles(particles);
		if (!targetTf)
		{
			StopBeam();
			KillAllParticles();
		}
		else if (destroyOnProximity)
		{
			DestroyParticlesInTargetProximity();
		}
	}

	public void MoveToTarget()
	{
		for (int i = 0; i < particleCount; i++)
		{
			particles[i].velocity = (targetTf.position - particles[i].position).normalized * speed;
		}
		system.SetParticles(particles, particleCount);
	}

	public void MoveToTargetWithNoise(float noiseFactor)
	{
		for (int i = 0; i < particleCount; i++)
		{
			particles[i].velocity = (targetTf.position - particles[i].position).normalized * speed + new Vector3(Mathf.PerlinNoise(Time.time, noiseSeed) * noiseFactor, Mathf.PerlinNoise(Time.time, noiseSeed) * noiseFactor, Mathf.PerlinNoise(Time.time, noiseSeed) * noiseFactor);
		}
		system.SetParticles(particles, particleCount);
	}

	public void KillAllParticles()
	{
		for (int i = 0; i < particleCount; i++)
		{
			particles[i].remainingLifetime = 0f;
		}
		system.SetParticles(particles, particleCount);
	}

	public void DestroyParticlesInTargetProximity()
	{
		for (int i = 0; i < particleCount; i++)
		{
			if (Vector3.Distance(particles[i].position, targetTf.position) < proximityCutoff)
			{
				particles[i].remainingLifetime = 0f;
			}
		}
		system.SetParticles(particles, particleCount);
	}

	public void SetTarget(Transform transform)
	{
		targetTf = transform;
	}

	public void OnSourceDied()
	{
		ParticleSystem.MainModule main = system.main;
		main.startSize = 0f;
		StartCoroutine(DelayedDestroy());
	}

	private IEnumerator DelayedDestroy()
	{
		yield return new WaitForSeconds(0.1f);
		Object.Destroy(base.gameObject);
	}

	public void StartBeam()
	{
		playing = true;
		if (system != null)
		{
			system.Play();
		}
	}

	public void StopBeam()
	{
		playing = false;
		if (system != null)
		{
			system.Stop();
		}
	}
}
