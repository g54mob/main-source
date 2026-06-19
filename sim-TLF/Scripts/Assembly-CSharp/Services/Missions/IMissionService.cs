using System;
using System.Collections.Generic;

namespace Services.Missions
{
	public interface IMissionService
	{
		event Action<MissionInstance> OnMissionStarted;

		event Action<MissionInstance> OnMissionCompleted;

		event Action<MissionInstance, ObjectiveInstance> OnObjectiveUpdated;

		bool StartMission(MissionDefinition def, bool ignorePrerequisites = false);

		void FailMission(string missionId);

		void ForceComplete(string missionId);

		MissionInstance Get(string missionId);

		MissionInstance GetActive(string missionId);

		MissionInstance GetCompleted(string missionId);

		bool IsActive(string missionId);

		bool IsCompleted(string missionId);

		IReadOnlyCollection<MissionInstance> GetAllActive();

		IReadOnlyCollection<MissionInstance> GetAllCompleted();

		void MarkRewardCollected(string missionId);

		bool IsRewardCollected(string missionId);
	}
}
