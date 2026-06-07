using System;
using System.Collections.Generic;
using ObservableCollections;
using R3;
using ZLinq;

public class DatabaseDerived : IDisposable
{
	private DisposableBag _disposableBag;

	public readonly ReadOnlyReactiveProperty<double> PlayersCapacity;

	public readonly ReadOnlyReactiveProperty<double> MarketCapacity;

	public readonly ReadOnlyReactiveProperty<double> HistoryRevenue;

	public readonly ReadOnlyReactiveProperty<double> DataCapacity;

	public readonly ReadOnlyReactiveProperty<double> DataCapacityCost;

	public readonly ReadOnlyReactiveProperty<float> BugSoftCapacity;

	public readonly ReadOnlyReactiveProperty<float> BugHardCapacity;

	public readonly ReadOnlyReactiveProperty<double> DatacenterCapacity;

	public readonly ReadOnlyReactiveProperty<int> TotalEngineers;

	public DatabaseDerived(DatabaseState state, DatabaseModifiers modifiers)
	{
		PlayersCapacity = ObservePlayersCapacity(state, modifiers, ref _disposableBag);
		MarketCapacity = ObserveMarketCapacity(state, modifiers, ref _disposableBag);
		HistoryRevenue = ObserveHistoryRevenue(state, modifiers, ref _disposableBag);
		DataCapacity = ObserveDataCapacity(state, modifiers, ref _disposableBag);
		DataCapacityCost = ObserveDataCapacityCost(state, modifiers, ref _disposableBag);
		BugSoftCapacity = ObserveBugSoftCapacity(state, modifiers, ref _disposableBag);
		BugHardCapacity = ObserveBugHardCapacity(state, modifiers, ref _disposableBag);
		DatacenterCapacity = ObserveDatacenterCapacity(state, modifiers, ref _disposableBag);
		TotalEngineers = ObserveTotalEngineers(state, modifiers, ref _disposableBag);
	}

	public void Dispose()
	{
		_disposableBag.Dispose();
	}

	private ReadOnlyReactiveProperty<double> ObservePlayersCapacity(DatabaseState state, DatabaseModifiers modifiers, ref DisposableBag bag)
	{
		return state.Resources.Nodes.Prepend(state.Resources.Nodes.CurrentValue).CombineLatest(modifiers.Observe(ModifierType.NodeCapacity), modifiers.Observe(ModifierType.NodeCapacityScaling), (int nodes, double nodeCap, double scaling) => (double)nodes * nodeCap * (1.0 + scaling * Math.Pow(nodes, 0.5))).ToReadOnlyReactiveProperty(0.0)
			.AddTo(ref bag);
	}

	private ReadOnlyReactiveProperty<double> ObserveMarketCapacity(DatabaseState state, DatabaseModifiers modifiers, ref DisposableBag bag)
	{
		ReadOnlyReactiveProperty<int> source = state.Datacenters.Details.ObserveCountChanged().ToReadOnlyReactiveProperty(state.Datacenters.Details.Count).AddTo(ref bag);
		return state.Metrics.Releases.Prepend(state.Metrics.Releases.CurrentValue).CombineLatest(source, modifiers.Observe(ModifierType.MarketCapacity), modifiers.Observe(ModifierType.MarketCapacitySequelModifier), modifiers.Observe(ModifierType.MarketCapacityDatacenter), modifiers.Observe(ModifierType.MarketCapacityScaling), (int releases, int dcCount, double marketBase, double sequelMod, double dcMod, double dcScaling) => marketBase * ((double)releases * sequelMod * (1.0 + dcScaling * Math.Pow(releases, 0.75))) + (double)dcCount * dcMod * (1.0 + dcScaling * Math.Pow(dcCount, 0.75))).ToReadOnlyReactiveProperty(0.0)
			.AddTo(ref bag);
	}

