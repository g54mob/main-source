using System.Collections.Generic;
using System.Linq;
using AudioSystem;
using UnityEngine;

public class E2_5Sacrificer : EnemyBase
{
	[Header("Special SFX")]
	[SerializeField]
	private SoundData chargeSound;

	[SerializeField]
	private SoundData cheeseBiteSound;

	[SerializeField]
	private SoundData bloodSplatterSound;

	[SerializeField]
	private SoundData alternativeEngineSound;

	[Header("Movement Fields")]
	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float ySpeedMult = 10f;

	[SerializeField]
	private Transform muzzleTF;

	[Header("Trail and Smoke")]
	[Header("Sacrificer fields")]
	[SerializeField]
	private Transform headTf;

	[SerializeField]
	private Transform bodyTf;

	[SerializeField]
	private Transform capeTf;

	[SerializeField]
	private Transform tailTf;

	[SerializeField]
	private SpriteRenderer bodySr;

	[SerializeField]
	private SpriteRenderer transitionSr;

	[SerializeField]
	private float initialDelay = 3f;

	[SerializeField]
	private float castingTime = 6f;

	[SerializeField]
	private float transitionTime = 6f;

	[SerializeField]
	private float castingDamageReductionPercent = 90f;

	[SerializeField]
	private int maxEnemiesToSacrifice = 5;

	[SerializeField]
	private float maxSacrificeRange = 2f;

	[SerializeField]
	private float healthBuffPerEnemy = 3f;

	[SerializeField]
	private float damageBuffPerEnemy = 1f;

	[SerializeField]
	private GameObject chargingBeamParticlePrafab;

	[SerializeField]
	private float fireRate = 2f;

	[SerializeField]
	private float baseShots = 3f;

	private int sacrificedEnemies;

	private int bulletsFired;

	private float enterTimer;

	private float chargingTimer;

	private float transitionTimer;

	private List<EnemyBase> enemiesToSacrifice;

	private List<SacrificerBeamParticleController> chargingParticles;

	private bool shotsFired;

	public bool CompletedSacrifice { get; private set; }

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[5]
		{
			new E2_5Entering(sm, this),
			new E2_5Charging(sm, this),
			new E2_5Sacrifice(sm, this),
			new E2_5Idle(sm, this),
			new E2_5EMP(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
		noiseSeed = Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		shotsFired = true;
		Target();
		chargingParticles = new List<SacrificerBeamParticleController>();
		float num = ((base.transform.position.y > 0f) ? 1 : (-1));
		base.transform.localScale = new Vector3(1f, 0f - num, 1f);
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			base.Anim.SetFloat("WheelSpeed", relativeSpeedMult);
			CheckTarget();
		}
	}

