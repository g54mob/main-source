using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Rewired.Config;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class Logger
	{
		private const int screenLogLength = 50;

		private static List<string> __screenLog;

		private static Rewired.Internal.GUIText _guiText;

		private static bool _logToScreen;

		private static List<string> screenLog
		{
			get
			{
				return __screenLog ?? (__screenLog = new List<string>());
			}
		}

		private static LogLevelFlags logLevel
		{
			get
			{
				if (!ReInput.isReady || ReInput.configVars == null)
				{
					return LogLevelFlags.Info | LogLevelFlags.Warning | LogLevelFlags.Error;
				}
				return ReInput.configVars.logLevel;
			}
		}

		public static bool logToScreen
		{
			get
			{
				return _logToScreen;
			}
			set
			{
				if (value == _logToScreen)
				{
					return;
				}
				GameObject gameObject = default(GameObject);
				while (true)
				{
					int num;
					int num2;
					if (value)
					{
						num = 1131258912;
						num2 = num;
					}
					else
					{
						num = 1131258915;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x436DA423)
						{
						case 4:
							num = 1131258918;
							continue;
						default:
							return;
						case 1:
							_guiText = gameObject.AddComponent<Rewired.Internal.GUIText>();
							_guiText.anchor = TextAnchor.LowerLeft;
							num = 1131258917;
							continue;
						case 0:
							if (_guiText != null)
							{
								UnityEngine.Object.Destroy(_guiText.gameObject);
								num = 1131258917;
								continue;
							}
							goto case 6;
						case 5:
							break;
						case 3:
							gameObject = new GameObject("Screen Log");
							num = 1131258914;
							continue;
						case 6:
							_logToScreen = value;
							num = 1131258913;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		public static void LogEditor(object msg)
		{
			LogEditor(msg, false);
		}

		public static void LogEditor(object msg, bool requiredThreadSafety)
		{
			if ((requiredThreadSafety || Application.isEditor) && (!UnityTools.isInitialized || UnityTools.isEditor))
			{
				Log(msg, requiredThreadSafety);
			}
		}

		public static void LogWarningEditor(object msg)
		{
			LogWarningEditor(msg, false);
		}

		public static void LogWarningEditor(object msg, bool requiredThreadSafety)
		{
			if (!requiredThreadSafety)
			{
				goto IL_0003;
			}
			goto IL_0031;
			IL_0003:
			int num = 2079750527;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x7BF6797D)
			{
			case 0:
				break;
			case 4:
				return;
			case 3:
				goto IL_0031;
			case 2:
				if (!Application.isEditor)
				{
					return;
				}
				goto IL_0031;
			default:
				goto IL_005f;
			}
			goto IL_0003;
			IL_005f:
			LogWarning(msg, requiredThreadSafety);
			return;
			IL_0031:
			if (UnityTools.isInitialized)
			{
				int num2;
				if (!UnityTools.isEditor)
				{
					num = 2079750521;
					num2 = num;
				}
				else
				{
					num = 2079750524;
					num2 = num;
				}
				goto IL_0008;
			}
			goto IL_005f;
		}

		public static void LogErrorEditor(object msg)
		{
			LogErrorEditor(msg, false);
		}

		public static void LogErrorEditor(object msg, bool requiredThreadSafety)
		{
			if (!requiredThreadSafety && !Application.isEditor)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (UnityTools.isInitialized)
				{
					num = -1480691854;
					num2 = num;
				}
				else
				{
					num = -1480691856;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1480691854)
					{
					case 4:
						num = -1480691853;
						continue;
					default:
						return;
					case 1:
						break;
					case 2:
						LogError(msg, requiredThreadSafety);
						num = -1480691855;
						continue;
					case 0:
						if (!UnityTools.isEditor)
						{
							return;
						}
						goto case 2;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public static void Log(object msg)
		{
			Log(msg, false);
		}

		public static void Log(object msg, bool requiredThreadSafety)
		{
			if (!IsLoggingAllowed(LogLevel.Info))
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (msg != null)
				{
					num = -136104245;
					num2 = num;
				}
				else
				{
					num = -136104248;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -136104246)
					{
					case 0:
						num = -136104247;
						continue;
					default:
						return;
					case 3:
						break;
					case 4:
						LogToScreen(msg);
						num = -136104241;
						continue;
					case 2:
						msg = string.Empty;
						num = -136104245;
						continue;
					case 1:
					{
						LogNow(msg, requiredThreadSafety);
						int num3;
						if (!_logToScreen)
						{
							num = -136104241;
							num3 = num;
						}
						else
						{
							num = -136104242;
							num3 = num;
						}
						continue;
					}
					case 5:
						return;
					}
					break;
				}
			}
		}

		public static void LogWarning(object msg)
		{
			LogWarning(msg, false);
		}

		public static void LogWarning(object msg, bool requiredThreadSafety)
		{
			if (!IsLoggingAllowed(LogLevel.Warning))
			{
				goto IL_0008;
			}
			goto IL_0082;
			IL_0008:
			int num = -511252420;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -511252418)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					return;
				case 3:
					goto IL_003e;
				case 4:
					if (_logToScreen)
					{
						LogToScreen(msg);
						num = -511252417;
						continue;
					}
					return;
				case 5:
					goto IL_0060;
				case 6:
					goto IL_0082;
				case 1:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0060:
			if (ReInput.isReady && !UnityTools.isEditor)
			{
				msg = "[WARNING] " + msg;
				num = -511252419;
				goto IL_000d;
			}
			goto IL_003e;
			IL_003e:
			LogWarningNow(msg, requiredThreadSafety);
			num = -511252422;
			goto IL_000d;
			IL_0082:
			if (msg == null)
			{
				msg = string.Empty;
				num = -511252421;
				goto IL_000d;
			}
			goto IL_0060;
		}

		public static void LogError(object msg)
		{
			LogError(msg, false);
		}

		public static void LogError(object msg, bool requiredThreadSafety)
		{
			if (!IsLoggingAllowed(LogLevel.Error))
			{
				return;
			}
			object[] array2 = default(object[]);
			object obj2 = default(object);
			object[] array = default(object[]);
			object obj4 = default(object);
			object[] array4 = default(object[]);
			object[] array6 = default(object[]);
			object obj6 = default(object);
			object[] array5 = default(object[]);
			object[] array3 = default(object[]);
			while (true)
			{
				IL_02e9:
				int num;
				if (msg == null)
				{
					msg = string.Empty;
					num = -68693325;
					goto IL_0011;
				}
				goto IL_00de;
				IL_0011:
				while (true)
				{
					switch (num ^ -68693344)
					{
					case 15:
						num = -68693339;
						continue;
					default:
						return;
					case 10:
						if (ReInput.isReady && ReInput.UserData != null && ReInput.UserData.ConfigVars != null)
						{
							msg = string.Concat(msg, ReInput.UserData.ConfigVars.GetDebugConfigSettings());
							num = -68693333;
							continue;
						}
						goto case 11;
					case 6:
						array2 = new object[4] { obj2, "Using Unity input: ", null, null };
						num = -68693336;
						continue;
					case 19:
						break;
					case 4:
						array[3] = "\n";
						msg = string.Concat(array);
						num = -68693331;
						continue;
					case 0:
						goto IL_011f;
					case 12:
						goto IL_0136;
					case 14:
						obj4 = msg;
						array4 = new object[4];
						num = -68693337;
						continue;
					case 16:
						array6[0] = obj6;
						array6[1] = "Platform: ";
						array6[2] = UnityTools.platform;
						num = -68693332;
						continue;
					case 2:
						msg = string.Concat(array5);
						obj6 = msg;
						array6 = new object[4];
						num = -68693328;
						continue;
					case 9:
						msg = string.Concat(array2);
						num = -68693334;
						continue;
					case 7:
					{
						array4[0] = obj4;
						array4[1] = "Unity version: ";
						array4[2] = UnityTools.unityVersionString;
						array4[3] = "\n";
						msg = string.Concat(array4);
						object obj5 = msg;
						array5 = new object[4]
						{
							obj5,
							"Rewired version: ",
							ReInput.programVersion,
							"\n"
						};
						num = -68693342;
						continue;
					}
					case 21:
						msg = string.Concat(array3);
						num = -68693341;
						continue;
					case 20:
						array3[3] = "\n";
						num = -68693323;
						continue;
					case 17:
					{
						object obj3 = msg;
						array3 = new object[4] { obj3, "Editor Platform: ", null, null };
						num = -68693343;
						continue;
					}
					case 13:
						obj2 = msg;
						num = -68693338;
						continue;
					case 1:
						array3[2] = UnityTools.editorPlatform;
						num = -68693324;
						continue;
					case 8:
						array2[2] = ReInput.usingUnityInput;
						array2[3] = "\n";
						num = -68693335;
						continue;
					case 3:
						if (UnityTools.webplayerPlatform != WebplayerPlatform.None)
						{
							object obj = msg;
							array = new object[4]
							{
								obj,
								"Webplayer Platform: ",
								UnityTools.webplayerPlatform,
								null
							};
							num = -68693340;
							continue;
						}
						goto case 13;
					case 5:
						goto IL_02e9;
					case 11:
						LogErrorNow(msg, requiredThreadSafety);
						if (_logToScreen)
						{
							LogToScreen(msg);
							num = -68693326;
							continue;
						}
						return;
					case 18:
						return;
					}
					break;
					IL_0136:
					array6[3] = "\n";
					msg = string.Concat(array6);
					int num2;
					if (UnityTools.editorPlatform == EditorPlatform.None)
					{
						num = -68693341;
						num2 = num;
					}
					else
					{
						num = -68693327;
						num2 = num;
					}
				}
				goto IL_00de;
				IL_00de:
				if (ReInput.isReady && !UnityTools.isEditor)
				{
					msg = "[ERROR] " + msg;
					num = -68693344;
					goto IL_0011;
				}
				goto IL_011f;
				IL_011f:
				msg = string.Concat(msg, "\n------- Rewired System Info -------\n");
				num = -68693330;
				goto IL_0011;
			}
		}

		private static void LogNow(object msg, bool requireThreadSafety)
		{
			if (requireThreadSafety)
			{
				goto IL_0003;
			}
			goto IL_003a;
			IL_0003:
			int num = -1052122265;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ -1052122267)
				{
				case 0:
					break;
				case 2:
					UnityEngine.Debug.Log(msg);
					num = -1052122266;
					continue;
				case 5:
					goto IL_003a;
				case 4:
					UnityEngine.Debug.unityLogger.Log("Rewired", msg);
					return;
				case 3:
					return;
				default:
					Console.WriteLine(msg);
					return;
				}
				break;
			}
			goto IL_0003;
			IL_003a:
			int num2;
			if (!UnityTools.logToDebugLog)
			{
				num = -1052122268;
				num2 = num;
			}
			else
			{
				num = -1052122271;
				num2 = num;
			}
			goto IL_0008;
		}

		private static void LogWarningNow(object msg, bool requireThreadSafety)
		{
			if (requireThreadSafety)
			{
				UnityEngine.Debug.LogWarning(msg);
			}
			else if (UnityTools.logToDebugLog)
			{
				UnityEngine.Debug.unityLogger.LogWarning("Rewired", msg);
			}
			else
			{
				Console.WriteLine(msg);
			}
		}

		private static void LogErrorNow(object msg, bool requireThreadSafety)
		{
			if (requireThreadSafety)
			{
				UnityEngine.Debug.LogError(msg);
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!UnityTools.logToDebugLog)
				{
					num = 1518336839;
					num2 = num;
				}
				else
				{
					num = 1518336838;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x5A7FFB45)
					{
					case 0:
						goto IL_000a;
					case 1:
						break;
					case 3:
						UnityEngine.Debug.unityLogger.LogError("Rewired", msg);
						return;
					default:
						Console.WriteLine(msg);
						return;
					}
					break;
					IL_000a:
					num = 1518336836;
				}
			}
		}

		private static bool IsLoggingAllowed(LogLevel logLevel)
		{
			while (true)
			{
				int num = 708052345;
				while (true)
				{
					int num2;
					switch (num ^ 0x2A340578)
					{
					case 3:
						break;
					case 1:
						switch (logLevel)
						{
						case LogLevel.Info:
							break;
						case LogLevel.Warning:
							goto IL_0052;
						case LogLevel.Error:
							goto IL_005d;
						case LogLevel.Debug:
							goto IL_0079;
						default:
							throw new NotImplementedException();
						}
						goto case 4;
					case 4:
						if ((Logger.logLevel & LogLevelFlags.Info) != LogLevelFlags.Off)
						{
							return true;
						}
						goto default;
					case 2:
						return true;
					default:
						{
							return false;
						}
						IL_0079:
						if ((Logger.logLevel & LogLevelFlags.Debug) != LogLevelFlags.Off)
						{
							return true;
						}
						goto default;
						IL_0052:
						if ((Logger.logLevel & LogLevelFlags.Warning) != LogLevelFlags.Off)
						{
							return true;
						}
						goto default;
						IL_005d:
						if ((Logger.logLevel & LogLevelFlags.Error) == 0)
						{
							num = 708052344;
							num2 = num;
						}
						else
						{
							num = 708052346;
							num2 = num;
						}
						continue;
					}
					break;
				}
			}
		}

		private static void LogToScreen(object msg)
		{
			if (msg == null)
			{
				goto IL_0006;
			}
			goto IL_00e5;
			IL_0006:
			int num = 1293044097;
			goto IL_000b;
			IL_000b:
			int num3 = default(int);
			string[] array = default(string[]);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x4D124987)
				{
				case 8:
					break;
				default:
					return;
				case 6:
					return;
				case 4:
					goto IL_005f;
				case 5:
					if (screenLog.Count > 0)
					{
						num3 = 0;
						num = 1293044099;
						continue;
					}
					return;
				case 11:
					goto IL_009b;
				case 0:
				{
					int num4 = screenLog.Count - 50;
					if (num4 > 0)
					{
						screenLog.RemoveRange(0, num4);
						num = 1293044110;
						continue;
					}
					goto case 9;
				}
				case 12:
					num = 1293044103;
					continue;
				case 1:
					goto IL_00e5;
				case 13:
					goto IL_012d;
				case 2:
					if (!string.IsNullOrEmpty(array[num2]))
					{
						screenLog.Add(array[num2]);
						num = 1293044100;
						continue;
					}
					goto case 3;
				case 10:
				{
					Rewired.Internal.GUIText guiText = _guiText;
					guiText.text = guiText.text + screenLog[num3] + "\n";
					num3++;
					num = 1293044099;
					continue;
				}
				case 3:
					num2++;
					num = 1293044106;
					continue;
				case 9:
					_guiText.text = "";
					num = 1293044098;
					continue;
				case 7:
					if (!string.IsNullOrEmpty(array[num2]))
					{
						array[num2] = array[num2].Trim();
						num = 1293044101;
						continue;
					}
					goto case 3;
				case 14:
					return;
				}
				break;
				IL_012d:
				int num5;
				if (num2 >= array.Length)
				{
					num = 1293044107;
					num5 = num;
				}
				else
				{
					num = 1293044096;
					num5 = num;
				}
				continue;
				IL_005f:
				int num6;
				if (num3 >= screenLog.Count)
				{
					num = 1293044105;
					num6 = num;
				}
				else
				{
					num = 1293044109;
					num6 = num;
				}
			}
			goto IL_0006;
			IL_009b:
			string text = default(string);
			screenLog.Add(text);
			num = 1293044103;
			goto IL_000b;
			IL_00e5:
			text = msg.ToString();
			if (Regex.IsMatch(text, "(\r\n|\r|\n)"))
			{
				Regex.Replace(text, "(\r\n|\r|\n)", "\n");
				array = text.Split('\n');
				num2 = 0;
				num = 1293044106;
				goto IL_000b;
			}
			goto IL_009b;
		}

		[Conditional("LOG_INIT")]
		public static void LogInit(object o)
		{
			Log(o, true);
		}

		[Conditional("LOG_INIT")]
		public static void LogInitError(object o)
		{
			LogError(o, true);
		}

		[Conditional("LOG_INIT")]
		public static void LogInitWarning(object o)
		{
			LogWarning(o, true);
		}

		[Conditional("LOG_VC")]
		public static void Log_VCTest(object o)
		{
			Log(o);
		}

		[Conditional("LOG_UPDATE")]
		public static void LogUpdate(object o)
		{
			Log(o, true);
		}
	}
}
