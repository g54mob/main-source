using System;
using System.Collections.Generic;
using Coherence.Log.Targets;
using UnityEngine;

namespace Coherence.Log
{
	public class UnityLogger : Logger
	{
		public delegate void OnLogEvent(object context, string message, params (string key, object value)[] args);

		public static OnLogEvent OnLogTraceEvent;

		public static OnLogEvent OnLogDebugEvent;

		public static OnLogEvent OnLogInfoEvent;

		public static OnLogEvent OnLogWarningEvent;

		public static OnLogEvent OnLogErrorEvent;

		private UnityEngine.Object unityLogContext;

		public UnityLogger(Type source = null, IEnumerable<ILogTarget> logTargets = null)
		{
		}

		public override Logger With<TSource>()
		{
			return null;
		}

		public override Logger With(Type source)
		{
			return null;
		}

		public override Logger WithArgs(params (string key, object value)[] args)
		{
			return null;
		}

		[HideInCallstack]
		public override void Trace(string log, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		public override void Debug(string log, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		public override void Info(string log, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		public override void Warning(Warning id, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		public override void Warning(Warning id, string msg, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		public override void Error(Error id, params (string key, object value)[] args)
		{
		}

		[HideInCallstack]
		public override void Error(Error id, string msg, params (string key, object value)[] args)
		{
		}

		internal UnityEngine.Object GetUnityLogContext()
		{
			return null;
		}
	}
}
