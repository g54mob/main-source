using System;
using System.Collections.Generic;

namespace Pathfinding.Util
{
	public struct GraphSnapshot : IGraphSnapshot, IDisposable
	{
		private List<IGraphSnapshot> inner;

		internal GraphSnapshot(List<IGraphSnapshot> inner)
		{
			this.inner = inner;
		}

		public void Restore(IGraphUpdateContext ctx)
		{
			for (int i = 0; i < inner.Count; i++)
			{
				inner[i].Restore(ctx);
			}
		}

		public void Dispose()
		{
			if (inner != null)
			{
				for (int i = 0; i < inner.Count; i++)
				{
					inner[i].Dispose();
				}
				inner = null;
			}
		}
	}
}
