using System.Collections;
using System.ComponentModel;
using DV.InventorySystem;
using DV.Utils;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class HUDCursorButtonsLinker : MonoBehaviour
	{
		private GameParams gameParams;

		private Coroutine listenerCoro;

		private void Start()
		{
			gameParams = Globals.G.GameParams;
			if (VRManager.IsVREnabled())
			{
				Object.Destroy(this);
			}
			else
			{
				SetupListeners(on: true);
			}
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				PlayerManager.CarChanged += OnCarChanged;
				gameParams.PropertyChanged += OnGameParamChanged;
				listenerCoro = StartCoroutine(ListenerCoro());
				return;
			}
			PlayerManager.CarChanged -= OnCarChanged;
			if (listenerCoro != null)
			{
				StopCoroutine(listenerCoro);
				listenerCoro = null;
			}
			gameParams.PropertyChanged -= OnGameParamChanged;
			if ((bool)SingletonBehaviour<PlayerCameraSwitcher>.Instance)
			{
				PlayerCameraSwitcher instance = SingletonBehaviour<PlayerCameraSwitcher>.Instance;
				instance.externalCamera.PhotoModeChanged -= PhotomodeChanged;
				instance.externalCamera.FollowingCarChanged -= FollowingCarChanged;
				instance.RequestedViewChanged -= PCSViewChanged;
				instance.RequestedPauseChanged -= PCSPauseChanged;
			}
		}

		private IEnumerator ListenerCoro()
		{
			while (!SingletonBehaviour<PlayerCameraSwitcher>.Instance)
			{
				yield return null;
			}
			PlayerCameraSwitcher pcs = SingletonBehaviour<PlayerCameraSwitcher>.Instance;
			ExternalCamera cam = pcs.externalCamera;
			pcs.RequestedViewChanged += PCSViewChanged;
			pcs.RequestedPauseChanged += PCSPauseChanged;
			cam.PhotoModeChanged += PhotomodeChanged;
			cam.FollowingCarChanged += FollowingCarChanged;
			while (!SingletonBehaviour<HUDManager>.Instance)
			{
				yield return null;
			}
			while (!SingletonBehaviour<InventoryViewBase>.Instance)
			{
				yield return null;
			}
			SingletonBehaviour<HUDManager>.Instance.RegisterCallback(HUDManager.HUDButtonType.ToggleContextUI, delegate
			{
				cam.locoSelect = !cam.locoSelect;
				SingletonBehaviour<HUDManager>.Instance.SetVisualState(HUDManager.HUDButtonType.ToggleContextUI, cam.locoSelect);
			});
			SingletonBehaviour<HUDManager>.Instance.RegisterCallback(HUDManager.HUDButtonType.ToggleTimePaused, delegate
			{
				pcs.RequestPause(!pcs.requestedPause);
				SingletonBehaviour<HUDManager>.Instance.SetVisualState(HUDManager.HUDButtonType.ToggleTimePaused, !pcs.requestedPause);
			});
			SingletonBehaviour<HUDManager>.Instance.RegisterCallback(HUDManager.HUDButtonType.ToggleCameraLock, delegate
			{
				cam.lockCameraOnTrain = !cam.lockCameraOnTrain;
				SingletonBehaviour<HUDManager>.Instance.SetVisualState(HUDManager.HUDButtonType.ToggleCameraLock, cam.lockCameraOnTrain);
			});
			SingletonBehaviour<HUDManager>.Instance.RegisterCallback(HUDManager.HUDButtonType.EnterFreeCam, pcs.EnterFreeCam);
			SingletonBehaviour<HUDManager>.Instance.RegisterCallback(HUDManager.HUDButtonType.EnterOrbitCam, pcs.EnterOrbitCam);
			SingletonBehaviour<HUDManager>.Instance.RegisterCallback(HUDManager.HUDButtonType.EnterPlayerCam, pcs.EnterPlayerCam);
			SingletonBehaviour<HUDManager>.Instance.RegisterCallback(HUDManager.HUDButtonType.TogglePhotoMode, pcs.PhotoModeToggle);
			SingletonBehaviour<HUDManager>.Instance.RegisterCallback(HUDManager.HUDButtonType.InventoryOpen, delegate
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TryToggleState(CanvasController.ElementType.Inventory);
			});
			SingletonBehaviour<HUDManager>.Instance.RegisterCallback(HUDManager.HUDButtonType.SaveCabPosition, delegate
			{
				PlayerCabPositionManager.SavePosition();
				SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ResetCabPosition);
			});
			SingletonBehaviour<HUDManager>.Instance.RegisterCallback(HUDManager.HUDButtonType.ResetCabPosition, delegate
			{
				PlayerCabPositionManager.ClearPosition(PlayerManager.Car.carLivery.parentType, isVR: false);
				SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ResetCabPosition);
			});
			SingletonBehaviour<HUDManager>.Instance.RegisterCallback(HUDManager.HUDButtonType.SaveExtCamPose, delegate
			{
				ExternalCameraSavePositionManager.SavePosition();
				SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ResetExtCamPose);
			});
			SingletonBehaviour<HUDManager>.Instance.RegisterCallback(HUDManager.HUDButtonType.ResetExtCamPose, delegate
			{
				ExternalCameraSavePositionManager.ClearPosition();
				SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ResetExtCamPose);
			});
			SingletonBehaviour<HUDManager>.Instance.SetButtonConditions(HUDManager.HUDButtonType.ToggleContextUI, () => pcs.requestedView == PlayerCameraSwitcher.CameraView.External);
			SingletonBehaviour<HUDManager>.Instance.SetButtonConditions(HUDManager.HUDButtonType.ToggleTimePaused, () => cam.PhotoMode);
			SingletonBehaviour<HUDManager>.Instance.SetButtonConditions(HUDManager.HUDButtonType.ToggleCameraLock, () => cam.CurrentCar);
			SingletonBehaviour<HUDManager>.Instance.SetButtonConditions(HUDManager.HUDButtonType.EnterFreeCam, () => gameParams.FreeCamAllowed && (pcs.requestedView == PlayerCameraSwitcher.CameraView.FirstPerson || pcs.externalCamera.CurrentCar != null));
			SingletonBehaviour<HUDManager>.Instance.SetButtonConditions(HUDManager.HUDButtonType.EnterOrbitCam, () => gameParams.FreeCamAllowed && (bool)PlayerManager.Car && (pcs.requestedView == PlayerCameraSwitcher.CameraView.FirstPerson || !pcs.externalCamera.IsOrbitingPlayerCar));
			SingletonBehaviour<HUDManager>.Instance.SetButtonConditions(HUDManager.HUDButtonType.EnterPlayerCam, () => pcs.requestedView == PlayerCameraSwitcher.CameraView.External);
			SingletonBehaviour<HUDManager>.Instance.SetButtonConditions(HUDManager.HUDButtonType.TogglePhotoMode, () => gameParams.FreeCamAllowed);
			SingletonBehaviour<HUDManager>.Instance.SetButtonConditions(HUDManager.HUDButtonType.InventoryOpen, () => pcs.requestedView == PlayerCameraSwitcher.CameraView.FirstPerson);
			SingletonBehaviour<HUDManager>.Instance.SetButtonConditions(HUDManager.HUDButtonType.SaveCabPosition, () => pcs.requestedView == PlayerCameraSwitcher.CameraView.FirstPerson && (bool)PlayerManager.Car && (bool)PlayerManager.Car.cabTeleportDestination);
			SingletonBehaviour<HUDManager>.Instance.SetButtonConditions(HUDManager.HUDButtonType.SaveExtCamPose, () => pcs.requestedView == PlayerCameraSwitcher.CameraView.External && (bool)pcs.externalCamera.CurrentCar);
			SingletonBehaviour<HUDManager>.Instance.SetButtonConditions(HUDManager.HUDButtonType.ResetExtCamPose, () => pcs.requestedView == PlayerCameraSwitcher.CameraView.External && (bool)pcs.externalCamera.CurrentCar && ExternalCameraSavePositionManager.TryLoadPosition(out var _));
			SingletonBehaviour<HUDManager>.Instance.SetButtonConditions(HUDManager.HUDButtonType.ResetCabPosition, () => pcs.requestedView == PlayerCameraSwitcher.CameraView.FirstPerson && (bool)PlayerManager.Car && (bool)PlayerManager.Car.cabTeleportDestination && PlayerCabPositionManager.TryLoadPosition(PlayerManager.Car.carLivery.parentType, isVR: false, out var _));
			SingletonBehaviour<HUDManager>.Instance.SetButtonConditions(HUDManager.HUDButtonType.ToggleContextUI, () => !cam.PhotoMode);
			SingletonBehaviour<HUDManager>.Instance.SetVisualState(HUDManager.HUDButtonType.ToggleContextUI, cam.locoSelect);
			SingletonBehaviour<HUDManager>.Instance.SetVisualState(HUDManager.HUDButtonType.TogglePhotoMode, cam.PhotoMode);
			listenerCoro = null;
		}

		private void OnCarChanged(TrainCar car)
		{
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.EnterFreeCam);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.EnterOrbitCam);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.EnterPlayerCam);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.SaveCabPosition);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.SaveExtCamPose);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ResetExtCamPose);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ResetCabPosition);
		}

		private void PhotomodeChanged(bool _)
		{
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ToggleTimePaused);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ToggleContextUI);
			SingletonBehaviour<HUDManager>.Instance.SetVisualState(HUDManager.HUDButtonType.TogglePhotoMode, SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.PhotoMode);
		}

		private void FollowingCarChanged()
		{
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ToggleCameraLock);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.EnterFreeCam);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.EnterOrbitCam);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.SaveExtCamPose);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ResetExtCamPose);
		}

		private void PCSViewChanged()
		{
			SingletonBehaviour<HUDManager>.Instance.SetVisualState(HUDManager.HUDButtonType.ToggleTimePaused, on: false);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ToggleContextUI);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.InventoryOpen);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.EnterFreeCam);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.EnterOrbitCam);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.EnterPlayerCam);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.SaveCabPosition);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.SaveExtCamPose);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ResetExtCamPose);
			SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.ResetCabPosition);
		}

		private void PCSPauseChanged()
		{
			SingletonBehaviour<HUDManager>.Instance.SetVisualState(HUDManager.HUDButtonType.ToggleTimePaused, !SingletonBehaviour<PlayerCameraSwitcher>.Instance.requestedPause);
		}

		private void OnGameParamChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "FreeCamAllowed")
			{
				SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.EnterFreeCam);
				SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.EnterOrbitCam);
				SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.EnterPlayerCam);
				SingletonBehaviour<HUDManager>.Instance.RefreshButtonConditions(HUDManager.HUDButtonType.TogglePhotoMode);
			}
		}
	}
}
