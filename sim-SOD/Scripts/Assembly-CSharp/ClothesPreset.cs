using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "clothes_data", menuName = "Database/Clothing Item")]
public class ClothesPreset : SoCustomComparison
{
	[Serializable]
	public class MaterialSettings
	{
		public Color colour;

		[Range(1f, 5f)]
		public int weighting;
	}

	[Serializable]
	public class ModelSettings
	{
		public GameObject prefab;

		public CitizenOutfitController.CharacterAnchor anchor;

		public Vector3 offsetPosition;

		public Vector3 offsetEuler;

		public bool exclusiveAnchorModel;
	}

	public enum OutfitCategory
	{
		casual = 0,
		work = 1,
		smart = 2,
		outdoorsCasual = 3,
		outdoorsWork = 4,
		outdoorsSmart = 5,
		undressed = 6,
		bed = 7,
		underwear = 8
	}

	public enum ClothingColourSource
	{
		none = 0,
		garment = 1,
		skin = 2,
		white = 3,
		hair = 4,
		underneathColour1 = 5,
		underneathColour2 = 6,
		underneathColour3 = 7,
		workUniformColour = 8
	}

	public enum ClothesTags
	{
		longGarment = 0,
		noLongGarments = 1
	}

	public enum HairRenderSetting
	{
		renderHatCompatibleHair = 0,
		renderAllHair = 1,
		dontRenderAnyHair = 2
	}

	public enum Incompatibility
	{
		inAnyCategory = 0,
		inThisCategory = 1
	}

	[Serializable]
	public class IncompatibilitySetting
	{
		public Incompatibility incompatibleIf;

		public List<ClothesTags> tags;

		public ClothesPreset featured;
	}

	[Serializable]
	public class TraitPickRule
	{
		public CharacterTrait.RuleType rule;

		public List<CharacterTrait> traitList;

		[ShowIf("isTrait")]
		[Tooltip("If this isn't true then it won't be picked for application at all.")]
		public bool mustPassForApplication;

		[ShowIf("isTrait")]
		[Range(-10f, 10f)]
		[Tooltip("If the rules match, then apply this to the base chance...")]
		public int addChance;
	}

	[ReorderableList]
	[Tooltip("Covers these components: If an anchor here is NOT covered by this outfit, it will look for other elements in outfits.")]
	[Header("Setup")]
	public List<CitizenOutfitController.CharacterAnchor> covers;

	[Space(7f)]
	[ReorderableList]
	public List<OutfitCategory> outfitCategories;

	[ReorderableList]
	public List<Human.Gender> suitableForGenders;

	[ReorderableList]
	public List<Descriptors.BuildType> suitableForBuilds;

	public List<ClothesTags> tags;

	[Tooltip("If true enable facial-feature specific setup")]
	public bool enableFacialFeatureSetup;

	[ReorderableList]
	public List<Descriptors.HairStyle> suitableForHairstyle;

	[Header("Head")]
	public bool isHead;

	[EnableIf("isHead")]
	public Vector3 pupilsOffset;

	[EnableIf("isHead")]
	public Vector3 eyebrowsOffset;

	[EnableIf("isHead")]
	public Vector3 mouthOffset;

	[Header("Hair")]
	[Tooltip("This needs to be true for the game to render both the hair and hat")]
	public bool hatRenderCompatible;

	[Tooltip("Exclude these types of hats from compatibility...")]
	[EnableIf("hatRenderCompatible")]
	public List<ClothesPreset> excludeHats;

	[Header("Hat")]
	public HairRenderSetting hairRenderMode;

	[Header("Feet")]
	public bool setFootwear;

	[EnableIf("setFootwear")]
	public Human.ShoeType footwear;

	[Range(0f, 5f)]
	[Header("Compatibility")]
	[Tooltip("Controls which clothing will be loaded first. If this is important to the outfit, eg wearing a coat outdoors, increase the priority.")]
	public int priority;

	[Tooltip("Only choose this preset if the model can display all elements in the 'models' section below. Only applies when using clothing elements not from the category (eg using casual for outdoors casual)")]
	public bool onlyChooseIfAllModelPartsAreAvailable;

	[ReorderableList]
	[Tooltip("This cannot be chosen if these existing clothes are chosen")]
	public List<IncompatibilitySetting> incompatibility;

	[Tooltip("The citizen/company must have at least this much wealth to have this outfit")]
	public bool useWealthValues;

	[EnableIf("useWealthValues")]
	[Range(0f, 1f)]
	public float minimumWealth;

	[EnableIf("useWealthValues")]
	[Range(0f, 1f)]
	public float maximumWealth;

	[Space(7f)]
	[Header("Colours")]
	public ClothingColourSource baseColourSource;

	[ReorderableList]
	public List<ColourPalettePreset> colourBase;

	[Space(5f)]
	public ClothingColourSource colour1Source;

	[ReorderableList]
	public List<ColourPalettePreset> colour1;

	[Space(5f)]
	public ClothingColourSource colour2Source;

	[ReorderableList]
	public List<ColourPalettePreset> colour2;

	[Space(5f)]
	public ClothingColourSource colour3Source;

	[ReorderableList]
	public List<ColourPalettePreset> colour3;

	[Tooltip("Include this when using citizen stats to pick a style")]
	[Header("Suited Personality")]
	public bool includeInPersonalityMatching;

	[Tooltip("The base chance of selecting this item of clothing. This is added to by HEXACO and Traits below...")]
	[Range(0f, 10f)]
	[EnableIf("includeInPersonalityMatching")]
	public int baseChance;

	[Space(7f)]
	[InfoBox("If enabled: The below HEXACO values will combine for a score of 1 to 10: this will be used to calculate the likihood of this being chosen vs others.", EInfoBoxType.Normal)]
	[Tooltip("Use the below hexaco values to match to personality.")]
	public bool useHEXACO;

	public HEXACO hexaco;

	[Tooltip("Use character traits to match to personality.")]
	[Space(7f)]
	[InfoBox("If enabled: The below traits will be used to calculate the likihood of this being chosen vs others.", EInfoBoxType.Normal)]
	public bool useTraits;

	[ReorderableList]
	public List<TraitPickRule> characterTraits;

	[Header("Models")]
	[InfoBox("Note: The 'covers anchor' box will ensure only this model will be loaded to cover this anchor. If you want more than one model to be loaded for this anchor, make sure one is unchecked.", EInfoBoxType.Normal)]
	[ReorderableList]
	public List<ModelSettings> models;
}
