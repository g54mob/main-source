using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "lighting_data", menuName = "Database/Lighting Preset")]
public class LightingPreset : SoCustomComparison
{
	public enum ShadowMode
	{
		everyFrame = 0,
		onEnable = 1,
		onDemand = 2,
		dynamicSystemStatic = 3,
		dynamicSystemSlowerUpdate = 4
	}

	public enum ShadowResolution
	{
		low = 0,
		medium = 1,
		high = 2,
		ultra = 3
	}

	[Tooltip("Cool Colours")]
	[Header("Light")]
	public List<CityControls.WindowColour> coolColours;

	[Tooltip("Warm Colours")]
	public List<CityControls.WindowColour> warmColours;

	[Tooltip("If no room is assigned, use this intensity")]
	public float defaultIntensity;

	public float defaultRange;

	[Tooltip("how much the intensity changes per room size, also range")]
	public float intensityRoomSizeMultiplier;

	[Tooltip("Clamped intensity range")]
	public Vector2 intensityRange;

	[Tooltip("Fade in or out when turned on or off")]
	public bool fadeOnOff;

	[Tooltip("Fade in/out by this speed")]
	public float fadeSpeed;

	[Tooltip("When setup, set the light")]
	public bool onByDefault;

	[Tooltip("Distance at which the emission is culled completely")]
	public float fadeDistance;

	[Header("Materials")]
	[Tooltip("If true, uses the tv broadcast material")]
	public bool useBroadcastMaterial;

	[Tooltip("Use an alternate material when on (shared)")]
	[DisableIf("useBroadcastMaterial")]
	public Material useOnMaterial;

	[Tooltip("Dynamically alter emissive (create instanced material)")]
	public bool useInstancedEmissive;

	[Tooltip("Emmission multiplier")]
	[EnableIf("useInstancedEmissive")]
	public float emissionMultiplier;

	[Header("Atrium Lights")]
	[Tooltip("Special option to make this hang down")]
	public bool isAtriumLight;

	[EnableIf("isAtriumLight")]
	[Tooltip("What is the minimum number of floors this atrium covers before it is allowed to feature this light?")]
	public int minimumFloors;

	[EnableIf("isAtriumLight")]
	public GameObject cablePrefab;

	[EnableIf("isAtriumLight")]
	public GameObject bulbPrefab;

	[EnableIf("isAtriumLight")]
	public GameObject endBulbPrefab;

	[Tooltip("Spawn a bulb every x metres")]
	[EnableIf("isAtriumLight")]
	public float heightInterval;

	[Tooltip("Can this light also spawn a ceiling fan? Must be set up in lighting config")]
	[Header("Additional")]
	public bool allowCeilingFans;

	[Header("Volumetrics")]
	public bool enableVolumetrics;

	[Tooltip("The atmosphere setting in the room preset is multiplied by this")]
	public float atmosphereMultiplier;

	[Header("Shadows")]
	public bool enableShadows;

	public ShadowMode shadowMode;

	public ShadowResolution resolution;

	[Tooltip("Distance at which shadows are culled completely.")]
	public float shadowFadeDistance;

	[Range(0f, 1f)]
	[Header("Flickering")]
	public float chanceOfFlicker;

	[Tooltip("When flickering, use this multiplier on the flicker colour to determin the actual colour (basically a darker version of flicker colour)")]
	public Vector2 flickerMultiplierRange;

	[Tooltip("When flickering, how fast it pulses")]
	public Vector2 flickerPulseRange;

	[Tooltip("Flickering lasts this long")]
	public Vector2 flickerIntervalRange;

	[Tooltip("Intervals between flickering are this long")]
	public Vector2 flickerNormalityIntervalRange;
}
