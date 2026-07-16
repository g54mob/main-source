using UnityEngine;

public class E4_B_Servant : EnemyBase
{
	[Header("Servants Fields")]
	[SerializeField]
	protected Transform muzzleTF;

	[SerializeField]
	protected float xVariation = 1f;

	[SerializeField]
	protected float ySpeedMult = 10f;

	protected EnemyPositionOnScreen assignedPosition;

	protected E4_B_Warlord warlord;

	[Header("Trail and Smoke")]
	[SerializeField]
	protected ParticleSystem backWheelTrail;

	[field: SerializeField]
	public Animator HeadAnim { get; private set; }

	protected new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		previousPos = base.transform.position;
		noiseSeed = Random.Range(0, 100000);
	}

	protected new void Start()
	{
		base.Start();
		enemyPos = assignedPosition;
		if (enemyPos == EnemyPositionOnScreen.BottomOfScreen)
		{
			base.transform.position = new Vector3(3f, -2f);
		}
		else if (enemyPos == EnemyPositionOnScreen.TopOfScreen)
		{
			base.transform.position = new Vector3(3f, 2f);
		}
		base.transform.localScale = new Vector3(1f, (float)enemyPos, 1f);
		HeadAnim.gameObject.transform.localScale = new Vector3(0f - (float)enemyPos, (float)enemyPos, 1f);
		backWheelTrail.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
	}

	protected new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			base.Anim.SetFloat("WheelSpeed", relativeSpeedMult);
		}
	}

	public override void Move()
	{
		Vector3 vector = Vector3.zero;
		if (enemyPos == EnemyPositionOnScreen.BottomOfScreen)
		{
			vector = new Vector3(0.75f, -1.5f);
		}
		else if (enemyPos == EnemyPositionOnScreen.TopOfScreen)
		{
			vector = new Vector3(0.75f, 1.5f);
		}
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
		HeadAnim.gameObject.transform.rotation = Quaternion.RotateTowards(HeadAnim.gameObject.transform.rotation, to, Time.deltaTime * 60f);
	}

	public virtual void SetupServant(EnemyPositionOnScreen position, E4_B_Warlord warlord)
	{
		assignedPosition = position;
		this.warlord = warlord;
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		if (backWheelTrail.TryGetComponent<TireTrailController>(out var component))
		{
			component.Detach();
		}
		warlord.ServantDied(enemyPos);
		base.OnDeath(info);
	}
}
