using System.Collections.Generic;
using DV.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.WeatherSystem
{
	public class WeatherForecastPoster : MonoBehaviour
	{
		public WeatherForecaster forecaster;

		public WeatherForecastIconMapping iconMapping;

		public GameObject forecastItemPrefab;

		public TMP_Text dateTMPro;

		public GameObject itemsContainer;

		public GameObject dataNotAvailable;

		private HorizontalOrVerticalLayoutGroup itemsLayout;

		private bool initialized;

		private void Start()
		{
			itemsLayout = itemsContainer.GetComponent<HorizontalOrVerticalLayoutGroup>();
			if (forecaster == null)
			{
				SetDataProvider(SingletonBehaviour<WeatherForecaster>.Instance);
			}
			else
			{
				OnForecastUpdated();
			}
			initialized = true;
		}

		private void OnEnable()
		{
			if (initialized)
			{
				SetDataProvider(SingletonBehaviour<WeatherForecaster>.Instance);
			}
		}

		private void OnDisable()
		{
			if (initialized)
			{
				SetDataProvider(null);
			}
		}

		private void OnForecastUpdated()
		{
			if (forecaster == null || !forecaster.HasValidForecastForToday())
			{
				itemsContainer.SetActive(value: false);
				dateTMPro.gameObject.SetActive(value: false);
				dataNotAvailable.SetActive(value: true);
				return;
			}
			List<WeatherForecastItem> interpretedData = forecaster.interpretedData;
			if (interpretedData.Count == 0)
			{
				Debug.LogWarning("Weather forecast data contains no items, this should've been prevented by previous check.");
				itemsContainer.SetActive(value: false);
				dateTMPro.gameObject.SetActive(value: false);
				dataNotAvailable.SetActive(value: true);
				return;
			}
			itemsLayout.enabled = true;
			itemsContainer.SetActive(value: true);
			dateTMPro.gameObject.SetActive(value: true);
			dataNotAvailable.SetActive(value: false);
			if (interpretedData.Count < 8)
			{
				Debug.LogWarning($"Weather forecast data contains {interpretedData.Count} items but {8} will be displayed.");
			}
			else if (interpretedData.Count > 8)
			{
				Debug.LogWarning($"Weather forecast data contains {interpretedData.Count} items but only {8} will be displayed.");
				interpretedData.RemoveRange(8, interpretedData.Count - 8);
			}
			for (int num = itemsContainer.transform.childCount - 1; num >= 0; num--)
			{
				Transform child = itemsContainer.transform.GetChild(num);
				child.SetParent(null);
				Object.Destroy(child.gameObject);
			}
			dateTMPro.text = forecaster.lastForecastTimestamp.Value.ToString("MM/dd");
			foreach (WeatherForecastItem item in interpretedData)
			{
				GameObject obj = Object.Instantiate(forecastItemPrefab, itemsContainer.transform);
				TMP_Text componentInChildren = obj.GetComponentInChildren<TMP_Text>();
				Image componentInChildren2 = obj.GetComponentInChildren<Image>();
				componentInChildren.text = $"{item.hourStart}:00";
				componentInChildren2.sprite = iconMapping.GetIconFor(item.iconType);
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(itemsContainer.transform as RectTransform);
			itemsLayout.enabled = false;
		}

		public void SetDataProvider(WeatherForecaster provider)
		{
			if (forecaster != null)
			{
				forecaster.ForecastUpdated -= OnForecastUpdated;
				forecaster = null;
			}
			forecaster = provider;
			OnForecastUpdated();
			if (forecaster != null)
			{
				forecaster.ForecastUpdated += OnForecastUpdated;
			}
		}
	}
}
