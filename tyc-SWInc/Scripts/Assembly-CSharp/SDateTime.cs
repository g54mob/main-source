using System;
using System.IO;
using System.Text;
using UnityEngine;

[Serializable]
public struct SDateTime : IComparable<SDateTime>, IByteData
{
	public static string[] Months = new string[12]
	{
		"January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
		"November", "December"
	};

	public const int BaseYear = 1900;

	public static bool AMPM = false;

	public readonly int Minute;

	public readonly int Hour;

	public readonly int Month;

	public readonly int Year;

	public readonly int Day;

	public int RealYear
	{
		get
		{
			return Year + 1900;
		}
	}

	public float HourFraction
	{
		get
		{
			return (float)Hour + (float)Minute / 60f;
		}
	}

	public SDateTime(int month, int year)
		: this(0, 0, month, year)
	{
	}

	public SDateTime(int day, int month, int year)
		: this(0, 0, day, month, year)
	{
	}

	public SDateTime(int baseYear)
	{
		Minute = 0;
		Hour = 0;
		Day = 0;
		Month = 0;
		Year = baseYear - 1900;
	}

	public void WriteData(Stream st)
	{
		st.WriteByte((byte)Minute);
		st.WriteByte((byte)Hour);
		st.WriteByte((byte)Month);
		st.WriteByte((byte)Day);
		st.WriteUShort((ushort)Year);
	}

	public static SDateTime ReadData(Stream st)
	{
		int minute = st.ReadByte();
		int hour = st.ReadByte();
		int month = st.ReadByte();
		int day = st.ReadByte();
		uint year = st.ReadUShort();
		return new SDateTime(minute, hour, day, month, (int)year);
	}

	public uint ConvertToUint()
	{
		return (uint)(((((((((Minute & 0x3F) << 5) | (Hour & 0x1F)) << 4) | (Month & 0xF)) << 5) | (Day & 0x1F)) << 12) | (Year & 0xFFF));
	}

	public static SDateTime ConvertFromUint(uint val)
	{
		uint year = val & 0xFFF;
		val >>= 12;
		uint day = val & 0x1F;
		val >>= 5;
		uint month = val & 0xF;
		val >>= 4;
		uint hour = val & 0x1F;
		val >>= 5;
		return new SDateTime((int)val, (int)hour, (int)day, (int)month, (int)year);
	}

	public SDateTime(int minute, int hour, int month, int year)
		: this(minute, hour, 0, month, year)
	{
	}

	public SDateTime(int minute, int hour, int day, int month, int year)
	{
		FixCounter(ref minute, ref hour, 60);
		FixCounter(ref hour, ref day, 24);
		FixCounter(ref day, ref month, GameSettings.DaysPerMonth);
		FixCounter(ref month, ref year, 12);
		Minute = minute;
		Hour = hour;
		Day = day;
		Month = month;
		Year = year;
	}

	public SDateTime(float h, int day, int month, int year)
	{
		int postCount = Mathf.FloorToInt(h);
		int count = Mathf.FloorToInt((h - (float)postCount) * 60f);
		FixCounter(ref count, ref postCount, 60);
		FixCounter(ref postCount, ref day, 24);
		FixCounter(ref day, ref month, GameSettings.DaysPerMonth);
		FixCounter(ref month, ref year, 12);
		Minute = count;
		Hour = postCount;
		Day = day;
		Month = month;
		Year = year;
	}

	private static void FixCounter(ref int count, ref int postCount, int interval)
	{
		if (count >= interval)
		{
			postCount += count / interval;
			count %= interval;
		}
		else if (count < 0)
		{
			postCount -= -count / interval + 1;
			count = interval - -count % interval;
			if (count == interval)
			{
				postCount++;
				count = 0;
			}
		}
	}

	public int ToInt()
	{
		return Minute + (Hour + (Day + (Month + Year * 12) * GameSettings.DaysPerMonth) * 24) * 60;
	}

