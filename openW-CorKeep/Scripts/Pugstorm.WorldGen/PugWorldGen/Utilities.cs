using System;
using System.Text;
using UnityEngine;

namespace PugWorldGen
{
	public static class Utilities
	{
		public static string GetValidName(string name)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < name.Length; i++)
			{
				if (name[i].IsAsciiLetter() || char.IsDigit(name[i]))
				{
					stringBuilder.Append(name[i]);
				}
			}
			if (stringBuilder.Length < 1)
			{
				return null;
			}
			if (char.IsDigit(stringBuilder[0]))
			{
				stringBuilder.Insert(0, '_');
			}
			return stringBuilder.ToString().Capitalize();
		}

		public static string GetSubClassName(string name)
		{
			return GetValidName(name).Capitalize();
		}

		public static string GetFieldName(string name)
		{
			return GetValidName(name).Uncapitalize();
		}

		public static string GetShaderPropertyName(string name)
		{
			return "_" + GetSubClassName(name);
		}

		public static bool IsAsciiLetter(this char c)
		{
			if (c < 'A' || c > 'Z')
			{
				if (c >= 'a')
				{
					return c <= 'z';
				}
				return false;
			}
			return true;
		}

		public static int HashRGB(this Color32 c)
		{
			return (c.b << 16) | (c.g << 8) | c.r;
		}

		public static string Capitalize(this string str)
		{
			return char.ToUpper(str[0]) + str.Substring(1);
		}

		public static string Uncapitalize(this string str)
		{
			return char.ToLower(str[0]) + str.Substring(1);
		}

		public static void DecodeBitmask(byte b, out bool b1, out bool b2, out bool b3, out bool b4, out bool b5, out bool b6, out bool b7, out bool b8)
		{
			b1 = (b & 1) != 0;
			b2 = (b & 2) != 0;
			b3 = (b & 4) != 0;
			b4 = (b & 8) != 0;
			b5 = (b & 0x10) != 0;
			b6 = (b & 0x20) != 0;
			b7 = (b & 0x40) != 0;
			b8 = (b & 0x80) != 0;
		}

		public static void DecodeBitmask(byte b, out bool b1, out bool b2, out bool b3, out bool b4, out bool b5, out bool b6, out bool b7)
		{
			b1 = (b & 1) != 0;
			b2 = (b & 2) != 0;
			b3 = (b & 4) != 0;
			b4 = (b & 8) != 0;
			b5 = (b & 0x10) != 0;
			b6 = (b & 0x20) != 0;
			b7 = (b & 0x40) != 0;
		}

		public static void DecodeBitmask(byte b, out bool b1, out bool b2, out bool b3, out bool b4, out bool b5, out bool b6)
		{
			b1 = (b & 1) != 0;
			b2 = (b & 2) != 0;
			b3 = (b & 4) != 0;
			b4 = (b & 8) != 0;
			b5 = (b & 0x10) != 0;
			b6 = (b & 0x20) != 0;
		}

		public static void DecodeBitmask(byte b, out bool b1, out bool b2, out bool b3, out bool b4, out bool b5)
		{
			b1 = (b & 1) != 0;
			b2 = (b & 2) != 0;
			b3 = (b & 4) != 0;
			b4 = (b & 8) != 0;
			b5 = (b & 0x10) != 0;
		}

		public static void DecodeBitmask(byte b, out bool b1, out bool b2, out bool b3, out bool b4)
		{
			b1 = (b & 1) != 0;
			b2 = (b & 2) != 0;
			b3 = (b & 4) != 0;
			b4 = (b & 8) != 0;
		}

		public static void DecodeBitmask(byte b, out bool b1, out bool b2, out bool b3)
		{
			b1 = (b & 1) != 0;
			b2 = (b & 2) != 0;
			b3 = (b & 4) != 0;
		}

		public static void DecodeBitmask(byte b, out bool b1, out bool b2)
		{
			b1 = (b & 1) != 0;
			b2 = (b & 2) != 0;
		}

		public static void DecodeBitmask(byte b, out bool b1)
		{
			b1 = (b & 1) != 0;
		}

		[Obsolete("Use DecodeBitmask with byte as input instead.")]
		public static void DecodeBitmask(float f, out bool b1, out bool b2, out bool b3, out bool b4, out bool b5, out bool b6, out bool b7, out bool b8)
		{
			uint num = (uint)(f * 255f);
			b1 = (num & 1) != 0;
			b2 = (num & 2) != 0;
			b3 = (num & 4) != 0;
			b4 = (num & 8) != 0;
			b5 = (num & 0x10) != 0;
			b6 = (num & 0x20) != 0;
			b7 = (num & 0x40) != 0;
			b8 = (num & 0x80) != 0;
		}

		[Obsolete("Use DecodeBitmask with byte as input instead.")]
		public static void DecodeBitmask(float f, out bool b1, out bool b2, out bool b3, out bool b4, out bool b5, out bool b6, out bool b7)
		{
			uint num = (uint)(f * 255f);
			b1 = (num & 1) != 0;
			b2 = (num & 2) != 0;
			b3 = (num & 4) != 0;
			b4 = (num & 8) != 0;
			b5 = (num & 0x10) != 0;
			b6 = (num & 0x20) != 0;
			b7 = (num & 0x40) != 0;
		}

		[Obsolete("Use DecodeBitmask with byte as input instead.")]
		public static void DecodeBitmask(float f, out bool b1, out bool b2, out bool b3, out bool b4, out bool b5, out bool b6)
		{
			uint num = (uint)(f * 255f);
			b1 = (num & 1) != 0;
			b2 = (num & 2) != 0;
			b3 = (num & 4) != 0;
			b4 = (num & 8) != 0;
			b5 = (num & 0x10) != 0;
			b6 = (num & 0x20) != 0;
		}

		[Obsolete("Use DecodeBitmask with byte as input instead.")]
		public static void DecodeBitmask(float f, out bool b1, out bool b2, out bool b3, out bool b4, out bool b5)
		{
			uint num = (uint)(f * 255f);
			b1 = (num & 1) != 0;
			b2 = (num & 2) != 0;
			b3 = (num & 4) != 0;
			b4 = (num & 8) != 0;
			b5 = (num & 0x10) != 0;
		}

		[Obsolete("Use DecodeBitmask with byte as input instead.")]
		public static void DecodeBitmask(float f, out bool b1, out bool b2, out bool b3, out bool b4)
		{
			uint num = (uint)(f * 255f);
			b1 = (num & 1) != 0;
			b2 = (num & 2) != 0;
			b3 = (num & 4) != 0;
			b4 = (num & 8) != 0;
		}

		[Obsolete("Use DecodeBitmask with byte as input instead.")]
		public static void DecodeBitmask(float f, out bool b1, out bool b2, out bool b3)
		{
			uint num = (uint)(f * 255f);
			b1 = (num & 1) != 0;
			b2 = (num & 2) != 0;
			b3 = (num & 4) != 0;
		}

		[Obsolete("Use DecodeBitmask with byte as input instead.")]
		public static void DecodeBitmask(float f, out bool b1, out bool b2)
		{
			uint num = (uint)(f * 255f);
			b1 = (num & 1) != 0;
			b2 = (num & 2) != 0;
		}

		[Obsolete("Use DecodeBitmask with byte as input instead.")]
		public static void DecodeBitmask(float f, out bool b1)
		{
			uint num = (uint)(f * 255f);
			b1 = (num & 1) != 0;
		}
	}
}
