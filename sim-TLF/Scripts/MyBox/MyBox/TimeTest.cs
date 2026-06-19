using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

namespace MyBox
{
	public class TimeTest : IDisposable
	{
		private struct TimeTestData
		{
			private readonly string _testTitle;

			private readonly bool _precise;

			public readonly Stopwatch Timer;

			private static readonly StringBuilder StringBuilder = new StringBuilder();

			public TimeTestData(string testTitle, bool precise)
			{
				_testTitle = testTitle;
				_precise = precise;
				Timer = Stopwatch.StartNew();
			}

			public void EndTest()
			{
				long elapsedMilliseconds = Timer.ElapsedMilliseconds;
				float value = (_precise ? ((float)elapsedMilliseconds) : ((float)elapsedMilliseconds / 1000f));
				string value2 = (_precise ? "ms" : "s");
				StringBuilder.Length = 0;
				StringBuilder.Append("Time Test <color=brown>").Append(_testTitle).Append("</color>: ")
					.Append(value)
					.Append(value2);
				UnityEngine.Debug.LogWarning(StringBuilder);
			}
		}

		private static readonly Dictionary<string, TimeTestData> _tests = new Dictionary<string, TimeTestData>();

		private readonly string _disposableTest;

		private static string _lastStaticTest = string.Empty;

		public TimeTest(string title, bool useMilliseconds = false)
		{
			_disposableTest = title;
			_tests[_disposableTest] = new TimeTestData(title, useMilliseconds);
		}

		public void Dispose()
		{
			_tests[_disposableTest].EndTest();
			_tests.Remove(_disposableTest);
		}

		public static void Start(string title, bool useMilliseconds = false)
		{
			if (_tests.ContainsKey(title))
			{
				_tests[title].Timer.Start();
				return;
			}
			_lastStaticTest = title;
			_tests[_lastStaticTest] = new TimeTestData(title, useMilliseconds);
		}

		public static void Pause()
		{
			if (!_tests.ContainsKey(_lastStaticTest))
			{
				UnityEngine.Debug.LogWarning("TimeTest caused: TimeTest.Pause() call. There was no TimeTest.Start()");
			}
			else
			{
				_tests[_lastStaticTest].Timer.Stop();
			}
		}

		public static void Pause(string title)
		{
			if (!_tests.ContainsKey(title))
			{
				UnityEngine.Debug.LogWarning("TimeTest caused: Test Paused but not Started — " + title);
			}
			else
			{
				_tests[title].Timer.Stop();
			}
		}

		public static void End()
		{
			if (!_tests.ContainsKey(_lastStaticTest))
			{
				UnityEngine.Debug.LogWarning("TimeTest caused: TimeTest.End() call. There was no TimeTest.Start()");
				return;
			}
			_tests[_lastStaticTest].EndTest();
			_tests.Remove(_lastStaticTest);
		}

		public static void End(string title)
		{
			if (!_tests.ContainsKey(title))
			{
				UnityEngine.Debug.LogWarning("TimeTest caused: Test not found — " + title);
				return;
			}
			_tests[title].EndTest();
			_tests.Remove(title);
			_lastStaticTest = string.Empty;
		}
	}
}
