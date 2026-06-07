using System;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Input
{
	[Serializable]
	public class InputControllerInputRange
	{
		private static readonly char[] _StringSplitCharacters = new char[1] { ',' };

		private bool _invertResult;

		private float _maxRangeInverse;

		[SerializeField]
		private float _maxValue;

		private float _minRangeInverse;

		[SerializeField]
		private float _minValue;

		[SerializeField]
		private float _zeroValue;

		public InputControllerInputRange(float min, float zero, float max, bool invert)
		{
			float num = zero - min;
			float num2 = max - zero;
			_minValue = min;
			_maxValue = max;
			_zeroValue = zero;
			_invertResult = invert;
			_minRangeInverse = (Mathf.Approximately(num, 0f) ? 0f : (1f / num));
			_maxRangeInverse = (Mathf.Approximately(num2, 0f) ? 0f : (1f / num2));
		}

		public static InputControllerInputRange Create(XAttribute xml)
		{
			if (xml == null)
			{
				return null;
			}
			return Create(((string)xml) ?? string.Empty);
		}

		public static InputControllerInputRange Create(string value)
		{
			if (value == null)
			{
				return null;
			}
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			bool invert = false;
			string[] array = value.Split(_StringSplitCharacters, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 1)
			{
				num3 = 0f;
				num = 0f;
				num2 = float.Parse(array[0]);
				if (num2 == 0f)
				{
					return null;
				}
				if (num2 < 0f)
				{
					num = num2;
					num2 = 0f;
					invert = true;
				}
			}
			else if (array.Length == 2)
			{
				num = float.Parse(array[0]);
				num2 = float.Parse(array[1]);
				num3 = num + (num2 - num) * 0.5f;
				if (num > num2)
				{
					float num4 = num;
					num = num2;
					num2 = num4;
					invert = true;
				}
			}
			else
			{
				if (array.Length != 3)
				{
					return null;
				}
				num = float.Parse(array[0]);
				num3 = float.Parse(array[1]);
				num2 = float.Parse(array[2]);
				if (num >= num3 && num3 >= num2)
				{
					float num5 = num;
					num = num2;
					num2 = num5;
					invert = true;
				}
				else if (!(num <= num3) || !(num3 <= num2))
				{
					Debug.LogError("Input range '" + value + "' is not an ascending or descending 'min,zero,max' set of values.");
					return null;
				}
			}
			return new InputControllerInputRange(num, num3, num2, invert);
		}

		public bool HasValues()
		{
			if (_minValue == 0f && _maxValue == 0f)
			{
				return _zeroValue != 0f;
			}
			return true;
		}

		public float RemapInput(float input)
		{
			float num = ((input < _zeroValue) ? _minRangeInverse : _maxRangeInverse);
			float num2 = (input - _zeroValue) * num;
			if (num2 > 1f)
			{
				num2 = 1f;
			}
			else if (num2 < -1f)
			{
				num2 = -1f;
			}
			if (!_invertResult)
			{
				return num2;
			}
			return 0f - num2;
		}

		public XAttribute SaveXml(string attributeName)
		{
			float zeroValue = _zeroValue;
			float num = (_invertResult ? _maxValue : _minValue);
			float num2 = (_invertResult ? _minValue : _maxValue);
			XAttribute xAttribute = new XAttribute(attributeName, string.Empty);
			if (Mathf.Approximately(zeroValue, 0f) && Mathf.Approximately(num, 0f))
			{
				xAttribute.Value = $"{num2}";
			}
			else if (Mathf.Approximately(_minRangeInverse, _maxRangeInverse))
			{
				xAttribute.Value = $"{num},{num2}";
			}
			else
			{
				xAttribute.Value = $"{num},{zeroValue},{num2}";
			}
			return xAttribute;
		}
	}
}
