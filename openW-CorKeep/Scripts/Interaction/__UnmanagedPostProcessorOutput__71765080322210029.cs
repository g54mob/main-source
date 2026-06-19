using Interaction;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__71765080322210029
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(InteractableVisualUpdateSystem), BurstRuntime.GetHashCode64<InteractableVisualUpdateSystem>(), null, InteractableVisualUpdateSystem.__codegen__OnUpdate, null, null, null, InteractableVisualUpdateSystem.__codegen__OnCreateForCompiler, "Interaction.InteractableVisualUpdateSystem", 0);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(LocalInteractionSystem), BurstRuntime.GetHashCode64<LocalInteractionSystem>(), null, LocalInteractionSystem.__codegen__OnUpdate, null, null, null, LocalInteractionSystem.__codegen__OnCreateForCompiler, "Interaction.LocalInteractionSystem", 0);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(ResolveInteractableActiveSystem), BurstRuntime.GetHashCode64<ResolveInteractableActiveSystem>(), null, ResolveInteractableActiveSystem.__codegen__OnUpdate, null, ResolveInteractableActiveSystem.__codegen__OnStartRunning, ResolveInteractableActiveSystem.__codegen__OnStopRunning, ResolveInteractableActiveSystem.__codegen__OnCreateForCompiler, "Interaction.ResolveInteractableActiveSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(ResolveInteractorActiveSystem), BurstRuntime.GetHashCode64<ResolveInteractorActiveSystem>(), ResolveInteractorActiveSystem.__codegen__OnCreate, ResolveInteractorActiveSystem.__codegen__OnUpdate, null, null, null, ResolveInteractorActiveSystem.__codegen__OnCreateForCompiler, "Interaction.ResolveInteractorActiveSystem", 3);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(SetInteractorInputSystem), BurstRuntime.GetHashCode64<SetInteractorInputSystem>(), null, SetInteractorInputSystem.__codegen__OnUpdate, null, null, null, SetInteractorInputSystem.__codegen__OnCreateForCompiler, "Interaction.SetInteractorInputSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(ToggleClosestLocalInteractableSystem), BurstRuntime.GetHashCode64<ToggleClosestLocalInteractableSystem>(), ToggleClosestLocalInteractableSystem.__codegen__OnCreate, ToggleClosestLocalInteractableSystem.__codegen__OnUpdate, null, null, null, ToggleClosestLocalInteractableSystem.__codegen__OnCreateForCompiler, "Interaction.ToggleClosestLocalInteractableSystem", 3);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(TriggerLocalInteractionSystem), BurstRuntime.GetHashCode64<TriggerLocalInteractionSystem>(), null, TriggerLocalInteractionSystem.__codegen__OnUpdate, null, null, null, TriggerLocalInteractionSystem.__codegen__OnCreateForCompiler, "Interaction.TriggerLocalInteractionSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(TriggerUseInteractionSystem), BurstRuntime.GetHashCode64<TriggerUseInteractionSystem>(), null, TriggerUseInteractionSystem.__codegen__OnUpdate, null, null, null, TriggerUseInteractionSystem.__codegen__OnCreateForCompiler, "Interaction.TriggerUseInteractionSystem", 2);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(UpdateSelectedInteractableSystem), BurstRuntime.GetHashCode64<UpdateSelectedInteractableSystem>(), null, UpdateSelectedInteractableSystem.__codegen__OnUpdate, null, UpdateSelectedInteractableSystem.__codegen__OnStartRunning, UpdateSelectedInteractableSystem.__codegen__OnStopRunning, UpdateSelectedInteractableSystem.__codegen__OnCreateForCompiler, "Interaction.UpdateSelectedInteractableSystem", 10);
	}
}
