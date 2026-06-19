using Interaction;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__8441331062636855580
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(DisableImmuneZoneSystem), BurstRuntime.GetHashCode64<DisableImmuneZoneSystem>(), null, DisableImmuneZoneSystem.__codegen__OnUpdate, null, null, null, DisableImmuneZoneSystem.__codegen__OnCreateForCompiler, "Interaction.DisableImmuneZoneSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(TriggerPetPetSystem), BurstRuntime.GetHashCode64<TriggerPetPetSystem>(), null, TriggerPetPetSystem.__codegen__OnUpdate, null, null, null, TriggerPetPetSystem.__codegen__OnCreateForCompiler, "Interaction.TriggerPetPetSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(TriggerPickupGraveSystem), BurstRuntime.GetHashCode64<TriggerPickupGraveSystem>(), TriggerPickupGraveSystem.__codegen__OnCreate, TriggerPickupGraveSystem.__codegen__OnUpdate, null, null, null, TriggerPickupGraveSystem.__codegen__OnCreateForCompiler, "Interaction.TriggerPickupGraveSystem", 3);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(TriggerSetVariationSystem), BurstRuntime.GetHashCode64<TriggerSetVariationSystem>(), TriggerSetVariationSystem.__codegen__OnCreate, TriggerSetVariationSystem.__codegen__OnUpdate, null, null, null, TriggerSetVariationSystem.__codegen__OnCreateForCompiler, "Interaction.TriggerSetVariationSystem", 3);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(TriggerUseControllableSystem), BurstRuntime.GetHashCode64<TriggerUseControllableSystem>(), null, TriggerUseControllableSystem.__codegen__OnUpdate, null, null, null, TriggerUseControllableSystem.__codegen__OnCreateForCompiler, "Interaction.TriggerUseControllableSystem", 2);
	}
}
