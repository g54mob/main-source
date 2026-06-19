using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace TH20
{
	public static class LogCallStack
	{
		private static readonly string[] NewLineStrings = new string[3] { "\r\n", "\r", "\n" };

		[StackTraceIgnore]
		public static List<LogCallStackFrame> GetCallstack()
		{
			List<LogCallStackFrame> callstack = new List<LogCallStackFrame>();
			GetCallstack(ref callstack);
			return callstack;
		}

		[StackTraceIgnore]
		public static void GetCallstack(ref List<LogCallStackFrame> callstack)
		{
			callstack.Clear();
			StackTrace stackTrace = new StackTrace(fNeedFileInfo: true);
			callstack.Capacity = Math.Max(stackTrace.FrameCount, callstack.Capacity);
			for (int i = 0; i < stackTrace.FrameCount; i++)
			{
				StackFrame frame = stackTrace.GetFrame(i);
				MethodBase method = frame.GetMethod();
				if (method.IsDefined(typeof(StackTraceIgnoreAttribute), inherit: true))
				{
					continue;
				}
				string name = method.DeclaringType.Name;
				string name2 = method.Name;
				if (name == "Application" && name2 == "CallLogCallback")
				{
					continue;
				}
				if (name == "DebugLogHandler")
				{
					switch (name2)
					{
					case "Internal_Log":
					case "Log":
					case "LogFormat":
						continue;
					}
				}
				if ((!(name == "Debug") || !(name2 == "Log")) && (!(name == "Logger") || !(name2 == "Log")))
				{
					LogCallStackFrame item = new LogCallStackFrame(frame);
					callstack.Add(item);
				}
			}
		}

		public static List<LogCallStackFrame> GetCallstackFromUnityLog(string unityCallstack)
		{
			string[] array = unityCallstack.Split(NewLineStrings, StringSplitOptions.RemoveEmptyEntries);
			List<LogCallStackFrame> list = new List<LogCallStackFrame>
			{
				Capacity = array.Length
			};
			foreach (string unityStackFrame in array)
			{
				if (!string.IsNullOrEmpty(new LogCallStackFrame(unityStackFrame).FormattedMethodName))
				{
					list.Add(new LogCallStackFrame(unityStackFrame));
				}
			}
			return list;
		}

		public static string CallStackToString(List<LogCallStackFrame> callStack)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < callStack.Count; i++)
			{
				LogCallStackFrame logCallStackFrame = callStack[i];
				stringBuilder.AppendFormat("{0}\n", logCallStackFrame.FormattedMethodName);
			}
			return stringBuilder.ToString();
		}
	}
}
