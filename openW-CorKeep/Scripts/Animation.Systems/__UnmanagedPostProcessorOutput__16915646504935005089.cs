using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__16915646504935005089
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(LocalAnimationSystem), BurstRuntime.GetHashCode64<LocalAnimationSystem>(), LocalAnimationSystem.__codegen__OnCreate, LocalAnimationSystem.__codegen__OnUpdate, null, null, null, LocalAnimationSystem.__codegen__OnCreateForCompiler, "LocalAnimationSystem", 3);
	}
}
