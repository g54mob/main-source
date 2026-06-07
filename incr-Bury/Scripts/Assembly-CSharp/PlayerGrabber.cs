using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Settings;

public class PlayerGrabber : MonoBehaviour
{
	[Header("Pick Up Raycast")]
	[SerializeField]
	private GameObject playerCam;

	[SerializeField]
	private float rayCastLength_PickUp;

	[SerializeField]
	private float rayCastLength_BuildingPlacement;

	private float raycastLength_CurrState;

	[SerializeField]
	private LayerMask pickUpMask;

	[SerializeField]
	private GameObject currentLookingAtPickup;

	[SerializeField]
	private Vector3 currentGroundLookSpot;

	private GameObject lastFrame_LookingAtPickUp;

	[SerializeField]
	private GameObject currentLookingAtWorldUsable;

	private GameObject lastFrame_LookingAtWorldUsable;

	[SerializeField]
	private GameObject currentLookingAtSuckUppable;

	private GameObject lastFrame_LookingAtSuckUppable;

	[Header("Buildables")]
	[SerializeField]
	private float rayCastLength_UpgradeInteraction;

	[SerializeField]
	private LayerMask upgradeInteractionMask;

	[SerializeField]
	private PlantBed currentLookingAtPlantBed;

	[SerializeField]
	private Buildable currentLookingAtBuildable;

	private PlantBed lastFrame_LookingAtPlantBed;

	private Buildable lastFrame_LookingAtBuildable;

	[Header("Destroying Buildables")]
	[SerializeField]
	private float holdToDestroy_Time;

	private float holdToDestroy_Time_Curr;

	[Header("Hold Locations")]
	[SerializeField]
	private HoldSpotHelper itemHoldSpot;

	[Header("Holding Physics")]
	[SerializeField]
	private float holdForcePower;

	[SerializeField]
	private Rigidbody heldRigidBody;

	[SerializeField]
	private PickUppable heldPickUppable;

	[SerializeField]
	private float heldObjectTorqueFacingPower;

	[SerializeField]
	private float torqueThreshold = 0.99f;

	[Header("Dropping JUICE")]
	[SerializeField]
	private float dropItem_CuteUpwardBoop;

	[SerializeField]
	private float dropItem_CuteTorque;

	[Header("Throwing")]
	[SerializeField]
	private float throwPower_Forward;

	[SerializeField]
	private float throwPower_UpwardBoop;

	[SerializeField]
	private Rigidbody playerRigidBody;

	[SerializeField]
	private Collider playerCollider;

	[Header("Building Mode")]
	[SerializeField]
	private GameObject buildingObjectPreview;

	[SerializeField]
	private Vector3 buildObjectPosition_Snapped;

	private bool hasValidBuilderPlacement;

	[Header("Kicking")]
	[SerializeField]
	private LayerMask kickRayMask;

	[SerializeField]
	private float kickRay_Length;

	[SerializeField]
	private float kickRadius;

	[SerializeField]
	private float kickForce;

	[SerializeField]
	private float kick_upwardForce;

	[SerializeField]
	private float kick_OutwardAffected;

	[SerializeField]
	private float kickDistanceToUnearthDiggables;

	[Header("Charge Up Kick")]
	[SerializeField]
	private float kickChargeUp_ChargePerSec;

	private float kickChargeUp_Max = 1f;

	private float kickChargeUp_Curr;

	private bool canPlayKickChargeAudio = true;

	[Header("Vacuum")]
	[SerializeField]
	private VacuumSuckTrigger vacuumSuckVolume;

	[SerializeField]
	private List<Rigidbody> rbsInVacuum;

	public bool vacuumisOn;

	[SerializeField]
	private float vacuumSuckForce;

	[SerializeField]
	private float suckUpDistThreshold;

	private Vector3 hiddenVacHolderSpot = new Vector3(0f, 0f, 500f);

	[SerializeField]
	private float vacShootPower;

	[SerializeField]
	private float vacShootUpwardPower;

	private float vacShootDowntime_Curr;

	[SerializeField]
	private float vacShootDowntime_Min;

	[SerializeField]
	private float vacShootDowntime_RampUpPerSec;

	private float vacShootDowntime_RampUpCurr;

	[SerializeField]
	private AudioSource vacuumSuck_Audio_Source;

	private float vacuumSuck_Audio_Pitch_Curr;

	[SerializeField]
	private float vacuumSuck_Audio_Pitch_Max;

	private float vacuumSuck_Audio_Pitch_Min = 0.5f;

	[SerializeField]
	private float vacuumSuck_Audio_Pitch_ChangeRate;

	private float vacuumSuck_Audio_Volume;

	[SerializeField]
	private float vacuumSuck_Audio_Volume_ChangeRate;

	private bool hasDingedCauseFull;

	[SerializeField]
	private AudioSource vacuumShooter_Audio_Source;

	[SerializeField]
	private AudioClip vacuumShooter_Audio_ShootSFX;

	[SerializeField]
	private AudioSource vacuumAirBlast_ChargeUp_AudioSource;

	private float vacuumShooter_Audio_Pitch_Min = 0.4f;

	private float vacuumShooter_Audio_Pitch_Max = 1.2f;

	private float vacuumShooter_Audio_Pitch_Curr;

	private float vacuumShooter_Audio_Pitch_Increase = 0.025f;

	private float vacuumShooter_Audio_Pitch_Timer_Curr;

	private float vacuumShooter_Audio_Pitch_Timer_Max = 1f;

	private bool beyondVacuumBuffer;

	private float vacuumBuffer_Curr;

	[SerializeField]
	private float vacuumBuffer;

	private bool canShootFromVac = true;

	[SerializeField]
	private GameObject vacuumArt;

	[SerializeField]
	private ParticleSystem vacuum_SuckParticles;

	private ParticleSystem.EmissionModule vacuum_SuckParticles_Emission;

	[SerializeField]
	private GameObject vacuum_AirBlastCharge_Particles;

	[SerializeField]
	private MMF_Player feedback_VacuumSpring;

	private float vacArtShowTime_Curr;

	private float vacArtShowTime = 1f;

	[SerializeField]
	private TMP_Text vac_DisplayCountText;

	[SerializeField]
	private Gradient vac_DisplayText_Gradient;

	[SerializeField]
	private GameObject[] vac_Lights_Off;

	[SerializeField]
	private GameObject[] vac_Lights_On;

	private int environmentMask;

	private float holeMove_LastTimePressed;

	private const float DOUBLETAP_THRESHOLD = 0.3f;

	[Header("Pop Gun")]
	[SerializeField]
	private GameObject popgun_BulletPrefab;

	[SerializeField]
	private Transform popgun_BulletSpawnPoint;

	[SerializeField]
	private float popgun_BulletForce;

	[SerializeField]
	private float popgun_FireRate;

	private float popgun_FireCooldown_Curr;

