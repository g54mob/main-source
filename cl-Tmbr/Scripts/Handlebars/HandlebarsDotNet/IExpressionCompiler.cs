using System;
using System.Linq.Expressions;

namespace HandlebarsDotNet
{
	public interface IExpressionCompiler
	{
		T Compile<T>(Expression<T> expression) where T : class, Delegate;
	}
}
