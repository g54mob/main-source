using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class HashParametersExpression : HandlebarsExpression
	{
		public Dictionary<string, Expression> Parameters { get; }

		public override ExpressionType NodeType => (ExpressionType)6011;

		public override Type Type => typeof(HashParameterDictionary);

		public HashParametersExpression(Dictionary<string, Expression> parameters)
		{
			Parameters = parameters;
		}
	}
}
