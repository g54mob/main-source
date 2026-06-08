using System;
using System.Collections.Generic;
using UnityEngine;

public class StealthUpgrade : BaseDroneUpgrade, IPoweredObject, IUpdateCameraView
{
	private const string COMMAND_VALUE = "stealth";

	private static List<CommandDefinition> commandList;

	private bool delayRechargeState;

	private bool firedLowState;

	private float rechargeDelayTimer;

	private float rechargeRate;

	private bool hasTestedUseStealthProperty;

	private float guiCurrentPower;

	private string _guiString = string.Empty;

	public override string CommandValue
	{
		get
		{
			return "stealth";
		}
	}

	public bool HasRechargeMod
	{
		get
		{
			return (AppliedModifications & ModificationStorageIdEnum.StealthRecharge) != 0;
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
			return true;
		}
	}

	public bool ShowPercentage
	{
		get
		{
			return true;
		}
	}

	public string guiStatus
	{
		get
		{
			if (guiCurrentPower != CurrentPower)
			{
				_guiString = " (" + Math.Round(CurrentPower, 0) + "%) ";
				guiCurrentPower = CurrentPower;
			}
			return _guiString;
		}
	}

	public StealthUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
		CurrentPower = TotalPower;
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
		if (!IsCharging && !delayRechargeState)
		{
			if (base.IsActivated)
			{
				float num = ((!HasRechargeMod) ? 2.4f : 6.5f);
				CurrentPower -= num * Time.deltaTime;
				if (CurrentPower <= 0f)
				{
					CancelAbility();
					delayRechargeState = true;
					rechargeDelayTimer = 0f;
					rechargeRate = ((!HasRechargeMod) ? 3f : 10f);
				}
				else if (CurrentPower < 25f && !firedLowState)
				{
					OnDroneUpgradeEvent(DroneUpgradeEventType.ActiveUpgradeLow);
					firedLowState = true;
				}
				if (SchematicViewCanvas.Instance != null)
				{
					SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
				}
				if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
				{
					DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
				}
			}
			else if (CurrentPower < TotalPower)
			{
				delayRechargeState = true;
				rechargeDelayTimer = 0f;
				rechargeRate = ((!HasRechargeMod) ? 3f : 10f);
			}
		}
		else if (CurrentPower < TotalPower)
		{
			if (rechargeDelayTimer < 2f)
			{
				rechargeDelayTimer += Time.deltaTime;
				return;
			}
			IsCharging = true;
			delayRechargeState = false;
			CurrentPower += rechargeRate * Time.deltaTime;
			if (CurrentPower > TotalPower)
			{
				CurrentPower = TotalPower;
			}
			if (SchematicViewCanvas.Instance != null)
			{
				SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
			}
			if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
			{
				DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
			}
		}
		else
		{
			IsCharging = false;
		}
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("StealthUpgrade"));
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
		case "stealth":
			if (command.Arguments.Count == 0 || (command.Arguments.Count == 1 && command.Arguments[0].ToLower() == "all"))
			{
				if (!delayRechargeState)
				{
					if (base.IsActivated)
					{
						CancelAbility();
						SendConsoleResponseMessage("Stealth field deactivated", ConsoleMessageType.UpgradeStateChange);
					}
					else
					{
						if (!ActivateAbility())
						{
							break;
						}
						drone.stealthSound.Play();
						drone.stealthSound.volume = GameAudio.RemoteVolume * 1f;
						IsCharging = false;
						SendConsoleResponseMessage("Stealth field activated", ConsoleMessageType.Info);
					}
				}
				else
				{
					SendConsoleResponseMessage("Stealth field is temporarily offline - cannot be activated", ConsoleMessageType.Warning);
				}
				command.Handled = true;
				if (!hasTestedUseStealthProperty)
				{
					if (!GlobalSettings.StealthUsedOnce)
					{
						GlobalSettings.StealthUsedOnce = true;
					}
					hasTestedUseStealthProperty = true;
				}
			}
			else
			{
				SendConsoleResponseMessage("Invalid argument(s) provided to 'stealth'.  Ex: stealth 1", ConsoleMessageType.Warning);
				command.Handled = true;
			}
			break;
		}
	}

	public override bool ActivateAbility()
	{
		firedLowState = false;
		return base.ActivateAbility();
	}

	public override void CancelAbility()
	{
		base.CancelAbility();
		drone.stealthSound.Stop();
		delayRechargeState = false;
		firedLowState = false;
	}

	public void UpdateCameraView()
	{
		if (base.IsActivated)
		{
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				drone.stealthSound.Play();
				drone.stealthSound.volume = GameAudio.RemoteVolume * 1f;
			}
			else
			{
				drone.stealthSound.Stop();
			}
		}
	}
}
