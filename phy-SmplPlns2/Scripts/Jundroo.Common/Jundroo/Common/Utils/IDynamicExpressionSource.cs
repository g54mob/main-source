using System;

namespace Jundroo.Common.Utils
{
	public interface IDynamicExpressionSource
	{
		Func<float> GetFloatExpression(string expression);

		Func<string> GetStringExpression(string expression);
	}
}
