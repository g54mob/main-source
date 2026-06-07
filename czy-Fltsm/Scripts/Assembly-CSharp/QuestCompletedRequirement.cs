using UnityEngine;

[CreateAssetMenu(fileName = "Quest Completed Requirement", menuName = "Flotsam/Tech Tree/Quest Completed Requirement")]
public class QuestCompletedRequirement : TechTreeRequirement
{
	[SerializeField]
	private QuestProperties _questProperties;

	public override GameEventType UpdateGUIEvent => GameEventType.QuestCompleted;

	public override bool IsMet()
	{
		return StoryManager.IsQuestCompleted(_questProperties);
	}

	public override bool TryGetAmount(out int amount)
	{
		amount = 0;
		return false;
	}

	public override string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return string.Empty;
	}
}
