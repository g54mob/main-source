using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public static class MyExtensions
{
	public enum RangeLimits
	{
		BothIncluded = 0,
		BothExcluded = 1,
		MinInMaxEx = 2,
		MinExMaxIn = 3
	}

	private static Toggle.ToggleEvent emptyToggleEvent = new Toggle.ToggleEvent();

	private static Slider.SliderEvent emptySliderEvent = new Slider.SliderEvent();

	public static BlockView GetBlockView(this GameObject gameObject)
	{
		BlockView blockView = gameObject.GetComponent<BlockView>();
		if (blockView == null)
		{
			blockView = gameObject.GetBlockBodyView().ParentBlockView;
		}
		return blockView;
	}

	public static BlockBodyView GetBlockBodyView(this GameObject gameObject)
	{
		BlockBodyView blockBodyView = gameObject.GetComponent<BlockBodyView>();
		if (blockBodyView == null)
		{
			blockBodyView = gameObject.GetComponentInParent<BlockBodyView>();
		}
		return blockBodyView;
	}

	public static void SetLayersRecursively(this GameObject gameObject, int layer)
	{
		gameObject.layer = layer;
		foreach (Transform item in gameObject.transform)
		{
			item.gameObject.SetLayersRecursively(layer);
		}
	}

	public static void SetLayersRecursively(this GameObject gameObject, int layer, string tagName)
	{
		gameObject.layer = layer;
		foreach (Transform item in gameObject.transform)
		{
			if (item.CompareTag(tagName))
			{
				item.gameObject.SetLayersRecursively(layer);
			}
		}
	}

	public static void SetTagsRecursively(this GameObject gameObject, string tag)
	{
		gameObject.tag = tag;
		foreach (Transform item in gameObject.transform)
		{
			item.gameObject.SetTagsRecursively(tag);
		}
	}

	public static T GetComponentInChildren<T>(this GameObject gameObject, bool includeInactive) where T : Component
	{
		return gameObject.GetComponentsInChildren<T>(includeInactive)[0];
	}

	public static string PrintFullValues(this Vector3 vector)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("(").Append(vector.x).Append(", ")
			.Append(vector.y)
			.Append(", ")
			.Append(vector.z)
			.Append(")");
		return stringBuilder.ToString();
	}

	public static string PrintFullValues(this Quaternion quaternion)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("(").Append(quaternion.x).Append(", ")
			.Append(quaternion.y)
			.Append(", ")
			.Append(quaternion.z)
			.Append(", ")
			.Append(quaternion.w)
			.Append(")");
		return stringBuilder.ToString();
	}

	public static float GetMaxValue(this Vector3 vector)
	{
		if (vector.x >= vector.y && vector.x >= vector.z)
		{
			return vector.x;
		}
		if (vector.y >= vector.z)
		{
			return vector.y;
		}
		return vector.z;
	}

	public static KeyCode GetAttributeAsKeyCode(this XElement xElement, string name, KeyCode defaultValue = KeyCode.A)
	{
		XAttribute xAttribute = xElement.Attribute(name);
		if (xAttribute != null)
		{
			return (KeyCode)Enum.Parse(typeof(KeyCode), xAttribute.Value);
		}
		return defaultValue;
	}

	public static AxisCode GetAttributeAsAxisCode(this XElement xElement, string name, AxisCode defaultValue = AxisCode.None)
	{
		XAttribute xAttribute = xElement.Attribute(name);
		if (xAttribute != null)
		{
			return (AxisCode)Enum.Parse(typeof(AxisCode), xAttribute.Value);
		}
		return defaultValue;
	}

	public static string GetAttributeAsString(this XElement xElement, string name, string defaultValue = "")
	{
		XAttribute xAttribute = xElement.Attribute(name);
		if (xAttribute != null)
		{
			return xAttribute.Value;
		}
		return defaultValue;
	}

	public static int GetAttributeAsInt(this XElement xElement, string name, int defaultValue = 0)
	{
		XAttribute xAttribute = xElement.Attribute(name);
		if (xAttribute != null)
		{
			return int.Parse(xAttribute.Value);
		}
		return defaultValue;
	}

	public static float GetAttributeAsFloat(this XElement xElement, string name, float defaultValue = 0f)
	{
		XAttribute xAttribute = xElement.Attribute(name);
		if (xAttribute != null)
		{
			return float.Parse(xAttribute.Value);
		}
		return defaultValue;
	}

	public static bool GetAttributeAsBool(this XElement xElement, string name, bool defaultValue = false)
	{
		XAttribute xAttribute = xElement.Attribute(name);
		if (xAttribute != null)
		{
			return bool.Parse(xAttribute.Value);
		}
		return defaultValue;
	}

	public static Vector3 GetAttributeAsVector3(this XElement xElement, string name, Vector3 defaultValue)
	{
		XAttribute xAttribute = xElement.Attribute(name);
		if (xAttribute != null)
		{
			return Util.Vector3Parser(xAttribute.Value);
		}
		return defaultValue;
	}

	public static Color GetAttributeAsColor(this XElement xElement, string name, Color defaultValue)
	{
		XAttribute xAttribute = xElement.Attribute(name);
		if (xAttribute != null && ColorUtility.TryParseHtmlString(xAttribute.Value, out var color))
		{
			return color;
		}
		return defaultValue;
	}

	public static T GetAttributeAsEnum<T>(this XElement xElement, string name, T defaultValue) where T : struct, IConvertible
	{
		XAttribute xAttribute = xElement.Attribute(name);
		if (xAttribute != null && Enum.TryParse<T>(xAttribute.Value, out var result))
		{
			return result;
		}
		return defaultValue;
	}

	public static string GetChildTagValueAsString(this XElement xElement, string childTagName, string defaultValue = "")
	{
		XElement xElement2 = xElement.Element(childTagName);
		if (xElement2 != null)
		{
			return xElement2.Value;
		}
		return defaultValue;
	}

	public static int GetChildTagValueAsInt(this XElement xElement, string childTagName, int defaultValue = 0)
	{
		XElement xElement2 = xElement.Element(childTagName);
		if (xElement2 != null)
		{
			return int.Parse(xElement2.Value);
		}
		return defaultValue;
	}

	public static float GetChildTagValueAsFloat(this XElement xElement, string childTagName, float defaultValue = 0f)
	{
		XElement xElement2 = xElement.Element(childTagName);
		if (xElement2 != null)
		{
			return float.Parse(xElement2.Value);
		}
		return defaultValue;
	}

	public static T Clone<T>(this T source)
	{
		if (!typeof(T).IsSerializable)
		{
			throw new ArgumentException("The type must be serializable.", "source");
		}
		if (source == null)
		{
			return default(T);
		}
		using (Stream stream = new MemoryStream())
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			((IFormatter)binaryFormatter).Serialize(stream, (object)source);
			stream.Seek(0L, SeekOrigin.Begin);
			return (T)((IFormatter)binaryFormatter).Deserialize(stream);
		}
	}

	public static string XmlSerialize<T>(this T source)
	{
		if (source == null)
		{
			return string.Empty;
		}
		if (!typeof(T).IsSerializable)
		{
			throw new ArgumentException("The type must be serializable.", "source");
		}
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			StringWriter stringWriter = new StringWriter();
			XmlWriterSettings settings = new XmlWriterSettings
			{
				OmitXmlDeclaration = true,
				Encoding = Encoding.UTF8,
				Indent = true
			};
			using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
			{
				xmlSerializer.Serialize(xmlWriter, source);
				string s = stringWriter.ToString();
				byte[] bytes = Encoding.Default.GetBytes(s);
				return Encoding.UTF8.GetString(bytes);
			}
		}
		catch (Exception innerException)
		{
			throw new Exception("An error occurred", innerException);
		}
	}

	public static T XmlDeserialize<T>(this string source)
	{
		if (source == null)
		{
			return default(T);
		}
		if (!typeof(T).IsSerializable)
		{
			throw new ArgumentException("The type must be serializable.", "source");
		}
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			using (TextReader textReader = new StringReader(source))
			{
				return (T)xmlSerializer.Deserialize(textReader);
			}
		}
		catch (Exception innerException)
		{
			throw new Exception("An error occurred", innerException);
		}
	}

	public static Vector3 TransformPoint(this Vector3 referencePosition, Quaternion referenceRotation, Vector3 localPoint)
	{
		return referencePosition + referenceRotation * localPoint;
	}

	public static Vector3 InverseTransformPoint(this Vector3 referencePosition, Quaternion referenceRotation, Vector3 worldPoint)
	{
		return Quaternion.Inverse(referenceRotation) * (worldPoint - referencePosition);
	}

	public static Vector3 InverseTransformDirection(this Quaternion referenceRotation, Vector3 worldDirection)
	{
		return Quaternion.Inverse(referenceRotation) * worldDirection;
	}

	public static Vector3 ReplaceInfinites(this Vector3 vector, float replaceValue = 0f)
	{
		if (float.IsInfinity(vector.x))
		{
			vector.x = replaceValue;
		}
		if (float.IsInfinity(vector.y))
		{
			vector.y = replaceValue;
		}
		if (float.IsInfinity(vector.z))
		{
			vector.z = replaceValue;
		}
		return vector;
	}

	public static void SetValue(this Toggle toggle, bool isOn)
	{
		Toggle.ToggleEvent onValueChanged = toggle.onValueChanged;
		toggle.onValueChanged = emptyToggleEvent;
		toggle.isOn = isOn;
		toggle.onValueChanged = onValueChanged;
	}

	public static void SetValue(this Slider slider, float value)
	{
		Slider.SliderEvent onValueChanged = slider.onValueChanged;
		slider.onValueChanged = emptySliderEvent;
		slider.value = value;
		slider.onValueChanged = onValueChanged;
	}

	public static bool IsInRange(this float value, float minLimit, float maxLimit, RangeLimits rangeLimits = RangeLimits.BothIncluded)
	{
		bool flag = false;
		switch (rangeLimits)
		{
		case RangeLimits.BothIncluded:
			return value >= minLimit && value <= maxLimit;
		case RangeLimits.BothExcluded:
			return value > minLimit && value < maxLimit;
		case RangeLimits.MinInMaxEx:
			return value >= minLimit && value < maxLimit;
		case RangeLimits.MinExMaxIn:
			return value > minLimit && value <= maxLimit;
		default:
			return value >= minLimit && value <= maxLimit;
		}
	}

	public static bool IsInRange(this float value, float[] minMaxLimits, RangeLimits rangeLimits = RangeLimits.BothIncluded)
	{
		if (minMaxLimits.Length != 2)
		{
			return false;
		}
		return value.IsInRange(minMaxLimits[0], minMaxLimits[1], rangeLimits);
	}

	public static Vector3 WithChange(this Vector3 vector, float? x = null, float? y = null, float? z = null)
	{
		if (x.HasValue)
		{
			vector.x = x.Value;
		}
		if (y.HasValue)
		{
			vector.y = y.Value;
		}
		if (z.HasValue)
		{
			vector.z = z.Value;
		}
		return vector;
	}

	public static Color WithChange(this Color color, float? r = null, float? g = null, float? b = null, float? a = null)
	{
		if (r.HasValue)
		{
			color.r = r.Value;
		}
		if (g.HasValue)
		{
			color.g = g.Value;
		}
		if (b.HasValue)
		{
			color.b = b.Value;
		}
		if (a.HasValue)
		{
			color.a = a.Value;
		}
		return color;
	}

	public static string ToRoman(this int value)
	{
		if (value < 0 || value > 3999)
		{
			throw new ArgumentOutOfRangeException("Insert value betwheen 1 and 3999!");
		}
		if (value < 1)
		{
			return string.Empty;
		}
		if (value >= 1000)
		{
			return "M" + (value - 1000).ToRoman();
		}
		if (value >= 900)
		{
			return "CM" + (value - 900).ToRoman();
		}
		if (value >= 500)
		{
			return "D" + (value - 500).ToRoman();
		}
		if (value >= 400)
		{
			return "CD" + (value - 400).ToRoman();
		}
		if (value >= 100)
		{
			return "C" + (value - 100).ToRoman();
		}
		if (value >= 90)
		{
			return "XC" + (value - 90).ToRoman();
		}
		if (value >= 50)
		{
			return "L" + (value - 50).ToRoman();
		}
		if (value >= 40)
		{
			return "XL" + (value - 40).ToRoman();
		}
		if (value >= 10)
		{
			return "X" + (value - 10).ToRoman();
		}
		if (value >= 9)
		{
			return "IX" + (value - 9).ToRoman();
		}
		if (value >= 5)
		{
			return "V" + (value - 5).ToRoman();
		}
		if (value >= 4)
		{
			return "IV" + (value - 4).ToRoman();
		}
		if (value >= 1)
		{
			return "I" + (value - 1).ToRoman();
		}
		throw new ArgumentOutOfRangeException("Failed to convert (" + value + ") to roman numerals!");
	}

	public static string ReplaceFirst(this string text, string oldValue, string newValue)
	{
		int num = text.IndexOf(oldValue);
		if (num < 0)
		{
			return text;
		}
		return text.Substring(0, num) + newValue + text.Substring(num + oldValue.Length);
	}

	public static bool SetBoolIfExist(this Animator animator, string name, bool value)
	{
		bool flag = false;
		AnimatorControllerParameter[] parameters = animator.parameters;
		for (int i = 0; i < parameters.Length; i++)
		{
			if (parameters[i].name == name)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			animator.SetBool(name, value);
		}
		return flag;
	}
}
