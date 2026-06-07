using System.Collections.Generic;
using Factory;
using Factory.Allocators;
using Helpers.GameCenter;
using Motorways.Leaderboards;
using Motorways.Leaderboards.Backends;

public class macOSAppStoreEnvironment : macOSBaseEnvironment
{
	public override List<string> FeatureConfigs => new List<string> { "ArcadeConfig" };

	public override void PopulateAppAssembler(Assembler baseAssembler)
	{
		base.PopulateAppAssembler(baseAssembler);
		baseAssembler.Register<IGameCenterAuthentication, GameCenterAuthentication>().Allocator(new HeapAllocator<GameCenterAuthentication>()).Binding(Binding.Scope);
		baseAssembler.Register<IControllerButtonToSymbolService, AppleSfSymbolService>().Allocator(new HeapAllocator<AppleSfSymbolService>()).Binding(Binding.Scope);
		baseAssembler.Register<IGameCenterAccessPoint, GameCenterAccessPoint>().Allocator(new HeapAllocator<GameCenterAccessPoint>()).Binding(Binding.Scope);
		baseAssembler.Register<IAchievementHandler, GameCenterAchievementHandler>().Allocator(new HeapAllocator<GameCenterAchievementHandler>()).Binding(Binding.Scope);
		baseAssembler.Register<ILeaderboardBackend, GameCenterLeaderboardBackend>().Allocator(new HeapAllocator<GameCenterLeaderboardBackend>()).Binding(Binding.Scope);
		baseAssembler.Register<IHistogramBackend, GameCenterHistogramBackend>().Allocator(new HeapAllocator<GameCenterHistogramBackend>()).Binding(Binding.Scope);
		baseAssembler.Register<IContentProfile, RetailContentProfile>().Allocator(new HeapAllocator<RetailContentProfile>()).Binding(Binding.Scope);
		baseAssembler.Register<iCloudKernel>().Allocator(new SingletonAllocator<iCloudKernel>(iCloudKernel.Instance)).Binding(Binding.Scope);
		baseAssembler.Register<IiCloudCache, iCloudFileCache>().Allocator(new HeapAllocator<iCloudFileCache>()).Binding(Binding.Scope);
		baseAssembler.Register<IPersistentStorageProvider, iCloudStorage>().Allocator(new HeapAllocator<iCloudStorage>()).Binding(Binding.Scope);
		baseAssembler.Register<ISoftwareCapabilities, MacAppStoreSoftwareCapabilities>().Allocator(new HeapAllocator<MacAppStoreSoftwareCapabilities>()).Binding(Binding.Scope);
	}
}
