using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Research All Technologies")]
public class ResearchAllTechnologies : AchievementBase
{
	protected override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.ResearchFinished, OnResearchFinished);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ResearchFinished, OnResearchFinished);
	}

	private void OnResearchFinished(GameEvent gameEvent)
	{
		if (GameSettings.Instance.TechTree.IsFullyUnlocked() && UnlockAchievement())
		{
			Uninitialize();
		}
	}
}
