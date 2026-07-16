using UnityEngine;

public class Autocannon : MonoBehaviour
{
	public bool isN;

	public bool isArmed;

	public ModuleAutocannon module;

	private Transform muzzle;

	private Animator anim;

	private Transform cannon;

	private AudioSource audioSource;

	private EnemyBase currentTarget;

	private float shotTimer;

	private float zDifference;

	private float zDifferenceMax = 5f;

	public SpriteRenderer LoaderSr { get; private set; }

	public Transform Mask { get; private set; }

	public event Delegates.HealthChangeHandler OnHit;

	public event Delegates.HealthChangeHandler OnKill;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		Mask = base.transform.Find("Loader/Mask");
		cannon = base.transform.Find("Pivot/Cannon");
		muzzle = cannon.Find("Muzzle");
		anim = cannon.GetComponent<Animator>();
		LoaderSr = base.transform.Find("Loader").GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		module.frenzyDuration -= Time.deltaTime;
		if (!LevelManager.Instance.IsPlaying || module.IsFullyBroken || module.IsEMPattached || module.GetUpgradedStatValueByStatType(StatTypes.consumption) > ResourceManager.Instance.AvailableAmmo)
		{
			Offline();
			return;
		}
		FindTarget();
		if (currentTarget == null)
		{
			anim.Play("Idle");
			return;
		}
		Aim();
		shotTimer -= Time.deltaTime;
		if (shotTimer > 0f)
		{
			if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
			{
				anim.Play("Idle");
			}
		}
		else
		{
			Fire();
		}
	}

	private bool IsTargetValid(EnemyBase target)
	{
		if (!target.IsEnemy)
		{
			return false;
		}
		if (target.IsDead)
		{
			return false;
		}
		if (target.IsEnemyGadget || target.IsHacked)
		{
			return false;
		}
		if (target.ignoreProjectiles)
		{
			return false;
		}
		if (target.HealthComponent.IsImmune)
		{
			return false;
		}
		if (target.HealthComponent.HealthMax == 0f)
		{
			return false;
		}
		if (target.HealthComponent.DamageReductionPercent > 99f)
		{
			return false;
		}
		if (target.HealthComponent.IsImmune)
		{
			return false;
		}
		if (!target.IsBoss && (target.transform.position.x < -4.5f || target.transform.position.x > 2.75f))
		{
			return false;
		}
		if (isN)
		{
			if (target.transform.position.y < 0f || target.transform.position.y > 3f)
			{
				return false;
			}
		}
		else if (target.transform.position.y > 0f || target.transform.position.y < -3f)
		{
			return false;
		}
		return true;
	}

	private void FindTarget()
	{
		if (EnemyManager.Instance.Enemies.Count == 0)
		{
			return;
		}
		if (module.findHighestHpTarget)
		{
			if (!(currentTarget != null) || !currentTarget.IsEnemy)
			{
				FindHighestHpTarget();
			}
		}
		else if (module.findLowestHpTarget)
		{
			if (!(currentTarget != null) || !currentTarget.IsEnemy)
			{
				FindLowestHpTarget();
			}
		}
		else
		{
			if (currentTarget != null && IsTargetValid(currentTarget))
			{
				return;
			}
			float num = float.MaxValue;
			EnemyBase enemyBase = null;
			foreach (EnemyBase enemy in EnemyManager.Instance.Enemies)
			{
				if (IsTargetValid(enemy))
				{
					float sqrMagnitude = (enemy.transform.position - base.transform.position).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						enemyBase = enemy;
					}
				}
			}
			currentTarget = enemyBase;
		}
	}

	private void FindHighestHpTarget()
	{
		EnemyBase target = EnemyManager.Instance.Enemies[0];
		float num = 0f;
		for (int i = 0; i < EnemyManager.Instance.Enemies.Count; i++)
		{
			if ((bool)EnemyManager.Instance.Enemies[i] && (bool)EnemyManager.Instance.Enemies[i].HealthComponent)
			{
				float healthCurrent = EnemyManager.Instance.Enemies[i].HealthComponent.HealthCurrent;
				if (healthCurrent > num && IsTargetValid(EnemyManager.Instance.Enemies[i]))
				{
					num = healthCurrent;
					target = EnemyManager.Instance.Enemies[i];
				}
			}
		}
		if (IsTargetValid(target))
		{
			currentTarget = target;
		}
	}

	private void FindLowestHpTarget()
	{
		EnemyBase target = EnemyManager.Instance.Enemies[0];
		float num = 999f;
		for (int i = 0; i < EnemyManager.Instance.Enemies.Count; i++)
		{
			if (EnemyManager.Instance.Enemies[i].GetComponent<APCMissile>() == null)
			{
				float healthCurrent = EnemyManager.Instance.Enemies[i].HealthComponent.HealthCurrent;
				if (healthCurrent < num && IsTargetValid(EnemyManager.Instance.Enemies[i]))
				{
					num = healthCurrent;
					target = EnemyManager.Instance.Enemies[i];
				}
			}
		}
		if (IsTargetValid(target))
		{
			currentTarget = target;
		}
	}

	private void Aim()
	{
		Vector3 normalized = (currentTarget.transform.position - cannon.transform.position).normalized;
		Quaternion to = Quaternion.LookRotation(Vector3.forward, normalized);
		cannon.rotation = Quaternion.RotateTowards(cannon.rotation, to, module.GetUpgradedStatValueByStatType(StatTypes.transformSpeed) * Time.deltaTime);
		float current = (cannon.rotation.eulerAngles.z + 360f) % 360f;
		float target = (to.eulerAngles.z + 360f) % 360f;
		zDifference = Mathf.Abs(Mathf.DeltaAngle(current, target));
	}

	private void Fire()
	{
		if (!(zDifference > zDifferenceMax * 0.5f))
		{
			ResourceManager.Instance.Ammo.TrySpend(module.GetUpgradedStatValueByStatType(StatTypes.consumption));
			DataTrackingManager.Instance.AddAmmoUsed((int)module.GetUpgradedStatValueByStatType(StatTypes.consumption));
			if (module.frenzyDuration > 0f)
			{
				shotTimer = module.GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary) * (1f - module.frenzyAttackSpeedGain / 100f);
			}
			else
			{
				shotTimer = module.GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary);
			}
			float upgradedStatValueByStatType = module.GetUpgradedStatValueByStatType(StatTypes.count);
			float upgradedStatValueByStatType2 = module.GetUpgradedStatValueByStatType(StatTypes.spread);
			float num = (0f - upgradedStatValueByStatType2) / 2f;
			float num2 = upgradedStatValueByStatType2 / upgradedStatValueByStatType;
			for (int i = 0; (float)i < upgradedStatValueByStatType; i++)
			{
				float angle = num + num2 * (float)i;
				SpawnProjectile(angle);
			}
		}
	}

	private void SpawnProjectile(float angle)
	{
		Quaternion rotation = Quaternion.Euler(0f, 0f, angle) * cannon.rotation;
		Projectile component = Object.Instantiate(module.projectile, muzzle.position, rotation).GetComponent<Projectile>();
		component.damage = module.GetUpgradedStatValueByStatType(StatTypes.damage);
		component.sourceUnit = module;
		component.speed = module.GetUpgradedStatValueByStatType(StatTypes.projectileSpeed);
		component.screenWarpCounter = Train.Instance.projectileScreenWarpCounter;
		component.ProjectileHit += HandleHit;
		component.hitsRemaining = 1 + Mathf.CeilToInt(module.GetUpgradedStatValueByStatType(StatTypes.pierce));
		anim.Play("Shoot");
		module.PlayShotSound();
	}

	private void HandleHit(HealthChangeInfo info)
	{
		this.OnHit?.Invoke(info);
		if (info.IsLethal)
		{
			this.OnKill?.Invoke(info);
		}
	}

	private void Offline()
	{
		if (!(Train.Instance.HealthComponent.HealthCurrent <= 0f))
		{
			anim.Play("Idle");
			Quaternion to = Quaternion.LookRotation(Vector3.forward, Vector3.right);
			cannon.rotation = Quaternion.RotateTowards(cannon.rotation, to, module.GetUpgradedStatValueByStatType(StatTypes.transformSpeed) * Time.deltaTime);
		}
	}

	public void LoaderActive(bool active)
	{
		LoaderSr.enabled = active;
		base.transform.Find("Loader/Mask").GetComponent<SpriteRenderer>().enabled = active;
	}
}
