using System;
using R3;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.Extensions;

public class DatabaseVariables : IDisposable
{
	private const string DecimalFormat = "{0:0}";

	private const string FloatFormat = "{0:F1}";

	private const string FloatFormatDetailed = "{0:F4}";

	private DisposableBag _subscriptions;

	public DatabaseVariables(DatabaseState state, DatabaseDerived derived, DatabaseModifiers modifiers)
	{
		using (PersistentVariablesSource.UpdateScope())
		{
			SubscribeToDatabaseSourceImmediate("studio_name", state.Studio.Name);
			SubscribeToDatabaseSourceFormatTime("studio_time", state.Studio.Time);
			SubscribeToDatabaseSourceImmediate("studio_releases", state.Metrics.Releases);
			SubscribeToDatabaseSourceImmediate("game_name", state.Game.Name);
			SubscribeToDatabaseSourceFormatTime("game_time", state.Game.Time);
			SubscribeToDatabaseSource("sequel_name", state.Sequel.Name);
			SubscribeToDatabaseSource("sequel_time", state.Sequel.Time, "{0:F1}");
			SubscribeToDatabaseSource("sequel_duration", state.Sequel.Duration, "{0:F1}");
			SubscribeToDatabaseSource("sequel_round", state.Sequel.Round);
			SubscribeToDatabaseSource("sequel_cost", state.Sequel.Cost, "{0:0}");
			SubscribeToDatabaseSource("resource_players", state.Resources.Players, "{0:0}");
			SubscribeToDatabaseSource("resource_players_second", state.Resources.PlayersPerSecond, "{0:F1}");
			SubscribeToDatabaseSource("resource_money", state.Resources.Money, "{0:0}");
			SubscribeToDatabaseSource("resource_money_lifetime", state.Resources.MoneyLifetime, "{0:0}");
			SubscribeToDatabaseSource("resource_money_second", state.Resources.MoneyPerSecond, "{0:F1}");
			SubscribeToDatabaseSource("resource_nodes", state.Resources.Nodes);
			SubscribeToDatabaseSource("resource_load", state.Resources.LoadPercentage, "{0:F1}");
			SubscribeToDatabaseSource("resource_load_players", state.Resources.LoadPlayersPercentage, "{0:F1}");
			SubscribeToDatabaseSource("resource_uptime", state.Resources.UptimePercentage, "{0:F4}");
			SubscribeToDatabaseSource("resource_ping", state.Resources.Ping, "{0:0}");
			SubscribeToDatabaseSource("resource_tick_rate", state.Resources.TickRate, "{0:F1}");
			SubscribeToDatabaseSource("resource_bugs", state.Resources.Bugs, "{0:0}");
			SubscribeToDatabaseSource("resource_bugs_second", state.Resources.BugsPerSecond, "{0:F1}");
			SubscribeToDatabaseSource("resource_hype", state.Resources.HypePercentage, "{0:F1}");
			SubscribeToDatabaseSource("resource_target_hype", state.Resources.TargetHypePercentage, "{0:F1}");
			SubscribeToDatabaseSource("prestige_fans", state.Prestige.Fans, "{0:0}");
			SubscribeToDatabaseSourceImmediate("prestige_fans_release", state.Prestige.LastReleaseFansGain, "{0:0}");
			SubscribeToDatabaseSource("prestige_data", state.Prestige.Data, "{0:F1}");
			SubscribeToDatabaseSourceImmediate("prestige_data_release", state.Prestige.LastReleaseDataGain, "{0:F1}");
			SubscribeToDatabaseSource("research_nodes", state.Research.DataNodes);
			SubscribeToDatabaseSource("debugger_progress", state.Debugger.Progress);
			SubscribeToDatabaseSource("debugger_refresh_timer", state.Debugger.RefreshTimer);
			SubscribeToDatabaseSource("debugger_glitch_timer", state.Debugger.GlitchTimer);
			SubscribeToDatabaseSource("debugger_bonus_decay_timer", state.Debugger.BonusDecayTimer);
			SubscribeToDatabaseSource("debugger_bonus_decay_rate", state.Debugger.BonusDecayRate, "{0:F1}");
			SubscribeToDatabaseSource("server_capacity", derived.PlayersCapacity, "{0:0}");
			SubscribeToDatabaseSource("datacenter_capacity", derived.DatacenterCapacity, "{0:0}");
			SubscribeToDatabaseSource("data_capacity", derived.DataCapacity, "{0:F1}");
			SubscribeToDatabaseSource("data_capacity_cost", derived.DataCapacityCost, "{0:F1}");
			SubscribeToDatabaseSource("line_of_credit_loan", modifiers.Observe(ModifierType.OperationLineOfCreditLoan), "{0:0}");
			SubscribeToDatabaseSource("line_of_credit_repayment", modifiers.Observe(ModifierType.OperationLineOfCreditRepayment).Percentage(2), "{0:F1}");
			SubscribeToDatabaseSource("line_of_credit_repayment", modifiers.Observe(ModifierType.OperationLineOfCreditInterest).Percentage(2), "{0:F1}");
			SubscribeToDatabaseSource("price_per_copy", modifiers.Observe(ModifierType.PricePerCopy), "{0:F1}");
			SubscribeToDatabaseSource("load_system", modifiers.Observe(ModifierType.Load).CombineLatest(modifiers.Observe(ModifierType.LoadOverhead), (double l, double o) => l * 100.0 + o * 100.0), "{0:F1}");
			SubscribeToDatabaseSource("auction_cut", from x in modifiers.ObserveAsFloat(ModifierType.AuctionCut)
				select x * 100f, "{0:0}");
			SubscribeToDatabaseSource("auction_value_modifier", modifiers.Observe(ModifierType.AuctionValueModifier));
			SubscribeToDatabaseSource("auction_escrow_interest", modifiers.Observe(ModifierType.AuctionEscrowInterest));
			SubscribeToDatabaseSource("auction_player_participation", modifiers.Observe(ModifierType.AuctionPlayerParticipation));
			SubscribeToDatabaseSource("auction_fans_participation", modifiers.Observe(ModifierType.AuctionFansParticipation));
			SubscribeToDatabaseSource("auction_lootchest_capacity", modifiers.Observe(ModifierType.AuctionLootchestCapacity));
			SubscribeToDatabaseSource("auction_lootchest_duration", modifiers.Observe(ModifierType.AuctionLootchestDuration));
			SubscribeToDatabaseSource("auction_lootchest_luck", modifiers.Observe(ModifierType.AuctionLootchestBonusLuck));
			DatabaseSource.Context.Set("resource_money_history", " ");
			SubscribeToHistoryRevenue("resource_money_history", derived.HistoryRevenue);
		}
	}

