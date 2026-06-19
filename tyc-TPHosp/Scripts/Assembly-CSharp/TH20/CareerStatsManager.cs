using System;
using I2.Loc;
using TH20.EventAwardRemixBadge;
using TH20.EventAwardSilver;
using TH20.EventAwardStar;

namespace TH20
{
	[DontSave]
	public class CareerStatsManager : MustCallDestroy, TH20.EventAwardStar.Interface, IGameEventCallback, TH20.EventAwardSilver.Interface, TH20.EventAwardRemixBadge.Interface
	{
		public enum Type
		{
			LevelCureRate = 0,
			LevelHospitalValue = 1,
			LevelStaffMorale = 2,
			LevelReputation = 3,
			LevelPrestige = 4,
			LevelBalance = 5,
			LevelStaffCount = 6,
			LevelCuresPerYear = 7,
			LevelYearlyIncome = 8,
			LevelStatLast = 8,
			TotalStars = 9,
			TotalFoundationValue = 10,
			TotalSilverEarned = 11,
			TotalRemixBadges = 12
		}

		public static readonly string[] StatNames = new string[12]
		{
			"Cure Rate", "Hospital Value", "Staff Morale", "Reputation", "Hospital Level", "Balance", "Staff Count", "Cures Per Year", "Yearly Income", "Stars",
			"Foundation Value", "Silver Earned"
		};

		public static readonly string[] StatNameLocTerms = new string[12]
		{
			"Menu/CareerStats/CureRate_CS", "Menu/CareerStats/HospitalValue_CS", "Menu/CareerStats/StaffMorale_CS", "Menu/CareerStats/Reputation_CS", "Menu/CareerStats/HospitalLevel_CS", "Menu/CareerStats/Balance_CS", "Menu/CareerStats/StaffCount_CS", "Menu/CareerStats/CuresPerYear_CS", "Menu/CareerStats/YearlyIncome_CS", "Menu/CareerStats/Stars_CS",
			"Menu/CareerStats/FoundationValue_CS", "Menu/CareerStats/KudoshEarned_CS"
		};

		private readonly Metagame _metagame;

		public CareerStatsManager(Metagame metagame)
		{
			_metagame = metagame;
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				LevelEventsIntermediary levelEventsIntermediary = _metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(levelEventsIntermediary.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
				LevelEventsIntermediary levelEventsIntermediary2 = _metagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnEndOfMonthStatsCompiled = (Action<LevelStatsDatabase.MonthStats>)Delegate.Combine(levelEventsIntermediary2.OnEndOfMonthStatsCompiled, new Action<LevelStatsDatabase.MonthStats>(OnEndOfMonthStatsReceived));
				_metagame.OnSilverAwarded.Add(this);
				_metagame.OnStarAwarded.Add(this);
				_metagame.OnRemixBadgeAwarded.Add(this);
				UploadLeaderboardStats();
			}
		}

		public override void Destroy()
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				LevelEventsIntermediary levelEventsIntermediary = _metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(levelEventsIntermediary.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
				LevelEventsIntermediary levelEventsIntermediary2 = _metagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnEndOfMonthStatsCompiled = (Action<LevelStatsDatabase.MonthStats>)Delegate.Remove(levelEventsIntermediary2.OnEndOfMonthStatsCompiled, new Action<LevelStatsDatabase.MonthStats>(OnEndOfMonthStatsReceived));
				_metagame.OnSilverAwarded.Remove(this);
				_metagame.OnStarAwarded.Remove(this);
				_metagame.OnRemixBadgeAwarded.Remove(this);
			}
			base.Destroy();
		}

		public static string GetStatNameLoc(Type statType)
		{
			return LocalizationManager.GetTranslation(StatNameLocTerms[(int)statType]);
		}

