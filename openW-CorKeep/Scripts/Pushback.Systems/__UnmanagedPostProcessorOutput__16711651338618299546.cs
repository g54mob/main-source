using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__16711651338618299546
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(PushbackSystem), BurstRuntime.GetHashCode64<PushbackSystem>(), PushbackSystem.__codegen__OnCreate, PushbackSystem.__codegen__OnUpdate, null, null, null, PushbackSystem.__codegen__OnCreateForCompiler, "PushbackSystem", 2);
	}
}
