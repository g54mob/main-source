using System;

namespace Assets.Scripts.Mods.Events
{
	public class ApiVersionMismatchEventArgs : EventArgs
	{
		public string ApiName { get; private set; }

		public Version CurrentApiVersion { get; private set; }

		public ModInfo Mod { get; private set; }

		public Version ModApiVersion { get; private set; }

		public ApiVersionMismatchEventArgs(ModInfo mod, Version currentVersion, Version modVersion, string apiName)
		{
			Mod = mod;
			CurrentApiVersion = currentVersion;
			ModApiVersion = modVersion;
			ApiName = apiName;
		}
	}
}
