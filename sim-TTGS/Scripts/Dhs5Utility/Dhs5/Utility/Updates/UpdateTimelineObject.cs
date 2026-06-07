using System.Collections.Generic;
using Dhs5.Utility.Databases;
using UnityEngine;

namespace Dhs5.Utility.Updates
{
	public class UpdateTimelineObject : BaseDataContainerScriptableElement, IUpdateTimeline
	{
		[SerializeField]
		private EUpdateChannel m_channel;

		[SerializeField]
		private int m_minutesDuration = 1;

		[SerializeField]
		private float m_secondsDuration;

		[SerializeField]
		private bool m_loop;

		[SerializeField]
		private float m_timescale = 1f;

		[SerializeField]
		private List<IUpdateTimeline.Event> m_events;

		public EUpdateChannel UpdateChannel => m_channel;

		public float Duration => (float)m_minutesDuration * 60f + m_secondsDuration;

		public bool Loop => m_loop;

		public float Timescale => m_timescale;

		public IEnumerable<IUpdateTimeline.Event> GetSortedEvents()
		{
			List<IUpdateTimeline.Event> list = new List<IUpdateTimeline.Event>(m_events);
			list.Sort((IUpdateTimeline.Event e1, IUpdateTimeline.Event e2) => e1.normalizedTime.CompareTo(e2.normalizedTime));
			return list;
		}
	}
}
