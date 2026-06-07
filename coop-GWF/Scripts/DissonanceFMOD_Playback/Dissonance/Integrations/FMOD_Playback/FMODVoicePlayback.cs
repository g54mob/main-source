using System;
using System.Runtime.InteropServices;
using AOT;
using Dissonance.Audio.Playback;
using FMOD;
using FMODUnity;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dissonance.Integrations.FMOD_Playback
{
	public class FMODVoicePlayback : BaseVoicePlayback
	{
		private class AudioGenerator
		{
			private readonly FMODVoicePlayback _parent;

			private SpeechSession? _session;

			private float[] _temp;

			private readonly object _pumpLock = new object();

			private volatile bool _isVirtual;

			private float _virtualisedTimeAccumulator;

			public float Amplitude { get; private set; }

			public SpeechSession? ActiveSession => _session;

			public bool IsVirtual => _isVirtual;

			public AudioGenerator(FMODVoicePlayback parent)
			{
				_parent = parent;
			}

			public unsafe RESULT GetAudio(IntPtr outbuffer, uint length, uint outchannels)
			{
				lock (_pumpLock)
				{
					SpeechSession? activeSession = ActiveSession;
					if (!activeSession.HasValue)
					{
						if (outbuffer != IntPtr.Zero)
						{
							FloatMemClear((float*)outbuffer.ToPointer(), length);
						}
						return RESULT.OK;
					}
					uint num = length / outchannels;
					if (_temp == null || num > _temp.Length)
					{
						_temp = new float[num * 2];
					}
					if (activeSession.Value.Read(new ArraySegment<float>(_temp, 0, (int)num)))
					{
						_session = null;
					}
					float num2 = 0f;
					if (outbuffer == IntPtr.Zero)
					{
						int num3 = 0;
						for (uint num4 = 0u; num4 < length; num4 += outchannels)
						{
							num2 += Mathf.Abs(_temp[num3++]);
						}
					}
					else
					{
						float* ptr = (float*)outbuffer.ToPointer();
						int num5 = 0;
						for (uint num6 = 0u; num6 < length; num6 += outchannels)
						{
							float num7 = _temp[num5++];
							num2 += Mathf.Abs(num7);
							for (int i = 0; i < outchannels; i++)
							{
								ptr[num6 + i] = num7;
							}
						}
					}
					Amplitude = num2 / (float)length;
					return RESULT.OK;
				}
			}

			public RESULT ShouldProcess()
			{
				if (!_session.HasValue)
				{
					return RESULT.ERR_DSP_SILENCE;
				}
				return RESULT.OK;
			}

			public void Start(SpeechSession speechSession)
			{
				if (_session.HasValue)
				{
					throw new InvalidOperationException("Cannot start a new voice session when one is already playing");
				}
				_session = speechSession;
				_parent.UpdatePositionalPlayback(speechSession.PlaybackOptions);
			}

			public void PumpVirtualised(float deltaTime, int sampleRate)
			{
				if (!_isVirtual)
				{
					return;
				}
				lock (_pumpLock)
				{
					if (_isVirtual)
					{
						_virtualisedTimeAccumulator += deltaTime;
						uint num = (uint)Math.Floor(_virtualisedTimeAccumulator * (float)sampleRate);
						_virtualisedTimeAccumulator -= (float)num / (float)sampleRate;
						GetAudio(IntPtr.Zero, num, 1u);
					}
				}
			}

			public void SetVirtualised(bool virtualised)
			{
				lock (_pumpLock)
				{
					_isVirtual = virtualised;
					_virtualisedTimeAccumulator = 0f;
				}
			}
		}

		private static readonly Log Log = Logs.Create(LogCategory.Playback, "FMODVoicePlayback");

		private AudioGenerator _generator;

		private GCHandle _handle;

		private DSP _dsp;

		private Channel _channel;

		private int _sampleRate;

		private FMODChannelGroupLocks.Handle? _busLock;

		[SerializeField]
		[Tooltip("Audio Minimum distance")]
		public float MinDistance = 5f;

		[SerializeField]
		[Tooltip("Audio Maximum distance")]
		public float MaxDistance = 100f;

		[SerializeField]
		[Tooltip("Audio Attenuation Mode")]
		public RolloffMode RolloffMode = RolloffMode.InverseTapered;

		[SerializeField]
		[Tooltip("Output Audio Bus")]
		public string OutputBusID;

		[SerializeField]
		[Tooltip("Disable passing positional information to FMOD")]
		[FormerlySerializedAs("DisablePositionalAudio")]
		private bool _disablePositionalAudio;

		public override float Amplitude => _generator?.Amplitude ?? 0f;

		public bool IsVirtualised => _generator?.IsVirtual ?? false;

		public bool DisablePositionalAudio
		{
			get
			{
				return _disablePositionalAudio;
			}
			set
			{
				if (value != _disablePositionalAudio)
				{
					_disablePositionalAudio = value;
					if (base.LatestPlaybackOptions.HasValue)
					{
						UpdatePositionalPlayback(base.LatestPlaybackOptions.Value);
					}
				}
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			RuntimeManager.CoreSystem.getSoftwareFormat(out _sampleRate, out var _, out var _);
			_generator = new AudioGenerator(this);
			_handle = GCHandle.Alloc(_generator);
			DSP_DESCRIPTION description = new DSP_DESCRIPTION
			{
				numinputbuffers = 0,
				numoutputbuffers = 1,
				read = ReadDSP,
				shouldiprocess = ShouldProcessDSP,
				userdata = (IntPtr)_handle
			};
			RuntimeManager.CoreSystem.createDSP(ref description, out _dsp);
			_busLock = FMODChannelGroupLocks.Instance.LockBus(OutputBusID);
			RuntimeManager.CoreSystem.playDSP(_dsp, _busLock?.ChannelGroup ?? default(ChannelGroup), paused: false, out _channel);
			_channel.setUserData((IntPtr)_handle);
			_channel.setCallback(ChannelEventCallback);
			_channel.setPriority(0);
		}

		private static bool Check(RESULT result, string message, bool err = false)
		{
			if (result == RESULT.OK)
			{
				return true;
			}
			if (err)
			{
				Log.Error("{0}. FMOD Result: {1}", message, result);
			}
			else
			{
				Log.Warn("{0}. FMOD Result: {1}", message, result);
			}
			return false;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			Teardown();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Teardown();
		}

		private void Teardown()
		{
			if (_channel.hasHandle())
			{
				_channel.stop();
				_channel.setUserData(IntPtr.Zero);
				_channel.removeDSP(_dsp);
				_channel.clearHandle();
			}
			if (_dsp.hasHandle())
			{
				_dsp.setUserData(IntPtr.Zero);
				_dsp.release();
				_dsp.clearHandle();
			}
			if (_busLock.HasValue)
			{
				FMODChannelGroupLocks.Instance.UnlockBus(_busLock.Value);
				_busLock = null;
			}
			if (_handle.IsAllocated)
			{
				_handle.Free();
			}
		}

		protected override void Update()
		{
			base.Update();
			if (!_generator.ActiveSession.HasValue)
			{
				SpeechSession? speechSession = TryDequeueSession(_sampleRate);
				if (speechSession.HasValue)
				{
					_generator.Start(speechSession.Value);
				}
			}
			UpdateOutputBus();
			if (base.LatestPlaybackOptions.HasValue)
			{
				UpdatePositionalPlayback(base.LatestPlaybackOptions.Value);
			}
		}

		private void FixedUpdate()
		{
			_generator.PumpVirtualised(Time.fixedUnscaledDeltaTime, _sampleRate);
		}

		private void UpdateOutputBus()
		{
			if ((_busLock.HasValue || !string.IsNullOrWhiteSpace(OutputBusID)) && _busLock?.Name != OutputBusID)
			{
				if (_busLock.HasValue)
				{
					FMODChannelGroupLocks.Instance.UnlockBus(_busLock.Value);
				}
				_busLock = FMODChannelGroupLocks.Instance.LockBus(OutputBusID);
				Check(_channel.setChannelGroup(_busLock?.ChannelGroup ?? default(ChannelGroup)), "Failed to change channel group");
			}
		}

		private void UpdatePositionalPlayback(PlaybackOptions options)
		{
			if (!_channel.hasHandle())
			{
				return;
			}
			Check(_channel.getMode(out var mode), "Failed `getMode`", err: true);
			bool isPositional = options.IsPositional;
			if (((IVoicePlaybackInternal)this).AllowPositionalPlayback && !DisablePositionalAudio && isPositional)
			{
				if ((mode & MODE._2D) == MODE._2D || ((uint)mode & (uint)RolloffMode) != (uint)RolloffMode)
				{
					Check(_channel.setMode((MODE)((RolloffMode)16u | RolloffMode)), "Failed `setMode`", err: true);
				}
				Check(_channel.set3DMinMaxDistance(MinDistance, MaxDistance), "Failed `set3DMinMaxDistance`", err: true);
			}
			else if ((mode & MODE._2D) != MODE._2D)
			{
				Check(_channel.setMode(MODE._2D), "Failed `setMode`", err: true);
			}
		}

		protected override void SetTransform(Vector3 pos, Quaternion rot)
		{
			base.SetTransform(pos, rot);
			if (_channel.hasHandle())
			{
				Check(_channel.getMode(out var mode), "Failed `getMode`", err: true);
				if ((mode & MODE._3D) == MODE._3D)
				{
					VECTOR pos2 = new VECTOR
					{
						x = pos.x,
						y = pos.y,
						z = pos.z
					};
					VECTOR vel = default(VECTOR);
					Check(_channel.set3DAttributes(ref pos2, ref vel), "Failed `set3DAttributes`", err: true);
				}
			}
		}

		protected override SpeechSession? TryGetActiveSession()
		{
			return _generator?.ActiveSession;
		}

		[MonoPInvokeCallback(typeof(CHANNELCONTROL_CALLBACK))]
		private static RESULT ChannelEventCallback(IntPtr channelcontrol, CHANNELCONTROL_TYPE controltype, CHANNELCONTROL_CALLBACK_TYPE callbacktype, IntPtr commanddata1, IntPtr commanddata2)
		{
			if (controltype != CHANNELCONTROL_TYPE.CHANNEL)
			{
				return RESULT.OK;
			}
			if (callbacktype != CHANNELCONTROL_CALLBACK_TYPE.VIRTUALVOICE)
			{
				return RESULT.OK;
			}
			if (!Check(new Channel(channelcontrol).getUserData(out var userdata), "Failed to getUserData from channel"))
			{
				return RESULT.OK;
			}
			if (userdata == IntPtr.Zero)
			{
				return RESULT.OK;
			}
			AudioGenerator audioGenerator = (AudioGenerator)GCHandle.FromIntPtr(userdata).Target;
			if (audioGenerator == null)
			{
				return RESULT.OK;
			}
			audioGenerator.SetVirtualised(commanddata1.ToInt32() != 0);
			return RESULT.OK;
		}

		[MonoPInvokeCallback(typeof(DSP_READ_CALLBACK))]
		private static RESULT ReadDSP(ref DSP_STATE dsp_state, IntPtr inbuffer, IntPtr outbuffer, uint length, int inchannels, ref int outchannels)
		{
			if (dsp_state.functions.getuserdata(ref dsp_state, out var userdata) != RESULT.OK || userdata == IntPtr.Zero)
			{
				FloatMemClear(outbuffer, length);
				return RESULT.OK;
			}
			AudioGenerator audioGenerator = (AudioGenerator)GCHandle.FromIntPtr(userdata).Target;
			if (audioGenerator == null)
			{
				FloatMemClear(outbuffer, length);
				return RESULT.OK;
			}
			return audioGenerator.GetAudio(outbuffer, length, (uint)outchannels);
		}

		[MonoPInvokeCallback(typeof(DSP_SHOULDIPROCESS_CALLBACK))]
		private static RESULT ShouldProcessDSP(ref DSP_STATE dsp_state, bool inputsidle, uint length, CHANNELMASK inmask, int inchannels, SPEAKERMODE speakermode)
		{
			if (dsp_state.functions.getuserdata(ref dsp_state, out var userdata) != RESULT.OK || userdata == IntPtr.Zero)
			{
				return RESULT.OK;
			}
			return ((AudioGenerator)GCHandle.FromIntPtr(userdata).Target)?.ShouldProcess() ?? RESULT.ERR_DSP_SILENCE;
		}

		private unsafe static void FloatMemClear(IntPtr buffer, uint length)
		{
			float* buffer2 = (float*)buffer.ToPointer();
			FloatMemClear(buffer2, length);
		}

		private unsafe static void FloatMemClear(float* buffer, uint length)
		{
			for (int i = 0; i < length; i++)
			{
				buffer[i] = 0f;
			}
		}
	}
}
