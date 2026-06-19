using Pug.Dev.Generated;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__13644973290699417700
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(CleanupGoToCommandSystem), BurstRuntime.GetHashCode64<CleanupGoToCommandSystem>(), null, CleanupGoToCommandSystem.__codegen__OnUpdate, null, null, null, CleanupGoToCommandSystem.__codegen__OnCreateForCompiler, "CleanupGoToCommandSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(GoToObjectRequestRpcCommandRequestSystem), BurstRuntime.GetHashCode64<GoToObjectRequestRpcCommandRequestSystem>(), GoToObjectRequestRpcCommandRequestSystem.__codegen__OnCreate, GoToObjectRequestRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.Dev.Generated.GoToObjectRequestRpcCommandRequestSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(GoToObjectResponseRpcCommandRequestSystem), BurstRuntime.GetHashCode64<GoToObjectResponseRpcCommandRequestSystem>(), GoToObjectResponseRpcCommandRequestSystem.__codegen__OnCreate, GoToObjectResponseRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.Dev.Generated.GoToObjectResponseRpcCommandRequestSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(RevealWholeMapRequestRpcCommandRequestSystem), BurstRuntime.GetHashCode64<RevealWholeMapRequestRpcCommandRequestSystem>(), RevealWholeMapRequestRpcCommandRequestSystem.__codegen__OnCreate, RevealWholeMapRequestRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.Dev.Generated.RevealWholeMapRequestRpcCommandRequestSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(RevealWholeMapProgressUpdateRpcCommandRequestSystem), BurstRuntime.GetHashCode64<RevealWholeMapProgressUpdateRpcCommandRequestSystem>(), RevealWholeMapProgressUpdateRpcCommandRequestSystem.__codegen__OnCreate, RevealWholeMapProgressUpdateRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.Dev.Generated.RevealWholeMapProgressUpdateRpcCommandRequestSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(RegenerateTerrainRequestRpcCommandRequestSystem), BurstRuntime.GetHashCode64<RegenerateTerrainRequestRpcCommandRequestSystem>(), RegenerateTerrainRequestRpcCommandRequestSystem.__codegen__OnCreate, RegenerateTerrainRequestRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.Dev.Generated.RegenerateTerrainRequestRpcCommandRequestSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(RegenerateTerrainResponseRpcCommandRequestSystem), BurstRuntime.GetHashCode64<RegenerateTerrainResponseRpcCommandRequestSystem>(), RegenerateTerrainResponseRpcCommandRequestSystem.__codegen__OnCreate, RegenerateTerrainResponseRpcCommandRequestSystem.__codegen__OnUpdate, null, null, null, null, "Pug.Dev.Generated.RegenerateTerrainResponseRpcCommandRequestSystem", 2);
	}
}
