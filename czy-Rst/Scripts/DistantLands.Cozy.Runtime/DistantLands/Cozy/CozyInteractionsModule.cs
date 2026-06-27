using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyInteractionsModule : CozyModule
	{
		[CozySearchable(true, new string[] { })]
		public MaterialManagerProfile profile;

		private void Awake()
		{
			if (!(profile == null))
			{
				SetupStaticGlobalVariables();
			}
		}

		public override void CozyUpdateLoop()
		{
			if (base.weatherSphere == null)
			{
				base.InitializeModule();
			}
			if (profile == null || (CozyWeather.FreezeUpdateInEditMode && !Application.isPlaying))
			{
				return;
			}
			SetupStaticGlobalVariables();
			MaterialManagerProfile.ModulatedValue[] modulatedValues = profile.modulatedValues;
			foreach (MaterialManagerProfile.ModulatedValue modulatedValue in modulatedValues)
			{
				switch (modulatedValue.modulationTarget)
				{
				case MaterialManagerProfile.ModulatedValue.ModulationTarget.globalColor:
					Shader.SetGlobalColor(modulatedValue.targetVariableName, modulatedValue.mappedGradient.Evaluate(GetPercentage(modulatedValue.modulationSource)));
					break;
				case MaterialManagerProfile.ModulatedValue.ModulationTarget.globalValue:
					Shader.SetGlobalFloat(modulatedValue.targetVariableName, modulatedValue.mappedCurve.Evaluate(GetPercentage(modulatedValue.modulationSource)));
					break;
				case MaterialManagerProfile.ModulatedValue.ModulationTarget.materialColor:
					if ((bool)modulatedValue.targetMaterial)
					{
						modulatedValue.targetMaterial.SetColor(modulatedValue.targetVariableName, modulatedValue.mappedGradient.Evaluate(GetPercentage(modulatedValue.modulationSource)));
					}
					break;
				case MaterialManagerProfile.ModulatedValue.ModulationTarget.materialValue:
					if ((bool)modulatedValue.targetMaterial)
					{
						modulatedValue.targetMaterial.SetFloat(modulatedValue.targetVariableName, modulatedValue.mappedCurve.Evaluate(GetPercentage(modulatedValue.modulationSource)));
					}
					break;
				case MaterialManagerProfile.ModulatedValue.ModulationTarget.terrainLayerColor:
					if ((bool)modulatedValue.targetLayer)
					{
						modulatedValue.targetLayer.specular = modulatedValue.mappedGradient.Evaluate(GetPercentage(modulatedValue.modulationSource));
					}
					break;
				case MaterialManagerProfile.ModulatedValue.ModulationTarget.terrainLayerTint:
					if ((bool)modulatedValue.targetLayer)
					{
						modulatedValue.targetLayer.diffuseRemapMax = modulatedValue.mappedGradient.Evaluate(GetPercentage(modulatedValue.modulationSource));
					}
					break;
				}
			}
		}

		private float GetPercentage(MaterialManagerProfile.ModulatedValue.ModulationSource modulationSource)
		{
			float result = 0f;
			switch (modulationSource)
			{
			case MaterialManagerProfile.ModulatedValue.ModulationSource.dayPercent:
				if ((bool)base.weatherSphere.timeModule)
				{
					result = base.weatherSphere.timeModule.currentTime;
				}
				break;
			case MaterialManagerProfile.ModulatedValue.ModulationSource.precipitation:
				if ((bool)base.weatherSphere.climateModule)
				{
					result = Mathf.Clamp01(base.weatherSphere.climateModule.currentPrecipitation / 100f);
				}
				break;
			case MaterialManagerProfile.ModulatedValue.ModulationSource.rainAmount:
				if ((bool)base.weatherSphere.climateModule)
				{
					result = base.weatherSphere.climateModule.groundwaterAmount;
				}
				break;
			case MaterialManagerProfile.ModulatedValue.ModulationSource.snowAmount:
				if ((bool)base.weatherSphere.climateModule)
				{
					result = base.weatherSphere.climateModule.snowAmount;
				}
				break;
			case MaterialManagerProfile.ModulatedValue.ModulationSource.temperature:
				if ((bool)base.weatherSphere.climateModule)
				{
					result = Mathf.Clamp01(base.weatherSphere.climateModule.GetTemperature() / 100f);
				}
				break;
			case MaterialManagerProfile.ModulatedValue.ModulationSource.yearPercent:
				if ((bool)base.weatherSphere.timeModule)
				{
					result = base.weatherSphere.timeModule.yearPercentage;
				}
				break;
			}
			return result;
		}

		public void SetupStaticGlobalVariables()
		{
			Shader.SetGlobalFloat("CZY_SnowScale", profile.snowNoiseSize);
			Shader.SetGlobalTexture("CZY_SnowTexture", profile.snowTexture);
			Shader.SetGlobalColor("CZY_SnowColor", profile.snowColor);
			Shader.SetGlobalFloat("CZY_PuddleScale", profile.puddleScale);
		}
	}
}
