using System;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDefense : RoomItem, IBreakable, ICombatTarget, IDamagableObject, IHasHitpoints, ITargetLocation
{
	public Material armedMtl;

	public Material disarmedMtl;

	private EnemyManager enemyManager;

	public bool armed;

	public AudioSource defenseFireSound;

	private float timer;

	private bool firstRot = true;

	private float rotDirection = 1f;

	private int rotCount;

	private float guiCurrentHitpoints;

	private string _guiString = string.Empty;

	public override string ItemName
	{
		get
		{
			return "Ship Defense";
		}
	}

	protected override bool _shouldShowHelpTextByDefault
	{
		get
		{
			return false;
		}
	}

	public Vector3 Position
	{
		get
		{
			return base.transform.position;
		}
	}

	public Collider ObjectCollider
	{
		get
		{
			return GetComponent<Collider>();
		}
	}

	public bool CanCollide
	{
		get
		{
			return true;
		}
	}

	public List<ICombatTarget> SubordinateTargets { get; set; }

	public bool IsHidden
	{
		get
		{
			return false;
		}
	}

	public Room CurrentRoom { get; set; }

	public Corridor CurrentCorridor { get; set; }

	public float CurrentHitPoints { get; private set; }

	public float TotalHitpoints
	{
		get
		{
			return 100f;
		}
	}

	public float TimeStunned { get; private set; }

	public bool IsStunned { get; private set; }

	public Vector3 StunPosition { get; private set; }

	public string guiStatus
	{
		get
		{
			if (guiCurrentHitpoints != CurrentHitPoints)
			{
				_guiString = " (" + Math.Round(CurrentHitPoints, 0) + ") ";
				guiCurrentHitpoints = CurrentHitPoints;
			}
			return _guiString;
		}
	}

	public BrokenStateEnum BrokenState
	{
		get
		{
			if (CurrentHitPoints == TotalHitpoints)
			{
				return BrokenStateEnum.OK;
			}
			if (CurrentHitPoints > 0f)
			{
				return BrokenStateEnum.ErrorsDetected;
			}
			return BrokenStateEnum.Broken;
		}
	}

	public string RepairId
	{
		get
		{
			return "defense";
		}
	}

	virtual bool IHasHitpoints.IsDead
	{
		get
		{
			return base.IsDead;
		}
	}

	public override void Start()
	{
		base.Start();
		CurrentHitPoints = TotalHitpoints;
		enemyManager = EnemyManager.Instance;
		droneManager = DroneManager.Instance;
		GetComponent<Renderer>().material = disarmedMtl;
		SetInactive();
	}

	protected override void OnDestroy()
	{
		armedMtl = null;
		disarmedMtl = null;
		defenseFireSound = null;
	}

	public override void Update()
	{
		base.Update();
		if (GlobalSettings.IsGamePaused)
		{
			return;
		}
		if (!IsInvisibleDueToToggle && gameplayManager != null && !gameplayManager.showSchematicToggleItems)
		{
			SetSchematicVisibility(gameplayManager.showSchematicToggleItems);
		}
		if (!IsStunned)
		{
			if (!Powered)
			{
				return;
			}
			rotCount++;
			if ((firstRot && rotCount > 85) || rotCount > 175)
			{
				if ((firstRot && rotCount > 95) || rotCount > 185)
				{
					firstRot = false;
					rotCount = 0;
					if (rotDirection > 0f)
					{
						rotDirection = -1f;
					}
					else
					{
						rotDirection = 1f;
					}
				}
				else
				{
					rotDirection *= 0.6f;
				}
			}
			droneViewModel.transform.Rotate(Vector3.forward, rotDirection);
			if (!armed)
			{
				return;
			}
			bool flag = false;
			int num = 0;
			timer += Time.deltaTime;
			if (timer < 0.5f)
			{
				GetComponent<Renderer>().material = disarmedMtl;
			}
			else if (timer < 1f)
			{
				GetComponent<Renderer>().material = armedMtl;
			}
			else
			{
				timer = 0f;
			}
			foreach (BaseEnemy enemy in enemyManager.Enemies)
			{
				if (enemy.CurrentRoom == base.roomLocation && !enemy.IsDead)
				{
					enemy.TakeDamage(1000f, DamageType.Physical, null);
					flag = true;
					num++;
				}
			}
			if (num > 0)
			{
				SystemMessageManager.ShowSystemMessage("Defense in Room " + base.roomLocation.Label + " killed " + num + " enemies", ConsoleMessageType.Warning);
			}
			num = 0;
			foreach (Drone drones in droneManager.dronesList)
			{
				if (drones.CurrentRoom == base.roomLocation && !drones.IsDead && !drones.IsHidden)
				{
					drones.TakeDamage(1000f, DamageType.Physical, null);
					flag = true;
					num++;
				}
			}
			if (num > 0)
			{
				SystemMessageManager.ShowSystemMessage("Defense in Room " + base.roomLocation.Label + " killed " + num + " enemies", ConsoleMessageType.Warning);
			}
			if (flag && GlobalSettings.cameraMode == CameraMode.Drone)
			{
				defenseFireSound.volume = GameAudio.RemoteVolume * 1f;
				defenseFireSound.Play();
			}
		}
		else
		{
			TimeStunned -= Time.deltaTime;
			if (TimeStunned <= 0f)
			{
				ClearStun();
			}
		}
	}

	public override void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			GetComponent<Renderer>().enabled = show;
			if (armed)
			{
				GetComponent<Renderer>().material = armedMtl;
			}
			else
			{
				GetComponent<Renderer>().material = disarmedMtl;
			}
			ModelViewRefresh(show);
		}
		else
		{
			if (defenseFireSound.isPlaying)
			{
				defenseFireSound.Stop();
			}
			GetComponent<Renderer>().enabled = false;
			ModelViewRefresh();
		}
	}

	public bool toggleArmed()
	{
		armed = !armed;
		if (armed)
		{
			GetComponent<Renderer>().material = armedMtl;
			SetActive();
		}
		else
		{
			GetComponent<Renderer>().material = disarmedMtl;
			SetInactive();
		}
		return armed;
	}

	public override void PowerDown(Drone drone)
	{
		if (armed)
		{
			toggleArmed();
		}
	}

	public void Stun(float durationMin, float durationMax)
	{
		if (base.IsDead)
		{
			return;
		}
		float num = UnityEngine.Random.Range(durationMin, durationMax);
		if (!IsStunned)
		{
			TimeStunned = num;
			PowerDown(null);
			if (StunMtl != null)
			{
				GetComponent<Renderer>().material = StunMtl;
			}
			else
			{
				GetComponent<Renderer>().material = baseMtl;
			}
			SystemMessageManager.ShowSystemMessage("Defense in Room " + base.roomLocation.Label + " stunned", ConsoleMessageType.Warning);
		}
		else
		{
			TimeStunned += num;
		}
		IsStunned = true;
	}

	public void ClearStun()
	{
		TimeStunned = 0f;
		IsStunned = false;
		if (!base.IsDead)
		{
			if (baseMtl != null)
			{
				GetComponent<Renderer>().material = baseMtl;
			}
			GameplayManager.ShowConsoleMessage("Defense in Room " + base.roomLocation.Label + " working.", ConsoleMessageType.Benefit);
		}
	}

	public void TakeDamage(float damage, DamageType type, ICombatTarget attacker)
	{
		if (base.IsDead)
		{
			return;
		}
		CurrentHitPoints -= damage;
		if (CurrentHitPoints <= 0f)
		{
			CurrentHitPoints = 0f;
			armed = false;
			base.IsDead = true;
			SystemMessageManager.ShowSystemMessage("Defense in Room " + base.roomLocation.Label + " destroyed", ConsoleMessageType.Error);
			SetDead();
			if (DeathMtl != null)
			{
				GetComponent<Renderer>().material = DeathMtl;
			}
		}
		else
		{
			if (DamageMtl != null)
			{
				GetComponent<Renderer>().material = DamageMtl;
			}
			SetDamaged();
			SystemMessageManager.ShowSystemMessage("Defense in Room " + base.roomLocation.Label + " damaged", ConsoleMessageType.Warning);
		}
	}

	public void MissedTarget(ICombatTarget target, float attackDamage)
	{
	}

	public void RegisterDirectionalHit(Vector3 force)
	{
	}

	public void ReduceQuality()
	{
		TakeDamage(TotalHitpoints / 2f, DamageType.Physical, null);
	}

	public void Break()
	{
		TakeDamage(9999999f, DamageType.Physical, null);
	}

	public bool Fix(out string fixMessage)
	{
		fixMessage = string.Empty;
		if (base.IsDead)
		{
			base.IsDead = false;
			CurrentHitPoints = TotalHitpoints;
			GetComponent<Renderer>().material = baseMtl;
			return true;
		}
		return false;
	}

	public void OverrideBrokenState(BrokenStateEnum state)
	{
	}
}
