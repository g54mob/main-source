using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Aggro.Core
{
	public static class FileUtil
	{
		private const int DEFAULT_FILE_COUNT = 9;

		public static void DeleteExtraFiles(string dirPath, int keepCount = 9)
		{
			try
			{
				if (Directory.Exists(dirPath))
				{
					List<string> list = new List<string>(Directory.GetFiles(dirPath));
					list.Sort();
					for (int i = 0; i < list.Count - keepCount; i++)
					{
						File.Delete(list[i]);
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogError("Caught exception when deleting files!");
				Debug.LogException(exception);
			}
		}
	}
}
