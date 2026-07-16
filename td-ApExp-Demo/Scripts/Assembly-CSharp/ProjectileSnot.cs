using System;
using System.Collections;
using UnityEngine;

public class ProjectileSnot : Projectile
{
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

	[SerializeField]
	private float snotDuration;

	[SerializeField]
	[Range(0f, 1f)]
	private float effectStrenghtEnemy;

	[SerializeField]
	[Range(0f, 1f)]
	private float effectStrenghtFurnace;

	[NonSerialized]
	public Unit TargetModule;

	[SerializeField]
	private GameObject SnotPrefab;

	private bool startedDestroying;

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

	private IEnumerator SplashSnot()
	{
		anim.Play("SnotExplode");
		yield return new WaitForSeconds(0.3f);
		if (TargetModule != null)
		{
			SnotModules();
		}
		else
		{
			DamageEnemiesWithinRadius();
		}
		LevelManager.Instance.DestinationReached -= ClearProjectile;
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public override void DestroyProjectile()
	{
		StartCoroutine(SplashSnot());
	}

	private void ClearProjectile()
	{
		UnityEngine.Object.Destroy(base.gameObject);
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
				if (burn > 0f)
				{
					component2.ApplyBurn(burn, this);
				}
				if (healthChangeInfo.IsLethal)
				{
					this.OnExplosionKill?.Invoke(healthChangeInfo);
				}
				component2.ChangeHealthWithInfo(healthChangeInfo);
				this.OnExplosionHit?.Invoke(healthChangeInfo);
				collider2D.GetComponent<Unit>().SnotUnit(snotDuration, effectStrenghtEnemy);
				collider2D.GetComponent<EnemyBase>().Snot = UnityEngine.Object.Instantiate(SnotPrefab, collider2D.transform.position, Quaternion.identity);
				collider2D.GetComponent<EnemyBase>().Snot.transform.parent = collider2D.transform;
			}
		}
	}

	private void SnotModules()
	{
		if (!(Vector3.Distance(base.transform.position, TargetModule.transform.position) <= 0.1f))
		{
			return;
		}
		HealthChangeInfo healthChangeInfo = new HealthChangeInfo(sourceUnit, TargetModule.HealthComponent, 0f - damage, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE);
		if (healthChangeInfo.IsLethal)
		{
			this.OnExplosionKill?.Invoke(healthChangeInfo);
		}
		TargetModule.HealthComponent.ChangeHealthWithInfo(healthChangeInfo);
		this.OnExplosionHit?.Invoke(healthChangeInfo);
		TargetModule.SnotUnit(snotDuration, effectStrenghtFurnace);
		TargetModule.gameObject.GetComponent<Module>().Snot = UnityEngine.Object.Instantiate(SnotPrefab, TargetModule.transform.position, Quaternion.identity);
		TargetModule.gameObject.GetComponent<Module>().Snot.transform.parent = TargetModule.transform;
		if (burn > 0f)
		{
			TargetModule.HealthComponent.ApplyBurn(burn, this);
		}
		Module[] array = Train.Instance.FindAdjacentModulesWithoutEmptySlots(TargetModule);
		if (array[0] != null)
		{
			array[0].SnotUnit(snotDuration, effectStrenghtFurnace);
			array[0].Snot = UnityEngine.Object.Instantiate(SnotPrefab, array[0].transform.position, Quaternion.identity);
			array[0].Snot.transform.parent = array[0].transform;
			if (burn > 0f)
			{
				array[0].HealthComponent.ApplyBurn(burn, this);
			}
		}
		if (array[1] != null)
		{
			array[1].SnotUnit(snotDuration, effectStrenghtFurnace);
			array[1].Snot = UnityEngine.Object.Instantiate(SnotPrefab, array[1].transform.position, Quaternion.identity);
			array[1].Snot.transform.parent = array[1].transform;
			if (burn > 0f)
			{
				array[1].HealthComponent.ApplyBurn(burn, this);
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
