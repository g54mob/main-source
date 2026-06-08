using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BruteTurretUpgrade : BaseDroneUpgrade, IWeapon, IStorageUpgrade, IUpdateCameraView
{
	private const string COMMAND_VALUE = "turret";

	private const float attackSpeed = 0.05f;

	private const float attackDamage = 15f;

	private const DamageType attackDamageType = DamageType.Physical;

	private const float attackRadius = 4f;

	private static List<CommandDefinition> commandList;

	private UpgradeState state = UpgradeState.Disarmed;

	public UpgradeState previousState = UpgradeState.Disarmed;

	private float lastAttackTime;

	private bool isFiring;

	private int _numberOfBullets = 100;

	private Dictionary<ICombatTarget, float> possibleTargets = new Dictionary<ICombatTarget, float>(50);

	private int guiCapacity;

	private int guiQuantity;

	private string _guiString = string.Empty;

	public override string CommandValue
	{
		get
		{
			return "turret";
		}
	}

	public int Capacity
	{
		get
		{
			return _numberOfBullets;
		}
	}

	public int Quantity { get; private set; }

	public string guiStatus
	{
		get
		{
			if (guiCapacity != Capacity || guiQuantity != Quantity)
			{
				_guiString = " (" + Quantity + "/" + Capacity + ") ";
				guiCapacity = Capacity;
				guiQuantity = Quantity;
			}
			return _guiString;
		}
	}

	public BruteTurretUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
		Quantity = Capacity;
	}

	protected override void OnUpdate()
	{
		if (GlobalSettings.IsGamePaused)
		{
			return;
		}
		if (state != UpgradeState.Disarmed && drone.isMoving && !drone.IsBraking)
		{
			Disarm();
			SendConsoleResponseMessage("Turret disabled", ConsoleMessageType.UpgradeStateChange);
		}
		if (state != UpgradeState.Armed || Quantity <= 0 || !(Time.time - lastAttackTime > 0.05f))
		{
			return;
		}
		possibleTargets.Clear();
		int count = drone.enemies.Count;
		for (int i = 0; i < count; i++)
		{
			BaseEnemy baseEnemy = drone.enemies[i];
			if (baseEnemy is DronesBestFriend)
			{
				continue;
			}
			ICombatTarget combatTarget = baseEnemy;
			if (!combatTarget.CanCollide)
			{
				continue;
			}
			bool flag = false;
			if (drone.CurrentRoom != null && combatTarget.CurrentRoom != null && drone.CurrentRoom != combatTarget.CurrentRoom)
			{
				if (!combatTarget.CurrentRoom.IsVisible)
				{
					flag = true;
				}
				else
				{
					flag = true;
					int count2 = drone.CurrentRoom.corridors.Count;
					for (int j = 0; j < count2; j++)
					{
						if (drone.CurrentRoom.corridors[j].getOtherRoom(drone.CurrentRoom) == combatTarget.CurrentRoom)
						{
							flag = false;
							break;
						}
					}
				}
			}
			float num = 0f;
			if (combatTarget.IsDead || flag)
			{
				continue;
			}
			num = Vector3.Distance(drone.transform.position, combatTarget.Position);
			if (num <= 4f)
			{
				Vector3 to = baseEnemy.transform.position - drone.transform.position;
				Vector3 up = drone.transform.up;
				up.Normalize();
				float f = Vector3.Angle(up, to);
				if (Mathf.Abs(f) <= 45f || Mathf.Abs(f) >= 315f)
				{
					possibleTargets.Add(combatTarget, num);
				}
			}
		}
		if (possibleTargets.Count > 0)
		{
			if (!isFiring)
			{
				isFiring = true;
				if (Quantity > 0)
				{
					GameAudio.Play2DSFX(GameAudio.SoundEnum.WeaponTriggered);
					if (GlobalSettings.cameraMode == CameraMode.Drone)
					{
						drone.turretSound.volume = GameAudio.RemoteVolume * 1f;
						drone.turretSound.Play();
					}
				}
			}
			KeyValuePair<ICombatTarget, float> keyValuePair = possibleTargets.First();
			Quantity -= 1;
			if (Quantity <= 0)
			{
				drone.turretSound.Stop();
			}
			if (SchematicViewCanvas.Instance != null)
			{
				SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
			}
			if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
			{
				DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
			}
			ProjectileManager.Instance().LaunchProjectile(ProjectileTypeEnum.Small, drone, keyValuePair.Key, 15f, DamageType.Physical, 2f, 95, true);
			lastAttackTime = Time.time;
		}
		else
		{
			isFiring = false;
			drone.turretSound.Stop();
		}
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("BruteTurretUpgrade"));
		}
		return commandList;
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		if (!base.PoweredUp)
		{
			return;
		}
		switch (command.Command.CommandName)
		{
		case "turret":
			command.Handled = true;
			if (command.Arguments.Count > 0 && (command.Arguments.Count > 1 || command.Arguments[0].ToLower() != "all"))
			{
				if (command.Arguments.Last().ToLower() == "on" && state == UpgradeState.Disarmed)
				{
					Arm();
				}
				else if (command.Arguments.Last().ToLower() == "off" && (state == UpgradeState.Armed || state == UpgradeState.SafteyMode))
				{
					Disarm();
					SendConsoleResponseMessage("turret gun disarmed", ConsoleMessageType.Info);
				}
				break;
			}
			switch (state)
			{
			case UpgradeState.Armed:
			case UpgradeState.SafteyMode:
				Disarm();
				SendConsoleResponseMessage("turret gun disarmed", ConsoleMessageType.Info);
				break;
			case UpgradeState.Disarmed:
				Arm();
				break;
			case UpgradeState.Arming:
			case UpgradeState.Disarming:
				break;
			}
			break;
		}
	}

	public void Arm()
	{
		ActivateAbility();
	}

	public void Disarm()
	{
		CancelAbility();
	}

	public override bool ActivateAbility()
	{
		if (!base.ActivateAbility())
		{
			return false;
		}
		state = UpgradeState.Armed;
		UpdateCameraView();
		SendConsoleResponseMessage("turret gun armed", ConsoleMessageType.Info);
		float angle = 0f;
		Vector3 axis = Vector3.zero;
		drone.transform.rotation.ToAngleAxis(out angle, out axis);
		if (SchematicViewCanvas.Instance != null)
		{
			SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
		}
		if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
		{
			DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
		}
		return true;
	}

	public override void CancelAbility()
	{
		base.CancelAbility();
		isFiring = false;
		state = UpgradeState.Disarmed;
		UpdateCameraView();
		if (SchematicViewCanvas.Instance != null)
		{
			SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
		}
		if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
		{
			DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
		}
	}

	public bool isArmed()
	{
		return state == UpgradeState.Armed;
	}

	public bool isSaftey()
	{
		return state == UpgradeState.SafteyMode;
	}

	public void EngageSaftey(bool engageSaftey)
	{
		if (engageSaftey && state == UpgradeState.Armed)
		{
			previousState = state;
			state = UpgradeState.SafteyMode;
			UpdateCameraView();
			SendConsoleResponseMessage("turret gun: saftey activated", ConsoleMessageType.Warning);
		}
		else if (!engageSaftey && state == UpgradeState.SafteyMode)
		{
			state = previousState;
			previousState = UpgradeState.SafteyMode;
			UpdateCameraView();
			SendConsoleResponseMessage("turret gun: saftey deactivated", ConsoleMessageType.Warning);
		}
	}

	public void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			switch (state)
			{
			case UpgradeState.Armed:
			{
				drone.TurretUIObject.GetComponent<Renderer>().material = drone.DroneViewGatGunOnMtl;
				Color color3 = drone.TurretUIObject.GetComponent<Renderer>().material.color;
				if (GameSaveFile.Get("Q_STATIC_HONLY", true))
				{
					color3.a = 0.5882353f;
				}
				else
				{
					color3.a = 26f / 51f;
				}
				drone.TurretUIObject.GetComponent<Renderer>().material.color = color3;
				break;
			}
			case UpgradeState.Disarmed:
			{
				drone.TurretUIObject.GetComponent<Renderer>().material = drone.DroneViewGatGunOffMtl;
				Color color2 = drone.TurretUIObject.GetComponent<Renderer>().material.color;
				if (GameSaveFile.Get("Q_STATIC_HONLY", true))
				{
					color2.a = 37f / 51f;
				}
				else
				{
					color2.a = 0.6039216f;
				}
				drone.TurretUIObject.GetComponent<Renderer>().material.color = color2;
				break;
			}
			case UpgradeState.SafteyMode:
			{
				drone.TurretUIObject.GetComponent<Renderer>().material = drone.DroneViewGatGunSafteyMtl;
				Color color = drone.TurretUIObject.GetComponent<Renderer>().material.color;
				if (GameSaveFile.Get("Q_STATIC_HONLY", true))
				{
					color.a = (color.a = 1f / 3f);
				}
				else
				{
					color.a = (color.a = 13f / 51f);
				}
				drone.TurretUIObject.GetComponent<Renderer>().material.color = color;
				break;
			}
			}
			if (isFiring && Quantity > 0)
			{
				drone.turretSound.volume = GameAudio.RemoteVolume * 1f;
				drone.turretSound.Play();
			}
		}
		else
		{
			switch (state)
			{
			case UpgradeState.Armed:
				drone.TurretUIObject.GetComponent<Renderer>().material = drone.SchematicViewGatGunOnMtl;
				break;
			case UpgradeState.Disarmed:
				drone.TurretUIObject.GetComponent<Renderer>().material = drone.SchematicViewGatGunOffMtl;
				break;
			case UpgradeState.SafteyMode:
				drone.TurretUIObject.GetComponent<Renderer>().material = drone.SchematicViewGatGunSafteyMtl;
				break;
			}
			if (drone.turretSound.isPlaying)
			{
				drone.turretSound.Pause();
			}
		}
	}

	public override void PowerUp()
	{
		base.PowerUp();
		drone.TurretUIObject.GetComponent<Renderer>().enabled = true;
		UpdateCameraView();
	}

	public override void PowerDown()
	{
		base.PowerDown();
		state = UpgradeState.Disarmed;
		if (drone.TurretUIObject != null && drone.GetUpgradeInstanceCount(DroneUpgradeType.BruteTurret) <= 1)
		{
			drone.TurretUIObject.GetComponent<Renderer>().enabled = false;
		}
	}

	public void AddItem(int count)
	{
	}

	public void OverrideQuantity(int qty)
	{
		if (qty < Capacity)
		{
			Quantity = qty;
		}
		else
		{
			Quantity = Capacity;
		}
	}
}
