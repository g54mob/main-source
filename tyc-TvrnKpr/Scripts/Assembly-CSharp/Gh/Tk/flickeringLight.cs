using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(Light))]
	public class flickeringLight : MonoBehaviour
	{
		public float intensityAdjust;

		public float rangeAdjust;

		private float minCycleDuration;

		private float maxCycleDuration;

		private float timeMultiplierMin;

		private float timeMultiplierMax;

		public float MaxIntensity;

		public float startIntensity;

		public float startRange;

		private float t;

		private Light _light;

		private float multiplier;

		private float randomSeed;

		private Tween _lightTween;

		public bool overrideColor;

		public Gradient overrideGradient;

		[Range(0.1f, 20f)]
		public float overrideColorDuration;

		public float offsetStartTime;

		private float _overrideColorTime;

		private void Start()
		{
		}

		public void SetLightOn()
		{
		}

		public void SetLightOff()
		{
		}

		public void TweenUpLight()
		{
		}

		public void TweenDownLight()
		{
		}

		private void Update()
		{
		}
	}
}
