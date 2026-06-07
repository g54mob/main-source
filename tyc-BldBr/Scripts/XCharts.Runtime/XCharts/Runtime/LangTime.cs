using System;
using System.Collections.Generic;

namespace XCharts.Runtime
{
	[Serializable]
	public class LangTime
	{
		public List<string> months = new List<string>
		{
			"January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
			"November", "December"
		};

		public List<string> monthAbbr = new List<string>
		{
			"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct",
			"Nov", "Dec"
		};

		public List<string> dayOfMonth = new List<string>
		{
			"1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
			"11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
			"21", "22", "23", "24", "25", "26", "27", "28", "29", "30",
			"31"
		};

		public List<string> dayOfWeek = new List<string> { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

		public List<string> dayOfWeekAbbr = new List<string> { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
	}
}
