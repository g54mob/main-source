using System;
using System.Collections.Generic;
using System.Text;

namespace Coherence.Log
{
	public static class LogFormatter
	{
		public static StringBuilder AppendLevel(StringBuilder logBuilder, LogLevel level, bool noTrailingSpace = false)
		{
			return null;
		}

		public static StringBuilder AppendPrefix(StringBuilder logBuilder, bool useWatermark, Type source = null)
		{
			return null;
		}

		public static StringBuilder AppendSource(StringBuilder logBuilder, Type source)
		{
			return null;
		}

		public static StringBuilder AppendTimestamp(StringBuilder logBuilder, bool noTrailingSpace = false)
		{
			return null;
		}

		public static StringBuilder AppendArgs(StringBuilder logBuilder, ICollection<(string key, object value)> args, bool useTab = true)
		{
			return null;
		}
	}
}
