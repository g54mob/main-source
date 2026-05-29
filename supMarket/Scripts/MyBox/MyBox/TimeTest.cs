using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MyBox
{
	public class TimeTest : IDisposable
	{
		private struct TimeTestData
		{
			private readonly string _testTitle;

			private readonly bool _precise;

			public readonly Stopwatch Timer;

			private static readonly StringBuilder StringBuilder;

			public TimeTestData(string testTitle, bool precise)
			{
				_testTitle = null;
				_precise = false;
				Timer = null;
			}

			public void EndTest()
			{
			}
		}

		private static readonly Dictionary<string, TimeTestData> _tests;

		private readonly string _disposableTest;

		private static string _lastStaticTest;

		public TimeTest(string title, bool useMilliseconds = false)
		{
		}

		public void Dispose()
		{
		}

		public static void Start(string title, bool useMilliseconds = false)
		{
		}

		public static void Pause()
		{
		}

		public static void Pause(string title)
		{
		}

		public static void End()
		{
		}

		public static void End(string title)
		{
		}
	}
}
