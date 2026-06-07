using System;
using System.Collections.Generic;
using ObservableCollections;
using R3;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using ZLinq;
using ZLinq.Linq;

public class DatabaseCommands : IDisposable
{
	public class AchievementCommands : IDisposable
	{
		private readonly DatabaseState _state;

		private readonly Dictionary<Achievement, IDisposable> _subscriptions = new Dictionary<Achievement, IDisposable>();

		public AchievementCommands(DatabaseState state)
		{
			_state = state;
			RegisterAchievements(AchievementData.Scope.Studio, _state.Achievements.Studio);
			RegisterAchievements(AchievementData.Scope.Global, _state.Achievements.Global);
		}

		public void Dispose()
		{
			foreach (IDisposable value in _subscriptions.Values)
			{
				value.Dispose();
			}
		}

		public void SetProgress(Achievement achievement, double current)
		{
			AchievementDetails? details = _state.Achievements.GetDetails(achievement);
			if (details.HasValue && !details.Value.Unlocked.Value)
			{
				UpdateProgress(achievement, details.Value, current);
			}
		}

		public void AddProgress(Achievement achievement, double delta)
		{
			if (!(delta <= 0.0))
			{
				AchievementDetails? details = _state.Achievements.GetDetails(achievement);
				if (details.HasValue && !details.Value.Unlocked.Value)
				{
					UpdateProgress(achievement, details.Value, details.Value.Progress.Value + delta);
				}
			}
		}

		public void Unlock(Achievement achievement)
		{
			AchievementDetails? details = _state.Achievements.GetDetails(achievement);
			if (details.HasValue && !details.Value.Unlocked.Value)
			{
				details.Value.Unlocked.Value = true;
				details.Value.Progress.Value = details.Value.Target;
				if (_subscriptions.TryGetValue(achievement, out var value))
				{
					value.Dispose();
				}
				Database.Commands.IRC.Print(IRCSystem.Achievement, delegate(LocalizedString localized)
				{
					localized["achievement_title"] = achievement.Data().TitleLocalized;
				});
				EventHub.Scene.Publish(new AchievementUnlocked(achievement));
				achievement.TriggerSteam();
			}
		}

		private void UpdateProgress(Achievement achievement, AchievementDetails details, double current)
		{
			double num = Math.Min(current, details.Target);
			if (!(num <= details.Progress.Value))
			{
				details.Progress.Value = num;
				achievement.SetStatSteam(num);
				if (details.Progress.Value >= details.Target)
				{
					Unlock(achievement);
				}
			}
		}

		private void RegisterAchievements(AchievementData.Scope scope, ObservableDictionary<Achievement, AchievementDetails> dictionary)
		{
			using ValueEnumerator<SelectWhere<FromEnumerable<Achievement>, Achievement, AchievementData>, AchievementData> valueEnumerator = (from x in EnumUtility.GetValuesSkipNone<Achievement>().AsValueEnumerable()
				select x.Data() into x
				where x.scope == scope
				select x).GetEnumerator<SelectWhere<FromEnumerable<Achievement>, Achievement, AchievementData>, AchievementData>();
			while (valueEnumerator.MoveNext())
			{
				AchievementData current = valueEnumerator.Current;
				if (!dictionary.ContainsKey(current))
				{
					dictionary.Add(current, new AchievementDetails(current.target));
				}
			}
		}

		public void SetupTracking()
		{
			using ValueEnumerator<FromEnumerable<Achievement>, Achievement> valueEnumerator = EnumUtility.GetValuesSkipNone<Achievement>().AsValueEnumerable().GetEnumerator<FromEnumerable<Achievement>, Achievement>();
			while (valueEnumerator.MoveNext())
			{
				AchievementData achievementData = valueEnumerator.Current.Data();
				AchievementDetails? details = _state.Achievements.GetDetails(achievementData);
				if (details.HasValue && !details.Value.Unlocked.Value)
				{
					AchievementContext ctx = new AchievementContext(achievementData, details.Value, _state, Database.Commands, this);
					_subscriptions.Add(achievementData, AchievementTracker.StartTracking(ctx));
				}
			}
		}
	}

	public class AuctionCommands
	{
		private readonly DatabaseState _state;

		public AuctionCommands(DatabaseState state)
		{
			_state = state;
		}

		public void ReceiveLootchest()
		{
			if (_state.Auction.AvailableLootchests.Value < ModifierType.AuctionLootchestCapacity.Int())
			{
				_state.Auction.AvailableLootchests.Increment();
			}
		}

		public void OpenLootchest()
		{
			if (!_state.Auction.CurrentLootItem.Value.HasValue && _state.Auction.AvailableLootchests.Value != 0)
			{
				_state.Auction.CurrentLootItem.Value = RandomLootItem();
				_state.Auction.AvailableLootchests.Decrement();
				_state.Metrics.LootchestsOpened.Increment();
			}
		}

		public void SalvageLootchest()
		{
			if (_state.Auction.CurrentLootItem.Value.HasValue)
			{
				_state.Auction.CurrentLootItem.Value = null;
				if (_state.Auction.AvailableLootchests.Value < ModifierType.AuctionLootchestCapacity.Int())
				{
					_state.Auction.AvailableLootchests.Increment();
				}
				EventHub.Scene.Publish(default(SalvagedLootItem));
			}
		}

