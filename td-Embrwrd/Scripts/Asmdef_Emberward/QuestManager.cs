using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
	[SerializeField]
	private QuestSettingData settingData;

	private AQuestBase currentQuest;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	protected override void Awake()
	{
	}

	public QuestData GetRandomQuestData(eQuestDifficulty difficulty, List<eQuestType> excludeType = null)
	{
		return null;
	}

	private void OnRequestLoadQuestInGame()
	{
	}

	public bool IsQuestSuccess()
	{
		return false;
	}
}
