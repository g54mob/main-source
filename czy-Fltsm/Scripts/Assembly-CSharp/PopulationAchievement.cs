using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Population Achievement")]
public class PopulationAchievement : AchievementBase
{
	[Header("Population Achievement")]
	[SerializeField]
	private ActorType _actorType;

	[SerializeField]
	[Tooltip("The amount of actors that meet all requirements needed to unlock the achievement. \r\n If the requirement is set to 0 (or a smaller amount) the other requirements are applied to all actors in the town.")]
	private int _requirement;

	[SerializeField]
	[Tooltip("Should the actor be housed")]
	private bool _requiresHouse;

	[SerializeField]
	[ConditionalHide("_requiresHouse")]
	[Tooltip("Is a specific house required? \r\nNOTE: This only applies to agents.")]
	private BuildableProperties[] _requiredHouseProperties;

	protected override void Initialize()
	{
		if (_requirement > 0 || _requiresHouse)
		{
			switch (_actorType)
			{
			case ActorType.Agent:
				if (_requiresHouse)
				{
					GameEventDispatcher.AddListener(GameEventType.AgentHouseUpdated, OnAgentHouseUpdated);
				}
				else
				{
					GameEventDispatcher.AddListener(GameEventType.AgentRescue, OnAgentRescue);
				}
				break;
			case ActorType.Seagull:
				if (_requiresHouse)
				{
					GameEventDispatcher.AddListener(GameEventType.BirdHouseUpdated, OnBirdHouseUpdated);
				}
				else
				{
					GameEventDispatcher.AddListener(GameEventType.BirdRescue, OnBirdRescue);
				}
				break;
			}
		}
		else
		{
			Debug.LogException(new Exception($"PopulationAchievement '{this}' is not setup correctly and will therefore never be unlocked."));
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentHouseUpdated, OnAgentHouseUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.AgentRescue, OnAgentRescue);
		GameEventDispatcher.RemoveListener(GameEventType.BirdHouseUpdated, OnBirdHouseUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.BirdRescue, OnBirdRescue);
	}

	private void OnAgentHouseUpdated(GameEvent gameEvent)
	{
		int num = 0;
		int num2 = ((_requirement <= 0) ? Community.PlayerCommunity.Agents.Count : _requirement);
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			if ((bool)agent.ReservedHouse && (_requiredHouseProperties.IsNullOrEmpty() || _requiredHouseProperties.Contains(agent.ReservedHouse.Buildable.Properties)))
			{
				num++;
			}
		}
		if (num >= num2 && UnlockAchievement())
		{
			Uninitialize();
		}
	}

	private void OnAgentRescue(GameEvent gameEvent)
	{
		if (_requirement > 0 && Community.PlayerCommunity.Agents.Count >= _requirement && UnlockAchievement())
		{
			Uninitialize();
		}
	}

	private void OnBirdHouseUpdated(GameEvent gameEvent)
	{
		int num = 0;
		if (_requirement > 0)
		{
			_ = _requirement;
		}
		else
		{
			_ = Community.PlayerCommunity.Birds.Count;
		}
		foreach (Bird bird in Community.PlayerCommunity.Birds)
		{
			if ((bool)bird.BirdHouse)
			{
				num++;
			}
		}
		if (num >= _requirement && UnlockAchievement())
		{
			Uninitialize();
		}
	}

	private void OnBirdRescue(GameEvent gameEvent)
	{
		if (_requirement > 0 && Community.PlayerCommunity.Birds.Count >= _requirement && UnlockAchievement())
		{
			Uninitialize();
		}
	}
}
