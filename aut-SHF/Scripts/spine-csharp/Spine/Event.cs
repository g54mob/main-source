namespace Spine
{
	public class Event
	{
		internal readonly EventData data;

		internal readonly float time;

		internal int intValue;

		internal float floatValue;

		internal string stringValue;

		internal float volume;

		internal float balance;

		public EventData Data => null;

		public float Time => 0f;

		public int Int
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float Float
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public string String
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float Volume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Balance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Event(float time, EventData data)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
