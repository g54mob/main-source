using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Features
{
	[FeatureOrder(2)]
	internal class DefaultCompilerFeature : IFeature
	{
		private class DefaultExpressionCompiler : IExpressionCompiler
		{
			private readonly IReadOnlyList<IExpressionMiddleware> _expressionMiddleware;

			public DefaultExpressionCompiler(IReadOnlyList<IExpressionMiddleware> expressionMiddlewares)
			{
				_expressionMiddleware = expressionMiddlewares;
			}

			public T Compile<T>(Expression<T> expression) where T : class, Delegate
			{
				for (int i = 0; i < _expressionMiddleware.Count; i++)
				{
					expression = _expressionMiddleware[i].Invoke(expression);
				}
				return expression.Compile();
			}
		}

		public void OnCompiling(ICompiledHandlebarsConfiguration configuration)
		{
			configuration.ExpressionCompiler = new DefaultExpressionCompiler(configuration.ExpressionMiddlewares);
		}

		public void CompilationCompleted()
		{
		}
	}
}
