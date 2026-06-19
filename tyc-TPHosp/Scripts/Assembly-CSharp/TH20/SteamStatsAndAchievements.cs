#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using Steamworks;
using UnityConsole;

namespace TH20
{
	public class SteamStatsAndAchievements : MustCallDestroy, IStatsAndAchievements
	{
		private readonly CGameID _gameID;

		private readonly Callback<UserStatsReceived_t> _mUserStatsReceived;

		private readonly Callback<UserStatsStored_t> _mUserStatsStored;

		private readonly Callback<UserAchievementStored_t> _mAchievementStored;

		private readonly Dictionary<Stat, string> _statApiNames = new Dictionary<Stat, string>();

		private readonly Dictionary<AchievementId, string> _achievementApiNames = new Dictionary<AchievementId, string>();

		private bool _bInitialised;

		private bool _statsAreDirty;

		public SteamStatsAndAchievements()
		{
			_mUserStatsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
			_mUserStatsStored = Callback<UserStatsStored_t>.Create(OnUserStatsStored);
			_mAchievementStored = Callback<UserAchievementStored_t>.Create(OnAchievementStored);
			if (_mUserStatsReceived != null && _mUserStatsStored != null)
			{
				_ = _mAchievementStored;
			}
			_gameID = new CGameID(SteamUtils.GetAppID());
			_bInitialised = false;
			RequestPlayerStats();
			_statApiNames.Add(Stat.PatientsCured, "STAT_PATIENTS_CURED");
			_statApiNames.Add(Stat.ProjectsResearched, "STAT_PROJECTS_RESEARCHED");
			_statApiNames.Add(Stat.MarketingCampaignsRun, "STAT_MARKETING_CAMPAIGNS");
			_statApiNames.Add(Stat.MachinesUpgraded, "STAT_MACHINES_UPGRADED");
			_statApiNames.Add(Stat.GhostsCaptured, "STAT_GHOSTS_CAPTURED");
			_statApiNames.Add(Stat.StarsEarned, "STAT_STARS_EARNED");
			_statApiNames.Add(Stat.OrganisationValueReached, "STAT_ORGANISATION_VALUE");
			_statApiNames.Add(Stat.SilverEarned, "STAT_SILVER_EARNED");
			_statApiNames.Add(Stat.HospitalLevelReached, "STAT_HOSPITAL_LEVEL");
			_statApiNames.Add(Stat.MonoBrowShotChainReached, "STAT_MONOBROWS_SHOT_CHAIN");
			_statApiNames.Add(Stat.CollaborativeNodesCompleted, "STAT_COLLABORATIVE_NODES_COMPLETED");
			_statApiNames.Add(Stat.AliensExposed, "STAT_ALIENS_EXPOSED");
			_statApiNames.Add(Stat.EnergyGenerated, "STAT_GREEN_ENERGY");
			_statApiNames.Add(Stat.TimeTunnelPatientsCured, "STAT_TIME_TUNNEL_PATIENTS_CURED");
			_achievementApiNames.Add(AchievementId.AwardWinner, "ACHIEVEMENT_AWARD_WINNER");
			_achievementApiNames.Add(AchievementId.MonoBrowKill, "ACHIEVEMENT_MONOBROW_SHOT");
			_achievementApiNames.Add(AchievementId.MultiplayerChallenge, "ACHIEVEMENT_MULTIPLAYER_CHALLENGE");
			_achievementApiNames.Add(AchievementId.TrainPsychiatrist, "ACHIEVEMENT_TRAIN_PSYCHIATRIST");
			_achievementApiNames.Add(AchievementId.TrainResearcher, "ACHIEVEMENT_TRAIN_RESEARCHER");
			_achievementApiNames.Add(AchievementId.TrainSurgeon, "ACHIEVEMENT_TRAIN_SURGEON");
			_achievementApiNames.Add(AchievementId.ExplosionInjury, "ACHIEVEMENT_EXPLOSION_INJURY");
			_achievementApiNames.Add(AchievementId.CompleteRegion6, "ACHIEVEMENT_COMPLETE_REGION_6");
			_achievementApiNames.Add(AchievementId.CompleteCheesyGubbinsResearch, "ACHIEVEMENT_RESEARCH_CHEESY_GUBBINS");
			_achievementApiNames.Add(AchievementId.Level5DeluxSuite, "ACHIEVEMENT_LEVEL_5_DELUX_SUITE");
			_achievementApiNames.Add(AchievementId.TopReviewFromYeti, "ACHIEVEMENT_TOP_REVIEW_YETI");
			_achievementApiNames.Add(AchievementId.CuringSpree, "ACHIEVEMENT_CURING_SPREE");
			_achievementApiNames.Add(AchievementId.FinalWaveToplessMountain, "ACHIEVEMENT_FINAL_WAVE_TOPLESS_MOUNTAIN");
			_achievementApiNames.Add(AchievementId.UnlockAllPlotsOvergrowth, "ACHIEVEMENT_UNLOCK_ALL_PLOTS_OVERGROWTH");
			_achievementApiNames.Add(AchievementId.CompleteRegion7, "ACHIEVEMENT_COMPLETE_REGION_7");
			_achievementApiNames.Add(AchievementId.CompletedCollaborativeProject1, "ACHIEVEMENT_COMPLETE_SUPERBUG_1");
			_achievementApiNames.Add(AchievementId.CompletedCollaborativeProject5, "ACHIEVEMENT_COMPLETE_SUPERBUG_5");
			_achievementApiNames.Add(AchievementId.ActivateRoboJanitors, "ACHIEVEMENT_ACTIVATE_JANITORS");
			_achievementApiNames.Add(AchievementId.CureFrogborne, "ACHIEVEMENT_CURE_FROGBORNE");
			_achievementApiNames.Add(AchievementId.CompleteRegion8, "ACHIEVEMENT_COMPLETE_REGION_8");
			_achievementApiNames.Add(AchievementId.RemixRegion1, "ACHIEVEMENT_REMIX_REGION_1");
			_achievementApiNames.Add(AchievementId.CompleteRegion9, "ACHIEVEMENT_COMPLETE_REGION_9");
			_achievementApiNames.Add(AchievementId.MaxEcoRating, "ACHIEVEMENT_MAX_ECO_RATING");
			_achievementApiNames.Add(AchievementId.HerbGardenCure, "ACHIEVEMENT_HERB_GARDEN_CURE");
			_achievementApiNames.Add(AchievementId.RemixRegion2, "ACHIEVEMENT_REMIX_REGION_2");
			_achievementApiNames.Add(AchievementId.TrainRoderick, "ACHIEVEMENT_TRAIN_RODERICK");
			_achievementApiNames.Add(AchievementId.GoodVibe, "ACHIEVEMENT_GOOD_VIBE");
			_achievementApiNames.Add(AchievementId.SickInTheMud, "ACHIEVEMENT_SICK_IN_THE_MUD");
			_achievementApiNames.Add(AchievementId.CompleteRegion10, "ACHIEVEMENT_COMPLETE_REGION_10");
			_achievementApiNames.Add(AchievementId.TimeTunnelPatients100, "ACHIEVEMENT_BESTERIZER");
			_achievementApiNames.Add(AchievementId.TimeCure100, "ACHIEVEMENT_TIME_CURE_100");
			_achievementApiNames.Add(AchievementId.TimeCureLightheaded, "ACHIEVEMENT_TIME_CURE_LIGHTHEADED_VARIANTS");
			_achievementApiNames.Add(AchievementId.CompleteRegion11, "ACHIEVEMENT_COMPLETE_REGION_11");
			_achievementApiNames.Add(AchievementId.TopAllLeagues, "ACHIEVEMENT_TOP_ALL_LEAGUES");
			_achievementApiNames.Add(AchievementId.ClownCarCollectAndCure, "ACHIEVEMENT_CLOWN_CAR");
			_achievementApiNames.Add(AchievementId.AllAmbulances, "ACHIEVEMENT_ALL_AMBULANCES");
			_achievementApiNames.Add(AchievementId.CompleteRegion12, "ACHIEVEMENT_COMPLETE_REGION_12");
			ConsoleCommandsDatabase.RegisterCommand("ClearAchievements", "Clears all stats and achievements", "ClearAchievements", Debug_ClearAchievements);
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("ClearAchievements");
			base.Destroy();
		}

