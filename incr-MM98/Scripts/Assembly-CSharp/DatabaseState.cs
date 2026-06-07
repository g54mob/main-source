using System;
using System.Collections.Generic;
using System.Threading;
using MessagePipe;
using ObservableCollections;
using R3;
using UnityEngine;
using ZLinq;

public class DatabaseState : IDisposable
{
	public class AchievementState : IDisposable
	{
		public readonly ObservableDictionary<Achievement, AchievementDetails> Studio = new ObservableDictionary<Achievement, AchievementDetails>();

		public readonly ObservableDictionary<Achievement, AchievementDetails> Global = new ObservableDictionary<Achievement, AchievementDetails>();

		public readonly ReadOnlyReactiveProperty<int> Unlocked;

		public AchievementState()
		{
			Observable<Unit> observable = from _ in Studio.ObserveAdd().SelectMany((CollectionAddEvent<KeyValuePair<Achievement, AchievementDetails>> x) => x.Value.Value.Unlocked)
				select Unit.Default;
			Observable<Unit> observable2 = from _ in Global.ObserveAdd().SelectMany((CollectionAddEvent<KeyValuePair<Achievement, AchievementDetails>> x) => x.Value.Value.Unlocked)
				select Unit.Default;
			Unlocked = (from _ in Observable.Merge<Unit>(observable, observable2).Prepend(Unit.Default)
				select UnlockedCount()).DistinctUntilChanged().ToReadOnlyReactiveProperty(0);
		}

		public bool IsUnlocked(Achievement achievement)
		{
			if (achievement != Achievement.None)
			{
				return GetDetails(achievement)?.Unlocked.Value ?? false;
			}
			return true;
		}

		public int UnlockedCount()
		{
			return (from x in Global.AsValueEnumerable().Union(Studio.AsValueEnumerable())
				where x.Value.Unlocked.Value
				select x).Count();
		}

		public AchievementDetails? GetDetails(AchievementData achievement)
		{
			return (achievement.scope == AchievementData.Scope.Studio) ? Studio.GetValueOrDefault(achievement) : Global.GetValueOrDefault(achievement);
		}

		public void Dispose()
		{
			foreach (KeyValuePair<Achievement, AchievementDetails> item in Studio)
			{
				item.Value.Dispose();
			}
			foreach (KeyValuePair<Achievement, AchievementDetails> item2 in Global)
			{
				item2.Value.Dispose();
			}
			Unlocked.Dispose();
		}
	}

	public class AuctionState : IDisposable
	{
		public const int LOG_CAPACITY = 11;

		public readonly ReactiveProperty<int> AvailableLootchests = new ReactiveProperty<int>(0);

		public readonly ReactiveProperty<TimerData> TimeNextLootchest = new ReactiveProperty<TimerData>(TimerData.Empty);

		public readonly ReactiveProperty<LootItem?> CurrentLootItem = new ReactiveProperty<LootItem?>(null);

		public readonly ReactiveProperty<float> CommonDropchance = new ReactiveProperty<float>(0.5f);

		public readonly ReactiveProperty<float> UncommonDropchance = new ReactiveProperty<float>(0.3f);

		public readonly ReactiveProperty<float> RareDropchance = new ReactiveProperty<float>(0.15f);

		public readonly ReactiveProperty<float> LegendaryDropchance = new ReactiveProperty<float>(0.05f);

		public readonly ReactiveProperty<float> HiddenCommonDropchance = new ReactiveProperty<float>(0f);

		public readonly ReactiveProperty<float> HiddenUncommonDropchance = new ReactiveProperty<float>(0f);

		public readonly ReactiveProperty<float> HiddenRareDropchance = new ReactiveProperty<float>(0f);

		public readonly ReactiveProperty<float> HiddenLegendaryDropchance = new ReactiveProperty<float>(0f);

		public readonly ReactiveProperty<float> HiddenSentiment = new ReactiveProperty<float>(0f);

		public readonly ReactiveProperty<float> HiddenSentimentTarget = new ReactiveProperty<float>(0f);

		public readonly ReactiveProperty<TimerData> HiddenSentimentTimer = new ReactiveProperty<TimerData>(TimerData.Empty);

		public readonly ObservableFixedSizeRingBuffer<AuctionLogMessage> AuctionLog = new ObservableFixedSizeRingBuffer<AuctionLogMessage>(11);

		public readonly ReactiveProperty<double> EscrowMoney = new ReactiveProperty<double>(0.0);

