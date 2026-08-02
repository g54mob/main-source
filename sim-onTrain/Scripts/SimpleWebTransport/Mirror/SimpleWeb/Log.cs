using System;
using UnityEngine;

namespace Mirror.SimpleWeb
{
	public static class Log
	{
		public enum Levels
		{
			none = 0,
			error = 1,
			warn = 2,
			info = 3,
			verbose = 4
		}

		public static ILogger logger = Debug.unityLogger;

		public static Levels level = Levels.none;

		public static string BufferToString(byte[] buffer, int offset = 0, int? length = null)
		{
			return BitConverter.ToString(buffer, offset, length ?? buffer.Length);
		}

		public static void DumpBuffer(string label, byte[] buffer, int offset, int length)
		{
			if (level >= Levels.verbose)
			{
				logger.Log(LogType.Log, "[SimpleWebTransport] VERBOSE: <color=cyan>" + label + ": " + BufferToString(buffer, offset, length) + "</color>");
			}
		}

		public static void DumpBuffer(string label, ArrayBuffer arrayBuffer)
		{
			if (level >= Levels.verbose)
			{
				logger.Log(LogType.Log, "[SimpleWebTransport] VERBOSE: <color=cyan>" + label + ": " + BufferToString(arrayBuffer.array, 0, arrayBuffer.count) + "</color>");
			}
		}

		public static void Verbose(string msg, bool showColor = true)
		{
			if (level >= Levels.verbose)
			{
				if (showColor)
				{
					logger.Log(LogType.Log, "[SimpleWebTransport] VERBOSE: <color=cyan>" + msg + "</color>");
				}
				else
				{
					logger.Log(LogType.Log, "[SimpleWebTransport] VERBOSE: " + msg);
				}
			}
		}

		public static void Info(string msg, bool showColor = true)
		{
			if (level >= Levels.info)
			{
				if (showColor)
				{
					logger.Log(LogType.Log, "[SimpleWebTransport] INFO: <color=cyan>" + msg + "</color>");
				}
				else
				{
					logger.Log(LogType.Log, "[SimpleWebTransport] INFO: " + msg);
				}
			}
		}

		public static void InfoException(Exception e)
		{
			if (level >= Levels.info)
			{
				logger.Log(LogType.Log, "[SimpleWebTransport] INFO_EXCEPTION: <color=cyan>" + e.GetType().Name + "</color> Message: " + e.Message + "\n" + e.StackTrace + "\n\n");
			}
		}

		public static void Warn(string msg, bool showColor = true)
		{
			if (level >= Levels.warn)
			{
				if (showColor)
				{
					logger.Log(LogType.Warning, "[SimpleWebTransport] WARN: <color=orange>" + msg + "</color>");
				}
				else
				{
					logger.Log(LogType.Warning, "[SimpleWebTransport] WARN: " + msg);
				}
			}
		}

		public static void Error(string msg, bool showColor = true)
		{
			if (level >= Levels.error)
			{
				if (showColor)
				{
					logger.Log(LogType.Error, "[SimpleWebTransport] ERROR: <color=red>" + msg + "</color>");
				}
				else
				{
					logger.Log(LogType.Error, "[SimpleWebTransport] ERROR: " + msg);
				}
			}
		}

		public static void Exception(Exception e)
		{
			logger.Log(LogType.Error, "[SimpleWebTransport] EXCEPTION: <color=red>" + e.GetType().Name + "</color> Message: " + e.Message + "\n" + e.StackTrace + "\n\n");
		}
	}
}
