using System;
using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[Serializable]
	public class AndroidPlatformSettings
	{
		[SerializeField]
		private Texture2D storageSnapshotImage;

		[SerializeField]
		private uint appId;

		[SerializeField]
		private string storageNameExtension;

		[SerializeField]
		private StorageConflictResolution storageConflictResolution;

		[SerializeField]
		private FilePathRoot storageRoot;

		[SerializeField]
		private StandaloneStorageContainerBehaviour storageContainerBehaviour;

		[SerializeField]
		private bool useCloudSaves;

		[SerializeField]
		private bool syncCloudAndLocalData;

		public Texture2D StorageSnapshotImage => null;

		public uint AppID => 0u;

		public string StorageNameExtension => null;

		public StorageConflictResolution StorageConflictResolution => default(StorageConflictResolution);

		public FilePathRoot StorageRoot => default(FilePathRoot);

		public StandaloneStorageContainerBehaviour StorageContainerBehaviour => default(StandaloneStorageContainerBehaviour);

		public bool UseCloudSaves => false;

		public bool SyncCloudAndLocalData => false;
	}
}
