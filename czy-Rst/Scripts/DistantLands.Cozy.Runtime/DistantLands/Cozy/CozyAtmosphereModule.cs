using System.Collections;
using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyAtmosphereModule : CozyBiomeModuleBase<CozyAtmosphereModule>
	{
		[CozySearchable(true, new string[] { "sky", "atmosphere", "fog", "lighting", "clouds" })]
		public AtmosphereProfile atmosphereProfile;

		public bool transitioningAtmosphere;

		public override void PropogateVariables()
		{
			if (atmosphereProfile == null)
			{
				Debug.LogWarning("Cozy Weather requires an active atmosphere profile to function properly.\nPlease ensure that the active CozyWeather script contains all necessary profile references.");
			}
			else
			{
				SetAtmosphereVariables();
			}
		}

		private void LateUpdate()
		{
			if (!base.isBiomeModule)
			{
				ComputeBiomeWeights();
				base.weatherSphere.UpdateShaderVariables();
			}
		}

		private void SetAtmosphereVariables()
		{
			float time = (base.weatherSphere.usePhysicalSunHeight ? base.weatherSphere.modifiedDayPercentage : base.weatherSphere.dayPercentage);
			base.weatherSphere.gradientExponent = atmosphereProfile.gradientExponent.GetFloatValue(time);
			base.weatherSphere.acScale = atmosphereProfile.acScale.GetFloatValue(time);
			base.weatherSphere.ambientLightHorizonColor = atmosphereProfile.ambientLightHorizonColor.GetColorValue(time);
			base.weatherSphere.ambientLightZenithColor = atmosphereProfile.ambientLightZenithColor.GetColorValue(time);
			base.weatherSphere.ambientLightMultiplier = atmosphereProfile.ambientLightMultiplier.GetFloatValue(time);
			base.weatherSphere.chemtrailsMoveSpeed = atmosphereProfile.chemtrailsMoveSpeed.GetFloatValue(time);
			base.weatherSphere.cirroMoveSpeed = atmosphereProfile.cirroMoveSpeed.GetFloatValue(time);
			base.weatherSphere.cirrusMoveSpeed = atmosphereProfile.cirrusMoveSpeed.GetFloatValue(time);
			base.weatherSphere.clippingThreshold = atmosphereProfile.clippingThreshold.GetFloatValue(time);
			base.weatherSphere.cloudCohesion = atmosphereProfile.cloudCohesion.GetFloatValue(time);
			base.weatherSphere.cloudColor = atmosphereProfile.cloudColor.GetColorValue(time);
			base.weatherSphere.cloudDetailAmount = atmosphereProfile.cloudDetailAmount.GetFloatValue(time);
			base.weatherSphere.cloudDetailScale = atmosphereProfile.cloudDetailScale.GetFloatValue(time);
			base.weatherSphere.cloudHighlightColor = atmosphereProfile.cloudHighlightColor.GetColorValue(time);
			base.weatherSphere.cloudMainScale = atmosphereProfile.cloudMainScale.GetFloatValue(time);
			base.weatherSphere.cloudMoonColor = atmosphereProfile.cloudMoonColor.GetColorValue(time);
			base.weatherSphere.cloudMoonHighlightFalloff = atmosphereProfile.cloudMoonHighlightFalloff.GetFloatValue(time);
			base.weatherSphere.cloudSunHighlightFalloff = atmosphereProfile.cloudSunHighlightFalloff.GetFloatValue(time);
			base.weatherSphere.cloudTextureColor = atmosphereProfile.cloudTextureColor.GetColorValue(time);
			base.weatherSphere.cloudThickness = atmosphereProfile.cloudThickness.GetFloatValue(time);
			base.weatherSphere.cloudWindSpeed = atmosphereProfile.cloudWindSpeed.GetFloatValue(time);
			base.weatherSphere.fogColor1 = atmosphereProfile.fogColor1.GetColorValue(time);
			base.weatherSphere.fogColor2 = atmosphereProfile.fogColor2.GetColorValue(time);
			base.weatherSphere.fogColor3 = atmosphereProfile.fogColor3.GetColorValue(time);
			base.weatherSphere.fogColor4 = atmosphereProfile.fogColor4.GetColorValue(time);
			base.weatherSphere.fogColor5 = atmosphereProfile.fogColor5.GetColorValue(time);
			base.weatherSphere.fogStart1 = atmosphereProfile.fogStart1.GetFloatValue(time);
			base.weatherSphere.fogStart2 = atmosphereProfile.fogStart2.GetFloatValue(time);
			base.weatherSphere.fogStart3 = atmosphereProfile.fogStart3.GetFloatValue(time);
			base.weatherSphere.fogStart4 = atmosphereProfile.fogStart4.GetFloatValue(time);
			base.weatherSphere.fogDensityMultiplier = atmosphereProfile.fogDensityMultiplier.GetFloatValue(time);
			base.weatherSphere.fogFlareColor = atmosphereProfile.fogFlareColor.GetColorValue(time);
			base.weatherSphere.fogMoonFlareColor = atmosphereProfile.fogMoonFlareColor.GetColorValue(time);
			base.weatherSphere.fogHeight = atmosphereProfile.fogHeight.GetFloatValue(time);
			base.weatherSphere.fogVariationAmount = atmosphereProfile.fogVariationAmount.GetFloatValue(time);
			base.weatherSphere.fogVariationDirection = atmosphereProfile.fogVariationDirection;
			base.weatherSphere.fogVariationDistance = atmosphereProfile.fogVariationDistance.GetFloatValue(time);
			base.weatherSphere.fogVariationScale = atmosphereProfile.fogVariationScale.GetFloatValue(time);
			base.weatherSphere.fogLightFlareFalloff = atmosphereProfile.fogLightFlareFalloff.GetFloatValue(time);
			base.weatherSphere.fogLightFlareIntensity = atmosphereProfile.fogLightFlareIntensity.GetFloatValue(time);
			base.weatherSphere.fogLightFlareSquish = atmosphereProfile.fogLightFlareSquish.GetFloatValue(time);
			base.weatherSphere.fogBase = atmosphereProfile.fogBase.GetFloatValue(time);
			base.weatherSphere.heightFogColor = atmosphereProfile.heightFogColor.GetColorValue(time);
			base.weatherSphere.heightFogDistance = atmosphereProfile.heightFogDistance.GetFloatValue(time);
			base.weatherSphere.heightFogIntensity = atmosphereProfile.heightFogIntensity.GetFloatValue(time);
			base.weatherSphere.heightFogTransition = atmosphereProfile.heightFogTransition.GetFloatValue(time);
			base.weatherSphere.heightFogVariationAmount = atmosphereProfile.heightFogVariationAmount.GetFloatValue(time);
			base.weatherSphere.heightFogVariationScale = atmosphereProfile.heightFogVariationScale.GetFloatValue(time);
			base.weatherSphere.galaxy1Color = atmosphereProfile.galaxy1Color.GetColorValue(time);
			base.weatherSphere.galaxy2Color = atmosphereProfile.galaxy2Color.GetColorValue(time);
			base.weatherSphere.galaxy3Color = atmosphereProfile.galaxy3Color.GetColorValue(time);
			base.weatherSphere.galaxyIntensity = atmosphereProfile.galaxyIntensity.GetFloatValue(time);
			base.weatherSphere.highAltitudeCloudColor = atmosphereProfile.highAltitudeCloudColor.GetColorValue(time);
			base.weatherSphere.lightScatteringColor = atmosphereProfile.lightScatteringColor.GetColorValue(time);
			base.weatherSphere.moonlightColor = atmosphereProfile.moonlightColor.GetColorValue(time);
			base.weatherSphere.moonColor = atmosphereProfile.moonColor.GetColorValue(time);
			base.weatherSphere.moonFalloff = atmosphereProfile.moonFalloff.GetFloatValue(time);
			base.weatherSphere.moonFlareColor = atmosphereProfile.moonFlareColor.GetColorValue(time);
			base.weatherSphere.useRainbow = atmosphereProfile.useRainbow;
			base.weatherSphere.rainbowPosition = atmosphereProfile.rainbowPosition.GetFloatValue(time);
			base.weatherSphere.rainbowWidth = atmosphereProfile.rainbowWidth.GetFloatValue(time);
			base.weatherSphere.shadowDistance = atmosphereProfile.shadowDistance.GetFloatValue(time);
			base.weatherSphere.skyHorizonColor = atmosphereProfile.skyHorizonColor.GetColorValue(time);
			base.weatherSphere.skyZenithColor = atmosphereProfile.skyZenithColor.GetColorValue(time);
			base.weatherSphere.spherize = atmosphereProfile.spherize.GetFloatValue(time);
			base.weatherSphere.starColor = atmosphereProfile.starColor.GetColorValue(time);
			base.weatherSphere.sunColor = atmosphereProfile.sunColor.GetColorValue(time);
			base.weatherSphere.sunDirection = atmosphereProfile.sunDirection.GetFloatValue(time);
			base.weatherSphere.sunFalloff = atmosphereProfile.sunFalloff.GetFloatValue(time);
			base.weatherSphere.sunFlareColor = atmosphereProfile.sunFlareColor.GetColorValue(time);
			base.weatherSphere.sunlightColor = atmosphereProfile.sunlightColor.GetColorValue(time);
			base.weatherSphere.moonlightShadows = atmosphereProfile.moonlightShadows;
			base.weatherSphere.sunlightShadows = atmosphereProfile.sunlightShadows;
			base.weatherSphere.sunPitch = atmosphereProfile.sunPitch.GetFloatValue(time);
			base.weatherSphere.sunSize = atmosphereProfile.sunSize.GetFloatValue(time);
			base.weatherSphere.textureAmount = atmosphereProfile.textureAmount.GetFloatValue(time);
			base.weatherSphere.fogSmoothness = atmosphereProfile.fogSmoothness.GetFloatValue(time);
			base.weatherSphere.texturePanDirection = atmosphereProfile.texturePanDirection;
			base.weatherSphere.cloudTexture = atmosphereProfile.cloudTexture;
			base.weatherSphere.chemtrailsTexture = atmosphereProfile.chemtrailsTexture;
			base.weatherSphere.cirrusCloudTexture = atmosphereProfile.cirrusCloudTexture;
			base.weatherSphere.altocumulusCloudTexture = atmosphereProfile.altocumulusCloudTexture;
			base.weatherSphere.cirrostratusCloudTexture = atmosphereProfile.cirrostratusCloudTexture;
			base.weatherSphere.starMap = atmosphereProfile.starMap;
			base.weatherSphere.galaxyMap = atmosphereProfile.galaxyMap;
			base.weatherSphere.galaxyStarMap = atmosphereProfile.galaxyStarMap;
			base.weatherSphere.galaxyVariationMap = atmosphereProfile.galaxyVariationMap;
			base.weatherSphere.lightScatteringMap = atmosphereProfile.lightScatteringMap;
			base.weatherSphere.partlyCloudyLuxuryClouds = atmosphereProfile.partlyCloudyLuxuryClouds;
			base.weatherSphere.mostlyCloudyLuxuryClouds = atmosphereProfile.mostlyCloudyLuxuryClouds;
			base.weatherSphere.overcastLuxuryClouds = atmosphereProfile.overcastLuxuryClouds;
			base.weatherSphere.lowBorderLuxuryClouds = atmosphereProfile.lowBorderLuxuryClouds;
			base.weatherSphere.highBorderLuxuryClouds = atmosphereProfile.highBorderLuxuryClouds;
			base.weatherSphere.lowNimbusLuxuryClouds = atmosphereProfile.lowNimbusLuxuryClouds;
			base.weatherSphere.midNimbusLuxuryClouds = atmosphereProfile.midNimbusLuxuryClouds;
			base.weatherSphere.highNimbusLuxuryClouds = atmosphereProfile.highNimbusLuxuryClouds;
			base.weatherSphere.luxuryVariation = atmosphereProfile.luxuryVariation;
			base.weatherSphere.constellationIntensity = atmosphereProfile.constellationIntensity.GetFloatValue(time);
			base.weatherSphere.lightScatteringPosition = atmosphereProfile.lightScatteringPosition.GetFloatValue(time);
			base.weatherSphere.lightScatteringHeight = atmosphereProfile.lightScatteringHeight.GetFloatValue(time);
			base.weatherSphere.skyFogAmount = atmosphereProfile.skyFogAmount.GetFloatValue(time);
			base.weatherSphere.cloudsFogAmount = atmosphereProfile.cloudsFogAmount.GetFloatValue(time);
			base.weatherSphere.cloudsFogLightAmount = atmosphereProfile.cloudsFogLightAmount.GetFloatValue(time);
			base.weatherSphere.starDomeTexture = atmosphereProfile.starDomeTexture;
			base.weatherSphere.constellationDomeTexture = atmosphereProfile.constellationDomeTexture;
			base.weatherSphere.galaxyDomeTexture = atmosphereProfile.galaxyDomeTexture;
			base.weatherSphere.lightScatteringMap = atmosphereProfile.lightScatteringMap;
			base.weatherSphere.rainbowTexture = atmosphereProfile.rainbowTexture;
			base.weatherSphere.sunFlare = atmosphereProfile.sunFlare;
			base.weatherSphere.moonFlare = atmosphereProfile.moonFlare;
			foreach (CozyAtmosphereModule biome in biomes)
			{
				if (!(biome == null) && biome.system.weight != 0f)
				{
					if ((bool)biome.atmosphereProfile.gradientExponent)
					{
						base.weatherSphere.gradientExponent = Mathf.Lerp(base.weatherSphere.gradientExponent, biome.atmosphereProfile.gradientExponent.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.ambientLightHorizonColor)
					{
						base.weatherSphere.ambientLightHorizonColor = Color.Lerp(base.weatherSphere.ambientLightHorizonColor, biome.atmosphereProfile.ambientLightHorizonColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.ambientLightZenithColor)
					{
						base.weatherSphere.ambientLightZenithColor = Color.Lerp(base.weatherSphere.ambientLightZenithColor, biome.atmosphereProfile.ambientLightZenithColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.ambientLightMultiplier)
					{
						base.weatherSphere.ambientLightMultiplier = Mathf.Lerp(base.weatherSphere.ambientLightMultiplier, biome.atmosphereProfile.ambientLightMultiplier.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.clippingThreshold)
					{
						base.weatherSphere.clippingThreshold = Mathf.Lerp(base.weatherSphere.clippingThreshold, biome.atmosphereProfile.clippingThreshold.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.cloudCohesion)
					{
						base.weatherSphere.cloudCohesion = Mathf.Lerp(base.weatherSphere.cloudCohesion, biome.atmosphereProfile.cloudCohesion.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.cloudColor)
					{
						base.weatherSphere.cloudColor = Color.Lerp(base.weatherSphere.cloudColor, biome.atmosphereProfile.cloudColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.cloudHighlightColor)
					{
						base.weatherSphere.cloudHighlightColor = Color.Lerp(base.weatherSphere.cloudHighlightColor, biome.atmosphereProfile.cloudHighlightColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.cloudMoonColor)
					{
						base.weatherSphere.cloudMoonColor = Color.Lerp(base.weatherSphere.cloudMoonColor, biome.atmosphereProfile.cloudMoonColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.cloudMoonHighlightFalloff)
					{
						base.weatherSphere.cloudMoonHighlightFalloff = Mathf.Lerp(base.weatherSphere.cloudMoonHighlightFalloff, biome.atmosphereProfile.cloudMoonHighlightFalloff.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.cloudSunHighlightFalloff)
					{
						base.weatherSphere.cloudSunHighlightFalloff = Mathf.Lerp(base.weatherSphere.cloudSunHighlightFalloff, biome.atmosphereProfile.cloudSunHighlightFalloff.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.cloudTextureColor)
					{
						base.weatherSphere.cloudTextureColor = Color.Lerp(base.weatherSphere.cloudTextureColor, biome.atmosphereProfile.cloudTextureColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.cloudThickness)
					{
						base.weatherSphere.cloudThickness = Mathf.Lerp(base.weatherSphere.cloudThickness, biome.atmosphereProfile.cloudThickness.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogColor1)
					{
						base.weatherSphere.fogColor1 = Color.Lerp(base.weatherSphere.fogColor1, biome.atmosphereProfile.fogColor1.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogColor2)
					{
						base.weatherSphere.fogColor2 = Color.Lerp(base.weatherSphere.fogColor2, biome.atmosphereProfile.fogColor2.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogColor3)
					{
						base.weatherSphere.fogColor3 = Color.Lerp(base.weatherSphere.fogColor3, biome.atmosphereProfile.fogColor3.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogColor4)
					{
						base.weatherSphere.fogColor4 = Color.Lerp(base.weatherSphere.fogColor4, biome.atmosphereProfile.fogColor4.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogColor5)
					{
						base.weatherSphere.fogColor5 = Color.Lerp(base.weatherSphere.fogColor5, biome.atmosphereProfile.fogColor5.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogStart1)
					{
						base.weatherSphere.fogStart1 = Mathf.Lerp(base.weatherSphere.fogStart1, biome.atmosphereProfile.fogStart1.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogStart2)
					{
						base.weatherSphere.fogStart2 = Mathf.Lerp(base.weatherSphere.fogStart2, biome.atmosphereProfile.fogStart2.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogStart3)
					{
						base.weatherSphere.fogStart3 = Mathf.Lerp(base.weatherSphere.fogStart3, biome.atmosphereProfile.fogStart3.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogStart4)
					{
						base.weatherSphere.fogStart4 = Mathf.Lerp(base.weatherSphere.fogStart4, biome.atmosphereProfile.fogStart4.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogDensityMultiplier)
					{
						base.weatherSphere.fogDensityMultiplier = Mathf.Lerp(base.weatherSphere.fogDensityMultiplier, biome.atmosphereProfile.fogDensityMultiplier.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogFlareColor)
					{
						base.weatherSphere.fogFlareColor = Color.Lerp(base.weatherSphere.fogFlareColor, biome.atmosphereProfile.fogFlareColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogMoonFlareColor)
					{
						base.weatherSphere.fogMoonFlareColor = Color.Lerp(base.weatherSphere.fogMoonFlareColor, biome.atmosphereProfile.fogMoonFlareColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogHeight)
					{
						base.weatherSphere.fogHeight = Mathf.Lerp(base.weatherSphere.fogHeight, biome.atmosphereProfile.fogHeight.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogVariationAmount)
					{
						base.weatherSphere.fogVariationAmount = Mathf.Lerp(base.weatherSphere.fogVariationAmount, biome.atmosphereProfile.fogVariationAmount.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogVariationDistance)
					{
						base.weatherSphere.fogVariationDistance = Mathf.Lerp(base.weatherSphere.fogVariationDistance, biome.atmosphereProfile.fogVariationDistance.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogLightFlareFalloff)
					{
						base.weatherSphere.fogLightFlareFalloff = Mathf.Lerp(base.weatherSphere.fogLightFlareFalloff, biome.atmosphereProfile.fogLightFlareFalloff.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogLightFlareIntensity)
					{
						base.weatherSphere.fogLightFlareIntensity = Mathf.Lerp(base.weatherSphere.fogLightFlareIntensity, biome.atmosphereProfile.fogLightFlareIntensity.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogLightFlareSquish)
					{
						base.weatherSphere.fogLightFlareSquish = Mathf.Lerp(base.weatherSphere.fogLightFlareSquish, biome.atmosphereProfile.fogLightFlareSquish.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.galaxy1Color)
					{
						base.weatherSphere.galaxy1Color = Color.Lerp(base.weatherSphere.galaxy1Color, biome.atmosphereProfile.galaxy1Color.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.galaxy2Color)
					{
						base.weatherSphere.galaxy2Color = Color.Lerp(base.weatherSphere.galaxy2Color, biome.atmosphereProfile.galaxy2Color.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.galaxy3Color)
					{
						base.weatherSphere.galaxy3Color = Color.Lerp(base.weatherSphere.galaxy3Color, biome.atmosphereProfile.galaxy3Color.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.galaxyIntensity)
					{
						base.weatherSphere.galaxyIntensity = Mathf.Lerp(base.weatherSphere.galaxyIntensity, biome.atmosphereProfile.galaxyIntensity.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.highAltitudeCloudColor)
					{
						base.weatherSphere.highAltitudeCloudColor = Color.Lerp(base.weatherSphere.highAltitudeCloudColor, biome.atmosphereProfile.highAltitudeCloudColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.lightScatteringColor)
					{
						base.weatherSphere.lightScatteringColor = Color.Lerp(base.weatherSphere.lightScatteringColor, biome.atmosphereProfile.lightScatteringColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.moonlightColor)
					{
						base.weatherSphere.moonlightColor = Color.Lerp(base.weatherSphere.moonlightColor, biome.atmosphereProfile.moonlightColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.moonColor)
					{
						base.weatherSphere.moonColor = Color.Lerp(base.weatherSphere.moonColor, biome.atmosphereProfile.moonColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.moonFalloff)
					{
						base.weatherSphere.moonFalloff = Mathf.Lerp(base.weatherSphere.moonFalloff, biome.atmosphereProfile.moonFalloff.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.moonFlareColor)
					{
						base.weatherSphere.moonFlareColor = Color.Lerp(base.weatherSphere.moonFlareColor, biome.atmosphereProfile.moonFlareColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.rainbowPosition)
					{
						base.weatherSphere.rainbowPosition = Mathf.Lerp(base.weatherSphere.rainbowPosition, biome.atmosphereProfile.rainbowPosition.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.rainbowWidth)
					{
						base.weatherSphere.rainbowWidth = Mathf.Lerp(base.weatherSphere.rainbowWidth, biome.atmosphereProfile.rainbowWidth.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.shadowDistance)
					{
						base.weatherSphere.shadowDistance = Mathf.Lerp(base.weatherSphere.shadowDistance, biome.atmosphereProfile.shadowDistance.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.skyHorizonColor)
					{
						base.weatherSphere.skyHorizonColor = Color.Lerp(base.weatherSphere.skyHorizonColor, biome.atmosphereProfile.skyHorizonColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.skyZenithColor)
					{
						base.weatherSphere.skyZenithColor = Color.Lerp(base.weatherSphere.skyZenithColor, biome.atmosphereProfile.skyZenithColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.spherize)
					{
						base.weatherSphere.spherize = Mathf.Lerp(base.weatherSphere.spherize, biome.atmosphereProfile.spherize.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.starColor)
					{
						base.weatherSphere.starColor = Color.Lerp(base.weatherSphere.starColor, biome.atmosphereProfile.starColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.sunColor)
					{
						base.weatherSphere.sunColor = Color.Lerp(base.weatherSphere.sunColor, biome.atmosphereProfile.sunColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.sunDirection)
					{
						base.weatherSphere.sunDirection = Mathf.Lerp(base.weatherSphere.sunDirection, biome.atmosphereProfile.sunDirection.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.sunFalloff)
					{
						base.weatherSphere.sunFalloff = Mathf.Lerp(base.weatherSphere.sunFalloff, biome.atmosphereProfile.sunFalloff.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.sunFlareColor)
					{
						base.weatherSphere.sunFlareColor = Color.Lerp(base.weatherSphere.sunFlareColor, biome.atmosphereProfile.sunFlareColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.sunlightColor)
					{
						base.weatherSphere.sunlightColor = Color.Lerp(base.weatherSphere.sunlightColor, biome.atmosphereProfile.sunlightColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.sunPitch)
					{
						base.weatherSphere.sunPitch = Mathf.Lerp(base.weatherSphere.sunPitch, biome.atmosphereProfile.sunPitch.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.sunSize)
					{
						base.weatherSphere.sunSize = Mathf.Lerp(base.weatherSphere.sunSize, biome.atmosphereProfile.sunSize.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.textureAmount)
					{
						base.weatherSphere.textureAmount = Mathf.Lerp(base.weatherSphere.textureAmount, biome.atmosphereProfile.textureAmount.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogSmoothness)
					{
						base.weatherSphere.fogSmoothness = Mathf.Lerp(base.weatherSphere.fogSmoothness, biome.atmosphereProfile.fogSmoothness.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.fogBase)
					{
						base.weatherSphere.fogBase = Mathf.Lerp(base.weatherSphere.fogBase, biome.atmosphereProfile.fogBase.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.heightFogColor)
					{
						base.weatherSphere.heightFogColor = Color.Lerp(base.weatherSphere.heightFogColor, biome.atmosphereProfile.heightFogColor.GetColorValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.heightFogDistance)
					{
						base.weatherSphere.heightFogDistance = Mathf.Lerp(base.weatherSphere.heightFogDistance, biome.atmosphereProfile.heightFogDistance.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.heightFogIntensity)
					{
						base.weatherSphere.heightFogIntensity = Mathf.Lerp(base.weatherSphere.heightFogIntensity, biome.atmosphereProfile.heightFogIntensity.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.heightFogTransition)
					{
						base.weatherSphere.heightFogTransition = Mathf.Lerp(base.weatherSphere.heightFogTransition, biome.atmosphereProfile.heightFogTransition.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.heightFogVariationAmount)
					{
						base.weatherSphere.heightFogVariationAmount = Mathf.Lerp(base.weatherSphere.heightFogVariationAmount, biome.atmosphereProfile.heightFogVariationAmount.GetFloatValue(time), biome.weight);
					}
					if ((bool)biome.atmosphereProfile.heightFogVariationScale)
					{
						base.weatherSphere.heightFogVariationScale = Mathf.Lerp(base.weatherSphere.heightFogVariationScale, biome.atmosphereProfile.heightFogVariationScale.GetFloatValue(time), biome.weight);
					}
				}
			}
		}

		public void ChangeAtmosphere(AtmosphereProfile end, float transitionTime)
		{
			StartCoroutine(TransitionAtmosphere(end, transitionTime));
		}

		private IEnumerator TransitionAtmosphere(AtmosphereProfile end, float transitionTime)
		{
			float gradientExponentStart = base.weatherSphere.gradientExponent;
			float acScaleStart = base.weatherSphere.acScale;
			Color ambientLightHorizonColorStart = base.weatherSphere.ambientLightHorizonColor;
			Color ambientLightZenithColorStart = base.weatherSphere.ambientLightZenithColor;
			float ambientLightMultiplierStart = base.weatherSphere.ambientLightMultiplier;
			float chemtrailsMoveSpeedStart = base.weatherSphere.chemtrailsMoveSpeed;
			float cirroMoveSpeedStart = base.weatherSphere.cirroMoveSpeed;
			float cirrusMoveSpeedStart = base.weatherSphere.cirrusMoveSpeed;
			float clippingThresholdStart = base.weatherSphere.clippingThreshold;
			float cloudCohesionStart = base.weatherSphere.cloudCohesion;
			Color cloudColorStart = base.weatherSphere.cloudColor;
			float cloudDetailAmountStart = base.weatherSphere.cloudDetailAmount;
			float cloudDetailScaleStart = base.weatherSphere.cloudDetailScale;
			Color cloudHighlightColorStart = base.weatherSphere.cloudHighlightColor;
			float cloudMainScaleStart = base.weatherSphere.cloudMainScale;
			Color cloudMoonColorStart = base.weatherSphere.cloudMoonColor;
			float cloudMoonHighlightFalloffStart = base.weatherSphere.cloudMoonHighlightFalloff;
			float cloudSunHighlightFalloffStart = base.weatherSphere.cloudSunHighlightFalloff;
			Color cloudTextureColorStart = base.weatherSphere.cloudTextureColor;
			float cloudThicknessStart = base.weatherSphere.cloudThickness;
			float cloudWindSpeedStart = base.weatherSphere.cloudWindSpeed;
			Color fogColor1Start = base.weatherSphere.fogColor1;
			Color fogColor2Start = base.weatherSphere.fogColor2;
			Color fogColor3Start = base.weatherSphere.fogColor3;
			Color fogColor4Start = base.weatherSphere.fogColor4;
			Color fogColor5Start = base.weatherSphere.fogColor5;
			float fogStart1Start = base.weatherSphere.fogStart1;
			float fogStart2Start = base.weatherSphere.fogStart2;
			float fogStart3Start = base.weatherSphere.fogStart3;
			float fogStart4Start = base.weatherSphere.fogStart4;
			float fogDensityMultiplierStart = base.weatherSphere.fogDensityMultiplier;
			Color fogFlareColorStart = base.weatherSphere.fogFlareColor;
			float fogHeightStart = base.weatherSphere.fogHeight;
			float fogLightFlareFalloffStart = base.weatherSphere.fogLightFlareFalloff;
			float fogLightFlareIntensityStart = base.weatherSphere.fogLightFlareIntensity;
			float fogLightFlareSquishStart = base.weatherSphere.fogLightFlareSquish;
			Color galaxy1ColorStart = base.weatherSphere.galaxy1Color;
			Color galaxy2ColorStart = base.weatherSphere.galaxy2Color;
			Color galaxy3ColorStart = base.weatherSphere.galaxy3Color;
			Color highAltitudeCloudColorStart = base.weatherSphere.highAltitudeCloudColor;
			Color lightScatteringColorStart = base.weatherSphere.lightScatteringColor;
			Color moonlightColorStart = base.weatherSphere.moonlightColor;
			Color moonFlareColorStart = base.weatherSphere.moonFlareColor;
			Color skyHorizonColorStart = base.weatherSphere.skyHorizonColor;
			Color skyZenithColorStart = base.weatherSphere.skyZenithColor;
			Color starColorStart = base.weatherSphere.starColor;
			Color sunColorStart = base.weatherSphere.sunColor;
			Color sunFlareColorStart = base.weatherSphere.sunFlareColor;
			Color sunlightColorStart = base.weatherSphere.sunlightColor;
			float galaxyIntensityStart = base.weatherSphere.galaxyIntensity;
			float moonFalloffStart = base.weatherSphere.moonFalloff;
			float rainbowPositionStart = base.weatherSphere.rainbowPosition;
			float rainbowWidthStart = base.weatherSphere.rainbowWidth;
			float shadowDistanceStart = base.weatherSphere.shadowDistance;
			float spherizeStart = base.weatherSphere.spherize;
			float sunDirectionStart = base.weatherSphere.sunDirection;
			float sunFalloffStart = base.weatherSphere.sunFalloff;
			float sunPitchStart = base.weatherSphere.sunPitch;
			float sunSizeStart = base.weatherSphere.sunSize;
			float textureAmountStart = base.weatherSphere.textureAmount;
			transitioningAtmosphere = true;
			for (float t = transitionTime; t > 0f; t -= Time.deltaTime)
			{
				float div = 1f - t / transitionTime;
				yield return new WaitForEndOfFrame();
				base.weatherSphere.gradientExponent = Mathf.Lerp(gradientExponentStart, end.gradientExponent.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.acScale = Mathf.Lerp(acScaleStart, end.acScale.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.ambientLightHorizonColor = Color.Lerp(ambientLightHorizonColorStart, end.ambientLightHorizonColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.ambientLightZenithColor = Color.Lerp(ambientLightZenithColorStart, end.ambientLightZenithColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.ambientLightMultiplier = Mathf.Lerp(ambientLightMultiplierStart, end.ambientLightMultiplier.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.chemtrailsMoveSpeed = Mathf.Lerp(chemtrailsMoveSpeedStart, end.chemtrailsMoveSpeed.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.cirroMoveSpeed = Mathf.Lerp(cirroMoveSpeedStart, end.cirroMoveSpeed.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.cirrusMoveSpeed = Mathf.Lerp(cirrusMoveSpeedStart, end.cirrusMoveSpeed.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.clippingThreshold = Mathf.Lerp(clippingThresholdStart, end.clippingThreshold.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.cloudCohesion = Mathf.Lerp(cloudCohesionStart, end.cloudCohesion.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.cloudColor = Color.Lerp(cloudColorStart, end.cloudColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.cloudDetailAmount = Mathf.Lerp(cloudDetailAmountStart, end.cloudDetailAmount.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.cloudDetailScale = Mathf.Lerp(cloudDetailScaleStart, end.cloudDetailScale.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.cloudHighlightColor = Color.Lerp(cloudHighlightColorStart, end.cloudHighlightColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.cloudMainScale = Mathf.Lerp(cloudMainScaleStart, end.cloudMainScale.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.cloudMoonColor = Color.Lerp(cloudMoonColorStart, end.cloudMoonColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.cloudMoonHighlightFalloff = Mathf.Lerp(cloudMoonHighlightFalloffStart, end.cloudMoonHighlightFalloff.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.cloudSunHighlightFalloff = Mathf.Lerp(cloudSunHighlightFalloffStart, end.cloudSunHighlightFalloff.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.cloudTextureColor = Color.Lerp(cloudTextureColorStart, end.cloudTextureColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.cloudThickness = Mathf.Lerp(cloudThicknessStart, end.cloudThickness.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.cloudWindSpeed = Mathf.Lerp(cloudWindSpeedStart, end.cloudWindSpeed.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogColor1 = Color.Lerp(fogColor1Start, end.fogColor1.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogColor2 = Color.Lerp(fogColor2Start, end.fogColor2.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogColor3 = Color.Lerp(fogColor3Start, end.fogColor3.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogColor4 = Color.Lerp(fogColor4Start, end.fogColor4.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogColor5 = Color.Lerp(fogColor5Start, end.fogColor5.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogStart1 = Mathf.Lerp(fogStart1Start, end.fogStart1.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogStart2 = Mathf.Lerp(fogStart2Start, end.fogStart2.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogStart3 = Mathf.Lerp(fogStart3Start, end.fogStart3.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogStart4 = Mathf.Lerp(fogStart4Start, end.fogStart4.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogDensityMultiplier = Mathf.Lerp(fogDensityMultiplierStart, end.fogDensityMultiplier.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogFlareColor = Color.Lerp(fogFlareColorStart, end.fogFlareColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogHeight = Mathf.Lerp(fogHeightStart, end.fogHeight.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogLightFlareFalloff = Mathf.Lerp(fogLightFlareFalloffStart, end.fogLightFlareFalloff.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogLightFlareIntensity = Mathf.Lerp(fogLightFlareIntensityStart, end.fogLightFlareIntensity.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.fogLightFlareSquish = Mathf.Lerp(fogLightFlareSquishStart, end.fogLightFlareSquish.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.galaxy1Color = Color.Lerp(galaxy1ColorStart, end.galaxy1Color.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.galaxy2Color = Color.Lerp(galaxy2ColorStart, end.galaxy2Color.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.galaxy3Color = Color.Lerp(galaxy3ColorStart, end.galaxy3Color.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.galaxyIntensity = Mathf.Lerp(galaxyIntensityStart, end.galaxyIntensity.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.highAltitudeCloudColor = Color.Lerp(highAltitudeCloudColorStart, end.highAltitudeCloudColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.lightScatteringColor = Color.Lerp(lightScatteringColorStart, end.lightScatteringColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.moonlightColor = Color.Lerp(moonlightColorStart, end.moonlightColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.moonFalloff = Mathf.Lerp(moonFalloffStart, end.moonFalloff.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.moonFlareColor = Color.Lerp(moonFlareColorStart, end.moonFlareColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.rainbowPosition = Mathf.Lerp(rainbowPositionStart, end.rainbowPosition.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.rainbowWidth = Mathf.Lerp(rainbowWidthStart, end.rainbowWidth.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.shadowDistance = Mathf.Lerp(shadowDistanceStart, end.shadowDistance.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.skyHorizonColor = Color.Lerp(skyHorizonColorStart, end.skyHorizonColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.skyZenithColor = Color.Lerp(skyZenithColorStart, end.skyZenithColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.spherize = Mathf.Lerp(spherizeStart, end.spherize.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.starColor = Color.Lerp(starColorStart, end.starColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.sunColor = Color.Lerp(sunColorStart, end.sunColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.sunDirection = Mathf.Lerp(sunDirectionStart, end.sunDirection.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.sunFalloff = Mathf.Lerp(sunFalloffStart, end.sunFalloff.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.sunFlareColor = Color.Lerp(sunFlareColorStart, end.sunFlareColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.sunlightColor = Color.Lerp(sunlightColorStart, end.sunlightColor.GetColorValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.sunPitch = Mathf.Lerp(sunPitchStart, end.sunPitch.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.sunSize = Mathf.Lerp(sunSizeStart, end.sunSize.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
				base.weatherSphere.textureAmount = Mathf.Lerp(textureAmountStart, end.textureAmount.GetFloatValue(base.weatherSphere.modifiedDayPercentage), div);
			}
			transitioningAtmosphere = false;
			atmosphereProfile = end;
		}
	}
}
