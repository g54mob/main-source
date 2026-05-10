using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace NorskaLib.GoogleSheetsDatabase.Utils
{
	public static class Utilities
	{
		public static readonly string[] TrueOptions = new string[2] { "true", "yes" };

		public static readonly string[] FalseOptions = new string[2] { "false", "no" };

		public static string[] Split(string line)
		{
			bool flag = false;
			List<string> list = new List<string>();
			string text = string.Empty;
			for (int i = 0; i < line.Length; i++)
			{
				if (line[i] == '"')
				{
					flag = !flag;
					if (i == line.Length - 1)
					{
						list.Add(text);
					}
				}
				else if (!flag && line[i] == ',')
				{
					list.Add(text);
					text = string.Empty;
				}
				else
				{
					text += line[i];
				}
			}
			return list.ToArray();
		}

		public static object Parse(string s, Type type)
		{
			bool error;
			return Parse(s, type, out error);
		}

		public static object Parse(string s, Type type, out bool error)
		{
			error = false;
			if (type == typeof(string))
			{
				return s;
			}
			if (type == typeof(int))
			{
				return ParseInt(s, out error);
			}
			if (type == typeof(float))
			{
				return ParseFloat(s, out error);
			}
			if (type == typeof(bool))
			{
				return ParseBool(s, out error);
			}
			if (type.IsEnum)
			{
				object result;
				try
				{
					result = Enum.Parse(type, s, ignoreCase: true);
				}
				catch (ArgumentException)
				{
					result = null;
					error = false;
				}
				return result;
			}
			return null;
		}

		public static int ParseInt(string s, out bool error)
		{
			error = !int.TryParse(s, out var result);
			if (error)
			{
				Debug.LogWarning("Error at parsing '" + s + "' to Integer");
			}
			if (!error)
			{
				return result;
			}
			return 0;
		}

		public static bool ParseBool(string s, out bool error)
		{
			s = s.ToLower();
			error = false;
			for (int i = 0; i < TrueOptions.Length; i++)
			{
				if (s == TrueOptions[i])
				{
					return true;
				}
				if (s == FalseOptions[i])
				{
					return false;
				}
			}
			error = true;
			return false;
		}

		public static float ParseFloat(string s, out bool error)
		{
			error = !float.TryParse(s.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out var result);
			return result;
		}
	}
}
