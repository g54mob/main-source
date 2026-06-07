using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace NAudio.Wave
{
	public class DirectSoundOut : IWavePlayer, IDisposable
	{
		[StructLayout((LayoutKind)0)]
		internal class BufferDescription
		{
			public int dwSize;

			public DirectSoundBufferCaps dwFlags;

			public uint dwBufferBytes;

			public int dwReserved;

			public IntPtr lpwfxFormat;

			public Guid guidAlgo;
		}

		[StructLayout((LayoutKind)0)]
		internal class BufferCaps
		{
			public int dwSize;

			public int dwFlags;

			public int dwBufferBytes;

			public int dwUnlockTransferRate;

			public int dwPlayCpuOverhead;
		}

		internal enum DirectSoundCooperativeLevel : uint
		{
			DSSCL_NORMAL = 1u,
			DSSCL_PRIORITY = 2u,
			DSSCL_EXCLUSIVE = 3u,
			DSSCL_WRITEPRIMARY = 4u
		}

		[Flags]
		internal enum DirectSoundPlayFlags : uint
		{
			DSBPLAY_LOOPING = 1u,
			DSBPLAY_LOCHARDWARE = 2u,
			DSBPLAY_LOCSOFTWARE = 4u,
			DSBPLAY_TERMINATEBY_TIME = 8u,
			DSBPLAY_TERMINATEBY_DISTANCE = 0x10u,
			DSBPLAY_TERMINATEBY_PRIORITY = 0x20u
		}

		internal enum DirectSoundBufferLockFlag : uint
		{
			None = 0u,
			FromWriteCursor = 1u,
			EntireBuffer = 2u
		}

		[Flags]
		internal enum DirectSoundBufferStatus : uint
		{
			DSBSTATUS_PLAYING = 1u,
			DSBSTATUS_BUFFERLOST = 2u,
			DSBSTATUS_LOOPING = 4u,
			DSBSTATUS_LOCHARDWARE = 8u,
			DSBSTATUS_LOCSOFTWARE = 0x10u,
			DSBSTATUS_TERMINATED = 0x20u
		}

		[Flags]
		internal enum DirectSoundBufferCaps : uint
		{
			DSBCAPS_PRIMARYBUFFER = 1u,
			DSBCAPS_STATIC = 2u,
			DSBCAPS_LOCHARDWARE = 4u,
			DSBCAPS_LOCSOFTWARE = 8u,
			DSBCAPS_CTRL3D = 0x10u,
			DSBCAPS_CTRLFREQUENCY = 0x20u,
			DSBCAPS_CTRLPAN = 0x40u,
			DSBCAPS_CTRLVOLUME = 0x80u,
			DSBCAPS_CTRLPOSITIONNOTIFY = 0x100u,
			DSBCAPS_CTRLFX = 0x200u,
			DSBCAPS_STICKYFOCUS = 0x4000u,
			DSBCAPS_GLOBALFOCUS = 0x8000u,
			DSBCAPS_GETCURRENTPOSITION2 = 0x10000u,
			DSBCAPS_MUTE3DATMAXDISTANCE = 0x20000u,
			DSBCAPS_LOCDEFER = 0x40000u
		}

		internal struct DirectSoundBufferPositionNotify
		{
			public uint dwOffset;

			public IntPtr hEventNotify;
		}

		[ComImport]
		[Guid("279AFA83-4981-11CE-A521-0020AF0BE560")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		internal interface IDirectSound
		{
			void CreateSoundBuffer([In] BufferDescription desc, out object dsDSoundBuffer, IntPtr pUnkOuter);

			void GetCaps(IntPtr caps);

			void DuplicateSoundBuffer([In] IDirectSoundBuffer bufferOriginal, [In] IDirectSoundBuffer bufferDuplicate);

			void SetCooperativeLevel(IntPtr HWND, [In] DirectSoundCooperativeLevel dwLevel);

			void Compact();

			void GetSpeakerConfig(IntPtr pdwSpeakerConfig);

			void SetSpeakerConfig(uint pdwSpeakerConfig);

			void Initialize([In] Guid guid);
		}

		[ComImport]
		[Guid("279AFA85-4981-11CE-A521-0020AF0BE560")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		internal interface IDirectSoundBuffer
		{
			void GetCaps(BufferCaps pBufferCaps);

			void GetCurrentPosition(out uint currentPlayCursor, out uint currentWriteCursor);

			void GetFormat();

			int GetVolume();

			void GetPan(out uint pan);

			int GetFrequency();

			DirectSoundBufferStatus GetStatus();

			void Initialize([In] IDirectSound directSound, [In] BufferDescription desc);

			void Lock(int dwOffset, uint dwBytes, out IntPtr audioPtr1, out int audioBytes1, out IntPtr audioPtr2, out int audioBytes2, DirectSoundBufferLockFlag dwFlags);

			void Play(uint dwReserved1, uint dwPriority, [In] DirectSoundPlayFlags dwFlags);

			void SetCurrentPosition(uint dwNewPosition);

			void SetFormat([In] WaveFormat pcfxFormat);

			void SetVolume(int volume);

			void SetPan(uint pan);

			void SetFrequency(uint frequency);

			void Stop();

			void Unlock(IntPtr pvAudioPtr1, int dwAudioBytes1, IntPtr pvAudioPtr2, int dwAudioBytes2);

			void Restore();
		}

		[ComImport]
		[Guid("b0210783-89cd-11d0-af08-00a0c925cd16")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		internal interface IDirectSoundNotify
		{
			void SetNotificationPositions(uint dwPositionNotifies, [In] DirectSoundBufferPositionNotify[] pcPositionNotifies);
		}

		private delegate bool DSEnumCallback(IntPtr lpGuid, IntPtr lpcstrDescription, IntPtr lpcstrModule, IntPtr lpContext);

		private PlaybackState playbackState;

		private WaveFormat waveFormat;

		private int samplesTotalSize;

		private int samplesFrameSize;

		private int nextSamplesWriteIndex;

		private int desiredLatency;

		private Guid device;

		private byte[] samples;

		private IWaveProvider waveStream;

		private IDirectSound directSound;

		private IDirectSoundBuffer primarySoundBuffer;

		private IDirectSoundBuffer secondaryBuffer;

		private EventWaitHandle frameEventWaitHandle1;

		private EventWaitHandle frameEventWaitHandle2;

		private EventWaitHandle endEventWaitHandle;

		private Thread notifyThread;

		private SynchronizationContext syncContext;

		private long bytesPlayed;

		private object m_LockObject;

		private static List<DirectSoundDeviceInfo> devices;

		public static readonly Guid DSDEVID_DefaultPlayback;

		public static readonly Guid DSDEVID_DefaultCapture;

		public static readonly Guid DSDEVID_DefaultVoicePlayback;

		public static readonly Guid DSDEVID_DefaultVoiceCapture;

		public static IEnumerable<DirectSoundDeviceInfo> Devices => null;

		public TimeSpan PlaybackPosition => default(TimeSpan);

		public PlaybackState PlaybackState => default(PlaybackState);

		public float Volume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public event EventHandler<StoppedEventArgs> PlaybackStopped
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private static bool EnumCallback(IntPtr lpGuid, IntPtr lpcstrDescription, IntPtr lpcstrModule, IntPtr lpContext)
		{
			return false;
		}

		public DirectSoundOut()
		{
		}

		public DirectSoundOut(Guid device)
		{
		}

		public DirectSoundOut(int latency)
		{
		}

		public DirectSoundOut(Guid device, int latency)
		{
		}

		~DirectSoundOut()
		{
		}

		public void Play()
		{
		}

		public void Stop()
		{
		}

		public void Pause()
		{
		}

		public long GetPosition()
		{
			return 0L;
		}

		public void Init(IWaveProvider waveProvider)
		{
		}

		private void InitializeDirectSound()
		{
		}

		public void Dispose()
		{
		}

		private bool IsBufferLost()
		{
			return false;
		}

		private int MsToBytes(int ms)
		{
			return 0;
		}

		private void PlaybackThreadFunc()
		{
		}

		private void RaisePlaybackStopped(Exception e)
		{
		}

		private void StopPlayback()
		{
		}

		private void CleanUpSecondaryBuffer()
		{
		}

		private int Feed(int bytesToCopy)
		{
			return 0;
		}

		[PreserveSig]
		private static extern void DirectSoundCreate(ref Guid GUID, out IDirectSound directSound, IntPtr pUnkOuter);

		[PreserveSig]
		private static extern void DirectSoundEnumerate(DSEnumCallback lpDSEnumCallback, IntPtr lpContext);

		[PreserveSig]
		private static extern IntPtr GetDesktopWindow();
	}
}
