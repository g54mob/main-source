using UnityEngine;

public class DaytimeSensitiveActivation : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public DayNightCycle.Timestate activeTime;

	public GameObject target;

	public void OnDawn_AfterSunrise()
	{
		if (activeTime == DayNightCycle.Timestate.Day)
		{
			target.SetActive(value: true);
		}
		else
		{
			target.SetActive(value: false);
		}
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDusk()
	{
		if (activeTime == DayNightCycle.Timestate.Night)
		{
			target.SetActive(value: true);
		}
		else
		{
			target.SetActive(value: false);
		}
	}

	private void Start()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		if (DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Day)
		{
			target.SetActive(activeTime == DayNightCycle.Timestate.Day);
		}
		else
		{
			target.SetActive(activeTime == DayNightCycle.Timestate.Night);
		}
	}

	public void OnDuskEarly()
	{
	}
}
