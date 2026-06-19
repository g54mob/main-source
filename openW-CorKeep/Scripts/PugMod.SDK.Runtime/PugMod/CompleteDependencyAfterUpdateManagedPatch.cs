using Unity.Collections;
using Unity.Entities;

namespace PugMod
{
	internal static class CompleteDependencyAfterUpdateManagedPatch
	{
		public unsafe static void Postfix(SystemState* ___m_StatePtr, NativeReference<bool> __state)
		{
			if (___m_StatePtr != null)
			{
				___m_StatePtr->Dependency.Complete();
			}
		}
	}
}
