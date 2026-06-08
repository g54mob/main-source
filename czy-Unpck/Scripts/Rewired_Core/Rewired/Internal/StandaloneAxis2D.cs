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

		[Tooltip("The X axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _xAxis = new StandaloneAxis();

		[Tooltip("The Y axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _yAxis = new StandaloneAxis();

		private bool _allowEvents = true;

		private ValueChangedEventHandler m__ValueChangedEvent;

		private ValueChangedEventHandler m__RawValueChangedEvent;

		public Axis2DCalibration calibration => _calibration;

		public StandaloneAxis xAxis => _xAxis;

		public StandaloneAxis yAxis => _yAxis;

		public Vector2 value => GetCalibratedValue(_xAxis, _yAxis);

		public Vector2 valuePrev => GetCalibratedValuePrev(_xAxis, _yAxis);

		public Vector2 valueDelta => value - valuePrev;

		public Vector2 rawValue => new Vector2((_xAxis != null) ? _xAxis.value : 0f, (_yAxis != null) ? _yAxis.value : 0f);

		public Vector2 rawValuePrev => new Vector2((_xAxis != null) ? _xAxis.valuePrev : 0f, (_yAxis != null) ? _yAxis.valuePrev : 0f);

		public Vector2 rawValueDelta => rawValue - rawValuePrev;

		internal Vector2 rawZero => new Vector2((_xAxis != null) ? _xAxis.rawZero : 0f, (_yAxis != null) ? _yAxis.rawZero : 0f);

		private event ValueChangedEventHandler _ValueChangedEvent
		{
			add
			{
				ValueChangedEventHandler valueChangedEventHandler = this.m__ValueChangedEvent;
				ValueChangedEventHandler valueChangedEventHandler2 = default(ValueChangedEventHandler);
				ValueChangedEventHandler valueChangedEventHandler3 = default(ValueChangedEventHandler);
				while (true)
				{
					int num = 1290035288;
					while (true)
					{
						switch (num ^ 0x4CE4605B)
						{
						case 2:
							break;
						case 3:
							valueChangedEventHandler2 = valueChangedEventHandler;
							valueChangedEventHandler3 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
							num = 1290035291;
							continue;
						case 0:
							valueChangedEventHandler = Interlocked.CompareExchange(ref this.m__ValueChangedEvent, valueChangedEventHandler3, valueChangedEventHandler2);
							num = 1290035290;
							continue;
						default:
							if ((object)valueChangedEventHandler == valueChangedEventHandler2)
							{
								return;
							}
							goto case 3;
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
					int num = 1497678176;
					while (true)
					{
						switch (num ^ 0x5944C162)
						{
						case 0:
							break;
						default:
							return;
						case 2:
						{
							valueChangedEventHandler2 = valueChangedEventHandler;
							ValueChangedEventHandler valueChangedEventHandler3 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler2, value);
							valueChangedEventHandler = Interlocked.CompareExchange(ref this.m__ValueChangedEvent, valueChangedEventHandler3, valueChangedEventHandler2);
							num = 1497678177;
							continue;
						}
						case 3:
						{
							int num2;
							if ((object)valueChangedEventHandler != valueChangedEventHandler2)
							{
								num = 1497678176;
								num2 = num;
							}
							else
							{
								num = 1497678179;
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
				ValueChangedEventHandler valueChangedEventHandler2 = default(ValueChangedEventHandler);
				while (true)
				{
					int num = -1806135806;
					while (true)
					{
						switch (num ^ -1806135807)
						{
						case 0:
							break;
						default:
							return;
						case 3:
						{
							valueChangedEventHandler2 = valueChangedEventHandler;
							ValueChangedEventHandler valueChangedEventHandler3 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
							valueChangedEventHandler = Interlocked.CompareExchange(ref this.m__RawValueChangedEvent, valueChangedEventHandler3, valueChangedEventHandler2);
							num = -1806135805;
							continue;
						}
						case 2:
						{
							int num2;
							if ((object)valueChangedEventHandler == valueChangedEventHandler2)
							{
								num = -1806135808;
								num2 = num;
							}
							else
							{
								num = -1806135806;
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
				ValueChangedEventHandler valueChangedEventHandler = this.m__RawValueChangedEvent;
				ValueChangedEventHandler valueChangedEventHandler3 = default(ValueChangedEventHandler);
				ValueChangedEventHandler valueChangedEventHandler2 = default(ValueChangedEventHandler);
				while (true)
				{
					int num = -860817612;
					while (true)
					{
						switch (num ^ -860817609)
						{
						case 0:
							break;
						default:
							return;
						case 3:
							valueChangedEventHandler3 = valueChangedEventHandler;
							valueChangedEventHandler2 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler3, value);
							num = -860817611;
							continue;
						case 2:
						{
							valueChangedEventHandler = Interlocked.CompareExchange(ref this.m__RawValueChangedEvent, valueChangedEventHandler2, valueChangedEventHandler3);
							int num2;
							if ((object)valueChangedEventHandler == valueChangedEventHandler3)
							{
								num = -860817610;
								num2 = num;
							}
							else
							{
								num = -860817612;
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
			while (true)
			{
				int num = -1764234846;
				while (true)
				{
					switch (num ^ -1764234845)
					{
					case 4:
						break;
					case 5:
						if (_yAxis != null)
						{
							_yAxis.SetRawValue(y);
							num = -1764234847;
							continue;
						}
						goto default;
					case 0:
					{
						int num2;
						if (_xAxis == null)
						{
							num = -1764234842;
							num2 = num;
						}
						else
						{
							num = -1764234848;
							num2 = num;
						}
						continue;
					}
					case 1:
						_allowEvents = false;
						num = -1764234845;
						continue;
					case 3:
						_xAxis.SetRawValue(x);
						num = -1764234842;
						continue;
					default:
						_allowEvents = allowEvents;
						EvalAndSendValueChangeEvents();
						return;
					}
					break;
				}
			}
		}

		public void SetRawValue(Vector2 value)
		{
			SetRawValue(value.x, value.y);
		}

		public void Clear()
		{
			bool allowEvents = _allowEvents;
			_allowEvents = false;
			while (true)
			{
				int num = -208429992;
				while (true)
				{
					switch (num ^ -208429990)
					{
					case 3:
						break;
					case 4:
						_allowEvents = allowEvents;
						num = -208429990;
						continue;
					case 1:
						if (_yAxis != null)
						{
							_yAxis.Clear();
							num = -208429986;
							continue;
						}
						goto case 4;
					case 2:
						if (_xAxis != null)
						{
							_xAxis.Clear();
							num = -208429989;
							continue;
						}
						goto case 1;
					default:
						EvalAndSendValueChangeEvents();
						return;
					}
					break;
				}
			}
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
			goto IL_00e1;
			IL_000b:
			int num = -71928994;
			goto IL_0010;
			IL_0010:
			Vector2 vector = default(Vector2);
			Vector2 vector2 = default(Vector2);
			while (true)
			{
				switch (num ^ -71928995)
				{
				case 6:
					break;
				default:
					return;
				case 3:
					return;
				case 4:
					goto IL_0048;
				case 5:
					if (this._RawValueChangedEvent != null)
					{
						this._RawValueChangedEvent(rawValue);
						num = -71928999;
						continue;
					}
					goto IL_0048;
				case 0:
					if (!MathTools.ApproximatelyZero(vector.y) && this._ValueChangedEvent != null)
					{
						this._ValueChangedEvent(value);
						num = -71928998;
						continue;
					}
					return;
				case 2:
					goto IL_00bf;
				case 1:
					goto IL_00e1;
				case 7:
					return;
				}
				break;
				IL_00bf:
				int num2;
				if (MathTools.ApproximatelyZero(vector2.y))
				{
					num = -71928999;
					num2 = num;
				}
				else
				{
					num = -71929000;
					num2 = num;
				}
				continue;
				IL_0048:
				vector = valueDelta;
				int num3;
				if (MathTools.ApproximatelyZero(vector.x))
				{
					num = -71928998;
					num3 = num;
				}
				else
				{
					num = -71928995;
					num3 = num;
				}
			}
			goto IL_000b;
			IL_00e1:
			vector2 = rawValueDelta;
			int num4;
			if (!MathTools.ApproximatelyZero(vector2.x))
			{
				num = -71928993;
				num4 = num;
			}
			else
			{
				num = -71928999;
				num4 = num;
			}
			goto IL_0010;
		}

		private void Subscribe()
		{
			Unsubscribe();
			if (_xAxis != null)
			{
				_xAxis.AxisValueChangedEvent += OnAxisValueChanged;
				_xAxis.RawAxisValueChangedEvent += OnAxisRawValueChanged;
				goto IL_003c;
			}
			goto IL_005a;
			IL_005a:
			int num;
			if (_yAxis != null)
			{
				_yAxis.AxisValueChangedEvent += OnAxisValueChanged;
				_yAxis.RawAxisValueChangedEvent += OnAxisRawValueChanged;
				num = 1743655000;
				goto IL_0041;
			}
			return;
			IL_003c:
			num = 1743655003;
			goto IL_0041;
			IL_0041:
			switch (num ^ 0x67EE1059)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_005a;
			case 1:
				return;
			}
			goto IL_003c;
		}

		private void Unsubscribe()
		{
			if (_xAxis != null)
			{
				_xAxis.AxisValueChangedEvent -= OnAxisValueChanged;
				_xAxis.RawAxisValueChangedEvent -= OnAxisRawValueChanged;
				goto IL_0036;
			}
			goto IL_0058;
			IL_0058:
			int num;
			int num2;
			if (_yAxis == null)
			{
				num = -1633270386;
				num2 = num;
			}
			else
			{
				num = -1633270387;
				num2 = num;
			}
			goto IL_003b;
			IL_0036:
			num = -1633270385;
			goto IL_003b;
			IL_003b:
			while (true)
			{
				switch (num ^ -1633270386)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					goto IL_0058;
				case 3:
					_yAxis.AxisValueChangedEvent -= OnAxisValueChanged;
					_yAxis.RawAxisValueChangedEvent -= OnAxisRawValueChanged;
					num = -1633270386;
					continue;
				case 0:
					return;
				}
				break;
			}
			goto IL_0036;
		}

		private Vector2 GetCalibratedValue(StandaloneAxis xAxis, StandaloneAxis yAxis)
		{
			if (_calibration == null)
			{
				return Vector2.zero;
			}
			AxisCalibration axisCalibration;
			if (xAxis != null)
			{
				axisCalibration = xAxis.calibration;
				goto IL_001b;
			}
			goto IL_00b3;
			IL_00b3:
			axisCalibration = null;
			float valueRawX = 0f;
			int num = -903306620;
			goto IL_0020;
			IL_0020:
			AxisCalibration axisCalibration2 = default(AxisCalibration);
			float valueRawY = default(float);
			while (true)
			{
				switch (num ^ -903306620)
				{
				case 7:
					break;
				case 8:
					num = -903306618;
					continue;
				case 3:
					axisCalibration2 = yAxis.calibration;
					num = -903306624;
					continue;
				case 4:
					valueRawY = yAxis.valueRaw;
					num = -903306612;
					continue;
				case 1:
					valueRawX = xAxis.valueRaw;
					num = -903306622;
					continue;
				case 6:
					num = -903306620;
					continue;
				case 9:
					axisCalibration2 = null;
					valueRawY = 0f;
					num = -903306618;
					continue;
				case 0:
					goto IL_009c;
				case 5:
					goto IL_00b3;
				default:
					return _calibration.GetCalibrated2DValue(valueRawX, valueRawY, axisCalibration, axisCalibration2);
				}
				break;
				IL_009c:
				int num2;
				if (yAxis != null)
				{
					num = -903306617;
					num2 = num;
				}
				else
				{
					num = -903306611;
					num2 = num;
				}
			}
			goto IL_001b;
			IL_001b:
			num = -903306619;
			goto IL_0020;
		}

		private Vector2 GetCalibratedValuePrev(StandaloneAxis xAxis, StandaloneAxis yAxis)
		{
			if (_calibration == null)
			{
				return Vector2.zero;
			}
			if (xAxis == null)
			{
				goto IL_007d;
			}
			AxisCalibration axisCalibration = xAxis.calibration;
			float valueRawX = xAxis.valueRawPrev;
			goto IL_0086;
			IL_0026:
			int num;
			float valueRawY = default(float);
			AxisCalibration axisCalibration2 = default(AxisCalibration);
			while (true)
			{
				switch (num ^ -2121031594)
				{
				case 0:
					num = -2121031593;
					continue;
				case 3:
					break;
				case 7:
					num = -2121031598;
					continue;
				case 6:
					valueRawY = 0f;
					num = -2121031598;
					continue;
				case 5:
					valueRawX = 0f;
					num = -2121031596;
					continue;
				case 1:
					goto IL_007d;
				case 2:
					goto IL_0086;
				default:
					return _calibration.GetCalibrated2DValue(valueRawX, valueRawY, axisCalibration, axisCalibration2);
				}
				break;
			}
			goto IL_0053;
			IL_007d:
			axisCalibration = null;
			num = -2121031597;
			goto IL_0026;
			IL_0086:
			if (yAxis != null)
			{
				axisCalibration2 = yAxis.calibration;
				valueRawY = yAxis.valueRawPrev;
				num = -2121031599;
				goto IL_0026;
			}
			goto IL_0053;
			IL_0053:
			axisCalibration2 = null;
			num = -2121031600;
			goto IL_0026;
		}

		private void OnAxisValueChanged(float value)
		{
			if (_allowEvents)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -601065406;
			goto IL_000d;
			IL_000d:
			switch (num ^ -601065407)
			{
			case 2:
				break;
			default:
				return;
			case 3:
				return;
			case 0:
				goto IL_0032;
			case 1:
				return;
			}
			goto IL_0008;
			IL_0032:
			if (this._ValueChangedEvent != null)
			{
				this._ValueChangedEvent(this.value);
				num = -601065408;
				goto IL_000d;
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
				int num = 1957815644;
				while (true)
				{
					switch (num ^ 0x74B1E55E)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0009:
					num = 1957815647;
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
