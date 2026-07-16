using System;
using AudioSystem;
using UnityEngine;

public class E3_8_FighterJet : EnemyBase
{
	[Header("Special SFX")]
	[SerializeField]
	private SoundData flyOverSound;

	[SerializeField]
	private new float MoveSpeed = 5f;

	[SerializeField]
	public float bulletBurstDuration = 2f;

	[SerializeField]
	private float bulletBurstRate = 20f;

	[SerializeField]
	private float bulletBurstTravelX = 1f;

	[SerializeField]
	public float flyOverDuration = 1f;

	[SerializeField]
	private Transform muzzleTF;

	[SerializeField]
	private Rotator rotator;

	[NonSerialized]
	public bool isShooting;

	[NonSerialized]
	public bool isFinishedShooting;

	[NonSerialized]
	public float shootTimer;

	[NonSerialized]
	public float flyOverTimer;

	[NonSerialized]
	public float singleShotTimer;

	private float singleShotTime = 0.1f;

	private Vector3 startPos;

	private Vector3 endPos;

	private Vector3 attackVector;

	[NonSerialized]
	public bool IsInitialized;

	private new void Start()
	{
		base.Start();
		singleShotTime = 1f / bulletBurstRate;
		IsInitialized = false;
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[3]
		{
			new E3_8_Jet_Attack(sm, this),
			new E3_8_Jet_FlyOver(sm, this),
			new E3_8_Jet_Leave(sm, this)
		});
	}

	private void OnEnable()
	{
		isShooting = false;
		isFinishedShooting = false;
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

	public void Initialize(Unit target, Vector3 start, Vector3 end, bool isEnemy)
	{
		base.TargetUnit = target;
		base.IsEnemy = isEnemy;
		SetTravelLine(start, end);
		attackVector = (endPos - startPos).normalized;
		base.transform.position = start;
		rotator.SnapTowardsPosition(end);
		IsInitialized = true;
	}

	public override void Shoot()
	{
		singleShotTimer -= Time.deltaTime;
		if (!(singleShotTimer > 0f))
		{
			singleShotTimer = singleShotTime;
			Projectile component = UnityEngine.Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation).GetComponent<Projectile>();
			component.ProjectileHit += base.OnTargetDamaged;
			component.sourceUnit = this;
			component.speed = projSpeed;
			component.damage = damage;
			component.GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.005f), new Keyframe(0.5f, 0f));
			component.transform.Find("Outline").GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.02f), new Keyframe(0.5f, 0f));
		}
	}

	public void SetTravelLine(Vector3 start, Vector3 end)
	{
		startPos = start;
		endPos = end;
		base.transform.position = startPos;
	}

	public void MoveForShooting()
	{
		float x = Mathf.Lerp(startPos.x, startPos.x + bulletBurstTravelX, shootTimer / bulletBurstDuration);
		base.transform.position = new Vector3(x, startPos.y);
		if (shootTimer >= bulletBurstDuration)
		{
			isShooting = false;
			isFinishedShooting = true;
			startPos.x += bulletBurstTravelX / 2f;
		}
		shootTimer += Time.deltaTime;
	}

	public void MoveForFlyOver()
	{
		float t = 1f - flyOverTimer / flyOverDuration;
		float x = Mathf.Lerp(startPos.x, endPos.x, t);
		float y = Mathf.Lerp(startPos.y, endPos.y, t);
		base.transform.position = new Vector3(x, y);
		flyOverTimer -= Time.deltaTime;
	}

	public new void Despawn()
	{
		base.Despawn();
	}

	public void PlayFlyOverSound()
	{
		soundBuilder.Play(flyOverSound);
	}

	public void PlayShootSound()
	{
		soundBuilder.Play(shootSound);
	}
}
