using System.Collections.Generic;
using AK.Wwise;
using UnityEngine;
using UnityEngine.PostProcessing;

namespace Gh.Tk
{
	public class Rain : WeatherEffectBase
	{
		public float lerpTimeMultiplier;

		public Renderer rainFogRenderer;

		public Gradient fogGradient;

		public PostProcessingProfile postProcProf;

		public float bloomIntensity;

		public float bloomThreshhold;

		public float bloomSoftKnee;

		public float bloomRadius;

		public AnimationCurve lerpCurve;

		public AnimationCurve sunlightCurve;

		public AnimationCurve daytimeCurve;

		public ParticleSystem[] particles;

		public Gradient particleGradient;

		public Material[] particleMats;

		public Light lightning;

		public float lightningStartThreshold;

		public float lightningLightDuration;

		public float flashCount;

		public float flashPeriod;

		public float lightningMaxIntensity;

		public float timeBetweenLightningMin;

		public float timeBetweenLightningMax;

		private AmplifyColorBase amplifyColor;

		public Texture2D LUT;

		private BloomModel.Settings bloomSettings;

		[PersistenceOptIn]
		private float lerpTime;

		private float lerpTimeCurveAdjusted;

		private float lightningTimer;

		private float nextLightningTime;

		private List<float> particleRates;

		private Material rainFogMat;

		private bool startedRaining;

		public AK.Wwise.Event RainSFX;

		public AK.Wwise.Event LightningStrikeSFX;

		private void Start()
		{
		}

		private void Update()
		{
		}

		protected void OnDisable()
		{
		}

		public override void ResetState()
		{
		}

		private void TurnOff(bool immediate = false)
		{
		}

		private void FlashLightning()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
