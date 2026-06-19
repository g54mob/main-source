using System;
using System.Collections.Generic;

namespace Services.Missions
{
	[Serializable]
	public class MissionInstance
	{
		public string MissionId;

		public MissionStatus Status;

		public long StartedAt;

		public long CompletedAt;

		public string Title;

		public string Description;

		public List<ObjectiveInstance> Objectives = new List<ObjectiveInstance>();

		public MissionDefinition Definition;

		public bool RewardCollected;

		public MissionInstance()
		{
		}

		public MissionInstance(MissionDefinition def)
		{
			Definition = def;
			MissionId = def.MissionId;
			Status = MissionStatus.Active;
			StartedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			Title = def.Title;
			Description = def.Description;
			foreach (ObjectiveDefinition objective in def.Objectives)
			{
				Objectives.Add(new ObjectiveInstance(objective.ObjectiveId));
			}
			if (Definition.Reward.FlyCoins == 0.0)
			{
				RewardCollected = true;
			}
		}

		public ObjectiveInstance GetObjective(string objectiveId)
		{
			return Objectives.Find((ObjectiveInstance o) => o.ObjectiveId == objectiveId);
		}
	}
}