	public float ToFloat()
	{
		return ((((float)Minute / 60f + (float)Hour) / 24f + (float)Day) / (float)GameSettings.DaysPerMonth + (float)Month) / 12f + (float)Year;
	}

	public static SDateTime Lerp(SDateTime start, SDateTime end, float t)
	{
		return FromInt(Mathf.RoundToInt(Mathf.Lerp(start.ToInt(), end.ToInt(), t)));
	}

	public static SDateTime FromInt(int d)
	{
		return FromInt(d, GameSettings.Instance.IsReferenceNull() ? GameData.DaysPerMonth : GameSettings.DaysPerMonth);
	}

	public static SDateTime FromInt(int d, int dpm)
	{
		return new SDateTime(d % 60, d / 60 % 24, d / 1440 % dpm, d / (60 * dpm * 24) % 12, d / (60 * dpm * 24 * 12));
	}

	public static SDateTime GetMinutes(float min)
	{
		return new SDateTime(Mathf.RoundToInt(min), 0, 0, 0, 0);
	}

	public static SDateTime GetHourMinutes(int hour, int min)
	{
		return new SDateTime(min, hour, 0, 0, 0);
	}

	public static SDateTime GetHour(int hour)
	{
		return new SDateTime(0, hour, 0, 0, 0);
	}

	public static SDateTime GetHour(float hour)
	{
		int num = Mathf.FloorToInt(hour);
		return new SDateTime(Mathf.RoundToInt((hour - (float)num) * 60f), num, 0, 0, 0);
	}

	public static SDateTime GetDay(int day)
	{
		return new SDateTime(0, 0, day, 0, 0);
	}

	public static SDateTime GetMonth(int month)
	{
		return new SDateTime(0, 0, 0, month, 0);
	}

	public static SDateTime GetYear(int year)
	{
		return new SDateTime(0, 0, 0, 0, year);
	}

	public static SDateTime operator -(SDateTime d1, SDateTime d2)
	{
		return FromInt(d1.ToInt() - d2.ToInt());
	}

	public static SDateTime operator -(SDateTime d1, int n)
	{
		return d1 - new SDateTime(n, 0);
	}

	public static SDateTime operator +(SDateTime d1, int n)
	{
		return d1 + new SDateTime(n, 0);
	}

	public static SDateTime operator +(SDateTime d1, double n)
	{
		return d1 + (float)n;
	}

	public static SDateTime operator +(SDateTime d1, float n)
	{
		if (Mathf.Approximately(n, 0f))
		{
			return d1;
		}
		bool num = n < 0f;
		if (num)
		{
			n = 0f - n;
		}
		int num2 = Mathf.FloorToInt(n);
		n = (n - (float)num2) * (float)GameSettings.DaysPerMonth;
		int num3 = Mathf.FloorToInt(n);
		n = (n - (float)num3) * 24f;
		int num4 = Mathf.FloorToInt(n);
		n = (n - (float)num4) * 60f;
		SDateTime sDateTime = new SDateTime(Mathf.RoundToInt(n), num4, num3, num2, 0);
		if (!num)
		{
			return d1 + sDateTime;
		}
		return d1 - sDateTime;
	}

	public static SDateTime operator -(SDateTime d1, float n)
	{
		return d1 + (0f - n);
	}

	public static bool operator <(SDateTime d1, SDateTime d2)
	{
		return d1.ToInt() < d2.ToInt();
	}

	public static bool operator <=(SDateTime d1, SDateTime d2)
	{
		return d1.ToInt() <= d2.ToInt();
	}

	public static bool operator >(SDateTime d1, SDateTime d2)
	{
		return d1.ToInt() > d2.ToInt();
	}

	public static bool operator >=(SDateTime d1, SDateTime d2)
	{
		return d1.ToInt() >= d2.ToInt();
	}

	public static SDateTime operator +(SDateTime d1, SDateTime d2)
	{
		return FromInt(d1.ToInt() + d2.ToInt());
	}

	public SDateTime ChangeHour(int newHour)
	{
		return new SDateTime(Minute, newHour, Day, Month, Year);
	}

