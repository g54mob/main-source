using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using UnityEngine;

public class Quest : ScriptableObject, IWeightedRandomizable
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public int conditionIndex;

		public Func<ConditionDifficultyIncrease, bool> _003C_003E9__0;

		internal bool _003CDifficultyIncrease_003Eb__0(ConditionDifficultyIncrease x)
		{
			return x.targetCondition == conditionIndex;
		}
	}

	public string stringId;

	public QuestId id;

	[SerializeField]
	private float probability = 1f;

	public bool countsTowardsQuestLimit = true;

	public List<int> defaultWatchDirections;

	public WatchType watchType;

	public List<QuestCondition> conditions;

	public List<ConditionDifficultyIncrease> difficultyIncreases;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private QuestManager questManager;

	public int tileReward;

	public float lockQuestProbability = 0.5f;

	public QuestDisplayType displayType;

	public GroupType groupType;

	public float Probability => probability;

	public int DifficultyIncrease(int conditionIndex, int overwriteLevel = -1)
	{
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals2.conditionIndex = conditionIndex;
		float num = 0f;
		foreach (ConditionDifficultyIncrease item in Enumerable.Where(difficultyIncreases, (ConditionDifficultyIncrease x) => x.targetCondition == CS_0024_003C_003E8__locals2.conditionIndex))
		{
			float f = ((overwriteLevel == -1) ? rewardSystem.Level : overwriteLevel);
			f = Mathf.Pow(f, questManager.Configuration.ExponentialQuestDifficultyFactor);
			num += f / (float)item.levelsNeededPerIncrease * item.targetValueIncrease * rewardSystem.Configuration.globalDifficultyMultiplier * questManager.Configuration.GlobalQuestDifficultyMultiplier;
		}
		return Mathf.RoundToInt(num);
	}

	private void OnValidate()
	{
		if (conditions != null && conditions.Count > 0)
		{
			groupType = conditions[0].groupType;
		}
		else
		{
			groupType = null;
		}
	}
}
