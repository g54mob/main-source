using System;
using UnityEngine;

public class BurnAOE : MonoBehaviour
{
	[NonSerialized]
	public float radius;

	private float emissionRateMult = 100f;

	private float timeBetweenBurns = 1f;

	private float burnTimer;

	[NonSerialized]
	public float duration = 10f;

	private float timer;

	private ParticleSystem ps;

	private ParticleSystem.ShapeModule psShape;

	private ParticleSystem.EmissionModule psEmission;

	[NonSerialized]
	public Unit sourceUnit;

	private bool disabled;

	private void Awake()
	{
		ps = GetComponent<ParticleSystem>();
		psShape = ps.shape;
		psEmission = ps.emission;
	}

	private void Start()
	{
		psShape.radius = radius * 0.75f;
		psEmission.rateOverTime = radius * emissionRateMult;
		timer = duration;
		LevelManager.Instance.LevelCompleted += delegate
		{
			timer = -5f;
		};
	}

	private void Update()
	{
		timer -= Time.deltaTime;
		if (disabled)
		{
			if (timer < 0f)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			return;
		}
		if (timer < 0f)
		{
			ps.Stop();
			timer = 3f;
			disabled = true;
		}
		burnTimer -= Time.deltaTime;
		if (burnTimer > 0f)
		{
			return;
		}
		foreach (EnemyBase enemy in EnemyManager.Instance.Enemies)
		{
			if ((enemy.transform.position - base.transform.position).magnitude < radius)
			{
				enemy.HealthComponent.ApplyBurn(1f, sourceUnit);
			}
		}
		burnTimer = timeBetweenBurns;
	}
}
