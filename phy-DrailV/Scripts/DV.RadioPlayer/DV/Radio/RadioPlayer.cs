using System;
using System.Collections;
using System.Threading;
using Crosstales;
using Crosstales.NAudio.Wave;
using Crosstales.NLayer;
using Crosstales.NVorbis;
using UnityEngine;

namespace DV.Radio
{
	public class RadioPlayer : BasePlayer
	{
		public float playDelay = 0.1f;

		public bool legacyMode;

		private RadioStationInfo station;

		private RadioPlayerThreadWrapper threadWrapper;

		private Thread worker;

		private AudioClip clip;

		private bool bufferAvailable;

		private string currentStationName;

		private bool resumeOnNextFocus;

		private MemoryCacheStream ms;

		private byte[] buffer;

		private int bytesPerSample = -1;

		private void OnDestroy()
		{
			KillWorker();
			StopAllCoroutines();
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			if (!hasFocus)
			{
				if (StopOnFocusLost)
				{
					resumeOnNextFocus = threadWrapper?.playback ?? false;
					Stop();
				}
				else
				{
					resumeOnNextFocus = false;
				}
			}
			else if (resumeOnNextFocus)
			{
				Play();
			}
		}

		private void Update()
		{
			RadioPlayerThreadWrapper radioPlayerThreadWrapper = threadWrapper;
			if (radioPlayerThreadWrapper != null && radioPlayerThreadWrapper.recordInfo?.Equals(currentRecordInfo) == false)
			{
				currentRecordInfo = threadWrapper.recordInfo;
				SongInfoChanged_Fire(currentRecordInfo.Artist + " - " + currentRecordInfo.Title);
			}
			if (station?.ServerName != currentStationName)
			{
				currentStationName = station.ServerName;
				StationNameChanged_Fire(currentStationName);
			}
		}

		public void SetStation(RadioStationInfo station)
		{
			this.station = station;
			station.ServerName = (currentStationName = station.Name);
		}

		public override void Play()
		{
			if (!IsStopped)
			{
				ErrorInfo_Fire("RadioPlayer is already playing");
				return;
			}
			if (Application.internetReachability == NetworkReachability.NotReachable)
			{
				ErrorInfo_Fire("RadioPlayer cannot access Internet");
				return;
			}
			string text = RadioStationInfo.Validate(station);
			if (!string.IsNullOrEmpty(text))
			{
				ErrorInfo_Fire(text);
			}
			else if (station.Format.GetCodec() == AudioCodec.None)
			{
				ErrorInfo_Fire(string.Format("{0} encountered unsupported audio format {1} for station {2}", "RadioPlayer", station.Format, station.URL));
			}
			else
			{
				StartCoroutine(PlayRadioStation(station));
			}
		}

		public override void Stop()
		{
			IsStopped = true;
			if (threadWrapper != null)
			{
				threadWrapper.playback = false;
			}
			if (audioSource != null && audioSource.clip == clip && clip != null)
			{
				audioSource.Stop();
				audioSource.clip = null;
			}
			if (clip != null)
			{
				UnityEngine.Object.Destroy(clip);
				clip = null;
			}
		}

		public override bool Pause()
		{
			Stop();
			return true;
		}

		public override long GetSeekPosition()
		{
			return 0L;
		}

		public override void SetSeekPosition(long _)
		{
		}

