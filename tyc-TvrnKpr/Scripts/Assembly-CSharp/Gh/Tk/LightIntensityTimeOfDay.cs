using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(Light))]
	public class LightIntensityTimeOfDay : MonoBehaviour
	{
		public AnimationCurve dayTimeCurve;

		public float maxIntensity;

		private Light _light;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
