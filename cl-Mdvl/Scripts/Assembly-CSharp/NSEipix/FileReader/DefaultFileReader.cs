using System.IO;
using NSMedieval.Tools;
using UnityEngine;

namespace NSEipix.FileReader
{
	public class DefaultFileReader : IFileReader
	{
		private static string persistantPath;

		private static string streamingPath;

		private static string PersistantPath
		{
			get
			{
				if (string.IsNullOrEmpty(persistantPath))
				{
					persistantPath = Application.persistentDataPath;
				}
				return persistantPath;
			}
		}

		private static string StreamingPath
		{
			get
			{
				if (string.IsNullOrEmpty(streamingPath))
				{
					streamingPath = Application.streamingAssetsPath;
				}
				return streamingPath;
			}
		}

		public DefaultFileReader()
		{
			streamingPath = Application.streamingAssetsPath;
			persistantPath = Application.persistentDataPath;
		}

		public virtual string GetPersistentDataPath()
		{
			return PersistantPath;
		}

		public virtual string GetStreamingAssetsPath()
		{
			return StreamingPath;
		}

		public virtual string ReadFromPersistentData(string fileName)
		{
			string path = Path.Combine(PersistantPath, fileName);
			if (!File.Exists(path))
			{
				return string.Empty;
			}
			return FileUtils.SafeReadAllText(path);
		}

		public virtual string ReadFromStreamingAssets(string fileName)
		{
			string path = Path.Combine(StreamingPath, fileName);
			if (!File.Exists(path))
			{
				return string.Empty;
			}
			return FileUtils.SafeReadAllText(path);
		}

		public virtual string ReadFile(string fileName)
		{
			string text = ReadFromPersistentData(fileName);
			if (!string.IsNullOrEmpty(text))
			{
				return text;
			}
			return ReadFromStreamingAssets(fileName);
		}
	}
}
