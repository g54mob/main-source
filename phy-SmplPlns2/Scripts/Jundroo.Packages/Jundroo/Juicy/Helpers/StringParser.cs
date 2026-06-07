using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using DG.Tweening;
using Jundroo.Juicy.Widgets.Extra;
using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.Juicy.Helpers
{
	public class StringParser
	{
		private static char[] _separators = new char[2] { ' ', ',' };

		public static AnimationData ToAnimationData(string s)
		{
			AnimationData animationData = new AnimationData();
			string[] array = s.Split(':', StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 2)
			{
				animationData.Target = array[0];
				string[] array2 = SplitString(array[1]);
				animationData.Ease = ((array2.Length != 0) ? Enum.Parse<EaseType>(array2[0]) : EaseType.Unset);
				animationData.Duration = ((array2.Length > 1) ? ToFloat(array2[1]) : 0.5f);
				animationData.Delay = ((array2.Length > 2) ? ToFloat(array2[2]) : 0f);
				animationData.Overshoot = ((array2.Length > 3) ? ToFloat(array2[3]) : 1f);
				animationData.NumLoops = ((array2.Length > 4) ? ToInt(array2[4]) : 0);
				animationData.LoopType = ((array2.Length <= 5) ? LoopType.Yoyo : ToEnum<LoopType>(array2[5]));
				animationData.From = ((array2.Length > 6) ? array2[6] : null);
			}
			return animationData;
		}

		public static bool ToBool(string value, bool defaultValue)
		{
			return DataIO.ParseBool(value, defaultValue);
		}

		public static Color ToColor(string s)
		{
			if (s.StartsWith("#"))
			{
				s = s.Substring(1);
				byte r = byte.Parse(s.Substring(0, 2), NumberStyles.HexNumber);
				byte g = byte.Parse(s.Substring(2, 2), NumberStyles.HexNumber);
				byte b = byte.Parse(s.Substring(4, 2), NumberStyles.HexNumber);
				byte a = ((s.Length > 6) ? byte.Parse(s.Substring(6, 2), NumberStyles.HexNumber) : byte.MaxValue);
				if (s.Length >= 8)
				{
					a = byte.Parse(s.Substring(6, 2), NumberStyles.HexNumber);
				}
				return new Color32(r, g, b, a);
			}
			if (s == "None")
			{
				return new Color(0f, 0f, 0f, 0f);
			}
			PropertyInfo property = typeof(Color).GetProperty(s.ToLower());
			if (property?.PropertyType == typeof(Color))
			{
				return (Color)property.GetValue(null, BindingFlags.Instance | BindingFlags.Public, null, null, null);
			}
			Debug.LogWarning("Unknown color value " + s);
			return Color.white;
		}

		public static ColorBlock ToColorBlock(string s)
		{
			string[] array = SplitString(s);
			return new ColorBlock
			{
				normalColor = ((array.Length != 0) ? ToColor(array[0]) : Color.white),
				highlightedColor = ((array.Length > 1) ? ToColor(array[1]) : Color.white),
				pressedColor = ((array.Length > 2) ? ToColor(array[2]) : Color.white),
				selectedColor = ((array.Length > 3) ? ToColor(array[3]) : Color.white),
				disabledColor = ((array.Length > 4) ? ToColor(array[4]) : Color.white),
				colorMultiplier = ((array.Length > 5) ? ToFloat(array[5]) : 1f),
				fadeDuration = ((array.Length > 6) ? ToFloat(array[6]) : 0.1f)
			};
		}

		public static T ToEnum<T>(string s)
		{
			return (T)Enum.Parse(typeof(T), s);
		}

		public static float ToFloat(string s, float defaultValue = 0f)
		{
			return DataIO.ParseFloat(s, defaultValue);
		}

		public static int ToInt(string s, int defaultValue = 0)
		{
			if (DataIO.TryParseInt(s, out var value))
			{
				return value;
			}
			return defaultValue;
		}

		public static List<int> ToIntList(string s)
		{
			List<int> list = new List<int>();
			if (!string.IsNullOrEmpty(s))
			{
				string[] array = SplitString(s);
				foreach (string s2 in array)
				{
					list.Add(ToInt(s2));
				}
			}
			return list;
		}

		public static RectOffset ToRectOffset(string s)
		{
			List<int> list = ToIntList(s);
			int left = 0;
			int right = 0;
			int top = 0;
			int bottom = 0;
			if (list.Count == 1)
			{
				left = (right = (top = (bottom = list[0])));
			}
			else if (list.Count == 2)
			{
				top = (bottom = list[0]);
				left = (right = list[1]);
			}
			else if (list.Count == 4)
			{
				top = list[0];
				right = list[1];
				bottom = list[2];
				left = list[3];
			}
			return new RectOffset(left, right, top, bottom);
		}

		public static SoundData ToSoundData(string s)
		{
			string[] array = SplitString(s);
			return new SoundData
			{
				Path = ((array.Length != 0) ? array[0] : null),
				Volume = ((array.Length > 1) ? ToFloat(array[1]) : 1f),
				PitchVariation = ((array.Length > 2) ? ToFloat(array[2]) : 0.1f),
				MinimumDelay = ((array.Length > 3) ? ToFloat(array[3]) : 0f),
				Priority = ((array.Length > 4) ? ToInt(array[4]) : 0)
			};
		}

		public static Vector2 ToVector2(string s, Vector2 defaultValue)
		{
			if (string.IsNullOrEmpty(s))
			{
				return defaultValue;
			}
			string[] array = SplitString(s);
			if (array.Length == 2)
			{
				return new Vector2(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]));
			}
			if (array.Length == 1)
			{
				float num = DataIO.ParseFloat(array[0]);
				return new Vector2(num, num);
			}
			return defaultValue;
		}

		public static Vector3 ToVector3(string s, Vector3 defaultValue)
		{
			if (string.IsNullOrEmpty(s))
			{
				return defaultValue;
			}
			string[] array = SplitString(s);
			if (array.Length == 3)
			{
				return new Vector3(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]));
			}
			if (array.Length == 1)
			{
				float num = DataIO.ParseFloat(array[0]);
				return new Vector3(num, num, num);
			}
			return defaultValue;
		}

		private static string[] SplitString(string s)
		{
			return s.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
		}
	}
}
