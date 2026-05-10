using System;
using TMPro;
using UnityEngine;

namespace ScheduleOne.UI
{
	public class TemperatureDisplay : MonoBehaviour
	{
		public const float MaxCameraDistance = 8f;

		public const float MinCameraDistance = 0.5f;

		public const float FadeInDistance = 2f;

		public const float FadeOutDistance = 0.25f;

		public bool UseColor;

		[SerializeField]
		private Gradient _temperatureColorGradient;

		[SerializeField]
		private TextMeshPro _label;

		private Func<float> _getCelsiusTemperature;

		private Func<bool> _getIsVisible;

		private void Awake()
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateCanvas()
		{
		}

		public void SetTemperatureGetter(Func<float> getCelsiusTemperature)
		{
		}

		public void SetVisibilityGetter(Func<bool> getIsVisible)
		{
		}

		public void SetEnabled(bool enabled)
		{
		}
	}
}
