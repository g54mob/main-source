using System;
using System.Collections.Generic;
using System.Linq;
using ObservableCollections;
using ZLinq;
using ZLinq.Linq;

public static class DatabaseLoadDtoMapper
{
	public static DatabaseState LoadGameState(StateFileDto data = null, GlobalFileDto global = null)
	{
		DatabaseState databaseState = new DatabaseState();
		if (data != null)
		{
			Migrations.Migrate(data);
			FromDto(databaseState.Studio, data.Studio);
			FromDto(databaseState.Game, data.Game);
			FromDto(databaseState.Sequel, data.Sequel);
			FromDto(databaseState.History, data.History);
			FromDto(databaseState.Resources, data.Resources);
			FromDto(databaseState.Prestige, data.Prestige);
			FromDto(databaseState.Gnorman, data.Gnorman);
			FromDto(databaseState.Upgrades, data.Upgrades);
			FromDto(databaseState.Research, data.Research);
			FromDto(databaseState.Operations, data.Operations);
			FromDto(databaseState.Debugger, data.Debugger);
			FromDto(databaseState.Datacenters, data.Datacenters);
			FromDto(databaseState.Customization, data.Customization);
			FromDto(databaseState.Metrics, data.Metrics);
			FromDto(databaseState.Achievements.Studio, data.Achievements);
			FromDto(databaseState.IRC, data.IRC);
			FromDto(databaseState.Auction, data.Auction);
		}
		if (global != null)
		{
			FromDto(databaseState.Achievements.Global, global.Achievements);
		}
		Validate(databaseState);
		return databaseState;
	}

	private static void Validate(DatabaseState state)
	{
		try
		{
			CatalogProvider.ValidateCatalogs();
			foreach (UpgradeNode item in state.Upgrades.Unlocked)
			{
				item.Data();
			}
			foreach (UpgradeNode item2 in state.Upgrades.Visited)
			{
				item2.Data();
			}
			foreach (ResearchNode item3 in state.Research.Unlocked)
			{
				item3.Data();
			}
			foreach (KeyValuePair<Operation, int> activation in state.Operations.Activations)
			{
				activation.Key.Data();
			}
			foreach (KeyValuePair<Operation, ObservableList<OperationInstance>> instance in state.Operations.Instances)
			{
				instance.Key.Data();
			}
			foreach (KeyValuePair<Datacenter, DatacenterDetails> detail in state.Datacenters.Details)
			{
				detail.Key.Data();
			}
			foreach (GnormanAction item4 in state.Gnorman.TutorialActionsStarted)
			{
				item4.Data();
			}
			if (state.Gnorman.InProgress)
			{
				state.Gnorman.Action.CurrentValue.Data();
			}
			state.Customization.Background.CurrentValue.Value();
			state.Customization.Cursor.CurrentValue.Value();
			state.Customization.Gnorman.CurrentValue.Value();
			foreach (KeyValuePair<Achievement, AchievementDetails> item5 in state.Achievements.Studio)
			{
				item5.Key.Data();
			}
			foreach (KeyValuePair<Achievement, AchievementDetails> item6 in state.Achievements.Global)
			{
				item6.Key.Data();
			}
		}
		catch (Exception innerException)
		{
			throw new DataLoadException("Failed to validate loaded database state.", innerException);
		}
	}

	private static void FromDto(DatabaseState.StudioState state, StudioStateDto data)
	{
		state.Name.Value = data.Name;
		state.Time.Value = data.Time;
		state.Tutorial.Value = data.Tutorial;
		state.Paused.Value = data.Paused;
		state.Ending.Value = data.Ending;
		state.EndingAchieved = data.EndingAchieved;
	}

	private static void FromDto(DatabaseState.GameState state, GameStateDto data)
	{
		state.Name.Value = data.Name;
		state.Time.Value = data.Time;
		state.Launched.Value = data.Launched;
		state.BoxArt.Value = data.BoxArt;
		state.World.Value = data.World;
	}

	private static void FromDto(DatabaseState.SequelState state, SequelStateDto data)
	{
		state.Name.Value = data.Name;
		state.BoxArt.Value = data.BoxArt;
		state.Developing.Value = data.Developing;
		state.Time.Value = data.Time;
		state.Duration.Value = data.Duration;
		state.Round.Value = data.Round;
		state.Cost.Value = data.Cost;
		state.Progress.GameDesign.Value = data.Progress.GameDesign;
		state.Progress.Art.Value = data.Progress.Art;
		state.Progress.Netcode.Value = data.Progress.Netcode;
		state.Progress.Marketing.Value = data.Progress.Marketing;
		state.Progress.Qa.Value = data.Progress.Qa;
		state.Progress.FactorRange.Value = data.Progress.FactorRange;
	}

	private static void FromDto(DatabaseState.HistoryState state, HistoryStateDto data)
	{
		state.Releases.AddRange((from x in data.Releases.AsValueEnumerable()
			select new HistoryEntryData
			{
				Release = x.Release,
				Title = x.Title,
				BoxArt = x.BoxArt,
				Money = x.Money,
				Players = x.Players,
				Time = x.Time
			}).AsEnumerable());
	}

