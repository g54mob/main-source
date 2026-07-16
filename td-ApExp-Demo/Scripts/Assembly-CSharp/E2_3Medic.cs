using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class E2_3Medic : EnemyBase
{
	[NonSerialized]
	[Header("Squad Fields")]
	public Vector3 targetPos;

	[SerializeField]
	private float reviveTime = 12f;

	[Header("Medic Fields")]
	[SerializeField]
	private Animator reviveAnim;

	[SerializeField]
	private Animator gunAnim;

	[SerializeField]
	private float maxWheelAngle = 10f;

	[SerializeField]
	private float wheelSpeed = 10f;

	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float yVariation = 1f;

	[SerializeField]
	private Transform muzzleTF;

	[SerializeField]
	private Transform turretTF;

	[SerializeField]
	private Transform frontWheelTf1;

	[SerializeField]
	private Transform frontWheelTf2;

	[SerializeField]
	private SpriteRenderer bodySr;

	[SerializeField]
	private Sprite bodyAlive;

	[SerializeField]
	private Sprite bodyDead;

	[SerializeField]
	private SpriteRenderer headSr;

	[SerializeField]
	private SpriteRenderer gunSr;

	[Header("Squads")]
	[SerializeField]
	private MedicSquads teamColor;

	[SerializeField]
	private List<Sprite> bakedColors;

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem backWheelTrail1;

	[SerializeField]
	private ParticleSystem backWheelTrail2;

	[SerializeField]
	private ParticleSystem backWheelSmoke1;

	[SerializeField]
	private ParticleSystem deadSmokePs;

	[SerializeField]
	private List<E2_3Medic> medics;

	private bool canBeRevived;

	private Coroutine reviveCoroutine;

	private bool isKilled;

	private new void Awake()
	{
		base.Awake();
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
	}

	private new void Start()
	{
		base.Start();
		Target();
		base.transform.localScale = new Vector3(1f, (float)enemyPos, 1f);
		turretTF.localScale = new Vector3((float)enemyPos, (float)enemyPos, 1f);
		backWheelSmoke1.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		backWheelTrail1.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		backWheelTrail2.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
	}

	private new void Update()
	{
		if (Time.timeScale == 0f || Time.deltaTime == 0f)
		{
			return;
		}
		base.Update();
		base.Anim.SetFloat("WheelSpeed", relativeSpeedMult);
		CheckTarget();
		if (base.IsEMPd)
		{
			empDuration -= Time.deltaTime;
			if (empDuration <= 0f)
			{
				OnEMPEnd();
			}
		}
	}

	protected new void FixedUpdate()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.FixedUpdate();
			Move();
			if (!base.HealthComponent.IsDead && base.TargetUnit != null)
			{
				Aim();
				Shoot();
			}
		}
	}

	public void SetSquad(E2_3Medic med1, E2_3Medic med2)
	{
		medics = new List<E2_3Medic> { med1, med2 };
	}

	public override void Move()
	{
		_ = (float)enemyPos;
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(targetPos.x - xVariation, targetPos.x + xVariation, t2);
		float b2 = Mathf.Lerp(targetPos.y - yVariation, targetPos.y + yVariation, t);
		Vector3 position = base.transform.position;
		float t3 = base.MoveSpeed * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, b, t3);
		float t4 = base.MoveSpeed * relativeSpeedMult;
		position.y = Mathf.Lerp(position.y, b2, t4);
		if (Train.Instance.SpeedCurrent > 0f || base.transform.position.x < -1f)
		{
			base.transform.position = position + GetPositionModifiers();
		}
		else
		{
			base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
		}
		base.Move();
		IsInPosition = MathF.Abs(position.x - targetPos.x) < xVariation && MathF.Abs(position.y - targetPos.y) < yVariation;
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

	public override void Aim()
	{
		Vector3 position = base.TargetUnit.transform.position;
		Vector3 upwards = new Vector3(base.TargetUnit.transform.position.x, position.y) - base.transform.position;
		Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
		turretTF.transform.rotation = Quaternion.RotateTowards(turretTF.transform.rotation, to, Time.deltaTime * 60f);
	}

	public override void Shoot()
	{
		if (!(base.TargetUnit == null) && !(shotTimer > 0f) && IsInPosition)
		{
			shotTimer = timeBetweenShots;
			Projectile component = UnityEngine.Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation).GetComponent<Projectile>();
			component.ProjectileHit += base.OnTargetDamaged;
			component.sourceUnit = this;
			component.speed = projSpeed;
			component.damage = damage;
			gunAnim.SetTrigger("Fire");
			soundBuilder.Play(shootSound);
			component.GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.005f), new Keyframe(0.5f, 0f));
			component.transform.Find("Outline").GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.02f), new Keyframe(0.5f, 0f));
		}
	}

	public void StartRevive()
	{
		if (reviveCoroutine == null && !base.IsDead)
		{
			reviveCoroutine = StartCoroutine(ReviveCoroutine());
		}
	}

	private IEnumerator ReviveCoroutine()
	{
		SetChargingAnim();
		yield return new WaitForSeconds(reviveTime);
		SetReviveAnim();
		yield return new WaitForSeconds(0.5f);
		ReviveSquad();
		reviveCoroutine = null;
	}

	public void ReviveSquad()
	{
		foreach (E2_3Medic medic in medics)
		{
			medic.Revive();
		}
	}

	public void Revive()
	{
		if (!canBeRevived)
		{
			return;
		}
		canBeRevived = false;
		if (base.IsDead)
		{
			base.HealthComponent.IsDead = false;
			if ((bool)reviveAnim)
			{
				reviveAnim.SetBool("IsDead", value: false);
			}
			base.HealthComponent.Heal(base.HealthComponent.HealthMissing, this);
			headSr.enabled = true;
			gunSr.enabled = true;
			bodySr.sprite = bodyAlive;
		}
		HideDeadAssSmoke();
	}

	private void InterruptRevive()
	{
		if (reviveCoroutine != null)
		{
			StopCoroutine(reviveCoroutine);
			StopChargingAnim();
			reviveCoroutine = null;
		}
	}

	public void ShowDeadAssSmoke()
	{
		if (deadSmokePs != null)
		{
			deadSmokePs.Play(withChildren: true);
		}
	}

	public void HideDeadAssSmoke()
	{
		if (deadSmokePs != null)
		{
			deadSmokePs.Stop(withChildren: true);
		}
	}

	public void StopChargingAnim()
	{
		if (!base.HealthComponent.IsDead && (bool)reviveAnim)
		{
			reviveAnim.Play("Idle");
		}
	}

	public void SetChargingAnim()
	{
		if (!base.HealthComponent.IsDead && (bool)reviveAnim)
		{
			reviveAnim.SetTrigger("Charging");
		}
	}

	public void SetReviveAnim()
	{
		if (!base.HealthComponent.IsDead && (bool)reviveAnim)
		{
			reviveAnim.SetTrigger("Revive");
		}
	}

	public void Kill(HealthChangeInfo info)
	{
		if (!isKilled)
		{
			isKilled = true;
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
			if ((bool)deadSmokePs)
			{
				deadSmokePs.Stop();
			}
			base.OnDeath(info);
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		canBeRevived = true;
		base.HealthComponent.IsDead = true;
		if (medics.All((E2_3Medic m) => m.IsDead || m.IsHacked))
		{
			foreach (E2_3Medic medic in medics)
			{
				medic.Kill(info);
			}
			Kill(info);
			return;
		}
		headSr.enabled = false;
		gunSr.enabled = false;
		bodySr.sprite = bodyDead;
		ShowDeadAssSmoke();
		InterruptRevive();
		reviveAnim.SetBool("IsDead", value: true);
		foreach (E2_3Medic medic2 in medics)
		{
			medic2.StartRevive();
		}
	}

	public override void EMP(float duration)
	{
		if (reviveCoroutine != null)
		{
			StopChargingAnim();
			StopCoroutine(reviveCoroutine);
		}
		base.EMP(duration);
	}

	public override void OnEMPEnd()
	{
		base.OnEMPEnd();
		Target();
		if (reviveCoroutine != null)
		{
			reviveCoroutine = null;
			StartRevive();
		}
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
	}

	public void SetSquadColors(int squadIterator)
	{
		teamColor = (MedicSquads)squadIterator;
		GetComponent<ExplodeSprite>().SetSprite(bakedColors[squadIterator]);
		PlayIdleAnim(squadIterator);
	}

	private void PlayIdleAnim(int i)
	{
		switch (i)
		{
		case 0:
			base.Anim.Play("Idle");
			break;
		case 1:
			base.Anim.Play("IdleBlue");
			break;
		case 2:
			base.Anim.Play("IdlePink");
			break;
		case 3:
			base.Anim.Play("IdleWhite");
			break;
		case 4:
			base.Anim.Play("IdleYellow");
			break;
		default:
			base.Anim.Play("Idle");
			break;
		}
	}
}
