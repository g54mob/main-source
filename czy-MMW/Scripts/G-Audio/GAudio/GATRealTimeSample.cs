using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAudio
{
	public class GATRealTimeSample : AGATWrappedSample, IDisposable
	{
		public delegate bool SampleWillLoopHandler(GATRealTimeSample sample);

		public class FadeInfo
		{
			public readonly float FromGain;

			public readonly float ToGain;

			public readonly double StartDspTime;

			public readonly double Duration;

			public FadeInfo(float toGain, double duration)
			{
				FromGain = -1f;
				ToGain = toGain;
				Duration = duration;
				StartDspTime = 0.0;
			}

			public FadeInfo(float fromGain, float toGain, double duration, double startDspTime = 0.0)
			{
				FromGain = fromGain;
				ToGain = toGain;
				Duration = duration;
				StartDspTime = startDspTime;
			}
		}

		private class Fader
		{
			private float _fromGain;

			private float _toGain;

			private float _lastGain;

			private double _startDspTime;

			private double _duration;

			private double _fadeEndDspTime;

			public float ToGain => _toGain;

			public float LastGain => _lastGain;

			public Fader()
			{
				_lastGain = 1f;
			}

			public Fader(FadeInfo info)
			{
				_lastGain = 1f;
				SetFadeInfo(info);
			}

			public void SetFadeInfo(FadeInfo info)
			{
				if (info.FromGain < 0f)
				{
					_fromGain = _lastGain;
				}
				else
				{
					_fromGain = info.FromGain;
				}
				_toGain = info.ToGain;
				_duration = info.Duration;
				_startDspTime = info.StartDspTime;
				_fadeEndDspTime = _startDspTime + _duration;
			}

			public int DoFade(GATData target, double dspTime, int lengthInSamples, bool readOnly = false)
			{
				int num = 0;
				if (_startDspTime == 0.0)
				{
					_startDspTime = dspTime;
					_fadeEndDspTime = dspTime + _duration;
				}
				else if (dspTime < _startDspTime)
				{
					num = (int)((dspTime - _startDspTime) * (double)GATInfo.OutputSampleRate);
				}
				double num2 = ((double)lengthInSamples - (double)num) / (double)GATInfo.OutputSampleRate;
				if (num2 + dspTime > _fadeEndDspTime)
				{
					num2 = _fadeEndDspTime - dspTime;
					if (num2 <= 0.0)
					{
						return 0;
					}
					lengthInSamples = (int)(num2 * (double)GATInfo.OutputSampleRate);
				}
				float t = (float)((dspTime - _startDspTime) / _duration);
				float fromGain = Mathf.Lerp(_fromGain, _toGain, t);
				dspTime += num2;
				t = (float)((dspTime - _startDspTime) / _duration);
				float num3 = Mathf.Lerp(_fromGain, _toGain, t);
				if (!readOnly)
				{
					target.Fade(fromGain, num3, lengthInSamples - num, num);
				}
				_lastGain = num3;
				return lengthInSamples;
			}
		}

		protected SampleWillLoopHandler onSampleWillLoop;

		private IGATDynamicMixInfo _scheduledDynamicMix;

		protected double _pitch = 1.0;

		protected IGATDynamicMixInfo _dynamicMix;

		protected GATDataSource _dataSource;

		protected bool _loop;

		protected List<AGATMonoFilter> _filters = new List<AGATMonoFilter>();

		protected bool _disposed;

		protected bool _shouldFade;

		protected double _fadeInDuration = 1.0;

		protected FadeInfo _scheduledFade;

		private bool _shouldAbort;

		private Fader _fader;

		public double Pitch
		{
			get
			{
				return _pitch;
			}
			set
			{
				if (Math.Abs(value) < 0.01)
				{
					value = 0.01 * (double)Math.Sign(value);
				}
				_pitch = value;
			}
		}

		public IGATDynamicMixInfo DynamicMix
		{
			get
			{
				return _dynamicMix;
			}
			set
			{
				_dynamicMix = value;
			}
		}

		public bool Loop
		{
			get
			{
				return _loop;
			}
			set
			{
				_loop = value;
			}
		}

		public int Length => _dataSource.Length;

		public int Position => _dataSource.NextIndex;

		public int StartPosition { get; set; }

		public bool FadesIn { get; set; }

		public double FadeInDuration
		{
			get
			{
				return _fadeInDuration;
			}
			set
			{
				_fadeInDuration = value;
			}
		}

		public void SetLoopCallback(SampleWillLoopHandler callback)
		{
			onSampleWillLoop = callback;
		}

		public void ScheduleDynamicMix(IGATDynamicMixInfo dynamicMix)
		{
			_scheduledDynamicMix = dynamicMix;
		}

		public GATRealTimeSample(IGATDataOwner dataOwner, AGATPanInfo ipaninfo = null)
			: base(dataOwner, ipaninfo)
		{
			_dataSource = new GATDataSource(dataOwner?.AudioData);
			_fader = new Fader();
		}

		[Obsolete("Obsolete ctor: canPitchShift parameter is now obsolete. Please use GATLoopedSample if you need to monitor and smoothly stop playback without pitch shift.")]
		public GATRealTimeSample(IGATDataOwner dataOwner, bool canPitchShift, AGATPanInfo ipaninfo = null)
			: base(dataOwner, ipaninfo)
		{
			Debug.LogWarning("Obsolete ctor: canPitchShift parameter is now obsolete. Please use GATLoopedSample if you need to monitor and smoothly stop playback without pitch shift.");
			_dataSource = new GATDataSource(dataOwner.AudioData);
			_fader = new Fader();
		}

		public void FadeOutAndStop(double fadeDuration)
		{
			if (base.PlayingStatus == Status.Playing)
			{
				if (_shouldFade)
				{
					_fader.SetFadeInfo(new FadeInfo(0f, fadeDuration));
				}
				else
				{
					_fader.SetFadeInfo(new FadeInfo(1f, 0f, fadeDuration));
				}
				_shouldFade = true;
			}
			else if (base.PlayingStatus == Status.Scheduled)
			{
				_shouldAbort = true;
			}
		}

		public void ScheduleFadeOut(double fadeStartDspTime, double fadeDuration)
		{
			if (fadeStartDspTime < AudioSettings.dspTime)
			{
				FadeOutAndStop(fadeDuration);
			}
			else
			{
				_scheduledFade = new FadeInfo(1f, 0f, fadeDuration, fadeStartDspTime);
			}
		}

		public AGATMonoFilter AddFilter<T>() where T : AGATMonoFilter
		{
			AGATMonoFilter aGATMonoFilter = ScriptableObject.CreateInstance<T>();
			_filters.Add(aGATMonoFilter);
			return aGATMonoFilter;
		}

		public AGATMonoFilter AddFilter<T>(int index) where T : AGATMonoFilter
		{
			if (index > _filters.Count)
			{
				index = _filters.Count;
			}
			AGATMonoFilter aGATMonoFilter = ScriptableObject.CreateInstance<T>();
			_filters.Insert(index, aGATMonoFilter);
			return aGATMonoFilter;
		}

		public AGATMonoFilter GetFilter(int index)
		{
			if (index >= _filters.Count)
			{
				return null;
			}
			return _filters[index];
		}

		public void ResetFilters()
		{
			for (int i = 0; i < _filters.Count; i++)
			{
				_filters[i].ResetFilter();
			}
		}

		public void RemoveFilter(AGATMonoFilter filter)
		{
			_filters.Remove(filter);
		}

		public void Seek(int samplePos)
		{
			_dataSource.Seek(samplePos);
			if (base.PlayingStatus == Status.ReadyToPlay)
			{
				StartPosition = samplePos;
			}
		}

		public void SetData(IGATDataOwner dataOwner)
		{
			if (_dataOwner != dataOwner && base.PlayingStatus == Status.ReadyToPlay)
			{
				_dataOwner = dataOwner;
				_dataSource.SetData(_dataOwner.AudioData);
			}
		}

		public void Reset()
		{
			_dynamicMix = null;
			_shouldFade = false;
			_shouldAbort = false;
			_fadeInDuration = 1.0;
		}

		protected override bool PlayerWillMixSample(IGATBufferedSample sample, int length, float[] audioBuffer)
		{
			if (_scheduledDynamicMix != null)
			{
				_dynamicMix = _scheduledDynamicMix;
				_scheduledDynamicMix = null;
			}
			if (_shouldAbort)
			{
				_shouldAbort = false;
				sample.IsLastChunk = true;
				base.PlayingStatus = Status.ReadyToPlay;
				return false;
			}
			bool flag = sample.PlayingGain == 0f || !sample.PanInfo.IsAudible;
			double num = 0.0;
			if (_dynamicMix != null)
			{
				if (_dynamicMix.HasStaticPitch)
				{
					_pitch = _dynamicMix.StaticPitch;
				}
				else
				{
					num = _dynamicMix.Pitch;
				}
			}
			bool flag2 = _dynamicMix != null && !_dynamicMix.HasStaticPitch && num != 0.0;
			double num2 = AudioSettings.dspTime;
			if (sample.IsFirstChunk)
			{
				base.PlayingStatus = Status.Playing;
				sample.NextIndex = 1;
				if (flag2)
				{
					_pitch = num;
				}
				if (_pitch < 0.0)
				{
					if (StartPosition == 0)
					{
						StartPosition = _dataOwner.AudioData.Count - 2;
					}
				}
				else if (StartPosition == _dataOwner.AudioData.Count - 2)
				{
					StartPosition = 0;
				}
				_dataSource.Seek(StartPosition);
				if (FadesIn && _fadeInDuration > 0.0)
				{
					_fader.SetFadeInfo(new FadeInfo(0f, 1f, _fadeInDuration));
					_shouldFade = true;
				}
				if (GATPlayer.streamWriter != null)
				{
					GATPlayer.streamWriter.WriteLine($"\t\t... first sample. _pitch = {_pitch}, StartPosition = {StartPosition}, FadesIn = {FadesIn}, _fadeInDuration = {_fadeInDuration}");
				}
			}
			else if (_scheduledFade != null && num2 + GATInfo.AudioBufferDuration > _scheduledFade.StartDspTime)
			{
				if (_shouldFade && _scheduledFade.FromGain >= 0f)
				{
					_scheduledFade = new FadeInfo(_fader.LastGain, _scheduledFade.ToGain, _scheduledFade.Duration);
					if (GATPlayer.streamWriter != null)
					{
						GATPlayer.streamWriter.WriteLine("\t\t... adjusting fade.");
					}
				}
				if (GATPlayer.streamWriter != null)
				{
					GATPlayer.streamWriter.WriteLine("\t\t... starting scheduled fade. {0} -> {1} over {2} seconds.", _scheduledFade.FromGain, _scheduledFade.ToGain, _scheduledFade.Duration);
				}
				_fader.SetFadeInfo(_scheduledFade);
				_shouldFade = true;
				_scheduledFade = null;
			}
			bool forceLastChunk = false;
			int nextIndex = _dataSource.NextIndex;
			int num3;
			if (!flag2)
			{
				if (_dynamicMix != null)
				{
					_dynamicMix.Update((double)length / (double)GATInfo.OutputSampleRate);
				}
				if (_pitch == 1.0)
				{
					num3 = _dataSource.GetData(sample.ProcessingBuffer, length, 0, reverse: false, flag);
					if (GATPlayer.streamWriter != null)
					{
						GATPlayer.streamWriter.WriteLine("\t\t... no pitch shifting. From {0} / {1}, requested {2} samples and fetched {3}.", nextIndex, _dataSource.Length, length, num3);
					}
				}
				else if (_pitch == -1.0)
				{
					num3 = _dataSource.GetData(sample.ProcessingBuffer, length, 0, reverse: true, flag);
					if (GATPlayer.streamWriter != null)
					{
						GATPlayer.streamWriter.WriteLine("\t\t... reverse pitch. From {0} / {1}, requested {2} samples and fetched {3}.", nextIndex, _dataSource.Length, length, num3);
					}
				}
				else
				{
					num3 = _dataSource.GetResampledData(sample.ProcessingBuffer, length, 0, _loop, _pitch, ref forceLastChunk, flag);
					if (GATPlayer.streamWriter != null)
					{
						GATPlayer.streamWriter.WriteLine("\t\t... pitch shifting to {0}. From {1} / {2}, requested {3} samples and fetched {4}, last chunk forced? {5}.", _pitch, nextIndex, _dataSource.Length, length, num3, forceLastChunk);
					}
				}
			}
			else
			{
				num3 = ResampleDataWithDynamicPitch(sample, length, 0, ref forceLastChunk, flag);
			}
			if (base.StopsEarly && num2 >= _endDspTime)
			{
				_shouldStop = true;
			}
			if (num3 < length || forceLastChunk)
			{
				if (_loop)
				{
					if (onSampleWillLoop != null && !onSampleWillLoop(this))
					{
						if (GATPlayer.streamWriter != null)
						{
							GATPlayer.streamWriter.WriteLine("\t\t... not looping, last chunk.");
						}
						sample.IsLastChunk = true;
					}
					else
					{
						if (!_dataSource.SeekToLoopPoint())
						{
							int samplePos = ((!(_pitch < 0.0)) ? ((StartPosition < _dataOwner.AudioData.Count - 2) ? StartPosition : 0) : ((StartPosition == 0) ? (_dataOwner.AudioData.Count - 2) : StartPosition));
							_dataSource.Seek(samplePos);
						}
						if (num3 < length)
						{
							if (!flag2)
							{
								_dataSource.GetResampledData(sample.ProcessingBuffer, length - num3, num3, _loop, _pitch, ref forceLastChunk, flag);
							}
							else
							{
								ResampleDataWithDynamicPitch(sample, length - num3, num3, ref forceLastChunk, flag);
							}
							if (GATPlayer.streamWriter != null)
							{
								GATPlayer.streamWriter.WriteLine("\t\t... looping, seeking back and fetching {0} more samples.", length - num3);
							}
						}
						num3 = length;
					}
				}
				else
				{
					sample.IsLastChunk = true;
					if (GATPlayer.streamWriter != null)
					{
						GATPlayer.streamWriter.WriteLine("\t\t... last chunk.");
					}
				}
			}
			else if (_shouldStop)
			{
				if (GATPlayer.streamWriter != null)
				{
					GATPlayer.streamWriter.WriteLine("\t\t... should stop.");
				}
				if (!flag)
				{
					sample.ProcessingBuffer.FadeOut(0, length);
				}
				sample.IsLastChunk = true;
				_shouldStop = false;
			}
			if (_shouldFade)
			{
				if (sample.IsFirstChunk)
				{
					num2 += (double)sample.OffsetInBuffer / (double)GATInfo.OutputSampleRate;
				}
				int num4 = _fader.DoFade(sample.ProcessingBuffer, num2, num3, flag);
				if (GATPlayer.streamWriter != null)
				{
					GATPlayer.streamWriter.WriteLine("\t\t... fading, {0} samples faded from {1}.", num4, num3);
				}
				if (num4 < num3)
				{
					if (_fader.ToGain == 0f)
					{
						if (GATPlayer.streamWriter != null)
						{
							GATPlayer.streamWriter.WriteLine("\t\t... faded to zero, last chunk.");
						}
						sample.IsLastChunk = true;
						num3 = num4;
					}
					_shouldFade = false;
				}
			}
			if (!flag)
			{
				for (int i = 0; i < _filters.Count; i++)
				{
					_filters[i].ProcessChunk(sample.ProcessingBuffer.ParentArray, sample.ProcessingBuffer.MemOffset, num3, emptyData: false);
				}
				if ((object)sample.Track != null)
				{
					sample.Track.MixFrom(sample.ProcessingBuffer, 0, sample.OffsetInBuffer, num3, sample.PlayingGain);
				}
				else
				{
					sample.PanInfo.PanMixProcessingBuffer(sample, num3, audioBuffer, sample.PlayingGain);
				}
			}
			if (sample.IsLastChunk)
			{
				base.PlayingStatus = Status.ReadyToPlay;
			}
			return false;
		}

		private int ResampleDataWithDynamicPitch(IGATBufferedSample sample, int length, int offset, ref bool forceLastChunk, bool readOnly = false)
		{
			int num = GATInfo.OutputSampleRate / 200;
			int num2 = 0;
			forceLastChunk = false;
			while (!forceLastChunk && num2 < length)
			{
				int num3 = Mathf.Min(length - num2, num);
				int resampledData = _dataSource.GetResampledData(sample.ProcessingBuffer, num3, offset + num2, _loop, _pitch, ref forceLastChunk, readOnly);
				num2 += resampledData;
				if (_dynamicMix != null)
				{
					_dynamicMix.Update((double)resampledData / (double)GATInfo.OutputSampleRate);
					_pitch = _dynamicMix.Pitch;
				}
				else
				{
					Debug.LogWarning("Sample was called with ResampleDataWithDynamicPitch but has no dynamic mixer. Pitch is not being updated.");
				}
				if (num3 < num)
				{
					break;
				}
			}
			return num2;
		}

		public void Dispose()
		{
			Dispose(explicitly: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool explicitly)
		{
			if (!_disposed)
			{
				if (explicitly)
				{
					_dataSource.Dispose();
				}
				for (int i = 0; i < _filters.Count; i++)
				{
					UnityEngine.Object.Destroy(_filters[i]);
				}
				_disposed = true;
			}
		}

		~GATRealTimeSample()
		{
			Dispose(explicitly: false);
		}
	}
}
