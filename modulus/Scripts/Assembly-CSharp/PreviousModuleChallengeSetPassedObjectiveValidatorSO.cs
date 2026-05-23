#define ENABLE_DEBUG_ERRORS
using Data.Objectives.Validators;
using Presentation.Locators;
using UnityEngine;
using Utils;

[CreateAssetMenu(menuName = "Objectives/Validators/PreviousModuleChallengeSetPassed", fileName = "PreviousModuleChallengeSetPassedObjectiveValidatorSO")]
public class PreviousModuleChallengeSetPassedObjectiveValidatorSO : AbstractObjectiveValidator
{
	[SerializeField]
	private ObjectivesManagerLocator _objectiveManagerLocator;

	public override bool IsValid()
	{
		if (ObjectivesValidatorContext.CurrentCategory == null)
		{
			this.LogError("ValidatorContext.CurrentCategory is not set!", "IsValid", 22);
			return false;
		}
		return HasPreviousModuleChallengeCategoryPassed(ObjectivesValidatorContext.CurrentCategory);
	}

	private bool HasPreviousModuleChallengeCategoryPassed(ObjectiveTargetCategorySO category)
	{
		ModuleChallengeSO moduleChallengeSO = _objectiveManagerLocator.ObjectivesManager.ModuleChallengeSO;
		for (int i = 0; i < moduleChallengeSO.Sets.Count; i++)
		{
			ModuleChallengeSet moduleChallengeSet = moduleChallengeSO.Sets[i];
			for (int j = 0; j < moduleChallengeSet.Categories.Count; j++)
			{
				if (!(moduleChallengeSet.Categories[j] != category))
				{
					return CompareWithPreviousSet(i);
				}
			}
		}
		return false;
	}

	private bool CompareWithPreviousSet(int setIndex)
	{
		if (setIndex == 0)
		{
			return true;
		}
		ObjectivesPersistentSO objectivesPersistentSO = _objectiveManagerLocator.ObjectivesManager.ObjectivesPersistentSO;
		ModuleChallengeSet moduleChallengeSet = _objectiveManagerLocator.ObjectivesManager.ModuleChallengeSO.Sets[setIndex - 1];
		for (int i = 0; i < moduleChallengeSet.Categories.Count; i++)
		{
			ObjectiveTargetCategorySO objectiveTargetCategorySO = moduleChallengeSet.Categories[i];
			if (objectiveTargetCategorySO.Resource.HasResourceData)
			{
				if (objectivesPersistentSO.GetDeliveryTargetClaimedTiersAmount(objectiveTargetCategorySO.Resource.GetResourceID()) > 0)
				{
					return true;
				}
			}
			else if (objectiveTargetCategorySO.Resource.HasShapeData && objectivesPersistentSO.GetModuleChallengeClaimedTier(objectiveTargetCategorySO.Resource.GetRotationIndependentHash()) > 0)
			{
				return true;
			}
		}
		return false;
	}
}
