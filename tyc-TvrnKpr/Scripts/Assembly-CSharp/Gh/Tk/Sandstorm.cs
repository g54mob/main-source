using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

namespace Gh.Tk
{
	public class Sandstorm : WeatherEffectBase
	{
		public float lerpTimeMultiplier;

		public PostProcessingProfile postProcProf;

		private GrainModel.Settings grainSettings;

		public float grainIntensity;

		public float grainLuminanceContribution;

		public float grainSize;

		public bool grainColored;

		public Color fogColor;

		public float fogDensity;

		public AnimationCurve lerpCurve;

		public AnimationCurve sunlightCurve;

		public AnimationCurve daytimeCurve;

		[PersistenceOptIn]
		private float lerpTime;

		private float lerpTimeCurveAdjusted;

		public ParticleSystem[] particles;

		private List<float> particleRates;

		public Gradient particleGradient;

		public WindZone wind;

		public float windIntensity;

		public DotweenRotateEdittable windmill;

		public float windmillMaxSpeed;

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

		public override void StopEffect()
		{
		}

		private void CheckActors()
		{
		}

		protected void TurnOff(bool immediate = false)
		{
		}

		private void AddDirt()
		{
		}

		private void OnApplicationQuit()
		{
		}
	}
}
