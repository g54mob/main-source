using System.Diagnostics;
using UnityEngine;

namespace DebugSystem
{
	public static class GameLog
	{
		public enum LogLevel
		{
			Error = 0,
			Warning = 1,
			Info = 2,
			Verbose = 3
		}

		public static class Network
		{
			public static void Info(string msg, Object ctx = null)
			{
			}

			[Conditional("UNITY_EDITOR")]
			[Conditional("DEVELOPMENT_BUILD")]
			public static void Verbose(string msg, Object ctx = null)
			{
			}

			public static void Warn(string msg, Object ctx = null)
			{
			}

			public static void Error(string msg, Object ctx = null)
			{
			}
		}

		public static class Save
		{
			public static void Info(string msg, Object ctx = null)
			{
			}

			[Conditional("UNITY_EDITOR")]
			[Conditional("DEVELOPMENT_BUILD")]
			public static void Verbose(string msg, Object ctx = null)
			{
			}

			public static void Warn(string msg, Object ctx = null)
			{
			}

			public static void Error(string msg, Object ctx = null)
			{
			}
		}

		public static class Loading
		{
			public static void Info(string msg, Object ctx = null)
			{
			}

			[Conditional("UNITY_EDITOR")]
			[Conditional("DEVELOPMENT_BUILD")]
			public static void Verbose(string msg, Object ctx = null)
			{
			}

			public static void Warn(string msg, Object ctx = null)
			{
			}

			public static void Error(string msg, Object ctx = null)
			{
			}
		}

		public static class UI
		{
			public static void Info(string msg, Object ctx = null)
			{
			}

			[Conditional("UNITY_EDITOR")]
			[Conditional("DEVELOPMENT_BUILD")]
			public static void Verbose(string msg, Object ctx = null)
			{
			}

			public static void Warn(string msg, Object ctx = null)
			{
			}

			public static void Error(string msg, Object ctx = null)
			{
			}
		}

		public static class NPC
		{
			public static void Info(string msg, Object ctx = null)
			{
			}

			[Conditional("UNITY_EDITOR")]
			[Conditional("DEVELOPMENT_BUILD")]
			public static void Verbose(string msg, Object ctx = null)
			{
			}

			public static void Warn(string msg, Object ctx = null)
			{
			}

			public static void Error(string msg, Object ctx = null)
			{
			}
		}

		public static class Inventory
		{
			public static void Info(string msg, Object ctx = null)
			{
			}

			[Conditional("UNITY_EDITOR")]
			[Conditional("DEVELOPMENT_BUILD")]
			public static void Verbose(string msg, Object ctx = null)
			{
			}

			public static void Warn(string msg, Object ctx = null)
			{
			}

			public static void Error(string msg, Object ctx = null)
			{
			}
		}

		public static class Quest
		{
			public static void Info(string msg, Object ctx = null)
			{
			}

			[Conditional("UNITY_EDITOR")]
			[Conditional("DEVELOPMENT_BUILD")]
			public static void Verbose(string msg, Object ctx = null)
			{
			}

			public static void Warn(string msg, Object ctx = null)
			{
			}

			public static void Error(string msg, Object ctx = null)
			{
			}
		}

		public static class Property
		{
			public static void Info(string msg, Object ctx = null)
			{
			}

			[Conditional("UNITY_EDITOR")]
			[Conditional("DEVELOPMENT_BUILD")]
			public static void Verbose(string msg, Object ctx = null)
			{
			}

			public static void Warn(string msg, Object ctx = null)
			{
			}

			public static void Error(string msg, Object ctx = null)
			{
			}
		}

		public static class Placement
		{
			public static void Info(string msg, Object ctx = null)
			{
			}

			[Conditional("UNITY_EDITOR")]
			[Conditional("DEVELOPMENT_BUILD")]
			public static void Verbose(string msg, Object ctx = null)
			{
			}

			public static void Warn(string msg, Object ctx = null)
			{
			}

			public static void Error(string msg, Object ctx = null)
			{
			}
		}

		public static LogLevel MinLevel { get; set; }

		public static bool Enabled { get; set; }

		private static bool IsVerboseEnabled => false;

		private static bool IsQuietMode => false;

		private static bool IsVerboseForCategory(string category)
		{
			return false;
		}

		public static void Error(string category, string message, Object context = null)
		{
		}

		public static void Warn(string category, string message, Object context = null)
		{
		}

		public static void Info(string category, string message, Object context = null)
		{
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		public static void Verbose(string category, string message, Object context = null)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void EditorOnly(string category, string message, Object context = null)
		{
		}
	}
}
