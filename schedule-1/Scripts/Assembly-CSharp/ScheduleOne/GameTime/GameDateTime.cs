using System;
using ScheduleOne.Persistence.Datas;

namespace ScheduleOne.GameTime
{
	[Serializable]
	public struct GameDateTime
	{
		public int elapsedDays;

		public int time;

		public GameDateTime(int _elapsedDays, int _time)
		{
			elapsedDays = 0;
			time = 0;
		}

		public GameDateTime(int _minSum)
		{
			elapsedDays = 0;
			time = 0;
		}

		public GameDateTime(GameDateTimeData data)
		{
			elapsedDays = 0;
			time = 0;
		}

		public int GetMinSum()
		{
			return 0;
		}

		public GameDateTime AddMins(int mins)
		{
			return default(GameDateTime);
		}

		public GameDateTime GetCopy()
		{
			return default(GameDateTime);
		}

		public static GameDateTime operator +(GameDateTime a, GameDateTime b)
		{
			return default(GameDateTime);
		}

		public static GameDateTime operator -(GameDateTime a, GameDateTime b)
		{
			return default(GameDateTime);
		}

		public static bool operator >(GameDateTime a, GameDateTime b)
		{
			return false;
		}

		public static bool operator <(GameDateTime a, GameDateTime b)
		{
			return false;
		}
	}
}
