using System;
using System.Collections.Generic;

namespace PugMod
{
	public interface IIntegration
	{
		IEnumerable<LoadedMod> LoadedMods { get; }

		IEnumerable<NotLoadedMod> FailedToLoadMods { get; }

		event Action<object> AssetProcessor;

		void Init(IConfigFilesystem configFilesystem);

		void Update();

		bool AddMod(ModMetadata metadata, string modDirectory, long modId, bool supportsCurrentVersion);

		void RemoveMod(long modId);

		void LoadUnsupportedMod(string guid);
	}
}
