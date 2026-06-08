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
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal static class Logger
	{
		private const int screenLogLength = 50;

		private static List<string> __screenLog;

		private static Rewired.Internal.GUIText _guiText;

		private static bool _logToScreen;

		private static List<string> screenLog => __screenLog ?? (__screenLog = new List<string>());

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
					if (value)
					{
						GameObject gameObject = new GameObject("Screen Log");
						_guiText = gameObject.AddComponent<Rewired.Internal.GUIText>();
						_guiText.anchor = TextAnchor.LowerLeft;
						num = -1224058275;
						goto IL_000e;
					}
					goto IL_0067;
					IL_005a:
					_logToScreen = value;
					num = -1224058273;
					goto IL_000e;
					IL_0067:
					if (_guiText != null)
					{
						UnityEngine.Object.Destroy(_guiText.gameObject);
						num = -1224058275;
						goto IL_000e;
					}
					goto IL_005a;
					IL_000e:
					while (true)
					{
						switch (num ^ -1224058274)
						{
						case 0:
							num = -1224058278;
							continue;
						default:
							return;
						case 4:
							break;
						case 3:
							goto IL_005a;
						case 2:
							goto IL_0067;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		public static void LogEditor(object msg)
		{
			LogEditor(msg, requiredThreadSafety: false);
		}

		public static void LogEditor(object msg, bool requiredThreadSafety)
		{
			if (!requiredThreadSafety && !Application.isEditor)
			{
				while (true)
				{
					switch (-437631160 ^ -437631159)
					{
					case 0:
						break;
					case 1:
						return;
					case 2:
						goto end_IL_000a;
					default:
						goto IL_004a;
					}
					continue;
					end_IL_000a:
					break;
				}
			}
			if (UnityTools.isInitialized && !UnityTools.isEditor)
			{
				return;
			}
			goto IL_004a;
			IL_004a:
			Log(msg, requiredThreadSafety);
		}

		public static void LogWarningEditor(object msg)
		{
			LogWarningEditor(msg, requiredThreadSafety: false);
		}

		public static void LogWarningEditor(object msg, bool requiredThreadSafety)
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
					num = -2058006714;
					num2 = num;
				}
				else
				{
					num = -2058006713;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -2058006715)
					{
					case 0:
						num = -2058006716;
						continue;
					default:
						return;
					case 3:
						LogWarning(msg, requiredThreadSafety);
						num = -2058006719;
						continue;
					case 2:
						if (!UnityTools.isEditor)
						{
							return;
						}
						goto case 3;
					case 1:
						break;
					case 4:
						return;
					}
					break;
				}
			}
		}

		public static void LogErrorEditor(object msg)
		{
			LogErrorEditor(msg, requiredThreadSafety: false);
		}

		public static void LogErrorEditor(object msg, bool requiredThreadSafety)
		{
			if (!requiredThreadSafety)
			{
				while (true)
				{
					int num = 1815628960;
					while (true)
					{
						switch (num ^ 0x6C384CA1)
						{
						case 2:
							break;
						case 3:
							goto end_IL_0003;
						case 4:
							return;
						case 1:
							goto IL_0047;
						default:
							goto IL_005f;
						}
						break;
						IL_0047:
						int num2;
						if (!Application.isEditor)
						{
							num = 1815628965;
							num2 = num;
						}
						else
						{
							num = 1815628962;
							num2 = num;
						}
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			if (UnityTools.isInitialized && !UnityTools.isEditor)
			{
				return;
			}
			goto IL_005f;
			IL_005f:
			LogError(msg, requiredThreadSafety);
		}

		public static void Log(object msg)
		{
			Log(msg, requiredThreadSafety: false);
		}

		public static void Log(object msg, bool requiredThreadSafety)
		{
			if (!IsLoggingAllowed(LogLevel.Info))
			{
				goto IL_0008;
			}
			goto IL_003e;
			IL_0008:
			int num = -1982059207;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -1982059203)
				{
				case 0:
					break;
				default:
					return;
				case 4:
					return;
				case 1:
					goto IL_003e;
				case 2:
					LogNow(msg, requiredThreadSafety);
					num = -1982059202;
					continue;
				case 3:
					if (_logToScreen)
					{
						LogToScreen(msg);
						num = -1982059208;
						continue;
					}
					return;
				case 6:
					msg = string.Empty;
					num = -1982059201;
					continue;
				case 5:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_003e:
			int num2;
			if (msg == null)
			{
				num = -1982059205;
				num2 = num;
			}
			else
			{
				num = -1982059201;
				num2 = num;
			}
			goto IL_000d;
		}

		public static void LogWarning(object msg)
		{
			LogWarning(msg, requiredThreadSafety: false);
		}

		public static void LogWarning(object msg, bool requiredThreadSafety)
		{
			if (!IsLoggingAllowed(LogLevel.Warning))
			{
				goto IL_0008;
			}
			goto IL_0086;
			IL_0008:
			int num = 1186204132;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x46B409E3)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					goto IL_003a;
				case 0:
					goto IL_0052;
				case 5:
					msg = "[WARNING] " + msg;
					num = 1186204135;
					continue;
				case 7:
					return;
				case 3:
					goto IL_0086;
				case 4:
					LogWarningNow(msg, requiredThreadSafety);
					if (_logToScreen)
					{
						LogToScreen(msg);
						num = 1186204133;
						continue;
					}
					return;
				case 6:
					return;
				}
				break;
				IL_003a:
				int num2;
				if (!UnityTools.isEditor)
				{
					num = 1186204134;
					num2 = num;
				}
				else
				{
					num = 1186204135;
					num2 = num;
				}
			}
			goto IL_0008;
			IL_0086:
			if (msg == null)
			{
				msg = string.Empty;
				num = 1186204131;
				goto IL_000d;
			}
			goto IL_0052;
			IL_0052:
			int num3;
			if (!ReInput.isReady)
			{
				num = 1186204135;
				num3 = num;
			}
			else
			{
				num = 1186204130;
				num3 = num;
			}
			goto IL_000d;
		}

		public static void LogError(object msg)
		{
			LogError(msg, requiredThreadSafety: false);
		}

		public static void LogError(object msg, bool requiredThreadSafety)
		{
			if (!IsLoggingAllowed(LogLevel.Error))
			{
				return;
			}
			object[] array4 = default(object[]);
			object obj3 = default(object);
			object[] array3 = default(object[]);
			object[] array = default(object[]);
			object obj2 = default(object);
			object[] array2 = default(object[]);
			object obj5 = default(object);
			while (true)
			{
				int num;
				int num2;
				if (msg == null)
				{
					num = 1361167730;
					num2 = num;
				}
				else
				{
					num = 1361167733;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x5121C571)
					{
					case 11:
						num = 1361167715;
						continue;
					default:
						return;
					case 9:
						array4 = new object[4]
						{
							obj3,
							"Webplayer Platform: ",
							UnityTools.webplayerPlatform,
							"\n"
						};
						num = 1361167740;
						continue;
					case 13:
						msg = string.Concat(array4);
						num = 1361167732;
						continue;
					case 15:
					{
						array3[2] = ReInput.programVersion;
						array3[3] = "\n";
						msg = string.Concat(array3);
						object obj6 = msg;
						msg = string.Concat(obj6, "Platform: ", UnityTools.platform, "\n");
						num = 1361167731;
						continue;
					}
					case 7:
						array[0] = obj2;
						array[1] = "Editor Platform: ";
						array[2] = UnityTools.editorPlatform;
						num = 1361167735;
						continue;
					case 6:
						array[3] = "\n";
						msg = string.Concat(array);
						num = 1361167743;
						continue;
					case 3:
						msg = string.Empty;
						num = 1361167733;
						continue;
					case 8:
					{
						object obj = msg;
						msg = string.Concat(obj, "Unity version: ", UnityTools.unityVersionString, "\n");
						num = 1361167739;
						continue;
					}
					case 1:
						array2[3] = "\n";
						msg = string.Concat(array2);
						if (ReInput.isReady && ReInput.UserData != null && ReInput.UserData.ConfigVars != null)
						{
							msg = string.Concat(msg, ReInput.UserData.ConfigVars.GetDebugConfigSettings());
							num = 1361167712;
							continue;
						}
						goto case 17;
					case 10:
						obj5 = msg;
						array3 = new object[4];
						num = 1361167713;
						continue;
					case 16:
						array3[0] = obj5;
						num = 1361167741;
						continue;
					case 12:
						array3[1] = "Rewired version: ";
						num = 1361167742;
						continue;
					case 18:
						break;
					case 19:
						msg = string.Concat(msg, "\n------- Rewired System Info -------\n");
						num = 1361167737;
						continue;
					case 2:
						if (UnityTools.editorPlatform != EditorPlatform.None)
						{
							obj2 = msg;
							array = new object[4];
							num = 1361167734;
							continue;
						}
						goto case 14;
					case 5:
					{
						object obj4 = msg;
						array2 = new object[4]
						{
							obj4,
							"Using Unity input: ",
							ReInput.usingUnityInput,
							null
						};
						num = 1361167728;
						continue;
					}
					case 4:
						if (ReInput.isReady && !UnityTools.isEditor)
						{
							msg = "[ERROR] " + msg;
							num = 1361167714;
							continue;
						}
						goto case 19;
					case 14:
						if (UnityTools.webplayerPlatform != WebplayerPlatform.None)
						{
							obj3 = msg;
							num = 1361167736;
							continue;
						}
						goto case 5;
					case 17:
						LogErrorNow(msg, requiredThreadSafety);
						if (_logToScreen)
						{
							LogToScreen(msg);
							num = 1361167729;
							continue;
						}
						return;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private static void LogNow(object msg, bool requireThreadSafety)
		{
			if (requireThreadSafety)
			{
				goto IL_0003;
			}
			goto IL_0036;
			IL_0003:
			int num = -834467370;
			goto IL_0008;
			IL_0008:
			switch (num ^ -834467371)
			{
			case 0:
				break;
			default:
				return;
			case 4:
				goto IL_0029;
			case 1:
				goto IL_0036;
			case 3:
				UnityEngine.Debug.Log(msg);
				return;
			case 2:
				return;
			}
			goto IL_0003;
			IL_0036:
			if (UnityTools.logToDebugLog)
			{
				UnityEngine.Debug.unityLogger.Log("Rewired", msg);
				return;
			}
			goto IL_0029;
			IL_0029:
			Console.WriteLine(msg);
			num = -834467369;
			goto IL_0008;
		}

		private static void LogWarningNow(object msg, bool requireThreadSafety)
		{
			if (requireThreadSafety)
			{
				goto IL_0003;
			}
			goto IL_004a;
			IL_0003:
			int num = 551355578;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ 0x20DD04BB)
				{
				case 4:
					break;
				case 5:
					return;
				case 3:
					return;
				case 1:
					UnityEngine.Debug.LogWarning(msg);
					num = 551355576;
					continue;
				case 0:
					goto IL_004a;
				default:
					goto IL_0068;
				}
				break;
			}
			goto IL_0003;
			IL_004a:
			if (UnityTools.logToDebugLog)
			{
				UnityEngine.Debug.unityLogger.LogWarning("Rewired", msg);
				num = 551355582;
				goto IL_0008;
			}
			goto IL_0068;
			IL_0068:
			Console.WriteLine(msg);
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
					num = -1282475303;
					num2 = num;
				}
				else
				{
					num = -1282475301;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1282475302)
					{
					case 0:
						goto IL_000a;
					case 2:
						break;
					case 1:
						UnityEngine.Debug.unityLogger.LogError("Rewired", msg);
						return;
					default:
						Console.WriteLine(msg);
						return;
					}
					break;
					IL_000a:
					num = -1282475304;
				}
			}
		}

		private static bool IsLoggingAllowed(LogLevel logLevel)
		{
			switch (logLevel)
			{
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
				int num;
				int num2;
				if ((Logger.logLevel & LogLevelFlags.Debug) == 0)
				{
					num = -1553688323;
					num2 = num;
				}
				else
				{
					num = -1553688324;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1553688321)
					{
					case 0:
						num = -1553688322;
						continue;
					case 1:
						break;
					case 3:
						return true;
					default:
						goto end_IL_0003;
					}
					break;
				}
				goto case LogLevel.Info;
			}
			default:
				{
					throw new NotImplementedException();
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
			string[] array = default(string[]);
			int num4 = default(int);
			int num2 = default(int);
			while (true)
			{
				string text = msg.ToString();
				int num = -1380569464;
				while (true)
				{
					switch (num ^ -1380569462)
					{
					case 0:
						num = -1380569472;
						continue;
					default:
						return;
					case 3:
						Regex.Replace(text, "(\r\n|\r|\n)", "\n");
						array = text.Split('\n');
						num4 = 0;
						num = -1380569461;
						continue;
					case 4:
					{
						int num6 = screenLog.Count - 50;
						if (num6 > 0)
						{
							screenLog.RemoveRange(0, num6);
							num = -1380569457;
							continue;
						}
						goto case 5;
					}
					case 13:
						if (!string.IsNullOrEmpty(array[num4]))
						{
							array[num4] = array[num4].Trim();
							if (!string.IsNullOrEmpty(array[num4]))
							{
								screenLog.Add(array[num4]);
								num = -1380569468;
								continue;
							}
						}
						goto case 14;
					case 11:
					{
						int num5;
						if (num2 < screenLog.Count)
						{
							num = -1380569460;
							num5 = num;
						}
						else
						{
							num = -1380569459;
							num5 = num;
						}
						continue;
					}
					case 14:
						num4++;
						num = -1380569461;
						continue;
					case 1:
						if (num4 >= array.Length)
						{
							num = -1380569458;
							continue;
						}
						goto case 13;
					case 2:
					{
						int num3;
						if (!Regex.IsMatch(text, "(\r\n|\r|\n)"))
						{
							num = -1380569466;
							num3 = num;
						}
						else
						{
							num = -1380569463;
							num3 = num;
						}
						continue;
					}
					case 9:
						num = -1380569471;
						continue;
					case 5:
						_guiText.text = "";
						if (screenLog.Count > 0)
						{
							num2 = 0;
							num = -1380569469;
							continue;
						}
						return;
					case 6:
					{
						Rewired.Internal.GUIText guiText = _guiText;
						guiText.text = guiText.text + screenLog[num2] + "\n";
						num = -1380569470;
						continue;
					}
					case 8:
						num2++;
						num = -1380569471;
						continue;
					case 12:
						screenLog.Add(text);
						num = -1380569458;
						continue;
					case 10:
						break;
					case 7:
						return;
					}
					break;
				}
			}
		}

		[Conditional("LOG_INIT")]
		public static void LogInit(object o)
		{
			Log(o, requiredThreadSafety: true);
		}

		[Conditional("LOG_INIT")]
		public static void LogInitError(object o)
		{
			LogError(o, requiredThreadSafety: true);
		}

		[Conditional("LOG_INIT")]
		public static void LogInitWarning(object o)
		{
			LogWarning(o, requiredThreadSafety: true);
		}

		[Conditional("LOG_VC")]
		public static void Log_VCTest(object o)
		{
			Log(o);
		}

		[Conditional("LOG_UPDATE")]
		public static void LogUpdate(object o)
		{
			Log(o, requiredThreadSafety: true);
		}
	}
}