		public readonly ReactiveProperty<TimerData> EscrowInterestInterval = new ReactiveProperty<TimerData>(TimerData.Empty);

		public bool DrainingEscrow;

		public void Dispose()
		{
		}
	}

	public class CustomizationState : IDisposable
	{
		public readonly ReactiveProperty<BackgroundSkin> Background = new ReactiveProperty<BackgroundSkin>(BackgroundSkin.Win95Clouds);

		public readonly ReactiveProperty<bool> CustomBackground = new ReactiveProperty<bool>(value: false);

		public readonly ReactiveProperty<CursorSkin> Cursor = new ReactiveProperty<CursorSkin>(CursorSkin.Standard);

		public readonly ReactiveProperty<bool> TrailingCursor = new ReactiveProperty<bool>(value: false);

		public readonly ReactiveProperty<GnormanSkin> Gnorman = new ReactiveProperty<GnormanSkin>(GnormanSkin.Default);

		public void Dispose()
		{
			Background.Dispose();
			CustomBackground.Dispose();
			Cursor.Dispose();
			TrailingCursor.Dispose();
			Gnorman.Dispose();
		}
	}

	public class DatacentersState : IDisposable
	{
		public readonly ObservableDictionary<Datacenter, DatacenterDetails> Details = new ObservableDictionary<Datacenter, DatacenterDetails>();

		public readonly ReactiveProperty<Datacenter> Selected = new ReactiveProperty<Datacenter>(Datacenter.None);

		public readonly DictionaryTimer<Datacenter> RecentlyDegraded = new DictionaryTimer<Datacenter>();

		public readonly ReactiveProperty<TimerData> BonusGrowthTimer = new ReactiveProperty<TimerData>();

		public readonly Subject<Datacenter> StateChanged = new Subject<Datacenter>();

		public readonly Subject<Datacenter> HireChanged = new Subject<Datacenter>();

		public readonly Subject<Datacenter> ReprovisionChanged = new Subject<Datacenter>();

		private R3.DisposableBag _detailsSubscription;

		private readonly Dictionary<Datacenter, IDisposable> _detailsSubscriptionsCache = new Dictionary<Datacenter, IDisposable>();

		public DatacentersState()
		{
			_detailsSubscription = default(R3.DisposableBag);
			Details.ObserveDictionaryAdd().Subscribe(SubscribeDetailChanges).AddTo(ref _detailsSubscription);
			Details.ObserveClear().Subscribe(SubscribeDetailsCleared).AddTo(ref _detailsSubscription);
		}

		public bool IsUnlocked(Datacenter datacenter)
		{
			if (datacenter != Datacenter.None)
			{
				DatacenterState? datacenterState = GetDetails(datacenter)?.State.Value;
				if (datacenterState.HasValue)
				{
					DatacenterState valueOrDefault = datacenterState.GetValueOrDefault();
					if (valueOrDefault != DatacenterState.Unprovisioned)
					{
						return valueOrDefault != DatacenterState.Construction;
					}
				}
				return false;
			}
			return true;
		}

		public bool IsAvailable(DatacenterData datacenter)
		{
			return IsUnlocked(datacenter.prerequisite);
		}

		public DatacenterDetails GetDetails(Datacenter datacenter)
		{
			return Details.GetValueOrDefault(datacenter);
		}

		public DatacenterState GetState(Datacenter datacenter)
		{
			return GetDetails(datacenter)?.State.Value ?? DatacenterState.Unprovisioned;
		}

		public int GetEngineers(Datacenter datacenter)
		{
			return GetDetails(datacenter)?.Engineers.Value ?? 0;
		}

		public float GetReprovisionProgress(Datacenter datacenter)
		{
			return GetDetails(datacenter)?.ReprovisionProgress.Value ?? 0f;
		}

		public int GetConstructedDatacenters()
		{
			return (from x in Details.AsValueEnumerable()
				select x.Value).Count(delegate(DatacenterDetails x)
			{
				DatacenterState value = x.State.Value;
				return value != DatacenterState.Unprovisioned && value != DatacenterState.Construction;
			});
		}

		public void Dispose()
		{
			_detailsSubscription.Dispose();
			foreach (KeyValuePair<Datacenter, IDisposable> item in _detailsSubscriptionsCache)
			{
				item.Value.Dispose();
			}
			foreach (KeyValuePair<Datacenter, DatacenterDetails> detail in Details)
			{
				detail.Value.Dispose();
			}
			Selected.Dispose();
			StateChanged.Dispose();
			HireChanged.Dispose();
			ReprovisionChanged.Dispose();
		}

