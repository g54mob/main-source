using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml
{
	public static class ConversionExtensions
	{
		private static CultureInfo _CultureInfo;

		private static Dictionary<Type, Func<string, XmlLayout, object>> CustomTypeConverters = new Dictionary<Type, Func<string, XmlLayout, object>>();

		private static Regex rgbTest = new Regex("(\\d+[.]\\d+)|(\\d+)");

		private static char[] numberSeparators = new char[3] { ' ', 'x', ',' };

		private static char[] colorSeparators = new char[2] { ' ', '|' };

		private static CultureInfo CultureInfo
		{
			get
			{
				if (_CultureInfo == null)
				{
					_CultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
					_CultureInfo.NumberFormat.NumberDecimalSeparator = ".";
				}
				return _CultureInfo;
			}
		}

		public static void RegisterCustomTypeConverter(Type type, Func<string, object> convertMethod)
		{
			if (CustomTypeConverters.ContainsKey(type))
			{
				CustomTypeConverters[type] = (string value, XmlLayout xmlLayout) => convertMethod(value);
			}
			else
			{
				CustomTypeConverters.Add(type, (string value, XmlLayout xmlLayout) => convertMethod(value));
			}
		}

		public static void RegisterCustomTypeConverter(Type type, Func<string, XmlLayout, object> convertMethod)
		{
			if (CustomTypeConverters.ContainsKey(type))
			{
				CustomTypeConverters[type] = convertMethod;
			}
			else
			{
				CustomTypeConverters.Add(type, convertMethod);
			}
		}

		public static T ChangeToType<T>(this string str, XmlLayout xmlLayout = null)
		{
			return (T)str.ChangeToType(typeof(T), xmlLayout);
		}

		public static object ChangeToType(this string str, Type type, XmlLayout xmlLayout = null)
		{
			if (string.IsNullOrEmpty(str) || (str.ToLower() == "none" && type != typeof(string)) || (str.StartsWith("{") && str.EndsWith("}")))
			{
				return null;
			}
			if (CustomTypeConverters.ContainsKey(type))
			{
				return CustomTypeConverters[type](str, xmlLayout);
			}
			if (type.IsEnum)
			{
				return Enum.Parse(type, str, ignoreCase: true);
			}
			switch (type.Name)
			{
			case "RectOffset":
				return str.ToRectOffset();
			case "Rect":
				return str.ToRect();
			case "Vector2":
				return str.ToVector2();
			case "Vector3":
				return str.ToVector3();
			case "Vector4":
				return str.ToVector4();
			case "Boolean":
			case "bool":
				return str.ToBoolean();
			case "Color":
				return str.ToColor(xmlLayout);
			case "Color32":
				return (Color32)str.ToColor(xmlLayout);
			case "ColorBlock":
				return str.ToColorBlock(xmlLayout);
			case "Sprite":
				return str.ToSprite();
			case "Texture":
				return str.ToTexture();
			case "Quaternion":
				return str.ToQuaternion();
			case "Font":
				return str.ToFont();
			case "AudioClip":
				return str.ToAudioClip();
			case "Material":
				return str.ToMaterial();
			case "CursorInfo":
				return str.ToCursorInfo();
			case "float":
				return str.ToFloat();
			case "int":
			case "Int32":
			case "Int64":
				return Convert.ChangeType(str.ToInt(), type, CultureInfo);
			case "Transform":
				return str.ToTransform();
			default:
				if (typeof(IEnumerable<float>).IsAssignableFrom(type))
				{
					return GetFloatList(str);
				}
				return Convert.ChangeType(str, type, CultureInfo);
			}
		}

		public static RectOffset ToRectOffset(this string str)
		{
			List<int> intList = GetIntList(str);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			num = intList[0];
			num2 = ((intList.Count > 1) ? intList[1] : num);
			num3 = ((intList.Count > 2) ? intList[2] : num2);
			num4 = ((intList.Count > 3) ? intList[3] : num3);
			return new RectOffset(num, num2, num3, num4);
		}

		public static Rect ToRect(this string str)
		{
			List<float> floatList = GetFloatList(str);
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			num = floatList[0];
			num2 = ((floatList.Count > 1) ? floatList[1] : num);
			num3 = ((floatList.Count > 2) ? floatList[2] : num2);
			num4 = ((floatList.Count > 3) ? floatList[3] : num3);
			return new Rect(num, num2, num3, num4);
		}

		public static bool ToBoolean(this string str)
		{
			if (str == null)
			{
				return false;
			}
			if (!str.Equals("true", StringComparison.OrdinalIgnoreCase))
			{
				return str.Equals("1");
			}
			return true;
		}

		public static Vector2 ToVector2(this string str)
		{
			List<float> floatList = GetFloatList(str);
			float num = 0f;
			float num2 = 0f;
			num = floatList[0];
			num2 = ((floatList.Count > 1) ? floatList[1] : num);
			return new Vector2(num, num2);
		}

		public static Vector3 ToVector3(this string str)
		{
			List<float> floatList = GetFloatList(str);
			float num = 0f;
			float num2 = 0f;
			float z = 0f;
			num = floatList[0];
			if (floatList.Count == 1)
			{
				num2 = (z = num);
			}
			else
			{
				num2 = ((floatList.Count > 1) ? floatList[1] : num);
				if (floatList.Count > 2)
				{
					z = floatList[2];
				}
			}
			return new Vector3(num, num2, z);
		}

		public static Vector4 ToVector4(this string str)
		{
			List<float> floatList = GetFloatList(str);
			float num = 0f;
			float num2 = 0f;
			float z = 0f;
			float w = 0f;
			num = floatList[0];
			if (floatList.Count == 1)
			{
				num2 = (z = (w = num));
			}
			else
			{
				num2 = ((floatList.Count > 1) ? floatList[1] : num);
				if (floatList.Count > 2)
				{
					z = floatList[2];
				}
				if (floatList.Count > 3)
				{
					w = floatList[3];
				}
			}
			return new Vector4(num, num2, z, w);
		}

		public static Color ToColor(this string str, XmlLayout xmlLayout = null)
		{
			str = str.ToLower();
			if (xmlLayout != null && xmlLayout.namedColors.ContainsKey(str))
			{
				return xmlLayout.namedColors[str];
			}
			if (str.StartsWith("#"))
			{
				return HexStringToColor(str);
			}
			if (str.StartsWith("rgb"))
			{
				MatchCollection matchCollection = rgbTest.Matches(str);
				if (matchCollection.Count >= 3)
				{
					float colorValue = GetColorValue(matchCollection[0].Value);
					float colorValue2 = GetColorValue(matchCollection[1].Value);
					float colorValue3 = GetColorValue(matchCollection[2].Value);
					float a = 1f;
					if (matchCollection.Count == 4)
					{
						a = GetColorValue(matchCollection[3].Value);
					}
					return new Color(colorValue, colorValue2, colorValue3, a);
				}
				Debug.LogWarning("[XmlLayout] Warning: '" + str + "' is not a valid Color value.");
			}
			PropertyInfo property = typeof(Color).GetProperty(str);
			if (property != null && property.PropertyType == typeof(Color))
			{
				return (Color)property.GetValue(null, XmlLayoutUtilities.BindingFlags, null, null, null);
			}
			Debug.LogWarning("[XmlLayout] Warning: '" + str + "' is not a valid Color value.");
			return Color.clear;
		}

		private static float GetColorValue(string match)
		{
			return float.Parse(match, CultureInfo.InvariantCulture);
		}

		public static Color HexStringToColor(string hex)
		{
			hex = hex.Replace("0x", string.Empty);
			hex = hex.Replace("#", string.Empty);
			if (hex.Length < 6)
			{
				return Color.clear;
			}
			byte a = byte.MaxValue;
			byte r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
			if (hex.Length == 8)
			{
				a = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber, CultureInfo);
			}
			return new Color32(r, g, b, a);
		}

		private static string[] GetParts(string str, char[] separators, bool trim)
		{
			return (trim ? str.Trim('(', ')') : str).Split(separators);
		}

		public static List<int> GetIntList(string str)
		{
			List<int> list = new List<int>();
			if (string.IsNullOrEmpty(str))
			{
				return list;
			}
			string[] parts = GetParts(str, numberSeparators, trim: true);
			foreach (string text in parts)
			{
				int result = 0;
				if (!string.IsNullOrEmpty(text))
				{
					int.TryParse(text, NumberStyles.Any, CultureInfo, out result);
				}
				list.Add(result);
			}
			return list;
		}

		public static List<float> GetFloatList(string str)
		{
			List<float> list = new List<float>();
			if (string.IsNullOrEmpty(str))
			{
				return list;
			}
			string[] parts = GetParts(str, numberSeparators, trim: true);
			foreach (string text in parts)
			{
				float result = 0f;
				if (!string.IsNullOrEmpty(text))
				{
					float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out result);
				}
				list.Add(result);
			}
			return list;
		}

		public static List<Color> GetColorList(string str, XmlLayout xmlLayout = null)
		{
			List<Color> list = new List<Color>();
			if (string.IsNullOrEmpty(str))
			{
				return list;
			}
			string[] parts = GetParts(str, colorSeparators, trim: false);
			foreach (string str2 in parts)
			{
				list.Add(str2.ToColor(xmlLayout));
			}
			return list;
		}

		public static ColorBlock ToColorBlock(this string str, XmlLayout xmlLayout = null)
		{
			ColorBlock result = default(ColorBlock);
			Color color = (result.pressedColor = Color.white);
			Color normalColor = (result.disabledColor = color);
			result.normalColor = normalColor;
			result.disabledColor = new Color(1f, 1f, 1f, 0.5f);
			result.colorMultiplier = 1f;
			List<Color> colorList = GetColorList(str, xmlLayout);
			if (colorList.Count > 0)
			{
				result.normalColor = colorList[0];
			}
			if (colorList.Count > 1)
			{
				result.highlightedColor = colorList[1];
			}
			if (colorList.Count > 2)
			{
				result.pressedColor = colorList[2];
			}
			if (colorList.Count > 3)
			{
				result.disabledColor = colorList[3];
			}
			if (colorList.Count > 4)
			{
				result.selectedColor = colorList[4];
			}
			return result;
		}

		public static Sprite ToSprite(this string str, bool reportError = true)
		{
			if (string.IsNullOrEmpty(str) || str.ToLower() == "none")
			{
				return null;
			}
			Sprite sprite = XmlLayoutUtilities.LoadResource<Sprite>(str);
			if (sprite == null && reportError)
			{
				Debug.LogError("[XmlLayout] Unable to load sprite '" + str + "'. Please ensure that it is located within a Resources folder or XmlLayout Resource Database.");
			}
			return sprite;
		}

		public static Texture ToTexture(this string str)
		{
			if (string.IsNullOrEmpty(str) || str.ToLower() == "none")
			{
				return null;
			}
			Texture texture = XmlLayoutUtilities.LoadResource<Texture>(str);
			if (texture == null)
			{
				Sprite sprite = XmlLayoutUtilities.LoadResource<Sprite>(str);
				if (sprite == null)
				{
					Debug.LogError("[XmlLayout] Unable to load texture '" + str + "'. Please ensure that it is located within a Resources folder or XmlLayout Resource Database.");
				}
				else
				{
					texture = sprite.texture;
				}
			}
			return texture;
		}

		public static Texture2D ToTexture2D(this string str)
		{
			return (Texture2D)str.ToTexture();
		}

		public static Cubemap ToCubeMap(this string str)
		{
			return (Cubemap)str.ToTexture();
		}

		public static Quaternion ToQuaternion(this string str)
		{
			List<float> floatList = GetFloatList(str);
			Quaternion result = default(Quaternion);
			if (floatList.Count >= 4)
			{
				return new Quaternion(floatList[0], floatList[1], floatList[2], floatList[3]);
			}
			float x = floatList[0];
			float y = ((floatList.Count > 1) ? floatList[1] : 0f);
			float z = ((floatList.Count > 2) ? floatList[2] : 0f);
			result.eulerAngles = new Vector3(x, y, z);
			return result;
		}

		public static Font ToFont(this string str)
		{
			Font font = XmlLayoutUtilities.LoadResource<Font>("Fonts/" + str);
			if (font == null)
			{
				font = XmlLayoutUtilities.LoadResource<Font>(str);
			}
			if (font == null)
			{
				Debug.LogWarning("Font '" + str + "' not found. Please ensure that it is located within a Resources folder or XmlLayout Resource Database. (Reverting to Arial)");
				return Resources.GetBuiltinResource(typeof(Font), "LegacyRuntime.ttf") as Font;
			}
			return font;
		}

		public static RuntimeAnimatorController ToRuntimeAnimatorController(this string str)
		{
			if (str.ToLower() == "none")
			{
				return null;
			}
			RuntimeAnimatorController runtimeAnimatorController = XmlLayoutUtilities.LoadResource<RuntimeAnimatorController>(str);
			if (runtimeAnimatorController == null)
			{
				Debug.Log("Animation Controller '" + str + "' not found. Please ensure that it is located within a Resources folder or XmlLayout Resource Database.");
			}
			return runtimeAnimatorController;
		}

		public static AudioClip ToAudioClip(this string str)
		{
			if (str.ToLower() == "none")
			{
				return null;
			}
			AudioClip audioClip = XmlLayoutUtilities.LoadResource<AudioClip>(str);
			if (audioClip == null)
			{
				Debug.Log("Audio Clip '" + str + "' not found. Please ensure that it is located within a Resources folder or XmlLayout Resource Database.");
			}
			return audioClip;
		}

		public static Material ToMaterial(this string str)
		{
			if (str.ToLower() == "none")
			{
				return null;
			}
			Material material = XmlLayoutUtilities.LoadResource<Material>(str);
			if (material == null)
			{
				Debug.Log("Material '" + str + "' not found. Please ensure that it is located within a Resources folder or XmlLayout Resource Database.");
			}
			return material;
		}

		public static XmlLayoutCursorController.CursorInfo ToCursorInfo(this string str)
		{
			if (string.IsNullOrEmpty(str) || str.ToLower() == "none")
			{
				return null;
			}
			string[] array = str.Split('|');
			Texture2D cursor = array[0].ToTexture2D();
			Vector2 hotspot = Vector2.zero;
			if (array.Length > 1)
			{
				hotspot = array[1].ToVector2();
			}
			return new XmlLayoutCursorController.CursorInfo
			{
				cursor = cursor,
				hotspot = hotspot
			};
		}

		public static float ToFloat(this string str)
		{
			float result = 0f;
			float.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out result);
			return result;
		}

		public static int ToInt(this string str)
		{
			int result = 0;
			int.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
			return result;
		}

		public static Transform ToTransform(this string str)
		{
			return XmlLayoutUtilities.LoadResource<Transform>(str);
		}

		public static List<string> ToClassList(this string str)
		{
			if (str == null)
			{
				return new List<string>();
			}
			return (from s in str.Split(',', ' ')
				select s.Trim().ToLower()).ToList();
		}

		public static string ToString(object o)
		{
			if (o == null)
			{
				return "";
			}
			Type type = o.GetType();
			if (type.Name.StartsWith("Vector"))
			{
				return o.ToString().Replace(" ", "");
			}
			if (type.IsSubclassOf(typeof(UnityEngine.Object)))
			{
				UnityEngine.Object obj = o as UnityEngine.Object;
				string text = XmlLayoutResourceDatabase.instance.GetResourcePath(obj);
				if (text == null)
				{
					text = "DynamicResource_" + Guid.NewGuid().ToString() + "_" + obj.name;
					XmlLayoutResourceDatabase.instance.AddResource(text, obj);
				}
				return text;
			}
			return o.ToString();
		}

		public static bool IsNumericType(this Type t)
		{
			TypeCode typeCode = Type.GetTypeCode(t);
			if ((uint)(typeCode - 5) <= 10u)
			{
				return true;
			}
			return false;
		}
	}
}
