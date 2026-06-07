using System;
using Crosstales.NAudio.Wave;
using Crosstales.NLayer;
using Crosstales.NVorbis;
using UnityEngine;

namespace DV.Radio
{
	public abstract class BasePlayer : MonoBehaviour, IAudioPlayer
	{
		public AudioSource audioSource;

		public bool stopOnFocusLost;

		protected AudioCodec currentCodec;

		protected RecordInfo currentRecordInfo = new RecordInfo();

		protected Mp3FileReader nAudioReader;

		protected VorbisReader nVorbisReader;

		protected MpegFile nLayerReader;

		public virtual bool StopOnFocusLost
		{
			get
			{
				return stopOnFocusLost;
			}
			set
			{
				stopOnFocusLost = value;
			}
		}

		public virtual bool IsStopped { get; protected set; } = true;

		public virtual RecordInfo CurrentRecordInfo { get; protected set; }

		public virtual RadioStationInfo CurrentStationInfo { get; }

		public event Action PlaybackStarted;

		public event Action PlaybackStopped;

		public event Action BufferingStarted;

		public event Action BufferingEnded;

		public event Action<float> BufferingProgress;

		public event Action<string> SongInfoChanged;

		public event Action<string> StationNameChanged;

		public event Action<string> ErrorInfo;

		protected virtual void PlaybackStarted_Fire()
		{
			this.PlaybackStarted?.Invoke();
		}

		protected virtual void PlaybackStopped_Fire()
		{
			this.PlaybackStopped?.Invoke();
		}

		protected virtual void BufferingStarted_Fire()
		{
			this.BufferingStarted?.Invoke();
		}

		protected virtual void BufferingEnded_Fire()
		{
			this.BufferingEnded?.Invoke();
		}

		protected virtual void BufferingProgress_Fire(float progress)
		{
			this.BufferingProgress?.Invoke(progress);
		}

		protected virtual void SongInfoChanged_Fire(string songInfo)
		{
			this.SongInfoChanged?.Invoke(songInfo);
		}

		protected virtual void StationNameChanged_Fire(string stationName)
		{
			this.StationNameChanged?.Invoke(stationName);
		}

		protected virtual void ErrorInfo_Fire(string info)
		{
			this.ErrorInfo?.Invoke(info);
		}

		public abstract void Play();

		public abstract void Stop();

		public abstract bool Pause();

		public abstract long GetSeekPosition();

		public abstract void SetSeekPosition(long position);

		protected virtual void OnDisable()
		{
			Stop();
		}

		protected static int ConvertByteArrayToFloatArray(byte[] src, int byteCount, float[] dest)
		{
			if (byteCount == 0)
			{
				Array.Clear(dest, 0, dest.Length);
				return 0;
			}
			if (dest.Length < byteCount / 2)
			{
				byteCount = dest.Length * 2;
			}
			int num = 0;
			for (int i = 0; i < byteCount; i += 2)
			{
				dest[num] = (float)(short)((src[i + 1] << 8) | src[i]) / 32768f;
				num++;
			}
			return byteCount / 2;
		}

		protected void DisposeReader()
		{
			if (AudioCodec.MP3_NLayer == currentCodec)
			{
				if (nLayerReader != null)
				{
					nLayerReader.Dispose();
					nLayerReader = null;
				}
			}
			else if (AudioCodec.MP3_NAudio == currentCodec)
			{
				if (nAudioReader != null)
				{
					nAudioReader.Dispose();
					nAudioReader = null;
				}
			}
			else if (AudioCodec.OGG_NVorbis == currentCodec && nVorbisReader != null)
			{
				nVorbisReader.Dispose();
				nVorbisReader = null;
				Mdct.ClearSetupCache();
			}
		}
	}
}