		private void SubscribeDetailChanges(DictionaryAddEvent<Datacenter, DatacenterDetails> ctx)
		{
			DisposableBagBuilder disposableBagBuilder = MessagePipe.DisposableBag.CreateBuilder();
			ctx.Value.State.Subscribe((StateChanged, ctx.Key), delegate(DatacenterState _, (Subject<Datacenter> StateChanged, Datacenter Key) state)
			{
				state.StateChanged.OnNext(state.Key);
			}).AddTo(disposableBagBuilder);
			ctx.Value.Engineers.Subscribe((HireChanged, ctx.Key), delegate(int _, (Subject<Datacenter> HireChanged, Datacenter Key) state)
			{
				state.HireChanged.OnNext(state.Key);
			}).AddTo(disposableBagBuilder);
			ctx.Value.ReprovisionProgress.Subscribe((ReprovisionChanged, ctx.Key), delegate(float _, (Subject<Datacenter> ReprovisionChanged, Datacenter Key) state)
			{
				state.ReprovisionChanged.OnNext(state.Key);
			}).AddTo(disposableBagBuilder);
			_detailsSubscriptionsCache.Add(ctx.Key, disposableBagBuilder.Build());
		}

		private void SubscribeDetailsCleared(Unit _)
		{
			foreach (IDisposable value in _detailsSubscriptionsCache.Values)
			{
				value?.Dispose();
			}
			_detailsSubscriptionsCache.Clear();
		}
	}

	public class DebuggerState : IDisposable
	{
		public readonly ObservableList<int> Staged = new ObservableList<int>();

		public readonly ObservableHashSet<int> Glitched = new ObservableHashSet<int>();

		public readonly ObservableDictionary<int, ReactiveProperty<TimerData>> Automated = new ObservableDictionary<int, ReactiveProperty<TimerData>>();

		public readonly ReactiveProperty<bool> Hotfixing = new ReactiveProperty<bool>(value: false);

		public readonly ReactiveProperty<bool> Compiling = new ReactiveProperty<bool>(value: false);

		public readonly ReactiveProperty<TimerData> Progress = new ReactiveProperty<TimerData>(TimerData.Empty);

		public readonly ReactiveProperty<TimerData> RefreshTimer = new ReactiveProperty<TimerData>(TimerData.Empty);

		public readonly ReactiveProperty<TimerData> GlitchTimer = new ReactiveProperty<TimerData>(TimerData.Empty);

		public readonly ReactiveProperty<TimerData> BonusDecayTimer = new ReactiveProperty<TimerData>(TimerData.Empty);

		public readonly ReactiveProperty<TimerData> BonusGrowthTimer = new ReactiveProperty<TimerData>(TimerData.Empty);

		public readonly ReactiveProperty<float> BonusDecayRate = new ReactiveProperty<float>(0f);

		public readonly ReactiveProperty<float> BonusGrowthRate = new ReactiveProperty<float>(0f);

		public bool InProgress
		{
			get
			{
				if (!Hotfixing.Value)
				{
					return Compiling.Value;
				}
				return true;
			}
		}

		public float StagedBugs => (float)Staged.Count * ModifierType.DebuggerHexBugWorth.Float();

		public bool StagingFull => Staged.Count == ModifierType.DebuggerMaxStaging.Int();

		public Observable<bool> ObserveInProgress => Hotfixing.CombineLatest(Compiling, (bool h, bool c) => h || c);

		public Observable<float> ObserveStagedBugs => Staged.ObserveCountChanged().CombineLatest(Database.Modifiers.ObserveAsFloat(ModifierType.DebuggerHexBugWorth), (int i, float f) => (float)i * f);

		public void Dispose()
		{
			foreach (KeyValuePair<int, ReactiveProperty<TimerData>> item in Automated)
			{
				item.Value.Dispose();
			}
			Hotfixing.Dispose();
			Compiling.Dispose();
			Progress.Dispose();
			RefreshTimer.Dispose();
			GlitchTimer.Dispose();
			BonusDecayTimer.Dispose();
			BonusGrowthTimer.Dispose();
			BonusDecayRate.Dispose();
		}
	}

	public class GameState : IDisposable
	{
		public readonly ReactiveProperty<string> Name = new ReactiveProperty<string>("");

