using System;
using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[Serializable]
	public class StandalonePlatformSettings
	{
		[SerializeField]
		private FilePathRoot storageRoot;

		[SerializeField]
		private string storageRootSuffixPc;

		[SerializeField]
		private string storageRootSuffixOsX;

		[SerializeField]
		private string storageRootSuffixLinux;

		[SerializeField]
		private StandaloneStorageContainerBehaviour storageContainerBehaviour;

		public FilePathRoot StorageRoot => default(FilePathRoot);

		public string StorageRootSuffix => null;

		public StandaloneStorageContainerBehaviour StorageContainerBehaviour => default(StandaloneStorageContainerBehaviour);
	}
}
