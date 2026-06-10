using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "retailitem_data", menuName = "Database/Retail Item")]
public class RetailItemPreset : SoCustomComparison
{
	public enum Tags
	{
		starchProduct = 0
	}

	public enum MenuCategory
	{
		food = 0,
		drinks = 1,
		snacks = 2,
		none = 3
	}

	[Header("Item")]
	public InteractablePreset itemPreset;

	[Tooltip("Can this be ranked by the citizen as a favourite item? If true this will be used to calculate favourite places, as well as appear on shopping lists etc.")]
	public bool canBeFavourite;

	[Tooltip("If true this item stays warm for 1 hour after it was purchased.")]
	public bool isHot;

	[Tooltip("A citizen can pick this to buy at a shop")]
	public bool isConsumable;

	[Tooltip("If this is entered, upon singleton creation the evidence will be named using this entry.")]
	public string brandName;

	public List<Tags> tags;

	[Header("Menu")]
	public CompanyPreset.CompanyCategory desireCategory;

	public MenuCategory menuCategory;

	[Tooltip("Which ethnicity is this food (if any)")]
	[ReorderableList]
	[Header("Ethnicity")]
	public List<Descriptors.EthnicGroup> ethnicity;

	[Range(0f, 1f)]
	[Header("Citizen Suitability")]
	[Tooltip("Citizen's money must be higher than this to list this item in favourites")]
	public float minimumWealth;

	[ReorderableList]
	public List<CharacterTrait> mustFeatureTraits;

	[ReorderableList]
	public List<CharacterTrait> cantFeatureTrait;

	[ReorderableList]
	public List<CharacterTrait> preferredTraits;

	[Header("Stat Modifiers")]
	[Tooltip("This is applied as progress increases")]
	public float nourishment;

	[Tooltip("This is applied as progress increases")]
	public float hydration;

	[Tooltip("This is applied as progress increases")]
	public float alertness;

	[Tooltip("This is applied as progress increases")]
	public float energy;

	[Tooltip("This is applied as progress increases")]
	public float excitement;

	[Tooltip("This is applied as progress increases")]
	public float chores;

	[Tooltip("This is applied as progress increases")]
	public float hygiene;

	[Tooltip("This is applied as progress increases")]
	public float bladder;

	[Tooltip("This is applied as progress increases")]
	public float heat;

	[Tooltip("This is applied as progress increases")]
	public float drunk;

	[Tooltip("This is applied as progress increases")]
	public float sick;

	[Tooltip("This is applied as progress increases")]
	public float headache;

	[Tooltip("This is applied as progress increases")]
	public float wet;

	[Tooltip("This is applied as progress increases")]
	public float brokenLeg;

	[Tooltip("This is applied as progress increases")]
	public float bruised;

	[Tooltip("This is applied as progress increases")]
	public float blackEye;

	[Tooltip("This is applied as progress increases")]
	public float blackedOut;

	[Tooltip("This is applied as progress increases")]
	public float numb;

	[Tooltip("This is applied as progress increases")]
	public float bleeding;

	[Tooltip("This is applied as progress increases")]
	public float wellRested;

	[Tooltip("This is applied as progress increases")]
	public float breath;

	[Tooltip("This is applied as progress increases")]
	public float starchAddiction;

	[Tooltip("This is applied as progress increases")]
	public float poisoned;

	[Tooltip("This is applied as progress increases")]
	public float health;
}
