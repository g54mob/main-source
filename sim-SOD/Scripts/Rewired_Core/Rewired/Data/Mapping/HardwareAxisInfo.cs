using System;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public class HardwareAxisInfo : IDeepCloneable
	{
		[SerializeField]
		internal AxisCoordinateMode _dataFormat;

		[SerializeField]
		internal bool _excludeFromPolling;

		[SerializeField]
		internal SpecialAxisType _specialAxisType;

		[SerializeField]
		internal float _pollingDeadZone;

		public AxisCoordinateMode dataFormat => default(AxisCoordinateMode);

		public bool excludeFromPolling => false;

		public SpecialAxisType specialAxisType => default(SpecialAxisType);

		public float pollingDeadZone => 0f;

		[CustomObfuscation(rename = false)]
		internal static HardwareAxisInfo Default => null;

		public HardwareAxisInfo()
		{
		}

		[CustomObfuscation(rename = false)]
		internal HardwareAxisInfo(AxisCoordinateMode dataFormat, bool excludeFromPolling, float pollingDeadZone, SpecialAxisType specialAxisType)
		{
		}

		public object DeepClone()
		{
			return null;
		}
	}
}
