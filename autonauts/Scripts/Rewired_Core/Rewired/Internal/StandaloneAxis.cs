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

		[Range(0f, 1f)]
		[Tooltip("The axis value at or above which the buttonValue property will return True. This will also return true for negative values below the inverse of this threshold.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _buttonActivationThreshold = 0.5f;

		[SerializeField]
		[Tooltip("Contains calibration settings for the axis.")]
		[CustomObfuscation(rename = false)]
		private AxisCalibration _calibration = new AxisCalibration();

		[CustomObfuscation(rename = false)]
		private float _valueRaw;

		[CustomObfuscation(rename = false)]
		private float _valueRawPrev;

		private AxisValueChangedEventHandler UkJMZFbJhLdMvSjhIyryUeXaJfm;

		private AxisValueChangedEventHandler knNOmrIYwgWNUHvVmHamtKpZVCH;

		private ButtonDownEventHandler xYjinylJTvFfPfZFTiNnnTDpLuqF;

		private ButtonUpEventHandler LQKGfvMpnzFYJFALsMRPPJHVjYC;

		private ButtonValueChangedEventHandler VtjPsUSGSDMITjHFxVHaPDlCMPF;

		private ButtonDownEventHandler BQxBNKSfgdeeeCJuQDQYysoJCRx;

		private ButtonUpEventHandler UMqVHOwBSOSrmJJjaPDxZzJViRr;

		private ButtonValueChangedEventHandler CLZZPyuBgmCFUzCtjACojxYrXLn;

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
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = 161007547;
				goto IL_000e;
				IL_000e:
				switch (num ^ 0x998C7B9)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					return;
				case 1:
					goto IL_0033;
				case 0:
					return;
				}
				goto IL_0009;
				IL_0033:
				_buttonActivationThreshold = MathTools.Abs(value);
				num = 161007545;
				goto IL_000e;
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
				if (axisCalibration != _calibration)
				{
					_calibration = axisCalibration;
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
				if (num == _valueRaw)
				{
					return;
				}
				while (true)
				{
					_valueRaw = num;
					int num2 = -1827409204;
					while (true)
					{
						switch (num2 ^ -1827409203)
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
						num2 = -1827409201;
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
				if (num != _valueRawPrev)
				{
					_valueRawPrev = num;
				}
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
				AxisValueChangedEventHandler axisValueChangedEventHandler = UkJMZFbJhLdMvSjhIyryUeXaJfm;
				AxisValueChangedEventHandler axisValueChangedEventHandler2 = default(AxisValueChangedEventHandler);
				AxisValueChangedEventHandler axisValueChangedEventHandler3 = default(AxisValueChangedEventHandler);
				while (true)
				{
					int num = -1455879403;
					while (true)
					{
						switch (num ^ -1455879401)
						{
						case 0:
							break;
						case 2:
							goto IL_0025;
						default:
							axisValueChangedEventHandler = Interlocked.CompareExchange(ref UkJMZFbJhLdMvSjhIyryUeXaJfm, axisValueChangedEventHandler2, axisValueChangedEventHandler3);
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
						num = -1455879402;
					}
				}
			}
			remove
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = UkJMZFbJhLdMvSjhIyryUeXaJfm;
				AxisValueChangedEventHandler axisValueChangedEventHandler3 = default(AxisValueChangedEventHandler);
				while (true)
				{
					int num = -651752777;
					while (true)
					{
						switch (num ^ -651752779)
						{
						case 0:
							break;
						case 2:
							goto IL_0025;
						default:
						{
							AxisValueChangedEventHandler axisValueChangedEventHandler2 = (AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler3, axisValueChangedEventHandler4);
							axisValueChangedEventHandler = Interlocked.CompareExchange(ref UkJMZFbJhLdMvSjhIyryUeXaJfm, axisValueChangedEventHandler2, axisValueChangedEventHandler3);
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
						num = -651752780;
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
				AxisValueChangedEventHandler axisValueChangedEventHandler = knNOmrIYwgWNUHvVmHamtKpZVCH;
				AxisValueChangedEventHandler axisValueChangedEventHandler3 = default(AxisValueChangedEventHandler);
				while (true)
				{
					int num = -1030497369;
					while (true)
					{
						switch (num ^ -1030497370)
						{
						case 0:
							break;
						case 1:
							goto IL_0025;
						default:
						{
							AxisValueChangedEventHandler axisValueChangedEventHandler2 = (AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler3, b);
							axisValueChangedEventHandler = Interlocked.CompareExchange(ref knNOmrIYwgWNUHvVmHamtKpZVCH, axisValueChangedEventHandler2, axisValueChangedEventHandler3);
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
						num = -1030497372;
					}
				}
			}
			remove
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = knNOmrIYwgWNUHvVmHamtKpZVCH;
				AxisValueChangedEventHandler axisValueChangedEventHandler3 = default(AxisValueChangedEventHandler);
				AxisValueChangedEventHandler axisValueChangedEventHandler2 = default(AxisValueChangedEventHandler);
				while (true)
				{
					int num = 344877539;
					while (true)
					{
						switch (num ^ 0x148E69E1)
						{
						case 3:
							break;
						default:
							return;
						case 2:
							axisValueChangedEventHandler3 = axisValueChangedEventHandler;
							axisValueChangedEventHandler2 = (AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler3, axisValueChangedEventHandler4);
							num = 344877536;
							continue;
						case 1:
						{
							axisValueChangedEventHandler = Interlocked.CompareExchange(ref knNOmrIYwgWNUHvVmHamtKpZVCH, axisValueChangedEventHandler2, axisValueChangedEventHandler3);
							int num2;
							if ((object)axisValueChangedEventHandler == axisValueChangedEventHandler3)
							{
								num = 344877537;
								num2 = num;
							}
							else
							{
								num = 344877539;
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
				ButtonDownEventHandler buttonDownEventHandler = xYjinylJTvFfPfZFTiNnnTDpLuqF;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, b);
					buttonDownEventHandler = Interlocked.CompareExchange(ref xYjinylJTvFfPfZFTiNnnTDpLuqF, buttonDownEventHandler3, buttonDownEventHandler2);
				}
				while ((object)buttonDownEventHandler != buttonDownEventHandler2);
			}
			remove
			{
				ButtonDownEventHandler buttonDownEventHandler = xYjinylJTvFfPfZFTiNnnTDpLuqF;
				ButtonDownEventHandler buttonDownEventHandler2 = default(ButtonDownEventHandler);
				ButtonDownEventHandler buttonDownEventHandler3 = default(ButtonDownEventHandler);
				while (true)
				{
					int num = 1910283605;
					while (true)
					{
						switch (num ^ 0x71DC9D54)
						{
						case 3:
							break;
						default:
							return;
						case 2:
						{
							int num2;
							if ((object)buttonDownEventHandler == buttonDownEventHandler2)
							{
								num = 1910283604;
								num2 = num;
							}
							else
							{
								num = 1910283605;
								num2 = num;
							}
							continue;
						}
						case 4:
							buttonDownEventHandler = Interlocked.CompareExchange(ref xYjinylJTvFfPfZFTiNnnTDpLuqF, buttonDownEventHandler3, buttonDownEventHandler2);
							num = 1910283606;
							continue;
						case 1:
							buttonDownEventHandler2 = buttonDownEventHandler;
							buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, buttonDownEventHandler4);
							num = 1910283600;
							continue;
						case 0:
							return;
						}
						break;
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
				ButtonUpEventHandler buttonUpEventHandler = LQKGfvMpnzFYJFALsMRPPJHVjYC;
				while (true)
				{
					int num = 1368102812;
					while (true)
					{
						switch (num ^ 0x518B979D)
						{
						case 2:
							break;
						default:
							return;
						case 1:
						{
							ButtonUpEventHandler buttonUpEventHandler2 = buttonUpEventHandler;
							ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, b);
							buttonUpEventHandler = Interlocked.CompareExchange(ref LQKGfvMpnzFYJFALsMRPPJHVjYC, buttonUpEventHandler3, buttonUpEventHandler2);
							int num2;
							if ((object)buttonUpEventHandler == buttonUpEventHandler2)
							{
								num = 1368102813;
								num2 = num;
							}
							else
							{
								num = 1368102812;
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
				ButtonUpEventHandler buttonUpEventHandler = LQKGfvMpnzFYJFALsMRPPJHVjYC;
				while (true)
				{
					int num = 891257679;
					while (true)
					{
						switch (num ^ 0x351F834E)
						{
						case 2:
							break;
						default:
							return;
						case 1:
						{
							ButtonUpEventHandler buttonUpEventHandler2 = buttonUpEventHandler;
							ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, buttonUpEventHandler4);
							buttonUpEventHandler = Interlocked.CompareExchange(ref LQKGfvMpnzFYJFALsMRPPJHVjYC, buttonUpEventHandler3, buttonUpEventHandler2);
							int num2;
							if ((object)buttonUpEventHandler == buttonUpEventHandler2)
							{
								num = 891257678;
								num2 = num;
							}
							else
							{
								num = 891257679;
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
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = VtjPsUSGSDMITjHFxVHaPDlCMPF;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler2, b);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref VtjPsUSGSDMITjHFxVHaPDlCMPF, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
				}
				while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
			}
			remove
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = VtjPsUSGSDMITjHFxVHaPDlCMPF;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler2, buttonValueChangedEventHandler4);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref VtjPsUSGSDMITjHFxVHaPDlCMPF, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
				}
				while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
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
				ButtonDownEventHandler buttonDownEventHandler = BQxBNKSfgdeeeCJuQDQYysoJCRx;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, b);
					buttonDownEventHandler = Interlocked.CompareExchange(ref BQxBNKSfgdeeeCJuQDQYysoJCRx, buttonDownEventHandler3, buttonDownEventHandler2);
				}
				while ((object)buttonDownEventHandler != buttonDownEventHandler2);
			}
			remove
			{
				ButtonDownEventHandler buttonDownEventHandler = BQxBNKSfgdeeeCJuQDQYysoJCRx;
				ButtonDownEventHandler buttonDownEventHandler2 = default(ButtonDownEventHandler);
				while (true)
				{
					int num = 321321140;
					while (true)
					{
						switch (num ^ 0x1326F8B7)
						{
						case 4:
							break;
						default:
							return;
						case 3:
							buttonDownEventHandler2 = buttonDownEventHandler;
							num = 321321141;
							continue;
						case 2:
						{
							ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, buttonDownEventHandler4);
							buttonDownEventHandler = Interlocked.CompareExchange(ref BQxBNKSfgdeeeCJuQDQYysoJCRx, buttonDownEventHandler3, buttonDownEventHandler2);
							num = 321321142;
							continue;
						}
						case 1:
						{
							int num2;
							if ((object)buttonDownEventHandler != buttonDownEventHandler2)
							{
								num = 321321140;
								num2 = num;
							}
							else
							{
								num = 321321143;
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
				ButtonUpEventHandler buttonUpEventHandler = UMqVHOwBSOSrmJJjaPDxZzJViRr;
				ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, b);
					buttonUpEventHandler = Interlocked.CompareExchange(ref UMqVHOwBSOSrmJJjaPDxZzJViRr, buttonUpEventHandler3, buttonUpEventHandler2);
				}
				while ((object)buttonUpEventHandler != buttonUpEventHandler2);
			}
			remove
			{
				ButtonUpEventHandler buttonUpEventHandler = UMqVHOwBSOSrmJJjaPDxZzJViRr;
				ButtonUpEventHandler buttonUpEventHandler2 = default(ButtonUpEventHandler);
				while (true)
				{
					int num = 2053386164;
					while (true)
					{
						switch (num ^ 0x7A642FB6)
						{
						case 0:
							break;
						case 2:
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
						ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, buttonUpEventHandler4);
						buttonUpEventHandler = Interlocked.CompareExchange(ref UMqVHOwBSOSrmJJjaPDxZzJViRr, buttonUpEventHandler3, buttonUpEventHandler2);
						num = 2053386167;
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
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = CLZZPyuBgmCFUzCtjACojxYrXLn;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2 = default(ButtonValueChangedEventHandler);
				ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = default(ButtonValueChangedEventHandler);
				while (true)
				{
					int num = 1525810527;
					while (true)
					{
						switch (num ^ 0x5AF2055E)
						{
						case 2:
							break;
						case 1:
							goto IL_0025;
						default:
							buttonValueChangedEventHandler = Interlocked.CompareExchange(ref CLZZPyuBgmCFUzCtjACojxYrXLn, buttonValueChangedEventHandler2, buttonValueChangedEventHandler3);
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
						num = 1525810526;
					}
				}
			}
			remove
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = CLZZPyuBgmCFUzCtjACojxYrXLn;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2 = default(ButtonValueChangedEventHandler);
				while (true)
				{
					int num = -1260112564;
					while (true)
					{
						switch (num ^ -1260112562)
						{
						case 0:
							break;
						default:
							return;
						case 4:
						{
							int num2;
							if ((object)buttonValueChangedEventHandler == buttonValueChangedEventHandler2)
							{
								num = -1260112563;
								num2 = num;
							}
							else
							{
								num = -1260112564;
								num2 = num;
							}
							continue;
						}
						case 1:
						{
							ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler2, buttonValueChangedEventHandler4);
							buttonValueChangedEventHandler = Interlocked.CompareExchange(ref CLZZPyuBgmCFUzCtjACojxYrXLn, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
							num = -1260112566;
							continue;
						}
						case 2:
							buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
							num = -1260112561;
							continue;
						case 3:
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
			if (value == _valueRawPrev)
			{
				return;
			}
			bool flag3 = default(bool);
			bool flag = default(bool);
			bool flag2 = default(bool);
			while (true)
			{
				int num;
				int num2;
				if (knNOmrIYwgWNUHvVmHamtKpZVCH != null)
				{
					num = 262478614;
					num2 = num;
				}
				else
				{
					num = 262478617;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0xFA51B10)
					{
					case 11:
						num = 262478609;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
						if (BQxBNKSfgdeeeCJuQDQYysoJCRx != null)
						{
							int num7;
							if (rawButtonValue)
							{
								num = 262478620;
								num7 = num;
							}
							else
							{
								num = 262478592;
								num7 = num;
							}
							continue;
						}
						goto case 16;
					case 2:
						if (flag3 != rawButtonValuePrev)
						{
							CLZZPyuBgmCFUzCtjACojxYrXLn(flag3);
							num = 262478611;
							continue;
						}
						goto case 3;
					case 7:
						flag3 = rawButtonValue;
						num = 262478610;
						continue;
					case 17:
						if (LQKGfvMpnzFYJFALsMRPPJHVjYC != null && !buttonValue && buttonValuePrev)
						{
							LQKGfvMpnzFYJFALsMRPPJHVjYC();
							num = 262478595;
							continue;
						}
						return;
					case 13:
						if (flag != buttonValuePrev)
						{
							VtjPsUSGSDMITjHFxVHaPDlCMPF(flag);
							num = 262478622;
							continue;
						}
						goto case 14;
					case 9:
						if (UkJMZFbJhLdMvSjhIyryUeXaJfm != null)
						{
							float num4 = this.value;
							if (num4 != valuePrev)
							{
								UkJMZFbJhLdMvSjhIyryUeXaJfm(num4);
								num = 262478608;
								continue;
							}
						}
						goto case 0;
					case 14:
						if (xYjinylJTvFfPfZFTiNnnTDpLuqF != null)
						{
							flag2 = buttonValue;
							num = 262478623;
							continue;
						}
						goto case 17;
					case 8:
						xYjinylJTvFfPfZFTiNnnTDpLuqF();
						num = 262478593;
						continue;
					case 18:
						if (!rawButtonValue)
						{
							int num8;
							if (!rawButtonValuePrev)
							{
								num = 262478618;
								num8 = num;
							}
							else
							{
								num = 262478612;
								num8 = num;
							}
							continue;
						}
						goto case 10;
					case 4:
						UMqVHOwBSOSrmJJjaPDxZzJViRr();
						num = 262478618;
						continue;
					case 6:
						if (_valueRaw != _valueRawPrev)
						{
							knNOmrIYwgWNUHvVmHamtKpZVCH(_valueRaw);
							num = 262478617;
							continue;
						}
						goto case 9;
					case 0:
					{
						int num6;
						if (CLZZPyuBgmCFUzCtjACojxYrXLn == null)
						{
							num = 262478611;
							num6 = num;
						}
						else
						{
							num = 262478615;
							num6 = num;
						}
						continue;
					}
					case 12:
						if (!rawButtonValuePrev)
						{
							BQxBNKSfgdeeeCJuQDQYysoJCRx();
							num = 262478592;
							continue;
						}
						goto case 16;
					case 15:
						if (flag2)
						{
							int num3;
							if (buttonValuePrev)
							{
								num = 262478593;
								num3 = num;
							}
							else
							{
								num = 262478616;
								num3 = num;
							}
							continue;
						}
						goto case 17;
					case 5:
						flag = buttonValue;
						num = 262478621;
						continue;
					case 16:
					{
						int num5;
						if (UMqVHOwBSOSrmJJjaPDxZzJViRr == null)
						{
							num = 262478618;
							num5 = num;
						}
						else
						{
							num = 262478594;
							num5 = num;
						}
						continue;
					}
					case 10:
					{
						int num9;
						if (VtjPsUSGSDMITjHFxVHaPDlCMPF != null)
						{
							num = 262478613;
							num9 = num;
						}
						else
						{
							num = 262478622;
							num9 = num;
						}
						continue;
					}
					case 19:
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
