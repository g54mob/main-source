using Funly.SkyStudio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Tools;
using UnityEngine;
using VolumetricFogAndMist2;

namespace ScheduleOne.FX
{
	public class EnvironmentFX : Singleton<EnvironmentFX>
	{
		[SerializeField]
		[Header("References")]
		protected TimeOfDayController timeOfDayController;

		public VolumetricFog VolumetricFog;

		public Light SunLight;

		public Light MoonLight;

		[Header("Height Fog")]
		[SerializeField]
		protected Gradient HeightFogColor;

		[SerializeField]
		protected AnimationCurve HeightFogIntensityCurve;

		[SerializeField]
		protected float HeightFogIntensityMultiplier;

		[SerializeField]
		protected AnimationCurve HeightFogDirectionalIntensityCurve;

		[Header("Volumetric Fog")]
		[SerializeField]
		protected AnimationCurve VolumetricFogIntensityCurve;

		[SerializeField]
		protected float VolumetricFogIntensityMultiplier;

		[SerializeField]
		protected float VolumetricFogSaturationMultiplier;

		[SerializeField]
		[Header("Fog")]
		private float fogEndDistanceMultiplier;

		[SerializeField]
		[Header("God rays")]
		protected AnimationCurve godRayIntensityCurve;

		[SerializeField]
		[Header("Contrast")]
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

		[Header("Gloabl Shader Properties")]
		[SerializeField]
		private float _environmentScrollSpeed;

		[SerializeField]
		private float _testPercentage;

		public FloatSmoother FogEndDistanceController;

		private float _scrollTime;

		private float _scrollValue;

		private bool _scrollTActive;

		private Color _defaultDistantTreeMatColor;

		private Color _defaultGrassMatColor;

		public float normalizedEnvironmentalBrightness => 0f;

		public float FogEndDistanceMultiplier => 0f;

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected override void OnDestroy()
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
	}
}
