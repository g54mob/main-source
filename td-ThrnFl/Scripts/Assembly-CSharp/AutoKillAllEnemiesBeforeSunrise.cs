using UnityEngine;

public class AutoKillAllEnemiesBeforeSunrise : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	private void Start()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
		Hp.KillAllEnemyUnits();
	}

	public void OnDusk()
	{
	}

	public void OnDuskEarly()
	{
	}
}
