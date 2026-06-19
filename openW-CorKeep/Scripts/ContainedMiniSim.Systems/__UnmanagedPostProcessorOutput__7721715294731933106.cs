using ContainedMiniSim;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__7721715294731933106
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(AquariumFishMovementSystem), BurstRuntime.GetHashCode64<AquariumFishMovementSystem>(), null, AquariumFishMovementSystem.__codegen__OnUpdate, null, null, null, AquariumFishMovementSystem.__codegen__OnCreateForCompiler, "ContainedMiniSim.AquariumFishMovementSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(CacheContainedMiniSimVisualDataSystem), BurstRuntime.GetHashCode64<CacheContainedMiniSimVisualDataSystem>(), null, CacheContainedMiniSimVisualDataSystem.__codegen__OnUpdate, null, null, null, CacheContainedMiniSimVisualDataSystem.__codegen__OnCreateForCompiler, "ContainedMiniSim.CacheContainedMiniSimVisualDataSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(ContainedMiniSimInitializeSystem), BurstRuntime.GetHashCode64<ContainedMiniSimInitializeSystem>(), ContainedMiniSimInitializeSystem.__codegen__OnCreate, ContainedMiniSimInitializeSystem.__codegen__OnUpdate, null, null, null, ContainedMiniSimInitializeSystem.__codegen__OnCreateForCompiler, "ContainedMiniSim.ContainedMiniSimInitializeSystem", 3);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(TerrariumCritterMovementSystem), BurstRuntime.GetHashCode64<TerrariumCritterMovementSystem>(), null, TerrariumCritterMovementSystem.__codegen__OnUpdate, null, null, null, TerrariumCritterMovementSystem.__codegen__OnCreateForCompiler, "ContainedMiniSim.TerrariumCritterMovementSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(UpdateAquariumFishSystem), BurstRuntime.GetHashCode64<UpdateAquariumFishSystem>(), null, UpdateAquariumFishSystem.__codegen__OnUpdate, null, null, null, UpdateAquariumFishSystem.__codegen__OnCreateForCompiler, "ContainedMiniSim.UpdateAquariumFishSystem", 0);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(UpdateTerrariumCritterSystem), BurstRuntime.GetHashCode64<UpdateTerrariumCritterSystem>(), null, UpdateTerrariumCritterSystem.__codegen__OnUpdate, null, null, null, UpdateTerrariumCritterSystem.__codegen__OnCreateForCompiler, "ContainedMiniSim.UpdateTerrariumCritterSystem", 0);
	}
}
