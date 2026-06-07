using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI.LocoHUD
{
	public class PhotoModeWeatherController : MonoBehaviour
	{
		public enum WeatherSettingType
		{
			RainValue = 0,
			WetnessValue = 1,
			ThunderValue = 2,
			DayLengthInMinutes = 3,
			TimeOfDayHours = 4,
			WindDirection = 5,
			WeatherPointX = 6,
			WeatherPointY = 7,
			WindSpeed = 8
		}

		public WeatherSlider[] sliders;

		public HUDPanel panel;

		public Button vrButton;

		public RectTransform vrParent;

		private Dictionary<WeatherSettingType, WeatherSlider> sliderDictionary = new Dictionary<WeatherSettingType, WeatherSlider>();

		private DateTime? originalDateTime;

		private bool isOn;

		private bool panelOpen;

		public APhotoModeWeatherProvider Provider { get; private set; }

		private void Awake()
		{
			WeatherSlider[] array = sliders;
			foreach (WeatherSlider weatherSlider in array)
			{
				weatherSlider.clearButton.ToggleInteractable(newInteractable: false);
				weatherSlider.clearButton.PressChanged += delegate
				{
					ResetDefaultSettings(weatherSlider);
				};
				weatherSlider.slider.onValueChanged.AddListener(delegate
				{
					SliderChanged(weatherSlider);
				});
				weatherSlider.clearButton.Clicked += delegate
				{
					ResetDefaultSettings(weatherSlider);
				};
				sliderDictionary[weatherSlider.type] = weatherSlider;
			}
			panel.openCloseButton.Clicked += delegate
			{
				PressPanelButton();
			};
		}

		public void PressPanelButton()
		{
			panelOpen = !panelOpen;
			panel.SetOpen(panelOpen && isOn);
		}

		public void SetProvider(APhotoModeWeatherProvider provider)
		{
			Provider = provider;
			isOn = true;
			ToggleOn(on: false);
			UpdateSliderMinMax();
			UpdateWeatherValues();
			if ((bool)vrButton)
			{
				if (provider.IsVREnabled())
				{
					vrButton.onClick.AddListener(provider.VRWeatherButtonPressed);
					base.transform.SetParent(vrParent, worldPositionStays: false);
				}
				else
				{
					vrButton.gameObject.SetActive(value: false);
				}
			}
		}

		public void NotifyOverrideChanged(WeatherSettingType type, bool on)
		{
			if (sliderDictionary.TryGetValue(type, out var value))
			{
				value.isOverrideOn = on;
				value.clearButton.ToggleInteractable(isOn && value.isOverrideOn);
				value.slider.ToggleInteractable(isOn && Provider.IsSliderInteractable(type));
			}
		}

		public void ToggleInteractable(bool on)
		{
			panel.openCloseButton.ToggleInteractable(on);
			panel.SetVisible(isOn && on);
			panel.SetOpen(panelOpen && isOn && on);
		}

		public void ToggleOn(bool on)
		{
			if (isOn == on)
			{
				return;
			}
			isOn = on;
			if (Provider.IsVREnabled())
			{
				vrButton.gameObject.SetActive(on);
			}
			WeatherSlider[] array;
			if (isOn)
			{
				originalDateTime = Provider.GetTime();
				UpdateWeatherValues();
			}
			else
			{
				if (originalDateTime.HasValue)
				{
					Provider.SetTime(originalDateTime.Value);
				}
				array = sliders;
				foreach (WeatherSlider weatherSlider in array)
				{
					if (weatherSlider.isOverrideOn)
					{
						Provider.ClearWeatherOverride(weatherSlider.type);
					}
				}
			}
			array = sliders;
			foreach (WeatherSlider weatherSlider2 in array)
			{
				weatherSlider2.clearButton.ToggleInteractable(isOn && weatherSlider2.isOverrideOn);
				weatherSlider2.slider.ToggleInteractable(isOn && Provider.IsSliderInteractable(weatherSlider2.type));
			}
		}

		private void OnEnable()
		{
			if (Provider != null)
			{
				UpdateWeatherValues();
				WeatherSlider[] array = sliders;
				foreach (WeatherSlider weatherSlider in array)
				{
					weatherSlider.clearButton.ToggleInteractable(isOn && weatherSlider.isOverrideOn);
					weatherSlider.slider.ToggleInteractable(isOn && Provider.IsSliderInteractable(weatherSlider.type));
				}
			}
		}

		private void UpdateSliderMinMax()
		{
			Dictionary<WeatherSettingType, Vector2> minMaxDict = Provider.GetMinMaxDict();
			WeatherSlider[] array = sliders;
			foreach (WeatherSlider weatherSlider in array)
			{
				if (minMaxDict.TryGetValue(weatherSlider.type, out var value))
				{
					weatherSlider.minMax = value;
				}
			}
		}

		public void UpdateWeatherValues()
		{
			if ((bool)Provider)
			{
				WeatherSlider[] array = sliders;
				foreach (WeatherSlider weatherSlider in array)
				{
					bool newInteractable = (weatherSlider.isOverrideOn = Provider.IsWeatherOverridden(weatherSlider.type));
					weatherSlider.clearButton.ToggleInteractable(newInteractable);
					weatherSlider.Value = Provider.GetWeatherValue(weatherSlider.type);
				}
				UpdateInteractable();
			}
		}

		public void UpdateInteractable()
		{
			WeatherSlider[] array = sliders;
			foreach (WeatherSlider weatherSlider in array)
			{
				bool flag = Provider.IsSliderInteractable(weatherSlider.type);
				if (!flag && weatherSlider.isOverrideOn)
				{
					ResetDefaultSettings(weatherSlider);
				}
				weatherSlider.slider.ToggleInteractable(flag);
			}
		}

		private void SliderChanged(WeatherSlider weatherSlider)
		{
			if ((bool)Provider && isOn)
			{
				weatherSlider.isOverrideOn = true;
				weatherSlider.clearButton.ToggleInteractable(weatherSlider.isOverrideOn);
				if (weatherSlider.type == WeatherSettingType.WeatherPointX || weatherSlider.type == WeatherSettingType.WeatherPointY)
				{
					FixWeatherValueInPlace(WeatherSettingType.RainValue);
					FixWeatherValueInPlace(WeatherSettingType.ThunderValue);
					FixWeatherValueInPlace(WeatherSettingType.WetnessValue);
				}
				Provider.SetWeatherOverride(weatherSlider.type, weatherSlider.Value);
				StartCoroutine(DelayedRefresh());
			}
		}

		private void ResetDefaultSettings(WeatherSlider weatherSlider)
		{
			if ((bool)Provider && isOn)
			{
				weatherSlider.isOverrideOn = false;
				weatherSlider.clearButton.ToggleInteractable(weatherSlider.isOverrideOn);
				Provider.ClearWeatherOverride(weatherSlider.type);
				StartCoroutine(DelayedRefresh());
			}
		}

		private void FixWeatherValueInPlace(WeatherSettingType type)
		{
			if (sliderDictionary.TryGetValue(type, out var value))
			{
				float value2 = value.slider.value;
				value.slider.SetValueWithoutNotify(value.minMax.y - value.Value);
				value.slider.value = value2;
			}
		}

		private IEnumerator DelayedRefresh()
		{
			yield return null;
			UpdateWeatherValues();
		}
	}
}
