using System;
using System.Collections.Generic;
using UnityEngine;

namespace JSAM
{
	public static class JSAMExtensions
	{
		public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
		{
			if (val.CompareTo(min) < 0)
			{
				return min;
			}
			if (val.CompareTo(max) > 0)
			{
				return max;
			}
			return val;
		}

		public static bool Contains(this LayerMask mask, int layer)
		{
			return (int)mask == ((int)mask | (1 << layer));
		}

		public static float InverseLerpUnclamped(float min, float max, float value)
		{
			return (value - min) / (max - min);
		}

		public static bool IsNullEmptyOrWhiteSpace(this string input)
		{
			if (!string.IsNullOrEmpty(input))
			{
				return string.IsNullOrWhiteSpace(input);
			}
			return true;
		}

		public static bool TryForComponent<T>(this GameObject obj, out T comp) where T : UnityEngine.Object
		{
			return obj.TryGetComponent<T>(out comp);
		}

		public static bool TryForComponent<T>(this Component obj, out T comp) where T : Component
		{
			return obj.TryGetComponent<T>(out comp);
		}

		public static string ConvertToAlphanumeric(this string input, bool allowPeriods = false)
		{
			char[] array = input.ToCharArray();
			array = ((!allowPeriods) ? Array.FindAll(array, (char c) => char.IsLetterOrDigit(c) || c == '_') : Array.FindAll(array, (char c) => char.IsLetterOrDigit(c) || c == '_' || c == '.'));
			if (array.Length != 0)
			{
				while (char.IsDigit(array[0]) || array[0] == '.')
				{
					new List<char>();
					List<char> list = new List<char>(array);
					list.RemoveAt(0);
					array = list.ToArray();
					if (array.Length == 0)
					{
						break;
					}
				}
				if (array.Length != 0)
				{
					while (array[^1] == '.')
					{
						new List<char>();
						List<char> list2 = new List<char>(array);
						list2.RemoveAt(list2.Count - 1);
						array = list2.ToArray();
						if (array.Length == 0)
						{
							break;
						}
					}
				}
			}
			return new string(array);
		}

		public static Color Add(this Color thisColor, Color otherColor)
		{
			return new Color
			{
				r = Mathf.Clamp01(thisColor.r + otherColor.r),
				g = Mathf.Clamp01(thisColor.g + otherColor.g),
				b = Mathf.Clamp01(thisColor.b + otherColor.g),
				a = Mathf.Clamp01(thisColor.a + otherColor.a)
			};
		}

		public static Color Subtract(this Color thisColor, Color otherColor)
		{
			return new Color
			{
				r = Mathf.Clamp01(thisColor.r - otherColor.r),
				g = Mathf.Clamp01(thisColor.g - otherColor.g),
				b = Mathf.Clamp01(thisColor.b - otherColor.g),
				a = Mathf.Clamp01(thisColor.a - otherColor.a)
			};
		}
	}
}
