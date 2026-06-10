using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class SocialStatistics : MonoBehaviour
{
	[Serializable]
	public class EthnicityFrequency : IComparable<EthnicityFrequency>
	{
		public Descriptors.EthnicGroup ethnicity;

		public int frequency;

		public int CompareTo(EthnicityFrequency otherObject)
		{
			return 0;
		}
	}

	[Serializable]
	public class HairSetting
	{
		public Descriptors.HairColour colour;

		public Color hairColourRange1;

		public Color hairColourRange2;
	}

	[Serializable]
	public class EthnicityStats
	{
		public Descriptors.EthnicGroup group;

		[Header("Skin")]
		public Color skinColourRange1;

		public Color skinColourRange2;

		[Header("Hair Colour")]
		public int blackHairRatio;

		public int brownHairRatio;

		public int blondeHairRatio;

		public int gingerHairRatio;

		public int RedHairRatio;

		public int blueHairRatio;

		public int greenHairRatio;

		public int purpleHairRatio;

		public int pinkHairRatio;

		public int greyHairRatio;

		public int whiteHairRatio;

		[Header("Hair Type")]
		public int baldHairRatioMale;

		public int shortHairRatioMale;

		public int longHairRatioMale;

		public int baldHairRatioFemale;

		public int shortHairRatioFemale;

		public int longHairRatioFemale;

		[Header("Hair Type")]
		public int straightHairRatioMale;

		public int curlyHairRatioMale;

		public int balingHairRatioMale;

		public int messyHairRatioMale;

		public int styledHairRatioMale;

		public int mohawkHairRatioMale;

		public int afroHairRatioMale;

		public int straightHairRatioFemale;

		public int curlyHairRatioFemale;

		public int balingHairRatioFemale;

		public int messyHairRatioFemale;

		public int styledHairRatioFemale;

		public int mohawkHairRatioFemale;

		public int afroHairRatioFemale;

		[Header("Eye Colour")]
		public int blueEyesRatio;

		public int brownEyesRatio;

		public int greenEyesRatio;

		public int greyEyesRatio;

		[Header("Naming")]
		public bool overrideFirst;

		public Descriptors.EthnicGroup overrideNameFirst;

		public bool overrideSur;

		public Descriptors.EthnicGroup overrideNameSur;

		[Header("Cultural Similiarities")]
		public List<Descriptors.EthnicGroup> culturalSimilarities;

		[Header("Traits")]
		public List<CharacterTrait> ethTraits;
	}

	[Tooltip("The scale in the centre of Female:Male float that applies to citizens that identify as non-binary")]
	[Header("Gender/Sexuality")]
	public float genderNonBinaryThreshold;

	[Tooltip("How many citizens identify as something other than their birth gender?")]
	public float transThreshold;

	[Tooltip("Sexuality threshold for being attracted to opposite sex (straight)")]
	public float sexualityStraightThreshold;

	[Tooltip("Sexuality threshold for being attracted to same sex (gay)")]
	public float sexualityGayThreshold;

	[Tooltip("Chance of being asexual if attracted to neither sex")]
	public float asexualChance;

	[Space(7f)]
	public CharacterTrait maleTrait;

	public CharacterTrait femaleTrait;

	public CharacterTrait nbTrait;

	public CharacterTrait AttractedToMaleTrait;

	public CharacterTrait AttractedToFemaleTrait;

	public CharacterTrait AttractedToNBTrait;

	public CharacterTrait relationshipTrait;

	[Space(7f)]
	public List<Color> lipstickColours;

	[Tooltip("The higher the rank, the more likely it is that the person is older: 19-21, 22-26, 27-31, 32-36, 37-41, 42-46, 47-51, 52-56, 57-61, 62-66, 67+")]
	[Header("Demographics")]
	public int[] ageRanges;

	[Header("Ethnicity")]
	public List<EthnicityFrequency> ethnicityFrequencies;

	public int chanceOf2ndEthnicity;

	public float districtEthnictiyDominanceMultiplier;

	[Header("Ethnicity Classes")]
	public List<EthnicityStats> ethnicityStats;

	[Header("Physical Build")]
	[Tooltip("Real-world average height in cm")]
	public float averageHeight;

	[Tooltip("Real-world average weight in kg")]
	public float averageWeight;

	[Tooltip("Height min/max thresholds in cm")]
	public Vector2 heightMinMax;

	[Space(7f)]
	public int skinnyRatio;

	public int averageRatio;

	public int overweightRatio;

	public int muscleyRatio;

	[Header("Blood Group")]
	public float bloodOPosRatio;

	public float bloodAPosRatio;

	public float bloodBPosRatio;

	public float bloodONegRatio;

	public float bloodANegRatio;

	public float bloodABPosRatio;

	public float bloodBNegRatio;

	public float bloodABNegRatio;

	[Header("Hair")]
	[ReorderableList]
	public List<HairSetting> hairColourSettings;

	[Space(7f)]
	public int RedHairRatio;

	public int blueHairRatio;

	public int greenHairRatio;

	public int purpleHairRatio;

	public int pinkHairRatio;

	[Header("Facial Features")]
	public int scaringRatio;

	public int menWithBeards;

	public int menWithMoustaches;

	public int piercingRatio;

	public int TattooRatio;

	public int glassesRatio;

	public int moleRatio;

	public int frecklesRatio;

	[Header("Society")]
	public float seriousRelationshipsRatio;

	[Tooltip("A default slang greeting to be used on anyone in a casual manor")]
	[Header("Slang Defaults")]
	[ReorderableList]
	public List<string> slangGreetingDefault;

	[Tooltip("Similar to above, but male specific (eg. 'bro')")]
	[ReorderableList]
	public List<string> slangGreetingMale;

	[ReorderableList]
	[Tooltip("Similar to above, but female specific")]
	public List<string> slangGreetingFemale;

	[ReorderableList]
	[Tooltip("Slang greeting for a lover")]
	public List<string> slangGreetingLover;

	[ReorderableList]
	[Tooltip("Slang curse word")]
	public List<string> slangCurse;

	[Tooltip("Slang curse noun word")]
	[ReorderableList]
	public List<string> slangCurseNoun;

	[Tooltip("Slang praise noun word")]
	[ReorderableList]
	public List<string> slangPraiseNoun;

	[Header("Fav Colours Pool")]
	[ReorderableList]
	public List<Color> favouriteColoursPool;

	private static SocialStatistics _instance;

	public static SocialStatistics Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
