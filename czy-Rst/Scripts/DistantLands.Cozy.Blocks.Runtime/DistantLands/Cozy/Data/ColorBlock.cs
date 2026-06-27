using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Color Block", order = 361)]
	public class ColorBlock : BlocksBlendable
	{
		public enum BlockStyle
		{
			advanced = 0,
			simple = 1
		}

		public BlockStyle blockStyle;

		[Tooltip("Sets the color of the zenith (or top) of the skybox at a certain time. Starts and ends at midnight.")]
		[ColorUsage(false, true)]
		public Color skyZenithColor;

		[Tooltip("Sets the color of the horizon (or middle) of the skybox at a certain time. Starts and ends at midnight.")]
		[ColorUsage(false, true)]
		public Color skyHorizonColor;

		[Tooltip("Sets the main color of the clouds at a certain time. Starts and ends at midnight.")]
		[ColorUsage(false, true)]
		public Color cloudColor;

		[Tooltip("Sets the highlight color of the clouds at a certain time. Starts and ends at midnight.")]
		[ColorUsage(false, true)]
		public Color cloudHighlightColor;

		[Tooltip("Sets the color of the high altitude clouds at a certain time. Starts and ends at midnight.")]
		[ColorUsage(false, true)]
		public Color highAltitudeCloudColor;

		[Tooltip("Sets the color of the sun light source at a certain time. Starts and ends at midnight.")]
		[ColorUsage(false, true)]
		public Color sunlightColor;

		[Tooltip("Sets the color of the moon light source at a certain time. Starts and ends at midnight.")]
		[ColorUsage(false, true)]
		public Color moonlightColor;

		[Tooltip("Sets the color of the star particle FX and textures at a certain time. Starts and ends at midnight.")]
		[ColorUsage(false, true)]
		public Color starColor;

		[Tooltip("Sets the color of the zenith (or top) of the ambient scene lighting at a certain time. Starts and ends at midnight.")]
		[ColorUsage(false, true)]
		public Color ambientLightHorizonColor;

		[Tooltip("Sets the color of the horizon (or middle) of the ambient scene lighting at a certain time. Starts and ends at midnight.")]
		[ColorUsage(false, true)]
		public Color ambientLightZenithColor;

		[Tooltip("Multiplies the ambient light intensity.")]
		[Range(0f, 4f)]
		public float ambientLightMultiplier;

		[Tooltip("Sets the intensity of the galaxy effects at a certain time. Starts and ends at midnight.")]
		[Range(0f, 1f)]
		public float galaxyIntensity;

		public float fogDensity = 1f;

		public float fogVariationAmount = 1f;

		[Tooltip("Sets the fog color from 0m away from the camera to fog start 1.")]
		[ColorUsage(true, true)]
		public Color fogColor1;

		[Tooltip("Sets the fog color from fog start 1 to fog start 2.")]
		[ColorUsage(true, true)]
		public Color fogColor2;

		[Tooltip("Sets the fog color from fog start 2 to fog start 3.")]
		[ColorUsage(true, true)]
		public Color fogColor3;

		[Tooltip("Sets the fog color from fog start 3 to fog start 4.")]
		[ColorUsage(true, true)]
		public Color fogColor4;

		[Tooltip("Sets the fog color from fog start 4 to fog start 5.")]
		[ColorUsage(true, true)]
		public Color fogColor5;

		[Tooltip("Sets the color of the fog flare.")]
		[ColorUsage(true, true)]
		public Color fogFlareColor;

		[Range(0f, 1f)]
		[Tooltip("Controls the exponent used to modulate from the horizon color to the zenith color of the sky.")]
		public float gradientExponent;

		[Range(0f, 5f)]
		[Tooltip("Sets the size of the visual sun in the sky.")]
		public float sunSize;

		[Tooltip("Sets the color of the visual sun in the sky.")]
		[ColorUsage(false, true)]
		public Color sunColor;

		[Range(0f, 100f)]
		[Tooltip("Sets the falloff of the halo around the visual sun.")]
		public float sunFalloff;

		[Tooltip("Sets the color of the halo around the visual sun.")]
		[ColorUsage(false, true)]
		public Color sunFlareColor;

		[Range(0f, 100f)]
		[Tooltip("Sets the falloff of the halo around the main moon.")]
		public float moonFalloff;

		[Tooltip("Sets the color of the halo around the main moon.")]
		[ColorUsage(false, true)]
		public Color moonFlareColor;

		[Tooltip("Sets the color of the first galaxy algorithm.")]
		[ColorUsage(false, true)]
		public Color galaxy1Color;

		[Tooltip("Sets the color of the second galaxy algorithm.")]
		[ColorUsage(false, true)]
		public Color galaxy2Color;

		[Tooltip("Sets the color of the third galaxy algorithm.")]
		[ColorUsage(false, true)]
		public Color galaxy3Color;

		[Tooltip("Sets the color of the light columns around the horizon.")]
		[ColorUsage(false, true)]
		public Color lightScatteringColor;

		[Tooltip("Sets the distance at which the first fog color fades into the second fog color.")]
		public float fogStart1;

		public float fogStart2;

		public float fogStart3;

		public float fogStart4;

		[Range(0f, 2f)]
		public float fogHeight;

		[Range(0f, 1f)]
		public float fogSmoothness = 0.5f;

		[Range(0f, 2f)]
		public float fogLightFlareIntensity;

		[Range(0f, 40f)]
		public float fogLightFlareFalloff;

		[Range(0f, 10f)]
		[Tooltip("Sets the height divisor for the fog flare. High values sit the flare closer to the horizon, small values extend the flare into the sky.")]
		public float fogLightFlareSquish;

		[ColorUsage(false, true)]
		public Color cloudMoonColor;

		[Range(0f, 50f)]
		public float cloudSunHighlightFalloff;

		[Range(0f, 50f)]
		public float cloudMoonHighlightFalloff;

		[ColorUsage(false, true)]
		public Color cloudTextureColor;

		public ColorBlockExtension extension;

		[ColorUsage(false, true)]
		[Tooltip("Controls the color for the skybox")]
		public Color skyColor;

		[ColorUsage(false, true)]
		[Tooltip("Controls the color for the fog")]
		public Color fogColor;

		[ColorUsage(false, true)]
		public Color simpleSunColor;

		[ColorUsage(false, true)]
		public Color simpleCloudColor;

		[ColorUsage(false, true)]
		public Color moonColor;

		[Tooltip("Controls the amount of night FX in the scene")]
		public float nightFXAmount;

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

		public override void SingleBlockBlend(BlocksModule module)
		{
			module.gradientExponent = gradientExponent;
			module.ambientLightHorizonColor = ambientLightHorizonColor;
			module.ambientLightZenithColor = ambientLightZenithColor;
			module.ambientLightMultiplier = ambientLightMultiplier;
			module.cloudColor = cloudColor;
			module.cloudHighlightColor = cloudHighlightColor;
			module.cloudMoonColor = cloudMoonColor;
			module.cloudMoonHighlightFalloff = cloudMoonHighlightFalloff;
			module.cloudSunHighlightFalloff = cloudSunHighlightFalloff;
			module.cloudTextureColor = cloudTextureColor;
			module.fogColor1 = fogColor1;
			module.fogColor2 = fogColor2;
			module.fogColor3 = fogColor3;
			module.fogColor4 = fogColor4;
			module.fogColor5 = fogColor5;
			module.fogStart1 = fogStart1;
			module.fogStart2 = fogStart2;
			module.fogStart3 = fogStart3;
			module.fogStart4 = fogStart4;
			module.fogFlareColor = fogFlareColor;
			module.fogHeight = fogHeight;
			module.fogSmoothness = fogSmoothness;
			module.fogVariationAmount = fogVariationAmount;
			module.fogDensityMultiplier = fogDensity;
			module.fogLightFlareFalloff = fogLightFlareFalloff;
			module.fogLightFlareIntensity = fogLightFlareIntensity;
			module.fogLightFlareSquish = fogLightFlareSquish;
			module.galaxy1Color = galaxy1Color;
			module.galaxy2Color = galaxy2Color;
			module.galaxy3Color = galaxy3Color;
			module.galaxyIntensity = galaxyIntensity;
			module.highAltitudeCloudColor = highAltitudeCloudColor;
			module.lightScatteringColor = lightScatteringColor;
			module.moonlightColor = moonlightColor;
			module.moonFalloff = moonFalloff;
			module.moonFlareColor = moonFlareColor;
			module.skyHorizonColor = skyHorizonColor;
			module.skyZenithColor = skyZenithColor;
			module.starColor = starColor;
			module.sunColor = sunColor;
			module.sunFalloff = sunFalloff;
			module.sunFlareColor = sunFlareColor;
			module.sunlightColor = sunlightColor;
			module.sunSize = sunSize;
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

		public override ColorBlock GetValues(BlocksModule module)
		{
			return this;
		}

		public static void ConvertToOverride(ColorBlock instance)
		{
			ColorBlockOverride colorBlockOverride = ScriptableObject.CreateInstance<ColorBlockOverride>();
			colorBlockOverride.skyZenithColor = new Overridable<Color>(instance.skyZenithColor, _overrideValue: true);
			colorBlockOverride.skyHorizonColor = new Overridable<Color>(instance.skyHorizonColor, _overrideValue: true);
			colorBlockOverride.cloudColor = new Overridable<Color>(instance.cloudColor, _overrideValue: true);
			colorBlockOverride.cloudHighlightColor = new Overridable<Color>(instance.cloudHighlightColor, _overrideValue: true);
			colorBlockOverride.highAltitudeCloudColor = new Overridable<Color>(instance.highAltitudeCloudColor, _overrideValue: true);
			colorBlockOverride.sunlightColor = new Overridable<Color>(instance.sunlightColor, _overrideValue: true);
			colorBlockOverride.moonlightColor = new Overridable<Color>(instance.moonlightColor, _overrideValue: true);
			colorBlockOverride.starColor = new Overridable<Color>(instance.starColor, _overrideValue: true);
			colorBlockOverride.ambientLightHorizonColor = new Overridable<Color>(instance.ambientLightHorizonColor, _overrideValue: true);
			colorBlockOverride.ambientLightZenithColor = new Overridable<Color>(instance.ambientLightZenithColor, _overrideValue: true);
			colorBlockOverride.ambientLightMultiplier = new Overridable<float>(instance.ambientLightMultiplier, _overrideValue: true);
			colorBlockOverride.galaxyIntensity = new Overridable<float>(instance.galaxyIntensity, _overrideValue: true);
			colorBlockOverride.fogDensity = new Overridable<float>(instance.fogDensity, _overrideValue: true);
			colorBlockOverride.fogVariationAmount = new Overridable<float>(instance.fogVariationAmount, _overrideValue: true);
			colorBlockOverride.fogColor1 = new Overridable<Color>(instance.fogColor1, _overrideValue: true);
			colorBlockOverride.fogColor2 = new Overridable<Color>(instance.fogColor2, _overrideValue: true);
			colorBlockOverride.fogColor3 = new Overridable<Color>(instance.fogColor3, _overrideValue: true);
			colorBlockOverride.fogColor4 = new Overridable<Color>(instance.fogColor4, _overrideValue: true);
			colorBlockOverride.fogColor5 = new Overridable<Color>(instance.fogColor5, _overrideValue: true);
			colorBlockOverride.fogFlareColor = new Overridable<Color>(instance.fogFlareColor, _overrideValue: true);
			colorBlockOverride.gradientExponent = new Overridable<float>(instance.gradientExponent, _overrideValue: true);
			colorBlockOverride.sunSize = new Overridable<float>(instance.sunSize, _overrideValue: true);
			colorBlockOverride.sunColor = new Overridable<Color>(instance.sunColor, _overrideValue: true);
			colorBlockOverride.sunFalloff = new Overridable<float>(instance.sunFalloff, _overrideValue: true);
			colorBlockOverride.sunFlareColor = new Overridable<Color>(instance.sunFlareColor, _overrideValue: true);
			colorBlockOverride.moonFalloff = new Overridable<float>(instance.moonFalloff, _overrideValue: true);
			colorBlockOverride.moonFlareColor = new Overridable<Color>(instance.moonFlareColor, _overrideValue: true);
			colorBlockOverride.galaxy1Color = new Overridable<Color>(instance.galaxy1Color, _overrideValue: true);
			colorBlockOverride.galaxy2Color = new Overridable<Color>(instance.galaxy2Color, _overrideValue: true);
			colorBlockOverride.galaxy3Color = new Overridable<Color>(instance.galaxy3Color, _overrideValue: true);
			colorBlockOverride.lightScatteringColor = new Overridable<Color>(instance.lightScatteringColor, _overrideValue: true);
			colorBlockOverride.fogStart1 = new Overridable<float>(instance.fogStart1, _overrideValue: true);
			colorBlockOverride.fogStart2 = new Overridable<float>(instance.fogStart2, _overrideValue: true);
			colorBlockOverride.fogStart3 = new Overridable<float>(instance.fogStart3, _overrideValue: true);
			colorBlockOverride.fogStart4 = new Overridable<float>(instance.fogStart4, _overrideValue: true);
			colorBlockOverride.fogHeight = new Overridable<float>(instance.fogHeight, _overrideValue: true);
			colorBlockOverride.fogSmoothness = new Overridable<float>(instance.fogSmoothness, _overrideValue: true);
			colorBlockOverride.fogLightFlareIntensity = new Overridable<float>(instance.fogLightFlareIntensity, _overrideValue: true);
			colorBlockOverride.fogLightFlareFalloff = new Overridable<float>(instance.fogLightFlareFalloff, _overrideValue: true);
			colorBlockOverride.fogLightFlareSquish = new Overridable<float>(instance.fogLightFlareSquish, _overrideValue: true);
			colorBlockOverride.cloudMoonColor = new Overridable<Color>(instance.cloudMoonColor, _overrideValue: true);
			colorBlockOverride.cloudSunHighlightFalloff = new Overridable<float>(instance.cloudSunHighlightFalloff, _overrideValue: true);
			colorBlockOverride.cloudMoonHighlightFalloff = new Overridable<float>(instance.cloudMoonHighlightFalloff, _overrideValue: true);
			colorBlockOverride.cloudTextureColor = new Overridable<Color>(instance.cloudTextureColor, _overrideValue: true);
		}

		public static void ConvertToColorBlock(ColorBlock instance)
		{
			ColorBlock colorBlock = ScriptableObject.CreateInstance<ColorBlock>();
			colorBlock.skyZenithColor = instance.skyZenithColor;
			colorBlock.skyHorizonColor = instance.skyHorizonColor;
			colorBlock.cloudColor = instance.cloudColor;
			colorBlock.cloudHighlightColor = instance.cloudHighlightColor;
			colorBlock.highAltitudeCloudColor = instance.highAltitudeCloudColor;
			colorBlock.sunlightColor = instance.sunlightColor;
			colorBlock.moonlightColor = instance.moonlightColor;
			colorBlock.starColor = instance.starColor;
			colorBlock.ambientLightHorizonColor = instance.ambientLightHorizonColor;
			colorBlock.ambientLightZenithColor = instance.ambientLightZenithColor;
			colorBlock.ambientLightMultiplier = instance.ambientLightMultiplier;
			colorBlock.galaxyIntensity = instance.galaxyIntensity;
			colorBlock.fogDensity = instance.fogDensity;
			colorBlock.fogVariationAmount = instance.fogVariationAmount;
			colorBlock.fogColor1 = instance.fogColor1;
			colorBlock.fogColor2 = instance.fogColor2;
			colorBlock.fogColor3 = instance.fogColor3;
			colorBlock.fogColor4 = instance.fogColor4;
			colorBlock.fogColor5 = instance.fogColor5;
			colorBlock.fogFlareColor = instance.fogFlareColor;
			colorBlock.gradientExponent = instance.gradientExponent;
			colorBlock.sunSize = instance.sunSize;
			colorBlock.sunColor = instance.sunColor;
			colorBlock.sunFalloff = instance.sunFalloff;
			colorBlock.sunFlareColor = instance.sunFlareColor;
			colorBlock.moonFalloff = instance.moonFalloff;
			colorBlock.moonFlareColor = instance.moonFlareColor;
			colorBlock.galaxy1Color = instance.galaxy1Color;
			colorBlock.galaxy2Color = instance.galaxy2Color;
			colorBlock.galaxy3Color = instance.galaxy3Color;
			colorBlock.lightScatteringColor = instance.lightScatteringColor;
			colorBlock.fogStart1 = instance.fogStart1;
			colorBlock.fogStart2 = instance.fogStart2;
			colorBlock.fogStart3 = instance.fogStart3;
			colorBlock.fogStart4 = instance.fogStart4;
			colorBlock.fogHeight = instance.fogHeight;
			colorBlock.fogSmoothness = instance.fogSmoothness;
			colorBlock.fogLightFlareIntensity = instance.fogLightFlareIntensity;
			colorBlock.fogLightFlareFalloff = instance.fogLightFlareFalloff;
			colorBlock.fogLightFlareSquish = instance.fogLightFlareSquish;
			colorBlock.cloudMoonColor = instance.cloudMoonColor;
			colorBlock.cloudSunHighlightFalloff = instance.cloudSunHighlightFalloff;
			colorBlock.cloudMoonHighlightFalloff = instance.cloudMoonHighlightFalloff;
			colorBlock.cloudTextureColor = instance.cloudTextureColor;
		}
	}
}
