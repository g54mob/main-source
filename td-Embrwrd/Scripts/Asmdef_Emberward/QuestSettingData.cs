using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestSettingData", menuName = "設定檔/QuestSettingData", order = 1)]
public class QuestSettingData : ScriptableObject
{
	[SerializeField]
	private int expRewardMultiplier;

	[SerializeField]
	private int gemRewardMultiplier;

	public List<QuestSetting> list_ChallengeData;

	[Header("獎勵設定 (簡單)")]
	public List<QuestRewardEntry> list_RewardSets_Easy;

	[Header("獎勵設定 (普通)")]
	public List<QuestRewardEntry> list_RewardSets_Normal;

	[Header("獎勵設定 (困難)")]
	public List<QuestRewardEntry> list_RewardSets_Hard;

	[Header("當沒有可用的獎勵時，使用的替代獎勵")]
	public QuestRewardEntry fallbackReward_Easy;

	public QuestRewardEntry fallbackReward_Normal;

	public QuestRewardEntry fallbackReward_Hard;

	public int ExpRewardMultiplier => 0;

	public int GemRewardMultiplier => 0;

	public QuestSetting GetQuestData(eQuestType type)
	{
		return null;
	}

	public QuestData GetRandomQuestData(eQuestDifficulty difficulty, List<eQuestType> excludeType = null)
	{
		return null;
	}
}
