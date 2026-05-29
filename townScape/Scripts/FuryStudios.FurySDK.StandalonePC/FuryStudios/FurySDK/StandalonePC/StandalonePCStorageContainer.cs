using System.Collections.Generic;
using FuryStudios.FurySDK.Internal;
using FuryStudios.FurySDK.Settings;

namespace FuryStudios.FurySDK.StandalonePC
{
	public class StandalonePCStorageContainer : BaseStorageContainer
	{
		private readonly AsyncRequestScheduler requestScheduler;

		private string RootPath { get; }

		public StandalonePCStorageContainer(AsyncRequestScheduler requestScheduler, ContainerID ID, PlatformSettings settings)
			: base(default(ContainerID), null)
		{
		}

		public override IAsyncRequest<byte[]> LoadBytes(string filename)
		{
			return null;
		}

		public override IAsyncRequest<string> LoadText(string filename)
		{
			return null;
		}

		public override IAsyncRequest SaveBytes(string filename, byte[] data)
		{
			return null;
		}

		public override IAsyncRequest SaveText(string filename, string text)
		{
			return null;
		}

		public override IAsyncRequest Delete(string filename)
		{
			return null;
		}

		public override IAsyncRequest<bool> FileExists(string filename)
		{
			return null;
		}

		public override IAsyncRequest<IList<string>> ListFiles()
		{
			return null;
		}

		private string GetDirPath()
		{
			return null;
		}

		private string GetFilePath(string fileName)
		{
			return null;
		}
	}
}
