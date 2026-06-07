using System;
using System.Threading;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Internal
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class StandaloneAxis2D
	{
		[CustomObfuscation(rename = false)]
		public delegate void ValueChangedEventHandler(Vector2 value);

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Contains calibration settings for the 2D axis.")]
		private Axis2DCalibration _calibration = new Axis2DCalibration();

		[CustomObfuscation(rename = false)]
		[Tooltip("The X axis.")]
		[SerializeField]
		private StandaloneAxis _xAxis = new StandaloneAxis();

		[CustomObfuscation(rename = false)]
		[Tooltip("The Y axis.")]
		[SerializeField]
		private StandaloneAxis _yAxis = new StandaloneAxis();

		private bool _allowEvents = true;

		private ValueChangedEventHandler m__ValueChangedEvent;

		private ValueChangedEventHandler m__RawValueChangedEvent;

		public Axis2DCalibration calibration
		{
			get
			{
				return _calibration;
			}
		}

		public StandaloneAxis xAxis
		{
			get
			{
				return _xAxis;
			}
		}

		public StandaloneAxis yAxis
		{
			get
			{
				return _yAxis;
			}
		}

		public Vector2 value
		{
			get
			{
				return GetCalibratedValue(_xAxis, _yAxis);
			}
		}

		public Vector2 valuePrev
		{
			get
			{
				return GetCalibratedValuePrev(_xAxis, _yAxis);
			}
		}

		public Vector2 valueDelta
		{
			get
			{
				return value - valuePrev;
			}
		}

		public Vector2 rawValue
		{
			get
			{
				return new Vector2((_xAxis != null) ? _xAxis.value : 0f, (_yAxis != null) ? _yAxis.value : 0f);
			}
		}

		public Vector2 rawValuePrev
		{
			get
			{
				return new Vector2((_xAxis != null) ? _xAxis.valuePrev : 0f, (_yAxis != null) ? _yAxis.valuePrev : 0f);
			}
		}

		public Vector2 rawValueDelta
		{
			get
			{
				return rawValue - rawValuePrev;
			}
		}

		internal Vector2 rawZero
		{
			get
			{
				return new Vector2((_xAxis != null) ? _xAxis.rawZero : 0f, (_yAxis != null) ? _yAxis.rawZero : 0f);
			}
		}

		private event ValueChangedEventHandler _ValueChangedEvent
		{
			add
			{
				ValueChangedEventHandler valueChangedEventHandler = this.m__ValueChangedEvent;
				while (true)
				{
					int num = -640296125;
					while (true)
					{
						switch (num ^ -640296127)
						{
						case 0:
							break;
						default:
							return;
						case 2:
						{
							ValueChangedEventHandler valueChangedEventHandler2 = valueChangedEventHandler;
							ValueChangedEventHandler valueChangedEventHandler3 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
							valueChangedEventHandler = Interlocked.CompareExchange(ref this.m__ValueChangedEvent, valueChangedEventHandler3, valueChangedEventHandler2);
							int num2;
							if ((object)valueChangedEventHandler != valueChangedEventHandler2)
							{
								num = -640296125;
								num2 = num;
							}
							else
							{
								num = -640296128;
								num2 = num;
							}
							continue;
						}
						case 1:
							return;
						}
						break;
					}
				}
			}
			remove
			{
				ValueChangedEventHandler valueChangedEventHandler = this.m__ValueChangedEvent;
				ValueChangedEventHandler valueChangedEventHandler2 = default(ValueChangedEventHandler);
				while (true)
				{
					int num = 1330674970;
					while (true)
					{
						switch (num ^ 0x4F507D1B)
						{
						case 3:
							break;
						case 1:
							valueChangedEventHandler2 = valueChangedEventHandler;
							num = 1330674971;
							continue;
						case 0:
						{
							ValueChangedEventHandler valueChangedEventHandler3 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler2, value);
							valueChangedEventHandler = Interlocked.CompareExchange(ref this.m__ValueChangedEvent, valueChangedEventHandler3, valueChangedEventHandler2);
							num = 1330674969;
							continue;
						}
						default:
							if ((object)valueChangedEventHandler == valueChangedEventHandler2)
							{
								return;
							}
							goto case 1;
						}
						break;
					}
				}
			}
		}

		public event ValueChangedEventHandler ValueChangedEvent
		{
			add
			{
				_ValueChangedEvent += value;
			}
			remove
			{
				_ValueChangedEvent -= value;
			}
		}

		private event ValueChangedEventHandler _RawValueChangedEvent
		{
			add
			{
				ValueChangedEventHandler valueChangedEventHandler = this.m__RawValueChangedEvent;
				ValueChangedEventHandler valueChangedEventHandler2;
				do
				{
					valueChangedEventHandler2 = valueChangedEventHandler;
					ValueChangedEventHandler valueChangedEventHandler3 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
					valueChangedEventHandler = Interlocked.CompareExchange(ref this.m__RawValueChangedEvent, valueChangedEventHandler3, valueChangedEventHandler2);
				}
				while ((object)valueChangedEventHandler != valueChangedEventHandler2);
			}
			remove
			{
				ValueChangedEventHandler valueChangedEventHandler = this.m__RawValueChangedEvent;
				ValueChangedEventHandler valueChangedEventHandler3 = default(ValueChangedEventHandler);
				while (true)
				{
					int num = 47852604;
					while (true)
					{
						switch (num ^ 0x2DA2C3D)
						{
						case 0:
							break;
						case 1:
							goto IL_0025;
						default:
						{
							ValueChangedEventHandler valueChangedEventHandler2 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler3, value);
							valueChangedEventHandler = Interlocked.CompareExchange(ref this.m__RawValueChangedEvent, valueChangedEventHandler2, valueChangedEventHandler3);
							if ((object)valueChangedEventHandler != valueChangedEventHandler3)
							{
								goto IL_0025;
							}
							return;
						}
						}
						break;
						IL_0025:
						valueChangedEventHandler3 = valueChangedEventHandler;
						num = 47852607;
					}
				}
			}
		}

		public event ValueChangedEventHandler RawValueChangedEvent
		{
			add
			{
				_RawValueChangedEvent += value;
			}
			remove
			{
				_RawValueChangedEvent -= value;
			}
		}

		internal StandaloneAxis2D()
		{
		}

		internal StandaloneAxis2D(StandaloneAxis xAxis, StandaloneAxis yAxis)
		{
			_xAxis = xAxis;
			_yAxis = yAxis;
		}

		public void SetRawValue(float x, float y)
		{
			bool allowEvents = _allowEvents;
			_allowEvents = false;
			if (_xAxis != null)
			{
				_xAxis.SetRawValue(x);
				goto IL_0022;
			}
			goto IL_0040;
			IL_005b:
			_allowEvents = allowEvents;
			EvalAndSendValueChangeEvents();
			return;
			IL_0022:
			int num = 445630320;
			goto IL_0027;
			IL_0027:
			switch (num ^ 0x1A8FC771)
			{
			case 0:
				break;
			case 1:
				goto IL_0040;
			default:
				goto IL_005b;
			}
			goto IL_0022;
			IL_0040:
			if (_yAxis != null)
			{
				_yAxis.SetRawValue(y);
				num = 445630323;
				goto IL_0027;
			}
			goto IL_005b;
		}

		public void SetRawValue(Vector2 value)
		{
			SetRawValue(value.x, value.y);
		}

		public void Clear()
		{
			bool allowEvents = _allowEvents;
			_allowEvents = false;
			if (_xAxis != null)
			{
				goto IL_0016;
			}
			goto IL_006d;
			IL_0016:
			int num = 140937499;
			goto IL_001b;
			IL_001b:
			while (true)
			{
				switch (num ^ 0x8668918)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					_xAxis.Clear();
					num = 140937501;
					continue;
				case 2:
					EvalAndSendValueChangeEvents();
					num = 140937497;
					continue;
				case 4:
					goto IL_005f;
				case 5:
					goto IL_006d;
				case 1:
					return;
				}
				break;
			}
			goto IL_0016;
			IL_006d:
			if (_yAxis != null)
			{
				_yAxis.Clear();
				num = 140937500;
				goto IL_001b;
			}
			goto IL_005f;
			IL_005f:
			_allowEvents = allowEvents;
			num = 140937498;
			goto IL_001b;
		}

		internal void Initialize()
		{
			Subscribe();
		}

		internal void Deinitialize()
		{
			Unsubscribe();
		}

		private void EvalAndSendValueChangeEvents()
		{
			if (_allowEvents)
			{
				goto IL_000b;
			}
			goto IL_00ca;
			IL_000b:
			int num = -1673085689;
			goto IL_0010;
			IL_0010:
			Vector2 vector = default(Vector2);
			while (true)
			{
				switch (num ^ -1673085690)
				{
				case 3:
					break;
				default:
					return;
				case 7:
					if (this._ValueChangedEvent != null)
					{
						this._ValueChangedEvent(value);
						num = -1673085696;
						continue;
					}
					return;
				case 2:
					goto IL_0063;
				case 1:
					return;
				case 4:
					goto IL_00a8;
				case 0:
					goto IL_00ca;
				case 5:
					if (!MathTools.ApproximatelyZero(vector.y) && this._RawValueChangedEvent != null)
					{
						this._RawValueChangedEvent(rawValue);
						num = -1673085692;
						continue;
					}
					goto IL_0063;
				case 6:
					return;
				}
				break;
				IL_00a8:
				int num2;
				if (MathTools.ApproximatelyZero(vector.x))
				{
					num = -1673085692;
					num2 = num;
				}
				else
				{
					num = -1673085693;
					num2 = num;
				}
				continue;
				IL_0063:
				Vector2 vector2 = valueDelta;
				if (!MathTools.ApproximatelyZero(vector2.x))
				{
					int num3;
					if (MathTools.ApproximatelyZero(vector2.y))
					{
						num = -1673085696;
						num3 = num;
					}
					else
					{
						num = -1673085695;
						num3 = num;
					}
					continue;
				}
				return;
			}
			goto IL_000b;
			IL_00ca:
			vector = rawValueDelta;
			num = -1673085694;
			goto IL_0010;
		}

		private void Subscribe()
		{
			Unsubscribe();
			if (_xAxis != null)
			{
				_xAxis.AxisValueChangedEvent += OnAxisValueChanged;
				goto IL_0028;
			}
			goto IL_00ac;
			IL_00ac:
			int num;
			int num2;
			if (_yAxis == null)
			{
				num = -510888745;
				num2 = num;
			}
			else
			{
				num = -510888749;
				num2 = num;
			}
			goto IL_002d;
			IL_0028:
			num = -510888746;
			goto IL_002d;
			IL_002d:
			while (true)
			{
				switch (num ^ -510888749)
				{
				case 3:
					break;
				default:
					return;
				case 5:
					_xAxis.RawAxisValueChangedEvent += OnAxisRawValueChanged;
					num = -510888750;
					continue;
				case 2:
					_yAxis.RawAxisValueChangedEvent += OnAxisRawValueChanged;
					num = -510888745;
					continue;
				case 0:
					_yAxis.AxisValueChangedEvent += OnAxisValueChanged;
					num = -510888751;
					continue;
				case 1:
					goto IL_00ac;
				case 4:
					return;
				}
				break;
			}
			goto IL_0028;
		}

		private void Unsubscribe()
		{
			if (_xAxis != null)
			{
				_xAxis.AxisValueChangedEvent -= OnAxisValueChanged;
				_xAxis.RawAxisValueChangedEvent -= OnAxisRawValueChanged;
				goto IL_0039;
			}
			goto IL_009b;
			IL_009b:
			int num;
			int num2;
			if (_yAxis != null)
			{
				num = -1112196529;
				num2 = num;
			}
			else
			{
				num = -1112196533;
				num2 = num;
			}
			goto IL_003e;
			IL_0039:
			num = -1112196530;
			goto IL_003e;
			IL_003e:
			while (true)
			{
				switch (num ^ -1112196529)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					_yAxis.RawAxisValueChangedEvent -= OnAxisRawValueChanged;
					num = -1112196533;
					continue;
				case 0:
					_yAxis.AxisValueChangedEvent -= OnAxisValueChanged;
					num = -1112196532;
					continue;
				case 1:
					goto IL_009b;
				case 4:
					return;
				}
				break;
			}
			goto IL_0039;
		}

		private Vector2 GetCalibratedValue(StandaloneAxis xAxis, StandaloneAxis yAxis)
		{
			if (_calibration == null)
			{
				return Vector2.zero;
			}
			if (xAxis == null)
			{
				goto IL_0053;
			}
			AxisCalibration axisCalibration = xAxis.calibration;
			float valueRawX = xAxis.valueRaw;
			goto IL_0076;
			IL_0053:
			axisCalibration = null;
			int num = 92393132;
			goto IL_0026;
			IL_0026:
			float valueRawY = default(float);
			AxisCalibration axisCalibration2 = default(AxisCalibration);
			while (true)
			{
				switch (num ^ 0x581CEAB)
				{
				case 0:
					num = 92393129;
					continue;
				case 2:
					break;
				case 5:
					valueRawY = 0f;
					num = 92393135;
					continue;
				case 7:
					valueRawX = 0f;
					num = 92393133;
					continue;
				case 6:
					goto IL_0076;
				case 3:
					axisCalibration2 = null;
					num = 92393134;
					continue;
				case 1:
					axisCalibration2 = yAxis.calibration;
					valueRawY = yAxis.valueRaw;
					num = 92393135;
					continue;
				default:
					return _calibration.GetCalibrated2DValue(valueRawX, valueRawY, axisCalibration, axisCalibration2);
				}
				break;
			}
			goto IL_0053;
			IL_0076:
			int num2;
			if (yAxis == null)
			{
				num = 92393128;
				num2 = num;
			}
			else
			{
				num = 92393130;
				num2 = num;
			}
			goto IL_0026;
		}

		private Vector2 GetCalibratedValuePrev(StandaloneAxis xAxis, StandaloneAxis yAxis)
		{
			if (_calibration == null)
			{
				return Vector2.zero;
			}
			AxisCalibration axisCalibration;
			float valueRawX = default(float);
			if (xAxis != null)
			{
				axisCalibration = xAxis.calibration;
				valueRawX = xAxis.valueRawPrev;
				goto IL_001f;
			}
			goto IL_005f;
			IL_0024:
			int num;
			float valueRawY = default(float);
			AxisCalibration axisCalibration2 = default(AxisCalibration);
			while (true)
			{
				switch (num ^ 0x5C522771)
				{
				case 0:
					break;
				case 1:
					valueRawY = yAxis.valueRawPrev;
					num = 1548887923;
					continue;
				case 6:
					goto IL_005f;
				case 3:
					num = 1548887926;
					continue;
				case 7:
					if (yAxis != null)
					{
						axisCalibration2 = yAxis.calibration;
						num = 1548887920;
						continue;
					}
					goto case 5;
				case 5:
					axisCalibration2 = null;
					valueRawY = 0f;
					num = 1548887923;
					continue;
				case 4:
					valueRawX = 0f;
					num = 1548887926;
					continue;
				default:
					return _calibration.GetCalibrated2DValue(valueRawX, valueRawY, axisCalibration, axisCalibration2);
				}
				break;
			}
			goto IL_001f;
			IL_005f:
			axisCalibration = null;
			num = 1548887925;
			goto IL_0024;
			IL_001f:
			num = 1548887922;
			goto IL_0024;
		}

		private void OnAxisValueChanged(float value)
		{
			if (_allowEvents)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (this._ValueChangedEvent == null)
				{
					num = 2114114096;
					num2 = num;
				}
				else
				{
					num = 2114114097;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x7E02D233)
					{
					case 0:
						num = 2114114098;
						continue;
					default:
						return;
					case 1:
						break;
					case 2:
						this._ValueChangedEvent(this.value);
						num = 2114114096;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void OnAxisRawValueChanged(float value)
		{
			if (_allowEvents)
			{
				return;
			}
			while (this._RawValueChangedEvent != null)
			{
				this._RawValueChangedEvent(rawValue);
				int num = 1587416553;
				while (true)
				{
					switch (num ^ 0x5E9E0DE8)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0009:
					num = 1587416554;
				}
			}
		}

		internal static StandaloneAxis2D CreateRelative()
		{
			StandaloneAxis2D standaloneAxis2D = new StandaloneAxis2D(StandaloneAxis.CreateRelative(), StandaloneAxis.CreateRelative());
			standaloneAxis2D.calibration.deadZoneType = DeadZone2DType.Radial;
			standaloneAxis2D.calibration.sensitivityType = AxisSensitivity2DType.Radial;
			return standaloneAxis2D;
		}
	}
}
