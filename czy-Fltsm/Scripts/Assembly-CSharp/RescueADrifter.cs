using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Rescue A Drifter")]
public class RescueADrifter : AchievementBase
{
	protected override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.AgentRescue, OnAgentRescued);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentRescue, OnAgentRescued);
	}

	private void OnAgentRescued(GameEvent gameEvent)
	{
		if (UnlockAchievement())
		{
			Uninitialize();
		}
	}
}
