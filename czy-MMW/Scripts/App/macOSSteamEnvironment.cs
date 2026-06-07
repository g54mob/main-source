using System.Collections.Generic;
using Factory;
using Factory.Allocators;
using Helpers.GameCenter;
using Motorways.Leaderboards;
using Motorways.Leaderboards.Backends;
using SoftwareCapabilities;

public class macOSSteamEnvironment : macOSBaseEnvironment
{
	public override List<string> FeatureConfigs => new List<string> { "SteamConfig" };

	public override void PopulateAppAssembler(Assembler baseAssembler)
	{
		base.PopulateAppAssembler(baseAssembler);
		baseAssembler.Register<IGameCenterAuthentication, NullGameCenterAuthentication>().Allocator(new HeapAllocator<NullGameCenterAuthentication>()).Binding(Binding.Scope);
		baseAssembler.Register<IControllerButtonToSymbolService, DefaultControllerButtonToSymbolService>().Allocator(new HeapAllocator<DefaultControllerButtonToSymbolService>()).Binding(Binding.Scope);
		baseAssembler.Register<IGameCenterAccessPoint, NullGameCenterAccessPoint>().Allocator(new HeapAllocator<NullGameCenterAccessPoint>()).Binding(Binding.Scope);
		baseAssembler.Register<IAchievementHandler, SteamworksAchievementHandler>().Allocator(new HeapAllocator<SteamworksAchievementHandler>()).Binding(Binding.Scope);
		baseAssembler.Register<ILeaderboardBackend, SteamworksLeaderboardBackend>().Allocator(new HeapAllocator<SteamworksLeaderboardBackend>()).Binding(Binding.Scope);
		baseAssembler.Register<IHistogramBackend, SteamHistogramBackend>().Allocator(new HeapAllocator<SteamHistogramBackend>()).Binding(Binding.Scope);
		baseAssembler.Register<IContentProfile, RetailContentProfile>().Allocator(new HeapAllocator<RetailContentProfile>()).Binding(Binding.Scope);
		baseAssembler.Register<IPersistentStorageProvider, SteamCloud>().Allocator(new HeapAllocator<SteamCloud>()).Binding(Binding.Scope);
		baseAssembler.Register<ISoftwareCapabilities, SteamSoftwareCapabilities>().Allocator(new HeapAllocator<SteamSoftwareCapabilities>()).Binding(Binding.Scope);
	}
}