		public readonly ReactiveProperty<double> Time = new ReactiveProperty<double>(0.0);

		public readonly ReactiveProperty<bool> Launched = new ReactiveProperty<bool>(value: false);

		public readonly ReactiveProperty<BoxArt> BoxArt = new ReactiveProperty<BoxArt>(global::BoxArt.One);

		public readonly ReactiveProperty<WorldType> World = new ReactiveProperty<WorldType>();

		public void Dispose()
		{
			Name.Dispose();
			Time.Dispose();
			Launched.Dispose();
			BoxArt.Dispose();
			World.Dispose();
		}
	}

	public class GnormanState : IDisposable
	{
		public readonly ReactiveProperty<GnormanAction> Action = new ReactiveProperty<GnormanAction>(GnormanAction.None);

		public readonly ReactiveProperty<GnormanAnimation> Animation = new ReactiveProperty<GnormanAnimation>(GnormanAnimation.Idle);

		public readonly ReactiveProperty<int> Index = new ReactiveProperty<int>(0);

		public readonly ReactiveProperty<int> MaxIndex = new ReactiveProperty<int>(0);

		public readonly ReactiveProperty<bool> Visible = new ReactiveProperty<bool>(value: false);

		public readonly Queue<GnormanAction> TutorialActionsQueue = new Queue<GnormanAction>();

		public readonly HashSet<GnormanAction> TutorialActionsStarted = new HashSet<GnormanAction>();

		public Gullibleness Gullibleness;

		public bool InProgress => Action.Value != GnormanAction.None;

		public bool HasNextLine => MaxIndex.Value > Index.Value + 1;

		public GnormanFluffActionLine CurrentLine => Action.Value.Data().Line(Index.Value);

		public GnormanTutorialActionLine CurrentTutorialLine
		{
			get
			{
				if (!Action.Value.TutorialData(out var data))
				{
					return default(GnormanTutorialActionLine);
				}
				return data.lines[Index.Value];
			}
		}

		public void Dispose()
		{
			Action.Dispose();
			Animation.Dispose();
			Index.Dispose();
			MaxIndex.Dispose();
			Visible.Dispose();
		}
	}

	public class HistoryState : IDisposable
	{
		public readonly ObservableList<HistoryEntryData> Releases = new ObservableList<HistoryEntryData>();

		public void Dispose()
		{
		}
	}

	public class IRCState : IDisposable
	{
		public const int CAPACITY = 30;

		public readonly ObservableFixedSizeRingBuffer<IRCMessage> General = new ObservableFixedSizeRingBuffer<IRCMessage>(30);

		public readonly ObservableFixedSizeRingBuffer<IRCMessage> System = new ObservableFixedSizeRingBuffer<IRCMessage>(30);

		public readonly ObservableFixedSizeRingBuffer<IRCMessage> Twitch = new ObservableFixedSizeRingBuffer<IRCMessage>(30);

		public readonly ReactiveProperty<LoggedSystemLoadType> LoggedServerLoad = new ReactiveProperty<LoggedSystemLoadType>(LoggedSystemLoadType.NotTriggered);

		public readonly Observable<IRCMessage> NewMessage;

		public readonly Observable<IRCChannel> ChannelCleared;

		public IRCState()
		{
			NewMessage = Observable.Merge<IRCMessage>(from ctx in General.ObserveAdd()
				select ctx.Value, from ctx in System.ObserveAdd()
				select ctx.Value, from ctx in Twitch.ObserveAdd()
				select ctx.Value);
			ChannelCleared = Observable.Merge<IRCChannel>(from _ in General.ObserveClear()
				select IRCChannel.Default, from _ in System.ObserveClear()
				select IRCChannel.System, from _ in Twitch.ObserveClear()
				select IRCChannel.Twitch);
		}

		public void Dispose()
		{
			LoggedServerLoad.Dispose();
		}
	}

	public class MetricsState : IDisposable
	{
		public readonly ReactiveProperty<int> Releases = new ReactiveProperty<int>(1);

		public readonly ReactiveProperty<int> BombdusterEasyWins = new ReactiveProperty<int>(0);

		public readonly ReactiveProperty<int> BombdusterAdvancedWins = new ReactiveProperty<int>(0);

		public readonly ReactiveProperty<int> BombdusterExpertWins = new ReactiveProperty<int>(0);

		public readonly ReactiveProperty<double> MoneySpendUpgrades = new ReactiveProperty<double>(0.0);

