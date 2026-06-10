using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using UnityEngine;
using ZLogger;

namespace NSMedieval.Testing.Autoplay
{
	public class TestLogger
	{
		private readonly Microsoft.Extensions.Logging.ILogger logger;

		public TestLogger(string testId)
		{
			ILoggerFactory loggerFactory = LoggerFactory.Create(delegate(ILoggingBuilder config)
			{
				config.SetMinimumLevel(LogLevel.Trace);
				string path = Path.Combine(Application.dataPath, "..");
				path = Path.Combine(path, "autoplay_" + testId + ".log");
				config.AddZLoggerFile(path);
			});
			logger = loggerFactory.CreateLogger("Autoplay");
		}

		public static void LogFailedTests(List<string> failedTests, bool exceptionHappened)
		{
			Microsoft.Extensions.Logging.ILogger logger = LoggerFactory.Create(delegate(ILoggingBuilder config)
			{
				config.SetMinimumLevel(LogLevel.Trace);
				string path = Path.Combine(Application.dataPath, "..");
				path = Path.Combine(path, "autoplay.log");
				config.AddZLoggerFile(path);
			}).CreateLogger("Autoplay");
			logger.ZLogInformation("FAILED TESTS:");
			foreach (string failedTest in failedTests)
			{
				logger.ZLogInformation(failedTest);
			}
			if (exceptionHappened)
			{
				logger.ZLogInformation("Exception happened and cut testing short.");
			}
		}

		public void Log(string message)
		{
			DateTime dateTime = DateTime.Now.ToLocalTime();
			message = $"[{dateTime.Hour:D2}:{dateTime.Minute:D2}:{dateTime.Second:D2}.{dateTime.Millisecond:D3}] {message}";
			logger.ZLogInformation(message);
		}
	}
}
