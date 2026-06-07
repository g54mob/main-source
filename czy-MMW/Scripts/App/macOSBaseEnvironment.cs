using System.Collections.Generic;
using Factory;
using Factory.Allocators;
using NotificationService;
using NotificationService.Persistence;
using Notifications;
using Notifications.Services;
using UnityEngine;

public abstract class macOSBaseEnvironment : IEnvironment
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
		baseAssembler.Register<IReachability, AppleReachability>().Allocator(new HeapAllocator<AppleReachability>()).Binding(Binding.Scope);
		baseAssembler.Register<ISystemNotificationService, NullSystemNotificationService>().Allocator(new HeapAllocator<NullSystemNotificationService>()).Binding(Binding.Scope);
		baseAssembler.Register<INotificationEventSystem, NullNotificationEventSystem>().Allocator(new HeapAllocator<NullNotificationEventSystem>()).Binding(Binding.Scope);
		baseAssembler.Register<INotificationEventPersistence, NullNotificationEventPersistence>().Allocator(new HeapAllocator<NullNotificationEventPersistence>()).Binding(Binding.Scope);
		baseAssembler.Register<INotificationScheduleDebugger, NullNotificationScheduleDebugger>().Allocator(new HeapAllocator<NullNotificationScheduleDebugger>()).Binding(Binding.Scope);
		baseAssembler.Register<IFileSystem, DefaultFileSystem>().Allocator(new HeapAllocator<DefaultFileSystem>()).Binding(Binding.Scope);
	}

	public virtual void PopulateGameAssembler(Assembler baseAssembler)
	{
	}
}
