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

		public AxisCalibrationData(bool P_0, float P_1, float P_2, float P_3, float P_4, bool P_5, bool P_6)
		{
			enabled = false;
			deadZone = 0f;
			zero = 0f;
			min = 0f;
			max = 0f;
			invert = false;
			sensitivityType = default(AxisSensitivityType);
			sensitivity = 0f;
			sensitivityCurve = null;
			applyRangeCalibration = false;
			calibrations = null;
		}

		public AxisCalibrationData(bool P_0, float P_1, float P_2, float P_3, float P_4, bool P_5, bool P_6, float P_7)
		{
			enabled = false;
			deadZone = 0f;
			zero = 0f;
			min = 0f;
			max = 0f;
			invert = false;
			sensitivityType = default(AxisSensitivityType);
			sensitivity = 0f;
			sensitivityCurve = null;
			applyRangeCalibration = false;
			calibrations = null;
		}

		public AxisCalibrationData(bool P_0, float P_1, float P_2, float P_3, float P_4, bool P_5, bool P_6, AxisSensitivityType P_7, float P_8, AnimationCurve P_9)
		{
			enabled = false;
			deadZone = 0f;
			zero = 0f;
			min = 0f;
			max = 0f;
			invert = false;
			sensitivityType = default(AxisSensitivityType);
			sensitivity = 0f;
			sensitivityCurve = null;
			applyRangeCalibration = false;
			calibrations = null;
		}
	}
}
