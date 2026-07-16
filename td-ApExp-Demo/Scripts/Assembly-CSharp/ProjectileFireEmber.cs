using AudioSystem;
using UnityEngine;

public class ProjectileFireEmber : Projectile
{
	[SerializeField]
	private SoundData emberFlyingSfx;

	[HideInInspector]
	public ModuleFurnace furnace;

	private Vector3 spawnPos;

	[HideInInspector]
	public Vector3 targetPos;

	public float speedMult;

	[SerializeField]
	public float radius;

	private Animator anim;

	private Vector3 targetVector;

	private float targetDst;

	private float targetAngle;

	private float timeToTarget;

	private float timer;

	[SerializeField]
	private AnimationCurve trajectory;

	public event Delegates.HealthChangeHandler OnExplosionHit;

	public event Delegates.HealthChangeHandler OnExplosionKill;

	private void Start()
	{
		anim = GetComponent<Animator>();
		spawnPos = base.transform.position;
		targetVector = targetPos - spawnPos;
		targetDst = targetVector.magnitude;
		targetAngle = Mathf.Atan2(targetVector.y, targetVector.x);
		timeToTarget = targetDst / CurveSum(trajectory) / speedMult;
		anim.SetFloat("Time To Target Mult", 1f / timeToTarget);
		base.transform.rotation = Quaternion.LookRotation(Vector3.forward, targetVector);
		soundBuilder.Play(emberFlyingSfx);
	}

	private new void Update()
	{
		timer += Time.deltaTime;
		if (timer >= timeToTarget)
		{
			DestroyProjectile();
		}
	}

	private new void FixedUpdate()
	{
		if (timer < timeToTarget)
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
		DamageEnemiesWithinRadius();
		soundBuilder.Play(enemyHitSound1);
		Object.Destroy(base.gameObject);
	}

	private void DamageEnemiesWithinRadius()
	{
		Collider2D[] array = Physics2D.OverlapCircleAll(base.transform.position, radius, LayerMask.GetMask("Unit", "Mine", "Enemy"));
		if (array == null || array.Length == 0)
		{
			return;
		}
		Collider2D[] array2 = array;
		foreach (Collider2D collider2D in array2)
		{
			float distance = Vector3.Distance(base.transform.position, collider2D.transform.position);
			Unit component = collider2D.GetComponent<Unit>();
			if (((object)component == null || component.IsEnemy) && collider2D.TryGetComponent<Health>(out var component2) && (bool)component2 && !component2.IsDead && !component2.gameObject.GetComponent<Unit>().ignoreProjectiles && !component2.gameObject.GetComponent<E3_5_StealthBomber>())
			{
				Vector2 direction = (collider2D.transform.position - base.transform.position).normalized;
				RaycastHit2D value = Physics2D.Raycast(base.transform.position, direction, distance, LayerMask.GetMask("Unit", "Mine", "Enemy"));
				HealthChangeInfo healthChangeInfo = new HealthChangeInfo(sourceUnit, component2, 0f - damage, isPercent: false, value, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE);
				if (healthChangeInfo.IsLethal)
				{
					this.OnExplosionKill?.Invoke(healthChangeInfo);
				}
				component2.ChangeHealthWithInfo(healthChangeInfo);
				this.OnExplosionHit?.Invoke(healthChangeInfo);
				component2.ApplyBurn(burn, this);
			}
		}
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
