using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace FoxyVoxel.Logging
{
	[Serializable]
	internal class LoggerConfigJson
	{
		public string MinimumLevel = LogLevel.Information.ToString();

		public List<LoggerCategorySettings> CategorySettings;

		public LoggerConfig ToConfig()
		{
			LoggerConfig loggerConfig = new LoggerConfig();
			loggerConfig.MinimumLevel = Enum.Parse<LogLevel>(MinimumLevel);
			loggerConfig.SetCategorySettings(CategorySettings);
			return loggerConfig;
		}
	}
}
