using UnityEngine;

namespace DistantLands.Cozy
{
	public class CozySystem : MonoBehaviour
	{
		[Range(0f, 1f)]
		public float weight = 1f;

		[Range(0f, 1f)]
		public float targetWeight = 1f;

		public int priority;

		public void OnEnable()
		{
			if ((bool)CozyWeather.instance)
			{
				CozyWeather.instance.SetupSystems();
			}
		}

		public void SkipTime(MeridiemTime time)
		{
		}
	}
}
