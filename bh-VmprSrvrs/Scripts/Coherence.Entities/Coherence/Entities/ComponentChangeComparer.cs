using System.Collections.Generic;

namespace Coherence.Entities
{
	internal class ComponentChangeComparer : IComparer<ComponentChange>
	{
		internal static readonly ComponentChangeComparer Cached;

		public int Compare(ComponentChange x, ComponentChange y)
		{
			return 0;
		}
	}
}