	private static void FromDto(DatabaseState.ResourceState state, ResourceStateDto data)
	{
		state.Players.Value = data.Players;
		state.Money.Value = data.Money;
		state.MoneyLifetime.Value = data.MoneyLifetime;
		state.Nodes.Value = data.Nodes;
		state.Load.Value = data.Load;
		state.Uptime.Value = data.Uptime;
		state.Ping.Value = data.Ping;
		state.Bugs.Value = data.Bugs;
		state.Hype.Value = data.Hype;
		state.TargetHype.Value = data.TargetHype;
		state.MoneySpend.Value = data.MoneySpend;
	}

	private static void FromDto(DatabaseState.PrestigeState state, PrestigeStateDto data)
	{
		state.Fans.Value = data.Fans;
		state.LastReleaseFansGain.Value = data.LastReleaseFansGain;
		state.Data.Value = data.Data;
		state.LastReleaseDataGain.Value = data.LastReleaseDataGain;
	}

	private static void FromDto(DatabaseState.GnormanState state, GnormanStateDto data)
	{
		state.Action.Value = data.Action;
		state.Index.Value = data.Index;
		state.MaxIndex.Value = data.MaxIndex;
		state.TutorialActionsStarted.AddRange(data.TutorialActionsStarted);
		state.Gullibleness = data.Gullibleness;
		foreach (GnormanAction item in data.TutorialActionsQueue)
		{
			state.TutorialActionsQueue.Enqueue(item);
		}
	}

	private static void FromDto(DatabaseState.UpgradesState state, UpgradeStateDto data)
	{
		state.Unlocked.AddRange(data.Unlocked);
		state.Visited.AddRange(data.Visited);
	}

	private static void FromDto(DatabaseState.ResearchState state, ResearchStateDto data)
	{
		state.Unlocked.AddRange(data.Unlocked);
		state.DataNodes.Value = data.DataNodes;
	}

	private static void FromDto(DatabaseState.OperationState state, OperationStateDto data)
	{
		foreach (KeyValuePair<Operation, int> activation in data.Activations)
		{
			state.Activations.Add(activation.Key, activation.Value);
		}
		foreach (var (key, value) in ParseOperationInstances(data.Instances))
		{
			state.Instances.Add(key, value);
		}
	}

	private static IEnumerable<(Operation, ObservableList<OperationInstance>)> ParseOperationInstances(Dictionary<Operation, List<OperationInstanceStateDto>> collection)
	{
		return (from x in collection.AsValueEnumerable()
			select (Key: x.Key, new ObservableList<OperationInstance>((from i in x.Value.AsValueEnumerable()
				select OperationInstanceFactory.Create(x.Key, i.Time, i.Duration)).AsEnumerable()))).AsEnumerable();
	}

	private static void FromDto(DatabaseState.DebuggerState state, DebuggerStateDto data)
	{
		state.Staged.AddRange(data.Staged);
		state.Glitched.AddRange(data.Glitched);
		state.Hotfixing.Value = data.Hotfixing;
		state.Compiling.Value = data.Compiling;
		state.Progress.StartTimer(data.Progress, 1f);
		state.GlitchTimer.StartTimer(data.GlitchTimerCurrent, data.GlitchTimerDuration);
		state.BonusDecayTimer.StartTimer(data.BonusDecayTimerCurrent, data.BonusDecayTimerDuration);
		state.BonusGrowthTimer.StartTimer(data.BonusGrowthTimerCurrent, data.BonusGrowthTimerDuration);
		state.BonusDecayRate.Value = data.BonusDecayRate;
		state.BonusGrowthRate.Value = data.BonusGrowthRate;
	}

	private static void FromDto(DatabaseState.DatacentersState state, DatacenterStateDto data)
	{
		foreach (var (key, value) in data.DatacenterDetails.AsValueEnumerable().Select(delegate(KeyValuePair<Datacenter, DatacenterDetailsStateDto> x)
		{
			Datacenter key2 = x.Key;
			DatacenterDetails item = new DatacenterDetails(x.Value.State, x.Value.Engineers, x.Value.ReprovisionProgress);
			return (datacenter: key2, details: item);
		}).AsEnumerable())
		{
			state.Details.Add(key, value);
		}
	}

	private static void FromDto(DatabaseState.CustomizationState state, CustomizationStateDto data)
	{
		state.Background.Value = data.Background;
		state.CustomBackground.Value = data.CustomBackground;
		state.Cursor.Value = data.Cursor;
		state.TrailingCursor.Value = data.TrailingCursor;
		state.Gnorman.Value = data.Gnorman;
	}

