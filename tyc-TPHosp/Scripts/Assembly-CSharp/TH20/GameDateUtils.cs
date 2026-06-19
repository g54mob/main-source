using I2.Loc;

namespace TH20
{
	public static class GameDateUtils
	{
		private static readonly int[] DaysSoFarForMonth = new int[12]
		{
			0, 31, 59, 90, 120, 151, 181, 212, 243, 273,
			304, 334
		};

		public static int AsTotalMonths(this GameDate date)
		{
			return date.Year * 12 + date.Month;
		}

		public static int AsTotalDays(this GameDate date)
		{
			return date.Year * 365 + (DaysSoFarForMonth.ValidIndex(date.Month) ? DaysSoFarForMonth[date.Month] : 0) + date.Day;
		}

		public static int DaysSince(this GameDate date, GameDate dateToCompare)
		{
			return date.AsTotalDays() - dateToCompare.AsTotalDays();
		}

		public static string MonthCountToShortName(int count)
		{
			return ((12 + count % 12) % 12) switch
			{
				0 => ScriptLocalization.Misc_Months.JanAbbr_CS, 
				1 => ScriptLocalization.Misc_Months.FebAbbr_CS, 
				2 => ScriptLocalization.Misc_Months.MarAbbr_CS, 
				3 => ScriptLocalization.Misc_Months.AprAbbr_CS, 
				4 => ScriptLocalization.Misc_Months.MayAbbr_CS, 
				5 => ScriptLocalization.Misc_Months.JunAbbr_CS, 
				6 => ScriptLocalization.Misc_Months.JulAbbr_CS, 
				7 => ScriptLocalization.Misc_Months.AugAbbr_CS, 
				8 => ScriptLocalization.Misc_Months.SepAbbr_CS, 
				9 => ScriptLocalization.Misc_Months.OctAbbr_CS, 
				10 => ScriptLocalization.Misc_Months.NovAbbr_CS, 
				11 => ScriptLocalization.Misc_Months.DecAbbr_CS, 
				_ => string.Empty, 
			};
		}
	}
}
