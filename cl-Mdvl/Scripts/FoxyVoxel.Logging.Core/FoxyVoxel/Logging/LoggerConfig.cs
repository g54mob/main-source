using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using UnityEngine;

namespace FoxyVoxel.Logging
{
	public class LoggerConfig
	{
		public LogLevel MinimumLevel = LogLevel.Information;

		public ConcurrentDictionary<string, bool> CategoryNameToEnabled = new ConcurrentDictionary<string, bool>();

		public void SetCategorySettings(IEnumerable<LoggerCategorySettings> settings)
		{
			CategoryNameToEnabled.Clear();
			foreach (LoggerCategorySettings setting in settings)
			{
				CategoryNameToEnabled[setting.CategoryName] = setting.Enabled;
			}
		}

		public void RemoveCategory(string categoryName)
		{
			if (CategoryNameToEnabled.ContainsKey(categoryName))
			{
				CategoryNameToEnabled.Remove(categoryName, out var _);
			}
		}

		public void SetCategory(string category, bool show)
		{
			CategoryNameToEnabled[category] = show;
		}

		public bool ShouldShowCategory(string categoryName)
		{
			if (CategoryNameToEnabled.TryGetValue(categoryName, out var value))
			{
				return value;
			}
			CategoryNameToEnabled[categoryName] = true;
			return true;
		}

		private LoggerConfigJson ToJsonObj()
		{
			return new LoggerConfigJson
			{
				MinimumLevel = MinimumLevel.ToString(),
				CategorySettings = CategoryNameToEnabled.Select<KeyValuePair<string, bool>, LoggerCategorySettings>((KeyValuePair<string, bool> pair) => new LoggerCategorySettings
				{
					CategoryName = pair.Key,
					Enabled = pair.Value
				}).ToList()
			};
		}

		public static LoggerConfig ReadFromFile(string path)
		{
			return JsonUtility.FromJson<LoggerConfigJson>(File.ReadAllText(path)).ToConfig();
		}

		public void WriteToFile(string path)
		{
			string contents = JsonUtility.ToJson(ToJsonObj(), prettyPrint: true);
			File.WriteAllText(path, contents);
		}
	}
}
