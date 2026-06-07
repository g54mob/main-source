using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public abstract class APhotoModeWeatherProvider : MonoBehaviour
	{
		public abstract DateTime GetTime();

		public abstract void SetTime(DateTime time);

		public abstract float GetWeatherValue(PhotoModeWeatherController.WeatherSettingType type);

		public abstract void SetWeatherOverride(PhotoModeWeatherController.WeatherSettingType type, float value, bool updateUI = false);

		public abstract void ClearWeatherOverride(PhotoModeWeatherController.WeatherSettingType type);

		public abstract bool IsWeatherOverridden(PhotoModeWeatherController.WeatherSettingType type);

		public abstract bool IsSliderInteractable(PhotoModeWeatherController.WeatherSettingType type);

		public abstract Dictionary<PhotoModeWeatherController.WeatherSettingType, Vector2> GetMinMaxDict();

		public abstract bool IsVREnabled();

		public abstract void VRWeatherButtonPressed();
	}
}
