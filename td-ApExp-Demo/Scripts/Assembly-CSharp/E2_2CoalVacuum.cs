using System;
using System.Linq;
using UnityEngine;

public class E2_2CoalVacuum : EnemyBase
{
	[Header("Vehicle Fields")]
	[SerializeField]
	private float maxWheelAngle = 10f;

	[SerializeField]
	private float wheelSpeed = 10f;

	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float yVariation = 0.2f;

	[SerializeField]
	private float xSpeedMult = 1.5f;

	[SerializeField]
	private float ySpeedMult = 2f;

	[SerializeField]
	private Transform muzzleTF;

	[SerializeField]
	private Transform turretTF;

	[SerializeField]
	private Transform frontWheelTf;

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem leftWheelTrail;

	[SerializeField]
	private ParticleSystem rightWheelTrail;

	[SerializeField]
	private ParticleSystem leftWheelSmoke;

	[SerializeField]
	private ParticleSystem rightWheelSmoke;

	[Header("Coal Vacuum")]
	[SerializeField]
	[Tooltip("How many seconds worth of coal are sucked per second")]
	private float coalSuckAmount = 5f;

	[NonSerialized]
	public float extensionTimeElapsed;

	[SerializeField]
	public ParticleSystem suckParticles;

	[NonSerialized]
	public bool isSuckingHoseAttached;

	[SerializeField]
	private float xPosOffset = 1f;

	[SerializeField]
	private float distanceFromTrain = 0.5f;

	[SerializeField]
	private float maxSuckDistance = 0.6f;

	[SerializeField]
	private float allowedSlack = 0.1f;

	public CoalHose Hose;

	private Vector3 targetPos;

	private int suckDirectionSign = 1;

	public float ExtensionProgress { get; set; }

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[5]
		{
			new E2_2Idle(sm, this),
			new E2_2Expanding(sm, this),
			new E2_2Sucking(sm, this),
			new E2_2Retracting(sm, this),
			new E2_2EMP(sm, this)
		});
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		Target();
		targetPos = base.TargetUnit.transform.position + new Vector3(0f, distanceFromTrain * base.posSign, 0f);
		leftWheelTrail.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
		rightWheelTrail.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
		leftWheelSmoke.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		rightWheelSmoke.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
	}

	private new void Update()
	{
		if (Time.timeScale == 0f || Time.deltaTime == 0f)
		{
			return;
		}
		base.Update();
		base.Anim.SetFloat("WheelSpeed", relativeSpeedMult);
		if (IsInPosition)
		{
			switch (sm.CurrentState.Key)
			{
			case "Idle":
				sm.SwitchState(sm.states["Expanding"]);
				break;
			case "Expanding":
				sm.SwitchState(sm.states["Sucking"]);
				break;
			case "Retracting":
				sm.SwitchState(sm.states["Expanding"]);
				break;
			}
		}
		else
		{
			switch (sm.CurrentState.Key)
			{
			case "Sucking":
				sm.SwitchState(sm.states["Retracting"]);
				break;
			case "Retracting":
				sm.SwitchState(sm.states["Idle"]);
				break;
			case "Expanding":
				sm.SwitchState(sm.states["Retracting"]);
				break;
			}
		}
		if (base.TargetUnit == null && !IsHacked)
		{
			Target();
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
		Vector3 position = base.transform.position;
		float num = (float)enemyPos;
		float num2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float num3 = Mathf.PerlinNoise(Time.time, noiseSeed);
		if (IsInPosition)
		{
			num2 /= 2f;
		}
		num3 /= 2f;
		float b = Mathf.Lerp(targetPos.x - xVariation, targetPos.x + xVariation, num2);
		float b2 = (Mathf.Lerp(distanceFromTrain - yVariation, distanceFromTrain + yVariation, num3) + targetOffsetY) * num;
		float t = Time.deltaTime * base.MoveSpeed * xSpeedMult * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, b, t);
		float t2 = Time.deltaTime * base.MoveSpeed * ySpeedMult * relativeSpeedMult;
		position.y = Mathf.Lerp(position.y, b2, t2);
		if (MathF.Abs(position.y) < minY)
		{
			position.y = minY * num;
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
		rateOfChangeY = (position.y - previousPos.y) * Time.deltaTime;
		previousPos = position;
		RotateWheel(rateOfChangeY);
		IsInPosition = MathF.Abs(position.x - targetPos.x) < xVariation && Mathf.Abs(position.y) < maxSuckDistance;
	}

	public bool LeftRange()
	{
		if ((object)base.TargetUnit != null)
		{
			return Mathf.Abs(base.transform.position.y - base.TargetUnit.transform.position.y) > maxSuckDistance + allowedSlack;
		}
		return true;
	}

	private void RotateWheel(float verticalMovement)
	{
		float num = 0.1f;
		float num2 = verticalMovement / num;
		float z = base.transform.rotation.z;
		float b = num2 * maxWheelAngle;
		float z2 = Mathf.Lerp(z, b, Time.deltaTime * wheelSpeed);
		Quaternion rotation = Quaternion.Euler(0f, 0f, z2);
		frontWheelTf.rotation = rotation;
	}

	public override void Target()
	{
		if (base.IsEnemy)
		{
			base.TargetUnit = Train.Instance.Modules.FirstOrDefault((Module m) => m is ModuleFurnace);
			Hose.SetTarget(base.TargetUnit.GetComponent<Module>().ModuleSlot.GetAnchorPoint(base.transform.position.y > 0f));
		}
	}

	public override void Shoot()
	{
		if (!(shotTimer > 0f) && !base.HealthComponent.isEMPd)
		{
			shotTimer = timeBetweenShots;
			SuckCoal();
		}
	}

	private void SuckCoal()
	{
		Hose.PlaySuckingSound();
		float amount = (float)suckDirectionSign * coalSuckAmount;
		Train.Instance.DrainCoal(amount, this);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		if (IsHacked)
		{
			suckDirectionSign = -1;
		}
		else
		{
			suckDirectionSign = 1;
		}
		Hose.IsHacked = IsHacked;
	}

	protected override void OnDeath(HealthChangeInfo healthChangeInfo)
	{
		if ((bool)leftWheelSmoke && leftWheelSmoke.TryGetComponent<TireSmokeController>(out var component))
		{
			component.Detach();
		}
		if ((bool)rightWheelSmoke && rightWheelSmoke.TryGetComponent<TireSmokeController>(out var component2))
		{
			component2.Detach();
		}
		if ((bool)leftWheelTrail && leftWheelTrail.TryGetComponent<TireTrailController>(out var component3))
		{
			component3.Detach();
		}
		if ((bool)rightWheelTrail && rightWheelTrail.TryGetComponent<TireTrailController>(out var component4))
		{
			component4.Detach();
		}
		base.OnDeath(healthChangeInfo);
	}

	public override void OnChained()
	{
		base.OnChained();
		Hose.Retract();
	}
}
