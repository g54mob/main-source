using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Coherence.Log.Targets;
using UnityEngine;

namespace Coherence.Log
{
	public class Logger : IDisposable
	{
		public delegate void LogDelegate(LogLevel level, bool filtered, string log, Type source, (string key, object value)[] args);

		public const string IDArg = "logId";

		public const string AlertArg = "logAlert";

		private List<ILogTarget> logTargets;

		protected readonly List<(string key, object value)> prefixArgs;

		private object context;

		public bool UseWatermark { get; set; }

		public IReadOnlyList<ILogTarget> LogTargets => null;

		public object Context
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal Type Source { get; }

		protected Logger WithLogger { get; set; }

		public static event LogDelegate OnLog
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

		public Logger(Type source = null, object context = null, IEnumerable<ILogTarget> logTargets = null)
		{
		}

		public void AddLogTarget(ILogTarget logTarget)
		{
		}

		[HideInCallstack]
		protected virtual bool BuildAndPrintLog(LogLevel level, string log, params (string key, object value)[] args)
		{
			return false;
		}

		public virtual Logger With<TSource>()
		{
			return null;
		}

		public virtual Logger With(Type source)
		{
			return null;
		}

		public virtual Logger WithArgs(params (string key, object value)[] args)
		{
			return null;
		}

		public Logger NoWatermark()
		{
			return null;
		}

		[HideInCallstack]
		[Conditional("COHERENCE_LOG_TRACE")]
		public virtual void Trace(string log, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		[Conditional("COHERENCE_LOG_DEBUG")]
		public virtual void Debug(string log, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		public virtual void Info(string log, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		[Obsolete("Log warnings by ID now")]
		public virtual void Warning(string log, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		public virtual void Warning(Warning id, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		public virtual void Warning(Warning id, string msg, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		[Obsolete("Log errors by ID now")]
		public virtual void Error(string log, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		public virtual void Error(Error id, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		public virtual void Error(Error id, string msg, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		[Obsolete("Use specific methods per level now.")]
		public void Log(LogLevel level, string log, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		protected virtual void LogImpl(LogLevel level, string log, params (string key, object value)[] args)
		{
		}

		internal string BuildDefaultLog(LogLevel level, string log, StringBuilder logBuilder, params (string key, object value)[] args)
		{
			return null;
		}

		protected virtual StringBuilder AppendLevel(StringBuilder logBuilder, LogLevel level, bool noTrailingSpace = false)
		{
			return null;
		}

		protected StringBuilder AppendSource(StringBuilder logBuilder)
		{
			return null;
		}

		protected virtual StringBuilder AppendPrefix(StringBuilder logBuilder)
		{
			return null;
		}

		protected virtual StringBuilder AppendTimestamp(StringBuilder logBuilder, bool noTrailingSpace = false)
		{
			return null;
		}

		protected virtual StringBuilder AppendArgs(StringBuilder logBuilder, ICollection<(string key, object value)> args, bool useTab = true)
		{
			return null;
		}

		internal virtual StringBuilder AppendPrefixArgs(StringBuilder logBuilder)
		{
			return null;
		}

		protected virtual (string, object)[] GatherPrefixArgs(params (string key, object value)[] args)
		{
			return null;
		}

		protected (string, object)[] AppendLogID((string key, object value)[] args, object id)
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}
