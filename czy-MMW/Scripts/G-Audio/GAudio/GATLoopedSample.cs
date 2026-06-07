using UnityEngine;

namespace GAudio
{
	public class GATLoopedSample : AGATWrappedSample
	{
		public bool Loop { get; set; }

		public int NumberOfLoops { get; set; }

		public int CurrentLoop { get; protected set; }

		public GATLoopedSample(IGATDataOwner dataOwner, int numberOfLoops = -1, AGATPanInfo panInfo = null)
			: base(dataOwner, panInfo)
		{
			if (numberOfLoops != 0)
			{
				Loop = true;
			}
			NumberOfLoops = numberOfLoops;
		}

		protected override bool PlayerWillMixSample(IGATBufferedSample sample, int length, float[] audioBuffer)
		{
			if (sample.IsFirstChunk)
			{
				base.PlayingStatus = Status.Playing;
			}
			if (base.StopsEarly && AudioSettings.dspTime >= _endDspTime)
			{
				_shouldStop = true;
			}
			if (_shouldStop)
			{
				sample.CacheToProcessingBuffer(length);
				sample.ProcessingBuffer.FadeOut(0, length);
				sample.IsLastChunk = true;
				if ((object)sample.Track != null)
				{
					sample.Track.MixFrom(sample.ProcessingBuffer, 0, sample.OffsetInBuffer, length, sample.PlayingGain);
				}
				else
				{
					sample.PanInfo.PanMixProcessingBuffer(sample, length, audioBuffer, sample.PlayingGain);
				}
				base.PlayingStatus = Status.ReadyToPlay;
				CurrentLoop = 0;
				_shouldStop = false;
				return false;
			}
			if (sample.IsLastChunk)
			{
				if (Loop && (NumberOfLoops == -1 || CurrentLoop < NumberOfLoops))
				{
					int num = GATInfo.AudioBufferSizePerChannel - length;
					sample.IsLastChunk = false;
					sample.AudioData.CopyTo(sample.ProcessingBuffer, 0, sample.NextIndex, length);
					sample.AudioData.CopyTo(sample.ProcessingBuffer, length, 0, num);
					sample.NextIndex = num;
					if ((object)sample.Track != null)
					{
						sample.Track.MixFrom(sample.ProcessingBuffer, 0, sample.OffsetInBuffer, GATInfo.AudioBufferSizePerChannel, sample.PlayingGain);
					}
					else
					{
						sample.PanInfo.PanMixProcessingBuffer(sample, GATInfo.AudioBufferSizePerChannel, audioBuffer, sample.PlayingGain);
					}
					CurrentLoop++;
					return false;
				}
				base.PlayingStatus = Status.ReadyToPlay;
				CurrentLoop = 0;
			}
			return true;
		}
	}
}
