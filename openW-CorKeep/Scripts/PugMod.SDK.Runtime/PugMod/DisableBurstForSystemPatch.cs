using HarmonyLib;
using Unity.Burst;
using Unity.Entities;

namespace PugMod
{
	[HarmonyPatch("Unity.Entities.WorldUnmanagedImpl", "UpdateSystem")]
	internal static class DisableBurstForSystemPatch
	{
		public static void Prefix(SystemHandle sh, out bool? __state)
		{
			__state = null;
			if (BurstDisabler.SystemHandlesToDisableBurstFor.Contains(sh))
			{
				__state = BurstCompiler.Options.EnableBurstCompilation;
				BurstCompiler.Options.EnableBurstCompilation = false;
			}
		}

		public static void Postfix(bool? __state)
		{
			if (__state.HasValue)
			{
				BurstCompiler.Options.EnableBurstCompilation = __state.Value;
			}
		}
	}
}
