using UnityEngine;

public class Day
{
	public enum E_DayTime
	{
		Day = 0,
		Night = 1
	}

	public DailyReport Report { get; private set; }

	public float NormalizedDayProgress => CurrentTime / DayLength;

	public float CurrentTime { get; private set; }

	public int CurrentHour { get; private set; }

	public float DayLength { get; private set; }

	public float DaytimeLength { get; private set; }

	public float NighttimeLength { get; private set; }

	public float HourLength { get; private set; }

	public E_DayTime DayTime { get; private set; }

	public Day(float dayLength, float nightLength, int _hoursPerDay)
	{
		DayLength = dayLength + nightLength;
		DaytimeLength = dayLength;
		NighttimeLength = nightLength;
		HourLength = DayLength / (float)_hoursPerDay;
		Report = new DailyReport();
		Report.Start();
		CurrentTime = 0f;
		SetDayTime(E_DayTime.Day);
	}

	public Day(float dayLength, float nightLength, DayPersistentData data)
	{
		DayLength = dayLength + nightLength;
		DaytimeLength = dayLength;
		NighttimeLength = nightLength;
		Report = new DailyReport(data.Report);
		CurrentTime = data.CurrentTime;
		if (CurrentTime <= dayLength)
		{
			DayTime = E_DayTime.Day;
		}
		else
		{
			DayTime = E_DayTime.Night;
		}
	}

	public bool ProgressCycle(float deltaTime)
	{
		CurrentTime += deltaTime;
		CurrentHour = Mathf.FloorToInt(CurrentTime / HourLength);
		if (CurrentTime > DayLength)
		{
			return true;
		}
		UpdateDayTime();
		return false;
	}

	public void Finish()
	{
		Report.Finish();
	}

	public void SetPercentualTime(float percentage)
	{
		if (!(percentage > 1f))
		{
			float num = (CurrentTime = Mathf.Lerp(0f, DayLength, percentage));
			CurrentHour = Mathf.FloorToInt(num / HourLength);
			UpdateDayTime();
		}
	}

	private void SetDayTime(E_DayTime daytime)
	{
		DayTime = daytime;
		switch (daytime)
		{
		case E_DayTime.Day:
			new GameEvent(GameEventType.DaytimeStarted).Dispatch();
			break;
		case E_DayTime.Night:
			new GameEvent(GameEventType.NighttimeStarted).Dispatch();
			break;
		}
	}

	private void UpdateDayTime()
	{
		switch (DayTime)
		{
		case E_DayTime.Day:
			if (CurrentTime > DaytimeLength)
			{
				SetDayTime(E_DayTime.Night);
			}
			break;
		case E_DayTime.Night:
			if (CurrentTime < DaytimeLength)
			{
				SetDayTime(E_DayTime.Day);
			}
			break;
		}
	}
}
