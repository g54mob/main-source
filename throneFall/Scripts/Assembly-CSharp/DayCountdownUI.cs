using TMPro;
using UnityEngine;

public class DayCountdownUI : MonoBehaviour
{
	public GameObject parentToToggle;

	public TextMeshProUGUI clockText;

	private DayNightCycle dayNightCycle;

	private void Start()
	{
		dayNightCycle = DayNightCycle.Instance;
	}

	private string FormatTime(float timeInSeconds)
	{
		timeInSeconds = Mathf.Max(0f, timeInSeconds);
		int num = Mathf.FloorToInt(timeInSeconds);
		int num2 = num / 60;
		int num3 = num % 60;
		return $"{num2}:{num3:D2}";
	}

	private void Update()
	{
		bool flag = false;
		float num = 0f;
		if (dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day)
		{
			flag = dayNightCycle.AutomatedDaytime;
			num = dayNightCycle.RemainingAutoDayTime;
		}
		else
		{
			flag = dayNightCycle.AutomatedNighttime;
			num = dayNightCycle.RemainingAutoNightTime;
		}
		if (flag != parentToToggle.activeSelf)
		{
			parentToToggle.SetActive(flag);
		}
		if (flag)
		{
			clockText.text = FormatTime(num);
		}
	}
}
