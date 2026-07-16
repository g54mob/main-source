using System.Collections.Generic;
using UnityEngine;

public class E4_B_Snower : E4_B_Servant
{
	[Header("Snower Fields")]
	[SerializeField]
	private GameObject hudSnow;

	private Transform targetPosition;

	private GameObject currentHudSnow;

	private bool canShoot = true;

	[field: SerializeField]
	public List<ParticleSystem> mainSnowPs { get; private set; }

	[field: SerializeField]
	public List<ParticleSystem> snowDownPs { get; private set; }

	[field: SerializeField]
	public List<ParticleSystem> snowUpPs { get; private set; }

	private new void Awake()
	{
		base.Awake();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[2]
		{
			new E4_B_Snower_Idle(sm, this),
			new BEMPState(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private new void Start()
	{
		base.Start();
		base.TargetUnit = Train.Instance.DirectionLever;
		if (enemyPos == EnemyPositionOnScreen.TopOfScreen)
		{
			targetPosition = Train.Instance.snowmakerPositionUp;
		}
		else
		{
			targetPosition = Train.Instance.snowmakerPositionDown;
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
	}

	public override void Shoot()
	{
		if (!IsInPosition)
		{
			TurnOffSnow();
		}
		else if (!currentHudSnow && canShoot && base.IsEnemy && !base.IsEMPd)
		{
			currentHudSnow = Object.Instantiate(hudSnow, UIManager.Instance.HUD.transform);
			TurnOnSnow();
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		canShoot = false;
		TurnOffSnow();
		base.OnDeath(info);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
	}

	public void TurnOnSnow()
	{
		base.Anim.Play("SnowerShoot");
		EffectsUtils.PlayMultipleParticles(mainSnowPs, play: true);
		if (enemyPos == EnemyPositionOnScreen.TopOfScreen)
		{
			EffectsUtils.PlayMultipleParticles(snowDownPs, play: true);
		}
		else
		{
			EffectsUtils.PlayMultipleParticles(snowUpPs, play: true);
		}
	}

	private void TurnOffSnow()
	{
		base.Anim.Play("SnowerIdle");
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
		Object.Destroy(currentHudSnow);
	}
}
