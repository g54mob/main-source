using System;
using System.Collections.Generic;
using System.Linq;
using ObservableCollections;
using ZLinq;

public static class DatabaseSaveDtoMapper
{
	public static MetaFileDto SaveMetaState()
	{
		return new MetaFileDto
		{
			Version = 3,
			SavedAtUnixSecondsUtc = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
			StudioName = Database.State.Studio.Name.Value,
			PlayTime = Database.State.Studio.Time.Value,
			Releases = Database.State.Metrics.Releases.Value
		};
	}

	public static GlobalFileDto SaveGlobalState()
	{
		return new GlobalFileDto
		{
			Achievements = ToDto(Database.State.Achievements.Global)
		};
	}

	public static StateFileDto SaveGameState()
	{
		return new StateFileDto
		{
			Version = 3,
			SavedAtUnixSecondsUtc = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
			Studio = ToDto(Database.State.Studio),
			Game = ToDto(Database.State.Game),
			Sequel = ToDto(Database.State.Sequel),
			History = ToDto(Database.State.History),
			Resources = ToDto(Database.State.Resources),
			Prestige = ToDto(Database.State.Prestige),
			Gnorman = ToDto(Database.State.Gnorman),
			Upgrades = ToDto(Database.State.Upgrades),
			Research = ToDto(Database.State.Research),
			Operations = ToDto(Database.State.Operations),
			Debugger = ToDto(Database.State.Debugger),
			Datacenters = ToDto(Database.State.Datacenters),
			Customization = ToDto(Database.State.Customization),
			Metrics = ToDto(Database.State.Metrics),
			Achievements = ToDto(Database.State.Achievements.Studio),
			IRC = ToDto(Database.State.IRC),
			Auction = ToDto(Database.State.Auction)
		};
	}

	private static StudioStateDto ToDto(DatabaseState.StudioState data)
	{
		return new StudioStateDto
		{
			Name = data.Name.Value,
			Time = data.Time.Value,
			Tutorial = data.Tutorial.Value,
			Paused = data.Paused.Value,
			Ending = data.Ending.Value,
			EndingAchieved = data.EndingAchieved
		};
	}

	private static GameStateDto ToDto(DatabaseState.GameState data)
	{
		return new GameStateDto
		{
			Name = data.Name.Value,
			Time = data.Time.Value,
			Launched = data.Launched.Value,
			BoxArt = data.BoxArt.Value,
			World = data.World.Value
		};
	}

	private static SequelStateDto ToDto(DatabaseState.SequelState data)
	{
		return new SequelStateDto
		{
			Name = data.Name.Value,
			BoxArt = data.BoxArt.Value,
			Developing = data.Developing.Value,
			Time = data.Time.Value,
			Duration = data.Duration.Value,
			Round = data.Round.Value,
			Cost = data.Cost.Value,
			Progress = new SequelProgressStateDto
			{
				GameDesign = data.Progress.GameDesign.Value,
				Art = data.Progress.Art.Value,
				Netcode = data.Progress.Netcode.Value,
				Marketing = data.Progress.Marketing.Value,
				Qa = data.Progress.Qa.Value,
				FactorRange = data.Progress.FactorRange.Value
			}
		};
	}

	private static HistoryStateDto ToDto(DatabaseState.HistoryState data)
	{
		return new HistoryStateDto
		{
			Releases = (from x in data.Releases.AsValueEnumerable()
				select new HistoryEntryDto
				{
					Release = x.Release,
					Title = x.Title,
					BoxArt = x.BoxArt,
					Money = x.Money,
					Players = x.Players,
					Time = x.Time
				}).ToList()
		};
	}

	private static ResourceStateDto ToDto(DatabaseState.ResourceState data)
	{
		return new ResourceStateDto
		{
			Players = data.Players.Value,
			Money = data.Money.Value,
			MoneyLifetime = data.MoneyLifetime.Value,
			Nodes = data.Nodes.Value,
			Load = data.Load.Value,
			Uptime = data.Uptime.Value,
			Ping = data.Ping.Value,
			Bugs = data.Bugs.Value,
			Hype = data.Hype.Value,
			TargetHype = data.TargetHype.Value,
			MoneySpend = data.MoneySpend.Value
		};
	}

