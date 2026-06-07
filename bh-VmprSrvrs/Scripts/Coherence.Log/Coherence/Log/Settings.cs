using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Coherence.Log
{
	public class Settings
	{
		internal const string defaultLogFilePath = "Logs/player_logs.txt";

		internal const LogLevel defaultFileLogLevel = LogLevel.Debug;

		[JsonProperty("editorLoglevel")]
		public LogLevel EditorLogLevel;

		[JsonProperty("loglevel")]
		public LogLevel LogLevel;

		[JsonProperty("filtermode")]
		public Log.FilterMode FilterMode;

		[JsonProperty("logStackTrace")]
		public bool LogStackTrace;

		[JsonProperty("sourcefilters")]
		public string SourceFilters;

		[JsonProperty("logToFile")]
		public bool LogToFile;

		[JsonProperty("logFilePath", DefaultValueHandling = DefaultValueHandling.Populate)]
		[DefaultValue("Logs/player_logs.txt")]
		public string LogFilePath;

		[JsonProperty("fileLogLevel", DefaultValueHandling = DefaultValueHandling.Populate)]
		[DefaultValue(LogLevel.Debug)]
		public LogLevel FileLogLevel;

		[NonSerialized]
		private string[] processedSourceFilters;

		[NonSerialized]
		private string savePath;

		internal event Action OnSaved
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public Settings()
		{
		}

		public Settings(string savePath)
		{
		}

		internal string[] GetSourceFilter()
		{
			return null;
		}

		public static Settings Load(string path)
		{
			return null;
		}

		public void Save()
		{
		}

		private void ProcessSourceFilters()
		{
		}

		private static string Serialize(Settings settings)
		{
			return null;
		}

		private static Settings Deserialize(string json)
		{
			return null;
		}

		private static void LogError(string message)
		{
		}
	}
}
