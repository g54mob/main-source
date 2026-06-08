using System.Collections.Generic;

public class EventObjectiveGetLocationStarCompleted : EventObjectiveBase
{
	private List<string> LOCATION_IDs = new List<string>(new string[8] { "rocky_plateau", "deadwood_valley", "caustic_caves", "fungus_forest", "undead_crypt", "bronze_mine", "icy_ridge", "temple" });

	private int stars;

	private List<string> uniqueLocationIDs { get; set; }

	public EventObjectiveGetLocationStarCompleted(int goal, int stars, string starLevel)
		: base("complete_locations_level", goal)
	{
		this.stars = stars;
		description = string.Format(Te.xt("tid_q_obj_location_star_completed"), starLevel);
	}

	public override bool CheckConditions()
	{
		if (uniqueLocationIDs == null)
		{
			uniqueLocationIDs = new List<string>();
		}
		for (int i = 0; i < LOCATION_IDs.Count; i++)
		{
			if (!uniqueLocationIDs.Contains(LOCATION_IDs[i]) && QuestController.singleton.GetStarDifficultyForQuest(LOCATION_IDs[i]) >= stars)
			{
				uniqueLocationIDs.Add(LOCATION_IDs[i]);
			}
		}
		progress = uniqueLocationIDs.Count;
		return uniqueLocationIDs.Count < goal;
	}

	public override void Init()
	{
		QuestController.singleton.OnQuestCompleted += HandleQuestCompleted;
	}

	public override void End()
	{
		QuestController.singleton.OnQuestCompleted -= HandleQuestCompleted;
	}

	private void HandleQuestCompleted(Data.Quest quest, bool firstCompletion)
	{
		if (quest.level >= stars && LOCATION_IDs.Contains(quest.id) && !uniqueLocationIDs.Contains(quest.id))
		{
			uniqueLocationIDs.Add(quest.id);
			AddProgress();
		}
	}
}
