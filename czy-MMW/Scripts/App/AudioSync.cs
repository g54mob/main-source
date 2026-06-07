public class AudioSync
{
	private AudioSyncState _nextSyncState;

	private bool _isSyncForced;

	private double _lastPulseTime = -1.0;

	private double _lastPulsePeriod = -1.0;

	private float _gamePulseProgress;

	public AudioSyncState State { get; private set; }

	public bool IsSynced => State == AudioSyncState.Synced;

	public void StartClock()
	{
		State = AudioSyncState.WaitForFirstPulse;
		_nextSyncState = AudioSyncState.StartClock;
		_isSyncForced = false;
		_lastPulseTime = -1.0;
		_lastPulsePeriod = -1.0;
	}

	public void ResumeClock(float gamePulseProgress)
	{
		if (State != AudioSyncState.WaitForFirstPulse)
		{
			State = AudioSyncState.ResumeClock;
		}
		else
		{
			_nextSyncState = AudioSyncState.ResumeClock;
		}
		_gamePulseProgress = gamePulseProgress;
		_isSyncForced = false;
	}

	public void SyncTimeInterval(TimeInterval time, double nextPulseTime, IAudioSystem audioSystem)
	{
		if (!audioSystem.RequiresSync)
		{
			return;
		}
		float num = time.UnsyncedDelta;
		double dspTime = audioSystem.DspTime;
		double pulsePeriod = audioSystem.PulsePeriod;
		if (State == AudioSyncState.WaitForFirstPulse || State == AudioSyncState.StartClock)
		{
			if (nextPulseTime >= 0.0)
			{
				if (dspTime >= nextPulseTime)
				{
					if (State == AudioSyncState.WaitForFirstPulse)
					{
						num = 0f;
						State = _nextSyncState;
					}
					else
					{
						num = (float)(dspTime - nextPulseTime);
						State = AudioSyncState.Synced;
						nextPulseTime = -1.0;
					}
				}
				else
				{
					num = 0f;
				}
			}
			else
			{
				num = 0f;
			}
		}
		if (State == AudioSyncState.ResumeClock && _lastPulseTime >= 0.0)
		{
			float num2 = (float)((dspTime - _lastPulseTime) / _lastPulsePeriod);
			if (_gamePulseProgress > num2)
			{
				num = 0f;
				_isSyncForced = true;
			}
			else
			{
				float num3 = (num2 - _gamePulseProgress) * (float)pulsePeriod;
				if (_isSyncForced || num3 <= num * 2f)
				{
					num = num3;
					time.IsPaused = false;
					State = AudioSyncState.Scale;
					_isSyncForced = false;
				}
				else
				{
					num = 0f;
				}
			}
		}
		else if (State == AudioSyncState.Scale)
		{
			TimeScale activePulseTimeScale = audioSystem.ActivePulseTimeScale;
			if (activePulseTimeScale != time.Scale)
			{
				num /= time.Scale.Scale;
				num *= activePulseTimeScale.Scale;
			}
			else
			{
				State = AudioSyncState.Synced;
			}
		}
		if (nextPulseTime >= 0.0 && dspTime >= nextPulseTime)
		{
			if (State == AudioSyncState.ResumeClock)
			{
				_isSyncForced = true;
			}
			_lastPulseTime = nextPulseTime;
			_lastPulsePeriod = pulsePeriod;
			nextPulseTime = -1.0;
		}
		time.Delta = num;
	}
}
