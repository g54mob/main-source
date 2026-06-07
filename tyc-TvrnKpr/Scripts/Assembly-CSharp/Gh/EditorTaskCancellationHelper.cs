using System;
using System.Runtime.InteropServices;

namespace Gh
{
	public static class EditorTaskCancellationHelper
	{
		[StructLayout((LayoutKind)0, Size = 1)]
		public readonly struct TaskContext : IDisposable
		{
			public void Dispose()
			{
			}
		}

		private static int _nestingCount;

		public static bool IsCancelled { get; private set; }

		public static TaskContext BeginTask()
		{
			return default(TaskContext);
		}

		private static void Reset()
		{
		}

		public static bool Show(string title, string detail, int current = 0, int total = 0)
		{
			return false;
		}

		public static bool Show(string title, string detail, float progress)
		{
			return false;
		}
	}
}
