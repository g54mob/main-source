using Data.CustomTypes.LimitedValue.Dependecies.Solvers;

public abstract class bdb : bdc
{
	protected bdb(DependencySolverType a, float b, float c, float d)
		: base(default(DependencySolverType), 0f, 0f, 0f)
	{
	}
}
