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

public abstract class WindowsBaseEnvironment : IEnvironment
{
	public DeviceCategory DeviceCategory => DeviceCategory.Desktop;

	public virtual List<string> FeatureConfigs => null;

	public BaseInputOverride AddInputOverrideToGameObject(GameObject gameObject)
	{
		return gameObject.AddComponent<BaseInputOverride>();
	}

	public virtual void PopulateAppAssembler(Assembler baseAssembler)
	{
		baseAssembler.Register<IHardwareCapabilities, DesktopHardwareCapabilities>().Allocator(new HeapAllocator<DesktopHardwareCapabilities>()).Binding(Binding.Scope);
		baseAssembler.Register<IPersistentStorageProvider, LocalFileStorage>().Allocator(new HeapAllocator<LocalFileStorage>()).Binding(Binding.Scope);
		baseAssembler.Register<IReachability, NullReachability>().Allocator(new HeapAllocator<NullReachability>()).Binding(Binding.Scope);
		baseAssembler.Register<IGameCenterAuthentication, NullGameCenterAuthentication>().Allocator(new HeapAllocator<NullGameCenterAuthentication>()).Binding(Binding.Scope);
		baseAssembler.Register<IGameCenterAccessPoint, NullGameCenterAccessPoint>().Allocator(new HeapAllocator<NullGameCenterAccessPoint>()).Binding(Binding.Scope);
		baseAssembler.Register<IAchievementHandler, NullAchievementHandler>().Allocator(new HeapAllocator<NullAchievementHandler>()).Binding(Binding.Scope);
		baseAssembler.Register<ILeaderboardBackend, TestLeaderboardBackend>().Allocator(new HeapAllocator<TestLeaderboardBackend>()).Binding(Binding.Scope);
		baseAssembler.Register<IHistogramBackend, SteamHistogramBackend>().Allocator(new HeapAllocator<SteamHistogramBackend>()).Binding(Binding.Scope);
		baseAssembler.Register<IControllerButtonToSymbolService, DefaultControllerButtonToSymbolService>().Allocator(new HeapAllocator<DefaultControllerButtonToSymbolService>()).Binding(Binding.Scope);
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
