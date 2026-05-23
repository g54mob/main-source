using System;
using System.Runtime.CompilerServices;
using Data.CustomTypes.LimitedValue.Dependecies.Solvers;

public abstract class bda : bdc
{
	private bool srd;

	public event Action sre
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	protected bda(DependencySolverType a = DependencySolverType.TakeSmallestValue, float b = 0f, float c = 100f, float d = -1f / 0f)
		: base(default(DependencySolverType), 0f, 0f, 0f)
	{
	}

	public void iib(ref Action a)
	{
	}

	[CompilerGenerated]
	private void iie()
	{
	}

	public void ogs(ref Action a)
	{
	}
}
