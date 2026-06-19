using FixedTickInterpolation;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__2599310017424107166
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(ResetPhysicsStepsForSmoothingSystem), BurstRuntime.GetHashCode64<ResetPhysicsStepsForSmoothingSystem>(), ResetPhysicsStepsForSmoothingSystem.__codegen__OnCreate, ResetPhysicsStepsForSmoothingSystem.__codegen__OnUpdate, null, null, null, ResetPhysicsStepsForSmoothingSystem.__codegen__OnCreateForCompiler, "FixedTickInterpolation.ResetPhysicsStepsForSmoothingSystem", 3);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(RecordPhysicsStepsForSmoothingSystem), BurstRuntime.GetHashCode64<RecordPhysicsStepsForSmoothingSystem>(), RecordPhysicsStepsForSmoothingSystem.__codegen__OnCreate, RecordPhysicsStepsForSmoothingSystem.__codegen__OnUpdate, null, null, null, RecordPhysicsStepsForSmoothingSystem.__codegen__OnCreateForCompiler, "FixedTickInterpolation.RecordPhysicsStepsForSmoothingSystem", 3);
	}
}
