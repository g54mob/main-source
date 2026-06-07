using System;
using System.Collections.Generic;
using System.Diagnostics;
using Coherence.Log.Targets;

namespace Coherence.Log
{
	public static class Log
	{
		public enum FilterMode
		{
			Include = 0,
			Exclude = 1
		}

		private static readonly object lockObject;

		private static bool didParseCLIArgs;

		private static bool didCheckForLevelDefines;

		private static ILogTarget consoleTarget;

		private static FileTarget fileTarget;

		private static Settings settings;

		private static List<ILogTarget> baseTargets;

		private static Func<Type, Logger> LoggerSource;

		internal static FilterMode SourceFilterMode => default(FilterMode);

		internal static string[] SourceFilters => null;

		public static Settings GetSettings()
		{
			return null;
		}

		private static void Init()
		{
		}

		private static void InitSettings()
		{
		}

		private static void InitFileTarget()
		{
		}

		private static void InitConsoleTarget()
		{
		}

		private static void ParseCLIArgs()
		{
		}

		private static void CheckForLevelDefines()
		{
		}

		private static void CheckForTraceDefine()
		{
		}

		private static void CheckForDebugDefine()
		{
		}

		[Conditional("COHERENCE_LOG_TRACE")]
		private static void HasTraceDefine(ref bool has)
		{
		}

		[Conditional("COHERENCE_LOG_DEBUG")]
		private static void HasDebugDefine(ref bool has)
		{
		}

		public static Logger GetLogger<TSource>(object context = null)
		{
			return null;
		}

		public static Logger GetLogger(Type source, object context = null)
		{
			return null;
		}
	}
}
