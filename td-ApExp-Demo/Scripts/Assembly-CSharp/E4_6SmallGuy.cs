using System;
using UnityEngine;

public class E4_6SmallGuy : EnemyBase
{
	[Header("Small Guy Fields")]
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
	private E4_6BigGuy bigGuy;

	[SerializeField]
	private int burnAmount;

	[NonSerialized]
	public bool bigGuyDead;

	[field: SerializeField]
	public GameObject RopeGo { get; private set; }

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[2]
		{
			new E4_6Idle_SmallGuy(sm, this),
			new BEMPState(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		Target();
		base.transform.localScale = new Vector3(1f, (float)enemyPos, 1f);
		turretTF.localScale = new Vector3((float)enemyPos, (float)enemyPos, 1f);
		Burn = burnAmount;
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			base.Anim.SetFloat("WheelSpeed", bigGuy.relativeSpeedMult);
			CheckTarget();
		}
	}

	private new void FixedUpdate()
	{
		base.FixedUpdate();
		if (bigGuy == null || bigGuy.HealthComponent == null || bigGuy.HealthComponent.IsDead)
		{
			Stay();
			if (base.transform.position.x <= -5f)
			{
				KillSelf();
				bigGuy.KillSelf();
			}
		}
		else
		{
			Move();
		}
	}

	public override void Move()
	{
		Vector3 position = base.transform.position;
		float num = 0.1f;
		float num2 = 2f;
		float num3 = Mathf.Sin(Time.time * num2) * num;
		position.y += num3 * Time.deltaTime * bigGuy.relativeSpeedMult;
		base.transform.position = position;
		rateOfChangeY = (position.y - previousPos.y) / Time.deltaTime;
		previousPos = position;
	}

	public void Stay()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = new Vector3(position.x - Train.Instance.SpeedCurrent * Time.deltaTime, position.y, position.z);
		base.transform.position = position2;
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
		if (!(base.TargetUnit == null) && !(shotTimer > 0f))
		{
			shotTimer = base.TimeBetweenShots;
			gunAnim.Play("BikerGunFire");
			Projectile component = UnityEngine.Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation).GetComponent<Projectile>();
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
		if (bigGuy != null && bigGuy.HealthComponent != null && !bigGuy.HealthComponent.IsDead)
		{
			bigGuy.Enrage();
		}
		base.OnDeath(info);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
	}

	public void BigGuyDied()
	{
		bigGuyDead = true;
	}
}
