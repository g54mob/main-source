using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Atmosphere Profile", order = 361)]
	public class AtmosphereProfile : CozyProfile
	{
		[Serializable]
		public class SRPFlare
		{
			public LensFlareDataSRP flare;

			public float intensity = 1f;

			public float scale = 1f;

			public AnimationCurve screenAttenuation;

			public bool useOcclusion = true;

			public float occlusionRadius = 0.5f;

			public bool allowOffscreen = true;
		}

		[Tooltip("Sets the color of the zenith (or top) of the skybox at a certain time. Starts and ends at midnight.")]
		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		public VariableProperty skyZenithColor;

		[Tooltip("Sets the color of the horizon (or middle) of the skybox at a certain time. Starts and ends at midnight.")]
		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		public VariableProperty skyHorizonColor;

		[Tooltip("Sets the main color of the clouds at a certain time. Starts and ends at midnight.")]
		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		public VariableProperty cloudColor;

		[Tooltip("Sets the highlight color of the clouds at a certain time. Starts and ends at midnight.")]
		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		public VariableProperty cloudHighlightColor;

		[Tooltip("Sets the color of the high altitude clouds at a certain time. Starts and ends at midnight.")]
		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		public VariableProperty highAltitudeCloudColor;

		[Tooltip("Sets the color of the sun light source at a certain time. Starts and ends at midnight.")]
		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		public VariableProperty sunlightColor;

		public LightShadows sunlightShadows = LightShadows.Soft;

		public LightShadows moonlightShadows = LightShadows.Soft;

		[Tooltip("Sets the color of the moon light source at a certain time. Starts and ends at midnight.")]
		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		public VariableProperty moonlightColor;

		[Tooltip("Sets the color of the star particle FX and textures at a certain time. Starts and ends at midnight.")]
		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		public VariableProperty starColor;

		[Tooltip("Sets the color of the zenith (or top) of the ambient scene lighting at a certain time. Starts and ends at midnight.")]
		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		public VariableProperty ambientLightHorizonColor;

		[Tooltip("Sets the color of the horizon (or middle) of the ambient scene lighting at a certain time. Starts and ends at midnight.")]
		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		public VariableProperty ambientLightZenithColor;

		[Tooltip("Multiplies the ambient light intensity.")]
		[CozyPropertyType(false, 0f, 4f)]
		[CozySearchable(new string[] { })]
		public VariableProperty ambientLightMultiplier;

		[Tooltip("Sets the intensity of the galaxy effects at a certain time. Starts and ends at midnight.")]
		[CozyPropertyType(false, 0f, 1f)]
		[CozySearchable(new string[] { })]
		public VariableProperty galaxyIntensity;

		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		[Tooltip("Sets the fog color from 0m away from the camera to fog start 1.")]
		public VariableProperty fogColor1;

		[CozySearchable(new string[] { })]
		[CozyPropertyType(true)]
		[Tooltip("Sets the fog color from fog start 1 to fog start 2.")]
		public VariableProperty fogColor2;

		[CozySearchable(new string[] { })]
		[Tooltip("Sets the fog color from fog start 2 to fog start 3.")]
		[CozyPropertyType(true)]
		public VariableProperty fogColor3;

		[CozySearchable(new string[] { })]
		[Tooltip("Sets the fog color from fog start 3 to fog start 4.")]
		[CozyPropertyType(true)]
		public VariableProperty fogColor4;

		[CozySearchable(new string[] { })]
		[Tooltip("Sets the fog color from fog start 4 to fog start 5.")]
		[CozyPropertyType(true)]
		public VariableProperty fogColor5;

		[CozySearchable(new string[] { })]
		[CozyPropertyType(true)]
		[Tooltip("Sets the color of the fog flare.")]
		public VariableProperty fogFlareColor;

		[CozySearchable(new string[] { })]
		[CozyPropertyType(true)]
		[Tooltip("Sets the color of the moon flare for the fog.")]
		public VariableProperty fogMoonFlareColor;

		[CozySearchable(new string[] { })]
		[CozyPropertyType(false, 0f, 1f)]
		[Tooltip("Sets the smoothness of the fog.")]
		public VariableProperty fogSmoothness;

		[CozySearchable(new string[] { })]
		public Vector3 fogVariationDirection;

		[CozyPropertyType(false, 0f, 30f)]
		[Tooltip("Sets the variation scale of the fog.")]
		[CozySearchable(new string[] { })]
		public VariableProperty fogVariationScale;

		[CozySearchable(new string[] { })]
		[CozyPropertyType(false, 0f, 1f)]
		[Tooltip("Sets the variation amount.")]
		public VariableProperty fogVariationAmount;

		[CozySearchable(new string[] { })]
		[Tooltip("Sets the variation distance of the fog.")]
		[CozyPropertyType(false, 0f, 200f)]
		public VariableProperty fogVariationDistance;

		[CozyPropertyType(false, 0f, 1f)]
		[CozySearchable(new string[] { })]
		public VariableProperty heightFogIntensity;

		[CozyPropertyType(false, 100f, 1000f)]
		[CozySearchable(new string[] { })]
		public VariableProperty heightFogVariationScale;

		[CozyPropertyType(false, 0f, 50f)]
		[CozySearchable(new string[] { })]
		public VariableProperty heightFogVariationAmount;

		[CozyPropertyType(false)]
		[CozySearchable(new string[] { })]
		public VariableProperty fogBase;

		[CozyPropertyType(false, 0f, 500f)]
		[CozySearchable(new string[] { })]
		public VariableProperty heightFogTransition;

		[CozyPropertyType(false, 0f, 5000f)]
		[CozySearchable(new string[] { })]
		public VariableProperty heightFogDistance;

		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		public VariableProperty heightFogColor;

		[CozyPropertyType(false, 0f, 1f)]
		[CozySearchable(new string[] { })]
		[Tooltip("Controls the exponent used to modulate from the horizon color to the zenith color of the sky.")]
		public VariableProperty gradientExponent;

		[CozyPropertyType(false, 0f, 5f)]
		[CozySearchable(new string[] { })]
		[Tooltip("Sets the size of the visual sun in the sky.")]
		public VariableProperty sunSize;

		[Tooltip("Sets the world space direction of the sun in degrees.")]
		[CozyPropertyType(false, 0f, 360f)]
		[CozySearchable(new string[] { })]
		public VariableProperty sunDirection;

		[Tooltip("Sets the roll value of the sun's rotation. Allows the sun to be slightly off from directly overhead at noon.")]
		[CozyPropertyType(false, -90f, 90f)]
		[CozySearchable(new string[] { })]
		public VariableProperty sunPitch;

		[CozySearchable(new string[] { })]
		[Tooltip("Sets the color of the visual sun in the sky.")]
		[CozyPropertyType(true)]
		public VariableProperty sunColor;

		[CozySearchable(new string[] { })]
		[Tooltip("Sets the color of the visual moon in the sky (only impacts the global shader variable for the stylized moon material).")]
		[CozyPropertyType(true)]
		public VariableProperty moonColor;

		[CozyPropertyType(false, 0f, 1f)]
		[CozySearchable(new string[] { })]
		[Tooltip("Sets the falloff of the halo around the visual sun.")]
		public VariableProperty sunFalloff;

		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		[Tooltip("Sets the color of the halo around the visual sun.")]
		public VariableProperty sunFlareColor;

		[CozyPropertyType(false, 0f, 1f)]
		[CozySearchable(new string[] { })]
		[Tooltip("Sets the falloff of the halo around the main moon.")]
		public VariableProperty moonFalloff;

		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		[Tooltip("Sets the color of the halo around the main moon.")]
		public VariableProperty moonFlareColor;

		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		[Tooltip("Sets the color of the first galaxy algorithm.")]
		public VariableProperty galaxy1Color;

		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		[Tooltip("Sets the color of the second galaxy algorithm.")]
		public VariableProperty galaxy2Color;

		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		[Tooltip("Sets the color of the third galaxy algorithm.")]
		public VariableProperty galaxy3Color;

		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		[Tooltip("Sets the color of the light columns around the horizon.")]
		public VariableProperty lightScatteringColor;

		[CozyPropertyType(false, 0f, 1f)]
		[CozySearchable(new string[] { })]
		[Tooltip("Sets the position of the light columns around the horizon.")]
		public VariableProperty lightScatteringPosition;

		[CozyPropertyType(false, 0f, 1f)]
		[CozySearchable(new string[] { })]
		[Tooltip("Sets the position of the light columns around the horizon.")]
		public VariableProperty lightScatteringHeight;

		[CozyPropertyType(false, 0f, 1f)]
		[CozySearchable(new string[] { })]
		[Tooltip("Sets the brightness of constellation lines in the night sky.")]
		public VariableProperty constellationIntensity;

		[Tooltip("Should COZY use a rainbow?")]
		[CozySearchable(new string[] { })]
		public bool useRainbow = true;

		public Texture rainbowTexture;

		[Tooltip("Sets the position of the rainbow in the sky.")]
		[CozyPropertyType(false, 0f, 100f)]
		[CozySearchable(new string[] { })]
		public VariableProperty rainbowPosition;

		[Tooltip("Sets the width of the rainbow in the sky.")]
		[CozySearchable(new string[] { })]
		[CozyPropertyType(false, 0f, 50f)]
		public VariableProperty rainbowWidth;

		[CozyPropertyType(false, 0f, 5f)]
		[CozySearchable(new string[] { })]
		[Tooltip("Multiplies the world space distance before entering the fog algorithm. Use this for simple density changes.")]
		public VariableProperty fogDensityMultiplier;

		[Tooltip("Sets the distance at which the first fog color fades into the second fog color.")]
		[CozySearchable(new string[] { })]
		public VariableProperty fogStart1 = new VariableProperty
		{
			floatVal = 5f
		};

		[Tooltip("Sets the distance at which the second fog color fades into the third fog color.")]
		[CozySearchable(new string[] { })]
		public VariableProperty fogStart2 = new VariableProperty
		{
			floatVal = 12f
		};

		[Tooltip("Sets the distance at which the third fog color fades into the fourth fog color.")]
		[CozySearchable(new string[] { })]
		public VariableProperty fogStart3 = new VariableProperty
		{
			floatVal = 20f
		};

		[Tooltip("Sets the distance at which the fourth fog color fades into the fifth fog color.")]
		[CozySearchable(new string[] { })]
		public VariableProperty fogStart4 = new VariableProperty
		{
			floatVal = 35f
		};

		[CozyPropertyType(false, 0f, 2f)]
		[CozySearchable(new string[] { })]
		public VariableProperty fogHeight;

		[CozyPropertyType(false, 0f, 2f)]
		[CozySearchable(new string[] { })]
		public VariableProperty fogLightFlareIntensity;

		[CozyPropertyType(false, 0f, 40f)]
		[CozySearchable(new string[] { })]
		public VariableProperty fogLightFlareFalloff;

		[CozyPropertyType(false, 0f, 10f)]
		[CozySearchable(new string[] { })]
		[Tooltip("Sets the height divisor for the fog flare. High values sit the flare closer to the horizon, small values extend the flare into the sky.")]
		public VariableProperty fogLightFlareSquish;

		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		public VariableProperty cloudMoonColor;

		[CozyPropertyType(false, 0f, 50f)]
		[CozySearchable(new string[] { })]
		public VariableProperty cloudSunHighlightFalloff;

		[CozyPropertyType(false, 0f, 50f)]
		[CozySearchable(new string[] { })]
		public VariableProperty cloudMoonHighlightFalloff;

		[CozyPropertyType(false, 0f, 10f)]
		[CozySearchable(new string[] { })]
		public VariableProperty cloudWindSpeed;

		[CozyPropertyType(false, 0f, 1f)]
		[CozySearchable(new string[] { })]
		public VariableProperty clippingThreshold;

		[CozyPropertyType(false, 2f, 60f)]
		[CozySearchable(new string[] { })]
		public VariableProperty cloudMainScale;

		[CozyPropertyType(false, 0.2f, 10f)]
		[CozySearchable(new string[] { })]
		public VariableProperty cloudDetailScale;

		[CozyPropertyType(false, 0f, 30f)]
		[CozySearchable(new string[] { })]
		public VariableProperty cloudDetailAmount;

		[CozyPropertyType(false, 0.1f, 3f)]
		[CozySearchable(new string[] { })]
		public VariableProperty acScale;

		[CozyPropertyType(false, 0f, 3f)]
		[CozySearchable(new string[] { })]
		public VariableProperty cirroMoveSpeed;

		[CozyPropertyType(false, 0f, 3f)]
		[CozySearchable(new string[] { })]
		public VariableProperty cirrusMoveSpeed;

		[CozyPropertyType(false, 0f, 3f)]
		[CozySearchable(new string[] { })]
		public VariableProperty chemtrailsMoveSpeed;

		[CozySearchable(new string[] { })]
		public Texture cloudTexture;

		[CozySearchable(new string[] { })]
		public Texture chemtrailsTexture;

		[CozySearchable(new string[] { })]
		public Texture cirrusCloudTexture;

		[CozySearchable(new string[] { })]
		public Texture cirrostratusCloudTexture;

		[CozySearchable(new string[] { })]
		public Texture altocumulusCloudTexture;

		[CozySearchable(new string[] { })]
		public Texture starMap;

		[CozySearchable(new string[] { })]
		public Texture starDomeTexture;

		[CozySearchable(new string[] { })]
		public Texture galaxyMap;

		[CozySearchable(new string[] { })]
		public Texture galaxyDomeTexture;

		[CozySearchable(new string[] { })]
		public Texture constellationDomeTexture;

		[CozySearchable(new string[] { })]
		public Texture galaxyStarMap;

		[CozySearchable(new string[] { })]
		public Texture galaxyVariationMap;

		[CozySearchable(new string[] { })]
		public Texture lightScatteringMap;

		[CozySearchable(new string[] { })]
		public Texture partlyCloudyLuxuryClouds;

		[CozySearchable(new string[] { })]
		public Texture mostlyCloudyLuxuryClouds;

		[CozySearchable(new string[] { })]
		public Texture overcastLuxuryClouds;

		[CozySearchable(new string[] { })]
		public Texture lowBorderLuxuryClouds;

		[CozySearchable(new string[] { })]
		public Texture highBorderLuxuryClouds;

		[CozySearchable(new string[] { })]
		public Texture lowNimbusLuxuryClouds;

		[CozySearchable(new string[] { })]
		public Texture midNimbusLuxuryClouds;

		[CozySearchable(new string[] { })]
		public Texture highNimbusLuxuryClouds;

		[CozySearchable(new string[] { })]
		public Texture luxuryVariation;

		[CozyPropertyType(true)]
		[CozySearchable(new string[] { })]
		public VariableProperty cloudTextureColor;

		[CozyPropertyType(false, 0f, 10f)]
		[CozySearchable(new string[] { })]
		public VariableProperty cloudCohesion;

		[CozyPropertyType(false, 0f, 1f)]
		[CozySearchable(new string[] { })]
		public VariableProperty spherize;

		[CozyPropertyType(false, 0f, 10f)]
		[CozySearchable(new string[] { })]
		public VariableProperty shadowDistance;

		[CozyPropertyType(false, 0f, 4f)]
		[CozySearchable(new string[] { })]
		public VariableProperty cloudThickness;

		[CozyPropertyType(false, 0f, 3f)]
		[CozySearchable(new string[] { })]
		public VariableProperty textureAmount;

		[CozySearchable(new string[] { })]
		public Vector3 texturePanDirection;

		public SRPFlare sunFlare;

		public SRPFlare moonFlare;

		[CozyPropertyType(false, 0f, 1f)]
		[CozySearchable(new string[] { })]
		public VariableProperty skyFogAmount;

		[CozyPropertyType(false, 0f, 1f)]
		[CozySearchable(new string[] { })]
		public VariableProperty cloudsFogAmount;

		[CozyPropertyType(false, 0f, 1f)]
		[CozySearchable(new string[] { })]
		public VariableProperty cloudsFogLightAmount;
	}
}
