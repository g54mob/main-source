using HarmonyLib;
using Unity.Burst;
using Unity.Entities;

namespace PugMod
{
	internal static class DisableBurstForManagedSystemPatch
	{
		internal static void OnCreatePrefix(SystemBase __instance, out bool? __state)
		{
			__state = BurstCompiler.Options.EnableBurstCompilation;
			BurstCompiler.Options.EnableBurstCompilation = false;
		}

		internal static void OnCreatePostfix(bool? __state)
		{
			if (__state.HasValue)
			{
				BurstCompiler.Options.EnableBurstCompilation = __state.Value;
			}
		}

		internal static void OnStartRunningPrefix(SystemBase __instance, out bool? __state)
		{
			__state = BurstCompiler.Options.EnableBurstCompilation;
			BurstCompiler.Options.EnableBurstCompilation = false;
		}

		internal static void OnStartRunningPostfix(bool? __state)
		{
			if (__state.HasValue)
			{
				BurstCompiler.Options.EnableBurstCompilation = __state.Value;
			}
		}

		internal static void OnUpdatePrefix(SystemBase __instance, out bool? __state)
		{
			__state = BurstCompiler.Options.EnableBurstCompilation;
			BurstCompiler.Options.EnableBurstCompilation = false;
		}

		[HarmonyPriority(200)]
		internal static void OnUpdatePostfix(bool? __state)
		{
			if (__state.HasValue)
			{
				BurstCompiler.Options.EnableBurstCompilation = __state.Value;
			}
		}

		internal static void OnStopRunningPrefix(SystemBase __instance, out bool? __state)
		{
			__state = BurstCompiler.Options.EnableBurstCompilation;
			BurstCompiler.Options.EnableBurstCompilation = false;
		}

		internal static void OnStopRunningPostfix(bool? __state)
		{
			if (__state.HasValue)
			{
				BurstCompiler.Options.EnableBurstCompilation = __state.Value;
			}
		}

		internal static void OnDestroyPrefix(SystemBase __instance, out bool? __state)
		{
			__state = BurstCompiler.Options.EnableBurstCompilation;
			BurstCompiler.Options.EnableBurstCompilation = false;
		}

		internal static void OnDestroyPostfix(bool? __state)
		{
			if (__state.HasValue)
			{
				BurstCompiler.Options.EnableBurstCompilation = __state.Value;
			}
		}
	}
}
