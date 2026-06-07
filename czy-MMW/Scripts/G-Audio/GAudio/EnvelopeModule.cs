using System;
using UnityEngine;

namespace GAudio
{
	[ExecuteInEditMode]
	public class EnvelopeModule : MonoBehaviour
	{
		[SerializeField]
		protected int _length = 44100;

		[SerializeField]
		protected int _fadeIn;

		[SerializeField]
		protected int _fadeOut = 12000;

		[SerializeField]
		protected int _offset;

		[SerializeField]
		protected bool _normalize = true;

		[SerializeField]
		protected float _normalizeValue = 0.3f;

		[SerializeField]
		protected bool _reverse;

		[SerializeField]
		protected PulseModule _pulse;

		[SerializeField]
		protected bool _mapLengthToPulse;

		[SerializeField]
		protected float _lengthToPulseRatio = 1f;

		protected bool _ratioDidChange;

		public int Length
		{
			get
			{
				return _length;
			}
			set
			{
				if (_length != value)
				{
					Envelope.Length = value;
					_length = value;
				}
			}
		}

		public int FadeIn
		{
			get
			{
				return _fadeIn;
			}
			set
			{
				if (_fadeIn != value)
				{
					Envelope.FadeInSamples = value;
					_fadeIn = value;
				}
			}
		}

		public int FadeOut
		{
			get
			{
				return _fadeOut;
			}
			set
			{
				if (_fadeOut != value)
				{
					Envelope.FadeOutSamples = value;
					_fadeOut = value;
				}
			}
		}

		public int Offset
		{
			get
			{
				return _offset;
			}
			set
			{
				if (_offset != value)
				{
					Envelope.Offset = value;
					_offset = value;
				}
			}
		}

		public bool Normalize
		{
			get
			{
				return _normalize;
			}
			set
			{
				if (_normalize != value)
				{
					Envelope.Normalize = value;
					_normalize = value;
				}
			}
		}

		public float NormalizeValue
		{
			get
			{
				return _normalizeValue;
			}
			set
			{
				if (_normalizeValue != value)
				{
					Envelope.NormalizeValue = value;
					_normalizeValue = value;
				}
			}
		}

		public bool Reverse
		{
			get
			{
				return _reverse;
			}
			set
			{
				if (_reverse != value)
				{
					Envelope.Reverse = value;
					_reverse = value;
				}
			}
		}

		public PulseModule Pulse
		{
			get
			{
				return _pulse;
			}
			set
			{
				if (_pulse == value)
				{
					return;
				}
				if (_mapLengthToPulse)
				{
					if (_pulse != null)
					{
						PulseModule pulse = _pulse;
						pulse.onWillPulse = (PulseModule.OnPulseHandler)Delegate.Remove(pulse.onWillPulse, new PulseModule.OnPulseHandler(OnWillPulse));
					}
					if (value != null)
					{
						value.onWillPulse = (PulseModule.OnPulseHandler)Delegate.Combine(value.onWillPulse, new PulseModule.OnPulseHandler(OnWillPulse));
					}
				}
				_pulse = value;
			}
		}

		public bool MapLengthToPulse
		{
			get
			{
				return _mapLengthToPulse;
			}
			set
			{
				if (_mapLengthToPulse == value)
				{
					return;
				}
				if (_pulse != null)
				{
					if (value)
					{
						_lengthToPulseRatio = (float)_length / (float)GATInfo.OutputSampleRate / (float)_pulse.PulseInfo.PulseDuration;
						PulseModule pulse = _pulse;
						pulse.onWillPulse = (PulseModule.OnPulseHandler)Delegate.Combine(pulse.onWillPulse, new PulseModule.OnPulseHandler(OnWillPulse));
					}
					else
					{
						PulseModule pulse2 = _pulse;
						pulse2.onWillPulse = (PulseModule.OnPulseHandler)Delegate.Remove(pulse2.onWillPulse, new PulseModule.OnPulseHandler(OnWillPulse));
					}
				}
				_mapLengthToPulse = value;
			}
		}

		public float LengthToPulseRatio
		{
			get
			{
				return _lengthToPulseRatio;
			}
			set
			{
				if (_lengthToPulseRatio != value)
				{
					_lengthToPulseRatio = value;
					_ratioDidChange = true;
				}
			}
		}

		public GATEnvelope Envelope { get; protected set; }

		private void Awake()
		{
			Envelope = new GATEnvelope(_length, _fadeIn, _fadeOut, _offset, _normalize, _normalizeValue);
		}

		private void OnEnable()
		{
			if (_pulse != null && _mapLengthToPulse)
			{
				PulseModule pulse = _pulse;
				pulse.onWillPulse = (PulseModule.OnPulseHandler)Delegate.Combine(pulse.onWillPulse, new PulseModule.OnPulseHandler(OnWillPulse));
			}
			if (Envelope == null)
			{
				Envelope = new GATEnvelope(_length, _fadeIn, _fadeOut, _offset, _normalize, _normalizeValue);
			}
		}

		private void OnDisable()
		{
			if (_pulse != null)
			{
				PulseModule pulse = _pulse;
				pulse.onWillPulse = (PulseModule.OnPulseHandler)Delegate.Remove(pulse.onWillPulse, new PulseModule.OnPulseHandler(OnWillPulse));
			}
		}

		public void OnWillPulse(IGATPulseInfo pulseInfo)
		{
			if ((pulseInfo.PulseDidChange || _ratioDidChange) && _mapLengthToPulse)
			{
				MapLength(pulseInfo.PulseDuration);
				_ratioDidChange = false;
			}
		}

		private void MapLength(double pulseDuration)
		{
			int num = (int)(pulseDuration * (double)_lengthToPulseRatio * (double)GATInfo.OutputSampleRate);
			if (_fadeOut + _fadeIn > num)
			{
				int num2 = (_length - num) / 2 + 1;
				if (_fadeIn - num2 < 0)
				{
					_fadeIn = 8;
				}
				else
				{
					_fadeIn -= num2;
				}
				if (_fadeOut - num2 < 0)
				{
					_fadeOut = 8;
				}
				else
				{
					_fadeOut -= num2;
				}
				_length = num;
				Envelope.SetParams(_length, _fadeIn, _fadeOut);
			}
			else
			{
				_length = num;
				Envelope.Length = num;
			}
		}
	}
}
