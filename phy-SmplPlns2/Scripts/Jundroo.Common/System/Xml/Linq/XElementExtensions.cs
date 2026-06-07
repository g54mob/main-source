using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Jundroo.Common.Extensions;
using Jundroo.Common.Math;
using Jundroo.Common.Utils;
using Unity.Mathematics;
using UnityEngine;

namespace System.Xml.Linq
{
	public static class XElementExtensions
	{
		private static readonly char[] _stringSplitBar = new char[1] { '|' };

		private static readonly char[] _stringSplitComma = new char[1] { ',' };

		private static readonly string[] _stringSplitDoubleBar = new string[1] { "||" };

		private static char[] _vectorParseTrimChars = new char[2] { '(', ')' };

		public static XElement AddElement(this XElement element, XName elementName)
		{
			XElement xElement = new XElement(elementName);
			element.Add(xElement);
			return xElement;
		}

		public static ReadOnlySpan<char> AttributeAsSpan(this XElement element, string attributeName)
		{
			return ((string)element.Attribute(attributeName)).AsSpan();
		}

		public static AnimationCurve GetAnimationCurveAttribute(this XElement element, string attributeName, AnimationCurve defaultValue = null)
		{
			string text = (string)element.Attribute(attributeName);
			if (string.IsNullOrEmpty(text))
			{
				return defaultValue;
			}
			return new AnimationCurve((from x in text.Split('|')
				select x.Split(',').ToArray()).Select(delegate(string[] x)
			{
				Keyframe result = new Keyframe(DataIO.ParseFloat(x[0]), DataIO.ParseFloat(x[1]), DataIO.ParseFloat(x[2]), DataIO.ParseFloat(x[3]));
				if (x.Length == 4)
				{
					return result;
				}
				result.inWeight = DataIO.ParseFloat(x[4]);
				result.outWeight = DataIO.ParseFloat(x[5]);
				result.weightedMode = (WeightedMode)DataIO.ParseInt(x[6]);
				result.tangentMode = DataIO.ParseInt(x[7]);
				return result;
			}).ToArray());
		}

		public static void GetArrayElements<T>(this XElement element, string elementNames, T[] array, Func<XElement, T> getValue, Func<T, T> getDefaultValue = null)
		{
			int num = 0;
			T arg = default(T);
			foreach (XElement item in element.Elements(elementNames))
			{
				arg = (array[num++] = getValue(item));
				if (num == array.Length)
				{
					return;
				}
			}
			if (getDefaultValue != null)
			{
				while (num < array.Length)
				{
					array[num++] = getDefaultValue(arg);
				}
			}
		}

		public static T[] GetArrayElements<T>(this XElement element, string elementNames, int size, Func<XElement, T> getValue, Func<T, T> getDefaultValue = null)
		{
			T[] array = new T[size];
			element.GetArrayElements(elementNames, array, getValue, getDefaultValue);
			return array;
		}

		public static bool2 GetBool2Attribute(this XElement element, string attributeName, bool2 defaultValue = default(bool2))
		{
			return DataIO.ParseBool2((string)element.Attribute(attributeName), defaultValue);
		}

		public static bool3 GetBool3Attribute(this XElement element, string attributeName, bool3 defaultValue = default(bool3))
		{
			return DataIO.ParseBool3((string)element.Attribute(attributeName), defaultValue);
		}

		public static bool4 GetBool4Attribute(this XElement element, string attributeName, bool4 defaultValue = default(bool4))
		{
			return DataIO.ParseBool4((string)element.Attribute(attributeName), defaultValue);
		}

		public static bool GetBoolAttribute(this XElement element, string attributeName, bool defaultValue = false)
		{
			return ((bool?)element.Attribute(attributeName)) ?? defaultValue;
		}

		public static bool? GetBoolAttributeOrNull(this XElement element, string attributeName)
		{
			return (bool?)element.Attribute(attributeName);
		}