		public readonly ReactiveProperty<double> MoneyLifetime = new ReactiveProperty<double>(0.0);

		public readonly ReactiveProperty<double> BugsSquashed = new ReactiveProperty<double>(0.0);

		public readonly ReactiveProperty<double> BugsStagedAuto = new ReactiveProperty<double>(0.0);

		public readonly ReactiveProperty<int> DatacenterReprovisionedFromDegraded = new ReactiveProperty<int>(0);

		public readonly ReactiveProperty<int> DatacenterReprovisionedFromCritical = new ReactiveProperty<int>(0);

		public readonly ReactiveProperty<int> LootchestsOpened = new ReactiveProperty<int>(0);

		public readonly ReactiveProperty<double> MarketingBlastTotalTime = new ReactiveProperty<double>(0.0);

		public readonly HashSet<ComponentUnlockRequirement.Requirement> ComponentsUnlocked = new HashSet<ComponentUnlockRequirement.Requirement>();

		public void Dispose()
		{
			Releases.Dispose();
			BombdusterEasyWins.Dispose();
			BombdusterAdvancedWins.Dispose();
			BombdusterExpertWins.Dispose();
			MoneyLifetime.Dispose();
			BugsSquashed.Dispose();
			BugsStagedAuto.Dispose();
		}
	}

	public class OperationState : IDisposable
	{
		public readonly ObservableDictionary<Operation, int> Activations = new ObservableDictionary<Operation, int>();

		public readonly ObservableDictionary<Operation, ObservableList<OperationInstance>> Instances = new ObservableDictionary<Operation, ObservableList<OperationInstance>>();

		public int TotalActiveOperations => Instances.AsValueEnumerable().Sum((KeyValuePair<Operation, ObservableList<OperationInstance>> x) => x.Value.Count);

		public IEnumerable<OperationInstance> AllActiveOperations => Instances.AsValueEnumerable().SelectMany((KeyValuePair<Operation, ObservableList<OperationInstance>> x) => x.Value).AsEnumerable();

		public bool IsUnlocked(Operation operation)
		{
			if (operation != Operation.None)
			{
				return Activations.ContainsKey(operation);
			}
			return true;
		}

		public bool IsActive(Operation operation)
		{
			return ActiveCount(operation) > 0;
		}

		public int ActiveCount(Operation operation)
		{
			if (!Instances.TryGetValue(operation, out var value))
			{
				return 0;
			}
			return value.Count;
		}

		public int GetActivations(Operation operation)
		{
			return Activations.GetValueOrDefault(operation, 0);
		}

		public void Dispose()
		{
		}
	}

	public class PrestigeState : IDisposable
	{
		public readonly ReactiveProperty<double> Fans = new ReactiveProperty<double>(0.0);

		public readonly ReactiveProperty<double> LastReleaseFansGain = new ReactiveProperty<double>(0.0);

		public readonly ReactiveProperty<double> Data = new ReactiveProperty<double>(0.0);

		public readonly ReactiveProperty<double> LastReleaseDataGain = new ReactiveProperty<double>(0.0);

		public void Dispose()
		{
			Fans.Dispose();
			LastReleaseFansGain.Dispose();
			Data.Dispose();
			LastReleaseDataGain.Dispose();
		}
	}

	public class ResearchState : IDisposable
	{
		public const int MAX_STORAGE_BLADES = 6;

		public readonly ObservableHashSet<ResearchNode> Unlocked = new ObservableHashSet<ResearchNode>();

		public readonly ReactiveProperty<int> DataNodes = new ReactiveProperty<int>(1);

		public bool CanUnlockStorageBlade => DataNodes.Value < 6;

		public bool IsUnlocked(ResearchNode research)
		{
			if (research != ResearchNode.None)
			{
				return Unlocked.Contains(research);
			}
			return true;
		}

		public void Dispose()
		{
			DataNodes.Dispose();
		}
	}

	public class ResourceState : IDisposable
	{
		public readonly ReactiveProperty<double> Players = new ReactiveProperty<double>(0.0);

		public readonly ReactiveProperty<double> Money = new ReactiveProperty<double>(0.0);

		public readonly ReactiveProperty<double> MoneyLifetime = new ReactiveProperty<double>(0.0);

		public readonly ReactiveProperty<double> MoneySpend = new ReactiveProperty<double>(0.0);

