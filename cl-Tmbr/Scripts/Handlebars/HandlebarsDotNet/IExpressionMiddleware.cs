using System;
using System.Linq.Expressions;

namespace HandlebarsDotNet
{
	public interface IExpressionMiddleware
	{
		Expression<T> Invoke<T>(Expression<T> expression) where T : Delegate;
	}
}
