using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Jundroo.Common.Animation;
using UnityEngine;

namespace Jundroo.Common.DataTypes
{
	public class UserCurve
	{
		public enum CurveStyle
		{
			Custom = 0,
			SmoothUnclamped = 1,
			Linear = 2,
			Constant = 3,
			Smooth = 4
		}

		public enum CurveWrapMode
		{
			Loop = 2,
			PingPong = 4,
			Clamp = 8
		}

		private static readonly char[] _separatorKeyframe = new char[1] { '|' };

		private static readonly char[] _separatorKeyframeValues = new char[1] { ',' };

		private float _amplitude;

		private float _currentTime;

		private AnimationCurve _curve;

		private float _frequency;

		private float _modulusTime;

		private CurveStyle _style;

		private CurveWrapMode _wrapMode;

		private string _xmlName;

		public float Amplitude
		{
			get
			{
				return _amplitude;
			}
			set
			{
				_amplitude = value;
			}
		}

		public float CurrentTime
		{
			get
			{
				return _currentTime;
			}
			set
			{
				_currentTime = value % _modulusTime;
			}
		}

		public AnimationCurve Curve
		{
			get
			{
				return _curve;
			}
			set
			{
				_curve = value;
				if (_curve != null && _curve.length > 0)
				{
					_curve.SetTangents((AnimationCurveTangentMode)_style);
					UpdateModulusTime();
				}
			}
		}

		public float Frequency
		{
			get
			{
				return _frequency;
			}
			set
			{
				_frequency = value;
				UpdateModulusTime();
			}
		}

		public CurveStyle Style
		{
			get
			{
				return _style;
			}
			set
			{
				if (_style != value)
				{
					_style = value;
					if (_curve != null && _curve.length > 0)
					{
						_curve.SetTangents((AnimationCurveTangentMode)_style);
					}
				}
			}
		}

		public CurveWrapMode WrapMode
		{
			get
			{
				return _wrapMode;
			}
			set
			{
				_wrapMode = value;
				if (_curve != null)
				{
					_curve.preWrapMode = (WrapMode)value;
					_curve.postWrapMode = (WrapMode)value;
				}
			}
		}

		public string XmlName
		{
			get
			{
				return _xmlName;
			}
			set
			{
				_xmlName = value;
			}
		}

		public UserCurve(string xmlName, CurveStyle style, CurveWrapMode wrapMode, params Keyframe[] keyframes)
		{
			_xmlName = xmlName;
			_style = style;
			_frequency = 1f;
			_amplitude = 1f;
			_wrapMode = wrapMode;
			_curve = new AnimationCurve(keyframes);
			_curve.SetTangents((AnimationCurveTangentMode)_style);
			_curve.postWrapMode = (WrapMode)wrapMode;
			_curve.preWrapMode = (WrapMode)wrapMode;
			UpdateModulusTime();
		}

		public UserCurve(string xmlName, AnimationCurve curve, CurveStyle style, CurveWrapMode wrapMode, float frequency, float amplitude)
		{
			_xmlName = xmlName;
			_style = style;
			_frequency = frequency;
			_amplitude = amplitude;
			_wrapMode = wrapMode;
			_curve = curve;
			_curve.postWrapMode = (WrapMode)wrapMode;
			_curve.preWrapMode = (WrapMode)wrapMode;
			UpdateModulusTime();
		}

		public static void AddKeyframes(AnimationCurve curve, string keyframes)
		{
			string[] array = (keyframes ?? string.Empty).Split(_separatorKeyframe, StringSplitOptions.RemoveEmptyEntries);
			foreach (string text in array)
			{
				try
				{
					string[] array2 = text.Split(_separatorKeyframeValues, StringSplitOptions.RemoveEmptyEntries);
					Keyframe key;
					if (array2.Length == 2)
					{
						key = new Keyframe(DataIO.ParseFloat(array2[0]), DataIO.ParseFloat(array2[1]));
						goto IL_00c2;
					}
					if (array2.Length == 3)
					{
						float num = DataIO.ParseFloat(array2[2]);
						key = new Keyframe(DataIO.ParseFloat(array2[0]), DataIO.ParseFloat(array2[1]), num, num);
						goto IL_00c2;
					}
					if (array2.Length == 4)
					{
						key = new Keyframe(DataIO.ParseFloat(array2[0]), DataIO.ParseFloat(array2[1]), DataIO.ParseFloat(array2[2]), DataIO.ParseFloat(array2[3]));
						goto IL_00c2;
					}
					Debug.LogError("Keyframe not in the correct format");
					goto end_IL_0021;
					IL_00c2:
					curve.AddKey(key);
					end_IL_0021:;
				}
				catch (Exception exception)
				{
					Debug.LogError("Keyframe not in the correct format");
					Debug.LogException(exception);
				}
			}
		}

