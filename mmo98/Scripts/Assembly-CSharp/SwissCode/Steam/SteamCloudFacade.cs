using Steamworks;

namespace SwissCode.Steam
{
	public class SteamCloudFacade : SteamFacade
	{
		public override void Initialize()
		{
			Initialized = SteamRemoteStorage.IsCloudEnabledForAccount() && SteamRemoteStorage.IsCloudEnabledForApp();
		}

		public void FileWrite(params SteamFile[] files)
		{
			if (Initialized)
			{
				SteamRemoteStorage.BeginFileWriteBatch();
				for (int i = 0; i < files.Length; i++)
				{
					SteamFile steamFile = files[i];
					SteamRemoteStorage.FileWrite(steamFile.Name, steamFile.Data, steamFile.Size);
				}
				SteamRemoteStorage.EndFileWriteBatch();
			}
		}

		public byte[] FileRead(string name)
		{
			if (!Initialized)
			{
				return null;
			}
			byte[] array = new byte[GetFileSize(name)];
			SteamRemoteStorage.FileRead(name, array, GetFileSize(name));
			return array;
		}

		public bool FilePersisted(string name)
		{
			if (Initialized)
			{
				return SteamRemoteStorage.FilePersisted(name);
			}
			return false;
		}

		public void FileForget(string name)
		{
			if (Initialized)
			{
				SteamRemoteStorage.FileForget(name);
			}
		}

		public int GetFileCount()
		{
			if (Initialized)
			{
				return SteamRemoteStorage.GetFileCount();
			}
			return 0;
		}

		public (string name, int size) GetFileNameAndSize(int index)
		{
			if (!Initialized)
			{
				return default((string, int));
			}
			int pnFileSizeInBytes;
			return (name: SteamRemoteStorage.GetFileNameAndSize(index, out pnFileSizeInBytes), size: pnFileSizeInBytes);
		}

		public int GetFileSize(string name)
		{
			if (Initialized)
			{
				return SteamRemoteStorage.GetFileSize(name);
			}
			return 0;
		}

		public long GetFileTimestamp(string name)
		{
			if (Initialized)
			{
				return SteamRemoteStorage.GetFileTimestamp(name);
			}
			return 0L;
		}

		public (ulong total, ulong available) GetQuota()
		{
			if (!Initialized)
			{
				return default((ulong, ulong));
			}
			SteamRemoteStorage.GetQuota(out var pnTotalBytes, out var puAvailableBytes);
			return (total: pnTotalBytes, available: puAvailableBytes);
		}
	}
}
