using UnityEngine;

namespace Brewery.Stand
{
	public class StandLampController : MonoBehaviour
	{
		[Header("Time Settings")]
		[Tooltip("Hour to turn lights on (24h format, e.g. 20 = 8 PM)")]
		[SerializeField]
		private int turnOnHour;

		[Tooltip("Hour to turn lights off (24h format, e.g. 6 = 6 AM)")]
		[SerializeField]
		private int turnOffHour;

		[Header("Fade Settings")]
		[Tooltip("Duration of the smooth fade in seconds")]
		[SerializeField]
		private float fadeDuration;

		private Light[] _lights;

		private float[] _originalIntensities;

		private bool _isOn;

		private bool _isFading;

		private bool _intensitiesCaptured;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		private bool ShouldBeOn()
		{
			return false;
		}

		private void FadeIn()
		{
		}

		private void FadeOut()
		{
		}

		private void SetAllIntensities(float intensity)
		{
		}
	}
}
