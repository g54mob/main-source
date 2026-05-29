using System.Collections.Generic;

namespace Spine
{
	public class Animation
	{
		internal string name;

		internal ExposedList<Timeline> timelines;

		internal HashSet<string> timelineIds;

		internal float duration;

		public ExposedList<Timeline> Timelines
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float Duration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public string Name => null;

		public Animation(string name, ExposedList<Timeline> timelines, float duration)
		{
		}

		public void SetTimelines(ExposedList<Timeline> timelines)
		{
		}

		public bool HasTimeline(string[] propertyIds)
		{
			return false;
		}

		public void Apply(Skeleton skeleton, float lastTime, float time, bool loop, ExposedList<Event> events, float alpha, MixBlend blend, MixDirection direction)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
