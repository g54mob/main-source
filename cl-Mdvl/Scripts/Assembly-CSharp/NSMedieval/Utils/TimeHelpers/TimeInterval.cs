using System;
using NSEipix.Base;
using NSMedieval.Serialization;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.Utils.TimeHelpers
{
	[FVSerializableKey("TimeInterval", "")]
	public struct TimeInterval : IFVSerializable
	{
		private long timeStart;

		private long timeEnd;

		public float TimeProgress => Mathf.Clamp01(((float)(DateTime.MinutesTotal - timeStart) + DateTime.MinuteFract) / (float)DurationMinutes);

		public long DurationMinutes => timeEnd - timeStart;

		public bool HasEnded => DateTime.MinutesTotal >= timeEnd;

		public long TimeStart => timeStart;

		public long TimeEnd => timeEnd;

		public int TimeStartHours => (int)(timeStart / DateTime.MinutesInHour);

		public int HoursSinceStart => (int)(DateTime.HoursTotal - TimeStartHours);

		public int MinutesLeft => (int)(timeEnd - DateTime.MinutesTotal);

		public bool IsEndless => timeEnd == int.MaxValue;

		private WorldDate DateTime
		{
			get
			{
				if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
				{
					return null;
				}
				return GlobalSaveController.CurrentVillageData.DateAndTime;
			}
		}

		public string ToMinutesLeftString()
		{
			return UiUtils.GetTimeFormatByMinutes(Math.Max(0, MinutesLeft), isDuration: true);
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}, {2}: {3}, {4}: {5}", "timeStart", timeStart, "timeEnd", timeEnd, "DurationMinutes", DurationMinutes);
		}

		public void ResetFromNowMinutes(int durationMinutes)
		{
			timeStart = DateTime.MinutesTotal;
			if (durationMinutes == int.MaxValue)
			{
				timeEnd = 2147483647L;
			}
			else
			{
				timeEnd = timeStart + durationMinutes;
			}
		}

		public void ResetFromNowHours(int durationHours)
		{
			if (durationHours == int.MaxValue)
			{
				ResetFromNowMinutes(int.MaxValue);
				return;
			}
			int durationMinutes = GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour * durationHours;
			ResetFromNowMinutes(durationMinutes);
		}

		public void ResetFromNowDays(int days)
		{
			if (days == int.MaxValue)
			{
				ResetFromNowMinutes(int.MaxValue);
				return;
			}
			WorldDate dateAndTime = GlobalSaveController.CurrentVillageData.DateAndTime;
			int durationMinutes = dateAndTime.MinutesInHour * dateAndTime.HoursInDay * days;
			ResetFromNowMinutes(durationMinutes);
		}

		public static TimeInterval FromNowMinutes(int durationMinutes)
		{
			TimeInterval result = default(TimeInterval);
			result.ResetFromNowMinutes(durationMinutes);
			return result;
		}

		public static TimeInterval FromNowHours(int durationHours)
		{
			TimeInterval result = default(TimeInterval);
			result.ResetFromNowHours(durationHours);
			return result;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("timeStart", timeStart);
			serializer.Write("timeEnd", timeEnd);
		}

		public TimeInterval(FVDeserializer deserializer)
		{
			timeStart = deserializer.ReadLong("timeStart", 0L);
			timeEnd = deserializer.ReadLong("timeEnd", 0L);
		}
	}
}
