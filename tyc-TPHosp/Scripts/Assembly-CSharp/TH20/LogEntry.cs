using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public class LogEntry
	{
		public List<LogCallStackFrame> CallStack;

		public LogChannel Channel;

		public string Message;

		public LogLevel Level;

		public UnityEngine.Object RelatedUnityObject;

		public DateTime Time;

		public string TimeFormatted;

		public long FrameCount;

		public LogEntry(UnityEngine.Object relatedUnityObject, LogChannel channel, LogLevel level, List<LogCallStackFrame> callStack, string message, DateTime time, string timeFormatted, long frameCount)
		{
			RelatedUnityObject = relatedUnityObject;
			Channel = channel;
			Level = level;
			Message = message ?? "";
			CallStack = callStack;
			Time = time;
			TimeFormatted = timeFormatted;
			FrameCount = frameCount;
		}

		public string GetTimeStampAsString()
		{
			return TimeFormatted;
		}
	}
}
