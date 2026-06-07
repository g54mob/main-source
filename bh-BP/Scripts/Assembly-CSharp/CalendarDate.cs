using System;

[Serializable]
public class CalendarDate
{
	public int Year;

	public int Month;

	public int Day;

	public CalendarDate(int yr, int mn, int dy)
	{
	}

	public CalendarDate(DateTime dt)
	{
	}

	public CalendarDate(CalendarDate toCopy)
	{
	}

	public CalendarDate(string str)
	{
	}

	public TimeState GetStateTo(CalendarDate other)
	{
		return default(TimeState);
	}

	public bool IsSame(CalendarDate other)
	{
		return false;
	}

	public override string ToString()
	{
		return null;
	}

	public DateTime ToDateTime()
	{
		return default(DateTime);
	}

	public static CalendarDate Now()
	{
		return null;
	}

	public void AddDays(int days)
	{
	}
}