	protected new void FixedUpdate()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.FixedUpdate();
			Move();
		}
	}

	public override void Move()
	{
		Vector3 vector = ((!(base.TargetUnit == null)) ? base.TargetUnit.transform.position : Vector3.zero);
		float num = (float)enemyPos;
		float num2 = Train.Instance.Wagons[0].transform.position.y * num;
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = (Mathf.Lerp(minY + num2, maxY + num2, t) + targetOffsetY) * num;
		float b2 = Mathf.Lerp(vector.x - xVariation, vector.x + xVariation, t2);
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, b2, t3);
		float t4 = Time.deltaTime * base.MoveSpeed * ySpeedMult * relativeSpeedMult;
		position.y = Mathf.Lerp(position.y, b, t4);
		if ((num == 1f && position.y < minY) || (num == -1f && position.y > minY))
		{
			position.y = minY;
		}
		if (Train.Instance.SpeedCurrent > 0f || base.transform.position.x < -1f)
		{
			base.transform.position = position + GetPositionModifiers();
		}
		else
		{
			base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
		}
		base.Move();
		IsInPosition = position.x < vector.x + xVariation && position.x > vector.x - xVariation && position.y * num > minY && position.y * num < maxY;
	}

	public override void Target()
	{
		if (!IsHacked)
		{
			base.TargetUnit = GetRandomModule();
		}
		else
		{
			base.TargetUnit = UnitHelper.GetRandomEnemyUnit(this);
		}
	}

	private Module GetRandomModule()
	{
		Module[] array = Train.Instance.Modules.Where((Module m) => (bool)m && m != base.TargetUnit).ToArray();
		if (array != null)
		{
			return array[Random.Range(0, array.Length)];
		}
		return null;
	}

	public override void Aim()
	{
		float num = ((!(base.transform.position.y > 0f)) ? 1 : (-1));
		Vector3 upwards = num * base.TargetUnit.transform.position - num * base.transform.position;
		Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
		bodyTf.transform.rotation = Quaternion.RotateTowards(bodyTf.transform.rotation, to, Time.deltaTime * 60f);
		headTf.transform.rotation = Quaternion.RotateTowards(headTf.transform.rotation, to, Time.deltaTime * 60f);
	}

	public override void Shoot()
	{
		if (!(base.TargetUnit == null) && !(shotTimer > 0f) && IsInPosition)
		{
			shotTimer = timeBetweenShots;
			shotsFired = true;
			bulletsFired = 0;
			base.Anim.SetTrigger("Shoot");
		}
	}

	private void SpawnBullet()
	{
		if ((float)bulletsFired <= (float)sacrificedEnemies + baseShots)
		{
			bulletsFired++;
			Vector3 upwards = base.TargetUnit.transform.position - muzzleTF.position;
			Quaternion rotation = Quaternion.LookRotation(Vector3.forward, upwards);
			Projectile component = Object.Instantiate(bullet, muzzleTF.position, rotation).GetComponent<Projectile>();
			component.ProjectileHit += base.OnTargetDamaged;
			component.sourceUnit = this;
			component.speed = projSpeed;
			component.damage = damage;
			component.GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.005f), new Keyframe(0.5f, 0f));
			component.transform.Find("Outline").GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.02f), new Keyframe(0.5f, 0f));
			soundBuilder.Play(shootSound);
		}
		else
		{
			base.Anim.SetTrigger("StopShooting");
			Target();
		}
	}

	public void StartCastingAnim()
	{
		base.Anim.SetTrigger("StartCasting");
		soundBuilder.Play(cheeseBiteSound);
		soundBuilder.Play(chargeSound);
	}

	public void StopCastingAnim()
	{
		base.Anim.SetTrigger("StopCasting");
		soundBuilder.FindAndStop(cheeseBiteSound);
		soundBuilder.FindAndStop(chargeSound);
	}

	public void StartTransition()
	{
		base.Anim.SetTrigger("StartTransition");
	}

	public void DoTransition()
	{
		base.Anim.SetTrigger("DoTransition");
		headTf.gameObject.SetActive(value: true);
		capeTf.gameObject.SetActive(value: true);
		tailTf.gameObject.SetActive(value: false);
		soundBuilder.FindAndStop(engineSound);
		soundBuilder.Play(alternativeEngineSound);
	}

	public void ResetEnterTimer()
	{
		enterTimer = initialDelay;
	}

	public void ResetChargingTimer()
	{
		chargingTimer = castingTime;
	}

	public bool EnterTimerTick()
	{
		return (enterTimer -= Time.deltaTime) <= 0f;
	}

	public bool ChargingTimerTick()
	{
		return (chargingTimer -= Time.deltaTime) <= 0f;
	}

	public void ResetTransitionTimer()
	{
		transitionTimer = transitionTime;
	}

	public bool TransitionTimerTick()
	{
		return (transitionTimer -= Time.deltaTime) <= 0f;
	}

	public void ApplyDamageReduction()
	{
		base.HealthComponent.DamageReductionPercent = castingDamageReductionPercent;
	}

	public void ChoseEnemiesToSacrifice()
	{
		enemiesToSacrifice = new List<EnemyBase>();
		foreach (EnemyBase enemy in EnemyManager.Instance.Enemies)
		{
			if ((object)enemy != null && !enemy.HealthComponent.IsDead && !(enemy is EnemyComponent) && !(enemy == this))
			{
				if ((enemy.transform.position - base.transform.position).magnitude <= maxSacrificeRange)
				{
					GameObject obj = Object.Instantiate(chargingBeamParticlePrafab, enemy.transform);
					obj.transform.localPosition = Vector3.zero;
					SacrificerBeamParticleController component = obj.GetComponent<SacrificerBeamParticleController>();
					component.SetTarget(base.transform);
					chargingParticles.Add(component);
					enemiesToSacrifice.Add(enemy);
				}
				if (enemiesToSacrifice.Count >= maxEnemiesToSacrifice)
				{
					break;
				}
			}
		}
	}

	public void Sacrifice()
	{
		CompletedSacrifice = true;
		int num = 0;
		foreach (EnemyBase item in enemiesToSacrifice)
		{
			if (item != null)
			{
				num++;
			}
		}
		if (num > 0)
		{
			soundBuilder.Play(bloodSplatterSound);
		}
		sacrificedEnemies = num;
		float maxHealthToAdd = (float)num * healthBuffPerEnemy;
		float num2 = (float)num * damageBuffPerEnemy;
		base.HealthComponent.DamageReductionPercent = 0f;
		base.HealthComponent.ChangeMaxHealthBy(maxHealthToAdd);
		damage += num2;
		foreach (EnemyBase item2 in enemiesToSacrifice)
		{
			if (item2 != null)
			{
				item2?.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(this, item2.HealthComponent, -10000f, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
			}
		}
		while (chargingParticles.Count > 0)
		{
			if ((bool)chargingParticles[0])
			{
				chargingParticles[0].DestroyAfterDelay(0f);
			}
			chargingParticles.RemoveAt(0);
		}
		enemiesToSacrifice.Clear();
	}

	public void InterruptSacrifice()
	{
		StopCastingAnim();
		while (chargingParticles.Count > 0)
		{
			chargingParticles[0].DestroyAfterDelay(1f);
			chargingParticles.RemoveAt(0);
		}
		enemiesToSacrifice.Clear();
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		foreach (SacrificerBeamParticleController chargingParticle in chargingParticles)
		{
			if ((bool)chargingParticle)
			{
				chargingParticle.OnSourceDied();
			}
		}
		base.OnDeath(info);
	}

	public override void OnEMPEnd()
	{
		if ((bool)base.HealthComponent)
		{
			base.HealthComponent.isEMPd = false;
		}
		Object.Destroy(base.StunPsGo);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
	}
}