	private static PrestigeStateDto ToDto(DatabaseState.PrestigeState data)
	{
		return new PrestigeStateDto
		{
			Fans = data.Fans.Value,
			LastReleaseFansGain = data.LastReleaseFansGain.Value,
			Data = data.Data.Value,
			LastReleaseDataGain = data.LastReleaseDataGain.Value
		};
	}

	private static GnormanStateDto ToDto(DatabaseState.GnormanState data)
	{
		return new GnormanStateDto
		{
			Action = data.Action.Value,
			Index = data.Index.Value,
			MaxIndex = data.MaxIndex.Value,
			TutorialActionsStarted = data.TutorialActionsStarted.ToList(),
			TutorialActionsQueue = data.TutorialActionsQueue.ToList(),
			Gullibleness = data.Gullibleness
		};
	}

	private static UpgradeStateDto ToDto(DatabaseState.UpgradesState data)
	{
		return new UpgradeStateDto
		{
			Unlocked = data.Unlocked.ToHashSet(),
			Visited = data.Visited.ToHashSet()
		};
	}

	private static ResearchStateDto ToDto(DatabaseState.ResearchState data)
	{
		return new ResearchStateDto
		{
			Unlocked = data.Unlocked.ToHashSet(),
			DataNodes = data.DataNodes.Value
		};
	}

	private static OperationStateDto ToDto(DatabaseState.OperationState data)
	{
		return new OperationStateDto
		{
			Activations = data.Activations.ToDictionary((KeyValuePair<Operation, int> x) => x.Key, (KeyValuePair<Operation, int> x) => x.Value),
			Instances = data.Instances.ToDictionary((KeyValuePair<Operation, ObservableList<OperationInstance>> x) => x.Key, (KeyValuePair<Operation, ObservableList<OperationInstance>> x) => (from i in x.Value.AsValueEnumerable()
				select new OperationInstanceStateDto
				{
					Time = i.Time,
					Duration = i.Duration
				}).ToList())
		};
	}

	private static DebuggerStateDto ToDto(DatabaseState.DebuggerState data)
	{
		return new DebuggerStateDto
		{
			Staged = data.Staged.ToList(),
			Glitched = data.Glitched.ToHashSet(),
			Hotfixing = data.Hotfixing.Value,
			Compiling = data.Compiling.Value,
			Progress = data.Progress.Value.Current,
			GlitchTimerCurrent = data.GlitchTimer.Value.Current,
			GlitchTimerDuration = data.GlitchTimer.Value.Duration,
			BonusDecayTimerCurrent = data.BonusDecayTimer.Value.Current,
			BonusDecayTimerDuration = data.BonusDecayTimer.Value.Duration,
			BonusDecayRate = data.BonusDecayRate.Value,
			BonusGrowthRate = data.BonusGrowthRate.Value,
			BonusGrowthTimerCurrent = data.BonusGrowthTimer.Value.Current,
			BonusGrowthTimerDuration = data.BonusGrowthTimer.Value.Duration
		};
	}

	private static DatacenterStateDto ToDto(DatabaseState.DatacentersState data)
	{
		return new DatacenterStateDto
		{
			DatacenterDetails = data.Details.ToDictionary((KeyValuePair<Datacenter, DatacenterDetails> x) => x.Key, (KeyValuePair<Datacenter, DatacenterDetails> x) => new DatacenterDetailsStateDto
			{
				State = x.Value.State.Value,
				Engineers = x.Value.Engineers.Value,
				ReprovisionProgress = x.Value.ReprovisionProgress.Value
			})
		};
	}

	private static CustomizationStateDto ToDto(DatabaseState.CustomizationState data)
	{
		return new CustomizationStateDto
		{
			Background = data.Background.Value,
			CustomBackground = data.CustomBackground.Value,
			Cursor = data.Cursor.Value,
			TrailingCursor = data.TrailingCursor.Value,
			Gnorman = data.Gnorman.Value
		};
	}

