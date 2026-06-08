using System;
using System.Collections.Generic;
using UnityEngine;

public class DungeonTerminal : RoomItem, IBreakable, ICombatTarget, IDamagableObject, IHasHitpoints, ITargetLocation
{
	public DungeonTerminalType type;

	private bool accessed;

	public Material UnPoweredMaterial;

	public Material PoweredMaterial;

	public Material ActivatedMaterial;

	private DungeonManager _dungeonManager;

	private bool isPowerFlowing;

	private MonoBehaviour animatedTexture;

	private float guiCurrentHitpoints;

	private string _guiString = string.Empty;

	public override string ItemName
	{
		get
		{
			return "Access Terminal";
		}
	}

	public bool supportsDefenseCommand { get; set; }

	public bool supportsSurveyCommand { get; set; }

	public bool supportsShipScanCommand { get; set; }

	protected override bool _shouldShowHelpTextByDefault
	{
		get
		{
			return false;
		}
	}

	protected override HelpTextTypeEnum _helpTextType
	{
		get
		{
			return HelpTextTypeEnum.Terminal;
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
			return "terminal";
		}
	}

	virtual bool IHasHitpoints.IsDead
	{
		get
		{
			return base.IsDead;
		}
	}

	public override void Awake()
	{
		base.Awake();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void Start()
	{
		base.Start();
		CurrentHitPoints = TotalHitpoints;
		if (!base.IsDead)
		{
			SetInactive();
		}
		_dungeonManager = DungeonManager.Instance;
		droneUIObject.AddInfoCommand("interface");
		droneViewModelDefaultTransform.GetComponent<Renderer>().material = UnPoweredMaterial;
		animatedTexture = droneViewModelDefaultTransform.GetComponent<MonoBehaviour>();
		animatedTexture.enabled = false;
		Transform transform = base.transform.parent.Find("DVStatusOverlay");
		if (transform != null)
		{
			dvStatusOverlay = transform.gameObject;
			dvStatusOverlay.GetComponent<Renderer>().enabled = false;
		}
	}

	public override void BeginPowerFlow()
	{
		droneViewModelDefaultTransform.GetComponent<Renderer>().material = PoweredMaterial;
		animatedTexture.enabled = false;
		isPowerFlowing = true;
		base.BeginPowerFlow();
	}

	public override void EndPowerFlow()
	{
		droneViewModelDefaultTransform.GetComponent<Renderer>().material = UnPoweredMaterial;
		if (animatedTexture != null)
		{
			animatedTexture.enabled = false;
		}
		isPowerFlowing = false;
		base.EndPowerFlow();
	}

	public override void PowerUp(Drone drone)
	{
		if (!base.roomLocation.isPowered)
		{
			Debug.Log("Trying to powerup a terminal, with no power in the room");
			return;
		}
		accessed = true;
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			dvStatusOverlay.GetComponent<Renderer>().enabled = true;
			statusOverlayBlinkManager = new ColorBlinkManager();
			statusOverlayBlinkManager.Start(ActiveColor, Color.black, 0.1f, 10, false);
		}
		droneViewModelDefaultTransform.GetComponent<Renderer>().material = ActivatedMaterial;
		itemRenderer.material = PoweredMaterial;
		animatedTexture.enabled = true;
		if (!GlobalSettings.UseCombinedTerminal)
		{
			switch (type)
			{
			case DungeonTerminalType.Scan:
				_dungeonManager.SendConsoleMessage("Access Granted: Ship Scanner", ConsoleMessageType.Info);
				_dungeonManager.SendConsoleMessage("    new Command 'shipscan' availible", ConsoleMessageType.Info);
				break;
			case DungeonTerminalType.defense:
				_dungeonManager.SendConsoleMessage("Access Granted: Ship Defenses", ConsoleMessageType.Info);
				_dungeonManager.SendConsoleMessage("    new Command 'defense' availible", ConsoleMessageType.Info);
				break;
			}
		}
		else
		{
			TerminalManager.Instance.DisplayTerminalCommands(this);
		}
		SetActive();
		base.PowerUp(drone);
	}

	public override void PowerDown(Drone drone)
	{
		accessed = false;
		if (!isPowerFlowing)
		{
			droneViewModelDefaultTransform.GetComponent<Renderer>().material = UnPoweredMaterial;
			itemRenderer.material = UnPoweredMaterial;
		}
		else
		{
			droneViewModelDefaultTransform.GetComponent<Renderer>().material = PoweredMaterial;
			itemRenderer.material = PoweredMaterial;
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			dvStatusOverlay.GetComponent<Renderer>().enabled = true;
			statusOverlayBlinkManager = new ColorBlinkManager();
			statusOverlayBlinkManager.Start(Color.red, Color.black, 0.1f, 10, false);
		}
		animatedTexture.enabled = false;
		SetInactive();
		base.PowerDown(drone);
	}

	public override void Update()
	{
		base.Update();
		if (GlobalSettings.IsGamePaused || base.IsDead)
		{
			return;
		}
		if (!IsInvisibleDueToToggle && gameplayManager != null && !gameplayManager.showSchematicToggleItems)
		{
			SetSchematicVisibility(gameplayManager.showSchematicToggleItems);
		}
		if (IsStunned)
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
			itemRenderer.enabled = show;
			base.transform.GetChild(0).GetComponent<Renderer>().enabled = show;
			ModelViewRefresh(show);
		}
		else
		{
			itemRenderer.enabled = false;
			base.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
			ModelViewRefresh();
		}
	}

	public bool isActivated()
	{
		return accessed;
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
				itemRenderer.material = StunMtl;
			}
			else
			{
				itemRenderer.material = baseMtl;
			}
			SystemMessageManager.ShowSystemMessage("Terminal in Room " + base.roomLocation.Label + " stunned", ConsoleMessageType.Warning);
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
				itemRenderer.material = baseMtl;
			}
			GameplayManager.ShowConsoleMessage("Terminal in Room " + base.roomLocation.Label + " working.", ConsoleMessageType.Benefit);
		}
	}

	public void TakeDamage(float damage, DamageType type, ICombatTarget attacker)
	{
		TakeDamage(damage, type, attacker, false);
	}

	public void TakeDamage(float damage, DamageType type, ICombatTarget attacker, bool ignoreAlerts)
	{
		if (base.IsDead)
		{
			return;
		}
		CurrentHitPoints -= damage;
		if (CurrentHitPoints <= 0f)
		{
			CurrentHitPoints = 0f;
			accessed = false;
			base.IsDead = true;
			SetDead();
			if (!ignoreAlerts)
			{
				SystemMessageManager.ShowSystemMessage("Terminal in Room " + base.roomLocation.Label + " destroyed", ConsoleMessageType.Error);
			}
			if (DeathMtl != null)
			{
				itemRenderer.material = DeathMtl;
			}
		}
		else
		{
			if (DamageMtl != null)
			{
				itemRenderer.material = DamageMtl;
			}
			SetDamaged();
			if (!ignoreAlerts)
			{
				SystemMessageManager.ShowSystemMessage("Terminal in Room " + base.roomLocation.Label + " damaged", ConsoleMessageType.Warning);
			}
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
			itemRenderer.material = baseMtl;
			return true;
		}
		return false;
	}

	public void OverrideBrokenState(BrokenStateEnum state)
	{
	}
}
