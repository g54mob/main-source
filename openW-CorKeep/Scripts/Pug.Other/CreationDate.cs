using System;
using System.Globalization;

[Serializable]
public class CreationDate
{
	public int year;

	public int month;

	public int day;

	public CreationDate(DateTime dateTime)
	{
		year = dateTime.Year;
		month = dateTime.Month - 1;
		day = dateTime.Day;
	}

	public override string ToString()
	{
		return new DateTime(year, month, day).ToString(CultureInfo.InvariantCulture);
	}
}
