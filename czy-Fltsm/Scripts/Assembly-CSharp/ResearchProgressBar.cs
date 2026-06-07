using UnityEngine;

public class ResearchProgressBar : MonoBehaviour
{
	[SerializeField]
	private ImageSegmentBar _bar;

	private void OnEnable()
	{
		if (Application.isPlaying)
		{
			GameEventDispatcher.AddListener(GameEventType.ResearchStarted, OnResearchEvent);
			GameEventDispatcher.AddListener(GameEventType.ResearchProgressPointsUpdated, OnResearchEvent);
			CommunityResearch research = Community.PlayerCommunity.Research;
			UpdateProgress(research.CurrentProgress, research.CurrentCost);
		}
	}

	private void OnDisable()
	{
		if (Application.isPlaying)
		{
			GameEventDispatcher.RemoveListener(GameEventType.ResearchStarted, OnResearchEvent);
			GameEventDispatcher.RemoveListener(GameEventType.ResearchProgressPointsUpdated, OnResearchEvent);
		}
	}

	private void OnResearchEvent(GameEvent gameEvent)
	{
		if (gameEvent is ResearchEvent researchEvent)
		{
			UpdateProgress(researchEvent.Research.Progress, researchEvent.Research.Cost);
		}
	}

	private void UpdateProgress(int value, int max)
	{
		_bar.SetValue(value, max);
	}
}
