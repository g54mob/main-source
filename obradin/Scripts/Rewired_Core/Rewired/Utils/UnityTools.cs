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

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		internal class UnityVersionClass
		{
			public enum pOyAbQrKJnQPftllxDYGOAPUHHOF
			{
				YTgToBVNxXcoaDwoDBQufCSlYO = 0,
				TfFsLkpvDhvxrDkyfUuZBDQXiKj = 1,
				rTBzurrqanuhBDdLablUSJpWRhq = 2
			}

			public readonly int major;

			public readonly int minor;

			public readonly int maintenance;

			public readonly pOyAbQrKJnQPftllxDYGOAPUHHOF type;

			public readonly int build;

			public UnityVersionClass(string versionString)
			{
				type = pOyAbQrKJnQPftllxDYGOAPUHHOF.YTgToBVNxXcoaDwoDBQufCSlYO;
				string[] array = versionString.Split('.');
				string text = array[array.Length - 1];
				if (Regex.IsMatch(text, ".*[a-zA-Z]+.*"))
				{
					if (Regex.IsMatch(text, ".*[bB]+.*", RegexOptions.IgnoreCase))
					{
						type = pOyAbQrKJnQPftllxDYGOAPUHHOF.TfFsLkpvDhvxrDkyfUuZBDQXiKj;
					}
					else if (Regex.IsMatch(text, ".*[pP]+.*", RegexOptions.IgnoreCase))
					{
						type = pOyAbQrKJnQPftllxDYGOAPUHHOF.rTBzurrqanuhBDdLablUSJpWRhq;
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
				return major + "." + minor + "." + maintenance + tLQPCoMAxRrphBINKosQsrBMTbq(type) + build;
			}

			private string tLQPCoMAxRrphBINKosQsrBMTbq(pOyAbQrKJnQPftllxDYGOAPUHHOF P_0)
			{
				switch (P_0)
				{
				default:
					while (true)
					{
						switch (-1011336179 ^ -1011336180)
						{
						case 0:
							continue;
						case 1:
							throw new NotImplementedException();
						}
						break;
					}
					goto case pOyAbQrKJnQPftllxDYGOAPUHHOF.YTgToBVNxXcoaDwoDBQufCSlYO;
				case pOyAbQrKJnQPftllxDYGOAPUHHOF.YTgToBVNxXcoaDwoDBQufCSlYO:
					return "f";
				case pOyAbQrKJnQPftllxDYGOAPUHHOF.TfFsLkpvDhvxrDkyfUuZBDQXiKj:
					return "b";
				case pOyAbQrKJnQPftllxDYGOAPUHHOF.rTBzurrqanuhBDdLablUSJpWRhq:
					return "p";
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
				goto IL_0083;
				IL_0009:
				int num = 607313387;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x2432DDEE)
					{
					case 3:
						break;
					case 5:
						goto IL_003a;
					case 6:
						return 1;
					case 1:
						return 0;
					case 4:
						return -1;
					case 2:
						return 1;
					default:
						return 1;
					}
					break;
					IL_003a:
					if (object.Equals(b, null))
					{
						num = 607313391;
						continue;
					}
					goto IL_0083;
				}
				goto IL_0009;
				IL_0083:
				if (object.Equals(a, null))
				{
					num = 607313386;
				}
				else if (!object.Equals(b, null))
				{
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
						num = 607313388;
					}
					else
					{
						if (a.minor < b.minor)
						{
							return -1;
						}
						if (a.maintenance <= b.maintenance)
						{
							if (a.maintenance < b.maintenance)
							{
								return -1;
							}
							if (KBRGUEOMFtbGRrICreKzHJyIBdJc(a.type) > KBRGUEOMFtbGRrICreKzHJyIBdJc(b.type))
							{
								return 1;
							}
							if (KBRGUEOMFtbGRrICreKzHJyIBdJc(a.type) < KBRGUEOMFtbGRrICreKzHJyIBdJc(b.type))
							{
								return -1;
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
						num = 607313390;
					}
				}
				else
				{
					num = 607313384;
				}
				goto IL_000e;
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
					return false;
				}
				int result;
				if (!int.TryParse(array[0], out result))
				{
					return false;
				}
				if (!int.TryParse(array[1], out result))
				{
					return false;
				}
				if (!Regex.IsMatch(array[2], "^[0-9]+"))
				{
					return false;
				}
				return true;
			}

			private static int KBRGUEOMFtbGRrICreKzHJyIBdJc(pOyAbQrKJnQPftllxDYGOAPUHHOF P_0)
			{
				switch (P_0)
				{
				case pOyAbQrKJnQPftllxDYGOAPUHHOF.TfFsLkpvDhvxrDkyfUuZBDQXiKj:
					return 0;
				case pOyAbQrKJnQPftllxDYGOAPUHHOF.YTgToBVNxXcoaDwoDBQufCSlYO:
					return 10;
				case pOyAbQrKJnQPftllxDYGOAPUHHOF.rTBzurrqanuhBDdLablUSJpWRhq:
					return 100;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private const UnityVersion WfhFWjwwqMSyafXJeJamzGGdLGk = UnityVersion.UNITY_5_0;

		private static UnityVersionClass fytgrcqicPYuVRynSPvNvWQqPdU;

		private static UnityVersion HhUcfAfathuZdUwExEfjNlLUbqdE = UnityVersion.Unknown;

		private static string dCeOGUzcRwLToVdfjhUVfEySoYkd;

		private static Platform mLEjzCONQxewtfMqTzjCjXcnmAN;

		private static EditorPlatform TAeiTQcgMAUjxnGidzESNBdrZfL;

		private static bool pUjXmoClaqAScEyXFQTGbMYIYhRD;

		private static bool BMqYVQTBOGkiqBwYdORkfmZYOzj;

		private static bool MdzHzTWTwuIKKMjMWYlflDgWlAN;

		private static WebplayerPlatform hfpQRTMlbWHjpKZUTBjPrNSHOMN;

		private static bool OzSzuYcbDfaEEwiiCrBdFnRMjLr;

		private static bool LimXWHcwEYhzCjjnawXqqTFlURO;

		private static bool DbYozYMNfhjihgvNvfHXjoSGDPga;

		private static bool NUqUTNPFCClnYFiEvnShrkLFsOx;

		private static bool SLODlNdbCtxSTcUIgdjDzktdwvk;

		private static bool hfwpMeuhAHjQlbHCfbEaJGafskXr;

		private static string JtLerAipovhaqKOSApGnjkThXzuM;

		private static ScriptingBackend LmvbaryBoUUZyiBfMLUzUhumCJyC;

		private static ScriptingAPILevel chsaHgOfWmfBIIUVLbuqIlhCMgZu;

		private static IExternalTools hpLdyFVMkPBycwhCIbjEeQSvAcHD;

		private static bool CEOUfcZJBUPInVYkafUQiywkcdB;

		[CustomObfuscation(rename = false)]
		internal static UnityVersionClass unityVersionObj
		{
			get
			{
				if (!initialized)
				{
					return null;
				}
				return fytgrcqicPYuVRynSPvNvWQqPdU;
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
				return HhUcfAfathuZdUwExEfjNlLUbqdE;
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
				return dCeOGUzcRwLToVdfjhUVfEySoYkd;
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
				return mLEjzCONQxewtfMqTzjCjXcnmAN;
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
				if (!pUjXmoClaqAScEyXFQTGbMYIYhRD)
				{
					return mLEjzCONQxewtfMqTzjCjXcnmAN;
				}
				EditorPlatform tAeiTQcgMAUjxnGidzESNBdrZfL = TAeiTQcgMAUjxnGidzESNBdrZfL;
				while (true)
				{
					switch (0x19DE75CD ^ 0x19DE75CF)
					{
					case 0:
						continue;
					case 2:
						switch (tAeiTQcgMAUjxnGidzESNBdrZfL)
						{
						case EditorPlatform.Windows:
							break;
						case EditorPlatform.OSX:
							return Platform.OSX;
						case EditorPlatform.Linux:
							return Platform.Linux;
						default:
							return mLEjzCONQxewtfMqTzjCjXcnmAN;
						}
						break;
					}
					break;
				}
				return Platform.Windows;
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
				return TAeiTQcgMAUjxnGidzESNBdrZfL;
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
				return pUjXmoClaqAScEyXFQTGbMYIYhRD;
			}
		}

		public static bool isPlaying
		{
			get
			{
				return BMqYVQTBOGkiqBwYdORkfmZYOzj;
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
				return MdzHzTWTwuIKKMjMWYlflDgWlAN;
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
				return hfpQRTMlbWHjpKZUTBjPrNSHOMN;
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
				if (!pUjXmoClaqAScEyXFQTGbMYIYhRD)
				{
					Platform platform = default(Platform);
					while (true)
					{
						int num = -1408349424;
						while (true)
						{
							switch (num ^ -1408349421)
							{
							case 8:
								break;
							case 5:
								return true;
							case 7:
								goto IL_0080;
							case 4:
							case 6:
								goto IL_0096;
							case 1:
								goto IL_00a7;
							case 2:
								goto end_IL_0013;
							case 3:
								goto IL_00da;
							default:
								return true;
							}
							break;
							IL_00da:
							if (!Application.isEditor)
							{
								if (!isAndroidPlatform)
								{
									platform = mLEjzCONQxewtfMqTzjCjXcnmAN;
									if (platform <= Platform.Linux)
									{
										switch (platform)
										{
										case Platform.Windows:
										case Platform.OSX:
										case Platform.Linux:
											goto IL_0080;
										case Platform.iOS:
											goto IL_0096;
										}
										num = -1408349417;
										continue;
									}
									goto IL_00a7;
								}
								num = -1408349418;
								continue;
							}
							num = -1408349423;
							continue;
							IL_00a7:
							switch (platform)
							{
							case Platform.XboxOne:
								return true;
							case Platform.Switch:
								return true;
							}
							num = -1408349419;
							continue;
							IL_0096:
							if (MdzHzTWTwuIKKMjMWYlflDgWlAN)
							{
								num = -1408349421;
								continue;
							}
							return false;
						}
						continue;
						IL_0080:
						if (!MdzHzTWTwuIKKMjMWYlflDgWlAN)
						{
							return LmvbaryBoUUZyiBfMLUzUhumCJyC == ScriptingBackend.IL2CPP;
						}
						return true;
						continue;
						end_IL_0013:
						break;
					}
				}
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
				if (!pUjXmoClaqAScEyXFQTGbMYIYhRD)
				{
					while (true)
					{
						switch (-397958405 ^ -397958406)
						{
						case 2:
							continue;
						case 1:
							return true;
						}
						break;
					}
				}
				else
				{
					switch (TAeiTQcgMAUjxnGidzESNBdrZfL)
					{
					case EditorPlatform.Windows:
						break;
					case EditorPlatform.OSX:
						return mLEjzCONQxewtfMqTzjCjXcnmAN == Platform.OSX;
					case EditorPlatform.Linux:
						return mLEjzCONQxewtfMqTzjCjXcnmAN == Platform.Linux;
					default:
						return true;
					}
				}
				return mLEjzCONQxewtfMqTzjCjXcnmAN == Platform.Windows;
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
				return OzSzuYcbDfaEEwiiCrBdFnRMjLr;
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
				return LimXWHcwEYhzCjjnawXqqTFlURO;
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
				return HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_4_3;
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
				return HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_4_3;
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
				return HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_4_6;
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
				return HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_5_0;
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
				if (mLEjzCONQxewtfMqTzjCjXcnmAN != Platform.Android && mLEjzCONQxewtfMqTzjCjXcnmAN != Platform.Ouya && mLEjzCONQxewtfMqTzjCjXcnmAN != Platform.AmazonFireTV)
				{
					return mLEjzCONQxewtfMqTzjCjXcnmAN == Platform.RazerForgeTV;
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
				if (mLEjzCONQxewtfMqTzjCjXcnmAN != Platform.iOS)
				{
					return mLEjzCONQxewtfMqTzjCjXcnmAN == Platform.tvOS;
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
				if (mLEjzCONQxewtfMqTzjCjXcnmAN != Platform.Windows && mLEjzCONQxewtfMqTzjCjXcnmAN != Platform.Linux)
				{
					return mLEjzCONQxewtfMqTzjCjXcnmAN == Platform.OSX;
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
				return DbYozYMNfhjihgvNvfHXjoSGDPga;
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
				return HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_5_2;
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
				return HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_2018_3;
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
				if (HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_5_0)
				{
					return HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_5_0_1;
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
				return HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_5_2;
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
				return HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_5_3;
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
				return HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_4_5;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static ScriptingBackend scriptingBackend
		{
			get
			{
				return LmvbaryBoUUZyiBfMLUzUhumCJyC;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static ScriptingAPILevel scriptingAPILevel
		{
			get
			{
				return chsaHgOfWmfBIIUVLbuqIlhCMgZu;
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
				return hpLdyFVMkPBycwhCIbjEeQSvAcHD;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isInitialized
		{
			get
			{
				return CEOUfcZJBUPInVYkafUQiywkcdB;
			}
		}

		private static bool initialized
		{
			get
			{
				return KrDkfUaKgwLlTBDBOttdhpqHjPa();
			}
		}

		private static bool KrDkfUaKgwLlTBDBOttdhpqHjPa()
		{
			if (CEOUfcZJBUPInVYkafUQiywkcdB)
			{
				return true;
			}
			try
			{
				dCeOGUzcRwLToVdfjhUVfEySoYkd = Application.unityVersion;
				fytgrcqicPYuVRynSPvNvWQqPdU = new UnityVersionClass(dCeOGUzcRwLToVdfjhUVfEySoYkd);
				lWdmAJAIMqiZQEGIVKRiGFuFfHLp();
				CEOUfcZJBUPInVYkafUQiywkcdB = true;
			}
			catch
			{
				Logger.LogError("Could not determine Unity version.");
			}
			return CEOUfcZJBUPInVYkafUQiywkcdB;
		}

		internal static void YJaAHaimrHWIfKrgfWxeihnqrcza(Platform P_0, EditorPlatform P_1, bool P_2, WebplayerPlatform P_3, ScriptingBackend P_4, ScriptingAPILevel P_5, IExternalTools P_6)
		{
			if (!initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (P_0 != Platform.Windows81Store)
				{
					num = 722517897;
					num2 = num;
				}
				else
				{
					num = 722517900;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x2B10BF8E)
					{
					case 6:
						num = 722517903;
						continue;
					case 7:
						mLEjzCONQxewtfMqTzjCjXcnmAN = P_0;
						TAeiTQcgMAUjxnGidzESNBdrZfL = P_1;
						pUjXmoClaqAScEyXFQTGbMYIYhRD = P_2;
						hfpQRTMlbWHjpKZUTBjPrNSHOMN = P_3;
						num = 722517899;
						continue;
					case 2:
						P_0 = Platform.WindowsUWP;
						num = 722517897;
						continue;
					case 0:
						hpLdyFVMkPBycwhCIbjEeQSvAcHD = P_6;
						MdzHzTWTwuIKKMjMWYlflDgWlAN = Debug.isDebugBuild;
						BMqYVQTBOGkiqBwYdORkfmZYOzj = true;
						num = 722517901;
						continue;
					case 4:
						hpLdyFVMkPBycwhCIbjEeQSvAcHD.Destroy();
						num = 722517902;
						continue;
					case 5:
					{
						LmvbaryBoUUZyiBfMLUzUhumCJyC = P_4;
						chsaHgOfWmfBIIUVLbuqIlhCMgZu = P_5;
						int num3;
						if (hpLdyFVMkPBycwhCIbjEeQSvAcHD == null)
						{
							num = 722517902;
							num3 = num;
						}
						else
						{
							num = 722517898;
							num3 = num;
						}
						continue;
					}
					case 1:
						break;
					default:
						cBMTcrrzWasOCZKCFzXdUGhCFCk();
						return;
					}
					break;
				}
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
				return false;
			}
			if (!string.IsNullOrEmpty(minVersionStr))
			{
				minVersionStr = Regex.Replace(minVersionStr, "[^0-9\\.a-zA-Z]", "", RegexOptions.IgnoreCase);
				goto IL_0027;
			}
			goto IL_014f;
			IL_002c:
			int num;
			int num3 = default(int);
			int num2 = default(int);
			bool flag = default(bool);
			while (true)
			{
				int num4;
				switch (num ^ -2117257160)
				{
				case 13:
					break;
				case 7:
					goto IL_0074;
				case 9:
					goto IL_0089;
				case 5:
					if (num3 > 0)
					{
						minVersionStr = num3 + ".0.0b0";
						num = -2117257153;
						continue;
					}
					goto IL_0074;
				case 10:
					goto IL_00c5;
				case 11:
					return false;
				case 6:
					num4 = (UnityVersionClass.IsValidVersionString(minVersionStr) ? 1 : 0);
					goto IL_0114;
				case 0:
					SFQgSbAOcwfGbOcXMxDlclCscMr(minVersionStr, out num3);
					num = -2117257168;
					continue;
				case 12:
					maxVersionStr = Regex.Replace(maxVersionStr, "[^0-9\\.a-zA-Z]", "", RegexOptions.IgnoreCase);
					num = -2117257160;
					continue;
				case 2:
					goto IL_014f;
				case 1:
					maxVersionStr = num2 + 1 + ".0.0b0";
					num = -2117257156;
					continue;
				case 4:
					if (num3 > 0)
					{
						num4 = 1;
						goto IL_0114;
					}
					num = -2117257154;
					continue;
				case 8:
					SFQgSbAOcwfGbOcXMxDlclCscMr(maxVersionStr, out num2);
					num = -2117257155;
					continue;
				default:
					{
						return false;
					}
					IL_0114:
					flag = (byte)num4 != 0;
					num = -2117257166;
					continue;
				}
				break;
				IL_00c5:
				bool flag2 = num2 > 0 || UnityVersionClass.IsValidVersionString(maxVersionStr);
				if (flag && fytgrcqicPYuVRynSPvNvWQqPdU < new UnityVersionClass(minVersionStr))
				{
					num = -2117257165;
					continue;
				}
				if (num2 > 0)
				{
					if (flag2)
					{
						num = -2117257167;
						continue;
					}
				}
				else if (flag2 && fytgrcqicPYuVRynSPvNvWQqPdU > new UnityVersionClass(maxVersionStr))
				{
					return false;
				}
				goto IL_01c3;
				IL_01c3:
				return true;
				IL_0074:
				int num5;
				if (num2 <= 0)
				{
					num = -2117257156;
					num5 = num;
				}
				else
				{
					num = -2117257159;
					num5 = num;
				}
				continue;
				IL_0089:
				if (fytgrcqicPYuVRynSPvNvWQqPdU >= new UnityVersionClass(maxVersionStr))
				{
					num = -2117257157;
					continue;
				}
				goto IL_01c3;
			}
			goto IL_0027;
			IL_014f:
			int num6;
			if (!string.IsNullOrEmpty(maxVersionStr))
			{
				num = -2117257164;
				num6 = num;
			}
			else
			{
				num = -2117257160;
				num6 = num;
			}
			goto IL_002c;
			IL_0027:
			num = -2117257158;
			goto IL_002c;
		}

		private static bool SFQgSbAOcwfGbOcXMxDlclCscMr(string P_0, out int P_1)
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

		private static void lWdmAJAIMqiZQEGIVKRiGFuFfHLp()
		{
			HhUcfAfathuZdUwExEfjNlLUbqdE = NjMuvNfRaYDYhNACGHKVBJKdfBaT(Application.unityVersion);
			while (true)
			{
				int num = -1635318380;
				while (true)
				{
					switch (num ^ -1635318379)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						if (HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_3_5 && HhUcfAfathuZdUwExEfjNlLUbqdE < UnityVersion.UNITY_4_0)
						{
							OzSzuYcbDfaEEwiiCrBdFnRMjLr = true;
							num = -1635318377;
							continue;
						}
						goto case 4;
					case 2:
						return;
					case 4:
						if (HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_4_0)
						{
							LimXWHcwEYhzCjjnawXqqTFlURO = true;
							num = -1635318379;
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

		private static UnityVersion NjMuvNfRaYDYhNACGHKVBJKdfBaT(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				goto IL_000b;
			}
			string[] array = P_0.Split('.');
			int num = array.Length;
			int num2;
			if (num >= 2)
			{
				num2 = 1822741764;
				goto IL_0010;
			}
			goto IL_065f;
			IL_04d4:
			int result = default(int);
			if (result > 3)
			{
				return UnityVersion.UNITY_4_6_3p1Plus;
			}
			goto IL_04dc;
			IL_065f:
			return UnityVersion.Unknown;
			IL_000b:
			num2 = 1822741798;
			goto IL_0010;
			IL_0010:
			string[] array2 = default(string[]);
			string text = default(string);
			bool flag = default(bool);
			int result4 = default(int);
			int result3 = default(int);
			int result2 = default(int);
			while (true)
			{
				switch (num2 ^ 0x6CA4D527)
				{
				case 22:
					break;
				case 20:
					int.TryParse(string.Concat(array2[0][0]), out result);
					num2 = 1822741818;
					continue;
				case 7:
					return UnityVersion.UNITY_2018_6;
				case 34:
					goto IL_00f9;
				case 24:
					goto IL_012d;
				case 28:
					return UnityVersion.UNITY_2020_6;
				case 16:
					goto IL_0194;
				case 2:
					return UnityVersion.UNITY_2021_0;
				case 32:
					return UnityVersion.UNITY_2018_8;
				case 25:
					if (text.IndexOf('p', 0) >= 1)
					{
						flag = true;
						num2 = 1822741820;
						continue;
					}
					goto case 27;
				case 13:
					return UnityVersion.UNITY_2018_5;
				case 15:
					return UnityVersion.UNITY_2019_9;
				case 1:
					return UnityVersion.Unknown;
				case 5:
					goto IL_028b;
				case 33:
					goto IL_02a4;
				case 17:
					return UnityVersion.UNITY_4_4;
				case 6:
					return UnityVersion.UNITY_2019_8;
				case 9:
					return UnityVersion.UNITY_2018_2;
				case 35:
					result = -1;
					text = string.Empty;
					int.TryParse(array[0], out result4);
					num2 = 1822741812;
					continue;
				case 37:
					return UnityVersion.UNITY_4_7;
				case 10:
					return UnityVersion.UNITY_2019_2;
				case 27:
					if (flag)
					{
						goto IL_00f9;
					}
					if (text != string.Empty)
					{
						string s = string.Concat(text[0]);
						int.TryParse(s, out result);
						num2 = 1822741766;
						continue;
					}
					goto IL_02a4;
				case 18:
					return UnityVersion.UNITY_2020_5;
				case 11:
					return UnityVersion.UNITY_5_4;
				case 4:
					return UnityVersion.UNITY_2017_2;
				case 12:
					return UnityVersion.UNITY_2_6_1;
				case 8:
					if (num >= 3)
					{
						text = array[2];
						num2 = 1822741822;
						continue;
					}
					goto IL_02a4;
				case 23:
					return UnityVersion.UNITY_4_9;
				case 0:
					goto IL_04c8;
				case 14:
					return UnityVersion.UNITY_3_1;
				case 19:
					int.TryParse(array[1], out result3);
					flag = false;
					result2 = 0;
					num2 = 1822741807;
					continue;
				case 31:
					return UnityVersion.UNITY_5_0_0p1;
				case 3:
					return UnityVersion.UNITY_2019_4;
				case 29:
					if (array2.Length > 1)
					{
						int.TryParse(string.Concat(array2[1][0]), out result2);
						num2 = 1822741766;
						continue;
					}
					goto IL_02a4;
				case 21:
					return UnityVersion.UNITY_2017_1;
				case 26:
					return UnityVersion.UNITY_5_0_1;
				case 36:
					return UnityVersion.UNITY_2018_3;
				default:
					return UnityVersion.UNITY_2021_1;
				}
				break;
				IL_02a4:
				if (result4 == 2)
				{
					if (result3 == 6)
					{
						if (result == 1)
						{
							num2 = 1822741803;
							continue;
						}
						return UnityVersion.UNITY_2_6;
					}
				}
				else
				{
					if (result4 == 3)
					{
						switch (result3)
						{
						case 1:
							num2 = 1822741801;
							break;
						case 0:
							num2 = 1822741794;
							break;
						case 2:
							return UnityVersion.UNITY_3_2;
						case 3:
							return UnityVersion.UNITY_3_3;
						case 4:
							return UnityVersion.UNITY_3_4;
						case 5:
							switch (result)
							{
							case 2:
								return UnityVersion.UNITY_3_5_2;
							case 7:
								return UnityVersion.UNITY_3_5_7;
							default:
								return UnityVersion.UNITY_3_5;
							}
						default:
							return UnityVersion.UNITY_3_5_7;
						}
						continue;
					}
					if (result4 == 4)
					{
						if (result3 != 0)
						{
							if (result3 == 1)
							{
								return UnityVersion.UNITY_4_1;
							}
							if (result3 == 2)
							{
								return UnityVersion.UNITY_4_2;
							}
							if (result3 == 3)
							{
								return UnityVersion.UNITY_4_3;
							}
							if (result3 == 4)
							{
								num2 = 1822741814;
								continue;
							}
							if (result3 == 5)
							{
								return UnityVersion.UNITY_4_5;
							}
							if (result3 == 6)
							{
								if (result == 3)
								{
									num2 = 1822741799;
									continue;
								}
								goto IL_04d4;
							}
							switch (result3)
							{
							case 8:
								return UnityVersion.UNITY_4_8;
							case 9:
								num2 = 1822741808;
								break;
							default:
								return UnityVersion.UNITY_4_0;
							case 7:
								num2 = 1822741762;
								break;
							}
							continue;
						}
						num2 = 1822741815;
						continue;
					}
					switch (result4)
					{
					case 2021:
						switch (result3)
						{
						case 0:
							num2 = 1822741797;
							break;
						case 1:
							num2 = 1822741817;
							break;
						case 2:
							return UnityVersion.UNITY_2021_2;
						case 3:
							return UnityVersion.UNITY_2021_3;
						case 4:
							return UnityVersion.UNITY_2021_4;
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
					case 2019:
						switch (result3)
						{
						case 0:
							return UnityVersion.UNITY_2019_0;
						case 1:
							return UnityVersion.UNITY_2019_1;
						case 2:
							num2 = 1822741805;
							break;
						default:
							return UnityVersion.UNITY_2019_0;
						case 9:
							num2 = 1822741800;
							break;
						case 3:
							return UnityVersion.UNITY_2019_3;
						case 4:
							num2 = 1822741796;
							break;
						case 5:
							return UnityVersion.UNITY_2019_5;
						case 6:
							return UnityVersion.UNITY_2019_6;
						case 7:
							return UnityVersion.UNITY_2019_7;
						case 8:
							num2 = 1822741793;
							break;
						}
						continue;
					case 2020:
						num2 = 1822741823;
						continue;
					case 2017:
						switch (result3)
						{
						case 0:
							return UnityVersion.UNITY_2017_0;
						case 1:
							num2 = 1822741810;
							break;
						case 3:
							return UnityVersion.UNITY_2017_3;
						case 4:
							return UnityVersion.UNITY_2017_4;
						case 5:
							return UnityVersion.UNITY_2017_5;
						case 6:
							return UnityVersion.UNITY_2017_6;
						case 7:
							return UnityVersion.UNITY_2017_7;
						case 8:
							return UnityVersion.UNITY_2017_8;
						case 9:
							return UnityVersion.UNITY_2017_9;
						default:
							return UnityVersion.UNITY_2017_0;
						case 2:
							num2 = 1822741795;
							break;
						}
						continue;
					case 2018:
						switch (result3)
						{
						case 7:
							return UnityVersion.UNITY_2018_7;
						case 8:
							num2 = 1822741767;
							break;
						case 9:
							return UnityVersion.UNITY_2018_9;
						default:
							return UnityVersion.UNITY_2018_0;
						case 6:
							num2 = 1822741792;
							break;
						case 3:
							num2 = 1822741763;
							break;
						case 0:
							return UnityVersion.UNITY_2018_0;
						case 1:
							return UnityVersion.UNITY_2018_1;
						case 2:
							num2 = 1822741806;
							break;
						case 4:
							return UnityVersion.UNITY_2018_4;
						case 5:
							num2 = 1822741802;
							break;
						}
						continue;
					case 5:
						switch (result3)
						{
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
						case 0:
							switch (result)
							{
							case 0:
								if (!flag)
								{
									break;
								}
								if (result2 == 1)
								{
									num2 = 1822741816;
									goto end_IL_04a3;
								}
								return UnityVersion.UNITY_5_0_0p1Plus;
							case 1:
								num2 = 1822741821;
								goto end_IL_04a3;
							case 2:
								return UnityVersion.UNITY_5_0_2;
							}
							return UnityVersion.UNITY_5_0;
						case 1:
							return UnityVersion.UNITY_5_1;
						case 2:
							return UnityVersion.UNITY_5_2;
						case 3:
							return UnityVersion.UNITY_5_3;
						case 4:
							{
								num2 = 1822741804;
								break;
							}
							end_IL_04a3:
							break;
						}
						continue;
					}
				}
				goto IL_065f;
				IL_00f9:
				array2 = text.Split('p');
				int num3;
				if (array2.Length > 0)
				{
					num2 = 1822741811;
					num3 = num2;
				}
				else
				{
					num2 = 1822741818;
					num3 = num2;
				}
				continue;
				IL_012d:
				switch (result3)
				{
				case 0:
					return UnityVersion.UNITY_2020_0;
				case 1:
					return UnityVersion.UNITY_2020_1;
				case 2:
					return UnityVersion.UNITY_2020_2;
				case 3:
					return UnityVersion.UNITY_2020_3;
				case 4:
					return UnityVersion.UNITY_2020_4;
				case 5:
					num2 = 1822741813;
					break;
				case 7:
					return UnityVersion.UNITY_2020_7;
				case 8:
					return UnityVersion.UNITY_2020_8;
				case 9:
					return UnityVersion.UNITY_2020_9;
				default:
					return UnityVersion.UNITY_2020_0;
				case 6:
					num2 = 1822741819;
					break;
				}
			}
			goto IL_000b;
			IL_04c8:
			if (flag && result2 == 1)
			{
				return UnityVersion.UNITY_4_6_3p1;
			}
			goto IL_04dc;
			IL_028b:
			if (result == 0)
			{
				return UnityVersion.UNITY_3_0_0;
			}
			return UnityVersion.UNITY_3_0;
			IL_04dc:
			return UnityVersion.UNITY_4_6;
			IL_0194:
			if (result == 1)
			{
				return UnityVersion.UNITY_4_0_1;
			}
			return UnityVersion.UNITY_4_0;
		}

		private static UnityVersion MlHATPwLXgDHlBHSiitosfBMhmo(int P_0)
		{
			while (true)
			{
				int num = 2038666515;
				while (true)
				{
					switch (num ^ 0x79839510)
					{
					case 0:
						break;
					case 3:
						switch (P_0)
						{
						default:
							goto IL_0058;
						case 3:
							break;
						case 4:
							return UnityVersion.UNITY_4_0;
						case 5:
							return UnityVersion.UNITY_5_0;
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
						}
						goto default;
					default:
						return UnityVersion.UNITY_3_0;
					case 2:
						return UnityVersion.Unknown;
					}
					break;
					IL_0058:
					num = 2038666514;
				}
			}
		}

		private static UnityVersion HbUxambcChbzZRiFrZcbSMlmiIu(int P_0)
		{
			switch (P_0)
			{
			default:
				while (true)
				{
					switch (0x22BF426E ^ 0x22BF426F)
					{
					case 0:
						continue;
					case 1:
						return UnityVersion.Unknown;
					}
					break;
				}
				goto case 3;
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
			}
		}

		private static void cBMTcrrzWasOCZKCFzXdUGhCFCk()
		{
			Platform platform = mLEjzCONQxewtfMqTzjCjXcnmAN;
			while (true)
			{
				int num = 168368769;
				while (true)
				{
					int num3;
					switch (num ^ 0xA091A8D)
					{
					case 13:
						break;
					default:
						return;
					case 12:
					{
						int num4;
						if (platform <= Platform.Android)
						{
							num = 168368773;
							num4 = num;
						}
						else
						{
							num = 168368778;
							num4 = num;
						}
						continue;
					}
					case 6:
					{
						int num6;
						if (HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_5_0_0p1)
						{
							num = 168368771;
							num6 = num;
						}
						else
						{
							num = 168368782;
							num6 = num;
						}
						continue;
					}
					case 7:
						switch (platform)
						{
						case Platform.AmazonFireTV:
						case Platform.RazerForgeTV:
							goto IL_013c;
						case Platform.PS4:
							goto IL_01b9;
						}
						num = 168368772;
						continue;
					case 14:
						DbYozYMNfhjihgvNvfHXjoSGDPga = true;
						NUqUTNPFCClnYFiEvnShrkLFsOx = true;
						num = 168368782;
						continue;
					case 16:
						SLODlNdbCtxSTcUIgdjDzktdwvk = true;
						num = 168368772;
						continue;
					case 1:
						goto IL_00da;
					case 5:
						DbYozYMNfhjihgvNvfHXjoSGDPga = true;
						NUqUTNPFCClnYFiEvnShrkLFsOx = true;
						num = 168368772;
						continue;
					case 4:
						hfwpMeuhAHjQlbHCfbEaJGafskXr = true;
						num = 168368772;
						continue;
					case 9:
						if (pUjXmoClaqAScEyXFQTGbMYIYhRD)
						{
							EditorPlatform tAeiTQcgMAUjxnGidzESNBdrZfL = TAeiTQcgMAUjxnGidzESNBdrZfL;
							if (tAeiTQcgMAUjxnGidzESNBdrZfL != EditorPlatform.Windows)
							{
								return;
							}
							goto case 10;
						}
						return;
					case 0:
						goto IL_013c;
					case 11:
					{
						int num5;
						if (HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_5_0_0p1)
						{
							num = 168368776;
							num5 = num;
						}
						else
						{
							num = 168368772;
							num5 = num;
						}
						continue;
					}
					case 10:
						if (HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_4_6_3p1)
						{
							int num7;
							if (HhUcfAfathuZdUwExEfjNlLUbqdE < UnityVersion.UNITY_5_0)
							{
								num = 168368771;
								num7 = num;
							}
							else
							{
								num = 168368779;
								num7 = num;
							}
							continue;
						}
						goto case 6;
					case 8:
						switch (platform)
						{
						case Platform.Linux:
							break;
						case Platform.Windows:
							goto IL_00da;
						case Platform.Android:
							goto IL_013c;
						default:
							goto IL_01af;
						}
						goto case 16;
					case 2:
						goto IL_01b9;
					case 15:
					{
						int num2;
						if (HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_5_0)
						{
							num = 168368774;
							num2 = num;
						}
						else
						{
							num = 168368776;
							num2 = num;
						}
						continue;
					}
					case 3:
						return;
						IL_00da:
						if (HhUcfAfathuZdUwExEfjNlLUbqdE < UnityVersion.UNITY_4_6_3p1)
						{
							num = 168368774;
							num3 = num;
						}
						else
						{
							num = 168368770;
							num3 = num;
						}
						continue;
						IL_01af:
						num = 168368772;
						continue;
						IL_01b9:
						NUqUTNPFCClnYFiEvnShrkLFsOx = true;
						JtLerAipovhaqKOSApGnjkThXzuM = "Empty";
						num = 168368777;
						continue;
						IL_013c:
						NUqUTNPFCClnYFiEvnShrkLFsOx = true;
						SLODlNdbCtxSTcUIgdjDzktdwvk = true;
						num = 168368772;
						continue;
					}
					break;
				}
			}
		}

		internal static Type nMyBmbJgewOMcOHvXYhEPODKPqkM(CLFnbXohLFPWmnaRcLIjRiKMfeb P_0)
		{
			if (!initialized)
			{
				return null;
			}
			if (HhUcfAfathuZdUwExEfjNlLUbqdE >= UnityVersion.UNITY_4_3)
			{
				return eOsooUolyUoZgJktnqlgCUkjkAY(P_0);
			}
			return null;
		}

		private static Type eOsooUolyUoZgJktnqlgCUkjkAY(CLFnbXohLFPWmnaRcLIjRiKMfeb P_0)
		{
			switch (P_0)
			{
			case CLFnbXohLFPWmnaRcLIjRiKMfeb.mGZodcyCorQhvpVxnjuEakftZdy:
				return typeof(RigidbodyInterpolation2D);
			case CLFnbXohLFPWmnaRcLIjRiKMfeb.UOzjZQgRPEVQHTkCpHeKFaMtelk:
				return typeof(RigidbodySleepMode2D);
			case CLFnbXohLFPWmnaRcLIjRiKMfeb.oZKYhSdBDRKnYRYDMQrIIfMnFzM:
				return typeof(CollisionDetectionMode2D);
			case CLFnbXohLFPWmnaRcLIjRiKMfeb.mNiCGnKeXZtqQmuqCWmOeLWMFvSD:
				return typeof(PhysicsMaterial2D);
			case CLFnbXohLFPWmnaRcLIjRiKMfeb.KMeHpHkunbnUIeOuMjtRJTHgIDm:
				return typeof(Collider2D);
			default:
				return null;
			}
		}

		public static List<string> GetCurrentPlatformResourecesDLLPaths()
		{
			if (!initialized)
			{
				goto IL_000a;
			}
			List<string> list = new List<string>();
			Platform platform = UnityTools.platform;
			int num;
			int num2;
			if (platform == Platform.Windows)
			{
				num = -920530947;
				num2 = num;
			}
			else
			{
				num = -920530950;
				num2 = num;
			}
			goto IL_000f;
			IL_000a:
			num = -920530946;
			goto IL_000f;
			IL_000f:
			while (true)
			{
				switch (num ^ -920530949)
				{
				case 3:
					break;
				case 0:
					num = -920530945;
					continue;
				case 1:
					switch (platform)
					{
					case Platform.OSX:
						goto IL_006c;
					case Platform.Linux:
						goto IL_0093;
					case Platform.iOS:
						goto IL_00ce;
					}
					num = -920530949;
					continue;
				case 7:
					num = -920530945;
					continue;
				case 2:
					goto IL_006c;
				case 6:
					list.Add("Libs/Rewired_Windows");
					num = -920530945;
					continue;
				case 8:
					goto IL_0093;
				case 5:
					return null;
				default:
					goto IL_00ce;
					IL_00ce:
					return list;
					IL_0093:
					list.Add("Libs/Rewired_Linux");
					num = -920530945;
					continue;
					IL_006c:
					list.Add("Libs/Rewired_OSX");
					num = -920530948;
					continue;
				}
				break;
			}
			goto IL_000a;
		}

		public static Transform FindTransformInChildren(Transform transform, string name)
		{
			if (transform == null)
			{
				return null;
			}
			int childCount = transform.childCount;
			int num2 = default(int);
			while (true)
			{
				int num = 1099407162;
				while (true)
				{
					switch (num ^ 0x41879F39)
					{
					case 0:
						break;
					case 3:
						num2 = 0;
						num = 1099407163;
						continue;
					case 1:
					{
						Transform child = transform.GetChild(num2);
						if (child.name == name)
						{
							return child;
						}
						Transform transform2 = FindTransformInChildren(child, name);
						if (transform2 != null)
						{
							return transform2;
						}
						num2++;
						num = 1099407163;
						continue;
					}
					default:
						if (num2 >= childCount)
						{
							return null;
						}
						goto case 1;
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
			while (true)
			{
				int num = 725378282;
				while (true)
				{
					switch (num ^ 0x2B3C64EB)
					{
					case 2:
						break;
					case 1:
					{
						Transform transform2 = FindTransformInChildren(transform, name);
						if (!(transform2 != null))
						{
							goto IL_0041;
						}
						return transform2.gameObject;
					}
					default:
						return null;
					}
					break;
					IL_0041:
					num = 725378283;
				}
			}
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
			return wmXslAXzQdCqhpIpRtlCsLfDCSgh(gameObject.GetComponent(typeof(T)) as T);
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
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				T val = default(T);
				int num2 = default(int);
				int count = default(int);
				T result = default(T);
				while (true)
				{
					IL_0021:
					int num = 1154375237;
					while (true)
					{
						switch (num ^ 0x44CE5E47)
						{
						case 3:
							break;
						case 8:
							val = list[num2] as T;
							if (!IsNullOrDestroyed(val))
							{
								if (!includeInactive)
								{
									int num3;
									if (!IsEnabled(list[num2]))
									{
										num = 1154375232;
										num3 = num;
									}
									else
									{
										num = 1154375239;
										num3 = num;
									}
									continue;
								}
								goto case 0;
							}
							goto case 7;
						case 4:
							count = list.Count;
							num = 1154375234;
							continue;
						case 0:
							result = val;
							num = 1154375238;
							continue;
						case 5:
							num2 = 0;
							num = 1154375233;
							continue;
						case 7:
							num2++;
							num = 1154375233;
							continue;
						case 2:
							GetComponents(gameObject, list, false);
							num = 1154375235;
							continue;
						default:
							if (num2 >= count)
							{
								goto end_IL_0026;
							}
							goto case 8;
						case 1:
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
				GetComponents(gameObject, list, false);
				int count = list.Count;
				int num = 0;
				Component result = default(Component);
				while (num < count)
				{
					while (true)
					{
						if (!ReflectionTools.DoesTypeImplement(list[num].GetType(), type))
						{
							goto IL_0098;
						}
						int num2;
						if (!includeInactive)
						{
							int num3;
							if (!IsEnabled(list[num]))
							{
								num2 = 1122337999;
								num3 = num2;
							}
							else
							{
								num2 = 1122337998;
								num3 = num2;
							}
							goto IL_0034;
						}
						goto IL_00a3;
						IL_00a3:
						result = list[num];
						num2 = 1122337997;
						goto IL_0034;
						IL_0098:
						num++;
						num2 = 1122337995;
						goto IL_0034;
						IL_0034:
						while (true)
						{
							switch (num2 ^ 0x42E584CF)
							{
							case 5:
								num2 = 1122337996;
								continue;
							case 3:
								break;
							case 0:
								goto IL_0098;
							case 1:
								goto IL_00a3;
							default:
								goto end_IL_0059;
							case 2:
								return result;
							}
							break;
						}
						continue;
						end_IL_0059:
						break;
					}
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
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				int num2 = default(int);
				Component result = default(Component);
				int count = default(int);
				while (true)
				{
					IL_0018:
					int num = -1489536727;
					while (true)
					{
						switch (num ^ -1489536726)
						{
						case 4:
							break;
						case 5:
							num2++;
							num = -1489536726;
							continue;
						case 6:
							num2 = 0;
							num = -1489536726;
							continue;
						case 7:
							if (ReflectionTools.DoesTypeImplement(list[num2].GetType(), type))
							{
								result = list[num2];
								num = -1489536725;
								continue;
							}
							goto case 5;
						case 2:
							count = list.Count;
							num = -1489536724;
							continue;
						case 3:
							GetComponents(gameObject, list, false);
							num = -1489536728;
							continue;
						default:
							if (num2 >= count)
							{
								goto end_IL_001d;
							}
							goto case 7;
						case 1:
							return result;
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
			T result = default(T);
			T componentInChildren;
			while (true)
			{
				IL_0079:
				int num2;
				if (num >= childCount)
				{
					result = null;
					num2 = 1888588113;
					goto IL_0024;
				}
				goto IL_0041;
				IL_0024:
				while (true)
				{
					switch (num2 ^ 0x70919153)
					{
					case 0:
						num2 = 1888588112;
						continue;
					case 3:
						break;
					case 1:
						goto IL_0079;
					default:
						return result;
					}
					break;
				}
				goto IL_0041;
				IL_0041:
				Transform child = transform.GetChild(num);
				T component = GetComponent<T>(child);
				if (!IsNullOrDestroyed(component))
				{
					return component;
				}
				componentInChildren = GetComponentInChildren<T>(child);
				if (!IsNullOrDestroyed(componentInChildren))
				{
					break;
				}
				num++;
				num2 = 1888588114;
				goto IL_0024;
			}
			return componentInChildren;
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
				goto IL_0009;
			}
			int childCount = transform.childCount;
			int num = 194167674;
			goto IL_000e;
			IL_000e:
			T component = default(T);
			T componentInChildren = default(T);
			int num2 = default(int);
			Transform child = default(Transform);
			while (true)
			{
				switch (num ^ 0xB92C37B)
				{
				case 5:
					break;
				case 2:
					return null;
				case 6:
					return component;
				case 0:
					return componentInChildren;
				case 1:
					num2 = 0;
					num = 194167676;
					continue;
				case 3:
					if (IsNullOrDestroyed(component))
					{
						componentInChildren = GetComponentInChildren<T>(child, includeInactive);
						if (!IsNullOrDestroyed(componentInChildren))
						{
							num = 194167675;
							continue;
						}
						num2++;
						num = 194167676;
					}
					else
					{
						num = 194167677;
					}
					continue;
				case 4:
					child = transform.GetChild(num2);
					component = GetComponent<T>(child, includeInactive);
					num = 194167672;
					continue;
				default:
					if (num2 >= childCount)
					{
						return null;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0009;
			IL_0009:
			num = 194167673;
			goto IL_000e;
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
				int num2;
				int num3;
				if (num < childCount)
				{
					num2 = -690626965;
					num3 = num2;
				}
				else
				{
					num2 = -690626968;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -690626966)
					{
					case 3:
						num2 = -690626965;
						continue;
					case 1:
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
						num2 = -690626966;
						continue;
					}
					case 0:
						break;
					default:
						return null;
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
			int num = 0;
			Component component = default(Component);
			Transform child = default(Transform);
			while (true)
			{
				int num2 = -452736828;
				while (true)
				{
					switch (num2 ^ -452736825)
					{
					case 4:
						break;
					case 2:
					{
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
						num2 = -452736825;
						continue;
					}
					case 1:
						child = transform.GetChild(num);
						component = GetComponent(child, type, includeInactive);
						num2 = -452736827;
						continue;
					case 3:
						num2 = -452736825;
						continue;
					default:
						if (num >= childCount)
						{
							return null;
						}
						goto case 1;
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
			if (gameObject == null)
			{
				return null;
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
			if (component == null)
			{
				return null;
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
			T result2 = null;
			int num = 124238109;
			goto IL_0016;
			IL_0011:
			num = 124238110;
			goto IL_0016;
			IL_0016:
			switch (num ^ 0x767B91C)
			{
			case 0:
				break;
			case 2:
				return result;
			default:
				return result2;
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
				result = null;
				goto IL_0011;
			}
			T val = transform.GetComponent(typeof(T)) as T;
			int num = 2128977708;
			goto IL_0016;
			IL_0016:
			switch (num ^ 0x7EE59F2E)
			{
			case 0:
				break;
			case 1:
				return result;
			default:
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
			goto IL_0011;
			IL_0011:
			num = 2128977711;
			goto IL_0016;
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
				return list;
			}
			Component[] components = gameObject.GetComponents(typeof(Component));
			if (components == null)
			{
				return list;
			}
			int num = 0;
			while (num < components.Length)
			{
				while (true)
				{
					int num2;
					if (!IsNullOrDestroyed(components[num] as T))
					{
						list.Add(components[num] as T);
						num2 = -335407647;
						goto IL_0030;
					}
					goto IL_007b;
					IL_0030:
					while (true)
					{
						switch (num2 ^ -335407647)
						{
						case 2:
							num2 = -335407646;
							continue;
						case 3:
							break;
						case 0:
							goto IL_007b;
						default:
							goto end_IL_004d;
						}
						break;
					}
					continue;
					IL_007b:
					num++;
					num2 = -335407648;
					goto IL_0030;
					continue;
					end_IL_004d:
					break;
				}
			}
			return list;
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
			if (gameObject == null)
			{
				return list;
			}
			Component[] components = gameObject.GetComponents(typeof(Component));
			if (components == null)
			{
				return list;
			}
			int num = 0;
			while (num < components.Length)
			{
				while (true)
				{
					int num2;
					if (!IsNullOrDestroyed(components[num] as T))
					{
						if (!includeInactive)
						{
							int num3;
							if (!IsEnabled(components[num]))
							{
								num2 = 1997369236;
								num3 = num2;
							}
							else
							{
								num2 = 1997369239;
								num3 = num2;
							}
							goto IL_0030;
						}
						goto IL_0083;
					}
					goto IL_009d;
					IL_0083:
					list.Add(components[num] as T);
					num2 = 1997369236;
					goto IL_0030;
					IL_009d:
					num++;
					num2 = 1997369235;
					goto IL_0030;
					IL_0030:
					while (true)
					{
						switch (num2 ^ 0x770D6F97)
						{
						case 2:
							num2 = 1997369238;
							continue;
						case 1:
							break;
						case 0:
							goto IL_0083;
						case 3:
							goto IL_009d;
						default:
							goto end_IL_0051;
						}
						break;
					}
					continue;
					end_IL_0051:
					break;
				}
			}
			return list;
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
			if (components == null)
			{
				return list;
			}
			list.AddRange(components);
			return list;
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
			if (components == null)
			{
				return list;
			}
			int num = 0;
			while (true)
			{
				int num2 = -2119667099;
				while (true)
				{
					switch (num2 ^ -2119667104)
					{
					case 0:
						break;
					case 4:
						num++;
						num2 = -2119667103;
						continue;
					case 2:
					{
						int num4;
						if (includeInactive)
						{
							num2 = -2119667098;
							num4 = num2;
						}
						else
						{
							num2 = -2119667101;
							num4 = num2;
						}
						continue;
					}
					case 6:
						list.Add(components[num]);
						num2 = -2119667100;
						continue;
					case 5:
						num2 = -2119667103;
						continue;
					case 3:
					{
						int num3;
						if (IsEnabled(components[num]))
						{
							num2 = -2119667098;
							num3 = num2;
						}
						else
						{
							num2 = -2119667100;
							num3 = num2;
						}
						continue;
					}
					default:
						if (num >= components.Length)
						{
							return list;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public static List<T> GetComponentsInChildren<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				goto IL_0009;
			}
			goto IL_0078;
			IL_0009:
			int num = -39382964;
			goto IL_000e;
			IL_000e:
			int num2 = default(int);
			List<T> list = default(List<T>);
			int childCount = default(int);
			while (true)
			{
				switch (num ^ -39382968)
				{
				case 3:
					break;
				case 4:
					throw new ArgumentNullException("transform");
				case 6:
					goto IL_0049;
				case 2:
					GetComponentsInSelfAndChildren(transform.GetChild(num2), list, true);
					num2++;
					num = -39382962;
					continue;
				case 1:
					goto IL_0078;
				case 0:
					childCount = transform.childCount;
					num2 = 0;
					num = -39382962;
					continue;
				default:
					return list;
				}
				break;
				IL_0049:
				int num3;
				if (num2 < childCount)
				{
					num = -39382966;
					num3 = num;
				}
				else
				{
					num = -39382963;
					num3 = num;
				}
			}
			goto IL_0009;
			IL_0078:
			list = new List<T>();
			num = -39382968;
			goto IL_000e;
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
			while (true)
			{
				List<T> list = new List<T>();
				int childCount = transform.childCount;
				int num = 0;
				int num2 = 776445962;
				while (true)
				{
					switch (num2 ^ 0x2E47A00A)
					{
					case 4:
						num2 = 776445963;
						continue;
					case 0:
					{
						int num3;
						if (num >= childCount)
						{
							num2 = 776445960;
							num3 = num2;
						}
						else
						{
							num2 = 776445961;
							num3 = num2;
						}
						continue;
					}
					case 3:
						GetComponentsInSelfAndChildren(transform.GetChild(num), includeInactive, list, true);
						num++;
						num2 = 776445962;
						continue;
					case 1:
						break;
					default:
						return list;
					}
					break;
				}
			}
		}

		public static List<T> GetComponentsInChildren<T>(Component component, bool includeInactive) where T : class
		{
			if (component == null)
			{
				while (true)
				{
					switch (0x51FCBDED ^ 0x51FCBDEF)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentNullException("component");
					}
					break;
				}
			}
			return GetComponentsInChildren<T>(component.transform, includeInactive);
		}

		public static List<T> GetComponentsInChildren<T>(GameObject gameObject, bool includeInactive) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInChildren<T>(gameObject.transform, includeInactive);
		}

		public static List<Component> GetComponentsInChildren(Transform transform)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			int num2 = default(int);
			while (true)
			{
				List<Component> list = new List<Component>();
				int childCount = transform.childCount;
				int num = -283273513;
				while (true)
				{
					switch (num ^ -283273514)
					{
					case 5:
						num = -283273516;
						continue;
					case 2:
						break;
					case 4:
						num2++;
						num = -283273514;
						continue;
					case 1:
						num2 = 0;
						num = -283273514;
						continue;
					case 3:
						GetComponentsInSelfAndChildren(transform.GetChild(num2), list, true);
						num = -283273518;
						continue;
					default:
						if (num2 >= childCount)
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
				while (true)
				{
					switch (-1199078532 ^ -1199078531)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("component");
					}
					break;
				}
			}
			return GetComponentsInChildren(component.transform);
		}

		public static List<Component> GetComponentsInChildren(GameObject gameObject)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
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
			int num2 = default(int);
			Component[] componentsInChildren = default(Component[]);
			while (true)
			{
				int num = -1282924816;
				while (true)
				{
					switch (num ^ -1282924812)
					{
					case 5:
						break;
					case 3:
						num2++;
						num = -1282924810;
						continue;
					case 1:
						return list;
					case 4:
						if (!(gameObject == null))
						{
							componentsInChildren = gameObject.GetComponentsInChildren(typeof(Component), true);
							if (componentsInChildren == null)
							{
								return list;
							}
							num2 = 0;
							num = -1282924810;
						}
						else
						{
							num = -1282924811;
						}
						continue;
					case 0:
					{
						int num3;
						if (IsNullOrDestroyed(componentsInChildren[num2] as T))
						{
							num = -1282924809;
							num3 = num;
						}
						else
						{
							num = -1282924814;
							num3 = num;
						}
						continue;
					}
					case 6:
						list.Add(componentsInChildren[num2] as T);
						num = -1282924809;
						continue;
					default:
						if (num2 >= componentsInChildren.Length)
						{
							return list;
						}
						goto case 0;
					}
					break;
				}
			}
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
				int num = 1141791358;
				while (true)
				{
					switch (num ^ 0x440E5A7F)
					{
					case 3:
						num = 1141791354;
						continue;
					case 5:
						break;
					case 1:
						transform2 = transform;
						num = 1141791359;
						continue;
					case 4:
					{
						int num2;
						if (!((transform2 = transform2.parent) != null))
						{
							num = 1141791353;
							num2 = num;
						}
						else
						{
							num = 1141791357;
							num2 = num;
						}
						continue;
					}
					case 0:
						num = 1141791355;
						continue;
					case 2:
						GetComponents(transform2, list, true);
						num = 1141791355;
						continue;
					default:
						return list;
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
				while (true)
				{
					switch (-1501569210 ^ -1501569212)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentNullException("gameObject");
					}
					break;
				}
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
				int num = 1666770336;
				while (true)
				{
					switch (num ^ 0x6358E5A0)
					{
					case 2:
						num = 1666770337;
						continue;
					case 1:
						break;
					case 3:
						GetComponents(transform2, list, true);
						num = 1666770336;
						continue;
					default:
						if (!((transform2 = transform2.parent) != null))
						{
							return list;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public static List<Component> GetComponentsInParents(Component component)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInParents(component.transform);
		}

		public static List<Component> GetComponentsInParents(GameObject gameObject)
		{
			if (gameObject == null)
			{
				while (true)
				{
					switch (0x6A39580B ^ 0x6A39580A)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("gameObject");
					}
					break;
				}
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
				throw new ArgumentNullException("component");
			}
			return GetComponents(component.gameObject, results, append);
		}

		public static int GetComponents<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			int num4 = default(int);
			int count = default(int);
			while (results != null)
			{
				while (true)
				{
					IL_005c:
					int num;
					int num2;
					if (append)
					{
						num = -2079802209;
						num2 = num;
					}
					else
					{
						num = -2079802214;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -2079802210)
						{
						case 0:
							num = -2079802212;
							continue;
						case 2:
							break;
						case 4:
							results.Clear();
							num = -2079802209;
							continue;
						case 3:
							goto IL_005c;
						default:
						{
							using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
							{
								List<Component> list = tList.list;
								while (true)
								{
									IL_007d:
									int num3 = -2079802214;
									while (true)
									{
										switch (num3 ^ -2079802210)
										{
										case 6:
											break;
										case 4:
											gameObject.GetComponents(list);
											num3 = -2079802215;
											continue;
										case 2:
										{
											T val = list[num4] as T;
											if (!IsNullOrDestroyed(val))
											{
												results.Add(val);
												num3 = -2079802211;
												continue;
											}
											goto case 3;
										}
										case 3:
											num4++;
											num3 = -2079802209;
											continue;
										case 0:
											num4 = 0;
											num3 = -2079802213;
											continue;
										case 5:
											num3 = -2079802209;
											continue;
										case 7:
											count = list.Count;
											num3 = -2079802210;
											continue;
										default:
											if (num4 >= count)
											{
												goto end_IL_0082;
											}
											goto case 2;
										}
										goto IL_007d;
										continue;
										end_IL_0082:
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
					break;
				}
			}
			throw new ArgumentNullException("results");
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
				throw new ArgumentNullException("gameObject");
			}
			int num3 = default(int);
			T val = default(T);
			int count = default(int);
			while (results != null)
			{
				while (true)
				{
					IL_004b:
					if (!append)
					{
						results.Clear();
						int num = -29421575;
						while (true)
						{
							switch (num ^ -29421576)
							{
							case 0:
								num = -29421574;
								continue;
							case 2:
								break;
							case 3:
								goto IL_004b;
							default:
								goto IL_005b;
							}
							break;
						}
						break;
					}
					goto IL_005b;
					IL_005b:
					using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
					{
						List<Component> list = tList.list;
						gameObject.GetComponents(list);
						while (true)
						{
							IL_006f:
							int num2 = -29421570;
							while (true)
							{
								switch (num2 ^ -29421576)
								{
								case 3:
									break;
								case 5:
									num3++;
									num2 = -29421574;
									continue;
								case 4:
									val = list[num3] as T;
									if (!IsNullOrDestroyed(val))
									{
										int num5;
										if (includeInactive)
										{
											num2 = -29421575;
											num5 = num2;
										}
										else
										{
											num2 = -29421576;
											num5 = num2;
										}
										continue;
									}
									goto case 5;
								case 6:
									count = list.Count;
									num3 = 0;
									num2 = -29421574;
									continue;
								case 1:
									results.Add(val);
									num2 = -29421571;
									continue;
								case 0:
								{
									int num4;
									if (IsEnabled(list[num3]))
									{
										num2 = -29421575;
										num4 = num2;
									}
									else
									{
										num2 = -29421571;
										num4 = num2;
									}
									continue;
								}
								default:
									if (num3 >= count)
									{
										goto end_IL_0074;
									}
									goto case 4;
								}
								goto IL_006f;
								continue;
								end_IL_0074:
								break;
							}
							break;
						}
					}
					return results.Count;
				}
			}
			throw new ArgumentNullException("results");
		}

		public static int GetComponents(Transform transform, List<Component> results, bool append)
		{
			if (transform == null)
			{
				while (true)
				{
					switch (0x3AD7DE31 ^ 0x3AD7DE33)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentNullException("transform");
					}
					break;
				}
			}
			return GetComponents(transform.gameObject, results, append);
		}

		public static int GetComponents(Component component, List<Component> results, bool append)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponents(component.gameObject, results, append);
		}

		public static int GetComponents(GameObject gameObject, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			while (true)
			{
				int num;
				int num2;
				if (results == null)
				{
					num = 2038473620;
					num2 = num;
				}
				else
				{
					num = 2038473618;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x7980A390)
					{
					case 0:
						num = 2038473617;
						continue;
					case 2:
						if (!append)
						{
							results.Clear();
							num = 2038473619;
							continue;
						}
						goto default;
					case 4:
						throw new ArgumentNullException("results");
					case 1:
						break;
					default:
					{
						using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
						{
							List<Component> list = tList.list;
							gameObject.GetComponents(list);
							int count = list.Count;
							int num3 = 0;
							while (true)
							{
								IL_00e2:
								int num4;
								int num5;
								if (num3 >= count)
								{
									num4 = 2038473619;
									num5 = num4;
								}
								else
								{
									num4 = 2038473620;
									num5 = num4;
								}
								while (true)
								{
									switch (num4 ^ 0x7980A390)
									{
									case 2:
										num4 = 2038473620;
										continue;
									default:
										goto end_IL_0094;
									case 4:
									{
										Component component = list[num3];
										if (!(component == null))
										{
											results.Add(component);
											num4 = 2038473616;
											continue;
										}
										goto case 0;
									}
									case 0:
										num3++;
										num4 = 2038473617;
										continue;
									case 1:
										break;
									case 3:
										goto end_IL_0094;
									}
									goto IL_00e2;
									continue;
									end_IL_0094:
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
			}
		}

		public static int GetComponents(Transform transform, Type type, List<Component> results, bool append)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
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
			int num = -429771809;
			goto IL_000e;
			IL_000e:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -429771813)
				{
				case 5:
					break;
				case 1:
					goto IL_0033;
				case 2:
					results.Clear();
					num = -429771813;
					continue;
				case 4:
					throw new ArgumentNullException("gameObject");
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
							int num2 = -429771816;
							while (true)
							{
								switch (num2 ^ -429771813)
								{
								case 0:
									break;
								case 3:
									num3 = 0;
									num2 = -429771814;
									continue;
								case 2:
								{
									Component component = list[num3];
									if (!(component == null))
									{
										results.Add(component);
										num2 = -429771809;
										continue;
									}
									goto case 4;
								}
								case 4:
									num3++;
									num2 = -429771814;
									continue;
								default:
									if (num3 >= count)
									{
										goto end_IL_009c;
									}
									goto case 2;
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
			IL_0033:
			int num4;
			if (!append)
			{
				num = -429771815;
				num4 = num;
			}
			else
			{
				num = -429771813;
				num4 = num;
			}
			goto IL_000e;
			IL_0066:
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			goto IL_0033;
		}

		public static int GetComponentsInSelfAndChildren(Transform transform, List<Component> results, bool append)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			while (!(transform == null))
			{
				while (true)
				{
					IL_004b:
					if (!append)
					{
						results.Clear();
						int num = 1662868339;
						while (true)
						{
							switch (num ^ 0x631D5B73)
							{
							case 3:
								num = 1662868337;
								continue;
							case 2:
								break;
							case 1:
								goto IL_004b;
							default:
								goto IL_005b;
							}
							break;
						}
						break;
					}
					goto IL_005b;
					IL_005b:
					TempListPool.TList<Component> tList = TempListPool.GetTList<Component>();
					try
					{
						List<Component> list = tList.list;
						transform.GetComponents(list);
						int count = list.Count;
						int num2 = 0;
						while (true)
						{
							IL_00a0:
							int num3;
							int num4;
							if (num2 < count)
							{
								num3 = 1662868343;
								num4 = num3;
							}
							else
							{
								num3 = 1662868338;
								num4 = num3;
							}
							while (true)
							{
								switch (num3 ^ 0x631D5B73)
								{
								case 2:
									num3 = 1662868343;
									continue;
								default:
									goto end_IL_007f;
								case 0:
									break;
								case 3:
									num2++;
									num3 = 1662868339;
									continue;
								case 4:
								{
									Component component = list[num2];
									if (!(component == null))
									{
										results.Add(component);
										num3 = 1662868336;
										continue;
									}
									goto case 3;
								}
								case 1:
									goto end_IL_007f;
								}
								goto IL_00a0;
								continue;
								end_IL_007f:
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
								IL_00e7:
								int num5 = 1662868338;
								while (true)
								{
									switch (num5 ^ 0x631D5B73)
									{
									case 0:
										break;
									default:
										goto end_IL_00ec;
									case 1:
										goto IL_0105;
									case 2:
										goto end_IL_00ec;
									}
									goto IL_00e7;
									IL_0105:
									((IDisposable)tList).Dispose();
									num5 = 1662868337;
									continue;
									end_IL_00ec:
									break;
								}
								break;
							}
						}
					}
					int childCount = transform.childCount;
					int num6 = 0;
					while (true)
					{
						int num7 = 1662868337;
						while (true)
						{
							switch (num7 ^ 0x631D5B73)
							{
							case 0:
								break;
							case 2:
								num7 = 1662868338;
								continue;
							case 3:
								GetComponentsInSelfAndChildren(transform.GetChild(num6), results, true);
								num6++;
								num7 = 1662868338;
								continue;
							default:
								if (num6 >= childCount)
								{
									return results.Count;
								}
								goto case 3;
							}
							break;
						}
					}
				}
			}
			throw new ArgumentNullException("transform");
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
				throw new ArgumentNullException("gameObject");
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
			int num3 = default(int);
			while (!(transform == null))
			{
				while (true)
				{
					IL_004b:
					if (!append)
					{
						results.Clear();
						int num = -727871246;
						while (true)
						{
							switch (num ^ -727871248)
							{
							case 0:
								num = -727871245;
								continue;
							case 3:
								break;
							case 1:
								goto IL_004b;
							default:
								goto IL_005b;
							}
							break;
						}
						break;
					}
					goto IL_005b;
					IL_005b:
					using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
					{
						List<Component> list = tList.list;
						transform.GetComponents(list);
						while (true)
						{
							IL_006f:
							int num2 = -727871245;
							while (true)
							{
								switch (num2 ^ -727871248)
								{
								case 0:
									break;
								case 3:
									count = list.Count;
									num3 = 0;
									num2 = -727871247;
									continue;
								case 2:
								{
									T val = list[num3] as T;
									if (!IsNullOrDestroyed(val))
									{
										results.Add(val);
										num2 = -727871244;
										continue;
									}
									goto case 4;
								}
								case 4:
									num3++;
									num2 = -727871247;
									continue;
								default:
									if (num3 >= count)
									{
										goto end_IL_0074;
									}
									goto case 2;
								}
								goto IL_006f;
								continue;
								end_IL_0074:
								break;
							}
							break;
						}
					}
					int childCount = transform.childCount;
					int num4 = 0;
					while (num4 < childCount)
					{
						while (true)
						{
							GetComponentsInSelfAndChildren(transform.GetChild(num4), results, true);
							int num5 = -727871246;
							while (true)
							{
								switch (num5 ^ -727871248)
								{
								case 3:
									num5 = -727871247;
									continue;
								case 1:
									break;
								case 2:
									num4++;
									num5 = -727871248;
									continue;
								default:
									goto end_IL_011a;
								}
								break;
							}
							continue;
							end_IL_011a:
							break;
						}
					}
					return results.Count;
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
			int count = default(int);
			int num4 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (transform == null)
				{
					num = -944206657;
					num2 = num;
				}
				else
				{
					num = -944206663;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -944206659)
					{
					case 3:
						num = -944206660;
						continue;
					case 4:
						if (!append)
						{
							results.Clear();
							num = -944206659;
							continue;
						}
						goto default;
					case 2:
						throw new ArgumentNullException("transform");
					case 1:
						break;
					default:
					{
						TempListPool.TList<Component> tList = TempListPool.GetTList<Component>();
						try
						{
							List<Component> list = tList.list;
							while (true)
							{
								IL_007d:
								int num3 = -944206664;
								while (true)
								{
									switch (num3 ^ -944206659)
									{
									case 2:
										break;
									case 7:
										results.Add(val);
										num3 = -944206663;
										continue;
									case 6:
										count = list.Count;
										num4 = 0;
										num3 = -944206658;
										continue;
									case 3:
										num3 = -944206660;
										continue;
									case 0:
									{
										val = list[num4] as T;
										int num6;
										if (IsNullOrDestroyed(val))
										{
											num3 = -944206663;
											num6 = num3;
										}
										else
										{
											num3 = -944206667;
											num6 = num3;
										}
										continue;
									}
									case 4:
										num4++;
										num3 = -944206660;
										continue;
									case 5:
										transform.GetComponents(list);
										num3 = -944206661;
										continue;
									case 8:
										if (!includeInactive)
										{
											int num5;
											if (!IsEnabled(list[num4]))
											{
												num3 = -944206663;
												num5 = num3;
											}
											else
											{
												num3 = -944206662;
												num5 = num3;
											}
											continue;
										}
										goto case 7;
									default:
										if (num4 >= count)
										{
											goto end_IL_0082;
										}
										goto case 0;
									}
									goto IL_007d;
									continue;
									end_IL_0082:
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
									IL_0159:
									int num7 = -944206657;
									while (true)
									{
										switch (num7 ^ -944206659)
										{
										case 0:
											break;
										default:
											goto end_IL_015e;
										case 2:
											goto IL_0177;
										case 1:
											goto end_IL_015e;
										}
										goto IL_0159;
										IL_0177:
										((IDisposable)tList).Dispose();
										num7 = -944206660;
										continue;
										end_IL_015e:
										break;
									}
									break;
								}
							}
						}
						int childCount = transform.childCount;
						int num8 = 0;
						while (true)
						{
							int num9 = -944206657;
							while (true)
							{
								switch (num9 ^ -944206659)
								{
								case 3:
									break;
								case 2:
									num9 = -944206659;
									continue;
								case 1:
									GetComponentsInSelfAndChildren(transform.GetChild(num8), includeInactive, results, true);
									num8++;
									num9 = -944206659;
									continue;
								default:
									if (num8 >= childCount)
									{
										return results.Count;
									}
									goto case 1;
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
					switch (-1084930423 ^ -1084930424)
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
				throw new ArgumentNullException("results");
			}
			int num3 = default(int);
			int childCount = default(int);
			while (!(transform == null))
			{
				while (true)
				{
					IL_00b1:
					int num;
					int num2;
					if (append)
					{
						num = 1968465341;
						num2 = num;
					}
					else
					{
						num = 1968465337;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x755465BB)
						{
						case 3:
							num = 1968465330;
							continue;
						case 9:
							break;
						case 7:
							num3 = 0;
							num = 1968465342;
							continue;
						case 4:
							GetComponentsInSelfAndChildren(transform.GetChild(num3), results, true);
							num3++;
							num = 1968465331;
							continue;
						case 5:
							num = 1968465331;
							continue;
						case 6:
							childCount = transform.childCount;
							num = 1968465340;
							continue;
						case 2:
							results.Clear();
							num = 1968465341;
							continue;
						case 0:
							goto IL_00b1;
						case 8:
							goto IL_00c8;
						default:
							return results.Count;
						}
						break;
						IL_00c8:
						int num4;
						if (num3 >= childCount)
						{
							num = 1968465338;
							num4 = num;
						}
						else
						{
							num = 1968465343;
							num4 = num;
						}
					}
					break;
				}
			}
			throw new ArgumentNullException("transform");
		}

		public static int GetComponentsInChildren<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return GetComponentsInChildren(component.transform, results, append);
		}

		public static int GetComponentsInChildren<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				while (true)
				{
					switch (0x7A8EE3F4 ^ 0x7A8EE3F6)
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
				throw new ArgumentNullException("results");
			}
			int num3 = default(int);
			int childCount = default(int);
			while (true)
			{
				int num;
				int num2;
				if (transform == null)
				{
					num = -1568392594;
					num2 = num;
				}
				else
				{
					num = -1568392599;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1568392599)
					{
					case 5:
						num = -1568392597;
						continue;
					case 2:
						break;
					case 0:
					{
						int num4;
						if (!append)
						{
							num = -1568392607;
							num4 = num;
						}
						else
						{
							num = -1568392593;
							num4 = num;
						}
						continue;
					}
					case 7:
						throw new ArgumentNullException("transform");
					case 4:
						GetComponentsInSelfAndChildren(transform.GetChild(num3), includeInactive, results, true);
						num3++;
						num = -1568392600;
						continue;
					case 8:
						results.Clear();
						num = -1568392593;
						continue;
					case 6:
						childCount = transform.childCount;
						num3 = 0;
						num = -1568392598;
						continue;
					case 3:
						num = -1568392600;
						continue;
					default:
						if (num3 >= childCount)
						{
							return results.Count;
						}
						goto case 4;
					}
					break;
				}
			}
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
			int num = 1767574197;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			int childCount = default(int);
			while (true)
			{
				switch (num ^ 0x695B0AB7)
				{
				case 3:
					break;
				case 5:
					GetComponentsInSelfAndChildren(transform.GetChild(num2), results, true);
					num2++;
					num = 1767574198;
					continue;
				case 4:
					goto IL_004b;
				case 6:
					goto IL_0066;
				case 2:
					throw new ArgumentNullException("results");
				case 0:
					goto IL_0088;
				default:
					if (num2 >= childCount)
					{
						return results.Count;
					}
					goto case 5;
				}
				break;
			}
			goto IL_0003;
			IL_0066:
			childCount = transform.childCount;
			num2 = 0;
			num = 1767574198;
			goto IL_0008;
			IL_004b:
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			goto IL_0088;
			IL_0088:
			if (!append)
			{
				results.Clear();
				num = 1767574193;
				goto IL_0008;
			}
			goto IL_0066;
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
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInChildren(gameObject.transform, results, append);
		}

		public static int GetComponentsInParents<T>(Transform transform, List<T> results, bool append) where T : class
		{
			if (transform == null)
			{
				while (true)
				{
					switch (0x4EC0BF30 ^ 0x4EC0BF32)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentNullException("transform");
					}
					break;
				}
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
			while (true)
			{
				int num;
				int num2;
				if (results != null)
				{
					num = 1634161670;
					num2 = num;
				}
				else
				{
					num = 1634161664;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x61675407)
					{
					case 4:
						num = 1634161668;
						continue;
					case 6:
						results.Clear();
						num = 1634161666;
						continue;
					case 8:
						GetComponents(parent, results, true);
						num = 1634161671;
						continue;
					case 3:
						break;
					case 1:
					{
						int num3;
						if (!append)
						{
							num = 1634161665;
							num3 = num;
						}
						else
						{
							num = 1634161666;
							num3 = num;
						}
						continue;
					}
					case 7:
						throw new ArgumentNullException("results");
					case 5:
						parent = gameObject.transform.parent;
						num = 1634161669;
						continue;
					case 2:
						num = 1634161671;
						continue;
					default:
						if (!((parent = parent.parent) != null))
						{
							return results.Count;
						}
						goto case 8;
					}
					break;
				}
			}
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
					switch (-1877770402 ^ -1877770401)
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
				throw new ArgumentNullException("gameObject");
			}
			Transform parent = default(Transform);
			while (true)
			{
				int num;
				int num2;
				if (results != null)
				{
					num = -1419975222;
					num2 = num;
				}
				else
				{
					num = -1419975223;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1419975218)
					{
					case 5:
						num = -1419975224;
						continue;
					case 8:
						parent = gameObject.transform.parent;
						num = -1419975217;
						continue;
					case 7:
						throw new ArgumentNullException("results");
					case 2:
						GetComponents(parent, results, true);
						num = -1419975217;
						continue;
					case 0:
						results.Clear();
						num = -1419975226;
						continue;
					case 1:
					{
						int num4;
						if (!((parent = parent.parent) != null))
						{
							num = -1419975219;
							num4 = num;
						}
						else
						{
							num = -1419975220;
							num4 = num;
						}
						continue;
					}
					case 6:
						break;
					case 4:
					{
						int num3;
						if (!append)
						{
							num = -1419975218;
							num3 = num;
						}
						else
						{
							num = -1419975226;
							num3 = num;
						}
						continue;
					}
					default:
						return results.Count;
					}
					break;
				}
			}
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
			TempListPool.TList<Component> tList = TempListPool.GetTList<Component>();
			try
			{
				List<Component> list = tList.list;
				transform.GetComponents(list);
				int count = list.Count;
				int num = 0;
				while (num < count)
				{
					while (true)
					{
						T val = list[num] as T;
						int num2;
						if (!IsNullOrDestroyed(val))
						{
							@delegate(val);
							num2 = -1952597624;
							goto IL_006b;
						}
						goto IL_00b3;
						IL_006b:
						while (true)
						{
							switch (num2 ^ -1952597622)
							{
							case 0:
								num2 = -1952597621;
								continue;
							case 1:
								break;
							case 2:
								goto IL_00b3;
							default:
								goto end_IL_0088;
							}
							break;
						}
						continue;
						IL_00b3:
						num++;
						num2 = -1952597623;
						goto IL_006b;
						continue;
						end_IL_0088:
						break;
					}
				}
			}
			finally
			{
				if (tList != null)
				{
					while (true)
					{
						IL_00c7:
						int num3 = -1952597621;
						while (true)
						{
							switch (num3 ^ -1952597622)
							{
							case 2:
								break;
							default:
								goto end_IL_00cc;
							case 1:
								goto IL_00e5;
							case 0:
								goto end_IL_00cc;
							}
							goto IL_00c7;
							IL_00e5:
							((IDisposable)tList).Dispose();
							num3 = -1952597622;
							continue;
							end_IL_00cc:
							break;
						}
						break;
					}
				}
			}
			if (!includeChildren)
			{
				return;
			}
			int childCount = transform.childCount;
			int num4 = 0;
			while (true)
			{
				int num5;
				int num6;
				if (num4 >= childCount)
				{
					num5 = -1952597623;
					num6 = num5;
				}
				else
				{
					num5 = -1952597621;
					num6 = num5;
				}
				while (true)
				{
					switch (num5 ^ -1952597622)
					{
					case 2:
						num5 = -1952597621;
						continue;
					default:
						return;
					case 1:
						ForEachComponent(transform.GetChild(num4), @delegate, includeChildren);
						num4++;
						num5 = -1952597622;
						continue;
					case 0:
						break;
					case 3:
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
				goto IL_0009;
			}
			goto IL_0043;
			IL_0009:
			int num = 846094546;
			goto IL_000e;
			IL_000e:
			int num2 = default(int);
			int childCount = default(int);
			while (true)
			{
				switch (num ^ 0x326E60D3)
				{
				case 2:
					break;
				case 3:
					goto IL_0033;
				case 4:
					goto IL_0043;
				case 0:
					ForEachComponent(transform.GetChild(num2), @delegate, true);
					num2++;
					num = 846094550;
					continue;
				case 1:
					throw new ArgumentNullException("transform");
				default:
					if (num2 >= childCount)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0009;
			IL_0033:
			childCount = transform.childCount;
			num2 = 0;
			num = 846094550;
			goto IL_000e;
			IL_0043:
			if (@delegate == null)
			{
				throw new ArgumentNullException("@delegate");
			}
			goto IL_0033;
		}

		public static void ForEachComponentInChildren<T>(Component component, Action<T> @delegate) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			while (true)
			{
				ForEachComponentInChildren(component.transform, @delegate);
				int num = -816511127;
				while (true)
				{
					switch (num ^ -816511128)
					{
					case 0:
						goto IL_0014;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0014:
					num = -816511126;
				}
			}
		}

		public static void ForEachComponentInChildren<T>(GameObject gameObject, Action<T> @delegate) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			ForEachComponentInChildren(gameObject.transform, @delegate);
		}

		public static bool IsEnabled(Component component)
		{
			if (component == null)
			{
				return false;
			}
			Behaviour behaviour = component as Behaviour;
			if (behaviour != null && !behaviour.enabled)
			{
				return false;
			}
			return true;
		}

		public static bool IsActiveAndEnabled(Component component)
		{
			if (component == null)
			{
				goto IL_0009;
			}
			Behaviour behaviour = component as Behaviour;
			int num = 729461191;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x2B7AB1C6)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
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
			goto IL_0009;
			IL_0009:
			num = 729461188;
			goto IL_000e;
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
			if (!(parent != null))
			{
				goto IL_00b6;
			}
			Transform transform = null;
			int num;
			if (obj as Component != null)
			{
				transform = (obj as Component).transform;
				num = -51737506;
				goto IL_0019;
			}
			goto IL_01d7;
			IL_021e:
			return wmXslAXzQdCqhpIpRtlCsLfDCSgh(obj as T);
			IL_01d7:
			int num2;
			if (obj as GameObject != null)
			{
				num = -51737512;
				num2 = num;
			}
			else
			{
				num = -51737508;
				num2 = num;
			}
			goto IL_0019;
			IL_00b6:
			if (IsNullOrDestroyed(obj as T))
			{
				num = -51737515;
				goto IL_0019;
			}
			goto IL_021e;
			IL_0019:
			Vector3 localScale = default(Vector3);
			while (true)
			{
				switch (num ^ -51737518)
				{
				case 4:
					break;
				case 12:
					goto IL_0065;
				case 14:
					if (obj as Transform != null)
					{
						transform = obj as Transform;
						num = -51737506;
						continue;
					}
					goto IL_0065;
				case 9:
					transform.parent = parent;
					transform.localPosition = position;
					num = -51737517;
					continue;
				case 3:
					goto IL_00b6;
				case 6:
					return result;
				case 2:
					transform.rotation = rotation;
					num = -51737513;
					continue;
				case 13:
					transform.position = position;
					num = -51737520;
					continue;
				case 7:
					goto IL_0132;
				case 1:
					transform.localRotation = rotation;
					transform.localScale = localScale;
					num = -51737519;
					continue;
				case 5:
					transform.parent = parent;
					num = -51737519;
					continue;
				case 10:
					transform = (obj as GameObject).transform;
					num = -51737506;
					continue;
				case 11:
					if (!instantiateInWorldSpace)
					{
						localScale = transform.localScale;
						num = -51737509;
						continue;
					}
					goto case 13;
				case 8:
					goto IL_01d7;
				default:
					return wmXslAXzQdCqhpIpRtlCsLfDCSgh((obj as Transform).GetComponent(typeof(T)) as T);
				}
				break;
				IL_0132:
				if (obj as GameObject != null)
				{
					return wmXslAXzQdCqhpIpRtlCsLfDCSgh((obj as GameObject).GetComponent(typeof(T)) as T);
				}
				if (obj as Transform != null)
				{
					num = -51737518;
					continue;
				}
				goto IL_021e;
				IL_0065:
				int num3;
				if (!(transform != null))
				{
					num = -51737519;
					num3 = num;
				}
				else
				{
					num = -51737511;
					num3 = num;
				}
			}
			goto IL_0014;
			IL_0014:
			num = -51737516;
			goto IL_0019;
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
			if (!(from != null))
			{
				goto IL_0009;
			}
			Vector3 vector = from.TransformDirection(direction);
			goto IL_0031;
			IL_0031:
			Vector3 vector2 = vector;
			int num;
			if (to == null)
			{
				num = 946386005;
				goto IL_000e;
			}
			return to.InverseTransformDirection(vector2);
			IL_0009:
			num = 946386006;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x3868B457)
			{
			case 0:
				break;
			case 1:
				goto IL_0027;
			default:
				return vector2;
			}
			goto IL_0009;
			IL_0027:
			vector = direction;
			goto IL_0031;
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
			Vector3 position;
			if (from != null)
			{
				position = from.TransformPoint(new Vector2(rect.xMin, rect.yMin));
				goto IL_0028;
			}
			goto IL_005d;
			IL_005d:
			position = new Vector2(rect.xMin, rect.yMin);
			Vector3 position2 = new Vector2(rect.xMin, rect.yMax);
			Vector3 position3 = new Vector2(rect.xMax, rect.yMin);
			int num = -884105675;
			goto IL_002d;
			IL_0028:
			num = -884105676;
			goto IL_002d;
			IL_002d:
			while (true)
			{
				switch (num ^ -884105679)
				{
				case 0:
					break;
				case 6:
					goto IL_005d;
				case 1:
					position3 = to.InverseTransformPoint(position3);
					num = -884105677;
					continue;
				case 5:
					position2 = from.TransformPoint(new Vector2(rect.xMin, rect.yMax));
					num = -884105674;
					continue;
				case 7:
					position3 = from.TransformPoint(new Vector2(rect.xMax, rect.yMin));
					num = -884105675;
					continue;
				case 4:
					goto IL_0116;
				case 3:
					position = to.InverseTransformPoint(position);
					position2 = to.InverseTransformPoint(position2);
					num = -884105680;
					continue;
				default:
					return new Rect(position.x, position.y, position3.x - position.x, position.y - position2.y);
				}
				break;
				IL_0116:
				int num2;
				if (to != null)
				{
					num = -884105678;
					num2 = num;
				}
				else
				{
					num = -884105677;
					num2 = num;
				}
			}
			goto IL_0028;
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
			int num2 = default(int);
			while (true)
			{
				int num = 2014994115;
				while (true)
				{
					switch (num ^ 0x781A5EC7)
					{
					case 0:
						break;
					case 4:
						if (array == null)
						{
							num = 2014994116;
							continue;
						}
						num2 = 0;
						num = 2014994114;
						continue;
					case 3:
						return false;
					case 5:
						num = 2014994117;
						continue;
					case 1:
						if (array[num2] == @object)
						{
							return true;
						}
						num2++;
						num = 2014994117;
						continue;
					default:
						if (num2 >= array.Length)
						{
							return false;
						}
						goto case 1;
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
				int num = -1780162240;
				while (true)
				{
					switch (num ^ -1780162239)
					{
					case 2:
						break;
					case 1:
						goto IL_0025;
					default:
						return string.Concat(array);
					}
					break;
					IL_0025:
					array[0] = "Joy";
					array[1] = unityJoystickId;
					array[2] = "Axis";
					array[3] = axisIndex + 1;
					num = -1780162239;
				}
			}
		}

		public static string GetUnityInputButtonName(int unityJoystickIndex, int buttonIndex)
		{
			return GetUnityInputButtonNameByJoystickId(unityJoystickIndex + 1, buttonIndex);
		}

		public static string GetUnityInputButtonNameByJoystickId(int unityJoystickId, int buttonIndex)
		{
			object[] array = new object[4];
			while (true)
			{
				int num = -111822977;
				while (true)
				{
					switch (num ^ -111822978)
					{
					case 0:
						break;
					case 1:
						array[0] = "Joy";
						num = -111822980;
						continue;
					case 2:
						array[1] = unityJoystickId;
						array[2] = "Button";
						num = -111822979;
						continue;
					default:
						array[3] = buttonIndex;
						return string.Concat(array);
					}
					break;
				}
			}
		}

		public static bool IsValidUnityJoystickName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && DbYozYMNfhjihgvNvfHXjoSGDPga)
				{
					return false;
				}
				if (NUqUTNPFCClnYFiEvnShrkLFsOx)
				{
					return false;
				}
			}
			else
			{
				if (hfwpMeuhAHjQlbHCfbEaJGafskXr && name.Equals(JtLerAipovhaqKOSApGnjkThXzuM, StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
				if (SLODlNdbCtxSTcUIgdjDzktdwvk && name.IndexOf("keyboard", 0, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return false;
				}
			}
			return true;
		}

		public static AnimationCurve Copy(AnimationCurve orig)
		{
			if (orig == null)
			{
				return null;
			}
			Keyframe[] keys = orig.keys;
			AnimationCurve animationCurve;
			if (keys != null)
			{
				animationCurve = new AnimationCurve(keys);
			}
			else
			{
				while (true)
				{
					animationCurve = new AnimationCurve();
					int num = -1791694963;
					while (true)
					{
						switch (num ^ -1791694963)
						{
						case 2:
							num = -1791694964;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0036;
						}
						break;
					}
					continue;
					end_IL_0036:
					break;
				}
			}
			animationCurve.postWrapMode = orig.postWrapMode;
			animationCurve.preWrapMode = orig.preWrapMode;
			return animationCurve;
		}

		public static bool IsNullOrDestroyed(object @object)
		{
			if (object.ReferenceEquals(@object, null))
			{
				goto IL_0009;
			}
			int num;
			if (@object is UnityEngine.Object)
			{
				num = 1705420553;
				goto IL_000e;
			}
			return false;
			IL_0009:
			num = 1705420552;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x65A6A709)
			{
			case 2:
				break;
			case 1:
				return true;
			default:
				return @object as UnityEngine.Object == null;
			}
			goto IL_0009;
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

		private static T wmXslAXzQdCqhpIpRtlCsLfDCSgh<T>(T P_0) where T : class
		{
			if (object.ReferenceEquals(P_0, null))
			{
				return null;
			}
			if (P_0 is UnityEngine.Object && P_0 as UnityEngine.Object == null)
			{
				return null;
			}
			return P_0;
		}

		internal static ButtonStateFlags mbVZHaXFGbZcGLxzyBgyeAMFlgn(KeyCode P_0)
		{
			ButtonStateFlags buttonStateFlags = (Input.GetKey(P_0) ? ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf : ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE);
			while (true)
			{
				int num = 2118248626;
				while (true)
				{
					switch (num ^ 0x7E41E8B3)
					{
					case 2:
						break;
					case 1:
					{
						int num2;
						if (!Input.GetKeyDown(P_0))
						{
							num = 2118248627;
							num2 = num;
						}
						else
						{
							num = 2118248624;
							num2 = num;
						}
						continue;
					}
					case 0:
						if (Input.GetKeyUp(P_0))
						{
							buttonStateFlags |= ButtonStateFlags.wqjwiZOyPZUdbNDdvBGdKmBHhRs;
							num = 2118248631;
							continue;
						}
						goto default;
					case 3:
						buttonStateFlags |= ButtonStateFlags.FRjFpveoAfCIfdseBZyzcnsVzsPH;
						num = 2118248627;
						continue;
					default:
						return buttonStateFlags;
					}
					break;
				}
			}
		}

		internal static ButtonStateFlags lvyTpewEByrJQaPpHiuasLSeNzw(string P_0)
		{
			ButtonStateFlags buttonStateFlags = (Input.GetButton(P_0) ? ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf : ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE);
			if (Input.GetButtonDown(P_0))
			{
				buttonStateFlags |= ButtonStateFlags.FRjFpveoAfCIfdseBZyzcnsVzsPH;
				goto IL_0019;
			}
			goto IL_0037;
			IL_0037:
			int num;
			if (Input.GetButtonUp(P_0))
			{
				buttonStateFlags |= ButtonStateFlags.wqjwiZOyPZUdbNDdvBGdKmBHhRs;
				num = 153334950;
				goto IL_001e;
			}
			goto IL_004a;
			IL_001e:
			switch (num ^ 0x923B4A4)
			{
			case 0:
				break;
			case 1:
				goto IL_0037;
			default:
				goto IL_004a;
			}
			goto IL_0019;
			IL_0019:
			num = 153334949;
			goto IL_001e;
			IL_004a:
			return buttonStateFlags;
		}
	}
}
