using System;

namespace App.Data
{
	public class DateEvent : BaseKeyData
	{
		public int DateIn;

		public int DateOut;

		public string Achievement;

		public bool IsValid()
		{
			int dayOfYear = DateTime.UtcNow.DayOfYear;
			try
			{
				dayOfYear = DateTime.Now.DayOfYear;
			}
			catch
			{
			}
			if (dayOfYear >= DateIn)
			{
				return dayOfYear <= DateOut;
			}
			return false;
		}
	}
}