	public SDateTime ChangeHourMinute(int newHour, int minute)
	{
		return new SDateTime(minute, newHour, Day, Month, Year);
	}

	public SDateTime ChangeDayMonth(int day, int month)
	{
		return new SDateTime(Minute, Hour, day, month, Year);
	}

	public string ToString(int baseYear)
	{
		return string.Format("{0}{3} {1} {2}", Utilities.HourToTime(Hour, Minute, AMPM), Months[Month % 12].Loc(), Year + baseYear, (GameSettings.DaysPerMonth > 1) ? (" Day " + (Day + 1) + "/" + GameSettings.DaysPerMonth) : "");
	}

	public string ToTimeString(bool minutes = true)
	{
		if (!minutes)
		{
			return Utilities.HourToTime(Hour, AMPM);
		}
		return Utilities.HourToTime(Hour, Minute, AMPM);
	}

	public string ToCompactString()
	{
		return ToCompactString(1900);
	}

	public string ToCompactString(int baseYear)
	{
		return string.Format("{0} {1}", Months[Month % 12].Loc(), Year + baseYear);
	}

	public string ToExtraCompactString()
	{
		return ToExtraCompactString(1900);
	}

	public string ToExtraCompactString(int baseYear)
	{
		string text = Months[Month % 12].Loc();
		return string.Format("{0}{1}", text.Substring(0, Mathf.Min(3, text.Length)).ToUpper(), (Year + baseYear).ToString().Substring(2, 2));
	}

	public string ToCompactString2()
	{
		return ToCompactString2(1900);
	}

	public string ToCompactString2(int baseYear)
	{
		return string.Format("{2}{0} {1}", Months[Month % 12].Loc(), Year + baseYear, (GameSettings.DaysPerMonth > 1) ? ("Day " + (Day + 1) + "/" + GameSettings.DaysPerMonth + " ") : "");
	}

	public string ToVeryCompactString()
	{
		return ToVeryCompactString(1900);
	}

	public string ToVeryCompactString(int baseYear)
	{
		return string.Format("{0} {1}", (Months[Month % 12] + "Abbr").Loc(), Year + baseYear);
	}

	public string ToQuarterString()
	{
		return "Q" + (Month / 3 + 1) + " " + RealYear;
	}

	public override string ToString()
	{
		return ToString(1900);
	}

	public override int GetHashCode()
	{
		return ToInt();
	}

	public static bool operator ==(SDateTime d1, SDateTime d2)
	{
		return d1.Equals(d2);
	}

	public static bool operator !=(SDateTime d1, SDateTime d2)
	{
		return !d1.Equals(d2);
	}

	public bool Equals(SDateTime sd)
	{
		if (sd.Year == Year && sd.Month == Month && sd.Day == Day && sd.Hour == Hour)
		{
			return sd.Minute == Minute;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is SDateTime)
		{
			return Equals((SDateTime)obj);
		}
		return false;
	}

	public bool EqualsVerySimple(SDateTime sd)
	{
		if (sd.Year == Year)
		{
			return sd.Month == Month;
		}
		return false;
	}

	public bool Equals(SDateTime sd, bool simple)
	{
		if (simple)
		{
			if (sd.Year == Year && sd.Month == Month)
			{
				return sd.Day == Day;
			}
			return false;
		}
		return Equals(sd);
	}

	public bool Equals(object obj, bool simple)
	{
		object obj2;
		if ((obj2 = obj) is SDateTime)
		{
			SDateTime sd = (SDateTime)obj2;
			return Equals(sd, simple);
		}
		return false;
	}

	public static SDateTime FromString(string input)
	{
		string[] array = input.Split('-');
		int month = Convert.ToInt32(array[0]) - 1;
		int num = Convert.ToInt32(array[1]);
		return new SDateTime(month, num - 1900);
	}

	public int CompareTo(SDateTime other)
	{
		return ToInt().CompareTo(other.ToInt());
	}

