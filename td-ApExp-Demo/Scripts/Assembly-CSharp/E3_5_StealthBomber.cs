using System;
using UnityEngine;

public class E3_5_StealthBomber : EnemyBase
{
	[Header("Stealth Bomber Fields")]
	public float stealthTime;

	public float unstealthTime;

	[Header("Flight Fields")]
	[SerializeField]
	private float xVariation = 0.5f;

	[SerializeField]
	private float yVariation = 0.5f;

	[SerializeField]
	private Transform muzzleTF1;

	[SerializeField]
	private Transform muzzleTF2;

	private Vector3 targetPos;

	[NonSerialized]
	public bool ShotFired;

	[NonSerialized]
	public bool hasStealthed;

	[NonSerialized]
	public bool hasUnstealthed;

	private Shadow Shadow;

	[Header("Thrusters")]
	[SerializeField]
	private ParticleSystem thruster1;

	[SerializeField]
	private ParticleSystem thruster2;

	[field: NonSerialized]
	public Rotator Rotator { get; private set; }

	private new void Awake()
	{
		base.Awake();
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
		Rotator = base.gameObject.GetComponent<Rotator>();
	}

	private new void Start()
	{
		base.Start();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[4]
		{
			new E3_5_Enter(sm, this),
			new E3_5_Idle(sm, this),
			new E3_5_Attack(sm, this),
			new E3_5_EMPState(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
		Shadow = GetComponent<Shadow>();
		Stealthed();
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
		}
	}

	private new void FixedUpdate()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.FixedUpdate();
		}
	}

	public override void Move()
	{
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(targetPos.x - xVariation, targetPos.x + xVariation, t2);
		float b2 = Mathf.Lerp(targetPos.y - yVariation, targetPos.y + yVariation, t) + targetOffsetY;
		Vector3 position = base.transform.position;
		float num = base.MoveSpeed;
		if (IsInPosition)
		{
			num *= 0.3f;
		}
		float t3 = Time.deltaTime * num * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, b, t3);
		float t4 = Time.deltaTime * num * relativeSpeedMult;
		position.y = Mathf.Lerp(position.y, b2, t4);
		if (Train.Instance.SpeedCurrent > 0f || base.transform.position.x < -1f)
		{
			base.transform.position = position + GetPositionModifiers();
		}
		else
		{
			base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
		}
		IsInPosition = Mathf.Abs(position.x - targetPos.x) < xVariation && Mathf.Abs(position.y - targetPos.y) < yVariation;
	}

	public void SetNewTargetPos()
	{
		float num = ((UnityEngine.Random.Range(0f, 2f) > 1f) ? 1f : (-1f));
		float num2 = UnityEngine.Random.Range(PlayerManager.Instance.Players[0].transform.position.x - 2f, PlayerManager.Instance.Players[0].transform.position.x + 1.4f);
		if (num == base.posSignTf)
		{
			num2 = Mathf.Clamp(base.transform.position.x + num2, PlayerManager.Instance.Players[0].transform.position.x - 2f, PlayerManager.Instance.Players[0].transform.position.x + 1.4f);
		}
		targetPos = new Vector3(num2, UnityEngine.Random.Range(minY, maxY) * num);
	}

	public void Stealth()
	{
		base.Anim.Play("Stealth");
		hasUnstealthed = false;
	}

	public void Unstealth()
	{
		base.Anim.Play("Unstealth");
		hasStealthed = false;
		Shadow.SetShadowOpacity(GameManager.Instance.shadowColor.a);
		soundBuilder.Play(shootSound);
	}

	public override void Shoot()
	{
		if (!ShotFired)
		{
			ShotFired = true;
			GameObject obj = UnityEngine.Object.Instantiate(bullet, muzzleTF1.position, muzzleTF1.rotation);
			GameObject gameObject = UnityEngine.Object.Instantiate(bullet, muzzleTF2.position, muzzleTF2.rotation);
			APCMissile component = obj.GetComponent<APCMissile>();
			component.IsEnemy = base.IsEnemy;
			component.TargetUnit = UnitHelper.GetRandomLiveEnemyUnit(this);
			component.parentEnemy = this;
			APCMissile component2 = gameObject.GetComponent<APCMissile>();
			component2.IsEnemy = base.IsEnemy;
			component2.TargetUnit = UnitHelper.GetRandomLiveEnemyUnit(this);
			component2.parentEnemy = this;
		}
	}

	public override void Hack(bool isHacked)
	{
		base.Hack(isHacked);
		if (isHacked)
		{
			sm.ForceState("Attack");
		}
	}

	public void Stealthed()
	{
		hasStealthed = true;
		Shadow.SetShadowOpacity(0f);
		if (enemyUI != null)
		{
			enemyUI.HideUI(hide: true);
		}
		thruster1.gameObject.SetActive(value: false);
		thruster2.gameObject.SetActive(value: false);
		ignoreProjectiles = true;
	}

	public void Unstealthed()
	{
		hasUnstealthed = true;
		if (enemyUI != null)
		{
			enemyUI.HideUI(hide: false);
		}
		ignoreProjectiles = false;
	}

	public void StartUnstealthing()
	{
		thruster1.gameObject.SetActive(value: true);
		thruster2.gameObject.SetActive(value: true);
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		base.OnDeath(info);
	}
}