	[SerializeField]
	private GameObject popgun_Art_Gun;

	[SerializeField]
	private GameObject popgun_Art_Dart;

	[SerializeField]
	private float popgun_Art_TimeBeforeAutoHiding;

	private float popgun_Art_TimeBeforeAutoHiding_Curr;

	[SerializeField]
	private MMF_Player feedback_PopGun_Shoot;

	[SerializeField]
	private MMF_Player feedback_PopGun_Reload;

	[SerializeField]
	private LayerMask pcLookAtMask;

	private void Awake()
	{
		vacuum_SuckParticles_Emission = vacuum_SuckParticles.emission;
	}

	private void Start()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnBuildModeEntered_Action = (Action)Delegate.Combine(singleton.OnBuildModeEntered_Action, new Action(OnEnteredBuildMode));
		GameManager singleton2 = GameManager.Singleton;
		singleton2.OnBuildablePlaced_Action = (Action)Delegate.Combine(singleton2.OnBuildablePlaced_Action, new Action(OnBuildablePlaced));
		GameManager singleton3 = GameManager.Singleton;
		singleton3.OnNightTime_Action = (Action)Delegate.Combine(singleton3.OnNightTime_Action, new Action(OnNightTime));
		environmentMask = 1 << LayerMask.NameToLayer("Environment");
		HudManager.Singleton.UpdateKickChargeUI(0f);
		vacuumShooter_Audio_Pitch_Curr = vacuumShooter_Audio_Pitch_Min;
		HidePopGunArt();
	}

	private void OnDestroy()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnBuildModeEntered_Action = (Action)Delegate.Remove(singleton.OnBuildModeEntered_Action, new Action(OnEnteredBuildMode));
		GameManager singleton2 = GameManager.Singleton;
		singleton2.OnBuildablePlaced_Action = (Action)Delegate.Remove(singleton2.OnBuildablePlaced_Action, new Action(OnBuildablePlaced));
		GameManager singleton3 = GameManager.Singleton;
		singleton3.OnNightTime_Action = (Action)Delegate.Remove(singleton3.OnNightTime_Action, new Action(OnNightTime));
	}

	private void Update()
	{
		PlayerCamNullCheck();
		RaycastFromCamera_ForPickUpsAndBuilding();
		RaycastFromCamera_ForBuildables();
		RaycastForLookingAtPC();
		UpdateCrossHair();
		HandleBuildMode_PlacementGhost();
		HandlePlayerInputs();
		HandleIsHoldingStates();
		HandleVacShootDowntimeTimer();
		HandleShootingPitchShiftSFX_Timer();
		UpdateNextFrameComparisonVariables();
		HandlePopGunTimers();
		HandleHoldingACassetteTape();
	}

	private void FixedUpdate()
	{
		HandleHeldObjectPlacement();
		HandleVacuum();
		HandleVacuumArtVisability();
		HandleVacuumCountDisplay();
	}

	private void PlayerCamNullCheck()
	{
		if (playerCam == null)
		{
			playerCam = GameObject.FindGameObjectWithTag("MainCamera");
		}
	}

	private void HandleVacShootDowntimeTimer()
	{
		if (vacShootDowntime_Curr > 0f)
		{
			vacShootDowntime_Curr -= Time.deltaTime;
		}
		else
		{
			vacShootDowntime_Curr = 0f;
		}
	}

	private void RaycastFromCamera_ForPickUpsAndBuilding()
	{
		currentLookingAtPickup = null;
		currentLookingAtWorldUsable = null;
		currentLookingAtSuckUppable = null;
		currentGroundLookSpot = Vector3.zero;
		DecideRayCastLength();
		if (Physics.Raycast(new Ray(playerCam.transform.position, playerCam.transform.forward), out var hitInfo, raycastLength_CurrState, pickUpMask, QueryTriggerInteraction.Ignore))
		{
			if (hitInfo.collider.gameObject.CompareTag("PickUp"))
			{
				currentLookingAtPickup = hitInfo.collider.transform.root.gameObject;
			}
			else if (hitInfo.collider.gameObject.CompareTag("WorldUsable"))
			{
				currentLookingAtWorldUsable = hitInfo.collider.gameObject;
			}
			else if (hitInfo.collider.gameObject.CompareTag("SuckUppable"))
			{
				currentLookingAtSuckUppable = hitInfo.collider.transform.root.gameObject;
			}
			else if (hitInfo.collider.gameObject.CompareTag("Deck"))
			{
				currentGroundLookSpot = hitInfo.point;
			}
		}
		if (!currentLookingAtPickup)
		{
			HudManager.Singleton.HideCultistInfo();
		}
		if (!currentLookingAtWorldUsable)
		{
			HudManager.Singleton.HideHintText();
		}
		if (currentLookingAtPickup != lastFrame_LookingAtPickUp && (bool)currentLookingAtPickup)
		{
			try
			{
				BerryCultist_AI component = currentLookingAtPickup.GetComponent<BerryCultist_AI>();
				int upgradeCost = ((component.GetBerryTier() + 1 < UpgradeTreeManager.Singleton.cultists_UpgradePrices.Count) ? UpgradeTreeManager.Singleton.cultists_UpgradePrices[component.GetBerryTier() + 1] : (-1));
				HudManager.Singleton.DisplayNewCultistInfo(component.cultistsName, upgradeCost);
			}
			catch
			{
			}
		}
		if (!(currentLookingAtWorldUsable != lastFrame_LookingAtWorldUsable) || !currentLookingAtWorldUsable)
		{
			return;
		}
		try
		{
			MiscObjectIdentifier component2 = currentLookingAtWorldUsable.GetComponent<MiscObjectIdentifier>();
			if (component2.identity == MiscObjectIdentifier.MiscObjectIdentity.Bed)
			{
				string hintTextString_Bed = GetHintTextString_Bed();
				HudManager.Singleton.DisplayNewHintText(hintTextString_Bed);
			}
			else if (component2.identity == MiscObjectIdentifier.MiscObjectIdentity.RadioButton_Power)
			{
				string hintTextString_RadioButton_Power = GetHintTextString_RadioButton_Power();
				HudManager.Singleton.DisplayNewHintText(hintTextString_RadioButton_Power);
			}
			else if (component2.identity == MiscObjectIdentifier.MiscObjectIdentity.RadioButton_Station)
			{
				string hintTextString_RadioButton_Station = GetHintTextString_RadioButton_Station();
				HudManager.Singleton.DisplayNewHintText(hintTextString_RadioButton_Station);
			}
		}
		catch
		{
		}
	}

	private string GetHintTextString_Bed()
	{
		string text = ((InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse.GetBindingDisplayString(0) : InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse.GetBindingDisplayString(1));
		string[] arguments = new string[1] { text };
		return LocalizationSettings.StringDatabase.GetLocalizedStringAsync("HintText_UseBed", arguments).Result;
	}

	private string GetHintTextString_RadioButton_Power()
	{
		string text = ((InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse.GetBindingDisplayString(0) : InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse.GetBindingDisplayString(1));
		string[] arguments = new string[1] { text };
		return LocalizationSettings.StringDatabase.GetLocalizedStringAsync("HintText_UseRadio_Power", arguments).Result;
	}

	private string GetHintTextString_RadioButton_Station()
	{
		string text = ((InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse.GetBindingDisplayString(0) : InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse.GetBindingDisplayString(1));
		string[] arguments = new string[1] { text };
		return LocalizationSettings.StringDatabase.GetLocalizedStringAsync("HintText_UseRadio_Channel", arguments).Result;
	}

	private void RaycastFromCamera_ForBuildables()
	{
		currentLookingAtPlantBed = null;
		currentLookingAtBuildable = null;
		if (Physics.Raycast(new Ray(playerCam.transform.position, playerCam.transform.forward), out var hitInfo, rayCastLength_UpgradeInteraction, upgradeInteractionMask, QueryTriggerInteraction.Collide) && hitInfo.collider.gameObject.CompareTag("Buildable"))
		{
			hitInfo.collider.transform.root.gameObject.CompareTag("PlantBed");
		}
		_ = currentLookingAtPlantBed != lastFrame_LookingAtPlantBed;
		if (currentLookingAtBuildable != lastFrame_LookingAtBuildable)
		{
			if ((bool)lastFrame_LookingAtBuildable)
			{
				RemoveSelectedOutlineMaterialToBuildable(lastFrame_LookingAtBuildable);
			}
			if ((bool)currentLookingAtBuildable)
			{
				AddSelectedOutlineMaterialToBuildable(currentLookingAtBuildable);
			}
		}
		if (!currentLookingAtPlantBed && HudManager.Singleton.activeUiGroup == HudManager.ActiveUiGroup.PlantBedUpgrade)
		{
			HudManager.Singleton.HideUIGroup_SubGroup_PlantBedInfo();
		}
	}

	private void AddSelectedOutlineMaterialToBuildable(Buildable _buildable)
	{
		Renderer[] componentsInChildren = _buildable.gameObject.transform.root.GetComponentsInChildren<Renderer>();
		foreach (Renderer obj in componentsInChildren)
		{
			Material[] materials = obj.materials;
			obj.materials = new Material[2]
			{
				materials[0],
				GameManager.Singleton.prefabBank.selectionOutline_Mat
			};
		}
	}

	private void RemoveSelectedOutlineMaterialToBuildable(Buildable _buildable)
	{
		Renderer[] componentsInChildren = _buildable.gameObject.transform.root.GetComponentsInChildren<Renderer>();
		foreach (Renderer obj in componentsInChildren)
		{
			Material[] materials = obj.materials;
			obj.materials = new Material[1] { materials[0] };
		}
	}

	private void DecideRayCastLength()
	{
		if (GameManager.Singleton.buildModeState == PlayerBuildModeState.BuildMode)
		{
			raycastLength_CurrState = rayCastLength_BuildingPlacement;
		}
		else
		{
			raycastLength_CurrState = rayCastLength_PickUp;
		}
	}

	private void UpdateNextFrameComparisonVariables()
	{
		lastFrame_LookingAtPickUp = currentLookingAtPickup;
		lastFrame_LookingAtPlantBed = currentLookingAtPlantBed;
		lastFrame_LookingAtWorldUsable = currentLookingAtWorldUsable;
		lastFrame_LookingAtSuckUppable = currentLookingAtSuckUppable;
		lastFrame_LookingAtBuildable = currentLookingAtBuildable;
	}

	private void UpdateCrossHair()
	{
		if (GameManager.Singleton.isLookingAtPC)
		{
			HudManager.Singleton.SetCrossHair(HudManager.CrossHairType.MouseCursor);
		}
		else if ((bool)currentLookingAtPickup || (bool)currentLookingAtWorldUsable || (bool)currentLookingAtSuckUppable)
		{
			HudManager.Singleton.SetCrossHair(HudManager.CrossHairType.Useable);
		}
		else
		{
			HudManager.Singleton.SetCrossHair(HudManager.CrossHairType.Basic);
		}
	}

	private void HandlePlayerInputs()
	{
		_ = GameManager.Singleton.buildModeState;
		if (GenericMenuManager.Singleton.menuState != GenericMenuManager.MenuState.idle)
		{
			vacuumisOn = false;
			return;
		}
		if (GameManager.Singleton.buildModeState == PlayerBuildModeState.Default)
		{
			if (InputManager.Singleton.inputActions.PlayerActionMap.Drop.WasPressedThisFrame() && GetIsHoldingItem())
			{
				DropHeldItem(_Throw: false, heldPickUppable);
			}
			InputManager.Singleton.inputActions.PlayerActionMap.Drop.IsPressed();
			if (InputManager.Singleton.inputActions.PlayerActionMap.Throw.WasPressedThisFrame())
			{
				if (GetIsHoldingItem())
				{
					canShootFromVac = false;
					DropHeldItem(_Throw: true, heldPickUppable);
				}
				else if (OptionsManager.Singleton.toggle_PopGun_Setting == 0 && rbsInVacuum.Count == 0 && PlayerStats.Singleton.popgun_Unlocked)
				{
					FirePopGun();
				}
			}
			if (InputManager.Singleton.inputActions.PlayerActionMap.Throw.IsPressed() && OptionsManager.Singleton.toggle_PopGun_Setting == 1 && !GetIsHoldingItem() && rbsInVacuum.Count == 0 && PlayerStats.Singleton.popgun_Unlocked)
			{
				FirePopGun();
			}
			if (InputManager.Singleton.inputActions.PlayerActionMap.Throw.WasReleasedThisFrame())
			{
				canShootFromVac = true;
			}
			if (InputManager.Singleton.inputActions.PlayerActionMap.Throw.IsPressed())
			{
				if (!GetIsHoldingItem() && canShootFromVac && rbsInVacuum.Count > 0 && vacShootDowntime_Curr == 0f)
				{
					try
					{
						ShootBerryFromVacuum(rbsInVacuum[rbsInVacuum.Count - 1]);
						vacShootDowntime_RampUpCurr = Mathf.Clamp(vacShootDowntime_RampUpCurr - vacShootDowntime_RampUpPerSec, vacShootDowntime_Min, PlayerStats.Singleton.vacShootDowntime_Max);
						vacShootDowntime_Curr = vacShootDowntime_RampUpCurr;
					}
					catch
					{
						Debug.Log("Attempted to shoot a berry that didn't exist? Removing any nulls from list.");
						RemoveAnyNullsFromRbsInVacuumList();
					}
				}
			}
			else
			{
				vacShootDowntime_RampUpCurr = PlayerStats.Singleton.vacShootDowntime_Max;
			}
			if (InputManager.Singleton.inputActions.PlayerActionMap.BerryBlitz.WasPressedThisFrame())
			{
				if (GameManager.Singleton.gameState != GameManager.GameState.Playing || GameManager.Singleton.hasTimerElapsed_IsNighttime || GameManager.Singleton.goldRushIsActive)
				{
					return;
				}
				if (GameManager.Singleton.canUseGoldRush && PlayerStats.Singleton.goldRush_Unlocked && !PlayerStats.Singleton.hasUsedThisRound_GoldRush)
				{
					GameManager.Singleton.ActivateBerryBlitz();
				}
			}
			if (InputManager.Singleton.inputActions.PlayerActionMap.GapingMaw.WasPressedThisFrame())
			{
				if (GameManager.Singleton.gameState != GameManager.GameState.Playing || GameManager.Singleton.hasTimerElapsed_IsNighttime || GameManager.Singleton.bigHoleIsActive)
				{
					return;
				}
				if (GameManager.Singleton.canUseBigHole && PlayerStats.Singleton.bigHole_Unlocked && !PlayerStats.Singleton.hasUsedThisRound_BigHole)
				{
					GameManager.Singleton.ActivateBigHolePowerup();
				}
			}
			if (InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse.WasPressedThisFrame() && !GetIsHoldingItem())
			{
				if ((bool)currentLookingAtPickup)
				{
					AttemptPickup(currentLookingAtPickup);
				}
				else if ((bool)currentLookingAtWorldUsable)
				{
					currentLookingAtWorldUsable.GetComponent<WorldUsable>().Use();
				}
			}
			if (InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse.IsPressed())
			{
				if (!GetIsHoldingItem() && (bool)currentLookingAtSuckUppable)
				{
					SuckUppables component = currentLookingAtSuckUppable.GetComponent<SuckUppables>();
					component.pickedUpManually = true;
					component.OnPlayerPickedUsed();
				}
				if (GameManager.Singleton.gameState == GameManager.GameState.Playing)
				{
					if (vacuumBuffer_Curr < vacuumBuffer)
					{
						vacuumBuffer_Curr += Time.deltaTime;
						beyondVacuumBuffer = false;
					}
					else
					{
						beyondVacuumBuffer = true;
					}
				}
				else
				{
					beyondVacuumBuffer = false;
					vacuumisOn = false;
				}
			}
			else
			{
				vacuumisOn = false;
				beyondVacuumBuffer = false;
				vacuumBuffer_Curr = 0f;
			}
			if (beyondVacuumBuffer)
			{
				if (GetIsHoldingItem())
				{
					if (PlayerStats.Singleton.vacuum_Unlocked && rbsInVacuum.Count < PlayerStats.Singleton.vacuumCapacity)
					{
						ClearItemInHand();
					}
				}
				else
				{
					vacuumisOn = rbsInVacuum.Count < PlayerStats.Singleton.vacuumCapacity;
					if (rbsInVacuum.Count < PlayerStats.Singleton.vacuumCapacity)
					{
						hasDingedCauseFull = false;
					}
					else if (!hasDingedCauseFull)
					{
						AudioManager.Singleton.PlayVacuumFullDing(base.transform.position);
						hasDingedCauseFull = true;
					}
				}
			}
			if (InputManager.Singleton.inputActions.PlayerActionMap.Rotate.WasPressedThisFrame() && (bool)currentLookingAtBuildable && currentLookingAtBuildable.rotationSnap == BuildModeRotationMode.SnapRotation_90)
			{
				currentLookingAtBuildable.transform.root.gameObject.transform.Rotate(Vector3.up * 90f);
			}
			InputManager.Singleton.inputActions.PlayerActionMap.Rotate.IsPressed();
			if (InputManager.Singleton.inputActions.PlayerActionMap.AirBlast.WasReleasedThisFrame() && PlayerStats.Singleton.broom_Unlocked)
			{
				KickInFrontOfUs();
				HudManager.Singleton.UpdateKickChargeUI(0f);
			}
			if (InputManager.Singleton.inputActions.PlayerActionMap.AirBlast.IsPressed())
			{
				if (PlayerStats.Singleton.broom_Unlocked)
				{
					if (canPlayKickChargeAudio)
					{
						canPlayKickChargeAudio = false;
						if (!vacuumAirBlast_ChargeUp_AudioSource.isPlaying)
						{
							vacuumAirBlast_ChargeUp_AudioSource.volume = AudioManager.Singleton.sfxVolume;
							vacuumAirBlast_ChargeUp_AudioSource.Play();
						}
					}
					if (kickChargeUp_Curr < kickChargeUp_Max)
					{
						kickChargeUp_Curr += Time.deltaTime * kickChargeUp_ChargePerSec;
					}
					else
					{
						kickChargeUp_Curr = kickChargeUp_Max;
					}
					HudManager.Singleton.UpdateKickChargeUI(kickChargeUp_Curr);
				}
			}
			else
			{
				kickChargeUp_Curr = 0f;
				canPlayKickChargeAudio = true;
				if (vacuumAirBlast_ChargeUp_AudioSource.isPlaying)
				{
					vacuumAirBlast_ChargeUp_AudioSource.Stop();
				}
			}
			if ((bool)currentLookingAtBuildable)
			{
				if (InputManager.Singleton.inputActions.PlayerActionMap.DestroyBuildable.IsPressed() && currentLookingAtBuildable.canSell)
				{
					if (holdToDestroy_Time_Curr < holdToDestroy_Time)
					{
						holdToDestroy_Time_Curr += Time.deltaTime;
						if (!currentLookingAtBuildable.IsPlayingDeletionWiggleFeedback())
						{
							currentLookingAtBuildable.PlayDeletionWiggle_Feedback();
						}
					}
					else
					{
						GameManager.Singleton.OnBuildableDestroyed_RunAdditionalLogic(currentLookingAtBuildable);
						GameManager.Singleton.SetGridTileToAllowBuildingOn(currentLookingAtBuildable.transform.root.gameObject.transform.position);
						UnityEngine.Object.Destroy(currentLookingAtBuildable.transform.root.gameObject);
						holdToDestroy_Time_Curr = 0f;
					}
				}
				if (InputManager.Singleton.inputActions.PlayerActionMap.DestroyBuildable.WasReleasedThisFrame())
				{
					currentLookingAtBuildable.StopDeletionWiggle_Feedback();
					holdToDestroy_Time_Curr = 0f;
				}
			}
			else
			{
				holdToDestroy_Time_Curr = 0f;
			}
		}
		else if (GameManager.Singleton.buildModeState == PlayerBuildModeState.BuildMode)
		{
			if (InputManager.Singleton.inputActions.PlayerActionMap.Throw.WasPressedThisFrame())
			{
				if (!buildingObjectPreview)
				{
					return;
				}
				if (hasValidBuilderPlacement)
				{
					GameManager.Singleton.BuildCurrentBuildable(buildingObjectPreview.transform.position, buildingObjectPreview.transform.rotation, GameManager.Singleton.buildMode_SnapToGrid);
				}
			}
			if (InputManager.Singleton.inputActions.PlayerActionMap.Rotate.WasPressedThisFrame())
			{
				if (!buildingObjectPreview)
				{
					return;
				}
				if (GameManager.Singleton.buildMode_RotationMode == BuildModeRotationMode.SnapRotation_90)
				{
					buildingObjectPreview.transform.Rotate(Vector3.up * 90f);
				}
			}
			if (InputManager.Singleton.inputActions.PlayerActionMap.Rotate.IsPressed())
			{
				if (!buildingObjectPreview)
				{
					return;
				}
				_ = GameManager.Singleton.buildMode_RotationMode;
				_ = 2;
			}
		}
		if (InputManager.Singleton.inputActions.PlayerActionMap.MoveHole.IsPressed() && PlayerStats.Singleton.holeMove_IsUnlocked)
		{
			GameManager.Singleton.playerMovingHole = true;
			Vector3 raycastPositionForMovingHoleDestination = GetRaycastPositionForMovingHoleDestination();
			GameManager.Singleton.SetNewHoleDestination(raycastPositionForMovingHoleDestination);
		}
		if (InputManager.Singleton.inputActions.PlayerActionMap.MoveHole.WasReleasedThisFrame())
		{
			if (Time.time - holeMove_LastTimePressed <= 0.3f)
			{
				GameManager.Singleton.playerMovingHole = false;
			}
			holeMove_LastTimePressed = Time.time;
		}
	}

	private Vector3 GetRaycastPositionForMovingHoleDestination()
	{
		if (Physics.Raycast(new Ray(playerCam.transform.position, playerCam.transform.forward), out var hitInfo, 500f, environmentMask, QueryTriggerInteraction.Ignore))
		{
			return new Vector3(hitInfo.point.x, GameManager.Singleton.GetStartingHolePosition().y, hitInfo.point.z);
		}
		Vector3 result = base.transform.position + base.transform.forward * 500f;
		result.y = GameManager.Singleton.GetStartingHolePosition().y;
		return result;
	}

	private void DropHeldItem(bool _Throw, PickUppable _droppedPickUp)
	{
		Rigidbody rigidbody = heldRigidBody;
		ClearItemInHand();
		if (_Throw)
		{
			if (rigidbody.useGravity)
			{
				AddThrowPhysics(rigidbody, throwPower_Forward, throwPower_UpwardBoop);
			}
			else
			{
				float num = throwPower_Forward;
				try
				{
					if (rigidbody.GetComponent<PickUppable>().GetItemIdentity() == ItemIdentity.AnomalousMaterial)
					{
						num *= 3f;
					}
				}
				catch
				{
				}
				AddThrowPhysics(rigidbody, num, 0f);
			}
		}
		else
		{
			AddCuteDropPhysics(rigidbody, _droppedPickUp.dontTorqueWhenDropped);
		}
		popgun_FireCooldown_Curr = popgun_FireRate;
	}

	private void AddCuteDropPhysics(Rigidbody _droppedRB, bool _dontTorqueOnDrop)
	{
		_droppedRB.linearVelocity = Vector3.zero;
		_droppedRB.angularVelocity = Vector3.zero;
		_droppedRB.AddForce(Vector3.up * dropItem_CuteUpwardBoop + playerRigidBody.linearVelocity, ForceMode.VelocityChange);
		if (!_dontTorqueOnDrop)
		{
			Vector3 normalized = Vector3.Cross(base.transform.up, playerCam.transform.forward).normalized;
			_droppedRB.AddTorque(normalized * dropItem_CuteTorque, ForceMode.VelocityChange);
		}
	}

	private void AddThrowPhysics(Rigidbody _droppedRB, float _amount, float _upward)
	{
		Vector3 normalized = playerCam.transform.forward.normalized;
		_droppedRB.linearVelocity = Vector3.zero;
		_droppedRB.angularVelocity = Vector3.zero;
		_droppedRB.AddForce(normalized * _amount + playerRigidBody.linearVelocity + Vector3.up * _upward, ForceMode.VelocityChange);
		Vector3 normalized2 = Vector3.Cross(base.transform.up, playerCam.transform.forward).normalized;
		_droppedRB.AddTorque(normalized2 * dropItem_CuteTorque, ForceMode.VelocityChange);
	}

	private void AttemptPickup(GameObject _object)
	{
		try
		{
			PickUppable component = _object.GetComponent<PickUppable>();
			if (component.canPickUp)
			{
				heldRigidBody = _object.GetComponent<Rigidbody>();
				component.OnPickUp();
				heldPickUppable = component;
				IgnoreCollisionsBetweenUsAndObject(_object);
			}
		}
		catch
		{
			Debug.Log("Failed to pick up this object, ignoring.");
			ClearItemInHand();
		}
	}

	private void HandleHeldObjectPlacement()
	{
		if ((bool)heldRigidBody)
		{
			Vector3 vector = itemHoldSpot.transform.position - heldRigidBody.transform.position;
			heldRigidBody.AddForce(vector * holdForcePower, ForceMode.Acceleration);
			Vector3 forward = heldRigidBody.transform.forward;
			Vector3 rhs = base.transform.rotation * Quaternion.Euler(heldPickUppable.held_RotationOffset) * Vector3.forward;
			float num = Vector3.Dot(forward, rhs);
			if (num >= torqueThreshold)
			{
				heldRigidBody.angularVelocity = Vector3.zero;
				return;
			}
			Vector3 vector2 = Vector3.Cross(forward, rhs);
			heldRigidBody.AddTorque(vector2 * heldObjectTorqueFacingPower * (1f - num), ForceMode.Acceleration);
		}
	}

	private void HandleIsHoldingStates()
	{
	}

	public bool GetIsHoldingItem()
	{
		return heldRigidBody != null;
	}

	public void ClearItemInHand()
	{
		heldPickUppable = null;
		GameObject gameObject = null;
		if ((bool)heldRigidBody)
		{
			heldRigidBody.gameObject.GetComponent<PickUppable>().OnDrop();
			gameObject = heldRigidBody.gameObject;
		}
		heldRigidBody = null;
		if ((bool)gameObject)
		{
			StartCoroutine(WaitThenToggleCollisionBetweenColliderAndPlayCollider(gameObject));
		}
	}

	private void DisableAllCollidersOnObject(GameObject _go)
	{
		Collider[] componentsInChildren = _go.GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = false;
		}
	}

	private void EnableAllCollidersOnObject(GameObject _go)
	{
		Collider[] componentsInChildren = _go.GetComponentsInChildren<Collider>();
		StartCoroutine(WaitThenToggleCollisionBetweenColliderAndPlayCollider(_go));
		Collider[] array = componentsInChildren;
		foreach (Collider collider in array)
		{
			if ((bool)collider)
			{
				collider.enabled = true;
			}
		}
	}

	private void IgnoreCollisionsBetweenUsAndObject(GameObject _go)
	{
		Collider[] componentsInChildren = _go.GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Physics.IgnoreCollision(componentsInChildren[i], playerCollider, ignore: true);
		}
	}

	private IEnumerator WaitThenToggleCollisionBetweenColliderAndPlayCollider(GameObject _go)
	{
		Collider[] _allCols = _go.GetComponentsInChildren<Collider>();
		Collider[] array = _allCols;
		for (int i = 0; i < array.Length; i++)
		{
			Physics.IgnoreCollision(array[i], playerCollider, ignore: false);
		}
		yield return new WaitForSeconds(1f);
		array = _allCols;
		foreach (Collider collider in array)
		{
			if ((bool)collider)
			{
				Physics.IgnoreCollision(collider, playerCollider, ignore: false);
			}
		}
	}

	private void HandleBuildMode_PlacementGhost()
	{
		if (GameManager.Singleton.buildModeState == PlayerBuildModeState.BuildMode)
		{
			if (buildingObjectPreview == null)
			{
				buildingObjectPreview = UnityEngine.Object.Instantiate(GameManager.Singleton.buildMode_PlacementPrefab, Vector3.up * -50f, GameManager.Singleton.buildMode_PlacementPrefab.transform.rotation);
				hasValidBuilderPlacement = false;
			}
			if (!(currentGroundLookSpot != Vector3.zero))
			{
				return;
			}
			if (GameManager.Singleton.buildMode_SnapToGrid)
			{
				hasValidBuilderPlacement = false;
				Vector3 vector = new Vector3(Mathf.Round(currentGroundLookSpot.x / GameManager.Singleton.globalTileSize) * GameManager.Singleton.globalTileSize, currentGroundLookSpot.y + GameManager.Singleton.buildMode_YOffset, Mathf.Round(currentGroundLookSpot.z / GameManager.Singleton.globalTileSize) * GameManager.Singleton.globalTileSize);
				Debug.Log(vector);
				if (GameManager.Singleton.buildSpotsDict.ContainsKey(GameManager.Singleton.GetGridDictFromPos(vector)))
				{
					if (!GameManager.Singleton.buildSpotsDict[GameManager.Singleton.GetGridDictFromPos(vector)].isBuiltOn)
					{
						buildingObjectPreview.SetActive(value: true);
						buildingObjectPreview.transform.position = vector;
						hasValidBuilderPlacement = true;
					}
				}
				else
				{
					buildingObjectPreview.SetActive(value: false);
				}
			}
			else
			{
				buildingObjectPreview.transform.position = currentGroundLookSpot + Vector3.up * GameManager.Singleton.buildMode_YOffset;
				hasValidBuilderPlacement = true;
			}
		}
		else if (GameManager.Singleton.buildModeState == PlayerBuildModeState.Default && (bool)buildingObjectPreview)
		{
			UnityEngine.Object.Destroy(buildingObjectPreview);
			buildingObjectPreview = null;
		}
	}

	private void OnEnteredBuildMode()
	{
		if (GetIsHoldingItem())
		{
			DropHeldItem(_Throw: false, heldPickUppable);
		}
	}

	private void OnBuildablePlaced()
	{
		UnityEngine.Object.Destroy(buildingObjectPreview);
		buildingObjectPreview = null;
	}

	private void KickInFrontOfUs()
	{
		Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
		Vector3 zero = Vector3.zero;
		Vector3 forward = base.transform.forward;
		forward.y = 0f;
		zero = ((!Physics.Raycast(ray, out var hitInfo, kickRay_Length, kickRayMask, QueryTriggerInteraction.Ignore)) ? (playerCam.transform.position + playerCam.transform.forward * kickRay_Length) : hitInfo.point);
		if (zero != Vector3.zero)
		{
			Collider[] array = Physics.OverlapSphere(zero, kickRadius);
			Vector3 zero2 = Vector3.zero;
			List<Rigidbody> list = new List<Rigidbody>();
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				float num = kickForce * Mathf.Clamp(kickChargeUp_Curr, 0.1f, kickChargeUp_Curr);
				float num2 = kick_upwardForce + kick_upwardForce * kickChargeUp_Curr;
				if (!collider.gameObject.CompareTag("PickUp") && !collider.gameObject.CompareTag("SuckUppable"))
				{
					continue;
				}
				PickUppable component;
				try
				{
					component = collider.gameObject.transform.root.GetComponent<PickUppable>();
					if (!component.canBeKicked)
					{
						continue;
					}
				}
				catch
				{
					continue;
				}
				Rigidbody componentInChildren = collider.transform.root.GetComponentInChildren<Rigidbody>();
				if (!list.Contains(componentInChildren))
				{
					list.Add(componentInChildren);
					componentInChildren.linearVelocity = Vector3.zero;
					zero2 = (collider.transform.position - zero).normalized;
					if (component.GetItemIdentity() == ItemIdentity.AnomalousMaterial)
					{
						num *= 2f;
					}
					if (componentInChildren.useGravity)
					{
						componentInChildren.AddForce(Vector3.up * num2 + (zero2 * kick_OutwardAffected + forward) * num, ForceMode.VelocityChange);
					}
					else
					{
						componentInChildren.AddForce(playerCam.transform.forward * num, ForceMode.VelocityChange);
					}
					Vector3 normalized = Vector3.Cross(base.transform.up, zero2).normalized;
					componentInChildren.AddTorque(normalized * dropItem_CuteTorque, ForceMode.VelocityChange);
					try
					{
						component.OnKick();
					}
					catch
					{
					}
				}
			}
		}
		UnityEngine.Object.Instantiate(GameManager.Singleton.prefabBank.vacuumAirBlast_Particles_Prefab, zero, Quaternion.identity);
		AudioManager.Singleton.PlaySFX_VacuumAirBlast(zero);
	}

	private void HandleVacuum()
	{
		if (!PlayerStats.Singleton.vacuum_Unlocked || GameManager.Singleton.hasTimerElapsed_IsNighttime)
		{
			vacuumSuckVolume.gameObject.SetActive(value: false);
			if (vacuumSuck_Audio_Source.isPlaying)
			{
				vacuumSuck_Audio_Source.Stop();
			}
			return;
		}
		if (vacuumisOn)
		{
			vacuumSuckVolume.gameObject.SetActive(value: true);
			if (rbsInVacuum.Count >= PlayerStats.Singleton.vacuumCapacity)
			{
				vacuumisOn = false;
				return;
			}
			if (vacuumSuckVolume.rbsInSuckZone.Count > 0)
			{
				Vector3 zero = Vector3.zero;
				for (int num = vacuumSuckVolume.rbsInSuckZone.Count - 1; num >= 0; num--)
				{
					if (!(vacuumSuckVolume.rbsInSuckZone[num] == null))
					{
						zero = (vacuumSuckVolume.transform.position - vacuumSuckVolume.rbsInSuckZone[num].transform.position).normalized;
						vacuumSuckVolume.rbsInSuckZone[num].AddForce(zero * vacuumSuckForce, ForceMode.Acceleration);
						if (Vector3.Distance(vacuumSuckVolume.transform.position, vacuumSuckVolume.rbsInSuckZone[num].transform.position) < suckUpDistThreshold)
						{
							AddBerryToVacuum(vacuumSuckVolume.rbsInSuckZone[num]);
						}
					}
				}
			}
			if (vacuumSuckVolume.rbsInSuckZone_NonBerries.Count > 0)
			{
				Vector3 zero2 = Vector3.zero;
				for (int num2 = vacuumSuckVolume.rbsInSuckZone_NonBerries.Count - 1; num2 >= 0; num2--)
				{
					if (!(vacuumSuckVolume.rbsInSuckZone_NonBerries[num2] == null))
					{
						zero2 = (vacuumSuckVolume.transform.position - vacuumSuckVolume.rbsInSuckZone_NonBerries[num2].transform.position).normalized;
						vacuumSuckVolume.rbsInSuckZone_NonBerries[num2].AddForce(zero2 * vacuumSuckForce, ForceMode.Acceleration);
					}
				}
			}
			if (!vacuumSuck_Audio_Source.isPlaying)
			{
				vacuumSuck_Audio_Volume = 0f;
				vacuumSuck_Audio_Source.volume = vacuumSuck_Audio_Volume;
				vacuumSuck_Audio_Pitch_Curr = vacuumSuck_Audio_Pitch_Min;
				vacuumSuck_Audio_Source.pitch = vacuumSuck_Audio_Pitch_Curr;
				vacuumSuck_Audio_Source.Play();
			}
			if (vacuumSuck_Audio_Pitch_Curr < vacuumSuck_Audio_Pitch_Max)
			{
				vacuumSuck_Audio_Pitch_Curr += Time.deltaTime * vacuumSuck_Audio_Pitch_ChangeRate;
			}
			if (vacuumSuck_Audio_Volume < 1f)
			{
				vacuumSuck_Audio_Volume += Time.deltaTime * vacuumSuck_Audio_Volume_ChangeRate;
			}
			vacuumSuck_Audio_Source.pitch = vacuumSuck_Audio_Pitch_Curr;
			vacuumSuck_Audio_Source.volume = vacuumSuck_Audio_Volume * AudioManager.Singleton.sfxVolume;
			if (vacuumSuck_Audio_Source.isPlaying)
			{
				float constant = vacuum_SuckParticles_Emission.rateOverTime.constant;
				if (constant < 80f)
				{
					constant += Time.deltaTime * 50f;
					vacuum_SuckParticles_Emission.rateOverTime = constant;
				}
				else
				{
					vacuum_SuckParticles_Emission.rateOverTime = 80f;
				}
			}
			else
			{
				vacuum_SuckParticles_Emission.rateOverTime = 0f;
			}
			return;
		}
		vacuum_SuckParticles_Emission.rateOverTime = 0f;
		foreach (Rigidbody item in vacuumSuckVolume.rbsInSuckZone)
		{
			if ((bool)item)
			{
				item.gameObject.GetComponent<PickUppable>().SetDrag_NotHeld();
			}
		}
		foreach (Rigidbody rbsInSuckZone_NonBerry in vacuumSuckVolume.rbsInSuckZone_NonBerries)
		{
			if ((bool)rbsInSuckZone_NonBerry)
			{
				rbsInSuckZone_NonBerry.gameObject.GetComponent<PickUppable>().SetDrag_NotHeld();
			}
		}
		if (vacuumSuckVolume.rbsInSuckZone.Count > 0)
		{
			vacuumSuckVolume.rbsInSuckZone.Clear();
		}
		if (vacuumSuckVolume.rbsInSuckZone_NonBerries.Count > 0)
		{
			vacuumSuckVolume.rbsInSuckZone_NonBerries.Clear();
		}
		vacuumSuckVolume.gameObject.SetActive(value: false);
		if (vacuumSuck_Audio_Source.isPlaying)
		{
			if (vacuumSuck_Audio_Volume > 0f)
			{
				vacuumSuck_Audio_Volume -= Time.deltaTime * (vacuumSuck_Audio_Volume_ChangeRate * 1f);
				if (vacuumSuck_Audio_Pitch_Curr > 0f)
				{
					vacuumSuck_Audio_Pitch_Curr -= Time.deltaTime;
				}
			}
			else
			{
				vacuumSuck_Audio_Source.Stop();
			}
			vacuumSuck_Audio_Source.pitch = vacuumSuck_Audio_Pitch_Curr;
			vacuumSuck_Audio_Source.volume = vacuumSuck_Audio_Volume * AudioManager.Singleton.sfxVolume;
		}
		else
		{
			vacuumSuck_Audio_Source.pitch = vacuumSuck_Audio_Pitch_Min;
			vacuumSuck_Audio_Volume = 0f;
		}
	}

	private void HandleVacuumArtVisability()
	{
		if (!PlayerStats.Singleton.vacuum_Unlocked || GameManager.Singleton.hasTimerElapsed_IsNighttime || GameManager.Singleton.gameState != GameManager.GameState.Playing)
		{
			if (vacuumArt.activeSelf)
			{
				vacuumArt.SetActive(value: false);
				vacuum_AirBlastCharge_Particles.SetActive(value: false);
			}
			return;
		}
		if (vacuumisOn || rbsInVacuum.Count > 0 || kickChargeUp_Curr > 0f)
		{
			vacuumArt.SetActive(value: true);
			HidePopGunArt();
			vacArtShowTime_Curr = vacArtShowTime;
		}
		else if (vacArtShowTime_Curr > 0f)
		{
			vacArtShowTime_Curr -= Time.deltaTime;
		}
		else
		{
			vacuumArt.SetActive(value: false);
			vacuum_AirBlastCharge_Particles.SetActive(value: false);
		}
		vacuum_AirBlastCharge_Particles.SetActive(kickChargeUp_Curr > 0f);
	}

	private void AddBerryToVacuum(Rigidbody _rb)
	{
		vacuumSuckVolume.rbsInSuckZone.Remove(_rb);
		AudioManager.Singleton.PlayUnimportantSFX(vacuumShooter_Audio_ShootSFX, _rb.gameObject.transform.position, new Vector2(1.9f, 2.2f), 0.6f, 2f, 5f);
		rbsInVacuum.Add(_rb);
		_rb.isKinematic = true;
		_rb.linearVelocity = Vector3.zero;
		_rb.GetComponent<PickUppable>().DisableColliders_Local();
		_rb.gameObject.transform.position = hiddenVacHolderSpot;
		feedback_VacuumSpring?.PlayFeedbacks();
	}

	private void ShootBerryFromVacuum(Rigidbody _rb)
	{
		if (!GameManager.Singleton.hasTimerElapsed_IsNighttime)
		{
			rbsInVacuum.Remove(_rb);
			PickUppable component = _rb.gameObject.GetComponent<PickUppable>();
			component.SetDrag_NotHeld();
			component.ResetRecentlyThrownTime();
			_rb.position = itemHoldSpot.transform.position;
			_rb.isKinematic = false;
			_rb.linearVelocity = Vector3.zero;
			_rb.GetComponent<PickUppable>().EnableColliders_Local();
			AddThrowPhysics(_rb, vacShootPower, vacShootUpwardPower);
			vacuumShooter_Audio_Source.pitch = vacuumShooter_Audio_Pitch_Curr;
			vacuumShooter_Audio_Source.PlayOneShot(vacuumShooter_Audio_ShootSFX, AudioManager.Singleton.sfxVolume * 0.65f);
			vacuumShooter_Audio_Pitch_Curr = Mathf.Clamp(vacuumShooter_Audio_Pitch_Curr + vacuumShooter_Audio_Pitch_Increase, vacuumShooter_Audio_Pitch_Min, vacuumShooter_Audio_Pitch_Max);
			vacuumShooter_Audio_Pitch_Timer_Curr = vacuumShooter_Audio_Pitch_Timer_Max;
			feedback_VacuumSpring?.PlayFeedbacks();
			popgun_FireCooldown_Curr = popgun_FireRate;
		}
	}

	private void RemoveAnyNullsFromRbsInVacuumList()
	{
		for (int num = rbsInVacuum.Count - 1; num >= 0; num--)
		{
			if (rbsInVacuum[num] == null)
			{
				rbsInVacuum.RemoveAt(num);
			}
		}
	}

	private void HandleShootingPitchShiftSFX_Timer()
	{
		if (vacuumShooter_Audio_Pitch_Timer_Curr > 0f)
		{
			vacuumShooter_Audio_Pitch_Timer_Curr -= Time.deltaTime;
			if (vacuumShooter_Audio_Pitch_Timer_Curr <= 0f)
			{
				vacuumShooter_Audio_Pitch_Curr = vacuumShooter_Audio_Pitch_Min;
			}
		}
	}

	private void OnNightTime()
	{
		ClearItemInHand();
	}

	private void FirePopGun()
	{
		if (GameManager.Singleton.gameState == GameManager.GameState.Playing && !GameManager.Singleton.isLookingAtPC && popgun_FireCooldown_Curr <= 0f)
		{
			ShowPopGunArt();
			popgun_Art_TimeBeforeAutoHiding_Curr = popgun_Art_TimeBeforeAutoHiding;
			feedback_PopGun_Shoot?.PlayFeedbacks();
			AudioManager.Singleton.PlaySFX_PopGun_Fire(base.transform.position);
			GameObject gameObject = UnityEngine.Object.Instantiate(popgun_BulletPrefab, popgun_BulletSpawnPoint.position, popgun_BulletSpawnPoint.rotation);
			Rigidbody component = gameObject.GetComponent<Rigidbody>();
			GameManager.Singleton.popgun_SpawnedBullets.Add(gameObject);
			component.AddForce(playerCam.transform.forward * popgun_BulletForce, ForceMode.VelocityChange);
			popgun_FireCooldown_Curr = popgun_FireRate;
		}
	}

	private void HandlePopGunTimers()
	{
		if (!PlayerStats.Singleton.popgun_Unlocked)
		{
			return;
		}
		bool num = popgun_FireCooldown_Curr <= 0f;
		if (popgun_FireCooldown_Curr > 0f)
		{
			popgun_FireCooldown_Curr -= Time.deltaTime;
		}
		bool flag = popgun_FireCooldown_Curr <= 0f;
		popgun_Art_Dart.SetActive(popgun_FireCooldown_Curr <= 0f);
		if (!num && flag)
		{
			feedback_PopGun_Reload?.PlayFeedbacks();
		}
		if (GetIsHoldingItem())
		{
			HidePopGunArt();
		}
		else if (popgun_Art_TimeBeforeAutoHiding_Curr > 0f)
		{
			popgun_Art_TimeBeforeAutoHiding_Curr -= Time.deltaTime;
			if (popgun_Art_TimeBeforeAutoHiding_Curr <= 0f)
			{
				HidePopGunArt();
			}
		}
	}

	private void ShowPopGunArt()
	{
		popgun_Art_Gun.SetActive(value: true);
		vacuumArt.SetActive(value: false);
		vacArtShowTime_Curr = 0f;
	}

	private void HidePopGunArt()
	{
		popgun_Art_Gun.SetActive(value: false);
		popgun_Art_TimeBeforeAutoHiding_Curr = 0f;
	}

	public PickUppable GetHeldPickuppable()
	{
		if ((bool)heldPickUppable)
		{
			return heldPickUppable;
		}
		return null;
	}

	private void RaycastForLookingAtPC()
	{
		if (Physics.Raycast(new Ray(playerCam.transform.position, playerCam.transform.forward), out var hitInfo, 6f, pcLookAtMask, QueryTriggerInteraction.Ignore) && hitInfo.collider.gameObject.layer == 1)
		{
			GameManager.Singleton.isLookingAtPC = true;
		}
		else
		{
			GameManager.Singleton.isLookingAtPC = false;
		}
	}

	private void HandleHoldingACassetteTape()
	{
		if (!GetIsHoldingItem())
		{
			return;
		}
		try
		{
			if ((bool)heldPickUppable && heldPickUppable.GetItemIdentity() == ItemIdentity.Cassette)
			{
				CassettesManager.Singleton.PickedUpTape(heldPickUppable.cassetteIndex);
				DropHeldItem(_Throw: false, heldPickUppable);
			}
		}
		catch
		{
			Debug.Log("Failed to unlock cassette tape, ignoring for now - but not ideal!");
		}
	}

	private void HandleVacuumCountDisplay()
	{
		vac_DisplayCountText.text = "";
		float num = Mathf.Clamp(rbsInVacuum.Count, 0f, PlayerStats.Singleton.vacuumCapacity) / (float)PlayerStats.Singleton.vacuumCapacity;
		int num2 = 0;
		num2 = ((!(num >= 1f)) ? Mathf.FloorToInt(num * (float)vac_Lights_Off.Length) : vac_Lights_Off.Length);
		for (int i = 0; i < vac_Lights_Off.Length; i++)
		{
			if (i >= num2)
			{
				vac_Lights_Off[i].SetActive(value: true);
				vac_Lights_On[i].SetActive(value: false);
			}
			else
			{
				vac_Lights_Off[i].SetActive(value: false);
				vac_Lights_On[i].SetActive(value: true);
			}
		}
		if (num > 0f)
		{
			vac_Lights_On[0].SetActive(value: true);
			vac_Lights_Off[0].SetActive(value: false);
		}
	}
}
