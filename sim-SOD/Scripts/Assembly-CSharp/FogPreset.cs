using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "fog_data", menuName = "Database/Fog Settings")]
public class FogPreset : SoCustomComparison
{
	[Header("Lighting")]
	[Tooltip("Sun rises at this hour (90 degrees to terrain)")]
	public float sunRiseHour;

	[Tooltip("Sun sets at this hour (90 degrees to terrain)")]
	public float sunSetHour;

	[Tooltip("Sun intensity curve")]
	public AnimationCurve daytimeSunIntensityCurve;

	[Tooltip("Multiply the above curve by this")]
	public float sunIntensityBooster;

	[Tooltip("Morning sun Colour")]
	public Color morningSunColour;

	[Tooltip("Midday sun Colour")]
	public Color middaySunColour;

	[Tooltip("Evening sun Colour")]
	public Color eveningSunColour;

	[Tooltip("Sun shadow strength curve")]
	public AnimationCurve sunShadowStrengthCurve;

	[Tooltip("Sun dimmer")]
	public AnimationCurve sunVolumetricDimmer;

	[Tooltip("Sun shadows dimmer")]
	public AnimationCurve sunVolumetricShadowDimmer;

	[Tooltip("Exterior Ambient curve")]
	public AnimationCurve exteriorAmbientIntensityCurve;

	[Tooltip("Multiply the above curve by this")]
	public float ambientExteriorBooster;

	[Tooltip("Exterior Ambient curve")]
	public AnimationCurve interiorAmbientIntensityCurve;

	[Tooltip("Multiply the above curve by this")]
	public float ambientInteriorBooster;

	[ReorderableList]
	[Header("Colouring")]
	[Tooltip("Skybox colour grades w/ fog colour settings")]
	public List<SessionData.SkyboxGradient> skyboxGradientGrading;

	[Range(0f, 1f)]
	public float skyColourMultiplier;

	[Range(0f, 1f)]
	public float fogColourMultiplier;

	[Range(0f, 1f)]
	public float ambientLightMultiplier;

	[Range(0f, 1f)]
	public float globalLightIntensityMultiplier;

	[Header("Fog")]
	[Tooltip("Fog distance ranges")]
	public Vector2 fogDistanceRange;

	[Tooltip("Fog distance throughout the day")]
	public AnimationCurve fogDistanceCurve;

	public Vector2 maxFogDistanceRange;

	[Tooltip("Max Fog distance throughout the day")]
	public AnimationCurve maxFogDistanceCurve;

	[Space(7f)]
	public AnimationCurve fogAttenuationCurve;

	public AnimationCurve volumetricFogDistanceCurve;

	[Header("Skyline")]
	public AnimationCurve skylineEmissionCurve;

	[ColorUsage(true, true)]
	public Color skylineEmissionColor;

	[Header("Weather")]
	public AnimationCurve monthSnowChanceCurve;

	public AnimationCurve weatherExtremityCurve;

	public float thunderDelay;

	[Header("Temperature")]
	public AnimationCurve monthTempCurve;

	public AnimationCurve dayTempCurve;

	public float NoRainModifier;

	public float NoWindModifier;

	public float NoSnowModifier;
}
