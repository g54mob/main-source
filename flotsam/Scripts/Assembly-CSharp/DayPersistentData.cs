using System;

[Serializable]
public class DayPersistentData
{
	public DailyReportPersistentData Report;

	public float CurrentTime;

	public DayPersistentData(Day day)
	{
		Report = new DailyReportPersistentData(day.Report);
		CurrentTime = day.CurrentTime;
	}

	public Day ReturnRestored(float dayTimeLength, float nightTimeLength)
	{
		return new Day(dayTimeLength, nightTimeLength, this);
	}
}
