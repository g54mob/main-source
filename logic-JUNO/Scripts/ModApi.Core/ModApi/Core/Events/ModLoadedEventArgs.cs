using System;
using Jundroo.ModTools.Core;

namespace ModApi.Core.Events
{
	public class ModLoadedEventArgs : EventArgs
	{
		public ModManifestData ManifestData { get; private set; }

		public LoadedMod Mod { get; private set; }

		public ModLoadedEventArgs(LoadedMod mod, ModManifestData manifestData)
		{
			Mod = mod;
			ManifestData = manifestData;
		}
	}
}
