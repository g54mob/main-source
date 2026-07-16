using System;
using System.Collections;
using AudioSystem;
using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class EnemyBase : Unit, IEMPable
{
	public enum EnemyPositionOnScreen
	{
		BottomOfScreen = -1,
		TopOfScreen = 1
	}

	protected const float TARGET_HEALTHY_MODULE_CHANCE = 0.3f;

	public StateMachine sm;

	[SerializeField]
	private bool persistsThroughDeath;

	[Header("Movement Settings")]
	protected float rateOfChangeY;

	protected float noiseSeed;

	protected Vector3 previousPos;

	[NonSerialized]
	public float relativeSpeedMult = 1f;

	[SerializeField]
	public bool LockRotation = true;

	[SerializeField]
	protected float minY = 0.25f;

	[SerializeField]
	protected float maxY = 1.2f;

	[SerializeField]
	private bool ignoreAvoid;

	[SerializeField]
	private bool avoidFromOtherSide;

	[SerializeField]
	public int avoidPriority;

	[SerializeField]
	private float avoidDistance = 0.25f;

	[SerializeField]
	private float avoidStrength = 0.01f;

	[NonSerialized]
	public float turnAvoidDistance = 1f;

	[NonSerialized]
	public bool IsInPosition;

	[NonSerialized]
	public float targetOffsetY;

	public float minStoppingDistance = 0.25f;

	public float maxStoppingDistance = 1f;

	[Header("Combat Settings")]
	[SerializeField]
	public float IdleTime;

	[SerializeField]
	public float FirstIdleTime;

	[NonSerialized]
	public float idleTimer;

	public float timeBetweenShots;

	public float projSpeed;

	public float damage;

	[Tooltip("Buffs to health, damage, etc. affect this enemy.")]
	[SerializeField]
	protected bool waveBuffed = true;

	[SerializeField]
	protected bool reparentChildrenOnDeath;

	private float thrusterStartSpeed;

	[NonSerialized]
	[HideInInspector]
	public float distanceOfEnemyToTrain;

	[NonSerialized]
	[HideInInspector]
	public float farStoppingDistance;

	[NonSerialized]
	[HideInInspector]
	public ParticleSystem PS;

	[NonSerialized]
	[HideInInspector]
	public float shotTimer;

	[NonSerialized]
	[HideInInspector]
	public float closeStoppingDistance;

	[NonSerialized]
	[HideInInspector]
	public float empDuration;

	[NonSerialized]
	[HideInInspector]
	public EnemyPositionOnScreen enemyPos;

	[NonSerialized]
	[HideInInspector]
	public EnemyUI enemyUI;

	[NonSerialized]
	public bool IsChained;

	[Header("Prefabs")]
	[SerializeField]
	protected ParticleSystem thrusterPs;

	[SerializeField]
	protected GameObject explosionPrefab;

	[SerializeField]
	protected float explosionScale = 0.25f;

	[SerializeField]
	protected bool muteExplosion;

	public SimpleFlash flashEffect;

	public GameObject bullet;

	protected Explosion deathExplosion;

	public ParticleSystem HealingPs;

	private ParticleSystem.EmissionModule healingEmmision;

	private bool damageModified;

	public float trainDamage;

	protected float coopDamageMultiplier;

	private float coopHealthMultiplier;

	protected float speedInLastFrame;

	[NonSerialized]
	public GameObject Snot;

	[NonSerialized]
	public float SnotModifier = 1f;

	[NonSerialized]
	public int Burn;

	[NonSerialized]
	public float DamageModifier = 1f;

	[NonSerialized]
	public float RofModifier;

	protected Vector3 lagVector = Vector3.zero;

	protected Vector2 lagVelocity = Vector2.zero;

	protected Vector3 lagTarget = Vector3.zero;

	protected float speedUpTime;

	protected float startReactionTime;

	protected float slowDownTime;

	protected float stopReactionTime;

	protected Coroutine lagCorutine;

	[Header("Inertia settings")]
	[SerializeField]
	protected EnemyInertiaSettings inertiaSettings;

	protected float speedUpCooldown;

	protected float slowDownCooldown;

	protected bool disableInertia;

	protected float tempDamageForWeaken;

	protected float tempTrainDamageForWeaken;

	[Header("SFX")]
	[SerializeField]
	protected SoundData deathSFX;

	[SerializeField]
	protected SoundData spawnSFX;

	[SerializeField]
	[Range(0f, 1f)]
	protected float chanceForDeathSFX = 0.2f;

	[SerializeField]
	[Range(0f, 1f)]
	protected float chanceForSpawnSFX = 0.2f;

	[SerializeField]
	protected SoundData engineSound;

	[SerializeField]
	protected SoundData shootSound;

	private int rotateTweenId;

	protected bool NoDeathEvents;

	protected bool alreadyDied;

	private bool enemyDespawned;

	private bool isTurning;

	[field: SerializeField]
	public SpawnZone spawnZone { get; private set; }

	[field: SerializeField]
	public string Name { get; private set; }

	[field: SerializeField]
	public bool IsBoss { get; private set; }

	[field: SerializeField]
	public bool IsEnemyGadget { get; private set; }

	[field: SerializeField]
	public bool IsPet { get; private set; }

	[field: SerializeField]
	public EnemyTypes EnemyType { get; private set; }

	[field: SerializeField]
	public ScreenPositions PrefferedSpawnPos { get; private set; }

	[field: SerializeField]
	public float MoveSpeed { get; set; }

	[field: SerializeField]
	public float TurnSpeed { get; set; }

	[field: SerializeField]
	public int UnlockColumn { get; private set; }

	public float posSign => ((float)enemyPos == 1f) ? 1 : (-1);

	public float posSignTf => (base.transform.position.y > 0f) ? 1 : (-1);

	public Animator Anim { get; private set; }

	public GameObject StunPsGo { get; private set; }

	public bool IsEMPd
	{
		get
		{
			if ((bool)base.HealthComponent)
			{
				return base.HealthComponent.isEMPd;
			}
			return false;
		}
	}

	public bool IsDead
	{
		get
		{
			if ((bool)base.HealthComponent)
			{
				return base.HealthComponent.IsDead;
			}
			return false;
		}
	}

	public float EnemyDamage => damage * DamageModifier;

	public float TrainDamage => trainDamage * DamageModifier;

	public float TimeBetweenShots => timeBetweenShots * Mathf.Max(1f - RofModifier, 0.1f) * SnotModifier;

	public event Delegates.HealthChangeHandler TargetDamaged;

	public event Action OnDeathEvent;

	public event Action<HealthChangeInfo> DeathInfoEvent;

	protected new void Awake()
	{
		base.Awake();
		idleTimer = FirstIdleTime;
		Anim = GetComponent<Animator>();
		EnemyManager.Instance.RegisterEnemy(this);
		if ((bool)thrusterPs)
		{
			thrusterStartSpeed = thrusterPs.main.startSpeed.constant;
		}
		turnAvoidDistance = Mathf.Clamp(0.7f - minY, 0f, 1f);
		coopDamageMultiplier = (PlayerManager.Instance.IsCoop ? DifficultyManager.Instance.CoopDamageMultiplier : 1f);
		coopHealthMultiplier = (PlayerManager.Instance.IsCoop ? DifficultyManager.Instance.CoopHealthMultiplier : 1f);
		if (IsGrounded && !IsEnemyGadget && !IsBoss && !IsPet)
		{
			Train.Instance.OnBraking += SpeedDown;
			Train.Instance.OnSpeedingUp += SpeedUp;
			speedUpTime = UnityEngine.Random.Range(inertiaSettings.minSpeedUpTime, inertiaSettings.maxSpeedUptime);
			startReactionTime = UnityEngine.Random.Range(inertiaSettings.minStartReactionTime, inertiaSettings.maxStartReactionTime);
			slowDownTime = 0.5f;
			stopReactionTime = UnityEngine.Random.Range(inertiaSettings.minStopReactionTime, inertiaSettings.maxStopReactionTime);
		}
	}

	protected new void Start()
	{
		base.Start();
		_ = (Vector2)(Train.Instance.transform.position - base.transform.position);
		if ((bool)base.HealthComponent)
		{
			base.HealthComponent.OnDeath += OnDeath;
			base.HealthComponent.OnHealthChanged += OnHealthChanged;
			base.HealthComponent.RaiseMaxHealthByWithHeal(base.HealthComponent.HealthMax * (coopHealthMultiplier - 1f));
		}
		if ((bool)HealingPs)
		{
			healingEmmision = HealingPs.emission;
		}
		farStoppingDistance = UnityEngine.Random.Range(minStoppingDistance, maxStoppingDistance);
		closeStoppingDistance = farStoppingDistance - 0.1f;
		if (base.transform.position.y > Train.Instance.transform.position.y)
		{
			enemyPos = EnemyPositionOnScreen.TopOfScreen;
		}
		else
		{
			enemyPos = EnemyPositionOnScreen.BottomOfScreen;
		}
		if (!damageModified)
		{
			damage *= 1f + DifficultyManager.Instance.enemyDamageMultiplier;
			damageModified = true;
		}
		OnSpawn();
		if (!IsEnemyGadget && engineSound.clips.Count > 0)
		{
			soundBuilder.Play(engineSound, 0f, matchVolumeWithTrainSpeed: true);
		}
	}

	protected void Update()
	{
		if (IsDead && !persistsThroughDeath)
		{
			OnDeath(new HealthChangeInfo(this, base.HealthComponent, -100f, isPercent: false, null, canRes: false, ignoreArmor: true, ignoreImmunity: true, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		}
		if (!IsChained)
		{
			shotTimer -= Time.deltaTime;
			empDuration -= Time.deltaTime;
			if (speedUpCooldown > 0f)
			{
				speedUpCooldown -= Time.deltaTime;
			}
			if (slowDownCooldown > 0f)
			{
				slowDownCooldown -= Time.deltaTime;
			}
			if (sm != null)
			{
				sm.UpdateStates();
			}
			SetRelativeSpeedMult();
			if (thrusterPs != null)
			{
				ParticleSystem.MainModule main = thrusterPs.main;
				float num = Train.Instance.SpeedCurrent / Train.Instance.SpeedMax;
				main.startSpeed = num * thrusterStartSpeed;
			}
		}
	}

	protected void FixedUpdate()
	{
		if (!(Time.deltaTime <= 0f) && !IsChained && sm != null)
		{
			sm.FixedUpdateStates();
		}
	}

	protected virtual void CheckTarget()
	{
		if (base.TargetUnit == null || base.TargetUnit.IsEnemy == base.IsEnemy || base.TargetUnit.ignoreProjectiles)
		{
			Retarget();
		}
	}

	protected virtual void Retarget()
	{
		Target();
	}

	protected void RotateToIdentity()
	{
		if (LockRotation)
		{
			base.transform.rotation = Quaternion.identity;
		}
	}

	public void SpeedUp(bool forcedSpeedUp)
	{
		if (!(speedUpCooldown > 0f) || forcedSpeedUp)
		{
			speedUpTime = UnityEngine.Random.Range(inertiaSettings.minSpeedUpTime, inertiaSettings.maxSpeedUptime);
			startReactionTime = UnityEngine.Random.Range(inertiaSettings.minStartReactionTime, inertiaSettings.maxStartReactionTime);
			speedUpCooldown = startReactionTime + speedUpTime + 2f;
			slowDownCooldown = 3f;
			ApplyLag(Vector3.left * 0.02f * GameManager.Instance.GameSpeedModifier, startReactionTime, isBreaking: false);
		}
	}

	public void SpeedDown(bool forcedSlow)
	{
		if (!(slowDownCooldown > 0f) || forcedSlow)
		{
			stopReactionTime = UnityEngine.Random.Range(inertiaSettings.minStopReactionTime, inertiaSettings.maxStopReactionTime);
			slowDownCooldown = stopReactionTime + slowDownTime + 10f;
			speedUpCooldown = 0f;
			float num = UnityEngine.Random.Range((10f - inertiaSettings.minBreakingStrength) / 100f, (10f - inertiaSettings.maxBreakingStrength) / 100f);
			ApplyLag(Vector3.right * num, stopReactionTime, isBreaking: true);
		}
	}

	public virtual void OnChained()
	{
		IsChained = true;
		MoveSpeed = 0f;
	}

	protected virtual void SetRelativeSpeedMult()
	{
		relativeSpeedMult = Train.Instance.TrainSpeedNormalized;
		if (relativeSpeedMult < 1f && !IsInPosition)
		{
			relativeSpeedMult = 1f;
		}
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		if (base.IsEnemy && Train.Instance.hackExpiryStunDurationAndDamage != 0f)
		{
			HealthChangeInfo info = new HealthChangeInfo(this, base.HealthComponent, 0f - Train.Instance.hackExpiryStunDurationAndDamage);
			base.HealthComponent.ChangeHealthWithInfo(info);
			EMP(Train.Instance.hackExpiryStunDurationAndDamage);
		}
	}

	public virtual bool IsDistanceToTrainCorrect()
	{
		distanceOfEnemyToTrain = Mathf.Abs(base.transform.position.y - Train.Instance.transform.position.y);
		if (distanceOfEnemyToTrain <= farStoppingDistance)
		{
			return distanceOfEnemyToTrain >= closeStoppingDistance;
		}
		return false;
	}

	public virtual void Move()
	{
		if (base.transform.position.y * posSign < minY)
		{
			base.transform.position = new Vector3(base.transform.position.x, minY * posSign);
		}
	}

	[Obsolete("Use Rotator component instead")]
	public bool RotateTowardsTransform(Transform targetTf)
	{
		Vector3 normalized = (targetTf.position - base.transform.position).normalized;
		Quaternion to = Quaternion.LookRotation(Vector3.forward, normalized);
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, Time.deltaTime * TurnSpeed);
		float num = Vector3.Dot(base.transform.up, normalized.normalized);
		return 1f - num < 0.01f;
	}

	[Obsolete("Use Rotator component instead")]
	public bool RotateTowardsDirection(Vector3 dir)
	{
		Quaternion to = Quaternion.LookRotation(Vector3.forward, dir);
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, Time.deltaTime * TurnSpeed);
		float num = Vector3.Dot(base.transform.up, dir.normalized);
		return 1f - num < 0.01f;
	}

	[Obsolete("Use Rotator component instead")]
	public void RotateTowardsAngle(Vector3 angleVector, float rotationDuration, bool lockOnComplete = false)
	{
		if (!(base.HealthComponent == null) && !base.HealthComponent.IsDead)
		{
			float angle = Mathf.Atan2(angleVector.y, angleVector.x) * 57.29578f;
			RotateTowardsAngle(angle, rotationDuration, lockOnComplete);
		}
	}

	[Obsolete("Use Rotator component instead")]
	public void RotateTowardsAngle(float angle, float rotationDuration, bool lockOnComplete = false)
	{
		if (base.HealthComponent == null || base.HealthComponent.IsDead)
		{
			return;
		}
		if (rotateTweenId > 0)
		{
			LeanTween.cancel(rotateTweenId);
		}
		float z = base.transform.eulerAngles.z;
		float num = Mathf.DeltaAngle(z, angle);
		float to = z + num;
		rotateTweenId = LeanTween.value(base.transform.eulerAngles.z, to, rotationDuration).setOnUpdate(delegate(float z2)
		{
			base.transform.rotation = Quaternion.Euler(0f, 0f, z2);
		}).setOnComplete((Action)delegate
		{
			if (lockOnComplete)
			{
				LockRotation = true;
			}
		})
			.id;
	}

	public virtual void Target()
	{
		if (UnityEngine.Random.value <= 0.3f)
		{
			base.TargetUnit = UnitHelper.GetRandomLiveEnemyUnit(this);
		}
		else
		{
			base.TargetUnit = UnitHelper.GetRandomEnemyUnit(this);
		}
	}

	public virtual Vector2 GetNeighborAvoidanceVector()
	{
		Vector2 zero = Vector2.zero;
		int num = 0;
		foreach (EnemyBase enemy in EnemyManager.Instance.Enemies)
		{
			if (!enemy || enemy.IsGrounded != IsGrounded || enemy.ignoreAvoid != ignoreAvoid || enemy.avoidPriority < avoidPriority || (!avoidFromOtherSide && MathF.Sign(base.transform.position.y) != Math.Sign(enemy.transform.position.y)))
			{
				continue;
			}
			Collider2D component = enemy.GetComponent<Collider2D>();
			Collider2D component2 = GetComponent<Collider2D>();
			if (!(component == null) && !(component2 == null))
			{
				Vector2 vector = (Vector2)enemy.transform.position - (Vector2)base.transform.position;
				float num2 = component.bounds.extents.magnitude + component2.bounds.extents.magnitude;
				float magnitude = vector.magnitude;
				if (magnitude < avoidDistance + num2)
				{
					float num3 = avoidDistance + num2 - magnitude;
					distanceOfEnemyToTrain = Mathf.Abs(base.transform.position.y - Train.Instance.transform.position.y);
					Vector2 vector2 = ((!(distanceOfEnemyToTrain <= minStoppingDistance) || enemy.avoidPriority <= avoidPriority) ? (-vector.normalized) : new Vector2(-0.1f, 0f));
					zero += vector2 * num3;
					num++;
				}
			}
		}
		if (num > 0)
		{
			zero /= (float)num;
		}
		return zero * avoidStrength;
	}

	public virtual void Aim()
	{
	}

	public virtual void Shoot()
	{
	}

	protected virtual void OnHealthChanged(HealthChangeInfo info)
	{
		if (info.HealthChange > 0f)
		{
			SpawnHealParticles(info.HealthChange);
		}
		else if ((bool)flashEffect && !info.RemoveHitEffect)
		{
			if (info.IsImmune)
			{
				flashEffect.Flash(FlashTypes.Invulnerability);
			}
			else if (info.IsCrit)
			{
				flashEffect.Flash(FlashTypes.Crit);
			}
			else if (info.IsDamageReduced)
			{
				flashEffect.Flash(FlashTypes.ReducedDamage);
			}
			else
			{
				flashEffect.Flash();
			}
		}
	}

	protected void SpawnHealParticles(float amount)
	{
		if ((bool)HealingPs)
		{
			healingEmmision.burstCount = Mathf.Clamp((int)(amount * 10f), 0, 180);
			HealingPs.Play();
		}
	}

	protected virtual void OnDeath(HealthChangeInfo info)
	{
		if (info.source is Unit killer)
		{
			CombatManager.Instance.OnEnemyKilled(this, killer, info);
		}
		if ((bool)base.gameObject.GetComponent<StatusEffectComponent>())
		{
			StatusEffectComponent component = base.gameObject.GetComponent<StatusEffectComponent>();
			while (component.statusEffects.Count > 0)
			{
				component.statusEffects[0].Expire();
			}
		}
		base.gameObject.GetComponent<StatusEffectComponent>();
		if (IsGrounded)
		{
			DisableInertia();
			Train.Instance.OnBraking -= SpeedDown;
			Train.Instance.OnSpeedingUp -= SpeedUp;
		}
		if (reparentChildrenOnDeath)
		{
			foreach (Transform item in base.transform)
			{
				item.SetParent(EnemyManager.Instance.transform);
			}
		}
		if ((bool)explosionPrefab && !enemyDespawned && !alreadyDied)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(explosionPrefab, base.transform.position, base.transform.rotation);
			gameObject.layer = 15;
			deathExplosion = gameObject.GetComponent<Explosion>();
			deathExplosion.Initialize(this, explosionScale, 0f, 0f, muteExplosion);
		}
		if (!alreadyDied)
		{
			GetComponent<ExplodeSprite>()?.Explode();
		}
		if (deathSFX.clips.Count != 0 && UnityEngine.Random.Range(0f, 1f) > chanceForSpawnSFX)
		{
			soundBuilder.Play(deathSFX);
		}
		if (!NoDeathEvents)
		{
			this.OnDeathEvent?.Invoke();
			this.DeathInfoEvent?.Invoke(info);
		}
		EnemyManager.Instance.OnEnemyDestroyed(this);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public virtual void Despawn()
	{
		enemyDespawned = true;
		if (IsGrounded)
		{
			DisableInertia();
			Train.Instance.OnBraking -= SpeedDown;
			Train.Instance.OnSpeedingUp -= SpeedUp;
		}
		EnemyManager.Instance.OnEnemyDespawned(this);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void OnDestroy()
	{
		EnemyManager.Instance.UnregisterEnemy(this);
		this.TargetDamaged = null;
	}

	public virtual void EMP(float duration)
	{
		if (!isImmuneToEMP)
		{
			if ((bool)base.HealthComponent)
			{
				base.HealthComponent.isEMPd = true;
			}
			EnemyManager.Instance.OnEnemyEMPd(this);
			if (sm != null)
			{
				sm.ForceState("EMP");
			}
			if (IsBoss)
			{
				empDuration = duration * GlobalFields.Instance.BossEmpDurationMult;
			}
			else
			{
				empDuration = duration;
			}
			StunPsGo = UnityEngine.Object.Instantiate(EnemyManager.Instance.StunPsPrefab, base.transform.position, Quaternion.identity, base.transform);
		}
	}

	public virtual void OnEMPEnd()
	{
		if ((bool)base.HealthComponent)
		{
			base.HealthComponent.isEMPd = false;
		}
		UnityEngine.Object.Destroy(StunPsGo);
	}

	public void OnTargetDamaged(HealthChangeInfo info)
	{
		this.TargetDamaged?.Invoke(info);
	}

	public void KillSelf(float delay = 0f)
	{
		if (!(this == null))
		{
			StartCoroutine(KillSelfCoroutine(delay));
		}
	}

	private IEnumerator KillSelfCoroutine(float delay)
	{
		yield return new WaitForSeconds(delay);
		base.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(this, base.HealthComponent, -100f, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: true, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: false, DamageType.God));
	}

	public void ApplyLag(Vector3 offset, float duration, bool isBreaking)
	{
		if (disableInertia)
		{
			return;
		}
		if (lagCorutine != null)
		{
			StopCoroutine(lagCorutine);
			lagTarget = Vector3.zero;
			lagCorutine = null;
			if (isBreaking && base.transform.position.x < -1.3f)
			{
				lagCorutine = StartCoroutine(LagRoutine(offset, duration));
			}
		}
		else
		{
			lagCorutine = StartCoroutine(LagRoutine(offset, duration));
		}
	}

	protected IEnumerator LagRoutine(Vector3 offset, float duration)
	{
		lagTarget = offset;
		yield return new WaitForSeconds(duration);
		lagTarget = Vector3.zero;
		lagCorutine = null;
	}

	protected Vector2 GetLagVector()
	{
		lagVector = Vector2.SmoothDamp(lagVector, lagTarget, ref lagVelocity, speedUpTime);
		return lagVector;
	}

	protected Vector3 GetPositionModifiers()
	{
		return GetNeighborAvoidanceVector() + GetLagVector();
	}

	public void DisableInertia()
	{
		if (lagCorutine != null)
		{
			StopCoroutine(lagCorutine);
			lagTarget = Vector3.zero;
			lagCorutine = null;
		}
		disableInertia = true;
	}

	public void EnableInertia()
	{
		disableInertia = false;
	}

	public void AvoidTurn()
	{
		if (!isTurning && IsGrounded && !IsEnemyGadget && !IsBoss)
		{
			StartCoroutine(AvoidTurnCoroutine());
		}
	}

	private IEnumerator AvoidTurnCoroutine()
	{
		isTurning = true;
		float currentMoveSpeed = MoveSpeed;
		_ = TurnSpeed;
		MoveSpeed *= 3f;
		TurnSpeed *= 3f;
		yield return new WaitForSeconds(1f);
		MoveSpeed = currentMoveSpeed;
		TurnSpeed = TurnSpeed;
		isTurning = false;
	}

	public void Weaken(bool weakened)
	{
		if (weakened)
		{
			tempDamageForWeaken = damage;
			damage *= GlobalFields.Instance.WeakenDmgMult;
			tempTrainDamageForWeaken = trainDamage;
			trainDamage *= GlobalFields.Instance.WeakenDmgMult;
			return;
		}
		if (tempDamageForWeaken != 0f)
		{
			damage = tempDamageForWeaken;
		}
		if (tempTrainDamageForWeaken != 0f)
		{
			trainDamage = tempTrainDamageForWeaken;
		}
	}

	protected virtual void OnSpawn()
	{
		if (DifficultyManager.Instance.armoredEnemyChance > 0f && UnityEngine.Random.Range(0f, 1f) <= DifficultyManager.Instance.armoredEnemyChance)
		{
			base.HealthComponent.ApplyArmor();
		}
		if (spawnSFX.clips.Count != 0 && !(UnityEngine.Random.Range(0f, 1f) > chanceForSpawnSFX))
		{
			soundBuilder.Play(spawnSFX);
		}
	}

	public void SetIdleTimer()
	{
		if (idleTimer != FirstIdleTime)
		{
			idleTimer = IdleTime;
		}
	}

	protected override void ApplySnot(float strength)
	{
		base.ApplySnot(strength);
		SnotModifier = strength;
	}

	protected override void RemoveSnot(float strength)
	{
		base.RemoveSnot(strength);
		SnotModifier = 1f;
		if ((bool)Snot)
		{
			UnityEngine.Object.Destroy(Snot);
		}
	}
}