	public static SDateTime Now()
	{
		if (!TimeOfDay.Instance.IsReferenceNull())
		{
			return TimeOfDay.Instance.GetDate();
		}
		return default(SDateTime);
	}

	public static SDateTime Min(params SDateTime[] times)
	{
		if (times.Length == 0)
		{
			throw new Exception("Cannot find minimum date when no dates are given");
		}
		SDateTime sDateTime = times[0];
		for (int i = 1; i < times.Length; i++)
		{
			if (times[i] < sDateTime)
			{
				sDateTime = times[i];
			}
		}
		return sDateTime;
	}

	public static SDateTime Max(params SDateTime[] times)
	{
		if (times.Length == 0)
		{
			throw new Exception("Cannot find maximum date when no dates are given");
		}
		SDateTime sDateTime = times[0];
		for (int i = 1; i < times.Length; i++)
		{
			if (times[i] > sDateTime)
			{
				sDateTime = times[i];
			}
		}
		return sDateTime;
	}

	public SDateTime Simplify()
	{
		return new SDateTime(0, 0, Day, Month, Year);
	}

	public SDateTime SimplifyMore()
	{
		return new SDateTime(0, 0, 0, Month, Year);
	}

	public SDateTime SimplifyLess()
	{
		return new SDateTime(0, Hour, Day, Month, Year);
	}

	public bool IsDistanceBigger(SDateTime time, int minutes)
	{
		return Mathf.Abs(ToInt() - time.ToInt()) >= minutes;
	}

	public static SDateTime NextMonth(int month)
	{
		SDateTime sDateTime = Now();
		if (month > sDateTime.Month)
		{
			return new SDateTime(0, 0, 0, month, sDateTime.Year);
		}
		return new SDateTime(0, 0, 0, month, sDateTime.Year + 1);
	}

	public static float GetYears(SDateTime start, SDateTime now)
	{
		return (float)(now.Year - start.Year) + ((float)(now.Month - start.Month) + ((float)(now.Day - start.Day) + ((float)(now.Hour - start.Hour) + (float)(now.Minute - start.Minute) / 60f) / 24f) / (float)GameSettings.DaysPerMonth) / 12f;
	}

	public static float GetMonths(SDateTime start, SDateTime now)
	{
		return (float)(now.Year - start.Year) * 12f + (float)(now.Month - start.Month) + ((float)(now.Day - start.Day) + ((float)(now.Hour - start.Hour) + (float)(now.Minute - start.Minute) / 60f) / 24f) / (float)GameSettings.DaysPerMonth;
	}

	public static float GetDays(SDateTime start, SDateTime now)
	{
		return ((float)(now.Year - start.Year) * 12f + (float)(now.Month - start.Month)) * (float)GameSettings.DaysPerMonth + (float)(now.Day - start.Day) + ((float)(now.Hour - start.Hour) + (float)(now.Minute - start.Minute) / 60f) / 24f;
	}

	public static float GetHours(SDateTime start, SDateTime now)
	{
		return (((float)(now.Year - start.Year) * 12f + (float)(now.Month - start.Month)) * (float)GameSettings.DaysPerMonth + (float)(now.Day - start.Day)) * 24f + (float)(now.Hour - start.Hour) + (float)(now.Minute - start.Minute) / 60f;
	}

	public static int GetMonthsFlat(SDateTime start, SDateTime now)
	{
		return (now.Year - start.Year) * 12 + (now.Month - start.Month);
	}

	public static int GetDaysFlat(SDateTime start, SDateTime now)
	{
		return ((now.Year - start.Year) * 12 + (now.Month - start.Month)) * GameSettings.DaysPerMonth + (now.Day - start.Day);
	}

	public static bool DayHasPassed(SDateTime start, SDateTime now)
	{
		if (now.Year <= start.Year && (now.Year != start.Year || now.Month <= start.Month))
		{
			if (now.Year == start.Year && now.Month == start.Month)
			{
				return now.Day > start.Day;
			}
			return false;
		}
		return true;
	}