		public void SetStatsAsAchievementsData(StatsAsAchievementsData achievementData)
		{
		}

		public void SetStatValue(Stat stat, int value)
		{
			if (_bInitialised && _statApiNames.TryGetValue(stat, out var value2))
			{
				Logging.Info(LogChannels.Online, "SetStat '{0}' with value {1}", value2, value);
				SteamUserStats.SetStat(value2, value);
				_statsAreDirty = true;
			}
		}

		public void TriggerAchievement(AchievementId achievement)
		{
			if (_bInitialised && _achievementApiNames.TryGetValue(achievement, out var value))
			{
				Logging.Info(LogChannels.Online, "Achievement '{0}' unlock requested!", value);
				SteamUserStats.SetAchievement(value);
				_statsAreDirty = true;
			}
		}

		public void ClearStatsAndAchievements()
		{
			SteamUserStats.ResetAllStats(bAchievementsToo: true);
		}

		public void Update()
		{
			if (_statsAreDirty)
			{
				_statsAreDirty = false;
				Logging.Info(LogChannels.Online, "RB: SteamStatsAndAchievements - StoreStats called.");
				SteamUserStats.StoreStats();
			}
		}

		private bool RequestPlayerStats()
		{
			if (!SteamUser.BLoggedOn())
			{
				return false;
			}
			return SteamUserStats.RequestCurrentStats();
		}

		private void OnUserStatsReceived(UserStatsReceived_t pCallback)
		{
			if ((ulong)_gameID == pCallback.m_nGameID && pCallback.m_eResult == EResult.k_EResultOK)
			{
				_bInitialised = true;
			}
		}

		private void OnUserStatsStored(UserStatsStored_t pCallback)
		{
			if ((ulong)_gameID == pCallback.m_nGameID && pCallback.m_eResult != EResult.k_EResultOK)
			{
				if (pCallback.m_eResult == EResult.k_EResultInvalidParam)
				{
					Logging.Warning(LogChannels.Online, "SteamStatsAndAchievements.StoreStats - some stats failed to validate");
					return;
				}
				Logging.Warning(LogChannels.Online, "SteamStatsAndAchievements.StoreStats - failed. {0}", pCallback.m_eResult);
			}
		}

		private void OnAchievementStored(UserAchievementStored_t pCallback)
		{
			if ((ulong)_gameID == pCallback.m_nGameID)
			{
				if (pCallback.m_nMaxProgress == 0)
				{
					Logging.Info(LogChannels.Online, "Achievement '{0}' - Unlocked!", pCallback.m_rgchAchievementName);
					return;
				}
				Logging.Info(LogChannels.Online, "Achievement '{0}' - Progress callback ({1}/{2})", pCallback.m_rgchAchievementName, pCallback.m_nCurProgress, pCallback.m_nMaxProgress);
			}
		}

		private ConsoleCommandResult Debug_ClearAchievements(string[] args)
		{
			ClearStatsAndAchievements();
			return ConsoleCommandResult.Succeeded();
		}
	}
}
