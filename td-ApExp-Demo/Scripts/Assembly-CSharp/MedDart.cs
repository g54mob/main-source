using System;
using UnityEngine;

public class MedDart : Projectile
{
	private float randomDirectionNormalized;

	[NonSerialized]
	public float radius;

	private float timeToWaitForTarget;

	private float waitForTargetTimer;

	public bool CanWaitForTarget { get; set; }

	public float TimeToWaitForTarget
	{
		get
		{
			return timeToWaitForTarget;
		}
		set
		{
			timeToWaitForTarget = (waitForTargetTimer = value);
		}
	}

	public event Delegates.HealthChangeHandler ExplosionKill;

	private new void Awake()
	{
		base.Awake();
		randomDirectionNormalized = ((UnityEngine.Random.Range(0, 2) != 0) ? 1 : (-1));
		audioSource.Play();
	}

	private new void Update()
	{
		if (CanWaitForTarget && targetUnit == null && waitForTargetTimer > 0f)
		{
			waitForTargetTimer -= Time.deltaTime;
		}
		else
		{
			lifetimeTimer -= Time.deltaTime;
		}
		if (lifetimeTimer < 0f)
		{
			DestroyProjectile();
		}
		if (targetUnit == null)
		{
			FindTrackingTarget();
		}
	}

	protected override void Move()
	{
		float num = 1f;
		if (isEnemyProjectile)
		{
			num = EnemyManager.Instance.EnemyMissileSpeedMult;
		}
		Vector3 zero = Vector3.zero;
		zero = ((!isEnemyProjectile) ? (base.transform.up * speed * Time.deltaTime) : (base.transform.up * speed * num * Time.deltaTime));
		base.transform.Translate(zero, Space.World);
		float num2 = 1f;
		Vector3 upwards;
		if ((bool)targetUnit)
		{
			upwards = targetUnit.transform.position - base.transform.position;
		}
		else
		{
			if (CanWaitForTarget)
			{
				num2 = 10f;
			}
			upwards = base.transform.up;
		}
		Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, trackingSpeed * Time.deltaTime);
		float angle = Mathf.Sin(Time.time) * randomDirectionNormalized * num2;
		base.transform.Rotate(Vector3.forward, angle);
	}

	protected override void UnitHit(Unit hitUnit, RaycastHit2D hit)
	{
		OnProjectileHeal(null);
		DestroyProjectile();
	}

	public override void DestroyProjectile()
	{
		base.DestroyProjectile();
	}

	private void OnExplosionKill(HealthChangeInfo info)
	{
		this.ExplosionKill?.Invoke(info);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		this.ExplosionKill = null;
	}
}
