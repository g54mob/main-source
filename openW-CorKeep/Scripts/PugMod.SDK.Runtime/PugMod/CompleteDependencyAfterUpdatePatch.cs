using Unity.Collections;
using Unity.Entities;

namespace PugMod
{
	internal static class CompleteDependencyAfterUpdatePatch
	{
		public static void Postfix(ref SystemState state, NativeReference<bool> __state)
		{
			state.Dependency.Complete();
		}
	}
}
