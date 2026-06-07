using System;
using System.Collections.Generic;
using Factory;
using GAudio;
using UnityEngine;

namespace Motorways.Audio
{
	public class AudioSystem : IAudioSystem, IGATPulseClient
	{
		public delegate void SignalAudioEventScheduled(AudioEvent scheduledAudioEvent);

		private struct AudioEventListener
		{
			public int id;

			public SignalAudioEventScheduled signal;

			public AudioEventFilter filter;

			private static int nextId = 1;

			public AudioEventListener(SignalAudioEventScheduled signal, AudioEventFilter filter)
			{
				id = nextId++;
				this.signal = signal;
				this.filter = filter;
			}
		}

		private AudioDatabase audioDatabase;

		private bool m_isRunning;

		private MasterPulseModule masterPulse;

		private double defaultPulsePeriod;

		private int pulseLoopCount;

		private TimeScale pulseTimeScale = TimeScale.Single;

		private List<AudioEvent> queriedEvents = new List<AudioEvent>();

		private List<AudioEvent> events = new List<AudioEvent>();

		public List<AudioSample> PlayingSamples = new List<AudioSample>(200);

		private List<AudioSample> freeSamples = new List<AudioSample>(200);

		private float pulseLatency;

		private double lastDspTime;

		private int pausedDspFrameCount;

		private double nextFakePulse = 5.0 / 6.0;

		private double fakeDspTime;

		private int fakePulseCount;

		private const double FAKE_PULSE_LATENCY = 0.10000000149011612;

		private const double FAKE_PULSE_PERIOD = 5.0 / 6.0;

		private const int SkippedDspFrameThreshold = 90;

		public static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("Audio");

		public static AudioMixbus Mixbus;

		private List<AudioEventListener> audioEventListeners = new List<AudioEventListener>();

		private static IAudioSystem instance;

		[Dependency]
		private ActivePlayer _player;

		public float PulseLatency => pulseLatency;

		public TimeScale ScheduledPulseTimeScale
		{
			get
			{
				return pulseTimeScale;
			}
			set
			{
				if (pulseTimeScale != value)
				{
					pulseTimeScale = value;
					if (masterPulse != null)
					{
						masterPulse.NewPeriod = defaultPulsePeriod / (double)pulseTimeScale.Scale;
					}
				}
			}
		}

		public TimeScale ActivePulseTimeScale
		{
			get
			{
				if (masterPulse == null)
				{
					return pulseTimeScale;
				}
				return TimeScale.FromScale((float)(defaultPulsePeriod / masterPulse.Period));
			}
		}

		public int SampleCount => PlayingSamples.Count;

		public double PulsePeriod
		{
			get
			{
				if (masterPulse == null)
				{
					return 5.0 / 6.0 / (double)pulseTimeScale.Scale;
				}
				return masterPulse.Period;
			}
		}

		public bool RequiresSync => true;

		public double DspTime
		{
			get
			{
				if (!(masterPulse != null))
				{
					return fakeDspTime;
				}
				return AudioSettings.dspTime;
			}
		}

		public AudioDatabase Database => audioDatabase;

		public virtual bool RequiresVolumeControl => true;

		public bool IsRunning => m_isRunning;

		public static IAudioSystem Instance => instance;

		public event Action<double, int, int> SignalPulse;

		public bool Start(bool isAudioRunning)
		{
			Log.IsMuted = true;
			m_isRunning = true;
			_player.DataChanged += OnSaveDataChanged;
			Log.Info("AudioSystem: Starting. Sample rate: {0} kHz.", AudioSettings.outputSampleRate);
			audioDatabase = new AudioDatabase();
			Mixbus = new AudioMixbus();
			AudioPlayer.Default = new AudioPlayer("Default");
			AudioPlayer.UI = new AudioPlayer("UI");
			if (isAudioRunning && !audioDatabase.LoadBanks())
			{
				Log.Warn("AudioSystem: Failed to load sample banks, disabling audio.");
				isAudioRunning = false;
			}
			if (isAudioRunning)
			{
				audioDatabase.LoadLoadouts();
				masterPulse = audioDatabase.MasterPulse;
				if (masterPulse != null)
				{
					defaultPulsePeriod = masterPulse.Period;
					MasterPulseModule masterPulseModule = masterPulse;
					masterPulseModule.onWillPulse = (PulseModule.OnPulseHandler)Delegate.Combine(masterPulseModule.onWillPulse, new PulseModule.OnPulseHandler(OnWillPulse));
					masterPulse.SubscribeToPulse(this);
					pulseLatency = (float)GATManager.UniqueInstance.PulseLatency * 1.5f;
				}
				else
				{
					Log.Warn("AudioSystem: Failed to subscribe to master pulse.");
				}
			}
			else
			{
				pulseLatency = 0.15f;
			}
			return true;
		}

		public void Stop()
		{
			AudioPlayer.Default?.GAT.Stop();
			AudioPlayer.UI?.GAT.Stop();
		}

