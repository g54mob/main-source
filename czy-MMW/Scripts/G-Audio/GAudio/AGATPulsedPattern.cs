using UnityEngine;

namespace GAudio
{
	[ExecuteInEditMode]
	public abstract class AGATPulsedPattern : AGATPulseClient
	{
		public delegate void OnPatternWillPlay(PatternSample sample, int indexInPattern, double dspTime);

		public enum PlayingOrder
		{
			MapToPulseIndex = 0,
			Sequential = 1,
			Randomized = 2,
			MapToMasterPulseIndex = 3,
			Together = 4
		}

		public OnPatternWillPlay onPatternWillPlay;

		[SerializeField]
		protected GATPlayer _player;

		[SerializeField]
		protected GATActiveSampleBank _sampleBank;

		[SerializeField]
		protected int _trackNb;

		[SerializeField]
		protected PlayingOrder _playingOrder;

		[SerializeField]
		protected bool _randomDelay;

		[SerializeField]
		protected float _randomDelayMaxRatio;

		[SerializeField]
		protected bool _randomBypass;

		[SerializeField]
		protected float _randomBypassChance;

		private int _sampleIndex = -1;

		protected int _sampleCount;

		public GATPlayer Player
		{
			get
			{
				return _player;
			}
			set
			{
				if (!(_player == value))
				{
					_player = value;
					if (_player != null)
					{
						SubscribeToPulseIfNeeded();
					}
					else
					{
						UnsubscribeToPulse();
					}
				}
			}
		}

		public GATActiveSampleBank SampleBank
		{
			get
			{
				return _sampleBank;
			}
			set
			{
				if (!(_sampleBank == value))
				{
					_sampleBank = value;
					if (_sampleBank != null)
					{
						SubscribeToPulseIfNeeded();
					}
					else
					{
						UnsubscribeToPulse();
					}
				}
			}
		}

		public int TrackNb
		{
			get
			{
				return _trackNb;
			}
			set
			{
				if (_trackNb != value && !(_player == null) && _player.NbOfTracks > value)
				{
					_trackNb = value;
				}
			}
		}

		public PlayingOrder SamplesOrdering
		{
			get
			{
				return _playingOrder;
			}
			set
			{
				if (_playingOrder != value)
				{
					_playingOrder = value;
				}
			}
		}

		public bool AddRandomDelay
		{
			get
			{
				return _randomDelay;
			}
			set
			{
				if (_randomDelay != value)
				{
					_randomDelay = value;
				}
			}
		}

		public float RandomDelayMaxRatio
		{
			get
			{
				return _randomDelayMaxRatio;
			}
			set
			{
				if (_randomDelayMaxRatio != value)
				{
					_randomDelayMaxRatio = value;
				}
			}
		}

		public bool RandomBypass
		{
			get
			{
				return _randomBypass;
			}
			set
			{
				if (_randomBypass != value)
				{
					_randomBypass = value;
				}
			}
		}

		public float RandomBypassChance
		{
			get
			{
				return _randomBypassChance;
			}
			set
			{
				if (_randomBypassChance != value)
				{
					_randomBypassChance = value;
				}
			}
		}

		protected override bool CanSubscribeToPulse()
		{
			if (!base.CanSubscribeToPulse() || !_sampleBank || _player == null)
			{
				return false;
			}
			return true;
		}

		public override void OnPulse(IGATPulseInfo pulseInfo)
		{
			if (!_subscribedSteps[pulseInfo.StepIndex] || (_randomBypass && Random.value < _randomBypassChance))
			{
				return;
			}
			UpdateIndex(pulseInfo);
			double num = pulseInfo.PulseDspTime;
			if (_randomDelay)
			{
				num += (double)Random.Range(0f, _randomDelayMaxRatio) * pulseInfo.PulseDuration;
			}
			if (_playingOrder != PlayingOrder.Together)
			{
				PlaySample(_sampleIndex, num);
				return;
			}
			for (int i = 0; i < _sampleCount; i++)
			{
				PlaySample(i, num);
			}
		}

		protected override void Awake()
		{
			base.Awake();
			_sampleCount = UpdatedSampleCount();
			if (_player == null)
			{
				_player = GATManager.DefaultPlayer;
			}
		}

		public abstract void PlaySample(int index, double dspTime);

		protected abstract int UpdatedSampleCount();

		private void UpdateIndex(IGATPulseInfo pulseInfo)
		{
			switch (_playingOrder)
			{
			case PlayingOrder.MapToPulseIndex:
				_sampleIndex = pulseInfo.StepIndex % _sampleCount;
				break;
			case PlayingOrder.Sequential:
				_sampleIndex = (_sampleIndex + 1) % _sampleCount;
				break;
			case PlayingOrder.Randomized:
				_sampleIndex = Random.Range(0, _sampleCount);
				break;
			case PlayingOrder.MapToMasterPulseIndex:
				_sampleIndex = pulseInfo.PulseSender.MasterPulseInfo.StepIndex;
				break;
			}
		}
	}
}
