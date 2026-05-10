using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	public static class PhysicsAllocation
	{
		private static Dictionary<int, Collider[]> _allocations = new Dictionary<int, Collider[]>();

		public static Collider[] Get(int count)
		{
			if (_allocations.TryGetValue(count, out var value))
			{
				return value;
			}
			_allocations.Add(count, new Collider[count]);
			return _allocations[count];
		}
	}
}
