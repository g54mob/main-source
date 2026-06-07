using System;
using UnityEngine;

namespace VampireSurvivors.Framework.DLC
{
	[Serializable]
	public class ReleaseDateData
	{
		[Serializable]
		public struct DateInt
		{
			public int _Day;

			public int _Month;

			public int _Year;
		}

		[Serializable]
		public struct TimeInt
		{
			public int _Hour;

			public int _Minute;

			public int _Second;
		}

		[Tooltip("Date in UK format... not American")]
		public DateInt _Date;

		[Tooltip("Time in 24hr clock format")]
		public TimeInt _Time;

		public DateTime GetUtcDateTime()
		{
			return default(DateTime);
		}

		public bool HasDatePassed()
		{
			return false;
		}
	}
}
