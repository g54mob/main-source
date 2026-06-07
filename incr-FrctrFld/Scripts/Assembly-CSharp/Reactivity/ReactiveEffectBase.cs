using System.Collections.Generic;

namespace Reactivity
{
	public abstract class ReactiveEffectBase : IReactiveEffect
	{
		private readonly List<IReactiveDependency> _dependencies;

		public void AddDependency(IReactiveDependency dependency)
		{
		}

		public abstract void Invalidate();

		public void Cleanup()
		{
		}
	}
}
