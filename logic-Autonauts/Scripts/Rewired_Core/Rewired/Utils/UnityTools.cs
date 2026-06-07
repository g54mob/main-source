using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rewired.Platforms;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Utils
{
	public static class UnityTools
	{
		public enum UnityVersion
		{
			UNITY_2_6 = 0,
			UNITY_2_6_1 = 1,
			UNITY_3_0 = 2,
			UNITY_3_0_0 = 3,
			UNITY_3_1 = 4,
			UNITY_3_2 = 5,
			UNITY_3_3 = 6,
			UNITY_3_4 = 7,
			UNITY_3_5 = 8,
			UNITY_3_5_2 = 9,
			UNITY_3_5_7 = 10,
			UNITY_3_MAX = 11,
			UNITY_4_0 = 12,
			UNITY_4_0_1 = 13,
			UNITY_4_1 = 14,
			UNITY_4_2 = 15,
			UNITY_4_3 = 16,
			UNITY_4_4 = 17,
			UNITY_4_5 = 18,
			UNITY_4_6 = 19,
			UNITY_4_6_3p1 = 20,
			UNITY_4_6_3p1Plus = 21,
			UNITY_4_7 = 22,
			UNITY_4_8 = 23,
			UNITY_4_9 = 24,
			UNITY_4_MAX = 25,
			UNITY_5_0 = 26,
			UNITY_5_0_0p1 = 27,
			UNITY_5_0_0p1Plus = 28,
			UNITY_5_0_1 = 29,
			UNITY_5_0_2 = 30,
			UNITY_5_1 = 31,
			UNITY_5_2 = 32,
			UNITY_5_3 = 33,
			UNITY_5_4 = 34,
			UNITY_5_5 = 35,
			UNITY_5_6 = 36,
			UNITY_5_7 = 37,
			UNITY_5_8 = 38,
			UNITY_5_9 = 39,
			UNITY_5_MAX = 40,
			UNITY_2017_0 = 41,
			UNITY_2017_1 = 42,
			UNITY_2017_2 = 43,
			UNITY_2017_3 = 44,
			UNITY_2017_4 = 45,
			UNITY_2017_5 = 46,
			UNITY_2017_6 = 47,
			UNITY_2017_7 = 48,
			UNITY_2017_8 = 49,
			UNITY_2017_9 = 50,
			UNITY_2017_MAX = 51,
			UNITY_2018_0 = 52,
			UNITY_2018_1 = 53,
			UNITY_2018_2 = 54,
			UNITY_2018_3 = 55,
			UNITY_2018_4 = 56,
			UNITY_2018_5 = 57,
			UNITY_2018_6 = 58,
			UNITY_2018_7 = 59,
			UNITY_2018_8 = 60,
			UNITY_2018_9 = 61,
			UNITY_2018_MAX = 62,
			UNITY_2019_0 = 63,
			UNITY_2019_1 = 64,
			UNITY_2019_2 = 65,
			UNITY_2019_3 = 66,
			UNITY_2019_4 = 67,
			UNITY_2019_5 = 68,
			UNITY_2019_6 = 69,
			UNITY_2019_7 = 70,
			UNITY_2019_8 = 71,
			UNITY_2019_9 = 72,
			UNITY_2019_MAX = 73,
			UNITY_2020_0 = 74,
			UNITY_2020_1 = 75,
			UNITY_2020_2 = 76,
			UNITY_2020_3 = 77,
			UNITY_2020_4 = 78,
			UNITY_2020_5 = 79,
			UNITY_2020_6 = 80,
			UNITY_2020_7 = 81,
			UNITY_2020_8 = 82,
			UNITY_2020_9 = 83,
			UNITY_2020_MAX = 84,
			UNITY_2021_0 = 85,
			UNITY_2021_1 = 86,
			UNITY_2021_2 = 87,
			UNITY_2021_3 = 88,
			UNITY_2021_4 = 89,
			UNITY_2021_5 = 90,
			UNITY_2021_6 = 91,
			UNITY_2021_7 = 92,
			UNITY_2021_8 = 93,
			UNITY_2021_9 = 94,
			UNITY_2021_MAX = 95,
			Unknown = 1000
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal class UnityVersionClass
		{
			public enum MMagGVLkHpgZONoyTYbKhAVOGQB
			{
				dCLjDOhKNnqnPIEvWZdJDahGuaR = 0,
				qaPnMtRWRxuCWbozRCKLqLMJxHq = 1,
				YiJBeaPUstkHoxJEEOpClNxYRkj = 2
			}

			public readonly int major;

			public readonly int minor;

			public readonly int maintenance;

			public readonly MMagGVLkHpgZONoyTYbKhAVOGQB type;

			public readonly int build;

			public UnityVersionClass(string versionString)
			{
				type = MMagGVLkHpgZONoyTYbKhAVOGQB.dCLjDOhKNnqnPIEvWZdJDahGuaR;
				string[] array = versionString.Split('.');
				string text = array[array.Length - 1];
				if (Regex.IsMatch(text, ".*[a-zA-Z]+.*"))
				{
					if (Regex.IsMatch(text, ".*[bB]+.*", RegexOptions.IgnoreCase))
					{
						type = MMagGVLkHpgZONoyTYbKhAVOGQB.qaPnMtRWRxuCWbozRCKLqLMJxHq;
					}
					else if (Regex.IsMatch(text, ".*[pP]+.*", RegexOptions.IgnoreCase))
					{
						type = MMagGVLkHpgZONoyTYbKhAVOGQB.YiJBeaPUstkHoxJEEOpClNxYRkj;
					}
					text = Regex.Replace(text, "[a-zA-Z]", "|");
					if (text.Contains("|"))
					{
						string[] array2 = text.Split('|');
						if (array2.Length > 0)
						{
							int.TryParse(array2[0], out maintenance);
						}
						if (array2.Length > 1)
						{
							int.TryParse(array2[1], out build);
						}
					}
					else
					{
						int.TryParse(text, out maintenance);
					}
					Array.Resize(ref array, array.Length - 1);
				}
				else
				{
					int.TryParse(text, out maintenance);
				}
				if (array.Length > 0)
				{
					int.TryParse(array[0], out major);
				}
				if (array.Length > 1)
				{
					int.TryParse(array[1], out minor);
				}
			}

			public override string ToString()
			{
				return major + "." + minor + "." + maintenance + OuKFXdwknZeIKpYAwMwWXgTMruj(type) + build;
			}

			private string OuKFXdwknZeIKpYAwMwWXgTMruj(MMagGVLkHpgZONoyTYbKhAVOGQB P_0)
			{
				switch (P_0)
				{
				case MMagGVLkHpgZONoyTYbKhAVOGQB.dCLjDOhKNnqnPIEvWZdJDahGuaR:
					return "f";
				case MMagGVLkHpgZONoyTYbKhAVOGQB.qaPnMtRWRxuCWbozRCKLqLMJxHq:
					return "b";
				case MMagGVLkHpgZONoyTYbKhAVOGQB.YiJBeaPUstkHoxJEEOpClNxYRkj:
					return "p";
				default:
					throw new NotImplementedException();
				}
			}

			public override bool Equals(object obj)
			{
				if (!(obj is UnityVersionClass))
				{
					return false;
				}
				return this == (UnityVersionClass)obj;
			}

			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			public static bool operator <(UnityVersionClass a, UnityVersionClass b)
			{
				return Comparison(a, b) < 0;
			}

			public static bool operator >(UnityVersionClass a, UnityVersionClass b)
			{
				return Comparison(a, b) > 0;
			}

			public static bool operator >=(UnityVersionClass a, UnityVersionClass b)
			{
				return Comparison(a, b) >= 0;
			}

			public static bool operator <=(UnityVersionClass a, UnityVersionClass b)
			{
				return Comparison(a, b) <= 0;
			}

			public static bool operator ==(UnityVersionClass a, UnityVersionClass b)
			{
				return Comparison(a, b) == 0;
			}

			public static bool operator !=(UnityVersionClass a, UnityVersionClass b)
			{
				return Comparison(a, b) != 0;
			}

			public static int Comparison(UnityVersionClass a, UnityVersionClass b)
			{
				if (object.Equals(a, null))
				{
					goto IL_0009;
				}
				goto IL_0040;
				IL_0009:
				int num = -388184184;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ -388184181)
					{
					case 0:
						break;
					case 3:
						goto IL_002e;
					case 2:
						return 0;
					default:
						return -1;
					}
					break;
					IL_002e:
					if (object.Equals(b, null))
					{
						num = -388184183;
						continue;
					}
					goto IL_0040;
				}
				goto IL_0009;
				IL_0040:
				if (object.Equals(a, null))
				{
					return -1;
				}
				if (object.Equals(b, null))
				{
					return 1;
				}
				if (a.major > b.major)
				{
					return 1;
				}
				if (a.major < b.major)
				{
					return -1;
				}
				if (a.minor > b.minor)
				{
					return 1;
				}
				if (a.minor < b.minor)
				{
					return -1;
				}
				if (a.maintenance > b.maintenance)
				{
					return 1;
				}
				if (a.maintenance < b.maintenance)
				{
					return -1;
				}
				if (nGHLPHsLZpdtwRkNJAGrsIaGBgOh(a.type) > nGHLPHsLZpdtwRkNJAGrsIaGBgOh(b.type))
				{
					return 1;
				}
				if (nGHLPHsLZpdtwRkNJAGrsIaGBgOh(a.type) < nGHLPHsLZpdtwRkNJAGrsIaGBgOh(b.type))
				{
					num = -388184182;
					goto IL_000e;
				}
				if (a.build > b.build)
				{
					return 1;
				}
				if (a.build < b.build)
				{
					return -1;
				}
				return 0;
			}

			public static bool IsValidVersionString(string versionString)
			{
				if (string.IsNullOrEmpty(versionString))
				{
					return false;
				}
				if (!versionString.Contains("."))
				{
					return false;
				}
				string[] array = versionString.Split('.');
				while (true)
				{
					int num = 1847420373;
					while (true)
					{
						switch (num ^ 0x6E1D65D4)
						{
						case 2:
							break;
						case 1:
						{
							if (array.Length < 3)
							{
								return false;
							}
							if (!Regex.IsMatch(array[0], "^[0-9]+$"))
							{
								return false;
							}
							if (!Regex.IsMatch(array[1], "^[0-9]+$"))
							{
								num = 1847420375;
								continue;
							}
							int result;
							if (!int.TryParse(array[0], out result))
							{
								return false;
							}
							if (!int.TryParse(array[1], out result))
							{
								num = 1847420372;
								continue;
							}
							if (!Regex.IsMatch(array[2], "^[0-9]+"))
							{
								return false;
							}
							return true;
						}
						case 3:
							return false;
						default:
							return false;
						}
						break;
					}
				}
			}

			private static int nGHLPHsLZpdtwRkNJAGrsIaGBgOh(MMagGVLkHpgZONoyTYbKhAVOGQB P_0)
			{
				while (true)
				{
					switch (-90488778 ^ -90488780)
					{
					case 0:
						continue;
					case 2:
						switch (P_0)
						{
						case MMagGVLkHpgZONoyTYbKhAVOGQB.qaPnMtRWRxuCWbozRCKLqLMJxHq:
							break;
						case MMagGVLkHpgZONoyTYbKhAVOGQB.dCLjDOhKNnqnPIEvWZdJDahGuaR:
							return 10;
						case MMagGVLkHpgZONoyTYbKhAVOGQB.YiJBeaPUstkHoxJEEOpClNxYRkj:
							return 100;
						default:
							throw new NotImplementedException();
						}
						break;
					}
					break;
				}
				return 0;
			}
		}

		private const UnityVersion bhppRqAVcQWNHFzMQiwmSeOfLHp = UnityVersion.UNITY_5_0;

		private static UnityVersionClass WlvqsbMjwFyPmvHwuFpTiEEuoiND;

		private static UnityVersion atGgaXZxjrcHMqBTRjSxycXQCvo = UnityVersion.Unknown;

		private static string UFyeJTVdXsJuHtmiZFQJDviErPdC;

		private static Platform HVMovTcYKvFnWVazxFhUCtshfjS;

		private static EditorPlatform ckqMYVULGCvECZjzNaYYeazfmsEa;

		private static bool OuhCfbImssnfVgYGjfTGBzOeOiKQ;

		private static bool qpkHYHnKvIBbXrHhPTicAhFQiCu;

		private static bool fAbfKYoLegzlxaCFopQxCBsSDeAE;

		private static WebplayerPlatform MahmSOufpIgWKHrJtunLQmCVLTSF;

		private static bool bYkmLGMhrdVpiKfcJvldgHYRwgD;

		private static bool gVicEOQOWScAnNOiOWuqXuBxCVV;

		private static bool gIEEaTeTtrHVAKRCHjLZGGAGgYbh;

		private static bool sRsEWGEfMQWKjtnFRKUnFGFLtBkg;

		private static bool tzYKmKZBWfZxySxJUtvNMdvtaWv;

		private static bool MaqootErOZjNAPDLRSSuzdcfIhA;

		private static string wlNosTGNulGFLksDggGfIFPBlmpD;

		private static ScriptingBackend wTrjIuWuyCefJSIcedQhvnmkCMzg;

		private static ScriptingAPILevel DTuQcnmROwsNjyASfkccYuzCdhY;

		private static IExternalTools CSVtdAbVaTDDPSZLuxRKdHWbfrO;

		private static bool xjYZgbvKPQPdEnkfCpvIVtkoOnC;

		[CustomObfuscation(rename = false)]
		internal static UnityVersionClass unityVersionObj
		{
			get
			{
				if (!initialized)
				{
					return null;
				}
				return WlvqsbMjwFyPmvHwuFpTiEEuoiND;
			}
		}

		public static UnityVersion unityVersion
		{
			get
			{
				if (!initialized)
				{
					return UnityVersion.Unknown;
				}
				return atGgaXZxjrcHMqBTRjSxycXQCvo;
			}
		}

		public static string unityVersionString
		{
			get
			{
				if (!initialized)
				{
					return string.Empty;
				}
				return UFyeJTVdXsJuHtmiZFQJDviErPdC;
			}
		}

		public static Platform platform
		{
			get
			{
				if (!initialized)
				{
					return Platform.Unknown;
				}
				return HVMovTcYKvFnWVazxFhUCtshfjS;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static Platform effectivePlatform
		{
			get
			{
				if (!initialized)
				{
					return Platform.Unknown;
				}
				if (!OuhCfbImssnfVgYGjfTGBzOeOiKQ)
				{
					return HVMovTcYKvFnWVazxFhUCtshfjS;
				}
				switch (ckqMYVULGCvECZjzNaYYeazfmsEa)
				{
				case EditorPlatform.Windows:
					return Platform.Windows;
				case EditorPlatform.OSX:
					return Platform.OSX;
				case EditorPlatform.Linux:
					return Platform.Linux;
				default:
					return HVMovTcYKvFnWVazxFhUCtshfjS;
				}
			}
		}

		public static EditorPlatform editorPlatform
		{
			get
			{
				if (!initialized)
				{
					return EditorPlatform.None;
				}
				return ckqMYVULGCvECZjzNaYYeazfmsEa;
			}
		}

		public static bool isEditor
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return OuhCfbImssnfVgYGjfTGBzOeOiKQ;
			}
		}

		public static bool isPlaying
		{
			get
			{
				return qpkHYHnKvIBbXrHhPTicAhFQiCu;
			}
		}

		public static bool isDebugBuild
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return fAbfKYoLegzlxaCFopQxCBsSDeAE;
			}
		}

		public static WebplayerPlatform webplayerPlatform
		{
			get
			{
				if (!initialized)
				{
					return WebplayerPlatform.None;
				}
				return MahmSOufpIgWKHrJtunLQmCVLTSF;
			}
		}

		public static bool logToDebugLog
		{
			get
			{
				if (!initialized)
				{
					return true;
				}
				if (OuhCfbImssnfVgYGjfTGBzOeOiKQ)
				{
					goto IL_0041;
				}
				if (Application.isEditor)
				{
					goto IL_0017;
				}
				if (isAndroidPlatform)
				{
					return true;
				}
				Platform hVMovTcYKvFnWVazxFhUCtshfjS = HVMovTcYKvFnWVazxFhUCtshfjS;
				int num;
				if (hVMovTcYKvFnWVazxFhUCtshfjS <= Platform.Linux)
				{
					int num2;
					if (hVMovTcYKvFnWVazxFhUCtshfjS == Platform.Windows)
					{
						num = 261810785;
						num2 = num;
					}
					else
					{
						num = 261810786;
						num2 = num;
					}
					goto IL_001c;
				}
				goto IL_0079;
				IL_0079:
				switch (hVMovTcYKvFnWVazxFhUCtshfjS)
				{
				case Platform.XboxOne:
					return true;
				case Platform.Switch:
					return true;
				}
				goto IL_00bb;
				IL_001c:
				while (true)
				{
					switch (num ^ 0xF9AEA62)
					{
					case 4:
						break;
					case 1:
						goto IL_0041;
					case 3:
						goto IL_006b;
					case 2:
						goto IL_0079;
					case 0:
						goto IL_008c;
					default:
						return wTrjIuWuyCefJSIcedQhvnmkCMzg == ScriptingBackend.IL2CPP;
					}
					break;
					IL_008c:
					switch (hVMovTcYKvFnWVazxFhUCtshfjS)
					{
					case Platform.OSX:
					case Platform.Linux:
						break;
					default:
						goto IL_00bb;
					}
					goto IL_006b;
					IL_006b:
					if (!fAbfKYoLegzlxaCFopQxCBsSDeAE)
					{
						num = 261810791;
						continue;
					}
					return true;
				}
				goto IL_0017;
				IL_0017:
				num = 261810787;
				goto IL_001c;
				IL_00bb:
				if (fAbfKYoLegzlxaCFopQxCBsSDeAE)
				{
					return true;
				}
				return false;
				IL_0041:
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool editorPlatformMatchesBuildPlatform
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				if (!OuhCfbImssnfVgYGjfTGBzOeOiKQ)
				{
					goto IL_0010;
				}
				switch (ckqMYVULGCvECZjzNaYYeazfmsEa)
				{
				case EditorPlatform.Windows:
					goto IL_005e;
				case EditorPlatform.OSX:
					return HVMovTcYKvFnWVazxFhUCtshfjS == Platform.OSX;
				case EditorPlatform.Linux:
					return HVMovTcYKvFnWVazxFhUCtshfjS == Platform.Linux;
				}
				int num = 126512437;
				goto IL_0015;
				IL_0015:
				switch (num ^ 0x78A6D36)
				{
				case 2:
					break;
				case 1:
					return true;
				default:
					goto IL_005e;
				case 3:
					return true;
				}
				goto IL_0010;
				IL_0010:
				num = 126512439;
				goto IL_0015;
				IL_005e:
				return HVMovTcYKvFnWVazxFhUCtshfjS == Platform.Windows;
			}
		}

		public static bool isSupportedVersion3
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return bYkmLGMhrdVpiKfcJvldgHYRwgD;
			}
		}

		public static bool isSupportedVersion4
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return gVicEOQOWScAnNOiOWuqXuBxCVV;
			}
		}

		public static bool supports2DColliders
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_4_3;
			}
		}

		public static bool supportsSortingLayers
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_4_3;
			}
		}

		public static bool supportsUnityUI
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_4_6;
			}
		}

		public static bool supportsTouchControls
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_5_0;
			}
		}

		public static bool isAndroidPlatform
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				if (HVMovTcYKvFnWVazxFhUCtshfjS != Platform.Android && HVMovTcYKvFnWVazxFhUCtshfjS != Platform.Ouya && HVMovTcYKvFnWVazxFhUCtshfjS != Platform.AmazonFireTV)
				{
					return HVMovTcYKvFnWVazxFhUCtshfjS == Platform.RazerForgeTV;
				}
				return true;
			}
		}

		public static bool isIOSPlatform
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				if (HVMovTcYKvFnWVazxFhUCtshfjS != Platform.iOS)
				{
					return HVMovTcYKvFnWVazxFhUCtshfjS == Platform.tvOS;
				}
				return true;
			}
		}

		public static bool isStandalonePlatform
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				if (HVMovTcYKvFnWVazxFhUCtshfjS != Platform.Windows && HVMovTcYKvFnWVazxFhUCtshfjS != Platform.Linux)
				{
					return HVMovTcYKvFnWVazxFhUCtshfjS == Platform.OSX;
				}
				return true;
			}
		}

		public static bool windowsJoystickNamesReturnsEmptyStringsIfJoystickNull
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return gIEEaTeTtrHVAKRCHjLZGGAGgYbh;
			}
		}

		public static bool supportsUnityUIGraphicRaycastTarget
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_5_2;
			}
		}

		public static bool supportsNestedPrefabs
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_2018_3;
			}
		}

		public static bool supportsWindowsAppStore
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				if (atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_5_0)
				{
					return atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_5_0_1;
				}
				return true;
			}
		}

		public static bool supportsWindowsUWP
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_5_2;
			}
		}

		public static bool supportsWindowsUWP_IL2CPP
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_5_3;
			}
		}

		public static bool supportsXboxOne
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_4_5;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static ScriptingBackend scriptingBackend
		{
			get
			{
				return wTrjIuWuyCefJSIcedQhvnmkCMzg;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static ScriptingAPILevel scriptingAPILevel
		{
			get
			{
				return DTuQcnmROwsNjyASfkccYuzCdhY;
			}
		}

		public static IExternalTools externalTools
		{
			get
			{
				if (!initialized)
				{
					return null;
				}
				return CSVtdAbVaTDDPSZLuxRKdHWbfrO;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isInitialized
		{
			get
			{
				return xjYZgbvKPQPdEnkfCpvIVtkoOnC;
			}
		}

		private static bool initialized
		{
			get
			{
				return bwJpgNYIsqmEkzpQwWpdMNsHGCz();
			}
		}

		private static bool bwJpgNYIsqmEkzpQwWpdMNsHGCz()
		{
			if (xjYZgbvKPQPdEnkfCpvIVtkoOnC)
			{
				return true;
			}
			try
			{
				UFyeJTVdXsJuHtmiZFQJDviErPdC = Application.unityVersion;
				WlvqsbMjwFyPmvHwuFpTiEEuoiND = new UnityVersionClass(UFyeJTVdXsJuHtmiZFQJDviErPdC);
				UHbhDQyGSoFuxfaVxJRmgoghPCGR();
				while (true)
				{
					IL_0027:
					int num = 1341558001;
					while (true)
					{
						switch (num ^ 0x4FF68CF0)
						{
						case 0:
							break;
						default:
							goto end_IL_002c;
						case 1:
							goto IL_0045;
						case 2:
							goto end_IL_002c;
						}
						goto IL_0027;
						IL_0045:
						xjYZgbvKPQPdEnkfCpvIVtkoOnC = true;
						num = 1341558002;
						continue;
						end_IL_002c:
						break;
					}
					break;
				}
			}
			catch
			{
				Logger.LogError("Could not determine Unity version.");
			}
			return xjYZgbvKPQPdEnkfCpvIVtkoOnC;
		}

		internal static void dFyvOnKBbTYzKLbxHBbiIGdcrpeH(Platform P_0, EditorPlatform P_1, bool P_2, WebplayerPlatform P_3, ScriptingBackend P_4, ScriptingAPILevel P_5, IExternalTools P_6)
		{
			if (!initialized)
			{
				return;
			}
			while (true)
			{
				IL_0096:
				int num;
				if (P_0 == Platform.Windows81Store)
				{
					P_0 = Platform.WindowsUWP;
					num = 618225809;
					goto IL_0010;
				}
				goto IL_0086;
				IL_0010:
				while (true)
				{
					switch (num ^ 0x24D96093)
					{
					case 3:
						num = 618225810;
						continue;
					case 5:
						CSVtdAbVaTDDPSZLuxRKdHWbfrO = P_6;
						num = 618225815;
						continue;
					case 0:
						ckqMYVULGCvECZjzNaYYeazfmsEa = P_1;
						OuhCfbImssnfVgYGjfTGBzOeOiKQ = P_2;
						MahmSOufpIgWKHrJtunLQmCVLTSF = P_3;
						wTrjIuWuyCefJSIcedQhvnmkCMzg = P_4;
						num = 618225813;
						continue;
					case 6:
						DTuQcnmROwsNjyASfkccYuzCdhY = P_5;
						if (CSVtdAbVaTDDPSZLuxRKdHWbfrO != null)
						{
							CSVtdAbVaTDDPSZLuxRKdHWbfrO.Destroy();
							num = 618225814;
							continue;
						}
						goto case 5;
					case 2:
						break;
					case 1:
						goto IL_0096;
					default:
						fAbfKYoLegzlxaCFopQxCBsSDeAE = Debug.isDebugBuild;
						qpkHYHnKvIBbXrHhPTicAhFQiCu = true;
						DfOJfmTSKeqljfnPndrtbJfMBRfI();
						return;
					}
					break;
				}
				goto IL_0086;
				IL_0086:
				HVMovTcYKvFnWVazxFhUCtshfjS = P_0;
				num = 618225811;
				goto IL_0010;
			}
		}

		public static WebplayerPlatform DetermineWebplayerPlatformType(Platform platform, EditorPlatform editorPlatform)
		{
			return WebplayerPlatform.None;
		}

		public static bool IsUnityVersionInRange(string minVersionStr, string maxVersionStr)
		{
			if (!initialized)
			{
				goto IL_000a;
			}
			int num;
			int num2;
			if (!string.IsNullOrEmpty(minVersionStr))
			{
				num = 268269500;
				num2 = num;
			}
			else
			{
				num = 268269502;
				num2 = num;
			}
			goto IL_000f;
			IL_000a:
			num = 268269499;
			goto IL_000f;
			IL_000f:
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0xFFD77B9)
				{
				case 4:
					break;
				case 6:
					if (WlvqsbMjwFyPmvHwuFpTiEEuoiND >= new UnityVersionClass(maxVersionStr))
					{
						return false;
					}
					goto IL_01a6;
				case 5:
					minVersionStr = Regex.Replace(minVersionStr, "[^0-9\\.a-zA-Z]", "", RegexOptions.IgnoreCase);
					num = 268269502;
					continue;
				case 8:
				{
					bool flag = num4 > 0 || UnityVersionClass.IsValidVersionString(minVersionStr);
					bool flag2 = num3 > 0 || UnityVersionClass.IsValidVersionString(maxVersionStr);
					if (flag && WlvqsbMjwFyPmvHwuFpTiEEuoiND < new UnityVersionClass(minVersionStr))
					{
						return false;
					}
					if (num3 <= 0)
					{
						if (flag2)
						{
							num = 268269498;
							continue;
						}
					}
					else if (flag2)
					{
						num = 268269503;
						continue;
					}
					goto IL_01a6;
				}
				case 0:
				{
					int num6;
					if (num3 > 0)
					{
						num = 268269496;
						num6 = num;
					}
					else
					{
						num = 268269489;
						num6 = num;
					}
					continue;
				}
				case 9:
					maxVersionStr = Regex.Replace(maxVersionStr, "[^0-9\\.a-zA-Z]", "", RegexOptions.IgnoreCase);
					num = 268269491;
					continue;
				case 2:
					return false;
				case 7:
				{
					int num5;
					if (!string.IsNullOrEmpty(maxVersionStr))
					{
						num = 268269488;
						num5 = num;
					}
					else
					{
						num = 268269491;
						num5 = num;
					}
					continue;
				}
				case 10:
					tfALRwiIqiBvIwTUiOZnHaEsZZs(minVersionStr, out num4);
					tfALRwiIqiBvIwTUiOZnHaEsZZs(maxVersionStr, out num3);
					if (num4 > 0)
					{
						minVersionStr = num4 + ".0.0b0";
						num = 268269497;
						continue;
					}
					goto case 0;
				case 1:
					maxVersionStr = num3 + 1 + ".0.0b0";
					num = 268269489;
					continue;
				default:
					{
						if (WlvqsbMjwFyPmvHwuFpTiEEuoiND > new UnityVersionClass(maxVersionStr))
						{
							return false;
						}
						goto IL_01a6;
					}
					IL_01a6:
					return true;
				}
				break;
			}
			goto IL_000a;
		}

		private static bool tfALRwiIqiBvIwTUiOZnHaEsZZs(string P_0, out int P_1)
		{
			P_1 = 0;
			if (string.IsNullOrEmpty(P_0))
			{
				return false;
			}
			Match match = Regex.Match(P_0, "([0-9]+)[.]*[xX]");
			if (match.Success && int.TryParse(match.Groups[1].Value, out P_1))
			{
				return true;
			}
			return false;
		}

		private static void UHbhDQyGSoFuxfaVxJRmgoghPCGR()
		{
			atGgaXZxjrcHMqBTRjSxycXQCvo = yFKemUaJaOlfGjxPCoCVyiKUnCny(Application.unityVersion);
			if (atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_3_5 && atGgaXZxjrcHMqBTRjSxycXQCvo < UnityVersion.UNITY_4_0)
			{
				bYkmLGMhrdVpiKfcJvldgHYRwgD = true;
				return;
			}
			while (atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_4_0)
			{
				gVicEOQOWScAnNOiOWuqXuBxCVV = true;
				int num = 623120910;
				while (true)
				{
					switch (num ^ 0x2524120F)
					{
					case 0:
						goto IL_0027;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0027:
					num = 623120909;
				}
			}
		}

		private static UnityVersion yFKemUaJaOlfGjxPCoCVyiKUnCny(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				return UnityVersion.Unknown;
			}
			string[] array = P_0.Split('.');
			string[] array2 = default(string[]);
			int result3 = default(int);
			int num2 = default(int);
			int result2 = default(int);
			int result = default(int);
			string text = default(string);
			int result4 = default(int);
			bool flag = default(bool);
			while (true)
			{
				int num = -243960407;
				while (true)
				{
					switch (num ^ -243960437)
					{
					case 8:
						break;
					case 27:
						return UnityVersion.UNITY_3_1;
					case 19:
						return UnityVersion.UNITY_2019_7;
					case 26:
						if (array2.Length > 1)
						{
							int.TryParse(string.Concat(array2[1][0]), out result3);
							num = -243960417;
							continue;
						}
						goto case 20;
					case 34:
						num2 = array.Length;
						if (num2 >= 2)
						{
							num = -243960437;
							continue;
						}
						goto IL_0635;
					case 16:
						switch (result2)
						{
						case 2:
							return UnityVersion.UNITY_3_5_2;
						case 7:
							return UnityVersion.UNITY_3_5_7;
						default:
							return UnityVersion.UNITY_3_5;
						}
					case 32:
						switch (result)
						{
						case 2:
							return UnityVersion.UNITY_3_2;
						case 3:
							return UnityVersion.UNITY_3_3;
						case 4:
							return UnityVersion.UNITY_3_4;
						case 5:
							num = -243960421;
							break;
						default:
							return UnityVersion.UNITY_3_5_7;
						case 0:
							if (result2 == 0)
							{
								return UnityVersion.UNITY_3_0_0;
							}
							return UnityVersion.UNITY_3_0;
						case 1:
							num = -243960432;
							break;
						}
						continue;
					case 25:
						if (result2 == 1)
						{
							return UnityVersion.UNITY_4_0_1;
						}
						return UnityVersion.UNITY_4_0;
					case 9:
						return UnityVersion.UNITY_2019_9;
					case 1:
						return UnityVersion.UNITY_2017_2;
					case 15:
						return UnityVersion.UNITY_4_6_3p1;
					case 33:
						array2 = text.Split('p');
						if (array2.Length > 0)
						{
							int.TryParse(string.Concat(array2[0][0]), out result2);
							num = -243960431;
							continue;
						}
						goto case 26;
					case 13:
						return UnityVersion.UNITY_2020_3;
					case 20:
						switch (result4)
						{
						case 4:
							switch (result)
							{
							case 0:
								num = -243960430;
								break;
							case 1:
								return UnityVersion.UNITY_4_1;
							case 2:
								return UnityVersion.UNITY_4_2;
							case 3:
								return UnityVersion.UNITY_4_3;
							case 4:
								return UnityVersion.UNITY_4_4;
							case 5:
								return UnityVersion.UNITY_4_5;
							case 6:
								if (result2 == 3)
								{
									if (flag && result3 == 1)
									{
										num = -243960444;
										break;
									}
								}
								else if (result2 > 3)
								{
									num = -243960434;
									break;
								}
								return UnityVersion.UNITY_4_6;
							case 7:
								return UnityVersion.UNITY_4_7;
							case 8:
								return UnityVersion.UNITY_4_8;
							case 9:
								return UnityVersion.UNITY_4_9;
							default:
								return UnityVersion.UNITY_4_0;
							}
							continue;
						case 2020:
							num = -243960423;
							continue;
						case 2:
							if (result == 6)
							{
								if (result2 == 1)
								{
									return UnityVersion.UNITY_2_6_1;
								}
								return UnityVersion.UNITY_2_6;
							}
							break;
						case 3:
							num = -243960405;
							continue;
						case 5:
							num = -243960420;
							continue;
						case 2021:
							switch (result)
							{
							case 0:
								return UnityVersion.UNITY_2021_0;
							case 1:
								return UnityVersion.UNITY_2021_1;
							case 2:
								return UnityVersion.UNITY_2021_2;
							case 3:
								return UnityVersion.UNITY_2021_3;
							case 4:
								num = -243960448;
								break;
							case 5:
								return UnityVersion.UNITY_2021_5;
							case 6:
								return UnityVersion.UNITY_2021_6;
							case 7:
								return UnityVersion.UNITY_2021_7;
							case 8:
								return UnityVersion.UNITY_2021_8;
							case 9:
								return UnityVersion.UNITY_2021_9;
							default:
								return UnityVersion.UNITY_2021_0;
							}
							continue;
						case 2018:
							num = -243960401;
							continue;
						case 2017:
							num = -243960427;
							continue;
						case 2019:
							switch (result)
							{
							case 8:
								return UnityVersion.UNITY_2019_8;
							case 9:
								num = -243960446;
								break;
							default:
								return UnityVersion.UNITY_2019_0;
							case 2:
								return UnityVersion.UNITY_2019_2;
							case 3:
								return UnityVersion.UNITY_2019_3;
							case 4:
								num = -243960428;
								break;
							case 7:
								num = -243960424;
								break;
							case 5:
								return UnityVersion.UNITY_2019_5;
							case 6:
								num = -243960418;
								break;
							case 0:
								return UnityVersion.UNITY_2019_0;
							case 1:
								num = -243960422;
								break;
							}
							continue;
						}
						goto IL_0635;
					case 5:
						return UnityVersion.UNITY_4_6_3p1Plus;
					case 29:
						return UnityVersion.UNITY_2020_9;
					case 7:
						return UnityVersion.UNITY_2017_6;
					case 2:
						return UnityVersion.UNITY_2018_5;
					case 0:
						result2 = -1;
						text = string.Empty;
						int.TryParse(array[0], out result4);
						int.TryParse(array[1], out result);
						flag = false;
						result3 = 0;
						if (num2 < 3)
						{
							goto case 20;
						}
						text = array[2];
						if (text.IndexOf('p', 0) >= 1)
						{
							flag = true;
							num = -243960443;
							continue;
						}
						goto case 14;
					case 4:
						return UnityVersion.UNITY_2017_0;
					case 24:
						return UnityVersion.UNITY_2017_8;
					case 17:
						return UnityVersion.UNITY_2019_1;
					case 23:
						switch (result)
						{
						case 0:
							switch (result2)
							{
							case 0:
								if (flag)
								{
									if (result3 == 1)
									{
										return UnityVersion.UNITY_5_0_0p1;
									}
									return UnityVersion.UNITY_5_0_0p1Plus;
								}
								break;
							case 1:
								return UnityVersion.UNITY_5_0_1;
							case 2:
								return UnityVersion.UNITY_5_0_2;
							}
							return UnityVersion.UNITY_5_0;
						case 1:
							num = -243960441;
							break;
						case 2:
							return UnityVersion.UNITY_5_2;
						case 3:
							return UnityVersion.UNITY_5_3;
						case 4:
							num = -243960408;
							break;
						case 5:
							return UnityVersion.UNITY_5_5;
						case 6:
							return UnityVersion.UNITY_5_6;
						case 7:
							return UnityVersion.UNITY_5_7;
						case 8:
							return UnityVersion.UNITY_5_8;
						case 9:
							return UnityVersion.UNITY_5_9;
						default:
							return UnityVersion.UNITY_5_0;
						}
						continue;
					case 36:
						switch (result)
						{
						case 6:
							return UnityVersion.UNITY_2018_6;
						case 7:
							num = -243960419;
							break;
						case 0:
							return UnityVersion.UNITY_2018_0;
						case 1:
							return UnityVersion.UNITY_2018_1;
						case 2:
							return UnityVersion.UNITY_2018_2;
						case 3:
							return UnityVersion.UNITY_2018_3;
						case 4:
							return UnityVersion.UNITY_2018_4;
						case 5:
							num = -243960439;
							break;
						case 8:
							return UnityVersion.UNITY_2018_8;
						case 9:
							num = -243960447;
							break;
						default:
							return UnityVersion.UNITY_2018_0;
						}
						continue;
					case 12:
						return UnityVersion.UNITY_5_1;
					case 6:
						return UnityVersion.UNITY_2020_4;
					case 14:
						if (flag)
						{
							goto case 33;
						}
						if (text != string.Empty)
						{
							string s = string.Concat(text[0]);
							int.TryParse(s, out result2);
							num = -243960417;
							continue;
						}
						goto case 20;
					case 35:
						return UnityVersion.UNITY_5_4;
					case 18:
						switch (result)
						{
						case 4:
							num = -243960435;
							break;
						default:
							return UnityVersion.UNITY_2020_0;
						case 5:
							num = -243960425;
							break;
						case 0:
							return UnityVersion.UNITY_2020_0;
						case 1:
							return UnityVersion.UNITY_2020_1;
						case 2:
							return UnityVersion.UNITY_2020_2;
						case 3:
							num = -243960442;
							break;
						case 6:
							return UnityVersion.UNITY_2020_6;
						case 7:
							return UnityVersion.UNITY_2020_7;
						case 8:
							return UnityVersion.UNITY_2020_8;
						case 9:
							num = -243960426;
							break;
						}
						continue;
					case 21:
						return UnityVersion.UNITY_2019_6;
					case 31:
						return UnityVersion.UNITY_2019_4;
					case 22:
						return UnityVersion.UNITY_2018_7;
					case 3:
						return UnityVersion.UNITY_2017_1;
					case 28:
						return UnityVersion.UNITY_2020_5;
					case 10:
						return UnityVersion.UNITY_2018_9;
					case 30:
						switch (result)
						{
						case 3:
							return UnityVersion.UNITY_2017_3;
						case 4:
							return UnityVersion.UNITY_2017_4;
						case 5:
							return UnityVersion.UNITY_2017_5;
						case 6:
							num = -243960436;
							break;
						case 7:
							return UnityVersion.UNITY_2017_7;
						case 8:
							num = -243960429;
							break;
						case 1:
							num = -243960440;
							break;
						case 9:
							return UnityVersion.UNITY_2017_9;
						default:
							return UnityVersion.UNITY_2017_0;
						case 2:
							num = -243960438;
							break;
						case 0:
							num = -243960433;
							break;
						}
						continue;
					default:
						{
							return UnityVersion.UNITY_2021_4;
						}
						IL_0635:
						return UnityVersion.Unknown;
					}
					break;
				}
			}
		}

		private static UnityVersion dtNJGfMJziuYjfNEGwsDHPoAofL(int P_0)
		{
			switch (P_0)
			{
			default:
				while (true)
				{
					switch (0x48EE3029 ^ 0x48EE302B)
					{
					case 0:
						continue;
					case 2:
						switch (P_0)
						{
						case 2017:
							return UnityVersion.UNITY_2017_0;
						case 2018:
							return UnityVersion.UNITY_2018_0;
						case 2019:
							return UnityVersion.UNITY_2019_0;
						case 2020:
							return UnityVersion.UNITY_2020_0;
						case 2021:
							return UnityVersion.UNITY_2021_0;
						default:
							return UnityVersion.Unknown;
						}
					}
					break;
				}
				goto case 3;
			case 3:
				return UnityVersion.UNITY_3_0;
			case 4:
				return UnityVersion.UNITY_4_0;
			case 5:
				return UnityVersion.UNITY_5_0;
			}
		}

		private static UnityVersion wQmlnPMItCPsnDIJRlpdGjitwv(int P_0)
		{
			switch (P_0)
			{
			case 3:
				return UnityVersion.UNITY_3_MAX;
			case 4:
				return UnityVersion.UNITY_4_MAX;
			case 5:
				return UnityVersion.UNITY_5_MAX;
			case 2017:
				return UnityVersion.UNITY_2017_MAX;
			case 2018:
				return UnityVersion.UNITY_2018_MAX;
			case 2019:
				return UnityVersion.UNITY_2019_MAX;
			case 2020:
				return UnityVersion.UNITY_2020_MAX;
			case 2021:
				return UnityVersion.UNITY_2021_MAX;
			default:
				return UnityVersion.Unknown;
			}
		}

		private static void DfOJfmTSKeqljfnPndrtbJfMBRfI()
		{
			Platform hVMovTcYKvFnWVazxFhUCtshfjS = HVMovTcYKvFnWVazxFhUCtshfjS;
			if (hVMovTcYKvFnWVazxFhUCtshfjS <= Platform.Android)
			{
				switch (hVMovTcYKvFnWVazxFhUCtshfjS)
				{
				case Platform.Windows:
					break;
				case Platform.Linux:
					goto IL_00f9;
				case Platform.Android:
					goto IL_01b8;
				default:
					goto IL_01ce;
				}
				goto IL_008b;
			}
			goto IL_0129;
			IL_01b8:
			sRsEWGEfMQWKjtnFRKUnFGFLtBkg = true;
			tzYKmKZBWfZxySxJUtvNMdvtaWv = true;
			int num = -1530566154;
			goto IL_002b;
			IL_01ce:
			int num2;
			if (OuhCfbImssnfVgYGjfTGBzOeOiKQ)
			{
				num = -1530566160;
				num2 = num;
			}
			else
			{
				num = -1530566175;
				num2 = num;
			}
			goto IL_002b;
			IL_0129:
			switch (hVMovTcYKvFnWVazxFhUCtshfjS)
			{
			case Platform.PS4:
				break;
			default:
				goto IL_013f;
			case Platform.AmazonFireTV:
			case Platform.RazerForgeTV:
				goto IL_01b8;
			}
			goto IL_0109;
			IL_0109:
			sRsEWGEfMQWKjtnFRKUnFGFLtBkg = true;
			wlNosTGNulGFLksDggGfIFPBlmpD = "Empty";
			MaqootErOZjNAPDLRSSuzdcfIhA = true;
			num = -1530566151;
			goto IL_002b;
			IL_002b:
			EditorPlatform editorPlatform = default(EditorPlatform);
			while (true)
			{
				switch (num ^ -1530566157)
				{
				case 17:
					num = -1530566155;
					continue;
				default:
					return;
				case 13:
					break;
				case 5:
					num = -1530566176;
					continue;
				case 3:
					editorPlatform = ckqMYVULGCvECZjzNaYYeazfmsEa;
					num = -1530566156;
					continue;
				case 1:
					num = -1530566176;
					continue;
				case 15:
					sRsEWGEfMQWKjtnFRKUnFGFLtBkg = true;
					num = -1530566176;
					continue;
				case 10:
					num = -1530566176;
					continue;
				case 2:
					gIEEaTeTtrHVAKRCHjLZGGAGgYbh = true;
					sRsEWGEfMQWKjtnFRKUnFGFLtBkg = true;
					num = -1530566175;
					continue;
				case 8:
					goto IL_00f9;
				case 11:
					goto IL_0109;
				case 6:
					goto IL_0129;
				case 4:
					goto IL_0149;
				case 7:
					if (editorPlatform != EditorPlatform.Windows)
					{
						return;
					}
					goto case 9;
				case 16:
				{
					int num3;
					if (atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_5_0_0p1)
					{
						num = -1530566159;
						num3 = num;
					}
					else
					{
						num = -1530566175;
						num3 = num;
					}
					continue;
				}
				case 9:
					if (atGgaXZxjrcHMqBTRjSxycXQCvo < UnityVersion.UNITY_4_6_3p1)
					{
						goto case 16;
					}
					goto IL_019b;
				case 0:
					goto IL_01b8;
				case 19:
					goto IL_01ce;
				case 12:
					gIEEaTeTtrHVAKRCHjLZGGAGgYbh = true;
					num = -1530566148;
					continue;
				case 14:
					goto IL_01f9;
				case 18:
					return;
				}
				break;
				IL_01f9:
				int num4;
				if (atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_5_0_0p1)
				{
					num = -1530566145;
					num4 = num;
				}
				else
				{
					num = -1530566176;
					num4 = num;
				}
				continue;
				IL_019b:
				int num5;
				if (atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_5_0)
				{
					num = -1530566173;
					num5 = num;
				}
				else
				{
					num = -1530566159;
					num5 = num;
				}
				continue;
				IL_0149:
				int num6;
				if (atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_5_0)
				{
					num = -1530566147;
					num6 = num;
				}
				else
				{
					num = -1530566145;
					num6 = num;
				}
			}
			goto IL_008b;
			IL_013f:
			num = -1530566158;
			goto IL_002b;
			IL_00f9:
			tzYKmKZBWfZxySxJUtvNMdvtaWv = true;
			num = -1530566176;
			goto IL_002b;
			IL_008b:
			int num7;
			if (atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_4_6_3p1)
			{
				num = -1530566153;
				num7 = num;
			}
			else
			{
				num = -1530566147;
				num7 = num;
			}
			goto IL_002b;
		}

		internal static Type OCexvwUgwkCtHBjijWfYbhFOnbbV(xLReCHQPFooBcLQWcNvScYQOfeS P_0)
		{
			if (!initialized)
			{
				return null;
			}
			if (atGgaXZxjrcHMqBTRjSxycXQCvo >= UnityVersion.UNITY_4_3)
			{
				return ZoupMBYAcWcBPlamVGcmclezPfPE(P_0);
			}
			return null;
		}

		private static Type ZoupMBYAcWcBPlamVGcmclezPfPE(xLReCHQPFooBcLQWcNvScYQOfeS P_0)
		{
			if (P_0 == xLReCHQPFooBcLQWcNvScYQOfeS.ZeFEwjCukbHUQNGiXpqQNndtcqj)
			{
				goto IL_0003;
			}
			int num;
			if (P_0 == xLReCHQPFooBcLQWcNvScYQOfeS.vprudVGNJGyCkbIfZZIWahUvrkb)
			{
				num = -1817977293;
				goto IL_0008;
			}
			switch (P_0)
			{
			case xLReCHQPFooBcLQWcNvScYQOfeS.NZIRIHLPQNjCzzGykEEWpAcvQRC:
				return typeof(CollisionDetectionMode2D);
			case xLReCHQPFooBcLQWcNvScYQOfeS.FwaNqkkuVVHLfQZfoiWITsKMmkV:
				return typeof(PhysicsMaterial2D);
			case xLReCHQPFooBcLQWcNvScYQOfeS.pnoCQdWalnIdeYDIcrnSuVjgJns:
				return typeof(Collider2D);
			default:
				return null;
			}
			IL_0008:
			switch (num ^ -1817977293)
			{
			case 2:
				break;
			case 1:
				return typeof(RigidbodyInterpolation2D);
			default:
				return typeof(RigidbodySleepMode2D);
			}
			goto IL_0003;
			IL_0003:
			num = -1817977294;
			goto IL_0008;
		}

		public static List<string> GetCurrentPlatformResourecesDLLPaths()
		{
			if (!initialized)
			{
				goto IL_0007;
			}
			List<string> list = new List<string>();
			switch (platform)
			{
			case Platform.OSX:
				break;
			case Platform.Linux:
				goto IL_0059;
			default:
				goto IL_0098;
			case Platform.Windows:
				goto IL_00a2;
			case Platform.iOS:
				goto IL_00c1;
			}
			goto IL_0040;
			IL_0059:
			list.Add("Libs/Rewired_Linux");
			int num = 2119203928;
			goto IL_000c;
			IL_0098:
			num = 2119203923;
			goto IL_000c;
			IL_0007:
			num = 2119203924;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ 0x7E507C50)
				{
				case 0:
					break;
				case 5:
					goto IL_0040;
				case 1:
					num = 2119203928;
					continue;
				case 7:
					goto IL_0059;
				case 2:
					num = 2119203928;
					continue;
				case 4:
					return null;
				case 6:
					goto IL_00a2;
				case 3:
					num = 2119203928;
					continue;
				default:
					goto IL_00c1;
				}
				break;
			}
			goto IL_0007;
			IL_0040:
			list.Add("Libs/Rewired_OSX");
			num = 2119203921;
			goto IL_000c;
			IL_00a2:
			list.Add("Libs/Rewired_Windows");
			num = 2119203922;
			goto IL_000c;
			IL_00c1:
			return list;
		}

		public static Transform FindTransformInChildren(Transform transform, string name)
		{
			if (transform == null)
			{
				return null;
			}
			int childCount = transform.childCount;
			int num2 = default(int);
			Transform child = default(Transform);
			while (true)
			{
				int num = 1168394774;
				while (true)
				{
					switch (num ^ 0x45A44A15)
					{
					case 5:
						break;
					case 3:
						num2 = 0;
						num = 1168394769;
						continue;
					case 1:
					{
						if (child.name == name)
						{
							num = 1168394771;
							continue;
						}
						Transform transform2 = FindTransformInChildren(child, name);
						if (transform2 != null)
						{
							return transform2;
						}
						num2++;
						num = 1168394769;
						continue;
					}
					case 6:
						return child;
					case 4:
					{
						int num3;
						if (num2 >= childCount)
						{
							num = 1168394775;
							num3 = num;
						}
						else
						{
							num = 1168394773;
							num3 = num;
						}
						continue;
					}
					case 0:
						child = transform.GetChild(num2);
						num = 1168394772;
						continue;
					default:
						return null;
					}
					break;
				}
			}
		}

		public static Transform FindTransformInChildren(GameObject gameObject, string name)
		{
			if (gameObject == null)
			{
				return null;
			}
			return FindTransformInChildren(gameObject.transform, name);
		}

		public static GameObject FindGameObjectInChildren(GameObject gameObject, string name)
		{
			if (gameObject == null)
			{
				return null;
			}
			Transform transform = gameObject.transform;
			Transform transform2 = FindTransformInChildren(transform, name);
			if (!(transform2 != null))
			{
				return null;
			}
			return transform2.gameObject;
		}

		public static GameObject FindGameObjectInChildren(Transform transform, string name)
		{
			if (transform == null)
			{
				return null;
			}
			Transform transform2 = FindTransformInChildren(transform, name);
			if (transform2 == null)
			{
				return null;
			}
			return transform2.gameObject;
		}

		public static T GetComponent<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return null;
			}
			return GetComponent<T>(transform.gameObject);
		}

		public static T GetComponent<T>(Component component) where T : class
		{
			if (component == null)
			{
				return null;
			}
			return GetComponent<T>(component.gameObject);
		}

		public static T GetComponent<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				return null;
			}
			return FzTZeTvXCzeLKBYohshCVldDfZt(gameObject.GetComponent(typeof(T)) as T);
		}

		public static T GetComponent<T>(Transform transform, bool includeInactive) where T : class
		{
			if (transform == null)
			{
				return null;
			}
			return GetComponent<T>(transform.gameObject, includeInactive);
		}

		public static T GetComponent<T>(Component component, bool includeInactive) where T : class
		{
			if (component == null)
			{
				return null;
			}
			return GetComponent<T>(component.gameObject, includeInactive);
		}

		public static T GetComponent<T>(GameObject gameObject, bool includeInactive) where T : class
		{
			if (gameObject == null)
			{
				return null;
			}
			TempListPool.TList<Component> tList = TempListPool.GetTList<Component>();
			try
			{
				List<Component> list = tList.list;
				T val = default(T);
				int num2 = default(int);
				int count = default(int);
				T result = default(T);
				while (true)
				{
					IL_0021:
					int num = -64986591;
					while (true)
					{
						switch (num ^ -64986592)
						{
						case 3:
							break;
						default:
							goto end_IL_0026;
						case 6:
							val = list[num2] as T;
							if (IsNullOrDestroyed(val))
							{
								goto case 5;
							}
							if (!includeInactive)
							{
								int num4;
								if (IsEnabled(list[num2]))
								{
									num = -64986592;
									num4 = num;
								}
								else
								{
									num = -64986587;
									num4 = num;
								}
								continue;
							}
							goto case 0;
						case 5:
							num2++;
							num = -64986585;
							continue;
						case 8:
							num = -64986585;
							continue;
						case 7:
						{
							int num3;
							if (num2 >= count)
							{
								num = -64986588;
								num3 = num;
							}
							else
							{
								num = -64986586;
								num3 = num;
							}
							continue;
						}
						case 1:
							GetComponents(gameObject, list, false);
							count = list.Count;
							num2 = 0;
							num = -64986584;
							continue;
						case 0:
							result = val;
							num = -64986590;
							continue;
						case 4:
							goto end_IL_0026;
						case 2:
							return result;
						}
						goto IL_0021;
						continue;
						end_IL_0026:
						break;
					}
					break;
				}
			}
			finally
			{
				if (tList != null)
				{
					while (true)
					{
						IL_0103:
						int num5 = -64986591;
						while (true)
						{
							switch (num5 ^ -64986592)
							{
							case 2:
								break;
							default:
								goto end_IL_0108;
							case 1:
								goto IL_0121;
							case 0:
								goto end_IL_0108;
							}
							goto IL_0103;
							IL_0121:
							((IDisposable)tList).Dispose();
							num5 = -64986592;
							continue;
							end_IL_0108:
							break;
						}
						break;
					}
				}
			}
			return null;
		}

		public static Component GetComponent(Transform transform, Type type, bool includeInactive)
		{
			if (transform == null)
			{
				return null;
			}
			return GetComponent(transform.gameObject, type, includeInactive);
		}

		public static Component GetComponent(Component component, Type type, bool includeInactive)
		{
			if (component == null)
			{
				return null;
			}
			return GetComponent(component.gameObject, type, includeInactive);
		}

		public static Component GetComponent(GameObject gameObject, Type type, bool includeInactive)
		{
			if (gameObject == null)
			{
				return null;
			}
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				int num2 = default(int);
				int count = default(int);
				while (true)
				{
					IL_0018:
					int num = -1196903232;
					while (true)
					{
						switch (num ^ -1196903225)
						{
						case 3:
							break;
						default:
							goto end_IL_001d;
						case 2:
							num2++;
							num = -1196903230;
							continue;
						case 5:
						{
							int num4;
							if (num2 < count)
							{
								num = -1196903226;
								num4 = num;
							}
							else
							{
								num = -1196903229;
								num4 = num;
							}
							continue;
						}
						case 7:
							GetComponents(gameObject, list, false);
							num = -1196903225;
							continue;
						case 6:
							num2 = 0;
							num = -1196903230;
							continue;
						case 1:
							if (!ReflectionTools.DoesTypeImplement(list[num2].GetType(), type))
							{
								goto case 2;
							}
							if (!includeInactive)
							{
								int num3;
								if (!IsEnabled(list[num2]))
								{
									num = -1196903227;
									num3 = num;
								}
								else
								{
									num = -1196903217;
									num3 = num;
								}
								continue;
							}
							goto case 8;
						case 8:
							return list[num2];
						case 0:
							count = list.Count;
							num = -1196903231;
							continue;
						case 4:
							goto end_IL_001d;
						}
						goto IL_0018;
						continue;
						end_IL_001d:
						break;
					}
					break;
				}
			}
			return null;
		}

		public static Component GetComponent(Transform transform, Type type)
		{
			if (transform == null)
			{
				return null;
			}
			return GetComponent(transform.gameObject, type);
		}

		public static Component GetComponent(Component component, Type type)
		{
			if (component == null)
			{
				return null;
			}
			return GetComponent(component.gameObject, type);
		}

		public static Component GetComponent(GameObject gameObject, Type type)
		{
			if (gameObject == null)
			{
				return null;
			}
			TempListPool.TList<Component> tList = TempListPool.GetTList<Component>();
			try
			{
				List<Component> list = tList.list;
				GetComponents(gameObject, list, false);
				int count = list.Count;
				int num = 0;
				while (true)
				{
					IL_002a:
					int num2 = 841832803;
					while (true)
					{
						switch (num2 ^ 0x322D5967)
						{
						case 0:
							break;
						case 4:
							num2 = 841832806;
							continue;
						case 3:
							num++;
							num2 = 841832806;
							continue;
						case 2:
							if (ReflectionTools.DoesTypeImplement(list[num].GetType(), type))
							{
								return list[num];
							}
							goto case 3;
						default:
							if (num >= count)
							{
								goto end_IL_002f;
							}
							goto case 2;
						}
						goto IL_002a;
						continue;
						end_IL_002f:
						break;
					}
					break;
				}
			}
			finally
			{
				if (tList != null)
				{
					while (true)
					{
						IL_0091:
						int num3 = 841832806;
						while (true)
						{
							switch (num3 ^ 0x322D5967)
							{
							case 0:
								break;
							default:
								goto end_IL_0096;
							case 1:
								goto IL_00af;
							case 2:
								goto end_IL_0096;
							}
							goto IL_0091;
							IL_00af:
							((IDisposable)tList).Dispose();
							num3 = 841832805;
							continue;
							end_IL_0096:
							break;
						}
						break;
					}
				}
			}
			return null;
		}

		public static T GetComponentInChildren<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				return null;
			}
			return GetComponentInChildren<T>(gameObject.transform);
		}

		public static T GetComponentInChildren<T>(Component component) where T : class
		{
			if (component == null)
			{
				return null;
			}
			return GetComponentInChildren<T>(component.transform);
		}

		public static T GetComponentInChildren<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return null;
			}
			int childCount = transform.childCount;
			int num = 0;
			T component = default(T);
			T result = default(T);
			while (true)
			{
				int num2 = 1063671387;
				while (true)
				{
					switch (num2 ^ 0x3F66565F)
					{
					case 0:
						break;
					case 1:
						return component;
					case 3:
					{
						Transform child = transform.GetChild(num);
						component = GetComponent<T>(child);
						if (IsNullOrDestroyed(component))
						{
							T componentInChildren = GetComponentInChildren<T>(child);
							if (!IsNullOrDestroyed(componentInChildren))
							{
								return componentInChildren;
							}
							num++;
							num2 = 1063671389;
						}
						else
						{
							num2 = 1063671390;
						}
						continue;
					}
					case 4:
						num2 = 1063671389;
						continue;
					case 2:
						if (num >= childCount)
						{
							result = null;
							num2 = 1063671386;
							continue;
						}
						goto case 3;
					default:
						return result;
					}
					break;
				}
			}
		}

		public static T GetComponentInChildren<T>(GameObject gameObject, bool includeInactive) where T : class
		{
			if (gameObject == null)
			{
				return null;
			}
			return GetComponentInChildren<T>(gameObject.transform, includeInactive);
		}

		public static T GetComponentInChildren<T>(Component component, bool includeInactive) where T : class
		{
			if (component == null)
			{
				return null;
			}
			return GetComponentInChildren<T>(component.transform, includeInactive);
		}

		public static T GetComponentInChildren<T>(Transform transform, bool includeInactive) where T : class
		{
			if (transform == null)
			{
				return null;
			}
			int childCount = transform.childCount;
			int num = 0;
			T result = default(T);
			T component = default(T);
			T componentInChildren = default(T);
			Transform child = default(Transform);
			while (true)
			{
				int num2 = -1505386015;
				while (true)
				{
					switch (num2 ^ -1505386011)
					{
					case 6:
						break;
					case 4:
						num2 = -1505386016;
						continue;
					case 5:
						if (num >= childCount)
						{
							result = null;
							num2 = -1505386011;
							continue;
						}
						goto case 1;
					case 2:
						if (!IsNullOrDestroyed(component))
						{
							return component;
						}
						componentInChildren = GetComponentInChildren<T>(child, includeInactive);
						if (!IsNullOrDestroyed(componentInChildren))
						{
							num2 = -1505386010;
							continue;
						}
						num++;
						num2 = -1505386016;
						continue;
					case 1:
						child = transform.GetChild(num);
						component = GetComponent<T>(child, includeInactive);
						num2 = -1505386009;
						continue;
					case 3:
						return componentInChildren;
					default:
						return result;
					}
					break;
				}
			}
		}

		public static Component GetComponentInChildren(GameObject gameObject, Type type)
		{
			if (gameObject == null)
			{
				return null;
			}
			return GetComponentInChildren(gameObject.transform, type);
		}

		public static Component GetComponentInChildren(Component component, Type type)
		{
			if (component == null)
			{
				return null;
			}
			return GetComponentInChildren(component.transform, type);
		}

		public static Component GetComponentInChildren(Transform transform, Type type)
		{
			if (transform == null)
			{
				return null;
			}
			int childCount = transform.childCount;
			int num = 0;
			while (true)
			{
				int num2 = 802224034;
				while (true)
				{
					switch (num2 ^ 0x2FD0F7A1)
					{
					case 2:
						break;
					case 3:
						num2 = 802224032;
						continue;
					case 0:
					{
						Transform child = transform.GetChild(num);
						Component component = GetComponent(child, type);
						if (!IsNullOrDestroyed(component))
						{
							return component;
						}
						Component componentInChildren = GetComponentInChildren(child, type);
						if (!IsNullOrDestroyed(componentInChildren))
						{
							return componentInChildren;
						}
						num++;
						num2 = 802224032;
						continue;
					}
					default:
						if (num >= childCount)
						{
							return null;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public static Component GetComponentInChildren(GameObject gameObject, Type type, bool includeInactive)
		{
			if (gameObject == null)
			{
				return null;
			}
			return GetComponentInChildren(gameObject.transform, type, includeInactive);
		}

		public static Component GetComponentInChildren(Component component, Type type, bool includeInactive)
		{
			if (component == null)
			{
				return null;
			}
			return GetComponentInChildren(component.transform, type, includeInactive);
		}

		public static Component GetComponentInChildren(Transform transform, Type type, bool includeInactive)
		{
			if (transform == null)
			{
				return null;
			}
			int childCount = transform.childCount;
			int num2 = default(int);
			while (true)
			{
				int num = 1687917734;
				while (true)
				{
					switch (num ^ 0x649B94A4)
					{
					case 3:
						break;
					case 4:
					{
						int num3;
						if (num2 < childCount)
						{
							num = 1687917733;
							num3 = num;
						}
						else
						{
							num = 1687917732;
							num3 = num;
						}
						continue;
					}
					case 1:
					{
						Transform child = transform.GetChild(num2);
						Component component = GetComponent(child, type, includeInactive);
						if (!IsNullOrDestroyed(component))
						{
							return component;
						}
						Component componentInChildren = GetComponentInChildren(child, type);
						if (!IsNullOrDestroyed(componentInChildren))
						{
							return componentInChildren;
						}
						num2++;
						num = 1687917728;
						continue;
					}
					case 2:
						num2 = 0;
						num = 1687917728;
						continue;
					default:
						return null;
					}
					break;
				}
			}
		}

		public static T GetComponentInSelfOrChildren<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return null;
			}
			return GetComponentInSelfOrChildren<T>(transform.gameObject);
		}

		public static T GetComponentInSelfOrChildren<T>(Component component) where T : class
		{
			if (component == null)
			{
				return null;
			}
			return GetComponentInSelfOrChildren<T>(component.gameObject);
		}

		public static T GetComponentInSelfOrChildren<T>(GameObject gameObject) where T : class
		{
			T result = default(T);
			if (gameObject == null)
			{
				while (true)
				{
					int num = -237251047;
					while (true)
					{
						switch (num ^ -237251048)
						{
						case 2:
							break;
						case 1:
							goto IL_0027;
						default:
							return result;
						}
						break;
						IL_0027:
						result = null;
						num = -237251048;
					}
				}
			}
			T component = GetComponent<T>(gameObject);
			if (IsNullOrDestroyed(component))
			{
				return GetComponentInChildren<T>(gameObject);
			}
			return component;
		}

		public static T GetComponentInParents<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				return null;
			}
			return GetComponentInParents<T>(gameObject.transform);
		}

		public static T GetComponentInParents<T>(Component component) where T : class
		{
			T result = default(T);
			if (component == null)
			{
				while (true)
				{
					int num = 451421630;
					while (true)
					{
						switch (num ^ 0x1AE825BC)
						{
						case 0:
							break;
						case 2:
							goto IL_0027;
						default:
							return result;
						}
						break;
						IL_0027:
						result = null;
						num = 451421629;
					}
				}
			}
			return GetComponentInParents<T>(component.transform);
		}

		public static T GetComponentInParents<T>(Transform transform) where T : class
		{
			T result = default(T);
			if (transform == null)
			{
				result = null;
				goto IL_0011;
			}
			while ((transform = transform.parent) != null)
			{
				T val = transform.GetComponent(typeof(T)) as T;
				if (!IsNullOrDestroyed(val))
				{
					return val;
				}
			}
			int num = -1996816830;
			goto IL_0016;
			IL_0011:
			num = -1996816831;
			goto IL_0016;
			IL_0016:
			switch (num ^ -1996816832)
			{
			case 0:
				break;
			case 1:
				return result;
			default:
				return null;
			}
			goto IL_0011;
		}

		public static T GetComponentInSelfOrParents<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				return null;
			}
			return GetComponentInSelfOrParents<T>(gameObject.transform);
		}

		public static T GetComponentInSelfOrParents<T>(Component component) where T : class
		{
			if (component == null)
			{
				return null;
			}
			return GetComponentInSelfOrParents<T>(component.transform);
		}

		public static T GetComponentInSelfOrParents<T>(Transform transform) where T : class
		{
			T result = default(T);
			if (transform == null)
			{
				while (true)
				{
					int num = 660545324;
					while (true)
					{
						switch (num ^ 0x275F1F2D)
						{
						case 0:
							break;
						case 1:
							goto IL_0027;
						default:
							return result;
						}
						break;
						IL_0027:
						result = null;
						num = 660545327;
					}
				}
			}
			T val = transform.GetComponent(typeof(T)) as T;
			if (!IsNullOrDestroyed(val))
			{
				return val;
			}
			while ((transform = transform.parent) != null)
			{
				val = transform.GetComponent(typeof(T)) as T;
				if (!IsNullOrDestroyed(val))
				{
					return val;
				}
			}
			return null;
		}

		public static List<T> GetComponents<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return new List<T>();
			}
			return GetComponents<T>(transform.gameObject);
		}

		public static List<T> GetComponents<T>(Component component) where T : class
		{
			if (component == null)
			{
				return new List<T>();
			}
			return GetComponents<T>(component.gameObject);
		}

		public static List<T> GetComponents<T>(GameObject gameObject) where T : class
		{
			List<T> list = new List<T>();
			if (gameObject == null)
			{
				goto IL_000f;
			}
			Component[] components = gameObject.GetComponents(typeof(Component));
			if (components == null)
			{
				return list;
			}
			int num = 0;
			int num2 = -1634306858;
			goto IL_0014;
			IL_000f:
			num2 = -1634306862;
			goto IL_0014;
			IL_0014:
			while (true)
			{
				switch (num2 ^ -1634306861)
				{
				case 0:
					break;
				case 1:
					return list;
				case 5:
					num2 = -1634306857;
					continue;
				case 2:
					num++;
					num2 = -1634306857;
					continue;
				case 3:
					if (!IsNullOrDestroyed(components[num] as T))
					{
						list.Add(components[num] as T);
						num2 = -1634306863;
						continue;
					}
					goto case 2;
				default:
					if (num >= components.Length)
					{
						return list;
					}
					goto case 3;
				}
				break;
			}
			goto IL_000f;
		}

		public static List<T> GetComponents<T>(Transform transform, bool includeInactive) where T : class
		{
			if (transform == null)
			{
				return new List<T>();
			}
			return GetComponents<T>(transform.gameObject, includeInactive);
		}

		public static List<T> GetComponents<T>(Component component, bool includeInactive) where T : class
		{
			if (component == null)
			{
				return new List<T>();
			}
			return GetComponents<T>(component.gameObject, includeInactive);
		}

		public static List<T> GetComponents<T>(GameObject gameObject, bool includeInactive) where T : class
		{
			List<T> list = new List<T>();
			Component[] components = default(Component[]);
			int num2 = default(int);
			while (true)
			{
				int num = -954341527;
				while (true)
				{
					switch (num ^ -954341528)
					{
					case 4:
						break;
					case 3:
						list.Add(components[num2] as T);
						num = -954341523;
						continue;
					case 6:
						num = -954341526;
						continue;
					case 8:
						if (components == null)
						{
							num = -954341521;
							continue;
						}
						num2 = 0;
						num = -954341522;
						continue;
					case 5:
						num2++;
						num = -954341526;
						continue;
					case 1:
						if (gameObject == null)
						{
							return list;
						}
						components = gameObject.GetComponents(typeof(Component));
						num = -954341536;
						continue;
					case 0:
						if (!IsNullOrDestroyed(components[num2] as T))
						{
							if (!includeInactive)
							{
								int num3;
								if (!IsEnabled(components[num2]))
								{
									num = -954341523;
									num3 = num;
								}
								else
								{
									num = -954341525;
									num3 = num;
								}
								continue;
							}
							goto case 3;
						}
						goto case 5;
					case 7:
						return list;
					default:
						if (num2 >= components.Length)
						{
							return list;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public static List<Component> GetComponents(Transform transform, Type type)
		{
			if (transform == null)
			{
				return new List<Component>();
			}
			return GetComponents(transform.gameObject, type);
		}

		public static List<Component> GetComponents(Component component, Type type)
		{
			if (component == null)
			{
				return new List<Component>();
			}
			return GetComponents(component.gameObject, type);
		}

		public static List<Component> GetComponents(GameObject gameObject, Type type)
		{
			List<Component> list = new List<Component>();
			if (gameObject == null)
			{
				return list;
			}
			Component[] components = gameObject.GetComponents(type);
			while (true)
			{
				int num = -275618517;
				while (true)
				{
					switch (num ^ -275618519)
					{
					case 0:
						break;
					case 2:
						if (components != null)
						{
							goto IL_003c;
						}
						return list;
					default:
						return list;
					}
					break;
					IL_003c:
					list.AddRange(components);
					num = -275618520;
				}
			}
		}

		public static List<Component> GetComponents(Transform transform, Type type, bool includeInactive)
		{
			if (transform == null)
			{
				return new List<Component>();
			}
			return GetComponents(transform.gameObject, type, includeInactive);
		}

		public static List<Component> GetComponents(Component component, Type type, bool includeInactive)
		{
			if (component == null)
			{
				return new List<Component>();
			}
			return GetComponents(component.gameObject, type, includeInactive);
		}

		public static List<Component> GetComponents(GameObject gameObject, Type type, bool includeInactive)
		{
			List<Component> list = new List<Component>();
			if (gameObject == null)
			{
				return list;
			}
			Component[] components = gameObject.GetComponents(type);
			int num2 = default(int);
			while (true)
			{
				int num = -36639463;
				while (true)
				{
					switch (num ^ -36639462)
					{
					case 2:
						break;
					case 0:
					{
						int num3;
						if (num2 >= components.Length)
						{
							num = -36639458;
							num3 = num;
						}
						else
						{
							num = -36639457;
							num3 = num;
						}
						continue;
					}
					case 5:
						if (!includeInactive)
						{
							int num4;
							if (!IsEnabled(components[num2]))
							{
								num = -36639460;
								num4 = num;
							}
							else
							{
								num = -36639461;
								num4 = num;
							}
							continue;
						}
						goto case 1;
					case 6:
						num2++;
						num = -36639462;
						continue;
					case 1:
						list.Add(components[num2]);
						num = -36639460;
						continue;
					case 3:
						if (components == null)
						{
							return list;
						}
						num2 = 0;
						num = -36639462;
						continue;
					default:
						return list;
					}
					break;
				}
			}
		}

		public static List<T> GetComponentsInChildren<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			int num2 = default(int);
			int childCount = default(int);
			while (true)
			{
				List<T> list = new List<T>();
				int num = 495392807;
				while (true)
				{
					switch (num ^ 0x1D871825)
					{
					case 3:
						num = 495392804;
						continue;
					case 4:
						GetComponentsInSelfAndChildren(transform.GetChild(num2), list, true);
						num2++;
						num = 495392805;
						continue;
					case 2:
						childCount = transform.childCount;
						num2 = 0;
						num = 495392805;
						continue;
					case 1:
						break;
					default:
						if (num2 >= childCount)
						{
							return list;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public static List<T> GetComponentsInChildren<T>(Component component) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInChildren<T>(component.transform);
		}

		public static List<T> GetComponentsInChildren<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInChildren<T>(gameObject.transform);
		}

		public static List<T> GetComponentsInChildren<T>(Transform transform, bool includeInactive) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			int num2 = default(int);
			int childCount = default(int);
			while (true)
			{
				List<T> list = new List<T>();
				int num = 1687417378;
				while (true)
				{
					switch (num ^ 0x6493F222)
					{
					case 2:
						num = 1687417377;
						continue;
					case 4:
						GetComponentsInSelfAndChildren(transform.GetChild(num2), includeInactive, list, true);
						num2++;
						num = 1687417379;
						continue;
					case 0:
						childCount = transform.childCount;
						num2 = 0;
						num = 1687417379;
						continue;
					case 3:
						break;
					default:
						if (num2 >= childCount)
						{
							return list;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		public static List<T> GetComponentsInChildren<T>(Component component, bool includeInactive) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInChildren<T>(component.transform, includeInactive);
		}

		public static List<T> GetComponentsInChildren<T>(GameObject gameObject, bool includeInactive) where T : class
		{
			if (gameObject == null)
			{
				while (true)
				{
					switch (-762410158 ^ -762410157)
					{
					case 2:
						continue;
					case 1:
						throw new ArgumentNullException("gameObject");
					}
					break;
				}
			}
			return GetComponentsInChildren<T>(gameObject.transform, includeInactive);
		}

		public static List<Component> GetComponentsInChildren(Transform transform)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			while (true)
			{
				List<Component> list = new List<Component>();
				int childCount = transform.childCount;
				int num = 0;
				int num2 = 1331536669;
				while (true)
				{
					switch (num2 ^ 0x4F5DA31F)
					{
					case 0:
						num2 = 1331536667;
						continue;
					case 4:
						break;
					case 2:
						num2 = 1331536670;
						continue;
					case 3:
						GetComponentsInSelfAndChildren(transform.GetChild(num), list, true);
						num++;
						num2 = 1331536670;
						continue;
					default:
						if (num >= childCount)
						{
							return list;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public static List<Component> GetComponentsInChildren(Component component)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInChildren(component.transform);
		}

		public static List<Component> GetComponentsInChildren(GameObject gameObject)
		{
			if (gameObject == null)
			{
				while (true)
				{
					switch (-1284968144 ^ -1284968143)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("gameObject");
					}
					break;
				}
			}
			return GetComponentsInChildren(gameObject.transform);
		}

		public static List<T> GetComponentsInSelfAndChildren<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return new List<T>();
			}
			return GetComponentsInSelfAndChildren<T>(transform.gameObject);
		}

		public static List<T> GetComponentsInSelfAndChildren<T>(Component component) where T : class
		{
			if (component == null)
			{
				return new List<T>();
			}
			return GetComponentsInSelfAndChildren<T>(component.gameObject);
		}

		public static List<T> GetComponentsInSelfAndChildren<T>(GameObject gameObject) where T : class
		{
			List<T> list = new List<T>();
			if (gameObject == null)
			{
				goto IL_000f;
			}
			Component[] componentsInChildren = gameObject.GetComponentsInChildren(typeof(Component), true);
			if (componentsInChildren == null)
			{
				return list;
			}
			int num = 0;
			int num2 = -772855935;
			goto IL_0014;
			IL_000f:
			num2 = -772855936;
			goto IL_0014;
			IL_0014:
			while (true)
			{
				switch (num2 ^ -772855935)
				{
				case 3:
					break;
				case 1:
					return list;
				case 0:
				{
					int num3;
					if (num >= componentsInChildren.Length)
					{
						num2 = -772855931;
						num3 = num2;
					}
					else
					{
						num2 = -772855932;
						num3 = num2;
					}
					continue;
				}
				case 5:
					if (!IsNullOrDestroyed(componentsInChildren[num] as T))
					{
						list.Add(componentsInChildren[num] as T);
						num2 = -772855933;
						continue;
					}
					goto case 2;
				case 2:
					num++;
					num2 = -772855935;
					continue;
				default:
					return list;
				}
				break;
			}
			goto IL_000f;
		}

		public static List<T> GetComponentsInParents<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			Transform transform2 = default(Transform);
			while (true)
			{
				List<T> list = new List<T>();
				int num = 10137262;
				while (true)
				{
					switch (num ^ 0x9AAEAA)
					{
					case 2:
						num = 10137259;
						continue;
					case 1:
						break;
					case 0:
						GetComponents(transform2, list, true);
						num = 10137257;
						continue;
					case 4:
						transform2 = transform;
						num = 10137257;
						continue;
					default:
						if (!((transform2 = transform2.parent) != null))
						{
							return list;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public static List<T> GetComponentsInParents<T>(Component component) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInParents<T>(component.transform);
		}

		public static List<T> GetComponentsInParents<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInParents<T>(gameObject.transform);
		}

		public static List<Component> GetComponentsInParents(Transform transform)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			while (true)
			{
				List<Component> list = new List<Component>();
				Transform transform2 = transform;
				int num = -545795992;
				while (true)
				{
					switch (num ^ -545795990)
					{
					case 0:
						num = -545795986;
						continue;
					case 4:
						break;
					case 1:
						GetComponents(transform2, list, true);
						num = -545795992;
						continue;
					case 2:
					{
						int num2;
						if ((transform2 = transform2.parent) != null)
						{
							num = -545795989;
							num2 = num;
						}
						else
						{
							num = -545795991;
							num2 = num;
						}
						continue;
					}
					default:
						return list;
					}
					break;
				}
			}
		}

		public static List<Component> GetComponentsInParents(Component component)
		{
			if (component == null)
			{
				while (true)
				{
					switch (-1893801067 ^ -1893801068)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("component");
					}
					break;
				}
			}
			return GetComponentsInParents(component.transform);
		}

		public static List<Component> GetComponentsInParents(GameObject gameObject)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInParents(gameObject.transform);
		}

		public static int GetComponents<T>(Transform transform, List<T> results, bool append) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return GetComponents(transform.gameObject, results, append);
		}

		public static int GetComponents<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				while (true)
				{
					switch (-110070787 ^ -110070788)
					{
					case 2:
						continue;
					case 1:
						throw new ArgumentNullException("component");
					}
					break;
				}
			}
			return GetComponents(component.gameObject, results, append);
		}

		public static int GetComponents<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				goto IL_0009;
			}
			goto IL_0041;
			IL_0009:
			int num = -1720351257;
			goto IL_000e;
			IL_000e:
			switch (num ^ -1720351260)
			{
			case 4:
				break;
			case 3:
				throw new ArgumentNullException("gameObject");
			case 0:
				goto IL_0041;
			case 1:
				goto IL_0056;
			default:
				goto IL_0066;
			}
			goto IL_0009;
			IL_0041:
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			goto IL_0056;
			IL_0066:
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				gameObject.GetComponents(list);
				int count = list.Count;
				int num2 = 0;
				T val = default(T);
				while (true)
				{
					IL_0083:
					int num3 = -1720351257;
					while (true)
					{
						switch (num3 ^ -1720351260)
						{
						case 0:
							break;
						case 4:
							results.Add(val);
							num3 = -1720351263;
							continue;
						case 2:
						{
							val = list[num2] as T;
							int num4;
							if (!IsNullOrDestroyed(val))
							{
								num3 = -1720351264;
								num4 = num3;
							}
							else
							{
								num3 = -1720351263;
								num4 = num3;
							}
							continue;
						}
						case 5:
							num2++;
							num3 = -1720351259;
							continue;
						case 3:
							num3 = -1720351259;
							continue;
						default:
							if (num2 >= count)
							{
								goto end_IL_0088;
							}
							goto case 2;
						}
						goto IL_0083;
						continue;
						end_IL_0088:
						break;
					}
					break;
				}
			}
			return results.Count;
			IL_0056:
			if (!append)
			{
				results.Clear();
				num = -1720351258;
				goto IL_000e;
			}
			goto IL_0066;
		}

		public static int GetComponents<T>(Transform transform, bool includeInactive, List<T> results, bool append) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return GetComponents(transform.gameObject, includeInactive, results, append);
		}

		public static int GetComponents<T>(Component component, bool includeInactive, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponents(component.gameObject, includeInactive, results, append);
		}

		public static int GetComponents<T>(GameObject gameObject, bool includeInactive, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				goto IL_0009;
			}
			goto IL_0041;
			IL_0009:
			int num = 405816908;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x1830464D)
			{
			case 0:
				break;
			case 1:
				throw new ArgumentNullException("gameObject");
			case 4:
				goto IL_0041;
			case 2:
				goto IL_0056;
			default:
				goto IL_0066;
			}
			goto IL_0009;
			IL_0066:
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				gameObject.GetComponents(list);
				int count = default(int);
				int num3 = default(int);
				T val = default(T);
				while (true)
				{
					IL_007a:
					int num2 = 405816901;
					while (true)
					{
						switch (num2 ^ 0x1830464D)
						{
						case 0:
							break;
						default:
							goto end_IL_007f;
						case 8:
							count = list.Count;
							num2 = 405816910;
							continue;
						case 3:
							num3 = 0;
							num2 = 405816911;
							continue;
						case 2:
							num2 = 405816907;
							continue;
						case 5:
							num3++;
							num2 = 405816907;
							continue;
						case 1:
							results.Add(val);
							num2 = 405816904;
							continue;
						case 6:
						{
							int num6;
							if (num3 < count)
							{
								num2 = 405816900;
								num6 = num2;
							}
							else
							{
								num2 = 405816905;
								num6 = num2;
							}
							continue;
						}
						case 7:
						{
							int num5;
							if (IsEnabled(list[num3]))
							{
								num2 = 405816908;
								num5 = num2;
							}
							else
							{
								num2 = 405816904;
								num5 = num2;
							}
							continue;
						}
						case 9:
							val = list[num3] as T;
							if (!IsNullOrDestroyed(val))
							{
								int num4;
								if (!includeInactive)
								{
									num2 = 405816906;
									num4 = num2;
								}
								else
								{
									num2 = 405816908;
									num4 = num2;
								}
								continue;
							}
							goto case 5;
						case 4:
							goto end_IL_007f;
						}
						goto IL_007a;
						continue;
						end_IL_007f:
						break;
					}
					break;
				}
			}
			return results.Count;
			IL_0041:
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			goto IL_0056;
			IL_0056:
			if (!append)
			{
				results.Clear();
				num = 405816910;
				goto IL_000e;
			}
			goto IL_0066;
		}

		public static int GetComponents(Transform transform, List<Component> results, bool append)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return GetComponents(transform.gameObject, results, append);
		}

		public static int GetComponents(Component component, List<Component> results, bool append)
		{
			if (component == null)
			{
				while (true)
				{
					switch (0x7DE3F1D0 ^ 0x7DE3F1D1)
					{
					case 2:
						continue;
					case 1:
						throw new ArgumentNullException("component");
					}
					break;
				}
			}
			return GetComponents(component.gameObject, results, append);
		}

		public static int GetComponents(GameObject gameObject, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				goto IL_0009;
			}
			goto IL_0041;
			IL_0009:
			int num = 366438441;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x15D76828)
			{
			case 4:
				break;
			case 1:
				throw new ArgumentNullException("gameObject");
			case 3:
				goto IL_0041;
			case 2:
				goto IL_0056;
			default:
				goto IL_0066;
			}
			goto IL_0009;
			IL_0066:
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				Component component = default(Component);
				int num3 = default(int);
				int count = default(int);
				while (true)
				{
					IL_0073:
					int num2 = 366438447;
					while (true)
					{
						switch (num2 ^ 0x15D76828)
						{
						case 0:
							break;
						default:
							goto end_IL_0078;
						case 3:
							if (!(component == null))
							{
								results.Add(component);
								num2 = 366438445;
								continue;
							}
							goto case 5;
						case 1:
							component = list[num3];
							num2 = 366438443;
							continue;
						case 5:
							num3++;
							num2 = 366438444;
							continue;
						case 4:
						{
							int num4;
							if (num3 < count)
							{
								num2 = 366438441;
								num4 = num2;
							}
							else
							{
								num2 = 366438446;
								num4 = num2;
							}
							continue;
						}
						case 2:
							count = list.Count;
							num3 = 0;
							num2 = 366438444;
							continue;
						case 7:
							gameObject.GetComponents(list);
							num2 = 366438442;
							continue;
						case 6:
							goto end_IL_0078;
						}
						goto IL_0073;
						continue;
						end_IL_0078:
						break;
					}
					break;
				}
			}
			return results.Count;
			IL_0041:
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			goto IL_0056;
			IL_0056:
			if (!append)
			{
				results.Clear();
				num = 366438440;
				goto IL_000e;
			}
			goto IL_0066;
		}

		public static int GetComponents(Transform transform, Type type, List<Component> results, bool append)
		{
			if (transform == null)
			{
				while (true)
				{
					switch (-2063892945 ^ -2063892947)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentNullException("transform");
					}
					break;
				}
			}
			return GetComponents(transform.gameObject, type, results, append);
		}

		public static int GetComponents(Component component, Type type, List<Component> results, bool append)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponents(component.gameObject, type, results, append);
		}

		public static int GetComponents(GameObject gameObject, Type type, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				goto IL_0009;
			}
			goto IL_0066;
			IL_0009:
			int num = -2053663910;
			goto IL_000e;
			IL_000e:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -2053663909)
				{
				case 4:
					break;
				case 1:
					throw new ArgumentNullException("gameObject");
				case 5:
					results.Clear();
					num = -2053663911;
					continue;
				case 0:
					goto IL_0052;
				case 3:
					goto IL_0066;
				default:
				{
					using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
					{
						List<Component> list = tList.list;
						gameObject.GetComponents(type, list);
						int count = list.Count;
						while (true)
						{
							IL_0097:
							int num2 = -2053663906;
							while (true)
							{
								switch (num2 ^ -2053663909)
								{
								case 0:
									break;
								default:
									goto end_IL_009c;
								case 5:
									num3 = 0;
									num2 = -2053663910;
									continue;
								case 2:
								{
									int num4;
									if (num3 < count)
									{
										num2 = -2053663907;
										num4 = num2;
									}
									else
									{
										num2 = -2053663905;
										num4 = num2;
									}
									continue;
								}
								case 1:
									num2 = -2053663911;
									continue;
								case 6:
								{
									Component component = list[num3];
									if (!(component == null))
									{
										results.Add(component);
										num2 = -2053663912;
										continue;
									}
									goto case 3;
								}
								case 3:
									num3++;
									num2 = -2053663911;
									continue;
								case 4:
									goto end_IL_009c;
								}
								goto IL_0097;
								continue;
								end_IL_009c:
								break;
							}
							break;
						}
					}
					return results.Count;
				}
				}
				break;
			}
			goto IL_0009;
			IL_0052:
			int num5;
			if (!append)
			{
				num = -2053663906;
				num5 = num;
			}
			else
			{
				num = -2053663911;
				num5 = num;
			}
			goto IL_000e;
			IL_0066:
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			goto IL_0052;
		}

		public static int GetComponentsInSelfAndChildren(Transform transform, List<Component> results, bool append)
		{
			if (results == null)
			{
				goto IL_0003;
			}
			goto IL_003b;
			IL_0003:
			int num = 1753233905;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x688039F0)
			{
			case 0:
				break;
			case 1:
				throw new ArgumentNullException("results");
			case 2:
				goto IL_003b;
			case 4:
				goto IL_0056;
			default:
				goto IL_0066;
			}
			goto IL_0003;
			IL_0066:
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				int count = default(int);
				int num3 = default(int);
				Component component = default(Component);
				while (true)
				{
					IL_0073:
					int num2 = 1753233906;
					while (true)
					{
						switch (num2 ^ 0x688039F0)
						{
						case 6:
							break;
						case 2:
							transform.GetComponents(list);
							count = list.Count;
							num2 = 1753233905;
							continue;
						case 0:
							num3++;
							num2 = 1753233909;
							continue;
						case 4:
							if (!(component == null))
							{
								results.Add(component);
								num2 = 1753233904;
								continue;
							}
							goto case 0;
						case 3:
							component = list[num3];
							num2 = 1753233908;
							continue;
						case 1:
							num3 = 0;
							num2 = 1753233909;
							continue;
						default:
							if (num3 >= count)
							{
								goto end_IL_0078;
							}
							goto case 3;
						}
						goto IL_0073;
						continue;
						end_IL_0078:
						break;
					}
					break;
				}
			}
			int childCount = transform.childCount;
			int num5 = default(int);
			while (true)
			{
				int num4 = 1753233905;
				while (true)
				{
					switch (num4 ^ 0x688039F0)
					{
					case 3:
						break;
					case 1:
						num5 = 0;
						num4 = 1753233906;
						continue;
					case 0:
						GetComponentsInSelfAndChildren(transform.GetChild(num5), results, true);
						num5++;
						num4 = 1753233906;
						continue;
					default:
						if (num5 >= childCount)
						{
							return results.Count;
						}
						goto case 0;
					}
					break;
				}
			}
			IL_003b:
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			goto IL_0056;
			IL_0056:
			if (!append)
			{
				results.Clear();
				num = 1753233907;
				goto IL_0008;
			}
			goto IL_0066;
		}

		public static int GetComponentsInSelfAndChildren(Component component, List<Component> results, bool append)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInSelfAndChildren(component.transform, results, append);
		}

		public static int GetComponentsInSelfAndChildren(GameObject gameObject, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				while (true)
				{
					switch (0x47D91B3E ^ 0x47D91B3C)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentNullException("gameObject");
					}
					break;
				}
			}
			return GetComponentsInSelfAndChildren(gameObject.transform, results, append);
		}

		public static int GetComponentsInSelfAndChildren<T>(Transform transform, List<T> results, bool append) where T : class
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			int count = default(int);
			int num4 = default(int);
			T val = default(T);
			while (!(transform == null))
			{
				while (true)
				{
					IL_004f:
					int num;
					int num2;
					if (!append)
					{
						num = -1550975386;
						num2 = num;
					}
					else
					{
						num = -1550975391;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1550975387)
						{
						case 0:
							num = -1550975388;
							continue;
						case 1:
							break;
						case 2:
							goto IL_004f;
						case 3:
							results.Clear();
							num = -1550975391;
							continue;
						default:
						{
							using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
							{
								List<Component> list = tList.list;
								while (true)
								{
									IL_007d:
									int num3 = -1550975388;
									while (true)
									{
										switch (num3 ^ -1550975387)
										{
										case 5:
											break;
										case 1:
											transform.GetComponents(list);
											count = list.Count;
											num4 = 0;
											num3 = -1550975391;
											continue;
										case 3:
										{
											val = list[num4] as T;
											int num5;
											if (IsNullOrDestroyed(val))
											{
												num3 = -1550975385;
												num5 = num3;
											}
											else
											{
												num3 = -1550975387;
												num5 = num3;
											}
											continue;
										}
										case 2:
											num4++;
											num3 = -1550975391;
											continue;
										case 0:
											results.Add(val);
											num3 = -1550975385;
											continue;
										default:
											if (num4 >= count)
											{
												goto end_IL_0082;
											}
											goto case 3;
										}
										goto IL_007d;
										continue;
										end_IL_0082:
										break;
									}
									break;
								}
							}
							int childCount = transform.childCount;
							int num6 = 0;
							while (true)
							{
								int num7 = -1550975386;
								while (true)
								{
									switch (num7 ^ -1550975387)
									{
									case 0:
										break;
									case 3:
										num7 = -1550975388;
										continue;
									case 2:
										GetComponentsInSelfAndChildren(transform.GetChild(num6), results, true);
										num6++;
										num7 = -1550975388;
										continue;
									default:
										if (num6 >= childCount)
										{
											return results.Count;
										}
										goto case 2;
									}
									break;
								}
							}
						}
						}
						break;
					}
					break;
				}
			}
			throw new ArgumentNullException("transform");
		}

		public static int GetComponentsInSelfAndChildren<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInSelfAndChildren(component.transform, results, append);
		}

		public static int GetComponentsInSelfAndChildren<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInSelfAndChildren(gameObject.transform, results, append);
		}

		public static int GetComponentsInSelfAndChildren<T>(Transform transform, bool includeInactive, List<T> results, bool append) where T : class
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			T val = default(T);
			while (true)
			{
				int num;
				int num2;
				if (!(transform == null))
				{
					num = -1967701764;
					num2 = num;
				}
				else
				{
					num = -1967701761;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1967701764)
					{
					case 2:
						num = -1967701763;
						continue;
					case 0:
						if (!append)
						{
							results.Clear();
							num = -1967701768;
							continue;
						}
						goto default;
					case 3:
						throw new ArgumentNullException("transform");
					case 1:
						break;
					default:
					{
						using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
						{
							List<Component> list = tList.list;
							transform.GetComponents(list);
							int count = list.Count;
							int num3 = 0;
							while (true)
							{
								IL_008d:
								int num4 = -1967701767;
								while (true)
								{
									switch (num4 ^ -1967701764)
									{
									case 3:
										break;
									case 6:
										if (!includeInactive)
										{
											int num6;
											if (IsEnabled(list[num3]))
											{
												num4 = -1967701768;
												num6 = num4;
											}
											else
											{
												num4 = -1967701763;
												num6 = num4;
											}
											continue;
										}
										goto case 4;
									case 4:
										results.Add(val);
										num4 = -1967701763;
										continue;
									case 5:
										num4 = -1967701762;
										continue;
									case 0:
									{
										val = list[num3] as T;
										int num5;
										if (!IsNullOrDestroyed(val))
										{
											num4 = -1967701766;
											num5 = num4;
										}
										else
										{
											num4 = -1967701763;
											num5 = num4;
										}
										continue;
									}
									case 1:
										num3++;
										num4 = -1967701762;
										continue;
									default:
										if (num3 >= count)
										{
											goto end_IL_0092;
										}
										goto case 0;
									}
									goto IL_008d;
									continue;
									end_IL_0092:
									break;
								}
								break;
							}
						}
						int childCount = transform.childCount;
						int num7 = 0;
						while (true)
						{
							int num8 = -1967701768;
							while (true)
							{
								switch (num8 ^ -1967701764)
								{
								case 3:
									break;
								case 4:
									num8 = -1967701767;
									continue;
								case 0:
									num7++;
									num8 = -1967701767;
									continue;
								case 5:
								{
									int num9;
									if (num7 >= childCount)
									{
										num8 = -1967701763;
										num9 = num8;
									}
									else
									{
										num8 = -1967701762;
										num9 = num8;
									}
									continue;
								}
								case 2:
									GetComponentsInSelfAndChildren(transform.GetChild(num7), includeInactive, results, true);
									num8 = -1967701764;
									continue;
								default:
									return results.Count;
								}
								break;
							}
						}
					}
					}
					break;
				}
			}
		}

		public static int GetComponentsInSelfAndChildren<T>(Component component, bool includeInactive, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInSelfAndChildren(component.transform, includeInactive, results, append);
		}

		public static int GetComponentsInSelfAndChildren<T>(GameObject gameObject, bool includeInactive, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				while (true)
				{
					switch (-688926636 ^ -688926635)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("gameObject");
					}
					break;
				}
			}
			return GetComponentsInSelfAndChildren(gameObject.transform, includeInactive, results, append);
		}

		public static int GetComponentsInChildren<T>(Transform transform, List<T> results, bool append) where T : class
		{
			if (results == null)
			{
				goto IL_0003;
			}
			goto IL_0078;
			IL_0003:
			int num = 2017288466;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			int childCount = default(int);
			while (true)
			{
				switch (num ^ 0x783D6113)
				{
				case 0:
					break;
				case 4:
					GetComponentsInSelfAndChildren(transform.GetChild(num2), results, true);
					num2++;
					num = 2017288464;
					continue;
				case 2:
					num2 = 0;
					num = 2017288464;
					continue;
				case 1:
					throw new ArgumentNullException("results");
				case 6:
					goto IL_006a;
				case 7:
					goto IL_0078;
				case 5:
					goto IL_0096;
				default:
					if (num2 >= childCount)
					{
						return results.Count;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0003;
			IL_006a:
			childCount = transform.childCount;
			num = 2017288465;
			goto IL_0008;
			IL_0096:
			if (!append)
			{
				results.Clear();
				num = 2017288469;
				goto IL_0008;
			}
			goto IL_006a;
			IL_0078:
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			goto IL_0096;
		}

		public static int GetComponentsInChildren<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				while (true)
				{
					switch (0x5C02AD86 ^ 0x5C02AD87)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("component");
					}
					break;
				}
			}
			return GetComponentsInChildren(component.transform, results, append);
		}

		public static int GetComponentsInChildren<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				while (true)
				{
					switch (0x3AF2E0AC ^ 0x3AF2E0AE)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentNullException("gameObject");
					}
					break;
				}
			}
			return GetComponentsInChildren(gameObject.transform, results, append);
		}

		public static int GetComponentsInChildren<T>(Transform transform, bool includeInactive, List<T> results, bool append) where T : class
		{
			if (results == null)
			{
				goto IL_0003;
			}
			goto IL_0078;
			IL_0003:
			int num = 1953377217;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			int childCount = default(int);
			while (true)
			{
				switch (num ^ 0x746E2BC2)
				{
				case 5:
					break;
				case 0:
					GetComponentsInSelfAndChildren(transform.GetChild(num2), includeInactive, results, true);
					num2++;
					num = 1953377219;
					continue;
				case 7:
					results.Clear();
					num = 1953377220;
					continue;
				case 6:
					childCount = transform.childCount;
					num2 = 0;
					num = 1953377222;
					continue;
				case 2:
					goto IL_0078;
				case 8:
					goto IL_0096;
				case 4:
					num = 1953377219;
					continue;
				case 1:
					goto IL_00b7;
				case 3:
					throw new ArgumentNullException("results");
				default:
					return results.Count;
				}
				break;
				IL_00b7:
				int num3;
				if (num2 < childCount)
				{
					num = 1953377218;
					num3 = num;
				}
				else
				{
					num = 1953377227;
					num3 = num;
				}
			}
			goto IL_0003;
			IL_0096:
			int num4;
			if (append)
			{
				num = 1953377220;
				num4 = num;
			}
			else
			{
				num = 1953377221;
				num4 = num;
			}
			goto IL_0008;
			IL_0078:
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			goto IL_0096;
		}

		public static int GetComponentsInChildren<T>(Component component, bool includeInactive, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInChildren(component.transform, includeInactive, results, append);
		}

		public static int GetComponentsInChildren<T>(GameObject gameObject, bool includeInactive, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInChildren(gameObject.transform, includeInactive, results, append);
		}

		public static int GetComponentsInChildren(Transform transform, List<Component> results, bool append)
		{
			if (results == null)
			{
				goto IL_0003;
			}
			goto IL_004b;
			IL_0003:
			int num = -909451642;
			goto IL_0008;
			IL_0008:
			int childCount = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -909451645)
				{
				case 7:
					break;
				case 10:
					num = -909451643;
					continue;
				case 1:
					goto IL_004b;
				case 2:
					results.Clear();
					num = -909451637;
					continue;
				case 5:
					throw new ArgumentNullException("results");
				case 8:
					childCount = transform.childCount;
					num2 = 0;
					num = -909451639;
					continue;
				case 4:
					goto IL_0097;
				case 9:
					throw new ArgumentNullException("transform");
				case 0:
					GetComponentsInSelfAndChildren(transform.GetChild(num2), results, true);
					num = -909451648;
					continue;
				case 3:
					num2++;
					num = -909451643;
					continue;
				default:
					if (num2 >= childCount)
					{
						return results.Count;
					}
					goto case 0;
				}
				break;
				IL_0097:
				int num3;
				if (append)
				{
					num = -909451637;
					num3 = num;
				}
				else
				{
					num = -909451647;
					num3 = num;
				}
			}
			goto IL_0003;
			IL_004b:
			int num4;
			if (!(transform == null))
			{
				num = -909451641;
				num4 = num;
			}
			else
			{
				num = -909451638;
				num4 = num;
			}
			goto IL_0008;
		}

		public static int GetComponentsInChildren(Component component, List<Component> results, bool append)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInChildren(component.transform, results, append);
		}

		public static int GetComponentsInChildren(GameObject gameObject, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				while (true)
				{
					switch (0x22F7EB15 ^ 0x22F7EB17)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentNullException("gameObject");
					}
					break;
				}
			}
			return GetComponentsInChildren(gameObject.transform, results, append);
		}

		public static int GetComponentsInParents<T>(Transform transform, List<T> results, bool append) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return GetComponentsInParents(transform.gameObject, results, append);
		}

		public static int GetComponentsInParents<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInParents(component.gameObject, results, append);
		}

		public static int GetComponentsInParents<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			Transform parent = default(Transform);
			while (results != null)
			{
				while (true)
				{
					IL_00a9:
					int num;
					if (!append)
					{
						results.Clear();
						num = -734444801;
						goto IL_0019;
					}
					goto IL_0093;
					IL_0019:
					while (true)
					{
						switch (num ^ -734444808)
						{
						case 6:
							num = -734444804;
							continue;
						case 4:
							break;
						case 2:
							goto IL_005b;
						case 1:
							GetComponents(parent, results, true);
							num = -734444806;
							continue;
						case 5:
							num = -734444806;
							continue;
						case 7:
							goto IL_0093;
						case 3:
							goto IL_00a9;
						default:
							return results.Count;
						}
						break;
						IL_005b:
						int num2;
						if (!((parent = parent.parent) != null))
						{
							num = -734444808;
							num2 = num;
						}
						else
						{
							num = -734444807;
							num2 = num;
						}
					}
					break;
					IL_0093:
					parent = gameObject.transform.parent;
					num = -734444803;
					goto IL_0019;
				}
			}
			throw new ArgumentNullException("results");
		}

		public static int GetComponentsInParents(Transform transform, List<Component> results, bool append)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return GetComponentsInParents(transform.gameObject, results, append);
		}

		public static int GetComponentsInParents(Component component, List<Component> results, bool append)
		{
			if (component == null)
			{
				while (true)
				{
					switch (-359598043 ^ -359598044)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("component");
					}
					break;
				}
			}
			return GetComponentsInParents(component.gameObject, results, append);
		}

		public static int GetComponentsInParents(GameObject gameObject, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				goto IL_000c;
			}
			goto IL_009a;
			IL_000c:
			int num = 146127863;
			goto IL_0011;
			IL_0011:
			Transform parent = default(Transform);
			while (true)
			{
				switch (num ^ 0x8B5BBF4)
				{
				case 0:
					break;
				case 1:
					goto IL_0041;
				case 6:
					goto IL_0054;
				case 4:
					GetComponents(parent, results, true);
					num = 146127858;
					continue;
				case 3:
					throw new ArgumentNullException("gameObject");
				case 2:
					goto IL_009a;
				case 7:
					goto IL_00b2;
				default:
					return results.Count;
				}
				break;
				IL_0054:
				int num2;
				if ((parent = parent.parent) != null)
				{
					num = 146127856;
					num2 = num;
				}
				else
				{
					num = 146127857;
					num2 = num;
				}
			}
			goto IL_000c;
			IL_009a:
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			goto IL_00b2;
			IL_0041:
			parent = gameObject.transform.parent;
			num = 146127858;
			goto IL_0011;
			IL_00b2:
			if (!append)
			{
				results.Clear();
				num = 146127861;
				goto IL_0011;
			}
			goto IL_0041;
		}

		public static void ForEachComponent<T>(Transform transform, Action<T> @delegate, bool includeChildren) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (@delegate == null)
			{
				throw new ArgumentNullException("@delegate");
			}
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				transform.GetComponents(list);
				int count = list.Count;
				int num2 = default(int);
				while (true)
				{
					IL_0062:
					int num = 1669367794;
					while (true)
					{
						switch (num ^ 0x638087F3)
						{
						case 0:
							break;
						case 1:
							num2 = 0;
							num = 1669367799;
							continue;
						case 3:
							num2++;
							num = 1669367799;
							continue;
						case 2:
						{
							T val = list[num2] as T;
							if (!IsNullOrDestroyed(val))
							{
								@delegate(val);
								num = 1669367792;
								continue;
							}
							goto case 3;
						}
						default:
							if (num2 >= count)
							{
								goto end_IL_0067;
							}
							goto case 2;
						}
						goto IL_0062;
						continue;
						end_IL_0067:
						break;
					}
					break;
				}
			}
			if (!includeChildren)
			{
				return;
			}
			int childCount = transform.childCount;
			int num4 = default(int);
			while (true)
			{
				int num3 = 1669367799;
				while (true)
				{
					switch (num3 ^ 0x638087F3)
					{
					case 0:
						break;
					default:
						return;
					case 3:
					{
						int num5;
						if (num4 < childCount)
						{
							num3 = 1669367794;
							num5 = num3;
						}
						else
						{
							num3 = 1669367793;
							num5 = num3;
						}
						continue;
					}
					case 1:
						ForEachComponent(transform.GetChild(num4), @delegate, includeChildren);
						num4++;
						num3 = 1669367792;
						continue;
					case 4:
						num4 = 0;
						num3 = 1669367792;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		public static void ForEachComponent<T>(Transform transform, Action<T> @delegate) where T : class
		{
			ForEachComponent(transform, @delegate, false);
		}

		public static void ForEachComponent<T>(Component component, Action<T> @delegate, bool includeChildren) where T : class
		{
			ForEachComponent(component.transform, @delegate, includeChildren);
		}

		public static void ForEachComponent<T>(Component component, Action<T> @delegate) where T : class
		{
			ForEachComponent(component.transform, @delegate, false);
		}

		public static void ForEachComponent<T>(GameObject gameObject, Action<T> @delegate, bool includeChildren) where T : class
		{
			ForEachComponent(gameObject.transform, @delegate, includeChildren);
		}

		public static void ForEachComponent<T>(GameObject gameObject, Action<T> @delegate) where T : class
		{
			ForEachComponent(gameObject.transform, @delegate, false);
		}

		public static void ForEachComponentInChildren<T>(Transform transform, Action<T> @delegate) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			int num3 = default(int);
			int childCount = default(int);
			while (true)
			{
				int num;
				int num2;
				if (@delegate == null)
				{
					num = -239643074;
					num2 = num;
				}
				else
				{
					num = -239643077;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -239643075)
					{
					case 4:
						num = -239643076;
						continue;
					case 1:
						break;
					case 0:
						num3++;
						num = -239643080;
						continue;
					case 2:
						ForEachComponent(transform.GetChild(num3), @delegate, true);
						num = -239643075;
						continue;
					case 3:
						throw new ArgumentNullException("@delegate");
					case 6:
						childCount = transform.childCount;
						num3 = 0;
						num = -239643080;
						continue;
					default:
						if (num3 >= childCount)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public static void ForEachComponentInChildren<T>(Component component, Action<T> @delegate) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			ForEachComponentInChildren(component.transform, @delegate);
		}

		public static void ForEachComponentInChildren<T>(GameObject gameObject, Action<T> @delegate) where T : class
		{
			if (gameObject == null)
			{
				goto IL_0009;
			}
			goto IL_003d;
			IL_0009:
			int num = 530247500;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x1F9AEF4D)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				throw new ArgumentNullException("gameObject");
			case 3:
				goto IL_003d;
			case 2:
				return;
			}
			goto IL_0009;
			IL_003d:
			ForEachComponentInChildren(gameObject.transform, @delegate);
			num = 530247503;
			goto IL_000e;
		}

		public static bool IsEnabled(Component component)
		{
			if (component == null)
			{
				goto IL_0009;
			}
			Behaviour behaviour = component as Behaviour;
			int num;
			if (behaviour != null)
			{
				num = 1051073467;
				goto IL_000e;
			}
			goto IL_004a;
			IL_004a:
			return true;
			IL_0040:
			if (!behaviour.enabled)
			{
				return false;
			}
			goto IL_004a;
			IL_0009:
			num = 1051073464;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x3EA61BB9)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				goto IL_0040;
			}
			goto IL_0009;
		}

		public static bool IsActiveAndEnabled(Component component)
		{
			if (component == null)
			{
				return false;
			}
			Behaviour behaviour = component as Behaviour;
			if (behaviour != null)
			{
				return behaviour.isActiveAndEnabled;
			}
			if (!component.gameObject.activeInHierarchy)
			{
				return false;
			}
			return true;
		}

		public static UnityEngine.Object Instantiate(UnityEngine.Object original, Transform parent, bool instantiateInWorldSpace)
		{
			return Instantiate<UnityEngine.Object>(original, Vector3.zero, Quaternion.identity, parent, instantiateInWorldSpace);
		}

		public static UnityEngine.Object Instantiate(UnityEngine.Object original, Vector3 position, Quaternion rotation, Transform parent, bool instantiateInWorldSpace)
		{
			return Instantiate<UnityEngine.Object>(original, position, rotation, parent, instantiateInWorldSpace);
		}

		public static T Instantiate<T>(UnityEngine.Object original, Transform parent, bool instantiateInWorldSpace) where T : UnityEngine.Object
		{
			return Instantiate<T>(original, Vector3.zero, Quaternion.identity, parent, instantiateInWorldSpace);
		}

		public static T Instantiate<T>(UnityEngine.Object original, Vector3 position, Quaternion rotation, Transform parent, bool instantiateInWorldSpace) where T : UnityEngine.Object
		{
			T result = default(T);
			if (original == null)
			{
				result = null;
				goto IL_0014;
			}
			UnityEngine.Object obj = UnityEngine.Object.Instantiate(original);
			Transform transform = default(Transform);
			int num;
			if (parent != null)
			{
				transform = null;
				int num2;
				if (obj as Component != null)
				{
					num = -323115715;
					num2 = num;
				}
				else
				{
					num = -323115718;
					num2 = num;
				}
				goto IL_0019;
			}
			goto IL_00af;
			IL_0014:
			num = -323115716;
			goto IL_0019;
			IL_0019:
			Vector3 localScale = default(Vector3);
			while (true)
			{
				switch (num ^ -323115713)
				{
				case 12:
					break;
				case 8:
					num = -323115726;
					continue;
				case 10:
					if (!instantiateInWorldSpace)
					{
						localScale = transform.localScale;
						transform.parent = parent;
						transform.localPosition = position;
						transform.localRotation = rotation;
						num = -323115720;
						continue;
					}
					goto case 1;
				case 13:
					goto IL_0092;
				case 4:
					goto IL_00af;
				case 2:
					transform = (obj as Component).transform;
					num = -323115721;
					continue;
				case 0:
					return FzTZeTvXCzeLKBYohshCVldDfZt((obj as GameObject).GetComponent(typeof(T)) as T);
				case 1:
					transform.position = position;
					transform.rotation = rotation;
					transform.parent = parent;
					num = -323115717;
					continue;
				case 9:
					if (obj as Transform != null)
					{
						transform = obj as Transform;
						num = -323115726;
						continue;
					}
					goto IL_0092;
				case 11:
					goto IL_0165;
				case 3:
					return result;
				case 7:
					transform.localScale = localScale;
					num = -323115717;
					continue;
				case 5:
					if (obj as GameObject != null)
					{
						transform = (obj as GameObject).transform;
						num = -323115726;
						continue;
					}
					goto case 9;
				default:
					return FzTZeTvXCzeLKBYohshCVldDfZt((obj as Transform).GetComponent(typeof(T)) as T);
				}
				break;
				IL_0165:
				if (!(obj as GameObject != null))
				{
					if (obj as Transform != null)
					{
						num = -323115719;
						continue;
					}
					goto IL_0213;
				}
				num = -323115713;
				continue;
				IL_0092:
				int num3;
				if (!(transform != null))
				{
					num = -323115717;
					num3 = num;
				}
				else
				{
					num = -323115723;
					num3 = num;
				}
			}
			goto IL_0014;
			IL_00af:
			if (IsNullOrDestroyed(obj as T))
			{
				num = -323115724;
				goto IL_0019;
			}
			goto IL_0213;
			IL_0213:
			return FzTZeTvXCzeLKBYohshCVldDfZt(obj as T);
		}

		public static Vector3 TransformPoint(Transform from, Transform to, Vector3 point)
		{
			Vector3 vector = ((from != null) ? from.TransformPoint(point) : point);
			if (to == null)
			{
				return vector;
			}
			return to.InverseTransformPoint(vector);
		}

		public static Vector3 TransformPoint(Transform from, Transform to)
		{
			return TransformPoint(from, to, Vector3.zero);
		}

		public static Vector3 TransformDirection(Transform from, Transform to, Vector3 direction)
		{
			Vector3 vector = ((from != null) ? from.TransformDirection(direction) : direction);
			if (to == null)
			{
				return vector;
			}
			return to.InverseTransformDirection(vector);
		}

		public static Vector3 TransformDirection(Transform from, Transform to)
		{
			return TransformDirection(from, to, Vector3.zero);
		}

		public static Vector3 TransformVector(Transform from, Transform to, Vector3 vector)
		{
			Vector3 vector2 = ((from != null) ? (from.TransformPoint(vector) - from.position) : Vector3.zero);
			if (to == null)
			{
				return vector2;
			}
			return to.InverseTransformPoint(vector2 + to.position);
		}

		public static Vector3 TransformVector(Transform from, Transform to)
		{
			return TransformVector(from, to, Vector3.zero);
		}

		public static Rect TransformRect(Transform from, Transform to, Rect rect)
		{
			if (from != null)
			{
				goto IL_000c;
			}
			goto IL_00ea;
			IL_000c:
			int num = 531461959;
			goto IL_0011;
			IL_0011:
			Vector3 position3 = default(Vector3);
			Vector3 position2 = default(Vector3);
			Vector3 position = default(Vector3);
			while (true)
			{
				switch (num ^ 0x1FAD7746)
				{
				case 5:
					break;
				case 0:
					goto IL_003d;
				case 2:
					position3 = from.TransformPoint(new Vector2(rect.xMin, rect.yMax));
					position2 = from.TransformPoint(new Vector2(rect.xMax, rect.yMin));
					num = 531461958;
					continue;
				case 6:
					position = to.InverseTransformPoint(position);
					position3 = to.InverseTransformPoint(position3);
					position2 = to.InverseTransformPoint(position2);
					num = 531461957;
					continue;
				case 1:
					position = from.TransformPoint(new Vector2(rect.xMin, rect.yMin));
					num = 531461956;
					continue;
				case 4:
					goto IL_00ea;
				default:
					return new Rect(position.x, position.y, position2.x - position.x, position.y - position3.y);
				}
				break;
				IL_003d:
				int num2;
				if (!(to != null))
				{
					num = 531461957;
					num2 = num;
				}
				else
				{
					num = 531461952;
					num2 = num;
				}
			}
			goto IL_000c;
			IL_00ea:
			position = new Vector2(rect.xMin, rect.yMin);
			position3 = new Vector2(rect.xMin, rect.yMax);
			position2 = new Vector2(rect.xMax, rect.yMin);
			num = 531461958;
			goto IL_0011;
		}

		public static void DebugDrawCross(Vector3 position, float length, Color color)
		{
			Debug.DrawLine(position - Vector3.up * length * 0.5f, position + Vector3.up * length * 0.5f, color);
			Debug.DrawLine(position - Vector3.right * length * 0.5f, position + Vector3.right * length * 0.5f, color);
			Debug.DrawLine(position - Vector3.forward * length * 0.5f, position + Vector3.forward * length * 0.5f, color);
		}

		public static void DebugDrawCross(Vector3 position, float length, Color color, float duration)
		{
			Debug.DrawLine(position - Vector3.up * length * 0.5f, position + Vector3.up * length * 0.5f, color, duration);
			Debug.DrawLine(position - Vector3.right * length * 0.5f, position + Vector3.right * length * 0.5f, color, duration);
			Debug.DrawLine(position - Vector3.forward * length * 0.5f, position + Vector3.forward * length * 0.5f, color, duration);
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsObjectInScene<T>(T @object) where T : UnityEngine.Object
		{
			T[] array = UnityEngine.Object.FindObjectsOfType<T>();
			if (array == null)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2 = 1987966174;
				while (true)
				{
					switch (num2 ^ 0x767DF4DF)
					{
					case 3:
						break;
					case 1:
						num2 = 1987966173;
						continue;
					case 0:
						if (array[num] == @object)
						{
							return true;
						}
						num++;
						num2 = 1987966173;
						continue;
					default:
						if (num >= array.Length)
						{
							return false;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public static string GetUnityInputAxisName(int unityJoystickIndex, int axisIndex)
		{
			return GetUnityInputAxisNameByJoystickId(unityJoystickIndex + 1, axisIndex);
		}

		public static string GetUnityInputAxisNameByJoystickId(int unityJoystickId, int axisIndex)
		{
			object[] array = new object[4];
			while (true)
			{
				int num = 2128862991;
				while (true)
				{
					switch (num ^ 0x7EE3DF0C)
					{
					case 0:
						break;
					case 3:
						array[0] = "Joy";
						array[1] = unityJoystickId;
						num = 2128862990;
						continue;
					case 2:
						array[2] = "Axis";
						array[3] = axisIndex + 1;
						num = 2128862989;
						continue;
					default:
						return string.Concat(array);
					}
					break;
				}
			}
		}

		public static string GetUnityInputButtonName(int unityJoystickIndex, int buttonIndex)
		{
			return GetUnityInputButtonNameByJoystickId(unityJoystickIndex + 1, buttonIndex);
		}

		public static string GetUnityInputButtonNameByJoystickId(int unityJoystickId, int buttonIndex)
		{
			object[] array = new object[4] { "Joy", unityJoystickId, null, null };
			while (true)
			{
				int num = 611029216;
				while (true)
				{
					switch (num ^ 0x246B90E1)
					{
					case 2:
						break;
					case 1:
						goto IL_0036;
					default:
						return string.Concat(array);
					}
					break;
					IL_0036:
					array[2] = "Button";
					array[3] = buttonIndex;
					num = 611029217;
				}
			}
		}

		public static bool IsValidUnityJoystickName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				goto IL_0008;
			}
			if (MaqootErOZjNAPDLRSSuzdcfIhA && name.Equals(wlNosTGNulGFLksDggGfIFPBlmpD, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			int num;
			if (tzYKmKZBWfZxySxJUtvNMdvtaWv && name.IndexOf("keyboard", 0, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				num = -990343929;
				goto IL_000d;
			}
			goto IL_0081;
			IL_0081:
			return true;
			IL_0008:
			num = -990343932;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -990343931)
				{
				case 3:
					break;
				case 1:
					goto IL_002a;
				case 0:
					goto IL_0038;
				default:
					return false;
				}
				break;
				IL_0038:
				if (gIEEaTeTtrHVAKRCHjLZGGAGgYbh)
				{
					return false;
				}
				goto IL_0041;
				IL_002a:
				if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform)
				{
					num = -990343931;
					continue;
				}
				goto IL_0041;
			}
			goto IL_0008;
			IL_0041:
			if (sRsEWGEfMQWKjtnFRKUnFGFLtBkg)
			{
				return false;
			}
			goto IL_0081;
		}

		public static AnimationCurve Copy(AnimationCurve orig)
		{
			if (orig == null)
			{
				return null;
			}
			Keyframe[] keys = orig.keys;
			if (keys == null)
			{
				goto IL_003e;
			}
			AnimationCurve animationCurve = new AnimationCurve(keys);
			goto IL_005e;
			IL_003e:
			animationCurve = new AnimationCurve();
			int num = 1670383939;
			goto IL_001d;
			IL_001d:
			while (true)
			{
				switch (num ^ 0x63900941)
				{
				case 4:
					num = 1670383936;
					continue;
				case 1:
					break;
				case 3:
					animationCurve.preWrapMode = orig.preWrapMode;
					num = 1670383937;
					continue;
				case 2:
					goto IL_005e;
				default:
					return animationCurve;
				}
				break;
			}
			goto IL_003e;
			IL_005e:
			animationCurve.postWrapMode = orig.postWrapMode;
			num = 1670383938;
			goto IL_001d;
		}

		public static bool IsNullOrDestroyed(object @object)
		{
			if (object.ReferenceEquals(@object, null))
			{
				return true;
			}
			if (@object is UnityEngine.Object)
			{
				return @object as UnityEngine.Object == null;
			}
			return false;
		}

		public static bool IsNullOrDestroyed<T>(T @object) where T : class
		{
			if (object.ReferenceEquals(@object, null))
			{
				return true;
			}
			if (@object is UnityEngine.Object)
			{
				return @object as UnityEngine.Object == null;
			}
			return false;
		}

		private static T FzTZeTvXCzeLKBYohshCVldDfZt<T>(T P_0) where T : class
		{
			if (object.ReferenceEquals(P_0, null))
			{
				return null;
			}
			if (P_0 is UnityEngine.Object)
			{
				while (true)
				{
					int num = 406499894;
					while (true)
					{
						switch (num ^ 0x183AB234)
						{
						case 0:
							break;
						case 2:
							goto IL_0043;
						default:
							return null;
						}
						break;
						IL_0043:
						if (!(P_0 as UnityEngine.Object == null))
						{
							goto end_IL_0025;
						}
						num = 406499893;
					}
					continue;
					end_IL_0025:
					break;
				}
			}
			return P_0;
		}

		internal static ButtonStateFlags PgLEYpEdQnJZhnkuQzkyDbEHltm(KeyCode P_0)
		{
			ButtonStateFlags buttonStateFlags = (Input.GetKey(P_0) ? ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy : ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr);
			if (Input.GetKeyDown(P_0))
			{
				buttonStateFlags |= ButtonStateFlags.avtVkgWiQfRjAMVrjPmvYWatNrY;
				goto IL_0019;
			}
			goto IL_0037;
			IL_0037:
			int num;
			if (Input.GetKeyUp(P_0))
			{
				buttonStateFlags |= ButtonStateFlags.VlhlJSuMVXjhWdLiRItrzCZLEub;
				num = -1819156523;
				goto IL_001e;
			}
			goto IL_004a;
			IL_001e:
			switch (num ^ -1819156524)
			{
			case 0:
				break;
			case 2:
				goto IL_0037;
			default:
				goto IL_004a;
			}
			goto IL_0019;
			IL_0019:
			num = -1819156522;
			goto IL_001e;
			IL_004a:
			return buttonStateFlags;
		}

		internal static ButtonStateFlags OMsDoddGLoMsnAOixNusrDCoKsdq(string P_0)
		{
			ButtonStateFlags buttonStateFlags = (Input.GetButton(P_0) ? ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy : ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr);
			while (true)
			{
				int num = -564098570;
				while (true)
				{
					switch (num ^ -564098571)
					{
					case 2:
						break;
					case 3:
						if (Input.GetButtonDown(P_0))
						{
							buttonStateFlags |= ButtonStateFlags.avtVkgWiQfRjAMVrjPmvYWatNrY;
							num = -564098571;
							continue;
						}
						goto case 0;
					case 0:
						if (Input.GetButtonUp(P_0))
						{
							buttonStateFlags |= ButtonStateFlags.VlhlJSuMVXjhWdLiRItrzCZLEub;
							num = -564098572;
							continue;
						}
						goto default;
					default:
						return buttonStateFlags;
					}
					break;
				}
			}
		}
	}
}
