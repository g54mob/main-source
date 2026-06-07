using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Gull Boss")]
public class GullBoss : AchievementBase
{
	protected override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.AgentHouseUpdated, OnHouseUpdated);
		GameEventDispatcher.AddListener(GameEventType.BirdHouseUpdated, OnHouseUpdated);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentHouseUpdated, OnHouseUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.BirdHouseUpdated, OnHouseUpdated);
	}

	private void OnHouseUpdated(GameEvent gameEvent)
	{
		int num = 0;
		int num2 = 0;
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			if ((bool)agent.ReservedHouse)
			{
				num++;
			}
		}
		foreach (Bird bird in Community.PlayerCommunity.Birds)
		{
			if ((bool)bird.BirdHouse)
			{
				num2++;
			}
		}
		if (num2 > num && UnlockAchievement())
		{
			Uninitialize();
		}
	}
}