	public static int GetHoursFlat(SDateTime start, SDateTime now)
	{
		return (((now.Year - start.Year) * 12 + (now.Month - start.Month)) * GameSettings.DaysPerMonth + (now.Day - start.Day)) * 24 + (now.Hour - start.Hour);
	}

	public static string Countdown(SDateTime now, SDateTime end)
	{
		if (GameSettings.DaysPerMonth > 1)
		{
			int num = (end.Year * 12 + end.Month) * GameSettings.DaysPerMonth + end.Day - ((now.Year * 12 + now.Month) * GameSettings.DaysPerMonth + now.Day);
			if (num == 0)
			{
				return "Today".Loc();
			}
			if (num < 0)
			{
				return "TimeDiffNotLeft".Loc("Day".LocPlural(-num));
			}
			return "TimeDiffLeft".Loc("Day".LocPlural(num));
		}
		int num2 = end.Year * 12 + end.Month - (now.Year * 12 + now.Month);
		if (num2 == 0)
		{
			return "Thismonth".Loc();
		}
		if (num2 < 0)
		{
			return "TimeDiffNotLeft".Loc("Month".LocPlural(-num2));
		}
		return "TimeDiffLeft".Loc("Month".LocPlural(num2));
	}

	public static string DateDiff(SDateTime now, SDateTime end)
	{
		float days = GetDays(now, end);
		if (days <= 0f)
		{
			return "Now".Loc();
		}
		if (days < 1f)
		{
			float num = days * 24f;
			if (num < 1f)
			{
				return "Minute".LocPlural(Mathf.FloorToInt(num * 60f));
			}
			return "Hour".LocPlural(Mathf.CeilToInt(num));
		}
		return DateDiff(Mathf.FloorToInt(days));
	}

	public static string DateDiff(int d, bool includeDays = true)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		int num2 = (num = d % GameSettings.DaysPerMonth);
		d = (d - num) / GameSettings.DaysPerMonth;
		int num3 = (num = d % 12);
		int num4 = (d - num) / 12;
		bool flag = false;
		if (num4 > 0)
		{
			flag = true;
			stringBuilder.Append("Year".LocPlural(num4));
		}
		if (num3 > 0)
		{
			if (flag)
			{
				stringBuilder.Append((num2 == 0) ? "AndSeperator".Loc() : ", ");
			}
			flag = true;
			stringBuilder.Append("Month".LocPlural(num3));
		}
		if (num2 > 0 && includeDays)
		{
			if (flag)
			{
				stringBuilder.Append("AndSeperator".Loc());
			}
			stringBuilder.Append("Day".LocPlural(num2));
		}
		return stringBuilder.ToString();
	}

	public static string DateDiff2(SDateTime now, SDateTime end, bool addOne = false)
	{
		SDateTime sDateTime = end - now;
		if (sDateTime.Year > 0)
		{
			return "Year".LocPlural(sDateTime.Year + (addOne ? 1 : 0));
		}
		if (sDateTime.Month > 0)
		{
			return "Month".LocPlural(sDateTime.Month + (addOne ? 1 : 0));
		}
		if (sDateTime.Day > 0)
		{
			return "Day".LocPlural(sDateTime.Day + (addOne ? 1 : 0));
		}
		if (sDateTime.Hour > 0)
		{
			return "Hour".LocPlural(Mathf.Max(0, sDateTime.Hour + (addOne ? 1 : 0)));
		}
		return "Minute".LocPlural(Mathf.Max(0, sDateTime.Minute + (addOne ? 1 : 0)));
	}

	public int GetSimpleOrder(SDateTime other, bool withDay)
	{
		int num;
		int value;
		if (withDay)
		{
			num = (Year * 12 + Month) * GameSettings.DaysPerMonth + Day;
			value = (other.Year * 12 + other.Month) * GameSettings.DaysPerMonth + other.Day;
		}
		else
		{
			num = Year * 12 + Month;
			value = other.Year * 12 + other.Month;
		}
		return num.CompareTo(value);
	}
}
