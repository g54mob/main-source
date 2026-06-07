using UnityEngine;
using UnityEngine.UI;

public class TownExperienceTracker : SceneBehaviour
{
	[SerializeField]
	private Image _progressSlider;

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.CommunityExperienceUpdated, OnCommunityExperienceUpdated);
		OnCommunityExperienceUpdated(null);
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.CommunityExperienceUpdated, OnCommunityExperienceUpdated);
	}

	private void OnCommunityExperienceUpdated(GameEvent gameEvent)
	{
		_progressSlider.fillAmount = ExpertiseManager.ResearchPointProgress;
	}
}
