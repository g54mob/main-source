using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__2909992204487601742
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(FireSpreadingSystem), BurstRuntime.GetHashCode64<FireSpreadingSystem>(), FireSpreadingSystem.__codegen__OnCreate, FireSpreadingSystem.__codegen__OnUpdate, FireSpreadingSystem.__codegen__OnDestroy, FireSpreadingSystem.__codegen__OnStartRunning, FireSpreadingSystem.__codegen__OnStopRunning, FireSpreadingSystem.__codegen__OnCreateForCompiler, "FireSpreadingSystem", 15);
	}
}
