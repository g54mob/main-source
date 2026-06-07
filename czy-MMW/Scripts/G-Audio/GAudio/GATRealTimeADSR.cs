using UnityEngine;

namespace GAudio
{
	public class GATRealTimeADSR
	{
		private enum State
		{
			Attack = 0,
			Decay = 1,
			Sustain = 2,
			SustainCrossfade = 3,
			Release = 4
		}

		private IGATDataOwner _dataOwner;

		private GATData _data;

		private State _currentState;

		private int _attackStartIndex;

		private int _decayStartIndex;

		private int _loopStartIndex;

		private int _loopEndIndex;

		private int _releaseIndex;

		private int _endIndex;

		private int _nextIndex;

		private int _loopCrossfadeIndex;

		private int _attackLength;

		private int _loopLength;

		private int _releaseLength;

		private int _loopCrossfadeLength;

		private bool _keepLooping;

		private bool _noLoop;

		public bool IsPlaying { get; private set; }

		public GATRealTimeADSR(IGATDataOwner dataOwner)
		{
			_dataOwner = dataOwner;
			_currentState = State.Attack;
		}

		public bool TrySetEnvelope(int offset, int attack, int decay, int sustain, int release, int loopCrossfade = -1)
		{
			if (IsPlaying)
			{
				Debug.LogWarning("Envelope parameters cannot be updated while the sample is playing.");
				return false;
			}
			int num = ((loopCrossfade == -1) ? sustain : loopCrossfade);
			if (offset + attack + decay < num)
			{
				Debug.LogError("loopCrossfade must be smaller than offset + attack + decay ");
				return false;
			}
			_attackStartIndex = offset;
			_decayStartIndex = _attackStartIndex + attack;
			if (sustain > 0)
			{
				_loopStartIndex = _decayStartIndex + decay;
				_loopEndIndex = _loopStartIndex + sustain;
				_loopCrossfadeLength = loopCrossfade;
			}
			else
			{
				_noLoop = true;
				_loopStartIndex = _decayStartIndex + decay;
				_loopEndIndex = _loopStartIndex;
				_releaseIndex = _loopStartIndex;
				_endIndex = _loopStartIndex + release;
			}
			_attackLength = attack;
			_releaseLength = release;
			return true;
		}

		public void PlayThroughTrack(int trackNb, float gain = 1f)
		{
			IsPlaying = true;
			_keepLooping = true;
			_nextIndex = _attackStartIndex;
			_currentState = State.Attack;
			_data = _dataOwner.AudioData;
			if (!_noLoop)
			{
				UpdateZeroCrossings();
			}
			GATManager.DefaultPlayer.PlayData(_data, trackNb, gain, PlayerWillMixSample);
		}

		public void PlayThroughTrack(GATPlayer player, int trackNb, float gain = 1f)
		{
			IsPlaying = true;
			_keepLooping = true;
			_nextIndex = _attackStartIndex;
			_currentState = State.Attack;
			_data = _dataOwner.AudioData;
			if (!_noLoop)
			{
				UpdateZeroCrossings();
			}
			player.PlayData(_data, trackNb, gain, PlayerWillMixSample);
		}

		public void Release()
		{
			_keepLooping = false;
		}

		private void UpdateZeroCrossings()
		{
			_loopStartIndex = _data.NextZeroCrossing(_loopStartIndex, out var positive);
			bool positive2 = positive;
			while (positive2 != positive)
			{
				_loopEndIndex = _data.NextZeroCrossing(_loopEndIndex, out positive2);
			}
			_loopLength = _loopEndIndex - _loopStartIndex;
			if (_loopCrossfadeLength == -1)
			{
				_loopCrossfadeLength = _loopLength;
			}
			_loopCrossfadeIndex = _loopEndIndex - _loopCrossfadeLength;
		}