	private static MetricsStateDto ToDto(DatabaseState.MetricsState data)
	{
		return new MetricsStateDto
		{
			Releases = data.Releases.Value,
			BombdusterWins = data.BombdusterEasyWins.Value,
			BombdusterAdvancedWins = data.BombdusterAdvancedWins.Value,
			BombdusterExpertWins = data.BombdusterExpertWins.Value,
			MoneySpendUpgrades = data.MoneySpendUpgrades.Value,
			MoneyLifetime = data.MoneyLifetime.Value,
			BugsSquashed = data.BugsSquashed.Value,
			BugsStagedAuto = data.BugsStagedAuto.Value,
			DatacenterReprovisionedFromDegraded = data.DatacenterReprovisionedFromDegraded.Value,
			DatacenterReprovisionedFromCritical = data.DatacenterReprovisionedFromCritical.Value,
			LootchestsOpened = data.LootchestsOpened.Value,
			MarketingBlastTotalTime = data.MarketingBlastTotalTime.Value,
			ComponentsUnlocked = (from x in data.ComponentsUnlocked.AsValueEnumerable()
				select new ComponentUnlockedStateDto
				{
					Requirement = x.Type,
					Value = x.Value
				}).ToList()
		};
	}

	private static AchievementStateDto ToDto(ObservableDictionary<Achievement, AchievementDetails> collection)
	{
		return new AchievementStateDto
		{
			AchievementDetails = (from x in collection.AsValueEnumerable()
				where x.Value.HasProgress
				select x).ToDictionary((KeyValuePair<Achievement, AchievementDetails> x) => x.Key, (KeyValuePair<Achievement, AchievementDetails> x) => new AchievementDetailsStateDto
			{
				Unlocked = x.Value.Unlocked.Value,
				Progress = x.Value.Progress.Value
			})
		};
	}

	private static IRCStateDto ToDto(DatabaseState.IRCState data)
	{
		List<IRCMessage> list = new List<IRCMessage>();
		list.AddRange(data.System);
		list.AddRange(data.General);
		return new IRCStateDto
		{
			Messages = (from x in list.AsValueEnumerable()
				orderby x.Sequence
				select new IRCMessageDto
				{
					Channel = x.Channel,
					Username = x.Username,
					Message = x.Message,
					Color = x.Color
				}).ToList(),
			SystemLoad = data.LoggedServerLoad.Value
		};
	}

	private static AuctionStateDto ToDto(DatabaseState.AuctionState data)
	{
		AuctionStateDto.LootItemDto currentLootItem = null;
		if (data.CurrentLootItem.Value.HasValue)
		{
			LootItem value = data.CurrentLootItem.Value.Value;
			currentLootItem = new AuctionStateDto.LootItemDto
			{
				Quality = value.Quality,
				Category = value.Category,
				Name = value.Name,
				IconIndex = value.IconIndex,
				Value = value.Value
			};
		}
		List<AuctionStateDto.AuctionLogDto> auctionLog = (from x in data.AuctionLog.AsValueEnumerable()
			select new AuctionStateDto.AuctionLogDto
			{
				Username = x.Username,
				Item = x.Item,
				Value = x.Value,
				Cut = x.Cut,
				CutPercentage = x.CutPercentage
			}).ToList();
		return new AuctionStateDto
		{
			AvailableLootchests = data.AvailableLootchests.Value,
			TimeNextLootchestCurrent = data.TimeNextLootchest.Value.Current,
			TimeNextLootchestDuration = data.TimeNextLootchest.Value.Duration,
			CurrentLootItem = currentLootItem,
			CommonDropchance = data.CommonDropchance.Value,
			UncommonDropchance = data.UncommonDropchance.Value,
			RareDropchance = data.RareDropchance.Value,
			LegendaryDropchance = data.LegendaryDropchance.Value,
			AuctionLog = auctionLog,
			EscrowMoney = data.EscrowMoney.Value,
			EscrowInterestIntervalCurrent = data.EscrowInterestInterval.Value.Current,
			EscrowInterestIntervalDuration = data.EscrowInterestInterval.Value.Duration,
			HiddenCommonDropchance = data.HiddenCommonDropchance.Value,
			HiddenUncommonDropchance = data.HiddenUncommonDropchance.Value,
			HiddenRareDropchance = data.HiddenRareDropchance.Value,
			HiddenLegendaryDropchance = data.HiddenLegendaryDropchance.Value,
			HiddenSentiment = data.HiddenSentiment.Value,
			HiddenSentimentTarget = data.HiddenSentimentTarget.Value
		};
	}
}
