using System.Collections.Generic;
using FuryStudios.FurySDK.Settings;

namespace FuryStudios.FurySDK.Internal
{
	public abstract class BaseStorageContainer : IStorageContainer
	{
		protected readonly PlatformSettings settings;

		public ContainerID ID { get; protected set; }

		public BaseStorageContainer(ContainerID ID, PlatformSettings settings)
		{
		}

		public abstract IAsyncRequest<byte[]> LoadBytes(string filename);

		public abstract IAsyncRequest<string> LoadText(string filename);

		public abstract IAsyncRequest SaveBytes(string filename, byte[] data);

		public abstract IAsyncRequest SaveText(string filename, string text);

		public abstract IAsyncRequest Delete(string filename);

		public abstract IAsyncRequest<bool> FileExists(string filename);

		public abstract IAsyncRequest<IList<string>> ListFiles();
	}
}
