using Interaction.Components.Generated;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__568229433755880775
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(GhostComponentSerializerRegistrationSystem), BurstRuntime.GetHashCode64<GhostComponentSerializerRegistrationSystem>(), GhostComponentSerializerRegistrationSystem.__codegen__OnCreate, GhostComponentSerializerRegistrationSystem.__codegen__OnUpdate, null, null, null, null, "Interaction.Components.Generated.GhostComponentSerializerRegistrationSystem", 2);
	}
}
