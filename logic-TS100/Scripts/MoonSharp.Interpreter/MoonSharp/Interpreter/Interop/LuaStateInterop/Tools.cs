using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MoonSharp.Interpreter.Interop.LuaStateInterop
{
	internal static class Tools
	{
		internal static Regex r = new Regex("\\%(\\d*\\$)?([\\'\\#\\-\\+ ]*)(\\d*)(?:\\.(\\d+))?([hl])?([dioxXucsfeEgGpn%])");

		public static bool IsNumericType(object o)
		{
			if (!(o is byte) && !(o is sbyte) && !(o is short) && !(o is ushort) && !(o is int) && !(o is uint) && !(o is long) && !(o is ulong) && !(o is float) && !(o is double))
			{
				return o is decimal;
			}
			return true;
		}

		public static bool IsPositive(object Value, bool ZeroIsPositive)
		{
			switch (Type.GetTypeCode(Value.GetType()))
			{
			case TypeCode.SByte:
				if (!ZeroIsPositive)
				{
					return (sbyte)Value > 0;
				}
				return (sbyte)Value >= 0;
			case TypeCode.Int16:
				if (!ZeroIsPositive)
				{
					return (short)Value > 0;
				}
				return (short)Value >= 0;
			case TypeCode.Int32:
				if (!ZeroIsPositive)
				{
					return (int)Value > 0;
				}
				return (int)Value >= 0;
			case TypeCode.Int64:
				if (!ZeroIsPositive)
				{
					return (long)Value > 0;
				}
				return (long)Value >= 0;
			case TypeCode.Single:
				if (!ZeroIsPositive)
				{
					return (float)Value > 0f;
				}
				return (float)Value >= 0f;
			case TypeCode.Double:
				if (!ZeroIsPositive)
				{
					return (double)Value > 0.0;
				}
				return (double)Value >= 0.0;
			case TypeCode.Decimal:
				if (!ZeroIsPositive)
				{
					return (decimal)Value > 0m;
				}
				return (decimal)Value >= 0m;
			case TypeCode.Byte:
				if (!ZeroIsPositive)
				{
					return (byte)Value > 0;
				}
				return true;
			case TypeCode.UInt16:
				if (!ZeroIsPositive)
				{
					return (ushort)Value > 0;
				}
				return true;
			case TypeCode.UInt32:
				if (!ZeroIsPositive)
				{
					return (uint)Value != 0;
				}
				return true;
			case TypeCode.UInt64:
				if (!ZeroIsPositive)
				{
					return (ulong)Value != 0;
				}
				return true;
			case TypeCode.Char:
				if (!ZeroIsPositive)
				{
					return (char)Value != '\0';
				}
				return true;
			default:
				return false;
			}
		}

		public static object ToUnsigned(object Value)
		{
			switch (Type.GetTypeCode(Value.GetType()))
			{
			case TypeCode.SByte:
				return (byte)(sbyte)Value;
			case TypeCode.Int16:
				return (ushort)(short)Value;
			case TypeCode.Int32:
				return (uint)(int)Value;
			case TypeCode.Int64:
				return (ulong)(long)Value;
			case TypeCode.Byte:
				return Value;
			case TypeCode.UInt16:
				return Value;
			case TypeCode.UInt32:
				return Value;
			case TypeCode.UInt64:
				return Value;
			case TypeCode.Single:
				return (uint)(float)Value;
			case TypeCode.Double:
				return (ulong)(double)Value;
			case TypeCode.Decimal:
				return (ulong)(decimal)Value;
			default:
				return null;
			}
		}

		public static object ToInteger(object Value, bool Round)
		{
			switch (Type.GetTypeCode(Value.GetType()))
			{
			case TypeCode.SByte:
				return Value;
			case TypeCode.Int16:
				return Value;
			case TypeCode.Int32:
				return Value;
			case TypeCode.Int64:
				return Value;
			case TypeCode.Byte:
				return Value;
			case TypeCode.UInt16:
				return Value;
			case TypeCode.UInt32:
				return Value;
			case TypeCode.UInt64:
				return Value;
			case TypeCode.Single:
				return Round ? ((int)Math.Round((float)Value)) : ((int)(float)Value);
			case TypeCode.Double:
				return Round ? ((long)Math.Round((double)Value)) : ((long)(double)Value);
			case TypeCode.Decimal:
				return Round ? Math.Round((decimal)Value) : ((decimal)Value);
			default:
				return null;
			}
		}

		public static long UnboxToLong(object Value, bool Round)
		{
			switch (Type.GetTypeCode(Value.GetType()))
			{
			case TypeCode.SByte:
				return (sbyte)Value;
			case TypeCode.Int16:
				return (short)Value;
			case TypeCode.Int32:
				return (int)Value;
			case TypeCode.Int64:
				return (long)Value;
			case TypeCode.Byte:
				return (byte)Value;
			case TypeCode.UInt16:
				return (ushort)Value;
			case TypeCode.UInt32:
				return (uint)Value;
			case TypeCode.UInt64:
				return (long)(ulong)Value;
			case TypeCode.Single:
				if (!Round)
				{
					return (long)(float)Value;
				}
				return (long)Math.Round((float)Value);
			case TypeCode.Double:
				if (!Round)
				{
					return (long)(double)Value;
				}
				return (long)Math.Round((double)Value);
			case TypeCode.Decimal:
				if (!Round)
				{
					return (long)(decimal)Value;
				}
				return (long)Math.Round((decimal)Value);
			default:
				return 0L;
			}
		}

		public static string ReplaceMetaChars(string input)
		{
			return Regex.Replace(input, "(\\\\)(\\d{3}|[^\\d])?", ReplaceMetaCharsMatch);
		}

		private static string ReplaceMetaCharsMatch(Match m)
		{
			if (m.Groups[2].Length == 3)
			{
				return Convert.ToChar(Convert.ToByte(m.Groups[2].Value, 8)).ToString();
			}
			switch (m.Groups[2].Value)
			{
			case "0":
				return "\0";
			case "a":
				return "\a";
			case "b":
				return "\b";
			case "f":
				return "\f";
			case "v":
				return "\v";
			case "r":
				return "\r";
			case "n":
				return "\n";
			case "t":
				return "\t";
			default:
				return m.Groups[2].Value;
			}
		}

		public static void fprintf(TextWriter Destination, string Format, params object[] Parameters)
		{
			Destination.Write(sprintf(Format, Parameters));
		}

		public static string sprintf(string Format, params object[] Parameters)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Match match = null;
			string empty = string.Empty;
			int num = 0;
			object obj = null;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			int num2 = 0;
			int num3 = 0;
			char c = '\0';
			char c2 = '\0';
			char c3 = ' ';
			stringBuilder.Append(Format);
			match = r.Match(stringBuilder.ToString());
			while (match.Success)
			{
				int num4 = num;
				if (match.Groups[1] != null && match.Groups[1].Value.Length > 0)
				{
					string value = match.Groups[1].Value.Substring(0, match.Groups[1].Value.Length - 1);
					num4 = Convert.ToInt32(value) - 1;
				}
				flag2 = false;
				flag = false;
				flag3 = false;
				flag4 = false;
				flag5 = false;
				flag6 = false;
				if (match.Groups[2] != null && match.Groups[2].Value.Length > 0)
				{
					string value2 = match.Groups[2].Value;
					flag2 = value2.IndexOf('#') >= 0;
					flag = value2.IndexOf('-') >= 0;
					flag3 = value2.IndexOf('+') >= 0;
					flag4 = value2.IndexOf(' ') >= 0;
					flag6 = value2.IndexOf('\'') >= 0;
					if (flag3 && flag4)
					{
						flag4 = false;
					}
				}
				c3 = ' ';
				num2 = int.MinValue;
				if (match.Groups[3] != null && match.Groups[3].Value.Length > 0)
				{
					num2 = Convert.ToInt32(match.Groups[3].Value);
					flag5 = match.Groups[3].Value[0] == '0';
				}
				if (flag5)
				{
					c3 = '0';
				}
				if (flag && flag5)
				{
					flag5 = false;
					c3 = ' ';
				}
				num3 = int.MinValue;
				if (match.Groups[4] != null && match.Groups[4].Value.Length > 0)
				{
					num3 = Convert.ToInt32(match.Groups[4].Value);
				}
				c = '\0';
				if (match.Groups[5] != null && match.Groups[5].Value.Length > 0)
				{
					c = match.Groups[5].Value[0];
				}
				c2 = '\0';
				if (match.Groups[6] != null && match.Groups[6].Value.Length > 0)
				{
					c2 = match.Groups[6].Value[0];
				}
				if (num3 == int.MinValue && c2 != 's' && c2 != 'c' && char.ToUpper(c2) != 'X' && c2 != 'o')
				{
					num3 = 6;
				}
				if (Parameters == null || num4 >= Parameters.Length)
				{
					obj = null;
				}
				else
				{
					obj = Parameters[num4];
					switch (c)
					{
					case 'h':
						if (obj is int)
						{
							obj = (short)(int)obj;
						}
						else if (obj is long)
						{
							obj = (short)(long)obj;
						}
						else if (obj is uint)
						{
							obj = (ushort)(uint)obj;
						}
						else if (obj is ulong)
						{
							obj = (ushort)(ulong)obj;
						}
						break;
					case 'l':
						if (obj is short)
						{
							obj = (long)(short)obj;
						}
						else if (obj is int)
						{
							obj = (long)(int)obj;
						}
						else if (obj is ushort)
						{
							obj = (ulong)(ushort)obj;
						}
						else if (obj is uint)
						{
							obj = (ulong)(uint)obj;
						}
						break;
					}
				}
				empty = string.Empty;
				switch (c2)
				{
				case '%':
					empty = "%";
					break;
				case 'd':
				case 'i':
					empty = FormatNumber(flag6 ? "n" : "d", flag2, num2, int.MinValue, flag, flag3, flag4, c3, obj);
					num++;
					break;
				case 'o':
					empty = FormatOct("o", flag2, num2, int.MinValue, flag, c3, obj);
					num++;
					break;
				case 'x':
					empty = FormatHex("x", flag2, num2, num3, flag, c3, obj);
					num++;
					break;
				case 'X':
					empty = FormatHex("X", flag2, num2, num3, flag, c3, obj);
					num++;
					break;
				case 'u':
					empty = FormatNumber(flag6 ? "n" : "d", flag2, num2, int.MinValue, flag, false, false, c3, ToUnsigned(obj));
					num++;
					break;
				case 'c':
					if (IsNumericType(obj))
					{
						empty = Convert.ToChar(obj).ToString();
					}
					else if (obj is char)
					{
						empty = ((char)obj).ToString();
					}
					else if (obj is string && ((string)obj).Length > 0)
					{
						empty = ((string)obj)[0].ToString();
					}
					num++;
					break;
				case 's':
					empty = obj.ToString();
					if (num3 >= 0)
					{
						empty = empty.Substring(0, num3);
					}
					if (num2 != int.MinValue)
					{
						empty = ((!flag) ? empty.PadLeft(num2, c3) : empty.PadRight(num2, c3));
					}
					num++;
					break;
				case 'f':
					empty = FormatNumber(flag6 ? "n" : "f", flag2, num2, num3, flag, flag3, flag4, c3, obj);
					num++;
					break;
				case 'e':
					empty = FormatNumber("e", flag2, num2, num3, flag, flag3, flag4, c3, obj);
					num++;
					break;
				case 'E':
					empty = FormatNumber("E", flag2, num2, num3, flag, flag3, flag4, c3, obj);
					num++;
					break;
				case 'g':
					empty = FormatNumber("g", flag2, num2, num3, flag, flag3, flag4, c3, obj);
					num++;
					break;
				case 'G':
					empty = FormatNumber("G", flag2, num2, num3, flag, flag3, flag4, c3, obj);
					num++;
					break;
				case 'p':
					if (obj is IntPtr)
					{
						empty = "0x" + ((IntPtr)obj).ToString("x");
					}
					num++;
					break;
				case 'n':
					empty = FormatNumber("d", flag2, num2, int.MinValue, flag, flag3, flag4, c3, match.Index);
					break;
				default:
					empty = string.Empty;
					num++;
					break;
				}
				stringBuilder.Remove(match.Index, match.Length);
				stringBuilder.Insert(match.Index, empty);
				match = r.Match(stringBuilder.ToString(), match.Index + empty.Length);
			}
			return stringBuilder.ToString();
		}

		private static string FormatOct(string NativeFormat, bool Alternate, int FieldLength, int FieldPrecision, bool Left2Right, char Padding, object Value)
		{
			string text = string.Empty;
			string format = "{0" + ((FieldLength != int.MinValue) ? ("," + (Left2Right ? "-" : string.Empty) + FieldLength) : string.Empty) + "}";
			if (IsNumericType(Value))
			{
				text = Convert.ToString(UnboxToLong(Value, true), 8);
				if (Left2Right || Padding == ' ')
				{
					if (Alternate && text != "0")
					{
						text = "0" + text;
					}
					text = string.Format(format, text);
				}
				else
				{
					if (FieldLength != int.MinValue)
					{
						text = text.PadLeft(FieldLength - ((Alternate && text != "0") ? 1 : 0), Padding);
					}
					if (Alternate && text != "0")
					{
						text = "0" + text;
					}
				}
			}
			return text;
		}

		private static string FormatHex(string NativeFormat, bool Alternate, int FieldLength, int FieldPrecision, bool Left2Right, char Padding, object Value)
		{
			string text = string.Empty;
			string format = "{0" + ((FieldLength != int.MinValue) ? ("," + (Left2Right ? "-" : string.Empty) + FieldLength) : string.Empty) + "}";
			string format2 = "{0:" + NativeFormat + ((FieldPrecision != int.MinValue) ? FieldPrecision.ToString() : string.Empty) + "}";
			if (IsNumericType(Value))
			{
				text = string.Format(format2, Value);
				if (Left2Right || Padding == ' ')
				{
					if (Alternate)
					{
						text = ((NativeFormat == "x") ? "0x" : "0X") + text;
					}
					text = string.Format(format, text);
				}
				else
				{
					if (FieldLength != int.MinValue)
					{
						text = text.PadLeft(FieldLength - (Alternate ? 2 : 0), Padding);
					}
					if (Alternate)
					{
						text = ((NativeFormat == "x") ? "0x" : "0X") + text;
					}
				}
			}
			return text;
		}

		private static string FormatNumber(string NativeFormat, bool Alternate, int FieldLength, int FieldPrecision, bool Left2Right, bool PositiveSign, bool PositiveSpace, char Padding, object Value)
		{
			string result = string.Empty;
			string format = "{0" + ((FieldLength != int.MinValue) ? ("," + (Left2Right ? "-" : string.Empty) + FieldLength) : string.Empty) + "}";
			string format2 = "{0:" + NativeFormat + ((FieldPrecision != int.MinValue) ? FieldPrecision.ToString() : "0") + "}";
			if (IsNumericType(Value))
			{
				result = string.Format(CultureInfo.InvariantCulture, format2, Value);
				if (Left2Right || Padding == ' ')
				{
					if (IsPositive(Value, true))
					{
						result = (PositiveSign ? "+" : (PositiveSpace ? " " : string.Empty)) + result;
					}
					result = string.Format(format, result);
				}
				else
				{
					if (result.StartsWith("-"))
					{
						result = result.Substring(1);
					}
					if (FieldLength != int.MinValue)
					{
						result = ((!PositiveSign) ? result.PadLeft(FieldLength, Padding) : result.PadLeft(FieldLength - 1, Padding));
					}
					result = ((!IsPositive(Value, true)) ? ("-" + result) : ((PositiveSign ? "+" : "") + result));
				}
			}
			return result;
		}
	}
}
