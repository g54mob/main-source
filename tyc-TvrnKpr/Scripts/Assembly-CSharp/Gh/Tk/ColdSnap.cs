using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class ColdSnap : WeatherEffectBase
	{
		public float lerpTimeMultiplier;

		public AnimationCurve lerpCurve;

		public AnimationCurve sunlightCurve;

		public AnimationCurve daytimeCurve;

		public ParticleSystem[] particles;

		public Material coldFogMat;

		public Color activeFogColor;

		private AmplifyColorBase amplifyColor;

		public Texture2D LUT;

		[PersistenceOptIn]
		private float lerpTime;

		private float lerpTimeCurveAdjusted;

		private List<float> particleRates;

		private bool started;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public override void ResetState()
		{
		}

		private void TurnOff(bool immediate = false)
		{
		}
	}
}
