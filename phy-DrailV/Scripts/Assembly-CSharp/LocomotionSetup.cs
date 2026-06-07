using System;
using System.Collections;
using DV;
using DV.Common;
using DV.UI;
using DV.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class LocomotionSetup : MonoBehaviour
{
	private const float BLINK_DURATION = 0.3f;

	public GameObject charControllerRig;

	public Transform cameraHolder;

	public VRTK_TouchpadControl touchpadControlLeft;

	public VRTK_TouchpadControl touchpadControlRight;

	public RotatePlayer rotatePlayer;

	private CustomFirstPersonController customFPSController;

	private bool isSafeToInitSmooth = true;

	private bool isBlockingWindowOpen;

	private bool isToggleLocomotionPending;

	private float currentTeleportHeightOffset;

	public static LocomotionType CurrentLocomotion { get; private set; }

	public static bool Initialized { get; private set; }

	private float HeadOffsetSeated => GamePreferences.Get<float>(Preferences.PlayerSeatedHeight);

	private float HeadOffsetRoomscale => GamePreferences.Get<float>(Preferences.PlayerRoomscaleHeight) - 1.62f;

	private bool IsSeated => GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType);

	private bool IsSmoothLocomotion => LocomotionType.Smooth == CurrentLocomotion;

	public static event Action LocomotionAboutToBeChanged;

	public static event Action<LocomotionType> LocomotionChanged;

	private void Awake()
	{
		if (GamePreferences.Get<bool>(Preferences.SmoothLocomotion) && (!WorldStreamingInit.IsLoaded || LoadingScreenManager.IsLoading))
		{
			isSafeToInitSmooth = false;
			WorldStreamingInit.LoadingFinished += LoadingFinishedCallback;
		}
		customFPSController = charControllerRig.GetComponent<CustomFirstPersonController>();
		currentTeleportHeightOffset = HeadOffsetRoomscale;
		UpdateTeleportLocomotionHeight();
		SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled += ElementToggled;
		SingletonBehaviour<VRManager>.Instance.AboutToRecenterSeatedPosition += OnAboutToRecenterSeated;
		GamePreferences.RegisterToPreferenceUpdated(Preferences.SmoothLocomotion, OnLocomotionChanged);
		GamePreferences.RegisterToPreferenceUpdated(Preferences.UseControllerDirection, UpdateDirectionDevice);
		SingletonBehaviour<VRManager>.Instance.TrackingSpaceChanged += UpdateTeleportLocomotionHeight;
		GamePreferences.RegisterToPreferenceUpdated(Preferences.PlayerSeatedHeight, UpdateTeleportLocomotionHeight);
		GamePreferences.RegisterToPreferenceUpdated(Preferences.PlayerRoomscaleHeight, UpdateTeleportLocomotionHeight);
	}

	private void LoadingFinishedCallback()
	{
		WorldStreamingInit.LoadingFinished -= LoadingFinishedCallback;
		isSafeToInitSmooth = true;
	}

	private void OnAboutToRecenterSeated()
	{
		if ((bool)PlayerManager.Car)
		{
			VRTK_DeviceFinder.PlayAreaTransform().localRotation = Quaternion.identity;
		}
	}

	private void Start()
	{
		SingletonBehaviour<CoroutineManager>.Instance.Run(DelayedStart());
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled -= ElementToggled;
			SingletonBehaviour<VRManager>.Instance.TrackingSpaceChanged -= UpdateTeleportLocomotionHeight;
			SingletonBehaviour<VRManager>.Instance.AboutToRecenterSeatedPosition -= OnAboutToRecenterSeated;
		}
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.SmoothLocomotion, OnLocomotionChanged);
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.UseControllerDirection, UpdateDirectionDevice);
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.PlayerSeatedHeight, UpdateTeleportLocomotionHeight);
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.PlayerRoomscaleHeight, UpdateTeleportLocomotionHeight);
		WorldStreamingInit.LoadingFinished -= LoadingFinishedCallback;
		CurrentLocomotion = LocomotionType.Teleport;
		Initialized = false;
	}

	private void OnLocomotionChanged()
	{
		if (isBlockingWindowOpen)
		{
			Debug.Log("Delayed until menu is closed");
			isToggleLocomotionPending = true;
		}
		else
		{
			ToggleLocomotion();
		}
	}

	private IEnumerator DelayedStart()
	{
		yield return null;
		PlayerInputTouchpadControl[] array = new PlayerInputTouchpadControl[2]
		{
			VRTK_DeviceFinder.GetControllerLeftHand(getActual: true).GetComponentInChildren<PlayerInputTouchpadControl>(includeInactive: true),
			VRTK_DeviceFinder.GetControllerRightHand(getActual: true).GetComponentInChildren<PlayerInputTouchpadControl>(includeInactive: true)
		};
		for (int i = 0; i < array.Length; i++)
		{
			if (VRTK_DeviceFinder.GetHeadsetType() == SDK_BaseHeadset.HeadsetType.WindowsMixedReality)
			{
				array[i].coordinateAxis = VRTK_ControllerEvents.Vector2AxisAlias.TouchpadTwo;
				array[i].primaryActivationButton = VRTK_ControllerEvents.ButtonAlias.TouchpadTwoTouch;
				array[i].actionModifierButton = VRTK_ControllerEvents.ButtonAlias.TouchpadTwoPress;
			}
		}
		if (GamePreferences.Get<bool>(Preferences.SmoothLocomotion))
		{
			while (!isSafeToInitSmooth)
			{
				yield return null;
			}
			EnableSmoothLocomotion();
		}
		else
		{
			ResetToTeleportLocomotion();
		}
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		yield return null;
		Initialized = true;
	}

	private void ElementToggled(ACanvasController<CanvasController.ElementType>.Element element)
	{
		if (CanvasController.ElementType.Blockers.HasIntFlag(element.Type))
		{
			isBlockingWindowOpen = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Blockers);
			if (!isBlockingWindowOpen && isToggleLocomotionPending)
			{
				ToggleLocomotion();
			}
			else
			{
				UpdateLocomotionValues();
			}
		}
	}

	private void ToggleLocomotion()
	{
		isToggleLocomotionPending = false;
		bool flag = GamePreferences.Get<bool>(Preferences.SmoothLocomotion);
		bool flag2 = flag != (CurrentLocomotion == LocomotionType.Smooth);
		Debug.Log($"Current: {CurrentLocomotion}");
		Debug.Log($"Pref: smooth = {flag}");
		Debug.Log($"Locomotion changed: {flag2}");
		if (flag2)
		{
			if (flag)
			{
				Debug.Log("Enabling smooth locomotion");
				EnableSmoothLocomotion();
			}
			else
			{
				Debug.Log("Resetting to teleport locomotion");
				ResetToTeleportLocomotion();
			}
		}
	}

	private void UpdateDirectionDevice()
	{
		ChangeDirectionDevice(GamePreferences.Get<bool>(Preferences.UseControllerDirection) ? VRTK_ObjectControl.DirectionDevices.LeftController : VRTK_ObjectControl.DirectionDevices.Headset);
	}

	private void ChangeDirectionDevice(VRTK_ObjectControl.DirectionDevices directionDevice)
	{
		touchpadControlLeft.deviceForDirection = directionDevice;
		touchpadControlRight.deviceForDirection = directionDevice;
		if (directionDevice == VRTK_ObjectControl.DirectionDevices.Headset)
		{
			customFPSController.directionDevice = VRTK_DeviceFinder.HeadsetTransform();
		}
		else
		{
			customFPSController.directionDevice = touchpadControlLeft.transform;
		}
	}

	private void AddFallThroughTerrainFix(GameObject addTo)
	{
		FallThroughTerrainFix fallThroughTerrainFix = UnityEngine.Object.FindObjectOfType<FallThroughTerrainFix>();
		if ((bool)fallThroughTerrainFix)
		{
			UnityEngine.Object.Destroy(fallThroughTerrainFix);
		}
		addTo.AddComponent<FallThroughTerrainFix>();
	}

	private void AddWorldBoundaryEnforcer(GameObject addTo)
	{
		WorldBoundaryEnforcer worldBoundaryEnforcer = UnityEngine.Object.FindObjectOfType<WorldBoundaryEnforcer>();
		if ((bool)worldBoundaryEnforcer)
		{
			UnityEngine.Object.Destroy(worldBoundaryEnforcer);
		}
		addTo.AddComponent<WorldBoundaryEnforcer>();
	}

	private void ResetToTeleportLocomotion()
	{
		LocomotionSetup.LocomotionAboutToBeChanged?.Invoke();
		CurrentLocomotion = LocomotionType.Teleport;
		Transform transform = VRTK_DeviceFinder.PlayAreaTransform();
		PlayerManager.SetPlayer(transform, UpdatePlayerReference.GetCamera());
		customFPSController.directionDevice = customFPSController.transform;
		charControllerRig.SetActive(value: false);
		AddFallThroughTerrainFix(transform.gameObject);
		AddWorldBoundaryEnforcer(transform.gameObject);
		TrainCar car = PlayerManager.Car;
		Transform transform2 = ((car != null) ? car.interior : null);
		if (transform.parent != transform2)
		{
			transform.SetParent(transform2);
			if (transform2 == null)
			{
				SceneManager.MoveGameObjectToScene(transform.gameObject, SceneManager.GetActiveScene());
			}
		}
		LocomotionSetup.LocomotionChanged?.Invoke(LocomotionType.Teleport);
	}

	private void EnableSmoothLocomotion()
	{
		LocomotionSetup.LocomotionAboutToBeChanged?.Invoke();
		CurrentLocomotion = LocomotionType.Smooth;
		PlayerManager.SetPlayer(charControllerRig.transform, UpdatePlayerReference.GetCamera());
		VRTK_SDK_Bridge.HeadsetFade(Color.black, 0f);
		VRTK_SDK_Bridge.HeadsetFade(Color.clear, 0.3f);
		charControllerRig.SetActive(value: true);
		AddFallThroughTerrainFix(charControllerRig);
		AddWorldBoundaryEnforcer(charControllerRig);
		VRTK_ObjectControl.DirectionDevices directionDevice = (GamePreferences.Get<bool>(Preferences.UseControllerDirection) ? VRTK_ObjectControl.DirectionDevices.LeftController : VRTK_ObjectControl.DirectionDevices.Headset);
		ChangeDirectionDevice(directionDevice);
		Transform transform = VRTK_DeviceFinder.PlayAreaTransform();
		cameraHolder.position = transform.position;
		if (transform.parent != cameraHolder)
		{
			transform.SetParent(cameraHolder);
		}
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		Physics.SyncTransforms();
		Vector3 pointOnGround = GetPointOnGround();
		Quaternion rotation = Quaternion.Euler(0f, transform.localEulerAngles.y, 0f);
		Transform target = (PlayerManager.Car ? PlayerManager.Car.transform : null);
		customFPSController.IgnoreFootstepsSoundUntilGrounded();
		PlayerManager.TeleportPlayer(pointOnGround, rotation, target, useRotation: true);
		StartCoroutine(AlignCharControllerCollider());
		UpdateLocomotionValues();
		LocomotionSetup.LocomotionChanged?.Invoke(LocomotionType.Smooth);
	}

	private IEnumerator AlignCharControllerCollider()
	{
		yield return WaitFor.EndOfFrame;
		charControllerRig.GetComponent<CharacterControllerMover>().MoveCharacterColliderUnderPlayersHead(force: true);
	}

	private void UpdateLocomotionValues()
	{
		float walkMult = GamePreferences.Get<float>(Preferences.StrafeSpeedMultiplier);
		float runMult = GamePreferences.Get<float>(Preferences.RunSpeedMultiplier);
		customFPSController.UpdateLocomotionValues(walkMult, runMult);
		GetComponent<ComfortTunnelOverlay>().enabled = GamePreferences.Get<bool>(Preferences.ComfortTunnel);
		UpdateDirectionDevice();
	}

	private Vector3 GetPointOnGround()
	{
		Transform transform = VRTK_DeviceFinder.HeadsetCamera();
		LayerMask traversableLayers = customFPSController.GetTraversableLayers();
		float playerHeight = 1.62f;
		Vector3 origin = transform.position + Vector3.up * 0.2f;
		if (Physics.Raycast(origin, Vector3.down, out var hitInfo, 5f, traversableLayers, QueryTriggerInteraction.Ignore) && TeleportRaycastLogic.AdjustHit(origin, hitInfo, out var adjustedHit, traversableLayers, playerHeight))
		{
			return adjustedHit.point;
		}
		Debug.LogWarning("Couldn't find a good position based on player's current head position, trying a fallback method");
		if (Physics.Raycast(transform.position + Vector3.up * 5000f, Vector3.down, out hitInfo, 6000f, traversableLayers, QueryTriggerInteraction.Ignore) && TeleportRaycastLogic.AdjustHit(origin, hitInfo, out var adjustedHit2, traversableLayers, playerHeight))
		{
			return adjustedHit2.point;
		}
		Debug.LogWarning("Still couldn't find a good position based on player's current head position, returning headset position");
		return transform.position;
	}

	private void UpdateTeleportLocomotionHeight()
	{
		if (!IsSmoothLocomotion)
		{
			float num = (IsSeated ? HeadOffsetSeated : HeadOffsetRoomscale);
			if (currentTeleportHeightOffset != num)
			{
				Transform obj = VRTK_DeviceFinder.PlayAreaTransform();
				float num2 = num - currentTeleportHeightOffset;
				obj.Translate(Vector3.up * num2, Space.World);
				currentTeleportHeightOffset = num;
			}
		}
	}
}
