namespace TH20.Analytics
{
	public static class GameEventEx
	{
		public static GameEvent AddLevelHeader(this GameEvent gameEvent, Level level)
		{
			string value = level.Config.UniqueId;
			bool flag = level.IsSandbox();
			if (flag)
			{
				value = "000";
			}
			return gameEvent.AddParam("levelDisplayName", level.Config.GetDisplayName()).AddParam("levelUniqueId", value).AddParam("levelPlaythroughID", level.Metagame.LevelPlaythroughID(level.Config))
				.AddParam("metagamePlaythroughID", level.Metagame.PlaythroughID)
				.AddParam("isSandboxLevel", flag);
		}

		public static GameEvent AddGameDate(this GameEvent gameEvent, ref GameDate gameDate, bool addYear, bool addMonth, bool addDays)
		{
			gameEvent.AddParam("levelDate", gameDate.ToString(showTime: false));
			if (addYear)
			{
				gameEvent.AddParam("levelYearsPassed", gameDate.Year);
			}
			if (addMonth)
			{
				gameEvent.AddParam("levelMonthsPassed", gameDate.AsTotalMonths());
			}
			if (addDays)
			{
				gameEvent.AddParam("levelDaysPassed", gameDate.AsTotalDays());
			}
			return gameEvent;
		}

		public static GameEvent AddCollaborativeProjectNodeHeader(this GameEvent gameEvent, CollaborativeProject project, OnlineMetadataManager onlineMetadataManager)
		{
			return gameEvent.AddParam("projectId", project.ProjectID).AddParam("projectDefinition", project.LocalPlayerData.Definition.Name.Term).AddParam("totalNodeCompletions", project.Portfolio.PortfolioDataController.PortfolioData.NodesCompleted)
				.AddParam("numFriendsWhoPlayedTPH", onlineMetadataManager.DataCacheEntryCount)
				.AddParam("numCollaborators", (project.LocalPlayerData?.Collaborators != null) ? project.LocalPlayerData.Collaborators.Count : (-1));
		}

		public static GameEvent AddCollaborativeProjectCompletedHeader(this GameEvent gameEvent, CollaborativeProject project, OnlineMetadataManager onlineMetadataManager)
		{
			return gameEvent.AddParam("projectId", project.ProjectID).AddParam("projectDefinition", project.LocalPlayerData.Definition.Name.Term).AddParam("totalNodeCompletions", project.Portfolio.PortfolioDataController.PortfolioData.NodesCompleted)
				.AddParam("numFriendsWhoPlayedTPH", onlineMetadataManager.DataCacheEntryCount)
				.AddParam("numCollaborators", (project.LocalPlayerData?.Collaborators != null) ? project.LocalPlayerData.Collaborators.Count : (-1));
		}

		public static GameEvent AddSuperBugNodeHeader(this GameEvent gameEvent, SuperBugDefinition superBugDefinition, CollaborativePortfolio portfolio)
		{
			return gameEvent.AddParam("superBugId", superBugDefinition.SuperBugID).AddParam("totalNodeCompletions", portfolio.PortfolioDataController.PortfolioData.NodesCompleted);
		}
	}
}
