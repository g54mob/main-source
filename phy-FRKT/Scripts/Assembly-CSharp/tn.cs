using Data.CustomTypes.LimitedValue.Dependecies.Solvers;

public abstract class tn : bdb
{
	protected tn(float a = 0f, float b = 100f, float c = 0f, DependencySolverType d = DependencySolverType.TakeSmallestValue)
		: base(default(DependencySolverType), 0f, 0f, 0f)
	{
	}
}
