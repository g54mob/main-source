using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public class MultipleConditionExpression : Expression
	{
		public List<Expression> subExpressions => null;

		public MultipleConditionExpression(List<Expression> conditionExpressions)
		{
		}

		public override void GenerateIntoContainer(Container container)
		{
		}
	}
}
