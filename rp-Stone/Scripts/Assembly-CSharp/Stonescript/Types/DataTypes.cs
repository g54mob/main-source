using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Stonescript.Types
{
	public class DataTypes
	{
		public static bool ObjectEquals(object left, object right)
		{
			if (left is int && right is int)
			{
				return (int)left == (int)right;
			}
			if (left is float && right is float)
			{
				return (float)left == (float)right;
			}
			if (left is bool && right is bool)
			{
				return (bool)left == (bool)right;
			}
			if (left is int && right is bool)
			{
				return (int)left == (((bool)right) ? 1 : 0);
			}
			if (right is int && left is bool)
			{
				return (int)right == (((bool)left) ? 1 : 0);
			}
			if (left is string && right is string)
			{
				return CultureInfo.InvariantCulture.CompareInfo.IndexOf(left as string, right as string, CompareOptions.IgnoreCase) >= 0;
			}
			if (IsNull(left) || IsNull(right))
			{
				if (left is StonescriptObject)
				{
					return IsNull(left);
				}
				if (right is StonescriptObject)
				{
					return IsNull(right);
				}
				return left == right;
			}
			return left == right;
		}

		public static bool IsInt(object o)
		{
			return o is int;
		}

		public static bool IsFloat(object o)
		{
			return o is float;
		}

		public static bool IsBool(object o)
		{
			return o is bool;
		}

		public static bool IsNumber(object o)
		{
			if (!(o is int))
			{
				return o is float;
			}
			return true;
		}

		public static bool IsString(object o)
		{
			return o is string;
		}

		public static bool IsObject(object o)
		{
			return o is StonescriptObject;
		}

		public static bool IsArray(object o)
		{
			return o is StonescriptArray;
		}

		public static bool IsNull(object o)
		{
			if (o is StonescriptObject)
			{
				return ((StonescriptObject)o).destroyed;
			}
			return o == null;
		}

		public static bool ToBool(object o)
		{
			if (o == null)
			{
				return false;
			}
			if (o is bool)
			{
				return (bool)o;
			}
			if (o is int)
			{
				return (int)o != 0;
			}
			if (o is float)
			{
				return (float)o != 0f;
			}
			if (o is string)
			{
				if (o is string text)
				{
					return text.Length > 0;
				}
				return false;
			}
			if (o is StonescriptObject)
			{
				return !IsNull(o);
			}
			return true;
		}

		public static string ToString(object o)
		{
			if (o == null)
			{
				return null;
			}
			if (o is string)
			{
				return o as string;
			}
			return o.ToString();
		}

		public static int ToInt(object o)
		{
			if (o is int)
			{
				return (int)o;
			}
			throw new InvalidOperationException($"Unable to cast \"{o}\" as an integer.");
		}

		public static float ToFloat(object o)
		{
			if (o is float)
			{
				return (float)o;
			}
			if (o is int)
			{
				return Convert.ToSingle(o);
			}
			throw new InvalidOperationException($"Unable to cast \"{o}\" as a float.");
		}

		public static bool IsNumeric(object o)
		{
			if (!(o is int))
			{
				return o is float;
			}
			return true;
		}

		public static string EscapeString(string orig)
		{
			string text = Regex.Replace(orig, "\r?\n\\^", "");
			int num = 0;
			int num2 = 0;
			while (num >= 0 && num < text.Length && num2 < 1000)
			{
				num2++;
				num = text.IndexOf('\\', num);
				if (num < 0 || num >= text.Length - 1)
				{
					break;
				}
				string text2 = null;
				switch (text[num + 1])
				{
				case 'n':
					text2 = "\\n";
					break;
				case '"':
					text2 = "\"";
					break;
				case '\\':
					text2 = "\\";
					break;
				case '/':
					text2 = "/";
					break;
				}
				if (text2 != null)
				{
					text = text.Substring(0, num) + text2 + text.Substring(num + 2);
					num += text2.Length;
				}
				else
				{
					num++;
				}
			}
			return text;
		}
	}
}
