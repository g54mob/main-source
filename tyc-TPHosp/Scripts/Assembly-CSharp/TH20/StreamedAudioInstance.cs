using System;
using System.IO;
using MP3Sharp;
using TH20.ExtContent;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class StreamedAudioInstance
	{
		public const int cMaxTrackDurationSecs = 600;

		public const int cUnknownTrackDurationSecs = 30;

		public const int cBytesPerSample = 2;

		public const bool cVerboseTrackReadLogging = false;

		public const bool cVerboseTrackStreamInitLogging = true;

		public const bool cVerboseTrackSeekLogging = false;

		public const bool cVerboseTrackStreamGeneralLogging = false;

		private bool _bInited;

		private bool _bErrorEncountered;

		private string _contextStr;

		private bool _bUseMemoryStream;

		private bool _bCreateAudioClip;

		private bool _bAllowSeeks;

		private string _mp3FileSpec;

		private MemoryStream _memStream;

		private MP3Stream _mp3Stream;

		private AudioClip _audioClip;

		private byte[] _readBuffer;

		private int _totalSamplesRead;

		private int _numSamplesPerChannel;

		private float _normalisationFactor;

		private readonly object _lockObject = new object();

		public bool Inited => _bInited;

		public bool ErrorEncountered => _bErrorEncountered;

		public AudioClip AudioClip => _audioClip;

		public MP3Stream MP3Stream => _mp3Stream;

		public float NormalisationFactor => _normalisationFactor;

		public void Init(string contextStr, string mp3FileSpec, int numSamplesPerChannel = -1, float normalisationFactor = -1f, bool bUseMemoryStream = true, bool bCreateAudioClip = true, bool bAllowSeeks = false)
		{
			_bInited = false;
			_bErrorEncountered = false;
			_contextStr = contextStr;
			_bUseMemoryStream = bUseMemoryStream;
			_bCreateAudioClip = bCreateAudioClip;
			_numSamplesPerChannel = numSamplesPerChannel;
			_normalisationFactor = normalisationFactor;
			_bAllowSeeks = bAllowSeeks;
			if (!mp3FileSpec.IsNullOrEmpty() && File.Exists(mp3FileSpec))
			{
				_mp3FileSpec = mp3FileSpec;
				_memStream = null;
				if (_bUseMemoryStream)
				{
					try
					{
						byte[] buffer = File.ReadAllBytes(mp3FileSpec);
						_memStream = new MemoryStream(buffer);
					}
					catch (Exception ex)
					{
						ExtContentMessages.LogError($"[DYNPLMGR]: Exception error creating memory '{_contextStr}' stream for '{Path.GetFileName(mp3FileSpec)}' - ('{ex.ToString()}') ");
					}
				}
				MP3Stream mP3Stream = null;
				try
				{
					mP3Stream = ((_memStream == null) ? new MP3Stream(_mp3FileSpec, 131072) : new MP3Stream(_memStream, 131072));
				}
				catch (Exception ex2)
				{
					ExtContentMessages.LogError($"[DYNPLMGR]: Exception error creating '{_contextStr}' mp3 stream for '{Path.GetFileName(mp3FileSpec)}' - ('{ex2.ToString()}') ");
				}
				if (mP3Stream != null && mP3Stream.Length > 0 && mP3Stream.Format == SoundFormat.Pcm16BitStereo)
				{
					_bInited = true;
					_mp3Stream = mP3Stream;
					if (_bCreateAudioClip)
					{
						int num = 600;
						int frequency = _mp3Stream.Frequency;
						if (_numSamplesPerChannel > 0)
						{
							int num2 = num * frequency;
							if (_numSamplesPerChannel > num2)
							{
								_numSamplesPerChannel = num2;
							}
						}
						else
						{
							_numSamplesPerChannel = 30 * frequency;
						}
						_totalSamplesRead = 0;
						try
						{
							_audioClip = AudioClip.Create("TPHAudioClip", _numSamplesPerChannel, _mp3Stream.ChannelCount, frequency, stream: true, OnStreamedAudioClipRead, null);
						}
						catch (Exception ex3)
						{
							ExtContentMessages.LogError($"[DYNPLMGR]: Error creating '{_contextStr}' Audio Clip for '{Path.GetFileName(mp3FileSpec)}' - ('{ex3.ToString()}')");
						}
					}
				}
			}
			if (!_bInited)
			{
				_bErrorEncountered = true;
				ExtContentMessages.LogError($"[DYNPLMGR]: Error creating '{_contextStr}' stream for '{Path.GetFileName(mp3FileSpec)}'");
			}
			else
			{
				ExtContentMessages.LogDebug($"[DYNPLMGR]: MP3 STREAMING INIT : '{_mp3FileSpec}'");
			}
		}

		public void DeInit()
		{
			lock (_lockObject)
			{
				bool bInited = _bInited;
				_bInited = false;
				if (bInited)
				{
					ExtContentMessages.LogDebug($"[DYNPLMGR]: MP3 STREAMING DEINIT : '{_mp3FileSpec}'");
				}
				if (_mp3Stream != null)
				{
					_mp3Stream.Close();
					_mp3Stream.Dispose();
					_mp3Stream = null;
				}
				if (_audioClip != null)
				{
					UnityEngine.Object.Destroy(_audioClip);
					_audioClip = null;
				}
				if (_memStream != null)
				{
					_memStream.Close();
					_memStream.Dispose();
					_memStream = null;
				}
				DestroyReadBuffer();
			}
		}

		private void OnStreamedAudioPositionChange(int position)
		{
		}

		private void OnStreamedAudioClipRead(float[] dataToFill)
		{
			int num = dataToFill.Length;
			if (num <= 0)
			{
				return;
			}
			int num2 = num * 2;
			CheckReadBufferValid(num2);
			try
			{
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				lock (_lockObject)
				{
					if (_bInited)
					{
						int num6 = _mp3Stream.Read(_readBuffer, 0, num2);
						num5 = num6 / 2;
						_totalSamplesRead += num5;
						if (num6 > 0)
						{
							float num7 = Convert.ToSingle(32768);
							int num8 = 0;
							int num9 = 0;
							while (num9 < num5)
							{
								int num10 = _readBuffer[num8];
								float num11 = Convert.ToSingle((short)(ushort)((_readBuffer[num8 + 1] << 8) | num10)) / num7 * _normalisationFactor;
								dataToFill[num4++] = num11;
								num9++;
								num8 += 2;
							}
						}
						num3 = _totalSamplesRead;
					}
				}
				while (num4 < num)
				{
					dataToFill[num4++] = 0f;
				}
			}
			catch (Exception ex)
			{
				_bErrorEncountered = true;
				ExtContentMessages.LogError($"[DYNPLMGR]: '{_contextStr}' error encountered within mp3Stream.Read() for '{Path.GetFileName(_mp3FileSpec)}' - ('{ex.ToString()}')");
			}
		}

		private void CheckReadBufferValid(int reqdLen)
		{
			if (_readBuffer != null && _readBuffer.Length < reqdLen)
			{
				DestroyReadBuffer();
			}
			if (_readBuffer == null)
			{
				CreateReadBuffer(reqdLen);
			}
		}

		private void CreateReadBuffer(int reqdLen)
		{
			_readBuffer = new byte[reqdLen];
		}

		private void DestroyReadBuffer()
		{
			if (_readBuffer != null)
			{
				_readBuffer = null;
			}
		}
	}
}
