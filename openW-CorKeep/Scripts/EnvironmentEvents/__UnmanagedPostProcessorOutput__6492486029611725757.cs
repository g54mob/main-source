using EnvironmentEvents;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__6492486029611725757
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(EnvironmentEventSystem), BurstRuntime.GetHashCode64<EnvironmentEventSystem>(), EnvironmentEventSystem.__codegen__OnCreate, EnvironmentEventSystem.__codegen__OnUpdate, EnvironmentEventSystem.__codegen__OnDestroy, EnvironmentEventSystem.__codegen__OnStartRunning, EnvironmentEventSystem.__codegen__OnStopRunning, EnvironmentEventSystem.__codegen__OnCreateForCompiler, "EnvironmentEventSystem", 30);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(TriggerEnvironmentEventOnDeathSystem), BurstRuntime.GetHashCode64<TriggerEnvironmentEventOnDeathSystem>(), TriggerEnvironmentEventOnDeathSystem.__codegen__OnCreate, TriggerEnvironmentEventOnDeathSystem.__codegen__OnUpdate, null, null, null, TriggerEnvironmentEventOnDeathSystem.__codegen__OnCreateForCompiler, "EnvironmentEvents.TriggerEnvironmentEventOnDeathSystem", 3);
	}
}
