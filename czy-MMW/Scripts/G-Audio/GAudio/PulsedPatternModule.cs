using System.Collections.Generic;
using UnityEngine;

namespace GAudio
{
	[ExecuteInEditMode]
	public class PulsedPatternModule : AGATPulsedPattern
	{
		[SerializeField]
		protected EnvelopeModule _envelopeModule;

		[SerializeField]
		protected List<PatternSample> _samples = new List<PatternSample>();

		public EnvelopeModule Envelope
		{
			get
			{
				return _envelopeModule;
			}
			set
			{
				if (!(_envelopeModule == value))
				{
					for (int i = 0; i < _samples.Count; i++)
					{
						_samples[i].ProcessedSample = null;
					}
					_envelopeModule = value;
				}
			}
		}

		public PatternSample[] Samples
		{
			get
			{
				PatternSample[] array = new PatternSample[_samples.Count];
				_samples.CopyTo(array, 0);
				return array;
			}
		}

		public void AddSample(string sampleName)
		{
			_samples.Add(new PatternSample(sampleName));
			_sampleCount++;
			if (_sampleCount == 1)
			{
				SubscribeToPulseIfNeeded();
			}
		}

		public void InsertSample(PatternSample newSample, int index)
		{
			if (index > _samples.Count)
			{
				index = _samples.Count;
			}
			_samples.Insert(index, newSample);
			_sampleCount++;
			if (_sampleCount == 1)
			{
				SubscribeToPulseIfNeeded();
			}
		}

		public void RemoveSampleAt(int index)
		{
			_samples[index].ProcessedSample = null;
			_samples.RemoveAt(index);
			_sampleCount--;
			if (_sampleCount == 0)
			{
				UnsubscribeToPulse();
			}
		}

		public override void PlaySample(int index, double dspTime)
		{
			if (!_sampleBank.IsLoaded)
			{
				return;
			}
			PatternSample patternSample = _samples[index];
			if (onPatternWillPlay != null)
			{
				onPatternWillPlay(patternSample, index, dspTime);
			}
			if (_envelopeModule != null)
			{
				if (patternSample.ProcessedSample == null)
				{
					patternSample.ProcessedSample = _sampleBank.GetProcessedSample(patternSample.SampleName, _envelopeModule.Envelope, patternSample.Pitch);
				}
				patternSample.ProcessedSample.PlayScheduled(_player, dspTime, _trackNb, patternSample.Gain);
			}
			else
			{
				GATData audioData = _sampleBank.GetAudioData(patternSample.SampleName);
				_player.PlayDataScheduled(audioData, dspTime, _trackNb, patternSample.Gain);
			}
		}

		protected override int UpdatedSampleCount()
		{
			return _samples.Count;
		}

		protected void OnDestroy()
		{
			for (int i = 0; i < _samples.Count; i++)
			{
				_samples[i].ProcessedSample = null;
			}
		}

		protected override bool CanSubscribeToPulse()
		{
			if (!base.CanSubscribeToPulse() || _samples.Count == 0)
			{
				return false;
			}
			return true;
		}
	}
}
