using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__15129982454832738418
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(RandomWalkStateSystem), BurstRuntime.GetHashCode64<RandomWalkStateSystem>(), null, RandomWalkStateSystem.__codegen__OnUpdate, null, RandomWalkStateSystem.__codegen__OnStartRunning, RandomWalkStateSystem.__codegen__OnStopRunning, RandomWalkStateSystem.__codegen__OnCreateForCompiler, "RandomWalkStateSystem", 2);
	}
}
