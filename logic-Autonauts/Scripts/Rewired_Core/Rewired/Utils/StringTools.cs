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
		private static string kydCLwsDjJSXgULQOibcmxRvpQW;

		public static string ToString(int[] inArray)
		{
			string text = "";
			int num = 0;
			while (num < inArray.Length)
			{
				while (true)
				{
					text += inArray[num];
					int num2;
					if (num < inArray.Length - 1)
					{
						text += ", ";
						num2 = -1111027962;
						goto IL_000f;
					}
					goto IL_0056;
					IL_000f:
					while (true)
					{
						switch (num2 ^ -1111027964)
						{
						case 0:
							num2 = -1111027963;
							continue;
						case 1:
							break;
						case 2:
							goto IL_0056;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					IL_0056:
					num++;
					num2 = -1111027961;
					goto IL_000f;
					continue;
					end_IL_002c:
					break;
				}
			}
			return text;
		}

		public static string ToString(float[] inArray)
		{
			string text = "";
			int num2 = default(int);
			while (true)
			{
				int num = 687894470;
				while (true)
				{
					switch (num ^ 0x29006FC7)
					{
					case 0:
						break;
					case 6:
					{
						int num4;
						if (num2 >= inArray.Length - 1)
						{
							num = 687894467;
							num4 = num;
						}
						else
						{
							num = 687894479;
							num4 = num;
						}
						continue;
					}
					case 7:
						text += inArray[num2];
						num = 687894465;
						continue;
					case 2:
					{
						int num3;
						if (num2 >= inArray.Length)
						{
							num = 687894468;
							num3 = num;
						}
						else
						{
							num = 687894464;
							num3 = num;
						}
						continue;
					}
					case 1:
						num2 = 0;
						num = 687894466;
						continue;
					case 8:
						text += ", ";
						num = 687894467;
						continue;
					case 5:
						num = 687894469;
						continue;
					case 4:
						num2++;
						num = 687894469;
						continue;
					default:
						return text;
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
				int num = 800386032;
				while (true)
				{
					switch (num ^ 0x2FB4EBF6)
					{
					case 2:
						break;
					case 3:
					{
						int num4;
						if (num2 < inArray.Length)
						{
							num = 800386033;
							num4 = num;
						}
						else
						{
							num = 800386039;
							num4 = num;
						}
						continue;
					}
					case 0:
						text += ", ";
						num = 800386034;
						continue;
					case 6:
						num2 = 0;
						num = 800386035;
						continue;
					case 5:
						num = 800386037;
						continue;
					case 7:
					{
						text += inArray[num2];
						int num3;
						if (num2 < inArray.Length - 1)
						{
							num = 800386038;
							num3 = num;
						}
						else
						{
							num = 800386034;
							num3 = num;
						}
						continue;
					}
					case 4:
						num2++;
						num = 800386037;
						continue;
					default:
						return text;
					}
					break;
				}
			}
		}

		public static string ToString(bool[] inArray)
		{
			string text = "";
			int num = 0;
			while (true)
			{
				int num2 = 911877139;
				while (true)
				{
					switch (num2 ^ 0x365A2412)
					{
					case 3:
						break;
					case 1:
						num2 = 911877136;
						continue;
					case 4:
						text += inArray[num];
						if (num < inArray.Length - 1)
						{
							text += ", ";
							num2 = 911877138;
							continue;
						}
						goto case 0;
					case 0:
						num++;
						num2 = 911877136;
						continue;
					default:
						if (num >= inArray.Length)
						{
							return text;
						}
						goto case 4;
					}
					break;
				}
			}
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
					if (num < inArray.Length - 1)
					{
						text += ", ";
						num2 = -194502265;
						goto IL_000f;
					}
					goto IL_0056;
					IL_000f:
					while (true)
					{
						switch (num2 ^ -194502266)
						{
						case 0:
							num2 = -194502268;
							continue;
						case 2:
							break;
						case 1:
							goto IL_0056;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					IL_0056:
					num++;
					num2 = -194502267;
					goto IL_000f;
					continue;
					end_IL_002c:
					break;
				}
			}
			return text;
		}

		public static string ToString(byte[] inArray, string stringOptions, int maxItemsPerLine = 0)
		{
			string text = "";
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= inArray.Length)
				{
					num2 = 1443263239;
					num3 = num2;
				}
				else
				{
					num2 = 1443263235;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x56067300)
					{
					case 4:
						num2 = 1443263235;
						continue;
					case 2:
					{
						int num5;
						if (num >= inArray.Length - 1)
						{
							num2 = 1443263232;
							num5 = num2;
						}
						else
						{
							num2 = 1443263240;
							num5 = num2;
						}
						continue;
					}
					case 8:
						text += ", ";
						num2 = 1443263232;
						continue;
					case 3:
					{
						text += inArray[num].ToString(stringOptions);
						int num4;
						if (maxItemsPerLine <= 0)
						{
							num2 = 1443263234;
							num4 = num2;
						}
						else
						{
							num2 = 1443263237;
							num4 = num2;
						}
						continue;
					}
					case 1:
						if (num < inArray.Length - 1)
						{
							text += ", ";
							num2 = 1443263232;
							continue;
						}
						goto case 0;
					case 6:
						break;
					case 5:
						if ((num + 1) % maxItemsPerLine == 0)
						{
							text += "\n";
							num2 = 1443263232;
							continue;
						}
						goto case 1;
					case 0:
						num++;
						num2 = 1443263238;
						continue;
					default:
						return text;
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
				int num2 = 1542410962;
				while (true)
				{
					switch (num2 ^ 0x5BEF52D4)
					{
					case 5:
						break;
					case 2:
					{
						int num4;
						if (num >= inArray.Length - 1)
						{
							num2 = 1542410964;
							num4 = num2;
						}
						else
						{
							num2 = 1542410963;
							num4 = num2;
						}
						continue;
					}
					case 3:
						text += inArray[num];
						num2 = 1542410966;
						continue;
					case 6:
						num2 = 1542410965;
						continue;
					case 0:
						num++;
						num2 = 1542410965;
						continue;
					case 7:
						text += ", ";
						num2 = 1542410964;
						continue;
					case 1:
					{
						int num3;
						if (num >= inArray.Length)
						{
							num2 = 1542410960;
							num3 = num2;
						}
						else
						{
							num2 = 1542410967;
							num3 = num2;
						}
						continue;
					}
					default:
						return text;
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
					int num2;
					if (num < list.Count - 1)
					{
						text += ", ";
						num2 = 1699741883;
						goto IL_000f;
					}
					goto IL_0058;
					IL_000f:
					while (true)
					{
						switch (num2 ^ 0x655000BB)
						{
						case 3:
							num2 = 1699741882;
							continue;
						case 1:
							break;
						case 0:
							goto IL_0058;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					IL_0058:
					num++;
					num2 = 1699741881;
					goto IL_000f;
					continue;
					end_IL_002c:
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
			object[] array = new object[5];
			while (true)
			{
				int num = 486958714;
				while (true)
				{
					switch (num ^ 0x1D066678)
					{
					case 3:
						break;
					case 2:
						array[0] = v.x;
						array[1] = ", ";
						num = 486958713;
						continue;
					case 1:
						array[2] = v.y;
						array[3] = ", ";
						num = 486958712;
						continue;
					default:
						array[4] = v.z;
						return string.Concat(array);
					}
					break;
				}
			}
		}

		public static string ToString<T>(T[] inArray)
		{
			string text = "";
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = 268636455;
				while (true)
				{
					switch (num ^ 0x10031123)
					{
					case 6:
						break;
					case 2:
						num2++;
						num = 268636452;
						continue;
					case 1:
						text += inArray[num2].ToString();
						num = 268636448;
						continue;
					case 0:
						num = 268636452;
						continue;
					case 4:
						num3 = inArray.Length - 1;
						num2 = 0;
						num = 268636451;
						continue;
					case 3:
					{
						int num4;
						if (num2 >= num3)
						{
							num = 268636449;
							num4 = num;
						}
						else
						{
							num = 268636454;
							num4 = num;
						}
						continue;
					}
					case 5:
						text += ", ";
						num = 268636449;
						continue;
					default:
						if (num2 >= inArray.Length)
						{
							return text;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public static string ToString<T>(List<T> inList)
		{
			string text = "";
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = 670761186;
				while (true)
				{
					switch (num ^ 0x27FB00E7)
					{
					case 4:
						break;
					case 3:
						num2++;
						num = 670761189;
						continue;
					case 1:
					{
						text += inList[num2].ToString();
						int num4;
						if (num2 < num3)
						{
							num = 670761191;
							num4 = num;
						}
						else
						{
							num = 670761188;
							num4 = num;
						}
						continue;
					}
					case 6:
						num = 670761189;
						continue;
					case 5:
						num3 = inList.Count - 1;
						num2 = 0;
						num = 670761185;
						continue;
					case 0:
						text += ", ";
						num = 670761188;
						continue;
					default:
						if (num2 >= inList.Count)
						{
							return text;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public static string[] Split(string str, string delimiter)
		{
			if (str == null)
			{
				return null;
			}
			return str.Split(delimiter[0]);
		}

		public static string[] SplitAndTrim(string str, string delimiter)
		{
			if (str == null)
			{
				return null;
			}
			string[] array = Split(str, delimiter);
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= array.Length)
				{
					num2 = 153346707;
					num3 = num2;
				}
				else
				{
					num2 = 153346704;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x923E291)
					{
					case 3:
						num2 = 153346704;
						continue;
					case 1:
					{
						string text = array[num];
						array[num] = text.Trim();
						num++;
						num2 = 153346705;
						continue;
					}
					case 0:
						break;
					default:
						return array;
					}
					break;
				}
			}
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
					int num2 = 719982423;
					while (true)
					{
						switch (num2 ^ 0x2AEA0F54)
						{
						case 0:
							num2 = 719982421;
							continue;
						case 1:
							break;
						case 4:
							text += text2;
							num++;
							num2 = 719982422;
							continue;
						case 3:
							if (num != 0)
							{
								text += "\n";
								num2 = 719982416;
								continue;
							}
							goto case 4;
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
			int result;
			int.TryParse(s, out result);
			return result;
		}

		public static float StringToFloat(string s)
		{
			float result;
			float.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
			return result;
		}

		public static bool StringToBoolean(string s)
		{
			bool result;
			bool.TryParse(s, out result);
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
					int num = -1647491090;
					while (true)
					{
						switch (num ^ -1647491091)
						{
						case 0:
							break;
						case 3:
							goto IL_002f;
						case 1:
							goto end_IL_000d;
						default:
							goto IL_0074;
						}
						break;
						IL_002f:
						if (s == null)
						{
							num = -1647491092;
							continue;
						}
						s = s.Replace("|"[0], ""[0]);
						if (!(s == ""))
						{
							if (s == null)
							{
								num = -1647491089;
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
			if (s == null)
			{
				return null;
			}
			return s.ToCharArray();
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
					int num = -1736190897;
					while (true)
					{
						switch (num ^ -1736190898)
						{
						case 0:
							break;
						case 1:
							goto IL_0025;
						case 3:
							goto end_IL_0003;
						default:
							return s + ",";
						}
						break;
						IL_0025:
						if (s == "")
						{
							num = -1736190899;
							continue;
						}
						s = s.Replace("\\", "\\\\");
						s = s.Replace(",", "\\,");
						num = -1736190900;
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
			char c = default(char);
			char c2 = default(char);
			int num;
			if (s != null)
			{
				if (s == "")
				{
					goto IL_0016;
				}
				c = ","[0];
				c2 = "\\"[0];
				num = 1801432956;
				goto IL_001b;
			}
			goto IL_00ce;
			IL_001b:
			bool flag2 = default(bool);
			int num2 = default(int);
			bool flag = default(bool);
			string text = default(string);
			while (true)
			{
				switch (num ^ 0x6B5FAF70)
				{
				case 4:
					break;
				case 1:
					flag2 = false;
					if (s[num2] == c2)
					{
						goto IL_0078;
					}
					goto case 3;
				case 3:
					if (s[num2] == c)
					{
						goto IL_009a;
					}
					goto case 13;
				case 15:
					flag2 = true;
					flag = false;
					num = 1801432955;
					continue;
				case 14:
					flag = !flag;
					num = 1801432955;
					continue;
				case 7:
					goto IL_00ce;
				case 11:
					goto IL_00f6;
				case 8:
					text += s[num2];
					num = 1801432949;
					continue;
				case 13:
					flag = false;
					num = 1801432955;
					continue;
				case 5:
					num2++;
					num = 1801432953;
					continue;
				case 0:
					flag2 = false;
					num = 1801432946;
					continue;
				case 12:
					flag = false;
					num = 1801432944;
					continue;
				case 10:
					text = text.Substring(0, text.Length - 1);
					num = 1801432952;
					continue;
				case 2:
					text = "";
					num2 = 0;
					num = 1801432953;
					continue;
				case 6:
					flag2 = true;
					num = 1801432958;
					continue;
				default:
					if (num2 >= s.Length)
					{
						return text;
					}
					goto case 1;
				}
				break;
				IL_00f6:
				int num3;
				if (flag2)
				{
					num = 1801432954;
					num3 = num;
				}
				else
				{
					num = 1801432952;
					num3 = num;
				}
				continue;
				IL_0078:
				int num4;
				if (flag)
				{
					num = 1801432950;
					num4 = num;
				}
				else
				{
					num = 1801432958;
					num4 = num;
				}
				continue;
				IL_009a:
				int num5;
				if (flag)
				{
					num = 1801432959;
					num5 = num;
				}
				else
				{
					num = 1801432957;
					num5 = num;
				}
			}
			goto IL_0016;
			IL_00ce:
			return "";
			IL_0016:
			num = 1801432951;
			goto IL_001b;
		}

		public static string[] CSVToArray(string s)
		{
			char c = default(char);
			char c2 = default(char);
			List<object> list = default(List<object>);
			int num;
			if (s != null)
			{
				if (s == "")
				{
					goto IL_0016;
				}
				c = ","[0];
				c2 = "\\"[0];
				list = new List<object>();
				num = -817395182;
				goto IL_001b;
			}
			goto IL_013c;
			IL_001b:
			bool flag2 = default(bool);
			string text = default(string);
			bool flag = default(bool);
			int num3 = default(int);
			string[] array = default(string[]);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -817395198)
				{
				case 14:
					break;
				case 17:
					flag2 = false;
					num = -817395190;
					continue;
				case 16:
					text = "";
					flag = false;
					num = -817395181;
					continue;
				case 8:
					num3 = 0;
					num = -817395185;
					continue;
				case 18:
					text = "";
					num = -817395193;
					continue;
				case 1:
					goto IL_00b2;
				case 7:
					if (!flag2)
					{
						text += s[num3];
						num = -817395198;
						continue;
					}
					goto case 11;
				case 9:
					flag = false;
					num = -817395195;
					continue;
				case 5:
					flag2 = false;
					num = -817395198;
					continue;
				case 10:
					num = -817395195;
					continue;
				case 12:
					array[num2] = (string)list[num2];
					num2++;
					num = -817395194;
					continue;
				case 6:
					goto IL_013c;
				case 19:
					flag = !flag;
					num = -817395192;
					continue;
				case 3:
					num2 = 0;
					num = -817395194;
					continue;
				case 2:
					if (s[num3] == c && !flag)
					{
						flag2 = true;
						num = -817395189;
						continue;
					}
					goto case 9;
				case 13:
					num = -817395187;
					continue;
				case 11:
					text = CSVDecode(text);
					list.Add(text);
					num = -817395184;
					continue;
				case 0:
					num3++;
					num = -817395187;
					continue;
				case 15:
					if (num3 >= s.Length)
					{
						array = new string[list.Count];
						num = -817395199;
						continue;
					}
					goto IL_00b2;
				default:
					if (num2 >= list.Count)
					{
						return array;
					}
					goto case 12;
				}
				break;
				IL_00b2:
				int num4;
				if (s[num3] == c2)
				{
					num = -817395183;
					num4 = num;
				}
				else
				{
					num = -817395200;
					num4 = num;
				}
			}
			goto IL_0016;
			IL_013c:
			return null;
			IL_0016:
			num = -817395196;
			goto IL_001b;
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
				enumeration = (TEnum)Enum.Parse(typeFromHandle, value, true);
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
			int num2 = -798665587;
			goto IL_0010;
			IL_0010:
			string text = default(string);
			int num3 = default(int);
			float num6 = default(float);
			int num5 = default(int);
			while (true)
			{
				switch (num2 ^ -798665593)
				{
				case 8:
					break;
				case 0:
					text = text + num3 + " m";
					num2 = -798665598;
					continue;
				case 1:
				{
					int num8;
					if (!(text != ""))
					{
						num2 = -798665593;
						num8 = num2;
					}
					else
					{
						num2 = -798665597;
						num8 = num2;
					}
					continue;
				}
				case 2:
				{
					num3 = MathTools.FloorToInt(num / 60f);
					num -= (float)(num3 * 60);
					num6 = num;
					text = "";
					int num7;
					if (num5 <= 0)
					{
						num2 = -798665600;
						num7 = num2;
					}
					else
					{
						num2 = -798665586;
						num7 = num2;
					}
					continue;
				}
				case 10:
					num5 = MathTools.FloorToInt(num / 3600f);
					num -= (float)(num5 * 3600);
					num2 = -798665595;
					continue;
				case 11:
					text = text + num6 + " s";
					num2 = -798665599;
					continue;
				case 9:
					text = text + num5 + " h";
					num2 = -798665600;
					continue;
				case 4:
					text += ", ";
					num2 = -798665593;
					continue;
				case 5:
					if (num6 > 0f)
					{
						if (text != "")
						{
							text += ", ";
							num2 = -798665588;
							continue;
						}
						goto case 11;
					}
					goto default;
				case 7:
				{
					int num4;
					if (num3 > 0)
					{
						num2 = -798665594;
						num4 = num2;
					}
					else
					{
						num2 = -798665598;
						num4 = num2;
					}
					continue;
				}
				case 3:
					return seconds + " seconds";
				default:
					return text;
				}
				break;
			}
			goto IL_000b;
			IL_000b:
			num2 = -798665596;
			goto IL_0010;
		}

		static StringTools()
		{
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			kydCLwsDjJSXgULQOibcmxRvpQW = Regex.Escape(new string(invalidFileNameChars));
		}

		public static string CleanUpFileName(string name)
		{
			name = name.Trim();
			string pattern = "[ ~`,:;'\\.\\$\\^\\{\\}\\[\\]\\(\\|\\)\\*\\+\\?\\\\" + kydCLwsDjJSXgULQOibcmxRvpQW + "]";
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
				return name;
			}
			if (!int.TryParse(match.Value, out number))
			{
				throw new Exception("Could not parse string to Int32! " + match.Value);
			}
			int index = match.Index;
			if (index == 0)
			{
				return "";
			}
			return name.Substring(0, index);
		}

		public static string VerifyName(string name, int indexInNameList, string[] names, bool cleanUpIllegalFileChars)
		{
			return VerifyName(name, indexInNameList, names, cleanUpIllegalFileChars, false);
		}

		public static string VerifyName(string name, int indexInNameList, string[] names, bool cleanUpIllegalFileChars, bool allowBlank)
		{
			if (cleanUpIllegalFileChars)
			{
				name = CleanUpFileName(name);
				goto IL_009d;
			}
			goto IL_00eb;
			IL_00eb:
			int num;
			if (name != null)
			{
				name = name.Trim();
				num = 1051882296;
				goto IL_0018;
			}
			goto IL_009d;
			IL_009d:
			int num2;
			if (allowBlank)
			{
				num = 1051882289;
				num2 = num;
			}
			else
			{
				num = 1051882291;
				num2 = num;
			}
			goto IL_0018;
			IL_0018:
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num ^ 0x3EB27331)
				{
				case 8:
					num = 1051882292;
					continue;
				case 3:
					num = 1051882295;
					continue;
				case 0:
					break;
				case 7:
					goto IL_0062;
				case 2:
					if (string.IsNullOrEmpty(name))
					{
						name = "0";
						num = 1051882289;
						continue;
					}
					break;
				case 9:
					goto end_IL_0018;
				case 1:
					goto IL_00b5;
				case 4:
					return IterateName(name, indexInNameList, names);
				case 5:
					goto IL_00eb;
				default:
					if (num3 >= num4)
					{
						return name;
					}
					goto IL_00b5;
				}
				if (allowBlank)
				{
					num = 1051882294;
					continue;
				}
				goto IL_006c;
				IL_00b5:
				if (num3 != indexInNameList && names[num3] != null && name.Equals(names[num3], StringComparison.OrdinalIgnoreCase))
				{
					num = 1051882293;
					continue;
				}
				num3++;
				num = 1051882295;
				continue;
				IL_006c:
				num4 = ((names != null) ? names.Length : 0);
				if (num4 == 0)
				{
					return name;
				}
				num3 = 0;
				num = 1051882290;
				continue;
				IL_0062:
				if (string.IsNullOrEmpty(name))
				{
					return name;
				}
				goto IL_006c;
				continue;
				end_IL_0018:
				break;
			}
			goto IL_009d;
		}

		public static string IterateName(string name, int indexInNameList = -1, string[] names = null)
		{
			int number;
			string text = StripTrailingNumbers(name, out number);
			if (names != null)
			{
				int num = -1;
				int num4 = default(int);
				int num3 = default(int);
				string text2 = default(string);
				int number2 = default(int);
				while (true)
				{
					int num2 = -1258468978;
					while (true)
					{
						switch (num2 ^ -1258468977)
						{
						case 3:
							break;
						case 0:
						{
							int num7;
							if (num4 >= num3)
							{
								num2 = -1258468982;
								num7 = num2;
							}
							else
							{
								num2 = -1258468979;
								num7 = num2;
							}
							continue;
						}
						case 6:
							text2 = StripTrailingNumbers(text2, out number2);
							if (text.Equals(text2, StringComparison.OrdinalIgnoreCase))
							{
								int num6;
								if (number2 > num)
								{
									num2 = -1258468981;
									num6 = num2;
								}
								else
								{
									num2 = -1258468985;
									num6 = num2;
								}
								continue;
							}
							goto case 8;
						case 2:
							if (num4 != indexInNameList)
							{
								int num5;
								if (names[num4] == null)
								{
									num2 = -1258468985;
									num5 = num2;
								}
								else
								{
									num2 = -1258468984;
									num5 = num2;
								}
								continue;
							}
							goto case 8;
						case 7:
							text2 = names[num4];
							num2 = -1258468983;
							continue;
						case 8:
							num4++;
							num2 = -1258468977;
							continue;
						case 4:
							num = number2;
							num2 = -1258468985;
							continue;
						case 1:
							num3 = names.Length;
							num4 = 0;
							num2 = -1258468977;
							continue;
						default:
							num++;
							return text + num;
						}
						break;
					}
				}
			}
			return text + (number + 1);
		}

		public static string ToString(Rect rect)
		{
			return string.Format("{0}, {1}, {2}, {3}", rect.x, rect.y, rect.width, rect.height);
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
			if (source != null)
			{
				char[] array = default(char[]);
				int num3 = default(int);
				int num2 = default(int);
				int num5 = default(int);
				int num4 = default(int);
				while (true)
				{
					int num = -821956493;
					while (true)
					{
						switch (num ^ -821956494)
						{
						case 2:
							break;
						case 8:
							array[num3] = Convert.ToChar(num2);
							num3++;
							num = -821956485;
							continue;
						case 7:
							goto end_IL_0003;
						case 0:
							num5 = Convert.ToInt32('\0');
							num = -821956495;
							continue;
						case 3:
							array = source.ToCharArray();
							num3 = 0;
							num = -821956485;
							continue;
						case 1:
							goto IL_008e;
						case 9:
							goto IL_00a5;
						case 6:
							num2 = Convert.ToInt32(array[num3]) + shift;
							if (num2 > num4)
							{
								num2 -= num4;
								num = -821956486;
								continue;
							}
							goto case 5;
						case 5:
							if (num2 < num5)
							{
								num2 += num4;
								num = -821956486;
								continue;
							}
							goto case 8;
						default:
							return new string(array);
						}
						break;
						IL_00a5:
						int num6;
						if (num3 >= array.Length)
						{
							num = -821956490;
							num6 = num;
						}
						else
						{
							num = -821956492;
							num6 = num;
						}
						continue;
						IL_008e:
						if (!(source == string.Empty))
						{
							num4 = Convert.ToInt32('\uffff');
							num = -821956494;
						}
						else
						{
							num = -821956491;
						}
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			return string.Empty;
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
				num3 = -221895169;
				goto IL_000e;
			}
			goto IL_007e;
			IL_000e:
			int count = default(int);
			while (true)
			{
				switch (num3 ^ -221895172)
				{
				case 0:
					break;
				case 1:
					goto IL_0037;
				case 2:
					if (bytes[num2] == 0)
					{
						num = num2 - 1;
						num3 = -221895171;
						continue;
					}
					goto case 6;
				case 3:
					goto IL_005c;
				case 6:
					num2 += 2;
					num3 = -221895169;
					continue;
				case 5:
					goto IL_007e;
				default:
					return Encoding.Unicode.GetString(bytes, 0, count);
				}
				break;
				IL_005c:
				int num4;
				if (num2 < bytes.Length)
				{
					num3 = -221895170;
					num4 = num3;
				}
				else
				{
					num3 = -221895171;
					num4 = num3;
				}
				continue;
				IL_0037:
				if (num < 0)
				{
					return string.Empty;
				}
				count = num + 1;
				num3 = -221895176;
			}
			goto IL_0009;
			IL_007e:
			return string.Empty;
			IL_0009:
			num3 = -221895175;
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
				goto IL_0013;
			}
			if (index < 0)
			{
				return @string;
			}
			char[] array = @string.ToCharArray();
			array[index] = replacement;
			int num = 710472733;
			goto IL_0018;
			IL_0018:
			switch (num ^ 0x2A58F41C)
			{
			case 0:
				break;
			case 2:
				return @string;
			default:
				return new string(array);
			}
			goto IL_0013;
			IL_0013:
			num = 710472734;
			goto IL_0018;
		}

		public static string AddSpacesToSentence(string text, bool preserveAcronyms)
		{
			if (string.IsNullOrEmpty(text))
			{
				goto IL_000b;
			}
			StringBuilder stringBuilder = new StringBuilder(text.Length * 2);
			stringBuilder.Append(text[0]);
			int num = 761474751;
			goto IL_0010;
			IL_0010:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x2D632EBC)
				{
				case 6:
					break;
				case 7:
					if (preserveAcronyms)
					{
						int num5;
						if (char.IsUpper(text[num2 - 1]))
						{
							num = 761474748;
							num5 = num;
						}
						else
						{
							num = 761474749;
							num5 = num;
						}
						continue;
					}
					goto case 1;
				case 1:
					stringBuilder.Append(text[num2]);
					num2++;
					num = 761474740;
					continue;
				case 8:
				{
					int num4;
					if (num2 < text.Length)
					{
						num = 761474744;
						num4 = num;
					}
					else
					{
						num = 761474742;
						num4 = num;
					}
					continue;
				}
				case 5:
					stringBuilder.Append(' ');
					num = 761474749;
					continue;
				case 9:
					return string.Empty;
				case 4:
					if (char.IsUpper(text[num2]))
					{
						if (text[num2 - 1] != ' ')
						{
							int num7;
							if (!char.IsUpper(text[num2 - 1]))
							{
								num = 761474745;
								num7 = num;
							}
							else
							{
								num = 761474747;
								num7 = num;
							}
							continue;
						}
						goto case 7;
					}
					goto case 1;
				case 0:
				{
					int num6;
					if (num2 >= text.Length - 1)
					{
						num = 761474749;
						num6 = num;
					}
					else
					{
						num = 761474750;
						num6 = num;
					}
					continue;
				}
				case 3:
					num2 = 1;
					num = 761474740;
					continue;
				case 2:
				{
					int num3;
					if (char.IsUpper(text[num2 + 1]))
					{
						num = 761474749;
						num3 = num;
					}
					else
					{
						num = 761474745;
						num3 = num;
					}
					continue;
				}
				default:
					return stringBuilder.ToString();
				}
				break;
			}
			goto IL_000b;
			IL_000b:
			num = 761474741;
			goto IL_0010;
		}

		public static string WriteVar(string name, object value)
		{
			return WriteVar(name, value, '=');
		}

		public static string WriteVar(string name, object value, char delimiter)
		{
			object[] array = new object[6]
			{
				name,
				" ",
				delimiter,
				" ",
				(value != null) ? value.ToString() : "NULL",
				null
			};
			while (true)
			{
				int num = -882056331;
				while (true)
				{
					switch (num ^ -882056329)
					{
					case 0:
						break;
					case 2:
						goto IL_0055;
					default:
						return string.Concat(array);
					}
					break;
					IL_0055:
					array[5] = "\n";
					num = -882056330;
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
			char[] array = default(char[]);
			int num3 = default(int);
			MatchCollection matchCollection = default(MatchCollection);
			while (true)
			{
				int num = 562834195;
				while (true)
				{
					switch (num ^ 0x218C2B10)
					{
					case 2:
						break;
					case 0:
						array = fieldName.ToCharArray();
						num3 = 0;
						num = 562834193;
						continue;
					case 1:
						num = 562834196;
						continue;
					case 7:
					{
						int index = matchCollection[num3].Index;
						array[index] = array[index].ToString().ToUpper()[0];
						num3++;
						num = 562834196;
						continue;
					}
					case 4:
						if (num3 >= matchCollection.Count)
						{
							fieldName = AddSpacesToSentence(new string(array), false);
							num = 562834200;
							continue;
						}
						goto case 7;
					case 9:
						fieldName = Regex.Replace(fieldName, "[_]", " ");
						fieldName = fieldName.Trim();
						matchCollection = Regex.Matches(fieldName, "\\b([a-z])");
						num = 562834192;
						continue;
					case 6:
						fieldName = fieldName.Substring(2);
						num = 562834201;
						continue;
					case 5:
					{
						int num4;
						if (fieldName.Length > 2)
						{
							num = 562834198;
							num4 = num;
						}
						else
						{
							num = 562834201;
							num4 = num;
						}
						continue;
					}
					case 3:
					{
						int num2;
						if (!fieldName.StartsWith("m_"))
						{
							num = 562834201;
							num2 = num;
						}
						else
						{
							num = 562834197;
							num2 = num;
						}
						continue;
					}
					default:
						return Regex.Replace(fieldName, "([a-zA-Z_]+)([0-9]+)", "$1 $2");
					}
					break;
				}
			}
		}

		public static int CountChars(string text, char character)
		{
			if (string.IsNullOrEmpty(text))
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 0;
			int num3 = -862919542;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num3 ^ -862919538)
				{
				case 3:
					break;
				case 1:
					return 0;
				case 0:
					num2++;
					num3 = -862919542;
					continue;
				case 2:
					if (text[num2] == character)
					{
						num++;
						num3 = -862919538;
						continue;
					}
					goto case 0;
				default:
					if (num2 >= text.Length)
					{
						return num;
					}
					goto case 2;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num3 = -862919537;
			goto IL_000d;
		}
	}
}
