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

		[CustomObfuscation(rename = false)]
		[Range(0f, 1f)]
		[Tooltip("The axis value at or above which the buttonValue property will return True. This will also return true for negative values below the inverse of this threshold.")]
		[SerializeField]
		private float _buttonActivationThreshold = 0.5f;

		[Tooltip("Contains calibration settings for the axis.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private AxisCalibration _calibration = new AxisCalibration();

		[CustomObfuscation(rename = false)]
		private float _valueRaw;

		[CustomObfuscation(rename = false)]
		private float _valueRawPrev;

		private AxisValueChangedEventHandler HlcQcPamEeQYUXnCttxpkbIRLGe;

		private AxisValueChangedEventHandler fpaSVrVIvFAGhUOORVwhFbPeFnR;

		private ButtonDownEventHandler kvGAkyiXuIvrmGbysXIedbAIEMg;

		private ButtonUpEventHandler YSpkxrRBWOcEaWfuVJHAnMUcvwQ;

		private ButtonValueChangedEventHandler WaAcSWAVlgjIiqcgMvPrRbqzhmLw;

		private ButtonDownEventHandler MwKtGEXVMQPgNZfFvFFZGWhcfcnl;

		private ButtonUpEventHandler TFNUBQxdvbbSDUJCZBnoxsOcvBl;

		private ButtonValueChangedEventHandler JNmYCijEiDoIhmCEQRCvBJXAtfr;

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
				if (value != _calibration)
				{
					_calibration = value;
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
				if (value != _valueRaw)
				{
					_valueRaw = value;
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
				if (value != _valueRawPrev)
				{
					_valueRawPrev = value;
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
				AxisValueChangedEventHandler axisValueChangedEventHandler = HlcQcPamEeQYUXnCttxpkbIRLGe;
				AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler2, value);
					axisValueChangedEventHandler = Interlocked.CompareExchange(ref HlcQcPamEeQYUXnCttxpkbIRLGe, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
				}
				while ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2);
			}
			remove
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = HlcQcPamEeQYUXnCttxpkbIRLGe;
				AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler2, value);
					axisValueChangedEventHandler = Interlocked.CompareExchange(ref HlcQcPamEeQYUXnCttxpkbIRLGe, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
				}
				while ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2);
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
				AxisValueChangedEventHandler axisValueChangedEventHandler = fpaSVrVIvFAGhUOORVwhFbPeFnR;
				AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler2, value);
					axisValueChangedEventHandler = Interlocked.CompareExchange(ref fpaSVrVIvFAGhUOORVwhFbPeFnR, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
				}
				while ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2);
			}
			remove
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = fpaSVrVIvFAGhUOORVwhFbPeFnR;
				AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler2, value);
					axisValueChangedEventHandler = Interlocked.CompareExchange(ref fpaSVrVIvFAGhUOORVwhFbPeFnR, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
				}
				while ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2);
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
				ButtonDownEventHandler buttonDownEventHandler = kvGAkyiXuIvrmGbysXIedbAIEMg;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, value);
					buttonDownEventHandler = Interlocked.CompareExchange(ref kvGAkyiXuIvrmGbysXIedbAIEMg, buttonDownEventHandler3, buttonDownEventHandler2);
				}
				while ((object)buttonDownEventHandler != buttonDownEventHandler2);
			}
			remove
			{
				ButtonDownEventHandler buttonDownEventHandler = kvGAkyiXuIvrmGbysXIedbAIEMg;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, value);
					buttonDownEventHandler = Interlocked.CompareExchange(ref kvGAkyiXuIvrmGbysXIedbAIEMg, buttonDownEventHandler3, buttonDownEventHandler2);
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
				ButtonUpEventHandler buttonUpEventHandler = YSpkxrRBWOcEaWfuVJHAnMUcvwQ;
				ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, value);
					buttonUpEventHandler = Interlocked.CompareExchange(ref YSpkxrRBWOcEaWfuVJHAnMUcvwQ, buttonUpEventHandler3, buttonUpEventHandler2);
				}
				while ((object)buttonUpEventHandler != buttonUpEventHandler2);
			}
			remove
			{
				ButtonUpEventHandler buttonUpEventHandler = YSpkxrRBWOcEaWfuVJHAnMUcvwQ;
				ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, value);
					buttonUpEventHandler = Interlocked.CompareExchange(ref YSpkxrRBWOcEaWfuVJHAnMUcvwQ, buttonUpEventHandler3, buttonUpEventHandler2);
				}
				while ((object)buttonUpEventHandler != buttonUpEventHandler2);
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
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = WaAcSWAVlgjIiqcgMvPrRbqzhmLw;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler2, value);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref WaAcSWAVlgjIiqcgMvPrRbqzhmLw, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
				}
				while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
			}
			remove
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = WaAcSWAVlgjIiqcgMvPrRbqzhmLw;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler2, value);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref WaAcSWAVlgjIiqcgMvPrRbqzhmLw, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
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
				ButtonDownEventHandler buttonDownEventHandler = MwKtGEXVMQPgNZfFvFFZGWhcfcnl;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, value);
					buttonDownEventHandler = Interlocked.CompareExchange(ref MwKtGEXVMQPgNZfFvFFZGWhcfcnl, buttonDownEventHandler3, buttonDownEventHandler2);
				}
				while ((object)buttonDownEventHandler != buttonDownEventHandler2);
			}
			remove
			{
				ButtonDownEventHandler buttonDownEventHandler = MwKtGEXVMQPgNZfFvFFZGWhcfcnl;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, value);
					buttonDownEventHandler = Interlocked.CompareExchange(ref MwKtGEXVMQPgNZfFvFFZGWhcfcnl, buttonDownEventHandler3, buttonDownEventHandler2);
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
				ButtonUpEventHandler buttonUpEventHandler = TFNUBQxdvbbSDUJCZBnoxsOcvBl;
				ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, value);
					buttonUpEventHandler = Interlocked.CompareExchange(ref TFNUBQxdvbbSDUJCZBnoxsOcvBl, buttonUpEventHandler3, buttonUpEventHandler2);
				}
				while ((object)buttonUpEventHandler != buttonUpEventHandler2);
			}
			remove
			{
				ButtonUpEventHandler buttonUpEventHandler = TFNUBQxdvbbSDUJCZBnoxsOcvBl;
				ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, value);
					buttonUpEventHandler = Interlocked.CompareExchange(ref TFNUBQxdvbbSDUJCZBnoxsOcvBl, buttonUpEventHandler3, buttonUpEventHandler2);
				}
				while ((object)buttonUpEventHandler != buttonUpEventHandler2);
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
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = JNmYCijEiDoIhmCEQRCvBJXAtfr;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler2, value);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref JNmYCijEiDoIhmCEQRCvBJXAtfr, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
				}
				while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
			}
			remove
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = JNmYCijEiDoIhmCEQRCvBJXAtfr;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler2, value);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref JNmYCijEiDoIhmCEQRCvBJXAtfr, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
				}
				while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
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
			if (fpaSVrVIvFAGhUOORVwhFbPeFnR != null && _valueRaw != _valueRawPrev)
			{
				fpaSVrVIvFAGhUOORVwhFbPeFnR(_valueRaw);
			}
			if (HlcQcPamEeQYUXnCttxpkbIRLGe != null)
			{
				float num = this.value;
				if (num != valuePrev)
				{
					HlcQcPamEeQYUXnCttxpkbIRLGe(num);
				}
			}
			if (JNmYCijEiDoIhmCEQRCvBJXAtfr != null)
			{
				bool flag = rawButtonValue;
				if (flag != rawButtonValuePrev)
				{
					JNmYCijEiDoIhmCEQRCvBJXAtfr(flag);
				}
			}
			if (MwKtGEXVMQPgNZfFvFFZGWhcfcnl != null && rawButtonValue && !rawButtonValuePrev)
			{
				MwKtGEXVMQPgNZfFvFFZGWhcfcnl();
			}
			if (TFNUBQxdvbbSDUJCZBnoxsOcvBl != null && !rawButtonValue && rawButtonValuePrev)
			{
				TFNUBQxdvbbSDUJCZBnoxsOcvBl();
			}
			if (WaAcSWAVlgjIiqcgMvPrRbqzhmLw != null)
			{
				bool flag2 = buttonValue;
				if (flag2 != buttonValuePrev)
				{
					WaAcSWAVlgjIiqcgMvPrRbqzhmLw(flag2);
				}
			}
			if (kvGAkyiXuIvrmGbysXIedbAIEMg != null && buttonValue && !buttonValuePrev)
			{
				kvGAkyiXuIvrmGbysXIedbAIEMg();
			}
			if (YSpkxrRBWOcEaWfuVJHAnMUcvwQ != null && !buttonValue && buttonValuePrev)
			{
				YSpkxrRBWOcEaWfuVJHAnMUcvwQ();
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