		public void Tick()
		{
			if (masterPulse != null)
			{
				if (Math.Abs(lastDspTime - DspTime) < 1E-05)
				{
					pausedDspFrameCount++;
					if (pausedDspFrameCount >= 90)
					{
						Log.Warn("AudioSystem: Audio thread halted, faking DSP clock from now on.");
						MasterPulseModule masterPulseModule = masterPulse;
						masterPulseModule.onWillPulse = (PulseModule.OnPulseHandler)Delegate.Remove(masterPulseModule.onWillPulse, new PulseModule.OnPulseHandler(OnWillPulse));
						masterPulse.UnsubscribeToPulse(this);
						masterPulse = null;
						fakeDspTime = lastDspTime;
					}
				}
				else
				{
					pausedDspFrameCount = 0;
				}
				lastDspTime = DspTime;
			}
			else
			{
				fakeDspTime += Time.deltaTime;
				while (fakeDspTime >= nextFakePulse - 0.10000000149011612)
				{
					this.SignalPulse?.Invoke(nextFakePulse, fakePulseCount % 12, fakePulseCount);
					nextFakePulse += 5.0 / 6.0 / (double)pulseTimeScale.Scale;
					fakePulseCount++;
				}
			}
			double num = DspTime - 1.0;
			int i;
			for (i = 0; i < events.Count && events[i].DspTime < num; i++)
			{
			}
			if (i > 0)
			{
				events.RemoveRange(0, i);
			}
			int num2 = 0;
			while (num2 < PlayingSamples.Count)
			{
				AudioSample audioSample = PlayingSamples[num2];
				if (audioSample.CanRecycle)
				{
					audioSample.Recycle();
					PlayingSamples.RemoveAt(num2);
				}
				else
				{
					num2++;
				}
			}
		}

		private void OnSaveDataChanged()
		{
			bool flag = _player.Soundscape == 0;
			UpdateVolume((!flag) ? _player.VolumeSetting : 0);
			if (_player.Soundscape == 1)
			{
				if ((Get.State & StateType.Minimal) == 0)
				{
					Get.State |= StateType.Minimal;
					ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.AudioMinimized));
				}
			}
			else
			{
				Get.State &= ~StateType.Minimal;
			}
		}

		public void UpdateVolume(int index)
		{
			switch (index)
			{
			case 0:
				Mixbus.Volume = -80f;
				break;
			case 1:
				Mixbus.Volume = -20f;
				break;
			case 2:
				Mixbus.Volume = -10f;
				break;
			case 3:
				Mixbus.Volume = 0f;
				break;
			default:
				Mixbus.Volume = 0f;
				break;
			}
		}

		public AudioSample GetSample(IGATDataOwner sampleData)
		{
			AudioSample audioSample;
			if (freeSamples.Count > 0)
			{
				audioSample = freeSamples[freeSamples.Count - 1];
				freeSamples.RemoveAt(freeSamples.Count - 1);
			}
			else
			{
				audioSample = new AudioSample();
			}
			audioSample.Initialise(sampleData);
			PlayingSamples.Add(audioSample);
			return audioSample;
		}

		public void ScheduleEvent(AudioEvent audioEvent)
		{
			if (audioEvent == null)
			{
				return;
			}
			events.Add(audioEvent);
			try
			{
				int count = audioEventListeners.Count;
				for (int i = 0; i < count; i++)
				{
					AudioEventListener audioEventListener = audioEventListeners[i];
					if (audioEventListener.filter.IsEventFiltered(audioEvent))
					{
						audioEventListener.signal(audioEvent);
					}
				}
			}
			catch (Exception ex)
			{
				Log.Error("Hit exception {0} while signalling audio event {1} to listeners.", ex, audioEvent);
			}
		}

		public int AddAudioEventListener(SignalAudioEventScheduled signal, AudioEventFilter filter)
		{
			audioEventListeners.Add(new AudioEventListener(signal, filter));
			return audioEventListeners[audioEventListeners.Count - 1].id;
		}

		public void RemoveAudioEventListener(int listenerId)
		{
			for (int i = 0; i < audioEventListeners.Count; i++)
			{
				if (audioEventListeners[i].id == listenerId)
				{
					audioEventListeners.RemoveAt(i);
					break;
				}
			}
		}

		public List<AudioEvent> GetEvents(double fromDspTime, int minId, AudioEventFilter filter, City city = null)
		{
			queriedEvents.Clear();
			int i;
			for (i = 0; i < events.Count && events[i].Id < minId; i++)
			{
			}
			for (; i < events.Count; i++)
			{
				if (filter.IsEventFiltered(events[i]))
				{
					City city2 = events[i].City;
					if (city2 == null || city == null || city2 == city)
					{
						queriedEvents.Add(events[i]);
					}
				}
			}
			return queriedEvents;
		}

		public void OnWillPulse(IGATPulseInfo pulseInfo)
		{
			ScheduleEvent(AudioEvent.CreateEvent(pulseInfo.PulseDspTime, AudioEventType.Pulse));
		}

		public void OnPulse(IGATPulseInfo pulseInfo)
		{
			if (pulseInfo.StepIndex == 0)
			{
				pulseLoopCount++;
			}
			this.SignalPulse?.Invoke(pulseInfo.PulseDspTime, pulseInfo.StepIndex, pulseLoopCount * Database.MasterPulse.Steps.Length + pulseInfo.StepIndex);
			fakePulseCount = pulseInfo.StepIndex;
			nextFakePulse = pulseInfo.PulseDspTime + 5.0 / 6.0;
		}

		public void PulseStepsDidChange(bool[] newSteps)
		{
		}

		public AudioLoadout GetLoadout(string loadoutId)
		{
			if (audioDatabase == null)
			{
				return null;
			}
			return audioDatabase.GetLoadout(loadoutId);
		}

		public AudioSystem()
		{
			if (Diagnostics.Verify(instance == null))
			{
				instance = this;
			}
		}

		public static void Hack_DontCallSetAudioSystem(NullAudioSystem nullAudioSystem)
		{
			instance = nullAudioSystem;
		}
	}
}