		public static string GetKeyframesAsString(AnimationCurve curve, CurveStyle style)
		{
			Keyframe[] keys = curve.keys;
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = style == CurveStyle.Custom;
			char value = _separatorKeyframe[0];
			char value2 = _separatorKeyframeValues[0];
			for (int i = 0; i < keys.Length; i++)
			{
				if (i != 0)
				{
					stringBuilder.Append(value);
				}
				if (flag)
				{
					stringBuilder.Append(DataIO.ToString(keys[i].time));
					stringBuilder.Append(value2);
					stringBuilder.Append(DataIO.ToString(keys[i].value));
					stringBuilder.Append(value2);
					stringBuilder.Append(DataIO.ToString(keys[i].inTangent));
					stringBuilder.Append(value2);
					stringBuilder.Append(DataIO.ToString(keys[i].outTangent));
				}
				else
				{
					stringBuilder.Append(DataIO.ToString(keys[i].time));
					stringBuilder.Append(value2);
					stringBuilder.Append(DataIO.ToString(keys[i].value));
				}
			}
			return stringBuilder.ToString();
		}

		public static UserCurve RestoreFromXml(XElement xml, string xmlName, CurveWrapMode defaultWrapMode)
		{
			CurveStyle enumAttribute = xml.GetEnumAttribute(xmlName + "Style", CurveStyle.Smooth);
			float floatAttribute = xml.GetFloatAttribute(xmlName + "Frequency", 1f);
			float floatAttribute2 = xml.GetFloatAttribute(xmlName + "Amplitude", 1f);
			string stringAttribute = xml.GetStringAttribute(xmlName + "Keyframes", string.Empty);
			CurveWrapMode enumAttribute2 = xml.GetEnumAttribute(xmlName + "WrapMode", defaultWrapMode);
			AnimationCurve animationCurve = new AnimationCurve();
			AddKeyframes(animationCurve, stringAttribute);
			animationCurve.SetTangents((AnimationCurveTangentMode)enumAttribute);
			return new UserCurve(xmlName, animationCurve, enumAttribute, enumAttribute2, floatAttribute, floatAttribute2);
		}

		public void GenerateXml(XElement xml)
		{
			string keyframesAsString = GetKeyframesAsString();
			xml.SetAttributeValue(_xmlName + "Style", _style);
			xml.SetAttributeValue(_xmlName + "Keyframes", keyframesAsString);
			xml.SetAttributeValue(_xmlName + "Amplitude", _amplitude);
			xml.SetAttributeValue(_xmlName + "Frequency", _frequency);
			xml.SetAttributeValue(_xmlName + "WrapMode", _wrapMode);
		}

		public string GetKeyframesAsString()
		{
			return GetKeyframesAsString(_curve, _style);
		}

		public float GetValue(double elapsedTime)
		{
			_currentTime = (float)(((double)_currentTime + elapsedTime) % (double)_modulusTime);
			return _curve.Evaluate(_currentTime * _frequency) * _amplitude;
		}

		public float GetValue(float elapsedTime)
		{
			_currentTime = (_currentTime + elapsedTime) % _modulusTime;
			return _curve.Evaluate(_currentTime * _frequency) * _amplitude;
		}

		public float GetValueAtCurrentTime()
		{
			return _curve.Evaluate(_currentTime * _frequency) * _amplitude;
		}

		public float GetValueAtTime(float time)
		{
			return _curve.Evaluate(time * _frequency) * _amplitude;
		}

		public void SetKeyframes(IEnumerable<Keyframe> keyframes)
		{
			_curve.keys = keyframes.ToArray();
			_curve.SetTangents((AnimationCurveTangentMode)_style);
			UpdateModulusTime();
		}

		public void SetKeyframes(Keyframe[] keyframes)
		{
			_curve.keys = keyframes;
			_curve.SetTangents((AnimationCurveTangentMode)_style);
			UpdateModulusTime();
		}

		public void SetKeyframes(string keyframes)
		{
			_curve.keys = new Keyframe[0];
			AddKeyframes(_curve, keyframes);
			_curve.SetTangents((AnimationCurveTangentMode)_style);
			UpdateModulusTime();
		}

		private void UpdateModulusTime()
		{
			Keyframe[] array = Curve?.keys;
			if (array == null || array.Length == 0)
			{
				_modulusTime = float.MaxValue;
				return;
			}
			float num = array[^1].time - array[0].time;
			_modulusTime = num * 2f / _frequency;
			if (_modulusTime == 0f)
			{
				_modulusTime = float.MaxValue;
			}
		}
	}
}
