using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sirenix.Utilities;
using UnityEngine;

namespace Restory.Data.Localization
{
	public static class MissingLocalizationStatistic
	{
		private const string FILE_NAME = "MissingLocalizations.txt";

		private static readonly HashSet<string> EmptyIds = new HashSet<string>();

		public static void Add(string localizationID)
		{
			EmptyIds.Add(localizationID);
		}

		public static List<string> Get()
		{
			return CollectAllData();
		}

		public static void Save()
		{
			List<string> data = CollectAllData();
			try
			{
				WriteData(data);
			}
			catch (Exception)
			{
			}
		}

		private static List<string> CollectAllData()
		{
			List<string> range = ReadData();
			EmptyIds.AddRange(range);
			return EmptyIds.ToList();
		}

		private static List<string> ReadData()
		{
			string filePath = GetFilePath();
			if (!File.Exists(filePath))
			{
				return new List<string>();
			}
			return File.ReadAllLines(filePath).ToList();
		}

		private static void WriteData(List<string> data)
		{
			if (data != null && data.Count != 0)
			{
				File.WriteAllLines(GetFilePath(), data);
			}
		}

		private static string GetFilePath()
		{
			return Path.Combine(Application.persistentDataPath, "MissingLocalizations.txt");
		}
	}
}
