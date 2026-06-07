using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Prefabs/VRTK_DesktopCamera")]
	public class VRTK_DesktopCamera : MonoBehaviour
	{
		[Header("Desktop Camera")]
		[Tooltip("The camera to use for the desktop view. If left blank the camera on the game object this script is attached to or any of its children will be used.")]
		public Camera desktopCamera;

		[Tooltip("The follow script to use for following the headset. If left blank the follow script on the game object this script is attached to or any of its children will be used.")]
		public VRTK_ObjectFollow followScript;

		[Header("Headset Image")]
		[Tooltip("The optional image to render the headset's view into. Can be left blank.")]
		public RawImage headsetImage;

		[Tooltip("The optional render texture to render the headset's view into. Can be left blank. If this is blank and `headsetImage` is set a default render texture will be created.")]
		public RenderTexture headsetRenderTexture;

		protected Camera headsetCameraCopy;

		protected VRTK_TransformFollow headsetCameraTransformFollow;

		protected virtual void OnEnable()
		{
			desktopCamera = ((desktopCamera == null) ? GetComponentInChildren<Camera>() : desktopCamera);
			followScript = ((followScript == null) ? GetComponentInChildren<VRTK_ObjectFollow>() : followScript);
			if (desktopCamera == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_NOT_INJECTED, "VRTK_DesktopCamera", "Camera", "desktopCamera", "the same", " or any child of it"));
			}
			else if (followScript == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_NOT_INJECTED, "VRTK_DesktopCamera", "VRTK_ObjectFollow", "followScript", "the same", " or any child of it"));
			}
			else
			{
				headsetCameraTransformFollow = base.gameObject.AddComponent<VRTK_TransformFollow>();
				headsetCameraTransformFollow.moment = VRTK_TransformFollow.FollowMoment.OnLateUpdate;
				if (VRTK_SDKManager.SubscribeLoadedSetupChanged(LoadedSetupChanged) && VRTK_SDKManager.GetLoadedSDKSetup() != null)
				{
					ConfigureForCurrentSDKSetup();
				}
			}
		}

		protected virtual void OnDisable()
		{
			VRTK_SDKManager.UnsubscribeLoadedSetupChanged(LoadedSetupChanged);
			Object.Destroy(headsetCameraTransformFollow);
			if (headsetCameraCopy != null)
			{
				Object.Destroy(headsetCameraCopy.gameObject);
			}
		}

		protected virtual void LoadedSetupChanged(VRTK_SDKManager sender, VRTK_SDKManager.LoadedSetupChangeEventArgs e)
		{
			ConfigureForCurrentSDKSetup();
		}

		protected virtual void ConfigureForCurrentSDKSetup()
		{
			if (headsetCameraCopy != null)
			{
				Object.Destroy(headsetCameraCopy.gameObject);
			}
			headsetCameraTransformFollow.enabled = false;
			followScript.enabled = false;
			if (VRTK_SDKManager.GetLoadedSDKSetup() == null)
			{
				return;
			}
			Camera component = VRTK_DeviceFinder.HeadsetCamera().GetComponent<Camera>();
			desktopCamera.depth = component.depth + 1f;
			desktopCamera.stereoTargetEye = StereoTargetEyeMask.None;
			followScript.gameObjectToFollow = component.gameObject;
			followScript.gameObjectToChange = desktopCamera.gameObject;
			followScript.Follow();
			followScript.enabled = true;
			if (headsetImage == null)
			{
				return;
			}
			if (headsetRenderTexture == null)
			{
				headsetRenderTexture = new RenderTexture((int)headsetImage.rectTransform.rect.width, (int)headsetImage.rectTransform.rect.height, 24, RenderTextureFormat.ARGB32)
				{
					name = VRTK_SharedMethods.GenerateVRTKObjectName(true, "Headset RenderTexture")
				};
			}
			headsetCameraCopy = Object.Instantiate(component, base.transform);
			headsetCameraCopy.name = VRTK_SharedMethods.GenerateVRTKObjectName(true, "Headset Camera Copy");
			headsetCameraCopy.targetTexture = headsetRenderTexture;
			foreach (Transform item in headsetCameraCopy.transform)
			{
				Object.Destroy(item.gameObject);
			}
			foreach (Component item2 in from component2 in headsetCameraCopy.GetComponents<Component>()
				where component2 != headsetCameraCopy && !(component2 is Transform)
				select component2)
			{
				Object.Destroy(item2);
			}
			headsetCameraTransformFollow.gameObjectToFollow = component.gameObject;
			headsetCameraTransformFollow.gameObjectToChange = headsetCameraCopy.gameObject;
			headsetCameraTransformFollow.Follow();
			headsetCameraTransformFollow.enabled = true;
			headsetImage.texture = headsetRenderTexture;
			headsetImage.SetNativeSize();
		}
	}
}
