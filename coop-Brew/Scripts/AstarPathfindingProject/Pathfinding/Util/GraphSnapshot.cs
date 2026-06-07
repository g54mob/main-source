using System;
using System.Collections.Generic;

namespace Pathfinding.Util
{
	public struct GraphSnapshot : IGraphSnapshot, IDisposable
	{
		private List<IGraphSnapshot> inner;

		internal GraphSnapshot(List<IGraphSnapshot> inner)
		{
			this.inner = null;
		}

		public void Restore(IGraphUpdateContext ctx)
		{
		}

		public void Dispose()
		{
		}
	}
}