		public void SellLootchest()
		{
			if (_state.Auction.CurrentLootItem.Value.HasValue)
			{
				LootItem value = _state.Auction.CurrentLootItem.Value.Value;
				_state.Auction.CurrentLootItem.Value = null;
				_state.Auction.EscrowMoney.Value += value.Value;
				_state.Auction.AuctionLog.AddLast(new AuctionLogMessage(GetPlayersUsername(), value.Name, value.Value, value.Value, 1f));
				EventHub.Scene.Publish(default(SoldLootItem));
			}
		}

		public void SellRandom()
		{
			LootItem lootItem = RandomLootItem();
			double cut = lootItem.Cut;
			_state.Auction.EscrowMoney.Value += cut;
			_state.Auction.AuctionLog.AddLast(new AuctionLogMessage(LocalizationUtility.Random(LocTable.Names).GetLocalizedString(), lootItem.Name, lootItem.Value, cut, ModifierType.AuctionCut.Float()));
		}

		public void EscrowInterest()
		{
			_state.Auction.EscrowMoney.Value *= 1f + ModifierType.AuctionEscrowInterest.Float();
		}

		public void AdjustDropchance(LootItemQuality quality, float value)
		{
			float[] chances = new float[4];
			ReactiveProperty<float>[] properties = new ReactiveProperty<float>[4]
			{
				_state.Auction.CommonDropchance,
				_state.Auction.UncommonDropchance,
				_state.Auction.RareDropchance,
				_state.Auction.LegendaryDropchance
			};
			AuctionUtility.MapFromProperties(ref chances, properties);
			AuctionUtility.RedistributeProportionally((int)quality, value, ref chances);
			AuctionUtility.MapToProperties(ref chances, properties);
		}

		public void WithdrawMoney()
		{
			Database.Commands.Achievements.SetProgress(Achievement.Wallstreet, _state.Auction.EscrowMoney.Value);
			Database.Commands.Resource.ReceiveMoney(_state.Auction.EscrowMoney.Value);
			_state.Auction.EscrowMoney.Value = 0.0;
		}

		private string GetPlayersUsername()
		{
			if (!RichPresence.TryGetUsername(out var username))
			{
				return _state.Studio.Name.Value;
			}
			return username;
		}

		private static LootItem RandomLootItem()
		{
			LootItemQuality quality = AuctionUtility.RandomLootQuality();
			LootItemCategory random = EnumUtility.GetRandom<LootItemCategory>();
			string randomName = AuctionItemsReference.GetRandomName(random, quality);
			int iconIndex = random.Value().AsValueEnumerable().RandomIndex();
			double value = AuctionUtility.RandomLootValue(quality);
			return new LootItem(quality, random, randomName, iconIndex, value);
		}
	}

	public class DatacenterCommands
	{
		private readonly DatabaseState _state;

		public DatacenterCommands(DatabaseState state)
		{
			_state = state;
		}

		public double CalculateCostDatacenter(DatacenterData datacenter)
		{
			return ModifierType.DatacenterCost.Modified(datacenter.cost);
		}

		public double CalculateCostEngineer(DatacenterData datacenter)
		{
			double baseCost = ModifierType.EngineerCost.Modified(datacenter.costEngineer);
			float scaleFactor = ModifierType.EngineerCostScale.Modified(datacenter.costEngineerScale);
			return Database.Commands.Resource.CalculateScaledCost(baseCost, scaleFactor, _state.Datacenters.GetEngineers(datacenter));
		}

		public float ManualReprovision(Datacenter datacenter)
		{
			if (!_state.Datacenters.IsUnlocked(datacenter))
			{
				return 0f;
			}
			DatacenterDetails details = _state.Datacenters.GetDetails(datacenter);
			if (details.State.Value == DatacenterState.Nominal)
			{
				return 0f;
			}
			return details.ReprovisionProgress.Value += ModifierType.ReprovisionProgressManual.Float();
		}

		public void HireEngineer(Datacenter datacenter)
		{
			if (_state.Datacenters.IsUnlocked(datacenter) && Database.Commands.Resource.AttemptBuyMoney(CalculateCostEngineer(datacenter)))
			{
				_state.Datacenters.GetDetails(datacenter).Engineers.Increment();
				_state.Datacenters.HireChanged.OnNext(datacenter);
			}
		}

		public void Degrade(Datacenter datacenter)
		{
			if (!_state.Datacenters.IsUnlocked(datacenter))
			{
				return;
			}
			DatacenterDetails details = _state.Datacenters.GetDetails(datacenter);
			if (details.State.Value != DatacenterState.Critical)
			{
				DatacenterState value = details.State.Value;
				if (details.State.Value == DatacenterState.Nominal)
				{
					details.ReprovisionProgress.Value = 0f;
					details.State.Value = DatacenterState.Degraded;
				}
				else if (details.State.Value == DatacenterState.Degraded)
				{
					details.State.Value = DatacenterState.Critical;
				}
				_state.Datacenters.StateChanged.OnNext(datacenter);
				PrintDatacenterStateIrcMessage(datacenter, value, details.State.Value);
			}
		}

