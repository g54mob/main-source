using UnityEngine;

public class TimeController : MonoBehaviour
{
	public delegate void OnEndOfTheDay();

	public static TimeController instance;

	public float secondsInFullDay;

	[Range(0f, 1f)]
	public float currentTimeOfDay;

	[SerializeField]
	private float timeMultiplier;

	public static OnEndOfTheDay onEndOfTheDayCallback;

	public int day;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public bool TimeIsBetween(float startHour, float endHour)
	{
		return false;
	}

	public float CurrentTimeInHours()
	{
		return 0f;
	}

	public int HoursFromDate(float _time, int _day)
	{
		return 0;
	}

	private void OnDisable()
	{
	}
}
