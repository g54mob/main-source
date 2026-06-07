using UnityEngine;

namespace GAudio
{
	public class GATEnvelope
	{
		public class NullEnvelope : GATEnvelope
		{
			public override void ProcessSample(GATData sample)
			{
			}
		}

		protected int _length;

		protected int _fadeInSamples;

		protected int _fadeOutSamples;

		protected int _offset;

		protected bool _normalize;

		protected bool _reverse;

		protected float _normalizeValue;

		public static readonly NullEnvelope nullEnvelope;

		public int Length
		{
			get
			{
				return _length;
			}
			set
			{
				if (value < 64)
				{
					value = 64;
				}
				_length = value;
				LastLengthChangeTime = AudioSettings.dspTime;
				LastChangeTime = LastLengthChangeTime;
			}
		}

		public int FadeInSamples
		{
			get
			{
				return _fadeInSamples;
			}
			set
			{
				if (value < 0)
				{
					value = 0;
				}
				_fadeInSamples = value;
				LastChangeTime = AudioSettings.dspTime;
			}
		}

		public int FadeOutSamples
		{
			get
			{
				return _fadeOutSamples;
			}
			set
			{
				if (value < 0)
				{
					value = 0;
				}
				_fadeOutSamples = value;
				LastChangeTime = AudioSettings.dspTime;
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
				if (value < 0)
				{
					value = 0;
				}
				_offset = value;
				LastChangeTime = AudioSettings.dspTime;
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
				_normalize = value;
				LastChangeTime = AudioSettings.dspTime;
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
				if (value < 0f)
				{
					value = 0f;
				}
				_normalizeValue = value;
				if (_normalize)
				{
					LastChangeTime = AudioSettings.dspTime;
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
				_reverse = value;
				LastChangeTime = AudioSettings.dspTime;
			}
		}

		public double LastChangeTime { get; protected set; }

		public double LastLengthChangeTime { get; protected set; }

		public GATEnvelope(int length, int fadeInSamples, int fadeOutSamples, int offset, bool doNormalize = true, float normalizeValue = 0.3f)
		{
			_length = length;
			_fadeInSamples = fadeInSamples;
			_fadeOutSamples = fadeOutSamples;
			_offset = offset;
			_normalizeValue = normalizeValue;
			_normalize = doNormalize;
			LastLengthChangeTime = AudioSettings.dspTime;
			LastChangeTime = LastLengthChangeTime;
		}

		public virtual void ProcessSample(GATData sample)
		{
			if (_normalize)
			{
				sample.Normalize(_normalizeValue);
			}
			if (_reverse)
			{
				sample.Reverse();
			}
			if (_fadeInSamples > 0)
			{
				sample.FadeIn(_fadeInSamples);
			}
			if (_fadeOutSamples > 0)
			{
				sample.FadeOut(_fadeOutSamples);
			}
		}

		public void SetParams(int length, int fadeIn, int fadeOut)
		{
			_length = length;
			_fadeInSamples = fadeIn;
			_fadeOutSamples = fadeOut;
			LastLengthChangeTime = AudioSettings.dspTime;
			LastChangeTime = LastLengthChangeTime;
		}

		protected GATEnvelope()
		{
		}

		static GATEnvelope()
		{
			nullEnvelope = new NullEnvelope();
		}
	}
}