		public void Restore(Datacenter datacenter)
		{
			if (!_state.Datacenters.IsUnlocked(datacenter))
			{
				return;
			}
			DatacenterDetails details = _state.Datacenters.GetDetails(datacenter);
			DatacenterState value = details.State.Value;
			if (value == DatacenterState.Degraded || value == DatacenterState.Critical)
			{
				DatacenterState value2 = details.State.Value;
				details.State.Value = DatacenterState.Nominal;
				details.ReprovisionProgress.Value = 0f;
				_state.Datacenters.StateChanged.OnNext(datacenter);
				_state.Datacenters.RecentlyDegraded.Add(datacenter, ModifierType.DatacenterDegradeGracePeriod.Float());
				if (value2 == DatacenterState.Degraded)
				{
					_state.Metrics.DatacenterReprovisionedFromDegraded.Increment();
				}
				else
				{
					_state.Metrics.DatacenterReprovisionedFromCritical.Increment();
				}
				PrintDatacenterStateIrcMessage(datacenter, value2, details.State.Value);
				Audio.PlaySfx(AudioDataType.DatacenterRestored);
			}
		}

		public void Unlock(DatacenterData datacenter)
		{
			if (!_state.Datacenters.IsUnlocked(datacenter) && _state.Datacenters.IsAvailable(datacenter) && Database.Commands.Resource.AttemptBuyMoney(datacenter.cost))
			{
				_state.Datacenters.Details.Add(datacenter.ID, new DatacenterDetails(DatacenterState.Construction));
				_state.Datacenters.StateChanged.OnNext(datacenter);
				Database.Commands.IRC.Print(IRCSystem.DatacenterOpened, delegate(LocalizedString localized)
				{
					localized["datacenter_title"] = datacenter.TitleLocalized;
				});
			}
		}

		public void Construct(Datacenter datacenter)
		{
			if (!_state.Datacenters.IsUnlocked(datacenter))
			{
				DatacenterDetails details = _state.Datacenters.GetDetails(datacenter);
				DatacenterState? datacenterState = details?.State.Value;
				if (datacenterState.HasValue && datacenterState == DatacenterState.Construction)
				{
					details.State.Value = DatacenterState.Nominal;
					details.ReprovisionProgress.Value = 0f;
					_state.Datacenters.StateChanged.OnNext(datacenter);
					_state.Datacenters.BonusGrowthTimer.Value = IncreaseBonusGrowthTimer(_state.Datacenters.BonusGrowthTimer.Value);
					Audio.PlaySfx(AudioDataType.DatacenterConstructed);
					PrintDatacenterStateIrcMessage(datacenter, DatacenterState.Construction, DatacenterState.Nominal);
				}
			}
		}

		private static TimerData IncreaseBonusGrowthTimer(TimerData current)
		{
			float current2 = 0f;
			float num = ModifierType.DatacenterUnlockGrowthDuration.Float();
			if (!current.IsActive)
			{
				return new TimerData(current2, num);
			}
			current2 = current.Current;
			num += current.Duration;
			return new TimerData(current2, num);
		}

		private static void PrintDatacenterStateIrcMessage(DatacenterData datacenter, DatacenterState oldState, DatacenterState newState)
		{
			Database.Commands.IRC.Print(IRCSystem.DatacenterState, delegate(LocalizedString localized)
			{
				localized["datacenter_title"] = datacenter.TitleLocalized;
				localized["datacenter_old_state"] = LocalizationUtility.For(oldState);
				localized["datacenter_new_state"] = LocalizationUtility.For(newState);
			});
		}
	}

	public class DebuggerCommands
	{
		private readonly DatabaseState _state;

		public DebuggerCommands(DatabaseState state)
		{
			_state = state;
		}

		public void GlitchHex(int index)
		{
			if (_state.Resources.Bugs.Value != 0f)
			{
				_state.Debugger.Glitched.Add(index);
			}
		}

		public bool StageHex(int index, int hex, bool automated)
		{
			_state.Debugger.Automated.Remove(index);
			if (_state.Debugger.InProgress)
			{
				return false;
			}
			if (_state.Debugger.Staged.Count >= ModifierType.DebuggerMaxStaging.Int())
			{
				return false;
			}
			if (!_state.Debugger.Glitched.Remove(index))
			{
				return false;
			}
			_state.Debugger.Staged.Add(hex);
			if (automated)
			{
				_state.Metrics.BugsStagedAuto.AddValue(1.0);
			}
			return true;
		}

		public void PushHotfix()
		{
			if (!_state.Debugger.InProgress && _state.Debugger.Staged.Count != 0)
			{
				_state.Debugger.Hotfixing.Value = true;
				_state.Debugger.Progress.Value = new TimerData(0f, 1f);
			}
		}

		public void CompilePatch()
		{
			if (!_state.Debugger.InProgress && _state.Debugger.StagedBugs != 0f)
			{
				_state.Debugger.Compiling.Value = true;
				_state.Debugger.Progress.StartTimer(1f);
			}
		}

