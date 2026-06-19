using System.Runtime.InteropServices;
using EnvironmentEvents.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public static class EnvironmentEventBase
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate bool ShouldActivateEvent(in Entity playerEntity, in int2 playerTilePos, ref Random rnd, in NativeList<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.ComponentLookups componentLookups);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void InitEvent(in Entity playerEntity, in int2 playerTilePos, ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeList<int2> eventPositions, ref Random rnd, in NativeArray<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ExecuteEvent(ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeParallelHashSet<int2> spawnPositions, in NativeList<int2> eventPositions, ref Random rnd, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups);
}
