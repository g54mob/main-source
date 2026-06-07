using System.IO;
using UnityEngine;

namespace SoulGames.EasyGridBuilderPro
{
	public static class GridSaveSystem
	{
		private const string SAVE_EXTENSION = "txt";

		private static readonly string saveFolder = Application.dataPath + EasyGridBuilderPro.Instance.saveLocation;

		private static bool isInit = false;

		public static void Init()
		{
			if (!isInit)
			{
				isInit = true;
				if (!Directory.Exists(saveFolder))
				{
					Directory.CreateDirectory(saveFolder);
				}
			}
		}

		public static void Save(string fileName, string saveString, bool overwrite)
		{
			Init();
			File.WriteAllText(saveFolder + fileName + ".txt", saveString);
		}

		public static string Load(string fileName)
		{
			Init();
			if (File.Exists(saveFolder + fileName + ".txt"))
			{
				return File.ReadAllText(saveFolder + fileName + ".txt");
			}
			return null;
		}
	}
}
