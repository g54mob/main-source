using System;
using System.Collections.Generic;
using System.Linq;
using UIScripts.InfoHandles;
using UnityEngine;

namespace SettingScripts
{
	[Serializable]
	public abstract class NumericSetting<TValueType> : Setting<TValueType>
	{
		[NonSerialized]
		public TValueType minValue;

		[NonSerialized]
		public TValueType maxValue;

		[NonSerialized]
		public int precision;

		[NonSerialized]
		public string prefix = "";

		[NonSerialized]
		public string units = "";

		[NonSerialized]
		public float factor = 1f;

		[NonSerialized]
		public bool alwaysShowSign;

		[NonSerialized]
		public bool canGoOutOfBounds = true;

		[NonSerialized]
		public bool SI = true;

		[NonSerialized]
		public List<SettingLandmarkValues<TValueType>> landmarks;

		public bool canBeNegative => (dynamic)minValue < 0f;

		public abstract FloatValueFormat formatting { get; }

		public void SetMinMax(TValueType newMin, TValueType newMax)
		{
			minValue = newMin;
			maxValue = newMax;
		}

		public override void SetValue(TValueType _value)
		{
			if (!canGoOutOfBounds)
			{
				_value = (((dynamic)_value < (dynamic)minValue) ? minValue : (((dynamic)_value > (dynamic)maxValue) ? maxValue : _value));
			}
			base.SetValue(_value);
		}

		public void SetClosestLandmark(TValueType newValue)
		{
			SettingLandmarkValues<TValueType> settingLandmarkValues = landmarks.OrderBy((SettingLandmarkValues<TValueType> l) => Mathf.Abs((dynamic)l.value - (dynamic)newValue)).FirstOrDefault();
			if (settingLandmarkValues != null)
			{
				SetValue(settingLandmarkValues.value);
			}
		}
	}
}
