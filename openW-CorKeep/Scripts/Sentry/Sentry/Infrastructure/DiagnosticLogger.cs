using System;
using System.Text;
using Sentry.Extensibility;

namespace Sentry.Infrastructure
{
	public abstract class DiagnosticLogger : IDiagnosticLogger
	{
		private readonly SentryLevel _minimalLevel;

		protected DiagnosticLogger(SentryLevel minimalLevel)
		{
			_minimalLevel = minimalLevel;
		}

		public bool IsEnabled(SentryLevel level)
		{
			return level >= _minimalLevel;
		}

		public void Log(SentryLevel logLevel, string message, Exception? exception = null, params object?[] args)
		{
			string text = ScrubNewlines((args.Length == 0) ? message : string.Format(message, args));
			string message2 = ((exception == null) ? $"{logLevel,7}: {text}" : $"{logLevel,7}: {text}{Environment.NewLine}{exception}");
			LogMessage(message2);
		}

		protected abstract void LogMessage(string message);

		private static string ScrubNewlines(string s)
		{
			StringBuilder stringBuilder = new StringBuilder(s.Length);
			for (int i = 0; i < s.Length; i++)
			{
				char c = s[i];
				switch (c)
				{
				case '\r':
					stringBuilder.Append(' ');
					if (i < s.Length - 1 && s[i + 1] == '\n')
					{
						i++;
					}
					break;
				case '\n':
					stringBuilder.Append(' ');
					break;
				default:
					stringBuilder.Append(c);
					break;
				}
			}
			int num = stringBuilder.Length;
			while (stringBuilder[num - 1] == ' ')
			{
				num--;
			}
			return stringBuilder.ToString(0, num);
		}
	}
}
