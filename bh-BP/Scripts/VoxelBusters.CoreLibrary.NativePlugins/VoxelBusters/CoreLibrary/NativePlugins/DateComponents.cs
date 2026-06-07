using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	[Serializable]
	public class DateComponents
	{
		[SerializeField]
		private Calendar m_calendar;

		[SerializeField]
		private int m_year;

		[SerializeField]
		private int m_month;

		[SerializeField]
		private int m_day;

		[SerializeField]
		private int m_hour;

		[SerializeField]
		private int m_minute;

		[SerializeField]
		private int m_second;

		[SerializeField]
		private int m_nanosecond;

		[SerializeField]
		private int m_weekday;

		[SerializeField]
		private int m_weekOfMonth;

		[SerializeField]
		private int m_weekOfYear;

		public Calendar Calendar
		{
			get
			{
				return default(Calendar);
			}
			set
			{
			}
		}

		public int Year
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Month
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Day
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Hour
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Minute
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Second
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Nanosecond
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Obsolete("Use DayOfWeek property instead", true)]
		public int Weekday
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int DayOfWeek
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int WeekOfMonth
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int WeekOfYear
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}
	}
}
