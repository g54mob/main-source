using System.Collections;
using UnityEngine;

public class E3_1_Biplane : EnemyBase
{
	[Header("Biplane Fields")]
	[SerializeField]
	private float maxTiltAngle = 10f;

	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float yVariation = 0.5f;

	[SerializeField]
	private float ySpeedMult = 10f;

	[SerializeField]
	private Transform muzzleTF;

	[SerializeField]
	private Transform turretTF;

	[SerializeField]
	private Animator gunAnim;

	[field: SerializeField]
	public int ShotsPerBurst { get; private set; }

	[field: SerializeField]
	public float TimeBetweenShotsInBurst { get; private set; }

	private new void Awake()
	{
		base.Awake();
		previousPos = base.transform.position;
		noiseSeed = Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[2]
		{
			new E3_1_Idle(sm, this),
			new BEMPState(sm, this)
		});
		Target();
		if (enemyPos == EnemyPositionOnScreen.TopOfScreen)
		{
			gunAnim.gameObject.GetComponent<SpriteRenderer>().flipX = true;
		}
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			CheckTarget();
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
		Vector3 vector = ((!(base.TargetUnit == null)) ? base.TargetUnit.transform.position : Vector3.zero);
		float num = Train.Instance.Wagons[0].transform.position.y * base.posSignTf;
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float num2 = Mathf.Lerp(vector.x - xVariation, vector.x + xVariation, t2);
		float num3 = (Mathf.Lerp(minY + num, maxY + num, t) + targetOffsetY) * base.posSignTf;
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, num2, t3);
		float t4 = Time.deltaTime * base.MoveSpeed * ySpeedMult * relativeSpeedMult;
		if (Mathf.Abs(num3) < minY)
		{
			num3 = minY * base.posSignTf;
		}
		position.y = Mathf.Lerp(position.y, num3, t4);
		if (Train.Instance.SpeedCurrent > 0f || base.transform.position.x < -1f)
		{
			base.transform.position = position + GetPositionModifiers();
		}
		else
		{
			base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
		}
		IsInPosition = IsHacked || (Mathf.Abs(position.x - num2) < xVariation && Mathf.Abs(position.y - num3) < yVariation);
		rateOfChangeY = (position.y - previousPos.y) / Time.deltaTime;
		previousPos = position;
		TiltPlane(rateOfChangeY);
	}

	private void TiltPlane(float verticalMovement)
	{
		float num = 0.1f;
		float num2 = verticalMovement / num;
		float z = base.transform.rotation.z;
		float b = num2 * maxTiltAngle;
		Mathf.Lerp(z, b, Time.deltaTime);
	}

	public override void Aim()
	{
		if (!(base.TargetUnit == null))
		{
			Vector3 position = base.TargetUnit.transform.position;
			Vector3 upwards = new Vector3(base.TargetUnit.transform.position.x, position.y) - base.transform.position;
			Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
			turretTF.transform.rotation = Quaternion.RotateTowards(turretTF.transform.rotation, to, Time.deltaTime * 60f);
		}
	}

	public override void Shoot()
	{
		if (!(base.TargetUnit == null) && !(shotTimer > 0f) && IsInPosition)
		{
			StartCoroutine(BurstShotCoroutine());
		}
	}

	private IEnumerator BurstShotCoroutine()
	{
		for (int i = 0; i < ShotsPerBurst; i++)
		{
			gunAnim.Play("BiplaneGunFire");
			Projectile component = Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation).GetComponent<Projectile>();
			component.ProjectileHit += base.OnTargetDamaged;
			component.sourceUnit = this;
			component.speed = projSpeed;
			component.damage = damage;
			component.GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.005f), new Keyframe(0.5f, 0f));
			component.transform.Find("Outline").GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.02f), new Keyframe(0.5f, 0f));
			soundBuilder.Play(shootSound);
			yield return new WaitForSeconds(TimeBetweenShotsInBurst);
		}
	}

	public override void Hack(bool isHacked)
	{
		base.Hack(isHacked);
		Target();
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		base.OnDeath(info);
	}
}
