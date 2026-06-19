using UnityEngine;

namespace Gauges
{
	public class TimerGauge : MonoBehaviour
	{
		[SerializeField]
		private GameObject _screenOn;

		[SerializeField]
		private GameObject _screenOff;

		private void OnEnable()
		{
			if (_screenOn != null)
			{
				_screenOn.SetActive(value: true);
			}
			if (_screenOff != null)
			{
				_screenOff.SetActive(value: false);
			}
		}

		private void OnDisable()
		{
			if (_screenOn != null)
			{
				_screenOn.SetActive(value: false);
			}
			if (_screenOff != null)
			{
				_screenOff.SetActive(value: true);
			}
		}
	}
}