	private ReadOnlyReactiveProperty<double> ObserveHistoryRevenue(DatabaseState state, DatabaseModifiers modifiers, ref DisposableBag bag)
	{
		return state.History.Releases.ObserveCountChanged().Prepend(state.History.Releases.Count).Select(state.History.Releases, (int _, ObservableList<HistoryEntryData> list) => list.AsValueEnumerable().Sum((HistoryEntryData x) => x.Money))
			.ToReadOnlyReactiveProperty(0.0)
			.AddTo(ref bag);
	}

	private ReadOnlyReactiveProperty<double> ObserveDataCapacity(DatabaseState state, DatabaseModifiers modifiers, ref DisposableBag bag)
	{
		return state.Research.DataNodes.Prepend(state.Research.DataNodes.Value).CombineLatest(modifiers.Observe(ModifierType.DataCapacity), (int dataNodes, double cap) => (double)dataNodes * cap).ToReadOnlyReactiveProperty(0.0)
			.AddTo(ref bag);
	}

	private ReadOnlyReactiveProperty<double> ObserveDataCapacityCost(DatabaseState state, DatabaseModifiers modifiers, ref DisposableBag bag)
	{
		return (from cap in DataCapacity.Prepend(DataCapacity.CurrentValue)
			select Math.Round(cap * 0.8)).ToReadOnlyReactiveProperty(0.0).AddTo(ref bag);
	}

	private ReadOnlyReactiveProperty<float> ObserveBugSoftCapacity(DatabaseState state, DatabaseModifiers modifiers, ref DisposableBag bag)
	{
		return state.Resources.Players.Prepend(state.Resources.Players.Value).CombineLatest(modifiers.Observe(ModifierType.BugsSoftCapBase), modifiers.Observe(ModifierType.BugsSoftCapScaling), (double players, double baseCap, double scaling) => (float)(baseCap + Math.Log10(Math.Max(1.0, players)) * scaling)).ToReadOnlyReactiveProperty(0f)
			.AddTo(ref bag);
	}

	private ReadOnlyReactiveProperty<float> ObserveBugHardCapacity(DatabaseState state, DatabaseModifiers modifiers, ref DisposableBag bag)
	{
		return BugSoftCapacity.Prepend(BugSoftCapacity.CurrentValue).CombineLatest(modifiers.Observe(ModifierType.BugsHardCapModifier), (float soft, double hardMod) => (float)((double)soft * hardMod)).ToReadOnlyReactiveProperty(0f)
			.AddTo(ref bag);
	}

	private ReadOnlyReactiveProperty<double> ObserveDatacenterCapacity(DatabaseState state, DatabaseModifiers modifiers, ref DisposableBag bag)
	{
		return state.Datacenters.StateChanged.AsObservable().Prepend(Datacenter.None).CombineLatest(state.Metrics.Releases, modifiers.Observe(ModifierType.PingDatacenterCapacity), modifiers.Observe(ModifierType.PingDegradedModifier), modifiers.Observe(ModifierType.PingCriticalModifier), delegate(Datacenter _, int _, double nominal, double degradedMod, double criticalMod)
		{
			double num = nominal * degradedMod;
			double num2 = nominal * criticalMod;
			double num3 = nominal * 0.25;
			foreach (KeyValuePair<Datacenter, DatacenterDetails> detail in Database.State.Datacenters.Details)
			{
				double num4 = num3;
				num3 = num4 + detail.Value.State.Value switch
				{
					DatacenterState.Nominal => nominal, 
					DatacenterState.Degraded => num, 
					DatacenterState.Critical => num2, 
					_ => 0.0, 
				};
			}
			return num3;
		})
			.ToReadOnlyReactiveProperty(0.0)
			.AddTo(ref bag);
	}

	private ReadOnlyReactiveProperty<int> ObserveTotalEngineers(DatabaseState state, DatabaseModifiers modifiers, ref DisposableBag bag)
	{
		return state.Datacenters.HireChanged.Prepend(Datacenter.None).Select(state.Datacenters.Details, (Datacenter _, ObservableDictionary<Datacenter, DatacenterDetails> list) => list.AsValueEnumerable().Sum((KeyValuePair<Datacenter, DatacenterDetails> x) => x.Value.Engineers.Value)).ToReadOnlyReactiveProperty(0)
			.AddTo(ref bag);
	}
}
