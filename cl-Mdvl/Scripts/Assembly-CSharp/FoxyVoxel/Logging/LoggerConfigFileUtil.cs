using UnityEngine;

namespace FoxyVoxel.Logging
{
	public static class LoggerConfigFileUtil
	{
		public static readonly string BuildConfigFolderPath = Application.streamingAssetsPath + "/Config/Logging";

		public static readonly string ProdBuildJsonPath = BuildConfigFolderPath + "/loggingProdBuildConfig.json";

		public static LoggerConfig ReadFromFile(string path)
		{
			return LoggerConfig.ReadFromFile(path);
		}

		public static void WriteToFile(LoggerConfig config, string path)
		{
			config.WriteToFile(path);
		}

		public static void SaveToProductionConfig()
		{
			WriteToFile(FVLogger.Config, ProdBuildJsonPath);
		}

		public static void LoadFromProductionConfig()
		{
			FVLogger.Config = ReadFromFile(ProdBuildJsonPath);
		}
	}
}
