using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Expertise/Properties")]
public class ExpertiseProperties : ScriptableObject
{
	public enum Mode
	{
		PerSecond = 0,
		PerItem = 1
	}

	[Serializable]
	public struct FishExperience
	{
		public ItemProperties Fish;

		public float Experience;
	}

	[SerializeField]
	private int _maximumLevel = 15;

	[Header("Experience Requirements")]
	[SerializeField]
	private float _communityBaseExperienceRequirement = 300f;

	[SerializeField]
	private float _communityPerLevelExperienceRequirement = 100f;

	[SerializeField]
	private float _drifterBaseExperienceRequirement = 300f;

	[SerializeField]
	private float _drifterPerLevelExperienceRequirement = 100f;

	[Header("Salvaging")]
	[SerializeField]
	[Tooltip("Per item salvaged.")]
	private float _salvageExperience = 10f;

	[Header("Fishing")]
	[SerializeField]
	private List<FishExperience> _fishingChairExperiences = new List<FishExperience>();

	[SerializeField]
	private List<FishExperience> _fishingBoatExperiences = new List<FishExperience>();

	[Header("Construction")]
	[SerializeField]
	[Tooltip("Per item built / salvaged of a construction.")]
	private float _constructionExperience = 10f;

	[Header("Hauling")]
	[SerializeField]
	[Tooltip("Per item put in / taken out of an inventory.")]
	private float _haulExperience = 10f;

	[Header("Production")]
	[SerializeField]
	private Mode _productionExperienceMode;

	[SerializeField]
	[Tooltip("Per second worked")]
	[ConditionalEnumHide("_productionExperienceMode", 0, false, HideInInspector = true)]
	private float _productionExperiencePerSecond = 10f;

	[SerializeField]
	[Tooltip("Per recipe produced.")]
	[ConditionalEnumHide("_productionExperienceMode", 1, false, HideInInspector = true)]
	private float _recycleExperience = 10f;

	[SerializeField]
	[Tooltip("Per recipe produced.")]
	[ConditionalEnumHide("_productionExperienceMode", 1, false, HideInInspector = true)]
	private float _cookingExperience = 10f;

	[SerializeField]
	[Tooltip("Per recipe produced.")]
	[ConditionalEnumHide("_productionExperienceMode", 1, false, HideInInspector = true)]
	private float _liquidsExperience = 10f;

	[Header("Research")]
	[SerializeField]
	[Tooltip("Per research unlocked.")]
	private float _researchExperience = 10f;

	[Header("Energy")]
	[SerializeField]
	[Tooltip("Per second energy generated.")]
	private float _energyGeneratedExperience = 0.1f;

	public int MaximumLevel => _maximumLevel;

	public float CommunityBaseExperienceRequirement => _communityBaseExperienceRequirement;

	public float CommunityPerLevelExperienceRequirement => _communityPerLevelExperienceRequirement;

	public float DrifterBaseExperienceRequirement => _drifterBaseExperienceRequirement;

	public float DrifterPerLevelExperienceRequirement => _drifterPerLevelExperienceRequirement;

	public float SalvageExperience => _salvageExperience;

	public float ConstructionExperience => _constructionExperience;

	public float HaulExperience => _haulExperience;

	public float ResearchExperience => _researchExperience;

	public float EnergyGeneratedExperience => _energyGeneratedExperience;

	public float ReturnCommunityLevelRequirement(int level)
	{
		return CommunityBaseExperienceRequirement + CommunityPerLevelExperienceRequirement * (float)level;
	}

	public float ReturnDrifterLevelRequirement(int level)
	{
		return DrifterBaseExperienceRequirement + DrifterPerLevelExperienceRequirement * (float)level;
	}

	public float ReturnFishingExperience(ItemProperties fish, bool isFishingFromBoat)
	{
		if ((isFishingFromBoat ? _fishingBoatExperiences : _fishingChairExperiences).TryFind(out var foundItem, (FishExperience item) => item.Fish == fish))
		{
			return foundItem.Experience;
		}
		Debug.LogException(new NotImplementedException("Fish of type \"" + fish.name + "\" is not present in Fishing " + (isFishingFromBoat ? "Boat" : "Chair") + " experience table and therefore cannot award experience!"));
		return 0f;
	}

	public float ReturnProductionExperience(ProductionRecipeProperties recipe, DrifterAttributes.AttributeType attribute)
	{
		return _productionExperienceMode switch
		{
			Mode.PerSecond => recipe.ProductionTime * _productionExperiencePerSecond + recipe.ProductionExperience, 
			Mode.PerItem => ReturnAttributeExperience(attribute), 
			_ => throw new NotImplementedException(), 
		};
	}

	private float ReturnAttributeExperience(DrifterAttributes.AttributeType attribute)
	{
		return attribute switch
		{
			DrifterAttributes.AttributeType.Recycling => _recycleExperience, 
			DrifterAttributes.AttributeType.Cooking => _cookingExperience, 
			DrifterAttributes.AttributeType.Liquids => _liquidsExperience, 
			_ => throw new NotImplementedException(), 
		};
	}
}
