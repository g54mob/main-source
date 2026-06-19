using UnityEngine;

public class EggSuckParticles : MonoBehaviour
{
	private float timeToSpawnNewInstance;

	private bool hasSpawnedNewInstance;

	private float currentSimTime;

	private ParticleSystem particleSystemRef;

	private void Awake()
	{
		particleSystemRef = GetComponent<ParticleSystem>();
		particleSystemRef.randomSeed = 1u;
		currentSimTime = particleSystemRef.main.duration;
		particleSystemRef.time = currentSimTime;
		timeToSpawnNewInstance = currentSimTime / 2f;
	}

	private void Update()
	{
		float num = currentSimTime;
		if (num <= 0f)
		{
			Object.Destroy(base.gameObject);
		}
		particleSystemRef.Clear();
		particleSystemRef.Simulate(num);
		particleSystemRef.time = num;
		particleSystemRef.Play();
		currentSimTime = num - Time.deltaTime;
		if (!hasSpawnedNewInstance && currentSimTime <= timeToSpawnNewInstance)
		{
			hasSpawnedNewInstance = true;
			Object.Instantiate(base.gameObject);
		}
	}
}
