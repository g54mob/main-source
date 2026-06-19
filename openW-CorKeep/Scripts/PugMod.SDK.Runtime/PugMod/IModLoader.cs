using System;
using System.Collections.Generic;

namespace PugMod
{
	public interface IModLoader
	{
		IEnumerable<LoadedMod> LoadedMods { get; }

		string GetDirectory(long modId);

		void ApplyHarmonyPatches(long modId);

		void ApplyHarmonyPatch(long modId, Type type);

		void UnloadHarmonyPatches(long modId);
	}
}
