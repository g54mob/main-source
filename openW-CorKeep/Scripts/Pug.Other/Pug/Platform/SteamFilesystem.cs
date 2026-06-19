using System;
using System.Collections.Generic;
using PugMod;
using Steamworks;
using UnityEngine;

namespace Pug.Platform
{
	[DisallowPatching]
	public class SteamFilesystem : NoDirectoryFilesystemInterface
	{
		private const int fileCountLimit = 99900;

		public override void Init(string partition, PlatformInterface platformInterface)
		{
			throw new NotImplementedException("SteamFilesystem has no partition support yet");
		}

		public override void Deinit()
		{
		}

		public override void Delete(string path)
		{
			if (path == null || !SteamRemoteStorage.FileDelete(path))
			{
				Debug.LogError("Delete failed on " + path);
			}
			else
			{
				base.Delete(path);
			}
		}

		public override bool FileExists(string path)
		{
			if (path == null)
			{
				Debug.LogError("FileExists got null");
				return false;
			}
			return SteamRemoteStorage.FileExists(path);
		}

		public override byte[] Read(string path)
		{
			if (path == null)
			{
				Debug.LogError("Read failed");
			}
			return SteamRemoteStorage.FileRead(path);
		}

		public override void BeginWrite()
		{
		}

		public override void EndWrite()
		{
		}

		public override void Write(string name, string path, byte[] data)
		{
			if (path == null || data == null || data.Length == 0 || !SteamRemoteStorage.FileWrite(path, data))
			{
				Debug.LogError("Write failed on " + path + " with size " + ((data != null) ? data.Length : (-1)));
			}
			else
			{
				base.Write(name, path, data);
			}
		}

		public override IEnumerable<string> GetAllFiles()
		{
			return SteamRemoteStorage.Files;
		}

		public override DateTime GetFileTime(string path)
		{
			return SteamRemoteStorage.FileTime(path);
		}

		public override ulong GetRemainingBytes()
		{
			if (SteamRemoteStorage.FileCount >= 99900)
			{
				Debug.Log("Reached steam file count limit");
				return 0uL;
			}
			return SteamRemoteStorage.QuotaRemainingBytes;
		}
	}
}
