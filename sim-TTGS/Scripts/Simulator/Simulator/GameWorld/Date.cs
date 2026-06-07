using System;

namespace Simulator.GameWorld
{
	[Serializable]
	public struct Date
	{
		public int year;

		public int month;

		public int day;

		public Date(int year, int month, int day)
		{
			this.year = year;
			this.month = month;
			this.day = day;
		}

		public override string ToString()
		{
			return day.ToString("00") + "/" + month.ToString("00") + "/" + year.ToString("0000");
		}

		public Date Tomorrow()
		{
			int num = year;
			int num2 = month;
			int num3 = day;
			switch (month)
			{
			case 1:
			case 3:
			case 5:
			case 7:
			case 8:
			case 10:
				if (day < 31)
				{
					num3++;
					break;
				}
				num3 = 1;
				num2++;
				break;
			case 12:
				if (day < 31)
				{
					num3++;
					break;
				}
				num3 = 1;
				num2 = 1;
				num++;
				break;
			case 4:
			case 6:
			case 9:
			case 11:
				if (day < 30)
				{
					num3++;
					break;
				}
				num3 = 1;
				num2++;
				break;
			case 2:
				if (day < 28)
				{
					num3++;
					break;
				}
				if (day == 28 && year % 4 == 0)
				{
					num3++;
					break;
				}
				num3 = 1;
				num2++;
				break;
			}
			return new Date(num, num2, num3);
		}

		public Date Yesterday()
		{
			int num = year;
			int num2 = month;
			int num3 = day;
			switch (month)
			{
			case 2:
			case 4:
			case 6:
			case 8:
			case 9:
			case 11:
				if (day > 1)
				{
					num3--;
					break;
				}
				num3 = 31;
				num2--;
				break;
			case 1:
				if (day > 1)
				{
					num3--;
					break;
				}
				num3 = 31;
				num2 = 12;
				num--;
				break;
			case 5:
			case 7:
			case 10:
			case 12:
				if (day > 1)
				{
					num3--;
					break;
				}
				num3 = 30;
				num2--;
				break;
			case 3:
				if (day > 1)
				{
					num3--;
					break;
				}
				num3 = ((year % 4 == 0) ? 29 : 28);
				num2 = 2;
				break;
			}
			return new Date(num, num2, num3);
		}

		private static int GetDayInMonth(int month, int year)
		{
			switch (month)
			{
			case 1:
			case 3:
			case 5:
			case 7:
			case 8:
			case 10:
			case 12:
				return 31;
			case 4:
			case 6:
			case 9:
			case 11:
				return 30;
			case 2:
				if (year % 4 != 0)
				{
					return 28;
				}
				return 29;
			default:
				throw new ArgumentOutOfRangeException("month", "Invalid month value");
			}
		}

		public int GetTotalDays()
		{
			int num = 0;
			for (int i = 1; i < year; i++)
			{
				num += 365;
				if (i % 4 == 0)
				{
					num++;
				}
			}
			for (int j = 1; j < month; j++)
			{
				num += GetDayInMonth(j, year);
			}
			return num + day;
		}

		public static Date operator -(Date a, Date b)
		{
			return new Date(a.year - b.year, a.month - b.month, a.day - b.day);
		}
	}
}
