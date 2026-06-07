using GAudio;
using UnityEngine;

namespace Motorways.Audio
{
	public class AudioSample
	{
		public class PanInfo : AGATPanInfo
		{
			private float _fixedPan = 0.5f;

			private bool _channelsDirty;

			private bool _shouldSnapPan;

			private GATDynamicPanInfo _dynamicPanInfo = new GATDynamicPanInfo(GATManager.DefaultPlayer, startsActive: false);

			public IGATDynamicMixInfo DynamicMix { get; set; }

			public float FixedPan
			{
				get
				{
					return _fixedPan;
				}
				set
				{
					_fixedPan = value;
					_channelsDirty = true;
				}
			}

			public override bool IsAudible
			{
				get
				{
					UpdateChannels();
					return _dynamicPanInfo.IsAudible;
				}
			}

			public PanInfo()
			{
				_channelsDirty = true;
			}

			public void Recycle()
			{
				DynamicMix = null;
				FixedPan = 0.5f;
				_dynamicPanInfo.Active = false;
				_dynamicPanInfo.SetGainForChannel(0.5f, 0);
				_dynamicPanInfo.SetGainForChannel(0.5f, 1);
			}

			public void OnPlay()
			{
				_dynamicPanInfo.Active = true;
				_shouldSnapPan = true;
				_channelsDirty = true;
			}

			public override void PanMixSample(IGATBufferedSample sample, int length, float[] audioBuffer, float gain = 1f)
			{
				UpdateChannels();
				_dynamicPanInfo.PanMixSample(sample, length, audioBuffer, gain);
			}

			public override void PanMixProcessingBuffer(IGATBufferedSample sample, int length, float[] audioBuffer, float gain = 1f)
			{
				UpdateChannels();
				_dynamicPanInfo.PanMixProcessingBuffer(sample, length, audioBuffer, gain);
			}

			public override void SetGains(float[] gains)
			{
				if (gains.Length == 2)
				{
					_dynamicPanInfo.SetGainForChannel(gains[0], 0);
					_dynamicPanInfo.SetGainForChannel(gains[1], 1);
				}
			}

			private void UpdateChannels()
			{
				IGATDynamicMixInfo dynamicMix = DynamicMix;
				if (dynamicMix != null || _channelsDirty)
				{
					_channelsDirty = false;
					float num = 1f;
					float num2 = _fixedPan;
					if (dynamicMix != null)
					{
						float num3 = (dynamicMix.HasStaticGain ? dynamicMix.StaticGain : dynamicMix.Gain);
						num = ((num3 >= 0f) ? num3 : num);
						float num4 = (dynamicMix.HasStaticPan ? dynamicMix.StaticPan : dynamicMix.Pan);
						num2 = ((num4 >= 0f) ? num4 : num2);
					}
					_dynamicPanInfo.SetGainForChannel((1f - num2) * num, 0);
					_dynamicPanInfo.SetGainForChannel(num2 * num, 1);
					if (_shouldSnapPan)
					{
						_dynamicPanInfo.channelGains[0].Snap();
						_dynamicPanInfo.channelGains[1].Snap();
					}
					_shouldSnapPan = false;
				}
			}
		}

		private PanInfo _panInfo = new PanInfo();

		public GATPlayer Player;

		private GATRealTimeSample _sample;

		private double _initialiseTime;

		private int _id;

		private static int _nextId = 1;

		public GATData Data;

		public string PlayOrigin { get; private set; }

		public string Name { get; set; }

		public bool IsImportant { get; set; }

		public bool IsLooping
		{
			get
			{
				return _sample.Loop;
			}
			set
			{
				_sample.Loop = value;
				Log("IsLooping = {0}", value);
			}
		}

		public GATRealTimeSample GATRealTimeSample => _sample;

		public bool FadesIn
		{
			get
			{
				return _sample.FadesIn;
			}
			set
			{
				_sample.FadesIn = value;
				Log("FadesIn = {0}", value);
			}
		}

		public double FadeInDuration
		{
			get
			{
				return _sample.FadeInDuration;
			}
			set
			{
				_sample.FadeInDuration = value;
				Log("FadeInDuration = {0}", value);
			}
		}

