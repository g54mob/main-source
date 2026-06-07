using System;

namespace Noesis
{
	public struct RepeatBehavior
	{
		private enum RepeatBehaviorType
		{
			IterationCount = 0,
			RepeatDuration = 1,
			Forever = 2
		}

		private RepeatBehaviorType _repeatBehaviorType;

		private float _iterationCount;

		private TimeSpanStruct _repeatDuration;

		public bool HasCount => false;

		public float Count => 0f;

		public bool HasDuration => false;

		public TimeSpan Duration => default(TimeSpan);

		public static RepeatBehavior Forever => default(RepeatBehavior);

		public RepeatBehavior(float count)
		{
			_repeatBehaviorType = default(RepeatBehaviorType);
			_iterationCount = 0f;
			_repeatDuration = default(TimeSpanStruct);
		}

		public RepeatBehavior(TimeSpan duration)
		{
			_repeatBehaviorType = default(RepeatBehaviorType);
			_iterationCount = 0f;
			_repeatDuration = default(TimeSpanStruct);
		}

		public static bool operator ==(RepeatBehavior r0, RepeatBehavior r1)
		{
			return false;
		}

		public static bool operator !=(RepeatBehavior r0, RepeatBehavior r1)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(RepeatBehavior v)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static RepeatBehavior Parse(string str)
		{
			return default(RepeatBehavior);
		}

		public static bool TryParse(string str, out RepeatBehavior result)
		{
			result = default(RepeatBehavior);
			return false;
		}
	}
}
