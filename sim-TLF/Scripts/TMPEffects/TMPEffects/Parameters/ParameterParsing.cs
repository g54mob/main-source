using System;
using System.Collections.Generic;
using System.Globalization;
using TMPEffects.Databases;
using TMPEffects.Extensions;
using UnityEngine;

namespace TMPEffects.Parameters
{
	public static class ParameterParsing
	{
		private static string TrimIfNeeded(string text)
		{
			if (text.Length == 0)
			{
				return text;
			}
			if (!char.IsWhiteSpace(text[0]))
			{
				if (!char.IsWhiteSpace(text[text.Length - 1]))
				{
					return text;
				}
			}
			return text.Trim();
		}

		public static bool StringToInt(string str, out int result, ITMPKeywordDatabase keywords = null)
		{
			result = 0;
			str = TrimIfNeeded(str);
			if (str.Length == 0)
			{
				return false;
			}
			if (string.IsNullOrWhiteSpace(str))
			{
				return false;
			}
			if (keywords != null && keywords.TryGetInt(str, out result))
			{
				return true;
			}
			int.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
			return true;
		}

		public static bool StringToFloat(string str, out float result, ITMPKeywordDatabase keywords = null)
		{
			result = 0f;
			str = TrimIfNeeded(str);
			if (str.Length == 0)
			{
				return false;
			}
			if (keywords != null && keywords.TryGetFloat(str, out result))
			{
				return true;
			}
			if (float.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				return true;
			}
			return false;
		}

		public static bool StringToBool(string str, out bool result, ITMPKeywordDatabase keywords = null)
		{
			result = false;
			str = TrimIfNeeded(str);
			if (str.Length == 0)
			{
				return false;
			}
			if (keywords != null && keywords.TryGetBool(str, out result))
			{
				return true;
			}
			if (bool.TryParse(str, out result))
			{
				return true;
			}
			return false;
		}

		public static bool StringToVector2(string str, out Vector2 result, ITMPKeywordDatabase keywords = null)
		{
			result = new Vector2(0f, 0f);
			str = TrimIfNeeded(str);
			if (str.Length == 0)
			{
				return false;
			}
			if (keywords != null && keywords.TryGetVector3(str, out var result2))
			{
				result = result2;
				return true;
			}
			Vector2? vector2;
			Vector2? vector = (vector2 = TryParse());
			if (vector.HasValue)
			{
				result = vector2.Value;
				return true;
			}
			return false;
			Vector2? TryParse()
			{
				str = str.Trim();
				if (str.Length <= 3)
				{
					return null;
				}
				if (str[0] != '(')
				{
					return null;
				}
				if (str[str.Length - 1] != ')')
				{
					return null;
				}
				int num = str.IndexOf(',');
				if (num < 2)
				{
					return null;
				}
				if (!StringToFloat(str.Substring(1, num - 1), out var result3, keywords))
				{
					return null;
				}
				if (!StringToFloat(str.Substring(num + 1, str.Length - (num + 2)), out var result4, keywords))
				{
					return null;
				}
				return new Vector2(result3, result4);
			}
		}

