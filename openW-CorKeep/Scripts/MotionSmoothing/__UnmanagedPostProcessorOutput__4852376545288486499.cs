using MotionSmoothing;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[BurstCompile]
internal class __UnmanagedPostProcessorOutput__4852376545288486499
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(MotionSmoothingSwapInterpolationTargetSystem), BurstRuntime.GetHashCode64<MotionSmoothingSwapInterpolationTargetSystem>(), MotionSmoothingSwapInterpolationTargetSystem.__codegen__OnCreate, MotionSmoothingSwapInterpolationTargetSystem.__codegen__OnUpdate, null, null, null, MotionSmoothingSwapInterpolationTargetSystem.__codegen__OnCreateForCompiler, "MotionSmoothing.MotionSmoothingSwapInterpolationTargetSystem", 3);
		SystemBaseRegistry.AddUnmanagedSystemType(typeof(MotionSmoothingSystem), BurstRuntime.GetHashCode64<MotionSmoothingSystem>(), MotionSmoothingSystem.__codegen__OnCreate, MotionSmoothingSystem.__codegen__OnUpdate, null, null, null, MotionSmoothingSystem.__codegen__OnCreateForCompiler, "MotionSmoothing.MotionSmoothingSystem", 3);
	}
}
