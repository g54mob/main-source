using Factory;
using Helpers.GameCenter;
using Motorways;

public class GameCenterAchievementHandler : IAchievementHandler
{
	[Dependency]
	private IGameCenterAuthentication _gameCenterAuthentication;

	[Dependency]
	private TickRegistry _tickRegistry;

	[Dependency]
	private ActivePlayer _activePlayer;

	private bool _isSyncingAchievements;

	public bool CompleteAchievement(Achievement achievement, bool showNotification)
	{
		if (!_gameCenterAuthentication.IsAuthenticated || !GameCenterShared.GCAreAchievementsReady())
		{
			return false;
		}
		if (!TryGetPlatformAchievementId(achievement, out var result))
		{
			return false;
		}
		return GameCenterShared.GCSetAchievement(result, showNotification);
	}

	public bool IsAchievementCompleted(AchievementDefinition achievement)
	{
		if (!_gameCenterAuthentication.IsAuthenticated)
		{
			return false;
		}
		if (!TryGetPlatformAchievementId(achievement, out var result))
		{
			return false;
		}
		return GameCenterShared.GCIsAchievementComplete(result);
	}

	public bool IncrementStatistic(string statisticId, int increment)
	{
		return false;
	}

	private static bool TryGetPlatformAchievementId(Achievement fromAchievement, out string result)
	{
		if (Diagnostics.Verify(fromAchievement != null) && Diagnostics.Verify(fromAchievement.Definition != null))
		{
			return TryGetPlatformAchievementId(fromAchievement.Definition, out result);
		}
		result = "";
		return false;
	}

	private static bool TryGetPlatformAchievementId(AchievementDefinition fromAchievementDefinition, out string result)
	{
		if (!Diagnostics.Verify(fromAchievementDefinition != null))
		{
			result = "";
			return false;
		}
		return fromAchievementDefinition.TryGetStringDataForPlatformAndKey(AchievementData.AchievementPlatform.GameCenter, AchievementData.AchievementDataType.PlatformId, out result);
	}

	public void OnAppStart()
	{
		_activePlayer.PlayerChanged += delegate
		{
			if (!_isSyncingAchievements)
			{
				_isSyncingAchievements = true;
				_tickRegistry.AppTicking += SyncProfileAchievementsToGameCenter;
			}
		};
	}

	private void SyncProfileAchievementsToGameCenter(float deltaTime)
	{
		if (!_gameCenterAuthentication.IsAuthenticated || !GameCenterShared.GCAreAchievementsReady() || !_activePlayer.HasActivePlayer)
		{
			return;
		}
		foreach (Achievement achievement in _activePlayer.MotorwaysUserProfile.Achievements)
		{
			if (achievement.IsComplete() && !IsAchievementCompleted(achievement.Definition))
			{
				CompleteAchievement(achievement, showNotification: true);
			}
		}
		_isSyncingAchievements = false;
		_tickRegistry.AppTicking -= SyncProfileAchievementsToGameCenter;
	}
}
