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
				while (true)
				{
					int num;
					int num2;
					if (value)
					{
						num = 2132833533;
						num2 = num;
					}
					else
					{
						num = 2132833530;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x7F2074FF)
						{
						case 0:
							num = 2132833532;
							continue;
						default:
							return;
						case 3:
							break;
						case 1:
							_logToScreen = value;
							num = 2132833531;
							continue;
						case 5:
							if (_guiText != null)
							{
								UnityEngine.Object.Destroy(_guiText.gameObject);
								num = 2132833534;
								continue;
							}
							goto case 1;
						case 2:
						{
							GameObject gameObject = new GameObject("Screen Log");
							_guiText = gameObject.AddComponent<Rewired.Internal.GUIText>();
							_guiText.anchor = TextAnchor.LowerLeft;
							num = 2132833534;
							continue;
						}
						case 4:
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
			if (!requiredThreadSafety && !Application.isEditor)
			{
				return;
			}
			while (UnityTools.isInitialized)
			{
				int num;
				int num2;
				if (UnityTools.isEditor)
				{
					num = -593679545;
					num2 = num;
				}
				else
				{
					num = -593679546;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -593679547)
					{
					case 0:
						num = -593679548;
						continue;
					case 1:
						break;
					case 3:
						return;
					default:
						goto end_IL_002d;
					}
					break;
				}
				continue;
				end_IL_002d:
				break;
			}
			Log(msg, requiredThreadSafety);
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
			goto IL_007b;
			IL_0003:
			int num = -393340439;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ -393340436)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					goto IL_0035;
				case 7:
					return;
				case 5:
					goto IL_0055;
				case 0:
					LogWarning(msg, requiredThreadSafety);
					num = -393340440;
					continue;
				case 6:
					goto IL_007b;
				case 1:
					return;
				case 4:
					return;
				}
				break;
				IL_0055:
				int num2;
				if (!Application.isEditor)
				{
					num = -393340437;
					num2 = num;
				}
				else
				{
					num = -393340438;
					num2 = num;
				}
				continue;
				IL_0035:
				int num3;
				if (UnityTools.isEditor)
				{
					num = -393340436;
					num3 = num;
				}
				else
				{
					num = -393340435;
					num3 = num;
				}
			}
			goto IL_0003;
			IL_007b:
			int num4;
			if (UnityTools.isInitialized)
			{
				num = -393340434;
				num4 = num;
			}
			else
			{
				num = -393340436;
				num4 = num;
			}
			goto IL_0008;
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
				if (!UnityTools.isInitialized)
				{
					num = -1213820800;
					num2 = num;
				}
				else
				{
					num = -1213820795;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1213820799)
					{
					case 3:
						num = -1213820797;
						continue;
					case 2:
						break;
					case 4:
					{
						int num3;
						if (UnityTools.isEditor)
						{
							num = -1213820800;
							num3 = num;
						}
						else
						{
							num = -1213820799;
							num3 = num;
						}
						continue;
					}
					case 0:
						return;
					default:
						LogError(msg, requiredThreadSafety);
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
				if (msg == null)
				{
					msg = string.Empty;
					num = -673930110;
					goto IL_000e;
				}
				goto IL_0069;
				IL_000e:
				while (true)
				{
					switch (num ^ -673930105)
					{
					case 3:
						num = -673930109;
						continue;
					default:
						return;
					case 4:
						break;
					case 0:
						goto IL_0044;
					case 2:
						LogToScreen(msg);
						num = -673930106;
						continue;
					case 5:
						goto IL_0069;
					case 1:
						return;
					}
					break;
					IL_0044:
					int num2;
					if (_logToScreen)
					{
						num = -673930107;
						num2 = num;
					}
					else
					{
						num = -673930106;
						num2 = num;
					}
				}
				continue;
				IL_0069:
				LogNow(msg, requiredThreadSafety);
				num = -673930105;
				goto IL_000e;
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
			goto IL_0056;
			IL_0008:
			int num = 1466999029;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x5770A0F7)
				{
				case 5:
					break;
				default:
					return;
				case 2:
					return;
				case 7:
					if (_logToScreen)
					{
						LogToScreen(msg);
						num = 1466999031;
						continue;
					}
					return;
				case 3:
					goto IL_0056;
				case 4:
					LogWarningNow(msg, requiredThreadSafety);
					num = 1466999024;
					continue;
				case 1:
					goto IL_0075;
				case 6:
					if (!UnityTools.isEditor)
					{
						msg = "[WARNING] " + msg;
						num = 1466999027;
						continue;
					}
					goto case 4;
				case 0:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0056:
			if (msg == null)
			{
				msg = string.Empty;
				num = 1466999030;
				goto IL_000d;
			}
			goto IL_0075;
			IL_0075:
			int num2;
			if (ReInput.isReady)
			{
				num = 1466999025;
				num2 = num;
			}
			else
			{
				num = 1466999027;
				num2 = num;
			}
			goto IL_000d;
		}

		public static void LogError(object msg)
		{
			LogError(msg, false);
		}

		public static void LogError(object msg, bool requiredThreadSafety)
		{
			if (!IsLoggingAllowed(LogLevel.Error))
			{
				goto IL_000b;
			}
			goto IL_00ec;
			IL_000b:
			int num = -891564377;
			goto IL_0010;
			IL_0010:
			object[] array4 = default(object[]);
			object obj2 = default(object);
			object[] array = default(object[]);
			object[] array2 = default(object[]);
			object obj3 = default(object);
			object[] array5 = default(object[]);
			object[] array3 = default(object[]);
			while (true)
			{
				switch (num ^ -891564369)
				{
				case 5:
					break;
				default:
					return;
				case 13:
				{
					msg = string.Concat(msg, "\n------- Rewired System Info -------\n");
					object obj6 = msg;
					array4 = new object[4]
					{
						obj6,
						"Unity version: ",
						UnityTools.unityVersionString,
						"\n"
					};
					num = -891564381;
					continue;
				}
				case 9:
					msg = string.Empty;
					num = -891564380;
					continue;
				case 12:
					msg = string.Concat(array4);
					obj2 = msg;
					array = new object[4];
					num = -891564358;
					continue;
				case 4:
					goto IL_00ec;
				case 6:
					if (ReInput.UserData.ConfigVars != null)
					{
						msg = string.Concat(msg, ReInput.UserData.ConfigVars.GetDebugConfigSettings());
						num = -891564355;
						continue;
					}
					goto IL_028e;
				case 1:
					array2 = new object[4] { obj3, "Platform: ", null, null };
					num = -891564369;
					continue;
				case 8:
					return;
				case 2:
					msg = string.Concat(array5);
					num = -891564379;
					continue;
				case 24:
					msg = "[ERROR] " + msg;
					num = -891564382;
					continue;
				case 21:
					array[0] = obj2;
					num = -891564356;
					continue;
				case 15:
					if (UnityTools.webplayerPlatform != WebplayerPlatform.None)
					{
						object obj4 = msg;
						msg = string.Concat(obj4, "Webplayer Platform: ", UnityTools.webplayerPlatform, "\n");
						num = -891564372;
						continue;
					}
					goto case 3;
				case 11:
					goto IL_01e5;
				case 23:
					obj3 = msg;
					num = -891564370;
					continue;
				case 20:
					goto IL_020d;
				case 16:
					array3[3] = "\n";
					msg = string.Concat(array3);
					num = -891564384;
					continue;
				case 7:
					array3[2] = UnityTools.editorPlatform;
					num = -891564353;
					continue;
				case 10:
					goto IL_025c;
				case 17:
					LogToScreen(msg);
					num = -891564359;
					continue;
				case 18:
					goto IL_028e;
				case 14:
					msg = string.Concat(array);
					num = -891564360;
					continue;
				case 3:
				{
					object obj5 = msg;
					array5 = new object[4]
					{
						obj5,
						"Using Unity input: ",
						ReInput.usingUnityInput,
						"\n"
					};
					num = -891564371;
					continue;
				}
				case 0:
					array2[2] = UnityTools.platform;
					array2[3] = "\n";
					msg = string.Concat(array2);
					if (UnityTools.editorPlatform != EditorPlatform.None)
					{
						object obj = msg;
						array3 = new object[4] { obj, "Editor Platform: ", null, null };
						num = -891564376;
						continue;
					}
					goto case 15;
				case 19:
					array[1] = "Rewired version: ";
					array[2] = ReInput.programVersion;
					array[3] = "\n";
					num = -891564383;
					continue;
				case 22:
					return;
				}
				break;
				IL_025c:
				if (ReInput.isReady)
				{
					int num2;
					if (ReInput.UserData == null)
					{
						num = -891564355;
						num2 = num;
					}
					else
					{
						num = -891564375;
						num2 = num;
					}
					continue;
				}
				goto IL_028e;
				IL_020d:
				int num3;
				if (UnityTools.isEditor)
				{
					num = -891564382;
					num3 = num;
				}
				else
				{
					num = -891564361;
					num3 = num;
				}
				continue;
				IL_01e5:
				int num4;
				if (ReInput.isReady)
				{
					num = -891564357;
					num4 = num;
				}
				else
				{
					num = -891564382;
					num4 = num;
				}
				continue;
				IL_028e:
				LogErrorNow(msg, requiredThreadSafety);
				int num5;
				if (!_logToScreen)
				{
					num = -891564359;
					num5 = num;
				}
				else
				{
					num = -891564354;
					num5 = num;
				}
			}
			goto IL_000b;
			IL_00ec:
			int num6;
			if (msg != null)
			{
				num = -891564380;
				num6 = num;
			}
			else
			{
				num = -891564378;
				num6 = num;
			}
			goto IL_0010;
		}

		private static void LogNow(object msg, bool requireThreadSafety)
		{
			if (requireThreadSafety)
			{
				UnityEngine.Debug.Log(msg);
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!UnityTools.logToDebugLog)
				{
					num = -1613465110;
					num2 = num;
				}
				else
				{
					num = -1613465112;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1613465109)
					{
					case 2:
						num = -1613465106;
						continue;
					default:
						return;
					case 5:
						break;
					case 0:
						return;
					case 1:
						Console.WriteLine(msg);
						num = -1613465105;
						continue;
					case 3:
						UnityEngine.Debug.unityLogger.Log("Rewired", msg);
						num = -1613465109;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		private static void LogWarningNow(object msg, bool requireThreadSafety)
		{
			if (requireThreadSafety)
			{
				UnityEngine.Debug.LogWarning(msg);
				return;
			}
			while (!UnityTools.logToDebugLog)
			{
				while (true)
				{
					IL_004b:
					Console.WriteLine(msg);
					int num = -375732410;
					while (true)
					{
						switch (num ^ -375732410)
						{
						case 2:
							num = -375732409;
							continue;
						default:
							return;
						case 1:
							break;
						case 3:
							goto IL_004b;
						case 0:
							return;
						}
						break;
					}
					break;
				}
			}
			UnityEngine.Debug.unityLogger.LogWarning("Rewired", msg);
		}

		private static void LogErrorNow(object msg, bool requireThreadSafety)
		{
			if (requireThreadSafety)
			{
				UnityEngine.Debug.LogError(msg);
				return;
			}
			while (!UnityTools.logToDebugLog)
			{
				while (true)
				{
					IL_004b:
					Console.WriteLine(msg);
					int num = 2026420944;
					while (true)
					{
						switch (num ^ 0x78C8BAD1)
						{
						case 2:
							num = 2026420946;
							continue;
						default:
							return;
						case 3:
							break;
						case 0:
							goto IL_004b;
						case 1:
							return;
						}
						break;
					}
					break;
				}
			}
			UnityEngine.Debug.unityLogger.LogError("Rewired", msg);
		}

		private static bool IsLoggingAllowed(LogLevel logLevel)
		{
			switch (logLevel)
			{
			default:
				while (true)
				{
					switch (-1801713721 ^ -1801713724)
					{
					case 0:
						break;
					case 2:
						goto end_IL_0018;
					case 3:
						throw new NotImplementedException();
					default:
						goto end_IL_0003;
					}
					continue;
					end_IL_0018:
					break;
				}
				goto case LogLevel.Info;
			case LogLevel.Info:
				if ((Logger.logLevel & LogLevelFlags.Info) != LogLevelFlags.Off)
				{
					return true;
				}
				break;
			case LogLevel.Warning:
				if ((Logger.logLevel & LogLevelFlags.Warning) != LogLevelFlags.Off)
				{
					return true;
				}
				break;
			case LogLevel.Error:
				if ((Logger.logLevel & LogLevelFlags.Error) != LogLevelFlags.Off)
				{
					return true;
				}
				break;
			case LogLevel.Debug:
				{
					if ((Logger.logLevel & LogLevelFlags.Debug) != LogLevelFlags.Off)
					{
						return true;
					}
					break;
				}
				end_IL_0003:
				break;
			}
			return false;
		}

		private static void LogToScreen(object msg)
		{
			if (msg == null)
			{
				return;
			}
			int num2 = default(int);
			int num3 = default(int);
			string[] array = default(string[]);
			while (true)
			{
				string text = msg.ToString();
				int num = -130626574;
				while (true)
				{
					switch (num ^ -130626567)
					{
					case 13:
						num = -130626570;
						continue;
					default:
						return;
					case 6:
						screenLog.Add(text);
						num = -130626576;
						continue;
					case 11:
						if (Regex.IsMatch(text, "(\r\n|\r|\n)"))
						{
							Regex.Replace(text, "(\r\n|\r|\n)", "\n");
							num = -130626566;
							continue;
						}
						goto case 6;
					case 1:
						num2++;
						num = -130626573;
						continue;
					case 14:
					{
						Rewired.Internal.GUIText guiText = _guiText;
						guiText.text = guiText.text + screenLog[num3] + "\n";
						num3++;
						num = -130626571;
						continue;
					}
					case 15:
						break;
					case 9:
					{
						int num4 = screenLog.Count - 50;
						if (num4 > 0)
						{
							screenLog.RemoveRange(0, num4);
							num = -130626575;
							continue;
						}
						goto case 8;
					}
					case 2:
					{
						int num6;
						if (!string.IsNullOrEmpty(array[num2]))
						{
							num = -130626562;
							num6 = num;
						}
						else
						{
							num = -130626568;
							num6 = num;
						}
						continue;
					}
					case 12:
					{
						int num5;
						if (num3 < screenLog.Count)
						{
							num = -130626569;
							num5 = num;
						}
						else
						{
							num = -130626564;
							num5 = num;
						}
						continue;
					}
					case 3:
						array = text.Split('\n');
						num2 = 0;
						num = -130626573;
						continue;
					case 10:
						if (num2 >= array.Length)
						{
							num = -130626576;
							continue;
						}
						goto case 4;
					case 0:
						if (screenLog.Count > 0)
						{
							num3 = 0;
							num = -130626571;
							continue;
						}
						return;
					case 7:
						screenLog.Add(array[num2]);
						num = -130626568;
						continue;
					case 4:
						if (!string.IsNullOrEmpty(array[num2]))
						{
							array[num2] = array[num2].Trim();
							num = -130626565;
							continue;
						}
						goto case 1;
					case 8:
						_guiText.text = "";
						num = -130626567;
						continue;
					case 5:
						return;
					}
					break;
				}
			}
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
