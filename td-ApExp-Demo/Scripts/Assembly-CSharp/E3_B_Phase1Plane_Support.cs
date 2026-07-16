using System;
using UnityEngine;

public class E3_B_Phase1Plane_Support : E3_B_Phase1Plane
{
	[Header("Support Fields")]
	public float healAmount = 20f;

	public float healDuration = 10f;

	public float healRange = 1f;

	public float interruptHealDamage = 15f;

	public HealingBeamParticleController healingPsController;

	public float moveSpeedInHealingMode = 0.5f;

	[NonSerialized]
	public bool isInHealingMode;

	private Vector2 _targetPos = Vector2.zero;

	private Vector2 _targetOffset = Vector2.zero;

	[NonSerialized]
	public float healingTimer;

	[SerializeField]
	private SpriteRenderer planeBodySr;

	[NonSerialized]
	public float HealCycleDamageTaken;

	[field: NonSerialized]
	public float startMoveSpeed { get; private set; }

	public bool FinishedHealing => healingTimer <= 0f;

	public void ResetHealingTimer()
	{
		healingTimer = healDuration;
	}

	public new void Start()
	{
		base.Start();
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[3]
		{
			new E3_B_Support_Idle(sm, this),
			new E3_B_Support_Heal(sm, this),
			new E3_B_SupportBombardment(sm, this)
		});
		_targetPos = Train.Instance.GetRandomVisiblePosition();
		startMoveSpeed = base.MoveSpeed;
	}

	private new void Update()
	{
		base.Update();
		if (Time.deltaTime != 0f)
		{
			_ = Time.timeScale;
			_ = 0f;
		}
	}

	public override void Move()
	{
		if (Vector2.Distance(base.transform.position, Train.Instance.Wagons[0].transform.position) > 2.5f)
		{
			base.MoveSpeed = startingMoveSpeed * 3f;
		}
		else
		{
			base.MoveSpeed = startingMoveSpeed;
		}
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(_targetPos.x - xVariation, _targetPos.x + xVariation, t2);
		float b2 = Mathf.Lerp(_targetPos.y - yVariation, _targetPos.y + yVariation, t);
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed;
		position.x = Mathf.Lerp(position.x, b, t3);
		float t4 = Time.deltaTime * base.MoveSpeed;
		position.y = Mathf.Lerp(position.y, b2, t4);
		if (Train.Instance.SpeedCurrent > 0f || base.transform.position.x < -1f)
		{
			base.transform.position = position + GetPositionModifiers();
		}
		else
		{
			base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
		}
		IsInPosition = Mathf.Abs(position.x - _targetPos.x) < xVariation && Mathf.Abs(position.y - _targetPos.y) < yVariation;
		if (IsInPosition)
		{
			_targetPos = Train.Instance.GetRandomVisiblePosition();
		}
		rateOfChangeY = (position.y - previousPos.y) / Time.deltaTime;
		previousPos = position;
		TiltPlane(rateOfChangeY);
	}

	public void MoveToTarget()
	{
		if (!(base.TargetUnit == null))
		{
			Vector2 vector = (Vector2)base.TargetUnit.transform.position + _targetOffset;
			float t = Mathf.PerlinNoise(Time.time, noiseSeed);
			float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
			float b = Mathf.Lerp(vector.x - xVariation, vector.x + xVariation, t2);
			float b2 = Mathf.Lerp(vector.y - yVariation, vector.y + yVariation, t);
			Vector3 position = base.transform.position;
			float t3 = Time.deltaTime * base.MoveSpeed;
			position.x = Mathf.Lerp(position.x, b, t3);
			float t4 = Time.deltaTime * base.MoveSpeed;
			position.y = Mathf.Lerp(position.y, b2, t4);
			base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
			IsInPosition = ((Vector2)base.transform.position - vector).magnitude < healRange + 0.2f;
			rateOfChangeY = (base.transform.position.y - vector.y) / Time.deltaTime;
			previousPos = base.transform.position;
			TiltPlane(rateOfChangeY);
		}
	}

	public override void Target()
	{
		if ((bossController.attacker == null || !bossController.attacker.IsValidHealingTarget()) && (bossController.disrupter == null || !bossController.disrupter.IsValidHealingTarget()))
		{
			base.TargetUnit = null;
			return;
		}
		if ((bossController.attacker != null || bossController.attacker.IsValidHealingTarget()) && (bossController.disrupter == null || !bossController.disrupter.IsValidHealingTarget()))
		{
			base.TargetUnit = bossController.attacker;
		}
		else if ((bossController.attacker == null || !bossController.attacker.IsValidHealingTarget()) && (bossController.attacker != null || bossController.disrupter.IsValidHealingTarget()))
		{
			base.TargetUnit = bossController.disrupter;
		}
		else
		{
			base.TargetUnit = ((bossController.attacker.HealthComponent.HealthMissing < bossController.disrupter.HealthComponent.HealthMissing) ? ((E3_B_Phase1Plane)bossController.disrupter) : ((E3_B_Phase1Plane)bossController.attacker));
		}
		if ((bool)base.TargetUnit)
		{
			Vector2 vector = base.TargetUnit.transform.position - base.transform.position;
			float num = ((vector.x >= 0f && vector.y >= 0f) ? UnityEngine.Random.Range(0f, 90f) : ((vector.x < 0f && vector.y >= 0f) ? UnityEngine.Random.Range(90f, 180f) : ((!(vector.x < 0f) || !(vector.y < 0f)) ? UnityEngine.Random.Range(270f, 360f) : UnityEngine.Random.Range(180f, 270f))));
			_targetOffset = new Vector3(Mathf.Cos(num * (MathF.PI / 180f)) * healRange, Mathf.Sin(num * (MathF.PI / 180f)) * healRange, 0f);
		}
	}

	public override void Aim()
	{
		if (!(base.TargetUnit == null))
		{
			rotator.RotateComponentTowardsPosition(turret1TF, base.TargetUnit.transform.position, 160f);
		}
	}

	public override void Shoot()
	{
	}

	public void StartHealingParticles()
	{
		if (!(base.TargetUnit == null) && !healingPsController.gameObject.activeSelf)
		{
			healingPsController.gameObject.SetActive(value: true);
			healingPsController.SetTarget(base.TargetUnit.transform);
			healingPsController.StartBeam();
		}
	}

	public void StopHealingParticles()
	{
		if ((bool)healingPsController)
		{
			healingPsController.StopBeam();
			healingPsController.gameObject.SetActive(value: false);
		}
	}

	public void Heal(bool noTick = false)
	{
		if (Time.deltaTime != 0f && Time.timeScale != 0f && !(base.TargetUnit == null))
		{
			if (!noTick)
			{
				TickHeal();
			}
			base.TargetUnit.HealthComponent.Heal(healAmount / healDuration * Time.deltaTime, this);
			if (base.TargetUnit.HealthComponent.HealthCurrent >= base.TargetUnit.HealthComponent.HealthMax)
			{
				base.TargetUnit = null;
				StopHealingParticles();
			}
		}
	}

	public bool TickHeal()
	{
		return (healingTimer -= Time.deltaTime) <= 0f;
	}

	protected override void OnHealthChanged(HealthChangeInfo info)
	{
		base.OnHealthChanged(info);
		if (isInHealingMode)
		{
			HealCycleDamageTaken -= info.HealthChange;
			if (HealCycleDamageTaken >= interruptHealDamage)
			{
				healingTimer = 0f;
				HealCycleDamageTaken = 0f;
			}
		}
	}

	public void HealMode(bool isOn)
	{
		if (isOn)
		{
			isInHealingMode = true;
		}
		else
		{
			isInHealingMode = false;
		}
	}
}
