using System;
using System.Threading;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Internal
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class StandaloneAxis
	{
		[CustomObfuscation(rename = false)]
		public delegate void AxisValueChangedEventHandler(float value);

		[CustomObfuscation(rename = false)]
		public delegate void ButtonValueChangedEventHandler(bool value);

		[CustomObfuscation(rename = false)]
		public delegate void ButtonDownEventHandler();

		[CustomObfuscation(rename = false)]
		public delegate void ButtonUpEventHandler();

		[Tooltip("The axis value at or above which the buttonValue property will return True. This will also return true for negative values below the inverse of this threshold.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Range(0f, 1f)]
		private float _buttonActivationThreshold = 0.5f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Contains calibration settings for the axis.")]
		private AxisCalibration _calibration = new AxisCalibration();

		[CustomObfuscation(rename = false)]
		private float _valueRaw;

		[CustomObfuscation(rename = false)]
		private float _valueRawPrev;

		private AxisValueChangedEventHandler bAHHEOTptXbbAuqcuBlybpNijmlo;

		private AxisValueChangedEventHandler PIBBycoMsklrsnetCHkZEQLHAAe;

		private ButtonDownEventHandler QLpsgdBsNpiCwdhQbmRbLcTfOpx;

		private ButtonUpEventHandler qSIQyuwGzfDncxVCOeVNgVZZGTZ;

		private ButtonValueChangedEventHandler ggdKJFcGFJtmoXAjLNQowxDKXfC;

		private ButtonDownEventHandler kGdMJhglTnDDTqlRsLAYFgITVmB;

		private ButtonUpEventHandler bwoAGTdCSEqENFfeDQPfXmREVKaO;

		private ButtonValueChangedEventHandler zTJEbAGFgaxBrHgJHWayUGhvKqR;

		public float buttonActivationThreshold
		{
			get
			{
				return _buttonActivationThreshold;
			}
			set
			{
				if (value == _buttonActivationThreshold)
				{
					while (true)
					{
						switch (0x4F2EB49A ^ 0x4F2EB49B)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_buttonActivationThreshold = MathTools.Abs(value);
			}
		}

		public AxisCalibration calibration
		{
			get
			{
				return _calibration;
			}
			private set
			{
				if (axisCalibration == _calibration)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = -1608258811;
				goto IL_000e;
				IL_000e:
				switch (num ^ -1608258809)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					return;
				case 3:
					goto IL_0033;
				case 1:
					return;
				}
				goto IL_0009;
				IL_0033:
				_calibration = axisCalibration;
				num = -1608258810;
				goto IL_000e;
			}
		}

		public float valueRaw
		{
			get
			{
				return _valueRaw;
			}
			private set
			{
				if (num == _valueRaw)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num2 = 1059826662;
				goto IL_000e;
				IL_000e:
				switch (num2 ^ 0x3F2BABE7)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					return;
				case 2:
					goto IL_0033;
				case 0:
					return;
				}
				goto IL_0009;
				IL_0033:
				_valueRaw = num;
				num2 = 1059826663;
				goto IL_000e;
			}
		}

		public float valueRawPrev
		{
			get
			{
				return _valueRawPrev;
			}
			private set
			{
				if (num == _valueRawPrev)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num2 = -222048594;
				goto IL_000e;
				IL_000e:
				switch (num2 ^ -222048593)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					return;
				case 2:
					goto IL_0033;
				case 0:
					return;
				}
				goto IL_0009;
				IL_0033:
				_valueRawPrev = num;
				num2 = -222048593;
				goto IL_000e;
			}
		}

		public float valueRawDelta
		{
			get
			{
				return _valueRaw - _valueRawPrev;
			}
		}

		public float value
		{
			get
			{
				if (_calibration == null)
				{
					return _valueRaw;
				}
				return _calibration.GetCalibratedValue(_valueRaw);
			}
		}

		public float valuePrev
		{
			get
			{
				if (_calibration == null)
				{
					return _valueRawPrev;
				}
				return _calibration.GetCalibratedValue(_valueRawPrev);
			}
		}

		public float valueDelta
		{
			get
			{
				if (_calibration == null)
				{
					return valueRawDelta;
				}
				return _calibration.GetCalibratedValue(_valueRaw) - _calibration.GetCalibratedValue(_valueRawPrev);
			}
		}

		public bool rawButtonValue
		{
			get
			{
				return _valueRaw >= _buttonActivationThreshold;
			}
		}

		public bool rawButtonValuePrev
		{
			get
			{
				return _valueRawPrev >= _buttonActivationThreshold;
			}
		}

		public bool buttonValue
		{
			get
			{
				return MathTools.Abs(_calibration.GetCalibratedValue(value)) >= _buttonActivationThreshold;
			}
		}

		public bool buttonValuePrev
		{
			get
			{
				return MathTools.Abs(_calibration.GetCalibratedValue(valuePrev)) >= _buttonActivationThreshold;
			}
		}

		internal float rawMin
		{
			get
			{
				if (_calibration == null)
				{
					return -1f;
				}
				if (!_calibration.applyRangeCalibration)
				{
					return float.NegativeInfinity;
				}
				return _calibration.calibratedMin;
			}
		}

		internal float rawMax
		{
			get
			{
				if (_calibration == null)
				{
					return 1f;
				}
				if (!_calibration.applyRangeCalibration)
				{
					return float.PositiveInfinity;
				}
				return _calibration.calibratedMax;
			}
		}

		internal float rawZero
		{
			get
			{
				if (_calibration == null)
				{
					return 0f;
				}
				if (!_calibration.applyRangeCalibration)
				{
					return 0f;
				}
				return _calibration.calibratedZero;
			}
		}

		private event AxisValueChangedEventHandler _AxisValueChangedEvent
		{
			add
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = bAHHEOTptXbbAuqcuBlybpNijmlo;
				AxisValueChangedEventHandler axisValueChangedEventHandler2 = default(AxisValueChangedEventHandler);
				AxisValueChangedEventHandler axisValueChangedEventHandler3 = default(AxisValueChangedEventHandler);
				while (true)
				{
					int num = 317141904;
					while (true)
					{
						switch (num ^ 0x12E73391)
						{
						case 0:
							break;
						case 1:
							goto IL_0025;
						default:
							axisValueChangedEventHandler = Interlocked.CompareExchange(ref bAHHEOTptXbbAuqcuBlybpNijmlo, axisValueChangedEventHandler2, axisValueChangedEventHandler3);
							if ((object)axisValueChangedEventHandler != axisValueChangedEventHandler3)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						axisValueChangedEventHandler3 = axisValueChangedEventHandler;
						axisValueChangedEventHandler2 = (AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler3, b);
						num = 317141907;
					}
				}
			}
			remove
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = bAHHEOTptXbbAuqcuBlybpNijmlo;
				AxisValueChangedEventHandler axisValueChangedEventHandler3 = default(AxisValueChangedEventHandler);
				while (true)
				{
					int num = 1510428977;
					while (true)
					{
						switch (num ^ 0x5A075130)
						{
						case 2:
							break;
						case 1:
							goto IL_0025;
						default:
						{
							AxisValueChangedEventHandler axisValueChangedEventHandler2 = (AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler3, axisValueChangedEventHandler4);
							axisValueChangedEventHandler = Interlocked.CompareExchange(ref bAHHEOTptXbbAuqcuBlybpNijmlo, axisValueChangedEventHandler2, axisValueChangedEventHandler3);
							if ((object)axisValueChangedEventHandler != axisValueChangedEventHandler3)
							{
								goto IL_0025;
							}
							return;
						}
						}
						break;
						IL_0025:
						axisValueChangedEventHandler3 = axisValueChangedEventHandler;
						num = 1510428976;
					}
				}
			}
		}

		public event AxisValueChangedEventHandler AxisValueChangedEvent
		{
			add
			{
				_AxisValueChangedEvent += value;
			}
			remove
			{
				_AxisValueChangedEvent -= value;
			}
		}

		private event AxisValueChangedEventHandler _RawAxisValueChangedEvent
		{
			add
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = PIBBycoMsklrsnetCHkZEQLHAAe;
				AxisValueChangedEventHandler axisValueChangedEventHandler2 = default(AxisValueChangedEventHandler);
				while (true)
				{
					int num = -197051846;
					while (true)
					{
						switch (num ^ -197051845)
						{
						case 2:
							break;
						case 1:
							goto IL_0025;
						default:
							if ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						axisValueChangedEventHandler2 = axisValueChangedEventHandler;
						AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler2, b);
						axisValueChangedEventHandler = Interlocked.CompareExchange(ref PIBBycoMsklrsnetCHkZEQLHAAe, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
						num = -197051845;
					}
				}
			}
			remove
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = PIBBycoMsklrsnetCHkZEQLHAAe;
				AxisValueChangedEventHandler axisValueChangedEventHandler2 = default(AxisValueChangedEventHandler);
				AxisValueChangedEventHandler axisValueChangedEventHandler3 = default(AxisValueChangedEventHandler);
				while (true)
				{
					int num = -493504964;
					while (true)
					{
						switch (num ^ -493504963)
						{
						case 2:
							break;
						case 1:
							goto IL_0025;
						default:
							axisValueChangedEventHandler = Interlocked.CompareExchange(ref PIBBycoMsklrsnetCHkZEQLHAAe, axisValueChangedEventHandler2, axisValueChangedEventHandler3);
							if ((object)axisValueChangedEventHandler != axisValueChangedEventHandler3)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						axisValueChangedEventHandler3 = axisValueChangedEventHandler;
						axisValueChangedEventHandler2 = (AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler3, axisValueChangedEventHandler4);
						num = -493504963;
					}
				}
			}
		}

		public event AxisValueChangedEventHandler RawAxisValueChangedEvent
		{
			add
			{
				_RawAxisValueChangedEvent += value;
			}
			remove
			{
				_RawAxisValueChangedEvent -= value;
			}
		}

		private event ButtonDownEventHandler _ButtonDownEvent
		{
			add
			{
				ButtonDownEventHandler buttonDownEventHandler = QLpsgdBsNpiCwdhQbmRbLcTfOpx;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, b);
					buttonDownEventHandler = Interlocked.CompareExchange(ref QLpsgdBsNpiCwdhQbmRbLcTfOpx, buttonDownEventHandler3, buttonDownEventHandler2);
				}
				while ((object)buttonDownEventHandler != buttonDownEventHandler2);
			}
			remove
			{
				ButtonDownEventHandler buttonDownEventHandler = QLpsgdBsNpiCwdhQbmRbLcTfOpx;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, buttonDownEventHandler4);
					buttonDownEventHandler = Interlocked.CompareExchange(ref QLpsgdBsNpiCwdhQbmRbLcTfOpx, buttonDownEventHandler3, buttonDownEventHandler2);
				}
				while ((object)buttonDownEventHandler != buttonDownEventHandler2);
			}
		}

		public event ButtonDownEventHandler ButtonDownEvent
		{
			add
			{
				_ButtonDownEvent += value;
			}
			remove
			{
				_ButtonDownEvent -= value;
			}
		}

		private event ButtonUpEventHandler _ButtonUpEvent
		{
			add
			{
				ButtonUpEventHandler buttonUpEventHandler = qSIQyuwGzfDncxVCOeVNgVZZGTZ;
				while (true)
				{
					int num = -1428920646;
					while (true)
					{
						switch (num ^ -1428920645)
						{
						case 2:
							break;
						default:
							return;
						case 1:
						{
							ButtonUpEventHandler buttonUpEventHandler2 = buttonUpEventHandler;
							ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, b);
							buttonUpEventHandler = Interlocked.CompareExchange(ref qSIQyuwGzfDncxVCOeVNgVZZGTZ, buttonUpEventHandler3, buttonUpEventHandler2);
							int num2;
							if ((object)buttonUpEventHandler == buttonUpEventHandler2)
							{
								num = -1428920645;
								num2 = num;
							}
							else
							{
								num = -1428920646;
								num2 = num;
							}
							continue;
						}
						case 0:
							return;
						}
						break;
					}
				}
			}
			remove
			{
				ButtonUpEventHandler buttonUpEventHandler = qSIQyuwGzfDncxVCOeVNgVZZGTZ;
				ButtonUpEventHandler buttonUpEventHandler2 = default(ButtonUpEventHandler);
				ButtonUpEventHandler buttonUpEventHandler3 = default(ButtonUpEventHandler);
				while (true)
				{
					int num = -1248270539;
					while (true)
					{
						switch (num ^ -1248270537)
						{
						case 3:
							break;
						case 2:
							buttonUpEventHandler2 = buttonUpEventHandler;
							buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, buttonUpEventHandler4);
							num = -1248270538;
							continue;
						case 1:
							buttonUpEventHandler = Interlocked.CompareExchange(ref qSIQyuwGzfDncxVCOeVNgVZZGTZ, buttonUpEventHandler3, buttonUpEventHandler2);
							num = -1248270537;
							continue;
						default:
							if ((object)buttonUpEventHandler == buttonUpEventHandler2)
							{
								return;
							}
							goto case 2;
						}
						break;
					}
				}
			}
		}

		public event ButtonUpEventHandler ButtonUpEvent
		{
			add
			{
				_ButtonUpEvent += value;
			}
			remove
			{
				_ButtonUpEvent -= value;
			}
		}

		private event ButtonValueChangedEventHandler _ButtonValueChangedEvent
		{
			add
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = ggdKJFcGFJtmoXAjLNQowxDKXfC;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2 = default(ButtonValueChangedEventHandler);
				ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = default(ButtonValueChangedEventHandler);
				while (true)
				{
					int num = -245488170;
					while (true)
					{
						switch (num ^ -245488169)
						{
						case 0:
							break;
						case 1:
							goto IL_0025;
						default:
							buttonValueChangedEventHandler = Interlocked.CompareExchange(ref ggdKJFcGFJtmoXAjLNQowxDKXfC, buttonValueChangedEventHandler2, buttonValueChangedEventHandler3);
							if ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler3)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						buttonValueChangedEventHandler3 = buttonValueChangedEventHandler;
						buttonValueChangedEventHandler2 = (ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler3, b);
						num = -245488171;
					}
				}
			}
			remove
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = ggdKJFcGFJtmoXAjLNQowxDKXfC;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2 = default(ButtonValueChangedEventHandler);
				ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = default(ButtonValueChangedEventHandler);
				while (true)
				{
					int num = -254007192;
					while (true)
					{
						switch (num ^ -254007191)
						{
						case 0:
							break;
						case 1:
							goto IL_0025;
						default:
							buttonValueChangedEventHandler = Interlocked.CompareExchange(ref ggdKJFcGFJtmoXAjLNQowxDKXfC, buttonValueChangedEventHandler2, buttonValueChangedEventHandler3);
							if ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler3)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						buttonValueChangedEventHandler3 = buttonValueChangedEventHandler;
						buttonValueChangedEventHandler2 = (ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler3, buttonValueChangedEventHandler4);
						num = -254007189;
					}
				}
			}
		}

		public event ButtonValueChangedEventHandler ButtonValueChangedEvent
		{
			add
			{
				_ButtonValueChangedEvent += value;
			}
			remove
			{
				_ButtonValueChangedEvent -= value;
			}
		}

		private event ButtonDownEventHandler _RawButtonDownEvent
		{
			add
			{
				ButtonDownEventHandler buttonDownEventHandler = kGdMJhglTnDDTqlRsLAYFgITVmB;
				ButtonDownEventHandler buttonDownEventHandler3 = default(ButtonDownEventHandler);
				while (true)
				{
					int num = 1797768524;
					while (true)
					{
						switch (num ^ 0x6B27C54D)
						{
						case 0:
							break;
						case 1:
							goto IL_0025;
						default:
						{
							ButtonDownEventHandler buttonDownEventHandler2 = (ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler3, b);
							buttonDownEventHandler = Interlocked.CompareExchange(ref kGdMJhglTnDDTqlRsLAYFgITVmB, buttonDownEventHandler2, buttonDownEventHandler3);
							if ((object)buttonDownEventHandler != buttonDownEventHandler3)
							{
								goto IL_0025;
							}
							return;
						}
						}
						break;
						IL_0025:
						buttonDownEventHandler3 = buttonDownEventHandler;
						num = 1797768527;
					}
				}
			}
			remove
			{
				ButtonDownEventHandler buttonDownEventHandler = kGdMJhglTnDDTqlRsLAYFgITVmB;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, buttonDownEventHandler4);
					buttonDownEventHandler = Interlocked.CompareExchange(ref kGdMJhglTnDDTqlRsLAYFgITVmB, buttonDownEventHandler3, buttonDownEventHandler2);
				}
				while ((object)buttonDownEventHandler != buttonDownEventHandler2);
			}
		}

		public event ButtonDownEventHandler RawButtonDownEvent
		{
			add
			{
				_RawButtonDownEvent += value;
			}
			remove
			{
				_RawButtonDownEvent -= value;
			}
		}

		private event ButtonUpEventHandler _RawButtonUpEvent
		{
			add
			{
				ButtonUpEventHandler buttonUpEventHandler = bwoAGTdCSEqENFfeDQPfXmREVKaO;
				while (true)
				{
					int num = -1436720309;
					while (true)
					{
						switch (num ^ -1436720311)
						{
						case 0:
							break;
						default:
							return;
						case 2:
						{
							ButtonUpEventHandler buttonUpEventHandler2 = buttonUpEventHandler;
							ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, b);
							buttonUpEventHandler = Interlocked.CompareExchange(ref bwoAGTdCSEqENFfeDQPfXmREVKaO, buttonUpEventHandler3, buttonUpEventHandler2);
							int num2;
							if ((object)buttonUpEventHandler != buttonUpEventHandler2)
							{
								num = -1436720309;
								num2 = num;
							}
							else
							{
								num = -1436720312;
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
				ButtonUpEventHandler buttonUpEventHandler = bwoAGTdCSEqENFfeDQPfXmREVKaO;
				while (true)
				{
					int num = -1502837141;
					while (true)
					{
						switch (num ^ -1502837142)
						{
						case 2:
							break;
						default:
							return;
						case 1:
						{
							ButtonUpEventHandler buttonUpEventHandler2 = buttonUpEventHandler;
							ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, buttonUpEventHandler4);
							buttonUpEventHandler = Interlocked.CompareExchange(ref bwoAGTdCSEqENFfeDQPfXmREVKaO, buttonUpEventHandler3, buttonUpEventHandler2);
							int num2;
							if ((object)buttonUpEventHandler == buttonUpEventHandler2)
							{
								num = -1502837142;
								num2 = num;
							}
							else
							{
								num = -1502837141;
								num2 = num;
							}
							continue;
						}
						case 0:
							return;
						}
						break;
					}
				}
			}
		}

		public event ButtonUpEventHandler RawButtonUpEvent
		{
			add
			{
				_RawButtonUpEvent += value;
			}
			remove
			{
				_RawButtonUpEvent -= value;
			}
		}

		private event ButtonValueChangedEventHandler _RawButtonValueChangedEvent
		{
			add
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = zTJEbAGFgaxBrHgJHWayUGhvKqR;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2 = default(ButtonValueChangedEventHandler);
				while (true)
				{
					int num = -985003042;
					while (true)
					{
						switch (num ^ -985003041)
						{
						case 0:
							break;
						case 1:
							goto IL_0025;
						default:
							if ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
						ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler2, b);
						buttonValueChangedEventHandler = Interlocked.CompareExchange(ref zTJEbAGFgaxBrHgJHWayUGhvKqR, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
						num = -985003043;
					}
				}
			}
			remove
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = zTJEbAGFgaxBrHgJHWayUGhvKqR;
				while (true)
				{
					int num = -1726845270;
					while (true)
					{
						switch (num ^ -1726845272)
						{
						case 0:
							break;
						default:
							return;
						case 2:
						{
							ButtonValueChangedEventHandler buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
							ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler2, buttonValueChangedEventHandler4);
							buttonValueChangedEventHandler = Interlocked.CompareExchange(ref zTJEbAGFgaxBrHgJHWayUGhvKqR, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
							int num2;
							if ((object)buttonValueChangedEventHandler == buttonValueChangedEventHandler2)
							{
								num = -1726845271;
								num2 = num;
							}
							else
							{
								num = -1726845270;
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

		public event ButtonValueChangedEventHandler RawButtonValueChangedEvent
		{
			add
			{
				_RawButtonValueChangedEvent += value;
			}
			remove
			{
				_RawButtonValueChangedEvent -= value;
			}
		}

		internal StandaloneAxis()
		{
		}

		public void SetRawValue(float value)
		{
			_valueRawPrev = _valueRaw;
			_valueRaw = value;
			bool flag2 = default(bool);
			while (true)
			{
				int num = -799137936;
				while (true)
				{
					switch (num ^ -799137925)
					{
					case 8:
						break;
					default:
						return;
					case 6:
						kGdMJhglTnDDTqlRsLAYFgITVmB();
						num = -799137935;
						continue;
					case 18:
						if (ggdKJFcGFJtmoXAjLNQowxDKXfC != null)
						{
							bool flag = buttonValue;
							if (flag != buttonValuePrev)
							{
								ggdKJFcGFJtmoXAjLNQowxDKXfC(flag);
								num = -799137929;
								continue;
							}
						}
						goto case 12;
					case 0:
						if (buttonValue)
						{
							int num8;
							if (!buttonValuePrev)
							{
								num = -799137942;
								num8 = num;
							}
							else
							{
								num = -799137928;
								num8 = num;
							}
							continue;
						}
						goto case 3;
					case 13:
						if (kGdMJhglTnDDTqlRsLAYFgITVmB != null && rawButtonValue)
						{
							int num2;
							if (rawButtonValuePrev)
							{
								num = -799137935;
								num2 = num;
							}
							else
							{
								num = -799137923;
								num2 = num;
							}
							continue;
						}
						goto case 10;
					case 17:
						QLpsgdBsNpiCwdhQbmRbLcTfOpx();
						num = -799137928;
						continue;
					case 7:
						if (flag2 != rawButtonValuePrev)
						{
							zTJEbAGFgaxBrHgJHWayUGhvKqR(flag2);
							num = -799137930;
							continue;
						}
						goto case 13;
					case 9:
					{
						int num7;
						if (bAHHEOTptXbbAuqcuBlybpNijmlo != null)
						{
							num = -799137932;
							num7 = num;
						}
						else
						{
							num = -799137941;
							num7 = num;
						}
						continue;
					}
					case 15:
					{
						float num3 = this.value;
						if (num3 != valuePrev)
						{
							bAHHEOTptXbbAuqcuBlybpNijmlo(num3);
							num = -799137941;
							continue;
						}
						goto case 16;
					}
					case 3:
						if (qSIQyuwGzfDncxVCOeVNgVZZGTZ != null)
						{
							int num6;
							if (!buttonValue)
							{
								num = -799137926;
								num6 = num;
							}
							else
							{
								num = -799137922;
								num6 = num;
							}
							continue;
						}
						return;
					case 10:
						if (bwoAGTdCSEqENFfeDQPfXmREVKaO != null && !rawButtonValue)
						{
							int num9;
							if (!rawButtonValuePrev)
							{
								num = -799137943;
								num9 = num;
							}
							else
							{
								num = -799137927;
								num9 = num;
							}
							continue;
						}
						goto case 18;
					case 4:
						if (PIBBycoMsklrsnetCHkZEQLHAAe != null && _valueRaw != _valueRawPrev)
						{
							PIBBycoMsklrsnetCHkZEQLHAAe(_valueRaw);
							num = -799137934;
							continue;
						}
						goto case 9;
					case 2:
						bwoAGTdCSEqENFfeDQPfXmREVKaO();
						num = -799137943;
						continue;
					case 11:
						if (value == _valueRawPrev)
						{
							return;
						}
						goto case 4;
					case 14:
						flag2 = rawButtonValue;
						num = -799137924;
						continue;
					case 16:
					{
						int num5;
						if (zTJEbAGFgaxBrHgJHWayUGhvKqR != null)
						{
							num = -799137931;
							num5 = num;
						}
						else
						{
							num = -799137930;
							num5 = num;
						}
						continue;
					}
					case 12:
					{
						int num4;
						if (QLpsgdBsNpiCwdhQbmRbLcTfOpx != null)
						{
							num = -799137925;
							num4 = num;
						}
						else
						{
							num = -799137928;
							num4 = num;
						}
						continue;
					}
					case 1:
						if (buttonValuePrev)
						{
							qSIQyuwGzfDncxVCOeVNgVZZGTZ();
							num = -799137922;
							continue;
						}
						return;
					case 5:
						return;
					}
					break;
				}
			}
		}

		public void Clear()
		{
			SetRawValue(rawZero);
		}

		[CustomObfuscation(rename = false)]
		internal static StandaloneAxis CreateRelative()
		{
			StandaloneAxis standaloneAxis = new StandaloneAxis();
			standaloneAxis._calibration = AxisCalibration.CreateRelative();
			return standaloneAxis;
		}
	}
}
