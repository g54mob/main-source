using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security;
using System.Threading;

namespace MessagePipe
{
	public class StackTraceInfo
	{
		private static bool displayFileNames = true;

		private static int idSeed = 0;

		internal string formattedStackTrace;

		public int Id { get; }

		public DateTimeOffset Timestamp { get; }

		public StackTrace StackTrace { get; }

		public string Head { get; }

		public StackTraceInfo(StackTrace stackTrace)
		{
			Id = Interlocked.Increment(ref idSeed);
			Timestamp = DateTimeOffset.UtcNow;
			StackTrace = stackTrace;
			Head = GetGroupKey(stackTrace);
		}

		internal static string GetGroupKey(StackTrace stackTrace)
		{
			for (int i = 0; i < stackTrace.FrameCount; i++)
			{
				StackFrame frame = stackTrace.GetFrame(i);
				if (frame == null)
				{
					continue;
				}
				MethodBase method = frame.GetMethod();
				if (method == null || method.DeclaringType == null || (method.DeclaringType.Namespace != null && method.DeclaringType.Namespace.StartsWith("MessagePipe")))
				{
					continue;
				}
				if (displayFileNames && frame.GetILOffset() != -1)
				{
					string text = null;
					try
					{
						text = frame.GetFileName();
					}
					catch (NotSupportedException)
					{
						displayFileNames = false;
					}
					catch (SecurityException)
					{
						displayFileNames = false;
					}
					if (text != null)
					{
						return method.DeclaringType.FullName + "." + method.Name + " (at " + Path.GetFileName(text) + ":" + frame.GetFileLineNumber() + ")";
					}
					return method.DeclaringType.FullName + "." + method.Name + " (offset: " + frame.GetILOffset() + ")";
				}
				return method.DeclaringType.FullName + "." + method.Name;
			}
			return "";
		}
	}
}
