using System;

[Serializable]
public class WatchedSessionQuest
{
	private SessionQuest _003CSessionQuest_003Ek__BackingField;

	private int _003CWatchLevel_003Ek__BackingField;

	private bool _003CEffectWasWatched_003Ek__BackingField;

	public SessionQuest SessionQuest
	{
		get
		{
			return _003CSessionQuest_003Ek__BackingField;
		}
		private set
		{
			_003CSessionQuest_003Ek__BackingField = value;
		}
	}

	public int WatchLevel
	{
		get
		{
			return _003CWatchLevel_003Ek__BackingField;
		}
		private set
		{
			_003CWatchLevel_003Ek__BackingField = value;
		}
	}

	public bool EffectWasWatched
	{
		get
		{
			return _003CEffectWasWatched_003Ek__BackingField;
		}
		set
		{
			_003CEffectWasWatched_003Ek__BackingField = value;
		}
	}

	public WatchedSessionQuest(SessionQuest sessionQuest, int level, bool effectWasWatched = false)
	{
		SessionQuest = sessionQuest;
		WatchLevel = level;
		EffectWasWatched = effectWasWatched;
	}

	public void UpdateLevel(int newLevel)
	{
		WatchLevel = newLevel;
	}
}
