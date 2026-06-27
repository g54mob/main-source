using UnityEngine;

namespace Restory.TimeSystems
{
	public class TimeScalingService : MonoBehaviour
	{
		private const float DEFAULT_TIME_SCALE = 1f;

		public void ResetTimeScaleToDefault()
		{
			Time.timeScale = 1f;
		}

		public void SetTimeScale(float to)
		{
			Time.timeScale = to;
		}

		public float CurrentTimeScale()
		{
			return Time.timeScale;
		}
	}
}
