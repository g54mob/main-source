using System.Collections.Generic;
using UnityEngine;

public class E4_7Snowmaker : EnemyBase
{
	[Header("Snowmaker Fields")]
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
	private Transform turretTF;

	[SerializeField]
	private Transform frontWheelTf;

	[SerializeField]
	private Animator gunAnim;

	[SerializeField]
	private GameObject hudSnow;

	[SerializeField]
	private Animator collectorAnim;

	[SerializeField]
	private Animator pumpAnim;

	[SerializeField]
	private Animator backWheelsAnim;

	[SerializeField]
	private Animator frontWheelsAnim;

	[SerializeField]
	private List<ParticleSystem> mainSnowPs;

	[SerializeField]
	private List<ParticleSystem> snowDownPs;

	[SerializeField]
	private List<ParticleSystem> snowUpPs;

	[Header("Trail and Smoke")]
	[SerializeField]
	private ParticleSystem backWheelTrail;

	[SerializeField]
	private ParticleSystem backWheelTrail2;

	[SerializeField]
	private ParticleSystem backWheelSmoke;

	private Transform targetPosition;

	private GameObject currentHudSnow;

	private bool canShoot = true;

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[2]
		{
			new E4_7Idle(sm, this),
			new BEMPState(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
		previousPos = base.transform.position;
		noiseSeed = Random.Range(0, 100000);
		disableInertia = true;
	}

	private new void Start()
	{
		base.Start();
		base.transform.localScale = new Vector3(1f, (float)enemyPos, 1f);
		backWheelSmoke.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		backWheelTrail.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		backWheelTrail2.transform.localRotation = Quaternion.Euler(0f, 0f, -90f * (float)enemyPos);
		if (enemyPos == EnemyPositionOnScreen.TopOfScreen)
		{
			targetPosition = Train.Instance.snowmakerPositionUp;
		}
		else
		{
			targetPosition = Train.Instance.snowmakerPositionDown;
		}
		base.TargetUnit = Train.Instance.DirectionLever;
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			frontWheelsAnim.SetFloat("WheelSpeed", relativeSpeedMult);
			backWheelsAnim.SetFloat("WheelSpeed", relativeSpeedMult);
		}
	}

	public override void Move()
	{
		Vector3 vector = ((!(targetPosition == null)) ? targetPosition.position : Vector3.zero);
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

	public override void Aim()
	{
	}

	public override void Shoot()
	{
		if (!IsInPosition)
		{
			TurnOffSnow();
		}
		else if (!currentHudSnow && canShoot && base.IsEnemy && !base.IsEMPd)
		{
			EffectsUtils.PlayMultipleParticles(mainSnowPs, play: true);
			if (enemyPos == EnemyPositionOnScreen.TopOfScreen)
			{
				EffectsUtils.PlayMultipleParticles(snowDownPs, play: true);
			}
			else
			{
				EffectsUtils.PlayMultipleParticles(snowUpPs, play: true);
			}
			currentHudSnow = Object.Instantiate(hudSnow, UIManager.Instance.HUD.transform);
			gunAnim.Play("SnowmakerPengiunShoot");
			pumpAnim.Play("SnowmakerPumpRunning");
			base.Anim.Play("SnowmakerFlashing");
			collectorAnim.Play("SnowmakerCollectorRunning");
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		if (backWheelSmoke.TryGetComponent<TireSmokeController>(out var component))
		{
			component.Detach();
		}
		if (backWheelTrail.TryGetComponent<TireTrailController>(out var component2))
		{
			component2.Detach();
		}
		if (backWheelTrail2.TryGetComponent<TireTrailController>(out var component3))
		{
			component3.Detach();
		}
		canShoot = false;
		TurnOffSnow();
		base.OnDeath(info);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		if (!base.IsEnemy)
		{
			TurnOffSnow();
		}
	}

	private void TurnOffSnow()
	{
		EffectsUtils.PlayMultipleParticles(mainSnowPs, play: false, clearOnStop: true);
		if (enemyPos == EnemyPositionOnScreen.TopOfScreen)
		{
			EffectsUtils.PlayMultipleParticles(snowDownPs, play: false, clearOnStop: true);
		}
		else
		{
			EffectsUtils.PlayMultipleParticles(snowUpPs, play: false, clearOnStop: true);
		}
		if ((bool)currentHudSnow)
		{
			Object.Destroy(currentHudSnow);
		}
		gunAnim.Play("SnowmakerPenguinIdle");
		pumpAnim.Play("SnowmakerPumpIdle");
		base.Anim.Play("SnowmakerIdle");
		collectorAnim.Play("SnowmakerCollectorIdle");
	}

	public override void EMP(float duration)
	{
		base.EMP(duration);
		if ((bool)base.HealthComponent)
		{
			TurnOffSnow();
		}
	}
}
