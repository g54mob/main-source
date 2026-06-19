using Pushback.Components.Generated;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__6642026837686237008
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(GhostComponentSerializerRegistrationSystem), BurstRuntime.GetHashCode64<GhostComponentSerializerRegistrationSystem>(), GhostComponentSerializerRegistrationSystem.__codegen__OnCreate, GhostComponentSerializerRegistrationSystem.__codegen__OnUpdate, null, null, null, null, "Pushback.Components.Generated.GhostComponentSerializerRegistrationSystem", 2);
	}
}
