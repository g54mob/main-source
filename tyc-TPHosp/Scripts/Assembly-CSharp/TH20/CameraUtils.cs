using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	public static class CameraUtils
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct CustomPostProcessComparar : IComparer<PostProcessLayer.SerializedBundleRef>
		{
			private int Ordering(PostProcessEffectSettings settings)
			{
				if (settings is SoftCloudShadowsSettings)
				{
					return 0;
				}
				if (settings is HighlightSettings)
				{
					return 1;
				}
				if (settings is HeightFogSettings)
				{
					return 2;
				}
				if (settings is ScreenBlurSettings)
				{
					return 3;
				}
				_ = settings is FogOfWarSettings;
				return 4;
			}

			public int Compare(PostProcessLayer.SerializedBundleRef x, PostProcessLayer.SerializedBundleRef y)
			{
				return Ordering(x.bundle.settings).CompareTo(Ordering(y.bundle.settings));
			}
		}

		public static byte[] TakeScreenShotAsBytes(Camera camera, int width = 0, int height = 0)
		{
			width = ((width <= 0) ? (Screen.width / 8) : width);
			height = ((height <= 0) ? (Screen.height / 8) : height);
			RenderTexture renderTexture = (camera.targetTexture = new RenderTexture(width, height, 24));
			Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGB24, mipChain: false);
			camera.Render();
			RenderTexture.active = renderTexture;
			texture2D.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
			camera.targetTexture = null;
			RenderTexture.active = null;
			Object.Destroy(renderTexture);
			return texture2D.EncodeToPNG();
		}

		public static Camera AddCameraComponent(GameObject gameObject, TopDownCameraLogic.Config config)
		{
			Camera camera = gameObject.AddComponent<Camera>();
			camera.fieldOfView = config.FOV;
			camera.allowHDR = true;
			camera.allowMSAA = false;
			camera.cullingMask = config.CullingMask;
			camera.nearClipPlane = config.NearPlace;
			camera.farClipPlane = config.FarPlace;
			return camera;
		}

		public static PostProcessVolume AddPostProcessLayer(GameObject gameObject, TopDownCameraLogic.Config config)
		{
			if (config.PostProcessingProfile != null)
			{
				PostProcessLayer orAddComponent = gameObject.GetOrAddComponent<PostProcessLayer>();
				orAddComponent.volumeTrigger = gameObject.transform;
				orAddComponent.volumeLayer = config.PostProcessLayerMask;
				orAddComponent.Init(config.PostProcessingResources);
				orAddComponent.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
				orAddComponent.temporalAntialiasing.jitterSpread = 0.424f;
				orAddComponent.temporalAntialiasing.stationaryBlending = 0.794f;
				orAddComponent.temporalAntialiasing.motionBlending = 0.7f;
				orAddComponent.temporalAntialiasing.sharpness = 0.05f;
				if (orAddComponent.sortedBundles != null && orAddComponent.sortedBundles.TryGetValue(PostProcessEvent.AfterStack, out var value))
				{
					value.Sort(default(CustomPostProcessComparar));
				}
				GameObject gameObject2 = new GameObject("GlobalPostProcessVolume");
				gameObject2.transform.SetParent(gameObject.transform);
				gameObject2.layer = LayerMask.NameToLayer(config.PostProcessVolumeLayer);
				PostProcessVolume postProcessVolume = gameObject2.AddComponent<PostProcessVolume>();
				postProcessVolume.isGlobal = true;
				postProcessVolume.sharedProfile = config.PostProcessingProfile;
				PostProcessDebug postProcessDebug = gameObject.AddComponent<PostProcessDebug>();
				postProcessDebug.enabled = false;
				postProcessDebug.postProcessLayer = orAddComponent;
				return postProcessVolume;
			}
			return null;
		}

		public static CinemachineBrain AddCinemachineBrain(GameObject gameObject, TopDownCameraLogic.Config config)
		{
			CinemachineBrain cinemachineBrain = gameObject.AddComponent<CinemachineBrain>();
			cinemachineBrain.m_IgnoreTimeScale = true;
			cinemachineBrain.m_CustomBlends = config.CinemachineBlenderSettings;
			return cinemachineBrain;
		}

		public static Vector3 ClampToBounds(Vector3 focalPoint, Bounds bounds)
		{
			return new Vector3(Mathf.Clamp(focalPoint.x, bounds.min.x, bounds.max.x), Mathf.Clamp(focalPoint.y, bounds.min.y, bounds.max.y), Mathf.Clamp(focalPoint.z, bounds.min.z, bounds.max.z));
		}

		public static bool GetCameraFocalPoint(Transform transform, out Vector3 focalPoint)
		{
			Ray ray = new Ray(transform.position, transform.forward);
			if (!new Plane(Vector3.up, Vector3.zero).Raycast(ray, out var enter))
			{
				focalPoint = Vector3.one;
				return false;
			}
			focalPoint = ray.GetPoint(enter);
			return true;
		}

		public static Vector3 GetOrbitPosition(Vector3 center, float radius, float pitch, float yaw)
		{
			return -Vector3.Normalize(Quaternion.Euler(pitch, yaw, 0f) * Vector3.forward) * radius + center;
		}

		public static CameraHeightFadeComponent AddCameraHeightFadeComponent(GameObject gameObject, Level level, Transform cameraTransform, TopDownCameraLogic.Config config)
		{
			if (level == null)
			{
				return null;
			}
			CameraHeightFadeComponent cameraHeightFadeComponent = gameObject.AddComponent<CameraHeightFadeComponent>();
			cameraHeightFadeComponent.Initialise(level, cameraTransform, config.CharacterFadeSpeed);
			return cameraHeightFadeComponent;
		}

		public static bool GetLimitVisibleAspectRatioRect(int screenWidth, int screenHeight, float maxVisibleAspectRatio, out Rect rect)
		{
			float num = (float)screenHeight * maxVisibleAspectRatio;
			if ((float)screenWidth > num)
			{
				float num2 = ((float)screenWidth - num) / (float)screenWidth;
				rect = new Rect(0.5f * num2, 0f, 1f - num2, 1f);
				return true;
			}
			rect = new Rect(0f, 0f, 1f, 1f);
			return false;
		}
	}
}