		public readonly ReactiveProperty<int> Nodes = new ReactiveProperty<int>(1);

		public readonly ReactiveProperty<float> Load = new ReactiveProperty<float>(0f);

		public readonly ReactiveProperty<float> LoadPlayers = new ReactiveProperty<float>(0f);

		public readonly ReactiveProperty<float> Uptime = new ReactiveProperty<float>(1f);

		public readonly ReactiveProperty<float> Ping = new ReactiveProperty<float>(30f);

		public readonly ReactiveProperty<float> TickRate = new ReactiveProperty<float>(60f);

		public readonly ReactiveProperty<float> Bugs = new ReactiveProperty<float>(0f);

		public readonly ReactiveProperty<float> Hype = new ReactiveProperty<float>(1.2f);

		public readonly ReactiveProperty<float> TargetHype = new ReactiveProperty<float>(1.2f);

		private readonly CancellationTokenSource _cts = new CancellationTokenSource();

		public Observable<double> PlayersPerSecond => (from _ in Players.IntervalChange(1f, 1, _cts.Token)
			where !Database.State.Studio.Paused.CurrentValue
			select _).Prepend(0.0).Share();

		public Observable<double> MoneyPerSecond => (from _ in Money.IntervalChange(1f, 1, _cts.Token)
			where !Database.State.Studio.Paused.CurrentValue
			select _).Prepend(0.0).Share();

		public Observable<double> MoneyRefresh => Money.ThrottleLastTenthSecond().Share();

		public Observable<float> BugsPerSecond => (from _ in Bugs.IntervalChange(1f, 1, _cts.Token)
			where !Database.State.Studio.Paused.CurrentValue
			select _).Prepend(0f).Share();

		public Observable<float> LoadPercentage => Load.Percentage(2).Share();

		public Observable<float> LoadPlayersPercentage => LoadPlayers.Percentage(2).Share();

		public Observable<float> UptimePercentage => Uptime.Percentage(4).Share();

		public Observable<float> HypePercentage => Hype.Percentage(4).Share();

		public Observable<float> TargetHypePercentage => TargetHype.Percentage(4).Share();

		public void Dispose()
		{
			_cts.Cancel();
			Players.Dispose();
			Money.Dispose();
			MoneyLifetime.Dispose();
			MoneySpend.Dispose();
			Nodes.Dispose();
			Load.Dispose();
			LoadPlayers.Dispose();
			Uptime.Dispose();
			Ping.Dispose();
			TickRate.Dispose();
			Bugs.Dispose();
			Hype.Dispose();
			TargetHype.Dispose();
		}
	}

	public class SequelState : IDisposable
	{
		public class SequelProgressState : IDisposable
		{
			public readonly ReactiveProperty<float> GameDesign = new ReactiveProperty<float>(0f);

			public readonly ReactiveProperty<float> Art = new ReactiveProperty<float>(0f);

			public readonly ReactiveProperty<float> Netcode = new ReactiveProperty<float>(0f);

			public readonly ReactiveProperty<float> Marketing = new ReactiveProperty<float>(0f);

			public readonly ReactiveProperty<float> Qa = new ReactiveProperty<float>(0f);

			public readonly ReactiveProperty<Vector2> FactorRange = new ReactiveProperty<Vector2>(Vector2.zero);

			public float Factor => BiteRandom.NextFloat(MinimumFactor, MaximumFactor);

			public float MinimumFactor => FactorRange.Value.x;

			public float MaximumFactor => FactorRange.Value.y;

			public float Normalized => Mathf.Clamp01((GameDesign.Value + Art.Value + Netcode.Value + Marketing.Value + Qa.Value) / 5f);

			public void Dispose()
			{
				GameDesign.Dispose();
				Art.Dispose();
				Netcode.Dispose();
				Marketing.Dispose();
				Qa.Dispose();
				FactorRange.Dispose();
			}
		}

		public readonly ReactiveProperty<string> Name = new ReactiveProperty<string>("");

		public readonly ReactiveProperty<BoxArt> BoxArt = new ReactiveProperty<BoxArt>(global::BoxArt.One);

		public readonly ReactiveProperty<bool> Developing = new ReactiveProperty<bool>(value: false);

		public readonly ReactiveProperty<float> Time = new ReactiveProperty<float>(0f);

		public readonly ReactiveProperty<float> Duration = new ReactiveProperty<float>(0f);

		public readonly ReactiveProperty<int> Round = new ReactiveProperty<int>(0);

