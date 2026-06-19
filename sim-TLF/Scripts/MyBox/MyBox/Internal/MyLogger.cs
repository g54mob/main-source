using System;
using System.IO;
using UnityEngine;

namespace MyBox.Internal
{
	public static class MyLogger
	{
		private static string LogFile;

		private static string TimeFormat;

		public static bool Disabled;

		public const string DefaultFilename = "customLog.txt";

		public const string DefaultTimeFormat = "MM-dd_HH-mm-ss";

		private const int MaxMessageLength = 4000;

		public static string Session { get; private set; }

		public static string Version { get; private set; }

		public static bool LogToConsole { get; set; }

		static MyLogger()
		{
			LogFile = "customLog.txt";
			TimeFormat = "MM-dd_HH-mm-ss";
			AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs args)
			{
				LogException(args.ExceptionObject as Exception);
			};
			Application.logMessageReceived += delegate(string condition, string trace, LogType type)
			{
				Log($"Console Log ({type}): {condition}{Environment.NewLine}{trace}", withStackTrace: false, logToConsole: false);
			};
		}

		public static void InitializeSession(string version = null, string filename = "customLog.txt", string timeFormat = "MM-dd_HH-mm-ss", bool logToConsole = false)
		{
			Session = Guid.NewGuid().ToString();
			Version = version ?? string.Empty;
			LogFile = filename;
			TimeFormat = timeFormat;
			LogToConsole = logToConsole;
			Log("Initialized. " + version);
		}

		public static void Log(string text, bool withStackTrace = false, bool logToConsole = true)
		{
			if (Application.isEditor && LogToConsole && logToConsole)
			{
				Debug.Log("Logger: ".Colored(Colors.brown) + text);
			}
			if (Application.isEditor || Disabled)
			{
				return;
			}
			string path = Path.Combine(Application.dataPath, LogFile);
			if (text.Length > 4000)
			{
				text = text.Substring(0, 4000) + "...<trimmed>";
			}
			if (withStackTrace)
			{
				text = text + Environment.NewLine + Environment.StackTrace;
			}
			try
			{
				if (!File.Exists(path))
				{
					using (StreamWriter streamWriter = File.CreateText(path))
					{
						streamWriter.WriteLine(GetCurrentTime() + " || Log created" + Environment.NewLine);
						streamWriter.WriteLine(GetCurrentTime() + ": " + text);
						return;
					}
				}
				using StreamWriter streamWriter2 = File.AppendText(path);
				streamWriter2.WriteLine(GetCurrentTime() + ": " + text);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			static string GetCurrentTime()
			{
				return DateTime.Now.ToString(TimeFormat);
			}
		}

		private static void LogException(Exception ex)
		{
			Log("Exception:" + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, withStackTrace: false, logToConsole: false);
		}
	}
}
