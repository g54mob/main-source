using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

namespace Gh.Tk
{
	public class Heatwave : WeatherEffectBase
	{
		public float lerpTimeMultiplier;

		private PostProcessMat postProcessHeatwave;

		private PostProcessMat postProcessHeatwaveFreecam;

		private Material heatwaveMat;

		private float maxHeatwaveStrength;

		private float maxHeatwaveTransparency;

		public PostProcessingProfile postProcProf;

		private BloomModel.Settings bloomSettings;

		public float bloomIntensity;

		public float bloomThreshhold;

		public float bloomSoftKnee;

		public float bloomRadius;

		public AnimationCurve lerpCurve;

		public AnimationCurve sunlightCurve;

		public AnimationCurve daytimeCurve;

		[PersistenceOptIn]
		private float lerpTime;

		private float lerpTimeCurveAdjusted;

		public ParticleSystem[] particles;

		private List<float> particleRates;

		private bool weatherStarted;

		public override void ResetState()
		{
		}

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}

		private void Update()
		{
		}

		protected void TurnOff(bool immediate = false)
		{
		}
	}
}
