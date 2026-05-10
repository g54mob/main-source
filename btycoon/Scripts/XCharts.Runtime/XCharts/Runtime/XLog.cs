using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;

namespace XCharts.Runtime
{
	public class XLog : MonoBehaviour
	{
		public const int ALL = 0;

		public const int WARNING = 1;

		public const int DEBUG = 2;

		public const int INFO = 3;

		public const int PROTO = 4;

		public const int VITAL = 5;

		public const int ERROR = 6;

		public const int EXCEPTION = 7;

		private const int MAX_ERROR_LOG = 20;

		public static bool isReportBug = false;

		public static bool isOutputLog = false;

		public static bool isUploadLog = false;

		public static bool isCloseOutLog = false;

		public static int errorCount = 0;

		public static int exceptCount = 0;

		public static int uploadTick = 20;

		public static int reportTick = 10;

		private static bool initFileSuccess = false;

		private static bool[] levelList = new bool[8] { true, true, true, true, true, true, true, true };

		private static List<string> writeList = new List<string>();

		private static float uploadTime = 0f;

		private static float reportTime = 0f;

		private string outpath;

		private StreamWriter writer;

		private string[] temp;

		public int logCount;

		public static List<string> errorList = new List<string>();

		private static object m_Lock = new object();

		private static XLog m_Instance;

		public static XLog Instance => m_Instance;

		private void Awake()
		{
			if (m_Instance != null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			m_Instance = this;
			InitLogFile();
			Application.logMessageReceivedThreaded += HandleLog;
		}

		private void OnDestroy()
		{
			if (writer != null)
			{
				writer.Close();
				writer.Dispose();
			}
			Application.logMessageReceivedThreaded -= HandleLog;
		}

		private void Update()
		{
			uploadTime += Time.deltaTime;
			reportTime += Time.deltaTime;
			lock (m_Lock)
			{
				if (writeList.Count <= 0)
				{
					return;
				}
				logCount = writeList.Count;
				if (!initFileSuccess)
				{
					writeList.Clear();
					return;
				}
				try
				{
					temp = writeList.ToArray();
					int num = 0;
					string[] array = temp;
					foreach (string text in array)
					{
						num++;
						writer.WriteLine(text);
						writeList.Remove(text);
						if (num > 10)
						{
							break;
						}
					}
					writer.Flush();
				}
				catch (Exception ex)
				{
					initFileSuccess = false;
					Application.logMessageReceivedThreaded -= HandleLog;
					UnityEngine.Debug.LogError("write outlog.txt error:" + ex.Message);
				}
			}
		}

		private void InitLogFile()
		{
			ClearAllLog();
			EnableLog(0);
			if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
			{
				ClearAllLog();
				EnableLog(5);
				EnableLog(6);
				isReportBug = true;
				isUploadLog = true;
			}
			else
			{
				isUploadLog = false;
				isReportBug = false;
			}
			outpath = GetLogOutputPath();
			try
			{
				if (File.Exists(outpath))
				{
					File.Delete(outpath);
				}
				writer = new StreamWriter(outpath, append: false, Encoding.UTF8);
				writer.WriteLine(GetNowTime() + "init file success!!");
				UnityEngine.Debug.Log(GetNowTime() + "init file success:" + outpath);
				writer.Flush();
				initFileSuccess = true;
			}
			catch (Exception ex)
			{
				initFileSuccess = false;
				Application.logMessageReceived -= HandleLog;
				UnityEngine.Debug.LogError("write outlog.txt error:" + ex.Message);
			}
		}

		private static string GetLogOutputPath()
		{
			string text = Application.persistentDataPath + "/outlog.txt";
			if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
			{
				return Application.persistentDataPath + "/outlog.txt";
			}
			return Application.dataPath + "/../outlog.txt";
		}

		private void HandleLog(string logString, string stackTrace, LogType type)
		{
			lock (m_Lock)
			{
				if (!initFileSuccess)
				{
					return;
				}
				int num = logString.IndexOf("stack traceback");
				if (num > 0)
				{
					string text = logString.Substring(0, num);
					string text2 = logString.Substring(num, logString.Length - num);
					logString = text;
					stackTrace = text2;
				}
				switch (type)
				{
				case LogType.Error:
					if (logString.IndexOf("LUA ERROR") > 0 || logString.IndexOf("stack traceback") > 0)
					{
						exceptCount++;
					}
					else
					{
						errorCount++;
					}
					writeList.Add(logString);
					if (errorList.Count >= 20)
					{
						errorList.RemoveAt(1);
					}
					if (errorList.Count < 20)
					{
						errorList.Add(logString);
					}
					break;
				case LogType.Exception:
					exceptCount++;
					writeList.Add(logString);
					writeList.Add(stackTrace + "\n");
					if (errorList.Count >= 20)
					{
						errorList.RemoveAt(1);
					}
					if (errorList.Count < 20)
					{
						errorList.Add(logString);
						errorList.Add(stackTrace + "\n");
					}
					break;
				}
			}
		}

		public static void FlushLog()
		{
			XLog instance = Instance;
			if (instance != null && instance.writer != null)
			{
				for (int i = 0; i < writeList.Count; i++)
				{
					instance.writer.WriteLine(writeList[i]);
				}
				instance.writer.Flush();
				writeList.Clear();
			}
		}

		public static void EnableLog(int logType)
		{
			if (logType >= 0 && logType < levelList.Length)
			{
				levelList[logType] = true;
			}
		}

		public static void ClearAllLog()
		{
			for (int i = 0; i < levelList.Length; i++)
			{
				levelList[i] = false;
			}
		}

		public static bool CanLog(int level)
		{
			if (level < 0 || level >= levelList.Length)
			{
				return false;
			}
			if (!levelList[level])
			{
				return levelList[0];
			}
			return true;
		}

		public static void Log(string log)
		{
			Debug(log);
		}

		public static void LogError(string log)
		{
			Error(log);
		}

		public static void LogWarning(string log)
		{
			Warning(log);
		}

		public static void Debug(string log)
		{
			if (CanLog(2))
			{
				UnityEngine.Debug.Log(GetNowTime() + "[DEBUG]\t" + log);
			}
		}

		public static void Vital(string log)
		{
			if (CanLog(3))
			{
				UnityEngine.Debug.Log(GetNowTime() + "[VITAL]\t" + log);
			}
		}

		public static void Info(string log)
		{
			if (CanLog(3))
			{
				UnityEngine.Debug.Log(GetNowTime() + "[INFO]\t" + log);
			}
		}

		public static void Proto(string log)
		{
			if (CanLog(4))
			{
				UnityEngine.Debug.Log(GetNowTime() + "[PROTO]\t" + log);
			}
		}

		public static void Warning(string log)
		{
			if (CanLog(1))
			{
				UnityEngine.Debug.LogWarning(GetNowTime() + "[WARN]\t" + log);
			}
		}

		public static void Error(string log)
		{
			if (CanLog(6))
			{
				UnityEngine.Debug.LogError(GetNowTime() + "[ERROR]\t" + log);
			}
		}

		public static string GetNowTime(string formatter = null)
		{
			DateTime now = DateTime.Now;
			if (formatter == null)
			{
				return now.ToString("[HH:mm:ss fff]", DateTimeFormatInfo.InvariantInfo);
			}
			return now.ToString(formatter, DateTimeFormatInfo.InvariantInfo);
		}

		public static ulong GetTimestamp()
		{
			return (ulong)(DateTime.Now - new DateTime(190, 1, 1, 0, 0, 0, 0)).TotalSeconds;
		}
	}
}
