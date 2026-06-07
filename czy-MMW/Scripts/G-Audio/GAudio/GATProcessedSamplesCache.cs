using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAudio
{
	public class GATProcessedSamplesCache : IDisposable
	{
		private class ProcessedAudioChunk : RetainableObject, IGATProcessedSample, IRetainable, IGATDataOwner
		{
			private double _pitch;

			private double _nextPitch;

			public readonly GATEnvelope envelope;

			protected readonly GATProcessedSamplesCache _parentCache;

			protected GATData _audioData;

			protected bool _needsNewContainer = true;

			protected bool _needsDataUpdate = true;

			protected int _cachedLength;

			private double _lastLengthChange;

			private double _lastDataChange;

			public readonly GATData sourceSample;

			public double Pitch
			{
				get
				{
					return _pitch;
				}
				set
				{
					SetPitch(value);
				}
			}

			GATData IGATDataOwner.AudioData
			{
				get
				{
					UpdateAudioData();
					return _audioData;
				}
			}

			public IGATBufferedSampleOptions Play(AGATPanInfo panInfo, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null)
			{
				UpdateAudioData();
				return GATManager.DefaultPlayer.PlayData(_audioData, panInfo, gain, mixCallback);
			}

			public IGATBufferedSampleOptions Play(GATPlayer player, AGATPanInfo panInfo, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null)
			{
				UpdateAudioData();
				return player.PlayData(_audioData, panInfo, gain, mixCallback);
			}

			public IGATBufferedSampleOptions Play(int trackNb, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null)
			{
				UpdateAudioData();
				return GATManager.DefaultPlayer.PlayData(_audioData, trackNb, gain, mixCallback);
			}

			public IGATBufferedSampleOptions Play(GATPlayer player, int trackNb, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null)
			{
				UpdateAudioData();
				return player.PlayData(_audioData, trackNb, gain, mixCallback);
			}

			public IGATBufferedSampleOptions PlayScheduled(double dspTime, AGATPanInfo panInfo, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null)
			{
				UpdateAudioData();
				return GATManager.DefaultPlayer.PlayDataScheduled(_audioData, dspTime, panInfo, gain, mixCallback);
			}

			public IGATBufferedSampleOptions PlayScheduled(GATPlayer player, double dspTime, AGATPanInfo panInfo, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null)
			{
				UpdateAudioData();
				return player.PlayDataScheduled(_audioData, dspTime, panInfo, gain, mixCallback);
			}

			public IGATBufferedSampleOptions PlayScheduled(double dspTime, int trackNb, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null)
			{
				UpdateAudioData();
				return GATManager.DefaultPlayer.PlayDataScheduled(_audioData, dspTime, trackNb, gain, mixCallback);
			}

			public IGATBufferedSampleOptions PlayScheduled(GATPlayer player, double dspTime, int trackNb, float gain = 1f, GATPlayer.OnShouldMixSample mixCallback = null)
			{
				UpdateAudioData();
				return player.PlayDataScheduled(_audioData, dspTime, trackNb, gain, mixCallback);
			}

			public void UpdateAudioData()
			{
				if (_lastDataChange < envelope.LastChangeTime)
				{
					_needsDataUpdate = true;
					_lastDataChange = AudioSettings.dspTime;
					if (_lastLengthChange < envelope.LastLengthChangeTime)
					{
						_needsNewContainer = true;
						_lastLengthChange = _lastDataChange;
						_cachedLength = envelope.Length;
					}
				}
				if (_needsDataUpdate)
				{
					if (!_needsNewContainer)
					{
						CheckNeedsNewContainer();
					}
					if (_needsNewContainer)
					{
						UpdateContainer();
					}
					else if (!_needsDataUpdate)
					{
						return;
					}
					FillAndProcessData();
				}
			}

			public ProcessedAudioChunk(GATData sourcesample, GATEnvelope ienvelope, GATProcessedSamplesCache parentCache, double pitch = 1.0)
			{
				sourceSample = sourcesample;
				envelope = ienvelope;
				_parentCache = parentCache;
				if (envelope == GATEnvelope.nullEnvelope)
				{
					_cachedLength = sourcesample.Count;
				}
				else
				{
					_cachedLength = envelope.Length;
				}
				SetPitch(pitch);
			}

			private void SetPitch(double newPitch)
			{
				if (newPitch != _nextPitch)
				{
					_nextPitch = newPitch;
					_needsDataUpdate = true;
					if (envelope == GATEnvelope.nullEnvelope)
					{
						_cachedLength = GATMaths.ResampledLength(sourceSample.Count, _nextPitch);
						_needsNewContainer = true;
					}
				}
			}

			public void CleanUp()
			{
				if (_audioData != null)
				{
					_audioData.Release();
					_audioData = null;
				}
			}

			protected virtual void FillAndProcessData()
			{
				if (_nextPitch == 1.0)
				{
					FillWithSampleData(envelope.Offset, _cachedLength);
				}
				else
				{
					FillWithResampledData(envelope.Offset, _cachedLength, _nextPitch);
				}
				_pitch = _nextPitch;
				envelope.ProcessSample(_audioData);
				_needsDataUpdate = false;
			}

			protected override void Discard()
			{
				CleanUp();
				_parentCache.RemoveChunkFromCache(this);
				_retainCount = 0;
			}

			private void CheckNeedsNewContainer()
			{
				if (_needsDataUpdate && _audioData.RetainCount > 1)
				{
					_needsNewContainer = true;
				}
			}

			private void UpdateContainer()
			{
				if (_audioData != null)
				{
					_audioData.Release();
				}
				_audioData = GATManager.GetDataContainer(_cachedLength);
				_audioData.Retain();
			}

			private void FillWithSampleData(int fromIndex, int length)
			{
				int num = ((fromIndex + length > sourceSample.Count) ? (sourceSample.Count - fromIndex) : length);
				if (num >= 0)
				{
					sourceSample.CopyTo(_audioData, 0, fromIndex, num);
				}
			}

			private void FillWithResampledData(int fromIndex, int targetLength, double pitch)
			{
				int num = GATMaths.ClampedResampledLength(sourceSample.Count - fromIndex, targetLength, pitch);
				if (num >= 0)
				{
					sourceSample.ResampleCopyTo(fromIndex, _audioData, num, pitch);
					if (num < targetLength)
					{
						_audioData.Clear(num, _audioData.Count - num);
					}
				}
			}
		}

		private Dictionary<GATData, List<ProcessedAudioChunk>> _processedChunksInMemory;

		private bool _disposed;

		public GATProcessedSamplesCache(List<GATData> sourceSamples, int extraCapacity = 0)
		{
			_processedChunksInMemory = new Dictionary<GATData, List<ProcessedAudioChunk>>(sourceSamples.Count + extraCapacity);
			for (int i = 0; i < sourceSamples.Count; i++)
			{
				_processedChunksInMemory.Add(sourceSamples[i], new List<ProcessedAudioChunk>());
			}
		}

		public GATProcessedSamplesCache(int capacity)
		{
			_processedChunksInMemory = new Dictionary<GATData, List<ProcessedAudioChunk>>(capacity);
		}

		public void AddSample(GATData sample)
		{
			_processedChunksInMemory.Add(sample, new List<ProcessedAudioChunk>());
		}

		public IGATProcessedSample GetProcessedSample(GATData sourceSample, double pitch, GATEnvelope envelope)
		{
			if (envelope == null)
			{
				envelope = GATEnvelope.nullEnvelope;
			}
			List<ProcessedAudioChunk> list = _processedChunksInMemory[sourceSample];
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].envelope == envelope && list[i].Pitch == pitch)
				{
					return list[i];
				}
			}
			ProcessedAudioChunk processedAudioChunk = new ProcessedAudioChunk(sourceSample, envelope, this, pitch);
			list.Add(processedAudioChunk);
			return processedAudioChunk;
		}

		public void RemoveSample(GATData sample)
		{
			List<ProcessedAudioChunk> list = _processedChunksInMemory[sample];
			for (int i = 0; i < list.Count; i++)
			{
				list[i].CleanUp();
			}
			_processedChunksInMemory.Remove(sample);
		}

		public void FlushCacheForEnvelope(GATEnvelope envelope)
		{
			List<ProcessedAudioChunk> list = new List<ProcessedAudioChunk>();
			if (envelope == null)
			{
				envelope = GATEnvelope.nullEnvelope;
			}
			foreach (KeyValuePair<GATData, List<ProcessedAudioChunk>> item in _processedChunksInMemory)
			{
				List<ProcessedAudioChunk> value = item.Value;
				if (value.Count == 0)
				{
					continue;
				}
				for (int i = 0; i < value.Count; i++)
				{
					ProcessedAudioChunk processedAudioChunk = value[i];
					if (processedAudioChunk.envelope == envelope)
					{
						processedAudioChunk.CleanUp();
						list.Add(processedAudioChunk);
					}
				}
				if (list.Count > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						value.Remove(list[i]);
					}
					list.Clear();
				}
			}
		}

		private void RemoveChunkFromCache(ProcessedAudioChunk chunk)
		{
			if (_processedChunksInMemory.Count != 0)
			{
				_processedChunksInMemory[chunk.sourceSample].Remove(chunk);
			}
		}

		public void Dispose()
		{
			Dispose(explicitly: true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool explicitly)
		{
			if (!_disposed)
			{
				if (explicitly)
				{
					FreeAll();
				}
				_disposed = true;
			}
		}

		~GATProcessedSamplesCache()
		{
			Dispose(explicitly: false);
		}

		private void FreeAll()
		{
			foreach (KeyValuePair<GATData, List<ProcessedAudioChunk>> item in _processedChunksInMemory)
			{
				List<ProcessedAudioChunk> value = item.Value;
				if (value.Count != 0)
				{
					for (int i = 0; i < value.Count; i++)
					{
						value[i].CleanUp();
					}
				}
			}
			_processedChunksInMemory.Clear();
		}
	}
}
