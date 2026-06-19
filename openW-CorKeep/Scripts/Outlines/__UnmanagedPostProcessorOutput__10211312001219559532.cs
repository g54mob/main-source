using Outlines.Systems;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__10211312001219559532
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(VisualOutlineDisplaySystem), BurstRuntime.GetHashCode64<VisualOutlineDisplaySystem>(), null, VisualOutlineDisplaySystem.__codegen__OnUpdate, null, null, null, VisualOutlineDisplaySystem.__codegen__OnCreateForCompiler, "Outlines.Systems.VisualOutlineDisplaySystem", 0);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(VisualOutlineSelectSystem), BurstRuntime.GetHashCode64<VisualOutlineSelectSystem>(), VisualOutlineSelectSystem.__codegen__OnCreate, VisualOutlineSelectSystem.__codegen__OnUpdate, null, null, null, VisualOutlineSelectSystem.__codegen__OnCreateForCompiler, "Outlines.Systems.VisualOutlineSelectSystem", 3);
	}
}
