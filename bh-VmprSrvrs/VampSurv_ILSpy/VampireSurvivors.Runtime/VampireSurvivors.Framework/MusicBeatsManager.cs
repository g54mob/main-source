using Zenject;

namespace VampireSurvivors.Framework;

public class MusicBeatsManager
{
	private SignalBus _signalBus;

	public void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	public void RegisterBeatEvent(MusicBeatsEvent ev)
	{
	}

	private void _registerBeatEvent(MusicBeatsEvent ev)
	{
	}
}
