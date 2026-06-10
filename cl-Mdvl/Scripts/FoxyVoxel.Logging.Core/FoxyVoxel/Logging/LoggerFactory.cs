using System;
using System.Buffers;
using Cysharp.Text;
using Microsoft.Extensions.Logging;
using UnityEngine;
using ZLogger;

namespace FoxyVoxel.Logging
{
	public static class LoggerFactory
	{
		private static readonly ILoggerFactory factory;

		static LoggerFactory()
		{
			factory = UnityLoggerFactory.Create(delegate(ILoggingBuilder builder)
			{
				builder.SetMinimumLevel(LogLevel.Trace);
				builder.AddZLoggerUnityDebug(delegate(ZLoggerOptions options)
				{
					if (Application.isEditor)
					{
						ConfigureForEditor(options);
					}
					else
					{
						ConfigureForBuild(options);
					}
				});
			});
		}

		private static void ConfigureForEditor(ZLoggerOptions options)
		{
			Utf8PreparedFormat<string, string, string> prefixFormat = ZString.PrepareUtf8<string, string, string>("<color={0}>[{1}]</color> [{2}] ");
			options.PrefixFormatter = delegate(IBufferWriter<byte> writer, LogInfo info)
			{
				string logColor = GetLogColor(info.LogLevel);
				string levelLabel = GetLevelLabel(info.LogLevel);
				prefixFormat.FormatTo(ref writer, logColor, levelLabel, info.CategoryName);
			};
		}

		private static void ConfigureForBuild(ZLoggerOptions options)
		{
			Utf8PreparedFormat<int, int, int, int, string, string> prefixFormat = ZString.PrepareUtf8<int, int, int, int, string, string>("[{0:D2}:{1:D2}:{2:D2}.{3}] [{4}] [{5}] ");
			options.PrefixFormatter = delegate(IBufferWriter<byte> writer, LogInfo info)
			{
				string levelLabel = GetLevelLabel(info.LogLevel);
				DateTime dateTime = info.Timestamp.DateTime.ToLocalTime();
				prefixFormat.FormatTo(ref writer, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond, levelLabel, info.CategoryName);
			};
		}

		private static string GetLevelLabel(LogLevel level)
		{
			return level switch
			{
				LogLevel.Trace => "TRC", 
				LogLevel.Debug => "DBG", 
				LogLevel.Information => "INFO", 
				LogLevel.Warning => "WARN", 
				LogLevel.Error => "ERR", 
				LogLevel.Critical => "CRIT", 
				_ => "???", 
			};
		}

		private static string GetLogColor(LogLevel level)
		{
			return level switch
			{
				LogLevel.Trace => "cyan", 
				LogLevel.Debug => "lime", 
				LogLevel.Information => "white", 
				LogLevel.Warning => "yellow", 
				LogLevel.Error => "red", 
				LogLevel.Critical => "magenta", 
				_ => "???", 
			};
		}

		public static Microsoft.Extensions.Logging.ILogger Create(string categoryName)
		{
			return factory.CreateLogger(categoryName);
		}
	}
}
