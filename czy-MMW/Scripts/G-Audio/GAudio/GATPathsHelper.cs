using System.IO;
using UnityEngine;

namespace GAudio
{
	public static class GATPathsHelper
	{
		public static string PathForWavFile(string relativePath, PathRelativeType type, bool createDirectory)
		{
			if (Path.GetExtension(relativePath) != ".wav")
			{
				relativePath = Path.ChangeExtension(relativePath, ".wav");
			}
			return GetAbsolutePath(relativePath, type, createDirectory);
		}

		public static string GetAbsolutePath(string relativePath, PathRelativeType type, bool createDirectory)
		{
			switch (type)
			{
			case PathRelativeType.ApplicationDataPath:
				relativePath = Path.Combine(Application.dataPath, relativePath);
				break;
			case PathRelativeType.ApplicationPersistentDataPath:
				relativePath = Path.Combine(Application.persistentDataPath, relativePath);
				break;
			case PathRelativeType.StreamingAssets:
				relativePath = Path.Combine(Application.streamingAssetsPath, relativePath);
				break;
			}
			if (createDirectory)
			{
				Directory.CreateDirectory(Path.GetDirectoryName(relativePath));
			}
			return relativePath;
		}

		public static string URLFromFilePath(string path)
		{
			return "file:///" + path;
		}
	}
}
