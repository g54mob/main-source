using System.Linq;
using UnityEngine;

public class E2_1EMPLauncher : EnemyBase
{
	[Header("Bus Fields")]
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
	private Transform frontWheelTf1;

	[SerializeField]
	private Transform frontWheelTf2;

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem leftWheelTrail;

	[SerializeField]
	private ParticleSystem rightWheelTrail;

	[SerializeField]
	private ParticleSystem leftWheelSmoke;

	[Header("EMP Launcher")]
	[SerializeField]
	private GameObject empPrefab;

	[SerializeField]
	private AimerComponent aimer;

	[SerializeField]
	private Animator launcherAnim;

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[3]
		{
			new E2_1Idle(sm, this),
			new E2_1Shoot(sm, this),
			new E2_1EMP(sm, this, "Idle")
		});
		previousPos = base.transform.position;
		noiseSeed = Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		Target();
		leftWheelTrail.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
		rightWheelTrail.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
		leftWheelSmoke.transform.rotation = Quaternion.Euler(0f, 0f, -90f * base.posSign);
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

	public override void Target()
	{
		if (base.IsEnemy)
		{
			base.TargetUnit = GetRandomModule();
		}
		else
		{
			EnemyBase[] array = EnemyManager.Instance.Enemies.Where((EnemyBase e) => e.IsEnemy && e != this).ToArray();
			if (array.Length != 0)
			{
				base.TargetUnit = array[Random.Range(0, array.Length)];
			}
			else
			{
				base.TargetUnit = null;
			}
		}
		aimer.SetTarget(base.TargetUnit?.transform);
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
		frontWheelTf1.rotation = rotation;
		frontWheelTf2.rotation = rotation;
	}

	public void LoadEmp()
	{
		launcherAnim.SetTrigger("Load");
	}

	public override void Shoot()
	{
		SpawnProjectile();
	}

	private void SpawnProjectile()
	{
		launcherAnim.SetTrigger("Shoot");
		EMPProjectile component = Object.Instantiate(empPrefab, muzzleTF.position, muzzleTF.rotation).GetComponent<EMPProjectile>();
		component.SourceUnit = this;
		component.IsEnemy = base.IsEnemy;
		component.SetTarget(base.TargetUnit);
		soundBuilder.Play(shootSound);
	}

	private Module GetRandomModule()
	{
		Module[] array = Train.Instance.Modules.Where((Module m) => (bool)m && !(m is ModuleCannon) && m != base.TargetUnit).ToArray();
		if (array != null)
		{
			return array[Random.Range(0, array.Length)];
		}
		return null;
	}

	protected override void OnDeath(HealthChangeInfo healthChangeInfo)
	{
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
		base.OnDeath(healthChangeInfo);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
	}
}
