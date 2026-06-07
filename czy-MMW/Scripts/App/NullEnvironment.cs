using System.Collections.Generic;
using Factory;
using Factory.Allocators;
using Helpers.GameCenter;
using Motorways.Leaderboards;
using Motorways.Leaderboards.Backends;
using UnityEngine;

public class NullEnvironment : IEnvironment
{
	public DeviceCategory DeviceCategory => DeviceCategory.Desktop;

	public List<string> FeatureConfigs => null;

	public BaseInputOverride AddInputOverrideToGameObject(GameObject gameObject)
	{
		return gameObject.AddComponent<BaseInputOverride>();
	}

	public virtual void PopulateAppAssembler(Assembler baseAssembler)
	{
		baseAssembler.Register<IGameCenterAuthentication, NullGameCenterAuthentication>().Allocator(new HeapAllocator<NullGameCenterAuthentication>()).Binding(Binding.Scope);
		baseAssembler.Register<IGameCenterAccessPoint, NullGameCenterAccessPoint>().Allocator(new HeapAllocator<NullGameCenterAccessPoint>()).Binding(Binding.Scope);
		baseAssembler.Register<IAchievementHandler, NullAchievementHandler>().Allocator(new HeapAllocator<NullAchievementHandler>()).Binding(Binding.Scope);
		baseAssembler.Register<ILeaderboardBackend, NullLeaderboardBackend>().Allocator(new HeapAllocator<NullLeaderboardBackend>()).Binding(Binding.Scope);
		baseAssembler.Register<IHistogramBackend, NullHistogramBackend>().Allocator(new HeapAllocator<NullHistogramBackend>()).Binding(Binding.Scope);
		baseAssembler.Register<IPersistentStorageProvider, NullStorage>().Allocator(new HeapAllocator<NullStorage>()).Binding(Binding.Scope);
		baseAssembler.Register<IAchievementHandler, NullAchievementHandler>().Allocator(new HeapAllocator<NullAchievementHandler>()).Binding(Binding.Scope);
		baseAssembler.Register<IContentProfile, NullContentProfile>().Allocator(new HeapAllocator<NullContentProfile>()).Binding(Binding.Scope);
		baseAssembler.Register<IHardwareCapabilities, NullHardwareCapabilities>().Allocator(new HeapAllocator<NullHardwareCapabilities>()).Binding(Binding.Scope);
		baseAssembler.Register<IReachability, NullReachability>().Allocator(new HeapAllocator<NullReachability>()).Binding(Binding.Scope);
		baseAssembler.Register<ISoftwareCapabilities, NullSoftwareCapabilities>().Allocator(new HeapAllocator<NullSoftwareCapabilities>()).Binding(Binding.Scope);
	}

	public virtual void PopulateGameAssembler(Assembler baseAssembler)
	{
	}
}
