using System;
using NSEipix.Base;
using NSMedieval.Serialization;

namespace NSMedieval.Utils.TimeHelpers
{
	[FVSerializableKey("Cooldown", "")]
	public struct Cooldown : IFVSerializable
	{
		private long timeEndMinutes;

		private bool useUnityTime;

		public long TimeEndMinutes => timeEndMinutes;

		public uint TimeEndHours => (uint)(timeEndMinutes / DateTime.MinutesInHour);

		public uint MinutesLeft => (uint)Math.Max(0L, timeEndMinutes - CurrentTimeMinutes);

		public bool HasEnded => MinutesLeft == 0;

		public uint HoursLeft => (uint)(MinutesLeft / DateTime.MinutesInHour);

		private long CurrentTimeMinutes
		{
			get
			{
				if (!useUnityTime)
				{
					return DateTime.MinutesTotal;
				}
				return (long)WorldTimeManager.UnityTime;
			}
		}

		private static WorldDate DateTime
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

		public Cooldown()
		{
			timeEndMinutes = 0L;
			useUnityTime = false;
		}

		public Cooldown(bool useUnityTime)
		{
			timeEndMinutes = 0L;
			this.useUnityTime = useUnityTime;
		}

		public Cooldown(long timeEndMinutes, bool useUnityTime = false)
		{
			this.timeEndMinutes = timeEndMinutes;
			this.useUnityTime = useUnityTime;
		}

		public override string ToString()
		{
			return string.Format("Cooldown ({0}: {1})", "timeEndMinutes", timeEndMinutes);
		}

		public static Cooldown FromNowMinutes(int durationMinutes, bool useUnityTime = false)
		{
			Cooldown result = new Cooldown(useUnityTime);
			result.timeEndMinutes = result.CurrentTimeMinutes + durationMinutes;
			return result;
		}

		public static Cooldown FromNowHours(int durationHours, bool useUnityTime = false)
		{
			Cooldown result = new Cooldown(useUnityTime);
			int num = GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour * durationHours;
			result.timeEndMinutes = result.CurrentTimeMinutes + num;
			return result;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("timeEndMinutes", timeEndMinutes);
			serializer.Write("useUnityTime", useUnityTime);
		}

		public Cooldown(FVDeserializer deserializer)
		{
			timeEndMinutes = deserializer.ReadLong("timeEndMinutes", 0L);
			useUnityTime = deserializer.ReadBool("useUnityTime");
		}
	}
}
