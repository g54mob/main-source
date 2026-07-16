using System;
using System.Linq;
using UnityEngine;

public class E2_8MedDart : EnemyBase
{
	[Header("Movement Fields")]
	[SerializeField]
	private float maxWheelAngle = 10f;

	[SerializeField]
	private float wheelSpeed = 10f;

	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float yVariation = 1f;

	[SerializeField]
	private float ySpeedMult = 10f;

	[SerializeField]
	private Transform frontWheel1Tf;

	[SerializeField]
	private Transform frontWheel2Tf;

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem leftWheelTrail;

	[SerializeField]
	private ParticleSystem rightWheelTrail;

	[SerializeField]
	private ParticleSystem leftWheelSmoke;

	[Header("Med Dart Fields")]
	[SerializeField]
	private float healAmount;

	[SerializeField]
	private float healTime;

	[SerializeField]
	private float distanceToTarget;

	[SerializeField]
	private float healingDistanceBuffer;

	[SerializeField]
	private GameObject healingPsGO;

	private HealingBeamParticleController healingPsController;

	private float healingTimer;

	private bool hasHealableTarget;

	private float prefferedSideFromTargetSign = 1f;

	[NonSerialized]
	public bool targetEnteredRange;

	[NonSerialized]
	public bool targetLeftRange;

	public bool HasHealableTarget => hasHealableTarget;

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[3]
		{
			new E2_8Idle(sm, this),
			new E2_8Heal(sm, this),
			new E2_8EMP(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		Target();
		leftWheelSmoke.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
		leftWheelTrail.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
		rightWheelTrail.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
		healingPsController = healingPsGO.GetComponent<HealingBeamParticleController>();
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			base.Anim.SetFloat("WheelSpeed", relativeSpeedMult);
		}
	}