		public void Finished()
		{
			if (_state.Debugger.InProgress)
			{
				float stagedBugs = _state.Debugger.StagedBugs;
				Database.State.Metrics.BugsSquashed.AddValue(stagedBugs);
				Database.State.Resources.Bugs.SubtractValue(stagedBugs);
				_state.Debugger.Staged.Clear();
				_state.Debugger.Progress.Value = TimerData.Empty;
				if (_state.Debugger.Hotfixing.Value)
				{
					_state.Debugger.BonusDecayTimer.Value = new TimerData(0f, ModifierType.DebuggerHotfixBonusDuration.Float());
					_state.Debugger.BonusDecayRate.SetValue(ModifierType.DebuggerHotfixBonusDecayRate.Float());
					_state.Debugger.Hotfixing.Value = false;
					Database.Commands.IRC.Print(IRCSystem.DebuggerHotfix);
				}
				else if (_state.Debugger.Compiling.Value)
				{
					_state.Debugger.BonusDecayTimer.Value = new TimerData(0f, ModifierType.DebuggerCompilationBonusDuration.Float());
					_state.Debugger.BonusDecayRate.SetValue(ModifierType.DebuggerCompilationBonusDecayRate.Float());
					_state.Debugger.BonusGrowthTimer.Value = new TimerData(0f, ModifierType.DebuggerCompilationGrowthDuration.Float());
					_state.Debugger.BonusGrowthRate.SetValue(ModifierType.DebuggerCompilationGrowth.Float() * (float)_state.Debugger.Staged.Count);
					_state.Debugger.Compiling.Value = false;
					Database.Commands.IRC.Print(IRCSystem.DebuggerPatch);
				}
			}
		}
	}

	public class GnormanCommands
	{
		private readonly DatabaseState _state;

		public GnormanCommands(DatabaseState state)
		{
			_state = state;
		}

		public void Activate(GnormanAction newAction)
		{
			GnormanActionData gnormanActionData = newAction.Data();
			_state.Gnorman.Index.Value = 0;
			_state.Gnorman.MaxIndex.Value = gnormanActionData.MaxLines;
			_state.Gnorman.Action.Value = newAction;
			_state.Gnorman.Visible.Value = true;
			_state.Gnorman.Gullibleness = ((newAction == GnormanAction.Fluff12) ? Gullibleness.Listen : Gullibleness.None);
			if (newAction.IsTutorial())
			{
				_state.Gnorman.TutorialActionsStarted.Add(newAction);
			}
		}

		public bool MoveNext()
		{
			_state.Gnorman.Index.Increment();
			return _state.Gnorman.Index.Value < _state.Gnorman.MaxIndex.Value;
		}

		public void EndAction()
		{
			_state.Gnorman.Index.Value = 0;
			_state.Gnorman.MaxIndex.Value = 0;
			_state.Gnorman.Action.Value = GnormanAction.None;
			EventHub.Scene.Publish(new GnormanActionFinished(_state.Gnorman.Action.Value));
		}

		public void ToggleVisibility()
		{
			if (!_state.Gnorman.InProgress)
			{
				if (ReactiveSettings.GnormanMuffled.Value && !_state.Gnorman.Visible.Value)
				{
					UI.Registry.popup.gnormanMuffled.SetActive(value: true);
				}
				else
				{
					_state.Gnorman.Visible.Toggle();
				}
			}
		}
	}

	public class HistoryCommands
	{
		private readonly DatabaseState _state;

		public HistoryCommands(DatabaseState state)
		{
			_state = state;
		}

		public HistoryEntryData CreateHistory()
		{
			return new HistoryEntryData
			{
				Release = _state.Metrics.Releases.Value,
				Title = _state.Game.Name.Value,
				BoxArt = _state.Game.BoxArt.Value,
				Money = _state.Resources.MoneyLifetime.Value,
				Players = _state.Resources.Players.Value,
				Time = _state.Game.Time.Value
			};
		}
	}

	public class IRCCommands
	{
		private readonly DatabaseState _state;

		public IRCCommands(DatabaseState state)
		{
			_state = state;
		}

		public void Print(IRCChannel channel, LocalizedString username, LocalizedString message, Color color)
		{
			Print(channel, username.GetLocalizedString(), message.GetLocalizedString(), color);
		}

		public void Print(IRCChannel channel, string username, string message, Color color)
		{
			IRCMessage item = new IRCMessage(channel, username, message, color);
			if (channel.HasFlag(IRCChannel.System))
			{
				_state.IRC.System.AddLast(item);
			}
			else if (channel.HasFlag(IRCChannel.Twitch))
			{
				_state.IRC.Twitch.AddLast(item);
			}
			else
			{
				_state.IRC.General.AddLast(item);
			}
		}

		public void Print(IRCSystem system, Action<LocalizedString> configure = null)
		{
			LocalizedString localizedString = system.Value().Duplicate();
			configure?.Invoke(localizedString);
			Print(IRCChannel.System, IRCSystem.Name.Value(), localizedString, IRCColor.System.Value());
		}