		protected virtual IEnumerator PlayRadioStation(RadioStationInfo station)
		{
			KillWorker();
			currentCodec = station.Format.GetCodec();
			bufferAvailable = false;
			clip = null;
			bool success = true;
			int channels = -1;
			int sampleRate = -1;
			bytesPerSample = -1;
			StationNameChanged_Fire(station.Name);
			IsStopped = false;
			try
			{
				using (ms = new MemoryCacheStream(2097152, 33554432))
				{
					threadWrapper = new RadioPlayerThreadWrapper(station, legacyMode, ms);
					worker = threadWrapper.CreateThread();
					worker.Start();
					do
					{
						yield return null;
					}
					while (!IsStopped && !threadWrapper.playback && !threadWrapper.hasError);
					yield return StartCoroutine(WaitForFullBuffer());
					if (IsStopped || !threadWrapper.playback)
					{
						yield break;
					}
					try
					{
						if (AudioCodec.MP3_NLayer == currentCodec)
						{
							nLayerReader = new MpegFile(ms);
							if (nLayerReader.SampleRate < 32000 || nLayerReader.SampleRate > 48000)
							{
								success = false;
								ErrorInfo_Fire($"Unsupported sample rate {nLayerReader.SampleRate}, only MP3 with layer 3 specs is supported! MPEG-1 (Audio Layer III) allows the following sample rates: 32kHz, 44.1kHz and 48kHz!");
							}
							else
							{
								sampleRate = nLayerReader.SampleRate;
								channels = nLayerReader.Channels;
							}
						}
						else if (AudioCodec.MP3_NAudio == currentCodec)
						{
							nAudioReader = new Mp3FileReader(ms);
							sampleRate = nAudioReader.WaveFormat.SampleRate;
							channels = nAudioReader.WaveFormat.Channels;
							bytesPerSample = nAudioReader.WaveFormat.BitsPerSample / 8;
						}
						else if (AudioCodec.OGG_NVorbis == currentCodec)
						{
							nVorbisReader = new VorbisReader(ms, closeStreamOnDispose: false);
							sampleRate = nVorbisReader.SampleRate;
							channels = nVorbisReader.Channels;
						}
						else
						{
							success = false;
							string info = $"Unsupported codec '{currentCodec}'";
							ErrorInfo_Fire(info);
						}
					}
					catch (Exception arg)
					{
						success = false;
						ErrorInfo_Fire($"Could not read '{station.URL}', original exception: {arg}");
					}
					if (!success)
					{
						threadWrapper.playback = false;
					}
					else
					{
						if (AudioCodec.OGG_NVorbis == currentCodec)
						{
							ms.Position = 0L;
						}
						clip = AudioClip.Create(station.Name, int.MaxValue, channels, sampleRate, stream: true, ReadPCMData);
						audioSource.clip = clip;
						PlaybackStarted_Fire();
						audioSource.Play();
					}
					int oggCacheCleanFrameCount = UnityEngine.Random.Range(1000, 6000);
					do
					{
						yield return null;
						if (currentCodec == AudioCodec.OGG_NVorbis && Time.frameCount % oggCacheCleanFrameCount == 0)
						{
							Mdct.ClearSetupCache();
						}
						if (!bufferAvailable)
						{
							yield return StartCoroutine(WaitForFullBuffer());
						}
					}
					while (threadWrapper.playback && !IsStopped);
				}
			}
			finally
			{
				RadioPlayer radioPlayer = this;
				radioPlayer.Stop();
				radioPlayer.DisposeReader();
				if (radioPlayer.threadWrapper?.hasError ?? false)
				{
					radioPlayer.ErrorInfo_Fire(radioPlayer.threadWrapper.errorMessage);
				}
				radioPlayer.PlaybackStopped_Fire();
			}
		}

		private IEnumerator WaitForFullBuffer()
		{
			int bufferSize = 65536;
			bufferAvailable = false;
			BufferingStarted_Fire();
			long initialLength = ms.Length;
			float bufferProgress = 0f;
			do
			{
				float num = Mathf.Clamp01((float)(ms.Length - initialLength) / (float)bufferSize);
				if (num == 1f || num - bufferProgress >= 0.01f)
				{
					bufferProgress = num;
					BufferingProgress_Fire(bufferProgress);
				}
				yield return null;
			}
			while (!IsStopped && threadWrapper.playback && bufferProgress < 1f);
			if (bufferProgress == 1f)
			{
				bufferAvailable = true;
			}
			BufferingEnded_Fire();
		}

		protected virtual void ReadPCMData(float[] data)
		{
			if (data == null)
			{
				return;
			}
			if (!IsStopped && bufferAvailable)
			{
				int num = 0;
				if (currentCodec == AudioCodec.MP3_NLayer)
				{
					if (nLayerReader != null)
					{
						try
						{
							num = nLayerReader.ReadSamples(data, 0, data.Length);
						}
						catch (Exception ex)
						{
							LogDataError(ex);
						}
					}
				}
				else if (currentCodec == AudioCodec.MP3_NAudio)
				{
					if (nAudioReader != null)
					{
						int num2 = data.Length * bytesPerSample;
						if (buffer == null || buffer.Length < num2)
						{
							buffer = new byte[num2];
						}
						try
						{
							int byteCount = nAudioReader.Read(buffer, 0, num2);
							num = BasePlayer.ConvertByteArrayToFloatArray(buffer, byteCount, data);
						}
						catch (Exception ex2)
						{
							LogDataError(ex2);
						}
					}
				}
				else
				{
					if (currentCodec != AudioCodec.OGG_NVorbis)
					{
						throw new NotImplementedException($"Unhandled codec {currentCodec}");
					}
					if (nVorbisReader != null)
					{
						try
						{
							num = nVorbisReader.ReadSamples(data, 0, data.Length);
						}
						catch (Exception ex3)
						{
							LogDataError(ex3);
						}
					}
				}
				if (num < data.Length)
				{
					Array.Clear(data, 0, data.Length);
					bufferAvailable = false;
				}
			}
			else
			{
				Array.Clear(data, 0, data.Length);
			}
		}

		private void LogDataError(Exception ex)
		{
			threadWrapper.playback = false;
			string info = "Could not read audio data, possible buffer underrun.";
			ErrorInfo_Fire(info);
		}

		private void KillWorker()
		{
			Thread thread = worker;
			if (thread != null && thread.IsAlive)
			{
				worker.Abort();
				worker = null;
			}
			threadWrapper = null;
		}
	}
}