	public override void Move()
	{
		float num = (float)enemyPos;
		Vector3 zero = Vector3.zero;
		if (base.TargetUnit == null)
		{
			zero = new Vector3(Mathf.Clamp(UnityEngine.Random.Range(base.transform.position.x - 0.1f, base.transform.position.x + 0.1f), -2f, 2f), UnityEngine.Random.Range(minY, maxY) * base.posSign);
		}
		else
		{
			Vector3 vector = new Vector3(0f, distanceToTarget * prefferedSideFromTargetSign, 0f);
			zero = base.TargetUnit.transform.position + vector;
		}
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(zero.x - xVariation, zero.x + xVariation, t);
		float b2 = Mathf.Lerp(zero.y - yVariation, zero.y + yVariation, t2);
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, b, t3);
		float t4 = Time.deltaTime * base.MoveSpeed * ySpeedMult * relativeSpeedMult;
		position.y = Mathf.Lerp(position.y, b2, t4);
		if (Mathf.Abs(position.y) < minY)
		{
			position.y = minY * num;
		}
		Debug.DrawLine(base.transform.position, position + GetPositionModifiers(), Color.white, 0.05f);
		if (Train.Instance.SpeedCurrent > 0f || base.transform.position.x < -1f)
		{
			base.transform.position = position + GetPositionModifiers();
		}
		else
		{
			base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
		}
		base.Move();
		targetEnteredRange = base.TargetUnit != null && (base.transform.position - base.TargetUnit.transform.position).magnitude <= healingDistanceBuffer;
		targetLeftRange = !(base.TargetUnit != null) || (base.transform.position - base.TargetUnit.transform.position).magnitude >= healingDistanceBuffer + 0.15f;
		IsInPosition = Mathf.Abs(base.transform.position.x - zero.x) <= xVariation && Mathf.Abs(base.transform.position.y - zero.y) <= yVariation;
		rateOfChangeY = (position.y - previousPos.y) / Time.deltaTime;
		previousPos = position;
		RotateWheel(rateOfChangeY);
	}

	private void RotateWheel(float verticalMovement)
	{
		float num = 0.1f;
		float num2 = verticalMovement / num;
		float z = base.transform.rotation.z;
		float b = num2 * maxWheelAngle;
		float z2 = Mathf.Lerp(z, b, Time.deltaTime * wheelSpeed);
		Quaternion rotation = Quaternion.Euler(0f, 0f, z2);
		frontWheel1Tf.rotation = rotation;
		frontWheel2Tf.rotation = rotation;
	}

	public void Heal(bool noTick = false)
	{
		if (Time.deltaTime != 0f && Time.timeScale != 0f)
		{
			if (!noTick)
			{
				TickHeal();
			}
			if (!(base.TargetUnit == null) || (!(healingTimer > 0f) && IsInPosition && CheckIsTargetHealable()))
			{
				healingTimer = healTime;
				base.TargetUnit.HealthComponent.Heal(healAmount, this);
			}
		}
	}

	public bool TickHeal()
	{
		return (healingTimer -= Time.deltaTime) <= 0f;
	}

	public override void Target()
	{
		if (IsHacked)
		{
			TryTargetTrain();
		}
		else
		{
			TryTargetEnemy();
		}
	}

	private void TryTargetEnemy()
	{
		EnemyBase[] sameSideEnemies = EnemyManager.Instance.Enemies.Where((EnemyBase e) => Mathf.Sign(e.transform.position.y) == Mathf.Sign(base.transform.position.y) && e != this).ToArray();
		if (sameSideEnemies == null || sameSideEnemies.Length == 0)
		{
			sm.ForceState("Exit");
			return;
		}
		EnemyBase enemyBase = sameSideEnemies.First((EnemyBase e) => e.HealthComponent.HealthMissing == sameSideEnemies.Max((EnemyBase s) => s.HealthComponent.HealthMissing));
		if (enemyBase != base.TargetUnit)
		{
			base.TargetUnit = enemyBase;
			SetPrefferedSideFromTarget();
		}
		if (base.TargetUnit.HealthComponent.HealthMissing == 0f)
		{
			base.TargetUnit = null;
		}
	}

	private void TryTargetTrain()
	{
		Module module = Train.Instance.Modules.Where((Module m) => (bool)m && m.HealthComponent.HealthMissing > 0f).FirstOrDefault();
		if ((object)module != null)
		{
			base.TargetUnit = module;
		}
		else
		{
			base.TargetUnit = null;
		}
	}

	private void SetPrefferedSideFromTarget()
	{
		if (!(base.TargetUnit == null))
		{
			float num = ((!(base.transform.position.y < 0f)) ? 1 : (-1));
			if (Mathf.Abs(base.TargetUnit.transform.position.y) + distanceToTarget > maxY)
			{
				prefferedSideFromTargetSign = 0f - num;
			}
			else if (Mathf.Abs(base.TargetUnit.transform.position.y) - distanceToTarget < minY)
			{
				prefferedSideFromTargetSign = num;
			}
			else
			{
				prefferedSideFromTargetSign = (((double)UnityEngine.Random.Range(0f, 1f) > 0.5) ? 1 : (-1));
			}
		}
	}

	public bool CheckIsTargetHealable()
	{
		if (base.TargetUnit != null)
		{
			return hasHealableTarget = base.TargetUnit.HealthComponent.HealthMissing > 0f;
		}
		return false;
	}

	public void StartHealingParticles()
	{
		healingPsGO.SetActive(value: true);
		healingPsController.SetTarget(base.TargetUnit.transform);
		healingPsController.StartBeam();
	}

	public void StopHealingParticles()
	{
		healingPsController.StopBeam();
		healingPsGO.SetActive(value: false);
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		StopHealingParticles();
		if (leftWheelSmoke.TryGetComponent<TireSmokeController>(out var component))
		{
			component.Detach();
		}
		if (leftWheelTrail.TryGetComponent<TireTrailController>(out var component2))
		{
			component2.Detach();
		}
		if (rightWheelTrail.TryGetComponent<TireTrailController>(out var component3))
		{
			component3.Detach();
		}
		base.OnDeath(info);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
	}
}
