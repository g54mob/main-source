using SiphonMana;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__7505066402646741631
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(SiphonManaSystem), BurstRuntime.GetHashCode64<SiphonManaSystem>(), SiphonManaSystem.__codegen__OnCreate, SiphonManaSystem.__codegen__OnUpdate, null, SiphonManaSystem.__codegen__OnStartRunning, SiphonManaSystem.__codegen__OnStopRunning, SiphonManaSystem.__codegen__OnCreateForCompiler, "SiphonMana.SiphonManaSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(SiphonManaVisualSystem), BurstRuntime.GetHashCode64<SiphonManaVisualSystem>(), null, SiphonManaVisualSystem.__codegen__OnUpdate, null, null, null, SiphonManaVisualSystem.__codegen__OnCreateForCompiler, "SiphonMana.SiphonManaVisualSystem", 0);
	}
}
