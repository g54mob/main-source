using System;
using System.Runtime.CompilerServices;
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

		[Tooltip("Contains calibration settings for the axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisCalibration _calibration = new AxisCalibration();

		[CustomObfuscation(rename = false)]
		private float _valueRaw;

		[CustomObfuscation(rename = false)]
		private float _valueRawPrev;

		[CompilerGenerated]
		private AxisValueChangedEventHandler HbbtvwbJVxDLtDBvBsMguKELybqe;

		[CompilerGenerated]
		private AxisValueChangedEventHandler GdWnVIdQoyqjINJDPoSwqxCQSkrp;

		[CompilerGenerated]
		private ButtonDownEventHandler rCZBebsrwUiiuiXGlNstkLEeCJxY;

		[CompilerGenerated]
		private ButtonUpEventHandler NFYtfkYoIXgSuIvMyYpYnXcToNl;

		[CompilerGenerated]
		private ButtonValueChangedEventHandler uLlSpstyxFnyMOBhJtmihEoEPcgt;

		[CompilerGenerated]
		private ButtonDownEventHandler emllHftSPknevllihShsIvVtcgLQ;

		[CompilerGenerated]
		private ButtonUpEventHandler wbyrwMQreytmKTWeoEeqlAGpHMMI;

		[CompilerGenerated]
		private ButtonValueChangedEventHandler jQSvGrsRTlQmefVPoYSgrEjYtEDH;

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
				if (num != _valueRaw)
				{
					_valueRaw = num;
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
			[CompilerGenerated]
			add
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = HbbtvwbJVxDLtDBvBsMguKELybqe;
				AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler2, b);
					axisValueChangedEventHandler = Interlocked.CompareExchange(ref HbbtvwbJVxDLtDBvBsMguKELybqe, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
				}
				while ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = HbbtvwbJVxDLtDBvBsMguKELybqe;
				AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler2, axisValueChangedEventHandler4);
					axisValueChangedEventHandler = Interlocked.CompareExchange(ref HbbtvwbJVxDLtDBvBsMguKELybqe, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
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
			[CompilerGenerated]
			add
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = GdWnVIdQoyqjINJDPoSwqxCQSkrp;
				AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler2, b);
					axisValueChangedEventHandler = Interlocked.CompareExchange(ref GdWnVIdQoyqjINJDPoSwqxCQSkrp, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
				}
				while ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				AxisValueChangedEventHandler axisValueChangedEventHandler = GdWnVIdQoyqjINJDPoSwqxCQSkrp;
				AxisValueChangedEventHandler axisValueChangedEventHandler2;
				do
				{
					axisValueChangedEventHandler2 = axisValueChangedEventHandler;
					AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler2, axisValueChangedEventHandler4);
					axisValueChangedEventHandler = Interlocked.CompareExchange(ref GdWnVIdQoyqjINJDPoSwqxCQSkrp, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
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
			[CompilerGenerated]
			add
			{
				ButtonDownEventHandler buttonDownEventHandler = rCZBebsrwUiiuiXGlNstkLEeCJxY;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, b);
					buttonDownEventHandler = Interlocked.CompareExchange(ref rCZBebsrwUiiuiXGlNstkLEeCJxY, buttonDownEventHandler3, buttonDownEventHandler2);
				}
				while ((object)buttonDownEventHandler != buttonDownEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ButtonDownEventHandler buttonDownEventHandler = rCZBebsrwUiiuiXGlNstkLEeCJxY;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, buttonDownEventHandler4);
					buttonDownEventHandler = Interlocked.CompareExchange(ref rCZBebsrwUiiuiXGlNstkLEeCJxY, buttonDownEventHandler3, buttonDownEventHandler2);
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
			[CompilerGenerated]
			add
			{
				ButtonUpEventHandler buttonUpEventHandler = NFYtfkYoIXgSuIvMyYpYnXcToNl;
				ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, b);
					buttonUpEventHandler = Interlocked.CompareExchange(ref NFYtfkYoIXgSuIvMyYpYnXcToNl, buttonUpEventHandler3, buttonUpEventHandler2);
				}
				while ((object)buttonUpEventHandler != buttonUpEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ButtonUpEventHandler buttonUpEventHandler = NFYtfkYoIXgSuIvMyYpYnXcToNl;
				ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, buttonUpEventHandler4);
					buttonUpEventHandler = Interlocked.CompareExchange(ref NFYtfkYoIXgSuIvMyYpYnXcToNl, buttonUpEventHandler3, buttonUpEventHandler2);
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
			[CompilerGenerated]
			add
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = uLlSpstyxFnyMOBhJtmihEoEPcgt;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler2, b);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref uLlSpstyxFnyMOBhJtmihEoEPcgt, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
				}
				while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = uLlSpstyxFnyMOBhJtmihEoEPcgt;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler2, buttonValueChangedEventHandler4);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref uLlSpstyxFnyMOBhJtmihEoEPcgt, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
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
			[CompilerGenerated]
			add
			{
				ButtonDownEventHandler buttonDownEventHandler = emllHftSPknevllihShsIvVtcgLQ;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, b);
					buttonDownEventHandler = Interlocked.CompareExchange(ref emllHftSPknevllihShsIvVtcgLQ, buttonDownEventHandler3, buttonDownEventHandler2);
				}
				while ((object)buttonDownEventHandler != buttonDownEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ButtonDownEventHandler buttonDownEventHandler = emllHftSPknevllihShsIvVtcgLQ;
				ButtonDownEventHandler buttonDownEventHandler2;
				do
				{
					buttonDownEventHandler2 = buttonDownEventHandler;
					ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, buttonDownEventHandler4);
					buttonDownEventHandler = Interlocked.CompareExchange(ref emllHftSPknevllihShsIvVtcgLQ, buttonDownEventHandler3, buttonDownEventHandler2);
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
			[CompilerGenerated]
			add
			{
				ButtonUpEventHandler buttonUpEventHandler = wbyrwMQreytmKTWeoEeqlAGpHMMI;
				ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, b);
					buttonUpEventHandler = Interlocked.CompareExchange(ref wbyrwMQreytmKTWeoEeqlAGpHMMI, buttonUpEventHandler3, buttonUpEventHandler2);
				}
				while ((object)buttonUpEventHandler != buttonUpEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ButtonUpEventHandler buttonUpEventHandler = wbyrwMQreytmKTWeoEeqlAGpHMMI;
				ButtonUpEventHandler buttonUpEventHandler2;
				do
				{
					buttonUpEventHandler2 = buttonUpEventHandler;
					ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, buttonUpEventHandler4);
					buttonUpEventHandler = Interlocked.CompareExchange(ref wbyrwMQreytmKTWeoEeqlAGpHMMI, buttonUpEventHandler3, buttonUpEventHandler2);
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
			[CompilerGenerated]
			add
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = jQSvGrsRTlQmefVPoYSgrEjYtEDH;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler2, b);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref jQSvGrsRTlQmefVPoYSgrEjYtEDH, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
				}
				while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ButtonValueChangedEventHandler buttonValueChangedEventHandler = jQSvGrsRTlQmefVPoYSgrEjYtEDH;
				ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
				do
				{
					buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
					ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler2, buttonValueChangedEventHandler4);
					buttonValueChangedEventHandler = Interlocked.CompareExchange(ref jQSvGrsRTlQmefVPoYSgrEjYtEDH, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
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
			if (GdWnVIdQoyqjINJDPoSwqxCQSkrp != null && _valueRaw != _valueRawPrev)
			{
				GdWnVIdQoyqjINJDPoSwqxCQSkrp(_valueRaw);
			}
			if (HbbtvwbJVxDLtDBvBsMguKELybqe != null)
			{
				float num = this.value;
				if (num != valuePrev)
				{
					HbbtvwbJVxDLtDBvBsMguKELybqe(num);
				}
			}
			if (jQSvGrsRTlQmefVPoYSgrEjYtEDH != null)
			{
				bool flag = rawButtonValue;
				if (flag != rawButtonValuePrev)
				{
					jQSvGrsRTlQmefVPoYSgrEjYtEDH(flag);
				}
			}
			if (emllHftSPknevllihShsIvVtcgLQ != null && rawButtonValue && !rawButtonValuePrev)
			{
				emllHftSPknevllihShsIvVtcgLQ();
			}
			if (wbyrwMQreytmKTWeoEeqlAGpHMMI != null && !rawButtonValue && rawButtonValuePrev)
			{
				wbyrwMQreytmKTWeoEeqlAGpHMMI();
			}
			if (uLlSpstyxFnyMOBhJtmihEoEPcgt != null)
			{
				bool flag2 = buttonValue;
				if (flag2 != buttonValuePrev)
				{
					uLlSpstyxFnyMOBhJtmihEoEPcgt(flag2);
				}
			}
			if (rCZBebsrwUiiuiXGlNstkLEeCJxY != null && buttonValue && !buttonValuePrev)
			{
				rCZBebsrwUiiuiXGlNstkLEeCJxY();
			}
			if (NFYtfkYoIXgSuIvMyYpYnXcToNl != null && !buttonValue && buttonValuePrev)
			{
				NFYtfkYoIXgSuIvMyYpYnXcToNl();
			}
		}

		public void Clear()
		{
			SetRawValue(rawZero);
		}

		[CustomObfuscation(rename = false)]
		internal static StandaloneAxis CreateRelative()
		{
			return new StandaloneAxis
			{
				_calibration = AxisCalibration.CreateRelative()
			};
		}
	}
}
