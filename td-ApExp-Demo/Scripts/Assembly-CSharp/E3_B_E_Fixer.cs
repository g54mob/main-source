using UnityEngine;

public class E3_B_E_Fixer : EnemyBase
{
	[Header("Fixer Fields")]
	[SerializeField]
	private E3_B_Phase1Plane bossPlane;

	[SerializeField]
	private new float MoveSpeed = 10f;

	[SerializeField]
	public float RepairTime = 15f;

	[SerializeField]
	private Rotator rotator;

	[SerializeField]
	private SpriteRenderer sr;

	[SerializeField]
	private Collider2D col;

	[SerializeField]
	private Transform homeBox;

	private Vector3 targetPos;

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[5]
		{
			new E3_B_Fixer_Idle(sm, this),
			new E3_B_Fixer_GoToFix(sm, this),
			new E3_B_Fixer_Repair(sm, this),
			new E3_B_Fixer_GoHome(sm, this),
			new BEMPState(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
		previousPos = base.transform.position;
		noiseSeed = Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
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
		Vector3 position = base.transform.position;
		float t = Time.deltaTime * MoveSpeed;
		position.x = Mathf.Lerp(position.x, targetPos.x, t);
		float t2 = Time.deltaTime * MoveSpeed;
		position.y = Mathf.Lerp(position.y, targetPos.y, t2);
		base.transform.position = position + GetPositionModifiers();
		IsInPosition = Mathf.Abs(base.transform.position.x - targetPos.x) <= 0.1f && Mathf.Abs(base.transform.position.y - targetPos.y) <= 0.1f;
	}

	public void MoveToHome()
	{
		Vector3 position = base.transform.position;
		float t = Time.deltaTime * MoveSpeed;
		position.x = Mathf.Lerp(position.x, homeBox.position.x, t);
		float t2 = Time.deltaTime * MoveSpeed;
		position.y = Mathf.Lerp(position.y, homeBox.position.y, t2);
		base.transform.position = position + GetPositionModifiers();
		IsInPosition = Mathf.Abs(base.transform.position.x - homeBox.position.x) <= 0.1f && Mathf.Abs(base.transform.position.y - homeBox.position.y) <= 0.1f;
	}

	public override void Aim()
	{
		rotator.RotateTowardsMovementVector();
	}

	public override void Shoot()
	{
	}

	public void Show(bool show)
	{
		sr.enabled = show;
		col.enabled = show;
	}

	public void GoToFix(Unit targetUnit)
	{
		base.TargetUnit = targetUnit;
		targetPos = base.TargetUnit.transform.position + new Vector3(-0.2f, 0f, 0f);
	}

	public void Fix()
	{
	}

	public void FinishFixing()
	{
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		NoDeathEvents = true;
		base.OnDeath(info);
	}
}
