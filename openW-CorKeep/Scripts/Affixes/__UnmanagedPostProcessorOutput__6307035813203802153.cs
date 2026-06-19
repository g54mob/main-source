using Affixes.Systems;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__6307035813203802153
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(AffixSystem), BurstRuntime.GetHashCode64<AffixSystem>(), AffixSystem.__codegen__OnCreate, AffixSystem.__codegen__OnUpdate, null, AffixSystem.__codegen__OnStartRunning, AffixSystem.__codegen__OnStopRunning, AffixSystem.__codegen__OnCreateForCompiler, "Affixes.Systems.AffixSystem", 3);
	}
}
