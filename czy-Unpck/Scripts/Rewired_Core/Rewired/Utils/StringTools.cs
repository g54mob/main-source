using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Rewired.Utils
{
	public static class StringTools
	{
		private static string VcpuibIfADSEzvDtDqQfgWpouJh;

		public static string ToString(int[] inArray)
		{
			string text = "";
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < inArray.Length)
				{
					num2 = -435123022;
					num3 = num2;
				}
				else
				{
					num2 = -435123018;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -435123018)
					{
					case 5:
						num2 = -435123022;
						continue;
					case 4:
						text += inArray[num];
						num2 = -435123020;
						continue;
					case 2:
						if (num < inArray.Length - 1)
						{
							text += ", ";
							num2 = -435123019;
							continue;
						}
						goto case 3;
					case 3:
						num++;
						num2 = -435123017;
						continue;
					case 1:
						break;
					default:
						return text;
					}
					break;
				}
			}
		}

		public static string ToString(float[] inArray)
		{
			string text = "";
			int num = 0;
			while (true)
			{
				int num2 = 1662629005;
				while (true)
				{
					switch (num2 ^ 0x6319B48C)
					{
					case 4:
						break;
					case 1:
						num2 = 1662629007;
						continue;
					case 2:
						num++;
						num2 = 1662629007;
						continue;
					case 0:
						text += inArray[num];
						if (num < inArray.Length - 1)
						{
							text += ", ";
							num2 = 1662629006;
							continue;
						}
						goto case 2;
					default:
						if (num >= inArray.Length)
						{
							return text;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public static string ToString(string[] inArray)
		{
			string text = "";
			int num2 = default(int);
			while (true)
			{
				int num = 2108856750;
				while (true)
				{
					switch (num ^ 0x7DB299AA)
					{
					case 5:
						break;
					case 4:
						num2 = 0;
						num = 2108856746;
						continue;
					case 2:
						text += inArray[num2];
						num = 2108856747;
						continue;
					case 3:
						num2++;
						num = 2108856746;
						continue;
					case 1:
						if (num2 < inArray.Length - 1)
						{
							text += ", ";
							num = 2108856745;
							continue;
						}
						goto case 3;
					default:
						if (num2 >= inArray.Length)
						{
							return text;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public static string ToString(bool[] inArray)
		{
			string text = "";
			int num = 0;
			while (num < inArray.Length)
			{
				while (true)
				{
					text += inArray[num];
					int num2;
					int num3;
					if (num >= inArray.Length - 1)
					{
						num2 = -888679360;
						num3 = num2;
					}
					else
					{
						num2 = -888679355;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -888679356)
						{
						case 0:
							num2 = -888679353;
							continue;
						case 3:
							break;
						case 1:
							text += ", ";
							num2 = -888679360;
							continue;
						case 4:
							num++;
							num2 = -888679354;
							continue;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return text;
		}

		public static string ToString(byte[] inArray)
		{
			string text = "";
			int num = 0;
			while (num < inArray.Length)
			{
				while (true)
				{
					text += inArray[num];
					int num2;
					int num3;
					if (num < inArray.Length - 1)
					{
						num2 = -176065888;
						num3 = num2;
					}
					else
					{
						num2 = -176065881;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -176065885)
						{
						case 0:
							num2 = -176065887;
							continue;
						case 2:
							break;
						case 3:
							text += ", ";
							num2 = -176065881;
							continue;
						case 4:
							num++;
							num2 = -176065886;
							continue;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return text;
		}

		public static string ToString(byte[] inArray, string stringOptions, int maxItemsPerLine = 0)
		{
			string text = "";
			int num2 = default(int);
			while (true)
			{
				int num = 133557665;
				while (true)
				{
					switch (num ^ 0x7F5EDA5)
					{
					case 0:
						break;
					case 6:
						if (num2 < inArray.Length - 1)
						{
							text += ", ";
							num = 133557670;
							continue;
						}
						goto case 3;
					case 1:
						num = 133557670;
						continue;
					case 7:
						text += ", ";
						num = 133557668;
						continue;
					case 5:
					{
						int num3;
						if (num2 < inArray.Length - 1)
						{
							num = 133557666;
							num3 = num;
						}
						else
						{
							num = 133557670;
							num3 = num;
						}
						continue;
					}
					case 3:
						num2++;
						num = 133557677;
						continue;
					case 4:
						num2 = 0;
						num = 133557677;
						continue;
					case 2:
						text += inArray[num2].ToString(stringOptions);
						if (maxItemsPerLine <= 0)
						{
							goto case 6;
						}
						if ((num2 + 1) % maxItemsPerLine == 0)
						{
							text += "\n";
							num = 133557670;
							continue;
						}
						goto case 5;
					default:
						if (num2 >= inArray.Length)
						{
							return text;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public static string ToString(Vector3[] inArray)
		{
			string text = "";
			int num = 0;
			while (true)
			{
				int num2 = 1948595874;
				while (true)
				{
					switch (num2 ^ 0x742536A6)
					{
					case 5:
						break;
					case 3:
						num++;
						num2 = 1948595878;
						continue;
					case 1:
						if (num < inArray.Length - 1)
						{
							text += ", ";
							num2 = 1948595877;
							continue;
						}
						goto case 3;
					case 2:
						text += inArray[num];
						num2 = 1948595879;
						continue;
					case 4:
						num2 = 1948595878;
						continue;
					default:
						if (num >= inArray.Length)
						{
							return text;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public static string ToString(List<object> list)
		{
			string text = "";
			int num = 0;
			while (num < list.Count)
			{
				while (true)
				{
					text += list[num];
					int num2 = 1195915930;
					while (true)
					{
						switch (num2 ^ 0x47483A9E)
						{
						case 0:
							num2 = 1195915935;
							continue;
						case 1:
							break;
						case 4:
							if (num < list.Count - 1)
							{
								text += ", ";
								num2 = 1195915932;
								continue;
							}
							goto case 2;
						case 2:
							num++;
							num2 = 1195915933;
							continue;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return text;
		}

		public static string ToString(Vector2 v)
		{
			return v.x + ", " + v.y;
		}

		public static string ToString(Vector3 v)
		{
			return v.x + ", " + v.y + ", " + v.z;
		}

		public static string ToString<T>(T[] inArray)
		{
			string text = "";
			int num = inArray.Length - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = 1224540650;
				while (true)
				{
					switch (num3 ^ 0x48FD01EB)
					{
					case 5:
						break;
					case 1:
						num3 = 1224540651;
						continue;
					case 4:
						num2++;
						num3 = 1224540651;
						continue;
					case 2:
						if (num2 < num)
						{
							text += ", ";
							num3 = 1224540655;
							continue;
						}
						goto case 4;
					case 0:
					{
						int num4;
						if (num2 < inArray.Length)
						{
							num3 = 1224540653;
							num4 = num3;
						}
						else
						{
							num3 = 1224540648;
							num4 = num3;
						}
						continue;
					}
					case 6:
						text += inArray[num2].ToString();
						num3 = 1224540649;
						continue;
					default:
						return text;
					}
					break;
				}
			}
		}

		public static string ToString<T>(List<T> inList)
		{
			string text = "";
			int num = inList.Count - 1;
			int num2 = 0;
			while (num2 < inList.Count)
			{
				while (true)
				{
					text += inList[num2].ToString();
					int num3;
					if (num2 < num)
					{
						text += ", ";
						num3 = -2027302786;
						goto IL_0018;
					}
					goto IL_0068;
					IL_0018:
					while (true)
					{
						switch (num3 ^ -2027302785)
						{
						case 3:
							num3 = -2027302787;
							continue;
						case 2:
							break;
						case 1:
							goto IL_0068;
						default:
							goto end_IL_0035;
						}
						break;
					}
					continue;
					IL_0068:
					num2++;
					num3 = -2027302785;
					goto IL_0018;
					continue;
					end_IL_0035:
					break;
				}
			}
			return text;
		}

		public static string[] Split(string str, string delimiter)
		{
			if (str == null)
			{
				goto IL_0003;
			}
			char[] array = new char[1];
			int num = 642622099;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ 0x264DA292)
				{
				case 0:
					break;
				case 3:
					return null;
				case 1:
					goto IL_0035;
				default:
					return str.Split(array);
				}
				break;
				IL_0035:
				array[0] = delimiter[0];
				num = 642622096;
			}
			goto IL_0003;
			IL_0003:
			num = 642622097;
			goto IL_0008;
		}

		public static string[] SplitAndTrim(string str, string delimiter)
		{
			if (str == null)
			{
				return null;
			}
			string[] array = Split(str, delimiter);
			int num = 0;
			while (num < array.Length)
			{
				while (true)
				{
					string text = array[num];
					array[num] = text.Trim();
					num++;
					int num2 = -1694578698;
					while (true)
					{
						switch (num2 ^ -1694578698)
						{
						case 2:
							num2 = -1694578697;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002f;
						}
						break;
					}
					continue;
					end_IL_002f:
					break;
				}
			}
			return array;
		}

		public static string DecodeNewlines(string s)
		{
			return s.Replace("\\r\\n", "\n");
		}

		public static string EncodeNewlines(string s)
		{
			return s.Replace("\n", "\\r\\n");
		}

		public static string ArrayToText(string[] sA)
		{
			string text = "";
			int num = 0;
			while (num < sA.Length)
			{
				while (true)
				{
					string text2 = sA[num];
					int num2;
					if (num != 0)
					{
						text += "\n";
						num2 = -282519202;
						goto IL_000f;
					}
					goto IL_0046;
					IL_000f:
					while (true)
					{
						switch (num2 ^ -282519201)
						{
						case 0:
							num2 = -282519203;
							continue;
						case 2:
							break;
						case 1:
							goto IL_0046;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					IL_0046:
					text += text2;
					num++;
					num2 = -282519204;
					goto IL_000f;
					continue;
					end_IL_002c:
					break;
				}
			}
			return text;
		}

		public static string[] TextToArray(string s)
		{
			return s.Split("\n"[0]);
		}

		public static string StringToString(string s)
		{
			if (s == null)
			{
				return "";
			}
			return s;
		}

		public static int StringToInt(string s)
		{
			int.TryParse(s, out var result);
			return result;
		}

		public static float StringToFloat(string s)
		{
			float.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var result);
			return result;
		}

		public static bool StringToBoolean(string s)
		{
			bool.TryParse(s, out var result);
			return result;
		}

		public static KeyCode StringToKeyCode(string s)
		{
			return (KeyCode)Enum.Parse(typeof(KeyCode), s);
		}

		public static Enum StringToEnum(string str, Type type)
		{
			return (Enum)Enum.Parse(type, str);
		}

		public static string ToStringWithCount(string s)
		{
			if (!(s == ""))
			{
				while (true)
				{
					int num = -254145901;
					while (true)
					{
						switch (num ^ -254145902)
						{
						case 3:
							break;
						case 1:
							goto IL_002f;
						case 2:
							goto end_IL_000d;
						default:
							goto IL_0074;
						}
						break;
						IL_002f:
						if (s == null)
						{
							num = -254145904;
							continue;
						}
						s = s.Replace("|"[0], ""[0]);
						if (!(s == ""))
						{
							if (s == null)
							{
								num = -254145902;
								continue;
							}
							s = s.Length + "|" + s;
							return s;
						}
						goto IL_0074;
						IL_0074:
						return "0|";
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			return "0|";
		}

		public static char[] StringToCharArray(string s)
		{
			return s?.ToCharArray();
		}

		public static string CharArrayToString(char[] c)
		{
			if (c == null)
			{
				return null;
			}
			return new string(c);
		}

		public static string CSVEncode(string s)
		{
			if (s != null)
			{
				while (true)
				{
					int num = 1182647655;
					while (true)
					{
						switch (num ^ 0x467DC566)
						{
						case 3:
							break;
						case 1:
							goto IL_0025;
						case 0:
							goto end_IL_0003;
						default:
							return s + ",";
						}
						break;
						IL_0025:
						if (s == "")
						{
							num = 1182647654;
							continue;
						}
						s = s.Replace("\\", "\\\\");
						s = s.Replace(",", "\\,");
						num = 1182647652;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			return ",";
		}

		public static string CSVDecode(string s)
		{
			if (s != null)
			{
				string text = default(string);
				bool flag = default(bool);
				char c = default(char);
				int num2 = default(int);
				bool flag2 = default(bool);
				char c2 = default(char);
				while (true)
				{
					int num = 346449177;
					while (true)
					{
						switch (num ^ 0x14A6651F)
						{
						case 10:
							break;
						case 6:
							goto IL_006b;
						case 15:
							text = text.Substring(0, text.Length - 1);
							num = 346449167;
							continue;
						case 11:
							text = "";
							num = 346449178;
							continue;
						case 3:
							flag = false;
							num = 346449179;
							continue;
						case 7:
							c = "\\"[0];
							num = 346449166;
							continue;
						case 14:
							goto IL_00d2;
						case 5:
							num2 = 0;
							num = 346449165;
							continue;
						case 0:
							flag2 = true;
							flag = false;
							num = 346449179;
							continue;
						case 17:
							flag = false;
							flag2 = false;
							num = 346449172;
							continue;
						case 19:
							flag = !flag;
							num = 346449170;
							continue;
						case 1:
							goto end_IL_0006;
						case 4:
							goto IL_013d;
						case 13:
							num = 346449179;
							continue;
						case 9:
							if (flag)
							{
								flag2 = true;
								num = 346449164;
								continue;
							}
							goto case 19;
						case 8:
							goto IL_016d;
						case 12:
							num2++;
							num = 346449165;
							continue;
						case 16:
							text += s[num2];
							num = 346449171;
							continue;
						case 2:
							goto IL_01be;
						default:
							if (num2 >= s.Length)
							{
								return text;
							}
							goto IL_016d;
						}
						break;
						IL_01be:
						int num3;
						if (s[num2] == c2)
						{
							num = 346449169;
							num3 = num;
						}
						else
						{
							num = 346449180;
							num3 = num;
						}
						continue;
						IL_006b:
						if (s == "")
						{
							num = 346449182;
							continue;
						}
						c2 = ","[0];
						num = 346449176;
						continue;
						IL_013d:
						int num4;
						if (!flag2)
						{
							num = 346449167;
							num4 = num;
						}
						else
						{
							num = 346449168;
							num4 = num;
						}
						continue;
						IL_016d:
						flag2 = false;
						int num5;
						if (s[num2] != c)
						{
							num = 346449181;
							num5 = num;
						}
						else
						{
							num = 346449174;
							num5 = num;
						}
						continue;
						IL_00d2:
						int num6;
						if (flag)
						{
							num = 346449183;
							num6 = num;
						}
						else
						{
							num = 346449180;
							num6 = num;
						}
					}
					continue;
					end_IL_0006:
					break;
				}
			}
			return "";
		}

		public static string[] CSVToArray(string s)
		{
			if (s != null)
			{
				int num3 = default(int);
				string[] array = default(string[]);
				List<object> list = default(List<object>);
				int num2 = default(int);
				bool flag2 = default(bool);
				bool flag = default(bool);
				string text = default(string);
				char c2 = default(char);
				char c = default(char);
				while (true)
				{
					int num = -188693315;
					while (true)
					{
						switch (num ^ -188693319)
						{
						case 16:
							break;
						case 2:
							if (num3 >= s.Length)
							{
								array = new string[list.Count];
								num2 = 0;
								num = -188693333;
								continue;
							}
							goto IL_0103;
						case 18:
							goto IL_008b;
						case 14:
							flag2 = false;
							num3 = 0;
							num = -188693317;
							continue;
						case 11:
							num2++;
							num = -188693333;
							continue;
						case 1:
							text = "";
							flag = false;
							num = -188693321;
							continue;
						case 6:
							flag = false;
							num = -188693325;
							continue;
						case 4:
							goto IL_00e9;
						case 7:
							goto IL_0103;
						case 0:
							text = CSVDecode(text);
							list.Add(text);
							text = "";
							flag2 = false;
							num = -188693323;
							continue;
						case 3:
							c2 = "\\"[0];
							list = new List<object>();
							num = -188693320;
							continue;
						case 15:
							flag = !flag;
							num = -188693325;
							continue;
						case 12:
							num3++;
							num = -188693317;
							continue;
						case 9:
							if (s[num3] == c && !flag)
							{
								flag2 = true;
								num = -188693313;
								continue;
							}
							goto case 6;
						case 8:
							text += s[num3];
							num = -188693323;
							continue;
						case 5:
							array[num2] = (string)list[num2];
							num = -188693326;
							continue;
						case 10:
							goto IL_01dc;
						case 17:
							goto end_IL_0006;
						default:
							return array;
						}
						break;
						IL_01dc:
						int num4;
						if (!flag2)
						{
							num = -188693327;
							num4 = num;
						}
						else
						{
							num = -188693319;
							num4 = num;
						}
						continue;
						IL_008b:
						int num5;
						if (num2 >= list.Count)
						{
							num = -188693324;
							num5 = num;
						}
						else
						{
							num = -188693316;
							num5 = num;
						}
						continue;
						IL_0103:
						int num6;
						if (s[num3] != c2)
						{
							num = -188693328;
							num6 = num;
						}
						else
						{
							num = -188693322;
							num6 = num;
						}
						continue;
						IL_00e9:
						if (s == "")
						{
							num = -188693336;
							continue;
						}
						c = ","[0];
						num = -188693318;
					}
					continue;
					end_IL_0006:
					break;
				}
			}
			return null;
		}

		public static bool TryParseEnum<TEnum>(string value, out TEnum enumeration)
		{
			enumeration = default(TEnum);
			if (string.IsNullOrEmpty(value))
			{
				return false;
			}
			Type typeFromHandle = typeof(TEnum);
			try
			{
				enumeration = (TEnum)Enum.Parse(typeFromHandle, value, ignoreCase: true);
			}
			catch (ArgumentException)
			{
				return false;
			}
			return true;
		}

		public static string TimeToString(int seconds)
		{
			return TimeToString((float)seconds);
		}

		public static string TimeToString(float seconds)
		{
			if (seconds == 0f)
			{
				goto IL_000b;
			}
			float num = MathTools.Abs(seconds);
			int num2 = MathTools.FloorToInt(num / 3600f);
			num -= (float)(num2 * 3600);
			int num3 = -2010226298;
			goto IL_0010;
			IL_0010:
			string text = default(string);
			float num5 = default(float);
			int num4 = default(int);
			while (true)
			{
				switch (num3 ^ -2010226301)
				{
				case 0:
					break;
				case 6:
					text = "";
					if (num2 > 0)
					{
						text = text + num2 + " h";
						num3 = -2010226302;
						continue;
					}
					goto case 1;
				case 8:
					text = text + num5 + " s";
					num3 = -2010226304;
					continue;
				case 7:
					return seconds + " seconds";
				case 4:
					if (num5 > 0f)
					{
						int num6;
						if (text != "")
						{
							num3 = -2010226294;
							num6 = num3;
						}
						else
						{
							num3 = -2010226293;
							num6 = num3;
						}
						continue;
					}
					goto default;
				case 5:
					num4 = MathTools.FloorToInt(num / 60f);
					num -= (float)(num4 * 60);
					num5 = num;
					num3 = -2010226299;
					continue;
				case 2:
					text = text + num4 + " m";
					num3 = -2010226297;
					continue;
				case 1:
					if (num4 <= 0)
					{
						goto case 4;
					}
					if (text != "")
					{
						text += ", ";
						num3 = -2010226303;
						continue;
					}
					goto case 2;
				case 9:
					text += ", ";
					num3 = -2010226293;
					continue;
				default:
					return text;
				}
				break;
			}
			goto IL_000b;
			IL_000b:
			num3 = -2010226300;
			goto IL_0010;
		}

		static StringTools()
		{
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			VcpuibIfADSEzvDtDqQfgWpouJh = Regex.Escape(new string(invalidFileNameChars));
		}

		public static string CleanUpFileName(string name)
		{
			name = name.Trim();
			string pattern = "[ ~`,:;'\\.\\$\\^\\{\\}\\[\\]\\(\\|\\)\\*\\+\\?\\\\" + VcpuibIfADSEzvDtDqQfgWpouJh + "]";
			name = Regex.Replace(name, pattern, "_");
			return name;
		}

		public static string StripTrailingNumbers(string name)
		{
			int number;
			return StripTrailingNumbers(name, out number);
		}

		public static string StripTrailingNumbers(string name, out int number)
		{
			Match match = Regex.Match(name, "[0-9]+$");
			if (!match.Success)
			{
				number = -1;
				goto IL_0017;
			}
			if (!int.TryParse(match.Value, out number))
			{
				throw new Exception("Could not parse string to Int32! " + match.Value);
			}
			goto IL_006a;
			IL_001c:
			int num;
			int index = default(int);
			while (true)
			{
				switch (num ^ 0x4C2B5072)
				{
				case 0:
					break;
				case 3:
					return name;
				case 4:
					goto IL_006a;
				case 2:
					goto IL_0078;
				default:
					return "";
				}
				break;
				IL_0078:
				if (index == 0)
				{
					num = 1277907059;
					continue;
				}
				return name.Substring(0, index);
			}
			goto IL_0017;
			IL_006a:
			index = match.Index;
			num = 1277907056;
			goto IL_001c;
			IL_0017:
			num = 1277907057;
			goto IL_001c;
		}

		public static string VerifyName(string name, int indexInNameList, string[] names, bool cleanUpIllegalFileChars)
		{
			return VerifyName(name, indexInNameList, names, cleanUpIllegalFileChars, allowBlank: false);
		}

		public static string VerifyName(string name, int indexInNameList, string[] names, bool cleanUpIllegalFileChars, bool allowBlank)
		{
			if (cleanUpIllegalFileChars)
			{
				goto IL_0003;
			}
			goto IL_0061;
			IL_0003:
			int num = -155304451;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -155304452)
				{
				case 0:
					break;
				case 1:
					name = CleanUpFileName(name);
					num = -155304449;
					continue;
				case 3:
					goto IL_0047;
				case 7:
					goto IL_0061;
				case 6:
					goto IL_0073;
				case 4:
					goto IL_0086;
				case 2:
					return name;
				default:
					if (num2 >= num3)
					{
						return name;
					}
					goto IL_0086;
				}
				break;
				IL_0086:
				if (num2 != indexInNameList && names[num2] != null && name.Equals(names[num2], StringComparison.OrdinalIgnoreCase))
				{
					return IterateName(name, indexInNameList, names);
				}
				num2++;
				num = -155304455;
			}
			goto IL_0003;
			IL_0047:
			if (!allowBlank && string.IsNullOrEmpty(name))
			{
				name = "0";
				num = -155304454;
				goto IL_0008;
			}
			goto IL_0073;
			IL_0073:
			if (allowBlank && string.IsNullOrEmpty(name))
			{
				num = -155304450;
			}
			else
			{
				num3 = ((names != null) ? names.Length : 0);
				if (num3 == 0)
				{
					return name;
				}
				num2 = 0;
				num = -155304455;
			}
			goto IL_0008;
			IL_0061:
			if (name != null)
			{
				name = name.Trim();
				num = -155304449;
				goto IL_0008;
			}
			goto IL_0047;
		}

		public static string IterateName(string name, int indexInNameList = -1, string[] names = null)
		{
			int number;
			string text = StripTrailingNumbers(name, out number);
			int num3 = default(int);
			int num2 = default(int);
			string text2 = default(string);
			int number2 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num = -942005568;
				while (true)
				{
					switch (num ^ -942005567)
					{
					case 2:
						break;
					case 1:
						if (names != null)
						{
							num4 = -1;
							num3 = names.Length;
							num = -942005564;
							continue;
						}
						return text + (number + 1);
					case 5:
						num2 = 0;
						num = -942005561;
						continue;
					case 8:
					{
						text2 = StripTrailingNumbers(text2, out number2);
						int num5;
						if (!text.Equals(text2, StringComparison.OrdinalIgnoreCase))
						{
							num = -942005566;
							num5 = num;
						}
						else
						{
							num = -942005562;
							num5 = num;
						}
						continue;
					}
					case 0:
						if (num2 != indexInNameList && names[num2] != null)
						{
							text2 = names[num2];
							num = -942005559;
							continue;
						}
						goto case 3;
					case 7:
						if (number2 > num4)
						{
							num4 = number2;
							num = -942005566;
							continue;
						}
						goto case 3;
					case 3:
						num2++;
						num = -942005563;
						continue;
					case 6:
						num = -942005563;
						continue;
					default:
						if (num2 >= num3)
						{
							num4++;
							return text + num4;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public static string ToString(Rect rect)
		{
			return $"{rect.x}, {rect.y}, {rect.width}, {rect.height}";
		}

		public static Guid ToGuid(string guid)
		{
			try
			{
				return new Guid(guid);
			}
			catch
			{
				return Guid.Empty;
			}
		}

		public static byte[] GetBytes(string str)
		{
			byte[] array = new byte[str.Length * 2];
			Buffer.BlockCopy(str.ToCharArray(), 0, array, 0, array.Length);
			return array;
		}

		public static string GetString(byte[] bytes)
		{
			char[] array = new char[bytes.Length / 2];
			Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
			return new string(array);
		}

		public static string ByteShiftEncode(string source, short shift)
		{
			int num = default(int);
			int num2 = default(int);
			char[] array = default(char[]);
			int num3 = default(int);
			int num4;
			if (source != null)
			{
				if (source == string.Empty)
				{
					goto IL_0016;
				}
				num = Convert.ToInt32('\uffff');
				num2 = Convert.ToInt32('\0');
				array = source.ToCharArray();
				num3 = 0;
				num4 = -724137135;
				goto IL_001b;
			}
			goto IL_00a9;
			IL_001b:
			int num5 = default(int);
			while (true)
			{
				switch (num4 ^ -724137136)
				{
				case 0:
					break;
				case 4:
					array[num3] = Convert.ToChar(num5);
					num3++;
					num4 = -724137135;
					continue;
				case 5:
					num4 = -724137132;
					continue;
				case 2:
					if (num5 > num)
					{
						num5 -= num;
						num4 = -724137131;
						continue;
					}
					goto case 3;
				case 1:
					goto IL_007d;
				case 3:
					if (num5 < num2)
					{
						num5 += num;
						num4 = -724137132;
						continue;
					}
					goto case 4;
				case 6:
					goto IL_00a9;
				case 7:
					num5 = Convert.ToInt32(array[num3]) + shift;
					num4 = -724137134;
					continue;
				default:
					return new string(array);
				}
				break;
				IL_007d:
				int num6;
				if (num3 < array.Length)
				{
					num4 = -724137129;
					num6 = num4;
				}
				else
				{
					num4 = -724137128;
					num6 = num4;
				}
			}
			goto IL_0016;
			IL_00a9:
			return string.Empty;
			IL_0016:
			num4 = -724137130;
			goto IL_001b;
		}

		public static string GetNullTerminatedUnicodeString(byte[] bytes)
		{
			int num = default(int);
			int num2 = default(int);
			int num3;
			if (bytes != null)
			{
				if (bytes.Length < 3)
				{
					goto IL_0009;
				}
				num = -1;
				num2 = 0;
				num3 = 211391817;
				goto IL_000e;
			}
			goto IL_0078;
			IL_000e:
			int count = default(int);
			while (true)
			{
				switch (num3 ^ 0xC99954C)
				{
				case 4:
					break;
				case 8:
					goto IL_003f;
				case 2:
					goto IL_0056;
				case 5:
					num3 = 211391812;
					continue;
				case 7:
					if (bytes[num2] == 0)
					{
						num = num2 - 1;
						num3 = 211391822;
						continue;
					}
					goto case 3;
				case 1:
					goto IL_0078;
				case 0:
					return string.Empty;
				case 3:
					num2 += 2;
					num3 = 211391812;
					continue;
				default:
					return Encoding.Unicode.GetString(bytes, 0, count);
				}
				break;
				IL_0056:
				if (num < 0)
				{
					num3 = 211391820;
					continue;
				}
				count = num + 1;
				num3 = 211391818;
				continue;
				IL_003f:
				int num4;
				if (num2 < bytes.Length)
				{
					num3 = 211391819;
					num4 = num3;
				}
				else
				{
					num3 = 211391822;
					num4 = num3;
				}
			}
			goto IL_0009;
			IL_0078:
			return string.Empty;
			IL_0009:
			num3 = 211391821;
			goto IL_000e;
		}

		public static string SanitizeDeviceString(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			try
			{
				string pattern = "[\\x1A]";
				return Regex.Replace(text, pattern, "");
			}
			catch
			{
				return string.Empty;
			}
		}

		public static string ReplaceChar(string @string, int index, char replacement)
		{
			if (string.IsNullOrEmpty(@string))
			{
				return @string;
			}
			if (index >= @string.Length)
			{
				return @string;
			}
			if (index < 0)
			{
				return @string;
			}
			char[] array = @string.ToCharArray();
			array[index] = replacement;
			return new string(array);
		}

		public static string AddSpacesToSentence(string text, bool preserveAcronyms)
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(text.Length * 2);
			stringBuilder.Append(text[0]);
			int num2 = default(int);
			while (true)
			{
				int num = 1197595102;
				while (true)
				{
					switch (num ^ 0x4761D9DA)
					{
					case 0:
						break;
					case 1:
						stringBuilder.Append(' ');
						num = 1197595100;
						continue;
					case 6:
						stringBuilder.Append(text[num2]);
						num2++;
						num = 1197595096;
						continue;
					case 7:
						if (num2 < text.Length - 1)
						{
							int num5;
							if (char.IsUpper(text[num2 + 1]))
							{
								num = 1197595100;
								num5 = num;
							}
							else
							{
								num = 1197595099;
								num5 = num;
							}
							continue;
						}
						goto case 6;
					case 4:
						num2 = 1;
						num = 1197595096;
						continue;
					case 5:
						if (preserveAcronyms)
						{
							int num3;
							if (char.IsUpper(text[num2 - 1]))
							{
								num = 1197595101;
								num3 = num;
							}
							else
							{
								num = 1197595100;
								num3 = num;
							}
							continue;
						}
						goto case 6;
					case 3:
						if (!char.IsUpper(text[num2]))
						{
							goto case 6;
						}
						if (text[num2 - 1] != ' ')
						{
							int num4;
							if (!char.IsUpper(text[num2 - 1]))
							{
								num = 1197595099;
								num4 = num;
							}
							else
							{
								num = 1197595103;
								num4 = num;
							}
							continue;
						}
						goto case 5;
					default:
						if (num2 >= text.Length)
						{
							return stringBuilder.ToString();
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public static string WriteVar(string name, object value)
		{
			return WriteVar(name, value, '=');
		}

		public static string WriteVar(string name, object value, char delimiter)
		{
			object[] array = new object[6];
			while (true)
			{
				int num = 141912073;
				while (true)
				{
					switch (num ^ 0x8756808)
					{
					case 2:
						break;
					case 1:
						goto IL_0025;
					default:
						array[4] = ((value != null) ? value.ToString() : "NULL");
						array[5] = "\n";
						return string.Concat(array);
					}
					break;
					IL_0025:
					array[0] = name;
					array[1] = " ";
					array[2] = delimiter;
					array[3] = " ";
					num = 141912072;
				}
			}
		}

		public static void WriteVar(StringBuilder sb, string name, object value)
		{
			WriteVar(sb, name, value, '=');
		}

		public static void WriteVar(StringBuilder sb, string name, object value, char delimiter)
		{
			sb.Append(name);
			sb.Append(" ");
			sb.Append(delimiter);
			sb.Append(" ");
			sb.Append((value != null) ? value.ToString() : ((value is string) ? string.Empty : "NULL"));
			sb.Append("\n");
		}

		public static string Trim(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return str;
			}
			return str.Trim();
		}

		public static string VariableNameToDisplayName(string fieldName)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				return fieldName;
			}
			fieldName = Regex.Replace(fieldName, "[^a-zA-Z0-9_]", "");
			fieldName = Regex.Replace(fieldName, "[_]{2,}", "_");
			if (fieldName.StartsWith("m_") && fieldName.Length > 2)
			{
				goto IL_004a;
			}
			goto IL_00ee;
			IL_004f:
			int num;
			MatchCollection matchCollection = default(MatchCollection);
			int num2 = default(int);
			char[] array = default(char[]);
			while (true)
			{
				switch (num ^ 0x4CC23D5B)
				{
				case 5:
					break;
				case 2:
					goto IL_007b;
				case 6:
				{
					int index = matchCollection[num2].Index;
					array[index] = array[index].ToString().ToUpper()[0];
					num2++;
					num = 1287798105;
					continue;
				}
				case 0:
					fieldName = fieldName.Trim();
					matchCollection = Regex.Matches(fieldName, "\\b([a-z])");
					array = fieldName.ToCharArray();
					num2 = 0;
					num = 1287798105;
					continue;
				case 3:
					goto IL_00ee;
				case 4:
					fieldName = fieldName.Substring(2);
					num = 1287798104;
					continue;
				default:
					fieldName = AddSpacesToSentence(new string(array), preserveAcronyms: false);
					return Regex.Replace(fieldName, "([a-zA-Z_]+)([0-9]+)", "$1 $2");
				}
				break;
				IL_007b:
				int num3;
				if (num2 >= matchCollection.Count)
				{
					num = 1287798106;
					num3 = num;
				}
				else
				{
					num = 1287798109;
					num3 = num;
				}
			}
			goto IL_004a;
			IL_00ee:
			fieldName = Regex.Replace(fieldName, "[_]", " ");
			num = 1287798107;
			goto IL_004f;
			IL_004a:
			num = 1287798111;
			goto IL_004f;
		}

		public static int CountChars(string text, char character)
		{
			if (string.IsNullOrEmpty(text))
			{
				return 0;
			}
			int num = 0;
			int num3 = default(int);
			while (true)
			{
				int num2 = -1083662384;
				while (true)
				{
					switch (num2 ^ -1083662381)
					{
					case 0:
						break;
					case 3:
						num3 = 0;
						num2 = -1083662382;
						continue;
					case 2:
						if (text[num3] == character)
						{
							num++;
							num2 = -1083662377;
							continue;
						}
						goto case 4;
					case 4:
						num3++;
						num2 = -1083662382;
						continue;
					default:
						if (num3 >= text.Length)
						{
							return num;
						}
						goto case 2;
					}
					break;
				}
			}
		}
	}
}
