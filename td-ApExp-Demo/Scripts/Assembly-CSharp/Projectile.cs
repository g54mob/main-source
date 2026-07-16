using System;
using System.Collections.Generic;
using System.Linq;
using AudioSystem;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public Unit sourceUnit;

	public float speed;

	public float lifetime;

	protected float lifetimeTimer;

	public float damage = 1f;

	public float trainDamage;

	public float heal = 1f;

	public float burn;

	public float critChance;

	public bool isSundering;

	public float sunderChance;

	public bool hasBeenDeflected;

	private ModuleCannon cannon;

	public bool isEnemyProjectile;

	private EnemyTypes enemyType;

	public int hitsRemaining;

	private const float TRAIL_SCALE_FACTOR = 0.015f;

	private float scale;

	[SerializeField]
	private bool missOnLeaveViewport = true;

	[NonSerialized]
	public int screenWarpCounter;

	[NonSerialized]
	public bool isRedirecting;

	private bool hasRedirected;

	[NonSerialized]
	public bool isGoingToSplit;

	[NonSerialized]
	public float splitAngle;

	public GameObject bulletPrefab;

	public Vector3 bulletVector;

	private Unit lastUnitHit;

	public bool deflectCanHack;

	public float deflectHackProbability;

	public bool explosiveShot;

	public GameObject explosionGo;

	public float explosionSize;

	private bool hasCheckedForClawDeflect;

	[SerializeField]
	private GameObject impactPrefab;

	protected List<Health> healthComponentsHit;

	protected AudioSource audioSource;

	private bool hasHitOnce;

	[SerializeField]
	protected Unit targetUnit;

	[NonSerialized]
	public float trackingSpeed;

	private TrailRenderer tr;

	private TrailRenderer trc;

	private TrailRenderer[] trs;

	[SerializeField]
	private Gradient EnemyBulletColor;

	[SerializeField]
	private Gradient EnemyBulletColorOutline;

	[SerializeField]
	private GameObject bulletCollisionPs;

	[Header("Sound")]
	[SerializeField]
	protected SoundData trainHitSound1;

	[SerializeField]
	protected SoundData enemyHitSound1;

	protected SoundBuilder soundBuilder;

	private bool warpDamageModifierAdded;

	public float Distance { get; set; }

	public float Scale
	{
		get
		{
			return scale;
		}
		set
		{
			scale = value;
			base.transform.localScale = Vector3.one * value;
			trs[0].startWidth = 0.015f * value;
			trs[1].startWidth = 0.015f * value * 2f;
		}
	}

	public event Action OnProjectileMiss;

	public event Delegates.HealthChangeHandler ProjectileHit;

	public event Delegates.HealthChangeHandler ProjectileHeal;

	protected void Awake()
	{
		healthComponentsHit = new List<Health>();
		audioSource = GetComponent<AudioSource>();
		trs = GetComponentsInChildren<TrailRenderer>();
		if (base.transform.childCount > 0)
		{
			trc = base.transform.GetChild(0).GetComponent<TrailRenderer>();
		}
		tr = GetComponent<TrailRenderer>();
		cannon = Train.Instance.GetModuleByType<ModuleCannon>();
		hasCheckedForClawDeflect = false;
		soundBuilder = PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder();
	}

	private void Start()
	{
		lifetimeTimer = lifetime;
		CombatManager.Instance.RegisterProjectile(this);
		if (sourceUnit.IsEnemy)
		{
			isEnemyProjectile = true;
			if ((bool)tr)
			{
				tr.colorGradient = EnemyBulletColor;
			}
			if ((bool)trc)
			{
				trc.colorGradient = EnemyBulletColorOutline;
			}
		}
		else
		{
			isEnemyProjectile = false;
		}
	}

	protected void Update()
	{
		lifetimeTimer -= Time.deltaTime;
		if (lifetimeTimer < 0f)
		{
			if (!hasHitOnce)
			{
				this.OnProjectileMiss?.Invoke();
			}
			DestroyProjectile();
		}
	}

	protected void FixedUpdate()
	{
		Move();
		RaycastCollide(speed);
		RaycastCollide((0f - speed) * 3f);
	}

	public void SetTarget(Unit target)
	{
		targetUnit = target;
	}

	protected virtual void RaycastCollide(float speed)
	{
		RaycastHit2D hit = ((!isEnemyProjectile) ? Physics2D.Raycast(base.transform.position, base.transform.up, speed * Time.deltaTime, LayerMask.GetMask("Enemy")) : Physics2D.Raycast(base.transform.position, base.transform.up, speed * Time.deltaTime, LayerMask.GetMask("Unit", "Resource")));
		if (GameManager.Instance.bulletCollisionOn)
		{
			RaycastHit2D raycastHit2D = Physics2D.Raycast(base.transform.position, base.transform.up, speed * Time.deltaTime, LayerMask.GetMask("PP"));
			if (!isEnemyProjectile && raycastHit2D.collider != null && raycastHit2D.collider.TryGetComponent<Projectile>(out var component) && component.isEnemyProjectile)
			{
				if (bulletCollisionPs != null)
				{
					UnityEngine.Object.Instantiate(bulletCollisionPs, base.transform);
					Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
					GameObject gameObject = UnityEngine.Object.Instantiate(bulletCollisionPs, base.transform.position, rotation);
					ParticleSystem component2 = gameObject.GetComponent<ParticleSystem>();
					if (component2 != null)
					{
						float t = component2.main.duration + component2.main.startLifetime.constantMax;
						UnityEngine.Object.Destroy(gameObject, t);
					}
				}
				component.DestroyProjectile();
				DestroyProjectile();
			}
		}
		if (hit.collider == null)
		{
			return;
		}
		Unit componentInChildren;
		if (isEnemyProjectile)
		{
			if (hit.collider.TryGetComponent<Unit>(out var component3) && component3.isShieldPlate)
			{
				HealthChangeInfo info = new HealthChangeInfo(this, component3.HealthComponent, trainDamage);
				component3.HealthComponent.ChangeHealthWithInfo(info);
				trainDamage = 0f;
			}
			if (hit.collider.TryGetComponent<ModuleSlot>(out var component4))
			{
				componentInChildren = component4.GetComponentInChildren<Unit>();
				if (componentInChildren == null)
				{
					SpawnImpact(hit.point, hit.normal);
					DestroyProjectile();
				}
				else if (componentInChildren != null && componentInChildren.IsEnemy != isEnemyProjectile)
				{
					UnitHit(componentInChildren, hit);
				}
				return;
			}
			if (!hasCheckedForClawDeflect && hit.collider.TryGetComponent<Claw>(out var component5) && component5.isDeflecting)
			{
				hasCheckedForClawDeflect = true;
				if (UnityEngine.Random.Range(0f, 100f) <= component5.deflectChance)
				{
					DeflectProjectile(Train.Instance.GetModuleByType<ModuleCannon>());
					Vector2 normalized = Vector2.Reflect(base.transform.up, hit.normal).normalized;
					base.transform.rotation = Quaternion.LookRotation(Vector3.forward, normalized);
					return;
				}
			}
		}
		componentInChildren = hit.collider.GetComponent<Unit>();
		if (componentInChildren == null || (componentInChildren.ignoreProjectiles && !(componentInChildren is E3_5_StealthBomber)) || componentInChildren.GetComponent<Explosion>() != null || (!isEnemyProjectile && !componentInChildren.IsEnemy))
		{
			return;
		}
		if (isEnemyProjectile == componentInChildren.IsEnemy)
		{
			if (this is MedDart)
			{
				UnitHeal(componentInChildren, hit);
			}
		}
		else
		{
			if (healthComponentsHit.Contains(componentInChildren.HealthComponent))
			{
				return;
			}
			if (componentInChildren.TryDodge())
			{
				if (isEnemyProjectile)
				{
					healthComponentsHit.AddRange(from module in Train.Instance.Modules
						where module
						select module.HealthComponent);
				}
				else
				{
					healthComponentsHit.Add(componentInChildren.HealthComponent);
				}
			}
			else if (!componentInChildren.HealthComponent.IsDead || componentInChildren.HealthComponent.IsImmune)
			{
				UnitHit(componentInChildren, hit);
			}
		}
	}

	protected virtual void UnitHit(Unit hitUnit, RaycastHit2D hit)
	{
		if (isEnemyProjectile && hitUnit.HealthComponent.isShield)
		{
			float num = UnityEngine.Random.Range(0f, 1f);
			float shieldSetsEnemyOnFireChance = GlobalFields.Instance.ShieldSetsEnemyOnFireChance;
			if (shieldSetsEnemyOnFireChance + shieldSetsEnemyOnFireChance * GlobalFields.Instance.LuckProb >= num)
			{
				sourceUnit.HealthComponent.ApplyBurn(1f, sourceUnit);
			}
			num = UnityEngine.Random.Range(0f, 100f);
			if (GlobalFields.Instance.ShieldSundersEnemyChance * (1f + GlobalFields.Instance.LuckProb) >= num)
			{
				sourceUnit.HealthComponent.ApplySunder();
			}
		}
		bool flag = UnityEngine.Random.Range(0f, 100f) < critChance;
		damage *= (flag ? 1.5f : 1f);
		if (isEnemyProjectile)
		{
			damage *= (PlayerManager.Instance.IsCoop ? DifficultyManager.Instance.CoopDamageMultiplier : 1f);
		}
		else
		{
			damage *= GlobalFields.Instance.ProjectileDamageMult;
		}
		float num2 = UnityEngine.Random.Range(0f, 100f);
		float ricochetChance = hitUnit.HealthComponent.ricochetChance;
		if (ricochetChance + ricochetChance * GlobalFields.Instance.LuckProb >= num2)
		{
			Vector2 normalized = Vector2.Reflect(base.transform.up, hit.normal).normalized;
			base.transform.rotation = Quaternion.LookRotation(Vector3.forward, normalized);
			DeflectProjectile(Train.Instance.GetModuleByType<ModuleCannon>());
			return;
		}
		HealthChangeInfo healthChangeInfo = new HealthChangeInfo(sourceUnit, hitUnit.HealthComponent, 0f - damage, isPercent: false, hit, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, flag);
		if (isEnemyProjectile)
		{
			DataTrackingManager.Instance.AddDamageByEnemy(sourceUnit.GetType().Name, 0f - healthChangeInfo.HealthChange);
		}
		OnProjectileHit(healthChangeInfo);
		healthComponentsHit.Add(hitUnit.HealthComponent);
		hitUnit.HealthComponent.ChangeHealthWithInfo(healthChangeInfo);
		hitUnit.HealthComponent.ApplyBurn(burn, healthChangeInfo.source);
		if (isSundering)
		{
			hitUnit.HealthComponent.ApplySunder();
		}
		else if (UnityEngine.Random.Range(0f, 100f) < sunderChance)
		{
			hitUnit.HealthComponent.ApplySunder();
		}
		hitsRemaining--;
		if (sourceUnit != null && sourceUnit.name == "ModuleCannon" && !hasHitOnce)
		{
			hasHitOnce = true;
			GameManager.Instance.cannonHitsInRun++;
		}
		if (isGoingToSplit)
		{
			SplitProjectile(healthChangeInfo, hitUnit);
		}
		if (explosiveShot)
		{
			ProjectileExplosion(healthChangeInfo);
		}
		if (hasBeenDeflected && deflectCanHack)
		{
			ApplyHack(hitUnit);
		}
		SpawnImpact(hit.point, hit.normal);
		if (isRedirecting && !hasRedirected)
		{
			RedirectProjectile();
		}
		else if (hitsRemaining <= 0)
		{
			DestroyProjectile();
		}
	}

	protected virtual void UnitHeal(Unit hitUnit, RaycastHit2D hit)
	{
		HealthChangeInfo info = new HealthChangeInfo(sourceUnit, hitUnit.HealthComponent, heal, isPercent: false, hit, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing);
		OnProjectileHeal(info);
		healthComponentsHit.Add(hitUnit.HealthComponent);
		hitUnit.HealthComponent.ChangeHealthWithInfo(info);
		SpawnImpact(hit.point, hit.normal);
		DestroyProjectile();
	}

	protected void OnProjectileHit(HealthChangeInfo info)
	{
		this.ProjectileHit?.Invoke(info);
	}

	protected void OnProjectileHeal(HealthChangeInfo info)
	{
		this.ProjectileHeal?.Invoke(info);
	}

	private EnemyBase FindNearestEnemyExceptLastHit()
	{
		if (healthComponentsHit.Count == 0)
		{
			return null;
		}
		return (from e in EnemyManager.Instance.Enemies
			where e.HealthComponent != healthComponentsHit[healthComponentsHit.Count - 1] && e.HealthComponent.HealthCurrent > 0f && !e.IsEnemyGadget && Vector2.SqrMagnitude(e.transform.position - base.transform.position) <= cannon.cannon.redirectRange * cannon.cannon.redirectRange
			orderby (e.transform.position - base.transform.position).magnitude
			select e).FirstOrDefault();
	}

	protected virtual void FindTrackingTarget()
	{
		if (sourceUnit == null)
		{
			return;
		}
		Unit[] validEnemyTargets = UnitHelper.GetValidEnemyTargets(sourceUnit);
		if (validEnemyTargets == null || validEnemyTargets.Length == 0)
		{
			return;
		}
		float num = 360f;
		int num2 = 0;
		for (int i = 0; i < validEnemyTargets.Length; i++)
		{
			if (validEnemyTargets[i] != lastUnitHit && validEnemyTargets[i].HealthComponent.HealthCurrent > 0f)
			{
				Vector2 to = validEnemyTargets[i].transform.position - base.transform.position;
				float num3 = Vector2.Angle(base.transform.up, to);
				if (num3 < num)
				{
					num = num3;
					num2 = i;
				}
			}
		}
		targetUnit = validEnemyTargets[num2];
	}

	protected virtual void Move()
	{
		if (targetUnit != null && isRedirecting && hasRedirected && targetUnit.HealthComponent.HealthCurrent > 0f)
		{
			Vector3 normalized = (targetUnit.transform.position - base.transform.position).normalized;
			Quaternion rotation = Quaternion.LookRotation(Vector3.forward, normalized);
			base.transform.rotation = rotation;
		}
		else if (trackingSpeed > 0f)
		{
			FindTrackingTarget();
			if (targetUnit != null && targetUnit.IsEnemy != isEnemyProjectile && !targetUnit.ignoreProjectiles && targetUnit.HealthComponent.HealthCurrent > 0f)
			{
				Vector3 normalized2 = (targetUnit.transform.position - base.transform.position).normalized;
				Quaternion to = Quaternion.LookRotation(Vector3.forward, normalized2);
				base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, Time.deltaTime * trackingSpeed);
			}
		}
		base.transform.Translate(base.transform.up * speed * Time.deltaTime, Space.World);
		bulletVector = base.transform.up;
		if (screenWarpCounter > 0)
		{
			if (base.transform.TryWrap())
			{
				screenWarpCounter--;
				if (!warpDamageModifierAdded)
				{
					damage *= GlobalFields.Instance.WrapDamageMult;
					warpDamageModifierAdded = true;
				}
				TrailRenderer[] array = trs;
				for (int i = 0; i < array.Length; i++)
				{
					array[i]?.Clear();
				}
			}
		}
		else if (missOnLeaveViewport && base.transform.IsOutsideViewport())
		{
			ProjectileMissed();
		}
	}

	private void SpawnImpact(Vector2 pos, Vector2 normal)
	{
		if (impactPrefab == null)
		{
			return;
		}
		Quaternion rotation = Quaternion.LookRotation(Vector3.forward, normal);
		GameObject obj = UnityEngine.Object.Instantiate(impactPrefab, pos, rotation);
		if (isEnemyProjectile)
		{
			if (trainHitSound1.clips.Count > 0)
			{
				soundBuilder.Play(trainHitSound1);
			}
			else if (!isEnemyProjectile && enemyHitSound1.clips.Count > 0)
			{
				soundBuilder.Play(enemyHitSound1);
			}
		}
		UnityEngine.Object.Destroy(obj, 1f);
	}

	public virtual void DestroyProjectile()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	protected virtual void OnDestroy()
	{
		this.ProjectileHit = null;
		this.OnProjectileMiss = null;
		CombatManager.Instance.DeregisterProjectile(this);
	}

	public void CloneProjectileStats(Projectile projectile)
	{
		projectile.speed = speed;
		projectile.burn = burn;
		projectile.screenWarpCounter = screenWarpCounter;
		projectile.critChance = critChance;
		projectile.damage = damage;
		projectile.lifetime = lifetime;
		projectile.scale = scale;
		projectile.deflectCanHack = deflectCanHack;
		projectile.deflectHackProbability = deflectHackProbability;
		projectile.missOnLeaveViewport = missOnLeaveViewport;
		projectile.EnemyBulletColor = EnemyBulletColor;
		projectile.EnemyBulletColorOutline = EnemyBulletColorOutline;
		projectile.enemyHitSound1 = enemyHitSound1;
		projectile.hasBeenDeflected = hasBeenDeflected;
		projectile.hitsRemaining = hitsRemaining;
		projectile.impactPrefab = impactPrefab;
		projectile.bulletVector = bulletVector;
		projectile.isGoingToSplit = isGoingToSplit;
		projectile.hasRedirected = hasRedirected;
		projectile.isRedirecting = isRedirecting;
		projectile.isSundering = isSundering;
		projectile.sunderChance = sunderChance;
		projectile.sourceUnit = sourceUnit;
		projectile.splitAngle = splitAngle;
		projectile.trackingSpeed = trackingSpeed;
		projectile.trainHitSound1 = trainHitSound1;
		projectile.lastUnitHit = lastUnitHit;
		projectile.sourceUnit = sourceUnit;
		projectile.explosiveShot = explosiveShot;
		projectile.explosionGo = explosionGo;
	}

	public void SplitProjectile(HealthChangeInfo info, Unit hitUnit)
	{
		Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, bulletVector);
		Projectile component = UnityEngine.Object.Instantiate(rotation: quaternion * Quaternion.Euler(0f, 0f, splitAngle), original: bulletPrefab, position: info.Target.transform.position).GetComponent<Projectile>();
		component.healthComponentsHit.Add(hitUnit.HealthComponent);
		CloneProjectileStats(component);
		component.isGoingToSplit = false;
		component.hasRedirected = false;
		component.isRedirecting = false;
		component.lastUnitHit = hitUnit;
		component.sourceUnit = sourceUnit;
		component.damage *= 0.5f;
		Quaternion rotation = quaternion * Quaternion.Euler(0f, 0f, 0f - splitAngle);
		Projectile component2 = UnityEngine.Object.Instantiate(bulletPrefab, info.Target.transform.position, rotation).GetComponent<Projectile>();
		component2.healthComponentsHit.Add(hitUnit.HealthComponent);
		CloneProjectileStats(component2);
		component2.isGoingToSplit = false;
		component2.hasRedirected = false;
		component2.isRedirecting = false;
		component2.lastUnitHit = hitUnit;
		component2.sourceUnit = sourceUnit;
		component2.damage *= cannon.cannon.splitDamageReduction;
	}

	public void ProjectileExplosion(HealthChangeInfo info)
	{
		Explosion component = UnityEngine.Object.Instantiate(explosionGo, info.Hit.Value.point, Quaternion.identity).GetComponent<Explosion>();
		float num = scale;
		component.Initialize(enemyDamage: cannon.cannon.explosionDamage, sourceUnit: cannon, radius: explosionSize * num);
	}

	public void ApplyHack(Unit hitUnit)
	{
		ModuleHacking moduleByType = Train.Instance.GetModuleByType<ModuleHacking>();
		if (ProbUtils.CheckWithLuck(deflectHackProbability))
		{
			moduleByType.HackEnemy(hitUnit.GetComponent<EnemyBase>());
		}
	}

	public void RedirectProjectile()
	{
		damage *= GlobalFields.Instance.RicochetDmgMult;
		targetUnit = FindNearestEnemyExceptLastHit();
		if (targetUnit == null)
		{
			base.transform.up = UnityEngine.Random.insideUnitCircle;
			bulletVector = base.transform.up;
		}
		hasRedirected = true;
		damage *= 0.8f;
	}

	public void ProjectileMissed()
	{
		if (!hasRedirected)
		{
			this.OnProjectileMiss?.Invoke();
		}
	}

	public virtual void DeflectProjectile(Unit newSourceUnit, float damageIncreasePercent = 0f)
	{
		sourceUnit = newSourceUnit;
		isEnemyProjectile = false;
		hasBeenDeflected = true;
		damage *= GlobalFields.Instance.RicochetDmgMult;
		damage *= 1f + damageIncreasePercent;
	}
}
