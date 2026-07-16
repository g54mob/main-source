using System.Linq;
using UnityEngine;

public class E2_6MolotovBiker : EnemyBase
{
	[Header("Movement Fields")]
	[SerializeField]
	private float maxWheelAngle = 10f;

	[SerializeField]
	private float wheelSpeed = 10f;

	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float ySpeedMult = 2f;

	[SerializeField]
	private Transform muzzleTF;

	[SerializeField]
	private Transform turretTF;

	[SerializeField]
	private Transform headTF;

	[SerializeField]
	private Transform frontWheelTf;

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem backWheelTrail;

	[SerializeField]
	private ParticleSystem backWheelSmokeL;

	[SerializeField]
	private ParticleSystem backWheelSmokeR;

	[Header("Molotov Fields")]
	[SerializeField]
	private int burnStacksApplied;

	private MolotovThrower molotovThrower;

	private bool molotovThrowComplete;

	private Unit lastTarget;

	public bool MolotovThrowComplete => molotovThrowComplete;

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[3]
		{
			new E2_6Idle(sm, this),
			new E2_6Throwing(sm, this),
			new E2_6EMP(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
		previousPos = base.transform.position;
		noiseSeed = Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		molotovThrower = GetComponentInChildren<MolotovThrower>();
		Target();
		base.transform.localScale = new Vector3(1f, base.posSign, 1f);
		headTF.GetChild(0).localScale = new Vector3(base.posSign, 1f, 1f);
		backWheelSmokeL.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		backWheelSmokeR.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		backWheelTrail.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			Move();
			Aim();
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
		frontWheelTf.rotation = rotation;
	}

	public override void Shoot()
	{
		Target();
		if (!(base.TargetUnit == null))
		{
			molotovThrower.SetThrow();
		}
	}

	public override void Aim()
	{
		if ((bool)base.TargetUnit)
		{
			Vector3 upwards = base.TargetUnit.transform.position - base.transform.position;
			Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
			headTF.transform.rotation = Quaternion.RotateTowards(headTF.transform.rotation, to, Time.deltaTime * 60f);
		}
	}

	public override void Target()
	{
		if (IsHacked)
		{
			base.Target();
			return;
		}
		Module[] array = Train.Instance.Modules.Where((Module m) => (bool)m && m != lastTarget).ToArray();
		base.TargetUnit = array[Random.Range(0, array.Length)];
		lastTarget = base.TargetUnit;
	}

	public void ResetMolotovThrown()
	{
		molotovThrowComplete = false;
	}

	public void CompleteMolotovThrow()
	{
		molotovThrowComplete = true;
	}

	public void ThrowMolotov()
	{
		ProjectileMolotov component = Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation).GetComponent<ProjectileMolotov>();
		component.sourceUnit = this;
		component.isEnemyProjectile = base.IsEnemy;
		component.biker = this;
		component.speed = projSpeed;
		component.damage = 0f;
		component.SetTarget(base.TargetUnit);
		soundBuilder.Play(shootSound);
	}

	public bool IdleTimerTick()
	{
		return (idleTimer -= Time.deltaTime) <= 0f;
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		if (backWheelSmokeL.TryGetComponent<TireSmokeController>(out var component))
		{
			component.Detach();
		}
		if (backWheelSmokeR.TryGetComponent<TireSmokeController>(out var component2))
		{
			component2.Detach();
		}
		if (backWheelTrail.TryGetComponent<TireTrailController>(out var component3))
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
