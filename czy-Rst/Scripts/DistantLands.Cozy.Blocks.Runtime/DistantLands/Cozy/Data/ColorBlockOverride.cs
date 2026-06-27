using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Color Block Override", order = 361)]
	public class ColorBlockOverride : BlocksBlendable
	{
		[Tooltip("Sets the color of the zenith (or top) of the skybox at a certain time. Starts and ends at midnight.")]
		public Overridable<Color> skyZenithColor;

		[Tooltip("Sets the color of the horizon (or middle) of the skybox at a certain time. Starts and ends at midnight.")]
		public Overridable<Color> skyHorizonColor;

		[Tooltip("Sets the main color of the clouds at a certain time. Starts and ends at midnight.")]
		public Overridable<Color> cloudColor;

		[Tooltip("Sets the highlight color of the clouds at a certain time. Starts and ends at midnight.")]
		public Overridable<Color> cloudHighlightColor;

		[Tooltip("Sets the color of the high altitude clouds at a certain time. Starts and ends at midnight.")]
		public Overridable<Color> highAltitudeCloudColor;

		[Tooltip("Sets the color of the sun light source at a certain time. Starts and ends at midnight.")]
		public Overridable<Color> sunlightColor;

		[Tooltip("Sets the color of the moon light source at a certain time. Starts and ends at midnight.")]
		public Overridable<Color> moonlightColor;

		[Tooltip("Sets the color of the star particle FX and textures at a certain time. Starts and ends at midnight.")]
		public Overridable<Color> starColor;

		[Tooltip("Sets the color of the zenith (or top) of the ambient scene lighting at a certain time. Starts and ends at midnight.")]
		public Overridable<Color> ambientLightHorizonColor;

		[Tooltip("Sets the color of the horizon (or middle) of the ambient scene lighting at a certain time. Starts and ends at midnight.")]
		public Overridable<Color> ambientLightZenithColor;

		[Tooltip("Multiplies the ambient light intensity.")]
		[OverrideRange(0f, 4f)]
		public Overridable<float> ambientLightMultiplier;

		[Tooltip("Sets the intensity of the galaxy effects at a certain time. Starts and ends at midnight.")]
		[OverrideRange(0f, 1f)]
		public Overridable<float> galaxyIntensity;

		public Overridable<float> fogDensity = 1f;

		public Overridable<float> fogVariationAmount = 1f;

		[Tooltip("Sets the fog color from 0m away from the camera to fog start 1.")]
		public Overridable<Color> fogColor1;

		[Tooltip("Sets the fog color from fog start 1 to fog start 2.")]
		public Overridable<Color> fogColor2;

		[Tooltip("Sets the fog color from fog start 2 to fog start 3.")]
		public Overridable<Color> fogColor3;

		[Tooltip("Sets the fog color from fog start 3 to fog start 4.")]
		public Overridable<Color> fogColor4;

		[Tooltip("Sets the fog color from fog start 4 to fog start 5.")]
		public Overridable<Color> fogColor5;

		[Tooltip("Sets the color of the fog flare.")]
		public Overridable<Color> fogFlareColor;

		[OverrideRange(0f, 1f)]
		[Tooltip("Controls the exponent used to modulate from the horizon color to the zenith color of the sky.")]
		public Overridable<float> gradientExponent;

		[OverrideRange(0f, 5f)]
		[Tooltip("Sets the size of the visual sun in the sky.")]
		public Overridable<float> sunSize;

		[Tooltip("Sets the color of the visual sun in the sky.")]
		public Overridable<Color> sunColor;

		[OverrideRange(0f, 100f)]
		[Tooltip("Sets the falloff of the halo around the visual sun.")]
		public Overridable<float> sunFalloff;

		[Tooltip("Sets the color of the halo around the visual sun.")]
		public Overridable<Color> sunFlareColor;

		[OverrideRange(0f, 100f)]
		[Tooltip("Sets the falloff of the halo around the main moon.")]
		public Overridable<float> moonFalloff;

		[Tooltip("Sets the color of the halo around the main moon.")]
		public Overridable<Color> moonFlareColor;

		[Tooltip("Sets the color of the first galaxy algorithm.")]
		public Overridable<Color> galaxy1Color;

		[Tooltip("Sets the color of the second galaxy algorithm.")]
		public Overridable<Color> galaxy2Color;

		[Tooltip("Sets the color of the third galaxy algorithm.")]
		public Overridable<Color> galaxy3Color;

		[Tooltip("Sets the color of the light columns around the horizon.")]
		public Overridable<Color> lightScatteringColor;

		[Tooltip("Sets the distance at which the first fog color fades into the second fog color.")]
		[OverrideRange(0f, 50f)]
		public Overridable<float> fogStart1;

		[OverrideRange(0f, 50f)]
		public Overridable<float> fogStart2;

		[OverrideRange(0f, 50f)]
		public Overridable<float> fogStart3;

		[OverrideRange(0f, 50f)]
		public Overridable<float> fogStart4;

		[OverrideRange(0f, 2f)]
		public Overridable<float> fogHeight;

		[OverrideRange(0f, 1f)]
		public Overridable<float> fogSmoothness = 0.5f;

		[OverrideRange(0f, 2f)]
		public Overridable<float> fogLightFlareIntensity;

		[OverrideRange(0f, 40f)]
		public Overridable<float> fogLightFlareFalloff;

		[OverrideRange(0f, 10f)]
		[Tooltip("Sets the height divisor for the fog flare. High values sit the flare closer to the horizon, small values extend the flare into the sky.")]
		public Overridable<float> fogLightFlareSquish;

		public Overridable<Color> cloudMoonColor;

		[OverrideRange(0f, 50f)]
		public Overridable<float> cloudSunHighlightFalloff;

		[OverrideRange(0f, 50f)]
		public Overridable<float> cloudMoonHighlightFalloff;

		public Overridable<Color> cloudTextureColor;

		public ColorBlockExtension extension;

		public override void PullFromAtmosphere()
		{
			CozyWeather instance = CozyWeather.instance;
			_ = (float)CozyWeather.instance.timeModule.currentTime;
			gradientExponent = instance.gradientExponent;
			ambientLightHorizonColor = instance.ambientLightHorizonColor;
			ambientLightZenithColor = instance.ambientLightZenithColor;
			ambientLightMultiplier = instance.ambientLightMultiplier;
			cloudColor = instance.cloudColor;
			cloudHighlightColor = instance.cloudHighlightColor;
			cloudMoonColor = instance.cloudMoonColor;
			cloudMoonHighlightFalloff = instance.cloudMoonHighlightFalloff;
			cloudSunHighlightFalloff = instance.cloudSunHighlightFalloff;
			cloudTextureColor = instance.cloudTextureColor;
			fogColor1 = instance.fogColor1;
			fogColor2 = instance.fogColor2;
			fogColor3 = instance.fogColor3;
			fogColor4 = instance.fogColor4;
			fogColor5 = instance.fogColor5;
			fogStart1 = instance.fogStart1;
			fogStart2 = instance.fogStart2;
			fogStart3 = instance.fogStart3;
			fogStart4 = instance.fogStart4;
			fogFlareColor = instance.fogFlareColor;
			fogHeight = instance.fogHeight;
			fogSmoothness = instance.fogSmoothness;
			fogVariationAmount = instance.fogVariationAmount;
			fogLightFlareFalloff = instance.fogLightFlareFalloff;
			fogLightFlareIntensity = instance.fogLightFlareIntensity;
			fogLightFlareSquish = instance.fogLightFlareSquish;
			galaxy1Color = instance.galaxy1Color;
			galaxy2Color = instance.galaxy2Color;
			galaxy3Color = instance.galaxy3Color;
			galaxyIntensity = instance.galaxyIntensity;
			highAltitudeCloudColor = instance.highAltitudeCloudColor;
			lightScatteringColor = instance.lightScatteringColor;
			moonlightColor = instance.moonlightColor;
			moonFalloff = instance.moonFalloff;
			moonFlareColor = instance.moonFlareColor;
			skyHorizonColor = instance.skyHorizonColor;
			skyZenithColor = instance.skyZenithColor;
			starColor = instance.starColor;
			sunColor = instance.sunColor;
			sunFalloff = instance.sunFalloff;
			sunFlareColor = instance.sunFlareColor;
			sunlightColor = instance.sunlightColor;
			sunSize = instance.sunSize;
			if (extension != null)
			{
				extension.PullFromWorld();
			}
		}

		public override ColorBlock GetValues(BlocksModule module)
		{
			float modifiedDayPercentage = module.weatherSphere.modifiedDayPercentage;
			ColorBlock colorBlock = ScriptableObject.CreateInstance<ColorBlock>();
			colorBlock.ambientLightHorizonColor = (ambientLightHorizonColor ? ((Color)ambientLightHorizonColor) : module.defaultSettings.ambientLightHorizonColor.GetColorValue(modifiedDayPercentage));
			colorBlock.ambientLightZenithColor = (ambientLightZenithColor ? ((Color)ambientLightZenithColor) : module.defaultSettings.ambientLightZenithColor.GetColorValue(modifiedDayPercentage));
			colorBlock.ambientLightMultiplier = (ambientLightMultiplier ? ((float)ambientLightMultiplier) : module.defaultSettings.ambientLightMultiplier.GetFloatValue(modifiedDayPercentage));
			colorBlock.cloudColor = (cloudColor ? ((Color)cloudColor) : module.defaultSettings.cloudColor.GetColorValue(modifiedDayPercentage));
			colorBlock.cloudHighlightColor = (cloudHighlightColor ? ((Color)cloudHighlightColor) : module.defaultSettings.cloudHighlightColor.GetColorValue(modifiedDayPercentage));
			colorBlock.cloudMoonColor = (cloudMoonColor ? ((Color)cloudMoonColor) : module.defaultSettings.cloudMoonColor.GetColorValue(modifiedDayPercentage));
			colorBlock.cloudMoonHighlightFalloff = (cloudMoonHighlightFalloff ? ((float)cloudMoonHighlightFalloff) : module.defaultSettings.cloudMoonHighlightFalloff.GetFloatValue(modifiedDayPercentage));
			colorBlock.cloudSunHighlightFalloff = (cloudSunHighlightFalloff ? ((float)cloudSunHighlightFalloff) : module.defaultSettings.cloudSunHighlightFalloff.GetFloatValue(modifiedDayPercentage));
			colorBlock.cloudTextureColor = (cloudTextureColor ? ((Color)cloudTextureColor) : module.defaultSettings.cloudTextureColor.GetColorValue(modifiedDayPercentage));
			colorBlock.fogColor1 = (fogColor1 ? ((Color)fogColor1) : module.defaultSettings.fogColor1.GetColorValue(modifiedDayPercentage));
			colorBlock.fogColor2 = (fogColor2 ? ((Color)fogColor2) : module.defaultSettings.fogColor2.GetColorValue(modifiedDayPercentage));
			colorBlock.fogColor3 = (fogColor3 ? ((Color)fogColor3) : module.defaultSettings.fogColor3.GetColorValue(modifiedDayPercentage));
			colorBlock.fogColor4 = (fogColor4 ? ((Color)fogColor4) : module.defaultSettings.fogColor4.GetColorValue(modifiedDayPercentage));
			colorBlock.fogColor5 = (fogColor5 ? ((Color)fogColor5) : module.defaultSettings.fogColor5.GetColorValue(modifiedDayPercentage));
			colorBlock.fogStart1 = (fogStart1 ? ((float)fogStart1) : module.defaultSettings.fogStart1.GetFloatValue(modifiedDayPercentage));
			colorBlock.fogStart2 = (fogStart2 ? ((float)fogStart2) : module.defaultSettings.fogStart2.GetFloatValue(modifiedDayPercentage));
			colorBlock.fogStart3 = (fogStart3 ? ((float)fogStart3) : module.defaultSettings.fogStart3.GetFloatValue(modifiedDayPercentage));
			colorBlock.fogStart4 = (fogStart4 ? ((float)fogStart4) : module.defaultSettings.fogStart4.GetFloatValue(modifiedDayPercentage));
			colorBlock.fogFlareColor = (fogFlareColor ? ((Color)fogFlareColor) : module.defaultSettings.fogFlareColor.GetColorValue(modifiedDayPercentage));
			colorBlock.fogHeight = (fogHeight ? ((float)fogHeight) : module.defaultSettings.fogHeight.GetFloatValue(modifiedDayPercentage));
			colorBlock.fogSmoothness = (fogSmoothness ? ((float)fogSmoothness) : module.defaultSettings.fogSmoothness.GetFloatValue(modifiedDayPercentage));
			colorBlock.fogDensity = (fogDensity ? ((float)fogDensity) : module.defaultSettings.fogDensityMultiplier.GetFloatValue(modifiedDayPercentage));
			colorBlock.fogVariationAmount = (fogVariationAmount ? ((float)fogVariationAmount) : module.defaultSettings.fogVariationAmount.GetFloatValue(modifiedDayPercentage));
			colorBlock.fogLightFlareFalloff = (fogLightFlareFalloff ? ((float)fogLightFlareFalloff) : module.defaultSettings.fogLightFlareFalloff.GetFloatValue(modifiedDayPercentage));
			colorBlock.fogLightFlareIntensity = (fogLightFlareIntensity ? ((float)fogLightFlareIntensity) : module.defaultSettings.fogLightFlareIntensity.GetFloatValue(modifiedDayPercentage));
			colorBlock.fogLightFlareSquish = (fogLightFlareSquish ? ((float)fogLightFlareSquish) : module.defaultSettings.fogLightFlareSquish.GetFloatValue(modifiedDayPercentage));
			colorBlock.galaxy1Color = (galaxy1Color ? ((Color)galaxy1Color) : module.defaultSettings.galaxy1Color.GetColorValue(modifiedDayPercentage));
			colorBlock.galaxy2Color = (galaxy2Color ? ((Color)galaxy2Color) : module.defaultSettings.galaxy2Color.GetColorValue(modifiedDayPercentage));
			colorBlock.galaxy3Color = (galaxy3Color ? ((Color)galaxy3Color) : module.defaultSettings.galaxy3Color.GetColorValue(modifiedDayPercentage));
			colorBlock.galaxyIntensity = (galaxyIntensity ? ((float)galaxyIntensity) : module.defaultSettings.galaxyIntensity.GetFloatValue(modifiedDayPercentage));
			colorBlock.highAltitudeCloudColor = (highAltitudeCloudColor ? ((Color)highAltitudeCloudColor) : module.defaultSettings.highAltitudeCloudColor.GetColorValue(modifiedDayPercentage));
			colorBlock.lightScatteringColor = (lightScatteringColor ? ((Color)lightScatteringColor) : module.defaultSettings.lightScatteringColor.GetColorValue(modifiedDayPercentage));
			colorBlock.moonlightColor = (moonlightColor ? ((Color)moonlightColor) : module.defaultSettings.moonlightColor.GetColorValue(modifiedDayPercentage));
			colorBlock.moonFalloff = (moonFalloff ? ((float)moonFalloff) : module.defaultSettings.moonFalloff.GetFloatValue(modifiedDayPercentage));
			colorBlock.moonFlareColor = (moonFlareColor ? ((Color)moonFlareColor) : module.defaultSettings.moonFlareColor.GetColorValue(modifiedDayPercentage));
			colorBlock.skyHorizonColor = (skyHorizonColor ? ((Color)skyHorizonColor) : module.defaultSettings.skyHorizonColor.GetColorValue(modifiedDayPercentage));
			colorBlock.skyZenithColor = (skyZenithColor ? ((Color)skyZenithColor) : module.defaultSettings.skyZenithColor.GetColorValue(modifiedDayPercentage));
			colorBlock.starColor = (starColor ? ((Color)starColor) : module.defaultSettings.starColor.GetColorValue(modifiedDayPercentage));
			colorBlock.sunColor = (sunColor ? ((Color)sunColor) : module.defaultSettings.sunColor.GetColorValue(modifiedDayPercentage));
			colorBlock.sunFalloff = (sunFalloff ? ((float)sunFalloff) : module.defaultSettings.sunFalloff.GetFloatValue(modifiedDayPercentage));
			colorBlock.sunFlareColor = (sunFlareColor ? ((Color)sunFlareColor) : module.defaultSettings.sunFlareColor.GetColorValue(modifiedDayPercentage));
			colorBlock.sunlightColor = (sunlightColor ? ((Color)sunlightColor) : module.defaultSettings.sunlightColor.GetColorValue(modifiedDayPercentage));
			colorBlock.sunSize = (sunSize ? ((float)sunSize) : module.defaultSettings.sunSize.GetFloatValue(modifiedDayPercentage));
			return colorBlock;
		}

		public override void SingleBlockBlend(BlocksModule module)
		{
			float modifiedDayPercentage = module.weatherSphere.modifiedDayPercentage;
			module.ambientLightHorizonColor = (ambientLightHorizonColor ? ((Color)ambientLightHorizonColor) : module.defaultSettings.ambientLightHorizonColor.GetColorValue(modifiedDayPercentage));
			module.ambientLightZenithColor = (ambientLightZenithColor ? ((Color)ambientLightZenithColor) : module.defaultSettings.ambientLightZenithColor.GetColorValue(modifiedDayPercentage));
			module.ambientLightMultiplier = (ambientLightMultiplier ? ((float)ambientLightMultiplier) : module.defaultSettings.ambientLightMultiplier.GetFloatValue(modifiedDayPercentage));
			module.cloudColor = (cloudColor ? ((Color)cloudColor) : module.defaultSettings.cloudColor.GetColorValue(modifiedDayPercentage));
			module.cloudHighlightColor = (cloudHighlightColor ? ((Color)cloudHighlightColor) : module.defaultSettings.cloudHighlightColor.GetColorValue(modifiedDayPercentage));
			module.cloudMoonColor = (cloudMoonColor ? ((Color)cloudMoonColor) : module.defaultSettings.cloudMoonColor.GetColorValue(modifiedDayPercentage));
			module.cloudMoonHighlightFalloff = (cloudMoonHighlightFalloff ? ((float)cloudMoonHighlightFalloff) : module.defaultSettings.cloudMoonHighlightFalloff.GetFloatValue(modifiedDayPercentage));
			module.cloudSunHighlightFalloff = (cloudSunHighlightFalloff ? ((float)cloudSunHighlightFalloff) : module.defaultSettings.cloudSunHighlightFalloff.GetFloatValue(modifiedDayPercentage));
			module.cloudTextureColor = (cloudTextureColor ? ((Color)cloudTextureColor) : module.defaultSettings.cloudTextureColor.GetColorValue(modifiedDayPercentage));
			module.fogColor1 = (fogColor1 ? ((Color)fogColor1) : module.defaultSettings.fogColor1.GetColorValue(modifiedDayPercentage));
			module.fogColor2 = (fogColor2 ? ((Color)fogColor2) : module.defaultSettings.fogColor2.GetColorValue(modifiedDayPercentage));
			module.fogColor3 = (fogColor3 ? ((Color)fogColor3) : module.defaultSettings.fogColor3.GetColorValue(modifiedDayPercentage));
			module.fogColor4 = (fogColor4 ? ((Color)fogColor4) : module.defaultSettings.fogColor4.GetColorValue(modifiedDayPercentage));
			module.fogColor5 = (fogColor5 ? ((Color)fogColor5) : module.defaultSettings.fogColor5.GetColorValue(modifiedDayPercentage));
			module.fogStart1 = (fogStart1 ? ((float)fogStart1) : module.defaultSettings.fogStart1.GetFloatValue(modifiedDayPercentage));
			module.fogStart2 = (fogStart2 ? ((float)fogStart2) : module.defaultSettings.fogStart2.GetFloatValue(modifiedDayPercentage));
			module.fogStart3 = (fogStart3 ? ((float)fogStart3) : module.defaultSettings.fogStart3.GetFloatValue(modifiedDayPercentage));
			module.fogStart4 = (fogStart4 ? ((float)fogStart4) : module.defaultSettings.fogStart4.GetFloatValue(modifiedDayPercentage));
			module.fogFlareColor = (fogFlareColor ? ((Color)fogFlareColor) : module.defaultSettings.fogFlareColor.GetColorValue(modifiedDayPercentage));
			module.fogHeight = (fogHeight ? ((float)fogHeight) : module.defaultSettings.fogHeight.GetFloatValue(modifiedDayPercentage));
			module.fogSmoothness = (fogSmoothness ? ((float)fogSmoothness) : module.defaultSettings.fogSmoothness.GetFloatValue(modifiedDayPercentage));
			module.fogVariationAmount = (fogVariationAmount ? ((float)fogVariationAmount) : module.defaultSettings.fogVariationAmount.GetFloatValue(modifiedDayPercentage));
			module.fogDensityMultiplier = (fogDensity ? ((float)fogDensity) : module.defaultSettings.fogDensityMultiplier.GetFloatValue(modifiedDayPercentage));
			module.fogLightFlareFalloff = (fogLightFlareFalloff ? ((float)fogLightFlareFalloff) : module.defaultSettings.fogLightFlareFalloff.GetFloatValue(modifiedDayPercentage));
			module.fogLightFlareIntensity = (fogLightFlareIntensity ? ((float)fogLightFlareIntensity) : module.defaultSettings.fogLightFlareIntensity.GetFloatValue(modifiedDayPercentage));
			module.fogLightFlareSquish = (fogLightFlareSquish ? ((float)fogLightFlareSquish) : module.defaultSettings.fogLightFlareSquish.GetFloatValue(modifiedDayPercentage));
			module.galaxy1Color = (galaxy1Color ? ((Color)galaxy1Color) : module.defaultSettings.galaxy1Color.GetColorValue(modifiedDayPercentage));
			module.galaxy2Color = (galaxy2Color ? ((Color)galaxy2Color) : module.defaultSettings.galaxy2Color.GetColorValue(modifiedDayPercentage));
			module.galaxy3Color = (galaxy3Color ? ((Color)galaxy3Color) : module.defaultSettings.galaxy3Color.GetColorValue(modifiedDayPercentage));
			module.galaxyIntensity = (galaxyIntensity ? ((float)galaxyIntensity) : module.defaultSettings.galaxyIntensity.GetFloatValue(modifiedDayPercentage));
			module.highAltitudeCloudColor = (highAltitudeCloudColor ? ((Color)highAltitudeCloudColor) : module.defaultSettings.highAltitudeCloudColor.GetColorValue(modifiedDayPercentage));
			module.lightScatteringColor = (lightScatteringColor ? ((Color)lightScatteringColor) : module.defaultSettings.lightScatteringColor.GetColorValue(modifiedDayPercentage));
			module.moonlightColor = (moonlightColor ? ((Color)moonlightColor) : module.defaultSettings.moonlightColor.GetColorValue(modifiedDayPercentage));
			module.moonFalloff = (moonFalloff ? ((float)moonFalloff) : module.defaultSettings.moonFalloff.GetFloatValue(modifiedDayPercentage));
			module.moonFlareColor = (moonFlareColor ? ((Color)moonFlareColor) : module.defaultSettings.moonFlareColor.GetColorValue(modifiedDayPercentage));
			module.skyHorizonColor = (skyHorizonColor ? ((Color)skyHorizonColor) : module.defaultSettings.skyHorizonColor.GetColorValue(modifiedDayPercentage));
			module.skyZenithColor = (skyZenithColor ? ((Color)skyZenithColor) : module.defaultSettings.skyZenithColor.GetColorValue(modifiedDayPercentage));
			module.starColor = (starColor ? ((Color)starColor) : module.defaultSettings.starColor.GetColorValue(modifiedDayPercentage));
			module.sunColor = (sunColor ? ((Color)sunColor) : module.defaultSettings.sunColor.GetColorValue(modifiedDayPercentage));
			module.sunFalloff = (sunFalloff ? ((float)sunFalloff) : module.defaultSettings.sunFalloff.GetFloatValue(modifiedDayPercentage));
			module.sunFlareColor = (sunFlareColor ? ((Color)sunFlareColor) : module.defaultSettings.sunFlareColor.GetColorValue(modifiedDayPercentage));
			module.sunlightColor = (sunlightColor ? ((Color)sunlightColor) : module.defaultSettings.sunlightColor.GetColorValue(modifiedDayPercentage));
			module.sunSize = (sunSize ? ((float)sunSize) : module.defaultSettings.sunSize.GetFloatValue(modifiedDayPercentage));
			if (extension != null)
			{
				extension.SingleBlock();
			}
		}

		public override void AdjustColors(ColorAdjustment colorMethod, float adjustment)
		{
			skyZenithColor = colorMethod(skyZenithColor, adjustment);
			skyHorizonColor = colorMethod(skyHorizonColor, adjustment);
			cloudColor = colorMethod(cloudColor, adjustment);
			cloudHighlightColor = colorMethod(cloudHighlightColor, adjustment);
			highAltitudeCloudColor = colorMethod(highAltitudeCloudColor, adjustment);
			sunlightColor = colorMethod(sunlightColor, adjustment);
			moonlightColor = colorMethod(moonlightColor, adjustment);
			starColor = colorMethod(starColor, adjustment);
			ambientLightHorizonColor = colorMethod(ambientLightHorizonColor, adjustment);
			ambientLightZenithColor = colorMethod(ambientLightZenithColor, adjustment);
			fogColor1 = colorMethod(fogColor1, adjustment);
			fogColor2 = colorMethod(fogColor2, adjustment);
			fogColor3 = colorMethod(fogColor3, adjustment);
			fogColor4 = colorMethod(fogColor4, adjustment);
			fogColor5 = colorMethod(fogColor5, adjustment);
			fogFlareColor = colorMethod(fogFlareColor, adjustment);
			sunColor = colorMethod(sunColor, adjustment);
			sunFlareColor = colorMethod(sunFlareColor, adjustment);
			moonFlareColor = colorMethod(moonFlareColor, adjustment);
			galaxy1Color = colorMethod(galaxy1Color, adjustment);
			galaxy2Color = colorMethod(galaxy2Color, adjustment);
			galaxy3Color = colorMethod(galaxy3Color, adjustment);
			lightScatteringColor = colorMethod(lightScatteringColor, adjustment);
			cloudMoonColor = colorMethod(cloudMoonColor, adjustment);
		}
	}
}