		public float FixedPan
		{
			get
			{
				return _panInfo.FixedPan;
			}
			set
			{
				_panInfo.FixedPan = value;
			}
		}

		public float Pitch
		{
			get
			{
				return (float)_sample.Pitch;
			}
			set
			{
				_sample.Pitch = value;
				Log("Pitch = {0}", value);
			}
		}

		public float Duration => (float)GATRealTimeSample.Length / (float)AudioSettings.outputSampleRate;

		public IGATDynamicMixInfo DynamicMix
		{
			get
			{
				return _sample.DynamicMix;
			}
			set
			{
				_panInfo.DynamicMix = value;
				_sample.ScheduleDynamicMix(value);
				Log("DynamicMin = {0}", value);
			}
		}

		public bool CanRecycle
		{
			get
			{
				if (_sample.PlayingStatus == AGATWrappedSample.Status.ReadyToPlay)
				{
					if (!(_initialiseTime < 0.0))
					{
						return AudioSystem.Instance.DspTime - _initialiseTime > 1.0;
					}
					return true;
				}
				return false;
			}
		}

		public AudioSample()
		{
			_id = _nextId++;
			_sample = new GATRealTimeSample(null, _panInfo);
			_initialiseTime = -1.0;
		}

		public bool Initialise(IGATDataOwner sampleData)
		{
			Recycle();
			_sample.SetData(sampleData);
			Data = sampleData.AudioData;
			_initialiseTime = AudioSystem.Instance.DspTime;
			return true;
		}

		public void ElegantStop()
		{
			_sample.ElegantStop();
			Log("ElegantStop");
		}

		public void FadeOutAndStop(double fadeDuration)
		{
			_sample.FadeOutAndStop(fadeDuration);
			Log("FadeOutAndStop({0})", fadeDuration);
		}

		public void ScheduleFadeOut(double fadeStartDspTime, double fadeDuration)
		{
			_sample.ScheduleFadeOut(fadeStartDspTime, fadeDuration);
			Log("ScheduleFadeOut({0}, {1})", fadeStartDspTime, fadeDuration);
		}

		public void PlayPanned(float gain = 1f)
		{
			if (IsImportant || (Get.State & StateType.Minimal) != StateType.Minimal)
			{
				PlayOrigin = GetOrigin();
				_panInfo.OnPlay();
				_sample.PlayPanned(Player ?? GATManager.DefaultPlayer, gain);
				Log("PlayPanned({0})", gain);
			}
		}

		public void PlayScheduled(double dspTime, float gain = 1f)
		{
			if (IsImportant || (Get.State & StateType.Minimal) != StateType.Minimal)
			{
				PlayOrigin = GetOrigin();
				_panInfo.OnPlay();
				_sample.PlayScheduled(Player ?? GATManager.DefaultPlayer, dspTime, gain);
				Log("PlayScheduled({0}), Gain {1}", dspTime, gain);
			}
		}

		public void SetStartPosition(float samplePoint)
		{
			GATRealTimeSample.StartPosition = Maf.FloorMod((int)(samplePoint * (float)AudioSettings.outputSampleRate), GATRealTimeSample.Length);
			GATRealTimeSample.SetLoopCallback(ResetStartPosition);
		}

		private bool ResetStartPosition(GATRealTimeSample loopingSample)
		{
			loopingSample.StartPosition = 0;
			return true;
		}

		public override string ToString()
		{
			return $"[AudioSample: Id={_id}, PlayingStatus={_sample.PlayingStatus}, Name={Name}, Origin={PlayOrigin}, Position={_sample.Position} / {_sample.Length}, Important={IsImportant}]";
		}

		public void Recycle()
		{
			Log("Recycle()");
			_panInfo.Recycle();
			_sample.Reset();
			_sample.Loop = false;
			_sample.FadesIn = false;
			_initialiseTime = -1.0;
			IsImportant = false;
			PlayOrigin = null;
		}

		private void Log(string message, params object[] args)
		{
		}

		private string GetOrigin()
		{
			return "<unknown>";
		}
	}
}
