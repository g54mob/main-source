using UnityEngine;

public class OVRDirectComposition : OVRCameraComposition
{
	private GameObject previousMainCameraObject;

	public GameObject directCompositionCameraGameObject;

	public Camera directCompositionCamera;

	public RenderTexture boundaryMeshMaskTexture;

	public override OVRManager.CompositionMethod CompositionMethod()
	{
		return OVRManager.CompositionMethod.Direct;
	}

	public OVRDirectComposition(GameObject parentObject, Camera mainCamera, OVRMixedRealityCaptureConfiguration configuration)
		: base(parentObject, mainCamera, configuration)
	{
		RefreshCameraObjects(parentObject, mainCamera, configuration);
	}

	private void RefreshCameraObjects(GameObject parentObject, Camera mainCamera, OVRMixedRealityCaptureConfiguration configuration)
	{
		if (!hasCameraDeviceOpened)
		{
			Debug.LogWarning("[OVRDirectComposition] RefreshCameraObjects(): Unable to open camera device " + cameraDevice);
		}
		else if (mainCamera.gameObject != previousMainCameraObject)
		{
			Debug.LogFormat("[OVRDirectComposition] Camera refreshed. Rebind camera to {0}", mainCamera.gameObject.name);
			OVRCompositionUtil.SafeDestroy(ref directCompositionCameraGameObject);
			directCompositionCamera = null;
			RefreshCameraRig(parentObject, mainCamera);
			if (configuration.instantiateMixedRealityCameraGameObject != null)
			{
				directCompositionCameraGameObject = configuration.instantiateMixedRealityCameraGameObject(mainCamera.gameObject, OVRManager.MrcCameraType.Normal);
			}
			else
			{
				directCompositionCameraGameObject = Object.Instantiate(mainCamera.gameObject);
			}
			directCompositionCameraGameObject.name = "OculusMRC_DirectCompositionCamera";
			directCompositionCameraGameObject.transform.parent = (cameraInTrackingSpace ? cameraRig.trackingSpace : parentObject.transform);
			if ((bool)directCompositionCameraGameObject.GetComponent<AudioListener>())
			{
				Object.Destroy(directCompositionCameraGameObject.GetComponent<AudioListener>());
			}
			if ((bool)directCompositionCameraGameObject.GetComponent<OVRManager>())
			{
				Object.Destroy(directCompositionCameraGameObject.GetComponent<OVRManager>());
			}
			directCompositionCamera = directCompositionCameraGameObject.GetComponent<Camera>();
			directCompositionCamera.stereoTargetEye = StereoTargetEyeMask.None;
			directCompositionCamera.depth = float.MaxValue;
			directCompositionCamera.rect = new Rect(0f, 0f, 1f, 1f);
			directCompositionCamera.cullingMask = (directCompositionCamera.cullingMask & ~(int)configuration.extraHiddenLayers) | (int)configuration.extraVisibleLayers;
			Debug.Log("DirectComposition activated : useDynamicLighting " + (configuration.useDynamicLighting ? "ON" : "OFF"));
			RefreshCameraFramePlaneObject(parentObject, directCompositionCamera, configuration);
			previousMainCameraObject = mainCamera.gameObject;
		}
	}

	public override void Update(GameObject gameObject, Camera mainCamera, OVRMixedRealityCaptureConfiguration configuration, OVRManager.TrackingOrigin trackingOrigin)
	{
		if (!hasCameraDeviceOpened)
		{
			return;
		}
		RefreshCameraObjects(gameObject, mainCamera, configuration);
		if (!OVRPlugin.SetHandNodePoseStateLatency(configuration.handPoseStateLatency))
		{
			Debug.LogWarning("HandPoseStateLatency is invalid. Expect a value between 0.0 to 0.5, get " + configuration.handPoseStateLatency);
		}
		directCompositionCamera.clearFlags = mainCamera.clearFlags;
		directCompositionCamera.backgroundColor = mainCamera.backgroundColor;
		if (configuration.dynamicCullingMask)
		{
			directCompositionCamera.cullingMask = (mainCamera.cullingMask & ~(int)configuration.extraHiddenLayers) | (int)configuration.extraVisibleLayers;
		}
		directCompositionCamera.nearClipPlane = mainCamera.nearClipPlane;
		directCompositionCamera.farClipPlane = mainCamera.farClipPlane;
		OVRPlugin.CameraExtrinsics cameraExtrinsics;
		OVRPlugin.CameraIntrinsics cameraIntrinsics;
		if (OVRMixedReality.useFakeExternalCamera || OVRPlugin.GetExternalCameraCount() == 0)
		{
			OVRPose oVRPose = new OVRPose
			{
				position = ((trackingOrigin == OVRManager.TrackingOrigin.EyeLevel) ? OVRMixedReality.fakeCameraEyeLevelPosition : OVRMixedReality.fakeCameraFloorLevelPosition),
				orientation = OVRMixedReality.fakeCameraRotation
			};
			directCompositionCamera.fieldOfView = OVRMixedReality.fakeCameraFov;
			directCompositionCamera.aspect = OVRMixedReality.fakeCameraAspect;
			if (cameraInTrackingSpace)
			{
				directCompositionCamera.transform.FromOVRPose(oVRPose, isLocal: true);
			}
			else
			{
				OVRPose oVRPose2 = default(OVRPose);
				oVRPose2 = oVRPose.ToWorldSpacePose(mainCamera);
				directCompositionCamera.transform.FromOVRPose(oVRPose2);
			}
		}
		else if (OVRPlugin.GetMixedRealityCameraInfo(0, out cameraExtrinsics, out cameraIntrinsics))
		{
			float fieldOfView = Mathf.Atan(cameraIntrinsics.FOVPort.UpTan) * 57.29578f * 2f;
			float aspect = cameraIntrinsics.FOVPort.LeftTan / cameraIntrinsics.FOVPort.UpTan;
			directCompositionCamera.fieldOfView = fieldOfView;
			directCompositionCamera.aspect = aspect;
			if (cameraInTrackingSpace)
			{
				OVRPose pose = ComputeCameraTrackingSpacePose(cameraExtrinsics);
				directCompositionCamera.transform.FromOVRPose(pose, isLocal: true);
			}
			else
			{
				OVRPose pose2 = ComputeCameraWorldSpacePose(cameraExtrinsics, mainCamera);
				directCompositionCamera.transform.FromOVRPose(pose2);
			}
		}
		else
		{
			Debug.LogWarning("Failed to get external camera information");
		}
		if (hasCameraDeviceOpened)
		{
			if (boundaryMeshMaskTexture == null || boundaryMeshMaskTexture.width != Screen.width || boundaryMeshMaskTexture.height != Screen.height)
			{
				boundaryMeshMaskTexture = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.R8);
				boundaryMeshMaskTexture.Create();
			}
			UpdateCameraFramePlaneObject(mainCamera, directCompositionCamera, configuration, boundaryMeshMaskTexture);
			directCompositionCamera.GetComponent<OVRCameraFrameCompositionManager>().boundaryMeshMaskTexture = boundaryMeshMaskTexture;
		}
	}

	public override void Cleanup()
	{
		base.Cleanup();
		OVRCompositionUtil.SafeDestroy(ref directCompositionCameraGameObject);
		directCompositionCamera = null;
		Debug.Log("DirectComposition deactivated");
	}
}
