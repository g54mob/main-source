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
		private static string HBzCXpAstTgPRcNTmnmqTRNrLDJ;

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
						num2 = -1237613505;
						goto IL_000f;
					}
					goto IL_0056;
					IL_000f:
					while (true)
					{
						switch (num2 ^ -1237613505)
						{
						case 3:
							num2 = -1237613506;
							continue;
						case 1:
							break;
						case 0:
							goto IL_0056;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					IL_0056:
					num++;
					num2 = -1237613507;
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
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= inArray.Length)
				{
					num2 = -214284280;
					num3 = num2;
				}
				else
				{
					num2 = -214284273;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -214284275)
					{
					case 0:
						num2 = -214284273;
						continue;
					case 2:
					{
						text += inArray[num];
						int num4;
						if (num < inArray.Length - 1)
						{
							num2 = -214284274;
							num4 = num2;
						}
						else
						{
							num2 = -214284276;
							num4 = num2;
						}
						continue;
					}
					case 3:
						text += ", ";
						num2 = -214284276;
						continue;
					case 4:
						break;
					case 1:
						num++;
						num2 = -214284279;
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
				int num = -729028428;
				while (true)
				{
					switch (num ^ -729028427)
					{
					case 0:
						break;
					case 1:
						num2 = 0;
						num = -729028431;
						continue;
					case 2:
						num2++;
						num = -729028431;
						continue;
					case 3:
						text += inArray[num2];
						if (num2 < inArray.Length - 1)
						{
							text += ", ";
							num = -729028425;
							continue;
						}
						goto case 2;
					default:
						if (num2 >= inArray.Length)
						{
							return text;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public static string ToString(bool[] inArray)
		{
			string text = "";
			int num2 = default(int);
			while (true)
			{
				int num = -1851931949;
				while (true)
				{
					switch (num ^ -1851931950)
					{
					case 0:
						break;
					case 1:
						num2 = 0;
						num = -1851931945;
						continue;
					case 6:
						text += inArray[num2];
						num = -1851931951;
						continue;
					case 2:
						text += ", ";
						num = -1851931946;
						continue;
					case 4:
						num2++;
						num = -1851931945;
						continue;
					case 3:
					{
						int num3;
						if (num2 >= inArray.Length - 1)
						{
							num = -1851931946;
							num3 = num;
						}
						else
						{
							num = -1851931952;
							num3 = num;
						}
						continue;
					}
					default:
						if (num2 >= inArray.Length)
						{
							return text;
						}
						goto case 6;
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
					int num2 = 1197409746;
					while (true)
					{
						switch (num2 ^ 0x475F05D0)
						{
						case 4:
							num2 = 1197409745;
							continue;
						case 3:
							num++;
							num2 = 1197409744;
							continue;
						case 2:
							break;
						case 5:
							text += ", ";
							num2 = 1197409747;
							continue;
						case 1:
							goto end_IL_000f;
						default:
							goto end_IL_006b;
						}
						int num3;
						if (num >= inArray.Length - 1)
						{
							num2 = 1197409747;
							num3 = num2;
						}
						else
						{
							num2 = 1197409749;
							num3 = num2;
						}
						continue;
						end_IL_000f:
						break;
					}
					continue;
					end_IL_006b:
					break;
				}
			}
			return text;
		}

		public static string ToString(byte[] inArray, string stringOptions, int maxItemsPerLine = 0)
		{
			string text = "";
			int num = 0;
			int num2 = default(int);
			while (num < inArray.Length)
			{
				while (true)
				{
					IL_00a7:
					text += inArray[num].ToString(stringOptions);
					int num3;
					if (maxItemsPerLine > 0)
					{
						num2 = (num + 1) % maxItemsPerLine;
						num3 = 1438520110;
						goto IL_0012;
					}
					goto IL_0046;
					IL_0061:
					num++;
					num3 = 1438520108;
					goto IL_0012;
					IL_0046:
					if (num < inArray.Length - 1)
					{
						text += ", ";
						num3 = 1438520109;
						goto IL_0012;
					}
					goto IL_0061;
					IL_0012:
					while (true)
					{
						switch (num3 ^ 0x55BE132C)
						{
						case 8:
							num3 = 1438520104;
							continue;
						case 7:
							break;
						case 1:
							goto IL_0061;
						case 6:
							if (num < inArray.Length - 1)
							{
								text += ", ";
								num3 = 1438520105;
								continue;
							}
							goto IL_0061;
						case 5:
							num3 = 1438520109;
							continue;
						case 2:
							if (num2 == 0)
							{
								text += "\n";
								num3 = 1438520111;
								continue;
							}
							goto case 6;
						case 4:
							goto IL_00a7;
						case 3:
							num3 = 1438520109;
							continue;
						default:
							goto end_IL_00a7;
						}
						break;
					}
					goto IL_0046;
					continue;
					end_IL_00a7:
					break;
				}
			}
			return text;
		}

		public static string ToString(Vector3[] inArray)
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
						num2 = -1718422472;
						num3 = num2;
					}
					else
					{
						num2 = -1718422471;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1718422471)
						{
						case 4:
							num2 = -1718422470;
							continue;
						case 1:
							num++;
							num2 = -1718422469;
							continue;
						case 0:
							text += ", ";
							num2 = -1718422472;
							continue;
						case 3:
							break;
						default:
							goto end_IL_004e;
						}
						break;
					}
					continue;
					end_IL_004e:
					break;
				}
			}
			return text;
		}

		public static string ToString(List<object> list)
		{
			string text = "";
			int num = 0;
			while (true)
			{
				int num2 = 1504929581;
				while (true)
				{
					switch (num2 ^ 0x59B3672C)
					{
					case 3:
						break;
					case 1:
						num2 = 1504929577;
						continue;
					case 0:
						text += list[num];
						if (num < list.Count - 1)
						{
							text += ", ";
							num2 = 1504929582;
							continue;
						}
						goto case 2;
					case 5:
					{
						int num3;
						if (num < list.Count)
						{
							num2 = 1504929580;
							num3 = num2;
						}
						else
						{
							num2 = 1504929576;
							num3 = num2;
						}
						continue;
					}
					case 2:
						num++;
						num2 = 1504929577;
						continue;
					default:
						return text;
					}
					break;
				}
			}
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
				int num = -764582802;
				while (true)
				{
					switch (num ^ -764582803)
					{
					case 0:
						break;
					case 3:
						array[0] = v.x;
						array[1] = ", ";
						num = -764582801;
						continue;
					case 2:
						array[2] = v.y;
						num = -764582804;
						continue;
					default:
						array[3] = ", ";
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
			int num4 = default(int);
			while (true)
			{
				int num = -1091926375;
				while (true)
				{
					switch (num ^ -1091926374)
					{
					case 0:
						break;
					case 1:
						num2++;
						num = -1091926370;
						continue;
					case 2:
						text += inArray[num2].ToString();
						if (num2 < num4)
						{
							text += ", ";
							num = -1091926373;
							continue;
						}
						goto case 1;
					case 3:
						num4 = inArray.Length - 1;
						num2 = 0;
						num = -1091926370;
						continue;
					case 4:
					{
						int num3;
						if (num2 >= inArray.Length)
						{
							num = -1091926369;
							num3 = num;
						}
						else
						{
							num = -1091926376;
							num3 = num;
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

		public static string ToString<T>(List<T> inList)
		{
			string text = "";
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = 227855414;
				while (true)
				{
					switch (num ^ 0xD94CC35)
					{
					case 5:
						break;
					case 3:
						num3 = inList.Count - 1;
						num = 227855413;
						continue;
					case 4:
						num2++;
						num = 227855415;
						continue;
					case 1:
						text += inList[num2].ToString();
						if (num2 < num3)
						{
							text += ", ";
							num = 227855409;
							continue;
						}
						goto case 4;
					case 0:
						num2 = 0;
						num = 227855415;
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
				goto IL_0003;
			}
			string[] array = Split(str, delimiter);
			int num = 0;
			int num2 = -634502490;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ -634502489)
				{
				case 3:
					break;
				case 0:
					num++;
					num2 = -634502490;
					continue;
				case 2:
				{
					string text = array[num];
					array[num] = text.Trim();
					num2 = -634502489;
					continue;
				}
				case 4:
					return null;
				default:
					if (num >= array.Length)
					{
						return array;
					}
					goto case 2;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = -634502493;
			goto IL_0008;
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
						num2 = -1970093921;
						goto IL_000f;
					}
					goto IL_0046;
					IL_000f:
					while (true)
					{
						switch (num2 ^ -1970093922)
						{
						case 3:
							num2 = -1970093924;
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
					num2 = -1970093922;
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
			if (s == "")
			{
				goto IL_0032;
			}
			if (s == null)
			{
				goto IL_0010;
			}
			s = s.Replace("|"[0], ""[0]);
			int num;
			if (!(s == ""))
			{
				if (s == null)
				{
					num = 1946513926;
				}
				else
				{
					s = s.Length + "|" + s;
					num = 1946513927;
				}
				goto IL_0015;
			}
			goto IL_006d;
			IL_006d:
			return "0|";
			IL_0010:
			num = 1946513925;
			goto IL_0015;
			IL_0015:
			switch (num ^ 0x74057206)
			{
			case 2:
				break;
			case 3:
				goto IL_0032;
			case 0:
				goto IL_006d;
			default:
				return s;
			}
			goto IL_0010;
			IL_0032:
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
			if (s == null || s == "")
			{
				return ",";
			}
			s = s.Replace("\\", "\\\\");
			s = s.Replace(",", "\\,");
			return s + ",";
		}

		public static string CSVDecode(string s)
		{
			char c = default(char);
			int num;
			if (s != null)
			{
				if (s == "")
				{
					goto IL_0016;
				}
				c = ","[0];
				num = 376618690;
				goto IL_001b;
			}
			goto IL_011e;
			IL_001b:
			bool flag2 = default(bool);
			string text = default(string);
			bool flag = default(bool);
			int num2 = default(int);
			char c2 = default(char);
			while (true)
			{
				switch (num ^ 0x1672BEC5)
				{
				case 13:
					break;
				case 2:
					if (flag2)
					{
						text = text.Substring(0, text.Length - 1);
						num = 376618689;
						continue;
					}
					goto case 4;
				case 9:
					goto IL_0084;
				case 12:
					flag = false;
					num = 376618695;
					continue;
				case 5:
					num = 376618703;
					continue;
				case 4:
					text += s[num2];
					num2++;
					num = 376618703;
					continue;
				case 8:
					flag = !flag;
					num = 376618695;
					continue;
				case 0:
					flag2 = true;
					num = 376618701;
					continue;
				case 11:
					goto IL_00ff;
				case 1:
					goto IL_011e;
				case 3:
					flag2 = true;
					flag = false;
					num = 376618695;
					continue;
				case 14:
					goto IL_0148;
				case 6:
					flag2 = false;
					text = "";
					num2 = 0;
					num = 376618688;
					continue;
				case 7:
					c2 = "\\"[0];
					flag = false;
					num = 376618691;
					continue;
				default:
					if (num2 >= s.Length)
					{
						return text;
					}
					goto IL_0084;
				}
				break;
				IL_0148:
				int num3;
				if (flag)
				{
					num = 376618694;
					num3 = num;
				}
				else
				{
					num = 376618697;
					num3 = num;
				}
				continue;
				IL_0084:
				flag2 = false;
				if (s[num2] == c2)
				{
					int num4;
					if (!flag)
					{
						num = 376618701;
						num4 = num;
					}
					else
					{
						num = 376618693;
						num4 = num;
					}
					continue;
				}
				goto IL_00ff;
				IL_00ff:
				int num5;
				if (s[num2] != c)
				{
					num = 376618697;
					num5 = num;
				}
				else
				{
					num = 376618699;
					num5 = num;
				}
			}
			goto IL_0016;
			IL_011e:
			return "";
			IL_0016:
			num = 376618692;
			goto IL_001b;
		}

		public static string[] CSVToArray(string s)
		{
			if (s != null)
			{
				int num3 = default(int);
				char c = default(char);
				bool flag2 = default(bool);
				string[] array = default(string[]);
				int num2 = default(int);
				List<object> list = default(List<object>);
				char c2 = default(char);
				bool flag = default(bool);
				string text = default(string);
				while (true)
				{
					int num = 1780294723;
					while (true)
					{
						switch (num ^ 0x6A1D2447)
						{
						case 9:
							break;
						case 19:
							if (s[num3] == c)
							{
								flag2 = !flag2;
								num = 1780294729;
								continue;
							}
							goto case 2;
						case 3:
							array[num2] = (string)list[num2];
							num = 1780294732;
							continue;
						case 0:
							goto end_IL_0006;
						case 4:
							goto IL_00c3;
						case 12:
							goto IL_00da;
						case 14:
							num = 1780294731;
							continue;
						case 2:
							if (s[num3] == c2 && !flag2)
							{
								flag = true;
								num = 1780294739;
								continue;
							}
							goto case 20;
						case 8:
							flag2 = false;
							flag = false;
							num = 1780294743;
							continue;
						case 13:
							if (num3 >= s.Length)
							{
								array = new string[list.Count];
								num2 = 0;
								num = 1780294720;
								continue;
							}
							goto case 19;
						case 16:
							num3 = 0;
							num = 1780294730;
							continue;
						case 5:
							flag = false;
							num = 1780294738;
							continue;
						case 6:
							text = "";
							num = 1780294722;
							continue;
						case 18:
							text += s[num3];
							num = 1780294738;
							continue;
						case 20:
							flag2 = false;
							num = 1780294731;
							continue;
						case 10:
							c = "\\"[0];
							list = new List<object>();
							num = 1780294728;
							continue;
						case 1:
							text = CSVDecode(text);
							list.Add(text);
							num = 1780294721;
							continue;
						case 7:
							goto IL_01de;
						case 21:
							num3++;
							num = 1780294730;
							continue;
						case 15:
							text = "";
							num = 1780294735;
							continue;
						case 11:
							num2++;
							num = 1780294720;
							continue;
						default:
							return array;
						}
						break;
						IL_01de:
						int num4;
						if (num2 < list.Count)
						{
							num = 1780294724;
							num4 = num;
						}
						else
						{
							num = 1780294742;
							num4 = num;
						}
						continue;
						IL_00da:
						int num5;
						if (flag)
						{
							num = 1780294726;
							num5 = num;
						}
						else
						{
							num = 1780294741;
							num5 = num;
						}
						continue;
						IL_00c3:
						if (!(s == ""))
						{
							c2 = ","[0];
							num = 1780294733;
						}
						else
						{
							num = 1780294727;
						}
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
			bool result = default(bool);
			while (true)
			{
				int num = 118018729;
				while (true)
				{
					switch (num ^ 0x708D2A8)
					{
					case 2:
						break;
					case 1:
					{
						if (string.IsNullOrEmpty(value))
						{
							goto IL_002d;
						}
						Type typeFromHandle = typeof(TEnum);
						try
						{
							enumeration = (TEnum)Enum.Parse(typeFromHandle, value, true);
						}
						catch (ArgumentException)
						{
							while (true)
							{
								int num2 = 118018729;
								while (true)
								{
									switch (num2 ^ 0x708D2A8)
									{
									case 0:
										break;
									case 1:
										goto IL_0075;
									default:
										return result;
									}
									break;
									IL_0075:
									result = false;
									num2 = 118018730;
								}
							}
						}
						return true;
					}
					default:
						return false;
					}
					break;
					IL_002d:
					num = 118018728;
				}
			}
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
			int num3 = MathTools.FloorToInt(num / 60f);
			num -= (float)(num3 * 60);
			float num4 = num;
			int num5 = 1202442246;
			goto IL_0010;
			IL_0010:
			string text = default(string);
			while (true)
			{
				switch (num5 ^ 0x47ABD00F)
				{
				case 3:
					break;
				case 5:
					text = text + num4 + " s";
					num5 = 1202442255;
					continue;
				case 6:
					if (num2 > 0)
					{
						text = text + num2 + " h";
						num5 = 1202442251;
						continue;
					}
					goto case 4;
				case 9:
					text = "";
					num5 = 1202442249;
					continue;
				case 8:
					if (num4 > 0f)
					{
						if (text != "")
						{
							text += ", ";
							num5 = 1202442250;
							continue;
						}
						goto case 5;
					}
					goto default;
				case 2:
					text = text + num3 + " m";
					num5 = 1202442247;
					continue;
				case 1:
					if (text != "")
					{
						text += ", ";
						num5 = 1202442253;
						continue;
					}
					goto case 2;
				case 4:
				{
					int num6;
					if (num3 <= 0)
					{
						num5 = 1202442247;
						num6 = num5;
					}
					else
					{
						num5 = 1202442254;
						num6 = num5;
					}
					continue;
				}
				case 7:
					return seconds + " seconds";
				default:
					return text;
				}
				break;
			}
			goto IL_000b;
			IL_000b:
			num5 = 1202442248;
			goto IL_0010;
		}

		static StringTools()
		{
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			HBzCXpAstTgPRcNTmnmqTRNrLDJ = Regex.Escape(new string(invalidFileNameChars));
		}

		public static string CleanUpFileName(string name)
		{
			name = name.Trim();
			string pattern = "[ ~`,:;'\\.\\$\\^\\{\\}\\[\\]\\(\\|\\)\\*\\+\\?\\\\" + HBzCXpAstTgPRcNTmnmqTRNrLDJ + "]";
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
				while (true)
				{
					switch (-566784442 ^ -566784444)
					{
					case 0:
						continue;
					case 2:
						throw new Exception("Could not parse string to Int32! " + match.Value);
					}
					break;
				}
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
			if (!cleanUpIllegalFileChars)
			{
				goto IL_004e;
			}
			name = CleanUpFileName(name);
			goto IL_0070;
			IL_00d6:
			if (allowBlank && string.IsNullOrEmpty(name))
			{
				return name;
			}
			int num = ((names != null) ? names.Length : 0);
			if (num == 0)
			{
				return name;
			}
			int num2 = 0;
			int num3 = -569197012;
			goto IL_0012;
			IL_0070:
			if (!allowBlank)
			{
				int num4;
				if (string.IsNullOrEmpty(name))
				{
					num3 = -569197011;
					num4 = num3;
				}
				else
				{
					num3 = -569197010;
					num4 = num3;
				}
				goto IL_0012;
			}
			goto IL_00d6;
			IL_004e:
			int num5;
			if (name == null)
			{
				num3 = -569197017;
				num5 = num3;
			}
			else
			{
				num3 = -569197014;
				num5 = num3;
			}
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num3 ^ -569197009)
				{
				case 6:
					num3 = -569197016;
					continue;
				case 7:
					break;
				case 2:
					name = "0";
					num3 = -569197010;
					continue;
				case 8:
					goto IL_0070;
				case 10:
					goto IL_008d;
				case 9:
					return IterateName(name, indexInNameList, names);
				case 5:
					name = name.Trim();
					num3 = -569197017;
					continue;
				case 3:
					num3 = -569197009;
					continue;
				case 1:
					goto IL_00d6;
				case 4:
					goto IL_00ff;
				default:
					if (num2 >= num)
					{
						return name;
					}
					goto IL_00ff;
				}
				break;
				IL_00ff:
				if (num2 != indexInNameList && names[num2] != null)
				{
					num3 = -569197019;
					continue;
				}
				goto IL_00ac;
				IL_008d:
				if (name.Equals(names[num2], StringComparison.OrdinalIgnoreCase))
				{
					num3 = -569197018;
					continue;
				}
				goto IL_00ac;
				IL_00ac:
				num2++;
				num3 = -569197009;
			}
			goto IL_004e;
		}

		public static string IterateName(string name, int indexInNameList = -1, string[] names = null)
		{
			int number;
			string text = StripTrailingNumbers(name, out number);
			string text2 = default(string);
			int num4 = default(int);
			int num3 = default(int);
			int num2 = default(int);
			if (names != null)
			{
				while (true)
				{
					int num = -303726528;
					while (true)
					{
						switch (num ^ -303726524)
						{
						case 6:
							break;
						case 2:
						{
							int number2;
							text2 = StripTrailingNumbers(text2, out number2);
							if (text.Equals(text2, StringComparison.OrdinalIgnoreCase) && number2 > num2)
							{
								num2 = number2;
								num = -303726521;
								continue;
							}
							goto case 3;
						}
						case 1:
							num4 = names.Length;
							num3 = 0;
							num = -303726524;
							continue;
						case 7:
							if (num3 != indexInNameList && names[num3] != null)
							{
								text2 = names[num3];
								num = -303726522;
								continue;
							}
							goto case 3;
						case 4:
							num2 = -1;
							num = -303726523;
							continue;
						case 0:
						{
							int num5;
							if (num3 >= num4)
							{
								num = -303726527;
								num5 = num;
							}
							else
							{
								num = -303726525;
								num5 = num;
							}
							continue;
						}
						case 3:
							num3++;
							num = -303726524;
							continue;
						default:
							num2++;
							return text + num2;
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
			while (true)
			{
				int num = 1866935117;
				while (true)
				{
					switch (num ^ 0x6F472B4F)
					{
					case 0:
						break;
					case 2:
						goto IL_002c;
					default:
						return array;
					}
					break;
					IL_002c:
					Buffer.BlockCopy(str.ToCharArray(), 0, array, 0, array.Length);
					num = 1866935118;
				}
			}
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
				int num2 = default(int);
				int num3 = default(int);
				int num5 = default(int);
				int num4 = default(int);
				while (true)
				{
					int num = 1624374815;
					while (true)
					{
						switch (num ^ 0x60D1FE19)
						{
						case 9:
							break;
						case 8:
							array[num2] = Convert.ToChar(num3);
							num = 1624374802;
							continue;
						case 4:
							array = source.ToCharArray();
							num2 = 0;
							num = 1624374812;
							continue;
						case 10:
							goto end_IL_0003;
						case 0:
							num5 = Convert.ToInt32('\0');
							num = 1624374813;
							continue;
						case 3:
							if (num3 < num5)
							{
								num3 += num4;
								num = 1624374801;
								continue;
							}
							goto case 8;
						case 1:
							num = 1624374801;
							continue;
						case 5:
							num = 1624374811;
							continue;
						case 11:
							num2++;
							num = 1624374811;
							continue;
						case 12:
							goto IL_00cd;
						case 7:
							num3 -= num4;
							num = 1624374808;
							continue;
						case 6:
							goto IL_0102;
						default:
							if (num2 >= array.Length)
							{
								return new string(array);
							}
							goto IL_00cd;
						}
						break;
						IL_0102:
						if (!(source == string.Empty))
						{
							num4 = Convert.ToInt32('\uffff');
							num = 1624374809;
						}
						else
						{
							num = 1624374803;
						}
						continue;
						IL_00cd:
						num3 = Convert.ToInt32(array[num2]) + shift;
						int num6;
						if (num3 > num4)
						{
							num = 1624374814;
							num6 = num;
						}
						else
						{
							num = 1624374810;
							num6 = num;
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
			int num2;
			if (bytes != null)
			{
				if (bytes.Length < 3)
				{
					goto IL_0009;
				}
				num = -1;
				num2 = -1520092771;
				goto IL_000e;
			}
			goto IL_003f;
			IL_000e:
			int num3 = default(int);
			int count = default(int);
			while (true)
			{
				switch (num2 ^ -1520092771)
				{
				case 7:
					break;
				case 5:
					goto IL_003f;
				case 6:
					goto IL_004e;
				case 2:
					goto IL_0065;
				case 8:
					num3 += 2;
					num2 = -1520092773;
					continue;
				case 1:
					if (bytes[num3] == 0)
					{
						num = num3 - 1;
						num2 = -1520092775;
						continue;
					}
					goto case 8;
				case 4:
					num2 = -1520092769;
					continue;
				case 0:
					num3 = 0;
					num2 = -1520092773;
					continue;
				default:
					return Encoding.Unicode.GetString(bytes, 0, count);
				}
				break;
				IL_0065:
				if (num < 0)
				{
					return string.Empty;
				}
				count = num + 1;
				num2 = -1520092770;
				continue;
				IL_004e:
				int num4;
				if (num3 >= bytes.Length)
				{
					num2 = -1520092769;
					num4 = num2;
				}
				else
				{
					num2 = -1520092772;
					num4 = num2;
				}
			}
			goto IL_0009;
			IL_003f:
			return string.Empty;
			IL_0009:
			num2 = -1520092776;
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
			int num2 = default(int);
			while (true)
			{
				int num = 816141693;
				while (true)
				{
					switch (num ^ 0x30A5557B)
					{
					case 8:
						break;
					case 5:
						stringBuilder.Append(' ');
						num = 816141692;
						continue;
					case 2:
						if (preserveAcronyms && char.IsUpper(text[num2 - 1]))
						{
							int num4;
							if (num2 >= text.Length - 1)
							{
								num = 816141692;
								num4 = num;
							}
							else
							{
								num = 816141690;
								num4 = num;
							}
							continue;
						}
						goto case 7;
					case 7:
						stringBuilder.Append(text[num2]);
						num = 816141695;
						continue;
					case 3:
						if (char.IsUpper(text[num2]))
						{
							if (text[num2 - 1] != ' ')
							{
								int num5;
								if (char.IsUpper(text[num2 - 1]))
								{
									num = 816141689;
									num5 = num;
								}
								else
								{
									num = 816141694;
									num5 = num;
								}
								continue;
							}
							goto case 2;
						}
						goto case 7;
					case 4:
						num2++;
						num = 816141691;
						continue;
					case 1:
					{
						int num3;
						if (!char.IsUpper(text[num2 + 1]))
						{
							num = 816141694;
							num3 = num;
						}
						else
						{
							num = 816141692;
							num3 = num;
						}
						continue;
					}
					case 6:
						stringBuilder.Append(text[0]);
						num2 = 1;
						num = 816141691;
						continue;
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
			return name + " " + delimiter + " " + ((value != null) ? value.ToString() : "NULL") + "\n";
		}

		public static void WriteVar(StringBuilder sb, string name, object value)
		{
			WriteVar(sb, name, value, '=');
		}

		public static void WriteVar(StringBuilder sb, string name, object value, char delimiter)
		{
			sb.Append(name);
			sb.Append(" ");
			while (true)
			{
				int num = -1212306522;
				while (true)
				{
					string value2;
					switch (num ^ -1212306524)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						sb.Append(delimiter);
						sb.Append(" ");
						value2 = ((value != null) ? value.ToString() : ((value is string) ? string.Empty : "NULL"));
						goto IL_0066;
					case 1:
						return;
					}
					break;
					IL_0066:
					sb.Append(value2);
					sb.Append("\n");
					num = -1212306523;
				}
			}
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
			MatchCollection matchCollection = default(MatchCollection);
			int num2 = default(int);
			char[] array = default(char[]);
			while (true)
			{
				int num = -740214390;
				while (true)
				{
					switch (num ^ -740214392)
					{
					case 6:
						break;
					case 3:
					{
						int index = matchCollection[num2].Index;
						array[index] = array[index].ToString().ToUpper()[0];
						num = -740214391;
						continue;
					}
					case 4:
						fieldName = Regex.Replace(fieldName, "[_]", " ");
						fieldName = fieldName.Trim();
						num = -740214387;
						continue;
					case 2:
						fieldName = Regex.Replace(fieldName, "[_]{2,}", "_");
						num = -740214385;
						continue;
					case 5:
						matchCollection = Regex.Matches(fieldName, "\\b([a-z])");
						array = fieldName.ToCharArray();
						num2 = 0;
						num = -740214392;
						continue;
					case 7:
					{
						int num3;
						if (!fieldName.StartsWith("m_"))
						{
							num = -740214388;
							num3 = num;
						}
						else
						{
							num = -740214400;
							num3 = num;
						}
						continue;
					}
					case 8:
						if (fieldName.Length > 2)
						{
							fieldName = fieldName.Substring(2);
							num = -740214388;
							continue;
						}
						goto case 4;
					case 1:
						num2++;
						num = -740214392;
						continue;
					default:
						if (num2 >= matchCollection.Count)
						{
							fieldName = AddSpacesToSentence(new string(array), false);
							return Regex.Replace(fieldName, "([a-zA-Z_]+)([0-9]+)", "$1 $2");
						}
						goto case 3;
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
			int num3 = -1853564279;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num3 ^ -1853564277)
				{
				case 4:
					break;
				case 1:
					return 0;
				case 3:
					if (text[num2] == character)
					{
						num++;
						num3 = -1853564277;
						continue;
					}
					goto case 0;
				case 2:
				{
					int num4;
					if (num2 >= text.Length)
					{
						num3 = -1853564274;
						num4 = num3;
					}
					else
					{
						num3 = -1853564280;
						num4 = num3;
					}
					continue;
				}
				case 0:
					num2++;
					num3 = -1853564279;
					continue;
				default:
					return num;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num3 = -1853564278;
			goto IL_000d;
		}
	}
}
