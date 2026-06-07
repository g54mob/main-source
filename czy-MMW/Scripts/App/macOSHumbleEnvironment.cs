using Factory;
using Factory.Allocators;
using Helpers.GameCenter;
using Motorways.Leaderboards;
using Motorways.Leaderboards.Backends;

public class macOSHumbleEnvironment : macOSBaseEnvironment
{
	public override void PopulateAppAssembler(Assembler baseAssembler)
	{
		base.PopulateAppAssembler(baseAssembler);
		baseAssembler.Register<IGameCenterAuthentication, NullGameCenterAuthentication>().Allocator(new HeapAllocator<NullGameCenterAuthentication>()).Binding(Binding.Scope);
		baseAssembler.Register<IControllerButtonToSymbolService, DefaultControllerButtonToSymbolService>().Allocator(new HeapAllocator<DefaultControllerButtonToSymbolService>()).Binding(Binding.Scope);
		baseAssembler.Register<IGameCenterAccessPoint, NullGameCenterAccessPoint>().Allocator(new HeapAllocator<NullGameCenterAccessPoint>()).Binding(Binding.Scope);
		baseAssembler.Register<IAchievementHandler, NullAchievementHandler>().Allocator(new HeapAllocator<NullAchievementHandler>()).Binding(Binding.Scope);
		baseAssembler.Register<ILeaderboardBackend, TestLeaderboardBackend>().Allocator(new HeapAllocator<TestLeaderboardBackend>()).Binding(Binding.Scope);
		baseAssembler.Register<IHistogramBackend, SteamHistogramBackend>().Allocator(new HeapAllocator<SteamHistogramBackend>()).Binding(Binding.Scope);
		baseAssembler.Register<IContentProfile, RetailContentProfile>().Allocator(new HeapAllocator<RetailContentProfile>()).Binding(Binding.Scope);
		baseAssembler.Register<IPersistentStorageProvider, LocalFileStorage>().Allocator(new HeapAllocator<LocalFileStorage>()).Binding(Binding.Scope);
		baseAssembler.Register<ISoftwareCapabilities, NullSoftwareCapabilities>().Allocator(new HeapAllocator<NullSoftwareCapabilities>()).Binding(Binding.Scope);
	}
}
