using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Amazon.Runtime.Logging
{
	internal class DiagnosticAdaptorLoggerFactory : IAdaptorLoggerFactory
	{
		internal static class TraceSourceUtil
		{
			public static TraceSource GetTraceSource(Type targetType)
			{
				return GetTraceSource(targetType, SourceLevels.All);
			}

			public static TraceSource GetTraceSource(Type targetType, SourceLevels sourceLevels)
			{
				return GetTraceSourceWithListeners(targetType.FullName, sourceLevels);
			}

			private static TraceSource GetTraceSourceWithListeners(string name, SourceLevels sourceLevels)
			{
				string[] array = name.Split(new char[1] { '.' }, StringSplitOptions.None);
				List<string> list = new List<string>();
				StringBuilder stringBuilder = new StringBuilder();
				string[] array2 = array;
				foreach (string value in array2)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(".");
					}
					stringBuilder.Append(value);
					string item = stringBuilder.ToString();
					list.Add(item);
				}
				list.Reverse();
				foreach (string item2 in list)
				{
					TraceSource traceSource = new TraceSource(item2, sourceLevels);
					traceSource.Listeners.AddRange(AWSConfigs.TraceListeners(item2));
					if (traceSource.Listeners == null || traceSource.Listeners.Count == 0)
					{
						traceSource.Close();
						continue;
					}
					if (traceSource.Listeners.Count > 1)
					{
						return traceSource;
					}
					TraceListener traceListener = traceSource.Listeners[0];
					if (!(traceListener is DefaultTraceListener))
					{
						return traceSource;
					}
					if (!string.Equals(traceListener.Name, "Default", StringComparison.Ordinal))
					{
						return traceSource;
					}
					traceSource.Close();
				}
				return null;
			}
		}

		public string Name { get; } = "Diagnostic";

		public IAdaptorLogger CreateAdaptorLogger(Type type)
		{
			return new DiagnosticAdaptorLogger(TraceSourceUtil.GetTraceSource(type));
		}
	}
}