	public void Dispose()
	{
		_subscriptions.Dispose();
	}

	private void SubscribeToDatabaseSource<T>(string key, Observable<T> property)
	{
		property.ThrottleLastHalfSecond().Subscribe(key, delegate(T x, string k)
		{
			DatabaseSource.Context.Set(k, x);
		}).AddTo(ref _subscriptions);
	}

	private void SubscribeToDatabaseSource<T>(string key, Observable<T> property, string format)
	{
		property.ThrottleLastHalfSecond().Format(format).Subscribe(key, delegate(string x, string k)
		{
			DatabaseSource.Context.Set(k, x);
		})
			.AddTo(ref _subscriptions);
	}

	private void SubscribeToDatabaseSourceFormatTime(string key, Observable<double> property)
	{
		property.ThrottleLastHalfSecond().FormatTimeHours().Subscribe(key, delegate(string x, string k)
		{
			DatabaseSource.Context.Set(k, x);
		})
			.AddTo(ref _subscriptions);
	}

	private void SubscribeToDatabaseSourceImmediate<T>(string key, Observable<T> property)
	{
		property.Subscribe(key, delegate(T x, string k)
		{
			DatabaseSource.Context.Set(k, x);
		}).AddTo(ref _subscriptions);
	}

	private void SubscribeToDatabaseSourceImmediate<T>(string key, Observable<T> property, string format)
	{
		property.Format(format).Subscribe(key, delegate(string x, string k)
		{
			DatabaseSource.Context.Set(k, x);
		}).AddTo(ref _subscriptions);
	}

	private void SubscribeToHistoryRevenue(string key, Observable<double> property)
	{
		string format = "<br>" + new LocalizedString(LocTable.Research.Value(), 2068302198009856L).GetLocalizedString() + ": <#2E8E34>${0:0}</color>/s";
		(from x in property.CombineLatest(Database.State.Research.Unlocked.ObserveContains(ResearchNode.LegacySupport), (double x, bool t) => (!t) ? 0.0 : (x * (double)ModifierType.RevenuePassivePreviousReleases.Float()))
			where x > 1.0
			select x).Format(format).Subscribe(key, delegate(string x, string k)
		{
			DatabaseSource.Context.Set(k, x);
		}).AddTo(ref _subscriptions);
	}
}
