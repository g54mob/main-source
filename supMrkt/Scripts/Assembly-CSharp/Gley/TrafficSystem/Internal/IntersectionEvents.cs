using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Gley.TrafficSystem.Internal
{
	public class IntersectionEvents
	{
		public delegate void ActiveIntersectionsChanged(List<GenericIntersection> activeIntersections);

		public static event ActiveIntersectionsChanged onActiveIntersectionsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void TriggetActiveIntersectionsChangedEvent(List<GenericIntersection> activeIntersections)
		{
		}
	}
}
