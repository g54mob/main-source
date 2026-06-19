using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Dissonance.Audio.Capture;
using FMOD;
using FMODUnity;
using JetBrains.Annotations;
using NAudio.Wave;
using UnityEngine;

namespace Dissonance.Integrations.FMOD_Recording
{
	public class FMODMicrophoneInput : MonoBehaviour, IMicrophoneCapture, IMicrophoneDeviceList
	{
		private static readonly Log Log = Logs.Create(LogCategory.Recording, "FMODMicrophoneInput");

		private readonly float[] _buffer = new float[48000];

		private readonly List<IMicrophoneSubscriber> _subscribers = new List<IMicrophoneSubscriber>();

		private int _deviceID;

		private string _deviceName;

		private WaveFormat _format;

		private Sound _sound;

		private uint _soundLength;

		private uint _lastRecordPos;

		public bool IsRecording { get; private set; }

		public string Device
		{
			get
			{
				if (!IsRecording)
				{
					return null;
				}
				return _deviceName;
			}
		}

		public TimeSpan Latency => TimeSpan.Zero;

		private static bool Check(RESULT result, string message)
		{
			if (result != RESULT.OK)
			{
				Log.Warn(message + $" FMOD Result: {result}");
				return false;
			}
			return true;
		}

		public WaveFormat StartCapture(string name)
		{
			StopCapture();
			int? num = ChooseAudioDevice(name, out _deviceName);
			if (!num.HasValue)
			{
				return null;
			}
			(int rate, int channels) deviceInfo = GetDeviceInfo(num.Value);
			int item = deviceInfo.rate;
			int item2 = deviceInfo.channels;
			_deviceID = num.Value;
			_format = new WaveFormat(item, 1);
			lock (_subscribers)
			{
				for (int i = 0; i < _subscribers.Count; i++)
				{
					_subscribers[i].Reset();
				}
			}
			CREATESOUNDEXINFO exinfo = new CREATESOUNDEXINFO
			{
				cbsize = Marshal.SizeOf(typeof(CREATESOUNDEXINFO)),
				numchannels = 1,
				format = SOUND_FORMAT.PCMFLOAT,
				defaultfrequency = item,
				length = (uint)(item * 4)
			};
			FMOD.System coreSystem = RuntimeManager.CoreSystem;
			if (!Check(coreSystem.createSound("recording", MODE.LOOP_NORMAL | MODE.OPENUSER, ref exinfo, out _sound), "Failed to call `createSound`"))
			{
				return null;
			}
			if (!Check(_sound.getLength(out _soundLength, TIMEUNIT.PCM), "Failed to call `getLength`"))
			{
				return null;
			}
			if (!Check(_sound.getFormat(out var _, out var _, out var _, out var _), "Failed to call `getFormat`"))
			{
				return null;
			}
			if (!Check(coreSystem.recordStart(_deviceID, _sound, loop: true), "Failed to call `recordStart`"))
			{
				return null;
			}
			IsRecording = true;
			_lastRecordPos = 0u;
			Log.Info("Began mic capture (SampleRate:{0}Hz, ChannelCount:{1}, Device:'{2}')", item, item2, _deviceName);
			return _format;
		}

		private static int? ChooseAudioDevice([CanBeNull] string name, out string fullName)
		{
			FMOD.System coreSystem = RuntimeManager.CoreSystem;
			coreSystem.getRecordNumDrivers(out var numdrivers, out var numconnected);
			fullName = null;
			if (numdrivers == 0)
			{
				return null;
			}
			(int, string)? tuple = null;
			for (int i = 0; i < numdrivers; i++)
			{
				if (coreSystem.getRecordDriverInfo(i, out var text, 128, out var _, out numconnected, out var _, out var _, out var state) != RESULT.OK)
				{
					continue;
				}
				if (i == 0)
				{
					tuple = (i, text);
				}
				if (!state.HasFlag(DRIVER_STATE.CONNECTED))
				{
					continue;
				}
				if (state.HasFlag(DRIVER_STATE.DEFAULT))
				{
					tuple = (i, text);
					if (name == null)
					{
						fullName = text;
						return i;
					}
				}
				if (text.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					fullName = text;
					return i;
				}
			}
			if (tuple.HasValue)
			{
				fullName = tuple.Value.Item2;
				return tuple.Value.Item1;
			}
			fullName = null;
			return null;
		}