		public bool GetFriendScore(Type statType, OnlinePlayerID onlinePlayerID, out int score, LevelConfig levelOverride = null)
		{
			score = 0;
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return false;
			}
			OnlineManager.GetPlayerInfo(onlinePlayerID);
			OnlineMetadata onlineMetadata = _metagame.OnlineMetadataManager.GetOnlineMetadata(onlinePlayerID);
			if (onlineMetadata == null)
			{
				return false;
			}
			if (!onlineMetadata.IsVisible())
			{
				return false;
			}
			return onlineMetadata.GetStat(GetStatName(statType, levelOverride), out score);
		}

		public bool GetRivalHospitalScore(Type statType, out int score)
		{
			score = 0;
			return true;
		}

		public int GetLocalPlayerStat(Type statType)
		{
			Level currentLevel = _metagame.CurrentLevel;
			if (currentLevel == null)
			{
				return statType switch
				{
					Type.TotalStars => _metagame.TotalStars(), 
					Type.TotalSilverEarned => _metagame.TotalSilverCumulative(), 
					Type.TotalFoundationValue => _metagame.TotalFoundationValue(), 
					Type.TotalRemixBadges => _metagame.TotalRemixBadges(), 
					_ => 0, 
				};
			}
			switch (statType)
			{
			case Type.LevelCureRate:
				return (int)currentLevel.LevelStatsDatabase.GetCumulativeLevelStats().CureRate;
			case Type.LevelHospitalValue:
				return currentLevel.LevelStatsDatabase.HospitalValue;
			case Type.LevelReputation:
				return (int)(currentLevel.ReputationTracker.OverallReputation * 100f);
			case Type.LevelStaffMorale:
				return (int)(currentLevel.CharacterManager.StaffMorale * 100f);
			case Type.LevelPrestige:
				return currentLevel.PrestigeTracker.Level;
			case Type.LevelBalance:
				return currentLevel.FinanceManager.Balance;
			case Type.LevelStaffCount:
				return currentLevel.CharacterManager.StaffMembers.Count;
			case Type.LevelCuresPerYear:
				return currentLevel.LevelStatsDatabase.GetLatestCompletedYearStats().NumberOfTreatmentCures;
			case Type.LevelYearlyIncome:
			{
				currentLevel.LevelStatsDatabase.GetPreviousMonthsProfitAndLoss(12, out var _, out var _, out var profit);
				return profit;
			}
			case Type.TotalStars:
				return _metagame.TotalStars();
			case Type.TotalSilverEarned:
				return _metagame.TotalSilverCumulative();
			case Type.TotalFoundationValue:
				return _metagame.TotalFoundationValue();
			case Type.TotalRemixBadges:
				return _metagame.TotalRemixBadges();
			default:
				return 0;
			}
		}

		private string GetStatName(Type statType, LevelConfig levelOverride = null)
		{
			string name = Enum.GetName(typeof(Type), statType);
			if (statType <= Type.LevelYearlyIncome)
			{
				return $"{((levelOverride != null) ? levelOverride.UniqueId : _metagame.CurrentLevel.UniqueID)}_{name}";
			}
			return name;
		}

		private void UploadLeaderboardStats()
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				OnlineMetadataManager onlineMetadataManager = _metagame.OnlineMetadataManager;
				onlineMetadataManager.SetLocalPlayerStat(GetStatName(Type.TotalStars), GetLocalPlayerStat(Type.TotalStars));
				onlineMetadataManager.SetLocalPlayerStat(GetStatName(Type.TotalFoundationValue), GetLocalPlayerStat(Type.TotalFoundationValue));
				onlineMetadataManager.SetLocalPlayerStat(GetStatName(Type.TotalSilverEarned), GetLocalPlayerStat(Type.TotalSilverEarned));
				onlineMetadataManager.SetLocalPlayerStat(GetStatName(Type.TotalRemixBadges), GetLocalPlayerStat(Type.TotalRemixBadges));
				onlineMetadataManager.Upload(immediately: true);
			}
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			if ((day == 7 || day == 21) && OnlineManager.IsInitializedAndLoggedOn())
			{
				OnlineMetadataManager onlineMetadataManager = _metagame.OnlineMetadataManager;
				onlineMetadataManager.SetLocalPlayerStat(GetStatName(Type.LevelCureRate), GetLocalPlayerStat(Type.LevelCureRate));
				onlineMetadataManager.SetLocalPlayerStat(GetStatName(Type.LevelHospitalValue), GetLocalPlayerStat(Type.LevelHospitalValue));
				onlineMetadataManager.SetLocalPlayerStat(GetStatName(Type.LevelReputation), GetLocalPlayerStat(Type.LevelReputation));
				onlineMetadataManager.SetLocalPlayerStat(GetStatName(Type.LevelStaffMorale), GetLocalPlayerStat(Type.LevelStaffMorale));
				onlineMetadataManager.SetLocalPlayerStat(GetStatName(Type.LevelPrestige), GetLocalPlayerStat(Type.LevelPrestige));
				onlineMetadataManager.SetLocalPlayerStat(GetStatName(Type.LevelBalance), GetLocalPlayerStat(Type.LevelBalance));
				onlineMetadataManager.SetLocalPlayerStat(GetStatName(Type.LevelStaffCount), GetLocalPlayerStat(Type.LevelStaffCount));
				onlineMetadataManager.SetLocalPlayerStat(GetStatName(Type.LevelCuresPerYear), GetLocalPlayerStat(Type.LevelCuresPerYear));
				onlineMetadataManager.SetLocalPlayerStat(GetStatName(Type.LevelYearlyIncome), GetLocalPlayerStat(Type.LevelYearlyIncome));
				onlineMetadataManager.Upload();
			}
		}

		private void OnEndOfMonthStatsReceived(LevelStatsDatabase.MonthStats monthStats)
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				string name = Enum.GetName(typeof(Type), Type.TotalFoundationValue);
				_metagame.OnlineMetadataManager.SetLocalPlayerStat(name, _metagame.TotalFoundationValue());
				_metagame.OnlineMetadataManager.Upload();
			}
		}

		public void OnStarAwardedEvent(MetagameHospitalRecord.StarIndex starIndex, LevelConfig levelConfig, bool debug)
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				string name = Enum.GetName(typeof(Type), Type.TotalStars);
				_metagame.OnlineMetadataManager.SetLocalPlayerStat(name, _metagame.TotalStars());
				_metagame.OnlineMetadataManager.Upload();
			}
		}

		public void OnRemixBadgeAwardedEvent(LevelConfig levelConfig, bool debug)
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				string name = Enum.GetName(typeof(Type), Type.TotalRemixBadges);
				_metagame.OnlineMetadataManager.SetLocalPlayerStat(name, _metagame.TotalRemixBadges());
				_metagame.OnlineMetadataManager.Upload();
			}
		}

		public void OnSilverAwardedEvent(int amount)
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				string name = Enum.GetName(typeof(Type), Type.TotalSilverEarned);
				_metagame.OnlineMetadataManager.SetLocalPlayerStat(name, _metagame.TotalSilverCumulative());
				_metagame.OnlineMetadataManager.Upload();
			}
		}
	}
}
