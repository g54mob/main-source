using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class E2_B_BossController : EnemyBase, iBossController
{
	[Header("Dual Boss")]
	public E2_B_DualBossController dualBossController;

	[Header("Animation")]
	[SerializeField]
	private Animator bossAnim;

	[Header("Movement")]
	[SerializeField]
	protected float distanceFromTracks = 1f;

	[SerializeField]
	protected float xVariation = 1f;

	[SerializeField]
	protected float yVariation = 1f;

	[SerializeField]
	protected float switchPositionChance = 50f;

	[SerializeField]
	protected float maxWheelAngle;

	[Header("Smoke and Trails")]
	[SerializeField]
	protected Transform trails;

	[SerializeField]
	protected Transform smokes;

	[Header("Reviving")]
	[SerializeField]
	public Animator reviveAnim;

	[SerializeField]
	protected GameObject reviveBomb;

	[SerializeField]
	protected float reviveChargeTime = 4f;

	[SerializeField]
	protected float reviveHealAmount = 20f;

	[NonSerialized]
	public bool shouldHealOther;

	[Header("Timers")]
	[SerializeField]
	protected float basicAttack1Time;

	[SerializeField]
	protected float basicAttack2Time;

	[SerializeField]
	protected float specialAttackTime;

	[SerializeField]
	protected float chainAttackTime;

	[SerializeField]
	protected float switchPositionTime;

	[SerializeField]
	protected float exitTime;

	[Header("Death")]
	[SerializeField]
	private float deathExplosionRadius;

	[SerializeField]
	private float deathExplosionScaleVariation;

	[NonSerialized]
	public bool StateSwitchBlocked;

	[NonSerialized]
	public bool SpecialAttackComplete;

	[NonSerialized]
	public bool canAimDuringSpecialAttack;

	[NonSerialized]
	public bool canAimDuringChainAttack;

	[NonSerialized]
	public int numberOfBossesDead;

	protected bool isEMPd;

	protected Vector3 targetPos;

	protected ScreenPositions currentPosition;

	protected float reviveTimer;

	protected float basicAttack1Timer;

	protected float basicAttack2Timer;

	protected float specialAttackTimer;

	protected float specialAttackDurationTimer;

	protected float chainAttackTimer;

	protected float switchPositionTimer;

	protected float exitTimer;

	[NonSerialized]
	public Unit TargetUnit2;

	[NonSerialized]
	public bool movingToChainAttackPos;

	[NonSerialized]
	public bool movingToExitPos;

	[NonSerialized]
	public bool movingOutDead;

	[SerializeField]
	public List<ParticleSystem> brokenPs;

	[NonSerialized]
	public bool moveOutDead;

	[SerializeField]
	private float firstExplosionAfter;

	[SerializeField]
	private float timeBetweenExplosions;

	private float timeBetweenExplosionsTimer;

	private int numberOfExplosions;

	private int explosionCounter;

	private bool exploded;

	[NonSerialized]
	public float stopExplosionsAfter;

	[SerializeField]
	protected Animator bodyAnim;

	public bool ReviveBombThrown;

	public bool Revived;

	public bool ChainAttackCharged => chainAttackTimer <= 0f;

	public float PosSign => (base.transform.position.y > 0f) ? 1 : (-1);

	private new void Awake()
	{
		base.Awake();
		previousPos = base.transform.position;
		movingToChainAttackPos = false;
		movingOutDead = false;
	}

	public new virtual void Start()
	{
		base.Start();
		Target();
		base.HealthComponent.OnHealthChanged += HandleHealthChanged;
		foreach (Transform trail in trails)
		{
			trail.localRotation = Quaternion.Euler(0f, 0f, -90f);
		}
		numberOfExplosions = brokenPs.Count;
		stopExplosionsAfter = 3f;
	}

	public new virtual void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			bodyAnim.SetFloat("Speed", Train.Instance.TrainSpeedNormalized);
			empDuration -= Time.deltaTime;
			bossAnim.SetFloat("WheelSpeed", relativeSpeedMult);
			Move();
			if (base.HealthComponent.IsDead)
			{
				sm.UpdateStates();
			}
			else
			{
				base.Update();
			}
		}
	}

	private void Explode()
	{
		if (!exploded)
		{
			UnityEngine.Object.Instantiate(explosionPrefab, brokenPs[0].transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(null, 0.125f, 0f);
			exploded = true;
		}
		timeBetweenExplosionsTimer -= Time.deltaTime;
		if (explosionCounter >= numberOfExplosions)
		{
			explosionCounter = 0;
		}
		if (timeBetweenExplosionsTimer < 0f)
		{
			UnityEngine.Object.Instantiate(explosionPrefab, brokenPs[explosionCounter].transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(null, 0.125f, 0f);
			explosionCounter++;
			timeBetweenExplosionsTimer = timeBetweenExplosions;
		}
	}

	private void MoveOut()
	{
		if (base.transform.position.y < 0f)
		{
			Quaternion b = Quaternion.Euler(base.transform.rotation.x, base.transform.rotation.y, base.transform.rotation.z - 20f);
			base.transform.position = new Vector2(base.transform.position.x, base.transform.position.y - 0.01f);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 0.5f);
		}
		else
		{
			Quaternion b2 = Quaternion.Euler(base.transform.rotation.x, base.transform.rotation.y, base.transform.rotation.z + 20f);
			base.transform.position = new Vector2(base.transform.position.x, base.transform.position.y + 0.01f);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b2, Time.deltaTime * 0.5f);
		}
	}

	public override void Target()
	{
		base.Target();
		if (UnityEngine.Random.value <= 0.3f)
		{
			TargetUnit2 = UnitHelper.GetRandomLiveEnemyUnit(this);
		}
		else
		{
			TargetUnit2 = UnitHelper.GetRandomEnemyUnit(this);
		}
	}

	public E2_B_BossController GetOtherBossController()
	{
		return dualBossController.GetOtherBossController(this);
	}

	public void Enter()
	{
		SetTargetLocation();
	}

	public void Exit()
	{
		sm.ForceState("Exit");
	}

	public override void Move()
	{
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(targetPos.x - xVariation, targetPos.x + xVariation, t2);
		float b2 = Mathf.Lerp(targetPos.y - yVariation, targetPos.y + yVariation, t) + targetOffsetY * base.posSignTf;
		Vector3 vector = GetNeighborAvoidanceVector();
		Vector3 position = base.transform.position;
		if (movingToChainAttackPos && !IsInPosition && relativeSpeedMult <= 0.5f)
		{
			relativeSpeedMult = 0.5f;
		}
		else if ((movingToChainAttackPos || movingOutDead || movingToExitPos) && relativeSpeedMult <= 0.3f)
		{
			relativeSpeedMult = 0.3f;
		}
		float t3 = base.MoveSpeed * relativeSpeedMult;
		position.x = Mathf.Lerp(position.x, b, t3);
		float t4 = base.MoveSpeed * relativeSpeedMult;
		position.y = Mathf.Lerp(position.y, b2, t4);
		base.transform.position = position + vector;
		IsInPosition = MathF.Abs(base.transform.position.x - targetPos.x) < xVariation && MathF.Abs(base.transform.position.y - targetPos.y) < yVariation;
		RotateWheel((position.y - previousPos.y) / Time.deltaTime);
		previousPos = position;
	}

	protected virtual void RotateWheel(float verticalMovement)
	{
	}

	public virtual void AimChainAttack()
	{
	}

	private Vector3 GetTargetLocation(ScreenPositions pos = ScreenPositions.Center)
	{
		return pos switch
		{
			ScreenPositions.Back => new Vector3(-1f, distanceFromTracks * PosSign, 0f), 
			ScreenPositions.Center => new Vector3(0f, distanceFromTracks * PosSign, 0f), 
			ScreenPositions.Front => new Vector3(1f, distanceFromTracks * PosSign, 0f), 
			_ => new Vector3(0f, distanceFromTracks * PosSign, 0f), 
		};
	}

	public void SetTargetLocation(ScreenPositions pos = ScreenPositions.None)
	{
		if (pos == ScreenPositions.None)
		{
			switch (UnityEngine.Random.Range(0, 3))
			{
			case 0:
				currentPosition = ScreenPositions.Back;
				targetPos = GetTargetLocation(ScreenPositions.Back);
				break;
			case 1:
				currentPosition = ScreenPositions.Center;
				targetPos = GetTargetLocation();
				break;
			case 2:
				currentPosition = ScreenPositions.Front;
				targetPos = GetTargetLocation(ScreenPositions.Front);
				break;
			default:
				targetPos = Vector3.zero;
				break;
			}
		}
		else
		{
			currentPosition = pos;
			targetPos = GetTargetLocation(pos);
		}
	}

	public void SetOutPosition()
	{
		targetPos = new Vector3(targetPos.x, 5f * PosSign, 0f);
	}

	public void SwitchSide()
	{
		targetPos.y = 0f - targetPos.y;
	}

	public void TryChangePosition()
	{
		if (UnityEngine.Random.Range(0f, 100f) <= switchPositionChance)
		{
			ScreenPositions[] array = (from ScreenPositions v in Enum.GetValues(typeof(ScreenPositions))
				where !v.Equals(currentPosition)
				select v).ToArray();
			if (array.Length != 0)
			{
				SetTargetLocation(array[UnityEngine.Random.Range(0, array.Length)]);
			}
		}
	}

	public virtual void BasicAttack1()
	{
	}

	public virtual void BasicAttack2()
	{
	}

	public virtual void SpecialAttack()
	{
		SpecialAttackComplete = false;
	}

	public virtual void TargetChainAttack()
	{
	}

	public virtual void ChargeChainAttack()
	{
	}

	public virtual void ChainAttack()
	{
		dualBossController.ChainAttackComplete = true;
	}

	public virtual void CancelChainAttack()
	{
	}

	public void StartReviveChargeUp()
	{
		ResetReviveTimer();
		reviveAnim.SetTrigger("Charging");
	}

	public void ReviveOtherBoss()
	{
		ThrowReviveBomb();
	}

	public void ThrowReviveBomb()
	{
		reviveAnim.SetTrigger("Revive");
		Vector3 upwards = new Vector3(base.TargetUnit.transform.position.x, base.TargetUnit.transform.position.y) - base.transform.position;
		Quaternion rotation = Quaternion.LookRotation(Vector3.forward, upwards);
		ReviveBomb component = UnityEngine.Object.Instantiate(reviveBomb, base.transform.position, rotation).GetComponent<ReviveBomb>();
		component.sourceUnit = this;
		component.TargetUnit = GetOtherBossController();
		component.revivePercent = reviveHealAmount;
		CombatManager.Instance.RegisterProjectile(component);
		ReviveBombThrown = true;
		dualBossController.HealingComplete = true;
	}

	public void ReviveSelf(HealthChangeInfo info)
	{
		base.HealthComponent.ChangeHealthWithInfo(info);
		Revived = true;
		OnBossRevive();
	}

	protected virtual void OnBossRevive()
	{
		foreach (ParticleSystem brokenP in brokenPs)
		{
			brokenP.Stop(withChildren: true);
		}
	}

	public void ResetReviveTimer()
	{
		reviveTimer = reviveChargeTime;
	}

	public bool TickReviveChargeUp()
	{
		return (reviveTimer -= Time.deltaTime) <= 0f;
	}

	public void ResetBasicAttack1Timer()
	{
		basicAttack1Timer = basicAttack1Time;
	}

	public bool TickBacicAttack1()
	{
		return (basicAttack1Timer -= Time.deltaTime) <= 0f;
	}

	public void ResetBasicAttack2Timer()
	{
		basicAttack2Timer = basicAttack2Time;
	}

	public virtual bool TickBasicAttack2()
	{
		return (basicAttack2Timer -= Time.deltaTime) <= 0f;
	}

	public void ResetSpecialAttackTimer()
	{
		specialAttackTimer = specialAttackTime;
	}

	public bool TickSpecialAttack()
	{
		return (specialAttackTimer -= Time.deltaTime) <= 0f;
	}

	public void ResetChainAttackTimer()
	{
		chainAttackTimer = chainAttackTime;
	}

	public bool TickChainAttack()
	{
		return (chainAttackTimer -= Time.deltaTime) <= 0f;
	}

	public void ResetSwitchPositionTimer()
	{
		switchPositionTimer = switchPositionTime;
	}

	public bool TickSwitchPosition()
	{
		return (switchPositionTimer -= Time.deltaTime) <= 0f;
	}

	public void ResetExitTimer()
	{
		exitTimer = exitTime;
	}

	public bool TickExit()
	{
		return (exitTimer -= Time.deltaTime) <= 0f;
	}

	private void HandleHealthChanged(HealthChangeInfo info)
	{
		if (base.HealthComponent.HealthCurrent <= 0f)
		{
			base.HealthComponent.IsDead = true;
			base.HealthComponent.IsImmune = true;
			reviveAnim.SetBool("IsDead", value: true);
			dualBossController.TriggerBossDied(this);
			Mathf.Clamp(numberOfBossesDead, 0, 2);
			if (!(sm.CurrentState is E2_B_FullDead))
			{
				sm.ForceState("Dead");
			}
			OnBossDeath();
		}
		else
		{
			base.HealthComponent.IsDead = false;
			base.HealthComponent.IsImmune = false;
			reviveAnim.SetBool("IsDead", value: false);
		}
	}

	protected virtual void OnBossDeath()
	{
		foreach (ParticleSystem brokenP in brokenPs)
		{
			if ((bool)brokenP)
			{
				brokenP.Play(withChildren: true);
			}
		}
	}

	public void Kill()
	{
		base.HealthComponent.OnHealthChanged -= HandleHealthChanged;
		sm.ForceState("FullDead");
	}

	private IEnumerator SpawnDeathExplosions()
	{
		while (true)
		{
			Vector3 position = base.transform.position + new Vector3(UnityEngine.Random.Range(0f - deathExplosionRadius, deathExplosionRadius), UnityEngine.Random.Range(0f - deathExplosionRadius, deathExplosionRadius));
			float radius = explosionScale + UnityEngine.Random.Range(0f - deathExplosionScaleVariation, deathExplosionScaleVariation);
			UnityEngine.Object.Instantiate(explosionPrefab, position, Quaternion.identity).GetComponent<Explosion>().Initialize(this, radius, 0f);
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 1f));
		}
	}

	internal void DestroySelf()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public override void EMP(float duration)
	{
		if (!(sm.CurrentState.Key == "Reviving"))
		{
			if ((bool)base.HealthComponent)
			{
				base.HealthComponent.isEMPd = true;
			}
			EnemyManager.Instance.OnEnemyEMPd(this);
			if (sm != null)
			{
				sm.ForceState("EMP");
			}
			empDuration = duration;
		}
	}

	public override void OnEMPEnd()
	{
		if ((bool)base.HealthComponent)
		{
			base.HealthComponent.isEMPd = false;
		}
	}

	private void OnDestroy()
	{
		EnemyManager.Instance.UnregisterEnemy(this);
		foreach (Transform trail in trails)
		{
			trail.GetComponent<TireTrailController>().Detach();
		}
		foreach (Transform smoke in smokes)
		{
			smoke.GetComponent<TireSmokeController>().Detach();
		}
	}

	public virtual void OnFullDead()
	{
		CancelChainAttack();
	}

	public float GetCurrentTotalHealth()
	{
		return base.HealthComponent.HealthCurrent;
	}

	public float GetTotalMaxHealth()
	{
		return base.HealthComponent.HealthMax;
	}
}
