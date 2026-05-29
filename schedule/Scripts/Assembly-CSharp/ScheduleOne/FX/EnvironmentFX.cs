using Funly.SkyStudio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Tools;
using UnityEngine;
using VolumetricFogAndMist2;

namespace ScheduleOne.FX
{
	[ExecuteInEditMode]
	public class EnvironmentFX : Singleton<EnvironmentFX>
	{
		[SerializeField]
		[Header("References")]
		protected WindZone windZone;

		[SerializeField]
		protected TimeOfDayController timeOfDayController;

		public VolumetricFog VolumetricFog;

		public Light SunLight;

		public Light MoonLight;

		[SerializeField]
		[Header("Height Fog")]
		protected Gradient HeightFogColor;

		[SerializeField]
		protected AnimationCurve HeightFogIntensityCurve;

		[SerializeField]
		protected float HeightFogIntensityMultiplier;

		[SerializeField]
		protected AnimationCurve HeightFogDirectionalIntensityCurve;

		[Header("Volumetric Fog")]
		[SerializeField]
		protected Gradient VolumetricFogColor;

		[SerializeField]
		protected AnimationCurve VolumetricFogIntensityCurve;

		[SerializeField]
		protected float VolumetricFogIntensityMultiplier;

		[Header("Fog")]
		[SerializeField]
		private float fogEndDistanceMultiplier;

		[SerializeField]
		[Header("God rays")]
		protected AnimationCurve godRayIntensityCurve;

		[Header("Contrast")]
		[SerializeField]
		protected AnimationCurve contrastCurve;

		[SerializeField]
		protected float contractMultiplier;

		[Header("Saturation")]
		[SerializeField]
		protected AnimationCurve saturationCurve;

		[SerializeField]
		protected float saturationMultiplier;

		[SerializeField]
		[Header("Grass")]
		protected Material grassMat;

		[SerializeField]
		protected Gradient grassColorGradient;

		[Header("Trees")]
		public Material distanceTreeMat;

		public AnimationCurve distanceTreeColorCurve;

		[Header("Stealth settings")]
		public AnimationCurve environmentalBrightnessCurve;

		[Header("Bloom")]
		public AnimationCurve bloomThreshholdCurve;

		[SerializeField]
		[Header("Gloabl Shader Properties")]
		private float _environmentScrollSpeed;

		[SerializeField]
		private float _testPercentage;

		private float _scrollTime;

		private float _scrollValue;

		private bool _scrollTActive;

		private bool started;

		public FloatSmoother FogEndDistanceController;

		public float normalizedEnvironmentalBrightness => 0f;

		public float FogEndDistanceMultiplier => 0f;

		protected override void Start()
		{
		}

		private void Update()
		{
		}

		private void UpdateVisuals()
		{
		}

		public void SetEnvironmentScrollingActive(bool active)
		{
		}

		public void SetEnvironmentScrollingSpeedByPercentage(float percentage)
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
