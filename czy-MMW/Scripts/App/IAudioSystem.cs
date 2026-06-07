using System;
using System.Collections.Generic;
using GAudio;
using Motorways;
using Motorways.Audio;

public interface IAudioSystem
{
	double DspTime { get; }

	double PulsePeriod { get; }

	TimeScale ActivePulseTimeScale { get; }

	TimeScale ScheduledPulseTimeScale { get; set; }

	bool RequiresSync { get; }

	AudioDatabase Database { get; }

	bool RequiresVolumeControl { get; }

	event Action<double, int, int> SignalPulse;

	void UpdateVolume(int option);

	bool Start(bool isAudioRunning);

	void Tick();

	void ScheduleEvent(AudioEvent audioEvent);

	AudioLoadout GetLoadout(string loadoutId);

	List<AudioEvent> GetEvents(double fromDspTime, int minId, AudioEventFilter filter, City city = null);

	AudioSample GetSample(IGATDataOwner sampleData);

	int AddAudioEventListener(AudioSystem.SignalAudioEventScheduled signal, AudioEventFilter filter);

	void RemoveAudioEventListener(int listenerId);
}
