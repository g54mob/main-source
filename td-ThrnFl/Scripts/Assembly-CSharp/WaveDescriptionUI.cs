using UnityEngine;

public class WaveDescriptionUI : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public GameObject waveDescriptionPanel;

	private void Start()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		waveDescriptionPanel.SetActive(DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Day);
	}

	public void OnDawn_AfterSunrise()
	{
		waveDescriptionPanel.SetActive(value: true);
	}

	public void OnDusk()
	{
		waveDescriptionPanel.SetActive(value: false);
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDuskEarly()
	{
	}
}
