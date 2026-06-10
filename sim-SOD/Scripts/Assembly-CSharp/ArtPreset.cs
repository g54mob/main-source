using System;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "artpreset_data", menuName = "Database/Decor/Art Preset")]
public class ArtPreset : SoCustomComparison
{
	public enum ArtOrientation
	{
		portrait = 0,
		landscape = 1,
		square = 2,
		poster = 3,
		litter = 4,
		wallGrimeTop = 5,
		wallGrimeBottom = 6,
		dynamicClue = 7,
		graffiti = 8
	}

	[Serializable]
	public class ArtPreference
	{
		public CharacterTrait trait;

		public int modifier;
	}

	public enum DynamicTextSouce
	{
		weaponsDealerPassword = 0,
		blackMarketTraderPassword = 1
	}

	public bool disable;

	[Header("Art Settings")]
	[ShowAssetPreview(64, 64)]
	public Texture2D texturePreview;

	public Material material;

	public List<ArtOrientation> orientationCompatibility;

	public float pixelScaleMultiplier;

	[Header("Suitability")]
	public bool allowInResidential;

	public bool allowInCommerical;

	public bool allowInLobby;

	public bool allowOnStreet;

	[Range(0f, 3f)]
	public int basePriority;

	[InfoBox("Colour matching gives a score out of 5", EInfoBoxType.Normal)]
	[Space(7f)]
	[Tooltip("used to match with room colour scheme")]
	public List<Color> colourMatching;

	[Range(0f, 5f)]
	public int colourMatchingScale;

	[Space(7f)]
	[Range(0f, 1f)]
	public float minimumWealth;

	[Range(0f, 1f)]
	public float maximumWealth;

	[Space(5f)]
	[InfoBox("The following gives a score out of x", EInfoBoxType.Normal)]
	[Range(0f, 5f)]
	public int roomMatchingScale;

	[Range(0f, 10f)]
	[Tooltip("0 = old fashioned/conservative, 1 = modern/liberal: Driven by the design style")]
	public int modernity;

	[Range(0f, 10f)]
	[Tooltip("0 = informal/cosy, 1 = clean/souless: Driven by the room type.")]
	public int cleanness;

	[Range(0f, 10f)]
	[Tooltip("0 = understated/quiet, 1 = loud/bold: Driven by the owner's personality")]
	public int loudness;

	[Tooltip("0 = cold/hard, 1 = warm/sensitive: Driven by the owner's personality")]
	[Range(0f, 10f)]
	public int emotive;

	public bool mustRequireTraitFromBelow;

	public List<ArtPreference> traitModifiers;

	[Header("Dynamic Text")]
	public bool useDynamicText;

	[EnableIf("useDynamicText")]
	public DynamicTextSouce dynamicTextSource;

	[EnableIf("useDynamicText")]
	public TMP_FontAsset textFont;

	[EnableIf("useDynamicText")]
	public Color textColour;

	[EnableIf("useDynamicText")]
	public float textSize;

	[Button(null, EButtonEnableMode.Always)]
	public void GenerateColourMatching()
	{
	}
}
