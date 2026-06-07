using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;

public static class CatalogProvider
{
	public static readonly UpgradeCatalog Upgrades = new UpgradeCatalog("Upgrades");

	public static readonly ResearchCatalog Research = new ResearchCatalog("Research");

	public static readonly OperationCatalog Operations = new OperationCatalog("Operations");

	public static readonly DatacenterCatalog Datacenters = new DatacenterCatalog("Datacenters");

	public static readonly GnormanCatalog Gnorman = new GnormanCatalog("Gnorman");

	public static readonly AchievementCatalog Achievements = new AchievementCatalog("Achievements");

	private static IDisposable _disposable;

	public static async UniTaskVoid Initialize()
	{
		_disposable?.Dispose();
		await UniTask.WhenAll(Upgrades.InitializeAsync(), Research.InitializeAsync(), Operations.InitializeAsync(), Datacenters.InitializeAsync(), Gnorman.InitializeAsync(), Achievements.InitializeAsync());
		_disposable = Disposable.Combine(Upgrades, Research, Operations, Datacenters, Gnorman, Achievements);
		Debug.Log("Catalogs initialized:\n" + $"Upgrades [{Upgrades.Count}]\n" + $"Research [{Research.Count}]\n" + $"Operations [{Operations.Count}]\n" + $"Datacenters [{Datacenters.Count}]\n" + $"Gnorman [{Gnorman.Count}]\n" + $"Achievements [{Achievements.Count}]");
	}

	public static void Dispose()
	{
		_disposable?.Dispose();
	}

	public static void ValidateCatalogs()
	{
		Upgrades.Validate();
		Research.Validate();
		Operations.Validate();
		Datacenters.Validate();
		Gnorman.Validate();
		Achievements.Validate();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static UpgradeNodeData Data(this UpgradeNode value)
	{
		return Upgrades.Get(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryGetData(this UpgradeNode value, out UpgradeNodeData data)
	{
		return Upgrades.TryGet(value, out data);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ResearchNodeData Data(this ResearchNode value)
	{
		return Research.Get(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryGetData(this ResearchNode value, out ResearchNodeData data)
	{
		return Research.TryGet(value, out data);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static OperationData Data(this Operation value)
	{
		return Operations.Get(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryGetData(this Operation value, out OperationData data)
	{
		return Operations.TryGet(value, out data);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static DatacenterData Data(this Datacenter value)
	{
		return Datacenters.Get(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryGetData(this Datacenter value, out DatacenterData data)
	{
		return Datacenters.TryGet(value, out data);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static GnormanActionData Data(this GnormanAction value)
	{
		return Gnorman.Get(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryGetData(this GnormanAction value, out GnormanActionData data)
	{
		return Gnorman.TryGet(value, out data);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static AchievementData Data(this Achievement value)
	{
		return Achievements.Get(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryGetData(this Achievement value, out AchievementData data)
	{
		return Achievements.TryGet(value, out data);
	}
}
