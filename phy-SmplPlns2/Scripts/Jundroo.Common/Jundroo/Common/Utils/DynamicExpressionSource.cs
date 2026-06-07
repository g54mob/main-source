using System;
using Jundroo.Common.Expressions;

namespace Jundroo.Common.Utils
{
	public class DynamicExpressionSource : IDynamicExpressionSource
	{
		private Context _expressionContext;

		public DynamicExpressionSource(Context expressionContext)
		{
			_expressionContext = expressionContext;
		}

		public Func<float> GetFloatExpression(string expression)
		{
			return Parser.Process<float>(expression, _expressionContext);
		}

		public Func<string> GetStringExpression(string expression)
		{
			return Parser.Process<string>(expression, _expressionContext);
		}
	}
}
