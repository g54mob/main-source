namespace Reactivity
{
	public interface IReactiveEffect
	{
		void Invalidate();

		void AddDependency(IReactiveDependency dependency);
	}
}
