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
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private StandaloneAxis _xAxis = new StandaloneAxis();

		[CustomObfuscation(rename = false)]
		[Tooltip("The Y axis.")]
		[SerializeField]
		private StandaloneAxis _yAxis = new StandaloneAxis();

		private bool _allowEvents = true;

		private ValueChangedEventHandler _RawValueChangedEvent;

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
				ValueChangedEventHandler valueChangedEventHandler = this._ValueChangedEvent;
				ValueChangedEventHandler valueChangedEventHandler2;
				do
				{
					valueChangedEventHandler2 = valueChangedEventHandler;
					ValueChangedEventHandler valueChangedEventHandler3 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
					valueChangedEventHandler = Interlocked.CompareExchange(ref this._ValueChangedEvent, valueChangedEventHandler3, valueChangedEventHandler2);
				}
				while ((object)valueChangedEventHandler != valueChangedEventHandler2);
			}
			remove
			{
				ValueChangedEventHandler valueChangedEventHandler = this._ValueChangedEvent;
				ValueChangedEventHandler valueChangedEventHandler2 = default(ValueChangedEventHandler);
				ValueChangedEventHandler valueChangedEventHandler3 = default(ValueChangedEventHandler);
				while (true)
				{
					int num = -863665187;
					while (true)
					{
						switch (num ^ -863665188)
						{
						case 0:
							break;
						case 1:
							goto IL_0025;
						default:
							valueChangedEventHandler = Interlocked.CompareExchange(ref this._ValueChangedEvent, valueChangedEventHandler2, valueChangedEventHandler3);
							if ((object)valueChangedEventHandler != valueChangedEventHandler3)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						valueChangedEventHandler3 = valueChangedEventHandler;
						valueChangedEventHandler2 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler3, value);
						num = -863665186;
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

		private event ValueChangedEventHandler _RawValueChangedEvent;

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
			goto IL_0044;
			IL_005f:
			_allowEvents = allowEvents;
			EvalAndSendValueChangeEvents();
			int num = 1157787934;
			goto IL_0027;
			IL_0022:
			num = 1157787933;
			goto IL_0027;
			IL_0027:
			switch (num ^ 0x4502711C)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_0044;
			case 3:
				goto IL_005f;
			case 2:
				return;
			}
			goto IL_0022;
			IL_0044:
			if (_yAxis != null)
			{
				_yAxis.SetRawValue(y);
				num = 1157787935;
				goto IL_0027;
			}
			goto IL_005f;
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
				_xAxis.Clear();
				goto IL_0021;
			}
			goto IL_0043;
			IL_0043:
			int num;
			int num2;
			if (_yAxis == null)
			{
				num = -192437431;
				num2 = num;
			}
			else
			{
				num = -192437432;
				num2 = num;
			}
			goto IL_0026;
			IL_0021:
			num = -192437429;
			goto IL_0026;
			IL_0026:
			while (true)
			{
				switch (num ^ -192437431)
				{
				case 3:
					break;
				case 2:
					goto IL_0043;
				case 1:
					_yAxis.Clear();
					num = -192437431;
					continue;
				default:
					_allowEvents = allowEvents;
					EvalAndSendValueChangeEvents();
					return;
				}
				break;
			}
			goto IL_0021;
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
				return;
			}
			Vector2 vector2 = default(Vector2);
			while (true)
			{
				Vector2 vector = rawValueDelta;
				int num;
				int num2;
				if (!MathTools.ApproximatelyZero(vector.x))
				{
					num = 345678812;
					num2 = num;
				}
				else
				{
					num = 345678808;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x149AA3DC)
					{
					case 5:
						num = 345678813;
						continue;
					default:
						return;
					case 4:
						vector2 = valueDelta;
						num = 345678810;
						continue;
					case 3:
						this._RawValueChangedEvent(rawValue);
						num = 345678808;
						continue;
					case 2:
						if (!MathTools.ApproximatelyZero(vector2.y) && this._ValueChangedEvent != null)
						{
							this._ValueChangedEvent(value);
							num = 345678811;
							continue;
						}
						return;
					case 1:
						break;
					case 6:
					{
						int num4;
						if (MathTools.ApproximatelyZero(vector2.x))
						{
							num = 345678811;
							num4 = num;
						}
						else
						{
							num = 345678814;
							num4 = num;
						}
						continue;
					}
					case 0:
						if (!MathTools.ApproximatelyZero(vector.y))
						{
							int num3;
							if (this._RawValueChangedEvent != null)
							{
								num = 345678815;
								num3 = num;
							}
							else
							{
								num = 345678808;
								num3 = num;
							}
							continue;
						}
						goto case 4;
					case 7:
						return;
					}
					break;
				}
			}
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
				num = -1759575391;
				goto IL_0041;
			}
			return;
			IL_003c:
			num = -1759575392;
			goto IL_0041;
			IL_0041:
			switch (num ^ -1759575391)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_005a;
			case 0:
				return;
			}
			goto IL_003c;
		}

		private void Unsubscribe()
		{
			if (_xAxis != null)
			{
				_xAxis.AxisValueChangedEvent -= OnAxisValueChanged;
				goto IL_001f;
			}
			goto IL_005f;
			IL_005f:
			int num;
			if (_yAxis != null)
			{
				_yAxis.AxisValueChangedEvent -= OnAxisValueChanged;
				_yAxis.RawAxisValueChangedEvent -= OnAxisRawValueChanged;
				num = 1544841934;
				goto IL_0024;
			}
			return;
			IL_001f:
			num = 1544841932;
			goto IL_0024;
			IL_0024:
			while (true)
			{
				switch (num ^ 0x5C146ACE)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					_xAxis.RawAxisValueChangedEvent -= OnAxisRawValueChanged;
					num = 1544841935;
					continue;
				case 1:
					goto IL_005f;
				case 0:
					return;
				}
				break;
			}
			goto IL_001f;
		}

		private Vector2 GetCalibratedValue(StandaloneAxis xAxis, StandaloneAxis yAxis)
		{
			if (_calibration == null)
			{
				goto IL_0008;
			}
			int num;
			int num2;
			if (xAxis == null)
			{
				num = 271753812;
				num2 = num;
			}
			else
			{
				num = 271753808;
				num2 = num;
			}
			goto IL_000d;
			IL_0008:
			num = 271753814;
			goto IL_000d;
			IL_000d:
			AxisCalibration axisCalibration2 = default(AxisCalibration);
			float valueRawY = default(float);
			AxisCalibration axisCalibration = default(AxisCalibration);
			float valueRawX = default(float);
			while (true)
			{
				switch (num ^ 0x1032A250)
				{
				case 2:
					break;
				case 7:
					axisCalibration2 = yAxis.calibration;
					valueRawY = yAxis.valueRaw;
					num = 271753809;
					continue;
				case 3:
					axisCalibration2 = null;
					valueRawY = 0f;
					num = 271753809;
					continue;
				case 0:
					axisCalibration = xAxis.calibration;
					valueRawX = xAxis.valueRaw;
					num = 271753813;
					continue;
				case 6:
					return Vector2.zero;
				case 5:
				{
					int num3;
					if (yAxis == null)
					{
						num = 271753811;
						num3 = num;
					}
					else
					{
						num = 271753815;
						num3 = num;
					}
					continue;
				}
				case 4:
					axisCalibration = null;
					valueRawX = 0f;
					num = 271753813;
					continue;
				default:
					return _calibration.GetCalibrated2DValue(valueRawX, valueRawY, axisCalibration, axisCalibration2);
				}
				break;
			}
			goto IL_0008;
		}

		private Vector2 GetCalibratedValuePrev(StandaloneAxis xAxis, StandaloneAxis yAxis)
		{
			if (_calibration == null)
			{
				return Vector2.zero;
			}
			if (xAxis != null)
			{
				goto IL_0011;
			}
			goto IL_007f;
			IL_007f:
			AxisCalibration axisCalibration = null;
			float valueRawX = 0f;
			int num = 816251222;
			goto IL_0016;
			IL_0011:
			num = 816251216;
			goto IL_0016;
			IL_0016:
			AxisCalibration axisCalibration2 = default(AxisCalibration);
			float valueRawY = default(float);
			while (true)
			{
				switch (num ^ 0x30A70155)
				{
				case 0:
					break;
				case 3:
					if (yAxis != null)
					{
						axisCalibration2 = yAxis.calibration;
						valueRawY = yAxis.valueRawPrev;
						num = 816251220;
						continue;
					}
					goto case 4;
				case 2:
					valueRawX = xAxis.valueRawPrev;
					num = 816251219;
					continue;
				case 6:
					num = 816251222;
					continue;
				case 4:
					axisCalibration2 = null;
					valueRawY = 0f;
					num = 816251220;
					continue;
				case 7:
					goto IL_007f;
				case 5:
					axisCalibration = xAxis.calibration;
					num = 816251223;
					continue;
				default:
					return _calibration.GetCalibrated2DValue(valueRawX, valueRawY, axisCalibration, axisCalibration2);
				}
				break;
			}
			goto IL_0011;
		}

		private void OnAxisValueChanged(float value)
		{
			if (_allowEvents)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -1276238386;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1276238385)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				return;
			case 0:
				goto IL_0032;
			case 3:
				return;
			}
			goto IL_0008;
			IL_0032:
			if (this._ValueChangedEvent != null)
			{
				this._ValueChangedEvent(this.value);
				num = -1276238388;
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
				int num = -1880976992;
				while (true)
				{
					switch (num ^ -1880976991)
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
					num = -1880976989;
				}
			}
		}

		internal static StandaloneAxis2D CreateRelative()
		{
			StandaloneAxis2D standaloneAxis2D = new StandaloneAxis2D(StandaloneAxis.CreateRelative(), StandaloneAxis.CreateRelative());
			while (true)
			{
				int num = -852507980;
				while (true)
				{
					switch (num ^ -852507979)
					{
					case 2:
						break;
					case 1:
						standaloneAxis2D.calibration.deadZoneType = DeadZone2DType.Radial;
						num = -852507979;
						continue;
					case 0:
						standaloneAxis2D.calibration.sensitivityType = AxisSensitivity2DType.Radial;
						num = -852507978;
						continue;
					default:
						return standaloneAxis2D;
					}
					break;
				}
			}
		}
	}
}