		private static (int rate, int channels) GetDeviceInfo(int id)
		{
			RuntimeManager.CoreSystem.getRecordDriverInfo(id, out var _, 0, out var _, out var systemrate, out var _, out var speakermodechannels, out var _);
			return (rate: systemrate, channels: speakermodechannels);
		}

		public void StopCapture()
		{
			if (IsRecording)
			{
				RuntimeManager.CoreSystem.recordStop(_deviceID);
			}
			if (_sound.hasHandle())
			{
				_sound.release();
			}
			_sound = default(Sound);
		}

		private void OnDestroy()
		{
			if (_sound.hasHandle())
			{
				_sound.release();
			}
			_sound = default(Sound);
		}

		public void Subscribe(IMicrophoneSubscriber listener)
		{
			lock (_subscribers)
			{
				_subscribers.Add(listener);
			}
		}

		public bool Unsubscribe(IMicrophoneSubscriber listener)
		{
			lock (_subscribers)
			{
				return _subscribers.Remove(listener);
			}
		}

		public bool UpdateSubscribers()
		{
			if (!IsRecording)
			{
				return true;
			}
			if (RuntimeManager.CoreSystem.isRecording(_deviceID, out var recording) != RESULT.OK || !recording)
			{
				return true;
			}
			if (RuntimeManager.CoreSystem.getRecordPosition(_deviceID, out var position) != RESULT.OK)
			{
				return true;
			}
			uint num = ((position >= _lastRecordPos) ? (position - _lastRecordPos) : (position + _soundLength - _lastRecordPos));
			if (num == 0)
			{
				return false;
			}
			if (_sound.@lock(_lastRecordPos * 4, num * 4, out var ptr, out var ptr2, out var len, out var len2) != RESULT.OK)
			{
				return true;
			}
			_lastRecordPos = position;
			bool flag;
			try
			{
				if (ReadSamples(ptr, len))
				{
					return true;
				}
				if (ReadSamples(ptr2, len2))
				{
					return true;
				}
			}
			finally
			{
				flag = _sound.unlock(ptr, ptr2, len, len2) == RESULT.OK;
			}
			return !flag;
		}

		private unsafe bool ReadSamples(IntPtr ptr, uint ptrBytesLength)
		{
			if (ptrBytesLength == 0)
			{
				return false;
			}
			uint num = ptrBytesLength / 4;
			if (num > _buffer.Length)
			{
				Log.Error("Insufficient buffer space to pump microphone");
				return true;
			}
			fixed (float* destination = &_buffer[0])
			{
				Buffer.MemoryCopy(ptr.ToPointer(), destination, 4 * _buffer.Length, ptrBytesLength);
			}
			SendToSubscribers(new ArraySegment<float>(_buffer, 0, (int)num));
			return false;
		}

		private void SendToSubscribers(ArraySegment<float> data)
		{
			lock (_subscribers)
			{
				for (int i = 0; i < _subscribers.Count; i++)
				{
					_subscribers[i].ReceiveMicrophoneData(data, _format);
				}
			}
		}

		void IMicrophoneDeviceList.GetDevices(List<string> output)
		{
			GetDevices(output);
		}

		public static void GetDevices(List<string> output)
		{
			output.Clear();
			if (!Application.isPlaying)
			{
				return;
			}
			FMOD.System coreSystem = RuntimeManager.CoreSystem;
			coreSystem.getRecordNumDrivers(out var numdrivers, out var numconnected);
			if (numdrivers == 0)
			{
				return;
			}
			for (int i = 0; i < numdrivers; i++)
			{
				coreSystem.getRecordDriverInfo(i, out var item, 128, out var _, out numconnected, out var _, out var _, out var state);
				if (state.HasFlag(DRIVER_STATE.CONNECTED))
				{
					if (state.HasFlag(DRIVER_STATE.DEFAULT))
					{
						output.Insert(0, item);
					}
					else
					{
						output.Add(item);
					}
				}
			}
		}
	}
}
