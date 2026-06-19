using Unity.Entities;
using UnityEngine;

public struct SkillTalentTreeBlob
{
	public BlobArray<SkillTalentInfoBlob> skillTalents;

	public ConditionData GetConditionDataForSkillTalent(int talentIndex, int points)
	{
		if (talentIndex < skillTalents.Length)
		{
			return new ConditionData
			{
				conditionID = skillTalents[talentIndex].givesCondition,
				value = skillTalents[talentIndex].conditionValuePerPoint * points
			};
		}
		Debug.LogError($"Could not find skill talent with index {talentIndex} when trying to get condition data.");
		return default(ConditionData);
	}
}
