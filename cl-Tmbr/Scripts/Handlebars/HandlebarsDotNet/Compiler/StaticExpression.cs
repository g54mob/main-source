using System;
using System.Linq.Expressions;

namespace HandlebarsDotNet.Compiler
{
	internal class StaticExpression : HandlebarsExpression
	{
		private readonly string _value;

		public override ExpressionType NodeType => (ExpressionType)6000;

		public override Type Type => typeof(void);

		public string Value => _value;

		public StaticExpression(string value)
		{
			_value = value;
		}
	}
}
