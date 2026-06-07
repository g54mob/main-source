using System.IO;
using UnityEngine;

namespace DV.WorldTools
{
	public static class RuntimeCommon
	{
		public static void MakeDirForFileAndRemoveReadOnlyIfNeeded(string pathToFile)
		{
			MakeDirIfDoesNotExist(Path.GetDirectoryName(pathToFile));
			FileInfo fileInfo = new FileInfo(pathToFile);
			if (fileInfo.Exists && fileInfo.IsReadOnly)
			{
				Debug.LogWarning("File '" + pathToFile + "' was read-only and had to be made writable");
				fileInfo.IsReadOnly = false;
			}
		}

		public static void MakeDirIfDoesNotExist(string pathToDirToMake)
		{
			if (!Directory.Exists(pathToDirToMake))
			{
				Directory.CreateDirectory(pathToDirToMake);
			}
		}
	}
}