		public void ClearChannel(IRCChannel channel)
		{
			switch (channel)
			{
			case IRCChannel.Default:
				_state.IRC.General.Clear();
				break;
			case IRCChannel.System:
				_state.IRC.System.Clear();
				break;
			case IRCChannel.Twitch:
				_state.IRC.Twitch.Clear();
				break;
			case IRCChannel.All:
				_state.IRC.General.Clear();
				_state.IRC.System.Clear();
				_state.IRC.Twitch.Clear();
				break;
			}
		}
	}

	public class OperationCommands
	{
		private readonly DatabaseState _state;

		public OperationCommands(DatabaseState state)
		{
			_state = state;
			using (ValueEnumerator<Select<FromEnumerable<ResearchNode>, ResearchNode, Operation>, Operation> valueEnumerator = (from r in _state.Research.Unlocked.AsValueEnumerable()
				select r.Data().operation).GetEnumerator<Select<FromEnumerable<ResearchNode>, ResearchNode, Operation>, Operation>())
			{
				while (valueEnumerator.MoveNext())
				{
					Operation current = valueEnumerator.Current;
					Unlock(current);
				}
			}
			if (!_state.Game.Launched.Value)
			{
				Unlock(Operation.ReleaseGame);
			}
		}

		public double CalculateCost(OperationData operation)
		{
			if (operation.cost == 0.0)
			{
				return 0.0;
			}
			double cost = ModifierType.OperationGeneralCost.Modified(operation.cost);
			cost = operation.ID.CostModifier(cost);
			float costScale = ModifierType.OperationGeneralCostScale.Modified(operation.costScale);
			costScale = operation.ID.CostScaleModifier(costScale);
			return Database.Commands.Resource.CalculateScaledCost(cost, costScale, _state.Operations.GetActivations(operation));
		}

		public float CalculateDuration(OperationData operation)
		{
			return operation.duration * operation.ID.SpeedModifier(ModifierType.OperationGeneralSpeed.Float());
		}

		public void Unlock(Operation operation)
		{
			if (!_state.Operations.IsUnlocked(operation))
			{
				_state.Operations.Activations[operation] = 0;
				_state.Operations.Instances[operation] = new ObservableList<OperationInstance>();
				EventHub.Scene.Publish(new OperationUnlocked(operation));
			}
		}

		public bool CanStartOperation(OperationData operation)
		{
			if (operation.ID == Operation.None)
			{
				return false;
			}
			if (operation.ID == Operation.LineOfCredit && !_state.Game.Launched.Value)
			{
				return false;
			}
			if (!_state.Operations.IsUnlocked(operation))
			{
				return false;
			}
			if (!operation.allowMultipleUses && _state.Operations.IsActive(operation))
			{
				return false;
			}
			return _state.Operations.TotalActiveOperations < ModifierType.OperationConcurrentAmount.Int();
		}

		public void StartOperation(OperationData operation)
		{
			if (CanStartOperation(operation) && Database.Commands.Resource.AttemptBuyMoney(CalculateCost(operation)))
			{
				OperationInstance operationInstance = OperationInstanceFactory.Create(operation);
				_state.Operations.Activations[operation]++;
				_state.Operations.Instances[operation].Add(operationInstance);
				Database.Modifiers.AddSource(ModifierSourceId.OperationInstance(operationInstance.Guid), operationInstance.AvailableModifiers);
				EventHub.Scene.Publish(new OperationStarted(operation));
			}
		}

		public void CompleteOperation(OperationInstance instance)
		{
			if (instance.Operation != Operation.None && _state.Operations.Instances.TryGetValue(instance.Operation, out var value))
			{
				value.Remove(instance);
				OperationData operationData = instance.Operation.Data();
				if (instance.Operation == Operation.MarketingBlast)
				{
					Database.State.Metrics.MarketingBlastTotalTime.Value += instance.Duration;
				}
				Database.Modifiers.RemoveSource(ModifierSourceId.OperationInstance(instance.Guid));
				Database.Rewards.Apply(operationData.rewards.AsValueEnumerable());
				EventHub.Scene.Publish(new OperationFinished(instance.Operation));
			}
		}
	}

	public class ResearchCommands
	{
		private readonly DatabaseState _state;

		public ResearchCommands(DatabaseState state)
		{
			_state = state;
		}

		public double CalculateCost(ResearchNodeData research)
		{
			return research.cost;
		}

		public void Unlock(ResearchNodeData research)
		{
			if (_state.Research.IsUnlocked(research) || !Database.Commands.Resource.AttemptBuyData(CalculateCost(research)))
			{
				return;
			}
			_state.Research.Unlocked.Add(research);
			Database.Commands.Operations.Unlock(research.operation);
			Database.Modifiers.AddSource(new ModifierSourceId(ModifierSourceType.Research, (int)research.ID), research.modifiers);
			EventHub.Scene.Publish(new ResearchBought(research));
			Database.Commands.IRC.Print(IRCSystem.Research, delegate(LocalizedString localized)
			{
				localized["research_title"] = research.TitleLocalized;
				localized["research_cost"] = new DoubleVariable
				{
					Value = CalculateCost(research)
				};
			});
			using ValueEnumerator<ListWhereSelect<Modifier, double>, double> valueEnumerator = (from x in research.modifiers.AsValueEnumerable()
				where x.type == ModifierType.StartingCapital
				select x.value).GetEnumerator<ListWhereSelect<Modifier, double>, double>();
			while (valueEnumerator.MoveNext())
			{
				double current = valueEnumerator.Current;
				Database.Commands.Resource.ReceiveMoney(current);
			}
		}

