using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Drifter Rescued Achievement")]
public class DrifterRescuedAchievement : AchievementBase
{
	[Header("Drifter Rescued Achievement")]
	[SerializeField]
	private ActorProfile _actorProfile;

	protected override void Initialize()
	{
		if (!Community.PlayerCommunity.HasActor(_actorProfile) || !UnlockAchievement())
		{
			GameEventDispatcher.AddListener(GameEventType.AgentRescue, OnAgentRescued);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentRescue, OnAgentRescued);
	}

	private void OnAgentRescued(GameEvent gameEvent)
	{
		if (gameEvent is AgentEvent agentEvent && agentEvent.AgentDescriptor.ActorProfile == _actorProfile && UnlockAchievement())
		{
			Uninitialize();
		}
	}
}
