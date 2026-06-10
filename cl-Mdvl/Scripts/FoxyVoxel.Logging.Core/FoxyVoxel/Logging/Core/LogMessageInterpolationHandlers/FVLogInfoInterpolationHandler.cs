using System;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Logging;

namespace FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers
{
	[InterpolatedStringHandler]
	public readonly ref struct FVLogInfoInterpolationHandler
	{
		private readonly StringBuilder? builder;

		public readonly FVLogger? Logger;

		public readonly bool IsEnabled;

		private const LogLevel Level = LogLevel.Information;

		public FVLogInfoInterpolationHandler(int literalLength, int formattedCount, out bool isEnabled, [CallerFilePath] string filePath = "?")
		{
			if (LogLevel.Information < FVLogger.Config.MinimumLevel)
			{
				isEnabled = false;
				IsEnabled = isEnabled;
				builder = null;
				Logger = null;
				return;
			}
			Logger = Log.GetLogger(filePath);
			if (Logger.ShouldHideCategory)
			{
				isEnabled = false;
				IsEnabled = isEnabled;
				builder = null;
				Logger = null;
			}
			else
			{
				isEnabled = true;
				IsEnabled = isEnabled;
				builder = new StringBuilder(literalLength);
			}
		}

		public void LogMessage()
		{
			if (IsEnabled)
			{
				Logger.LogNoCheck(LogLevel.Information, GetFormattedText());
			}
		}

		public void AppendLiteral(string s)
		{
			builder.Append(s);
		}

		public void AppendFormatted<T>(T t)
		{
			builder.Append(t?.ToString());
		}

		public void AppendFormatted<T>(T t, string format) where T : IFormattable
		{
			builder.Append(t?.ToString(format, null));
		}

		public string GetFormattedText()
		{
			return builder.ToString();
		}
	}
}
