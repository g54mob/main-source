using System;
using System.Threading;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Internal
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
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

		[SerializeField]
		[Tooltip("The axis value at or above which the buttonValue property will return True. This will also return true for negative values below the inverse of this threshold.")]
		[CustomObfuscation(rename = false)]
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

		private AxisValueChangedEventHandler xlRkoINFONdZuzJATOAlCCxxQiF;

		private AxisValueChangedEventHandler VpPAnyEmdwCDPbsUedehslizKIaA;

		private ButtonDownEventHandler UUzQpbDWqzyzYqNgAiSgVqzadJL;

		private ButtonUpEventHandler wrAMiksWWfPPSmQilqIAZpfYZad;

		private ButtonValueChangedEventHandler wabImBEsfHRBUUMesowhLSFPBBeF;

		private ButtonDownEventHandler oXnaaXaySlNjjSrHJcwVwyYCzROQ;

		private ButtonUpEventHandler tFauPXMfKEmlVsMzQmoZNtKuKYw;

		private ButtonValueChangedEventHandler zNBhureSoypDZmEMkGxhTbiibQIn;

		public float buttonActivationThreshold
		{
			get
			{
				return _buttonActivationThreshold;
			}
			set
			{
				if (value != _buttonActivationThreshold)
				{
					_buttonActivationThreshold = MathTools.Abs(value);
				}
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
				if (value == _calibration)
				{
					return;
				}
				while (true)
				{
					_calibration = value;
					int num = 2089693913;
					while (true)
					{
						switch (num ^ 0x7C8E32D8)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_000a:
						num = 2089693914;
					}
				}
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
				if (value == _valueRaw)
				{
					return;
				}
				while (true)
				{
					_valueRaw = value;
					int num = 1328873456;
					while (true)
					{
						switch (num ^ 0x4F34FFF2)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_000a:
						num = 1328873459;
					}
				}
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
				if (value == _valueRawPrev)
				{
					return;
				}
				while (true)
				{
					_valueRawPrev = value;
					int num = -1052168491;
					while (true)
					{
						switch (num ^ -1052168491)
						{
						case 2:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000a:
						num = -1052168492;
					}
				}
			}
		}

		public float valueRawDelta => _valueRaw - _valueRawPrev;

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

		public bool rawButtonValue => _valueRaw >= _buttonActivationThreshold;

		public bool rawButtonValuePrev => _valueRawPrev >= _buttonActivationThreshold;

		public bool buttonValue => MathTools.Abs(_calibration.GetCalibratedValue(value)) >= _buttonActivationThreshold;

		public bool buttonValuePrev => MathTools.Abs(_calibration.GetCalibratedValue(valuePrev)) >= _buttonActivationThreshold;

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
				AxisValueChangedEventHandler axisValueChangedEventHandler = xlRkoINFONdZuzJATOAlCCxxQiF;
				AxisValueChangedEventHandler axisValueChangedEventHandler3 = default(AxisValueChangedEventHandler);
				while (true)
				{
					int num = 846038071;
					while (true)
					{
						switch (num ^ 0x326D8436)
						{
						case 2:
							break;
						case 1:
							goto IL_0025;
						default:
						{
							AxisValueChangedEventHandler axisValueChangedEventHandler2 = (AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler3, value);
							axisValueChangedEventHandler = Interlocked.CompareExchange(ref xlRkoINFONdZuzJATOAlCCxxQiF, axisValueChangedEventHandler2, axisValueChangedEventHandler3);
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
						num = 846038070;
					}
				}
			}
			remove
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = xlRkoINFONdZuzJATOAlCCxxQiF;
				AxisValueChangedEventHandler axisValueChangedEventHandler2 = default(AxisValueChangedEventHandler);
				AxisValueChangedEventHandler axisValueChangedEventHandler3 = default(AxisValueChangedEventHandler);
				while (true)
				{
					int num = 217055756;
					while (true)
					{
						switch (num ^ 0xCF0020E)
						{
						case 0:
							break;
						case 2:
							goto IL_0025;
						default:
							axisValueChangedEventHandler = Interlocked.CompareExchange(ref xlRkoINFONdZuzJATOAlCCxxQiF, axisValueChangedEventHandler2, axisValueChangedEventHandler3);
							if ((object)axisValueChangedEventHandler != axisValueChangedEventHandler3)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						axisValueChangedEventHandler3 = axisValueChangedEventHandler;
						axisValueChangedEventHandler2 = (AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler3, value);
						num = 217055759;
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
				AxisValueChangedEventHandler axisValueChangedEventHandler = VpPAnyEmdwCDPbsUedehslizKIaA;
				AxisValueChangedEventHandler axisValueChangedEventHandler2 = default(AxisValueChangedEventHandler);
				while (true)
				{
					int num = 1976286292;
					while (true)
					{
						switch (num ^ 0x75CBBC56)
						{
						case 0:
							break;
						case 2:
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
						AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler2, value);
						axisValueChangedEventHandler = Interlocked.CompareExchange(ref VpPAnyEmdwCDPbsUedehslizKIaA, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
						num = 1976286295;
					}
				}
			}
			remove
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = VpPAnyEmdwCDPbsUedehslizKIaA;
				while (true)
				{
					int num = -1202573749;
					while (true)
					{
						switch (num ^ -1202573750)
						{
						case 2:
							break;
						default:
							return;
						case 1:
						{
							AxisValueChangedEventHandler axisValueChangedEventHandler2 = axisValueChangedEventHandler;
							AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler2, value);
							axisValueChangedEventHandler = Interlocked.CompareExchange(ref VpPAnyEmdwCDPbsUedehslizKIaA, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
							int num2;
							if ((object)axisValueChangedEventHandler == axisValueChangedEventHandler2)
							{
								num = -1202573750;
								num2 = num;
							}
							else
							{
								num = -1202573749;
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
				ButtonDownEventHandler buttonDownEventHandler = UUzQpbDWqzyzYqNgAiSgVqzadJL;
				while (true)
				{
					int num = 1722462436;
					while (true)
					{
						switch (num ^ 0x66AAB0E5)
						{
						case 2:
							break;
						default:
							return;
						case 1:
						{
							ButtonDownEventHandler buttonDownEventHandler2 = buttonDownEventHandler;
							ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, value);
							buttonDownEventHandler = Interlocked.CompareExchange(ref UUzQpbDWqzyzYqNgAiSgVqzadJL, buttonDownEventHandler3, buttonDownEventHandler2);
							int num2;
							if ((object)buttonDownEventHandler != buttonDownEventHandler2)
							{
								num = 1722462436;
								num2 = num;
							}
							else
							{
								num = 1722462437;
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
				ButtonDownEventHandler buttonDownEventHandler = UUzQpbDWqzyzYqNgAiSgVqzadJL;
				ButtonDownEventHandler buttonDownEventHandler2 = default(ButtonDownEventHandler);
				ButtonDownEventHandler buttonDownEventHandler3 = default(ButtonDownEventHandler);
				while (true)
				{
					int num = 913795480;
					while (true)
					{
						switch (num ^ 0x3677699A)
						{
						case 0:
							break;
						case 2:
							goto IL_0025;
						default:
							buttonDownEventHandler = Interlocked.CompareExchange(ref UUzQpbDWqzyzYqNgAiSgVqzadJL, buttonDownEventHandler2, buttonDownEventHandler3);
							if ((object)buttonDownEventHandler != buttonDownEventHandler3)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						buttonDownEventHandler3 = buttonDownEventHandler;
						buttonDownEventHandler2 = (ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler3, value);
						num = 913795483;
					}
				}
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
				ButtonUpEventHandler buttonUpEventHandler = wrAMiksWWfPPSmQilqIAZpfYZad;
				ButtonUpEventHandler buttonUpEventHandler3 = default(ButtonUpEventHandler);
				ButtonUpEventHandler buttonUpEventHandler2 = default(ButtonUpEventHandler);
				while (true)
				{
					int num = -821177805;
					while (true)
					{
						switch (num ^ -821177806)
						{
						case 3:
							break;
						default:
							return;
						case 1:
							buttonUpEventHandler3 = buttonUpEventHandler;
							buttonUpEventHandler2 = (ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler3, value);
							num = -821177806;
							continue;
						case 0:
						{
							buttonUpEventHandler = Interlocked.CompareExchange(ref wrAMiksWWfPPSmQilqIAZpfYZad, buttonUpEventHandler2, buttonUpEventHandler3);
							int num2;
							if ((object)buttonUpEventHandler != buttonUpEventHandler3)
							{
								num = -821177805;
								num2 = num;
							}
							else
							{
								num = -821177808;
								num2 = num;
							}
							continue;
						}
						case 2:
							return;
						}
						break;
					}
				}
			}
			remove
			{
				ButtonUpEventHandler buttonUpEventHandler = wrAMiksWWfPPSmQilqIAZpfYZad;
				ButtonUpEventHandler buttonUpEventHandler2 = default(ButtonUpEventHandler);
				while (true)
				{
					int num = -2053524385;
					while (true)
					{
						switch (num ^ -2053524386)
						{
						case 0:
							break;
						case 1:
							goto IL_0025;
						default:
							if ((object)buttonUpEventHandler != buttonUpEventHandler2)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						buttonUpEventHandler2 = buttonUpEventHandler;
						ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, value);
						buttonUpEventHandler = Interlocked.CompareExchange(ref wrAMiksWWfPPSmQilqIAZpfYZad, buttonUpEventHandler3, buttonUpEventHandler2);
						num = -2053524388;
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
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = wabImBEsfHRBUUMesowhLSFPBBeF;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2 = default(ButtonValueChangedEventHandler);
				while (true)
				{
					int num = 247305779;
					while (true)
					{
						switch (num ^ 0xEBD9632)
						{
						case 2:
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
						ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler2, value);
						buttonValueChangedEventHandler = Interlocked.CompareExchange(ref wabImBEsfHRBUUMesowhLSFPBBeF, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
						num = 247305778;
					}
				}
			}
			remove
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = wabImBEsfHRBUUMesowhLSFPBBeF;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = default(ButtonValueChangedEventHandler);
				while (true)
				{
					int num = -168882489;
					while (true)
					{
						switch (num ^ -168882490)
						{
						case 0:
							break;
						case 1:
							goto IL_0025;
						default:
						{
							ButtonValueChangedEventHandler buttonValueChangedEventHandler2 = (ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler3, value);
							buttonValueChangedEventHandler = Interlocked.CompareExchange(ref wabImBEsfHRBUUMesowhLSFPBBeF, buttonValueChangedEventHandler2, buttonValueChangedEventHandler3);
							if ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler3)
							{
								goto IL_0025;
							}
							return;
						}
						}
						break;
						IL_0025:
						buttonValueChangedEventHandler3 = buttonValueChangedEventHandler;
						num = -168882492;
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
				ButtonDownEventHandler buttonDownEventHandler = oXnaaXaySlNjjSrHJcwVwyYCzROQ;
				while (true)
				{
					int num = -223400524;
					while (true)
					{
						switch (num ^ -223400522)
						{
						case 0:
							break;
						default:
							return;
						case 2:
						{
							ButtonDownEventHandler buttonDownEventHandler2 = buttonDownEventHandler;
							ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, value);
							buttonDownEventHandler = Interlocked.CompareExchange(ref oXnaaXaySlNjjSrHJcwVwyYCzROQ, buttonDownEventHandler3, buttonDownEventHandler2);
							int num2;
							if ((object)buttonDownEventHandler == buttonDownEventHandler2)
							{
								num = -223400521;
								num2 = num;
							}
							else
							{
								num = -223400524;
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
				ButtonDownEventHandler buttonDownEventHandler = oXnaaXaySlNjjSrHJcwVwyYCzROQ;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, value);
					buttonDownEventHandler = Interlocked.CompareExchange(ref oXnaaXaySlNjjSrHJcwVwyYCzROQ, buttonDownEventHandler3, buttonDownEventHandler2);
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
				ButtonUpEventHandler buttonUpEventHandler = tFauPXMfKEmlVsMzQmoZNtKuKYw;
				ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, value);
					buttonUpEventHandler = Interlocked.CompareExchange(ref tFauPXMfKEmlVsMzQmoZNtKuKYw, buttonUpEventHandler3, buttonUpEventHandler2);
				}
				while ((object)buttonUpEventHandler != buttonUpEventHandler2);
			}
			remove
			{
				ButtonUpEventHandler buttonUpEventHandler = tFauPXMfKEmlVsMzQmoZNtKuKYw;
				ButtonUpEventHandler buttonUpEventHandler3 = default(ButtonUpEventHandler);
				ButtonUpEventHandler buttonUpEventHandler2 = default(ButtonUpEventHandler);
				while (true)
				{
					int num = 494099504;
					while (true)
					{
						switch (num ^ 0x1D735C33)
						{
						case 0:
							break;
						default:
							return;
						case 3:
							buttonUpEventHandler3 = buttonUpEventHandler;
							num = 494099506;
							continue;
						case 4:
						{
							buttonUpEventHandler = Interlocked.CompareExchange(ref tFauPXMfKEmlVsMzQmoZNtKuKYw, buttonUpEventHandler2, buttonUpEventHandler3);
							int num2;
							if ((object)buttonUpEventHandler == buttonUpEventHandler3)
							{
								num = 494099505;
								num2 = num;
							}
							else
							{
								num = 494099504;
								num2 = num;
							}
							continue;
						}
						case 1:
							buttonUpEventHandler2 = (ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler3, value);
							num = 494099511;
							continue;
						case 2:
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
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = zNBhureSoypDZmEMkGxhTbiibQIn;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler2, value);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref zNBhureSoypDZmEMkGxhTbiibQIn, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
				}
				while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
			}
			remove
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = zNBhureSoypDZmEMkGxhTbiibQIn;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2 = default(ButtonValueChangedEventHandler);
				ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = default(ButtonValueChangedEventHandler);
				while (true)
				{
					int num = 1310466062;
					while (true)
					{
						switch (num ^ 0x4E1C200F)
						{
						case 0:
							break;
						case 1:
							buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
							buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler2, value);
							num = 1310466061;
							continue;
						case 2:
							buttonValueChangedEventHandler = Interlocked.CompareExchange(ref zNBhureSoypDZmEMkGxhTbiibQIn, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
							num = 1310466060;
							continue;
						default:
							if ((object)buttonValueChangedEventHandler == buttonValueChangedEventHandler2)
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
			if (value == _valueRawPrev)
			{
				return;
			}
			bool flag = default(bool);
			bool flag3 = default(bool);
			while (true)
			{
				int num;
				int num2;
				if (VpPAnyEmdwCDPbsUedehslizKIaA == null)
				{
					num = -113779590;
					num2 = num;
				}
				else
				{
					num = -113779598;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -113779591)
					{
					case 0:
						num = -113779585;
						continue;
					default:
						return;
					case 19:
						zNBhureSoypDZmEMkGxhTbiibQIn(flag);
						num = -113779599;
						continue;
					case 17:
						VpPAnyEmdwCDPbsUedehslizKIaA(_valueRaw);
						num = -113779590;
						continue;
					case 7:
						flag3 = buttonValue;
						num = -113779594;
						continue;
					case 14:
						if (wabImBEsfHRBUUMesowhLSFPBBeF != null)
						{
							bool flag2 = buttonValue;
							if (flag2 != buttonValuePrev)
							{
								wabImBEsfHRBUUMesowhLSFPBBeF(flag2);
								num = -113779596;
								continue;
							}
						}
						goto case 13;
					case 11:
					{
						int num4;
						if (_valueRaw != _valueRawPrev)
						{
							num = -113779608;
							num4 = num;
						}
						else
						{
							num = -113779590;
							num4 = num;
						}
						continue;
					}
					case 20:
						tFauPXMfKEmlVsMzQmoZNtKuKYw();
						num = -113779593;
						continue;
					case 3:
						if (xlRkoINFONdZuzJATOAlCCxxQiF != null)
						{
							float num8 = this.value;
							if (num8 != valuePrev)
							{
								xlRkoINFONdZuzJATOAlCCxxQiF(num8);
								num = -113779595;
								continue;
							}
						}
						goto case 12;
					case 6:
						break;
					case 9:
					{
						int num6;
						if (!rawButtonValuePrev)
						{
							num = -113779592;
							num6 = num;
						}
						else
						{
							num = -113779589;
							num6 = num;
						}
						continue;
					}
					case 1:
						oXnaaXaySlNjjSrHJcwVwyYCzROQ();
						num = -113779589;
						continue;
					case 10:
					{
						int num3;
						if (flag == rawButtonValuePrev)
						{
							num = -113779599;
							num3 = num;
						}
						else
						{
							num = -113779606;
							num3 = num;
						}
						continue;
					}
					case 15:
					{
						int num10;
						if (!flag3)
						{
							num = -113779607;
							num10 = num;
						}
						else
						{
							num = -113779605;
							num10 = num;
						}
						continue;
					}
					case 8:
						if (oXnaaXaySlNjjSrHJcwVwyYCzROQ != null)
						{
							int num5;
							if (rawButtonValue)
							{
								num = -113779600;
								num5 = num;
							}
							else
							{
								num = -113779589;
								num5 = num;
							}
							continue;
						}
						goto case 2;
					case 18:
						if (!buttonValuePrev)
						{
							UUzQpbDWqzyzYqNgAiSgVqzadJL();
							num = -113779607;
							continue;
						}
						goto case 16;
					case 16:
						if (wrAMiksWWfPPSmQilqIAZpfYZad != null && !buttonValue && buttonValuePrev)
						{
							wrAMiksWWfPPSmQilqIAZpfYZad();
							num = -113779587;
							continue;
						}
						return;
					case 5:
						flag = rawButtonValue;
						num = -113779597;
						continue;
					case 12:
					{
						int num9;
						if (zNBhureSoypDZmEMkGxhTbiibQIn == null)
						{
							num = -113779599;
							num9 = num;
						}
						else
						{
							num = -113779588;
							num9 = num;
						}
						continue;
					}
					case 2:
						if (tFauPXMfKEmlVsMzQmoZNtKuKYw != null && !rawButtonValue)
						{
							int num7;
							if (!rawButtonValuePrev)
							{
								num = -113779593;
								num7 = num;
							}
							else
							{
								num = -113779603;
								num7 = num;
							}
							continue;
						}
						goto case 14;
					case 13:
					{
						int num11;
						if (UUzQpbDWqzyzYqNgAiSgVqzadJL != null)
						{
							num = -113779586;
							num11 = num;
						}
						else
						{
							num = -113779607;
							num11 = num;
						}
						continue;
					}
					case 4:
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
