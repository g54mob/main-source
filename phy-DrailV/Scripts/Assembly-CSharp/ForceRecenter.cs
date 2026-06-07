using DV.UI;
using DV.Utils;
using DV.VR;
using UnityEngine;
using VRTK;

public class ForceRecenter : MonoBehaviour
{
	private const float CAMERA_DISTANCE_FROM_CENTER_THRESHOLD = 0.1f;

	private static bool CalibratedRoomPosition;

	private bool IsSeated => GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType);

	private bool IsSmoothLoco => GamePreferences.Get<bool>(Preferences.SmoothLocomotion);

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void StaticReload()
	{
		CalibratedRoomPosition = false;
	}

	private void Awake()
	{
		SingletonBehaviour<VRManager>.Instance.TrackingSpaceChanged += OnTrackingSpaceChanged;
		GamePreferences.RegisterToPreferenceUpdated(Preferences.VRTeleportOrientation, VRTeleportOrientationChanged);
		bool flag = IsSeated;
		if (!IsSeated && !CalibratedRoomPosition && GamePreferences.Get<int>(Preferences.VRTeleportOrientation) == 3)
		{
			flag = true;
			CalibratedRoomPosition = true;
		}
		if (flag)
		{
			Recenter();
		}
	}

	private void VRTeleportOrientationChanged()
	{
		if (GamePreferences.Get<int>(Preferences.VRTeleportOrientation) == 3)
		{
			Recenter();
			CalibratedRoomPosition = true;
		}
	}

	private void OnDestroy()
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.VRTeleportOrientation, VRTeleportOrientationChanged);
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<VRManager>.Instance.TrackingSpaceChanged -= OnTrackingSpaceChanged;
		}
	}

	private void OnTrackingSpaceChanged()
	{
		if (IsSmoothLoco)
		{
			Vector3 position = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.mainCanvas.GetComponentInParent<Floatie>().transform.position;
			PlayerManager.PlayerTransform.GetComponent<CameraAnchorLeanCrouch>().UpdateHeight();
			((PlayerTeleportVR)SingletonBehaviour<APlayerTeleport>.Instance).smoothLocoRig.GetComponent<CameraSmoothing>().ForceUpdateHeadPosition();
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.mainCanvas.GetComponentInParent<FloatiePlayerCameraFollower>().RefreshPosition();
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.mainCanvas.GetComponentInParent<Floatie>().transform.position = position;
		}
		if (IsSeated)
		{
			Transform obj = VRTK_DeviceFinder.PlayAreaTransform();
			Transform transform = VRTK_DeviceFinder.HeadsetCamera();
			if (Vector3.Magnitude(obj.position - transform.position) > 0.1f)
			{
				Recenter();
			}
		}
	}

	private void Recenter()
	{
		VRCalibration.Recalibrate();
	}
}
