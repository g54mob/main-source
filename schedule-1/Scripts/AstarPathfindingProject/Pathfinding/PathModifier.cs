using System;

namespace Pathfinding
{
	[Serializable]
	public abstract class PathModifier : IPathModifier
	{
		[NonSerialized]
		public Seeker seeker;

		public abstract int Order { get; }

		public void Awake(Seeker seeker)
		{
		}

		public void OnDestroy(Seeker seeker)
		{
		}

		public virtual void PreProcess(Path path)
		{
		}

		public abstract void Apply(Path path);
	}
}
