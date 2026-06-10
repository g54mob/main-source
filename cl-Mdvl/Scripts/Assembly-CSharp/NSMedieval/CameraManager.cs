using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.EnvironmentEffects;
using NSMedieval.StructurePresets;
using NSMedieval.UI;
using NSMedieval.UI.PhotoMode;
using NSMedieval.WorldMap;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace NSMedieval
{
	public class CameraManager : MonoSingleton<CameraManager>
	{
		[SerializeField]
		public Camera GameplayCamera;

		[SerializeField]
		public Camera PhotoModeCamera;

		[SerializeField]
		private RenderTexture backgroundRenderTexture;

		[SerializeField]
		private GameObject backgroundPlane;

		[SerializeField]
		[Tooltip("For overriding grass camera, for trailer and promo stuff.")]
		private Camera grassDebugCamera;

		private bool showingLowRes;

		private int oldLayerMask;

		private CameraType selectedCameraType;

		private Dictionary<CameraType, Camera> cameras;

		public bool StopNonCameraEventPropagation { get; private set; }

		public CameraType SelectedCameraType => selectedCameraType;

		public bool ShowingLowRes => showingLowRes;

		public Camera CurrentCamera
		{
			get
			{
				if (SelectedCameraType == CameraType.Gameplay)
				{
					return GameplayCamera;
				}
				if (SelectedCameraType == CameraType.PhotoMode)
				{
					return PhotoModeCamera;
				}
				return null;
			}
		}

		public event Action<CameraType> CameraTypeChangedAction;

		public event Action<Vector3, CameraShakeStrength> CameraShakeEvent;

		public void OnCameraShakeEvent(Vector3 eventPosition, CameraShakeStrength shakeStrength)
		{
			this.CameraShakeEvent?.Invoke(eventPosition, shakeStrength);
		}

		public void SetBackground(bool showLowRes)
		{
			if (showingLowRes != showLowRes)
			{
				showingLowRes = showLowRes;
				if (oldLayerMask == 0)
				{
					oldLayerMask = GameplayCamera.cullingMask;
				}
				Camera camera = ((MonoSingleton<NSMedieval.WorldMap.WorldMap>.IsInstantiated() && MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible) ? MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.MainSceneWorldCamera : GameplayCamera);
				if (showLowRes)
				{
					backgroundPlane.SetActive(value: false);
					float aspect = camera.aspect;
					camera.targetTexture = backgroundRenderTexture;
					camera.aspect = aspect;
					camera.Render();
					camera.targetTexture = null;
					backgroundPlane.SetActive(value: true);
					camera.ResetAspect();
					camera.cullingMask = 1 << LayerMask.NameToLayer("UI");
				}
				else
				{
					camera.GetComponent<PostProcessLayer>().ResetHistory();
					camera.targetTexture = null;
					camera.ResetAspect();
					camera.cullingMask = oldLayerMask;
					backgroundPlane.SetActive(value: false);
				}
			}
		}

		private void ChangeCameraType(CameraType cameraType)
		{
			if (selectedCameraType == cameraType || !MonoSingleton<RtsCamera>.IsInstantiated() || GameplayCamera == null || cameras == null)
			{
				return;
			}
			selectedCameraType = cameraType;
			foreach (KeyValuePair<CameraType, Camera> camera in cameras)
			{
				if (camera.Key != CameraType.WorldMapMode)
				{
					camera.Value.gameObject.SetActive(camera.Key == selectedCameraType);
				}
			}
			StopNonCameraEventPropagation = selectedCameraType != CameraType.Gameplay;
			this.CameraTypeChangedAction?.Invoke(selectedCameraType);
		}

		private void OnWorldMapVisibilitySet(bool worldMapVisible)
		{
			ChangeCameraType((!worldMapVisible) ? CameraType.Gameplay : CameraType.WorldMapMode);
		}

		private void OnPhotoModeVisibilitySet(bool isVisible)
		{
			ChangeCameraType((!isVisible) ? CameraType.Gameplay : CameraType.PhotoMode);
		}

		private void OnStructurePresetVisibilitySet(bool isVisible)
		{
			ChangeCameraType((!isVisible) ? CameraType.Gameplay : CameraType.StructurePresetMode);
		}

		private void OnHideUIToggle(bool hideUi)
		{
			ChangeCameraType((!hideUi) ? CameraType.Gameplay : CameraType.PhotoMode);
		}

		private void Start()
		{
			grassDebugCamera = null;
			cameras = new Dictionary<CameraType, Camera>
			{
				{
					CameraType.Gameplay,
					GameplayCamera
				},
				{
					CameraType.PhotoMode,
					PhotoModeCamera
				},
				{
					CameraType.WorldMapMode,
					null
				}
			};
			ChangeCameraType(CameraType.Gameplay);
		}

		private void OnEnable()
		{
			MonoSingleton<PhotoModeController>.Instance.PhotoModeVisibleEvent += OnPhotoModeVisibilitySet;
			MonoSingleton<UIController>.Instance.HideUIToggleEvent += OnHideUIToggle;
			MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySetEvent += OnWorldMapVisibilitySet;
			MonoSingleton<StructurePresetModeController>.Instance.StructurePresetModeVisibleEvent += OnStructurePresetVisibilitySet;
			backgroundPlane.SetActive(value: false);
		}

		private void OnDisable()
		{
			if (MonoSingleton<PhotoModeController>.IsInstantiated())
			{
				MonoSingleton<PhotoModeController>.Instance.PhotoModeVisibleEvent -= OnPhotoModeVisibilitySet;
			}
			if (MonoSingleton<StructurePresetModeController>.IsInstantiated())
			{
				MonoSingleton<StructurePresetModeController>.Instance.StructurePresetModeVisibleEvent -= OnStructurePresetVisibilitySet;
			}
			if (MonoSingleton<WorldMapController>.IsInstantiated())
			{
				MonoSingleton<WorldMapController>.Instance.WorldMapVisibilitySetEvent -= OnWorldMapVisibilitySet;
			}
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.HideUIToggleEvent -= OnHideUIToggle;
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.CameraTypeChangedAction = null;
		}
	}
}
