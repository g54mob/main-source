using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Descriptors
{
	public enum Age
	{
		youngAdult = 0,
		adult = 1,
		old = 2
	}

	public enum BuildType
	{
		skinny = 0,
		average = 1,
		overweight = 2,
		muscular = 3
	}

	public enum Height
	{
		veryShort = 0,
		hShort = 1,
		hAverage = 2,
		tall = 3,
		veryTall = 4
	}

	public enum EthnicGroup
	{
		westEuropean = 0,
		eastEuropean = 1,
		scandinavian = 2,
		mediterranean = 3,
		hispanic = 4,
		african = 5,
		indian = 6,
		chinese = 7,
		japanese = 8,
		korean = 9,
		nativeAmerican = 10,
		middleEastern = 11,
		australian = 12,
		africanAmerican = 13,
		islander = 14,
		northAmerican = 15,
		southAmerican = 16
	}

	[Serializable]
	public class EthnicitySetting : IComparable<EthnicitySetting>
	{
		public EthnicGroup group;

		public float ratio;

		public SocialStatistics.EthnicityStats stats;

		public int CompareTo(EthnicitySetting otherObject)
		{
			return 0;
		}
	}

	public enum HairColour
	{
		black = 0,
		brown = 1,
		blonde = 2,
		ginger = 3,
		red = 4,
		blue = 5,
		green = 6,
		purple = 7,
		pink = 8,
		grey = 9,
		white = 10
	}

	public enum HairStyle
	{
		bald = 0,
		shortHair = 1,
		longHair = 2
	}

	public enum EyeColour
	{
		blueEyes = 0,
		brownEyes = 1,
		greenEyes = 2,
		greyEyes = 3
	}

	[Serializable]
	public struct FacialFeaturesSetting
	{
		public FacialFeature feature;

		public int id;
	}

	public enum FacialFeature
	{
		scaring = 0,
		beard = 1,
		moustache = 2,
		piercing = 3,
		tattoo = 4,
		glasses = 5,
		mole = 6
	}

	[NonSerialized]
	public Human citizen;

	public float visualDistinctiveness;

	public BuildType build;

	public Height height;

	public float heightCM;

	public float weightKG;

	public int shoeSize;

	public Human.ShoeType footwear;

	public List<EthnicitySetting> ethnicities;

	public Color skinColour;

	public HairColour hairColourCategory;

	public Color hairColour;

	public HairStyle hairType;

	public EyeColour eyeColour;

	public List<FacialFeaturesSetting> facialFeatures;

	public Descriptors(Human newCitizen)
	{
	}

	private void GenerateEthnicity()
	{
	}

	public void GenerateNameAndSkinColour()
	{
	}

	private void GenerateEyes()
	{
	}

	private void GenerateHair()
	{
	}

	private void GenerateBuild()
	{
	}

	private void GenerateFacialFeatures()
	{
	}

	private void GenerateFootwearPreference()
	{
	}

	public static float DescriptorComparison(Descriptors comp1, Descriptors comp2)
	{
		return 0f;
	}
}
