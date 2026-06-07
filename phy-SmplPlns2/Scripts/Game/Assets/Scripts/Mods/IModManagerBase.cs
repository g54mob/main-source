using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Assets.Scripts.Mods.Events;

namespace Assets.Scripts.Mods
{
	public interface IModManagerBase
	{
		ReadOnlyCollection<ModInfo> KnownMods { get; }

		ReadOnlyCollection<ILoadedMod> LoadedMods { get; }

		ICollection<ModLoadMessage> ModLoadErrors { get; }

		ICollection<ModLoadMessage> ModLoadMessages { get; }

		ICollection<ModLoadMessage> ModLoadWarnings { get; }

		event EventHandler<ApiVersionMismatchEventArgs> ApiVersionMismatch;

		void DeleteMod(ModInfo mod);

		List<Assembly> GetModAssemblies();

		void LoadEnabledMods(bool allowApiVersionMismatch);

		void LoadMod(ModInfo mod, bool allowApiVersionMismatch);

		void LoadMods(List<ModInfo> mods, bool allowApiVersionMismatch);

		void SaveModLoadLog(string filePath);

		List<ModInfo> ScanForMods(string directory, bool recursive, bool createIfNotFound);
	}
}