		public void IncreaseStorage()
		{
			if (Database.State.Research.CanUnlockStorageBlade && Database.Commands.Resource.AttemptBuyData(Database.Derived.DataCapacityCost.CurrentValue))
			{
				Database.State.Research.DataNodes.Increment();
			}
		}
	}

	public class ResourceCommands
	{
		private readonly DatabaseState _state;

		public ResourceCommands(DatabaseState state)
		{
			_state = state;
		}

		public void ReceiveMoney(double money)
		{
			double num = 0.0;
			if (Database.State.Operations.IsActive(Operation.LineOfCredit))
			{
				LineOfCreditInstance obj = Database.State.Operations.Instances[Operation.LineOfCredit][0] as LineOfCreditInstance;
				num = money * (double)ModifierType.OperationLineOfCreditRepayment.Float();
				obj.Time += (float)num;
			}
			_state.Resources.Money.Value += money - num;
			_state.Resources.MoneyLifetime.Value += money;
			_state.Metrics.MoneyLifetime.Value += money;
		}

		public bool HasMoney(double money)
		{
			return _state.Resources.Money.Value >= money;
		}

		public bool AttemptBuyMoney(double price)
		{
			if (!HasMoney(price))
			{
				Audio.PlaySfx(AudioDataType.FailSfx);
				return false;
			}
			_state.Resources.Money.SubtractValue(price);
			_state.Resources.MoneySpend.AddValue(price);
			return true;
		}

		public bool HasData(double data)
		{
			return _state.Prestige.Data.Value >= data;
		}

		public bool AttemptBuyData(double price)
		{
			if (!HasData(price))
			{
				Audio.PlaySfx(AudioDataType.FailSfx);
				return false;
			}
			_state.Prestige.Data.SubtractValue(price);
			return true;
		}

		public double CalculateScaledCost(double baseCost, float scaleFactor, int timesScaled)
		{
			return CalculateScaledCost(baseCost, (scaleFactor, timesScaled));
		}

		public double CalculateScaledCost(double baseCost, params (float scaleFactor, int timesScaled)[] scales)
		{
			using (ValueEnumerator<ArrayWhere<(float, int)>, (float, int)> valueEnumerator = (from x in scales.AsValueEnumerable()
				where x.timesScaled >= 1
				select x).GetEnumerator<ArrayWhere<(float, int)>, (float, int)>())
			{
				while (valueEnumerator.MoveNext())
				{
					(float, int) current = valueEnumerator.Current;
					float item = current.Item1;
					int item2 = current.Item2;
					baseCost *= Math.Pow(Math.Max(1f, item), item2);
				}
			}
			return Math.Round(baseCost);
		}
	}

	public class SequelCommands
	{
		private readonly DatabaseState _state;

		public SequelCommands(DatabaseState state)
		{
			_state = state;
		}

		public void RandomizeBoxArt()
		{
			BoxArt randomSkipNone;
			do
			{
				randomSkipNone = EnumUtility.GetRandomSkipNone<BoxArt>();
			}
			while (Database.State.Sequel.BoxArt.Value == randomSkipNone || Database.State.Game.BoxArt.Value == randomSkipNone);
			_state.Sequel.BoxArt.Value = randomSkipNone;
		}

		public void RandomizeName()
		{
			string localizedString;
			do
			{
				localizedString = LocalizationUtility.Random(LocTable.Titles).GetLocalizedString();
			}
			while (Database.State.Sequel.Name.Value == localizedString || Database.State.Game.Name.Value == localizedString);
			_state.Sequel.Name.Value = localizedString;
		}

		public (double minimum, double maximum) PreviewDataGain()
		{
			double players = ActualNewPlayers();
			double item = DataGain(players, _state.Sequel.Progress.MinimumFactor);
			double item2 = DataGain(players, _state.Sequel.Progress.MaximumFactor);
			return (minimum: item, maximum: item2);
		}

		public (double fans, double data) CalculateActualGain()
		{
			double players = ActualNewPlayers();
			double item = FansGain(players, _state.Sequel.Progress.Factor);
			double item2 = Math.Min(val2: DataGain(players, _state.Sequel.Progress.Factor), val1: Database.Derived.DataCapacity.CurrentValue - Database.State.Prestige.Data.Value);
			return (fans: item, data: item2);
		}

		private double FansGain(double players, float factor)
		{
			return MathUtility.FansGainFormula(players, 0.75f, factor, 2f) * (double)ModifierType.FansModifier.Float();
		}

		private double DataGain(double players, float factor)
		{
			return MathUtility.DataGainFormula(players, factor, 50000.0, 1.25f, 50.0, 4f) * (double)ModifierType.DataModifier.Float();
		}

