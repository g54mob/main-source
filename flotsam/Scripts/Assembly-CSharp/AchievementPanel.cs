using System.Collections.Generic;
using PajamaLlama.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;

public class AchievementPanel : Panel, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private QuestCompletedPopup _questCompletedPopup;

	[SerializeField]
	private float _questCompletedDuration;

	[SerializeField]
	private AchievementUnlockedPopup _achievementUnlockedPopup;

	[SerializeField]
	private float _achievementUnlockedDuration;

	private float _openDuration;

	private float _openTime;

	private Queue<Quest> _questQueue = new Queue<Quest>();

	private Queue<AchievementBase> _achievementQueue = new Queue<AchievementBase>();

	private void LateUpdate()
	{
		_openTime += GameSpeedManager.UnscaledDeltaTime;
		if (_openTime > _openDuration)
		{
			GameManager.UIManager.ClosePanel(ID);
		}
	}

	private void OnDisable()
	{
		if (_questQueue.Count > 0 || _achievementQueue.Count > 0)
		{
			FinalUpdate.RegisterOneShot(DequeueAchievement);
		}
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (context is Quest quest)
		{
			return OpenQuest(quest);
		}
		if (context is AchievementBase achievement)
		{
			return OpenAchievement(achievement);
		}
		return false;
	}

	private bool OpenQuest(Quest quest)
	{
		if (IsOpen())
		{
			_questQueue.Enqueue(quest);
			return true;
		}
		if (base.Open(quest.PanelID, quest))
		{
			_openDuration = _questCompletedDuration;
			_openTime = 0f;
			_questCompletedPopup.Activate(quest);
		}
		return false;
	}

	private bool OpenAchievement(AchievementBase achievement)
	{
		if (IsOpen())
		{
			_achievementQueue.Enqueue(achievement);
			return true;
		}
		if (base.Open(achievement.PanelID, achievement))
		{
			_openDuration = _achievementUnlockedDuration;
			_openTime = 0f;
			_achievementUnlockedPopup.Activate(achievement);
			return true;
		}
		return false;
	}

	private void DequeueAchievement()
	{
		if (_questQueue.TryDequeue(out var result))
		{
			GameManager.UIManager.DisplayPanel(result);
		}
		if (_achievementQueue.TryDequeue(out var result2))
		{
			GameManager.UIManager.DisplayPanel(result2);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		GameManager.UIManager.ClosePanel(ID);
	}
}
