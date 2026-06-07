using System;
using System.Linq;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class VRManager : SingletonBehaviour<VRManager>
{
	public enum SDK
	{
		SteamVR = 0,
		Oculus = 1
	}

	public const float RECENTER_FADE_DURATION = 0.25f;

	public const string VRMODE_EDITORPREF_KEY = "DV.NonVRToolbarButton";

	private static bool? vrEnabled;

	public static bool IsControllerEnabledRight => IsControllerEnabled(SDK_BaseController.ControllerHand.Right);

	public static bool IsControllerEnabledLeft => IsControllerEnabled(SDK_BaseController.ControllerHand.Left);

	public event Action AboutToChangeTrackingSpace;

	public event Action TrackingSpaceChanged;

	public event Action AboutToRecenterSeatedPosition;

	public event Action SeatedPositionRecentered;

	public new static string AllowAutoCreate()
	{
		return "[VRManager]";
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void StaticReload()
	{
		vrEnabled = null;
	}

	public static bool IsControllerEnabled(SDK_BaseController.ControllerHand hand)
	{
		if (hand == SDK_BaseController.ControllerHand.None)
		{
			return false;
		}
		VRTK_ControllerReference controllerReferenceForHand = VRTK_DeviceFinder.GetControllerReferenceForHand(hand);
		if (controllerReferenceForHand == null || !controllerReferenceForHand.IsValid())
		{
			return false;
		}
		GameObject controllerByIndex = VRTK_DeviceFinder.GetControllerByIndex(controllerReferenceForHand.index, getActual: true);
		if (controllerByIndex != null)
		{
			return controllerByIndex.activeInHierarchy;
		}
		return false;
	}

	protected override void Awake()
	{
		base.Awake();
		Validate();
	}

	private void Validate()
	{
		bool flag = false;
		flag = true;
		if (1 == 0 && !flag)
		{
			Debug.LogError("Neither SteamVR nor Oculus SDK have been detected");
		}
	}

	private void Start()
	{
		GamePreferences.RegisterToPreferenceUpdated(Preferences.SeatedPlayAreaType, OnTrackingModePreferenceChanged);
		ApplyTrackingSpace(GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType));
	}

	public static void ForceVREnabled(bool on)
	{
		vrEnabled = on;
	}

	public static bool HasNonVrArg()
	{
		bool flag = false;
		return Environment.GetCommandLineArgs().Contains("-nonvr") || flag;
	}

	public static bool IsVREnabled()
	{
		if (!vrEnabled.HasValue)
		{
			vrEnabled = !HasNonVrArg();
		}
		return vrEnabled.Value;
	}

	public void ResetSeatedPosition(bool fade = true)
	{
		if (!VRTK_SDKManager.ValidInstance())
		{
			Debug.LogWarning("VRTK not present, ignoring ResetSeatedPosition");
		}
		else if (GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType))
		{
			this.AboutToRecenterSeatedPosition?.Invoke();
			if (fade)
			{
				VRTK_SDK_Bridge.HeadsetFade(Color.black, 0f);
			}
			VRTK_SDKManager.instance.loadedSetup.systemSDK.ResetSeatedPosition();
			if (fade)
			{
				VRTK_SDK_Bridge.HeadsetFade(Color.clear, 0.25f);
			}
			this.SeatedPositionRecentered?.Invoke();
		}
	}

	public static SDK GetCurrentSDK()
	{
		if (VRTK_SDKManager.GetLoadedSDKSetup().name.ToLower().Contains("oculus"))
		{
			return SDK.Oculus;
		}
		return SDK.SteamVR;
	}

	private static void ApplyTrackingSpace(bool isSeated)
	{
		if (!VRTK_SDKManager.ValidInstance())
		{
			Debug.LogWarning("VRTK not present, ignoring ApplyTrackingSpace");
		}
		else
		{
			VRTK_SDKManager.instance.loadedSetup.systemSDK.SetSeatedMode(isSeated);
		}
	}

	private void OnTrackingModePreferenceChanged()
	{
		this.AboutToChangeTrackingSpace?.Invoke();
		bool num = GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType);
		ApplyTrackingSpace(num);
		this.TrackingSpaceChanged?.Invoke();
		if (num)
		{
			ResetSeatedPosition();
		}
		Anal.EnqueueSendPreferredTrackingMode();
	}

	public static bool AnyWandController()
	{
		if (!IsVREnabled())
		{
			return false;
		}
		VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Right);
		if (controllerReference.IsValid() && controllerReference.IsWandOrUndefined())
		{
			return true;
		}
		VRTK_ControllerReference controllerReference2 = VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Left);
		if (controllerReference2.IsValid() && controllerReference2.IsWandOrUndefined())
		{
			return true;
		}
		return false;
	}
}
