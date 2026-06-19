using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__17341725163219194176
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(ObjectLookupServerSystem), BurstRuntime.GetHashCode64<ObjectLookupServerSystem>(), ObjectLookupServerSystem.__codegen__OnCreate, ObjectLookupServerSystem.__codegen__OnUpdate, ObjectLookupServerSystem.__codegen__OnDestroy, ObjectLookupServerSystem.__codegen__OnStartRunning, ObjectLookupServerSystem.__codegen__OnStopRunning, ObjectLookupServerSystem.__codegen__OnCreateForCompiler, "ObjectLookupServerSystem", 15);
	}
}
