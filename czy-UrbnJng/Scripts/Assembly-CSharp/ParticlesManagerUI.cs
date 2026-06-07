using System;
using System.Collections;
using System.Collections.Generic;
using Coffee.UIExtensions;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using NewGameplayScripts;
using UnityEngine;

public class ParticlesManagerUI : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem greenParticleSystemTemplate;

	[SerializeField]
	private ParticleSystem redParticleSystemTemplate;

	[SerializeField]
	private UIParticleAttractor scoreAttractor;

	[SerializeField]
	private UIParticleAttractor plantAttractor;

	private Dictionary<Plant, int> particlesAtPlant = new Dictionary<Plant, int>();

	private Dictionary<Plant, int> particlesAtTarget = new Dictionary<Plant, int>();

	private List<UIParticleAttractor> attractors = new List<UIParticleAttractor>();

	public static ParticlesManagerUI Instance { get; private set; }

	public event EventHandler OnParticleHitTarget;

	public event EventHandler OnParticlesSpawnAtTarget;

	public event EventHandler OnParticlesSpawned;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		MovementSystem.Instance.OnStopMovingPlant += MovementSystem_OnStopMovingPlant;
		MovementSystem.Instance.OnStopMovingLamp_Humidifier += MovementSystem_OnStopMovingLamp_Humidifier;
	}

	private void OnDestroy()
	{
		MovementSystem.Instance.OnStopMovingPlant -= MovementSystem_OnStopMovingPlant;
		MovementSystem.Instance.OnStopMovingLamp_Humidifier -= MovementSystem_OnStopMovingLamp_Humidifier;
	}

	private void MovementSystem_OnStopMovingLamp_Humidifier(object sender, EventArgs e)
	{
		SpawnParticles();
	}

	private void MovementSystem_OnStopMovingPlant(object sender, EventArgs e)
	{
		SpawnParticles();
	}

	private void SpawnParticles()
	{
		if (!AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
		{
			particlesAtPlant.Clear();
			particlesAtTarget.Clear();
			attractors.Clear();
			StartCoroutine(SpawnParticlesWithDelays());
		}
	}

	public void SpawnParticlesAtPlant(Plant plant, int particlesAmount)
	{
		particlesAtPlant.Add(plant, particlesAmount);
	}

	public void SpawnParticlesAtTarget(Plant plant, int particlesAmount)
	{
		particlesAtTarget.Add(plant, particlesAmount);
	}

	private IEnumerator SpawnParticlesWithDelays()
	{
		yield return new WaitForSeconds(0.01f);
		if (particlesAtTarget.Count > 0 || particlesAtPlant.Count > 0)
		{
			this.OnParticlesSpawned?.Invoke(this, EventArgs.Empty);
		}
		if (particlesAtTarget.Count > 0)
		{
			SpawnAttractors();
			SpawnParticleSystemsAtTarget();
			yield return new WaitForSeconds(1f);
		}
		if (particlesAtPlant.Count > 0)
		{
			SpawnParticleSystemsAtPlants();
		}
	}

	private void SpawnAttractors()
	{
		foreach (Plant key in particlesAtTarget.Keys)
		{
			if (key != null)
			{
				UIParticleAttractor uIParticleAttractor = UnityEngine.Object.Instantiate(plantAttractor, plantAttractor.transform.parent);
				Vector2 vector = Camera.main.WorldToScreenPoint(key.transform.position);
				uIParticleAttractor.transform.position = new Vector2(vector.x, vector.y + 10f);
				attractors.Add(uIParticleAttractor);
			}
		}
	}

	private void SpawnParticleSystemsAtPlants()
	{
		foreach (Plant key in particlesAtPlant.Keys)
		{
			if (key != null && particlesAtPlant.TryGetValue(key, out var value))
			{
				ParticleSystem particleSystem = UnityEngine.Object.Instantiate(greenParticleSystemTemplate, greenParticleSystemTemplate.transform.parent);
				particleSystem.transform.position = Camera.main.WorldToScreenPoint(key.transform.position);
				scoreAttractor.AddParticleSystem(particleSystem);
				StartCoroutine(EmitParticlesOneByOne(particleSystem, value, scoreAttractor, null));
			}
		}
	}

	private void SpawnParticleSystemsAtTarget()
	{
		int num = 0;
		foreach (Plant key in particlesAtTarget.Keys)
		{
			if (key != null && particlesAtTarget.TryGetValue(key, out var value))
			{
				ParticleSystem particleSystem = UnityEngine.Object.Instantiate(redParticleSystemTemplate, redParticleSystemTemplate.transform.parent);
				particleSystem.transform.position = scoreAttractor.transform.position;
				attractors[num].AddParticleSystem(particleSystem);
				StartCoroutine(EmitParticlesOneByOne(particleSystem, value, scoreAttractor, attractors[num]));
				num++;
			}
		}
		this.OnParticlesSpawnAtTarget?.Invoke(this, EventArgs.Empty);
	}

	private IEnumerator EmitParticlesOneByOne(ParticleSystem particleSystem, int count, UIParticleAttractor attractor, UIParticleAttractor spawnedAttractor)
	{
		float delay = 0.05f;
		if (count > 20)
		{
			delay = 0.03f;
		}
		if (count > 40)
		{
			delay = 0.015f;
		}
		for (int i = 0; i < count; i++)
		{
			if (particleSystem != null)
			{
				particleSystem.Emit(1);
			}
			yield return new WaitForSeconds(delay);
		}
		yield return new WaitForSeconds(3f);
		attractor.RemoveParticleSystem(particleSystem);
		UnityEngine.Object.Destroy(particleSystem.gameObject);
		if (spawnedAttractor != null)
		{
			UnityEngine.Object.Destroy(spawnedAttractor.gameObject);
		}
	}

	public void OnParticlesHitTarget()
	{
		this.OnParticleHitTarget?.Invoke(this, EventArgs.Empty);
	}
}
