using System;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct SpeedrunScore
	{
		[Key(0)]
		public TimeSpan Duration { get; private set; }

		[IgnoreMember]
		public int Milliseconds
		{
			get
			{
				double totalMilliseconds = Duration.TotalMilliseconds;
				if (totalMilliseconds > 2147483647.0 || totalMilliseconds < -2147483648.0)
				{
					return int.MaxValue;
				}
				return (int)totalMilliseconds;
			}
		}

		public static SpeedrunScore FromSeconds(float seconds)
		{
			return new SpeedrunScore(new TimeSpan((long)(seconds * 10000000f)));
		}

		public static SpeedrunScore FromMilliseconds(int milliseconds)
		{
			return new SpeedrunScore(new TimeSpan((long)milliseconds * 10000L));
		}

		public SpeedrunScore(TimeSpan ts)
		{
			Duration = ts;
		}

		public override string ToString()
		{
			return $"{Math.Floor(Duration.TotalHours):00}:{Duration.Minutes:00}:{Duration.Seconds:00}";
		}

		public string ToMonospacedString()
		{
			return $"<mspace=0.8em>{Math.Floor(Duration.TotalHours):00}</mspace>:<mspace=0.8em>{Duration.Minutes:00}</mspace>:<mspace=0.8em>{Duration.Seconds:00}</mspace>";
		}

		public bool Equals(SpeedrunScore other)
		{
			return Duration.Equals(other.Duration);
		}
	}
}
