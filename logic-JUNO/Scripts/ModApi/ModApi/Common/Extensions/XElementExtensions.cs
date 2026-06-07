using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace ModApi.Common.Extensions
{
	public static class XElementExtensions
	{
		private static readonly char[] _stringSplitBar = new char[1] { '|' };

		private static readonly char[] _stringSplitComma = new char[1] { ',' };

		private static readonly string[] _stringSplitDoubleBar = new string[1] { "||" };

		public static bool GetBoolAttribute(this XElement element, string attributeName, bool defaultValue = false)
		{
			try
			{
				return ((bool?)element.Attribute(attributeName)) ?? defaultValue;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static bool? GetBoolAttributeOrNull(this XElement element, string attributeName)
		{
			try
			{
				return (bool?)element.Attribute(attributeName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Color? GetColorAttribute(this XElement element, string attributeName, XmlColorFormat format = XmlColorFormat.FloatRGBA)
		{
			try
			{
				string text = (string)element.Attribute(attributeName);
				if (text != null)
				{
					switch (format)
					{
					case XmlColorFormat.Default:
					case XmlColorFormat.FloatRGBA:
					{
						string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
						if (array.Length == 4)
						{
							return new Color(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]), DataIO.ParseFloat(array[3]));
						}
						if (array.Length == 3)
						{
							return new Color(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]));
						}
						return null;
					}
					case XmlColorFormat.FloatRGB:
					{
						string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
						if (array.Length == 3 || array.Length == 4)
						{
							return new Color(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]));
						}
						return null;
					}
					case XmlColorFormat.ByteRGBA:
					{
						string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
						if (array.Length == 4)
						{
							return new Color32(DataIO.ParseByte(array[0]), DataIO.ParseByte(array[1]), DataIO.ParseByte(array[2]), DataIO.ParseByte(array[3]));
						}
						if (array.Length == 3)
						{
							return new Color32(DataIO.ParseByte(array[0]), DataIO.ParseByte(array[1]), DataIO.ParseByte(array[2]), byte.MaxValue);
						}
						return null;
					}
					case XmlColorFormat.ByteRGB:
					{
						string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
						if (array.Length == 3 || array.Length == 4)
						{
							return new Color32(DataIO.ParseByte(array[0]), DataIO.ParseByte(array[1]), DataIO.ParseByte(array[2]), byte.MaxValue);
						}
						return null;
					}
					case XmlColorFormat.HexRGBA:
					case XmlColorFormat.HexRGB:
					{
						if (ColorUtility.TryParseHtmlString(text, out var color))
						{
							return color;
						}
						return null;
					}
					default:
						throw new NotSupportedException($"Color format '{format}' not supported.");
					}
				}
				return null;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Color GetColorAttribute(this XElement element, string attributeName, Color defaultValue, XmlColorFormat format = XmlColorFormat.FloatRGBA)
		{
			try
			{
				return element.GetColorAttribute(attributeName, format) ?? defaultValue;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static DateTime GetDateTimeAttribute(this XElement element, string attributeName, DateTime defaultValue)
		{
			try
			{
				return ((DateTime?)element.Attribute(attributeName)) ?? defaultValue;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static DateTime? GetDateTimeAttributeOrNull(this XElement element, string attributeName)
		{
			try
			{
				return (DateTime?)element.Attribute(attributeName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static double[] GetDoubleArray(this XElement element, string attributeName, double[] defaultValue = null)
		{
			try
			{
				string text = (string)element.Attribute(attributeName);
				if (!string.IsNullOrWhiteSpace(text))
				{
					string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
					if (array.Length != 0)
					{
						double[] array2 = new double[array.Length];
						for (int i = 0; i < array.Length; i++)
						{
							array2[i] = DataIO.ParseDouble(array[i]);
						}
						return array2;
					}
				}
				return defaultValue;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static double GetDoubleAttribute(this XElement element, string attributeName, double defaultValue = 0.0)
		{
			try
			{
				return ((double?)element.Attribute(attributeName)) ?? defaultValue;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static double? GetDoubleAttributeOrNull(this XElement element, string attributeName)
		{
			try
			{
				return (double?)element.Attribute(attributeName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static T GetEnumAttribute<T>(this XAttribute attribute, T defaultValue = default(T), T[] options = null) where T : struct
		{
			try
			{
				string text = (string)attribute;
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
			catch (Exception ex)
			{
				throw new Exception("Unable to parse XML attribute with value '" + (attribute?.Value ?? string.Empty) + "': " + ex.Message);
			}
		}

		public static T GetEnumAttribute<T>(this XElement xml, string attributeName, T defaultValue = default(T), T[] options = null) where T : struct
		{
			try
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
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + xml.Attribute(attributeName)?.Value + "' on element '" + xml.Name.LocalName + "': " + ex.Message);
			}
		}

		public static T? GetEnumAttributeOrNull<T>(this XElement xml, string attributeName, T[] options = null) where T : struct
		{
			try
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
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + xml.Attribute(attributeName)?.Value + "' on element '" + xml.Name.LocalName + "': " + ex.Message);
			}
		}

		public static float GetFloatAttribute(this XElement element, string attributeName, float defaultValue = 0f)
		{
			try
			{
				return ((float?)element.Attribute(attributeName)) ?? defaultValue;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static float? GetFloatAttributeOrNull(this XElement element, string attributeName)
		{
			try
			{
				return (float?)element.Attribute(attributeName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Gradient GetGradientAttribute(this XElement element, string attributeName, bool includeAlphaKeys, Gradient defaultValue)
		{
			try
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
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Guid GetGuidAttribute(this XElement element, string attributeName, Guid defaultValue)
		{
			try
			{
				return ((Guid?)element.Attribute(attributeName)) ?? defaultValue;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Guid? GetGuidAttributeOrNull(this XElement element, string attributeName)
		{
			try
			{
				return (Guid?)element.Attribute(attributeName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static int GetIntAttribute(this XElement element, string attributeName, int defaultValue = 0)
		{
			try
			{
				return ((int?)element.Attribute(attributeName)) ?? defaultValue;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static int? GetIntAttributeOrNull(this XElement element, string attributeName)
		{
			try
			{
				return (int?)element.Attribute(attributeName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static long GetLongAttribute(this XElement element, string attributeName, long defaultValue = 0L)
		{
			try
			{
				return ((long?)element.Attribute(attributeName)) ?? defaultValue;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static long? GetLongAttributeOrNull(this XElement element, string attributeName)
		{
			try
			{
				return (long?)element.Attribute(attributeName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
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
			try
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
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Quaternion? GetQuaternionAttributeOrNull(this XElement element, string attributeName)
		{
			try
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
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Quaterniond GetQuaterniondAttribute(this XElement element, string attributeName, Quaterniond defaultValue = default(Quaterniond))
		{
			try
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
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Quaterniond? GetQuaterniondAttributeOrNull(this XElement element, string attributeName)
		{
			try
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
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static string GetStringAttribute(this XElement element, string attributeName, string defaultValue = null)
		{
			try
			{
				return ((string)element.Attribute(attributeName)) ?? defaultValue;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static string GetStringAttributeOrNullIfEmpty(this XElement element, string attributeName)
		{
			try
			{
				string text = (string)element.Attribute(attributeName);
				return (text == string.Empty) ? null : text;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static string GetStringAttributeOrNullIfWhitespace(this XElement element, string attributeName)
		{
			try
			{
				string text = (string)element.Attribute(attributeName);
				return string.IsNullOrWhiteSpace(text) ? null : text;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
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

		public static List<string> GetStringList(this XElement element, string attributeName, List<string> defaultValue = null)
		{
			try
			{
				string text = element.Attribute(attributeName)?.Value;
				if (!string.IsNullOrWhiteSpace(text))
				{
					string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
					if (array.Length != 0)
					{
						List<string> list = new List<string>(array.Length);
						string[] array2 = array;
						foreach (string item in array2)
						{
							list.Add(item);
						}
						return list;
					}
				}
				return defaultValue;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Vector2 GetVector2Attribute(this XElement element, string attributeName, Vector2 defaultValue = default(Vector2))
		{
			try
			{
				string text = (string)element.Attribute(attributeName);
				if (string.IsNullOrEmpty(text))
				{
					return defaultValue;
				}
				string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length != 2)
				{
					return defaultValue;
				}
				return new Vector2(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]));
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Vector2? GetVector2AttributeOrNull(this XElement element, string attributeName)
		{
			try
			{
				string text = (string)element.Attribute(attributeName);
				if (string.IsNullOrEmpty(text))
				{
					return null;
				}
				string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length != 2)
				{
					return null;
				}
				return new Vector2(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]));
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Vector2d GetVector2dAttribute(this XElement element, string attributeName, Vector2d defaultValue = default(Vector2d))
		{
			try
			{
				string text = (string)element.Attribute(attributeName);
				if (string.IsNullOrEmpty(text))
				{
					return defaultValue;
				}
				string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length != 2)
				{
					return defaultValue;
				}
				return new Vector2d(DataIO.ParseDouble(array[0]), DataIO.ParseDouble(array[1]));
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Vector2d? GetVector2dAttributeOrNull(this XElement element, string attributeName)
		{
			try
			{
				string text = (string)element.Attribute(attributeName);
				if (string.IsNullOrEmpty(text))
				{
					return null;
				}
				string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length != 2)
				{
					return null;
				}
				return new Vector2d(DataIO.ParseDouble(array[0]), DataIO.ParseDouble(array[1]));
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Vector3 GetVector3Attribute(this XElement element, string attributeName, Vector3 defaultValue = default(Vector3))
		{
			try
			{
				string text = (string)element.Attribute(attributeName);
				if (string.IsNullOrEmpty(text))
				{
					return defaultValue;
				}
				string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length != 3)
				{
					return defaultValue;
				}
				return new Vector3(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]));
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Vector3? GetVector3AttributeOrNull(this XElement element, string attributeName)
		{
			try
			{
				string text = (string)element.Attribute(attributeName);
				if (string.IsNullOrEmpty(text))
				{
					return null;
				}
				string[] array = text.Split(_stringSplitComma, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length != 3)
				{
					return null;
				}
				return new Vector3(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]));
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Vector3d GetVector3dAttribute(this XElement element, string attributeName, Vector3d defaultValue = default(Vector3d))
		{
			try
			{
				string text = (string)element.Attribute(attributeName);
				if (string.IsNullOrEmpty(text))
				{
					return defaultValue;
				}
				if (!Vector3d.TryParse(text, out var result))
				{
					return defaultValue;
				}
				return result;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Vector3d? GetVector3dAttributeOrNull(this XElement element, string attributeName)
		{
			try
			{
				string text = (string)element.Attribute(attributeName);
				if (string.IsNullOrEmpty(text))
				{
					return null;
				}
				if (!Vector3d.TryParse(text, out var result))
				{
					return null;
				}
				return result;
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Vector4 GetVector4Attribute(this XElement element, string attributeName, Vector4 defaultValue = default(Vector4))
		{
			try
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
				return new Vector4(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]), DataIO.ParseFloat(array[3]));
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Vector4? GetVector4AttributeOrNull(this XElement element, string attributeName)
		{
			try
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
				return new Vector4(DataIO.ParseFloat(array[0]), DataIO.ParseFloat(array[1]), DataIO.ParseFloat(array[2]), DataIO.ParseFloat(array[3]));
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Vector4d GetVector4dAttribute(this XElement element, string attributeName, Vector4d defaultValue = default(Vector4d))
		{
			try
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
				return new Vector4d(DataIO.ParseDouble(array[0]), DataIO.ParseDouble(array[1]), DataIO.ParseDouble(array[2]), DataIO.ParseDouble(array[3]));
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Vector4d? GetVector4dAttributeOrNull(this XElement element, string attributeName)
		{
			try
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
				return new Vector4d(DataIO.ParseDouble(array[0]), DataIO.ParseDouble(array[1]), DataIO.ParseDouble(array[2]), DataIO.ParseDouble(array[3]));
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static Version GetVersionAttribute(this XElement element, string attributeName, Version defaultValue = null)
		{
			try
			{
				string text = (string)element.Attribute(attributeName);
				return string.IsNullOrEmpty(text) ? defaultValue : new Version(text);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to parse attribute '" + attributeName + "' with value '" + element.Attribute(attributeName)?.Value + "' on element '" + element.Name.LocalName + "': " + ex.Message);
			}
		}

		public static void SetAttribute(this XElement element, string attributeName, Gradient value, bool includeAlphaKeys)
		{
			StringBuilder stringBuilder = new StringBuilder();
			GradientColorKey[] colorKeys = value.colorKeys;
			for (int i = 0; i < colorKeys.Length; i++)
			{
				if (i != 0)
				{
					stringBuilder.Append("|");
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
						stringBuilder.Append("|");
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

		public static void SetAttribute(this XElement element, string attributeName, Vector3d value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z));
		}

		public static void SetAttribute(this XElement element, string attributeName, double[] value)
		{
			string text = string.Empty;
			if (value != null)
			{
				bool flag = true;
				foreach (double num in value)
				{
					if (!flag)
					{
						text += ",";
					}
					flag = false;
					text += DataIO.ToString(num);
				}
			}
			element.SetAttributeValue(attributeName, text);
		}

		public static void SetAttribute(this XElement element, string attributeName, IEnumerable<string> value)
		{
			string text = string.Empty;
			if (value != null)
			{
				bool flag = true;
				foreach (string item in value)
				{
					if (!flag)
					{
						text += ",";
					}
					flag = false;
					text += item;
				}
			}
			element.SetAttributeValue(attributeName, text);
		}

		public static void SetAttribute(this XElement element, string attributeName, Vector4d value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w));
		}

		public static void SetAttribute(this XElement element, string attributeName, Quaternion value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w));
		}

		public static void SetAttribute(this XElement element, string attributeName, Quaterniond value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w));
		}

		public static void SetAttribute(this XElement element, string attributeName, Vector2 value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y));
		}

		public static void SetAttribute(this XElement element, string attributeName, Vector2d value)
		{
			element.SetAttributeValue(attributeName, DataIO.ToString(value.x) + "," + DataIO.ToString(value.y));
		}

		public static void SetAttribute(this XElement element, string attributeName, Color32 value, XmlColorFormat format = XmlColorFormat.FloatRGBA)
		{
			element.SetAttributeValue(attributeName, value.ToXAttributeValue(format));
		}

		public static void SetAttribute(this XElement element, string attributeName, Color value, XmlColorFormat format = XmlColorFormat.FloatRGBA)
		{
			element.SetAttributeValue(attributeName, value.ToXAttributeValue(format));
		}

		public static string ToXAttributeValue(this Color value, XmlColorFormat format = XmlColorFormat.FloatRGBA)
		{
			switch (format)
			{
			case XmlColorFormat.Default:
			case XmlColorFormat.FloatRGBA:
				return DataIO.ToString(value.r) + "," + DataIO.ToString(value.g) + "," + DataIO.ToString(value.b) + "," + DataIO.ToString(value.a);
			case XmlColorFormat.FloatRGB:
				return DataIO.ToString(value.r) + "," + DataIO.ToString(value.g) + "," + DataIO.ToString(value.b);
			case XmlColorFormat.ByteRGBA:
			{
				Color32 color2 = value;
				return DataIO.ToString(color2.r) + "," + DataIO.ToString(color2.g) + "," + DataIO.ToString(color2.b) + "," + DataIO.ToString(color2.a);
			}
			case XmlColorFormat.ByteRGB:
			{
				Color32 color = value;
				return DataIO.ToString(color.r) + "," + DataIO.ToString(color.g) + "," + DataIO.ToString(color.b);
			}
			case XmlColorFormat.HexRGBA:
				return ColorUtility.ToHtmlStringRGBA(value);
			case XmlColorFormat.HexRGB:
				return ColorUtility.ToHtmlStringRGB(value);
			default:
				throw new NotSupportedException($"Color format '{format}' not supported.");
			}
		}

		public static string ToXAttributeValue(this Color32 value, XmlColorFormat format = XmlColorFormat.FloatRGBA)
		{
			switch (format)
			{
			case XmlColorFormat.Default:
			case XmlColorFormat.FloatRGBA:
			{
				Color color2 = value;
				return DataIO.ToString(color2.r) + "," + DataIO.ToString(color2.g) + "," + DataIO.ToString(color2.b) + "," + DataIO.ToString(color2.a);
			}
			case XmlColorFormat.FloatRGB:
			{
				Color color = value;
				return DataIO.ToString(color.r) + "," + DataIO.ToString(color.g) + "," + DataIO.ToString(color.b);
			}
			case XmlColorFormat.ByteRGBA:
				return DataIO.ToString(value.r) + "," + DataIO.ToString(value.g) + "," + DataIO.ToString(value.b) + "," + DataIO.ToString(value.a);
			case XmlColorFormat.ByteRGB:
				return DataIO.ToString(value.r) + "," + DataIO.ToString(value.g) + "," + DataIO.ToString(value.b);
			case XmlColorFormat.HexRGBA:
				return ColorUtility.ToHtmlStringRGBA(value);
			case XmlColorFormat.HexRGB:
				return ColorUtility.ToHtmlStringRGB(value);
			default:
				throw new NotSupportedException($"Color format '{format}' not supported.");
			}
		}

		public static string ToXAttributeValue(this Vector4 value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w);
		}

		public static string ToXAttributeValue(this Vector3 value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z);
		}

		public static string ToXAttributeValue(this Vector2 value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y);
		}

		public static string ToXAttributeValue(this Vector3i value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z);
		}

		public static string ToXAttributeValue(this Vector2i value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y);
		}

		public static string ToXAttributeValue(this Vector4d value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w);
		}

		public static string ToXAttributeValue(this Vector3d value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z);
		}

		public static string ToXAttributeValue(this Vector2d value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y);
		}

		public static string ToXAttributeValue(this float4 value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z) + "," + DataIO.ToString(value.w);
		}

		public static string ToXAttributeValue(this float3 value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y) + "," + DataIO.ToString(value.z);
		}

		public static string ToXAttributeValue(this float2 value)
		{
			return DataIO.ToString(value.x) + "," + DataIO.ToString(value.y);
		}
	}
}
