using UnityEngine;

namespace GAudio
{
	public abstract class AGATWrappedSample
	{
		public enum Status
		{
			ReadyToPlay = 0,
			Scheduled = 1,
			Playing = 2
		}

		public readonly AGATPanInfo panInfo;

		protected bool _shouldStop;

		protected IGATDataOwner _dataOwner;

		protected double _endDspTime;

		public Status PlayingStatus { get; protected set; }

		public bool StopsEarly { get; set; }

		public double MaxDuration { get; set; }

		public AGATWrappedSample(IGATDataOwner dataOwner, AGATPanInfo ipaninfo = null)
		{
			panInfo = ipaninfo;
			_dataOwner = dataOwner;
		}

		public void ElegantStop()
		{
			_shouldStop = true;
		}

		public void PlayPanned(float gain = 1f)
		{
			if (panInfo != null && PlayingStatus == Status.ReadyToPlay)
			{
				PlayingStatus = Status.Scheduled;
				GATManager.DefaultPlayer.PlayData(_dataOwner.AudioData, panInfo, gain, PlayerWillMixSample);
				_endDspTime = AudioSettings.dspTime + MaxDuration;
			}
		}

		public void PlayPanned(GATPlayer player, float gain = 1f)
		{
			if (panInfo != null && PlayingStatus == Status.ReadyToPlay)
			{
				PlayingStatus = Status.Scheduled;
				player.PlayData(_dataOwner.AudioData, panInfo, gain, PlayerWillMixSample);
				_endDspTime = AudioSettings.dspTime + MaxDuration;
			}
		}

		public void PlayThroughTrack(int trackNb, float gain = 1f)
		{
			if (PlayingStatus == Status.ReadyToPlay)
			{
				PlayingStatus = Status.Scheduled;
				GATManager.DefaultPlayer.PlayData(_dataOwner.AudioData, trackNb, gain, PlayerWillMixSample);
				_endDspTime = AudioSettings.dspTime + MaxDuration;
			}
		}

		public void PlayThroughTrack(GATPlayer player, int trackNb, float gain = 1f)
		{
			if (PlayingStatus == Status.ReadyToPlay)
			{
				PlayingStatus = Status.Scheduled;
				player.PlayData(_dataOwner.AudioData, trackNb, gain, PlayerWillMixSample);
				_endDspTime = AudioSettings.dspTime + MaxDuration;
			}
		}

		public void PlayScheduled(double dspTime, float gain = 1f)
		{
			if (panInfo != null && PlayingStatus == Status.ReadyToPlay)
			{
				PlayingStatus = Status.Scheduled;
				GATManager.DefaultPlayer.PlayDataScheduled(_dataOwner.AudioData, dspTime, panInfo, gain, PlayerWillMixSample);
				_endDspTime = dspTime + MaxDuration;
			}
		}

		public void PlayScheduled(GATPlayer player, double dspTime, float gain = 1f)
		{
			if (panInfo != null && PlayingStatus == Status.ReadyToPlay)
			{
				PlayingStatus = Status.Scheduled;
				player.PlayDataScheduled(_dataOwner.AudioData, dspTime, panInfo, gain, PlayerWillMixSample);
				_endDspTime = dspTime + MaxDuration;
			}
		}

		public void PlayScheduledThroughTrack(double dspTime, int trackNb, float gain = 1f)
		{
			if (PlayingStatus == Status.ReadyToPlay)
			{
				PlayingStatus = Status.Scheduled;
				GATManager.DefaultPlayer.PlayDataScheduled(_dataOwner.AudioData, dspTime, trackNb, gain, PlayerWillMixSample);
				_endDspTime = dspTime + MaxDuration;
			}
		}

		public void PlayScheduledThroughTrack(GATPlayer player, double dspTime, int trackNb, float gain = 1f)
		{
			if (PlayingStatus == Status.ReadyToPlay)
			{
				PlayingStatus = Status.Scheduled;
				player.PlayDataScheduled(_dataOwner.AudioData, dspTime, trackNb, gain, PlayerWillMixSample);
				_endDspTime = dspTime + MaxDuration;
			}
		}

		protected abstract bool PlayerWillMixSample(IGATBufferedSample sample, int length, float[] audioBuffer);
	}
}
