using System;
using System.Globalization;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public struct Date
	{
		[SerializeField]
		[Range(1f, 31f)]
		private byte _day;

		[SerializeField]
		[Range(1f, 12f)]
		private byte _month;

		[SerializeField]
		private uint _year;

		public byte Day => _day;

		public byte Month => _month;

		public uint Year => _year;

		public Date(byte p_startDay = 1, byte p_startMounth = 1, uint p_startYear = 1960u)
		{
			_day = p_startDay;
			_month = p_startMounth;
			_year = p_startYear;
		}

		public void AddDay()
		{
			switch (_month)
			{
			case 1:
			case 3:
			case 5:
			case 7:
			case 8:
			case 10:
			case 12:
				if (_day == 31)
				{
					StartNextMonth();
					return;
				}
				break;
			case 2:
				if (IsLeapYear())
				{
					if (_day == 29)
					{
						StartNextMonth();
						return;
					}
				}
				else if (_day == 28)
				{
					StartNextMonth();
					return;
				}
				break;
			case 4:
			case 6:
			case 9:
			case 11:
				if (_day == 30)
				{
					StartNextMonth();
					return;
				}
				break;
			}
			_day++;
		}

		public void StartNextMonth()
		{
			_day = 1;
			AddMonth();
		}

		public void AddMonth()
		{
			if (_month == 12)
			{
				_month = 1;
				AddYear();
			}
			else
			{
				_month++;
			}
		}

		public void AddYear()
		{
			_year++;
		}

		public bool IsLeapYear()
		{
			return _year % 4 == 0;
		}

		public readonly string ToStringEN()
		{
			return string.Format("{0} {1}", _day, CultureInfo.GetCultureInfo("en-GB").DateTimeFormat.GetAbbreviatedMonthName(_month).ToUpper());
		}
	}
}
