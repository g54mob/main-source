using System;
using UnityEngine;

[Serializable]
public class DialogueConditionSavedDriftersCount : IDialogueCondition
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Saved Drifters Count";

	[SerializeField]
	private int _count;

	[SerializeField]
	private ComparisonType _comparisonType;

	bool IDialogueCondition.IsMet()
	{
		return GameStatsManager.GetActorStat(ActorType.Agent, ActorStat.RescuedCount).Compare(_comparisonType, _count);
	}

	public override string ToString()
	{
		return $"Rescued Drifters count {_comparisonType} {_count}";
	}
}
