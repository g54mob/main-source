using System.Collections.Generic;
using Rewired.Data.Mapping;
using UnityEngine;

namespace Rewired
{
	public struct AxisCalibrationData
	{
		public bool enabled;

		public float deadZone;

		public float zero;

		public float min;

		public float max;

		public bool invert;

		public AxisSensitivityType sensitivityType;

		public float sensitivity;

		public AnimationCurve sensitivityCurve;

		public bool applyRangeCalibration;

		[CustomObfuscation]
		internal Dictionary<int, AxisCalibrationInfo> calibrations;

		public static AxisCalibrationData Default => default(AxisCalibrationData);

		[CustomObfuscation]
		internal static AxisCalibrationData Raw => default(AxisCalibrationData);

		public AxisCalibrationData(bool enabled, float deadZone, float zero, float min, float max, bool invert, bool applyRangeCalibration)
		{
			this.enabled = false;
			this.deadZone = 0f;
			this.zero = 0f;
			this.min = 0f;
			this.max = 0f;
			this.invert = false;
			sensitivityType = default(AxisSensitivityType);
			sensitivity = 0f;
			sensitivityCurve = null;
			this.applyRangeCalibration = false;
			calibrations = null;
		}

		public AxisCalibrationData(bool enabled, float deadZone, float zero, float min, float max, bool invert, bool applyRangeCalibration, float sensitivity)
		{
			this.enabled = false;
			this.deadZone = 0f;
			this.zero = 0f;
			this.min = 0f;
			this.max = 0f;
			this.invert = false;
			sensitivityType = default(AxisSensitivityType);
			this.sensitivity = 0f;
			sensitivityCurve = null;
			this.applyRangeCalibration = false;
			calibrations = null;
		}

		public AxisCalibrationData(bool enabled, float deadZone, float zero, float min, float max, bool invert, bool applyRangeCalibration, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			this.enabled = false;
			this.deadZone = 0f;
			this.zero = 0f;
			this.min = 0f;
			this.max = 0f;
			this.invert = false;
			this.sensitivityType = default(AxisSensitivityType);
			this.sensitivity = 0f;
			this.sensitivityCurve = null;
			this.applyRangeCalibration = false;
			calibrations = null;
		}
	}
}
