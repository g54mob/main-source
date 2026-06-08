using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SonicUpgrade : BaseDroneUpgrade, IPoweredObject, IUpdateCameraView
{
	private const string COMMAND_VALUE = "sonic";

	private const float VISUAL_TOGGLE_DURATION = 0.3f;

	private static List<CommandDefinition> commandList;

	private float _visualToggleTimer;

	private bool _delayRechargeState;

	private float guiCurrentPower;

	private string _guiString = string.Empty;

	public override string CommandValue
	{
		get
		{
			return "sonic";
		}
	}

	public float CurrentPower { get; private set; }

	public float TotalPower
	{
		get
		{
			return 100f;
		}
	}

	public bool IsCharging { get; private set; }

	public bool CanRecharge
	{
		get
		{
			return (AppliedModifications & ModificationStorageIdEnum.SonicRecharge) == ModificationStorageIdEnum.SonicRecharge;
		}
	}

	public bool ShowPercentage
	{
		get
		{
			return false;
		}
	}

	public string guiStatus
	{
		get
		{
			if (guiCurrentPower != CurrentPower)
			{
				_guiString = " (" + Math.Round(CurrentPower, 0) + ") ";
				guiCurrentPower = CurrentPower;
			}
			return _guiString;
		}
	}

	public SonicUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
	}

	public void OverridePower(float power)
	{
		if (power <= TotalPower)
		{
			CurrentPower = power;
		}
		else
		{
			CurrentPower = TotalPower;
		}
		if (drone != null)
		{
			if (SchematicViewCanvas.Instance != null)
			{
				SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
			}
			if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
			{
				DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
			}
		}
	}

	protected override void OnUpdate()
	{
		if (base.IsActivated && drone.isMoving && !drone.IsBraking)
		{
			CancelAbility();
			SendConsoleResponseMessage("Sonic pulse deactivated", ConsoleMessageType.UpgradeStateChange);
		}
		if (!IsCharging && !_delayRechargeState && base.IsActivated)
		{
			_visualToggleTimer -= Time.deltaTime;
			if (_visualToggleTimer <= 0f)
			{
				_visualToggleTimer = 0.3f;
				drone.StartColorBlink(Color.yellow, 0.3f, 1);
			}
			CurrentPower -= 0.8f * Time.deltaTime;
			if (SchematicViewCanvas.Instance != null)
			{
				SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
			}
			if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
			{
				DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
			}
			if (CurrentPower <= 0f)
			{
				CancelAbility();
			}
		}
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("SonicUpgrade"));
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
		case "sonic":
		{
			bool flag = false;
			command.Handled = true;
			if (command.Arguments.Count == 2 || (command.Arguments.Count == 1 && command.Arguments[0].ToLower() != "all"))
			{
				if (command.Arguments.Last().ToLower() == "on")
				{
					if (drone.isMovingForwardBack && !drone.IsBraking)
					{
						drone.StopPriorNavigation();
					}
					if (!base.IsActivated)
					{
						if (!ActivateAbility())
						{
							break;
						}
						drone.sonicSound.Play();
						drone.sonicSound.volume = GameAudio.RemoteVolume * 1f;
						IsCharging = false;
					}
				}
				else if (command.Arguments.Last().ToLower() == "off")
				{
					if (base.IsActivated)
					{
						CancelAbility();
						drone.sonicSound.Stop();
					}
				}
				else
				{
					flag = true;
				}
			}
			else if (command.Arguments.Count == 0 || (command.Arguments.Count == 1 && command.Arguments[0].ToLower() == "all"))
			{
				if (base.IsActivated)
				{
					CancelAbility();
				}
				else
				{
					if (drone.isMovingForwardBack && !drone.IsBraking)
					{
						drone.StopPriorNavigation();
					}
					if (!ActivateAbility())
					{
						break;
					}
					if (GlobalSettings.cameraMode == CameraMode.Drone)
					{
						drone.sonicSound.Play();
						drone.sonicSound.volume = GameAudio.RemoteVolume * 1f;
					}
					IsCharging = false;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				SendConsoleResponseMessage("Invalid arguments.  Usage: sonic [on, off]", ConsoleMessageType.Info);
			}
			break;
		}
		}
	}

	public override void CancelAbility()
	{
		base.CancelAbility();
		drone.sonicSound.Stop();
	}

	public void UpdateCameraView()
	{
		if (base.IsActivated)
		{
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				drone.sonicSound.Play();
				drone.sonicSound.volume = GameAudio.RemoteVolume * 1f;
			}
			else
			{
				drone.sonicSound.Stop();
			}
		}
	}
}
