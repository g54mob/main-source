using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyMicrosplatModule : CozyModule
	{
		public enum UpdateFrequency
		{
			everyFrame = 0,
			onAwake = 1,
			viaScripting = 2
		}

		[CozySearchable(new string[] { "Microsplat" })]
		public UpdateFrequency updateFrequency;

		[Header("Wetness")]
		[CozySearchable(new string[] { })]
		public bool updateWetness = true;

		[Range(0f, 1f)]
		[CozySearchable(new string[] { })]
		public float minWetness;

		[Range(0f, 1f)]
		[CozySearchable(new string[] { })]
		public float maxWetness = 1f;

		[Header("Rain Ripples")]
		[CozySearchable(new string[] { })]
		public bool updateRainRipples = true;

		[Header("Puddle Settings")]
		[CozySearchable(new string[] { })]
		public bool updatePuddles = true;

		[Header("Stream Settings")]
		[CozySearchable(new string[] { })]
		public bool updateStreams = true;

		[Header("Snow Settings")]
		[CozySearchable(new string[] { })]
		public bool updateSnow = true;

		[Header("Wind Settings")]
		[CozySearchable(new string[] { })]
		public bool updateWindStrength = true;

		private static readonly int GlobalSnowLevel = Shader.PropertyToID("_Global_SnowLevel");

		private static readonly int GlobalWetnessParams = Shader.PropertyToID("_Global_WetnessParams");

		private static readonly int GlobalPuddleParams = Shader.PropertyToID("_Global_PuddleParams");

		private static readonly int GlobalRainIntensity = Shader.PropertyToID("_Global_RainIntensity");

		private static readonly int GlobalStreamMax = Shader.PropertyToID("_Global_StreamMax");

		private static readonly int GlobalWindParticulateStrength = Shader.PropertyToID("_Global_WindParticulateStrength");

		private static readonly int GlobalSnowParticulateStrength = Shader.PropertyToID("_Global_SnowParticulateStrength");

		public override void InitializeModule()
		{
			base.InitializeModule();
			if (updateFrequency == UpdateFrequency.onAwake)
			{
				UpdateShaderProperties();
			}
		}

		private void Update()
		{
			if ((!CozyWeather.FreezeUpdateInEditMode || Application.isPlaying) && updateFrequency == UpdateFrequency.everyFrame)
			{
				UpdateShaderProperties();
			}
		}

		public void UpdateShaderProperties()
		{
			if ((bool)base.weatherSphere.climateModule)
			{
				if (updateSnow)
				{
					Shader.SetGlobalFloat(GlobalSnowLevel, base.weatherSphere.climateModule.snowAmount);
				}
				if (updateWetness)
				{
					float y = Mathf.Clamp(base.weatherSphere.climateModule.groundwaterAmount, minWetness, maxWetness);
					Shader.SetGlobalVector(GlobalWetnessParams, new Vector2(minWetness, y));
				}
				if (updatePuddles)
				{
					Shader.SetGlobalFloat(GlobalPuddleParams, base.weatherSphere.climateModule.groundwaterAmount);
				}
				if (updateRainRipples)
				{
					Shader.SetGlobalFloat(GlobalRainIntensity, base.weatherSphere.climateModule.groundwaterAmount);
				}
				if (updateStreams)
				{
					Shader.SetGlobalFloat(GlobalStreamMax, base.weatherSphere.climateModule.groundwaterAmount);
				}
			}
		}
	}
}
