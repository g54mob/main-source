using System.Collections.Generic;
using UnityEngine;

public class SwarmTurretUpgrade : BaseDroneUpgrade, IWeapon, IUpdateCameraView
{
	private const string COMMAND_VALUE = "theupgradeformerlyknownasturret";

	private const int NUMBER_OF_TARGETS = 5;

	private UpgradeState state = UpgradeState.Disarmed;

	public UpgradeState previousState = UpgradeState.Disarmed;

	private float attackSpeed = 0.5f;

	private float attackDamage = 10f;

	private DamageType attackDamageType = DamageType.Physical;

	private float attackRadius = 2.5f;

	private float lastAttackTime;

	private Dictionary<ICombatTarget, float> possibleTargets = new Dictionary<ICombatTarget, float>(50);

	public override string CommandValue
	{
		get
		{
			return "theupgradeformerlyknownasturret";
		}
	}

	public SwarmTurretUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
	}

	protected override void OnUpdate()
	{
		if (GlobalSettings.IsGamePaused)
		{
			return;
		}
		if (state != UpgradeState.Disarmed && drone.isMoving)
		{
			Disarm();
		}
		if (state != UpgradeState.Armed || !(Time.time - lastAttackTime > attackSpeed))
		{
			return;
		}
		possibleTargets.Clear();
		foreach (BaseEnemy enemy in drone.enemies)
		{
			if (enemy is DronesBestFriend)
			{
				continue;
			}
			ICombatTarget combatTarget = enemy;
			if (!combatTarget.CanCollide)
			{
				continue;
			}
			bool flag = false;
			if (drone.CurrentRoom != null && combatTarget.CurrentRoom != null && drone.CurrentRoom != combatTarget.CurrentRoom)
			{
				flag = true;
			}
			float distance = 0f;
			if (!flag)
			{
				distance = Vector3.Distance(drone.transform.position, combatTarget.Position);
			}
			if (!combatTarget.IsDead && !flag && distance <= attackRadius)
			{
				possibleTargets.Add(combatTarget, distance);
				combatTarget.SubordinateTargets.ForEach(delegate(ICombatTarget x)
				{
					possibleTargets.Add(x, distance);
				});
			}
		}
		int num = 0;
		foreach (KeyValuePair<ICombatTarget, float> possibleTarget in possibleTargets)
		{
			if (num++ < 5)
			{
				ProjectileManager.Instance().LaunchProjectile(ProjectileTypeEnum.Small, drone, possibleTarget.Key, attackDamage, attackDamageType, 95);
			}
		}
		if (num > 0)
		{
			lastAttackTime = Time.time;
		}
	}

	public void MissedTarget(ICombatTarget target, float attackDamage)
	{
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		return CommandHelper.GetCommands("SwarmTurretUpgrade");
	}

	public override void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		if (!base.PoweredUp)
		{
			return;
		}
		switch (command.Command.CommandName)
		{
		case "theupgradeformerlyknownasturret":
			command.Handled = true;
			if (command.Arguments.Count > 0)
			{
				if (command.Arguments[0].ToLower() == "on" && state == UpgradeState.Disarmed)
				{
					Arm();
				}
				else if (command.Arguments[0].ToLower() == "off" && (state == UpgradeState.Armed || state == UpgradeState.SafteyMode))
				{
					Disarm();
				}
				break;
			}
			switch (state)
			{
			case UpgradeState.Armed:
			case UpgradeState.SafteyMode:
				Disarm();
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
		SendConsoleResponseMessage("swarm turret armed", ConsoleMessageType.Info);
		return true;
	}

	public override void CancelAbility()
	{
		base.CancelAbility();
		state = UpgradeState.Disarmed;
		UpdateCameraView();
		SendConsoleResponseMessage("swarm turret disarmed", ConsoleMessageType.Info);
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
			SendConsoleResponseMessage("swarm turret: saftey activated", ConsoleMessageType.Warning);
		}
		else if (!engageSaftey && state == UpgradeState.SafteyMode)
		{
			state = previousState;
			previousState = UpgradeState.SafteyMode;
			UpdateCameraView();
			SendConsoleResponseMessage("swarm turret: saftey deactivated", ConsoleMessageType.Warning);
		}
	}

	public void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			switch (state)
			{
			case UpgradeState.Armed:
				drone.TurretUIObject.GetComponent<Renderer>().material = drone.DroneViewTurretOnMtl;
				break;
			case UpgradeState.Disarmed:
			{
				drone.TurretUIObject.GetComponent<Renderer>().material = drone.DroneViewTurretOffMtl;
				Color color = drone.TurretUIObject.GetComponent<Renderer>().material.color;
				if (GameSaveFile.Get("Q_STATIC_HONLY", true))
				{
					color.a = 175f;
				}
				else
				{
					color.a = 154f;
				}
				drone.TurretUIObject.GetComponent<Renderer>().material.color = color;
				break;
			}
			case UpgradeState.SafteyMode:
				drone.TurretUIObject.GetComponent<Renderer>().material = drone.DroneViewTurretSafteyMtl;
				break;
			case UpgradeState.Arming:
			case UpgradeState.Disarming:
				break;
			}
		}
		else
		{
			switch (state)
			{
			case UpgradeState.Armed:
				drone.TurretUIObject.GetComponent<Renderer>().material = drone.SchematicViewTurretOnMtl;
				break;
			case UpgradeState.Disarmed:
				drone.TurretUIObject.GetComponent<Renderer>().material = drone.SchematicViewTurretOffMtl;
				break;
			case UpgradeState.SafteyMode:
				drone.TurretUIObject.GetComponent<Renderer>().material = drone.SchematicViewTurretSafteyMtl;
				break;
			case UpgradeState.Arming:
			case UpgradeState.Disarming:
				break;
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
		if (drone.GetUpgradeInstanceCount(DroneUpgradeType.SwarmTurret) <= 1)
		{
			drone.TurretUIObject.GetComponent<Renderer>().enabled = false;
		}
	}
}
