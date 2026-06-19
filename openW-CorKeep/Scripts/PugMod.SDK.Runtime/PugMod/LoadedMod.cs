using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PugMod
{
	public class LoadedMod
	{
		public long ModId;

		public ModMetadata Metadata;

		public List<IMod> Handlers;

		public List<Object> Assets;

		public List<AssetBundle> AssetBundles;

		public byte[] GetFile(string path)
		{
			string directory = API.ModLoader.GetDirectory(ModId);
			if (string.IsNullOrEmpty(directory))
			{
				return null;
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(directory);
			FileInfo fileInfo = new FileInfo(Path.Combine(directory, path));
			if (!fileInfo.FullName.StartsWith(directoryInfo.FullName))
			{
				Debug.LogWarning("tried to access path outside mod directory " + fileInfo.FullName);
				return null;
			}
			return File.ReadAllBytes(fileInfo.FullName);
		}
	}
}
