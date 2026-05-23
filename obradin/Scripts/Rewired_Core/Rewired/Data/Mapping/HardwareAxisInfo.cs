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

		public AxisCoordinateMode dataFormat
		{
			get
			{
				return _dataFormat;
			}
		}

		public bool excludeFromPolling
		{
			get
			{
				return _excludeFromPolling;
			}
		}

		public SpecialAxisType specialAxisType
		{
			get
			{
				return _specialAxisType;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareAxisInfo Default
		{
			get
			{
				return new HardwareAxisInfo(AxisCoordinateMode.Absolute, false, SpecialAxisType.None);
			}
		}

		public HardwareAxisInfo()
		{
			_dataFormat = AxisCoordinateMode.Absolute;
			_excludeFromPolling = false;
			_specialAxisType = SpecialAxisType.None;
		}

		[CustomObfuscation(rename = false)]
		internal HardwareAxisInfo(AxisCoordinateMode dataFormat, bool excludeFromPolling, SpecialAxisType specialAxisType)
		{
			while (true)
			{
				int num = 450201012;
				while (true)
				{
					switch (num ^ 0x1AD585B5)
					{
					case 3:
						break;
					case 1:
						_dataFormat = dataFormat;
						num = 450201015;
						continue;
					case 2:
						_excludeFromPolling = excludeFromPolling;
						num = 450201013;
						continue;
					default:
						_specialAxisType = specialAxisType;
						return;
					}
					break;
				}
			}
		}

		public object DeepClone()
		{
			return new HardwareAxisInfo(_dataFormat, _excludeFromPolling, _specialAxisType);
		}
	}
}
