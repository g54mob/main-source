using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest Completed Requirement Provider", menuName = "Flotsam/Tech Tree/Quest Completed Requirement Provider")]
public class QuestCompletedRequirementProvider : TechTreeRequirementProvider
{
	public override TechTreeRequirement CreateRequirementInstance()
	{
		QuestCompletedRequirement questCompletedRequirement = ScriptableObject.CreateInstance<QuestCompletedRequirement>();
		questCompletedRequirement.SetProvider(this);
		return questCompletedRequirement;
	}

	public override Sprite GetIcon(TechTreeRequirement techTreeRequirement)
	{
		Debug.Log(new NotImplementedException());
		return null;
	}

	public override bool IsProviderFor(TechTreeRequirement techTreeRequirement)
	{
		return techTreeRequirement is QuestCompletedRequirement;
	}
}
