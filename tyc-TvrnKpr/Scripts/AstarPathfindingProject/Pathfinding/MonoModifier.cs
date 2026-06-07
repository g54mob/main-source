using System;

namespace Pathfinding
{
	[Serializable]
	public abstract class MonoModifier : VersionedMonoBehaviour, IPathModifier
	{
		[NonSerialized]
		public Seeker seeker;

		public abstract int Order { get; }

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		public virtual void PreProcess(Path path)
		{
		}

		public abstract void Apply(Path path);
	}
}
