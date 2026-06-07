using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DV.Utils;
using DV.VRTK_Extensions;
using DV.WeatherSystem;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class PhotoModeWeatherSettingsProvider : APhotoModeWeatherProvider
	{
		public PhotoModeWeatherController controller;

		private bool isVR;

		private bool vrPanelAllowed;

		private GameParams gameParams;

		private IEnumerator Start()
		{
			isVR = VRManager.IsVREnabled();
			gameParams = Globals.G.GameParams;
			controller.SetProvider(this);
			if (isVR)
			{
				controller.panel.openCloseButton.onClick.AddListener(delegate
				{
					if (vrPanelAllowed)
					{
						SetVRPanelAllowed(allowed: false);
					}
				});
			}
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.TopHUDMount, on: true);
			while (!SingletonBehaviour<WeatherDriver>.Instance)
			{
				yield return null;
			}
			SingletonBehaviour<WeatherDriver>.Instance.manager.MinuteChanged += delegate
			{
				controller.UpdateWeatherValues();
			};
			SingletonBehaviour<AppUtil>.Instance.GamePaused += OnPauseToggle;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused += OnPauseToggle;
			if ((bool)SingletonBehaviour<PlayerCameraSwitcher>.Instance)
			{
				SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.PhotoModeChanged += OnPhotoModeChanged;
			}
			gameParams.PropertyChanged += OnGameParamChanged;
			SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged += ScreenspaceChanged;
			RefreshControllerState();
			OverridableEnumPreset<WeatherDriver, PhotoModeWeatherController.WeatherSettingType>.Validate(allowIncompleteEnum: true);
		}

		private void OnPauseToggle()
		{
			RefreshControllerState();
		}

		private void OnDestroy()
		{
			gameParams.PropertyChanged -= OnGameParamChanged;
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged -= ScreenspaceChanged;
				SingletonBehaviour<AppUtil>.Instance.GamePaused -= OnPauseToggle;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= OnPauseToggle;
				if ((bool)SingletonBehaviour<PlayerCameraSwitcher>.Instance)
				{
					SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.PhotoModeChanged -= OnPhotoModeChanged;
				}
			}
		}

		private void OnGameParamChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
			case "WeatherEditorAlwaysAllowed":
			case "WeatherEditorInPausedPhotoModeAllowed":
			case "WeatherEditorInPhotoModeAllowed":
				RefreshControllerState();
				break;
			case "TimeOfDayEditingAllowed":
				if (!gameParams.TimeOfDayEditingAllowed)
				{
					ClearWeatherOverride(PhotoModeWeatherController.WeatherSettingType.TimeOfDayHours);
					ClearWeatherOverride(PhotoModeWeatherController.WeatherSettingType.DayLengthInMinutes);
				}
				controller.UpdateInteractable();
				break;
			}
		}

		private void OnPhotoModeChanged(bool _)
		{
			RefreshControllerState();
		}

		private void ScreenspaceChanged(bool _)
		{
			RefreshControllerState();
		}

		private void RefreshControllerState()
		{
			controller.ToggleOn(IsWeatherEditorActive());
			controller.ToggleInteractable(IsWeatherEditorInteractable());
		}

		private bool IsWeatherEditorActive()
		{
			if (!gameParams.WeatherEditorAlwaysAllowed && (!gameParams.WeatherEditorInPausedPhotoModeAllowed || !SingletonBehaviour<PlayerCameraSwitcher>.Instance || !SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.PhotoMode || !SingletonBehaviour<AppUtil>.Instance.IsTimePaused))
			{
				if (gameParams.WeatherEditorInPhotoModeAllowed && (bool)SingletonBehaviour<PlayerCameraSwitcher>.Instance)
				{
					return SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.PhotoMode;
				}
				return false;
			}
			return true;
		}

		private bool IsWeatherEditorInteractable()
		{
			if (IsWeatherEditorActive())
			{
				if (!isVR)
				{
					return SingletonBehaviour<ScreenspaceMouse>.Instance.on;
				}
				return vrPanelAllowed;
			}
			return false;
		}

		public override bool IsVREnabled()
		{
			return isVR;
		}

		public override void VRWeatherButtonPressed()
		{
			SetVRPanelAllowed(!controller.panel.open);
		}

		private void SetVRPanelAllowed(bool allowed)
		{
			vrPanelAllowed = allowed;
			RefreshControllerState();
			SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.RequestPointerState(this, vrPanelAllowed, onlyWhenHit: true);
			if (!controller.panel.open)
			{
				controller.PressPanelButton();
			}
		}

		public override DateTime GetTime()
		{
			if ((bool)SingletonBehaviour<WeatherDriver>.Instance)
			{
				return SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime;
			}
			return DateTime.Now;
		}

		public override void SetTime(DateTime time)
		{
			if ((bool)SingletonBehaviour<WeatherDriver>.Instance)
			{
				SingletonBehaviour<WeatherDriver>.Instance.manager.todSky.Cycle.DateTime = time;
			}
		}

		public override bool IsSliderInteractable(PhotoModeWeatherController.WeatherSettingType type)
		{
			if ((uint)(type - 3) <= 1u)
			{
				return gameParams.TimeOfDayEditingAllowed;
			}
			return true;
		}

		public override float GetWeatherValue(PhotoModeWeatherController.WeatherSettingType type)
		{
			if (!SingletonBehaviour<WeatherDriver>.Instance)
			{
				return 0f;
			}
			return OverridableEnumPreset<WeatherDriver, PhotoModeWeatherController.WeatherSettingType>.GetCurrentValueFrom<float>(SingletonBehaviour<WeatherDriver>.Instance, type);
		}

		public override bool IsWeatherOverridden(PhotoModeWeatherController.WeatherSettingType type)
		{
			if (!SingletonBehaviour<WeatherDriver>.Instance)
			{
				return false;
			}
			return OverridableEnumPreset<WeatherDriver, PhotoModeWeatherController.WeatherSettingType>.IsOverriddenIn(SingletonBehaviour<WeatherDriver>.Instance, type);
		}

		public override void SetWeatherOverride(PhotoModeWeatherController.WeatherSettingType type, float value, bool updateUI = false)
		{
			if ((bool)SingletonBehaviour<WeatherDriver>.Instance)
			{
				OverridableEnumPreset<WeatherDriver, PhotoModeWeatherController.WeatherSettingType>.EngageOverrideOn(SingletonBehaviour<WeatherDriver>.Instance, type, value);
				UpdateTODIfNeeded(type);
				if (updateUI)
				{
					controller.NotifyOverrideChanged(type, on: true);
				}
			}
		}

		public override void ClearWeatherOverride(PhotoModeWeatherController.WeatherSettingType type)
		{
			if ((bool)SingletonBehaviour<WeatherDriver>.Instance)
			{
				OverridableEnumPreset<WeatherDriver, PhotoModeWeatherController.WeatherSettingType>.ClearOverrideOn(SingletonBehaviour<WeatherDriver>.Instance, type);
				UpdateTODIfNeeded(type);
			}
		}

		private void UpdateTODIfNeeded(PhotoModeWeatherController.WeatherSettingType type)
		{
			if (type == PhotoModeWeatherController.WeatherSettingType.TimeOfDayHours || (uint)(type - 6) <= 1u)
			{
				SingletonBehaviour<WeatherDriver>.Instance.manager.RefreshTimeOfDay();
			}
		}

		public override Dictionary<PhotoModeWeatherController.WeatherSettingType, Vector2> GetMinMaxDict()
		{
			return new Dictionary<PhotoModeWeatherController.WeatherSettingType, Vector2>
			{
				{
					PhotoModeWeatherController.WeatherSettingType.WindSpeed,
					new Vector2(0f, 10f)
				},
				{
					PhotoModeWeatherController.WeatherSettingType.RainValue,
					new Vector2(0f, 1f)
				},
				{
					PhotoModeWeatherController.WeatherSettingType.ThunderValue,
					new Vector2(0f, 1f)
				},
				{
					PhotoModeWeatherController.WeatherSettingType.WetnessValue,
					new Vector2(0f, 1f)
				},
				{
					PhotoModeWeatherController.WeatherSettingType.DayLengthInMinutes,
					new Vector2(120f, 0.1f)
				},
				{
					PhotoModeWeatherController.WeatherSettingType.WeatherPointX,
					new Vector2(0f, 1f)
				},
				{
					PhotoModeWeatherController.WeatherSettingType.WeatherPointY,
					new Vector2(0f, 1f)
				},
				{
					PhotoModeWeatherController.WeatherSettingType.TimeOfDayHours,
					new Vector2(0f, 24f)
				},
				{
					PhotoModeWeatherController.WeatherSettingType.WindDirection,
					new Vector2(0f, 360f)
				}
			};
		}
	}
}
