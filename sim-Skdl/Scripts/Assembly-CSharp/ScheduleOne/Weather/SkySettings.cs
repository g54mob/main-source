using System;
using UnityEngine;

namespace ScheduleOne.Weather
{
	[Serializable]
	public class SkySettings
	{
		[SerializeField]
		private DynamicGradient _skyUpperGradient;

		[SerializeField]
		private DynamicGradient _skyMiddleGradient;

		[SerializeField]
		private DynamicGradient _skyLowerGradient;

		[SerializeField]
		private DynamicGradient _cloudDensityGradient;

		[SerializeField]
		private DynamicGradient _cloudColorGradient;

		[SerializeField]
		private DynamicGradient _sunLightGradient;

		[SerializeField]
		private DynamicGradient _sunIntensityGradient;

		[SerializeField]
		private DynamicGradient _sunColorGradient;

		[SerializeField]
		private DynamicGradient _sunSizeGradient;

		[SerializeField]
		private DynamicGradient _moonLightGradient;

		[SerializeField]
		private DynamicGradient _moonIntensityGradient;

		[SerializeField]
		private DynamicGradient _moonColorGradient;

		[SerializeField]
		private DynamicGradient _moonSizeGradient;

		[SerializeField]
		private DynamicGradient _ambientSkyGradient;

		[SerializeField]
		private DynamicGradient _ambientEquatorGradient;

		[SerializeField]
		private DynamicGradient _ambientGroundGradient;

		[SerializeField]
		private DynamicGradient _fogColorGradient;

		[SerializeField]
		private DynamicGradient _fogDensityGradient;

		public Vector2 FogHeightFade;

		[SerializeField]
		private DynamicGradient _windIntensityGradient;

		public DynamicGradient SkyUpperGradient => null;

		public DynamicGradient SkyMiddleGradient => null;

		public DynamicGradient SkyLowerGradient => null;

		public DynamicGradient CloudDensityGradient => null;

		public DynamicGradient CloudColorGradient => null;

		public DynamicGradient SunLightColorGradient => null;

		public DynamicGradient SunDiscColorGradient => null;

		public DynamicGradient MoonLightColorGradient => null;

		public DynamicGradient MoonDiscColorGradient => null;

		public DynamicGradient SunIntensityGradient => null;

		public DynamicGradient MoonIntensityGradient => null;

		public DynamicGradient AmbientSkyGradient => null;

		public DynamicGradient AmbientEquatorGradient => null;

		public DynamicGradient AmbientGroundGradient => null;

		public DynamicGradient FogColorGradient => null;

		public DynamicGradient FogDensityGradient => null;

		public DynamicGradient WindIntensityGradient => null;

		public DynamicGradient SunSizeGradient => null;

		public DynamicGradient MoonSizeGradient => null;

		public void Set(SkySettings settings)
		{
		}
	}
}
