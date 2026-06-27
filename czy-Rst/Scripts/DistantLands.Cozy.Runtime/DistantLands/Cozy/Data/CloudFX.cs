using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/FX/Cloud FX", order = 361)]
	public class CloudFX : FXProfile
	{
		[Tooltip("Multiplier for cumulus clouds.")]
		[OverrideRange(0f, 2f)]
		public Overridable<float> cumulusCoverage = 1f;

		[Tooltip("Multiplier for altocumulus clouds.")]
		[OverrideRange(0f, 2f)]
		public Overridable<float> altocumulusCoverage = 0f;

		[Tooltip("Multiplier for chemtrails.")]
		[OverrideRange(0f, 2f)]
		public Overridable<float> chemtrailCoverage = 0f;

		[Tooltip("Multiplier for cirrostratus clouds.")]
		[OverrideRange(0f, 2f)]
		public Overridable<float> cirrostratusCoverage = 0f;

		[Tooltip("Multiplier for cirrus clouds.")]
		[OverrideRange(0f, 2f)]
		public Overridable<float> cirrusCoverage = 0f;

		[Tooltip("Multiplier for nimbus clouds.")]
		[OverrideRange(0f, 2f)]
		public Overridable<float> nimbusCoverage = 0f;

		[Tooltip("Variation for nimbus clouds.")]
		[OverrideRange(0f, 1f)]
		public Overridable<float> nimbusVariation = 0.9f;

		[Tooltip("Height mask effect for nimbus clouds.")]
		[OverrideRange(0f, 1f)]
		public Overridable<float> nimbusHeightEffect = 1f;

		[Tooltip("Starting height for cloud border.")]
		[OverrideRange(0f, 1f)]
		public Overridable<float> borderHeight = 0.5f;

		[Tooltip("Variation for cloud border.")]
		[OverrideRange(0f, 1f)]
		public Overridable<float> borderVariation = 0.9f;

		[Tooltip("Multiplier for the border. Values below zero clip the clouds whereas values above zero add clouds.")]
		[OverrideRange(-1f, 1f)]
		public Overridable<float> borderEffect = 1f;

		[Tooltip("Controls the average density of the fog.")]
		[OverrideRange(0f, 5f)]
		public Overridable<float> fogDensity = 1f;

		private CozyWeatherModule weatherModule;

		public override void PlayEffect(float weight)
		{
			if ((bool)weatherModule || InitializeEffect(null))
			{
				weatherModule.cumulus = Mathf.Clamp(weatherModule.cumulus + (float)cumulusCoverage * transitionTimeModifier.Evaluate(weight), 0f, 2f);
				weatherModule.cirrus = Mathf.Clamp(weatherModule.cirrus + (float)cirrusCoverage * transitionTimeModifier.Evaluate(weight), 0f, 2f);
				weatherModule.altocumulus = Mathf.Clamp(weatherModule.altocumulus + (float)altocumulusCoverage * transitionTimeModifier.Evaluate(weight), 0f, 2f);
				weatherModule.cirrostratus = Mathf.Clamp(weatherModule.cirrostratus + (float)cirrostratusCoverage * transitionTimeModifier.Evaluate(weight), 0f, 2f);
				weatherModule.chemtrails = Mathf.Clamp(weatherModule.chemtrails + (float)chemtrailCoverage * transitionTimeModifier.Evaluate(weight), 0f, 2f);
				weatherModule.nimbus = Mathf.Clamp(weatherModule.nimbus + (float)nimbusCoverage * transitionTimeModifier.Evaluate(weight), 0f, 2f);
				weatherModule.nimbusHeight = Mathf.Clamp(weatherModule.nimbusHeight + (float)nimbusHeightEffect * transitionTimeModifier.Evaluate(weight), 0f, 1f);
				weatherModule.nimbusVariation = Mathf.Clamp(weatherModule.nimbusVariation + (float)nimbusVariation * transitionTimeModifier.Evaluate(weight), 0f, 1f);
				weatherModule.borderHeight = (borderHeight ? Mathf.Lerp(weatherModule.borderHeight, borderHeight, transitionTimeModifier.Evaluate(weight)) : weatherModule.borderHeight);
				weatherModule.borderEffect = (borderEffect ? Mathf.Lerp(weatherModule.borderEffect, borderEffect, transitionTimeModifier.Evaluate(weight)) : weatherModule.borderEffect);
				weatherModule.borderVariation = (borderVariation ? Mathf.Lerp(weatherModule.borderVariation, borderVariation, transitionTimeModifier.Evaluate(weight)) : weatherModule.borderVariation);
				weatherModule.fogDensity = (fogDensity ? Mathf.Clamp(weatherModule.fogDensity + (float)fogDensity * transitionTimeModifier.Evaluate(weight), 0f, 5f) : weatherModule.fogDensity);
			}
		}

		public override bool InitializeEffect(CozyWeather weather)
		{
			base.InitializeEffect(weather);
			if (!weatherSphere.weatherModule)
			{
				return false;
			}
			weatherModule = weatherSphere.weatherModule;
			return true;
		}
	}
}
