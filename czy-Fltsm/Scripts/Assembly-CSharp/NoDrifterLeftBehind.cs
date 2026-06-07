using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/No Drifter Left Behind")]
public class NoDrifterLeftBehind : AchievementBase
{
	protected override AchievementId DefaultId => base.DefaultId;

	public static bool NoDrifterDied { get; private set; }

	protected override void Initialize()
	{
		foreach (Day day in GameManager.TimeManager.Days)
		{
			if (day.Report.HasActorDeath(ActorType.Agent))
			{
				NoDrifterDied = false;
				return;
			}
		}
		NoDrifterDied = true;
		GameEventDispatcher.AddListener(GameEventType.AgentDeath, OnAgentDeath);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentDeath, OnAgentDeath);
	}

	public override void UnlockAchievement(PlayerProfile playerProfile)
	{
		if (NoDrifterDied)
		{
			playerProfile.UnlockAchievement(this);
		}
		NoDrifterDied = false;
	}

	private void OnAgentDeath(GameEvent gameEvent)
	{
		NoDrifterDied = false;
		Uninitialize();
	}
}
