using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired.Interfaces;
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
			UNITY_2022_0 = 96,
			UNITY_2022_1 = 97,
			UNITY_2022_2 = 98,
			UNITY_2022_3 = 99,
			UNITY_2022_4 = 100,
			UNITY_2022_5 = 101,
			UNITY_2022_6 = 102,
			UNITY_2022_7 = 103,
			UNITY_2022_8 = 104,
			UNITY_2022_9 = 105,
			UNITY_2022_MAX = 106,
			UNITY_2023_0 = 107,
			UNITY_2023_1 = 108,
			UNITY_2023_2 = 109,
			UNITY_2023_3 = 110,
			UNITY_2023_4 = 111,
			UNITY_2023_5 = 112,
			UNITY_2023_6 = 113,
			UNITY_2023_7 = 114,
			UNITY_2023_8 = 115,
			UNITY_2023_9 = 116,
			UNITY_2023_MAX = 117,
			UNITY_2024_0 = 118,
			UNITY_2024_1 = 119,
			UNITY_2024_2 = 120,
			UNITY_2024_3 = 121,
			UNITY_2024_4 = 122,
			UNITY_2024_5 = 123,
			UNITY_2024_6 = 124,
			UNITY_2024_7 = 125,
			UNITY_2024_8 = 126,
			UNITY_2024_9 = 127,
			UNITY_2024_MAX = 128,
			UNITY_2025_0 = 129,
			UNITY_2025_1 = 130,
			UNITY_2025_2 = 131,
			UNITY_2025_3 = 132,
			UNITY_2025_4 = 133,
			UNITY_2025_5 = 134,
			UNITY_2025_6 = 135,
			UNITY_2025_7 = 136,
			UNITY_2025_8 = 137,
			UNITY_2025_9 = 138,
			UNITY_2025_MAX = 139,
			Unknown = 1000
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal class UnityVersionClass
		{
			public enum pQsfXEvYmzhzNadNIQnFbwvHoRy
			{
				QENeUFfZupurGKpfZNgOVPTLUnoG = 0,
				LbLbNaxycrRpDCFUSnvCczmYGEB = 1,
				rHTQDbjrLtKCnYthVOXNriZBfpM = 2
			}

			public readonly int major;

			public readonly int minor;

			public readonly int maintenance;

			public readonly pQsfXEvYmzhzNadNIQnFbwvHoRy type;

			public readonly int build;

			public UnityVersionClass(string versionString)
			{
				type = pQsfXEvYmzhzNadNIQnFbwvHoRy.QENeUFfZupurGKpfZNgOVPTLUnoG;
				string[] array = versionString.Split('.');
				string text = array[array.Length - 1];
				if (Regex.IsMatch(text, ".*[a-zA-Z]+.*"))
				{
					if (Regex.IsMatch(text, ".*[bB]+.*", RegexOptions.IgnoreCase))
					{
						type = pQsfXEvYmzhzNadNIQnFbwvHoRy.LbLbNaxycrRpDCFUSnvCczmYGEB;
					}
					else if (Regex.IsMatch(text, ".*[pP]+.*", RegexOptions.IgnoreCase))
					{
						type = pQsfXEvYmzhzNadNIQnFbwvHoRy.rHTQDbjrLtKCnYthVOXNriZBfpM;
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
				return major + "." + minor + "." + maintenance + xUAmDgWpWHZmDUtnjNyVXcdHdbC(type) + build;
			}

			private string xUAmDgWpWHZmDUtnjNyVXcdHdbC(pQsfXEvYmzhzNadNIQnFbwvHoRy P_0)
			{
				while (true)
				{
					switch (-1303326041 ^ -1303326042)
					{
					case 0:
						continue;
					case 1:
						switch (P_0)
						{
						case pQsfXEvYmzhzNadNIQnFbwvHoRy.QENeUFfZupurGKpfZNgOVPTLUnoG:
							break;
						case pQsfXEvYmzhzNadNIQnFbwvHoRy.LbLbNaxycrRpDCFUSnvCczmYGEB:
							return "b";
						case pQsfXEvYmzhzNadNIQnFbwvHoRy.rHTQDbjrLtKCnYthVOXNriZBfpM:
							return "p";
						default:
							throw new NotImplementedException();
						}
						break;
					}
					break;
				}
				return "f";
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
				if (object.Equals(a, null) && object.Equals(b, null))
				{
					return 0;
				}
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
					goto IL_0058;
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
				if (OCXiEYSAghFqdwCeOqlmuiCRWxz(a.type) > OCXiEYSAghFqdwCeOqlmuiCRWxz(b.type))
				{
					return 1;
				}
				int num;
				if (OCXiEYSAghFqdwCeOqlmuiCRWxz(a.type) < OCXiEYSAghFqdwCeOqlmuiCRWxz(b.type))
				{
					num = 1028143221;
				}
				else
				{
					if (a.build > b.build)
					{
						return 1;
					}
					if (a.build >= b.build)
					{
						return 0;
					}
					num = 1028143222;
				}
				goto IL_005d;
				IL_0058:
				num = 1028143220;
				goto IL_005d;
				IL_005d:
				switch (num ^ 0x3D483877)
				{
				case 0:
					break;
				case 3:
					return 1;
				case 2:
					return -1;
				default:
					return -1;
				}
				goto IL_0058;
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
					int num = -536098763;
					while (true)
					{
						switch (num ^ -536098762)
						{
						case 0:
							break;
						case 3:
						{
							if (array.Length < 3)
							{
								return false;
							}
							if (!Regex.IsMatch(array[0], "^[0-9]+$"))
							{
								num = -536098761;
								continue;
							}
							if (!Regex.IsMatch(array[1], "^[0-9]+$"))
							{
								return false;
							}
							if (!int.TryParse(array[0], out var result))
							{
								return false;
							}
							if (!int.TryParse(array[1], out result))
							{
								num = -536098764;
								continue;
							}
							if (!Regex.IsMatch(array[2], "^[0-9]+"))
							{
								return false;
							}
							return true;
						}
						case 1:
							return false;
						default:
							return false;
						}
						break;
					}
				}
			}

			private static int OCXiEYSAghFqdwCeOqlmuiCRWxz(pQsfXEvYmzhzNadNIQnFbwvHoRy P_0)
			{
				while (true)
				{
					switch (-618425784 ^ -618425783)
					{
					case 0:
						continue;
					case 1:
						switch (P_0)
						{
						case pQsfXEvYmzhzNadNIQnFbwvHoRy.LbLbNaxycrRpDCFUSnvCczmYGEB:
							break;
						case pQsfXEvYmzhzNadNIQnFbwvHoRy.QENeUFfZupurGKpfZNgOVPTLUnoG:
							return 10;
						case pQsfXEvYmzhzNadNIQnFbwvHoRy.rHTQDbjrLtKCnYthVOXNriZBfpM:
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

		private const UnityVersion QCbasvkuLAxOQgQfDIBhISoueYM = UnityVersion.UNITY_5_0;

		private static UnityVersionClass nmhcVogFPLyKhUTJdrAYUYmzWpu;

		private static UnityVersion RWQkJOlZOhJpPBPaQFKmaerNgiXi = UnityVersion.Unknown;

		private static string fcoeWObfiyrPQWdHOdLCxeULbQG;

		private static Platform mZENHEMjnviELksEgQWRbKEsUyld;

		private static EditorPlatform JlcjnOsxtYZFRoDQYarTuTByUtd;

		private static bool tRrUBkACJwkpIlVbmyzJntkNhHj;

		private static bool LoceqWZlvAhSCAQaKcgdKEvJDbDy;

		private static bool QepunVUpXixcoTyglhUmWEYPahn;

		private static WebplayerPlatform pbdljLEcAYJBRAXwyPMCkhsQxAz;

		private static bool UNETLAsSOrCMugfQtWWgkyxFtfVo;

		private static bool XzkqdPeSfQfNiomHVgZzTbviFEa;

		private static bool RJQXwQECCvGkZtBjSfoAElyLJZW;

		private static bool JPcznPXbrOFGwKfeYlAqSRnGYuD;

		private static bool AaUVUHxdtdAijvOeLCQUMrRsrjC;

		private static bool teqiHkgPdBwoBecyAZpnnqCaqgj;

		private static string HHNDtCkHRliSQNLazSraPtjcVlI;

		private static ScriptingBackend DybhWfopPWHpQhJLbbUejiWzHRG;

		private static ScriptingAPILevel eSyFdoECbsirwEZtmpXdCIHTDmpd;

		private static IExternalTools fZECRaPLFYIMChwnLINJpkcikrZ;

		private static bool CCEFOaNkpOagHIWjJCcPReObgNb;

		[CompilerGenerated]
		private static IAndroidFallbackPlatformHelper rQzdDAvfNdXSmFWWeFjPRQATkrW;

		[CustomObfuscation(rename = false)]
		internal static UnityVersionClass unityVersionObj
		{
			get
			{
				if (!initialized)
				{
					return null;
				}
				return nmhcVogFPLyKhUTJdrAYUYmzWpu;
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
				return RWQkJOlZOhJpPBPaQFKmaerNgiXi;
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
				return fcoeWObfiyrPQWdHOdLCxeULbQG;
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
				return mZENHEMjnviELksEgQWRbKEsUyld;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static Platform effectivePlatform
		{
			get
			{
				if (!initialized)
				{
					goto IL_0007;
				}
				if (!tRrUBkACJwkpIlVbmyzJntkNhHj)
				{
					return mZENHEMjnviELksEgQWRbKEsUyld;
				}
				switch (JlcjnOsxtYZFRoDQYarTuTByUtd)
				{
				case EditorPlatform.Windows:
					goto IL_0062;
				case EditorPlatform.OSX:
					return Platform.OSX;
				case EditorPlatform.Linux:
					return Platform.Linux;
				}
				int num = 1954995064;
				goto IL_000c;
				IL_0062:
				return Platform.Windows;
				IL_0007:
				num = 1954995067;
				goto IL_000c;
				IL_000c:
				switch (num ^ 0x7486DB78)
				{
				case 2:
					break;
				case 3:
					return Platform.Unknown;
				default:
					goto IL_0062;
				case 0:
					return mZENHEMjnviELksEgQWRbKEsUyld;
				}
				goto IL_0007;
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
				return JlcjnOsxtYZFRoDQYarTuTByUtd;
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
				return tRrUBkACJwkpIlVbmyzJntkNhHj;
			}
		}

		public static bool isPlaying => LoceqWZlvAhSCAQaKcgdKEvJDbDy;

		public static bool isDebugBuild
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return QepunVUpXixcoTyglhUmWEYPahn;
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
				return pbdljLEcAYJBRAXwyPMCkhsQxAz;
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
				Platform platform = default(Platform);
				int num;
				if (!tRrUBkACJwkpIlVbmyzJntkNhHj)
				{
					if (Application.isEditor)
					{
						goto IL_001a;
					}
					if (!isAndroidPlatform)
					{
						platform = mZENHEMjnviELksEgQWRbKEsUyld;
						int num2;
						if (platform > Platform.Linux)
						{
							num = -188647974;
							num2 = num;
						}
						else
						{
							num = -188647976;
							num2 = num;
						}
					}
					else
					{
						num = -188647973;
					}
					goto IL_001f;
				}
				goto IL_0095;
				IL_001f:
				switch (num ^ -188647976)
				{
				case 5:
					break;
				case 2:
					goto IL_0044;
				case 0:
					goto IL_0057;
				case 3:
					return true;
				case 1:
					goto IL_0095;
				default:
					goto IL_00a8;
				}
				goto IL_001a;
				IL_0057:
				switch (platform)
				{
				case Platform.Windows:
				case Platform.OSX:
				case Platform.Linux:
					break;
				default:
					goto IL_00be;
				}
				goto IL_00a8;
				IL_0095:
				return true;
				IL_00a8:
				if (!QepunVUpXixcoTyglhUmWEYPahn)
				{
					return DybhWfopPWHpQhJLbbUejiWzHRG == ScriptingBackend.IL2CPP;
				}
				return true;
				IL_00be:
				if (QepunVUpXixcoTyglhUmWEYPahn)
				{
					return true;
				}
				return false;
				IL_001a:
				num = -188647975;
				goto IL_001f;
				IL_0044:
				switch (platform)
				{
				case Platform.XboxOne:
					return true;
				case Platform.Switch:
					return true;
				}
				goto IL_00be;
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
				if (!tRrUBkACJwkpIlVbmyzJntkNhHj)
				{
					return true;
				}
				EditorPlatform jlcjnOsxtYZFRoDQYarTuTByUtd = JlcjnOsxtYZFRoDQYarTuTByUtd;
				while (true)
				{
					int num = 526492997;
					while (true)
					{
						switch (num ^ 0x1F61A546)
						{
						case 0:
							break;
						case 3:
							switch (jlcjnOsxtYZFRoDQYarTuTByUtd)
							{
							default:
								goto IL_004e;
							case EditorPlatform.Windows:
								break;
							case EditorPlatform.OSX:
								return mZENHEMjnviELksEgQWRbKEsUyld == Platform.OSX;
							case EditorPlatform.Linux:
								return mZENHEMjnviELksEgQWRbKEsUyld == Platform.Linux;
							}
							goto default;
						default:
							return mZENHEMjnviELksEgQWRbKEsUyld == Platform.Windows;
						case 2:
							return true;
						}
						break;
						IL_004e:
						num = 526492996;
					}
				}
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
				return UNETLAsSOrCMugfQtWWgkyxFtfVo;
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
				return XzkqdPeSfQfNiomHVgZzTbviFEa;
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
				return RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_4_3;
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
				return RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_4_3;
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
				return RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_4_6;
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
				return RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_5_0;
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
				if (mZENHEMjnviELksEgQWRbKEsUyld != Platform.Android && mZENHEMjnviELksEgQWRbKEsUyld != Platform.Ouya && mZENHEMjnviELksEgQWRbKEsUyld != Platform.AmazonFireTV)
				{
					return mZENHEMjnviELksEgQWRbKEsUyld == Platform.RazerForgeTV;
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
				if (mZENHEMjnviELksEgQWRbKEsUyld != Platform.iOS)
				{
					return mZENHEMjnviELksEgQWRbKEsUyld == Platform.tvOS;
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
					goto IL_0007;
				}
				int num;
				if (mZENHEMjnviELksEgQWRbKEsUyld != Platform.Windows && mZENHEMjnviELksEgQWRbKEsUyld != Platform.Linux)
				{
					num = 1932922092;
					goto IL_000c;
				}
				return true;
				IL_000c:
				switch (num ^ 0x73360CED)
				{
				case 0:
					break;
				case 2:
					return false;
				default:
					return mZENHEMjnviELksEgQWRbKEsUyld == Platform.OSX;
				}
				goto IL_0007;
				IL_0007:
				num = 1932922095;
				goto IL_000c;
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
				return RJQXwQECCvGkZtBjSfoAElyLJZW;
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
				return RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_5_2;
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
				return RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_2018_3;
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
				if (RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_5_0)
				{
					return RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_5_0_1;
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
				return RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_5_2;
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
				return RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_5_3;
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
				return RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_4_5;
			}
		}

		public static bool supportsStadia
		{
			get
			{
				if (!initialized)
				{
					return false;
				}
				return RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_2019_3;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static ScriptingBackend scriptingBackend => DybhWfopPWHpQhJLbbUejiWzHRG;

		[CustomObfuscation(rename = false)]
		internal static ScriptingAPILevel scriptingAPILevel => eSyFdoECbsirwEZtmpXdCIHTDmpd;

		public static IExternalTools externalTools
		{
			get
			{
				if (!initialized)
				{
					return null;
				}
				return fZECRaPLFYIMChwnLINJpkcikrZ;
			}
		}

		internal static IAndroidFallbackPlatformHelper androidFallbackPlatformHelper
		{
			[CompilerGenerated]
			get
			{
				return rQzdDAvfNdXSmFWWeFjPRQATkrW;
			}
			[CompilerGenerated]
			set
			{
				rQzdDAvfNdXSmFWWeFjPRQATkrW = value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isInitialized => CCEFOaNkpOagHIWjJCcPReObgNb;

		private static bool initialized => YRVAJImMLeMBlKMzpDEsYWYYBDE();

		private static bool YRVAJImMLeMBlKMzpDEsYWYYBDE()
		{
			if (CCEFOaNkpOagHIWjJCcPReObgNb)
			{
				return true;
			}
			try
			{
				fcoeWObfiyrPQWdHOdLCxeULbQG = Application.unityVersion;
				nmhcVogFPLyKhUTJdrAYUYmzWpu = new UnityVersionClass(fcoeWObfiyrPQWdHOdLCxeULbQG);
				while (true)
				{
					IL_0022:
					int num = 786591864;
					while (true)
					{
						switch (num ^ 0x2EE27079)
						{
						case 0:
							break;
						default:
							goto end_IL_0027;
						case 1:
							goto IL_0040;
						case 2:
							goto end_IL_0027;
						}
						goto IL_0022;
						IL_0040:
						bjrokDWmrslWuLkuoqEveoUyDvb();
						CCEFOaNkpOagHIWjJCcPReObgNb = true;
						num = 786591867;
						continue;
						end_IL_0027:
						break;
					}
					break;
				}
			}
			catch
			{
				Logger.LogError("Could not determine Unity version.");
			}
			return CCEFOaNkpOagHIWjJCcPReObgNb;
		}

		internal static void SdmfoteCDVoXNaSlWEvRMBbwmDy(Platform P_0, EditorPlatform P_1, bool P_2, WebplayerPlatform P_3, ScriptingBackend P_4, ScriptingAPILevel P_5, IExternalTools P_6)
		{
			if (!initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				if (P_0 == Platform.Windows81Store)
				{
					P_0 = Platform.WindowsUWP;
					num = -1520020899;
					goto IL_000d;
				}
				goto IL_0072;
				IL_000d:
				while (true)
				{
					switch (num ^ -1520020899)
					{
					case 2:
						num = -1520020904;
						continue;
					case 6:
						pbdljLEcAYJBRAXwyPMCkhsQxAz = P_3;
						DybhWfopPWHpQhJLbbUejiWzHRG = P_4;
						num = -1520020898;
						continue;
					case 4:
						if (fZECRaPLFYIMChwnLINJpkcikrZ != null)
						{
							fZECRaPLFYIMChwnLINJpkcikrZ.Destroy();
							num = -1520020900;
							continue;
						}
						goto default;
					case 5:
						break;
					case 0:
						goto IL_0072;
					case 3:
						eSyFdoECbsirwEZtmpXdCIHTDmpd = P_5;
						num = -1520020903;
						continue;
					default:
						fZECRaPLFYIMChwnLINJpkcikrZ = P_6;
						QepunVUpXixcoTyglhUmWEYPahn = Debug.isDebugBuild;
						LoceqWZlvAhSCAQaKcgdKEvJDbDy = true;
						ebQADhlBvuDyoGCwkIUsrHHLWUS();
						return;
					}
					break;
				}
				continue;
				IL_0072:
				mZENHEMjnviELksEgQWRbKEsUyld = P_0;
				JlcjnOsxtYZFRoDQYarTuTByUtd = P_1;
				tRrUBkACJwkpIlVbmyzJntkNhHj = P_2;
				num = -1520020901;
				goto IL_000d;
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
				goto IL_0011;
			}
			goto IL_005c;
			IL_010f:
			int num = default(int);
			bool flag = default(bool);
			if (num > 0)
			{
				if (flag && nmhcVogFPLyKhUTJdrAYUYmzWpu >= new UnityVersionClass(maxVersionStr))
				{
					return false;
				}
			}
			else if (flag && nmhcVogFPLyKhUTJdrAYUYmzWpu > new UnityVersionClass(maxVersionStr))
			{
				return false;
			}
			return true;
			IL_0011:
			int num2 = 869708686;
			goto IL_0016;
			IL_0016:
			while (true)
			{
				switch (num2 ^ 0x33D6B38D)
				{
				case 2:
					break;
				case 3:
					minVersionStr = Regex.Replace(minVersionStr, "[^0-9\\.a-zA-Z]", "", RegexOptions.IgnoreCase);
					num2 = 869708685;
					continue;
				case 0:
					goto IL_005c;
				case 4:
					goto IL_007e;
				case 6:
					goto IL_00a7;
				case 1:
					goto IL_00d9;
				default:
					goto IL_00fb;
				}
				break;
			}
			goto IL_0011;
			IL_005c:
			if (!string.IsNullOrEmpty(maxVersionStr))
			{
				maxVersionStr = Regex.Replace(maxVersionStr, "[^0-9\\.a-zA-Z]", "", RegexOptions.IgnoreCase);
				num2 = 869708683;
				goto IL_0016;
			}
			goto IL_00a7;
			IL_00fb:
			if (nmhcVogFPLyKhUTJdrAYUYmzWpu < new UnityVersionClass(minVersionStr))
			{
				return false;
			}
			goto IL_010f;
			IL_007e:
			int num3 = default(int);
			bool flag2 = num3 > 0 || UnityVersionClass.IsValidVersionString(minVersionStr);
			flag = num > 0 || UnityVersionClass.IsValidVersionString(maxVersionStr);
			if (flag2)
			{
				num2 = 869708680;
				goto IL_0016;
			}
			goto IL_010f;
			IL_00a7:
			AgIcJlGaJebiLXHtxyikLdelhYV(minVersionStr, out num3);
			AgIcJlGaJebiLXHtxyikLdelhYV(maxVersionStr, out num);
			if (num3 > 0)
			{
				minVersionStr = num3 + ".0.0b0";
				num2 = 869708684;
				goto IL_0016;
			}
			goto IL_00d9;
			IL_00d9:
			if (num > 0)
			{
				maxVersionStr = num + 1 + ".0.0b0";
				num2 = 869708681;
				goto IL_0016;
			}
			goto IL_007e;
		}

		private static bool AgIcJlGaJebiLXHtxyikLdelhYV(string P_0, out int P_1)
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

		private static void bjrokDWmrslWuLkuoqEveoUyDvb()
		{
			RWQkJOlZOhJpPBPaQFKmaerNgiXi = TDEBCLbJJAihDAnmrrhEmiqiCRY(Application.unityVersion);
			if (RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_3_5)
			{
				goto IL_0017;
			}
			goto IL_005b;
			IL_0017:
			int num = 85617965;
			goto IL_001c;
			IL_001c:
			while (true)
			{
				switch (num ^ 0x51A6D2C)
				{
				case 4:
					break;
				default:
					return;
				case 1:
					if (RWQkJOlZOhJpPBPaQFKmaerNgiXi < UnityVersion.UNITY_4_0)
					{
						UNETLAsSOrCMugfQtWWgkyxFtfVo = true;
						num = 85617964;
						continue;
					}
					goto IL_005b;
				case 0:
					return;
				case 3:
					goto IL_005b;
				case 2:
					return;
				}
				break;
			}
			goto IL_0017;
			IL_005b:
			if (RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_4_0)
			{
				XzkqdPeSfQfNiomHVgZzTbviFEa = true;
				num = 85617966;
				goto IL_001c;
			}
		}

		private static UnityVersion TDEBCLbJJAihDAnmrrhEmiqiCRY(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				goto IL_000b;
			}
			string[] array = P_0.Split('.');
			int num = array.Length;
			int result = default(int);
			string text = default(string);
			int result2 = default(int);
			int result3 = default(int);
			int num2;
			if (num >= 2)
			{
				result = -1;
				text = string.Empty;
				int.TryParse(array[0], out result2);
				int.TryParse(array[1], out result3);
				num2 = 1565222038;
				goto IL_0010;
			}
			goto IL_08b9;
			IL_08b9:
			return UnityVersion.Unknown;
			IL_067a:
			int result4 = default(int);
			if (result4 == 1)
			{
				return UnityVersion.UNITY_5_0_0p1;
			}
			return UnityVersion.UNITY_5_0_0p1Plus;
			IL_000b:
			num2 = 1565222057;
			goto IL_0010;
			IL_0010:
			string[] array2 = default(string[]);
			string s = default(string);
			bool flag = default(bool);
			while (true)
			{
				switch (num2 ^ 0x5D4B64A6)
				{
				case 17:
					break;
				case 0:
					return UnityVersion.UNITY_2017_5;
				case 12:
					if (array2.Length > 1)
					{
						int.TryParse(string.Concat(array2[1][0]), out result4);
						num2 = 1565222078;
						continue;
					}
					goto IL_065a;
				case 31:
					return UnityVersion.UNITY_2021_9;
				case 37:
					return UnityVersion.UNITY_2019_6;
				case 2:
					return UnityVersion.UNITY_5_1;
				case 1:
					return UnityVersion.UNITY_2022_3;
				case 47:
					return UnityVersion.UNITY_2025_1;
				case 14:
					return UnityVersion.UNITY_2024_1;
				case 11:
					return UnityVersion.UNITY_4_0_1;
				case 48:
					goto IL_029e;
				case 26:
					return UnityVersion.UNITY_2018_9;
				case 3:
					return UnityVersion.UNITY_2020_0;
				case 30:
					return UnityVersion.UNITY_2018_6;
				case 5:
					return UnityVersion.UNITY_2_6_1;
				case 44:
					goto IL_0314;
				case 16:
					return UnityVersion.UNITY_2022_5;
				case 28:
					return UnityVersion.UNITY_2018_1;
				case 51:
					return UnityVersion.UNITY_2017_4;
				case 41:
					return UnityVersion.UNITY_2021_7;
				case 49:
					return UnityVersion.UNITY_2017_2;
				case 10:
					int.TryParse(s, out result);
					num2 = 1565222078;
					continue;
				case 29:
					return UnityVersion.UNITY_3_5_2;
				case 42:
					return UnityVersion.UNITY_2017_8;
				case 25:
					return UnityVersion.UNITY_2022_7;
				case 23:
					return UnityVersion.UNITY_2024_8;
				case 34:
					return UnityVersion.UNITY_2023_6;
				case 19:
					return UnityVersion.UNITY_2020_1;
				case 7:
					return UnityVersion.UNITY_2023_7;
				case 39:
					text = array[2];
					if (text.IndexOf('p', 0) >= 1)
					{
						flag = true;
						num2 = 1565222026;
						continue;
					}
					goto IL_0314;
				case 38:
					goto IL_054d;
				case 46:
					return UnityVersion.UNITY_2025_2;
				case 35:
					return UnityVersion.UNITY_2023_5;
				case 27:
					if (text != string.Empty)
					{
						s = string.Concat(text[0]);
						num2 = 1565222060;
						continue;
					}
					goto IL_065a;
				case 18:
					return UnityVersion.UNITY_2021_3;
				case 4:
					return UnityVersion.UNITY_2021_2;
				case 32:
					return UnityVersion.UNITY_2024_6;
				case 8:
					goto IL_064a;
				case 24:
					goto IL_065a;
				case 13:
					goto IL_067a;
				case 9:
					array2 = text.Split('p');
					if (array2.Length > 0)
					{
						int.TryParse(string.Concat(array2[0][0]), out result);
						num2 = 1565222058;
						continue;
					}
					goto case 12;
				case 6:
					goto IL_06e0;
				case 15:
					return UnityVersion.Unknown;
				case 22:
					return UnityVersion.UNITY_2019_0;
				case 43:
					goto IL_077a;
				case 36:
					return UnityVersion.UNITY_2018_5;
				case 50:
					return UnityVersion.UNITY_2018_7;
				case 20:
					return UnityVersion.UNITY_2017_1;
				case 40:
					return UnityVersion.UNITY_4_4;
				case 21:
					goto IL_0833;
				case 45:
					return UnityVersion.UNITY_5_0_1;
				default:
					return UnityVersion.UNITY_2025_6;
				}
				break;
				IL_0833:
				switch (result3)
				{
				default:
					return UnityVersion.UNITY_3_5_7;
				case 0:
					if (result == 0)
					{
						return UnityVersion.UNITY_3_0_0;
					}
					return UnityVersion.UNITY_3_0;
				case 1:
					return UnityVersion.UNITY_3_1;
				case 2:
					return UnityVersion.UNITY_3_2;
				case 3:
					return UnityVersion.UNITY_3_3;
				case 4:
					return UnityVersion.UNITY_3_4;
				case 5:
					switch (result)
					{
					case 7:
						return UnityVersion.UNITY_3_5_7;
					default:
						return UnityVersion.UNITY_3_5;
					case 2:
						num2 = 1565222075;
						break;
					}
					break;
				}
				continue;
				IL_077a:
				switch (result3)
				{
				case 2:
					return UnityVersion.UNITY_2024_2;
				case 3:
					return UnityVersion.UNITY_2024_3;
				case 4:
					return UnityVersion.UNITY_2024_4;
				case 5:
					return UnityVersion.UNITY_2024_5;
				case 6:
					num2 = 1565222022;
					break;
				case 9:
					return UnityVersion.UNITY_2024_9;
				default:
					return UnityVersion.UNITY_2024_0;
				case 7:
					return UnityVersion.UNITY_2024_7;
				case 8:
					num2 = 1565222065;
					break;
				case 0:
					return UnityVersion.UNITY_2024_0;
				case 1:
					num2 = 1565222056;
					break;
				}
				continue;
				IL_06e0:
				if (flag)
				{
					num2 = 1565222059;
					continue;
				}
				goto IL_087a;
				IL_029e:
				flag = false;
				result4 = 0;
				int num3;
				if (num >= 3)
				{
					num2 = 1565222017;
					num3 = num2;
				}
				else
				{
					num2 = 1565222078;
					num3 = num2;
				}
				continue;
				IL_064a:
				switch (result3)
				{
				case 7:
					return UnityVersion.UNITY_2019_7;
				case 8:
					return UnityVersion.UNITY_2019_8;
				case 9:
					return UnityVersion.UNITY_2019_9;
				default:
					return UnityVersion.UNITY_2019_0;
				case 0:
					num2 = 1565222064;
					break;
				case 1:
					return UnityVersion.UNITY_2019_1;
				case 2:
					return UnityVersion.UNITY_2019_2;
				case 3:
					return UnityVersion.UNITY_2019_3;
				case 4:
					return UnityVersion.UNITY_2019_4;
				case 5:
					return UnityVersion.UNITY_2019_5;
				case 6:
					num2 = 1565222019;
					break;
				}
				continue;
				IL_054d:
				switch (result3)
				{
				case 7:
					num2 = 1565222049;
					break;
				case 8:
					return UnityVersion.UNITY_2023_8;
				case 9:
					return UnityVersion.UNITY_2023_9;
				default:
					return UnityVersion.UNITY_2023_0;
				case 0:
					return UnityVersion.UNITY_2023_0;
				case 1:
					return UnityVersion.UNITY_2023_1;
				case 2:
					return UnityVersion.UNITY_2023_2;
				case 3:
					return UnityVersion.UNITY_2023_3;
				case 4:
					return UnityVersion.UNITY_2023_4;
				case 5:
					num2 = 1565222021;
					break;
				case 6:
					num2 = 1565222020;
					break;
				}
				continue;
				IL_0314:
				int num4;
				if (flag)
				{
					num2 = 1565222063;
					num4 = num2;
				}
				else
				{
					num2 = 1565222077;
					num4 = num2;
				}
				continue;
				IL_065a:
				if (result2 != 2)
				{
					if (result2 == 3)
					{
						num2 = 1565222067;
						continue;
					}
					if (result2 == 4)
					{
						switch (result3)
						{
						case 1:
							return UnityVersion.UNITY_4_1;
						case 2:
							return UnityVersion.UNITY_4_2;
						case 3:
							return UnityVersion.UNITY_4_3;
						case 4:
							num2 = 1565222030;
							break;
						case 0:
							if (result != 1)
							{
								return UnityVersion.UNITY_4_0;
							}
							num2 = 1565222061;
							break;
						case 5:
							return UnityVersion.UNITY_4_5;
						case 6:
							if (result == 3)
							{
								if (flag && result4 == 1)
								{
									return UnityVersion.UNITY_4_6_3p1;
								}
							}
							else if (result > 3)
							{
								return UnityVersion.UNITY_4_6_3p1Plus;
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
					}
					if (result2 == 5)
					{
						if (result3 == 0)
						{
							switch (result)
							{
							case 1:
								num2 = 1565222027;
								continue;
							case 0:
								num2 = 1565222048;
								continue;
							case 2:
								return UnityVersion.UNITY_5_0_2;
							}
							goto IL_087a;
						}
						switch (result3)
						{
						case 2:
							return UnityVersion.UNITY_5_2;
						case 3:
							return UnityVersion.UNITY_5_3;
						case 4:
							return UnityVersion.UNITY_5_4;
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
						case 1:
							num2 = 1565222052;
							break;
						}
						continue;
					}
					switch (result2)
					{
					case 2022:
						switch (result3)
						{
						case 0:
							return UnityVersion.UNITY_2022_0;
						case 1:
							return UnityVersion.UNITY_2022_1;
						case 2:
							return UnityVersion.UNITY_2022_2;
						case 3:
							num2 = 1565222055;
							break;
						case 4:
							return UnityVersion.UNITY_2022_4;
						case 5:
							num2 = 1565222070;
							break;
						case 6:
							return UnityVersion.UNITY_2022_6;
						case 7:
							num2 = 1565222079;
							break;
						case 8:
							return UnityVersion.UNITY_2022_8;
						case 9:
							return UnityVersion.UNITY_2022_9;
						default:
							return UnityVersion.UNITY_2022_0;
						}
						continue;
					case 2020:
						switch (result3)
						{
						case 0:
							num2 = 1565222053;
							break;
						case 1:
							num2 = 1565222069;
							break;
						case 2:
							return UnityVersion.UNITY_2020_2;
						case 3:
							return UnityVersion.UNITY_2020_3;
						case 4:
							return UnityVersion.UNITY_2020_4;
						case 5:
							return UnityVersion.UNITY_2020_5;
						case 6:
							return UnityVersion.UNITY_2020_6;
						case 7:
							return UnityVersion.UNITY_2020_7;
						case 8:
							return UnityVersion.UNITY_2020_8;
						case 9:
							return UnityVersion.UNITY_2020_9;
						default:
							return UnityVersion.UNITY_2020_0;
						}
						continue;
					case 2017:
						switch (result3)
						{
						case 6:
							return UnityVersion.UNITY_2017_6;
						case 7:
							return UnityVersion.UNITY_2017_7;
						case 8:
							num2 = 1565222028;
							break;
						case 0:
							return UnityVersion.UNITY_2017_0;
						case 1:
							num2 = 1565222066;
							break;
						case 5:
							num2 = 1565222054;
							break;
						case 3:
							return UnityVersion.UNITY_2017_3;
						case 4:
							num2 = 1565222037;
							break;
						case 9:
							return UnityVersion.UNITY_2017_9;
						default:
							return UnityVersion.UNITY_2017_0;
						case 2:
							num2 = 1565222039;
							break;
						}
						continue;
					case 2019:
						num2 = 1565222062;
						continue;
					case 2018:
						switch (result3)
						{
						default:
							return UnityVersion.UNITY_2018_0;
						case 7:
							num2 = 1565222036;
							break;
						case 2:
							return UnityVersion.UNITY_2018_2;
						case 3:
							return UnityVersion.UNITY_2018_3;
						case 4:
							return UnityVersion.UNITY_2018_4;
						case 5:
							num2 = 1565222018;
							break;
						case 0:
							return UnityVersion.UNITY_2018_0;
						case 1:
							num2 = 1565222074;
							break;
						case 6:
							num2 = 1565222072;
							break;
						case 8:
							return UnityVersion.UNITY_2018_8;
						case 9:
							num2 = 1565222076;
							break;
						}
						continue;
					case 2023:
						num2 = 1565222016;
						continue;
					case 2025:
						switch (result3)
						{
						case 2:
							num2 = 1565222024;
							break;
						case 0:
							return UnityVersion.UNITY_2025_0;
						case 1:
							num2 = 1565222025;
							break;
						case 3:
							return UnityVersion.UNITY_2025_3;
						case 4:
							return UnityVersion.UNITY_2025_4;
						case 5:
							return UnityVersion.UNITY_2025_5;
						case 6:
							num2 = 1565222023;
							break;
						case 7:
							return UnityVersion.UNITY_2025_7;
						case 8:
							return UnityVersion.UNITY_2025_8;
						case 9:
							return UnityVersion.UNITY_2025_9;
						default:
							return UnityVersion.UNITY_2025_0;
						}
						continue;
					case 2021:
						switch (result3)
						{
						default:
							return UnityVersion.UNITY_2021_0;
						case 8:
							return UnityVersion.UNITY_2021_8;
						case 9:
							num2 = 1565222073;
							break;
						case 0:
							return UnityVersion.UNITY_2021_0;
						case 1:
							return UnityVersion.UNITY_2021_1;
						case 2:
							num2 = 1565222050;
							break;
						case 4:
							return UnityVersion.UNITY_2021_4;
						case 5:
							return UnityVersion.UNITY_2021_5;
						case 6:
							return UnityVersion.UNITY_2021_6;
						case 7:
							num2 = 1565222031;
							break;
						case 3:
							num2 = 1565222068;
							break;
						}
						continue;
					case 2024:
						num2 = 1565222029;
						continue;
					}
				}
				else if (result3 == 6)
				{
					if (result != 1)
					{
						return UnityVersion.UNITY_2_6;
					}
					num2 = 1565222051;
					continue;
				}
				goto IL_08b9;
				IL_087a:
				return UnityVersion.UNITY_5_0;
			}
			goto IL_000b;
		}

		private static UnityVersion IaBzaRgIasIhREkkNMLlBJpTVnM(int P_0)
		{
			while (true)
			{
				int num = -387607252;
				while (true)
				{
					switch (num ^ -387607251)
					{
					case 2:
						break;
					case 1:
						switch (P_0)
						{
						default:
							num = -387607251;
							continue;
						case 3:
							break;
						case 4:
							return UnityVersion.UNITY_4_0;
						case 5:
							return UnityVersion.UNITY_5_0;
						}
						goto default;
					case 0:
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
						case 2022:
							return UnityVersion.UNITY_2022_0;
						case 2023:
							return UnityVersion.UNITY_2023_0;
						case 2024:
							return UnityVersion.UNITY_2024_0;
						case 2025:
							return UnityVersion.UNITY_2025_0;
						}
						num = -387607255;
						continue;
					default:
						return UnityVersion.UNITY_3_0;
					case 4:
						return UnityVersion.Unknown;
					}
					break;
				}
			}
		}

		private static UnityVersion VFISHsbzzjLLhObhKdcsfoDjXgM(int P_0)
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
			case 2022:
				return UnityVersion.UNITY_2022_MAX;
			case 2023:
				return UnityVersion.UNITY_2023_MAX;
			case 2024:
				return UnityVersion.UNITY_2024_MAX;
			case 2025:
				return UnityVersion.UNITY_2025_MAX;
			default:
				return UnityVersion.Unknown;
			}
		}

		private static void ebQADhlBvuDyoGCwkIUsrHHLWUS()
		{
			Platform platform = mZENHEMjnviELksEgQWRbKEsUyld;
			if (platform <= Platform.Android)
			{
				switch (platform)
				{
				case Platform.Android:
					goto IL_007d;
				case Platform.Windows:
					goto IL_00b3;
				case Platform.Linux:
					goto IL_0129;
				}
				goto IL_0024;
			}
			goto IL_0183;
			IL_0183:
			switch (platform)
			{
			case Platform.AmazonFireTV:
			case Platform.RazerForgeTV:
				break;
			case Platform.PS4:
				goto IL_00d9;
			default:
				goto IL_019c;
			}
			goto IL_007d;
			IL_0024:
			int num = 1234653172;
			goto IL_0029;
			IL_0029:
			while (true)
			{
				switch (num ^ 0x49974FFF)
				{
				case 6:
					break;
				default:
					return;
				case 7:
					goto IL_007d;
				case 15:
					if (RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_4_6_3p1)
					{
						goto IL_0096;
					}
					goto case 8;
				case 1:
					goto IL_00b3;
				case 12:
					goto IL_00d9;
				case 4:
					HHNDtCkHRliSQNLazSraPtjcVlI = "Empty";
					num = 1234653180;
					continue;
				case 11:
					num = 1234653170;
					continue;
				case 13:
					if (tRrUBkACJwkpIlVbmyzJntkNhHj)
					{
						EditorPlatform jlcjnOsxtYZFRoDQYarTuTByUtd = JlcjnOsxtYZFRoDQYarTuTByUtd;
						if (jlcjnOsxtYZFRoDQYarTuTByUtd != EditorPlatform.Windows)
						{
							return;
						}
						goto case 15;
					}
					return;
				case 9:
					goto IL_0129;
				case 10:
					goto IL_0139;
				case 3:
					teqiHkgPdBwoBecyAZpnnqCaqgj = true;
					num = 1234653170;
					continue;
				case 8:
				{
					int num2;
					if (RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_5_0_0p1)
					{
						num = 1234653181;
						num2 = num;
					}
					else
					{
						num = 1234653178;
						num2 = num;
					}
					continue;
				}
				case 16:
					goto IL_0183;
				case 14:
					RJQXwQECCvGkZtBjSfoAElyLJZW = true;
					JPcznPXbrOFGwKfeYlAqSRnGYuD = true;
					num = 1234653170;
					continue;
				case 0:
					AaUVUHxdtdAijvOeLCQUMrRsrjC = true;
					num = 1234653170;
					continue;
				case 2:
					RJQXwQECCvGkZtBjSfoAElyLJZW = true;
					JPcznPXbrOFGwKfeYlAqSRnGYuD = true;
					num = 1234653178;
					continue;
				case 5:
					return;
				}
				break;
				IL_0096:
				int num3;
				if (RWQkJOlZOhJpPBPaQFKmaerNgiXi < UnityVersion.UNITY_5_0)
				{
					num = 1234653181;
					num3 = num;
				}
				else
				{
					num = 1234653175;
					num3 = num;
				}
			}
			goto IL_0024;
			IL_007d:
			JPcznPXbrOFGwKfeYlAqSRnGYuD = true;
			num = 1234653183;
			goto IL_0029;
			IL_00b3:
			if (RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_4_6_3p1)
			{
				int num4;
				if (RWQkJOlZOhJpPBPaQFKmaerNgiXi < UnityVersion.UNITY_5_0)
				{
					num = 1234653169;
					num4 = num;
				}
				else
				{
					num = 1234653173;
					num4 = num;
				}
				goto IL_0029;
			}
			goto IL_0139;
			IL_00d9:
			JPcznPXbrOFGwKfeYlAqSRnGYuD = true;
			num = 1234653179;
			goto IL_0029;
			IL_0139:
			int num5;
			if (RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_5_0_0p1)
			{
				num = 1234653169;
				num5 = num;
			}
			else
			{
				num = 1234653170;
				num5 = num;
			}
			goto IL_0029;
			IL_0129:
			AaUVUHxdtdAijvOeLCQUMrRsrjC = true;
			num = 1234653170;
			goto IL_0029;
			IL_019c:
			num = 1234653170;
			goto IL_0029;
		}

		internal static Type jwdMpHkRCayAJQFJgCRvjlSDuAH(QqTsFDyFyVBrKaufXruuCgigFiHy P_0)
		{
			if (!initialized)
			{
				return null;
			}
			if (RWQkJOlZOhJpPBPaQFKmaerNgiXi >= UnityVersion.UNITY_4_3)
			{
				return wsenEUqFJEpYGGzTCqPvjjMskxa(P_0);
			}
			return null;
		}

		private static Type wsenEUqFJEpYGGzTCqPvjjMskxa(QqTsFDyFyVBrKaufXruuCgigFiHy P_0)
		{
			if (P_0 == QqTsFDyFyVBrKaufXruuCgigFiHy.sfRTwyaFFnFBRmGDCBUZDFBcIvG)
			{
				return typeof(RigidbodyInterpolation2D);
			}
			if (P_0 == QqTsFDyFyVBrKaufXruuCgigFiHy.QRrxROyNkAzrlOlKQdcNabiyckKD)
			{
				goto IL_0012;
			}
			if (P_0 == QqTsFDyFyVBrKaufXruuCgigFiHy.oBABmOrtaFiyuHOjdgzRXxgmQBeR)
			{
				return typeof(CollisionDetectionMode2D);
			}
			int num;
			if (P_0 == QqTsFDyFyVBrKaufXruuCgigFiHy.kamKkbWgiFWOcvOMjWNJXrgXopw)
			{
				num = -295851142;
			}
			else
			{
				if (P_0 != QqTsFDyFyVBrKaufXruuCgigFiHy.QpoUpFgYHzLLejbifAYiBqfrCMUy)
				{
					return null;
				}
				num = -295851144;
			}
			goto IL_0017;
			IL_0012:
			num = -295851143;
			goto IL_0017;
			IL_0017:
			switch (num ^ -295851144)
			{
			case 3:
				break;
			case 1:
				return typeof(RigidbodySleepMode2D);
			case 2:
				return typeof(PhysicsMaterial2D);
			default:
				return typeof(Collider2D);
			}
			goto IL_0012;
		}

		public static List<string> GetCurrentPlatformResourecesDLLPaths()
		{
			if (!initialized)
			{
				return null;
			}
			List<string> list = new List<string>();
			Platform platform = default(Platform);
			while (true)
			{
				int num = -463708821;
				while (true)
				{
					switch (num ^ -463708817)
					{
					case 0:
						break;
					case 4:
					{
						platform = UnityTools.platform;
						int num2;
						if (platform == Platform.Windows)
						{
							num = -463708823;
							num2 = num;
						}
						else
						{
							num = -463708820;
							num2 = num;
						}
						continue;
					}
					case 2:
						list.Add("Libs/Rewired_Linux");
						num = -463708822;
						continue;
					case 6:
						list.Add("Libs/Rewired_Windows");
						num = -463708824;
						continue;
					case 7:
						num = -463708822;
						continue;
					case 1:
						goto IL_0087;
					case 3:
						switch (platform)
						{
						case Platform.Linux:
							break;
						case Platform.OSX:
							goto IL_0087;
						default:
							goto IL_00b0;
						case Platform.iOS:
							goto IL_00ba;
						}
						goto case 2;
					default:
						goto IL_00ba;
						IL_00ba:
						return list;
						IL_00b0:
						num = -463708822;
						continue;
						IL_0087:
						list.Add("Libs/Rewired_OSX");
						num = -463708822;
						continue;
					}
					break;
				}
			}
		}

		public static Transform FindTransformInChildren(Transform transform, string name)
		{
			if (transform == null)
			{
				goto IL_0009;
			}
			int childCount = transform.childCount;
			int num = 0;
			int num2 = 1685383846;
			goto IL_000e;
			IL_000e:
			Transform transform2 = default(Transform);
			while (true)
			{
				switch (num2 ^ 0x6474EAA5)
				{
				case 5:
					break;
				case 1:
					return null;
				case 6:
				{
					Transform child = transform.GetChild(num);
					if (child.name == name)
					{
						return child;
					}
					transform2 = FindTransformInChildren(child, name);
					num2 = 1685383841;
					continue;
				}
				case 4:
					if (transform2 != null)
					{
						num2 = 1685383845;
						continue;
					}
					num++;
					num2 = 1685383846;
					continue;
				case 3:
				{
					int num3;
					if (num < childCount)
					{
						num2 = 1685383843;
						num3 = num2;
					}
					else
					{
						num2 = 1685383847;
						num3 = num2;
					}
					continue;
				}
				case 0:
					return transform2;
				default:
					return null;
				}
				break;
			}
			goto IL_0009;
			IL_0009:
			num2 = 1685383844;
			goto IL_000e;
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
			T result = default(T);
			if (transform == null)
			{
				while (true)
				{
					int num = 797072573;
					while (true)
					{
						switch (num ^ 0x2F825CBC)
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
						num = 797072572;
					}
				}
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
			return kxDDoYJpzrYCHuZTeImVHNJUUAG(gameObject.GetComponent(typeof(T)) as T);
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
				GetComponents(gameObject, list, append: false);
				int count = list.Count;
				T val = default(T);
				int num2 = default(int);
				while (true)
				{
					IL_0031:
					int num = 384272583;
					while (true)
					{
						switch (num ^ 0x16E788C3)
						{
						case 3:
							break;
						case 7:
							return val;
						case 0:
							if (!IsNullOrDestroyed(val))
							{
								int num4;
								if (includeInactive)
								{
									num = 384272580;
									num4 = num;
								}
								else
								{
									num = 384272578;
									num4 = num;
								}
								continue;
							}
							goto case 5;
						case 1:
						{
							int num3;
							if (IsEnabled(list[num2]))
							{
								num = 384272580;
								num3 = num;
							}
							else
							{
								num = 384272582;
								num3 = num;
							}
							continue;
						}
						case 6:
							val = list[num2] as T;
							num = 384272579;
							continue;
						case 5:
							num2++;
							num = 384272577;
							continue;
						case 4:
							num2 = 0;
							num = 384272577;
							continue;
						default:
							if (num2 >= count)
							{
								goto end_IL_0036;
							}
							goto case 6;
						}
						goto IL_0031;
						continue;
						end_IL_0036:
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
				GetComponents(gameObject, list, append: false);
				int count = list.Count;
				int num2 = default(int);
				while (true)
				{
					IL_0028:
					int num = -1286540691;
					while (true)
					{
						switch (num ^ -1286540690)
						{
						case 4:
							break;
						case 3:
							num2 = 0;
							num = -1286540690;
							continue;
						case 6:
							num2++;
							num = -1286540690;
							continue;
						case 2:
						{
							int num4;
							if (!IsEnabled(list[num2]))
							{
								num = -1286540696;
								num4 = num;
							}
							else
							{
								num = -1286540693;
								num4 = num;
							}
							continue;
						}
						case 5:
							return list[num2];
						case 1:
							if (ReflectionTools.DoesTypeImplement(list[num2].GetType(), type))
							{
								int num3;
								if (includeInactive)
								{
									num = -1286540693;
									num3 = num;
								}
								else
								{
									num = -1286540692;
									num3 = num;
								}
								continue;
							}
							goto case 6;
						default:
							if (num2 >= count)
							{
								goto end_IL_002d;
							}
							goto case 1;
						}
						goto IL_0028;
						continue;
						end_IL_002d:
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
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				GetComponents(gameObject, list, append: false);
				int num2 = default(int);
				int count = default(int);
				while (true)
				{
					IL_0021:
					int num = 693282805;
					while (true)
					{
						switch (num ^ 0x2952A7F1)
						{
						case 0:
							break;
						case 2:
							num2++;
							num = 693282800;
							continue;
						case 3:
							if (ReflectionTools.DoesTypeImplement(list[num2].GetType(), type))
							{
								return list[num2];
							}
							goto case 2;
						case 4:
							count = list.Count;
							num2 = 0;
							num = 693282800;
							continue;
						default:
							if (num2 >= count)
							{
								goto end_IL_0026;
							}
							goto case 3;
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
				goto IL_0009;
			}
			int childCount = transform.childCount;
			int num = 0;
			int num2 = -1748250804;
			goto IL_000e;
			IL_000e:
			T component = default(T);
			Transform child = default(Transform);
			T result2 = default(T);
			T componentInChildren = default(T);
			T result = default(T);
			while (true)
			{
				switch (num2 ^ -1748250805)
				{
				case 4:
					break;
				case 2:
					component = GetComponent<T>(child);
					num2 = -1748250813;
					continue;
				case 0:
					return result2;
				case 8:
					if (!IsNullOrDestroyed(component))
					{
						num2 = -1748250814;
						continue;
					}
					componentInChildren = GetComponentInChildren<T>(child);
					num2 = -1748250803;
					continue;
				case 9:
					return component;
				case 6:
					if (!IsNullOrDestroyed(componentInChildren))
					{
						return componentInChildren;
					}
					num++;
					num2 = -1748250804;
					continue;
				case 5:
					child = transform.GetChild(num);
					num2 = -1748250807;
					continue;
				case 7:
					if (num >= childCount)
					{
						result = null;
						num2 = -1748250806;
						continue;
					}
					goto case 5;
				case 3:
					result2 = null;
					num2 = -1748250805;
					continue;
				default:
					return result;
				}
				break;
			}
			goto IL_0009;
			IL_0009:
			num2 = -1748250808;
			goto IL_000e;
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
			int num = 540504502;
			goto IL_000e;
			IL_000e:
			T componentInChildren = default(T);
			int num2 = default(int);
			T result2 = default(T);
			T result = default(T);
			while (true)
			{
				switch (num ^ 0x203771BE)
				{
				case 6:
					break;
				case 4:
					num = 540504511;
					continue;
				case 0:
					if (!IsNullOrDestroyed(componentInChildren))
					{
						return componentInChildren;
					}
					num2++;
					num = 540504511;
					continue;
				case 5:
					return result2;
				case 1:
					if (num2 >= childCount)
					{
						result = null;
						num = 540504509;
						continue;
					}
					goto case 7;
				case 8:
					num2 = 0;
					num = 540504506;
					continue;
				case 7:
				{
					Transform child = transform.GetChild(num2);
					T component = GetComponent<T>(child, includeInactive);
					if (!IsNullOrDestroyed(component))
					{
						return component;
					}
					componentInChildren = GetComponentInChildren<T>(child, includeInactive);
					num = 540504510;
					continue;
				}
				case 2:
					result2 = null;
					num = 540504507;
					continue;
				default:
					return result;
				}
				break;
			}
			goto IL_0009;
			IL_0009:
			num = 540504508;
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
				goto IL_0009;
			}
			int childCount = transform.childCount;
			int num = 665844631;
			goto IL_000e;
			IL_000e:
			int num2 = default(int);
			Component componentInChildren = default(Component);
			while (true)
			{
				switch (num ^ 0x27AFFB97)
				{
				case 5:
					break;
				case 1:
					return null;
				case 0:
					num2 = 0;
					num = 665844627;
					continue;
				case 3:
				{
					Transform child = transform.GetChild(num2);
					Component component = GetComponent(child, type);
					if (!IsNullOrDestroyed(component))
					{
						return component;
					}
					componentInChildren = GetComponentInChildren(child, type);
					num = 665844629;
					continue;
				}
				case 2:
					if (!IsNullOrDestroyed(componentInChildren))
					{
						return componentInChildren;
					}
					num2++;
					num = 665844627;
					continue;
				default:
					if (num2 >= childCount)
					{
						return null;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0009;
			IL_0009:
			num = 665844630;
			goto IL_000e;
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
				goto IL_0009;
			}
			int childCount = transform.childCount;
			int num = 1871669976;
			goto IL_000e;
			IL_000e:
			Transform child = default(Transform);
			Component componentInChildren = default(Component);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x6F8F6AD9)
				{
				case 4:
					break;
				case 3:
				{
					Component component = GetComponent(child, type, includeInactive);
					if (!IsNullOrDestroyed(component))
					{
						return component;
					}
					componentInChildren = GetComponentInChildren(child, type);
					if (!IsNullOrDestroyed(componentInChildren))
					{
						num = 1871669977;
						continue;
					}
					num2++;
					num = 1871669983;
					continue;
				}
				case 1:
					num2 = 0;
					num = 1871669980;
					continue;
				case 7:
					child = transform.GetChild(num2);
					num = 1871669978;
					continue;
				case 5:
					num = 1871669983;
					continue;
				case 2:
					return null;
				case 0:
					return componentInChildren;
				default:
					if (num2 >= childCount)
					{
						return null;
					}
					goto case 7;
				}
				break;
			}
			goto IL_0009;
			IL_0009:
			num = 1871669979;
			goto IL_000e;
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
				goto IL_0009;
			}
			T component = GetComponent<T>(gameObject);
			int num;
			if (IsNullOrDestroyed(component))
			{
				num = -2052840494;
				goto IL_000e;
			}
			return component;
			IL_0009:
			num = -2052840493;
			goto IL_000e;
			IL_000e:
			switch (num ^ -2052840494)
			{
			case 2:
				break;
			case 1:
				return null;
			default:
				return GetComponentInChildren<T>(gameObject);
			}
			goto IL_0009;
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
			if (transform == null)
			{
				goto IL_0009;
			}
			while ((transform = transform.parent) != null)
			{
				T val = transform.GetComponent(typeof(T)) as T;
				if (!IsNullOrDestroyed(val))
				{
					return val;
				}
			}
			T result = null;
			int num = 846561309;
			goto IL_000e;
			IL_0009:
			num = 846561308;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x3275801D)
			{
			case 2:
				break;
			case 1:
				return null;
			default:
				return result;
			}
			goto IL_0009;
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
			if (transform == null)
			{
				return null;
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
						num2 = 554632361;
						goto IL_0030;
					}
					goto IL_007b;
					IL_0030:
					while (true)
					{
						switch (num2 ^ 0x210F04A9)
						{
						case 3:
							num2 = 554632360;
							continue;
						case 1:
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
					num2 = 554632363;
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
			Component[] components = default(Component[]);
			int num2 = default(int);
			while (true)
			{
				int num = -1314798942;
				while (true)
				{
					switch (num ^ -1314798944)
					{
					case 3:
						break;
					case 2:
						if (gameObject == null)
						{
							num = -1314798937;
							continue;
						}
						components = gameObject.GetComponents(typeof(Component));
						if (components == null)
						{
							return list;
						}
						num2 = 0;
						num = -1314798944;
						continue;
					case 7:
						return list;
					case 5:
						list.Add(components[num2] as T);
						num = -1314798938;
						continue;
					case 4:
						if (!IsNullOrDestroyed(components[num2] as T))
						{
							if (!includeInactive)
							{
								int num3;
								if (IsEnabled(components[num2]))
								{
									num = -1314798939;
									num3 = num;
								}
								else
								{
									num = -1314798938;
									num3 = num;
								}
								continue;
							}
							goto case 5;
						}
						goto case 6;
					case 6:
						num2++;
						num = -1314798943;
						continue;
					case 0:
						num = -1314798943;
						continue;
					default:
						if (num2 >= components.Length)
						{
							return list;
						}
						goto case 4;
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
			while (num < components.Length)
			{
				while (true)
				{
					int num2;
					if (!includeInactive)
					{
						int num3;
						if (IsEnabled(components[num]))
						{
							num2 = 1786927998;
							num3 = num2;
						}
						else
						{
							num2 = 1786927994;
							num3 = num2;
						}
						goto IL_0027;
					}
					goto IL_0071;
					IL_0027:
					while (true)
					{
						switch (num2 ^ 0x6A825B7E)
						{
						case 2:
							num2 = 1786927997;
							continue;
						case 3:
							break;
						case 4:
							num++;
							num2 = 1786927999;
							continue;
						case 0:
							goto IL_0071;
						default:
							goto end_IL_0048;
						}
						break;
					}
					continue;
					IL_0071:
					list.Add(components[num]);
					num2 = 1786927994;
					goto IL_0027;
					continue;
					end_IL_0048:
					break;
				}
			}
			return list;
		}

		public static List<T> GetComponentsInChildren<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				goto IL_0009;
			}
			goto IL_0046;
			IL_0009:
			int num = 685889139;
			goto IL_000e;
			IL_000e:
			int num2 = default(int);
			List<T> list = default(List<T>);
			int childCount = default(int);
			while (true)
			{
				switch (num ^ 0x28E1D671)
				{
				case 3:
					break;
				case 1:
					num2++;
					num = 685889142;
					continue;
				case 4:
					goto IL_0046;
				case 6:
					GetComponentsInSelfAndChildren(transform.GetChild(num2), list, append: true);
					num = 685889136;
					continue;
				case 0:
					childCount = transform.childCount;
					num = 685889140;
					continue;
				case 2:
					throw new ArgumentNullException("transform");
				case 5:
					num2 = 0;
					num = 685889142;
					continue;
				default:
					if (num2 >= childCount)
					{
						return list;
					}
					goto case 6;
				}
				break;
			}
			goto IL_0009;
			IL_0046:
			list = new List<T>();
			num = 685889137;
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
				int num2 = 1867874961;
				while (true)
				{
					switch (num2 ^ 0x6F558292)
					{
					case 0:
						num2 = 1867874960;
						continue;
					case 2:
						break;
					case 1:
						GetComponentsInSelfAndChildren(transform.GetChild(num), includeInactive, list, append: true);
						num++;
						num2 = 1867874961;
						continue;
					default:
						if (num >= childCount)
						{
							return list;
						}
						goto case 1;
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
				throw new ArgumentNullException("gameObject");
			}
			return GetComponentsInChildren<T>(gameObject.transform, includeInactive);
		}

		public static List<Component> GetComponentsInChildren(Transform transform)
		{
			if (transform == null)
			{
				goto IL_0009;
			}
			goto IL_0049;
			IL_0009:
			int num = 2039227796;
			goto IL_000e;
			IL_000e:
			int num2 = default(int);
			List<Component> list = default(List<Component>);
			int childCount = default(int);
			while (true)
			{
				switch (num ^ 0x798C2595)
				{
				case 3:
					break;
				case 4:
					GetComponentsInSelfAndChildren(transform.GetChild(num2), list, append: true);
					num2++;
					num = 2039227799;
					continue;
				case 0:
					goto IL_0049;
				case 1:
					throw new ArgumentNullException("transform");
				default:
					if (num2 >= childCount)
					{
						return list;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0009;
			IL_0049:
			list = new List<Component>();
			childCount = transform.childCount;
			num2 = 0;
			num = 2039227799;
			goto IL_000e;
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
			if (gameObject == null)
			{
				return list;
			}
			Component[] componentsInChildren = gameObject.GetComponentsInChildren(typeof(Component), includeInactive: true);
			if (componentsInChildren == null)
			{
				return list;
			}
			int num = 0;
			while (true)
			{
				int num2 = 2103484066;
				while (true)
				{
					switch (num2 ^ 0x7D609EA3)
					{
					case 2:
						break;
					case 1:
						num2 = 2103484070;
						continue;
					case 3:
						num++;
						num2 = 2103484070;
						continue;
					case 5:
					{
						int num3;
						if (num >= componentsInChildren.Length)
						{
							num2 = 2103484071;
							num3 = num2;
						}
						else
						{
							num2 = 2103484067;
							num3 = num2;
						}
						continue;
					}
					case 0:
						if (!IsNullOrDestroyed(componentsInChildren[num] as T))
						{
							list.Add(componentsInChildren[num] as T);
							num2 = 2103484064;
							continue;
						}
						goto case 3;
					default:
						return list;
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
				int num = 194385959;
				while (true)
				{
					switch (num ^ 0xB961824)
					{
					case 0:
						num = 194385952;
						continue;
					case 4:
						break;
					case 1:
						GetComponents(transform2, list, append: true);
						num = 194385958;
						continue;
					case 3:
						transform2 = transform;
						num = 194385958;
						continue;
					default:
						if (!((transform2 = transform2.parent) != null))
						{
							return list;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public static List<T> GetComponentsInParents<T>(Component component) where T : class
		{
			if (component == null)
			{
				while (true)
				{
					switch (0x19EEA0C5 ^ 0x19EEA0C4)
					{
					case 2:
						continue;
					case 1:
						throw new ArgumentNullException("component");
					}
					break;
				}
			}
			return GetComponentsInParents<T>(component.transform);
		}

		public static List<T> GetComponentsInParents<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				while (true)
				{
					switch (-1376896452 ^ -1376896450)
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
				int num = -794416870;
				while (true)
				{
					switch (num ^ -794416866)
					{
					case 0:
						num = -794416865;
						continue;
					case 4:
					{
						int num2;
						if (!((transform2 = transform2.parent) != null))
						{
							num = -794416867;
							num2 = num;
						}
						else
						{
							num = -794416868;
							num2 = num;
						}
						continue;
					}
					case 2:
						GetComponents(transform2, list, append: true);
						num = -794416870;
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
					switch (-483608465 ^ -483608466)
					{
					case 2:
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
				goto IL_0009;
			}
			goto IL_0041;
			IL_0009:
			int num = 1358025118;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x50F1D19C)
			{
			case 3:
				break;
			case 2:
				throw new ArgumentNullException("gameObject");
			case 1:
				goto IL_0041;
			case 0:
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
			IL_0056:
			if (!append)
			{
				results.Clear();
				num = 1358025112;
				goto IL_000e;
			}
			goto IL_0066;
			IL_0066:
			using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
			{
				List<Component> list = tList.list;
				gameObject.GetComponents(list);
				int count = default(int);
				int num3 = default(int);
				while (true)
				{
					IL_007a:
					int num2 = 1358025117;
					while (true)
					{
						switch (num2 ^ 0x50F1D19C)
						{
						case 2:
							break;
						default:
							goto end_IL_007f;
						case 1:
							count = list.Count;
							num3 = 0;
							num2 = 1358025113;
							continue;
						case 5:
							num2 = 1358025114;
							continue;
						case 3:
						{
							T val = list[num3] as T;
							if (!IsNullOrDestroyed(val))
							{
								results.Add(val);
								num2 = 1358025112;
								continue;
							}
							goto case 4;
						}
						case 6:
						{
							int num4;
							if (num3 >= count)
							{
								num2 = 1358025116;
								num4 = num2;
							}
							else
							{
								num2 = 1358025119;
								num4 = num2;
							}
							continue;
						}
						case 4:
							num3++;
							num2 = 1358025114;
							continue;
						case 0:
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
			while (results != null)
			{
				while (true)
				{
					IL_004b:
					if (!append)
					{
						results.Clear();
						int num = 1597843671;
						while (true)
						{
							switch (num ^ 0x5F3D28D7)
							{
							case 2:
								num = 1597843670;
								continue;
							case 1:
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
						int count = list.Count;
						while (true)
						{
							IL_0076:
							int num2 = 1597843666;
							while (true)
							{
								switch (num2 ^ 0x5F3D28D7)
								{
								case 0:
									break;
								case 5:
									num3 = 0;
									num2 = 1597843669;
									continue;
								case 4:
								{
									val = list[num3] as T;
									int num5;
									if (!IsNullOrDestroyed(val))
									{
										num2 = 1597843670;
										num5 = num2;
									}
									else
									{
										num2 = 1597843668;
										num5 = num2;
									}
									continue;
								}
								case 3:
									num3++;
									num2 = 1597843669;
									continue;
								case 1:
									if (!includeInactive)
									{
										int num4;
										if (IsEnabled(list[num3]))
										{
											num2 = 1597843665;
											num4 = num2;
										}
										else
										{
											num2 = 1597843668;
											num4 = num2;
										}
										continue;
									}
									goto case 6;
								case 6:
									results.Add(val);
									num2 = 1597843668;
									continue;
								default:
									if (num3 >= count)
									{
										goto end_IL_007b;
									}
									goto case 4;
								}
								goto IL_0076;
								continue;
								end_IL_007b:
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
					switch (0x48BACB81 ^ 0x48BACB83)
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
			int num4 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (results != null)
				{
					num = 555957389;
					num2 = num;
				}
				else
				{
					num = 555957387;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x21233C8F)
					{
					case 0:
						num = 555957388;
						continue;
					case 2:
						if (!append)
						{
							results.Clear();
							num = 555957390;
							continue;
						}
						goto default;
					case 4:
						throw new ArgumentNullException("results");
					case 3:
						break;
					default:
					{
						using (TempListPool.TList<Component> tList = TempListPool.GetTList<Component>())
						{
							List<Component> list = tList.list;
							gameObject.GetComponents(list);
							int count = list.Count;
							while (true)
							{
								IL_008b:
								int num3 = 555957390;
								while (true)
								{
									switch (num3 ^ 0x21233C8F)
									{
									case 3:
										break;
									case 2:
										num4++;
										num3 = 555957387;
										continue;
									case 0:
									{
										Component component = list[num4];
										if (!(component == null))
										{
											results.Add(component);
											num3 = 555957389;
											continue;
										}
										goto case 2;
									}
									case 1:
										num4 = 0;
										num3 = 555957387;
										continue;
									default:
										if (num4 >= count)
										{
											goto end_IL_0090;
										}
										goto case 0;
									}
									goto IL_008b;
									continue;
									end_IL_0090:
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
				throw new ArgumentNullException("gameObject");
			}
			int num3 = default(int);
			int count = default(int);
			while (results != null)
			{
				while (true)
				{
					IL_004b:
					if (!append)
					{
						results.Clear();
						int num = -1464816915;
						while (true)
						{
							switch (num ^ -1464816913)
							{
							case 0:
								num = -1464816914;
								continue;
							case 1:
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
						while (true)
						{
							IL_0068:
							int num2 = -1464816915;
							while (true)
							{
								switch (num2 ^ -1464816913)
								{
								case 0:
									break;
								case 4:
									num3++;
									num2 = -1464816914;
									continue;
								case 3:
								{
									Component component = list[num3];
									if (!(component == null))
									{
										results.Add(component);
										num2 = -1464816917;
										continue;
									}
									goto case 4;
								}
								case 2:
									gameObject.GetComponents(type, list);
									count = list.Count;
									num3 = 0;
									num2 = -1464816914;
									continue;
								default:
									if (num3 >= count)
									{
										goto end_IL_006d;
									}
									goto case 3;
								}
								goto IL_0068;
								continue;
								end_IL_006d:
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

		public static int GetComponentsInSelfAndChildren(Transform transform, List<Component> results, bool append)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			while (true)
			{
				int num;
				int num2;
				if (!(transform == null))
				{
					num = 2101616146;
					num2 = num;
				}
				else
				{
					num = 2101616147;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x7D441E13)
					{
					case 4:
						num = 2101616144;
						continue;
					case 3:
						break;
					case 1:
						if (!append)
						{
							results.Clear();
							num = 2101616145;
							continue;
						}
						goto default;
					case 0:
						throw new ArgumentNullException("transform");
					default:
					{
						TempListPool.TList<Component> tList = TempListPool.GetTList<Component>();
						try
						{
							List<Component> list = tList.list;
							transform.GetComponents(list);
							int count = list.Count;
							int num3 = 0;
							while (num3 < count)
							{
								while (true)
								{
									Component component = list[num3];
									int num4;
									if (!(component == null))
									{
										results.Add(component);
										num4 = 2101616145;
										goto IL_0094;
									}
									goto IL_00d3;
									IL_0094:
									while (true)
									{
										switch (num4 ^ 0x7D441E13)
										{
										case 3:
											num4 = 2101616146;
											continue;
										case 1:
											break;
										case 2:
											goto IL_00d3;
										default:
											goto end_IL_00b1;
										}
										break;
									}
									continue;
									IL_00d3:
									num3++;
									num4 = 2101616147;
									goto IL_0094;
									continue;
									end_IL_00b1:
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
									IL_00e7:
									int num5 = 2101616146;
									while (true)
									{
										switch (num5 ^ 0x7D441E13)
										{
										case 2:
											break;
										default:
											goto end_IL_00ec;
										case 1:
											goto IL_0105;
										case 0:
											goto end_IL_00ec;
										}
										goto IL_00e7;
										IL_0105:
										((IDisposable)tList).Dispose();
										num5 = 2101616147;
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
							int num7;
							int num8;
							if (num6 >= childCount)
							{
								num7 = 2101616144;
								num8 = num7;
							}
							else
							{
								num7 = 2101616146;
								num8 = num7;
							}
							while (true)
							{
								switch (num7 ^ 0x7D441E13)
								{
								case 2:
									num7 = 2101616146;
									continue;
								case 1:
									GetComponentsInSelfAndChildren(transform.GetChild(num6), results, append: true);
									num6++;
									num7 = 2101616147;
									continue;
								case 0:
									break;
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

		public static int GetComponentsInSelfAndChildren(Component component, List<Component> results, bool append)
		{
			if (component == null)
			{
				while (true)
				{
					switch (-1759421516 ^ -1759421515)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("component");
					}
					break;
				}
			}
			return GetComponentsInSelfAndChildren(component.transform, results, append);
		}

		public static int GetComponentsInSelfAndChildren(GameObject gameObject, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				while (true)
				{
					switch (-172659057 ^ -172659058)
					{
					case 2:
						continue;
					case 1:
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
			int num4 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (!(transform == null))
				{
					num = 26825379;
					num2 = num;
				}
				else
				{
					num = 26825376;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x19952A2)
					{
					case 0:
						num = 26825377;
						continue;
					case 1:
						if (!append)
						{
							results.Clear();
							num = 26825382;
							continue;
						}
						goto default;
					case 2:
						throw new ArgumentNullException("transform");
					case 3:
						break;
					default:
					{
						TempListPool.TList<Component> tList = TempListPool.GetTList<Component>();
						try
						{
							List<Component> list = tList.list;
							transform.GetComponents(list);
							int count = list.Count;
							while (true)
							{
								IL_008b:
								int num3 = 26825379;
								while (true)
								{
									switch (num3 ^ 0x19952A2)
									{
									case 3:
										break;
									default:
										goto end_IL_0090;
									case 2:
										num4++;
										num3 = 26825378;
										continue;
									case 0:
									{
										int num5;
										if (num4 >= count)
										{
											num3 = 26825382;
											num5 = num3;
										}
										else
										{
											num3 = 26825383;
											num5 = num3;
										}
										continue;
									}
									case 1:
										num4 = 0;
										num3 = 26825378;
										continue;
									case 5:
									{
										T val = list[num4] as T;
										if (!IsNullOrDestroyed(val))
										{
											results.Add(val);
											num3 = 26825376;
											continue;
										}
										goto case 2;
									}
									case 4:
										goto end_IL_0090;
									}
									goto IL_008b;
									continue;
									end_IL_0090:
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
									IL_010e:
									int num6 = 26825379;
									while (true)
									{
										switch (num6 ^ 0x19952A2)
										{
										case 2:
											break;
										default:
											goto end_IL_0113;
										case 1:
											goto IL_012c;
										case 0:
											goto end_IL_0113;
										}
										goto IL_010e;
										IL_012c:
										((IDisposable)tList).Dispose();
										num6 = 26825378;
										continue;
										end_IL_0113:
										break;
									}
									break;
								}
							}
						}
						int childCount = transform.childCount;
						int num7 = 0;
						while (true)
						{
							int num8 = 26825377;
							while (true)
							{
								switch (num8 ^ 0x19952A2)
								{
								case 4:
									break;
								case 3:
									num8 = 26825376;
									continue;
								case 2:
								{
									int num9;
									if (num7 < childCount)
									{
										num8 = 26825379;
										num9 = num8;
									}
									else
									{
										num8 = 26825378;
										num9 = num8;
									}
									continue;
								}
								case 1:
									GetComponentsInSelfAndChildren(transform.GetChild(num7), results, append: true);
									num7++;
									num8 = 26825376;
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

		public static int GetComponentsInSelfAndChildren<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				while (true)
				{
					switch (-1141900919 ^ -1141900920)
					{
					case 2:
						continue;
					case 1:
						throw new ArgumentNullException("component");
					}
					break;
				}
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
			int num8 = default(int);
			while (!(transform == null))
			{
				while (true)
				{
					int num;
					int num2;
					if (!append)
					{
						num = -1930027451;
						num2 = num;
					}
					else
					{
						num = -1930027456;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1930027455)
						{
						case 0:
							num = -1930027453;
							continue;
						case 4:
							results.Clear();
							num = -1930027456;
							continue;
						case 3:
							break;
						case 2:
							goto end_IL_0041;
						default:
						{
							TempListPool.TList<Component> tList = TempListPool.GetTList<Component>();
							try
							{
								List<Component> list = tList.list;
								transform.GetComponents(list);
								int count = list.Count;
								int num3 = 0;
								while (true)
								{
									IL_008d:
									int num4 = -1930027451;
									while (true)
									{
										switch (num4 ^ -1930027455)
										{
										case 0:
											break;
										case 3:
											num3++;
											num4 = -1930027453;
											continue;
										case 1:
											val = list[num3] as T;
											if (IsNullOrDestroyed(val))
											{
												goto case 3;
											}
											if (!includeInactive)
											{
												int num5;
												if (!IsEnabled(list[num3]))
												{
													num4 = -1930027454;
													num5 = num4;
												}
												else
												{
													num4 = -1930027452;
													num5 = num4;
												}
												continue;
											}
											goto case 5;
										case 5:
											results.Add(val);
											num4 = -1930027454;
											continue;
										case 4:
											num4 = -1930027453;
											continue;
										default:
											if (num3 >= count)
											{
												goto end_IL_0092;
											}
											goto case 1;
										}
										goto IL_008d;
										continue;
										end_IL_0092:
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
										IL_0122:
										int num6 = -1930027456;
										while (true)
										{
											switch (num6 ^ -1930027455)
											{
											case 0:
												break;
											default:
												goto end_IL_0127;
											case 1:
												goto IL_0140;
											case 2:
												goto end_IL_0127;
											}
											goto IL_0122;
											IL_0140:
											((IDisposable)tList).Dispose();
											num6 = -1930027453;
											continue;
											end_IL_0127:
											break;
										}
										break;
									}
								}
							}
							int childCount = transform.childCount;
							while (true)
							{
								int num7 = -1930027456;
								while (true)
								{
									switch (num7 ^ -1930027455)
									{
									case 2:
										break;
									case 1:
										num8 = 0;
										num7 = -1930027455;
										continue;
									case 3:
										GetComponentsInSelfAndChildren(transform.GetChild(num8), includeInactive, results, append: true);
										num8++;
										num7 = -1930027455;
										continue;
									default:
										if (num8 >= childCount)
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
						break;
					}
					continue;
					end_IL_0041:
					break;
				}
			}
			throw new ArgumentNullException("transform");
		}

		public static int GetComponentsInSelfAndChildren<T>(Component component, bool includeInactive, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				while (true)
				{
					switch (-830099734 ^ -830099733)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentNullException("component");
					}
					break;
				}
			}
			return GetComponentsInSelfAndChildren(component.transform, includeInactive, results, append);
		}

		public static int GetComponentsInSelfAndChildren<T>(GameObject gameObject, bool includeInactive, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				while (true)
				{
					switch (0x12CD170A ^ 0x12CD170B)
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
			goto IL_0053;
			IL_0003:
			int num = -1327966538;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			int childCount = default(int);
			while (true)
			{
				switch (num ^ -1327966540)
				{
				case 0:
					break;
				case 2:
					throw new ArgumentNullException("results");
				case 5:
					goto IL_0043;
				case 4:
					goto IL_0053;
				case 1:
					goto IL_006e;
				case 3:
					GetComponentsInSelfAndChildren(transform.GetChild(num2), results, append: true);
					num2++;
					num = -1327966542;
					continue;
				default:
					if (num2 >= childCount)
					{
						return results.Count;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0003;
			IL_0043:
			childCount = transform.childCount;
			num2 = 0;
			num = -1327966542;
			goto IL_0008;
			IL_0053:
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			goto IL_006e;
			IL_006e:
			if (!append)
			{
				results.Clear();
				num = -1327966543;
				goto IL_0008;
			}
			goto IL_0043;
		}

		public static int GetComponentsInChildren<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				while (true)
				{
					switch (-1125045955 ^ -1125045956)
					{
					case 2:
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
				throw new ArgumentNullException("gameObject");
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
				if (!(transform == null))
				{
					num = -1119832467;
					num2 = num;
				}
				else
				{
					num = -1119832478;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1119832475)
					{
					case 2:
						num = -1119832476;
						continue;
					case 4:
						GetComponentsInSelfAndChildren(transform.GetChild(num3), includeInactive, results, append: true);
						num3++;
						num = -1119832475;
						continue;
					case 5:
						num = -1119832475;
						continue;
					case 1:
						break;
					case 3:
						childCount = transform.childCount;
						num3 = 0;
						num = -1119832480;
						continue;
					case 7:
						throw new ArgumentNullException("transform");
					case 0:
					{
						int num4;
						if (num3 >= childCount)
						{
							num = -1119832477;
							num4 = num;
						}
						else
						{
							num = -1119832479;
							num4 = num;
						}
						continue;
					}
					case 8:
						if (!append)
						{
							results.Clear();
							num = -1119832474;
							continue;
						}
						goto case 3;
					default:
						return results.Count;
					}
					break;
				}
			}
		}

		public static int GetComponentsInChildren<T>(Component component, bool includeInactive, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				while (true)
				{
					switch (0x75807222 ^ 0x75807220)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentNullException("component");
					}
					break;
				}
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
				throw new ArgumentNullException("results");
			}
			int num2 = default(int);
			int childCount = default(int);
			while (!(transform == null))
			{
				while (true)
				{
					int num;
					if (!append)
					{
						results.Clear();
						num = 1906500817;
						goto IL_0013;
					}
					goto IL_006f;
					IL_0013:
					while (true)
					{
						switch (num ^ 0x71A2E4D2)
						{
						case 0:
							num = 1906500820;
							continue;
						case 1:
							num2 = 0;
							num = 1906500816;
							continue;
						case 4:
							break;
						case 5:
							GetComponentsInSelfAndChildren(transform.GetChild(num2), results, append: true);
							num2++;
							num = 1906500816;
							continue;
						case 3:
							goto IL_006f;
						case 6:
							goto end_IL_0045;
						default:
							if (num2 >= childCount)
							{
								return results.Count;
							}
							goto case 5;
						}
						break;
					}
					continue;
					IL_006f:
					childCount = transform.childCount;
					num = 1906500819;
					goto IL_0013;
					continue;
					end_IL_0045:
					break;
				}
			}
			throw new ArgumentNullException("transform");
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
			while (true)
			{
				int num;
				int num2;
				if (results != null)
				{
					num = 1918789026;
					num2 = num;
				}
				else
				{
					num = 1918789031;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x725E65A1)
					{
					case 0:
						num = 1918789028;
						continue;
					case 5:
						break;
					case 6:
						throw new ArgumentNullException("results");
					case 2:
						parent = gameObject.transform.parent;
						num = 1918789029;
						continue;
					case 3:
						if (!append)
						{
							results.Clear();
							num = 1918789027;
							continue;
						}
						goto case 2;
					case 1:
						GetComponents(parent, results, append: true);
						num = 1918789029;
						continue;
					default:
						if (!((parent = parent.parent) != null))
						{
							return results.Count;
						}
						goto case 1;
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
				throw new ArgumentNullException("component");
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
				if (results == null)
				{
					num = 892951052;
					num2 = num;
				}
				else
				{
					num = 892951048;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x35395A09)
					{
					case 6:
						num = 892951050;
						continue;
					case 3:
						break;
					case 5:
						throw new ArgumentNullException("results");
					case 4:
						parent = gameObject.transform.parent;
						num = 892951051;
						continue;
					case 0:
						GetComponents(parent, results, append: true);
						num = 892951051;
						continue;
					case 1:
						if (!append)
						{
							results.Clear();
							num = 892951053;
							continue;
						}
						goto case 4;
					default:
						if (!((parent = parent.parent) != null))
						{
							return results.Count;
						}
						goto case 0;
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
				T val = default(T);
				int num2 = default(int);
				int count = default(int);
				while (true)
				{
					IL_0054:
					int num = -1073100222;
					while (true)
					{
						switch (num ^ -1073100219)
						{
						case 0:
							break;
						case 6:
							val = list[num2] as T;
							num = -1073100223;
							continue;
						case 3:
							count = list.Count;
							num2 = 0;
							num = -1073100224;
							continue;
						case 1:
							num2++;
							num = -1073100224;
							continue;
						case 4:
						{
							int num3;
							if (!IsNullOrDestroyed(val))
							{
								num = -1073100217;
								num3 = num;
							}
							else
							{
								num = -1073100220;
								num3 = num;
							}
							continue;
						}
						case 2:
							@delegate(val);
							num = -1073100220;
							continue;
						case 7:
							transform.GetComponents(list);
							num = -1073100218;
							continue;
						default:
							if (num2 >= count)
							{
								goto end_IL_0059;
							}
							goto case 6;
						}
						goto IL_0054;
						continue;
						end_IL_0059:
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
						IL_0101:
						int num4 = -1073100217;
						while (true)
						{
							switch (num4 ^ -1073100219)
							{
							case 0:
								break;
							default:
								goto end_IL_0106;
							case 2:
								goto IL_011f;
							case 1:
								goto end_IL_0106;
							}
							goto IL_0101;
							IL_011f:
							((IDisposable)tList).Dispose();
							num4 = -1073100220;
							continue;
							end_IL_0106:
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
			int num5 = 0;
			while (true)
			{
				int num6;
				int num7;
				if (num5 < childCount)
				{
					num6 = -1073100220;
					num7 = num6;
				}
				else
				{
					num6 = -1073100219;
					num7 = num6;
				}
				while (true)
				{
					switch (num6 ^ -1073100219)
					{
					case 2:
						num6 = -1073100220;
						continue;
					default:
						return;
					case 4:
						break;
					case 3:
						num5++;
						num6 = -1073100223;
						continue;
					case 1:
						ForEachComponent(transform.GetChild(num5), @delegate, includeChildren);
						num6 = -1073100218;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		public static void ForEachComponent<T>(Transform transform, Action<T> @delegate) where T : class
		{
			ForEachComponent(transform, @delegate, includeChildren: false);
		}

		public static void ForEachComponent<T>(Component component, Action<T> @delegate, bool includeChildren) where T : class
		{
			ForEachComponent(component.transform, @delegate, includeChildren);
		}

		public static void ForEachComponent<T>(Component component, Action<T> @delegate) where T : class
		{
			ForEachComponent(component.transform, @delegate, includeChildren: false);
		}

		public static void ForEachComponent<T>(GameObject gameObject, Action<T> @delegate, bool includeChildren) where T : class
		{
			ForEachComponent(gameObject.transform, @delegate, includeChildren);
		}

		public static void ForEachComponent<T>(GameObject gameObject, Action<T> @delegate) where T : class
		{
			ForEachComponent(gameObject.transform, @delegate, includeChildren: false);
		}

		public static void ForEachComponentInChildren<T>(Transform transform, Action<T> @delegate) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			while (true)
			{
				if (@delegate != null)
				{
					while (true)
					{
						int childCount = transform.childCount;
						int num = 0;
						int num2 = 1972873618;
						while (true)
						{
							switch (num2 ^ 0x7597A993)
							{
							case 5:
								num2 = 1972873616;
								continue;
							case 4:
								ForEachComponent(transform.GetChild(num), @delegate, includeChildren: true);
								num++;
								num2 = 1972873619;
								continue;
							case 2:
								break;
							case 3:
								goto end_IL_0057;
							case 1:
								num2 = 1972873619;
								continue;
							default:
								if (num >= childCount)
								{
									return;
								}
								goto case 4;
							}
							break;
						}
						continue;
						end_IL_0057:
						break;
					}
					continue;
				}
				throw new ArgumentNullException("@delegate");
			}
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
				int num = -1555887304;
				while (true)
				{
					switch (num ^ -1555887303)
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
					num = -1555887301;
				}
			}
		}

		public static void ForEachComponentInChildren<T>(GameObject gameObject, Action<T> @delegate) where T : class
		{
			if (gameObject == null)
			{
				while (true)
				{
					switch (0x789DA9F4 ^ 0x789DA9F6)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentNullException("gameObject");
					}
					break;
				}
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
			if (original == null)
			{
				return null;
			}
			UnityEngine.Object obj = UnityEngine.Object.Instantiate(original);
			Transform transform = default(Transform);
			if (parent != null)
			{
				transform = null;
				goto IL_0028;
			}
			goto IL_00ed;
			IL_0203:
			return kxDDoYJpzrYCHuZTeImVHNJUUAG(obj as T);
			IL_00ed:
			int num;
			if (IsNullOrDestroyed(obj as T))
			{
				if (obj as GameObject != null)
				{
					num = -1737708166;
				}
				else
				{
					if (!(obj as Transform != null))
					{
						goto IL_0203;
					}
					num = -1737708165;
				}
				goto IL_002d;
			}
			goto IL_0203;
			IL_0028:
			num = -1737708168;
			goto IL_002d;
			IL_002d:
			Vector3 localScale = default(Vector3);
			while (true)
			{
				switch (num ^ -1737708167)
				{
				case 10:
					break;
				case 11:
					transform.localScale = localScale;
					num = -1737708172;
					continue;
				case 6:
					transform.parent = parent;
					num = -1737708172;
					continue;
				case 8:
					goto IL_0091;
				case 1:
					if (obj as Component != null)
					{
						transform = (obj as Component).transform;
						num = -1737708167;
						continue;
					}
					goto case 5;
				case 0:
					num = -1737708175;
					continue;
				case 9:
					num = -1737708175;
					continue;
				case 13:
					goto IL_00ed;
				case 12:
					transform.position = position;
					transform.rotation = rotation;
					num = -1737708161;
					continue;
				case 4:
					localScale = transform.localScale;
					transform.parent = parent;
					transform.localPosition = position;
					transform.localRotation = rotation;
					num = -1737708174;
					continue;
				case 7:
					if (obj as Transform != null)
					{
						transform = obj as Transform;
						num = -1737708175;
						continue;
					}
					goto IL_0091;
				case 5:
					if (obj as GameObject != null)
					{
						transform = (obj as GameObject).transform;
						num = -1737708176;
						continue;
					}
					goto case 7;
				case 3:
					return kxDDoYJpzrYCHuZTeImVHNJUUAG((obj as GameObject).GetComponent(typeof(T)) as T);
				default:
					return kxDDoYJpzrYCHuZTeImVHNJUUAG((obj as Transform).GetComponent(typeof(T)) as T);
				}
				break;
				IL_0091:
				if (transform != null)
				{
					int num2;
					if (!instantiateInWorldSpace)
					{
						num = -1737708163;
						num2 = num;
					}
					else
					{
						num = -1737708171;
						num2 = num;
					}
					continue;
				}
				goto IL_00ed;
			}
			goto IL_0028;
		}

		public static Vector3 TransformPoint(Transform from, Transform to, Vector3 point)
		{
			if (!(from != null))
			{
				goto IL_0009;
			}
			Vector3 vector = from.TransformPoint(point);
			goto IL_0031;
			IL_0039:
			Vector3 vector2 = default(Vector3);
			if (to == null)
			{
				return vector2;
			}
			return to.InverseTransformPoint(vector2);
			IL_0009:
			int num = -797541232;
			goto IL_000e;
			IL_000e:
			switch (num ^ -797541230)
			{
			case 0:
				break;
			case 2:
				goto IL_0027;
			default:
				goto IL_0039;
			}
			goto IL_0009;
			IL_0027:
			vector = point;
			goto IL_0031;
			IL_0031:
			vector2 = vector;
			num = -797541229;
			goto IL_000e;
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
				num = 827079046;
				goto IL_000e;
			}
			return to.InverseTransformDirection(vector2);
			IL_0009:
			num = 827079047;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x314C3986)
			{
			case 2:
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
			if (!(from != null))
			{
				goto IL_0098;
			}
			Vector3 position = from.TransformPoint(new Vector2(rect.xMin, rect.yMin));
			Vector3 position2 = from.TransformPoint(new Vector2(rect.xMin, rect.yMax));
			Vector3 position3 = from.TransformPoint(new Vector2(rect.xMax, rect.yMin));
			goto IL_00ea;
			IL_0129:
			return new Rect(position.x, position.y, position3.x - position.x, position.y - position2.y);
			IL_00ea:
			int num;
			if (to != null)
			{
				position = to.InverseTransformPoint(position);
				num = 464646685;
				goto IL_0070;
			}
			goto IL_0129;
			IL_0098:
			position = new Vector2(rect.xMin, rect.yMin);
			position2 = new Vector2(rect.xMin, rect.yMax);
			position3 = new Vector2(rect.xMax, rect.yMin);
			num = 464646684;
			goto IL_0070;
			IL_0070:
			while (true)
			{
				switch (num ^ 0x1BB1F219)
				{
				case 2:
					num = 464646680;
					continue;
				case 1:
					break;
				case 5:
					goto IL_00ea;
				case 0:
					position3 = to.InverseTransformPoint(position3);
					num = 464646682;
					continue;
				case 4:
					position2 = to.InverseTransformPoint(position2);
					num = 464646681;
					continue;
				default:
					goto IL_0129;
				}
				break;
			}
			goto IL_0098;
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
			while (true)
			{
				int num = 802499012;
				while (true)
				{
					switch (num ^ 0x2FD529C5)
					{
					case 0:
						break;
					case 1:
						goto IL_005b;
					default:
						Debug.DrawLine(position - Vector3.forward * length * 0.5f, position + Vector3.forward * length * 0.5f, color, duration);
						return;
					}
					break;
					IL_005b:
					Debug.DrawLine(position - Vector3.right * length * 0.5f, position + Vector3.right * length * 0.5f, color, duration);
					num = 802499015;
				}
			}
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
			while (num < array.Length)
			{
				while (true)
				{
					int num2;
					if (array[num] == @object)
					{
						num2 = 1604956907;
					}
					else
					{
						num++;
						num2 = 1604956905;
					}
					while (true)
					{
						switch (num2 ^ 0x5FA9B2EB)
						{
						case 3:
							num2 = 1604956906;
							continue;
						case 1:
							break;
						case 0:
							return true;
						default:
							goto end_IL_0031;
						}
						break;
					}
					continue;
					end_IL_0031:
					break;
				}
			}
			return false;
		}

		public static string GetUnityInputAxisName(int unityJoystickIndex, int axisIndex)
		{
			return GetUnityInputAxisNameByJoystickId(unityJoystickIndex + 1, axisIndex);
		}

		public static string GetUnityInputAxisNameByJoystickId(int unityJoystickId, int axisIndex)
		{
			return "Joy" + unityJoystickId + "Axis" + (axisIndex + 1);
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
				int num = 1555667848;
				while (true)
				{
					switch (num ^ 0x5CB99B89)
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
					array[2] = "Button";
					array[3] = buttonIndex;
					num = 1555667849;
				}
			}
		}

		public static bool IsValidUnityJoystickName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform)
				{
					goto IL_000f;
				}
				goto IL_003a;
			}
			if (teqiHkgPdBwoBecyAZpnnqCaqgj && name.Equals(HHNDtCkHRliSQNLazSraPtjcVlI, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			int num;
			if (AaUVUHxdtdAijvOeLCQUMrRsrjC && name.IndexOf("keyboard", 0, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				num = 564712585;
				goto IL_0014;
			}
			goto IL_0081;
			IL_0081:
			return true;
			IL_0014:
			switch (num ^ 0x21A8D489)
			{
			case 3:
				break;
			case 2:
				goto IL_0031;
			case 1:
				return false;
			default:
				return false;
			}
			goto IL_000f;
			IL_000f:
			num = 564712587;
			goto IL_0014;
			IL_0031:
			if (RJQXwQECCvGkZtBjSfoAElyLJZW)
			{
				return false;
			}
			goto IL_003a;
			IL_003a:
			if (JPcznPXbrOFGwKfeYlAqSRnGYuD)
			{
				num = 564712584;
				goto IL_0014;
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
			AnimationCurve animationCurve = default(AnimationCurve);
			while (true)
			{
				int num = -1481529845;
				while (true)
				{
					switch (num ^ -1481529847)
					{
					case 0:
						break;
					case 2:
						if (keys != null)
						{
							animationCurve = new AnimationCurve(keys);
							num = -1481529848;
							continue;
						}
						goto case 3;
					case 1:
						animationCurve.postWrapMode = orig.postWrapMode;
						animationCurve.preWrapMode = orig.preWrapMode;
						num = -1481529843;
						continue;
					case 3:
						animationCurve = new AnimationCurve();
						num = -1481529848;
						continue;
					default:
						return animationCurve;
					}
					break;
				}
			}
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

		private static T kxDDoYJpzrYCHuZTeImVHNJUUAG<T>(T P_0) where T : class
		{
			if (object.ReferenceEquals(P_0, null))
			{
				return null;
			}
			T result = default(T);
			if (P_0 is UnityEngine.Object && P_0 as UnityEngine.Object == null)
			{
				while (true)
				{
					int num = -384996682;
					while (true)
					{
						switch (num ^ -384996681)
						{
						case 2:
							break;
						case 1:
							goto IL_0056;
						default:
							return result;
						}
						break;
						IL_0056:
						result = null;
						num = -384996681;
					}
				}
			}
			return P_0;
		}

		internal static ButtonStateFlags wYNpbyNhrlIKyGFXFPwpHiiOqtP(KeyCode P_0)
		{
			ButtonStateFlags buttonStateFlags = (Input.GetKey(P_0) ? ButtonStateFlags.ioEDlyORdXqorMJDekPMrPtWpCR : ButtonStateFlags.fgKYpZIlWQCcuLZlzZrhMbbdBDO);
			if (Input.GetKeyDown(P_0))
			{
				buttonStateFlags |= ButtonStateFlags.NNrFjPsrEpeNRvALiVcrQKiugjL;
				goto IL_0019;
			}
			goto IL_0037;
			IL_0037:
			int num;
			if (Input.GetKeyUp(P_0))
			{
				buttonStateFlags |= ButtonStateFlags.splhCJEXiNqkFWSDEanyDbxOmDQ;
				num = -1445083467;
				goto IL_001e;
			}
			goto IL_004a;
			IL_001e:
			switch (num ^ -1445083467)
			{
			case 2:
				break;
			case 1:
				goto IL_0037;
			default:
				goto IL_004a;
			}
			goto IL_0019;
			IL_0019:
			num = -1445083468;
			goto IL_001e;
			IL_004a:
			return buttonStateFlags;
		}

		internal static ButtonStateFlags jFcZHuafkqlzijBvuFElJkopdfY(string P_0)
		{
			if (!Input.GetButton(P_0))
			{
				goto IL_0008;
			}
			int num = 1;
			goto IL_0032;
			IL_0032:
			ButtonStateFlags buttonStateFlags = (ButtonStateFlags)num;
			int num2 = -2048298670;
			goto IL_000d;
			IL_0008:
			num2 = -2048298671;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -2048298672)
				{
				case 0:
					break;
				case 1:
					goto IL_002e;
				case 2:
					if (Input.GetButtonDown(P_0))
					{
						buttonStateFlags |= ButtonStateFlags.NNrFjPsrEpeNRvALiVcrQKiugjL;
						num2 = -2048298668;
						continue;
					}
					goto case 4;
				case 4:
					if (Input.GetButtonUp(P_0))
					{
						buttonStateFlags |= ButtonStateFlags.splhCJEXiNqkFWSDEanyDbxOmDQ;
						num2 = -2048298669;
						continue;
					}
					goto default;
				default:
					return buttonStateFlags;
				}
				break;
			}
			goto IL_0008;
			IL_002e:
			num = 0;
			goto IL_0032;
		}
	}
}
