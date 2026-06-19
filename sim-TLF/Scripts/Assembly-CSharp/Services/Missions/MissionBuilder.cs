using System;
using System.Collections.Generic;

namespace Services.Missions
{
	public class MissionBuilder
	{
		private readonly string _missionId;

		private string _title = "Нова місія";

		private string _description = string.Empty;

		private readonly List<ObjectiveDefinition> _objectives = new List<ObjectiveDefinition>();

		private readonly List<string> _prerequisites = new List<string>();

		private MissionReward _reward = new MissionReward();

		public MissionBuilder(string missionId)
		{
			_missionId = missionId;
		}

		public MissionBuilder WithTitle(string title)
		{
			_title = title;
			return this;
		}

		public MissionBuilder WithDescription(string description)
		{
			_description = description;
			return this;
		}

		public MissionBuilder RequiresCompletion(params string[] missionIds)
		{
			_prerequisites.AddRange(missionIds);
			return this;
		}

		public MissionBuilder WithObjective(ObjectiveType type, string targetId, int requiredAmount = 1, string objectiveId = null, string description = null)
		{
			_objectives.Add(new ObjectiveDefinition
			{
				ObjectiveId = (objectiveId ?? MissionFactory.GenerateId(type.ToString().ToLower())),
				Description = (description ?? $"{type} {targetId} x{requiredAmount}"),
				Type = type,
				TargetId = targetId,
				RequiredAmount = requiredAmount
			});
			return this;
		}

		public MissionBuilder Kill(string targetId, int amount = 1, string description = null)
		{
			return WithObjective(ObjectiveType.Kill, targetId, amount, null, description);
		}

		public MissionBuilder Collect(string targetId, int amount = 1, string description = null)
		{
			return WithObjective(ObjectiveType.Collect, targetId, amount, null, description);
		}

		public MissionBuilder Talk(string npcId, string description = null)
		{
			return WithObjective(ObjectiveType.Talk, npcId, 1, null, description);
		}

		public MissionBuilder Reach(string locationId, string description = null)
		{
			return WithObjective(ObjectiveType.Reach, locationId, 1, null, description);
		}

		public MissionBuilder Interact(string targetId, int amount = 1, string description = null)
		{
			return WithObjective(ObjectiveType.Interact, targetId, amount, null, description);
		}

		public MissionBuilder Deliver(string deliveryId, int amount, string description = null)
		{
			return WithObjective(ObjectiveType.Delivery, deliveryId, amount, null, description);
		}

		public MissionBuilder Destroy(string targetId, int amount = 1, string description = null)
		{
			return WithObjective(ObjectiveType.Destroy, targetId, amount, null, description);
		}

		public MissionBuilder Assemble(string assembleId, int amount = 1, string description = null)
		{
			return WithObjective(ObjectiveType.Assemble, assembleId, amount, null, description);
		}

		public MissionBuilder WithReward(float reward = 0f)
		{
			_reward = new MissionReward
			{
				FlyCoins = reward
			};
			return this;
		}

		public MissionBuilder WithReward(MissionReward reward)
		{
			_reward = reward;
			return this;
		}

		public MissionDefinition Build()
		{
			if (_objectives.Count == 0)
			{
				throw new InvalidOperationException("[MissionBuilder] Mission '" + _missionId + "' must have at least one objective.");
			}
			return new MissionDefinition
			{
				MissionId = _missionId,
				Title = _title,
				Description = _description,
				Objectives = new List<ObjectiveDefinition>(_objectives),
				Prerequisites = new List<string>(_prerequisites),
				Reward = _reward
			};
		}
	}
}