		public readonly ReactiveProperty<double> Cost = new ReactiveProperty<double>(0.0);

		public readonly SequelProgressState Progress = new SequelProgressState();

		public bool DevelopmentNotification;

		public Observable<float> NormalizedTime => Time.Normalized(Duration).DistinctUntilChanged();

		public bool IsDoneDeveloping => Time.Value >= Duration.Value;

		public void Dispose()
		{
			Name.Dispose();
			BoxArt.Dispose();
			Developing.Dispose();
			Time.Dispose();
			Duration.Dispose();
			Round.Dispose();
			Cost.Dispose();
			Progress.Dispose();
		}
	}

	public class StudioState : IDisposable
	{
		public readonly ReactiveProperty<string> Name = new ReactiveProperty<string>("");

		public readonly ReactiveProperty<double> Time = new ReactiveProperty<double>(0.0);

		public readonly ReactiveProperty<bool> Tutorial = new ReactiveProperty<bool>(value: false);

		public readonly ReactiveProperty<bool> Paused = new ReactiveProperty<bool>(value: false);

		public readonly ReactiveProperty<EndingState> Ending = new ReactiveProperty<EndingState>(EndingState.InProgress);

		public DateTime EndingAchieved;

		public void Dispose()
		{
			Name.Dispose();
			Time.Dispose();
			Tutorial.Dispose();
			Paused.Dispose();
			Ending.Dispose();
		}
	}

	public class UpgradesState : IDisposable
	{
		public readonly ObservableHashSet<UpgradeNode> Unlocked = new ObservableHashSet<UpgradeNode>();

		public readonly ObservableHashSet<UpgradeNode> Visited = new ObservableHashSet<UpgradeNode>();

		public readonly Observable<UpgradeNode> Changed;

		public UpgradesState()
		{
			Changed = Observable.Merge<UpgradeNode>(from x in Unlocked.ObserveAdd()
				select x.Value, from x in Unlocked.ObserveRemove()
				select x.Value, from _ in Unlocked.ObserveClear()
				select UpgradeNode.None, from x in Visited.ObserveAdd()
				select x.Value).Share();
		}

		public Observable<Unit> ObserveUnlockedOrVisited(UpgradeNodeData data)
		{
			return from _ in Changed.Where((data.ID, data.prerequisite), (UpgradeNode node, (UpgradeNode ID, UpgradeNode prerequisite) state) => node == UpgradeNode.None || node == state.ID || node == state.prerequisite)
				select Unit.Default;
		}

		public bool IsUnlocked(UpgradeNode upgrade)
		{
			if (upgrade != UpgradeNode.None)
			{
				return Unlocked.Contains(upgrade);
			}
			return true;
		}

		public bool IsVisited(UpgradeNode upgrade)
		{
			if (upgrade != UpgradeNode.None)
			{
				return Visited.Contains(upgrade);
			}
			return true;
		}

		public void Dispose()
		{
		}
	}

	public readonly StudioState Studio = new StudioState();

	public readonly GameState Game = new GameState();

	public readonly SequelState Sequel = new SequelState();

	public readonly HistoryState History = new HistoryState();

	public readonly ResourceState Resources = new ResourceState();

	public readonly PrestigeState Prestige = new PrestigeState();

	public readonly MetricsState Metrics = new MetricsState();

	public readonly UpgradesState Upgrades = new UpgradesState();

	public readonly ResearchState Research = new ResearchState();

	public readonly OperationState Operations = new OperationState();

	public readonly DebuggerState Debugger = new DebuggerState();

	public readonly DatacentersState Datacenters = new DatacentersState();

	public readonly GnormanState Gnorman = new GnormanState();

	public readonly CustomizationState Customization = new CustomizationState();

	public readonly AchievementState Achievements = new AchievementState();

	public readonly IRCState IRC = new IRCState();

	public readonly AuctionState Auction = new AuctionState();

	public void Dispose()
	{
		Studio.Dispose();
		Game.Dispose();
		Sequel.Dispose();
		History.Dispose();
		Resources.Dispose();
		Prestige.Dispose();
		Metrics.Dispose();
		Upgrades.Dispose();
		Research.Dispose();
		Operations.Dispose();
		Debugger.Dispose();
		Datacenters.Dispose();
		Gnorman.Dispose();
		Customization.Dispose();
		Achievements.Dispose();
		IRC.Dispose();
		Auction.Dispose();
	}
}
