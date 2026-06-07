using System.Collections.Generic;
using Factory;
using Factory.Allocators;
using Helpers.GameCenter;
using Motorways.Leaderboards;
using Motorways.Leaderboards.Backends;
using NotificationService.Persistence;
using Notifications;
using Notifications.Services;
using UnityEngine;

public class iOSAppStoreEnvironment : IEnvironment
{
	public DeviceCategory DeviceCategory
	{
		get
		{
			if (!SystemInfo.deviceModel.StartsWith("iPad"))
			{
				return DeviceCategory.Phone;
			}
			return DeviceCategory.Tablet;
		}
	}

	public List<string> FeatureConfigs => new List<string> { "ArcadeConfig" };

	public BaseInputOverride AddInputOverrideToGameObject(GameObject gameObject)
	{
		return gameObject.AddComponent<BaseInputOverride>();
	}

	public void PopulateAppAssembler(Assembler baseAssembler)
	{
		baseAssembler.Register<IGameCenterAuthentication, GameCenterAuthentication>().Allocator(new HeapAllocator<GameCenterAuthentication>()).Binding(Binding.Scope);
		baseAssembler.Register<IGameCenterAccessPoint, GameCenterAccessPoint>().Allocator(new HeapAllocator<GameCenterAccessPoint>()).Binding(Binding.Scope);
		baseAssembler.Register<IAchievementHandler, GameCenterAchievementHandler>().Allocator(new HeapAllocator<GameCenterAchievementHandler>()).Binding(Binding.Scope);
		baseAssembler.Register<ILeaderboardBackend, GameCenterLeaderboardBackend>().Allocator(new HeapAllocator<GameCenterLeaderboardBackend>()).Binding(Binding.Scope);
		baseAssembler.Register<IHistogramBackend, GameCenterHistogramBackend>().Allocator(new HeapAllocator<GameCenterHistogramBackend>()).Binding(Binding.Scope);
		baseAssembler.Register<iCloudKernel>().Allocator(new SingletonAllocator<iCloudKernel>(iCloudKernel.Instance)).Binding(Binding.Scope);
		baseAssembler.Register<IiCloudCache, iCloudFileCache>().Allocator(new HeapAllocator<iCloudFileCache>()).Binding(Binding.Scope);
		baseAssembler.Register<IPersistentStorageProvider, iCloudStorage>().Allocator(new HeapAllocator<iCloudStorage>()).Binding(Binding.Scope);
		baseAssembler.Register<IContentProfile, RetailContentProfile>().Allocator(new HeapAllocator<RetailContentProfile>()).Binding(Binding.Scope);
		baseAssembler.Register<IHardwareCapabilities, iOSHardwareCapabilities>().Allocator(new HeapAllocator<iOSHardwareCapabilities>()).Binding(Binding.Scope);
		baseAssembler.Register<IReachability, AppleReachability>().Allocator(new HeapAllocator<AppleReachability>()).Binding(Binding.Scope);
		baseAssembler.Register<ISoftwareCapabilities, iOSSoftwareCapabilities>().Allocator(new HeapAllocator<iOSSoftwareCapabilities>()).Binding(Binding.Scope);
		baseAssembler.Register<IControllerButtonToSymbolService, AppleSfSymbolService>().Allocator(new HeapAllocator<AppleSfSymbolService>()).Binding(Binding.Scope);
		baseAssembler.Register<ISystemNotificationService, iOSSystemNotificationService>().Allocator(new HeapAllocator<iOSSystemNotificationService>()).Binding(Binding.Scope);
		baseAssembler.Register<INotificationEventSystem, NotificationEventSystem>().Allocator(new HeapAllocator<NotificationEventSystem>()).Binding(Binding.Scope);
		baseAssembler.Register<INotificationEventPersistence, ActivePlayerNotificationEventPersistence>().Allocator(new HeapAllocator<ActivePlayerNotificationEventPersistence>()).Binding(Binding.Scope);
		baseAssembler.Register<INotificationScheduleDebugger, NullNotificationScheduleDebugger>().Allocator(new HeapAllocator<NullNotificationScheduleDebugger>()).Binding(Binding.Scope);
		baseAssembler.Register<IFileSystem, DefaultFileSystem>().Allocator(new HeapAllocator<DefaultFileSystem>()).Binding(Binding.Scope);
	}

	public void PopulateGameAssembler(Assembler baseAssembler)
	{
	}
}
