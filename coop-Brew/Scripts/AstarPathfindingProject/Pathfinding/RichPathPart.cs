using Pathfinding.Pooling;

namespace Pathfinding
{
	public abstract class RichPathPart : IAstarPooledObject
	{
		public abstract void OnEnterPool();
	}
}
