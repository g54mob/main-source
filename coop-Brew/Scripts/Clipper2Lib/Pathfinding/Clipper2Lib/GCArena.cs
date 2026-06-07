using System;
using System.Collections.Generic;

namespace Pathfinding.Clipper2Lib
{
	internal class GCArena<T> where T : class, IDisposable, new()
	{
		private List<T> arena;

		private int index;

		public void Reclaim()
		{
		}

		public T Get()
		{
			return null;
		}
	}
}
