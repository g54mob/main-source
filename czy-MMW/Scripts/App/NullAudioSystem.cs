using System;
using System.Collections.Generic;
using GAudio;
using Motorways;
using Motorways.Audio;
using UnityEngine;

public class NullAudioSystem : IAudioSystem
{
	public double DspTime => AudioSettings.dspTime;

	public double PulsePeriod => 5.0 / 6.0;

	public TimeScale ActivePulseTimeScale => TimeScale.Single;

	public TimeScale ScheduledPulseTimeScale { get; set; }

	public bool RequiresSync => false;

	public AudioDatabase Database => null;

	public bool RequiresVolumeControl => true;

	public event Action<double, int, int> SignalPulse;

	public void UpdateVolume(int index)
	{
	}

	public bool Start(bool isAudioRunning)
	{
		return true;
	}

	public void Tick()
	{
	}

	public void ScheduleEvent(AudioEvent audioEvent)
	{
	}

	public AudioLoadout GetLoadout(string loadoutId)
	{
		return null;
	}

	public List<AudioEvent> GetEvents(double fromDspTime, int minId, AudioEventFilter filter, City city = null)
	{
		return new List<AudioEvent>();
	}

	public AudioSample GetSample(IGATDataOwner sampleData)
	{
		return null;
	}

	public int AddAudioEventListener(AudioSystem.SignalAudioEventScheduled signal, AudioEventFilter filter)
	{
		return -1;
	}

	public void RemoveAudioEventListener(int listenerId)
	{
	}

	public NullAudioSystem()
	{
		AudioSystem.Hack_DontCallSetAudioSystem(this);
	}
}
