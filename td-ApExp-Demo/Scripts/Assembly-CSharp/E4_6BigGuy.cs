using System.Collections.Generic;
using UnityEngine;

public class E4_6BigGuy : EnemyBase
{
	[Header("Big Guy Fields")]
	[SerializeField]
	private float maxWheelAngle = 10f;

	[SerializeField]
	private float wheelSpeed = 10f;

	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float ySpeedMult = 10f;

	[SerializeField]
	private Transform muzzleTF;

	[SerializeField]
	private Transform turretTF;

	[SerializeField]
	private Transform frontWheelTf;

	[SerializeField]
	private Animator gunAnim;

	[SerializeField]
	private Animator transformAnim;

	[SerializeField]
	[Range(0f, 100f)]
	private float damageReductionPercent;

	[SerializeField]
	private List<SpriteRenderer> srs;

	[Header("Enrage Fields")]
	[SerializeField]
	private float enragedRateOfFireModifier;

	[SerializeField]
	private float enragedEnemyDamage;

	[SerializeField]
	private float enragedTrainDamage;

	private bool isEnraged;

	[field: SerializeField]
	public E4_6SmallGuy SmallGuy { get; private set; }

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[3]
		{
			new E4_6Idle(sm, this),
			new E4_6Dead(sm, this),
			new BEMPState(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
		previousPos = base.transform.position;
		noiseSeed = Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		Target();
		base.transform.localScale = new Vector3(1f, (float)enemyPos, 1f);
		turretTF.localScale = new Vector3((float)enemyPos, (float)enemyPos, 1f);
		EnemyManager.Instance.RegisterEnemy(SmallGuy);
		base.HealthComponent.DamageReductionPercent = damageReductionPercent;
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

	public override void Move()
	{
		Vector3 vector = ((!(base.TargetUnit == null)) ? base.TargetUnit.transform.position : Vector3.zero);
		float num = (float)enemyPos;
		float num2 = Train.Instance.Wagons[0].transform.position.y * num;
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(vector.x - xVariation, vector.x + xVariation, t2);
		float b2 = (Mathf.Lerp(minY + num2, maxY + num2, t) + targetOffsetY) * num;
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, b, t3);
		float t4 = Time.deltaTime * base.MoveSpeed * ySpeedMult * relativeSpeedMult;
		position.y = Mathf.Lerp(position.y, b2, t4);
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
		rateOfChangeY = (position.y - previousPos.y) / Time.deltaTime;
		previousPos = position;
	}

	public override void Aim()
	{
		Vector3 position = base.TargetUnit.transform.position;
		Vector3 upwards = new Vector3(base.TargetUnit.transform.position.x, position.y) - base.transform.position;
		Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
		turretTF.transform.rotation = Quaternion.RotateTowards(turretTF.transform.rotation, to, Time.deltaTime * 60f);
	}

	public override void Shoot()
	{
		if (!(base.TargetUnit == null) && !(shotTimer > 0f) && IsInPosition)
		{
			shotTimer = base.TimeBetweenShots;
			if (!isEnraged)
			{
				gunAnim.Play("BigGuyCannonShoot");
			}
			else
			{
				gunAnim.Play("BigGuyCannonEnragedShoot");
			}
			Projectile component = Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation).GetComponent<Projectile>();
			component.ProjectileHit += base.OnTargetDamaged;
			component.sourceUnit = this;
			component.speed = projSpeed;
			component.isEnemyProjectile = base.IsEnemy;
			component.burn = Burn;
			if (base.IsEnemy)
			{
				component.damage = base.TrainDamage;
			}
			else
			{
				component.damage = base.EnemyDamage;
			}
			component.GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.005f), new Keyframe(0.5f, 0f));
			component.transform.Find("Outline").GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.02f), new Keyframe(0.5f, 0f));
			soundBuilder.Play(shootSound);
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		if (SmallGuy == null || SmallGuy.HealthComponent == null || SmallGuy.HealthComponent.IsDead)
		{
			base.OnDeath(info);
		}
		else if ((bool)SmallGuy && !alreadyDied)
		{
			alreadyDied = true;
			GetComponent<ExplodeSprite>()?.Explode();
			if (deathSFX.clips.Count != 0 && Random.Range(0f, 1f) > chanceForSpawnSFX)
			{
				soundBuilder.Play(deathSFX);
			}
			SmallGuy.BigGuyDied();
			Dead();
		}
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
	}

	public void Enrage()
	{
		isEnraged = true;
		RofModifier += enragedRateOfFireModifier;
		shotTimer = 0f;
		trainDamage = enragedTrainDamage;
		damage = enragedEnemyDamage;
		base.HealthComponent.DamageReductionPercent = 0f;
		base.Anim.Play("BigGuyEnraged");
		transformAnim.Play("BigGuyTransform");
	}

	public void Dead()
	{
		foreach (SpriteRenderer sr in srs)
		{
			sr.enabled = false;
		}
		GetComponent<Shadow>().SetShadowOpacity(0f);
		Object.Destroy(SmallGuy.RopeGo);
	}
}
