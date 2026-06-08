using System;
using System.Collections.Generic;
using UnityEngine;

public class FuelAccess : RoomItem, ICombatTarget, IDamagableObject, IHasHitpoints, ITargetLocation, IMetaData
{
	private Material fuelMat;

	private float guiCurrentHitpoints;

	private string _guiString = string.Empty;

	public bool hasBeenAccessedAtLeastOnce { get; set; }

	public bool hasFuel
	{
		get
		{
			return countPropulsionFuel > 0 || countJumpFuel > 0;
		}
	}

	public int countPropulsionFuel { get; set; }

	public int countJumpFuel { get; set; }

	public override string ItemName
	{
		get
		{
			return "Fuel Access Point";
		}
	}

	protected override HelpTextTypeEnum _helpTextType
	{
		get
		{
			return HelpTextTypeEnum.FuelAccess;
		}
	}

	public List<DesignedDungeonManager.MetaData> metaDataList { get; set; }

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

	virtual bool IHasHitpoints.IsDead
	{
		get
		{
			return base.IsDead;
		}
	}

	public string GetMetaData(string name)
	{
		if (metaDataList != null)
		{
			foreach (DesignedDungeonManager.MetaData metaData in metaDataList)
			{
				if (metaData.name == name)
				{
					return metaData.value;
				}
			}
		}
		return string.Empty;
	}

	public override void Awake()
	{
		base.Awake();
	}

	public override void Start()
	{
		base.Start();
		string text = "default";
		SkinEnum currentSkin = GlobalSettings.GameState.CurrentSkin;
		if (currentSkin == SkinEnum.Halloween)
		{
			text = "halloween";
		}
		Texture2D dvTexture = ResourceManager.LoadAsset<Texture2D>("skins/" + text + "/ui/droneview/fuelSource_vector");
		Texture2D svTexture = ResourceManager.LoadAsset<Texture2D>("skins/" + text + "/ui/schematic/fuelSchematic");
		droneUIObject.SetTextureOnObject(0, dvTexture, 0, svTexture);
		droneUIObject.AddInfoCommand("gather");
		fuelMat = GetComponent<Renderer>().material;
	}

	public override void Update()
	{
		base.Update();
		if (droneUIObject.Visible)
		{
			Vector3 pos = new Vector3(base.transform.position.x + 3.5f, base.transform.position.y + 1.25f, base.transform.position.z);
			OverrideInfoLabelPos(pos);
		}
	}

	public override void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			ModelViewRefresh(show);
		}
		else
		{
			ModelViewRefresh();
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
			if (!fuelMat)
			{
				fuelMat = GetComponent<Renderer>().material;
			}
			if (StunMtl != null)
			{
				fuelMat = StunMtl;
			}
			else
			{
				fuelMat = baseMtl;
			}
			SystemMessageManager.ShowSystemMessage("Fuel Access in Room " + base.roomLocation.Label + " stunned", ConsoleMessageType.Warning);
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
			if (!fuelMat)
			{
				fuelMat = GetComponent<Renderer>().material;
			}
			if (baseMtl != null)
			{
				fuelMat = baseMtl;
			}
			GameplayManager.ShowConsoleMessage("Fuel Access in Room " + base.roomLocation.Label + " working.", ConsoleMessageType.Benefit);
		}
	}

	public void TakeDamage(float damage, DamageType type, ICombatTarget attacker)
	{
		if (base.IsDead)
		{
			return;
		}
		CurrentHitPoints -= damage;
		if (!fuelMat)
		{
			fuelMat = GetComponent<Renderer>().material;
		}
		if (CurrentHitPoints <= 0f)
		{
			CurrentHitPoints = 0f;
			if (Powered)
			{
				PowerDown(null);
			}
			base.IsDead = true;
			SetDead();
			SystemMessageManager.ShowSystemMessage("Fuel Access in Room " + base.roomLocation.Label + " destroyed", ConsoleMessageType.Error);
			if (DeathMtl != null)
			{
				fuelMat = DeathMtl;
			}
		}
		else
		{
			if (DamageMtl != null)
			{
				fuelMat = DamageMtl;
			}
			SetDamaged();
			SystemMessageManager.ShowSystemMessage("Fuel Access in Room " + base.roomLocation.Label + " damaged", ConsoleMessageType.Warning);
		}
	}

	public void MissedTarget(ICombatTarget target, float attackDamage)
	{
	}

	public void RegisterDirectionalHit(Vector3 force)
	{
	}
}
