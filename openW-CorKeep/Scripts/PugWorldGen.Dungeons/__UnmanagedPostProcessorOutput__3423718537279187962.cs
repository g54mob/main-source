using PugWorldGen;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__3423718537279187962
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(DungeonApplySpawnedObjectsSystem), BurstRuntime.GetHashCode64<DungeonApplySpawnedObjectsSystem>(), DungeonApplySpawnedObjectsSystem.__codegen__OnCreate, DungeonApplySpawnedObjectsSystem.__codegen__OnUpdate, DungeonApplySpawnedObjectsSystem.__codegen__OnDestroy, DungeonApplySpawnedObjectsSystem.__codegen__OnStartRunning, DungeonApplySpawnedObjectsSystem.__codegen__OnStopRunning, DungeonApplySpawnedObjectsSystem.__codegen__OnCreateForCompiler, "PugWorldGen.DungeonApplySpawnedObjectsSystem", 30);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(DungeonPlacePathsSystem), BurstRuntime.GetHashCode64<DungeonPlacePathsSystem>(), DungeonPlacePathsSystem.__codegen__OnCreate, DungeonPlacePathsSystem.__codegen__OnUpdate, null, null, null, DungeonPlacePathsSystem.__codegen__OnCreateForCompiler, "PugWorldGen.DungeonPlacePathsSystem", 3);
	}
}
