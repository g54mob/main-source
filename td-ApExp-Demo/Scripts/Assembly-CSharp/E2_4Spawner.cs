using System;
using UnityEngine;

public class E2_4Spawner : EnemyBase
{
	private new const float TARGET_HEALTHY_MODULE_CHANCE = 0.3f;

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
	private Transform frontWheelTf1;

	[SerializeField]
	private Transform frontWheelTf2;

	[Header("Spawner Fields")]
	[SerializeField]
	public GameObject SpawnlingPrefab;

	[SerializeField]
	private Transform spawnLocation;

	[SerializeField]
	private SpawnerDoor spawnerDoor;

	[SerializeField]
	private float enterTime;

	[NonSerialized]
	public float enterTimer;

	[NonSerialized]
	public bool spawnFinished;

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem backWheelTrail1;

	[SerializeField]
	private ParticleSystem backWheelTrail2;

	[SerializeField]
	private ParticleSystem backWheelSmoke1;

	private Vector3 targetPos;

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[4]
		{
			new E2_4Enter(sm, this),
			new E2_4Idle(sm, this),
			new E2_4Spawn(sm, this),
			new E2_4EMP(sm, this, "Idle")
		});
		enterTimer = enterTime;
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		Target();
		SetIdleTimer();
		backWheelSmoke1.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
		backWheelTrail1.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
		backWheelTrail2.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			base.Anim.SetFloat("WheelSpeed", relativeSpeedMult);
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
		float num = (float)enemyPos;
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(targetPos.x - xVariation, targetPos.x + xVariation, t);
		float b2 = Mathf.Lerp(targetPos.y - yVariation, targetPos.y + yVariation, t2) + targetOffsetY * base.posSignTf;
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, b, t3);
		float t4 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
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

	public void ResetEnterTimer()
	{
	}

	public void OpenDoor()
	{
		spawnerDoor.GetComponent<Animator>().SetTrigger("Open");
	}

	public void Spawn()
	{
		if (!(enterTimer > 0f))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(SpawnlingPrefab, spawnLocation);
			gameObject.transform.position = spawnLocation.position;
			gameObject.transform.SetParent(EnemyManager.Instance.transform);
			if (IsHacked && gameObject.TryGetComponent<E2_4Spawnling>(out var component))
			{
				Train.Instance.GetModuleByType<ModuleHacking>().HackEnemy(component);
			}
			EnemyManager.Instance.OnEnemySpawned(gameObject.GetComponent<EnemyBase>());
		}
	}

	public void FinishSpawn()
	{
		spawnFinished = true;
	}

	public override void Target()
	{
		float num = ((base.transform.position.y > 0f) ? 1f : (-1f));
		targetPos = new Vector3(UnityEngine.Random.Range(-3f, -0f), UnityEngine.Random.Range(minY, maxY) * num, 0f);
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		if (backWheelSmoke1.TryGetComponent<TireSmokeController>(out var component))
		{
			component.Detach();
		}
		if (backWheelTrail1.TryGetComponent<TireTrailController>(out var component2))
		{
			component2.Detach();
		}
		if (backWheelTrail2.TryGetComponent<TireTrailController>(out var component3))
		{
			component3.Detach();
		}
		base.OnDeath(info);
	}

	public override void EMP(float duration)
	{
		base.EMP(duration);
	}

	public override void OnEMPEnd()
	{
		base.OnEMPEnd();
	}
}
