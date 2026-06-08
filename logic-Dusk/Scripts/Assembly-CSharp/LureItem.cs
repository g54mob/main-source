using System;
using System.Collections.Generic;
using UnityEngine;

public class LureItem : DropableItem, ICombatTarget, IDamagableObject, IHasHitpoints, ITargetLocation, IUpdateCameraView
{
	public Material NormalMtl;

	private float _currentHitPoints;

	private bool _isDead;

	private ColorBlinkManager _blinkManager = new ColorBlinkManager();

	private float guiCurrentHitpoints;

	private string _guiString = string.Empty;

	public override DropItemType DropType
	{
		get
		{
			return DropItemType.Lure;
		}
	}

	public bool hasBeenAttacked { get; private set; }

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

	public float CurrentHitPoints
	{
		get
		{
			return _currentHitPoints;
		}
	}

	public float TotalHitpoints
	{
		get
		{
			return 1000f;
		}
	}

	public float TimeStunned { get; private set; }

	public bool IsDead
	{
		get
		{
			return _isDead;
		}
	}

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

	public void Initialize(Room room, Corridor corridor)
	{
		CurrentRoom = room;
		CurrentCorridor = corridor;
	}

	private void Awake()
	{
		SubordinateTargets = new List<ICombatTarget>();
	}

	public override void Start()
	{
		_currentHitPoints = TotalHitpoints;
		thisMat = GetComponent<Renderer>().material;
		thisMat = NormalMtl;
		base.Start();
		UpdateCameraView();
	}

	protected override void Update()
	{
		if (!GlobalSettings.IsGamePaused && _blinkManager.IsActive)
		{
			Color color = _blinkManager.Update(Time.deltaTime);
			thisMat.color = color;
			if (!dvOverlayObjectMat)
			{
				dvOverlayObjectMat = dvOverlayObject.GetComponent<Renderer>().material;
			}
			if (!svOverlayObject)
			{
				svOverlayObjectMat = svOverlayObject.GetComponent<Renderer>().material;
			}
			if (dvOverlayObject != null)
			{
				dvOverlayObjectMat.color = color;
			}
			if (svOverlayObject != null)
			{
				svOverlayObjectMat.color = color;
			}
			if (IsDead)
			{
				SetDead();
			}
		}
		base.Update();
	}

	public override void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (droneUIObject != null)
			{
				GetComponent<Renderer>().enabled = !droneUIObject.Deactivated;
			}
			if (IsDead)
			{
				thisMat = DeathMtl;
			}
			else
			{
				thisMat = NormalMtl;
			}
		}
		else if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			GetComponent<Renderer>().enabled = false;
		}
	}

	public void Stun(float durationMin, float durationMax)
	{
	}

	public void ClearStun()
	{
	}

	public void TakeDamage(float damage, DamageType type, ICombatTarget attacker)
	{
		if (!IsDead)
		{
			if (attacker != null && !hasBeenAttacked)
			{
				SystemMessageManager.ShowSystemMessage("Lure attacked in Room " + CurrentRoom.Label, ConsoleMessageType.Warning);
				hasBeenAttacked = true;
			}
			_blinkManager.Start(ActiveColor, DamageColor, 0.2f, 2);
			_currentHitPoints -= damage;
			if (_currentHitPoints <= 0f)
			{
				_currentHitPoints = 0f;
				_isDead = true;
				base.Destroyed = true;
				SetDead();
			}
		}
	}

	public void MissedTarget(ICombatTarget target, float attackDamage)
	{
	}

	public void RegisterDirectionalHit(Vector3 force)
	{
	}
}