		private bool PlayerWillMixSample(IGATBufferedSample sample, int length, float[] audioBuffer)
		{
			int num = 0;
			int length2 = length;
			switch (_currentState)
			{
			case State.Attack:
				if (_nextIndex >= _decayStartIndex)
				{
					_currentState = State.Decay;
				}
				else
				{
					int num2 = ((!sample.IsFirstChunk || length <= _attackLength) ? length : _attackLength);
					float fromGain = (float)(_nextIndex - _attackStartIndex) / (float)_attackLength;
					float toGain;
					if (_nextIndex + num2 < _decayStartIndex)
					{
						toGain = (float)(_nextIndex + num2 - _attackStartIndex) / (float)_attackLength;
						_data.CopySmoothedGainTo(_nextIndex, sample.ProcessingBuffer, 0, num2, fromGain, toGain);
						_nextIndex += num2;
						break;
					}
					num2 = _decayStartIndex - _nextIndex;
					toGain = 1f;
					_data.CopySmoothedGainTo(_nextIndex, sample.ProcessingBuffer, 0, num2, fromGain, toGain);
					_nextIndex = _decayStartIndex;
					num = num2;
					_currentState = State.Decay;
				}
				goto case State.Decay;
			case State.Decay:
			{
				int num2 = GATInfo.AudioBufferSizePerChannel - num;
				if (_nextIndex + num2 >= _loopStartIndex)
				{
					num2 = _loopStartIndex - _nextIndex;
					_data.CopyTo(sample.ProcessingBuffer, num, _nextIndex, num2);
					_nextIndex = _loopStartIndex;
					num += num2;
					if (_noLoop)
					{
						_currentState = State.Release;
						goto case State.Release;
					}
					if (_loopCrossfadeLength == _loopLength)
					{
						_currentState = State.SustainCrossfade;
						goto case State.SustainCrossfade;
					}
					_currentState = State.Sustain;
					goto case State.Sustain;
				}
				_data.CopyTo(sample.ProcessingBuffer, num, _nextIndex, num2);
				_nextIndex += num2;
				break;
			}
			case State.Sustain:
			{
				int num2 = GATInfo.AudioBufferSizePerChannel - num;
				if (_nextIndex + num2 >= _loopCrossfadeIndex)
				{
					num2 = _loopCrossfadeIndex - _nextIndex;
					_data.CopyTo(sample.ProcessingBuffer, num, _nextIndex, num2);
					num += num2;
					_nextIndex += num2;
					if (_keepLooping)
					{
						_currentState = State.SustainCrossfade;
						goto case State.SustainCrossfade;
					}
					_releaseIndex = _nextIndex;
					_endIndex = _nextIndex + _releaseLength;
					_currentState = State.Release;
					goto case State.Release;
				}
				_data.CopyTo(sample.ProcessingBuffer, num, _nextIndex, num2);
				_nextIndex += num2;
				break;
			}
			case State.SustainCrossfade:
			{
				int num2 = GATInfo.AudioBufferSizePerChannel - num;
				int num3 = _nextIndex - _loopCrossfadeIndex;
				float fromGain = 1f - (float)num3 / (float)_loopCrossfadeLength;
				if (_nextIndex + num2 > _loopEndIndex)
				{
					num2 = _loopEndIndex - _nextIndex;
					_data.CopySmoothedGainTo(_nextIndex, sample.ProcessingBuffer, num, num2, fromGain, 0f);
					_data.MixSmoothedGainTo(_loopStartIndex - (_loopCrossfadeLength - num3), sample.ProcessingBuffer, num, num2, 1f - fromGain, 1f);
					num += num2;
					_nextIndex = _loopStartIndex;
					if (_keepLooping)
					{
						_currentState = State.Sustain;
						goto case State.Sustain;
					}
					_releaseIndex = _loopStartIndex;
					_endIndex = _loopStartIndex + _releaseLength;
					_currentState = State.Release;
					goto case State.Release;
				}
				float toGain = 1f - (float)(num3 + num2) / (float)_loopCrossfadeLength;
				_data.CopySmoothedGainTo(_nextIndex, sample.ProcessingBuffer, num, num2, fromGain, toGain);
				_data.MixSmoothedGainTo(_loopStartIndex - (_loopCrossfadeLength - num3), sample.ProcessingBuffer, num, num2, 1f - fromGain, 1f - toGain);
				_nextIndex += num2;
				break;
			}
			case State.Release:
			{
				int num2 = GATInfo.AudioBufferSizePerChannel - num;
				float fromGain = 1f - (float)(_nextIndex - _releaseIndex) / (float)_releaseLength;
				if (_nextIndex + num2 >= _endIndex)
				{
					float toGain = 0f;
					sample.IsLastChunk = true;
					IsPlaying = false;
					num2 = _endIndex - _nextIndex;
					length2 = num2 + num;
					_data.CopySmoothedGainTo(_nextIndex, sample.ProcessingBuffer, num, num2, fromGain, toGain);
				}
				else
				{
					float toGain = 1f - (float)(_nextIndex + num2 - _releaseIndex) / (float)_releaseLength;
					_data.CopySmoothedGainTo(_nextIndex, sample.ProcessingBuffer, num, num2, fromGain, toGain);
					_nextIndex += num2;
				}
				break;
			}
			}
			sample.NextIndex = _nextIndex;
			sample.Track.MixFrom(sample.ProcessingBuffer, 0, sample.OffsetInBuffer, length2);
			return false;
		}
	}
}
