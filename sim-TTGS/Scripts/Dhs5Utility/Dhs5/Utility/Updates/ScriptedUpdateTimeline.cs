using System.Collections.Generic;

namespace Dhs5.Utility.Updates
{
	public readonly struct ScriptedUpdateTimeline : IUpdateTimeline
	{
		private readonly int m_uid;

		private readonly EUpdateChannel m_updateChannel;

		private readonly float m_duration;

		private readonly bool m_loop;

		private readonly float m_timescale;

		private readonly List<IUpdateTimeline.Event> m_events;

		public int UID => m_uid;

		public EUpdateChannel UpdateChannel => m_updateChannel;

		public float Duration => m_duration;

		public bool Loop => m_loop;

		public float Timescale => m_timescale;

		public ScriptedUpdateTimeline(EUpdateChannel updateChannel, float duration, bool loop = false, float timescale = 1f, List<IUpdateTimeline.Event> events = null, int uid = 0)
		{
			m_uid = uid;
			m_updateChannel = updateChannel;
			m_duration = duration;
			m_loop = loop;
			m_timescale = timescale;
			m_events = events;
		}

		public IEnumerable<IUpdateTimeline.Event> GetSortedEvents()
		{
			if (m_events != null)
			{
				List<IUpdateTimeline.Event> list = new List<IUpdateTimeline.Event>(m_events);
				list.Sort((IUpdateTimeline.Event e1, IUpdateTimeline.Event e2) => e1.normalizedTime.CompareTo(e2.normalizedTime));
				return list;
			}
			return null;
		}
	}
}
