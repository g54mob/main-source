using System;
using System.Collections.Generic;

public class AbilityClock
{
	public int duration;

	public int elapsed;

	public bool cannotBeCleared;

	private static Dictionary<string, AbilityClock> sharedClocks = new Dictionary<string, AbilityClock>();

	protected static List<AbilityClock> activeClocks = new List<AbilityClock>();

	public event Action<AbilityClock> OnComplete;

	public static bool HasClockForAbility(string abilityId)
	{
		return sharedClocks.ContainsKey(abilityId);
	}

	public static AbilityClock GetClockForAbility(string abilityId)
	{
		if (sharedClocks.ContainsKey(abilityId))
		{
			return sharedClocks[abilityId];
		}
		AbilityClock abilityClock = new AbilityClock();
		sharedClocks[abilityId] = abilityClock;
		return abilityClock;
	}

	public void Play()
	{
		if (!activeClocks.Contains(this))
		{
			activeClocks.Add(this);
			elapsed = 0;
		}
	}

	public float GetPercent()
	{
		if (duration <= 0)
		{
			return 1f;
		}
		return (float)elapsed / (float)duration;
	}

	private void Tic()
	{
		if (elapsed >= duration)
		{
			return;
		}
		elapsed++;
		if (elapsed == duration)
		{
			if (this.OnComplete != null)
			{
				this.OnComplete(this);
			}
			activeClocks.Remove(this);
		}
	}

	public static void UpdateTic()
	{
		for (int i = 0; i < activeClocks.Count; i++)
		{
			activeClocks[i].Tic();
		}
	}

	public static void ClearAll()
	{
		for (int num = activeClocks.Count - 1; num >= 0; num--)
		{
			AbilityClock abilityClock = activeClocks[num];
			if (!abilityClock.cannotBeCleared)
			{
				abilityClock.elapsed = abilityClock.duration;
				activeClocks.RemoveAt(num);
			}
		}
	}
}