		public static void GetColor32ArrayAttribute(this XElement element, string attributeName, ColorStringFormat format, Color32[] array, Color32? defaultValue, char characterSeparator = ',')
		{
			int num = 0;
			Color32 color = defaultValue ?? new Color32(0, 0, 0, 1);
			ReadOnlySpan<char> value = ((string)element.Attribute(attributeName)).AsSpan();
			if (value.Length > 0)
			{
				StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, characterSeparator).GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (ColorsUtility.TryParse32(enumerator.Current.Span, format, out var color2))
					{
						array[num++] = color2;
						if (num == array.Length)
						{
							return;
						}
						if (!defaultValue.HasValue)
						{
							color = color2;
						}
					}
				}
			}
			for (int i = num; i < array.Length; i++)
			{
				array[i] = color;
			}
		}

		public static Color32[] GetColor32ArrayAttribute(this XElement element, string attributeName, ColorStringFormat format, int size, Color32? defaultValue, char characterSeparator = ',')
		{
			Color32[] array = new Color32[size];
			element.GetColor32ArrayAttribute(attributeName, format, array, defaultValue, characterSeparator);
			return array;
		}

		public static void GetColorArrayAttribute(this XElement element, string attributeName, ColorStringFormat format, Color[] array, Color? defaultValue, char characterSeparator = ',')
		{
			int num = 0;
			Color color = defaultValue ?? new Color(0f, 0f, 0f, 1f);
			ReadOnlySpan<char> value = ((string)element.Attribute(attributeName)).AsSpan();
			if (value.Length > 0)
			{
				StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, characterSeparator).GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (ColorsUtility.TryParse(enumerator.Current.Span, format, out var color2))
					{
						array[num++] = color2;
						if (num == array.Length)
						{
							return;
						}
						if (!defaultValue.HasValue)
						{
							color = color2;
						}
					}
				}
			}
			for (int i = num; i < array.Length; i++)
			{
				array[i] = color;
			}
		}

		public static Color[] GetColorArrayAttribute(this XElement element, string attributeName, ColorStringFormat format, int size, Color? defaultValue, char characterSeparator = ',')
		{
			Color[] array = new Color[size];
			element.GetColorArrayAttribute(attributeName, format, array, defaultValue, characterSeparator);
			return array;
		}

		public static Color? GetColorAttribute(this XElement element, string attributeName, ColorStringFormat format = ColorStringFormat.FloatRGBA)
		{
			if (!ColorsUtility.TryParse(((string)element.Attribute(attributeName)).AsSpan(), format, out var color))
			{
				return null;
			}
			return color;
		}

		public static Color GetColorAttribute(this XElement element, string attributeName, Color defaultValue, ColorStringFormat format = ColorStringFormat.FloatRGBA)
		{
			return element.GetColorAttribute(attributeName, format) ?? defaultValue;
		}

		public static DateTime GetDateTimeAttribute(this XElement element, string attributeName, DateTime defaultValue)
		{
			return ((DateTime?)element.Attribute(attributeName)) ?? defaultValue;
		}

		public static DateTime? GetDateTimeAttributeOrNull(this XElement element, string attributeName)
		{
			return (DateTime?)element.Attribute(attributeName);
		}

		public static void GetDecimalArrayAttribute(this XElement element, string attributeName, decimal[] array, decimal? defaultValue = 0m, char characterSeparator = ',')
		{
			int num = 0;
			decimal num2 = defaultValue.GetValueOrDefault();
			ReadOnlySpan<char> value = ((string)element.Attribute(attributeName)).AsSpan();
			if (value.Length > 0)
			{
				StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, characterSeparator).GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (DataIO.TryParseDecimal(enumerator.Current.Span, out var value2))
					{
						array[num++] = value2;
						if (num == array.Length)
						{
							return;
						}
						if (!defaultValue.HasValue)
						{
							num2 = value2;
						}
					}
				}
			}
			for (int i = num; i < array.Length; i++)
			{
				array[i] = num2;
			}
		}

		public static decimal GetDecimalAttribute(this XElement element, string attributeName, decimal defaultValue = 0m)
		{
			return ((decimal?)element.Attribute(attributeName)) ?? defaultValue;
		}

		public static decimal? GetDecimalAttributeOrNull(this XElement element, string attributeName)
		{
			return (decimal?)element.Attribute(attributeName);
		}

		public static double GetDoubleAttribute(this XElement element, string attributeName, double defaultValue = 0.0)
		{
			return ((double?)element.Attribute(attributeName)) ?? defaultValue;
		}

		public static double? GetDoubleAttributeOrNull(this XElement element, string attributeName)
		{
			return (double?)element.Attribute(attributeName);
		}

		public static T[] GetEnumArrayAttribute<T>(this XElement element, string attributeName, int size, T? defaultValue = null, char characterSeparator = ',') where T : struct, Enum
		{
			T[] array = new T[size];
			element.GetEnumArrayAttribute(attributeName, array, defaultValue, characterSeparator);
			return array;
		}

		public static void GetEnumArrayAttribute<T>(this XElement element, string attributeName, T[] array, T? defaultValue = null, char characterSeparator = ',') where T : struct, Enum
		{
			int num = 0;
			T val = defaultValue.GetValueOrDefault();
			ReadOnlySpan<char> value = ((string)element.Attribute(attributeName)).AsSpan();
			if (value.Length > 0)
			{
				StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, characterSeparator).GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (EnumUtility<T>.TryParse(enumerator.Current.Span, ignoreCase: true, out var result))
					{
						array[num++] = result;
						if (num == array.Length)
						{
							return;
						}
						if (!defaultValue.HasValue)
						{
							val = result;
						}
					}
				}
			}
			for (int i = num; i < array.Length; i++)
			{
				array[i] = val;
			}
		}

		public static T GetEnumAttribute<T>(this XElement xml, string attributeName, T defaultValue = default(T), T[] options = null) where T : struct
		{
			string text = (string)xml.Attribute(attributeName);
			if (text != null)
			{
				T val = (T)Enum.Parse(typeof(T), text, ignoreCase: true);
				if (options == null || options.Contains(val))
				{
					return val;
				}
			}
			return defaultValue;
		}

		public static T? GetEnumAttributeOrNull<T>(this XElement xml, string attributeName, T[] options = null) where T : struct
		{
			string text = (string)xml.Attribute(attributeName);
			if (text != null)
			{
				T value = (T)Enum.Parse(typeof(T), text, ignoreCase: true);
				if (options == null || options.Contains(value))
				{
					return value;
				}
			}
			return null;
		}

		public static List<T> GetEnumListAttribute<T>(this XElement element, string attributeName, T defaultValue, char characterSeparator = ',') where T : struct, Enum
		{
			List<T> list = new List<T>();
			ReadOnlySpan<char> value = ((string)element.Attribute(attributeName)).AsSpan();
			if (value.Length > 0)
			{
				StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, characterSeparator).GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (EnumUtility<T>.TryParse(enumerator.Current.Span, ignoreCase: true, out var result))
					{
						list.Add(result);
					}
				}
			}
			if (list.Count == 0)
			{
				list.Add(defaultValue);
			}
			return list;
		}

		public static void GetFloatArrayAttribute(this XElement element, string attributeName, float[] array, float? defaultValue = 0f, char characterSeparator = ',')
		{
			int num = 0;
			float num2 = defaultValue.GetValueOrDefault();
			ReadOnlySpan<char> value = ((string)element.Attribute(attributeName)).AsSpan();
			if (value.Length > 0)
			{
				StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, characterSeparator).GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (DataIO.TryParseFloat(enumerator.Current.Span, out var value2))
					{
						array[num++] = value2;
						if (num == array.Length)
						{
							return;
						}
						if (!defaultValue.HasValue)
						{
							num2 = value2;
						}
					}
				}
			}
			for (int i = num; i < array.Length; i++)
			{
				array[i] = num2;
			}
		}

		public static float[] GetFloatArrayAttribute(this XElement element, string attributeName, int size, float? defaultValue = 0f, char characterSeparator = ',')
		{
			float[] array = new float[size];
			element.GetFloatArrayAttribute(attributeName, array, defaultValue, characterSeparator);
			return array;
		}

		public static int GetFloatArrayAttributeWithLastParsedValueFallback(XElement element, string attributeName, Span<float> array, float defaultValue = 0f, char characterSeparator = ',')
		{
			int num = 0;
			ReadOnlySpan<char> value = ((string)element.Attribute(attributeName)).AsSpan();
			if (value.Length > 0)
			{
				StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, characterSeparator).GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (DataIO.TryParseFloat(enumerator.Current.Span, out var value2))
					{
						array[num++] = value2;
						if (num == array.Length)
						{
							return num;
						}
						defaultValue = value2;
					}
				}
			}
			for (int i = num; i < array.Length; i++)
			{
				array[i] = defaultValue;
			}
			return num;
		}

		public static float GetFloatAttribute(this XElement element, string attributeName, float defaultValue = 0f)
		{
			return ((float?)element.Attribute(attributeName)) ?? defaultValue;
		}

		public static float? GetFloatAttributeOrNull(this XElement element, string attributeName)
		{
			return (float?)element.Attribute(attributeName);
		}

		public static List<float> GetFloatListAttribute(this XElement element, string attributeName, char characterSeparator = ',')
		{
			List<float> list = null;
			ReadOnlySpan<char> value = ((string)element.Attribute(attributeName)).AsSpan();
			if (value.Length > 0)
			{
				list = new List<float>(value.CharacterCount(characterSeparator) + 1);
				StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, characterSeparator).GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (DataIO.TryParseFloat(enumerator.Current.Span, out var value2))
					{
						list.Add(value2);
					}
				}
			}
			return list ?? new List<float>(0);
		}

		public static Gradient GetGradientAttribute(this XElement element, string attributeName, bool includeAlphaKeys, Gradient defaultValue = null)
		{
			Gradient gradient = null;
			string text = (string)element.Attribute(attributeName);
			if (text == null)
			{
				if (defaultValue != null)
				{
					gradient = new Gradient();
					gradient.mode = defaultValue.mode;
					gradient.SetKeys(defaultValue.colorKeys, defaultValue.alphaKeys);
				}
			}
			else
			{
				gradient = new Gradient();
				string[] array = text.Split(_stringSplitDoubleBar, StringSplitOptions.None);
				string[] array2 = array[0].Split(_stringSplitBar, StringSplitOptions.RemoveEmptyEntries);
				GradientColorKey[] array3 = new GradientColorKey[array2.Length];
				for (int i = 0; i < array3.Length; i++)
				{
					string[] array4 = array2[i].Split(_stringSplitComma);
					array3[i] = new GradientColorKey(new Color(DataIO.ParseFloat(array4[1]), DataIO.ParseFloat(array4[2]), DataIO.ParseFloat(array4[3])), DataIO.ParseFloat(array4[0]));
				}
				if (includeAlphaKeys && array.Length > 1)
				{
					string[] array5 = array[1].Split(_stringSplitBar, StringSplitOptions.RemoveEmptyEntries);
					GradientAlphaKey[] array6 = new GradientAlphaKey[array2.Length];
					for (int j = 0; j < array6.Length; j++)
					{
						string[] array7 = array5[j].Split(_stringSplitComma);
						array6[j] = new GradientAlphaKey(DataIO.ParseFloat(array7[1]), DataIO.ParseFloat(array7[0]));
					}
					gradient.SetKeys(array3, array6);
				}
				else
				{
					gradient.SetKeys(array3, new GradientAlphaKey[0]);
				}
			}
			return gradient;
		}

		public static Guid GetGuidAttribute(this XElement element, string attributeName, Guid defaultValue)
		{
			return ((Guid?)element.Attribute(attributeName)) ?? defaultValue;
		}

		public static Guid? GetGuidAttributeOrNull(this XElement element, string attributeName)
		{
			return (Guid?)element.Attribute(attributeName);
		}

		public static Color GetHtmlColorAttribute(this XElement element, string attributeName, Color defaultValue)
		{
			return element.GetColorAttribute(attributeName, ColorStringFormat.HexRGBA) ?? defaultValue;
		}

		public static Color? GetHtmlColorAttributeOrNull(this XElement element, string attributeName)
		{
			return element.GetColorAttribute(attributeName, ColorStringFormat.HexRGBA);
		}

		public static int2 GetInt2Attribute(this XElement element, string attributeName, int2 defaultValue = default(int2))
		{
			return DataIO.ParseInt2((string)element.Attribute(attributeName), defaultValue);
		}

		public static int3 GetInt3Attribute(this XElement element, string attributeName, int3 defaultValue = default(int3))
		{
			return DataIO.ParseInt3((string)element.Attribute(attributeName), defaultValue);
		}

		public static int4 GetInt4Attribute(this XElement element, string attributeName, int4 defaultValue = default(int4))
		{
			return DataIO.ParseInt4((string)element.Attribute(attributeName), defaultValue);
		}

		public static int GetIntAttribute(this XElement element, string attributeName, int defaultValue = 0, bool suppressExceptions = false)
		{
			try
			{
				return ((int?)element.Attribute(attributeName)) ?? defaultValue;
			}
			catch (Exception)
			{
				if (suppressExceptions)
				{
					return defaultValue;
				}
				throw;
			}
		}

		public static int? GetIntAttributeOrNull(this XElement element, string attributeName)
		{
			return (int?)element.Attribute(attributeName);
		}

		public static List<int> GetIntListAttribute(this XElement element, string attributeName, char characterSeparator = ',')
		{
			List<int> list = null;
			ReadOnlySpan<char> value = ((string)element.Attribute(attributeName)).AsSpan();
			if (value.Length > 0)
			{
				list = new List<int>(value.CharacterCount(characterSeparator) + 1);
				StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(value, characterSeparator).GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (DataIO.TryParseInt(enumerator.Current.Span, out var value2))
					{
						list.Add(value2);
					}
				}
			}
			return list ?? new List<int>(0);
		}

		public static long GetLongAttribute(this XElement element, string attributeName, long defaultValue = 0L)
		{
			return ((long?)element.Attribute(attributeName)) ?? defaultValue;
		}

		public static long? GetLongAttributeOrNull(this XElement element, string attributeName)
		{
			return (long?)element.Attribute(attributeName);
		}

		public static XAttribute GetOrCreateAttribute(this XElement element, string attributeName)
		{
			XAttribute xAttribute = element.Attribute(attributeName);
			if (xAttribute == null)
			{
				xAttribute = new XAttribute(attributeName, string.Empty);
				element.Add(xAttribute);
			}
			return xAttribute;
		}

		public static XElement GetOrCreateElement(this XElement element, string elementName)
		{
			XElement xElement = element.Element(elementName);
			if (xElement == null)
			{
				xElement = new XElement(elementName);
				element.Add(xElement);
			}
			return xElement;
		}

		public static Quaternion GetQuaternionAttribute(this XElement element, string attributeName, Quaternion defaultValue = default(Quaternion))
		{
			string text = (string)element.Attribute(attributeName);
			if (string.IsNullOrEmpty(text))
			{
				return defaultValue;
			}
			string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length != 4)
			{
				return defaultValue;
			}
			return new Quaternion(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]), DataIO.ParseFloat(array[3]));
		}

		public static Quaternion? GetQuaternionAttributeOrNull(this XElement element, string attributeName)
		{
			string text = (string)element.Attribute(attributeName);
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length != 4)
			{
				return null;
			}
			return new Quaternion(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]), DataIO.ParseFloat(array[3]));
		}

		public static Quaterniond GetQuaterniondAttribute(this XElement element, string attributeName, Quaterniond defaultValue = default(Quaterniond))
		{
			string text = (string)element.Attribute(attributeName);
			if (string.IsNullOrEmpty(text))
			{
				return defaultValue;
			}
			string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length != 4)
			{
				return defaultValue;
			}
			return new Quaterniond(DataIO.ParseDouble(array[0]), DataIO.ParseDouble(array[1]), DataIO.ParseDouble(array[2]), DataIO.ParseDouble(array[3]));
		}

		public static Quaterniond? GetQuaterniondAttributeOrNull(this XElement element, string attributeName)
		{
			string text = (string)element.Attribute(attributeName);
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length != 4)
			{
				return null;
			}
			return new Quaterniond(DataIO.ParseDouble(array[0]), DataIO.ParseDouble(array[1]), DataIO.ParseDouble(array[2]), DataIO.ParseDouble(array[3]));
		}

		public static RangeFloat GetRangeFloatAttribute(this XElement element, string attributeName, RangeFloat defaultValue = default(RangeFloat))
		{
			return DataIO.ParseRangeFloat((string)element.Attribute(attributeName), defaultValue);
		}

		public static RangeFloat? GetRangeFloatAttributeOrNull(this XElement element, string attributeName)
		{
			return DataIO.TryParseRangeFloat((string)element.Attribute(attributeName));
		}

		public static RangeInteger GetRangeIntegerAttribute(this XElement element, string attributeName, RangeInteger defaultValue = default(RangeInteger))
		{
			return DataIO.ParseRangeInteger((string)element.Attribute(attributeName), defaultValue);
		}

		public static RangeInteger? GetRangeIntegerAttributeOrNull(this XElement element, string attributeName)
		{
			return DataIO.TryParseRangeInteger((string)element.Attribute(attributeName));
		}

		public static string GetStringAttribute(this XElement element, string attributeName, string defaultValue = null)
		{
			return ((string)element.Attribute(attributeName)) ?? defaultValue;
		}

		public static string GetStringAttributeOrNullIfEmpty(this XElement element, string attributeName)
		{
			string text = (string)element.Attribute(attributeName);
			if (!(text == string.Empty))
			{
				return text;
			}
			return null;
		}

		public static string GetStringAttributeOrNullIfWhitespace(this XElement element, string attributeName)
		{
			string text = (string)element.Attribute(attributeName);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
			return null;
		}

		public static string GetStringElement(this XElement element, string childElementName, string defaultValue)
		{
			return element?.Element(childElementName)?.Value ?? defaultValue;
		}

		public static string GetStringElement(this XElement element, string defaultValue = null)
		{
			return element?.Value ?? defaultValue;
		}

		public static string GetStringElementOrNullIfEmpty(this XElement element, string childElementName)
		{
			string text = element?.Element(childElementName)?.Value;
			if (!(text == string.Empty))
			{
				return text;
			}
			return null;
		}

		public static string GetStringElementOrNullIfEmpty(this XElement element)
		{
			string text = element?.Value;
			if (!(text == string.Empty))
			{
				return text;
			}
			return null;
		}

		public static string GetStringElementOrNullIfWhitespace(this XElement element, string childElementName)
		{
			string text = element?.Element(childElementName)?.Value;
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
			return null;
		}

		public static string GetStringElementOrNullIfWhitespace(this XElement element)
		{
			string text = element?.Value;
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
			return null;
		}

		public static List<string> GetStringListAttribute(this XElement element, string attributeName, char separatorCharacter = ',')
		{
			string text = (string)element.Attribute(attributeName);
			if (string.IsNullOrEmpty(text))
			{
				return new List<string>(0);
			}
			return new List<string>(text.Split(separatorCharacter, StringSplitOptions.RemoveEmptyEntries));
		}

		public static uint GetUintAttribute(this XElement element, string attributeName, uint defaultValue = 0u)
		{
			return ((uint?)element.Attribute(attributeName)) ?? defaultValue;
		}

		public static uint? GetUintAttributeOrNull(this XElement element, string attributeName)
		{
			return (uint?)element.Attribute(attributeName);
		}

		public static Vector2 GetVector2Attribute(this XElement element, string attributeName, Vector2 defaultValue = default(Vector2))
		{
			return DataIO.ParseVector2((string)element.Attribute(attributeName), defaultValue);
		}

		public static Vector2? GetVector2AttributeOrNull(this XElement element, string attributeName)
		{
			return DataIO.TryParseVector2((string)element.Attribute(attributeName));
		}

		public static Vector2 GetVector2AttributeWithLastParsedValueFallback(this XElement element, string attributeName, float defaultValue = 0f)
		{
			Span<float> array = stackalloc float[2];
			GetFloatArrayAttributeWithLastParsedValueFallback(element, attributeName, array, defaultValue);
			return new Vector2(array[0], array[1]);
		}

		public static Vector2d GetVector2dAttribute(this XElement element, string attributeName, Vector2d defaultValue = default(Vector2d))
		{
			return DataIO.ParseVector2d((string)element.Attribute(attributeName), defaultValue);
		}

		public static Vector2d? GetVector2dAttributeOrNull(this XElement element, string attributeName)
		{
			return DataIO.TryParseVector2d((string)element.Attribute(attributeName));
		}

		public static Vector3 GetVector3Attribute(this XElement element, string attributeName, Vector3 defaultValue = default(Vector3))
		{
			return DataIO.ParseVector3((string)element.Attribute(attributeName), defaultValue);
		}

		public static Vector3? GetVector3AttributeOrNull(this XElement element, string attributeName)
		{
			return DataIO.TryParseVector3((string)element.Attribute(attributeName));
		}

		public static Vector3 GetVector3AttributeWithLastParsedValueFallback(this XElement element, string attributeName, float defaultValue = 0f)
		{
			Span<float> array = stackalloc float[3];
			GetFloatArrayAttributeWithLastParsedValueFallback(element, attributeName, array, defaultValue);
			return new Vector3(array[0], array[1], array[2]);
		}

		public static Vector3d GetVector3dAttribute(this XElement element, string attributeName, Vector3d defaultValue = default(Vector3d))
		{
			return DataIO.ParseVector3d((string)element.Attribute(attributeName), defaultValue);
		}

		public static Vector3d? GetVector3dAttributeOrNull(this XElement element, string attributeName)
		{
			return DataIO.TryParseVector3d((string)element.Attribute(attributeName));
		}

		public static Vector4 GetVector4Attribute(this XElement element, string attributeName, Vector4 defaultValue = default(Vector4))
		{
			return DataIO.ParseVector4((string)element.Attribute(attributeName), defaultValue);
		}

		public static Vector4m GetVector4mAttribute(this XElement element, string attributeName, Vector4m defaultValue = default(Vector4m))
		{
			return DataIO.ParseVector4m((string)element.Attribute(attributeName), defaultValue);
		}

		public static Vector4? GetVector4AttributeOrNull(this XElement element, string attributeName)
		{
			return DataIO.TryParseVector4((string)element.Attribute(attributeName));
		}

		public static Vector4 GetVector4AttributeWithLastParsedValueFallback(this XElement element, string attributeName, float defaultValue = 0f)
		{
			Span<float> array = stackalloc float[4];
			GetFloatArrayAttributeWithLastParsedValueFallback(element, attributeName, array, defaultValue);
			return new Vector4(array[0], array[1], array[2], array[4]);
		}

		public static Vector4d GetVector4dAttribute(this XElement element, string attributeName, Vector4d defaultValue = default(Vector4d))
		{
			return DataIO.ParseVector4d((string)element.Attribute(attributeName), defaultValue);
		}

		public static Vector4d? GetVector4dAttributeOrNull(this XElement element, string attributeName)
		{
			return DataIO.TryParseVector4d((string)element.Attribute(attributeName));
		}

		public static Version GetVersionAttribute(this XElement element, string attributeName, Version defaultValue = null)
		{
			string text = (string)element.Attribute(attributeName);
			if (!string.IsNullOrEmpty(text))
			{
				return new Version(text);
			}
			return defaultValue;
		}

		public static void SetAttribute(this XElement element, string attributeName, Gradient value, bool includeAlphaKeys)
		{
			StringBuilder stringBuilder = new StringBuilder();
			GradientColorKey[] colorKeys = value.colorKeys;
			for (int i = 0; i < colorKeys.Length; i++)
			{
				if (i != 0)
				{
					stringBuilder.Append('|');
				}
				GradientColorKey gradientColorKey = colorKeys[i];
				stringBuilder.AppendFormat(DataIO.Culture, "{0},{1},{2},{3}", gradientColorKey.time, gradientColorKey.color.r, gradientColorKey.color.g, gradientColorKey.color.b);
			}
			if (includeAlphaKeys)
			{
				stringBuilder.Append("||");
				GradientAlphaKey[] alphaKeys = value.alphaKeys;
				for (int j = 0; j < alphaKeys.Length; j++)
				{
					if (j != 0)
					{
						stringBuilder.Append('|');
					}
					GradientAlphaKey gradientAlphaKey = alphaKeys[j];
					stringBuilder.AppendFormat(DataIO.Culture, "{0},{1}", gradientAlphaKey.time, gradientAlphaKey.alpha);
				}
			}
			element.SetAttributeValue(attributeName, stringBuilder.ToString());
		}

		public static void SetAttribute(this XElement element, string attributeName, Vector3 value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z));
		}

		public static void SetAttribute(this XElement element, string attributeName, Vector4 value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w));
		}

		public static void SetAttribute(this XElement element, string attributeName, Vector4m value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w));
		}

		public static void SetAttribute(this XElement element, string attributeName, Vector3d value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z));
		}

		public static void SetAttribute(this XElement element, string attributeName, Vector4d value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w));
		}

		public static void SetAttribute(this XElement element, string attributeName, Quaternion value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w));
		}

		public static void SetAttribute(this XElement element, string attributeName, int2 value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y));
		}

		public static void SetAttribute(this XElement element, string attributeName, int3 value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z));
		}

		public static void SetAttribute(this XElement element, string attributeName, int4 value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w));
		}

		public static void SetAttribute(this XElement element, string attributeName, bool value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value) ?? "");
		}

		public static void SetAttribute(this XElement element, string attributeName, bool2 value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y));
		}

		public static void SetAttribute(this XElement element, string attributeName, bool3 value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z));
		}

		public static void SetAttribute(this XElement element, string attributeName, bool4 value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w));
		}

		public static void SetAttribute(this XElement element, string attributeName, AnimationCurve curve)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Keyframe[] keys = curve.keys;
			for (int i = 0; i < keys.Length; i++)
			{
				if (i != 0)
				{
					stringBuilder.Append('|');
				}
				Keyframe keyframe = keys[i];
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0},{1},{2},{3},{4},{5},{6},{7}", keyframe.time, keyframe.value, keyframe.inTangent, keyframe.outTangent, keyframe.inWeight, keyframe.outWeight, (int)keyframe.weightedMode, keyframe.tangentMode);
			}
			element.SetAttributeValue(attributeName, stringBuilder.ToString());
		}

		public static void SetAttribute(this XElement element, string attributeName, Quaterniond value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w));
		}

		public static void SetAttribute(this XElement element, string attributeName, Vector2 value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y));
		}

		public static void SetAttribute(this XElement element, string attributeName, RangeInteger value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value));
		}

		public static void SetAttribute(this XElement element, string attributeName, RangeFloat value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value));
		}

		public static void SetAttribute(this XElement element, string attributeName, Vector2d value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y));
		}

		public static void SetAttribute(this XElement element, string attributeName, Color32 value, ColorStringFormat format = ColorStringFormat.FloatRGBA)
		{
			element.SetAttributeValue(attributeName, ColorsUtility.ToString(value, format));
		}

		public static void SetAttribute(this XElement element, string attributeName, Color value, ColorStringFormat format = ColorStringFormat.FloatRGBA)
		{
			element.SetAttributeValue(attributeName, ColorsUtility.ToString(value, format));
		}

		public static XAttribute ToXAttributeOrNull(this string value, string attributeName)
		{
			if (!string.IsNullOrEmpty(value))
			{
				return new XAttribute(attributeName, value);
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this string value, string attributeName, string defaultValue)
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value);
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull<T>(this T value, string attributeName, T defaultValue = default(T)) where T : struct, IEquatable<T>
		{
			if (!value.Equals(defaultValue))
			{
				return new XAttribute(attributeName, value);
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull<T>(this T? value, string attributeName, T? defaultValue = null) where T : struct, IEquatable<T>
		{
			if (!value.Equals(defaultValue))
			{
				return new XAttribute(attributeName, value.Value);
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this Color value, string attributeName, Color defaultValue, ColorStringFormat format = ColorStringFormat.FloatRGBA)
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value.ToXAttributeValue(format));
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this Color32 value, string attributeName, Color32 defaultValue, ColorStringFormat format = ColorStringFormat.FloatRGBA)
		{
			if (value.r != defaultValue.r || value.g != defaultValue.g || value.b != defaultValue.b || value.a != defaultValue.a)
			{
				return new XAttribute(attributeName, value.ToXAttributeValue(format));
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this float2 value, string attributeName, float2 defaultValue = default(float2))
		{
			if (value.x != defaultValue.x || value.y != defaultValue.y)
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this Vector2 value, string attributeName, Vector2 defaultValue = default(Vector2))
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this RangeFloat value, string attributeName, RangeFloat defaultValue)
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this RangeInteger value, string attributeName, RangeInteger defaultValue)
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this Vector2d value, string attributeName, Vector2d defaultValue = default(Vector2d))
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this Vector2i value, string attributeName, Vector2i defaultValue = default(Vector2i))
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this float3 value, string attributeName, float3 defaultValue = default(float3))
		{
			if (value.x != defaultValue.x || value.y != defaultValue.y || value.z != defaultValue.z)
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this Vector3d value, string attributeName, Vector3d defaultValue = default(Vector3d))
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this Vector3i value, string attributeName, Vector3i defaultValue = default(Vector3i))
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this Vector3 value, string attributeName, Vector3 defaultValue = default(Vector3))
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this float4 value, string attributeName, float4 defaultValue = default(float4))
		{
			if (value.x != defaultValue.x || value.y != defaultValue.y || value.z != defaultValue.z || value.w != defaultValue.w)
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this Vector4 value, string attributeName, Vector4 defaultValue = default(Vector4))
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this Vector4d value, string attributeName, Vector4d defaultValue = default(Vector4d))
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this Vector4i value, string attributeName, Vector4i defaultValue = default(Vector4i))
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this Quaternion value, string attributeName, Quaternion defaultValue)
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static XAttribute ToXAttributeOrNull(this Quaterniond value, string attributeName, Quaterniond defaultValue)
		{
			if (!(value == defaultValue))
			{
				return new XAttribute(attributeName, value.ToXAttributeValue());
			}
			return null;
		}

		public static string ToXAttributeValue(this Color value, ColorStringFormat format = ColorStringFormat.FloatRGBA)
		{
			return ColorsUtility.ToString(value, format);
		}

		public static string ToXAttributeValue(this Color32 value, ColorStringFormat format = ColorStringFormat.FloatRGBA)
		{
			return ColorsUtility.ToString(value, format);
		}

		public static string ToXAttributeValue(this float2 value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y);
		}

		public static string ToXAttributeValue(this Vector2 value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y);
		}

		public static string ToXAttributeValue(this Vector2 value, string format)
		{
			return DataIO.ToString(value.x, format) + "," + DataIO.ToString(value.y, format);
		}

		public static string ToXAttributeValue(this RangeInteger value)
		{
			return DataIO.ToString(value);
		}

		public static string ToXAttributeValue(this RangeFloat value)
		{
			return DataIO.ToString(value);
		}

		public static string ToXAttributeValue(this Vector2d value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y);
		}

		public static string ToXAttributeValue(this Vector2i value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y);
		}

		public static string ToXAttributeValue(this float3 value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z);
		}

		public static string ToXAttributeValue(this Vector3 value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z);
		}

		public static string ToXAttributeValue(this Vector3 value, string format)
		{
			return DataIO.ToString(value.x, format) + "," + DataIO.ToString(value.y, format) + "," + DataIO.ToString(value.z, format);
		}

		public static string ToXAttributeValue(this Vector3d value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z);
		}

		public static string ToXAttributeValue(this Vector3i value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z);
		}

		public static string ToXAttributeValue(this float4 value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w);
		}

		public static string ToXAttributeValue(this Vector4 value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w);
		}

		public static string ToXAttributeValue(this Vector4d value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w);
		}

		public static string ToXAttributeValue(this Vector4i value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w);
		}

		public static string ToXAttributeValue(this Quaternion value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w);
		}

		public static string ToXAttributeValue(this Quaterniond value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w);
		}

		public static bool TryGetBoolAttribute(this XElement element, string attributeName, out bool value)
		{
			XAttribute xAttribute = element.Attribute(attributeName);
			if (xAttribute != null)
			{
				value = (bool)xAttribute;
				return true;
			}
			value = false;
			return false;
		}
	}
}
