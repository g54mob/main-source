namespace GAudio
{
	public class GATDynamicChannelGain : GATChannelGain
	{
		private bool _needsUpdate;

		private float _prevGain;

		private float _nextGain;

		public bool ShouldInterpolate { get; set; }

		public float InterpolationDelta { get; private set; }

		public override float Gain
		{
			get
			{
				return _gain;
			}
			protected set
			{
				_prevGain = _gain;
				_gain = value;
			}
		}

		public float PrevGain => _prevGain;

		public float NextGain
		{
			set
			{
				_nextGain = value;
				_needsUpdate = true;
			}
		}

		public GATDynamicChannelGain(int ichannelnumber, float igain)
			: base(ichannelnumber, igain)
		{
		}

		public void Snap()
		{
			if (_needsUpdate)
			{
				_gain = _nextGain;
				_prevGain = _nextGain;
				_needsUpdate = false;
				ShouldInterpolate = false;
			}
		}

		public void PlayerWillMix()
		{
			if (_needsUpdate)
			{
				Gain = _nextGain;
				float num = _gain - _prevGain;
				if (num > GATInfo.MaxGainDelta || num < 0f - GATInfo.MaxGainDelta)
				{
					InterpolationDelta = num / (float)GATInfo.AudioBufferSizePerChannel;
					ShouldInterpolate = true;
				}
				else
				{
					ShouldInterpolate = false;
				}
				_needsUpdate = false;
			}
		}

		public void PlayerDidMix()
		{
			ShouldInterpolate = false;
		}
	}
}
