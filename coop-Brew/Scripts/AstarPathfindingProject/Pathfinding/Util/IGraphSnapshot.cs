using System;

namespace Pathfinding.Util
{
	public interface IGraphSnapshot : IDisposable
	{
		void Restore(IGraphUpdateContext ctx);
	}
}
