using System;
using System.Collections.Generic;
using UnityEngine;

namespace PugMod
{
	[Serializable]
	public struct ModMetadata
	{
		[Flags]
		public enum ModExistsOn
		{
			None = 0,
			Client = 1,
			Server = 2,
			ClientAndServer = 3
		}

		[Serializable]
		public struct Dependency
		{
			public string modName;

			public bool required;
		}

		public string guid;

		public string name;

		[HideInInspector]
		public string displayName;

		public bool skipSafetyChecks;

		public bool disableScripts;

		public bool accessesExtraAssemblies;

		public bool disableHarmonyPatching;

		public ModExistsOn requiredOn;

		public List<ModFile> files;

		public List<Dependency> dependencies;
	}
}
