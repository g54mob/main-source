using System;
using System.Collections.Generic;
using UnityEngine;

public class E3_B_WIP : EnemyBase, iMainBossController, iBossController
{
	[Header("WIP Fields")]
	[SerializeField]
	private GameObject attackPlane;

	[SerializeField]
	private GameObject supportPlane;

	[SerializeField]
	private GameObject disruptorPlane;

	[SerializeField]
	private GameObject BFP;

	[SerializeField]
	public float bombardmentStartingCooldown;

	[SerializeField]
	public float bombardmentCooldown;

	[SerializeField]
	private int coreDropAmount;

	private float bombardmentTimer;

	[NonSerialized]
	public E3_B_Phase1Plane_Attacker attacker;

	[NonSerialized]
	public E3_B_Phase1Plane_Support support;

	[NonSerialized]
	public E3_B_Phase1Plane_Disruptor disrupter;

	private int numberOfPlanesDead;

	private bool planesSpawned;

	public float bossMaxHealth;

	public float AttackerHealth
	{
		get
		{
			if (!attacker)
			{
				return 0f;
			}
			return attacker.GetCurrentTotalHealth();
		}
	}

	public bool AttackerDead
	{
		get
		{
			if (!attacker)
			{
				return true;
			}
			return attacker.IsDead;
		}
	}

	public float SupportHealth
	{
		get
		{
			if (!support)
			{
				return 0f;
			}
			return support.GetCurrentTotalHealth();
		}
	}

	public bool SupportDead
	{
		get
		{
			if (!support)
			{
				return true;
			}
			return support.IsDead;
		}
	}

	public float DisrupterHealth
	{
		get
		{
			if (!disrupter)
			{
				return 0f;
			}
			return disrupter.GetCurrentTotalHealth();
		}
	}

	public bool DisrupterDead
	{
		get
		{
			if (!disrupter)
			{
				return true;
			}
			return disrupter.IsDead;
		}
	}

	public event Action ControllerDied;

	private new void Awake()
	{
		base.Awake();
		previousPos = base.transform.position;
		noiseSeed = UnityEngine.Random.Range(0, 100000);
	}

	private void SpawnPlanes()
	{
		GameObject gameObject = EnemyManager.Instance.SpawnEnemy(attackPlane);
		attacker = gameObject.GetComponent<E3_B_Phase1Plane_Attacker>();
		attacker.bossController = this;
		GameObject gameObject2 = EnemyManager.Instance.SpawnEnemy(supportPlane);
		support = gameObject2.GetComponent<E3_B_Phase1Plane_Support>();
		support.bossController = this;
		GameObject gameObject3 = EnemyManager.Instance.SpawnEnemy(disruptorPlane);
		disrupter = gameObject3.GetComponent<E3_B_Phase1Plane_Disruptor>();
		disrupter.bossController = this;
		planesSpawned = true;
		bombardmentTimer = bombardmentStartingCooldown;
		GameManager.Instance.ringMinigame.OnEndMinigame += OnBombardmentEnd;
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			bombardmentTimer -= Time.deltaTime;
			if (bombardmentTimer < 0f && !GameManager.Instance.minigameInProgress)
			{
				StartBombardment();
			}
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
		base.Move();
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		GameManager.Instance.ringMinigame.EndMinigame();
		LevelManager.Instance.HandleBossBeaten(coreDropAmount);
		base.OnDeath(info);
	}

	public float GetCurrentTotalHealth()
	{
		if (!planesSpawned)
		{
			return bossMaxHealth;
		}
		float num = 0f;
		if ((bool)attacker && !attacker.HealthComponent.IsDead)
		{
			num += attacker.HealthComponent.HealthCurrent;
		}
		if ((bool)support && !support.HealthComponent.IsDead)
		{
			num += support.HealthComponent.HealthCurrent;
		}
		if ((bool)disrupter && !disrupter.HealthComponent.IsDead)
		{
			num += disrupter.HealthComponent.HealthCurrent;
		}
		return num;
	}

	public float GetTotalMaxHealth()
	{
		return bossMaxHealth;
	}

	public void OnBombardmentEnd()
	{
		bombardmentTimer = bombardmentCooldown;
		if ((bool)attacker)
		{
			attacker.sm.ForceState("Idle");
			attacker.secondary.sm.ForceState("Idle");
		}
		if ((bool)disrupter)
		{
			disrupter.sm.ForceState("Idle");
			disrupter.secondary.sm.ForceState("Idle");
		}
		if ((bool)support)
		{
			support.sm.ForceState("Idle");
			support.secondary.sm.ForceState("Idle");
		}
	}

	public void StartBombardment()
	{
		GameManager.Instance.ringMinigame.StartMinigame();
		if ((bool)attacker)
		{
			attacker.sm.ForceState("Bombardment");
			attacker.secondary.sm.ForceState("Retreat");
		}
		if ((bool)disrupter)
		{
			disrupter.sm.ForceState("Bombardment");
			disrupter.secondary.sm.ForceState("Retreat");
			disrupter.secondary.Deactivate();
		}
		if ((bool)support)
		{
			support.sm.ForceState("Bombardment");
			support.secondary.sm.ForceState("Retreat");
		}
	}

	public void AlertOfPlaneDeath()
	{
		numberOfPlanesDead++;
		if (numberOfPlanesDead >= 3)
		{
			EnemyManager.Instance.OnBirdTrioDestroyed();
			this.ControllerDied?.Invoke();
			KillSelf();
		}
	}

	public List<iBossController> GetAllControllers()
	{
		SpawnPlanes();
		return new List<iBossController> { attacker, disrupter, support };
	}
}
