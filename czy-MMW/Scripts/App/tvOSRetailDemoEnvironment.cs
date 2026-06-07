using System.Collections.Generic;
using Factory;
using Factory.Allocators;
using Helpers.GameCenter;
using Motorways.Leaderboards;
using Motorways.Leaderboards.Backends;
using NotificationService;
using NotificationService.Persistence;
using Notifications;
using Notifications.Services;
using UnityEngine;

public class tvOSRetailDemoEnvironment : IEnvironment
{
	public DeviceCategory DeviceCategory => DeviceCategory.Console;

	public List<string> FeatureConfigs => new List<string> { "ArcadeConfig", "DemoConfig" };

	public BaseInputOverride AddInputOverrideToGameObject(GameObject gameObject)
	{
		return gameObject.AddComponent<DisableUITouchInputOverride>();
	}

	public void PopulateAppAssembler(Assembler baseAssembler)
	{
		baseAssembler.Register<IGameCenterAuthentication, NullGameCenterAuthentication>().Allocator(new HeapAllocator<NullGameCenterAuthentication>()).Binding(Binding.Scope);
		baseAssembler.Register<IGameCenterAccessPoint, NullGameCenterAccessPoint>().Allocator(new HeapAllocator<NullGameCenterAccessPoint>()).Binding(Binding.Scope);
		baseAssembler.Register<IAchievementHandler, NullAchievementHandler>().Allocator(new HeapAllocator<NullAchievementHandler>()).Binding(Binding.Scope);
		baseAssembler.Register<ILeaderboardBackend, RetailDemoLeaderboardBackend>().Allocator(new HeapAllocator<RetailDemoLeaderboardBackend>()).Binding(Binding.Scope);
		baseAssembler.Register<IHistogramBackend, MockHistogramBackend>().Allocator(new HeapAllocator<MockHistogramBackend>()).Binding(Binding.Scope);
		baseAssembler.Register<IContentProfile, DemoContentProfile>().Allocator(new HeapAllocator<DemoContentProfile>()).Binding(Binding.Scope);
		baseAssembler.Register<IHardwareCapabilities, tvOSHardwareCapabilities>().Allocator(new HeapAllocator<tvOSHardwareCapabilities>()).Binding(Binding.Scope);
		baseAssembler.Register<IReachability, NullReachability>().Allocator(new HeapAllocator<NullReachability>()).Binding(Binding.Scope);
		baseAssembler.Register<IPersistentStorageProvider, NullStorage>().Allocator(new HeapAllocator<NullStorage>()).Binding(Binding.Scope);
		baseAssembler.Register<ISoftwareCapabilities, tvOSDemoSoftwareCapabilities>().Allocator(new HeapAllocator<tvOSDemoSoftwareCapabilities>()).Binding(Binding.Scope);
		baseAssembler.Register<IControllerButtonToSymbolService, AppleSfSymbolService>().Allocator(new HeapAllocator<AppleSfSymbolService>()).Binding(Binding.Scope);
		baseAssembler.Register<ISystemNotificationService, NullSystemNotificationService>().Allocator(new HeapAllocator<NullSystemNotificationService>()).Binding(Binding.Scope);
		baseAssembler.Register<INotificationEventSystem, NullNotificationEventSystem>().Allocator(new HeapAllocator<NullNotificationEventSystem>()).Binding(Binding.Scope);
		baseAssembler.Register<INotificationEventPersistence, NullNotificationEventPersistence>().Allocator(new HeapAllocator<NullNotificationEventPersistence>()).Binding(Binding.Scope);
		baseAssembler.Register<INotificationScheduleDebugger, NullNotificationScheduleDebugger>().Allocator(new HeapAllocator<NullNotificationScheduleDebugger>()).Binding(Binding.Scope);
		baseAssembler.Register<IFileSystem, DefaultFileSystem>().Allocator(new HeapAllocator<DefaultFileSystem>()).Binding(Binding.Scope);
	}

	public void PopulateGameAssembler(Assembler baseAssembler)
	{
	}
}
