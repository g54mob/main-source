using System;
using UnityEngine;

public class E2_B_HealDrone : EnemyBase
{
	[Header("ID")]
	public int id;

	[Header("Body")]
	[SerializeField]
	private Transform cannonTf;

	[SerializeField]
	private Transform muzzleTf;

	[Header("Healing")]
	[SerializeField]
	public float healTime;

	[SerializeField]
	public float healAmount;

	[SerializeField]
	private float healingDistanceBuffer;

	[SerializeField]
	private HealingBeamParticleController healingPsController;

	[Header("Movement")]
	[SerializeField]
	private float xVariation;

	[SerializeField]
	private float yVariation;

	[NonSerialized]
	public bool targetEnteredRange;

	[NonSerialized]
	public bool targetLeftRange;

	private float healTimer;

	private Transform targetTf;

	private Unit originalTarget;

	private Transform originalTargetTf;

	private new void Awake()
	{
		base.Awake();
		noiseSeed = UnityEngine.Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[3]
		{
			new E2_B_HD_Idle(sm, this),
			new E2_B_HD_Healing(sm, this),
			new BEMPState(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			Debug.Log(sm.CurrentState);
			sm.UpdateStates();
			if (targetTf != null)
			{
				Aim();
				Move();
			}
		}
	}

	public void SetTargetTf(Transform target)
	{
		targetTf = target;
	}

	public void SetTarget(Unit target)
	{
		base.TargetUnit = target;
	}

	public override void Move()
	{
		_ = (float)enemyPos;
		Vector3 position = targetTf.position;
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(position.x - xVariation, position.x + xVariation, t);
		float b2 = Mathf.Lerp(position.y - yVariation, position.y + yVariation, t2);
		Vector3 position2 = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed;
		position2.x = Mathf.Lerp(position2.x, b, t3);
		float t4 = Time.deltaTime * base.MoveSpeed;
		position2.y = Mathf.Lerp(position2.y, b2, t4);
		base.transform.position = position2;
		targetEnteredRange = (base.transform.position - base.TargetUnit.transform.position).magnitude <= healingDistanceBuffer;
		targetLeftRange = (base.transform.position - base.TargetUnit.transform.position).magnitude >= healingDistanceBuffer + 0.5f;
		IsInPosition = Mathf.Abs(base.transform.position.x - position.x) <= xVariation && Mathf.Abs(base.transform.position.y - position.y) <= yVariation;
	}

	public override void Aim()
	{
		if (!(base.TargetUnit == null))
		{
			Vector3 upwards = base.TargetUnit.transform.position - muzzleTf.position;
			cannonTf.rotation = Quaternion.LookRotation(Vector3.forward, upwards);
		}
	}

	public void Heal(bool noTick = false)
	{
		if (Time.deltaTime != 0f && Time.timeScale != 0f)
		{
			if (!noTick)
			{
				TickHeal();
			}
			if (!(base.TargetUnit == null) && !(healTimer > 0f) && IsInPosition && CheckIsTargetHealable())
			{
				healTimer = healTime;
				base.TargetUnit.HealthComponent.Heal(healAmount, this);
			}
		}
	}

	public bool TickHeal()
	{
		return (healTimer -= Time.deltaTime) <= 0f;
	}

	public bool CheckIsTargetHealable()
	{
		return base.TargetUnit.HealthComponent.HealthMissing > 0f;
	}

	public void StartHealingParticles()
	{
		healingPsController.SetTarget(base.TargetUnit.transform);
		healingPsController.StartBeam();
	}

	public void StopHealingParticles()
	{
		healingPsController.StopBeam();
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		StopHealingParticles();
		base.OnDeath(info);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		if (IsHacked)
		{
			originalTarget = base.TargetUnit;
			originalTargetTf = targetTf;
			Module randomModule = Train.Instance.GetRandomModule();
			SetTarget(randomModule);
			SetTargetTf(randomModule.transform);
			sm.ForceState("Idle");
		}
		else
		{
			SetTarget(originalTarget);
			SetTargetTf(originalTargetTf);
			sm.ForceState("Idle");
		}
	}
}