		public static bool StringToTypedVector3(string str, out TMPParameterTypes.TypedVector3 result, ITMPKeywordDatabase keywords = null)
		{
			if (StringToVector3(str, out var result2, keywords))
			{
				result = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Position, result2);
				return true;
			}
			if (StringToAnchor(str, out var result3, keywords))
			{
				result = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Anchor, result3);
				return true;
			}
			if (StringToVector3Offset(str, out result2, keywords))
			{
				result = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Offset, result2);
				return true;
			}
			result = default(TMPParameterTypes.TypedVector3);
			return false;
		}

		public static bool StringToTypedVector2(string str, out TMPParameterTypes.TypedVector2 result, ITMPKeywordDatabase keywords = null)
		{
			if (StringToVector2(str, out var result2, keywords))
			{
				result = new TMPParameterTypes.TypedVector2(TMPParameterTypes.VectorType.Position, result2);
				return true;
			}
			if (StringToAnchor(str, out result2, keywords))
			{
				result = new TMPParameterTypes.TypedVector2(TMPParameterTypes.VectorType.Anchor, result2);
				return true;
			}
			if (StringToVector2Offset(str, out result2, keywords))
			{
				result = new TMPParameterTypes.TypedVector2(TMPParameterTypes.VectorType.Offset, result2);
				return true;
			}
			result = default(TMPParameterTypes.TypedVector2);
			return false;
		}

		public static bool StringToVector3(string str, out Vector3 result, ITMPKeywordDatabase keywords = null)
		{
			result = new Vector3(0f, 0f, 0f);
			str = TrimIfNeeded(str);
			if (str.Length == 0)
			{
				return false;
			}
			if (keywords != null && keywords.TryGetVector3(str, out result))
			{
				return true;
			}
			Vector3? vector2;
			Vector3? vector = (vector2 = TryParse());
			if (vector.HasValue)
			{
				result = vector2.Value;
				return true;
			}
			return false;
			Vector3? TryParse()
			{
				str = str.Trim();
				if (str.Length <= 3)
				{
					return null;
				}
				if (str[0] != '(')
				{
					return null;
				}
				if (str[str.Length - 1] != ')')
				{
					return null;
				}
				string[] array = str.Substring(1, str.Length - 2).Split(',');
				if (array.Length < 2 || array.Length > 3)
				{
					return null;
				}
				float result2 = 0f;
				float result3;
				float result4;
				if (array.Length == 2)
				{
					if (!StringToFloat(array[0], out result3, keywords))
					{
						return null;
					}
					if (!StringToFloat(array[1], out result4, keywords))
					{
						return null;
					}
				}
				else
				{
					if (!StringToFloat(array[0], out result3, keywords))
					{
						return null;
					}
					if (!StringToFloat(array[1], out result4, keywords))
					{
						return null;
					}
					if (!StringToFloat(array[2], out result2, keywords))
					{
						return null;
					}
				}
				return new Vector3(result3, result4, result2);
			}
		}

		public static bool StringToVector2Offset(string str, out Vector2 result, ITMPKeywordDatabase keywords = null)
		{
			result = Vector2.zero;
			str = TrimIfNeeded(str);
			if (str.Length == 0)
			{
				return false;
			}
			if (str.Length < 3 || str[0] != 'o' || str[1] != ':')
			{
				return false;
			}
			str = str.Substring(2, str.Length - 2);
			if (StringToVector2(str, out result, keywords))
			{
				return true;
			}
			return false;
		}

		public static bool StringToVector3Offset(string str, out Vector3 result, ITMPKeywordDatabase keywords = null)
		{
			result = Vector3.zero;
			str = TrimIfNeeded(str);
			if (str.Length == 0)
			{
				return false;
			}
			if (str.Length < 3 || str[0] != 'o' || str[1] != ':')
			{
				return false;
			}
			str = str.Substring(2, str.Length - 2);
			if (StringToVector3(str, out result, keywords))
			{
				return true;
			}
			return false;
		}

		public static bool StringToAnchor(string str, out Vector2 result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Vector2);
			str = TrimIfNeeded(str);
			if (str.Length == 0)
			{
				return false;
			}
			if (str.Length < 3 || str[0] != 'a' || str[1] != ':')
			{
				result = Vector3.zero;
				return false;
			}
			if (keywords != null && keywords.TryGetAnchor(str, out result))
			{
				return true;
			}
			str = str.Substring(2, str.Length - 2);
			if (StringToVector2(str, out result, keywords))
			{
				return true;
			}
			return false;
		}

		public static bool StringToAnimCurve(string str, out AnimationCurve result, ITMPKeywordDatabase keywords = null)
		{
			result = null;
			str = TrimIfNeeded(str);
			if (str.Length == 0)
			{
				return false;
			}
			if (keywords != null && keywords.TryGetAnimCurve(str, out result))
			{
				result = new AnimationCurve(result.keys);
				return true;
			}
			if (str[0] == '(')
			{
				return VectorSequenceToAnimationCurve(str, ref result, keywords);
			}
			if (str.Contains('('))
			{
				return MethodToAnimationCurve(str, ref result, keywords);
			}
			return false;
		}

		public static bool StringToUnityObject(string str, out UnityEngine.Object result, ITMPKeywordDatabase keywords = null)
		{
			result = null;
			str = TrimIfNeeded(str);
			if (str.Length == 0)
			{
				return false;
			}
			return keywords?.TryGetUnityObject(str, out result) ?? false;
		}

		public static bool StringToColor(string str, out Color result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Color);
			str = TrimIfNeeded(str);
			if (str.Length == 0)
			{
				return false;
			}
			if (keywords != null && keywords.TryGetColor(str, out result))
			{
				return true;
			}
			if (StringToHexColor(str, out result, keywords))
			{
				return true;
			}
			if (StringToHSVColor(str, out result, keywords))
			{
				return true;
			}
			if (StringToRGBColor(str, out result, keywords))
			{
				return true;
			}
			if (StringToRGBAColor(str, out result, keywords))
			{
				return true;
			}
			return false;
		}

		internal static bool StringToHexInt(string str, out int result, ITMPKeywordDatabase keywords = null)
		{
			try
			{
				result = Convert.ToInt32(str, 16);
				return true;
			}
			catch
			{
				result = 0;
				return keywords?.TryGetInt(str, out result) ?? false;
			}
		}

		internal static bool StringToHexColor(string str, out Color result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Color);
			if (str.Length != 7 && str.Length != 9)
			{
				return false;
			}
			if (str[0] != '#')
			{
				return false;
			}
			if (!StringToHexInt(str.Substring(1, 2), out var result2, keywords))
			{
				return false;
			}
			if (!StringToHexInt(str.Substring(3, 2), out var result3, keywords))
			{
				return false;
			}
			if (!StringToHexInt(str.Substring(5, 2), out var result4, keywords))
			{
				return false;
			}
			if (str.Length == 9)
			{
				if (!StringToHexInt(str.Substring(7, 2), out var result5, keywords))
				{
					return false;
				}
				result = new Color((float)result2 / 255f, (float)result3 / 255f, (float)result4 / 255f, (float)result5 / 255f);
			}
			else
			{
				result = new Color((float)result2 / 255f, (float)result3 / 255f, (float)result4 / 255f);
			}
			return true;
		}

		internal static bool StringToHSVColor(string str, out Color result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Color);
			if (str.Length < 10)
			{
				return false;
			}
			if (str.Substring(0, 3) != "hsv")
			{
				return false;
			}
			if (str[3] != '(')
			{
				return false;
			}
			if (str[str.Length - 1] != ')')
			{
				return false;
			}
			string[] array = str.Substring(4, str.Length - 5).Split(',');
			if (array.Length != 3 && array.Length != 4)
			{
				return false;
			}
			float[] array2 = new float[3];
			for (int i = 0; i < 3; i++)
			{
				if (!StringToFloat(array[i], out var result2, keywords))
				{
					return false;
				}
				array2[i] = result2;
			}
			if (array.Length == 4)
			{
				if (!StringToBool(array[3], out var result3, keywords))
				{
					return false;
				}
				result = Color.HSVToRGB(array2[0], array2[1], array2[2], result3);
			}
			else
			{
				result = Color.HSVToRGB(array2[0], array2[1], array2[2]);
			}
			return true;
		}

		internal static bool StringToRGBColor(string str, out Color result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Color);
			if (str.Length < 10)
			{
				return false;
			}
			if (str.Substring(0, 3) != "rgb")
			{
				return false;
			}
			if (str[3] != '(')
			{
				return false;
			}
			if (str[str.Length - 1] != ')')
			{
				return false;
			}
			string[] array = str.Substring(4, str.Length - 5).Split(',');
			if (array.Length != 3)
			{
				return false;
			}
			float[] array2 = new float[3];
			for (int i = 0; i < 3; i++)
			{
				if (!StringToFloat(array[i], out var result2, keywords))
				{
					return false;
				}
				array2[i] = result2;
			}
			result = new Color(array2[0], array2[1], array2[2]);
			return true;
		}

		internal static bool StringToRGBAColor(string str, out Color result, ITMPKeywordDatabase keywords = null)
		{
			result = default(Color);
			if (str.Length < 11)
			{
				return false;
			}
			if (str.Substring(0, 4) != "rgba")
			{
				return false;
			}
			if (str[4] != '(')
			{
				return false;
			}
			if (str[str.Length - 1] != ')')
			{
				return false;
			}
			string[] array = str.Substring(5, str.Length - 6).Split(',');
			if (array.Length != 4)
			{
				return false;
			}
			float[] array2 = new float[4];
			for (int i = 0; i < 4; i++)
			{
				if (!StringToFloat(array[i], out var result2, keywords))
				{
					return false;
				}
				array2[i] = result2;
			}
			result = new Color(array2[0], array2[1], array2[2], array2[3]);
			return true;
		}

		internal static bool VectorSequenceToAnimationCurve(string str, ref AnimationCurve result, ITMPKeywordDatabase keywords = null)
		{
			List<Vector2> list = new List<Vector2>();
			int num = str.IndexOf('(', 0);
			int num2 = str.IndexOf(')', num);
			if (num == -1 || num2 == -1)
			{
				return false;
			}
			while (num2 < str.Length && num2 != -1)
			{
				if (!StringToVector2(str.Substring(num, num2 + 1 - num), out var result2, keywords))
				{
					return false;
				}
				list.Add(result2);
				num = str.IndexOf('(', num2);
				num2 = ((num != -1) ? str.IndexOf(')', num) : (-1));
			}
			result = AnimationCurveUtility.Bezier(list);
			return true;
		}

		internal static bool MethodToAnimationCurve(string str, ref AnimationCurve result, ITMPKeywordDatabase keywords = null)
		{
			if (str.Length < 4)
			{
				return false;
			}
			List<Vector2> list = new List<Vector2>();
			int num = str.IndexOf("((", 0);
			int num2 = str.IndexOf(')', num);
			if (num == -1 || num2 == -1)
			{
				return false;
			}
			Func<IEnumerable<Vector2>, AnimationCurve> func = AnimationCurveUtility.NameBezierConstructorMapping[str.Substring(0, num)];
			num++;
			if (str[str.Length - 1] != ')' || str[str.Length - 2] != ')')
			{
				return false;
			}
			while (num2 < str.Length && num2 != -1)
			{
				if (!StringToVector2(str.Substring(num, num2 + 1 - num), out var result2, keywords))
				{
					return false;
				}
				list.Add(result2);
				num = str.IndexOf('(', num2);
				num2 = ((num != -1) ? str.IndexOf(')', num) : (-1));
			}
			result = func(list);
			return true;
		}
	}
}
