using System;

namespace DepthFirstScheduler
{
	public interface IFunctor<T>
	{
		T GetResult();

		Exception GetError();

		ExecutionStatus Execute();
	}
}
