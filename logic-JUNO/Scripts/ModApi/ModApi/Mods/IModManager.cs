using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Jundroo.ModTools;

namespace ModApi.Mods
{
	public interface IModManager
	{
		IReadOnlyList<GameMod> GameMods { get; }

		ReadOnlyCollection<ModInfo> KnownMods { get; }

		ReadOnlyCollection<ILoadedMod> LoadedMods { get; }

		bool SupportsCodeExecution { get; }

		List<Assembly> GetModAssemblies();
	}
}