		private double ActualNewPlayers()
		{
			return Math.Max(_state.Resources.Players.Value - _state.Prestige.Fans.Value, 1.0);
		}

		public void Prestige(bool abandoned)
		{
			_state.History.Releases.Add(Database.Commands.History.CreateHistory());
			_state.Game.Name.Value = _state.Sequel.Name.Value;
			_state.Game.Time.Value = 0.0;
			_state.Game.BoxArt.OnNext(_state.Sequel.BoxArt.Value);
			_state.Game.World.Value = EnumUtility.GetRandom<WorldType>();
			_state.Game.Launched.Value = false;
			double value;
			double value2;
			if (!abandoned)
			{
				(value, value2) = CalculateActualGain();
			}
			else
			{
				value = 0.0;
				value2 = 0.0;
			}
			_state.Prestige.Fans.AddValue(value);
			_state.Prestige.LastReleaseFansGain.SetValue(value);
			_state.Prestige.Data.AddValue(value2);
			_state.Prestige.LastReleaseDataGain.SetValue(value2);
			_state.Sequel.Name.Value = "";
			_state.Sequel.Developing.Value = false;
			_state.Sequel.Time.Value = 0f;
			_state.Sequel.Duration.Value = 0f;
			_state.Sequel.Round.Value = 0;
			_state.Sequel.Cost.Value = 0.0;
			_state.Sequel.Progress.GameDesign.Value = 0f;
			_state.Sequel.Progress.Art.Value = 0f;
			_state.Sequel.Progress.Netcode.Value = 0f;
			_state.Sequel.Progress.Marketing.Value = 0f;
			_state.Sequel.Progress.Qa.Value = 0f;
			_state.Sequel.Progress.FactorRange.Value = Vector2.zero;
			RandomizeBoxArt();
			_state.Resources.Players.Value = 0.0;
			_state.Resources.Money.Value = 0.0;
			_state.Resources.MoneyLifetime.Value = 0.0;
			_state.Resources.MoneySpend.Value = 0.0;
			_state.Resources.Nodes.Value = 1;
			_state.Resources.Load.Value = 0f;
			_state.Resources.LoadPlayers.Value = 0f;
			_state.Resources.Uptime.Value = 1f;
			_state.Resources.Ping.Value = 30f;
			_state.Resources.TickRate.Value = 60f;
			_state.Resources.Bugs.Value = 0f;
			_state.Resources.Hype.Value = 1.2f;
			_state.Resources.TargetHype.Value = 1.2f;
			Database.State.Auction.CurrentLootItem.Value = null;
			Database.State.Auction.AvailableLootchests.SetValue(0);
			Database.State.Auction.TimeNextLootchest.ResetTimer();
			Database.State.Auction.EscrowMoney.SetValue(0.0);
			Database.State.Auction.EscrowInterestInterval.ResetTimer();
			Database.State.Auction.AuctionLog.Clear();
			AuctionUtility.RerollHiddenDistribution(_state.Auction);
			Database.Commands.Resource.ReceiveMoney(ModifierType.StartingCapital.Double());
			if (!_state.Research.IsUnlocked(ResearchNode.BackwardsCompatibility))
			{
				_state.Upgrades.Unlocked.Clear();
			}
			_state.Operations.Activations.Clear();
			foreach (KeyValuePair<Operation, ObservableList<OperationInstance>> instance in _state.Operations.Instances)
			{
				instance.Value.Clear();
			}
			_state.Operations.Instances.Clear();
			_state.Debugger.Staged.Clear();
			_state.Debugger.Glitched.Clear();
			_state.Debugger.Hotfixing.Value = false;
			_state.Debugger.Compiling.Value = false;
			_state.Debugger.Progress.Value = TimerData.Empty;
			_state.Debugger.RefreshTimer.ResetTimer();
			_state.Debugger.GlitchTimer.Value = TimerData.Empty;
			_state.Debugger.BonusDecayTimer.Value = TimerData.Empty;
			_state.Debugger.BonusDecayRate.Value = 0f;
			_state.Datacenters.Details.Clear();
			_state.Datacenters.RecentlyDegraded.Clear();
			_state.Datacenters.Selected.Value = Datacenter.None;
			Database.Modifiers.RefreshFull();
			using (ValueEnumerator<Select<FromEnumerable<UpgradeNode>, UpgradeNode, Operation>, Operation> valueEnumerator = (from r in _state.Upgrades.Unlocked.AsValueEnumerable()
				select r.Data().operation).GetEnumerator<Select<FromEnumerable<UpgradeNode>, UpgradeNode, Operation>, Operation>())
			{
				while (valueEnumerator.MoveNext())
				{
					Operation current = valueEnumerator.Current;
					Database.Commands.Operations.Unlock(current);
				}
			}
			using (ValueEnumerator<Select<FromEnumerable<ResearchNode>, ResearchNode, Operation>, Operation> valueEnumerator2 = (from r in _state.Research.Unlocked.AsValueEnumerable()
				select r.Data().operation).GetEnumerator<Select<FromEnumerable<ResearchNode>, ResearchNode, Operation>, Operation>())
			{
				while (valueEnumerator2.MoveNext())
				{
					Operation current2 = valueEnumerator2.Current;
					Database.Commands.Operations.Unlock(current2);
				}
			}
			Database.Commands.Operations.Unlock(Operation.ReleaseGame);
			EventHub.Scene.Publish<Prestiged>();
			Database.Commands.IRC.ClearChannel(IRCChannel.Default | IRCChannel.System);
			Database.Commands.IRC.Print(IRCSystem.GameReleased);
			_state.Metrics.Releases.Increment();
		}
	}

