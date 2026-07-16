using UnityEngine;

public class ProjectileFireshooterFireball : Projectile
{
	private Vector3 spawnPos;

	public float speedMult;

	private Animator anim;

	private Vector3 targetVector;

	private float targetDst;

	private float targetAngle;

	private float timeToTarget;

	private float timer;

	[SerializeField]
	private AnimationCurve trajectory;

	private bool startedDestroying;

	public event Delegates.HealthChangeHandler OnExplosionHit;

	public event Delegates.HealthChangeHandler OnExplosionKill;

	private void Start()
	{
		anim = GetComponent<Animator>();
		spawnPos = base.transform.position;
		targetVector = targetUnit.transform.position - spawnPos;
		targetDst = targetVector.magnitude;
		targetAngle = Mathf.Atan2(targetVector.y, targetVector.x);
		timeToTarget = targetDst / CurveSum(trajectory) / speedMult;
		anim.SetFloat("Time To Target Mult", 1f / timeToTarget);
		base.transform.rotation = Quaternion.LookRotation(Vector3.forward, targetVector);
		LevelManager.Instance.DestinationReached += ClearProjectile;
	}

	private new void Update()
	{
		timer += Time.deltaTime;
		if (timer >= timeToTarget && !startedDestroying)
		{
			DestroyProjectile();
		}
	}

	private new void FixedUpdate()
	{
		if (!startedDestroying && timer < timeToTarget)
		{
			Move();
		}
	}

	protected override void RaycastCollide(float speed)
	{
	}

	protected override void Move()
	{
		float num = timer / timeToTarget;
		float z = (0f - Mathf.Cos(targetAngle)) * 2f * 57.29578f * ((num - 0.5f) / 2f);
		base.transform.position += Quaternion.Euler(0f, 0f, z) * targetVector.normalized * trajectory.Evaluate(num) * speedMult * Time.deltaTime;
		base.transform.localScale = Vector3.one * (2f - trajectory.Evaluate(num));
	}

	public override void DestroyProjectile()
	{
		DamageEnemy();
		Object.Destroy(base.gameObject);
	}

	private void ClearProjectile()
	{
		Object.Destroy(base.gameObject);
	}

	private void DamageEnemy()
	{
		HealthChangeInfo healthChangeInfo = new HealthChangeInfo(sourceUnit, targetUnit.HealthComponent, 0f - damage);
		if (burn > 0f)
		{
			targetUnit.HealthComponent.ApplyBurn(burn, this);
		}
		if (healthChangeInfo.IsLethal)
		{
			this.OnExplosionKill?.Invoke(healthChangeInfo);
		}
		targetUnit.HealthComponent.ChangeHealthWithInfo(healthChangeInfo);
		this.OnExplosionHit?.Invoke(healthChangeInfo);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		this.OnExplosionHit = null;
	}

	public static float CurveSum(AnimationCurve curve)
	{
		float num = 0f;
		for (int i = 0; (float)i < 100f; i++)
		{
			num += IntegralOnStep(0.01f * (float)i, curve.Evaluate(0.01f * (float)i), 0.01f * (float)(i + 1), curve.Evaluate(0.01f * (float)(i + 1)));
		}
		return num;
	}

	public static float IntegralOnStep(float x0, float y0, float x1, float y1)
	{
		float num = (y1 - y0) / (x1 - x0);
		float num2 = y0 - num * x0;
		return num / 2f * x1 * x1 + num2 * x1 - (num / 2f * x0 * x0 + num2 * x0);
	}
}