	private static void FromDto(DatabaseState.MetricsState state, MetricsStateDto data)
	{
		state.Releases.Value = data.Releases;
		state.BombdusterEasyWins.Value = data.BombdusterWins;
		state.BombdusterAdvancedWins.Value = data.BombdusterAdvancedWins;
		state.BombdusterExpertWins.Value = data.BombdusterExpertWins;
		state.MoneySpendUpgrades.Value = data.MoneySpendUpgrades;
		state.MoneyLifetime.Value = data.MoneyLifetime;
		state.BugsSquashed.Value = data.BugsSquashed;
		state.BugsStagedAuto.Value = data.BugsStagedAuto;
		state.DatacenterReprovisionedFromDegraded.Value = data.DatacenterReprovisionedFromDegraded;
		state.DatacenterReprovisionedFromCritical.Value = data.DatacenterReprovisionedFromCritical;
		state.LootchestsOpened.Value = data.LootchestsOpened;
		state.MarketingBlastTotalTime.Value = data.MarketingBlastTotalTime;
		state.ComponentsUnlocked.AddRange((from x in data.ComponentsUnlocked.AsValueEnumerable()
			select new ComponentUnlockRequirement.Requirement(x.Requirement, x.Value)).ToList());
	}

	private static void FromDto(ObservableDictionary<Achievement, AchievementDetails> collection, AchievementStateDto data)
	{
		foreach (var (key, value) in data.AchievementDetails.AsValueEnumerable().Select(delegate(KeyValuePair<Achievement, AchievementDetailsStateDto> x)
		{
			Achievement key2 = x.Key;
			AchievementDetails item = new AchievementDetails(x.Value.Unlocked, x.Value.Progress, key2.Data().target);
			return (achievement: key2, details: item);
		}).AsEnumerable())
		{
			collection.Add(key, value);
		}
	}

	private static void FromDto(DatabaseState.IRCState state, IRCStateDto data)
	{
		using (ValueEnumerator<GroupBy<ListSelect<IRCMessageDto, IRCMessage>, IRCMessage, IRCChannel>, IGrouping<IRCChannel, IRCMessage>> valueEnumerator = (from x in data.Messages.AsValueEnumerable()
			select new IRCMessage(x.Channel, x.Username, x.Message, x.Color) into x
			group x by x.Channel).GetEnumerator<GroupBy<ListSelect<IRCMessageDto, IRCMessage>, IRCMessage, IRCChannel>, IGrouping<IRCChannel, IRCMessage>>())
		{
			while (valueEnumerator.MoveNext())
			{
				foreach (IRCMessage item in valueEnumerator.Current)
				{
					switch (item.Channel)
					{
					case IRCChannel.System:
						state.System.AddLast(item);
						break;
					case IRCChannel.Twitch:
						state.Twitch.AddLast(item);
						break;
					default:
						state.General.AddLast(item);
						break;
					}
				}
			}
		}
		state.LoggedServerLoad.Value = data.SystemLoad;
	}

	private static void FromDto(DatabaseState.AuctionState state, AuctionStateDto data)
	{
		LootItem? value = null;
		if (data.CurrentLootItem != null)
		{
			value = new LootItem(data.CurrentLootItem.Quality, data.CurrentLootItem.Category, data.CurrentLootItem.Name, data.CurrentLootItem.IconIndex, data.CurrentLootItem.Value);
		}
		state.AvailableLootchests.Value = data.AvailableLootchests;
		state.TimeNextLootchest.Value = new TimerData(data.TimeNextLootchestCurrent, data.TimeNextLootchestDuration);
		state.CurrentLootItem.Value = value;
		state.CommonDropchance.Value = data.CommonDropchance;
		state.UncommonDropchance.Value = data.UncommonDropchance;
		state.RareDropchance.Value = data.RareDropchance;
		state.LegendaryDropchance.Value = data.LegendaryDropchance;
		using (ValueEnumerator<ListSelect<AuctionStateDto.AuctionLogDto, AuctionLogMessage>, AuctionLogMessage> valueEnumerator = (from x in data.AuctionLog.AsValueEnumerable()
			select new AuctionLogMessage(x.Username, x.Item, x.Value, x.Cut, x.CutPercentage)).GetEnumerator<ListSelect<AuctionStateDto.AuctionLogDto, AuctionLogMessage>, AuctionLogMessage>())
		{
			while (valueEnumerator.MoveNext())
			{
				AuctionLogMessage current = valueEnumerator.Current;
				state.AuctionLog.AddLast(current);
			}
		}
		state.EscrowMoney.Value = data.EscrowMoney;
		state.EscrowInterestInterval.Value = new TimerData(data.EscrowInterestIntervalCurrent, data.EscrowInterestIntervalDuration);
		state.HiddenCommonDropchance.Value = data.HiddenCommonDropchance;
		state.HiddenUncommonDropchance.Value = data.HiddenUncommonDropchance;
		state.HiddenRareDropchance.Value = data.HiddenRareDropchance;
		state.HiddenLegendaryDropchance.Value = data.HiddenLegendaryDropchance;
		state.HiddenSentiment.Value = data.HiddenSentiment;
		state.HiddenSentimentTarget.Value = data.HiddenSentimentTarget;
		state.HiddenSentimentTimer.StartTimer(BiteRandom.NextFloat(8f, 15f));
	}
}
