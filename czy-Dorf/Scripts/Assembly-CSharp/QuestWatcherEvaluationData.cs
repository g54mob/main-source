using System;
using UnityEngine;

[SerializeField]
public class QuestWatcherEvaluationData
{
	public FulfillmentStatus fulfillmentStatus;

	public int remainingCount;

	public float valuePerElement;

	public QuestWatcherEvaluationData(QuestWatcher questWatcher)
	{
		fulfillmentStatus = questWatcher.CurrentFulfillmentStatus;
		QuestConditionWatcher conditionWatcher = questWatcher.GetConditionWatcher(0);
		remainingCount = conditionWatcher.RemainingValue;
		try
		{
			valuePerElement = ((conditionWatcher.Condition.conditionType == QuestConditionType.CloseGroup) ? 1f : (1f / questWatcher.CurrentQuest.difficultyIncreases[0].targetValueIncrease));
		}
		catch (Exception)
		{
			valuePerElement = 1f;
		}
	}
}
