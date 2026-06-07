using System;

namespace VoxelBusters.CoreLibrary
{
	[Serializable]
	public class UnityPackageDefinition
	{
		private string m_persistentDataRelativePath;

		public string Name { get; private set; }

		public string DisplayName { get; private set; }

		public string Version { get; private set; }

		public string DefaultInstallPath { get; private set; }

		public string UpmInstallPath { get; private set; }

		public string MutableResourcesPath { get; private set; }

		public string MutableResourcesRelativePath { get; private set; }

		public string PersistentDataRelativePath => null;

		public string PersistentDataPath => null;

		public UnityPackageDefinition[] Dependencies { get; private set; }

		public UnityPackageDefinition(string name, string displayName, string version, string defaultInstallPath = null, string mutableResourcesPath = "Assets/Resources", string persistentDataRelativePath = null, params UnityPackageDefinition[] dependencies)
		{
		}

		private void EnsurePersistentDataPathExists()
		{
		}

		private string GetPersistentDataPathInternal()
		{
			return null;
		}
	}
}