	public class UpgradeCommands
	{
		private readonly DatabaseState _state;

		public UpgradeCommands(DatabaseState state)
		{
			_state = state;
		}

		public double CalculateCost(UpgradeNodeData upgrade)
		{
			return ModifierType.UpgradeGeneralCost.Modified(upgrade.cost);
		}

		public UpgradeState GetState(UpgradeNodeData upgrade)
		{
			if (!_state.Research.IsUnlocked(upgrade.research))
			{
				return UpgradeState.Hidden;
			}
			if (!_state.Upgrades.IsVisited(upgrade.prerequisite))
			{
				return UpgradeState.Hidden;
			}
			if (!_state.Upgrades.IsUnlocked(upgrade.prerequisite))
			{
				return UpgradeState.Locked;
			}
			if (_state.Upgrades.IsUnlocked(upgrade))
			{
				return UpgradeState.Bought;
			}
			if (!Database.Commands.Resource.HasMoney(CalculateCost(upgrade)))
			{
				return UpgradeState.Available;
			}
			return UpgradeState.Purchaseable;
		}

		public void Unlock(UpgradeNodeData upgrade)
		{
			if (GetState(upgrade) != UpgradeState.Purchaseable)
			{
				return;
			}
			double num = CalculateCost(upgrade);
			if (Database.Commands.Resource.AttemptBuyMoney(num))
			{
				_state.Upgrades.Unlocked.Add(upgrade);
				_state.Upgrades.Visited.Add(upgrade);
				_state.Metrics.MoneySpendUpgrades.AddValue(num);
				Database.Commands.Operations.Unlock(upgrade.operation);
				Database.Modifiers.AddSource(new ModifierSourceId(ModifierSourceType.Upgrade, (int)upgrade.ID), upgrade.modifiers);
				EventHub.Scene.Publish(new UpgradeBought(upgrade));
				Database.Commands.IRC.Print(IRCSystem.Upgrade, delegate(LocalizedString localized)
				{
					localized["upgrade_title"] = upgrade.TitleLocalized;
					localized["upgrade_cost"] = new DoubleVariable
					{
						Value = CalculateCost(upgrade)
					};
				});
			}
		}
	}

	public readonly DatacenterCommands Datacenters;

	public readonly DebuggerCommands Debugger;

	public readonly GnormanCommands Gnorman;

	public readonly OperationCommands Operations;

	public readonly ResearchCommands Research;

	public readonly ResourceCommands Resource;

	public readonly SequelCommands Sequel;

	public readonly HistoryCommands History;

	public readonly UpgradeCommands Upgrades;

	public readonly AchievementCommands Achievements;

	public readonly IRCCommands IRC;

	public readonly AuctionCommands Auction;

	private readonly DatabaseState _state;

	public DatabaseCommands(DatabaseState state)
	{
		_state = state;
		Datacenters = new DatacenterCommands(state);
		Debugger = new DebuggerCommands(state);
		Gnorman = new GnormanCommands(state);
		Operations = new OperationCommands(state);
		Research = new ResearchCommands(state);
		Resource = new ResourceCommands(state);
		Sequel = new SequelCommands(state);
		History = new HistoryCommands(state);
		Upgrades = new UpgradeCommands(state);
		Achievements = new AchievementCommands(state);
		IRC = new IRCCommands(state);
		Auction = new AuctionCommands(state);
	}

	public void Dispose()
	{
		Achievements.Dispose();
	}

	public void AdvanceTime(float deltaTime)
	{
		if (!(deltaTime <= 0f))
		{
			_state.Studio.Time.AddValue(deltaTime);
			if (_state.Game.Launched.Value)
			{
				_state.Game.Time.AddValue(deltaTime);
			}
		}
	}

	public void LaunchGame()
	{
		_state.Game.Launched.Value = true;
		if (MonoSingleton<UI>.HasInstance && _state.Operations.Instances.TryGetValue(Operation.ReleaseGame, out var value))
		{
			foreach (OperationInstance item in value)
			{
				UI.Registry.footer.operations.ClearOperationProgress(item);
			}
		}
		_state.Operations.Instances.Remove(Operation.ReleaseGame);
		_state.Operations.Activations.Remove(Operation.ReleaseGame);
		EventHub.Scene.Publish(new OperationFinished(Operation.ReleaseGame));
		EventHub.Scene.Publish(new OperationLocked(Operation.ReleaseGame));
		MonoSingleton<TooltipVisualizer>.Instance.Hide();
		Database.Commands.IRC.Print(IRCSystem.GameLaunched);
	}
}
