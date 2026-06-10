using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "district_data", menuName = "Database/District Preset")]
public class DistrictPreset : SoCustomComparison
{
	public enum AffectStreetAreaLights
	{
		lerp = 0,
		multiply = 1,
		add = 2
	}

	[Tooltip("How important is it to generate this district first")]
	[Header("Generation")]
	public Vector2 generationPriority;

	[Tooltip("Can there be more than 1 of these districts?")]
	public bool limitToOne;

	[Tooltip("Distict size as ratio of the city")]
	[Range(0.1f, 0.5f)]
	public float cityRatio;

	[Tooltip("Hard minimum size")]
	public int minimumSize;

	[Tooltip("Hard maximum size")]
	public int maximumSize;

	[Tooltip("This district must be located on the coast")]
	public bool mustBeOnCoast;

	[Tooltip("How important is it that this district is located near the centre of the city?")]
	[Range(-0.5f, 0.5f)]
	public float centreWeighting;

	[Header("Naming")]
	[Tooltip("Chance of alliteration with prefix. This will add words with the same letter to the suffix to increase the chances of picking them by this amount")]
	[Range(0f, 15f)]
	public int aliterationWeight;

	[Space(5f)]
	[Range(0f, 1f)]
	public float prefixOrSuffixChance;

	[ReorderableList]
	[Tooltip("Use this name list to pick a prefix")]
	public List<string> prefixList;

	[Range(0f, 1f)]
	public float mainChance;

	[Tooltip("Use this name list to pick a main name")]
	[ReorderableList]
	public List<string> mainNamingList;

	[Tooltip("Append a random selection of this suffix list to the name")]
	[ReorderableList]
	public List<string> suffixList;

	[Header("Composition")]
	public BuildingPreset.Density minimumDensity;

	public BuildingPreset.Density maximumDensity;

	public BuildingPreset.LandValue minimumLandValue;

	public BuildingPreset.LandValue maximumLandValue;

	[Space(7f)]
	[Tooltip("Affect the ethnicity of the citizens in this district...")]
	public bool affectEthnicity;

	[EnableIf("affectEthnicity")]
	public List<SocialStatistics.EthnicityFrequency> ethnicityFrequencyModifiers;

	[Header("Environment")]
	public SessionData.SceneProfile sceneProfile;

	[Tooltip("Change street light area colours")]
	public bool alterStreetAreaLighting;

	[EnableIf("alterStreetAreaLighting")]
	public List<Color> possibleColours;

	[EnableIf("alterStreetAreaLighting")]
	[Tooltip("This is used in combination with the following to adjust street area lighting")]
	public AffectStreetAreaLights lightOperation;

	[EnableIf("alterStreetAreaLighting")]
	public float lightAmount;

	[EnableIf("alterStreetAreaLighting")]
	[Tooltip("This is added to brightness")]
	public float brightnessModifier;

	[Header("Debug")]
	public DistrictPreset copyFrom;

	[Button(null, EButtonEnableMode.Always)]
	public void CopyFrom()
	{
	}
}
