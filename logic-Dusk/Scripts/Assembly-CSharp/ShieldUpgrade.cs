using System;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpgrade : BaseDroneUpgrade, IDamagableObject, IHasHitpoints, IOverrideHitpoints, IUpdateCameraView
{
	private const string COMMAND_VALUE = "shield";

	private const float STANDARD_MAX_HITPOINTS = 500f;

	private const float RECHARGABLE_MAX_HITPOINTS = 100f;

	private static List<CommandDefinition> commandList;

	private float rechargeDelayTimer;

	private bool firstRecharge;

	private bool firstDamage;

	private ColorBlinkManager blinkManager = new ColorBlinkManager();

	private ColorBlinkManager flashManager = new ColorBlinkManager();

	private float guiCurrentHitpoints;

	private string _guiString = string.Empty;

	public override string CommandValue
	{
		get
		{
			return "shield";
		}
	}

	public bool HasRechargeMod
	{
		get
		{
			return (AppliedModifications & ModificationStorageIdEnum.ShieldRecharge) != 0;
		}
	}

	public bool HasRadiationMod
	{
		get
		{
			return (AppliedModifications & ModificationStorageIdEnum.ShieldRadiation) != 0;
		}
	}

	public override string ModIndicator
	{
		get
		{
			return ModificationsHelper.GetShieldUpgradeIndicators(AppliedModifications);
		}
	}

	public float TotalHitpoints
	{
		get
		{
			if (HasRechargeMod)
			{
				return 100f;
			}
			return 500f;
		}
	}

	public float CurrentHitPoints { get; private set; }

	public bool IsDead { get; private set; }

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

	public ShieldUpgrade(DroneUpgradeDefinition definition)
		: base(definition)
	{
		CurrentHitPoints = TotalHitpoints;
	}

	public void TakeDamage(float damage, DamageType type, ICombatTarget attacker)
	{
		if (!firstDamage || !blinkManager.IsActive)
		{
			firstDamage = true;
			blinkManager.Start(Color.white, Color.red, 0.1f, 2);
		}
		CurrentHitPoints -= damage;
		rechargeDelayTimer = 0f;
		firstRecharge = false;
		if (CurrentHitPoints <= 0f && !IsDead)
		{
			CurrentHitPoints = 0f;
			IsDead = true;
			GameplayManager.ShowConsoleMessage("Shield on Drone " + drone.DroneNumber + " depleted", ConsoleMessageType.Error);
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

	public void OverrideCurrentHitpoints(float hitpoints)
	{
		if (hitpoints <= TotalHitpoints)
		{
			CurrentHitPoints = hitpoints;
		}
		else
		{
			CurrentHitPoints = TotalHitpoints;
		}
	}

	public void OverrideTotalHitpoints(float hitpoints)
	{
	}

	public void OverrideIsDead(bool isDead)
	{
		IsDead = isDead;
	}

	protected override bool OnFixed()
	{
		return true;
	}

	protected override void OnBroken()
	{
		CurrentHitPoints = 0f;
	}

	protected override void OnUpdate()
	{
		if (CurrentHitPoints < TotalHitpoints && drone != null && !drone.IsHidden)
		{
			if (drone.IsDead)
			{
				CurrentHitPoints = 0f;
				IsDead = true;
				Break();
				return;
			}
			if (HasRechargeMod)
			{
				if (rechargeDelayTimer < 1f)
				{
					rechargeDelayTimer += Time.deltaTime;
				}
				else if (BrokenState != BrokenStateEnum.Broken)
				{
					firstDamage = false;
					if (!firstRecharge || !blinkManager.IsActive)
					{
						firstRecharge = true;
						if (base.IsActivated)
						{
							blinkManager.Start(Color.white, Color.green, 0.2f, 2);
						}
					}
					CurrentHitPoints += 10f * Time.deltaTime;
					if (IsDead)
					{
						IsDead = false;
					}
					if (CurrentHitPoints > TotalHitpoints)
					{
						CurrentHitPoints = TotalHitpoints;
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
			}
			if (blinkManager.IsActive)
			{
				drone.ShieldUIObject.GetComponent<Renderer>().material.color = blinkManager.Update(Time.deltaTime);
			}
		}
		else if (drone != null && drone.IsHidden)
		{
			if (blinkManager.IsActive)
			{
				blinkManager.Stop();
			}
		}
		else if (firstDamage || firstRecharge)
		{
			firstDamage = false;
			firstRecharge = false;
			UpdateCameraView();
		}
		if ((CurrentHitPoints >= TotalHitpoints || !blinkManager.IsActive) && flashManager.IsActive)
		{
			drone.ShieldUIObject.GetComponent<Renderer>().material.color = flashManager.Update(Time.deltaTime);
		}
	}

	public override List<CommandDefinition> QueryAvailableCommands()
	{
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(CommandHelper.GetCommands("ShieldUpgrade"));
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
		case "shield":
			if (command.Arguments.Count != 0 && (command.Arguments.Count != 1 || !(command.Arguments[0].ToLower() == "all")))
			{
				break;
			}
			if (base.IsActivated)
			{
				CancelAbility();
				SendConsoleResponseMessage("Shield deactivated", ConsoleMessageType.Info);
			}
			else
			{
				if (!ActivateAbility())
				{
					break;
				}
				SendConsoleResponseMessage("Shield activated", ConsoleMessageType.Info);
			}
			command.Handled = true;
			break;
		case "breakshield":
			TakeDamage(TotalHitpoints, DamageType.Physical, null);
			command.Handled = true;
			break;
		}
	}

	public override bool ActivateAbility()
	{
		if (!base.ActivateAbility())
		{
			return false;
		}
		UpdateCameraView();
		if (SchematicViewCanvas.Instance != null)
		{
			SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
		}
		if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
		{
			DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			drone.shieldSound.Play();
			drone.shieldSound.volume = GameAudio.RemoteVolume * 1f;
		}
		Color color = drone.ShieldUIObject.GetComponent<Renderer>().sharedMaterial.color;
		color.a *= 0.5f;
		flashManager.Start(drone.ShieldUIObject.GetComponent<Renderer>().sharedMaterial.color, color, 1f, true);
		return true;
	}

	public override void CancelAbility()
	{
		base.CancelAbility();
		UpdateCameraView();
		if (blinkManager.IsActive)
		{
			blinkManager.Stop();
		}
		if (SchematicViewCanvas.Instance != null)
		{
			SchematicViewCanvas.Instance.RefreshDrone(drone.DroneNumber);
		}
		if (DroneManager.Instance.currentDronePanel != null && DroneManager.Instance.CurrentDrone == drone)
		{
			DroneManager.Instance.currentDronePanel.UpgradesChanged = true;
		}
		drone.shieldSound.Stop();
		flashManager.Stop();
	}

	public override void PowerUp()
	{
		base.PowerUp();
		drone.ShieldUIObject.GetComponent<Renderer>().enabled = true;
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

	public override void PowerDown()
	{
		base.PowerDown();
		if (drone.GetUpgradeInstanceCount(DroneUpgradeType.Shield) <= 1)
		{
			drone.ShieldUIObject.GetComponent<Renderer>().enabled = false;
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

	public void UpdateCameraView()
	{
		if (!(drone != null))
		{
			return;
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (BrokenState != BrokenStateEnum.Broken)
			{
				if (base.IsActivated)
				{
					drone.ShieldUIObject.GetComponent<Renderer>().sharedMaterial = drone.DroneViewShieldOnMtl;
					Color color = drone.ShieldUIObject.GetComponent<Renderer>().material.color;
					if (GameSaveFile.Get("Q_STATIC_HONLY", true))
					{
						color.a = 0.78039217f;
					}
					else
					{
						color.a = 0.58431375f;
					}
					drone.ShieldUIObject.GetComponent<Renderer>().sharedMaterial.color = color;
				}
				else
				{
					drone.ShieldUIObject.GetComponent<Renderer>().sharedMaterial = drone.DroneViewShieldOffMtl;
					Color color2 = drone.ShieldUIObject.GetComponent<Renderer>().material.color;
					if (GameSaveFile.Get("Q_STATIC_HONLY", true))
					{
						color2.a = 8f / 15f;
					}
					else
					{
						color2.a = 0.3372549f;
					}
					drone.ShieldUIObject.GetComponent<Renderer>().sharedMaterial.color = color2;
				}
			}
			else
			{
				drone.ShieldUIObject.GetComponent<Renderer>().sharedMaterial = drone.DroneViewShieldBrokenMtl;
				Color color3 = drone.ShieldUIObject.GetComponent<Renderer>().material.color;
				if (GameSaveFile.Get("Q_STATIC_HONLY", true))
				{
					color3.a = 83f / 85f;
				}
				else
				{
					color3.a = 0.78039217f;
				}
				drone.ShieldUIObject.GetComponent<Renderer>().sharedMaterial.color = color3;
			}
		}
		else if (BrokenState != BrokenStateEnum.Broken)
		{
			if (base.IsActivated)
			{
				drone.ShieldUIObject.GetComponent<Renderer>().sharedMaterial = drone.SchematicViewShieldOnMtl;
			}
			else
			{
				drone.ShieldUIObject.GetComponent<Renderer>().sharedMaterial = drone.SchematicViewShieldOffMtl;
			}
		}
		else
		{
			drone.ShieldUIObject.GetComponent<Renderer>().sharedMaterial = drone.SchematicViewShieldBrokenMtl;
		}
		if (base.IsActivated)
		{
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				drone.shieldSound.Play();
				drone.shieldSound.volume = GameAudio.RemoteVolume * 1f;
			}
			else
			{
				drone.shieldSound.Stop();
			}
		}
	}
}
